using Loyalty.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.EF
{
    public class LoyaltyDBContextFactory : IDesignTimeDbContextFactory<LoyaltyEntities>
    {
        public LoyaltyEntities CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("LoyaltyDB");

            var optionsBuilder = new DbContextOptionsBuilder<LoyaltyEntities>();
            optionsBuilder.UseSqlServer(connectionString);

            return new LoyaltyEntities(optionsBuilder.Options);
        }
    }
}