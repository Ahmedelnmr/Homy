using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homy.Domin.models
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public long? CreatedById { get; set; }     
       // public virtual User? CreatedBy { get; set; }

        public long? UpdatedById { get; set; }
       // public virtual User? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;        
    }
}
