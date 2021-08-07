using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Infrastructure.Models
{
    public class RoleAction : EntityBaseModel
    {
        public string Name { get; set; }
        public int UserRoleId { get; set; }
    }
}
