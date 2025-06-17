using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    string nume = txtNume.Text;
                    string email = txtEmail.Text;

                    string query = "INSERT INTO Utilizatori (Nume, Email) VALUES (@Nume, @Email)";
                    using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DispozitiveSmartConnectionString"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Nume", nume);
                            cmd.Parameters.AddWithValue("@Email", email);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    GridViewUtilizatori.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "hideModal", "$('#addUserModal').modal('hide');", true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}