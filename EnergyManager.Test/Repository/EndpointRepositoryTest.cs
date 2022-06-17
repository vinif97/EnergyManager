using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnergyManager.Test.Repository
{
    public class EndpointRepositoryTest
    {
        public Mock<IEndpointRepository> MockEndpointRepository = new Mock<IEndpointRepository>();
        public List<Endpoint> MockEndpoints { get; set; }

        public EndpointRepositoryTest()
        {
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
            MockEndpointRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(MockEndpoints);

            var mockEndpointRepository = MockEndpointRepository.Object;
            var endpointsToTest = await mockEndpointRepository.GetAllAsync();

            Assert.Equal(3, endpointsToTest.Count);
        }

        [Fact]
        public async Task Can_Get_Endpoint_BySerialNumber()
        {
            var endpoint = MockEndpoints[0];
            MockEndpointRepository.Setup(x => x.GetEndpointBySerialNumber(endpoint.SerialNumber)).ReturnsAsync(endpoint);

            var mockEndpointRepository = MockEndpointRepository.Object;
            var endpointToTest = await mockEndpointRepository.GetEndpointBySerialNumber(endpoint.SerialNumber);

            Assert.Equal(endpoint, endpointToTest);
        }
    }
}
