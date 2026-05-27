using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Assessment1
{
    public partial class AddEditMenu : System.Web.UI.Page
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
                if (Request.QueryString["MenuId"] != null)
                {
                    LoadData();
                }
            }
        }

        void LoadData()
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM MenuItems WHERE MenuId=@Id", con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtCategory.Text = dr["Category"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd;

                if (Request.QueryString["MenuId"] == null)
                {
                    // INSERT
                    cmd = new SqlCommand("INSERT INTO MenuItems VALUES(@Name,@Price,@Category,@Desc)", con);
                }
                else
                {
                    // UPDATE
                    int id = Convert.ToInt32(Request.QueryString["MenuId"]);
                    cmd = new SqlCommand("UPDATE MenuItems SET Name=@Name, Price=@Price, Category=@Category, Description=@Desc WHERE MenuId=@Id", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                }

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@Category", txtCategory.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("MenuList.aspx");
        }
    }
}