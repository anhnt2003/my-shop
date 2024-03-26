using Microsoft.EntityFrameworkCore;
using MyShop.Domain;
using MyShop.Domain.AggregateModels.RoleAggregate.Repository;
using MyShop.Domain.AggregateModels.UserAggregate.Repository;
using MyShop.Persistent;
using MyShop.Persistent.Repositories;

namespace MyShop.Api.Extensions
{
    public static class AddPersistenceExtension
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyShopDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyShopDb"),
                    b => b.MigrationsAssembly("MyShop.Api"));
            });

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MyShopDbContext>());
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
