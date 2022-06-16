using EnergyManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyManager.Infrastructure.Context.Configuration
{
    public class EndpointConfiguration : BaseEntityConfiguration<Endpoint>, IEntityTypeConfiguration<Endpoint>
    {
        public override void Configure(EntityTypeBuilder<Endpoint> builder)
        {
            builder.HasKey(e => e.EndpointId);
            builder.Property(e => e.EndpointId).ValueGeneratedOnAdd();
            builder.Property(e => e.SwtichState).IsRequired();
            builder.Property(e => e.SerialNumber).IsRequired();
            builder.HasIndex(e => e.SerialNumber).IsUnique();
            base.Configure(builder);
        }
    }
}
