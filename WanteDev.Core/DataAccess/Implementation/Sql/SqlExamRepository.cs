using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Extensions;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class SqlExamRepository : BaseRepository, IExamRepository
    {
        public SqlExamRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(Exam value)
        {
            using (var connection=new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "Insert into Exams output inserted.id values(@Name,@Price,@IsDeleted)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("name", value.Name);
                command.Parameters.AddWithValue("price", value.Price);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                value.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "delete from Exams where Id=@id";
                var command = new SqlCommand(query,connection);
                command.Parameters.AddWithValue("Id", id);
                command.ExecuteNonQuery();

            }
        }

        public Exam Get(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "select * from Exams where Id=@id";
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

        public List<Exam> GetAll()
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "select * from Exams";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                var list = new List<Exam>();
                while (reader.Read())
                {
                    var exam = GetFromReader(reader);
                    list.Add(exam);
                }

                return list;
            }
        }

        public void Update(Exam value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "update Exams set Name=@name,Price=@price,IsDeleted=@isdeleted where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", value.Id);
                command.Parameters.AddWithValue("name", value.Name);
                command.Parameters.AddWithValue("price", value.Price);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                command.ExecuteNonQuery();

            }
        }
        private Exam GetFromReader(SqlDataReader reader)
        {
            return new Exam
            {
                Id = reader.Get<int>("Id"),
                Name=reader.Get<string>("Name"),
                Price = reader.Get<double>("Price"),
                IsDeleted = reader.Get<bool>("IsDeleted")
            };
        }
    }
}
