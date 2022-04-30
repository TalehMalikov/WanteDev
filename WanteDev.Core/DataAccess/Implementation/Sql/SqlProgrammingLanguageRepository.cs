using System;
using System.Collections.Generic;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.Domain.Entities;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class SqlProgrammingLanguageRepository :BaseRepository, IProgrammingLanguageRepository
    {
        public SqlProgrammingLanguageRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(ProgrammingLanguage value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProgrammingLanguage Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProgrammingLanguage> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProgrammingLanguage value)
        {
            throw new NotImplementedException();
        }
    }
}
