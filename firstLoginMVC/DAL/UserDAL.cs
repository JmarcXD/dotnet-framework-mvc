using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using firstLoginMVC.Models;

namespace firstLoginMVC.DAL
{
    public class UserDAL
    {
        private SqlConnection _connection;

        public UserDAL()
        {
            ConnectionDatabase cd = new ConnectionDatabase();
            _connection = cd.SqlConnection;
        }

        public List<LoginViewModel> GetUserListFromDB()
        {
            List<LoginViewModel> jobs = new List<LoginViewModel>();

            _connection.Open();
            try
            {

                string query = "SELECT * FROM User;";
                SqlCommand cmd = new SqlCommand(query, this._connection);

                // Recuperamos un lector...
                SqlDataReader records = cmd.ExecuteReader();

                while (records.Read())
                {
                    LoginViewModel user = new LoginViewModel();
                    user.Email = records.GetString(records.GetOrdinal("Email"));
                    user.Password= records.GetString(records.GetOrdinal("Password"));

                    // Agrega más campos según la estructura de tu tabla y tu clase Job
                    jobs.Add(user);
                }
                _connection.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return jobs;
        }

        public void InsertUserToDB(LoginViewModel newUser)
        {
            try
            {
                this._connection.Open();
                string sql = @"INSERT INTO User( 
                                             Email, 
                                             Password) 

                                VALUES (@Email, 
                                        @Password
                                        )";


                using (SqlCommand cmd = new SqlCommand(sql, this._connection))
                {
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@Password", newUser.Password);
          

                    cmd.ExecuteNonQuery();
                }
                this._connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}