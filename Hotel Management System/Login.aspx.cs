using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management_System
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      

        protected void login_Click(object sender, EventArgs e)
        {
            if (username.Text== "test" && password.Text== "test")
            {

                DisplayUserName.displayName = username.Text;
                Response.Redirect("~/Dashboard.aspx");
                
            }
            else
            {
                errorLabel.Visible = true;
                username.Text = "";
                password.Text = "";
            }
        }

        protected void password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}