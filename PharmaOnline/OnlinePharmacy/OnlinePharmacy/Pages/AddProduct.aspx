<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Template.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="OnlinePharmacy.Pages.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group container">

        <div>
            <label for="productName">Nume</label>
            <asp:TextBox ID="productName" runat="server" CssClass="form-control" />
        </div>
        <div>
            <label for="price_per_unit">Pret</label>
            <asp:TextBox ID="price_per_unit" runat="server" CssClass="form-control" type="number" MaxLength="5" />
        </div>
        <div>
            <label for="picture">Poza</label>
            <asp:TextBox ID="picture" runat="server" CssClass="form-control" />
        </div>
        <div>
            <label for="units">Unitati</label>
            <asp:TextBox ID="units" runat="server" CssClass="form-control" type="number" MaxLength="3" />
        </div>
        <div>
            <label for="category">Categorie</label>
            <asp:TextBox ID="category" runat="server" CssClass="form-control" />
        </div>
        <div>
            <asp:Button CssClass="btn btn-primary mt-2" runat="server" Text="Adauga" OnClick="Unnamed1_Click"/>
        </div>
    </div>

</asp:Content>
