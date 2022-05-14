using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Models;

namespace WanteDev.Utils
{
    public static class UserDefaultFiller
    {
        public static void Fill(EmployerModel model)
        {
           if(model.Bio is null)
            {
                model.Bio =String.Empty;
            }
           if(model.Photo is null)
            {
                model.Photo = File.ReadAllBytes(@"Images\avatar.jpg");
            }

        }
        public static void Fill(DeveloperModel model)
        {
            if (model.Bio is null)
            {
                model.Bio = String.Empty;
            }

            if (model.Photo is null)
            {
                model.Photo = File.ReadAllBytes(@"\Images\avatar.jpg");
            }

            if(model.ApartmentName is null)
            {
                model.ApartmentName = String.Empty;
            }  

            if(model.CompanyName is null)
            {
                model.CompanyName = String.Empty;
            }

            if (model.Position is null)
            {
                model.Position = String.Empty;
            }
        }

    }
}
