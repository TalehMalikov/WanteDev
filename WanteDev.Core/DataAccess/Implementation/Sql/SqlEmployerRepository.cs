using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Extensions;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class SqlEmployerRepository : BaseRepository, IEmployerRepository
    {
        public SqlEmployerRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(Employer value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                string query = "Insert into Employers(FirstName, LastName, Email, PasswordHash, Address, Phone, BirthDate, Gender, CompanyName, ApartmentName, Position, Bio, Photo,ModifiedDate)" +
                               "output inserted.id values(@firstname,@lastname,@email,@passwordhash,@adress,@phone,@birthdate,@gender,@companyname,@apartmentname,@position,@bio,@photo,@modifieddate)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@firstname", value.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", value.LastName);
                    cmd.Parameters.AddWithValue("@email", value.Email);
                    cmd.Parameters.AddWithValue("@passwordhash", value.PasswordHash);
                    cmd.Parameters.AddWithValue("@adress", value.Adress);
                    cmd.Parameters.AddWithValue("@phone", value.Phone);
                    cmd.Parameters.AddWithValue("@birthdate", value.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", value.Gender);
                    cmd.Parameters.AddWithValue("@companyname", value.CompanyName);
                    cmd.Parameters.AddWithValue("@apartmentname", value.ApartmentName);
                    cmd.Parameters.AddWithValue("@position", value.Position);
                    cmd.Parameters.AddWithValue("@bio", value.Bio);
                    cmd.Parameters.AddWithValue("@photo", value.Photo);
                    cmd.Parameters.AddWithValue("@modifieddate", value.ModifiedDate);

                    value.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "update Employers set IsDeleted=@isdeleted where ID=@value and IsDeleted=0";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    cmd.Parameters.AddWithValue("@isdeleted", 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Employer Get(int id)
        {
            using (SqlConnection connection = new(_connectionstring))
            {
                connection.Open();
                using (SqlCommand cmd = new("select * from Employers where id = @id and IsDeleted=0"))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return GetFromReaderAsEmployer(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public Employer Get(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "select * from Employers where Email=@email and IsDeleted=0";
                using (SqlCommand cmd = new(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return GetFromReaderAsUser(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public List<Employer> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "select * from Employers where IsDeleted=0";

                List<Employer> employers = new List<Employer>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    Employer employer = null;

                    while (reader.Read())
                    {
                        employer = GetFromReaderAsEmployer(reader);
                        employers.Add(employer);
                    }
                    return employers;
                }
            }
        }

        public void Update(Employer value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "update Employers set FirstName=@firstname,LastName=@lastname,Email=@email," +
                    "PasswordHash=@passwordhash,Address=@adress,Phone=@phone,BirthDate=@birthdate," +
                    "Gender=@gender,CompanyName=@companyname,ApartmentName=@apartmentname,Position=@position," +
                    "Bio=@bio,Photo=@photo,ModifiedDate=@modifieddate where ID=@value and IsDeleted=0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@value", value.Id);
                    cmd.Parameters.AddWithValue("@firstname", value.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", value.LastName);
                    cmd.Parameters.AddWithValue("@email", value.Email);
                    cmd.Parameters.AddWithValue("@passwordhash", value.PasswordHash);
                    cmd.Parameters.AddWithValue("@adress", value.Adress);
                    cmd.Parameters.AddWithValue("@phone", value.Phone);
                    cmd.Parameters.AddWithValue("@birthdate", value.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", value.Gender);
                    cmd.Parameters.AddWithValue("@companyname", value.CompanyName);
                    cmd.Parameters.AddWithValue("@apartmentname", value.ApartmentName);
                    cmd.Parameters.AddWithValue("@position", value.Position);
                    cmd.Parameters.AddWithValue("@bio", value.Bio);
                    cmd.Parameters.AddWithValue("@photo", value.Photo);
                    cmd.Parameters.AddWithValue("@modifieddate", value.ModifiedDate);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool UpdatePassword(string email, string passwordhash)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "update Employers set PasswordHash=@passwordhash where Email=@email and IsDeleted=0";
                using (SqlCommand cmd = new(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordhash", passwordhash);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private Employer GetFromReaderAsUser(SqlDataReader reader)
        {
            return new Employer
            {
                Id = reader.Get<int>(nameof(Employer.Id)),
                Email = reader.Get<string>(nameof(Employer.Email)),
                PasswordHash = reader.Get<string>(nameof(Employer.PasswordHash))
            };
        }

        private Employer GetFromReaderAsEmployer(SqlDataReader reader)
        {
            return new Employer()
            {
                Id = reader.Get<int>(nameof(Employer.Id)),
                FirstName = reader.Get<string>(nameof(Employer.FirstName)),
                LastName = reader.Get<string>(nameof(Employer.LastName)),
                Email = reader.Get<string>(nameof(Employer.Email)),
                PasswordHash = reader.Get<string>(nameof(Employer.PasswordHash)),
                Adress = reader.Get<string>(nameof(Employer.Adress)),
                Phone = reader.Get<string>(nameof(Employer.Phone)),
                BirthDate = reader.Get<DateTime>(nameof(Employer.BirthDate)),
                Gender = reader.Get<bool>(nameof(Employer.Gender)),
                CompanyName = reader.Get<string>(nameof(Employer.CompanyName)),
                ApartmentName = reader.Get<string>(nameof(Employer.ApartmentName)),
                Position = reader.Get<string>(nameof(Employer.Position)),
                Bio = reader.Get<string>(nameof(Employer.Bio)),
                Photo = reader.Get<byte[]>(nameof(Employer.Photo)),
            };
        }
    }
}
