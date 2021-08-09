using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Infrastructure.Models
{
    public enum RoleType
    {
        Administrator = 1,
        Regular = 2
    }
    public class UserRole : EntityBaseModel
    {
        public RoleType RoleType { get; set; }
        public virtual IEnumerable<RoleAction> RoleActions { get; set; }
    }
}
