﻿// <auto-generated />
using System;
using ChurchMS.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChurchMS.Persistence.Migrations
{
    [DbContext(typeof(ChurchMSContext))]
    [Migration("20241209134331_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChurchMS.Domain.Entites.Account", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");

                    b.HasData(
                        new
                        {
                            Id = "0283150F-5BB1-4DF2-87C5-AC3553384A1C",
                            CreatedAt = new DateTime(2024, 12, 9, 13, 43, 30, 868, DateTimeKind.Utc).AddTicks(8980),
                            CreatedBy = "Self",
                            ModifiedAt = new DateTime(2024, 12, 9, 13, 43, 30, 868, DateTimeKind.Utc).AddTicks(8983),
                            ModifiedBy = "Self",
                            Password = "PlainPassword",
                            UserName = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.AccountRoles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("AccountRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = "0283150F-5BB1-4DF2-87C5-AC3553384A1C",
                            CreatedAt = new DateTime(2024, 12, 9, 13, 43, 30, 869, DateTimeKind.Utc).AddTicks(895),
                            CreatedBy = "Self",
                            ModifiedAt = new DateTime(2024, 12, 9, 13, 43, 30, 869, DateTimeKind.Utc).AddTicks(897),
                            ModifiedBy = "Self",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsHidden")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 9, 13, 43, 30, 869, DateTimeKind.Utc).AddTicks(4067),
                            CreatedBy = "Self",
                            IsHidden = true,
                            ModifiedAt = new DateTime(2024, 12, 9, 13, 43, 30, 869, DateTimeKind.Utc).AddTicks(4069),
                            ModifiedBy = "Self",
                            Name = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.RolePermissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Permission")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 9, 13, 43, 30, 869, DateTimeKind.Utc).AddTicks(5142),
                            CreatedBy = "Self",
                            ModifiedAt = new DateTime(2024, 12, 9, 13, 43, 30, 869, DateTimeKind.Utc).AddTicks(5142),
                            ModifiedBy = "Self",
                            Permission = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DistinctiveSign")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DistrictId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.Account", b =>
                {
                    b.HasOne("ChurchMS.Domain.Entites.Role", null)
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.AccountRoles", b =>
                {
                    b.HasOne("ChurchMS.Domain.Entites.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChurchMS.Domain.Entites.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.District", b =>
                {
                    b.HasOne("ChurchMS.Domain.Entites.City", "City")
                        .WithMany("District")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.RolePermissions", b =>
                {
                    b.HasOne("ChurchMS.Domain.Entites.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.Street", b =>
                {
                    b.HasOne("ChurchMS.Domain.Entites.District", "District")
                        .WithMany("Street")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.City", b =>
                {
                    b.Navigation("District");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.District", b =>
                {
                    b.Navigation("Street");
                });

            modelBuilder.Entity("ChurchMS.Domain.Entites.Role", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("RolePermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
