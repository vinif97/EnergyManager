using AutoMapper;
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
            var endpoint = await _endpointService.GetEndpointBySerialNumberWithMeter(serialNumber);
            
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
        public async Task<IActionResult> InsertEndpoint(EndpointDto endpointDto)
        {
            var endpointResponse = await _endpointService.AddAsync(endpointDto);

            if (endpointResponse != null) return Ok(endpointResponse);

            return BadRequest("Entity already Exist.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEndpoint(EndpointUpdateDto endpointDto)
        {
            var endpointResponse = await _endpointService.UpdateAsync(endpointDto);

            if (endpointResponse == null) return NotFound("Endpoint Doesn't Exist");

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEndpoint(EndpointDto endpointDto)
        {
            try
            {
                await _endpointService.DeleteAsync(endpointDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
