using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class BaseRepository
    {
        public string _connectionstring { get; set; }
        public BaseRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
    }
}
