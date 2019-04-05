using HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DataAccess
{
    class UsersTableDataService
    {
        private readonly string _connectionString;
        public UsersTableDataService()
        {
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\пользователь\source\repos\HotelApp\Hotel.DataAccess\Database.mdf;Integrated Security=True";
        }

        public List<User> GetAllUsers()
        {
            var data = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = "select * from Users";

                    var sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        int id = (int)sqlDataReader["Id"];
                        string login = sqlDataReader["Login"].ToString();
                        string name = sqlDataReader["Name"].ToString();
                        string email = sqlDataReader["Email"].ToString();
                        string phone = sqlDataReader["Phone"].ToString();
                        string password = sqlDataReader["Password"].ToString();
                        data.Add(new User
                        {
                            Id = id,
                            Login = login,
                            Name=name,
                            Email=email,
                            Phone=phone,
                            Password = password
                        });
                    }

                }
                catch (SqlException exeption)
                {
                    //TODO обработка ошибки
                    throw;
                }
                catch (Exception exeption)
                {
                    //TODO обработка ошибки
                    throw;
                }
            }
            return data;
        }


    }
}
