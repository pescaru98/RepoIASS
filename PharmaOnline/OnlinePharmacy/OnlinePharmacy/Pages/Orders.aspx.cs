using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using OnlinePharmacy.Models;
using OnlinePharmacy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = iText.Layout.Element.Image;

namespace OnlinePharmacy.Pages
{
    public partial class Orders : System.Web.UI.Page
    {
        private OrderService orderService = new OrderService();
        private List<VW_Order_Product> myOrders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"] == "" || Session["role"].ToString() != "REGULAR")
                Response.Redirect("ErrorPage.aspx");

            myOrders = orderService.getAllOrderProductsOfUserId(Convert.ToInt32(Session["user_id"]));

            System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();
            table.CssClass += "table table-striped border";
            createAndAddTableHeaders(table);
            myOrders.ForEach(order =>
            {
                createAndAddTableRowOfOrder(order, table);
            });

            ordersPanel.Controls.Add(table);
            ordersPanel.Controls.Add(createButton());
        }

        private Button createButton()
        {
            Button btn = new Button();
            btn.ID = "downloadBtn";
            btn.Text = "Genereaza factura";
            btn.CssClass = "btn btn-primary";
            btn.Click += new EventHandler(btn_click);

            return btn;
        }

        private int getTotalPriceOfOrderList()
        {
            int total = 0;

            myOrders.ForEach(order =>
            {
                total += order.bought_units * order.bought_price_per_unit;
            });

            return total;
        }

        private void createAndDownloadPdf()
        {
            PdfWriter writer = new PdfWriter("C:\\PDFs\\factura.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("Factura")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(20);
            document.Add(header);
            Paragraph subheader = new Paragraph("S.C. PharmaOnline S.R.L.")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(15);
            document.Add(subheader);

            // Linie separatoare
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);
            // Linie noua
            Paragraph newline = new Paragraph(new Text("\n"));
            document.Add(newline);
            // Linie noua
            document.Add(newline);
            // Tabel
            iText.Layout.Element.Table table = new iText.Layout.Element.Table(4, false);


            Cell cell12 = new Cell(1, 1)
            .SetBackgroundColor(ColorConstants.GRAY)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Nume produs"));

                        Cell cell13 = new Cell(1, 1)
            .SetBackgroundColor(ColorConstants.GRAY)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Unitati"));


                        Cell cell14 = new Cell(1, 1)
            .SetBackgroundColor(ColorConstants.GRAY)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Pret/unitate"));


                        Cell cell15 = new Cell(1, 1)
            .SetBackgroundColor(ColorConstants.GRAY)
            .SetTextAlignment(TextAlignment.CENTER)
            .Add(new Paragraph("Data"));



            table.AddCell(cell12);
            table.AddCell(cell13);
            table.AddCell(cell14);
            table.AddCell(cell15);

            myOrders.ForEach(order =>
            {
                                Cell prodName = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph(order.product_name));

                                Cell prodUnits = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph(order.bought_units.ToString()));

                                Cell prodBoughtUnits = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph(order.bought_price_per_unit.ToString()));


                                Cell prodDate = new Cell(1, 1)
                .SetBackgroundColor(ColorConstants.WHITE)
                .SetTextAlignment(TextAlignment.CENTER)
                .Add(new Paragraph(order.issue_date.ToString()));

                table.AddCell(prodName);
                table.AddCell(prodUnits);
                table.AddCell(prodBoughtUnits);
                table.AddCell(prodDate);
            });

            document.Add(table);
            document.Add(newline);
            document.Add(newline);

                   Paragraph totalPriceText = new Paragraph("Total")
            .SetTextAlignment(TextAlignment.RIGHT)
            .SetFontSize(24);

            document.Add(totalPriceText);

                  Paragraph totalPriceTextValue = new Paragraph(getTotalPriceOfOrderList().ToString())
            .SetTextAlignment(TextAlignment.RIGHT)
            .SetFontSize(14);

            document.Add(totalPriceTextValue);

            int n = pdf.GetNumberOfPages();
            for (int i = 1; i <= n; i++)
            {
                document.ShowTextAligned(new Paragraph(String
                .Format("Pagina" + i + " din " + n)),
                559, 806, i, TextAlignment.RIGHT,
               VerticalAlignment.TOP, 0);
            }
            document.Close();

        }

        private void createAndAddTableHeaders(System.Web.UI.WebControls.Table table)
        {
            TableRow row = new TableRow();

            TableCell product_name = new TableCell();
            TableCell bought_units = new TableCell();
            TableCell bought_price_per_unit = new TableCell();
            TableCell issue_date = new TableCell();
           // TableCell name = new TableCell();
           // TableCell surname = new TableCell();
           // TableCell email = new TableCell();

            product_name.Text = "Nume produs";
            product_name.CssClass = "font-weight-bold";
            bought_units.Text = "Unitati";
            bought_units.CssClass = "font-weight-bold";
            bought_price_per_unit.Text = "Pret/unitate";
            bought_price_per_unit.CssClass = "font-weight-bold";
            issue_date.Text = "Data";
            issue_date.CssClass = "font-weight-bold";
           // name.Text = "Prenume";
           // name.CssClass = "font-weight-bold";
           // surname.Text = "Nume";
           // surname.CssClass = "font-weight-bold";
           // email.Text = "Email";
            //email.CssClass = "font-weight-bold";

            row.Cells.Add(product_name);
            row.Cells.Add(bought_units);
            row.Cells.Add(bought_price_per_unit);
            row.Cells.Add(issue_date);
            //row.Cells.Add(name);
            //row.Cells.Add(surname);
            //row.Cells.Add(email);

            table.Rows.Add(row);
        }

        private void createAndAddTableRowOfOrder(VW_Order_Product orderProduct, System.Web.UI.WebControls.Table table)
        {
            TableRow row = new TableRow();

            TableCell product_name = new TableCell();
            TableCell bought_units = new TableCell();
            TableCell bought_price_per_unit = new TableCell();
            TableCell issue_date = new TableCell();
           // TableCell name = new TableCell();
           // TableCell surname = new TableCell();
           // TableCell email = new TableCell();

            product_name.Text = orderProduct.product_name;
            bought_units.Text = orderProduct.bought_units.ToString();
            bought_price_per_unit.Text = orderProduct.bought_price_per_unit.ToString();
            issue_date.Text = orderProduct.issue_date.ToString();
          //  name.Text = orderProduct.name;
          //  surname.Text = orderProduct.surname;
          //  email.Text = orderProduct.email;

            row.Cells.Add(product_name);
            row.Cells.Add(bought_units);
            row.Cells.Add(bought_price_per_unit);
            row.Cells.Add(issue_date);
          //  row.Cells.Add(name);
           // row.Cells.Add(surname);
          //  row.Cells.Add(email);

            table.Rows.Add(row);
        }

        protected void btn_click(object sender, EventArgs e)
        {
            createAndDownloadPdf();
        }
    }
}