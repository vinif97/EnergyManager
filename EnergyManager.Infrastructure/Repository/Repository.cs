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
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EnergyManagerContext _context;

        public Repository(EnergyManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>().AsNoTracking().ToListAsync();
            return entities;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
