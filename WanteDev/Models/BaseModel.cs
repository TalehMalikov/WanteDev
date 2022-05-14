using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanteDev.Models
{
    public abstract class BaseModel
    {
        public int NO { get; set; }
        public int Id { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public abstract object Clone();
        public abstract bool IsValid(out string message);
    }
}
