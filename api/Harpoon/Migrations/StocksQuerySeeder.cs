using System;
using Microsoft.EntityFrameworkCore;

namespace Harpoon.Migrations
{
    public class StocksQuerySeeder
    {
        private readonly ModelBuilder _modelBuilder;

        public StocksQuerySeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        // public void Seed()
        // {
        //     _modelBuilder.Entity<Country>().Property(b => b.No).ValueGeneratedOnAdd();
        //     _modelBuilder.Entity<Country>().Property(b => b.Email).HasDefaultValue(string.Empty);
        //     _modelBuilder.Entity<Country>().HasData(GetCountries());
        // }

        // private Country[] GetCountries()
        // {
        //     return new[]
        //     {                
        //         new Country{ Code = "CA", Name = "Canada" },
        //         new Country{ Code = "JM", Name = "Jamaica" },
        //         new Country{ Code = "US", Name = "United States" },
        //         new Country{ Code = "ZA", Name = "South Africa" },
        //         new Country{ Code = "ZM", Name = "Zambia" },
        //         new Country{ Code = "ZW", Name = "Zimbabwe" }
        //      };
        // }
    }
}