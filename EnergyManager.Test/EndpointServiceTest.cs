using AutoMapper;
using EnergyManager.Application.Services;
using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EnergyManager.Test
{
    public class EndpointServiceTest
    {
        private readonly EndpointService _endpointService;
        private readonly Mock<IEndpointRepository> _repositorioMock = new Mock<IEndpointRepository>();
        private readonly IMapper mapper;
        public EndpointServiceTest()
        {
            _endpointService = new EndpointService(_repositorioMock.Object, mapper);
        }

        [Fact]
        public async Task Get_All_Endpoints_With_Meter()
        {
            var endpoint = new Endpoint
            {
                SerialNumber = "NSX1P2W",
                SwitchState = 0,
                Meter = new Meter
                {
                    Number = 155,
                    FirmwareVersion = "v1"
                }
            };
            _repositorioMock.Setup(x => x.GetAllAsync()).ReturnsAsync(endpoint);


            await _endpointService.GetAllAsync();
        }
    }
}
