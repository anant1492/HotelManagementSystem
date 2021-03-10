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
    public partial class Register_Room : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        string roomType;
        string roomBedding;
        
        string roomstatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DisplayUserName.displayUserType.Equals("customer"))
            {
                btnAddRoom.Visible = false;
                btnCheckout.Visible = false;
                btnCustomerRegistration.Visible = false;
                btnEmployeeDetails.Visible = false;
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

        protected void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reservation.aspx");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout.aspx");
        }

        protected void btnEmployeeDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnRegisterRoom_Click(object sender, EventArgs e)
        {
            ExistingRoomView.Visible = false;
            string roomPrice;

            if (RoomTypeList.SelectedValue.Equals("Delux"))
            {
                roomType = "Delux";
            }
            if (RoomTypeList.SelectedValue.Equals("Executive"))
            {
                roomType = "Executive";
            }
            if (RoomTypeList.SelectedValue.Equals("Suite"))
            {
                roomType = "Suite";
            }

            if (BedTypeList.SelectedValue.Equals("Single"))
            {
                roomBedding = "Single";
            }
            if (BedTypeList.SelectedValue.Equals("Double"))
            {
                roomBedding = "Double";
            }
            if (BedTypeList.SelectedValue.Equals("Triple"))
            {
                roomBedding = "Triple";
            }

            roomPrice = price.Text;

            if (RoomstatusList.SelectedValue.Equals("available"))
            {
                roomstatus = "available";
            }
            if (RoomstatusList.SelectedValue.Equals("pending"))
            {
                roomstatus = "pending";
            }
            if (RoomstatusList.SelectedValue.Equals("booked"))
            {
                roomstatus = "booked";
            }

            cnn.Open();
            cmd.Connection = cnn;
            try
            {
                cmd.CommandText = string.Format("insert into Room" + "(roomType,roomBedding,roomPrice,roomStatus)" +
                                                                           "values(@roomType," +
                                                                           "@roomBedding," +
                                                                           "@roomPrice," +
                                                                           "@roomStatus)");
                cmd.Parameters.AddWithValue("@roomType", roomType);
                cmd.Parameters.AddWithValue("@roomBedding", roomBedding);
                cmd.Parameters.AddWithValue("@roomPrice", roomPrice);
                cmd.Parameters.AddWithValue("@roomStatus", roomstatus);

                cmd.ExecuteNonQuery();
                
                SqlDataSource1.Update();
                ExistingRoomView.DataSourceID = SqlDataSource1.ID;
                ExistingRoomView.Visible = true;
                price.Text = "";
                regLbl.Text = "****room registered suucessfully";
                regLbl.Visible = true;

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {

                    regLbl.Text = "****room already exist";
                    regLbl.Visible = true;
                }
                else
                {
                    regLbl.Text = "****error occurred"+ ex.Message;
                    regLbl.Visible = true;

                }

            }
            cnn.Close();
        }
    }
}