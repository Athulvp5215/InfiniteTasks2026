using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assessment1
{
    public partial class MenuList : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadMenu();
            }
        }

        void LoadMenu()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM MenuItems", con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            gvMenu.DataSource = dt;
            gvMenu.DataBind();
        }

        protected void gvMenu_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandArgument == null) return;

            int index = Convert.ToInt32(e.CommandArgument);
            int id = Convert.ToInt32(gvMenu.DataKeys[index].Value);

            if (e.CommandName == "View")
            {
                Response.Redirect("MenuDetails.aspx?MenuId=" + id);
            }

            if (e.CommandName == "Edit")
            {
                Response.Redirect("AddEditMenu.aspx?MenuId=" + id);
            }

            if (e.CommandName == "Delete")
            {
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("DELETE FROM MenuItems WHERE MenuId=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                LoadMenu();
            }
        }

       
        protected void gvMenu_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            
        }
    }
}
