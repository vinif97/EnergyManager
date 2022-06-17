using AutoMapper;
using EnergyManager.Application.CustomAttribute;
using EnergyManager.Application.Dtos;
using EnergyManager.Application.Dtos.Response;
using EnergyManager.Application.Interfaces;
using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyManager.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly IEndpointService _endpointService;

        public EndpointController(IEndpointService endpointService)
        {
            _endpointService = endpointService;

        }

        [HttpGet]
        public async Task<IActionResult> GetEndpointBySerialNumber(string serialNumber)
        {
            var endpoint = await _endpointService.GetEndpointBySerialNumberWithMeterAsync(serialNumber);
            
            if (endpoint == null) return NotFound();

            return Ok(endpoint);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEndpoints()
        {
            var endpoints = await _endpointService.GetAllAsync();

            return Ok(endpoints);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEndpoint([SerialNumberValidator] EndpointDto endpointDto)
        {
            var endpointResponse = await _endpointService.AddAsync(endpointDto);

            if (endpointResponse != null) return NoContent();

            return BadRequest("Entity already Exist.");
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEndpoint([SerialNumberValidator] EndpointUpdateDto endpointDto)
        {
            var endpointResponse = await _endpointService.UpdateAsync(endpointDto);

            if (endpointResponse == null) return NotFound("Endpoint Doesn't Exist");

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEndpoint(EndpointDeleteDto endpointDeleteDto)
        {
            var endpoint = await _endpointService.GetEndpointBySerialNumberWithMeterForDeleteAsync(endpointDeleteDto.SerialNumber);
            if (endpoint == null) return NotFound();

            await _endpointService.DeleteAsync(endpoint);

            return NoContent();
        }
    }
}
