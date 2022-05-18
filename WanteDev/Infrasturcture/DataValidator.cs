
using System;
using System.Collections.Generic;
using System.Linq;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Core.Domain.Entities;
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



        public bool IsDeveloperValid(EmployerModel currentEmployer, out string message)
        {
            List<Developer> devModels = new List<Developer>(_db.DeveloperRepository.GetAllAsUser());
            List<Employer> empModels = new List<Employer>(_db.EmployerRepository.GetAllAsUser());
            List<Admin> adModels = new List<Admin>(_db.AdminRepository.GetAllAsUser());
            if (currentEmployer.IsValid(out message) == false)
                return false;

           
                #region EmailCheck
                bool resultDev = devModels.Any(x => x.Email == currentEmployer.Email);
                bool resultAdm = adModels.Any(x => x.Email == currentEmployer.Email);
                bool resultEmp = empModels.Any(x => x.Email == currentEmployer.Email);
                if (resultDev || resultEmp || resultAdm)
                {
                    message = ValidationHelper.GetUniqueMessage("Email");
                    return false;
                }
                #endregion

            //Name
            if (currentEmployer.FirstName.Any(x => char.IsLetter(x) == false))
            {
                message = ValidationHelper.GetLetterMessage("First Name");
                return false;
            }

            //Surname
            if (currentEmployer.LastName.Any(x => char.IsLetter(x) == false))
            {
                message = ValidationHelper.GetLetterMessage("Last Name");
                return false;
            }
            //Password
            if (currentEmployer.PasswordHash.Length < 8)
            {
                message = "Password length must be equal and greater than 8";
                return false;
            }

            if (!currentEmployer.PasswordHash.Any(char.IsUpper))
            {
                message = "Password must contain at least one capital letter";
                return false;
            }

            if (!currentEmployer.PasswordHash.Any(char.IsLower))
            {
                message = "Password must contain at least one lower letter";
                return false;
            }

            if (!currentEmployer.PasswordHash.Any(char.IsDigit))
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
            if (currentEmployer.Email.Contains('@') == false || currentEmployer.Email.Contains('.') == false)
            {
                message = "Email must contain @ and . ";
                //xxxxx@xxxxx.xxx
                return false;
            }
            char[] permittedSymbols = { '@', '.' };

            if (currentEmployer.Email.All(x => (x >= 'A' && x <= 'Z')
                                               || (x >= 'a' && x <= 'z')
                                               || char.IsNumber(x)
                                               || permittedSymbols.Contains(x)) == false)
            {
                message = "Email address should contain only letters, numbers and '@','.' symbols";
                return false;
            }



            // Phone Number
            if (currentEmployer.Phone.Length != 10)
            {
                message = ValidationHelper.GetRequiredLength("Phone number", 10);
                return false;
            }
            if (currentEmployer.Phone.All(x => char.IsNumber(x)) == false)
            {
                message = ValidationHelper.GetLetterMessage("Phone Number");
                return false;
            }
            if (devModels.Any(x => x.Id != currentEmployer.Id && x.Phone == currentEmployer.Phone))
            {
                message = ValidationHelper.GetUniqueMessage("Phone Number");
                return false;
            }
            //Date
            int age = DateUtil.GetAge(currentEmployer.BirthDate);
            if (age < 15)
            {
                message = "Users who are smaller than 14 can't sign up";
                return false;
            }
            message = string.Empty;
            return true;
        }



        public bool IsDeveloperValid(DeveloperModel currentDeveloper, out string message)
        {
            List<Developer> devModels = new List<Developer>(_db.DeveloperRepository.GetAllAsUser());
            List<Employer> empModels = new List<Employer>(_db.EmployerRepository.GetAllAsUser());
            List<Admin> adModels = new List<Admin>(_db.AdminRepository.GetAllAsUser());
            if (currentDeveloper.IsValid(out message) == false)
                return false;

            if (true)
            {
                #region EmailCheck
                bool resultDev = devModels.Any(x => x.Email == currentDeveloper.Email);
                bool resultAdm = adModels.Any(x => x.Email == currentDeveloper.Email);
                bool resultEmp = empModels.Any(x => x.Email == currentDeveloper.Email);
                if (resultDev || resultEmp || resultAdm)
                {
                    message = ValidationHelper.GetUniqueMessage("Email");
                    return false;
                }
                #endregion
            }




            //Name
            if (currentDeveloper.FirstName.Any(x => char.IsLetter(x) == false))
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
            char[] permittedSymbols = { '@', '.' };

            if (currentDeveloper.Email.All(x => (x >= 'A' && x <= 'Z')
                                               || (x >= 'a' && x <= 'z')
                                               || char.IsNumber(x)
                                               || permittedSymbols.Contains(x)) == false)
            {
                message = "Email address should contain only letters, numbers and '@','.' symbols";
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
            if (devModels.Any(x => x.Id != currentDeveloper.Id && x.Phone == currentDeveloper.Phone))
            {
                message = ValidationHelper.GetUniqueMessage("Phone Number");
                return false;
            }
            //Date
            int age = DateUtil.GetAge(currentDeveloper.BirthDate);
            if (age < 15)
            {
                message = "Users who are smaller than 14 can't sign up";
                return false;
            }
            message = string.Empty;
            return true;
        }

    }
}
