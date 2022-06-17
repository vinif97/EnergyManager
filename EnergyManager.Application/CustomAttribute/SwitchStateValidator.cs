using EnergyManager.Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnergyManager.Application.CustomAttribute
{
    public class SwitchStateValidator : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Invalid Switch State";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var endpoint = (dynamic)value;
            bool isSerialNumberValid = Enum.IsDefined(typeof(SwitchStateEnum), endpoint.SwitchState);

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
