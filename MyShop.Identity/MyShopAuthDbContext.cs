using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Identity
{
    public class MyShopAuthDbContext : IdentityDbContext<MyShopUser, IdentityRole<long>, long>
    {
        public MyShopAuthDbContext(DbContextOptions<MyShopAuthDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MyShopUser>(b =>
            {
                b.ToTable("AspNetUsers");
            });

            modelBuilder.Entity<IdentityUserClaim<long>>(b =>
            {
                b.ToTable("AspNetUserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<long>>(b =>
            {
                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity<IdentityUserToken<long>>(b =>
            {
                b.ToTable("AspNetUserTokens");
            });

            modelBuilder.Entity<IdentityUserRole<long>>(b =>
            {
                b.ToTable("AspNetRoles");
            });

            modelBuilder.Entity<IdentityRoleClaim<long>>(b =>
            {
                b.ToTable("AspNetRoleClaims");
            });

            modelBuilder.Entity<IdentityUserRole<long>>(b =>
            {
                b.ToTable("AspNetUserRoles");
            });
        }
    }
}
