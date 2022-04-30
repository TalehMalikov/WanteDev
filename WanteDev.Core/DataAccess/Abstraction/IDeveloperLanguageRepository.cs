using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WantedDev.Core.Domain.Entities;

namespace WantedDev.Core.DataAccess.Abstraction
{
    public interface IDeveloperLanguageRepository:ICrudRepository<DeveloperLanguage>
    {
    }
}
