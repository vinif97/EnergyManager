﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnergyManager.Application.Dtos
{
    public class EndpointUpdateDto
    {
        [Required]
        public string SerialNumber { get; set; }
        public int SwitchState { get; set; }
        public MeterDto Meter { get; set; }
    }
}
