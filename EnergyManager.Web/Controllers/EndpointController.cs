using AutoMapper;
using EnergyManager.Application.Dtos;
using EnergyManager.Application.Dtos.Response;
using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyManager.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly IService
        private readonly IEndpointRepository _endpointRepository;
        private readonly IMapper _mapper;

        public EndpointController(IEndpointRepository endpointRepository, IMapper mapper)
        {
            _endpointRepository = endpointRepository;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetEndpointBySerialNumber(string serialNumber)
        {
            Domain.Models.Endpoint endpoint = await _endpointRepository.GetEndpointBySerialNumberWithMeter(serialNumber);

            if (endpoint == null) return NotFound();

            return Ok(endpoint);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEndpoints()
        {   
            IEnumerable<Domain.Models.Endpoint> endpoints = await _endpointRepository.GetAllAsync();

            return Ok(endpoints);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEndpoint(EndpointDto endpointDto)
        {
            _endpoin

            var endpoint =  _mapper.Map<Domain.Models.Endpoint>(endpointDto);
            endpoint = await _endpointRepository.AddAsync(endpoint);

            var endpointDtoresponse = _mapper.Map<EndpointDtoResponse>(endpoint);

            return Ok(endpointDtoresponse);
        }
    }
}
