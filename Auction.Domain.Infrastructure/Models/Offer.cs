using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Infrastructure.Models
{
    public class Offer : EntityBaseModel
    {
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public Product Product { get; set; }
    }
}
