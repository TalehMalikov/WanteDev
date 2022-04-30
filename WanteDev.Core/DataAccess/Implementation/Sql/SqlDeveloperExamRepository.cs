using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.DataAccess.Implementation.Sql;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Extensions;

namespace WanteDev.Core.DataAccess.Implementation.Sql
{
    public class SqlDeveloperExamRepository : BaseRepository, IDeveloperExamRepository
    {
        public SqlDeveloperExamRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(DeveloperExam value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "Insert into DeveloperExams output inserted.id values(@DeveloperId,@ExamId,@Result,@Date,@IsDeleted)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("developerid", value.Developer.Id);
                command.Parameters.AddWithValue("examid", value.Exam.Id);
                command.Parameters.AddWithValue("result", value.Result);
                command.Parameters.AddWithValue("date", value.Date);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                value.Id = Convert.ToInt32(command.ExecuteScalar());

            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "delete from DeveloperExams where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                command.ExecuteNonQuery();
            }
        }

        public DeveloperExam Get(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "select * from  DeveloperExams Id= @id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Id", id);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var developerExam = GetFromReader(reader);
                    return developerExam;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<DeveloperExam> GetAll()
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                string query = "select * from DeveloperExams";
                var command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                var list = new List<DeveloperExam>();

                while (reader.Read())
                {
                    var developerExam = GetFromReader(reader);
                    list.Add(developerExam);
                }

                return list;

            }
        }

        public void Update(DeveloperExam value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "update DeveloperExams set DeveloperId=@developerid,ExamId=@examid,Result=@result,Date=@date,IsDeleted=@isdeleted where Id=@id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", value.Id);
                command.Parameters.AddWithValue("developerid", value.Developer.Id);
                command.Parameters.AddWithValue("examid", value.Exam.Id);
                command.Parameters.AddWithValue("result", value.Result);
                command.Parameters.AddWithValue("date", value.Date);
                command.Parameters.AddWithValue("isdeleted", value.IsDeleted);
                command.ExecuteNonQuery();
            }
        }

        private DeveloperExam GetFromReader(SqlDataReader reader)
        {
            return new DeveloperExam
            {
                Id = reader.Get<int>("Id"),
                Result = reader.Get<double>("Result"),
                Date = reader.Get<DateTime>("Date"),
                IsDeleted = reader.Get<bool>("IsDeleted"),
                Developer = new Developer
                {
                    Id = reader.Get<int>("DeveloperId")
                },
                Exam = new Exam
                {
                    Id = reader.Get<int>("ExamId")
                }
            };
        }
    }
}
