using EnergyManager.Application.Dtos;
using EnergyManager.Application.Dtos.Response;
using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnergyManager.Application.Interfaces
{
    public interface IEndpointService
    {
        Task<IEnumerable<EndpointDtoResponse>> GetAllAsync();
        Task<EndpointDtoResponse> GetEndpointBySerialNumberWithMeter(string serialNumber);
        Task<EndpointDtoResponse> AddAsync(EndpointDto entity);
        Task<EndpointDtoResponse> UpdateAsync(EndpointUpdateDto entity);
        Task DeleteAsync(EndpointDto entity);
    }
}
