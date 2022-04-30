using System;
using System.Data.SqlClient;

namespace WanteDev.Core.Extensions
{
    public static class SqlDataReaderExtension
    {

        public static T Get<T>(this SqlDataReader reader, string columnName)
        {
            object val = null;
            if (reader.HasRows)
            {
                val = reader[columnName];
            }

            T result = default;

            if (val != DBNull.Value && val != null)
            {
                result = (T)val;
            }
            return result;
        }

    }
}