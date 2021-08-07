using Auction.Domain.Contracts.Services;
using Auction.Domain.Core.Services;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Domain.Core.Config
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.Register(c =>
            //{
            //    var config = c.Resolve<IConfiguration>();

            //    var opt = new DbContextOptionsBuilder<AuctionDbContext>();
            //    opt.UseSqlServer(config.GetConnectionString("Default"));

            //    return new AuctionDbContext(opt.Options);
            //}).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<TokenService>().As<ITokenService>();
            builder.RegisterType<LoginService>().As<ILoginService>();

            // Scan an assembly for components
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                    .Where(t => t.Name.EndsWith("Validator"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}
