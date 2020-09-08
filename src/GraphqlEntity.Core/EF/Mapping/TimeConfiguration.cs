using GraphqlEntity.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphqlEntity.Core.EF.Mapping
{
    public class TimeConfiguration : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Identification).IsRequired().HasMaxLength(3900);
        }
    }
}
