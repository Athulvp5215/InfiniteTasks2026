using System;

namespace Assessment1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "food@123")
            {
                Session["Username"] = username;
                Session["Role"] = "Admin";

                Response.Redirect("MenuList.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid login. You are not authorized.";
            }
        }
    }
}