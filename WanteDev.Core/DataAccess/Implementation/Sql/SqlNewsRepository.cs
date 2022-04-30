using System;
using System.Collections.Generic;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.Domain.Entities;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class SqlNewsRepository : BaseRepository, INewsRepository
    {
        public SqlNewsRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(News value)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public News Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<News> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(News value)
        {
            throw new NotImplementedException();
        }
    }
}
