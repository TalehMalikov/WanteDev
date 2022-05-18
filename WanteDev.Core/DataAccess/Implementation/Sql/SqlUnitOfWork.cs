using System;
using System.Collections.Generic;
using System.Linq;
using WantedDev.Core.DataAccess.Abstraction;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Core.DataAccess.Implementation.Sql;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    internal class SqlUnitOfWork : BaseRepository,IUnitOfWork
    {
        public SqlUnitOfWork(string connectionstring) : base(connectionstring)
        {
        }
        public IDeveloperExamRepository DeveloperExamRepository => new SqlDeveloperExamRepository(_connectionstring);

        public IDeveloperLanguageRepository DeveloperLanguageRepository => new SqlDeveloperLanguageRepository(_connectionstring);

        public IDeveloperRepository DeveloperRepository => new SqlDeveloperRepository(_connectionstring);

        public IExamRepository ExamRepository => new SqlExamRepository(_connectionstring);

        public IEmployerRepository EmployerRepository => new SqlEmployerRepository(_connectionstring);

        public INewsRepository NewsRepository => new SqlNewsRepository(_connectionstring);

        public IProgrammingLanguageRepository ProgrammingLanguageRepository => new SqlProgrammingLanguageRepository(_connectionstring);

        public IAdminRepository AdminRepository => new SqlAdminRepository(_connectionstring);
    }
}
