using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WantedDev.Core.DataAccess.Abstraction;

namespace WanteDev.Core.DataAccess.Abstraction
{
    public interface IUnitOfWork
    {
        IDeveloperExamRepository DeveloperExamRepository { get; }
        IDeveloperLanguageRepository DeveloperLanguageRepository { get; }
        IDeveloperRepository DeveloperRepository { get; }
        IExamRepository ExamRepository { get; }
        IEmployerRepository EmployerRepository { get; }
        INewsRepository NewsRepository { get; }
        IAdminRepository AdminRepository { get; }
        IProgrammingLanguageRepository ProgrammingLanguageRepository { get; }
    }
}
