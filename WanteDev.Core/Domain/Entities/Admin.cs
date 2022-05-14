using System;

namespace WanteDev.Core.Domain.Entities
{
    public class Admin:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Gender { get; set; }
        public string Position { get; set; }
        public byte[] Photo { get; set; }
    }
}
