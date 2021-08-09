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
            modelBuilder.Entity<User>().Property(i => i.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<User>().HasOne<UserRole>().WithOne().HasForeignKey<User>(i => i.UserRoleId);
            //modelBuilder.Entity<UserRole>().HasMany<RoleAction>().WithOne().HasForeignKey(i => i.UserRoleId);

            modelBuilder.Entity<Product>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<UserRole>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RoleAction>().Property(i => i.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<RoleAction>().HasData(new List<RoleAction>(){ 
               new RoleAction
                           {
                               Name = "Products"
                           },
                          new RoleAction
                          {
                              Name = "AuctionEdit",
                              UserRoleId = 2
                          },
                           new RoleAction
                          {
                              Name = "ProductsDetail",
                              UserRoleId = 2
                          },

                               new RoleAction
                           {
                               Name = "Products"
                           },
                          new RoleAction
                          {
                              Name = "AuctionEdit",
                              UserRoleId = 2
                          },
                           new RoleAction
                          {
                              Name = "ProductsDetail",
                              UserRoleId = 2
                          },
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
            });

            modelBuilder.Entity<UserRole>().HasData(new List<UserRole>()
            {
                new UserRole
            {
                Id = 2,
                RoleType = RoleType.Administrator,
            },
                new UserRole
                    {
                      Id = 1,
                      RoleType = RoleType.Regular,
                    },
            });


            modelBuilder.Entity<User>().HasData(new List<User>() {
                new User
                {
                    Id=1,
                    UserRoleId = 2,
                    Name = "GUESS",
                    UserName="user1",
                    Password = "user1"

                },
                 new User
                {
                     Id=2,
                     UserRoleId = 2,
                    Name = "Admin",
                    UserName="admin",
                    Password = "admin",


                }
            });

            modelBuilder.Entity<Product>().HasData(new List<Product>() {

                new Product
                {
                    Id = 1,
                    Name = "Mustang",
                    ImageUrl = "https://i.picsum.photos/id/866/200/300.jpg?hmac=rcadCENKh4rD6MAp6V_ma-AyWv641M4iiOpe1RyFHeI",
                    Description = "old card",
                    Price = 40000,
                     UserCreator = "user2"
                },
                  new Product
                {
                    Id = 2,
                    Name = "Rolex",
                    ImageUrl = "https://i.picsum.photos/id/866/200/300.jpg?hmac=rcadCENKh4rD6MAp6V_ma-AyWv641M4iiOpe1RyFHeI",
                    Description = "Watch",
                    Price = 10000,
                     UserCreator = "user2"
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
