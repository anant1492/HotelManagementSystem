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
    public partial class Customer_Registration : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        string customerGender;
        string customerStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(DisplayUserName.displayUserType.Equals("customer"))
            {
                btnAddRoom.Visible = false;
                btnCustomerDetails.Visible = false;
                btnCheckout.Visible = false;
                btnCustomerRegistration.Visible = false;
                btnEmployeeDetails.Visible = false;
                btnLogout.Visible = false;                
            }

            btnLogin.Visible = false;
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

        protected void btnEmployeeDetails_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee.aspx");

        }

        protected void btnCustomerDetails_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Reservation.aspx");
        }

        protected void btnCheckout_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Checkout.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void btnAddGuest_Click1(object sender, EventArgs e)
        {
            string customerUserId = custUserId.Text;
            string customerName = custName.Text;
            string customerPass = custPass.Text;
            int customerAge = int.Parse(custAge.Text);
            string customerPhone = custPhoneNumber.Text;
            string customerAddress = custAddress.Text;
            
            if(custGender.SelectedValue.Equals("M"))
            {
                customerGender = "M";
            }
            if (custGender.SelectedValue.Equals("F"))
            {
                customerGender = "F";
            }
            if (custGender.SelectedValue.Equals("T"))
            {
                customerGender = "T";
            }
            if (custStatus.SelectedValue.Equals("Single"))
            {
                customerStatus = "Single";
            }
            if (custStatus.SelectedValue.Equals("Married"))
            {
                customerStatus = "Married";
            }
            
            cnn.Open();
            cmd.Connection = cnn;
            try
            {
                cmd.CommandText = string.Format("insert into Customer" + "(userId,customerName,customerAge,customerGender,customerPhone," +
                                                                           "customerAddress,customerStatus)" +
                                                                           "values(@userId," +
                                                                           "@customerName," +
                                                                           "@customerAge," +
                                                                           "@customerGender," +
                                                                           "@customerPhone," +
                                                                           "@customerAddress," +
                                                                           "@customerStatus)");
                cmd.Parameters.AddWithValue("@userId", customerUserId);
                cmd.Parameters.AddWithValue("@customerName", customerName);
                cmd.Parameters.AddWithValue("@customerAge", customerAge);
                cmd.Parameters.AddWithValue("@customerGender", customerGender);
                cmd.Parameters.AddWithValue("@customerPhone", customerPhone);
                cmd.Parameters.AddWithValue("@customerAddress", customerAddress);
                cmd.Parameters.AddWithValue("@customerStatus", customerStatus);


                cmd.ExecuteNonQuery();
                {
                    try
                    {
                        cmd.CommandText = string.Format("insert into userTable" + "(username,password,userType)" +
                                                                           "values(@username," +
                                                                           "@password," +
                                                                           "@userType)");
                        cmd.Parameters.AddWithValue("@username", customerUserId);
                        cmd.Parameters.AddWithValue("@password", customerPass);
                        cmd.Parameters.AddWithValue("@userType", "customer");

                        cmd.ExecuteNonQuery();
                        registerLabel.Text = "Customer added!! Click on login button to Redirect to login Page.";
                        registerLabel.Visible = true;
                        btnLogin.Visible = true;

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            registerLabel.Text = "****user already exist";
                            registerLabel.Visible = true;
                        }
                        else
                            registerLabel.Text = "an error occured" + ex.Message;
                        registerLabel.Visible = true;

                    }


                }
               
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    registerLabel.Text = "****user already exist";
                    registerLabel.Visible = true;
                }
                else
                    registerLabel.Text = "an error occured" + ex.Message;
                registerLabel.Visible = true;
                
            }
            cnn.Close();

        }

        protected void checkCustUserId_Click(object sender, EventArgs e)
        {
            string customerUserId = custUserId.Text;

            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = string.Format("select * from Customer where userId='{0}'", customerUserId);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
               
                displayUserIdCheck.Text = " user ID already exist, please make other user id.";
                displayUserIdCheck.Visible = true;
            }
            else
            {
                displayUserIdCheck.Text = " success!! You can proceed with this user id.";
                displayUserIdCheck.Visible = true;


            }
            cnn.Close();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}