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
    public partial class Products : System.Web.UI.Page
    {
        private ProductService productService = new ProductService();
        private List<Product> allProducts;
        private CartService cartService = new CartService();
            private Panel createCartPanel(Product product)
        {
            string[] headers = { "Nume",  "Pret", "Cantitate", "Categorie" };
            string[] values = {  product.name, product.price_per_unit.ToString(), product.units.ToString(), product.tag };

            Panel newPanel = new Panel();
            newPanel.CssClass = "bg-white rounded w-25 m-2";
            newPanel.ID = "panel_" + product.product_id;

            Image mainImage = new Image();
            mainImage.Width = 100;
            mainImage.Height = 100;
            mainImage.ImageUrl = "data:image;base64," + Convert.ToBase64String(product.picture);
            mainImage.CssClass = "align-self-center";

            Table table = new Table();
            table.CssClass += "table table-striped border";


            for (int i = 0; i < 4; i++)
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

            Button addBtn = new Button();
            addBtn.ID = "addBtn_" + product.product_id;
            addBtn.Text = "Adauga";
            addBtn.CssClass = "btn btn-primary mb-2 ml-2";
            addBtn.Click += new EventHandler(AddProducts);
           

            newPanel.Controls.Add(mainImage);
            newPanel.Controls.Add(table);
            newPanel.Controls.Add(addBtn);

            return newPanel;

            
           

           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user_id"] = 1;
            Session["username"] = "Test";
            Session["password"] = "1234";
            Session["role"] = "REGULAR";
            Session["name"] = "Ioana";
            Session["surname"] = "Farmacista";
            Session["email"] = "pescaru98@gmail.com";
            //if (Session["username"] == null || Session["username"] == "")
            //  Response.Redirect("ErrorPage.aspx");

            allProducts = productService.getAllByUserId();

            allProducts.ForEach(item =>
            {
                Panel1.Controls.Add(createCartPanel(item));
            });

            


        }

        private void AddProducts(object sender, EventArgs e)

        {
            string product_id = ((Button)sender).ID.Split(new string[] { "addBtn_" }, StringSplitOptions.None)[1];

            cartService.insert(Convert.ToInt32(Session["user_id"]), Convert.ToInt32(product_id), 1);
            //string url;
            //url = "Cart.aspx";
            //Response.Redirect(url);

        }
    }
}