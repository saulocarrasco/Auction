using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Infrastructure.Models
{
    public class BitConfiguration : EntityBaseModel
    {
        public int MaxAmount { get; set; }
        public int UserId { get; set; }
    }
}
