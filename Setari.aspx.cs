using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDeviceDropdown();
            }
        }

        private void BindDeviceDropdown()
        {
            ddlDevices.DataSource = GetDevices();
            ddlDevices.DataTextField = "Denumire";
            ddlDevices.DataValueField = "DispozitivID";
            ddlDevices.DataBind();
        }

        private DataTable GetDevices()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DispozitiveSmartConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DispozitivID, Denumire FROM Dispozitive", conn);
                DataTable devices = new DataTable();
                adapter.Fill(devices);
                return devices;
            }
        }

        protected void ddlDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSettingsGrid();
        }

        private void BindSettingsGrid()
        {
            int deviceId = int.Parse(ddlDevices.SelectedValue);
            gvSettings.DataSource = GetSettingsForDevice(deviceId);
            gvSettings.DataBind();
        }

        private DataTable GetSettingsForDevice(int deviceId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DispozitiveSmartConnectionString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT d.Denumire, s.NumeSetare, s.ValoareSetare FROM Dispozitive d JOIN SetariDispozitive s ON d.DispozitivID = s.DispozitivID WHERE d.DispozitivID = @DispozitivID", conn);
                cmd.Parameters.AddWithValue("@DispozitivID", deviceId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable settings = new DataTable();
                adapter.Fill(settings);
                return settings;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}
