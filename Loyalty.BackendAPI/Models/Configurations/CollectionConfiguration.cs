using Loyalty.BackendAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loyalty.BackendAPI.Models.Configurations
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.ToTable("Collection");

            //builder.HasOne(p => p.Product).WithMany(c => c.Collections)
            //    .HasForeignKey(c => c.productID);

            //builder.HasMany(ca => ca.Campaigns).WithOne(c => c.Collection)
            //    .HasForeignKey(ca => ca.campaignID);
        }
    }
}