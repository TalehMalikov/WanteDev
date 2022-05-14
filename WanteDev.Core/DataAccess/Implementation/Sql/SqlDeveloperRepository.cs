using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using WantedDev.Core.DataAccess.Abstraction;
using WantedDev.Core.Domain.Entities;
using WanteDev.Core.Extensions;

namespace WantedDev.Core.DataAccess.Implementation.Sql
{
    public class SqlDeveloperRepository : BaseRepository, IDeveloperRepository
    {
        public SqlDeveloperRepository(string connectionstring) : base(connectionstring)
        {
        }

        public void Add(Developer value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                string query = "Insert into Developers(FirstName, LastName, Email, PasswordHash, Address, Phone, BirthDate, Gender, CompanyName, ApartmentName, Position, Bio, Experience, AdditionalSkills, Photo, CV,ModifiedDate)" +
                               "output inserted.id values(@firstname,@lastname,@email,@passwordhash,@address,@phone,@birthdate,@gender,@companyname,@apartmentname,@position,@bio,@experience,@additionalskills,@photo,@CV,@modifieddate)";

                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@firstname", value.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", value.LastName);
                    cmd.Parameters.AddWithValue("@email", value.Email);
                    cmd.Parameters.AddWithValue("@passwordhash", value.PasswordHash);
                    cmd.Parameters.AddWithValue("@address", value.Address);
                    cmd.Parameters.AddWithValue("@phone", value.Phone);
                    cmd.Parameters.AddWithValue("@birthdate", value.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", value.Gender);
                    cmd.Parameters.AddWithValue("@companyname", value.CompanyName);
                    cmd.Parameters.AddWithValue("@apartmentname", value.ApartmentName);
                    cmd.Parameters.AddWithValue("@position", value.Position);
                    cmd.Parameters.AddWithValue("@bio", value.Bio);
                    cmd.Parameters.AddWithValue("@experience", short.Parse(value.Experience));
                    cmd.Parameters.AddWithValue("@additionalskills", value.AdditionalSkills);
                    cmd.Parameters.AddWithValue("@photo", value.Photo);
                    cmd.Parameters.AddWithValue("@CV", value.CV);
                    cmd.Parameters.AddWithValue("@modifieddate", value.ModifiedDate);
                    value.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public void AddDeveloper(Developer value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                string query = "Insert into Developers(FirstName, LastName, Email, PasswordHash, Address, Phone,BirthDate,Gender)" +
                               "output inserted.id values(@firstname,@lastname,@email,@passwordhash,@address,@phone,@birthdate,@gender)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@firstname", value.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", value.LastName);
                    cmd.Parameters.AddWithValue("@email", value.Email);
                    cmd.Parameters.AddWithValue("@passwordhash", value.PasswordHash);
                    cmd.Parameters.AddWithValue("@address", value.Address);
                    cmd.Parameters.AddWithValue("@phone", value.Phone);
                    cmd.Parameters.AddWithValue("@birthdate", value.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", value.Gender);
                    value.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string query = "update Developers set IsDeleted=@isdeleted where ID=@value and IsDeleted=0";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    cmd.Parameters.AddWithValue("@isdeleted", 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Developer Get(int id)
        {
            using (SqlConnection connection = new(_connectionstring))
            {
                connection.Open();
                using (SqlCommand cmd = new("select * from Developers where id = @id and IsDeleted=0"))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return GetFromReaderAsDeveloper(reader);
                        
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public Developer Get(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "select * from Developers where Email=@email and IsDeleted=0";
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

        public List<Developer> GetAllAsUser()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {

                List<Developer> list = new List<Developer>();
                connection.Open();
                string cmdText = "select * from Developers where IsDeleted=0";
                using (SqlCommand cmd = new(cmdText, connection))
                {
                    var reader = cmd.ExecuteReader();
                   while(reader.Read())
                    {
                        list.Add(GetFromReaderAsUser(reader));
                    }
                    return list;
                    
                }
            }
        }

        private Developer GetFromReaderAsUser(SqlDataReader reader)
        {
            return new Developer
            {
                Id = reader.Get<int>(nameof(Developer.Id)),
                Email = reader.Get<string>(nameof(Developer.Email)),
                PasswordHash = reader.Get<string>(nameof(Developer.PasswordHash))
            };
        }

        public List<Developer> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "select * from Developers where IsDeleted=0";

                List<Developer> developers = new List<Developer>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    Developer employee = null;

                    while (reader.Read())
                    {
                        employee = GetFromReaderAsDeveloper(reader);
                        developers.Add(employee);
                    }
                    return developers;
                }
            }
        }
        public List<Developer> GetAllDevelopers()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "select Id,FirstName,LastName,PasswordHash,Email,Phone,Address,BirthDate,Gender from Developers where IsDeleted=0";

                List<Developer> developers = new List<Developer>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    Developer employee = null;

                    while (reader.Read())
                    {
                        employee = GetFromReaderDeveloper(reader);
                        developers.Add(employee);
                    }
                    return developers;
                }
            }
        }

