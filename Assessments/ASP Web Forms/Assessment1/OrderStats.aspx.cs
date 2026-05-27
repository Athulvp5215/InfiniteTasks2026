using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assessment1
{
    public partial class OrderStats : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            
            lblVisitors.Text = Application["TotalVisitors"].ToString();
            lblActiveUsers.Text = Application["ActiveUsers"].ToString();

            if (!IsPostBack)
            {
                LoadCategoryStats();
            }
        }

       
        void LoadCategoryStats()
        {
            DataTable dt;

            // Check Cache
            if (Cache["FoodCategoryStats"] == null)
            {
               
                SqlConnection con = new SqlConnection(cs);

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Category, COUNT(*) AS TotalItems FROM MenuItems GROUP BY Category",
                    con);

                dt = new DataTable();
                da.Fill(dt);

               
                Cache.Insert(
                    "FoodCategoryStats",
                    dt,
                    null,
                    DateTime.Now.AddMinutes(5),
                    System.Web.Caching.Cache.NoSlidingExpiration
                );
            }
            else
            {
              
                dt = (DataTable)Cache["FoodCategoryStats"];
            }

            
            gvCategoryStats.DataSource = dt;
            gvCategoryStats.DataBind();
        }
    }
}
