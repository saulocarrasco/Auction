using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Dtos.Request
{
    public class CreateBitRequestDto
    {
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
        public bool AutoBit { get; set; }
        public decimal MaximanAmount { get; set; }
    }
}
