using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Services
{
    public class MySQLService
    {
        private string connectionString = "Server=localhost;Database=pharmaonline;Uid=dev;Pwd=;";
        protected MySqlConnection connection;

        public MySQLService()
        {
            connection = new MySqlConnection(connectionString);
        }
    }
}