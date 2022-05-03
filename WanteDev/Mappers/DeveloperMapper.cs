using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WantedDev.Core.Domain.Entities;
using WanteDev.Models;

namespace WanteDev.Mappers
{
    public class DeveloperMapper:BaseMapper<Developer,DeveloperModel>
    {
        public override Developer Map(DeveloperModel model)
        {
            return new Developer()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                Address = model.Address,
                Phone = model.Phone,
                BirthDate = model.BirthDate,
                Gender = model.Gender,
                CompanyName = model.CompanyName,
                ApartmentName = model.ApartmentName,
                Position = model.Position,
                Bio = model.Bio,
                Experience = model.Experience,
                AdditionalSkills = model.AdditionalSkills,
                Photo = model.Photo,
                CV = model.CV
            };
        }

        public override DeveloperModel Map(Developer entity)
        {
            return new DeveloperModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                Address = entity.Address,
                Phone = entity.Phone,
                BirthDate = entity.BirthDate,
                Gender = entity.Gender,
                CompanyName = entity.CompanyName,
                ApartmentName = entity.ApartmentName,
                Position = entity.Position,
                Bio = entity.Bio,
                Experience = entity.Experience,
                AdditionalSkills = entity.AdditionalSkills,
                Photo = entity.Photo,
                CV = entity.CV
            };
        }
    }
}
