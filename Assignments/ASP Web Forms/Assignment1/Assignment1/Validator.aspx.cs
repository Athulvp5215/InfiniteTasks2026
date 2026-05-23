using System;

namespace Assignment1

{

    public partial class Validator : System.Web.UI.Page

    {

        protected void Page_Load(object sender, EventArgs e)

        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)

        {

            if (Page.IsValid)

            {

                lblMessage.Text = "Form submitted successfully!";

            }

            else

            {

                lblMessage.Text = "";

            }

        }

    }

}
