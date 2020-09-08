using GraphqlEntity.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphqlEntity.Core.EF.Mapping
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Identification).IsRequired().HasMaxLength(3900);

            builder.HasOne(x => x.User)
              .WithMany(x => x.Product)
              .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.ProductType)
              .WithMany(x => x.Product)
              .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
