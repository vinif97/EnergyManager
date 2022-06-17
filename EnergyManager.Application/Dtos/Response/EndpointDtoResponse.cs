using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Application.Dtos.Response
{
    public class EndpointDtoResponse
    {
        public string SerialNumber { get; set; }
        public int SwitchState { get; set; }
        public MeterDto Meter { get; set; }
    }
}
