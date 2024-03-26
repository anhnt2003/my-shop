using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShop.Identity;
using MyShop.Identity.Services.Impls;
using MyShop.Identity.Services.Interfaces;

namespace MyShop.Api.Extensions
{
    public static class AddIdentityExtension
    {
        public static void AddConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyShopAuthDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("MyShopDb"),
                    b => b.MigrationsAssembly("MyShop.Api"));
            });

            services.AddIdentity<MyShopUser, IdentityRole<long>>(o =>
            {
                o.User.RequireUniqueEmail = false;
                o.ClaimsIdentity.UserIdClaimType = "Id";
            })
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<MyShopAuthDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IAuthService, AuthService>();
        }
        public static void AddConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opts =>
                {
                    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddGoogle(opts =>
                {
                    opts.ClientId = configuration["Authentication:Google:ClientId"];
                    opts.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                    opts.CallbackPath = "/api/auth/signin-google-callback";
                })
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Authentication:Jwt:ValidIssuer"],
                        ValidAudience = configuration["Authentication:Jwt:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Jwt:Secret"]))
                    };
                });
            services.AddAuthorization();

            services.AddSingleton(sp => new GoogleHandler(
                configuration["Authentication:Google:ClientId"]
            ));
            
            services.AddSingleton(sp => new JwtHandler(
                configuration["Authentication:Jwt:ValidIssuer"],
                configuration["Authentication:Jwt:ValidAudience"],
                configuration["Authentication:Jwt:Secret"]
            ));
        }
    }
}
