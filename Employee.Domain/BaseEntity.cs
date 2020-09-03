using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace iEmployee.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; protected set; } = Guid.NewGuid();
    }
}
