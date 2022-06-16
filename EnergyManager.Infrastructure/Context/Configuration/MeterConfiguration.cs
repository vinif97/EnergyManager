using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Infrastructure.Context.Configuration
{
    public class MeterConfiguration : BaseEntityConfiguration<Meter>
    {
        public MeterConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.SerialNumber).IsRequired().HasMaxLength(50);
            Property(m => m.FirmwareVersion).IsRequired();
        }
    }
}
