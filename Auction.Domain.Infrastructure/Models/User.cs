using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Infrastructure.Models
{
    public class User : EntityBaseModel
    {
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public BitConfiguration BitConfiguration { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual IEnumerable<Offer> Auctions { get; set; }
    }
}
