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
    public partial class Reservation : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        string customerID = "";
        int roomNumber;
        string checkInDate = "";
        string checkOutDate = "";
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DisplayUserName.displayUserType.Equals("admin"))
            {
                chooseCustomerLabel.Visible = true;
                selectCustomerList.Visible = true;
                customerID = selectCustomerList.SelectedValue;
            }
            if (DisplayUserName.displayUserType.Equals("customer"))
            {
                customerID = DisplayUserName.displayName;

                btnAddRoom.Visible = false;
                btnCheckout.Visible = false;
                btnCustomerRegistration.Visible = false;
                btnEmployeeDetails.Visible = false;
                btnVolumeReservation.Visible = false;
            }
            if (DisplayUserName.displayUserType.Equals("employee"))
            {
                chooseCustomerLabel.Visible = true;
                selectCustomerList.Visible = true;
                customerID = selectCustomerList.SelectedValue;

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


        protected void btnReservation_Click(object sender, EventArgs e)
        {
            AvailableRoomView.Visible = false;
            selectCustomerList.Visible = false;
            selectRoomList.Visible = false;


            roomNumber = int.Parse(selectRoomList.SelectedValue);
            checkInDate = CheckInDate1.Text;
            checkOutDate = CheckOutDate1.Text;

            cnn.Open();
            cmd.Connection = cnn;
            try
            {
                cmd.CommandText = string.Format("insert into Reservation" + "(roomNumber,customerID,checkInDate,checkOutDate,reservationStatus)" +
                                                                           "values(@roomNumber," +
                                                                           "@customerID," +
                                                                           "@checkInDate," +
                                                                           "@checkOutDate," +
                                                                           "@reservationStatus)");
                cmd.Parameters.AddWithValue("@roomNumber", roomNumber);
                cmd.Parameters.AddWithValue("@customerID", customerID);
                cmd.Parameters.AddWithValue("@checkInDate", checkInDate);
                cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate);
                cmd.Parameters.AddWithValue("@reservationStatus", "confirmed");

                int result = cmd.ExecuteNonQuery();
                //Response.Write(result);

                if (result != 0)
                {
                    cmd.CommandText = string.Format("update room set roomStatus=@roomStatus where roomNumber=@roomNumber1");
                    cmd.Parameters.AddWithValue("@roomStatus", "pending");
                    cmd.Parameters.AddWithValue("@roomNumber1", roomNumber);
                    int result1 = cmd.ExecuteNonQuery();
                   // Response.Write(result);
                    if (result1 != 0)
                    {
                        Response.Write("success");
                        
                    }
                    

                }
                SqlDataSource1.Update();
                AvailableRoomView.DataSourceID = SqlDataSource1.ID;
                AvailableRoomView.Visible = true;
                selectRoomList.DataSourceID = SqlDataSource1.ID; ;
                selectRoomList.Visible = true;
                SqlDataSource2.Update();
                selectCustomerList.Visible = true;

                if (DisplayUserName.displayUserType.Equals("admin"))
                {
                Response.Redirect("~/Dashboard.aspx");
                }
                if(DisplayUserName.displayUserType.Equals("customer"))
                {
                    Response.Write("success, you will receive email shortly");
                }

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Response.Write("error");

                }
                else
                {
                    Response.Write("error1"+ex.Message);

                }

            }
            cnn.Close();

        }

        
    }
}