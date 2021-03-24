using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using OnlinePharmacy.Models;

namespace OnlinePharmacy.Pages
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private string connectionString = "Server=localhost:3306;Database=pharmaonline;Uid=dev;Pwd=;";
        private MySqlConnection cnn;
        public Product product { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "" || Session["role"] != "PHARMACIST")
                Response.Redirect("ErrorPage.aspx");

            cnn = new MySqlConnection(connectionString);

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {

        }
    }
}