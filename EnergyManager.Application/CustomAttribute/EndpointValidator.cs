using EnergyManager.Application.Dtos;
using EnergyManager.Application.Helper;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnergyManager.Application.CustomAttribute
{
    public class SerialNumberValidator : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Invalid serial number.";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endpoint = (dynamic)value;
            bool isSerialNumberValid = EndpointDictionary.endpoints.ContainsKey(endpoint.SerialNumber);

            if (isSerialNumberValid)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage ??
                                            DefaultErrorMessage);
            }
        }
    }
}
