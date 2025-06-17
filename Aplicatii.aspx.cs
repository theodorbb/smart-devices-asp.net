using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132
{
    public partial class Aplicatii : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDeviceDropdown();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        private void BindDeviceDropdown()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DispozitiveSmartConnectionString"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT DispozitivID, Denumire FROM Dispozitive", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlDispozitive.DataSource = reader;
                    ddlDispozitive.DataTextField = "Denumire";
                    ddlDispozitive.DataValueField = "DispozitivID";
                    ddlDispozitive.DataBind();
                }
            }
            ddlDispozitive.Items.Insert(0, new ListItem("-- Selectează Dispozitivul --", ""));
        }

        protected void ddlDispozitive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDispozitive.SelectedValue) && ddlDispozitive.SelectedValue != "")
            {
                BindAppsData(Convert.ToInt32(ddlDispozitive.SelectedValue));
            }
            else
            {
                ListView1.DataSource = null;
                ListView1.DataBind();
            }
        }




        private void BindAppsData(int dispozitivID)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DispozitiveSmartConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAppsByDevice", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DispozitivID", dispozitivID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<AppData> apps = new List<AppData>();
                    while (reader.Read())
                    {
                        apps.Add(new AppData
                        {
                            NumeAplicatie = reader["NumeAplicatie"].ToString(),
                            Versiune = reader["Versiune"].ToString(),
                            DataInstalare = Convert.ToDateTime(reader["DataInstalare"])
                        });
                    }

                    ListView1.DataSource = apps;
                    ListView1.DataBind();
                }
            }
        }

        public class AppData
        {
            public string NumeAplicatie { get; set; }
            public string Versiune { get; set; }
            public DateTime DataInstalare { get; set; }
        }
    }
}
