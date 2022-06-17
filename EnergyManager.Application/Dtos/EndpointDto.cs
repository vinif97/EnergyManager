using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnergyManager.Application.Dtos
{
    public class EndpointDto
    {
        public int EndpointId { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public int SwitchState { get; set; }
        [Required]
        public MeterDto Meter { get; set; }
    }
}
