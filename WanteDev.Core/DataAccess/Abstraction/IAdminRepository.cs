
using System.Collections.Generic;
using WantedDev.Core.DataAccess.Abstraction;
using WanteDev.Core.Domain.Entities;

namespace WanteDev.Core.DataAccess.Abstraction
{
    public interface IAdminRepository : ICrudRepository<Admin>
    {
        Admin Get(string email);
        bool UpdatePassword(string email, string passwordhash);
        List<Admin> GetAllAsUser();
    }
}
