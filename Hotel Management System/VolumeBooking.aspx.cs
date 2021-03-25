using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Hotel_Management_System
{
    public partial class VolumeBooking : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        string vCustomerID ;
        string vCheckInDate = "";
        string vCheckOutDate = "";
        double discount;
        int finalResult;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DisplayUserName.displayUserType.Equals("customer"))
            {                
                btnAddRoom.Visible = false;
                btnCheckout.Visible = false;
                btnCustomerRegistration.Visible = false;
                btnEmployeeDetails.Visible = false;
                btnVolumeReservation.Visible = false;
            }
            if (DisplayUserName.displayUserType.Equals("employee"))
            {
                btnAddRoom.Visible = false;
                btnEmployeeDetails.Visible = false;
                btnVolumeReservation.Visible = false;
            }
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["HMSConnectionString"].ConnectionString;
            cnn.Open();
            cnn.Close();
        }


        protected void btnAddRoom_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register_Room.aspx");
        }

        protected void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Customer_Registration.aspx");

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout.aspx");

        }              

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reservation.aspx");
        }

        protected void btnEmployeeDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee.aspx");
        }
        
        protected void btnVolumeReservation_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VolumeBooking.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            AvailableRoomView.Visible = true;
        }


        protected void btnReservation_Click(object sender, EventArgs e)
        {
            int volumeReservationId = 0;
            vCustomerID = selectCustomerList.SelectedValue;            
            vCheckInDate = CheckInDate.Text;
            vCheckOutDate = CheckOutDate.Text;
            if (selectDiscount.SelectedValue.Equals("0"))
            {
                discount = 0;
            }
            if (selectDiscount.SelectedValue.Equals("10"))
            {
                discount = 0.10;
            }
            if (selectDiscount.SelectedValue.Equals("15"))
            {
                discount = 0.15;
            }
            if (selectDiscount.SelectedValue.Equals("20"))
            {
                discount = 0.20;
            }

            List<string> roomList = new List<string>();
            double price = 0;
            foreach(ListItem li in RoomListBox.Items)
            {
                if (li.Selected)
                {
                    roomList.Add(li.Text);
                    cnn.Open();
                    cmd.Connection = cnn;
                    try
                    {                        
                        cmd.CommandText = string.Format("select roomPrice from Room where roomNumber='{0}'", li.Text);
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            price = price + sdr.GetInt32(0);
                        }
                    }
                    catch(SqlException ex)
                    {
                        Response.Write( ex.Message + "from1");
                    }
                    cnn.Close();
                    //Response.Write(li.Text+ "");
                    
                }
            }

            int roomCount = roomList.Count;
            // Response.Write("" + roomCount);
            //Response.Write("price is" + price);
            double discountedPrice = price - (price * (discount));
            //Response.Write("disc price is" + discountedPrice);


            cnn.Open();
            cmd.Connection = cnn;
            try
            {
                cmd.CommandText = string.Format("insert into volumeReservation" + "(numberOfRoom,customerID,discount,totalPrice)" +
                                                                           "values(@numberOfRoom," +
                                                                           "@customerID," +
                                                                           "@discount," +
                                                                           "@totalPrice)");
                cmd.Parameters.AddWithValue("@numberOfRoom", roomCount);
                cmd.Parameters.AddWithValue("@customerID", vCustomerID);
                cmd.Parameters.AddWithValue("@discount", discount * 100);
                cmd.Parameters.AddWithValue("@totalPrice", discountedPrice);
                cmd.Parameters.AddWithValue("@reservationStatus", "confirmed");
                int result = cmd.ExecuteNonQuery();

                if (result != 0)
                {
                    cmd.CommandText = string.Format("select  TOP 1 (volumeId) from volumeReservation order by volumeId desc;");
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        volumeReservationId = sdr.GetInt32(0);
                    }
                    //Response.Write("volume reservation id is " + volumeReservationId);
                }
            }

            catch (SqlException ex)
            {
                Response.Write(ex.Message + "from 2");
            }
            cnn.Close();

            
            foreach(string room in roomList)
            {
                cmd.Parameters.Clear();
                int roomNum = int.Parse(room);
                cnn.Open();
                cmd.Connection = cnn;
                try
                {
                    cmd.CommandText = string.Format("insert into Reservation" + "(roomNumber,customerID,checkInDate,checkOutDate,reservationStatus,volumeReservationId)" +
                                                                              "values(@roomNumber," +
                                                                              "@customerID1," +
                                                                              "@checkInDate1," +
                                                                              "@checkOutDate1," +
                                                                              "@reservationStatus1,"+
                                                                              "@volumeReservationId)");
                    cmd.Parameters.AddWithValue("@roomNumber", roomNum);
                    cmd.Parameters.AddWithValue("@customerID1", vCustomerID);
                    cmd.Parameters.AddWithValue("@checkInDate1", vCheckInDate);
                    cmd.Parameters.AddWithValue("@checkOutDate1", vCheckOutDate);
                    cmd.Parameters.AddWithValue("@reservationStatus1", "confirmed");
                    cmd.Parameters.AddWithValue("@volumeReservationId", volumeReservationId);
                    int result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        cmd.CommandText = string.Format("update room set roomStatus=@roomStatus where roomNumber=@roomNumber2");
                        cmd.Parameters.AddWithValue("@roomStatus", "volumeBook");
                        cmd.Parameters.AddWithValue("@roomNumber2", roomNum);
                        finalResult = cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message + " from 3");
                }
                cnn.Close();
            }
            if (finalResult != 0)
            {
                Response.Write("volume bookinhg is confirmed");
            }

            AvailableRoomView.Visible = false;
            SqlDataSource1.Update();
            AvailableRoomView.DataSourceID = SqlDataSource1.ID;
            AvailableRoomView.Visible = true;
            RoomListBox.Visible = false;
            RoomListBox.DataSourceID = SqlDataSource3.ID; ;
            RoomListBox.Visible = true;
            
        }

       
    }
}