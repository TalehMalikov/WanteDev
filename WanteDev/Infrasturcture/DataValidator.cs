
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Core.Domain.Entities;
using WanteDev.Models;
using WanteDev.Utils;
using System.Diagnostics;
using Newtonsoft.Json;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable SYSLIB0014 // Type or member is obsolete

namespace WanteDev.Infrasturcture
{
    public class DataValidator
    {

        private class Response
        {
            public string result { get; set; }
            public string reason { get; set; }
        }
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
            bool resultEmp = empModels.Any(x => x.Email == currentEmployer.Email && x.Id != currentEmployer.Id);
            if (resultDev || resultEmp || resultAdm)
            {
                message = ValidationHelper.GetUniqueMessage("Email");
                return false;
            }

            try
            {
                string apiKey = "e994902b6e61b201cb70723f8577b53ff462db535cb229917d53505b9fbd";
                string emailToValidate = currentEmployer.Email;
                string? responseString = "";
                string apiURL = "http://api.quickemailverification.com/v1/verify?email=" + WebUtility.UrlEncode(emailToValidate) + "&apikey=" + apiKey;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiURL);
                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {

                    using (StreamReader ostream = new StreamReader(response.GetResponseStream()))
                    {
                        responseString = ostream.ReadLine();
                    }
                }

                Response info = JsonConvert.DeserializeObject<Response>(responseString);
                if (info == null)
                {
                    message = "Something went wrong";
                    return false;
                }
                //if (info.reason == "rejected_email")
                //{
                //    message = "Enter existed email";
                //    return false;
                //}
                if (info.result == "invalid")
                {
                    message = $"Either format incorrect or {currentEmployer.Email} does not exist";
                    return false;
                }
                if (info.reason == "no_connect")
                {
                    message = "Check your network, please";
                    return false;
                }
            }
            catch (Exception ex)
            {
                message = "Something went wrong... Check your internet";
                return false;
                //Catch Exception - All errors will be shown here - if there are issues with the API
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



            //Name Validation
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
