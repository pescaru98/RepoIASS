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
    public partial class Cart : System.Web.UI.Page
    {
        CartService cartService = new CartService();

        private Panel createCartPanel(VW_Cart_Product cartProduct)
        {
            Panel newPanel = new Panel();
            newPanel.ID = "panel_"+cartProduct.cart_product_id;
            newPanel.Width = 25;

            Image mainImage = new Image();
            mainImage.Width = 100;
            mainImage.Height = 100;
            mainImage.ImageUrl = "data:image;base64," + Convert.ToBase64String(cartProduct.picture);

            TextBox productName = new TextBox();
            productName.Text = "Nume: "+ cartProduct.name;

            TextBox cartUnits = new TextBox();
            cartUnits.Text = "Unitati: " + cartProduct.cart_units;

            TextBox price_per_unit = new TextBox();
            price_per_unit.Text = "Pret: " + cartProduct.price_per_unit;

            TextBox category = new TextBox();
            category.Text = "Categorie: " + cartProduct.tag;

            newPanel.Controls.Add(mainImage);
            newPanel.Controls.Add(productName);
            newPanel.Controls.Add(cartUnits);
            newPanel.Controls.Add(price_per_unit);
            newPanel.Controls.Add(category);

            return newPanel;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = "Gogu";
            Session["role"] = "REGULAR";
            Session["user_id"] = "1";
            if (Session["username"] == null || Session["username"] == "" || Session["role"] != "REGULAR")
                Response.Redirect("ErrorPage.aspx");

            List<VW_Cart_Product> allAddedProductsOfUser = cartService.getAllByUserId(Convert.ToInt32(Session["user_id"]));

            allAddedProductsOfUser.ForEach(item =>
            {
                cartItems.Controls.Add(createCartPanel(item));
            });
        }
    }
}