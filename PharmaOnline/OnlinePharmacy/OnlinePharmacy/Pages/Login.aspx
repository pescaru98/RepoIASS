<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlinePharmacy.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <style type="text/css">
        .auto-style2 {
            font-size: xx-large;
            text-align: center;
        }

        .auto-style3 {
            width: 100%;
        }

        .auto-style5 {
            width: 480px;
            text-align: center;
        }

        .auto-style6 {
            width: 320px;
            text-align: center;
        }

        .auto-style7 {
            text-align: center;
        }

        .auto-style8 {
            text-align: left;
        }

        .auto-style9 {
            width: 480px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="text-align:center;">
        <div class="auto-style2">
            <strong>
                <br />
                <br />
                Login Page<br />
                <br />
            </strong>
        </div>
        <div class="form-group" style="text-align: -webkit-center;">
            <label for="txtUser">Username:</label>
            <asp:TextBox ID="txtUser" CssClass="form-control" runat="server" Width="254px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUser" ErrorMessage="Please enter Username" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group" style="text-align: -webkit-center;">
            <label for="txtUser">Password:</label>

            <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password" Width="252px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPass" ErrorMessage="Please enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Login" Width="214px" />
    </form>
</body>
</html>