        public void Update(Developer value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "update Developers set FirstName=@firstname,LastName=@lastname,Email=@email," +
                    "PasswordHash=@passwordhash,Address=@address,Phone=@phone,BirthDate=@birthdate,Gender=@gender," +
                    "CompanyName=@companyname,ApartmentName=@apartmentname,Position=@position,Bio=@bio,Experience=@experience," +
                    "AdditionalSkills=@additionalskills,Photo=@photo,CV=@cv,ModifiedDate=@modifieddate where ID=@value and IsDeleted=0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@value", value.Id);
                    cmd.Parameters.AddWithValue("@firstname", value.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", value.LastName);
                    cmd.Parameters.AddWithValue("@email", value.Email);
                    cmd.Parameters.AddWithValue("@passwordhash", value.PasswordHash);
                    cmd.Parameters.AddWithValue("@address", value.Address);
                    cmd.Parameters.AddWithValue("@phone", value.Phone);
                    cmd.Parameters.AddWithValue("@birthdate", value.BirthDate);
                    cmd.Parameters.AddWithValue("@gender", value.Gender);
                    cmd.Parameters.AddWithValue("@companyname", value.CompanyName);
                    cmd.Parameters.AddWithValue("@apartmentname", value.ApartmentName);
                    cmd.Parameters.AddWithValue("@position", value.Position);
                    cmd.Parameters.AddWithValue("@bio", value.Bio);
                    cmd.Parameters.AddWithValue("@experience", value.Experience);
                    cmd.Parameters.AddWithValue("@additionalskills", value.AdditionalSkills);
                    cmd.Parameters.AddWithValue("@photo", value.Photo);
                    cmd.Parameters.AddWithValue("@CV", value.CV);
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
                string cmdText = "update Developers set PasswordHash=@passwordhash where Email=@email and IsDeleted=0";
                using (SqlCommand cmd = new(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordhash", passwordhash);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private Developer GetFromReaderAsDeveloper(SqlDataReader reader)
        {
            return new Developer()
            {
                Id=reader.Get<int>(nameof(Developer.Id)),
                FirstName=reader.Get<string>(nameof(Developer.FirstName)),
                LastName=reader.Get<string>(nameof(Developer.LastName)),
                Email=reader.Get<string>(nameof(Developer.Email)),
                PasswordHash=reader.Get<string>(nameof(Developer.PasswordHash)),
                Address=reader.Get<string>(nameof(Developer.Address)),
                Phone=reader.Get<string>(nameof(Developer.Phone)),
                BirthDate=reader.Get<DateTime>(nameof(Developer.BirthDate)),
                Gender=reader.Get<bool>(nameof(Developer.Gender)),
                CompanyName=reader.Get<string>(nameof(Developer.CompanyName)),
                ApartmentName=reader.Get<string>(nameof(Developer.ApartmentName)),
                Position=reader.Get<string>(nameof(Developer.Position)),
                Bio=reader.Get<string>(nameof(Developer.Bio)),
                Experience=reader.Get<string>(nameof(Developer.Experience)),
                AdditionalSkills=reader.Get<string>(nameof(Developer.AdditionalSkills)),
                Photo=reader.Get<byte[]>(nameof(Developer.Photo)),
                CV=reader.Get<byte[]>(nameof(Developer.CV))
            };
        }
        private Developer GetFromReaderDeveloper(SqlDataReader reader)
        {
            return new Developer()
            {
                Id = reader.Get<int>(nameof(Developer.Id)),
                FirstName = reader.Get<string>(nameof(Developer.FirstName)),
                LastName = reader.Get<string>(nameof(Developer.LastName)),
                Email = reader.Get<string>(nameof(Developer.Email)),
                PasswordHash = reader.Get<string>(nameof(Developer.PasswordHash)),
                Address = reader.Get<string>(nameof(Developer.Address)),
                Phone = reader.Get<string>(nameof(Developer.Phone)),
                BirthDate = reader.Get<DateTime>(nameof(Developer.BirthDate)),
                Gender = reader.Get<bool>(nameof(Developer.Gender))
            };
        }
    }
}
