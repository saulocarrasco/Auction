using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Models
{
    public class Bit : EntityBaseModel
    {
        public int UserId { get; set; }
        public decimal MaximumBidAmount { get; set; }
        public bool AutoBidding { get; set; }
    }
}
