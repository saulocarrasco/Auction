using Auction.Domain.Dtos.Request;
using Auction.Domain.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Services
{
    public interface ITokenService
    {
        LoginResponseDto GetToken(UserCredentialsDto userIdentityDto);
    }
}
