using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WantedDev.Core.DataAccess.Implementation.Sql;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Core.Domain.Entities;
using WanteDev.Core.Extensions;

namespace WanteDev.Core.DataAccess.Implementation.Sql
{
    public class SqlAdminRepository : BaseRepository, IAdminRepository
    {
        public SqlAdminRepository(string connectionstring) : base(connectionstring)
        {

        }

        public void Add(Admin value)
        {
            using (var connection = new SqlConnection(_connectionstring))
            {
                connection.Open();

                string query = "Insert into Employers(FirstName, LastName, Email, PasswordHash, Adress, Phone, BirthDate, Gender, Position, Photo,ModifiedDate)" +
                               "output inserted.id values(@firstname,@lastname,@email,@passwordhash,@adress,@phone,@birthdate,@gender,@position,@photo,@modifieddate)";

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
                    cmd.Parameters.AddWithValue("@position", value.Position);
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
                string query = "update Admins set IsDeleted=@isdeleted where ID=@value and IsDeleted=0";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@value", id);
                    cmd.Parameters.AddWithValue("@isdeleted", 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Admin Get(int id)
        {
            using (SqlConnection connection = new(_connectionstring))
            {
                connection.Open();
                using (SqlCommand cmd = new("select * from Admins where id = @id and IsDeleted=0"))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return GetFromReaderAsAdmin(reader);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public Admin Get(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "select * from Admins where Email=@email and IsDeleted=0";
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

        private Admin GetFromReaderAsUser(SqlDataReader reader)
        {
            return new Admin
            {
                Id = reader.Get<int>(nameof(Admin.Id)),
                Email = reader.Get<string>(nameof(Admin.Email)),
                PasswordHash = reader.Get<string>(nameof(Admin.PasswordHash))
            };
        }

        public List<Admin> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "select * from Admins where IsDeleted=0";

                List<Admin> employers = new List<Admin>();
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    Admin admin = null;

                    while (reader.Read())
                    {
                        admin = GetFromReaderAsAdmin(reader);
                        employers.Add(admin);
                    }
                    return employers;
                }
            }
        }

        public void Update(Admin value)
        {
            using (SqlConnection connection = new SqlConnection(_connectionstring))
            {
                connection.Open();
                string cmdText = "update Admins set FirstName=@firstname,LastName=@lastname,Email=@email," +
                    "PasswordHash=@passwordhash,Adress=@adress,Phone=@phone,BirthDate=@birthdate," +
                    "Gender=@gender,Position=@position,Photo=@photo,ModifiedDate=@modifieddate where ID=@value and IsDeleted=0";
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
                    cmd.Parameters.AddWithValue("@position", value.Position);
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
                string cmdText = "update Admins set PasswordHash=@passwordhash where Email=@email and IsDeleted=0";
                using (SqlCommand cmd = new(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@passwordhash", passwordhash);
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private Admin GetFromReaderAsAdmin(SqlDataReader reader)
        {
            return new Admin()
            {
                Id = reader.Get<int>(nameof(Admin.Id)),
                FirstName = reader.Get<string>(nameof(Admin.FirstName)),
                LastName = reader.Get<string>(nameof(Admin.LastName)),
                Email = reader.Get<string>(nameof(Admin.Email)),
                PasswordHash = reader.Get<string>(nameof(Admin.PasswordHash)),
                Adress = reader.Get<string>(nameof(Admin.Adress)),
                Phone = reader.Get<string>(nameof(Admin.Phone)),
                BirthDate = reader.Get<DateTime>(nameof(Admin.BirthDate)),
                Gender = reader.Get<bool>(nameof(Admin.Gender)),
                Position = reader.Get<string>(nameof(Admin.Position)),
                Photo = reader.Get<byte[]>(nameof(Admin.Photo)),
            };
        }
    }
}
