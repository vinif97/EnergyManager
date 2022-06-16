using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Domain.Models
{
    public class Meter : BaseEntity
    {
        public string SerialNumber { get; set; }
        public override int Id { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }
        public int SwitchState { get; set; }
    }
}
