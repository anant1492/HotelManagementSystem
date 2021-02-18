<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Hotel_Management_System.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 698px;
        }
    </style>
</head>
<body style="height: 758px">
    <form id="form1" runat="server">
        <asp:Button ID="btnAddRoom" runat="server" Height="97px" Text="Add Room" Width="245px" OnClick="btnAddRoom_Click" />
        <asp:Button ID="btnCustomerRegistration" runat="server" Height="97px" OnClick="btnCustomerRegistration_Click" style="margin-top: 0px" Text="Customer Registration" Width="253px" />
        <asp:Button ID="btnCustomerDetails" runat="server" Height="98px" OnClick="btnCustomerDetails_Click" Text="Customer Details" Width="223px" />
        <asp:Button ID="btnCheckout" runat="server" Height="100px" OnClick="btnCheckout_Click" Text="Checkout" Width="219px" />
        <asp:Button ID="btnEmployeeDetails" runat="server" Height="100px" OnClick="btnEmployeeDetails_Click" Text="Employee Details" Width="222px" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="412px">
            Welcome
            <asp:Label ID="userLabel" runat="server"></asp:Label>
            &nbsp;to Hotel Management System</asp:Panel>
    </form>
</body>
</html>
