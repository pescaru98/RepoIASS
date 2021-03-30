using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacy.Pages
{
    public partial class Template : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Session["role"]);

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Session["user_id"] = null;
            Session["username"] = null;
            Session["role"] = null;
            Session["name"] = null;
            Session["surname"] = null;
            Session["email"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}