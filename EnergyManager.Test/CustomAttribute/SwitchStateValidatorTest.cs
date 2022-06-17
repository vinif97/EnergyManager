using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using EnergyManager.Application.CustomAttribute;
using Xunit;
using EnergyManager.Application.Helper;

namespace EnergyManager.Test.CustomAttribute
{
    public class SwitchStateValidatorTest
    {
        [Fact]
        public void Validate_RightSwitchState()
        {
            SwitchStateValidator switchStateValidator = new SwitchStateValidator();
            Endpoint enpoint = new Endpoint() { SerialNumber = "NSX1P2W", SwitchState = 1};

            bool result = switchStateValidator.IsValid(enpoint);

            Assert.True(result);
        }

        [Fact]
        public void Validate_WrongSwitchState()
        {
            SwitchStateValidator switchStateValidator = new SwitchStateValidator();
            Endpoint enpoint = new Endpoint() { SerialNumber = "NSX1P2W", SwitchState = 3 };

            bool result = switchStateValidator.IsValid(enpoint);

            Assert.False(result);
        }
    }
}
