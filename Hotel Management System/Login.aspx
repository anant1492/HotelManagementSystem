<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Hotel_Management_System.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div draggable="true" style="background-image: none; background-attachment: scroll; height: 698px; width: 1110px;">
            <asp:Panel ID="Panel1" runat="server" BorderStyle="None" Height="715px">
                <asp:Image ID="Image1" runat="server" Height="223px" ImageAlign="Top" ImageUrl="~/images/login.gif" style="margin-top: 162px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="User" runat="server" BorderStyle="Groove" Text="User Login"></asp:Label>
                <br />
                username<br />
                <asp:TextBox ID="username" runat="server"></asp:TextBox>
                <br />
                <br />
                password<br />
                <asp:TextBox ID="password" runat="server" OnTextChanged="password_TextChanged" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RadioButtonList ID="userTypeList" runat="server">
                    <asp:ListItem>admin</asp:ListItem>
                    <asp:ListItem>employee</asp:ListItem>
                    <asp:ListItem>customer</asp:ListItem>
                </asp:RadioButtonList>
                <asp:Button ID="login" runat="server" OnClick="login_Click" Text="Login" />
                &nbsp;
                <br />
                <asp:Button ID="register" runat="server" OnClick="register_Click" Text="Register as Guest" />
                <br />
                <br />
                <br />
                <asp:Label ID="errorLabel" runat="server" Text="Invalid Credentials" Visible="False"></asp:Label>
                <br />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
