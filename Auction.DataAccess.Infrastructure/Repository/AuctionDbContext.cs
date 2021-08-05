using Auction.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DataAccess.Infrastructure.Repository
{
    public class AuctionDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bit> Bits { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
