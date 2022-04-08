using Loyalty.BackendAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.Configurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign");

            //builder.HasOne(p => p.Product).WithMany(c => c.Campaigns)
            //    .HasForeignKey(c => c.productID);
            //builder.HasMany(x => x.Collections).WithOne(ca => ca.Campaign)
            //    .HasForeignKey(c => c.collectionID);
        }
    }
}