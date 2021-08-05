using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Models
{
    public class User : EntityBaseModel
    {
        public int UserRoleId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public virtual Bit UserRole { get; set; }
        public virtual IEnumerable<Sale> Auctions { get; set; }
    }
}
