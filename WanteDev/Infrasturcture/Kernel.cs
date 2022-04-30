using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Core.Domain.Entities;

namespace WanteDev.Infrasturcture
{
    public static class Kernel
    {
        public static IUnitOfWork DB { get; set; }
        public static Admin Admin { get; set; }
        public static Employer CurrentEmployer { get; set; }
        public static Developer CurrentDeveloper { get; set; }
    }
}
