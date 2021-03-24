using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePharmacy.Models
{
    public class Users
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string role { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }

        public Users(int user_id, string username, string role, string name, string surname, string email)
        {
            this.user_id = user_id;
            this.username = username;
            this.role = role;
            this.name = name;
            this.surname = surname;
            this.email = email;
        }

        public static Users convertFromSqlReader(object user_id, object username, object role, object name, object surname, object email )
        {
            return new Users((int)user_id,(string)username, (string)role, (string)name, (string)surname, (string)email);
        }
    }
}