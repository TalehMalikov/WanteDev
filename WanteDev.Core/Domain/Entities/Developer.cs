using System;
using WanteDev.Core.Domain.Entities;

namespace WantedDev.Core.Domain.Entities
{
    public  class Developer:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string CompanyName { get; set; }
        public string ApartmentName { get; set; }
        public string Position { get; set; }
        public string Bio { get; set; }
        public byte Experience { get; set; }
        public string AdditionalSkills { get; set; }
        public byte[] Photo { get; set; }
        public byte[] CV { get; set; }
    }
}
