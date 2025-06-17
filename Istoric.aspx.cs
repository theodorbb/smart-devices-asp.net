using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserFilter.Text.Trim();

                int? userId = GetUserIDByName(userName);

                SqlDataSourceIstoric.SelectCommand = "EXEC sp_GetIstoricUtilizari @UserName";
                SqlDataSourceIstoric.SelectParameters["UserName"].DefaultValue = userName;
                GridViewIstoric.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

        private int? GetUserIDByName(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return null;

                int? userId = null;
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DispozitiveSmartConnectionString"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 UserID FROM Utilizatori WHERE Nume LIKE @UserName";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@UserName", "%" + userName + "%");

                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }

                return userId;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}