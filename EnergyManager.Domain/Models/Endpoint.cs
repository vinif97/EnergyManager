using EnergyManager.Domain.Validation;

namespace EnergyManager.Domain.Models
{
    public class Endpoint : BaseEntity
    {
        public int EndpointId { get; set; }
        public string SerialNumber { get; set; }
        public int SwtichState { get; set; }

        public Meter Meter { get; set; }

        //private int ValidateSwitchState(int switchState)
        //{
        //    bool isSwitchStateValide = (switchState >= 0 || switchState <= 2);
        //    DomainExceptionValidation.ValidateDomain(isSwitchStateValide, "Invalid switch.");
        //    return switchState;
        //}
    }
}
