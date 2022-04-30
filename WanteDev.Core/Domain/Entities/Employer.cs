using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.Domain.Entities;

namespace WantedDev.Core.Domain.Entities
{
    public class Employer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string CompanyName { get; set; }
        public string ApartmentName { get; set; }
        public string Position { get; set; }
        public string Bio { get; set; }
        public byte[] Photo { get; set; }
    }
}
