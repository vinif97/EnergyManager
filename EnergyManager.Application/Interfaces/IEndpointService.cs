using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnergyManager.Application.Interfaces
{
    public interface IEndpointService
    {
        Task<bool> CheckIfEntityExist(Endpoint entity);
    }
}
