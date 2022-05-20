﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Mappers;
using WanteDev.Models;

namespace WanteDev.Infrasturcture
{
    public class DataProvider
    {
        public readonly IUnitOfWork _db;
        public DataProvider(IUnitOfWork db)
        {
            _db = db;
        }

        public List<EmployerModel> GetEmployers()
        {
            var entities = Kernel.DB.EmployerRepository.GetAll();
            var employers = new List<EmployerModel>();
            EmployerMapper employerMapper = new EmployerMapper();
            for (int i = 0; i < entities.Count; i++)
            {
                var employer = entities[i];
                var employerModel = employerMapper.Map(employer);
                employerModel.NO = i + 1;
                employers.Add(employerModel);
            }

            return employers;
        }

        public List<ProgrammingLanguageModel> GetProgrammingLanguages()
        {
            var entities = Kernel.DB.ProgrammingLanguageRepository.GetAll();
            var languages = new List<ProgrammingLanguageModel>();
            ProgrammingLanguageMapper languageMapper = new ProgrammingLanguageMapper();
            for (int i = 0; i < entities.Count; i++)
            {
                var language = entities[i];
                var languageModel = languageMapper.Map(language);
                languageModel.NO = i + 1;
                languages.Add(languageModel);
            }
            return languages;
        }

        public List<DeveloperModel> GetDevelopersForSearch()
        {
            var entities = Kernel.DB.DeveloperRepository.GetAllSearch();
            var developers = new List<DeveloperModel>();
            DeveloperMapper mapper = new DeveloperMapper();
            for (int i = 0; i < entities.Count; i++)
            {
                var developer = entities[i];
                var developerModel = mapper.Map(developer);
                developerModel.NO = i + 1;
                developers.Add(developerModel);
            }
            return developers;
        }

    }
}
