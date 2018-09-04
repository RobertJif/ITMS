using Activity.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Activity.Pages
{
    public partial class EditProvider : System.Web.UI.Page
    {
        //private static string baseProjectId = "";
        protected void Page_Init(object sender, EventArgs e)
        {
            string uname = (String)Session["Username"];
            if (String.IsNullOrEmpty(uname))
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                InitalizeComponent();
                LoadData();
            }
        }        

        private void InitalizeComponent()
        {
            download.Items.Clear();
            download.Items.AddRange(new string[] { "Mbps", "Kbps" });
            download.SelectedIndex = 0;

            upload.Items.Clear();
            upload.Items.AddRange(new string[] { "Mbps", "Kbps" });
            upload.SelectedIndex = 0;

            code.Text = "";
            cost.Text = "";

            LocationID.Items.Clear();
            DataTable dtm = new DataTable();
            dtm = DB.SelectArrayDataTable("SELECT LocationID,LocationName FROM IT..Technical_MasterLocation",
                new object[] { });
            DataRow drm = dtm.Rows[0];
            LocationID.DataSource = dtm;
            LocationID.DataTextField = "LocationName";
            LocationID.DataValueField = "LocationID";
            LocationID.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string uname = (String)Session["Username"].ToString().ToUpper();

                string providerName = code.Text.ToString();

                bool isChecked = this.isActive.Checked;
                int isActive = 0;
                if (isChecked) isActive = 1;

                string LocationNamestr = LocationID.SelectedValue.ToString();

                int LocationName = Int32.Parse(LocationNamestr);

                string down = downSpeed.Text + " " + download.Text;
                string up = upSpeed.Text + " " + upload.Text;
                double cost = Convert.ToDouble(this.cost.Text.ToString());

                string sql = @"UPDATE IT..Technical_MasterProvider SET ProviderName = @0, 
                            LocationID = @1,DownloadSpeed = @2, UploadSpeed = @3, MonthlyCost = @4, 
                            ContractStartDate = @7, IsActive=@5 WHERE ProviderID = @6";
                DB.Insert(sql, new object[] { providerName, LocationName, down, up, cost, isActive, Int32.Parse(Request.QueryString["ProviderId"].ToString()),contractdateTime.Text});

                

                Response.Redirect("~/Pages/Provider.aspx");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      

        private void LoadData()
        {

            //string projectIdX = Request.QueryString["ProjectID"].ToString();
            //ProjectID.Text = projectIdX;
            //baseProjectId = projectIdX;
            string code = Request.QueryString["ProviderID"].ToString();
            DataTable dt = new DataTable();

            string sql = "SELECT * " +
                "FROM IT..Technical_MasterProvider WHERE ProviderID = @0";
            dt = DB.SelectArrayDataTable(sql, new object[] { code });
            DataRow dr = dt.Rows[0];
            //code.Text = dr["ProviderName"].ToString();
            this.code.Text = dr["ProviderName"].ToString();
            
            LocationID.Text = dr["LocationID"].ToString();
            upSpeed.Text = dr["UploadSpeed"].ToString().Remove(dr["UploadSpeed"].ToString().Length - 5, 5);
            downSpeed.Text = dr["DownloadSpeed"].ToString().Remove(dr["DownloadSpeed"].ToString().Length - 5, 5);
            upload.Text = dr["UploadSpeed"].ToString().Substring(dr["UploadSpeed"].ToString().Length - 4, 4);
            download.Text = dr["DownloadSpeed"].ToString().Substring(dr["DownloadSpeed"].ToString().Length - 4, 4);
            cost.Text = dr["MonthlyCost"].ToString();
   
            contractdateTime.Date = Convert.ToDateTime(dr["ContractStartDate"].ToString());
            int isActive = Convert.ToInt32(dt.Rows[0]["IsActive"].ToString());
            if (isActive == 1) this.isActive.Checked = true;
            else this.isActive.Checked = false;
        }        
                
    }
}