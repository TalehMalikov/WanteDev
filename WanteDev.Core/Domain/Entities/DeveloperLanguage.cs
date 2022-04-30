using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.Domain.Entities;

namespace WantedDev.Core.Domain.Entities
{
    public class DeveloperLanguage :BaseEntity
    {
        public Developer Developer { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
