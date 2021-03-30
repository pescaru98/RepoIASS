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
        private CartService cartService = new CartService();
        private ProductService productService = new ProductService();
        private UtilService utilService = new UtilService();
        private OrderService orderService = new OrderService();
        private EmailService emailService = new EmailService();

        private List<VW_Cart_Product> allAddedProductsOfUser;


        private Panel createCartPanel(VW_Cart_Product cartProduct)
        {
            string[] headers = { "Nume", "Unitati", "Pret unitate","Pret total", "Categorie" };
            string[] values = { cartProduct.name, cartProduct.cart_units.ToString(), cartProduct.price_per_unit.ToString(), (cartProduct.price_per_unit*cartProduct.cart_units).ToString(), cartProduct.tag };

            Panel newPanel = new Panel();
            newPanel.CssClass = "bg-white rounded w-25 m-2";
            newPanel.ID = "panel_"+cartProduct.cart_product_id;

            Image mainImage = new Image();
            mainImage.Width = 100;
            mainImage.Height = 100;
            mainImage.ImageUrl = "data:image;base64," + Convert.ToBase64String(cartProduct.picture);
            mainImage.CssClass = "align-self-center";

            Table table = new Table();
            table.CssClass += "table table-striped border";
            

            for (int i = 0; i < 5; i++)
            {
                TableRow row = new TableRow();

                TableCell header = new TableCell();
                TableCell value = new TableCell();

                header.Text = headers[i];
                value.Text = values[i];

                row.Cells.Add(header);
                row.Cells.Add(value);

                table.Rows.Add(row);
            }

            Button delBtn = new Button();
            delBtn.ID = "delBtn_" + cartProduct.cart_product_id;
            delBtn.Text = "Sterge";
            delBtn.CssClass = "btn btn-danger mb-2 ml-2";
            delBtn.Click += new EventHandler(DeleteCartHandler);

            newPanel.Controls.Add(mainImage);
            newPanel.Controls.Add(table);
            newPanel.Controls.Add(delBtn);

            return newPanel;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "" || Session["role"].ToString() != "REGULAR")
                Response.Redirect("ErrorPage.aspx");

            allAddedProductsOfUser = cartService.getAllByUserId(Convert.ToInt32(Session["user_id"]));

            allAddedProductsOfUser.ForEach(item =>
            {
                cartItems.Controls.Add(createCartPanel(item));
            });

            if (allAddedProductsOfUser.Capacity == 0)
            {
                Label noProductsLabel = new Label();
                noProductsLabel.Text = "Nu ai niciun produs in cos";
                cartItems.Controls.Add(noProductsLabel);
            }
            else
            {
                Button sendOrder = new Button();
                sendOrder.ID = "orderBtn";
                sendOrder.CssClass = "btn btn-primary align-self-end mb-2";
                sendOrder.Text = "Trimite comanda";
                sendOrder.Click += new EventHandler(SendOrderHandler);

                cartItems.Controls.Add(sendOrder);
            }
        }

        protected void DeleteCartHandler(object sender, EventArgs e)
        {
            string cart_product_id = ((Button)sender).ID.Split(new string[] { "delBtn_" }, StringSplitOptions.None)[1];

            cartService.removeProductFromCart(Convert.ToInt32(cart_product_id));
/*            foreach (Control item in cartItems.Controls)
            {
                if (typeof(EmptyControlCollection).IsInstanceOfType(item.Controls))
                    continue;
                if (typeof(Panel).IsInstanceOfType(item) == false)
                    continue;
                if (item.Controls[2] == sender )
                {
                    cartItems.Controls.Remove(item);
                    break;
                }
            }*/
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

            //TODO Add notify message
        }

        protected void SendOrderHandler(object sender, EventArgs e)
        {
            string product_ids_string;
            string units_string;
            string price_per_unit_string;

            int[] product_ids_array = new int[allAddedProductsOfUser.Count];
            int[] units_array = new int[allAddedProductsOfUser.Count];
            int[] price_per_unit_array = new int[allAddedProductsOfUser.Count];

            int index = 0;

            cartService.removeProductsOfUserId(Convert.ToInt32(Session["user_id"]));
            foreach(VW_Cart_Product cart_product in allAddedProductsOfUser)
            {
                productService.updateUnitsOfProduct(cart_product.product_id, cart_product.product_units - cart_product.cart_units);
                product_ids_array[index] = cart_product.product_id;
                units_array[index] = cart_product.cart_units;
                price_per_unit_array[index] = cart_product.price_per_unit;

                index++;
            }

            product_ids_string = utilService.convertIntArrayToStringWithDelimitator(product_ids_array);
            units_string = utilService.convertIntArrayToStringWithDelimitator(units_array);
            price_per_unit_string = utilService.convertIntArrayToStringWithDelimitator(price_per_unit_array);

            orderService.addOrderSetWithProducts(Convert.ToInt32(Session["user_id"]), DateTime.Now, product_ids_string, units_string, price_per_unit_string);
            emailService.sendMailTo(Session["email"].ToString(), "Comanda procesata", "Comanda ta a fost procesata! Mergi in sectiunea Comenzile mele pentru a descarca factura.");
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}