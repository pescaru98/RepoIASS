using System;
using System.Collections.Generic;
using System.IO;
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
        private string connectionString = "Server=localhost;Database=pharmaonline;Uid=dev;Pwd=;";
        private MySqlConnection cnn;
        private Product product { get; set; }

        private bool checkUploadedFileIsPicture(string uploadedFileName)
        {
            string[] pictureFormats = {"jpg","jpeg","png","bmp"};
            string[] splitName = uploadedFileName.Split('.');
            foreach (string format in pictureFormats)
            {
                if (splitName[splitName.Length - 1] == format)
                    return true;
            }
            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = "A";
            Session["role"] = "PHARMACIST";

            if (Session["username"] == null || Session["username"] == "" || Session["role"] != "PHARMACIST")
                Response.Redirect("ErrorPage.aspx");

            cnn = new MySqlConnection(connectionString);

        }

        private byte[] convertStreamToByteArray(Stream pictureStream)
        {
            byte[] bytes = new byte[pictureStream.Length + 10];
            int numBytesToRead = (int)pictureStream.Length;
            int numBytesRead = 0;
            while (numBytesToRead > 0)
            {
                int n = pictureStream.Read(bytes, numBytesRead, 10);
                //System.Diagnostics.Debug.WriteLine(n);
                numBytesRead += n;
                numBytesToRead -= n;
            }
            pictureStream.Close();

            return bytes;
        }

        private void reinitForm()
        {
            productName.Text = "";
            price_per_unit.Text = "";
            picture.Dispose();
            units.Text = "";
            category.Text = "";

        }

        private void execInsert(string name, int price_per_unit, int units, string tag, byte[] picture, MySqlConnection cnn)
        {
            string insertCmd = "INSERT INTO PRODUCT (name,price_per_unit, picture,units,tag) VALUES (@name, @price_per_unit, @picture, @units, @tag)";
            cnn.Open();

            MySqlCommand comm = cnn.CreateCommand();
            comm.CommandText = insertCmd;
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@price_per_unit", price_per_unit);
            comm.Parameters.AddWithValue("@picture", picture);
            comm.Parameters.AddWithValue("@units", units);
            comm.Parameters.AddWithValue("@tag", tag);
            comm.ExecuteNonQuery();

            cnn.Close();
        }
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Product newProduct;
            Stream pictureStream = picture.PostedFile.InputStream;
            pictureStream.Position = 0;
            if (checkUploadedFileIsPicture(picture.PostedFile.FileName.ToString()))
            {
                byte[] bytes = convertStreamToByteArray(pictureStream);
                newProduct = new Product(productName.Text, Convert.ToInt32(price_per_unit.Text), Convert.ToInt32(units.Text), category.Text, bytes);
                execInsert(newProduct.name, newProduct.price_per_unit, newProduct.units, newProduct.tag, newProduct.picture, cnn);
                reinitForm();
            }

           
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //System.Diagnostics.Debug.WriteLine(checkUploadedFileIsPicture(picture.PostedFile.FileName.ToString()));
            if (checkUploadedFileIsPicture(picture.PostedFile.FileName.ToString()))
                args.IsValid = true;
            else
                args.IsValid = false;
        }
    }
}