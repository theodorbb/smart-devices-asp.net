using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUtilizatori_Click(object sender, EventArgs e)
        {
            Response.Redirect("Utilizatori.aspx");
        }

        protected void btnIstoric_Click(object sender, EventArgs e)
        {
            Response.Redirect("IstoricUtilizari.aspx");
        }

        protected void btnGrafice_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grafice.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string pretValue = e.NewValues["Pret"]?.ToString() ?? string.Empty;
            pretValue = pretValue.Replace(",", ".");
            pretValue = Regex.Replace(pretValue, "[^0-9.]", "");

            if (!decimal.TryParse(pretValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal formattedPrice))
            {
                e.Cancel = true;
                lblErrorMessage.Text = "Formatul prețului este invalid. Vă rugăm să introduceți un număr valid.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (formattedPrice <= 0)
            {
                e.Cancel = true;
                lblErrorMessage.Text = "Prețul nu poate fi zero sau negativ. Vă rugăm să introduceți un preț valid.";
                lblErrorMessage.Visible = true;
                return;
            }

            string anulLansariiValue = e.NewValues["AnulLansarii"]?.ToString() ?? string.Empty;
            if (!int.TryParse(anulLansariiValue, out int anulLansarii))
            {
                e.Cancel = true;
                lblErrorMessage.Text = "Formatul anului este invalid. Vă rugăm să introduceți un an valid.";
                lblErrorMessage.Visible = true;
                return;
            }

            if (anulLansarii < 1970)
            {
                e.Cancel = true;
                lblErrorMessage.Text = "Anul nu poate fi anterior lui 1970. Vă rugăm să introduceți un an valid.";
                lblErrorMessage.Visible = true;
                return;
            }

            e.NewValues["Pret"] = formattedPrice;
            e.NewValues["AnulLansarii"] = anulLansarii;
            lblErrorMessage.Visible = false;
        }



        protected void DropDownListFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
    }
}