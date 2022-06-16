using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnergyManager.Application.Dtos
{
    public class MeterDto
    {
        public int MeterId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string FirmwareVersion { get; set; }
    }
}
