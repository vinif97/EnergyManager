using EnergyManager.Domain.Models;
using System.Threading.Tasks;

namespace EnergyManager.Domain.Interfaces
{
    public interface IEndpointRepository : IRepository<Endpoint>
    {
        Task<Endpoint> GetEndpointBySerialNumberWithMeter(string serialNumber);
        Task<Endpoint> GetEndpointBySerialNumber(string serialNumber); 
    }
}
