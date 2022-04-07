using Loyalty.BackendAPI.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.EF
{
    public class LoyaltyDBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public LoyaltyDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Collection>().HasOne(col => col.Campaign)
                                             .WithMany(x => x.Collections).HasForeignKey(c => c.campaignID);

            modelBuilder.Entity<Collection>().HasOne(x => x.Product)
                                 .WithMany(x => x.Collections)
                                 .HasForeignKey(c => c.productID);
            modelBuilder.Entity<Campaign>().Ignore(c => c.Collections);
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}