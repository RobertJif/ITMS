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
    public partial class NetworkProblem : System.Web.UI.Page
    {
        protected static int isEdit = 0, isDelete = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string uname = (String)Session["Username"];
            if (String.IsNullOrEmpty(uname))
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                InitializeGrid();
                LoadData();

                uname = uname.ToUpper();
                if (uname == "HENDRI IRAWAN" || uname == "RIAN" || uname == "HARISSURYA" || uname == "TONISANDRO")
                {
                    btnNew.Visible = true;
                    isEdit = 1;
                    isDelete = 1;
                }
                else
                {
                    btnNew.Visible = false;
                    isEdit = 0;
                    isDelete = 0;
                }
            }
        }

        private void InitializeGrid()
        {
            DataTable dt = new DataTable();

            dt = AddColumn(dt);
            grid.DataSource = dt;
            grid.DataBind();

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center;
      

        }

        private void LoadData()
        {
            DataTable dt = new DataTable();

            string sql = @"SELECT A.ProviderProblem_ID ID,A.ProviderProblemName,B.ProviderName,
                        (select C.LocationName from IT..Technical_MasterLocation C where C.LocationID=B.LocationID) LocationName,
                        A.DownDateTime,A.UpDateTime,A.Memo,A.InputID,A.InputDateTime
                        FROM IT..Technical_ProviderProblem A, IT..Technical_MasterProvider B
                        WHERE A.ProviderID= B.ProviderID ORDER BY A.ProviderProblem_ID Desc;";
            dt = DB.SelectArrayDataTable(sql, null);

            if (dt.Rows.Count < 1)
                dt = AddColumn(dt);

            grid.DataSource = dt;
            grid.DataBind();

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private DataTable AddColumn(DataTable dt)
        {
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("ProviderProblemName", typeof(String));
            dt.Columns.Add("ProviderName", typeof(String));
            dt.Columns.Add("LocationName", typeof(DateTime));
            dt.Columns.Add("DownDateTime", typeof(DateTime));
            dt.Columns.Add("UpDateTime", typeof(DateTime));
            dt.Columns.Add("Memo", typeof(String));
            dt.Columns.Add("InputID", typeof(String));
            dt.Columns.Add("InputDateTime", typeof(DateTime));
            return dt;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string id = grid.GetDataRow(grid.FocusedRowIndex)["ID"].ToString();
            Response.Redirect("/Pages/EditNetworkProblem.aspx?problemId=" + id);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/NewNetworkProblem.aspx");
        }

    }
}