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
    public partial class Employee : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        string employeeGender;
        string employeeStatus;
        string employeeType;

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

        protected void checkEmpUserId_Click(object sender, EventArgs e)
        {
            string employeeUserId = EmpUserId.Text;

            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandText = string.Format("select * from userTable where username='{0}'", employeeUserId);
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

        
        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string empUserId = EmpUserId.Text;
            string empPassword = EmpPassword.Text;
            string empName = EmpName.Text;
            int empAge = int.Parse(EmpAge.Text);
            string employeePhone = EmpPhone.Text;
            string employeeAddress = EmpAddress.Text;
           

            if (EmpGenderList.SelectedValue.Equals("M"))
            {
                employeeGender = "M";
            }
            if (EmpGenderList.SelectedValue.Equals("F"))
            {
                employeeGender = "F";
            }
            if (EmpGenderList.SelectedValue.Equals("T"))
            {
                employeeGender = "T";
            }
            if (EmpStatusList.SelectedValue.Equals("Single"))
            {
                employeeStatus = "Single";
            }
            if (EmpStatusList.SelectedValue.Equals("Married"))
            {
                employeeStatus = "Married";
            }
            if (EmpTypeList.SelectedValue.Equals("admin"))
            {
                employeeType = "admin";
            }
            if (EmpTypeList.SelectedValue.Equals("employee"))
            {
                employeeType = "employee";
            }

            cnn.Open();
            cmd.Connection = cnn;
            try
            {
                cmd.CommandText = string.Format("insert into userTable" + "(username,password,userType)" +
                                                                          "values(@username," +
                                                                          "@password," +
                                                                          "@userType)");
                cmd.Parameters.AddWithValue("@username", empUserId);
                cmd.Parameters.AddWithValue("@password", empPassword);
                cmd.Parameters.AddWithValue("@userType", employeeType);

                cmd.ExecuteNonQuery();

                {
                    try
                    {
                        cmd.CommandText = string.Format("insert into Employee" + "(empId,empName,empAge,empGender,empPhone," +
                                                                            "empAddress,empStatus,empType)" +
                                                                            "values(@empId," +
                                                                            "@empName," +
                                                                            "@empAge," +
                                                                            "@empGender," +
                                                                            "@empPhone," +
                                                                            "@empAddress," +
                                                                            "@empStatus," +
                                                                            "@empType)");

                        cmd.Parameters.AddWithValue("@empId", empUserId);
                        cmd.Parameters.AddWithValue("@empName", empName);
                        cmd.Parameters.AddWithValue("@empAge", empAge);
                        cmd.Parameters.AddWithValue("@empGender", employeeGender);
                        cmd.Parameters.AddWithValue("@empPhone", employeePhone);
                        cmd.Parameters.AddWithValue("@empAddress", employeeAddress);
                        cmd.Parameters.AddWithValue("@empStatus", employeeStatus);
                        cmd.Parameters.AddWithValue("@empType", employeeType);


                       int result= cmd.ExecuteNonQuery();

                        if (result != 0)
                        {
                            registerLabel.Text = "Employee added!!";
                            registerLabel.Visible = true;


                        }
                        else
                        {
                            registerLabel.Text = "an error occured";
                            registerLabel.Visible = true;
                        }
                        

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            registerLabel.Text = "****employee already exist";
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
                    registerLabel.Text = "****employee already exist";
                    registerLabel.Visible = true;
                }
                else
                    registerLabel.Text = "an error occured" + ex.Message;
                registerLabel.Visible = true;

            }
            cnn.Close();


        }
    }
}