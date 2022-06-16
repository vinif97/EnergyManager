using EnergyManager.Application.Interfaces;
using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnergyManager.Application.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IEndpointRepository _endpointRepository;

        public EndpointService(IEndpointRepository endpointRepository)
        {
            _endpointRepository = endpointRepository;
        }

        public async Task<bool> CheckIfEntityExist(Endpoint entity)
        {
            bool entityExist = _endpointRepository.GetEndpointBySerialNumber(entity.SerialNumber) != null;
            return entityExist;
        }
    }
}
