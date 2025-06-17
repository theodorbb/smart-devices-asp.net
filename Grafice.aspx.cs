using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZedGraph;

namespace UtilizareaDispozitivelorSmart_BragareaIonutTheodor_1132
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ZedGraphWeb1.RenderGraph += ZedGraphWeb1_RenderGraph1;

            if (!IsPostBack)
            {
                SetSelectedGraphType();

                DataSet dataSet = new DataSet();
                string connectionString = ConfigurationManager.ConnectionStrings["DispozitiveSmartConnectionString"].ConnectionString;

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetDeviceUsage", sqlConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;  
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(dataSet);  
                        GridView1.DataSource = dataSet;  
                        GridView1.DataBind();
                        Cache["Dispozitive"] = dataSet;  
                        Session["Dispozitive"] = dataSet.Tables[0]; 
                    }
                }
            }
        }


        private void ZedGraphWeb1_RenderGraph1(ZedGraph.Web.ZedGraphWeb webObject, Graphics g, ZedGraph.MasterPane pane)
        {
            GraphPane myPane = pane[0];
            myPane.Title.Text = "Utilizarea Dispozitivelor";
            myPane.XAxis.Title.Text = "Dispozitiv";
            myPane.YAxis.Title.Text = "Durata Totala Utilizare (Minute)";

            DataSet ds = (DataSet)Cache["Dispozitive"];
            Color[] colors = {
            Color.Red, Color.Yellow, Color.Green, Color.Blue,
            Color.Purple, Color.Pink, Color.Plum, Color.Silver, Color.Salmon
            };

            PointPairList list = new PointPairList();
            List<string> deviceNames = new List<string>();
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                string deviceName = r["Denumire"].ToString();
                double totalDuration = Convert.ToDouble(r["Durata Totala Utilizare (Minute)"]);
                list.Add(deviceNames.Count, totalDuration);
                deviceNames.Add(deviceName);
            }

            string graphType = Request.QueryString["tip"];
            switch (graphType)
            {
                case "Bare":
                    BarItem barItem = myPane.AddBar("Utilizare", list, Color.Blue);
                    barItem.Bar.Fill = new Fill(Color.Blue);
                    myPane.XAxis.Type = AxisType.Text;
                    myPane.XAxis.Scale.TextLabels = deviceNames.ToArray();
                    break;

                case "Linie":
                    LineItem lineItem = myPane.AddCurve("Utilizare", list, Color.Red, SymbolType.Diamond);
                    lineItem.Line.IsSmooth = true;
                    lineItem.Line.SmoothTension = 0.5F;
                    lineItem.Symbol.Fill = new Fill(Color.White);
                    myPane.XAxis.Type = AxisType.Text;
                    myPane.XAxis.Scale.TextLabels = deviceNames.ToArray();
                    break;

                case "Pie":
                    double total = list.Sum(p => p.Y);
                    for (int i = 0; i < list.Count; i++)
                    {
                        double percent = (list[i].Y / total) * 100;
                        string label = $"{deviceNames[i]}: {list[i].Y} min ({percent:F2}%)";
                        myPane.AddPieSlice(list[i].Y, colors[i % colors.Length], 0.2, label);
                    }
                    break;


                default:
                    break;
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Grafice.aspx/?tip=" + RadioButtonList1.SelectedValue);
        }
        private void SetSelectedGraphType()
        {
            var selectedGraphType = Request.QueryString["tip"];
            if (!string.IsNullOrEmpty(selectedGraphType))
            {
                ListItem selectedItem = RadioButtonList1.Items.FindByValue(selectedGraphType);
                if (selectedItem != null)
                {
                    RadioButtonList1.ClearSelection();
                    selectedItem.Selected = true;
                }
            }
        }
    }
}
