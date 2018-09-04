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
    public partial class Module : System.Web.UI.Page
    {   
        private string loginname = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string uname = (String)Session["Username"];
            loginname = ""+uname;
            if (String.IsNullOrEmpty(uname))
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                InitializeGrid();
                LoadData();

            }

            uname = uname.ToUpper();
            if (uname == "HENDRI IRAWAN")
            {
                btnNew.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
            }
            else if (uname == "JANITRA")
            {
                btnNew.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
            }
            else if (uname == "MULYADI")
            {
                btnNew.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                btnNew.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                
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
            grid.Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Left;
            grid.Columns[1].CellStyle.HorizontalAlign = HorizontalAlign.Left;

        }

        private void LoadData()
        {   
            DataTable dt = new DataTable();

            string sql = @"SELECT A.ModuleID,A.ModuleName,A.ProjectID,
(SELECT F.ProjectName FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectName,A.IsActive,
(select top 1 E.InputDateTime from IT..Programmer_Activity E where E.ModuleID=A.ModuleID order by E.InputDateTime) FirstBuildDateTime,
(select top 1 E.InputDateTime from IT..Programmer_Activity E where E.ModuleID=A.ModuleID order by E.InputDateTime desc) LastBuildDateTime,
(SELECT COUNT(*) FROM IT..Programmer_Memo where ModuleID=A.ModuleID) TaskTotal,
(SELECT COUNT(*) FROM IT..Programmer_Memo where Status = 1 AND ModuleID=A.ModuleID) TaskCompleted
FROM IT..Programmer_Module A LEFT JOIN
     (SELECT B.ProjectID
      FROM IT..Programmer_Activity B
      GROUP BY B.ProjectID
     ) B
     ON A.ProjectID = B.ProjectID LEFT JOIN
     (SELECT C.ProjectID,COUNT(MemoID) Total
      FROM IT..Programmer_Memo C
      GROUP BY C.ProjectID
     ) C
     ON A.ProjectID = C.ProjectID LEFT JOIN
     (SELECT D.ProjectID
      FROM IT..Programmer_Project D
      GROUP BY D.ProjectID
     ) D
     ON A.ProjectID = D.ProjectID";
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
            dt.Columns.Add("ModuleID", typeof(String));
            dt.Columns.Add("ModuleName", typeof(String));
            dt.Columns.Add("ProjectName", typeof(String));
            dt.Columns.Add("IsActive", typeof(Boolean));
            dt.Columns.Add("FirstBuildDateTime", typeof(DateTime));
            dt.Columns.Add("LastBuildDateTime", typeof(DateTime));
            dt.Columns.Add("TastTotal", typeof(DateTime));
            dt.Columns.Add("TaskCompleted", typeof(DateTime));
            dt.Columns.Add("ProjectID", typeof(String));

            return dt;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/NewModule.aspx");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string moduleId = grid.GetDataRow(grid.FocusedRowIndex)["ModuleId"].ToString();
            Response.Redirect("/Pages/EditModule.aspx?moduleId=" + moduleId);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string ModuleID = grid.GetDataRow(grid.FocusedRowIndex)["ModuleID"].ToString();
            string ProjectID = grid.GetDataRow(grid.FocusedRowIndex)["ProjectID"].ToString();
            int hasActivity = Convert.ToInt32(
                DB.SelectScalar("SELECT COUNT(*) FROM IT..Programmer_Memo WHERE ModuleId = @0 AND ProjectId = @1", 
                new object[] { ModuleID, ProjectID }).ToString());

            if (hasActivity > 0)
            {
                FailureText.Text = "Failed To Delete This Module !!";
                ErrorMessage.Visible = true;
            }
            else
                Response.Redirect("/Pages/DeleteModule.aspx?ModuleID=" + ModuleID + "&ProjectID=" + ProjectID);
        }

       

      
    }
}