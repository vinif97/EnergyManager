using System;

namespace EnergyManager.Domain.Models
{
    public abstract class BaseEntity
    {
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
