﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eudaci.Data;

namespace eudaci.Migrations
{
    [DbContext(typeof(EudaciContext))]
    partial class EudaciContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("eudaci.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SettingsId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("SettingsId")
                        .IsUnique()
                        .HasFilter("[SettingsId] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("eudaci.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GeographicLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GeographicLocation = "Southwest",
                            Name = "Portugal",
                            Population = 10196709
                        },
                        new
                        {
                            Id = 2,
                            GeographicLocation = "Southwest",
                            Name = "Spain",
                            Population = 46754778
                        },
                        new
                        {
                            Id = 3,
                            GeographicLocation = "Center",
                            Name = "Germany",
                            Population = 84031009
                        },
                        new
                        {
                            Id = 4,
                            GeographicLocation = "Center",
                            Name = "Austria",
                            Population = 9053899
                        },
                        new
                        {
                            Id = 5,
                            GeographicLocation = "West",
                            Name = "Belgium",
                            Population = 11589623
                        },
                        new
                        {
                            Id = 6,
                            GeographicLocation = "Southeast",
                            Name = "Bulgaria",
                            Population = 6948445
                        },
                        new
                        {
                            Id = 7,
                            GeographicLocation = "Northwest",
                            Name = "Croatia",
                            Population = 4105267
                        },
                        new
                        {
                            Id = 8,
                            GeographicLocation = "East",
                            Name = "Cyprus",
                            Population = 1215480
                        },
                        new
                        {
                            Id = 9,
                            GeographicLocation = "Center",
                            Name = "Czechia",
                            Population = 10727309
                        },
                        new
                        {
                            Id = 10,
                            GeographicLocation = "North",
                            Name = "Denmark",
                            Population = 5792202
                        },
                        new
                        {
                            Id = 11,
                            GeographicLocation = "Northeast",
                            Name = "Estonia",
                            Population = 1326535
                        },
                        new
                        {
                            Id = 12,
                            GeographicLocation = "North",
                            Name = "Finland",
                            Population = 5548661
                        },
                        new
                        {
                            Id = 13,
                            GeographicLocation = "West",
                            Name = "France",
                            Population = 65406747
                        },
                        new
                        {
                            Id = 14,
                            GeographicLocation = "Southeast",
                            Name = "Greece",
                            Population = 10423054
                        },
                        new
                        {
                            Id = 15,
                            GeographicLocation = "Center",
                            Name = "Hungary",
                            Population = 9637630
                        },
                        new
                        {
                            Id = 16,
                            GeographicLocation = "Northwest",
                            Name = "Ireland",
                            Population = 4937786
                        },
                        new
                        {
                            Id = 17,
                            GeographicLocation = "South",
                            Name = "Italy",
                            Population = 60379497
                        },
                        new
                        {
                            Id = 18,
                            GeographicLocation = "Northwest",
                            Name = "Latvia",
                            Population = 1886198
                        },
                        new
                        {
                            Id = 19,
                            GeographicLocation = "East",
                            Name = "Lithuania",
                            Population = 2722289
                        },
                        new
                        {
                            Id = 20,
                            GeographicLocation = "Northwest",
                            Name = "Luxembourg",
                            Population = 625978
                        },
                        new
                        {
                            Id = 21,
                            GeographicLocation = "South",
                            Name = "Malta",
                            Population = 441543
                        },
                        new
                        {
                            Id = 22,
                            GeographicLocation = "Northwest",
                            Name = "Netherlands",
                            Population = 17169846
                        },
                        new
                        {
                            Id = 23,
                            GeographicLocation = "Center",
                            Name = "Poland",
                            Population = 37846611
                        },
                        new
                        {
                            Id = 24,
                            GeographicLocation = "Southeast",
                            Name = "Romania",
                            Population = 19237691
                        },
                        new
                        {
                            Id = 25,
                            GeographicLocation = "Center",
                            Name = "Slovakia",
                            Population = 5462090
                        },
                        new
                        {
                            Id = 26,
                            GeographicLocation = "Center",
                            Name = "Slovenia",
                            Population = 2079202
                        },
                        new
                        {
                            Id = 27,
                            GeographicLocation = "North",
                            Name = "Sweden",
                            Population = 10099265
                        });
                });

            modelBuilder.Entity("eudaci.Models.Pandemic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("Hospitalisations")
                        .HasColumnType("int");

                    b.Property<int>("Infected")
                        .HasColumnType("int");

                    b.Property<int>("Recovered")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Pandemic");
                });

            modelBuilder.Entity("eudaci.Models.Settings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Notifications")
                        .HasColumnType("bit");

                    b.Property<bool>("NotifyPandemic")
                        .HasColumnType("bit");

                    b.Property<bool>("NotifyVaccination")
                        .HasColumnType("bit");

                    b.Property<bool>("Sugestions")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("eudaci.Models.Vaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuantityFirstDose")
                        .HasColumnType("int");

                    b.Property<int>("QuantitySecondDose")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Vaccination");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("eudaci.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("eudaci.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eudaci.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("eudaci.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eudaci.Models.ApplicationUser", b =>
                {
                    b.HasOne("eudaci.Models.Country", "Country")
                        .WithMany("users")
                        .HasForeignKey("CountryId");

                    b.HasOne("eudaci.Models.Settings", "Settings")
                        .WithOne("User")
                        .HasForeignKey("eudaci.Models.ApplicationUser", "SettingsId");

                    b.Navigation("Country");

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("eudaci.Models.Pandemic", b =>
                {
                    b.HasOne("eudaci.Models.Country", "Country")
                        .WithMany("Pandemics")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("eudaci.Models.Vaccination", b =>
                {
                    b.HasOne("eudaci.Models.Country", "Country")
                        .WithMany("Vaccinations")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("eudaci.Models.Country", b =>
                {
                    b.Navigation("Pandemics");

                    b.Navigation("users");

                    b.Navigation("Vaccinations");
                });

            modelBuilder.Entity("eudaci.Models.Settings", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
