namespace EnergyManager.Domain.Models
{
    public class Meter : BaseEntity
    {
        public int MeterId { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }

        public int EndpointId { get; set; }
        public Endpoint Endpoint { get; set; }
    }
}
