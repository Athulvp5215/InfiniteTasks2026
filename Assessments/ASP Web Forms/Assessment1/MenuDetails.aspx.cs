using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Assessment1
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            //  Session check
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadDetails();
            }
        }

        void LoadDetails()
        {
            if (Request.QueryString["MenuId"] == null)
                return;

            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblName.Text = dr["Name"].ToString();
                    lblPrice.Text = dr["Price"].ToString();
                    lblCategory.Text = dr["Category"].ToString();
                    lblDesc.Text = dr["Description"].ToString();
                }
            }
        }
    }
}
