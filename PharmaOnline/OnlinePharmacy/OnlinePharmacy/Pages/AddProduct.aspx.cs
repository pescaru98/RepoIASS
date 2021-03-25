using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using OnlinePharmacy.Models;
using OnlinePharmacy.Services;

namespace OnlinePharmacy.Pages
{
    public partial class AddProduct : System.Web.UI.Page
    {
        ProductService productService = new ProductService();
        UtilService utilService = new UtilService();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "" || Session["role"] != "PHARMACIST")
                Response.Redirect("ErrorPage.aspx");

        }

        private void reinitForm()
        {
            productName.Text = "";
            price_per_unit.Text = "";
            picture.Dispose();
            units.Text = "";
            category.Text = "";

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Product newProduct;
            Stream pictureStream = picture.PostedFile.InputStream;
            pictureStream.Position = 0;
            if (utilService.checkNameIsPicture(picture.PostedFile.FileName.ToString()))
            {
                byte[] bytes = utilService.convertStreamToByteArray(pictureStream);
                newProduct = new Product(productName.Text, Convert.ToInt32(price_per_unit.Text), Convert.ToInt32(units.Text), category.Text, bytes);
                productService.insert(newProduct.name, newProduct.price_per_unit, newProduct.units, newProduct.tag, newProduct.picture);
                reinitForm();
            }

           
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (utilService.checkNameIsPicture(picture.PostedFile.FileName.ToString()))
                args.IsValid = true;
            else
                args.IsValid = false;
        }
    }
}