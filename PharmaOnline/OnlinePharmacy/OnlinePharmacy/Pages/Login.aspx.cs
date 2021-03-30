using OnlinePharmacy.Models;
using OnlinePharmacy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{

    public partial class Login : System.Web.UI.Page
    {
        private UserService userservice = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null && Session["username"] != "" )
                Response.Redirect("Products.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Users myUser = userservice.getByUsernameAndPassword(txtUser.Text, txtPass.Text);
            if (myUser != null) {
                Session["user_id"] = myUser.user_id;
                Session["username"] = myUser.username;
                Session["role"] = myUser.role;
                Session["name"] = myUser.name;
                Session["surname"] = myUser.surname;
                Session["email"] = myUser.email;

                Response.Redirect("Products.aspx");
            }
        }
    }
}