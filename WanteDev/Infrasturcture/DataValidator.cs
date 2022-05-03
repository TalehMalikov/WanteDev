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
            var allDevelopers = _db.DeveloperRepository.GetAll();

            //Name
            if (currentDeveloper.FirstName.Any(x=>char.IsLetter(x)==false))
            {
                message = ValidationHelper.GetLetterMessage("First Name");
            }

            //Surname
            if (currentDeveloper.LastName.Any(x => char.IsLetter(x) == false))
            {
                message = ValidationHelper.GetLetterMessage("Last Name");
            }

            //Email
            if (currentDeveloper.Email.Contains('@') == false || currentDeveloper.Email.Contains('.') == false)
            {
                message = "Email must contain @ and .";
                return false;
            }
            char[] permittedSymbols = { '@','.'};

            if (currentDeveloper.Email.All(x => (x >= 'A' && x <= 'Z')
                                               || (x >= 'a' && x <= 'z')
                                               || char.IsNumber(x)
                                               || permittedSymbols.Contains(x)) == false)
            {
                message = "Email address should contain only letters, numbers and @ . symbols";
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
                message = ValidationHelper.GetUniqueMessage("Phone");
                return false;
            }

            message = string.Empty;
            return true;
        }
        
    }
}
