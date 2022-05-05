using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Models;
using WanteDev.Utils;

namespace WanteDev.Infrasturcture
{
    public class DataValidator
    {
        private readonly IUnitOfWork _db;

        public DataValidator(IUnitOfWork db)
        {
            _db = db;
        }

        public bool IsDeveloperValid(DeveloperModel currentDeveloper, out string message)
        {
            if (currentDeveloper.IsValid(out message) == false)
                return false;
            var allDevelopers = _db.DeveloperRepository.GetAllDevelopers();

            //Name
            if (currentDeveloper.FirstName.Any(x=>char.IsLetter(x)==false))
            {
                message = ValidationHelper.GetLetterMessage("First Name");
                return false;
            }

            //Surname
            if (currentDeveloper.LastName.Any(x => char.IsLetter(x) == false))
            {
                message = ValidationHelper.GetLetterMessage("Last Name");
                return false;
            }
            //Password
            if (currentDeveloper.PasswordHash.Length < 8)
            {
                message = "Password length must be equal and greater than 8";
                return false;
            }

            if (!currentDeveloper.PasswordHash.Any(char.IsUpper))
            {
                message = "Password must contain at least one capital letter";
                return false;
            }

            if (!currentDeveloper.PasswordHash.Any(char.IsLower))
            {
                message = "Password must contain at least one lower letter";
                return false;
            }

            if (!currentDeveloper.PasswordHash.Any(char.IsDigit))
            {
                message = "Password must contain at least one digit";
                return false;
            }
            /*if (!currentDeveloper.PasswordHash.Any(char.IsSymbol))
            {
                message = "Password must contain at least one symbol";
                return false;
            }*/

            //Email
            if (currentDeveloper.Email.Contains('@') == false || currentDeveloper.Email.Contains('.') == false)
            {
                message = "Email must contain @ and . ";
                //xxxxx@xxxxx.xxx
                return false;
            }
            char[] permittedSymbols = { '@','.'};

            if (currentDeveloper.Email.All(x => (x >= 'A' && x <= 'Z')
                                               || (x >= 'a' && x <= 'z')
                                               || char.IsNumber(x)
                                               || permittedSymbols.Contains(x)) == false)
            {
                message = "Email address should contain only letters, numbers and '@','.' symbols";
                return false;
            }
            if (allDevelopers.Any(x => x.Id != currentDeveloper.Id && x.Email == currentDeveloper.Email))
            {
                message = ValidationHelper.GetUniqueMessage("Email");
                return false;
            }
            // Phone Number
            if (currentDeveloper.Phone.Length != 10)
            {
                message = ValidationHelper.GetRequiredLength("Phone number", 10);
                return false;
            }
            if (currentDeveloper.Phone.All(x => char.IsNumber(x)) == false)
            {
                message = ValidationHelper.GetLetterMessage("Phone Number");
                return false;
            }
            if (allDevelopers.Any(x => x.Id != currentDeveloper.Id && x.Phone == currentDeveloper.Phone))
            {
                message = ValidationHelper.GetUniqueMessage("Phone Number");
                return false;
            }
            //Date
            int age = DateUtil.GetAge(currentDeveloper.BirthDate);
            if (age<15)
            {
                message = "Users who are smaller than 14 can't sign up";
                return false;
            }
            message = string.Empty;
            return true;
        }
        
    }
}
