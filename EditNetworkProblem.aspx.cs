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
    public partial class EditNetworkProblem : System.Web.UI.Page
    {
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
            networkProviders.Items.Clear();
            DataTable dt = new DataTable();
            dt = DB.SelectArrayDataTable("SELECT ProviderName, ProviderID FROM IT..Technical_MasterProvider WHERE IsActive = 1",
                new object[] { });
            DataRow dr = dt.Rows[0];
            networkProviders.DataSource = dt;
            networkProviders.DataTextField = "ProviderName";
            networkProviders.DataValueField = "ProviderID";
            networkProviders.DataBind();
        }

        private void LoadData()
        {
            int id = Convert.ToInt32(Request.QueryString["problemId"].ToString());
            

            DataTable dt = new DataTable();
            dt = DB.SelectArrayDataTable("SELECT * FROM IT..Technical_ProviderProblem WHERE ProviderProblem_ID = @0", new object[] { id });
            DataRow dr = dt.Rows[0];
            try
            {
                networkProviders.Items.FindByValue(dr["ProviderID"].ToString()).Selected = true;
            }
            catch(Exception esx)
            {
                networkProviders.SelectedIndex = 0;
            }

            problemname.Text = dr["ProviderProblemName"].ToString();
            downTime.Date = Convert.ToDateTime(dr["DownDateTime"].ToString());
            upTime.Date = Convert.ToDateTime(dr["UpDateTime"].ToString());
            memo.Text = dr["Memo"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    string uname = (String)Session["Username"].ToString().ToUpper();
                    
                    int id = Convert.ToInt32(Request.QueryString["problemId"].ToString());
                    int providerid = Int32.Parse(networkProviders.SelectedValue.ToString());
                   
                    string down = downTime.Text.ToString();
                    string up = upTime.Text.ToString();
                    string desc = memo.Text;
                    string probname = problemname.Text.ToString();

                    string sql = "UPDATE IT..Technical_ProviderProblem SET ProviderProblemName = @0, ProviderID = @1, DownDateTime = @2, " +
                        "UpDateTime = @3, Memo = @4 " +
                        "WHERE ProviderProblem_ID = @5";
                    DB.Insert(sql, new object[] { probname, providerid, down, up, desc, id });

                   
                    string sql2 = "UPDATE IT..Technical_TechnicalActivity SET EditID=@0,EditDateTime = SYSDATETIME()" +
                        "WHERE ReferenceID = @1 AND ReferenceTableName='Technical_ProviderProblem'";
                    DB.Insert(sql2, new object[] { uname, id });

                    Response.Redirect("~/Pages/NetworkProblem.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }        
    }
}