<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Template.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="OnlinePharmacy.Pages.Feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        text-align: center;
        font-size: xx-large;
    }
    .auto-style2 {
        height: 30px;
    }
    .auto-style3 {
        margin-left: 591px;
        margin-right: 739;
    }
        .auto-style4 {
            margin-left: 491px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
    <tr>
        <td class="auto-style1"><strong>
            <br />
            Feedback</strong></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style4" Height="97px" OnTextChanged="TextBox1_TextChanged" Width="405px"></asp:TextBox>
            <table class="w-100">
                <tr>
                    <td class="auto-style2"></td>
                    <td class="auto-style2">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="auto-style3 btn btn-primary" OnClick="Button1_Click" Text="Salvare feedback" />
                    </td>
                </tr>
            </table>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
