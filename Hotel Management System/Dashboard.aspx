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
        <asp:Button ID="btnAddRoom" runat="server" Height="97px" Text="Register Room" Width="245px" OnClick="btnAddRoom_Click" />
        <asp:Button ID="btnCustomerRegistration" runat="server" Height="97px" OnClick="btnCustomerRegistration_Click" style="margin-top: 0px" Text="Customer Registration" Width="253px" />
        <asp:Button ID="btnReserve" runat="server" Height="98px" OnClick="btnReserve_Click" Text="Reserve a Room" Width="223px" />
        <asp:Button ID="btnCheckout" runat="server" Height="100px" OnClick="btnCheckout_Click" Text="Checkout" Width="219px" />
        <asp:Button ID="btnEmployeeDetails" runat="server" Height="100px" OnClick="btnEmployeeDetails_Click" Text="Employee Details" Width="222px" />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" Height="412px">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Welcome
            <asp:Label ID="displayUserLabel" runat="server"></asp:Label>
            &nbsp;to Hotel Management System<br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Current Reservation<asp:GridView ID="ReservationView" runat="server" AutoGenerateColumns="False" DataKeyNames="reservationID" DataSourceID="SqlDataSource3" HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField DataField="reservationID" HeaderText="reservationID" InsertVisible="False" ReadOnly="True" SortExpression="reservationID" />
                    <asp:BoundField DataField="roomNumber" HeaderText="roomNumber" SortExpression="roomNumber" />
                    <asp:BoundField DataField="checkInDate" HeaderText="checkInDate" SortExpression="checkInDate" />
                    <asp:BoundField DataField="customerID" HeaderText="customerID" SortExpression="customerID" />
                    <asp:BoundField DataField="checkOutDate" HeaderText="checkOutDate" SortExpression="checkOutDate" />
                    <asp:BoundField DataField="reservationStatus" HeaderText="reservationStatus" SortExpression="reservationStatus" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HMSConnectionString %>" SelectCommand="SELECT [reservationID], [roomNumber], [checkInDate], [customerID], [checkOutDate], [reservationStatus] FROM [Reservation]" UpdateCommand="SELECT [reservationID], [roomNumber], [checkInDate], [customerID], [checkOutDate], [reservationStatus] FROM [Reservation]"></asp:SqlDataSource>
        </asp:Panel>
    </form>
</body>
</html>
