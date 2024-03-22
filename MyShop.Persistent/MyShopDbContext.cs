using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain;
using MyShop.Domain.AggregateModels.UserAggregate.Models;
using MyShop.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Persistent
{
    public class MyShopDbContext : DbContext, IUnitOfWork
    {
        public MyShopDbContext(DbContextOptions<MyShopDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Role>().ToTable("Roles");

            modelBuilder.Entity<IdentityUserClaim<long>>().ToTable("UserClaims");

            modelBuilder.Entity<IdentityUserLogin<long>>().ToTable("UserLogins");

            modelBuilder.Entity<IdentityUserToken<long>>().ToTable("UserTokens");

            modelBuilder.Entity<IdentityRoleClaim<long>>().ToTable("RoleClaims");

            modelBuilder.Entity<IdentityUserRole<long>>().ToTable("UserRoles");
        }
        public async Task CommitAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
