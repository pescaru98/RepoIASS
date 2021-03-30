<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Template.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="OnlinePharmacy.Pages.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group container">

        <div>
            <label for="productName">Nume</label>
            <asp:TextBox ID="productName" runat="server" CssClass="form-control" />
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Introduceti numele" ControlToValidate="productName"></asp:RequiredFieldValidator>
            <br /><br />
        <div>
            <label for="price_per_unit">Pret</label>
            <asp:TextBox ID="price_per_unit" runat="server" CssClass="form-control" type="number" MaxLength="5" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="price_per_unit" runat="server"
                ErrorMessage="Introduceti un numar intreg"
                ValidationExpression="\d+"></asp:RegularExpressionValidator> 
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Introduceti pretul" ControlToValidate="price_per_unit"></asp:RequiredFieldValidator>
            <br /><br />


        <div>
            <label for="picture">Poza</label>
            <br />
            <asp:FileUpload ID="picture" runat="server"  CssClass="btn btn-primary" />
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Introduceti poza" ControlToValidate="picture"></asp:RequiredFieldValidator><br />
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Fisierul introdus nu este o poza" OnServerValidate="CustomValidator1_ServerValidate" ControlToValidate="picture"></asp:CustomValidator>
            <br /><br />
        <div>
            <label for="units">Unitati</label>
            <asp:TextBox ID="units" runat="server" CssClass="form-control" type="number" MaxLength="3" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                ControlToValidate="units" runat="server"
                ErrorMessage="Introduceti un numar intreg"
                ValidationExpression="\d+"></asp:RegularExpressionValidator>
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Introduceti numarul unitatilor" ControlToValidate="units"></asp:RequiredFieldValidator>
            <br /><br />
        <div>
            <label for="category">Categorie</label>
            <asp:TextBox ID="category" runat="server" CssClass="form-control" MaxLength="50" />
        </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Introduceti categoria" ControlToValidate="category"></asp:RequiredFieldValidator>
            <br /><br />
        <div>
            <asp:Button CssClass="btn btn-primary mt-2" runat="server" Text="Adauga" OnClick="Unnamed1_Click" />
        </div><br />

        <!--  <asp:TextBox ID="TestBox" CssClass="form-control" runat="server" /> -->
    </div>

</asp:Content>
