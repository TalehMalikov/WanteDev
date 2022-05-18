using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Extensions;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class SqlProgrammingLanguageRepository :BaseRepository, IProgrammingLanguageRepository
    {
        public SqlProgrammingLanguageRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(ProgrammingLanguage value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "Insert into ProgrammingLanguages output inserted.id values(@Name,@IsDeleted)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("name", value.Name);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                value.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "delete from ProgrammingLanguages where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                command.ExecuteNonQuery();

            }
        }

        public ProgrammingLanguage Get(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "select * from ProgrammingLanguages where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    var exam = GetFromReader(reader);
                    return exam;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<ProgrammingLanguage> GetAll()
        {
            using(var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "select * from ProgrammingLanguages";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                var list = new List<ProgrammingLanguage>();
                while (reader.Read())
                {
                    var exam = GetFromReader(reader);
                    list.Add(exam);
                }
                return list;
            }
        }

        public void Update(ProgrammingLanguage value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "update ProgrammingLanguages set Name=@name,IsDeleted=@isdeleted where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", value.Id);
                command.Parameters.AddWithValue("name", value.Name);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                command.ExecuteNonQuery();

            }
        }

        private ProgrammingLanguage GetFromReader(SqlDataReader reader)
        {
            return new ProgrammingLanguage
            {
                Id = reader.Get<int>("Id"),
                Name = reader.Get<string>("Name"),
                IsDeleted = reader.Get<bool>("IsDeleted")
            };
        }
    }
}
