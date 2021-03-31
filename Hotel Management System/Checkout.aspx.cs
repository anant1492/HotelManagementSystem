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
    public partial class Checkout : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        int roomNumber;
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

       

        protected void btnConfirmCheckout_Click(object sender, EventArgs e)
        {
            roomNumber = int.Parse(roomList.SelectedValue);

            cnn.Open();
            cmd.Connection = cnn;
            try
            {
                cmd.CommandText = string.Format("update room set roomStatus='available' where roomNumber=@roomNumber;");
                
                cmd.Parameters.AddWithValue("@roomNumber", roomNumber);

                int result=cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = string.Format("update reservation set reservationStatus='checkedout' where roomNumber=@roomNumber;");

                    cmd.Parameters.AddWithValue("@roomNumber", roomNumber);

                    int result1 = cmd.ExecuteNonQuery();
                    if (result1 != 0)
                    {
                    msgLbl.Text = "Room Number: " + roomNumber + " has been checked out. Thank You.";
                    msgLbl.Visible = true;
                    }
                }


                SqlDataSource5.Update();
                roomList.DataSourceID = SqlDataSource5.ID;
                roomList.Visible = true;
                
            }
            catch (SqlException ex)
            {

                msgLbl.Text = "****error occurred" + ex.Message;
                msgLbl.Visible = true;               

            }
            cnn.Close();


        }
    }
}