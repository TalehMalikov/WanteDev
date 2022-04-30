using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.Domain.Entities;

namespace WantedDev.Core.Domain.Entities
{
    public class DeveloperExam:BaseEntity
    {
        public Developer Developer { get; set; }
        public Exam Exam { get; set; }
        public double Result { get; set; }
        public DateTime Date { get; set; }
    }
}
