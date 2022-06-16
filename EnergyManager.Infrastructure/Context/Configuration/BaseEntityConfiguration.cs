using EnergyManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace EnergyManager.Infrastructure.Context.Configuration
{
    public abstract class BaseEntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        protected BaseEntityConfiguration()
        {
            Property(a => a.CreatedDate).IsOptional();
            Property(a => a.ModifiedDate).IsOptional();
            Property(a => a.DeletedDate).IsOptional();
            Property(a => a.IsDeleted).IsOptional();
        }
    }
}
