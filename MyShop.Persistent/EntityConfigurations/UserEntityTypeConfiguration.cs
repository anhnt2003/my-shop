using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.AggregateModels.UserAggregate.Models;

namespace MyShop.Persistent.EntityConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(p => p.Id);

        builder.Ignore(b => b.DomainEvents);

        builder.Property(p => p.UserName)
            .HasColumnName(nameof(User.UserName))
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(p => p.PasswordHasded)
            .HasColumnName(nameof(User.PasswordHasded))
            .HasColumnType("VARCHAR(255)")
            .IsRequired(false);

        builder.Property(p => p.FullName)
            .HasColumnName(nameof(User.FullName))
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(p => p.PhoneNumber)
            .HasColumnName(nameof(User.PhoneNumber))
            .HasColumnType("VARCHAR(255)")
            .IsRequired(false);

        builder.Property(p => p.Email)
            .HasColumnName(nameof(User.Email))
            .HasColumnType("VARCHAR(255)")
            .IsRequired();

        builder.Property(p => p.Avatar)
            .HasColumnName(nameof(User.Avatar))
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(p => p.TwoFactorAuthEnable)
            .HasColumnName(nameof(User.TwoFactorAuthEnable))
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(p => p.TwoFactorSecretKey)
            .HasColumnName(nameof(User.TwoFactorSecretKey))
            .HasColumnType("VARCHAR(255)")
            .IsRequired(false);

        builder.Property(p => p.CreatedDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();
        
        builder.OwnsMany(p => p.Roles,
            x =>
            {
                x.ToTable("UserRoles");
                x.WithOwner().HasForeignKey(e => e.UserId);

                x.Property(e => e.RoleId)
                    .HasColumnType("BIGINT")
                    .IsRequired();

                x.Property(e => e.UserId)
                    .HasColumnType("BIGINT")
                    .IsRequired();

                x.Property(e => e.BranchId)
                    .HasColumnType("BIGINT")
                    .IsRequired();

                x.HasKey(k => new
                {
                    k.RoleId,
                    k.UserId,
                    k.BranchId
                });
            });
    }
}