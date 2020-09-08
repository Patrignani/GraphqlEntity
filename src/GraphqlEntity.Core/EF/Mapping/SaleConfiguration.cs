using GraphqlEntity.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphqlEntity.Core.EF.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Identification).IsRequired().HasMaxLength(3900);

            builder.HasOne(x => x.User)
             .WithMany(x => x.Sale)
             .HasForeignKey(x => x.UserId);
        }
    }
}
