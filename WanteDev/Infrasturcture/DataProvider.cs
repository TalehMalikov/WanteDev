using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.DataAccess.Abstraction;

namespace WanteDev.Infrasturcture
{
    public class DataProvider
    {
        public readonly IUnitOfWork DB;
        public DataProvider(IUnitOfWork db)
        {
            DB = db;
        }

        //methods
    }
}
