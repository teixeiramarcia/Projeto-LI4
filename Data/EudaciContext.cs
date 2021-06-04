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
                    Population = 10169411,
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
                    Population = 84030279,
                    GeographicLocation = "Center"
                }
            };

            countries.ForEach(c => {
                modelBuilder.Entity<Country>().HasData(c);
            });
        }
    }
}
