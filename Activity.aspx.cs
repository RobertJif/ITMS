using Activity.Core;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Activity.Pages
{
    public partial class Activity : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //DataModel.isReport = false;
        }

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
                if (uname == "MULIADY")
                {
                    btnNew.Visible = false;
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

            for (int i = 0; i < grid.Columns.Count; i++) { grid.Columns[i].CellStyle.HorizontalAlign = HorizontalAlign.Center; grid.Columns["MemoID"].CellStyle.HorizontalAlign = HorizontalAlign.Justify;
                grid.Columns["ActivityDescription"].CellStyle.HorizontalAlign = HorizontalAlign.Justify;
            }



        }

        private void LoadData()
        {
            string uname = (String)Session["Username"].ToString().ToUpper();
            string condt = "ORDER BY A.ActivityID desc";
            string condtuser = "WHERE A.InputID='" + uname + "' ORDER BY A.ActivityID desc";
            DataTable dt = new DataTable();
            string sql = @"SELECT A.ActivityID,
(SELECT F.ProjectName FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectName,
(SELECT G.ModuleName FROM IT..Programmer_Module G where G.ModuleID=A.ModuleID) ModuleName,
(SELECT F.ProjectID FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectID,
(SELECT G.ModuleID FROM IT..Programmer_Module G where G.ModuleID=A.ModuleID) ModuleID,
A.MemoID,A.ActivityDescription,A.InputID,A.InputDateTime,A.EditID,A.EditDateTime
FROM IT..Programmer_Activity A LEFT JOIN
     (SELECT B.ProjectID
      FROM IT..Programmer_Project B
      GROUP BY B.ProjectID
     ) B
     ON A.ProjectID = B.ProjectID LEFT JOIN
     (SELECT C.ProjectID
      FROM IT..Programmer_Module C
      GROUP BY C.ProjectID
     ) C
     ON A.ProjectID = C.ProjectID";
            if(uname.ToUpper()=="HENDRI IRAWAN"|| uname.ToUpper() == "JANITRA") {
                    sql = sql + " " + condt; }
            else
            {
                sql = sql + " " + condtuser;
            }
            dt = DB.SelectArrayDataTable(sql, null);
            
            if (dt.Rows.Count < 1) dt = AddColumn(dt);            

            grid.DataSource = dt;
            grid.DataBind();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private DataTable AddColumn(DataTable dt)
        {
            dt.Columns.Add("ActivityID", typeof(Int32));
            dt.Columns.Add("ProjectName", typeof(String));
            dt.Columns.Add("ModuleName", typeof(String));
            dt.Columns.Add("MemoID", typeof(Int32));
            dt.Columns.Add("ActivityDescription", typeof(String));
            dt.Columns.Add("InputID", typeof(String));
            dt.Columns.Add("InputDateTime", typeof(DateTime));
            dt.Columns.Add("EditID", typeof(String));
            dt.Columns.Add("EditDateTime", typeof(DateTime));
            return dt;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/NewActivity.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string id = grid.GetDataRow(grid.FocusedRowIndex)["ActivityID"].ToString();
            DataTable dt = new DataTable();
            string sql = @"select CAST(InputDateTime AS DATE) InputDateTime,CAST(GETDATE() AS DATE) TodayDate
                            from it..Programmer_Activity
                            where ActivityID=@0
                            order by InputDateTime desc";
            dt = DB.SelectArrayDataTable(sql, new object[] { id });
            DataRow dr = dt.Rows[0];
            string a = dr["InputDateTime"].ToString();
            string b = dr["TodayDate"].ToString();
            string msg = "Action Denied, You are not allowed to edit past activities!";

            if (a==b)
            {
                
                Response.Redirect("/Pages/EditActivity.aspx?activityid=" + id);
            }
            else
            {
                Dialogs.ShowMessageBoxClients(msg);
            }

        }
    }    
}