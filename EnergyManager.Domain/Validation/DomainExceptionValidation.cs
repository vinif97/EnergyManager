using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error) { }
        public DomainExceptionValidation(string error, Exception inner) : base(error, inner) { }
        public static void ValidateDomain(bool hasError, string error)
        {
            if (hasError) throw new DomainExceptionValidation(error);
        }
    }
}
