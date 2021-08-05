using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Models
{
    public class Product : EntityBaseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string UserCreator { get; set; }
        public int? AuctionId { get; set; }
    }
}
