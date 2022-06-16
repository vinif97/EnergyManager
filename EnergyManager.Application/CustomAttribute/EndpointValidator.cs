using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EnergyManager.Application.CustomAttribute
{
    public class EndpointValidator : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Endpoint com formatação incorreta. Verifique os dados enviados.";
        //protected override ValidationResult IsValid(Endpoint value, ValidationContext validationContext)
        //{
        //    bool isSerialNumberValid = value.SerialNumber

        //    if ()

        //    if ()
        //    {
        //        return ValidationResult.Success;
        //    }
        //    else
        //    {
        //        return new ValidationResult(ErrorMessage ??
        //                                    DefaultErrorMessage);
        //    }
        //}
    }
}
