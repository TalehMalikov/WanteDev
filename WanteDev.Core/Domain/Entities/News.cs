using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.Domain.Entities;

namespace WantedDev.Core.Domain.Entities
{
    public class News : BaseEntity
    {
        public Employer Employer { get; set; }
        public string Heading { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Photo { get; set; }
    }
}
