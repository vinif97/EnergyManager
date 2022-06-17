using EnergyManager.Application.Dtos;
using EnergyManager.Domain.Models;
using EnergyManager.Presentation.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EnergyManager.Presentation.Views
{
    internal class UserInterface
    {
        protected HttpService HttpService { get; set; }
        public UserInterface()
        {
            HttpService = new HttpService("https://localhost:44332");
            Console.WriteLine("Welcome.");
        }

        public async Task<int> ShowOptionsAsync()
        {
            Console.WriteLine("\nPlease, select one action to perfom(insert its respective number)\n");
            Console.WriteLine("Insert a new endpoint (1)\n" +
                "Edit an existing endpoint (2)\n" +
                "Delete an existing endpoint (3)\n" +
                "List all endpoints (4)\n" +
                "Find and endpoint by your serial number (5)\n" +
                "Exit the program (6)");

            string option = Console.ReadLine();
            int validoption = await IsOptionValidAsync(option);
            return validoption;
        }

        private async Task<int> IsOptionValidAsync(string option)
        {
            bool isOptionValid = int.TryParse(option, out int optionNumber);
            if (optionNumber < 0 || optionNumber > 6) isOptionValid = false;

            if (isOptionValid)
            {
                optionNumber = await SelectUserAction(optionNumber);
                return optionNumber;
            }
            else
            {
                Console.WriteLine("Invalid option, select a valid option please.\n");
                return 0;
            }
        }

        private async Task<int> SelectUserAction(int optionNumber)
        {
            switch (optionNumber)
            {
                case 1:
                    await InsertEndpointAsync();
                    break;
                case 2:
                    await UpdateEndpointAsync();
                    break;
                case 3:
                    await DeleteEndpointAsync();
                    break;
                case 4:
                    await ListAllEndpoints();
                    break;
                case 5:
                    await GetEndpointBySerialNumber();
                    break;
                case 6:
                    optionNumber = ConfimeExit();
                    break;
            }

            return optionNumber;
        }

        private int ConfimeExit()
        {
            bool optionIsValid = false;

            while (!optionIsValid)
            {
                Console.WriteLine("Do you wish to exit the program?[Y/N]");
                string option = Console.ReadLine();
                if (option.Substring(0, 1).ToUpper().Contains("Y")) return 6;
                else if (option.Substring(0, 1).ToUpper().Contains("N")) return 0;
                else Console.WriteLine("Please, Select a valid option");
            }

            return 6;
        }

        private async Task ListAllEndpoints()
        {
            var response = await HttpService.GetAllEndpoints();

            if (response == null || response.Count == 0) Console.WriteLine("Não existem endpoints cadastrados.");
            else
            {
                foreach (Endpoint endpoint in response)
                {
                    Console.WriteLine($"SerialNumber = {endpoint.SerialNumber}\n" +
                        $"SwitchState = { endpoint.SwitchState}\n" +
                        $"Meter Model Id = { endpoint.Meter.ModelId}\n" +
                        $"Meter Number = { endpoint.Meter.Number}\n" +
                        $"Meter Firmware Version = { endpoint.Meter.FirmwareVersion}");
                }
            }
        }

        private async Task GetEndpointBySerialNumber()
        {
            string serialNumber = GetSerialNumber();

            var response = await HttpService.GetEndpointBySerialNumber(serialNumber);

            if (response == null) Console.WriteLine("There are no endpoint registered with this serial number");
            else
            {
                ListSingleEndpointData(response);
            }
        }

        private void ListSingleEndpointData(Endpoint endpoint)
        {
            Console.WriteLine($"SerialNumber = {endpoint.SerialNumber}\n" +
                    $"SwitchState = { endpoint.SwitchState}\n" +
                    $"Meter Model Id = { endpoint.Meter.ModelId}\n" +
                    $"Meter Number = { endpoint.Meter.Number}\n" +
                    $"Meter Firmware Version = { endpoint.Meter.FirmwareVersion}");
        }

        private async Task InsertEndpointAsync()
        {
            Console.WriteLine("Please insert the endpoint data: \n");
            var endpoint = GetEndpointData();

            var httpStatusCode = await HttpService.InsertEndpoint(endpoint);

            if (httpStatusCode == HttpStatusCode.NoContent)
                Console.WriteLine("Endpoint added successful.");
            else if (httpStatusCode == HttpStatusCode.BadRequest)
                Console.WriteLine("Invalid data, endpoint could not be inserted in the database.");
            else
                Console.WriteLine("An unexpected problem ocurred, please contact the support.");
        }

        private async Task UpdateEndpointAsync()
        {
            string serialNumber = GetSerialNumber();

            var response = await HttpService.GetEndpointBySerialNumber(serialNumber);
            if (response == null) Console.WriteLine("There is no endpoint registered with this serial number");
            else
            {
                Console.WriteLine("\nThis is your endpoint, please enter the new data:\n");
                ListSingleEndpointData(response);
                Console.WriteLine();

                var endpointDataToUpdate = GetEndpointData();

                var httpStatusCode = await HttpService.UpdateEndpoint(endpointDataToUpdate);

                if (httpStatusCode == HttpStatusCode.BadRequest) 
                    Console.WriteLine("Problem with the data, please check it and try again.");
                else if (httpStatusCode == HttpStatusCode.NoContent) 
                    Console.WriteLine("Endpoint updated with success.");
                else
                    Console.WriteLine("An unexpected problem ocurred, please contact the support.");

            }
            
        }

        private string GetSerialNumber()
        {
            Console.WriteLine("Please, enter your serial number.");
            string serialNumber = Console.ReadLine();

            return serialNumber;
        }

        private async Task DeleteEndpointAsync()
        {
            Console.WriteLine("Please, insert your serial number to be deleted");
            string serialNumber = Console.ReadLine();

            bool confirmDelete = ConfirmDelete();

            if (confirmDelete == true)
            {
                var response = await HttpService.DeleteEndpointAsync(new EndpointDeleteDto() { SerialNumber = serialNumber});

                if (response == HttpStatusCode.NotFound) 
                    Console.WriteLine("Endpoint doesn't exist, check the Serial Number and try again");
                else if (response == HttpStatusCode.NoContent) 
                    Console.WriteLine("Endpoint deleted with sucess.");
                else
                    Console.WriteLine("An unexpected problem ocurred, please contact the support.");
            }
        }

        private bool ConfirmDelete()
        {
            bool optionIsValid = false;

            while (!optionIsValid)
            {
                Console.WriteLine("Do you wish to delete the endpoint?[Y/N]");
                string option = Console.ReadLine();
                if (option.Substring(0, 1).ToUpper().Contains("Y")) return true;
                else if (option.Substring(0, 1).ToUpper().Contains("N")) return false;
                else Console.WriteLine("Please, Select a valid option");
            }

            return false;
        }

        private Endpoint GetEndpointData()
        {
            Endpoint endpoint = new Endpoint();
            endpoint.Meter = new Meter();
            bool isDataValid = false;

            while (!isDataValid)
                try
                {
                    Console.WriteLine("Endpoint Serial Number: ");
                    endpoint.SerialNumber = Console.ReadLine();
                    Console.WriteLine("Endpoint Serial Number: ");
                    endpoint.Meter.ModelId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Endpoint Meter Number: ");
                    endpoint.Meter.Number = int.Parse(Console.ReadLine());
                    Console.WriteLine("Endpoint Meter FirmwareVersion: ");
                    endpoint.Meter.FirmwareVersion = Console.ReadLine();
                    Console.WriteLine("Endpoint Switch State: ");
                    endpoint.SwitchState = int.Parse(Console.ReadLine());
                    isDataValid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Erro ao receber dados, por favor, insira dados válidos.");
                }

            return endpoint;
        }
    }
}
