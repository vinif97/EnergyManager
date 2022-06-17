using EnergyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyManager.Infrastructure.Context.Configuration
{
    public class MeterConfiguration : BaseEntityConfiguration<Meter>, IEntityTypeConfiguration<Meter>
    {
        public override void Configure(EntityTypeBuilder<Meter> builder)
        {
            builder.HasKey(m => m.MeterId);
            builder.Property(m => m.MeterId).ValueGeneratedOnAdd();
            builder.Property(m => m.ModelId);
            builder.Property(m => m.Number).IsRequired();
            builder.Property(m => m.FirmwareVersion).IsRequired();
            base.Configure(builder);
        }
    }
}
