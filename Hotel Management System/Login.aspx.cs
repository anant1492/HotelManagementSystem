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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection cnn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        string userType;

        protected void Page_Load(object sender, EventArgs e)
        {
          
            cnn.ConnectionString = ConfigurationManager.ConnectionStrings["HMSConnectionString"].ConnectionString;
            cnn.Open();
            cnn.Close();

        }


        protected void login_Click(object sender, EventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;
            DisplayUserName.displayName = user;

            if (userTypeList.SelectedValue.Equals("admin"))
            {
                userType = "admin";
                DisplayUserName.displayUserType = "admin";
               
            }
            if (userTypeList.SelectedValue.Equals("employee"))
            {
                userType = "employee";
                DisplayUserName.displayUserType = "employee";
            }
            if (userTypeList.SelectedValue.Equals("customer"))
            {
                userType = "customer";
                DisplayUserName.displayUserType = "customer";
            }
                        
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandText = string.Format("select * from userTable where username='{0}' and password='{1}' and userType='{2}'", user, pass, userType);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    
                    Response.Redirect("~/Dashboard.aspx");
                }
                else
                {
                     errorLabel.Text = "UserId & Password Is not correct Try again..!!";
                     errorLabel.Visible = true;
                     username.Text = "";
                     password.Text = "";


                }
                cnn.Close();          
           
            
        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            DisplayUserName.displayUserType = "customer";
            Response.Redirect("~/Customer_Registration.aspx");
        }
    }
}