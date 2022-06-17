using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using EnergyManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnergyManager.Infrastructure.Repository
{
    public class EndpointRepository : Repository<Endpoint>, IEndpointRepository
    {
        public EndpointRepository(EnergyManagerContext context) : base(context) { }

        public async Task<Endpoint> GetEndpointBySerialNumberWithMeter(string serialNumber)
        {
            var endpoint = await _context.Set<Endpoint>().Include(a => a.Meter).FirstOrDefaultAsync(a => a.SerialNumber == serialNumber);
            return endpoint;
        }

        public override async Task<IEnumerable<Endpoint>> GetAllAsync()
        {
            var endpoints = await _context.Set<Endpoint>().Include(a => a.Meter).ToListAsync();
            return endpoints;
        }

        public async Task<Endpoint> GetEndpointBySerialNumber(string serialNumber)
        {
            var endpoint = await _context.Set<Endpoint>().FirstOrDefaultAsync(a => a.SerialNumber == serialNumber);
            return endpoint;
        }
    }
}
