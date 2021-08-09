using Auction.DataAccess.Infrastructure.Repository;
using Auction.Domain.Core.Config;
using Auction.Domain.Core.Exceptions;
using Auction.Domain.Dtos;
using Auction.Domain.Dtos.Configurations;
using Auction.Domain.Dtos.Response;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Auction.Services.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvcCore(p =>
            {
                // policy for requiring Authorization by default
                var policy = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser().Build();
                p.Filters.Add(new AuthorizeFilter(policy));

            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = c =>
                {
                    var errors = c.ModelState.Values.Where(v => v.Errors.Count > 0)
                                    .SelectMany(v => v.Errors).Select(p => p.ErrorMessage);

                    var result = new FailedOperationResult
                    {
                        Title = "Error",
                        Status = (int)HttpStatusCode.BadRequest,
                        Errors = errors,
                        TraceId = c.HttpContext.TraceIdentifier
                    };

                    return new BadRequestObjectResult(result);
                };
            }).AddApiExplorer();

            var tokenConfiguration = Configuration.GetSection("JWToken").Get<TokenConfiguration>();

            services.AddSingleton(tokenConfiguration);

            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfiguration.HasherKey));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = tokenConfiguration.ValidateAudience,
                    ValidateAudience = tokenConfiguration.ValidateAudience,
                    ValidIssuer = tokenConfiguration.ValidIssuer,
                    ValidAudience = tokenConfiguration.ValidAudience,
                    ValidateLifetime = tokenConfiguration.ValidateLifetime,
                    IssuerSigningKey = mySecurityKey,
                    ValidateIssuer = true
                };
            });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = System.AppDomain.CurrentDomain.FriendlyName, Version = "v1" });
            });

            services.AddControllers();

            services.AddDbContext<AuctionDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<CoreModule>();
        }

        public static void UseAPIErrorHandling(IApplicationBuilder action)
        {
            action.Run(
                   async context =>
                   {
                       var ex = context.Features.Get<IExceptionHandlerFeature>();
                       context.Response.ContentType = "application/json";
                       var failedResponse = new FailedOperationResult
                       {
                           Title = "Error",
                           Status = context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError,
                           TraceId = context.Request.HttpContext.TraceIdentifier
                       };

                       if (ex != null)
                       {
                           var errors = new List<string>();
                           if (ex.Error is DomainGlobalException exception)
                           {
                               failedResponse.Status = context.Response.StatusCode = (int)exception.StatusCode;
                               errors.Add(exception.Message);
                           }
                           else
                           {
                               errors.Add(ex.Error.Message);
#if DEBUG
                               errors.Add(ex.Error.StackTrace);
#endif
                           }
                           failedResponse.Errors = errors;
                       }
                       else
                       {
                           failedResponse.Detail = "Unhandler Exception";
                       }

                       await context.Response.WriteAsync(JsonSerializer.Serialize(failedResponse, Domain.Core.Helpers.JsonHelper.GetSerializerOptions()));
                   });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auction.Services.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(UseAPIErrorHandling);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
