using Microsoft.EntityFrameworkCore;
using eudaci.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System;

namespace eudaci.Data
{
    public class EudaciContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Country> Country { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Vaccination> Vaccination { get; set; }
        public DbSet<Pandemic> Pandemic { get; set; }


        public EudaciContext ()
            : base()
        {
        }

        public EudaciContext (DbContextOptions<EudaciContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            SeedCountries(modelBuilder);
        }

        private static void SeedCountries(ModelBuilder modelBuilder)
        {
            var countries = new List<Country>() {
                new Country {
                    Id = 1,
                    Name = "Portugal",
                    Population = 10196709,
                    GeographicLocation = "Southwest"
                },
                new Country {
                    Id = 2,
                    Name = "Spain",
                    Population = 46754778,
                    GeographicLocation = "Southwest"
                },
                new Country {
                    Id = 3,
                    Name = "Germany",
                    Population = 84031009,
                    GeographicLocation = "Center"
                },
                new Country {
                    Id = 4,
                    Name = "Austria",
                    Population = 9053899,
                    GeographicLocation = "Center"
                },
                new Country {
                    Id = 5,
                    Name = "Belgium",
                    Population = 11589623,
                    GeographicLocation = "West"
                },
                new Country {
                    Id = 6,
                    Name = "Bulgaria",
                    Population = 6948445,
                    GeographicLocation = "Southeast"
                },
                new Country {
                    Id = 7,
                    Name = "Croatia",
                    Population = 4105267,
                    GeographicLocation = "Northwest"
                },
                new Country {
                    Id = 8,
                    Name = "Cyprus",
                    Population = 1215480,
                    GeographicLocation = "East"
                },
                new Country {
                    Id = 9,
                    Name = "Czechia",
                    Population = 10727309,
                    GeographicLocation = "Center"
                },
                new Country {
                    Id = 10,
                    Name = "Denmark",
                    Population = 5792202,
                    GeographicLocation = "North"
                },
                new Country {
                    Id = 11,
                    Name = "Estonia",
                    Population = 1326535,
                    GeographicLocation = "Northeast"
                },
                new Country {
                    Id = 12,
                    Name = "Finland",
                    Population = 5548661,
                    GeographicLocation = "North"
                },
                new Country {
                    Id = 13,
                    Name = "France",
                    Population = 65406747,
                    GeographicLocation = "West"
                },
                new Country {
                    Id = 14,
                    Name = "Greece",
                    Population = 10423054,
                    GeographicLocation = "Southeast"
                },
                new Country {
                    Id = 15,
                    Name = "Hungary",
                    Population = 9637630,
                    GeographicLocation = "Center"
                },
                new Country {
                    Id = 16,
                    Name = "Ireland",
                    Population = 4937786,
                    GeographicLocation = "Northwest"
                },
                new Country {
                    Id = 17,
                    Name = "Italy",
                    Population = 60379497,
                    GeographicLocation = "South"
                },
                new Country {
                    Id = 18,
                    Name = "Latvia",
                    Population = 1886198,
                    GeographicLocation = "Northwest"
                },
                new Country {
                    Id = 19,
                    Name = "Lithuania",
                    Population = 2722289,
                    GeographicLocation = "East"
                },
                new Country {
                    Id = 20,
                    Name = "Luxembourg",
                    Population = 625978,
                    GeographicLocation = "Northwest"
                },
                new Country {
                    Id = 21,
                    Name = "Malta",
                    Population = 441543,
                    GeographicLocation = "South"
                },
                new Country {
                    Id = 22,
                    Name = "Netherlands",
                    Population = 17169846,
                    GeographicLocation = "Northwest"
                },
                new Country {
                    Id = 23,
                    Name = "Poland",
                    Population = 37846611,
                    GeographicLocation = "Center"
                },
                new Country {
                    Id = 24,
                    Name = "Romania",
                    Population = 19237691,
                    GeographicLocation = "Southeast"
                },
                new Country {
                    Id = 25,
                    Name = "Slovakia",
                    Population = 5462090,
                    GeographicLocation = "Center"
                },
                new Country {
                    Id = 26,
                    Name = "Slovenia",
                    Population = 2079202,
                    GeographicLocation = "Center"
                },
                new Country {
                    Id = 27,
                    Name = "Sweden",
                    Population = 10099265,
                    GeographicLocation = "North"
                }
            };

            countries.ForEach(c => {
                modelBuilder.Entity<Country>().HasData(c);
            });
        }
    }
}
