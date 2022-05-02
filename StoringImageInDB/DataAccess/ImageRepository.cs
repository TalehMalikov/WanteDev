using StoringImageInDB.DataAccess.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StoringImageInDB.DataAccess
{
   public  class ImageRepository
    {
        private string connectionString = Kernel.ConnectionString;
        public void Add(ImageClass image)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "insert into imageClasses values(@path, @byteArray)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("path", image.ImagePath);
                    command.Parameters.AddWithValue("byteArray", image.ImageToByte);
                    command.ExecuteNonQuery();
                }
            }
        }

        public ImageClass Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "select ImagePath, ImageToByte from imageClasses where id =@id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    var reader= command.ExecuteReader();
                    reader.Read();
                    ImageClass image = new ImageClass()
                    {
                        ImagePath = (string)reader["ImagePath"],
                        ImageToByte = (byte[])reader["ImageToByte"]
                    };
                    return image;
                     
                }
            }
        }
    }
}
