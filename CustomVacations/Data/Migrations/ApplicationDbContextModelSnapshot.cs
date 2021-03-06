﻿// <auto-generated />
using CustomVacations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CustomVacations.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomVacations.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationCart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Applicationuserid");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.HasKey("id");

                    b.HasIndex("Applicationuserid")
                        .IsUnique()
                        .HasFilter("[Applicationuserid] IS NOT NULL");

                    b.ToTable("VacationCarts");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationCategory", b =>
                {
                    b.Property<string>("CategoryName")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetDate()");

                    b.Property<DateTime?>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("CategoryName");

                    b.ToTable("vacationCategories");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerName");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<string>("DestinationDescription");

                    b.Property<string>("DreamDestination");

                    b.Property<string>("VacationCategoryCategoryName");

                    b.Property<string>("VacationModelName");

                    b.Property<decimal>("budget");

                    b.Property<string>("email");

                    b.Property<double>("phoneNumber");

                    b.HasKey("ID");

                    b.HasIndex("VacationCategoryCategoryName");

                    b.ToTable("VacationModels");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationModelVacationCart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<int>("Quantity");

                    b.Property<int>("VacationCartId");

                    b.Property<int>("vacationModelId");

                    b.HasKey("id");

                    b.HasIndex("VacationCartId");

                    b.HasIndex("vacationModelId");

                    b.ToTable("VacationModelCarts");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationOrder", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("streetaddress");

                    b.HasKey("id");

                    b.ToTable("VacationOrder");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationOrderDestinationDetails", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Budget");

                    b.Property<DateTime?>("DateCreated");

                    b.Property<DateTime?>("DateLastModified");

                    b.Property<int>("Quantity");

                    b.Property<Guid>("VacationOrderId");

                    b.Property<string>("destination");

                    b.Property<string>("destinationdescription");

                    b.HasKey("id");

                    b.HasIndex("VacationOrderId");

                    b.ToTable("VacationOrderDestinationDetails");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationSuggestions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Attractions");

                    b.Property<string>("BestTimeToGo");

                    b.Property<string>("Destination");

                    b.Property<string>("VacationCategoryName");

                    b.HasKey("id");

                    b.ToTable("GetVacationSuggestions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationCart", b =>
                {
                    b.HasOne("CustomVacations.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("VacationCart")
                        .HasForeignKey("CustomVacations.Models.VacationCart", "Applicationuserid");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationModel", b =>
                {
                    b.HasOne("CustomVacations.Models.VacationCategory", "VacationCategory")
                        .WithMany("VacationModels")
                        .HasForeignKey("VacationCategoryCategoryName");
                });

            modelBuilder.Entity("CustomVacations.Models.VacationModelVacationCart", b =>
                {
                    b.HasOne("CustomVacations.Models.VacationCart", "vacationCart")
                        .WithMany()
                        .HasForeignKey("VacationCartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CustomVacations.Models.VacationModel", "vacationModel")
                        .WithMany("VacationModelVacationCarts")
                        .HasForeignKey("vacationModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CustomVacations.Models.VacationOrderDestinationDetails", b =>
                {
                    b.HasOne("CustomVacations.Models.VacationOrder", "VacationOrder")
                        .WithMany("VacationOrderDestinationDetails")
                        .HasForeignKey("VacationOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CustomVacations.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CustomVacations.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CustomVacations.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CustomVacations.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
