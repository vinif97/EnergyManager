using EnergyManager.Domain.Validation;

namespace EnergyManager.Domain.Models
{
    public class Endpoint : BaseEntity
    {
        public int EndpointId { get; set; }
        public string SerialNumber { get; set; }
        public int SwitchState { get; set; }

        public Meter Meter { get; set; }
    }
}
