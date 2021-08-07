using Auction.Domain.Infrastructure.Models;
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
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new List<User>() {
                new User
                {
                    Name = "GUESS",
                    UserName="user1",
                    Password = "user1",
                    UserRole = new UserRole
                    {
                      Id = 1,
                      RoleType = RoleType.Regular,
                      RoleActions = new List<RoleAction>()
                      {
                          new RoleAction
                          {
                              Name = "Products",
                              UserRoleId = 1
                          },
                           new RoleAction
                          {
                              Name = "ProductsDetail",
                              UserRoleId = 1
                          },
                           new RoleAction
                           {
                               Name = "AutoBit"
                           }
                      }
                    },

                },
                 new User
                {
                    Name = "Admin",
                    UserName="admin",
                    Password = "admin",
                    UserRole = new UserRole
                    {
                      Id = 1,
                      RoleType = RoleType.Administrator,
                      RoleActions = new List<RoleAction>()
                      {
                             new RoleAction
                           {
                               Name = "Products"
                           },
                          new RoleAction
                          {
                              Name = "AuctionEdit",
                              UserRoleId = 1
                          },
                           new RoleAction
                          {
                              Name = "ProductsDetail",
                              UserRoleId = 1
                          }
                      }
                    },

                }
            });

            modelBuilder.Entity<Product>().HasData(new List<Product>() {

                new Product
                {
                    Name = "Mustang",
                    ImageUrl = "https://i.picsum.photos/id/866/200/300.jpg?hmac=rcadCENKh4rD6MAp6V_ma-AyWv641M4iiOpe1RyFHeI",
                    Description = "old card",
                    Price = 40000,
                     UserCreator = ""
                },

            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bit> Bits { get; set; }
        public DbSet<Offer> Sales { get; set; }
    }
}
