using AutoMapper;
using EnergyManager.Application.Dtos;
using EnergyManager.Application.Dtos.Response;
using EnergyManager.Application.Profiles;
using EnergyManager.Application.Services;
using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnergyManager.Test.Services
{
    public class EndpointServiceTest
    {
        private readonly EndpointService _endpointService;
        private readonly Mock<IEndpointRepository> _mockedRepository = new Mock<IEndpointRepository>();
        private readonly IMapper _mapper;
        public List<Endpoint> MockEndpoints { get; set; }

        public EndpointServiceTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new DomainToDtoProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _endpointService = new EndpointService(_mockedRepository.Object, _mapper);

            var endpoint1 = new Endpoint
            {
                SerialNumber = "NSX1P2W",
                SwitchState = 1,
                Meter = new Meter
                {
                    ModelId = 16,
                    Number = 155,
                    FirmwareVersion = "v1"
                }
            };
            var endpoint2 = new Endpoint
            {
                SerialNumber = "AAAA22",
                SwitchState = 1,
                Meter = new Meter
                {
                    ModelId = 5,
                    Number = 155,
                    FirmwareVersion = "v1"
                }
            };
            var endpoint3 = new Endpoint
            {
                SerialNumber = "11111",
                SwitchState = 2,
                Meter = new Meter
                {
                    ModelId = 5,
                    Number = 155,
                    FirmwareVersion = "v1"
                }
            };
            MockEndpoints = new List<Endpoint>() { endpoint1, endpoint2, endpoint3 };
        }

        [Fact]
        public async Task Can_GetAll_Endpoints()
        {
            _mockedRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(MockEndpoints);

            var mockEndpointRepository = _mockedRepository.Object;
            var endpointsToTest = await _endpointService.GetAllAsync();

            Assert.Equal(3, endpointsToTest.Count);
        }

        [Fact]
        public async Task Can_Get_Endpoint_By_SerialNumber()
        {
            var expectedResult = _mapper.Map<EndpointDtoResponse>(MockEndpoints[0]);

            _mockedRepository.Setup(x => x.GetEndpointBySerialNumberWithMeter(It.IsAny<string>())).ReturnsAsync(MockEndpoints[0]);
            
            var mockEndpointRepository = _mockedRepository.Object;
            var endpointsToTest = await _endpointService.GetEndpointBySerialNumberWithMeterAsync("NSX1P2W");

            Assert.Equal(expectedResult.SerialNumber, endpointsToTest.SerialNumber);
        }

        [Fact]
        public async Task Can_Add_Endpoint()
        {
            var endpointDto = _mapper.Map<EndpointDto>(MockEndpoints[0]);

            _mockedRepository.Setup(x => x.AddAsync(It.IsAny<Endpoint>())).ReturnsAsync(MockEndpoints[0]);

            var mockEndpointRepository = _mockedRepository.Object;
            var endpointsToTest = await _endpointService.AddAsync(endpointDto);

            Assert.NotNull(endpointsToTest);
        }
    }
}
