using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dtos.Response
{
    public class OperationResultDto
    {
        public bool IsSucess { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
