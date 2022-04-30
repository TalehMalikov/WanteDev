using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanteDev.Core.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id
        { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatorID { get; set; }
    }

}
