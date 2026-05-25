using System;

namespace Assignment1
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadImage();
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadImage();
            lblPrice.Text = "";
        }

        private void LoadImage()
        {
            // If nothing selected
            if (string.IsNullOrEmpty(ddlProducts.SelectedValue))
            {
                imgProduct.ImageUrl = "";
                return;
            }

            string basePath = ResolveUrl("~/Images/");

            switch (ddlProducts.SelectedValue)
            {
                case "fan":
                    imgProduct.ImageUrl = basePath + "fan.jpg";
                    break;

                case "fridge":
                    imgProduct.ImageUrl = basePath + "fridge.jpg";
                    break;

                case "washingmachine":
                    imgProduct.ImageUrl = basePath + "washingmachine.jpg";
                    break;
            }
        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            switch (ddlProducts.SelectedValue)
            {
                case "fan":
                    lblPrice.Text = "Price : Rs. 2,500";
                    break;

                case "fridge":
                    lblPrice.Text = "Price : Rs. 30,000";
                    break;

                case "washingmachine":
                    lblPrice.Text = "Price : Rs. 22,000";
                    break;

                default:
                    lblPrice.Text = "Please select a product";
                    break;
            }
        }
    }
}