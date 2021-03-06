using Core.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Extensions
{

    /// <summary>
    /// Klasa zarządzająca wprowadzeniem wszystkich potrzebnych elementów do funkcjonowania Identity.
    /// Klasa również przypisuje JWT jako sposób autentykacji
    /// </summary>
    public static class IdentityServiceExtensions
    {
        /// <summary>
        /// Dodaje serwis identyfikujący użytkowników.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            //Adds an identity system for App User
            var builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType, services);
            builder.AddEntityFrameworkStores<AppDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();


            //SignInManager relieas at authentication 
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;

                //options.SignIn.RequireConfirmedEmail = true;
            });
            return services;
        }
    }
}
