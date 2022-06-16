using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Application.Helper
{
    public static class EndpointDictionary
    {
        public static IDictionary<string, int> endpoints = new Dictionary<string, int>()
        {
            {"NSX1P2W", 16},
            {"NSX1P3W", 17},
            {"NSX2P3W", 18},
            {"NSX3P4W", 19}
        };
    }
}
