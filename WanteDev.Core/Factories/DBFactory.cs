using System;
using WantedDev.Core.DataAccess.Implementation.Sql;
using WantedDev.Core.Domain.Enums;
using WanteDev.Core.DataAccess.Abstraction;

namespace WanteDev.Core.Factories
{
    public static class DBFactory
    {
        private static SqlUnitOfWork SqlUnitOfWork;
        public static IUnitOfWork Create(ServerType servertype, string connectionstring)
        {
            if (servertype == ServerType.MsSql)
                return SqlUnitOfWork ??= new SqlUnitOfWork(connectionstring);
            throw new NotSupportedException("Only Microsoft SQL Server is Supported.");
        }
    }
}
