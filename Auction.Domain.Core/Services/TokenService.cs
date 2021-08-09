using Auction.Domain.Core.Exceptions;
using Auction.Domain.Core.Services;
using Auction.Domain.Dtos.Configurations;
using Auction.Domain.Dtos.Request;
using Auction.Domain.Dtos.Response;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenConfiguration _jwtConfiguration;

        public TokenService(TokenConfiguration appConfiguration)
        {
            _jwtConfiguration = appConfiguration;
        }

        public LoginResponseDto GetToken(UserCredentialsDto userIdentityDto)
        {
            if (userIdentityDto is null)
            {
                throw new DomainGlobalException(nameof(userIdentityDto), System.Net.HttpStatusCode.BadRequest);
            }

            var expiresAt = DateTimeOffset.Now.AddMinutes(_jwtConfiguration.TokenDuration);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sid, userIdentityDto.UserName),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, expiresAt.ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, _jwtConfiguration.ValidAudience),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtConfiguration.ValidIssuer),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.HasherKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(new JwtHeader(signingCredentials), new JwtPayload(claims));

            var output = new LoginResponseDto
            {
                IsSuccess = true,
                ExpiresAt = expiresAt,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return output;
        }

    }
}
