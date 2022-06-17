using EnergyManager.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EnergyManager.Presentation.Services
{
    internal class HttpService
    {
        private string BaseAddress { get; set; }
        public HttpClient HttpClient { get; set; }

        public HttpService(string baseAddress)
        { 
            BaseAddress = baseAddress;
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("http://localhost:64195/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ICollection<Endpoint>> GetAllEndpoints()
        {
            var response = await HttpClient.GetAsync($@"{BaseAddress}/api/Endpoint/GetAllEndpoints");

            if (response.IsSuccessStatusCode)
            {
                string endpoints = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ICollection<Endpoint>>(endpoints);
                return result;
            }
            else
            {
                throw new Exception(response.Content.ToString());
            }
        }

        public async Task<Endpoint> GetEndpointBySerialNumber(string serialNumber)
        {
            var response = await HttpClient.GetAsync($@"{BaseAddress}/api/Endpoint/GetEndpointBySerialNumber?serialNumber={serialNumber}");
            string endpoint = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Endpoint>(endpoint);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            return result;
        }

        public async Task<HttpStatusCode> InsertEndpoint(object endpoint)
        {
            var contentString = JsonConvert.SerializeObject(endpoint);
            var content = new StringContent(contentString.ToString(), Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync($@"{BaseAddress}/api/Endpoint/InsertEndpointAsync", content);

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DeleteEndpointAsync(object serialNumber)
        {
            var contentString = JsonConvert.SerializeObject(serialNumber);
            var content = new StringContent(contentString.ToString(), Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(contentString, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri($@"{BaseAddress}/api/Endpoint/DeleteEndpoint")
            };
            
            var response = await HttpClient.SendAsync(request);
            return response.StatusCode;
        }
    }
}
