using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dtos.Response
{
    public class LoginResponseDto : OperationResultDto
    {
        public string Token { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
    }
}
