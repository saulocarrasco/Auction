using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Models
{
    public class UserRole : EntityBaseModel
    {
        public string Name { get; set; }
        public virtual IEnumerable<RoleAction> RoleActions { get; set; }
    }
}
