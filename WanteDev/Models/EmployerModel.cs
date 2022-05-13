using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WanteDev.Models
{
    public class EmployerModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now.Date;
        public bool Gender { get; set; }
        public string CompanyName { get; set; }
        public string ApartmentName { get; set; }
        public string Position { get; set; }
        public string Bio { get; set; }
        public byte[] Photo { get; set; }
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override bool IsValid(out string message)
        {
            throw new NotImplementedException();
        }

        public override string ToExcelString()
        {
            throw new NotImplementedException();
        }
    }
}
