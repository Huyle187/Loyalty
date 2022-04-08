using Loyalty.BackendAPI.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.EF
{
    public class LoyaltyDBContext : DbContext
    {
        public LoyaltyDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
    }
}