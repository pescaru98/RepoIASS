using MySql.Data.MySqlClient;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{
    public partial class TestPage : System.Web.UI.Page
    {
        private string connectionString = "Server=localhost;Database=pharmaonline;Uid=dev;Pwd=;";
        private MySqlConnection cnn;
        public Users user { get; set; }
        public string users { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user_id"] = 1;
            Session["username"] = "Test";
            Session["password"] = "1234";
            Session["role"] = "PHARMACIST";
            Session["name"] = "Ioana";
            Session["surname"] = "Farmacista";
            Session["email"] = "pescaru98@gmail.com";

            if (Session["username"] == null || Session["username"] == "")
                Response.Redirect("ErrorPage.aspx");

            try
            {
                cnn = new MySqlConnection(connectionString);
                cnn.Open();

                /*                MySqlDataAdapter da = new MySqlDataAdapter("select * from users", connectionString);
                                DataSet ds = new DataSet();
                                da.Fill(ds, "users");*/

                string sqlCmd = "select * from users";
                int count=0;
                MySqlCommand cmd = new MySqlCommand(sqlCmd, cnn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                count = rdr.FieldCount;
                while (rdr.Read() && rdr.HasRows)
                {
                    user = Users.convertFromSqlReader(rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5));
                    userlabel.Text += user.user_id + " " + user.username + "\n";
                }

                rdr.Close();

                string sqlInsert = "insert into users (username,password,role,name,surname,email) values ('TEST','122','PHARMACIST','Num','Prenum','em@em.ro')";
                MySqlCommand cmd2= new MySqlCommand(sqlInsert, cnn);
                cmd2.ExecuteNonQuery();

                

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                cnn.Close();
            }
            
        }
    }
}