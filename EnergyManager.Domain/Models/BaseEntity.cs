using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyManager.Domain.Models
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual DateTime DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
