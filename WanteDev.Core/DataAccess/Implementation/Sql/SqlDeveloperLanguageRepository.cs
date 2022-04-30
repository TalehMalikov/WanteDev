using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Extensions;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class SqlDeveloperLanguageRepository : BaseRepository, IDeveloperLanguageRepository
    {
        public SqlDeveloperLanguageRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(DeveloperLanguage value)
        {
            using (var connection=new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "Insert into DeveloperLanguages output inserted.id values(@DeveloperId,@ProgrammingLanguageId,@IsDeleted)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("developerid", value.Developer.Id);
                command.Parameters.AddWithValue("programminglanguageid", value.ProgrammingLanguage.Id);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                value.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            using (var connection=new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "delete from DeveloperLanguages where Id=@id";
                var command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("Id", id);
                command.ExecuteNonQuery();
            }
        }

        public DeveloperLanguage Get(int id)
        {
            using (var connection=new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "select * from DeveloperLanguages where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var developerLanguage = GetFromReader(reader);
                    return developerLanguage;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<DeveloperLanguage> GetAll()
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "select * from DeveloperLanguages";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                var list = new List<DeveloperLanguage>();
                while (reader.Read())
                {
                    var developerLanguage = GetFromReader(reader);
                    list.Add(developerLanguage);
                }

                return list;
            }
        }

        public void Update(DeveloperLanguage value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "update DeveloperLanguages set DeveloperId=@developerid,ProgrammingLanguageId=@programminglanguageid,IsDeleted=@isdeleted where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", value.Id);
                command.Parameters.AddWithValue("developerid", value.Developer.Id);
                command.Parameters.AddWithValue("programminglanguageid", value.ProgrammingLanguage.Id);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                command.ExecuteNonQuery();
            }
        }
        private DeveloperLanguage GetFromReader(SqlDataReader reader)
        {
            return new DeveloperLanguage
            {
                Id = reader.Get<int>("Id"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
                Developer = new Developer
                {
                    Id = reader.Get<int>("DeveloperId")
                },
                ProgrammingLanguage = new ProgrammingLanguage
                {
                    Id = reader.Get<int>("ProgrammingLanguageId")
                }
            };
        }
    }
}
