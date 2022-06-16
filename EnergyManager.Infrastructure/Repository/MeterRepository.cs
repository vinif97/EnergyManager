using EnergyManager.Domain.Interfaces;
using EnergyManager.Domain.Models;
using EnergyManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyManager.Infrastructure.Repository
{
    public class MeterRepository : Repository<Meter>, IMeterRepository
    {
        public MeterRepository(EnergyManagerContext context) : base(context) {}
    }
}
