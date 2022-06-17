using AutoMapper;
using EnergyManager.Application.Dtos;
using EnergyManager.Application.Dtos.Response;
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
        private readonly IMapper _mapper;

        public EndpointService(IEndpointRepository endpointRepository, IMapper mapper)
        {
            _endpointRepository = endpointRepository;
            _mapper = mapper;
        }

        public async Task<EndpointDtoResponse> AddAsync(EndpointDto entity)
        {
            bool entityExist = await CheckIfEntityExist(entity.SerialNumber);
            if (!entityExist)
            {

                var endpoint = _mapper.Map<Endpoint>(entity);
                endpoint = await _endpointRepository.AddAsync(endpoint);

                return _mapper.Map<EndpointDtoResponse>(endpoint);
            }

            return null;
        }

        public async Task DeleteAsync(Endpoint entity)
        {
            await _endpointRepository.DeleteAsync(entity);
        }

        public async Task<List<EndpointDtoResponse>> GetAllAsync()
        {
            var endpoints = await _endpointRepository.GetAllAsync();
            return _mapper.Map<List<EndpointDtoResponse>>(endpoints);
        }

        public async Task<EndpointDtoResponse> GetEndpointBySerialNumberWithMeterAsync(string serialNumber)
        {
            var endpoint = await _endpointRepository.GetEndpointBySerialNumberWithMeter(serialNumber);
            return _mapper.Map<EndpointDtoResponse>(endpoint);
        }

        public async Task<Endpoint> GetEndpointBySerialNumberWithMeterForDeleteAsync(string serialNumber)
        {
            var endpoint = await _endpointRepository.GetEndpointBySerialNumberWithMeter(serialNumber);
            return endpoint;
        }

        public async Task<EndpointDtoResponse> UpdateAsync(EndpointUpdateDto endpointDto)
        {
            var endpoint = await _endpointRepository.GetEndpointBySerialNumberWithMeter(endpointDto.SerialNumber);

            if (endpoint != null)
            {
                endpoint = _mapper.Map(endpointDto, endpoint);
                var newEndpointResponse = await _endpointRepository.UpdateAsync(endpoint);
                return _mapper.Map<EndpointDtoResponse>(newEndpointResponse);
            }

            return null;
        }

        private async Task<bool> CheckIfEntityExist(string serialNumber)
        {
            bool entityExist = await _endpointRepository.GetEndpointBySerialNumber(serialNumber) != null;
            return entityExist;
        }
    }
}
