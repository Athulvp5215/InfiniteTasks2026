using System;

namespace Assessment1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["TotalVisitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["TotalVisitors"] = Convert.ToInt32(Application["TotalVisitors"]) + 1;
            Application["ActiveUsers"] = Convert.ToInt32(Application["ActiveUsers"]) + 1;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["ActiveUsers"] = Convert.ToInt32(Application["ActiveUsers"]) - 1;
        }

       
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = Request.Url.AbsolutePath.ToLower();

         
            if (url == "/" || url == "/login")
            {
                Response.Redirect("~/Login.aspx");
            }

            if (url == "/addeditmenu")
            {
                Response.Redirect("~/AddEditMenu.aspx");
            }

      
            if (url == "/menulist")
            {
                Response.Redirect("~/MenuList.aspx");
            }

           
            if (url == "/menudetails")
            {
                Response.Redirect("~/MenuDetails.aspx");
            }

         
            if (url == "/orderstats")
            {
                Response.Redirect("~/OrderStats.aspx");
            }
        }
    }
}
