using Auction.DataAccess.Infrastructure.Repository;
using Auction.Domain.Contracts.Services;
using Auction.Domain.Dtos.Request;
using Auction.Domain.Dtos.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly AuctionDbContext _dbContext;
        private readonly ITokenService _service;

        public LoginService(AuctionDbContext dbContext, ITokenService service)
        {
            _dbContext = dbContext;
            _service = service;
        }
        public async Task<LoginResponseDto> GetUserAsync(UserCredentialsDto request)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(i => i.UserName == request.UserName && i.Password == request.PassWord);

                if (user != null)
                {
                    return _service.GetToken(request);
                }
                else
                {
                    return new LoginResponseDto
                    {
                        Errors = new[]
                        {
                        "Incorrect credentials"
                    }
                    };
                }
            }
            catch (Exception)
            {
                return new LoginResponseDto
                {
                    Errors = new[]
                    {
                        "Unhandler Error"
                    }
                };
            }
        }
    }
}
