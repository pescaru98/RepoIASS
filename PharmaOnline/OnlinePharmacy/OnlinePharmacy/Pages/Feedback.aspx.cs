using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace OnlinePharmacy.Pages
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "" || Session["role"].ToString() != "REGULAR")
                Response.Redirect("ErrorPage.aspx");

            XmlDocument xmlSursa = new XmlDocument();
            string nume_fisier = Request.QueryString["feedback"];
            xmlSursa.Load(Server.MapPath("~/Feedback/feedback.xml"));
            ///luam toate nodurile textBox
            XmlNodeList nodes2 = xmlSursa.SelectNodes("//Feedback//textbox");
            foreach (XmlNode text in nodes2)
            {
                string idr = text.Attributes["detalii"].Value;
                PlaceHolder1.Controls.Add(new LiteralControl("<p/>" + idr));
                ///textBox generat
                TextBox txt = new TextBox();
                txt.CssClass = "form-control";
                txt.ID = text.Attributes["nume"].Value;
                txt.Text = "";
                PlaceHolder1.Controls.Add(new LiteralControl("<p/>"));
                PlaceHolder1.Controls.Add(txt);
            }

            //luam toate nodurile radioButton
            XmlNodeList nodes = xmlSursa.SelectNodes("//Feedback//radio");
            foreach (XmlNode radio in nodes)
            {
                string idr = radio.Attributes["detalii"].Value;
                PlaceHolder1.Controls.Add(new LiteralControl("<p/>" + idr));
                RadioButtonList new_radio = new RadioButtonList();
                new_radio.CssClass = "form-check-input";
                new_radio.ID = radio.Attributes["nume"].Value;
                XmlNodeList valori = radio.ChildNodes;
                foreach (XmlNode valoare in valori)
                {
                    string val = valoare.InnerText;
                    new_radio.Items.Add(val);
                }
                new_radio.RepeatDirection = RepeatDirection.Horizontal;
                PlaceHolder1.Controls.Add(new_radio);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in PlaceHolder1.Controls.OfType<TextBox>())
            {
                string nume_Control = txt.ID;
                string valoare_Control = txt.Text;
                TextBox1.Text = TextBox1.Text + "Nume control: " + nume_Control + " Valoare: " +
               valoare_Control + Environment.NewLine;
            }
            foreach (RadioButtonList rb in PlaceHolder1.Controls.OfType<RadioButtonList>())
            {
                string nume_Control = rb.ID;
                string valoare_Control = rb.SelectedValue;
                TextBox1.Text = TextBox1.Text + "Nume control: " + nume_Control + " Valoare: " +
               valoare_Control + Environment.NewLine;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
