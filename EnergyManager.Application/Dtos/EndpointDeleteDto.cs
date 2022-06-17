using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnergyManager.Application.Dtos
{
    public class EndpointDeleteDto
    {
        [Required]
        public string SerialNumber { get; set; }
    }
}
