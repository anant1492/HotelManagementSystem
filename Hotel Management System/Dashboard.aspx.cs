﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management_System
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayUserLabel.Text = DisplayUserName.displayName;
            displayUserLabel.Visible = true;

        if(DisplayUserName.displayUserType.Equals("customer"))
            {
                btnAddRoom.Visible = false;
                btnCheckout.Visible = false;
                btnCustomerRegistration.Visible = false;
                btnEmployeeDetails.Visible = false;

                ReservationView.Visible = false;
               /* SqlDataSource3.UpdateCommand = "select * from reservation where customerID='" + DisplayUserName.displayName + "' order by reservationID desc;";
                    SqlDataSource3.Update();
                ReservationView.DataSourceID = SqlDataSource3.ID;
                ReservationView.Visible = true;*/
            }
                
        }


        protected void btnAddRoom_Click(object sender, EventArgs e)
        {

           
            Response.Redirect("~/Register_Room.aspx");

        }

        protected void btnCustomerRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Customer_Resgistration.aspx");

        }

        protected void btnReserve_Click(object sender, EventArgs e)
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Add_Room.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}