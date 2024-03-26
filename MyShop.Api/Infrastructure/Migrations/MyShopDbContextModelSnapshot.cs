﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyShop.Persistent;

#nullable disable

namespace MyShop.Api.Infrastructure.Migrations
{
    [DbContext(typeof(MyShopDbContext))]
    partial class MyShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyShop.Domain.AggregateModels.UserAggregate.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Avatar");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("Email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("FullName");

                    b.Property<string>("PasswordHasded")
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("PasswordHasded");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("PhoneNumber");

                    b.Property<bool>("TwoFactorAuthEnable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("TwoFactorAuthEnable");

                    b.Property<string>("TwoFactorSecretKey")
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("TwoFactorSecretKey");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("MyShop.Domain.AggregateModels.UserAggregate.Models.User", b =>
                {
                    b.OwnsMany("MyShop.Domain.AggregateModels.UserAggregate.Models.UserRole", "Roles", b1 =>
                        {
                            b1.Property<long>("RoleId")
                                .HasColumnType("BIGINT");

                            b1.Property<long>("UserId")
                                .HasColumnType("BIGINT");

                            b1.Property<long>("BranchId")
                                .HasColumnType("BIGINT");

                            b1.HasKey("RoleId", "UserId", "BranchId");

                            b1.HasIndex("UserId");

                            b1.ToTable("UserRoles", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}