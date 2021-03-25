using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management_System
{
    public partial class Checkout : System.Web.UI.Page
    {
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
    }
}