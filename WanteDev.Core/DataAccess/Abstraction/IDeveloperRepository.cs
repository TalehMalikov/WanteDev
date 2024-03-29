﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WantedDev.Core.Domain.Entities;

namespace WantedDev.Core.DataAccess.Abstraction
{
    public interface IDeveloperRepository:ICrudRepository<Developer>
    {
        Developer Get(string email);
        bool UpdatePassword(string email, string passwordhash);
        void AddDeveloper(Developer developer);
        List<Developer> GetAllDevelopers();
    }
}
