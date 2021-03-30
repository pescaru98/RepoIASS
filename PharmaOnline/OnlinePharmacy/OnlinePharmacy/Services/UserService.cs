using MySql.Data.MySqlClient;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Services
{
    public class UserService : MySQLService
    {
        public UserService() : base()
        {
        }

        public Users getByUsernameAndPassword(string username, string password)
        {
            Users myUser = null;

            try
            {
                string selectString = "select * from users where username = @username and password = @password";
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(selectString, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read() && rdr.HasRows)
                {
                    myUser = Users.convertFromSqlReader(rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5), rdr.GetValue(6));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();

            }

            return myUser;
        }

    }

}