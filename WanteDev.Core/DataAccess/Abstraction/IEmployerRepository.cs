using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WantedDev.Core.Domain.Entities;

namespace WantedDev.Core.DataAccess.Abstraction
{
    public interface IEmployerRepository:ICrudRepository<Employer>
    {
        Employer Get(string email);
        bool UpdatePassword(string email, string passwordhash);
        List<Employer> GetAllAsUser();
    }
}
