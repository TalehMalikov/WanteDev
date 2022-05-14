using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Utils;

namespace WanteDev.Models
{
    public class DeveloperModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now.Date;
        public bool Gender { get; set; }
        public string CompanyName { get; set; }
        public string ApartmentName { get; set; }
        public string Position { get; set; }
        public string Bio { get; set; }
        public byte[] Photo { get; set; }
        public byte[] CV { get; set; }
        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override bool IsValid(out string message)
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                message = ValidationHelper.GetRequiredMessage("First Name");
                return false;
            }
            if (string.IsNullOrEmpty(LastName))
            {
                message = ValidationHelper.GetRequiredMessage("Last Name");
                return false;
            }
            if (string.IsNullOrEmpty(PasswordHash))
            {
                message = ValidationHelper.GetRequiredMessage("Password");
                return false;
            }
            if (string.IsNullOrEmpty(Email))
            {
                message = ValidationHelper.GetRequiredMessage("Email");
                return false;
            }
            if (string.IsNullOrEmpty(Phone))
            {
                message = ValidationHelper.GetRequiredMessage("Phone number");
                return false;
            }
            if (string.IsNullOrEmpty(Address))
            {
                message = ValidationHelper.GetRequiredMessage("Address");
                return false;
            }
            if (string.IsNullOrEmpty(CompanyName))
            {
                message = ValidationHelper.GetRequiredMessage(nameof(CompanyName));
                return false;
            }
            if(CV is null)
            {
                message = ValidationHelper.GetRequiredMessage(nameof(CV));
                return false;
            }
            //if (Gender)
            //{
            //    message = ValidationHelper.GetRequiredMessage(nameof(CV));
            //    return false;
            //}
            message = string.Empty;
            return true;
        }

    }
}
