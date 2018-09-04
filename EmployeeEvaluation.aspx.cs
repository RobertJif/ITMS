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
    public partial class EmployeeEvaluation : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

            InitializeComponent();
            InitializeGrid();

            try
            {
                DB.id4 = Request.QueryString["ID"].ToString();
                if (DB.id4 == "belum")
                {
                    Panel1.Visible = true;
                    if (DB.id1 != "")
                    {
                        id.SelectedIndex = id.Items.IndexOf(id.Items.FindByText(DB.id1));
                        id2.SelectedIndex = id2.Items.IndexOf(id2.Items.FindByText(DB.id2));
                        id3.SelectedIndex = id3.Items.IndexOf(id3.Items.FindByText(DB.id3));

                        LoadData(DB.id1, DB.id2, DB.id3);
                    }
                    
                }
                else
                {
                    LoadDataActivity(DB.id1, DB.id2, DB.id3, DB.id4);
                    Panel2.Visible = true;
                    btnbacktop.Visible = true;
                    btnbackbot.Visible = true;

                }

            }
            catch(Exception start)
            {
                try
                {
                    if (DB.id1 != "")
                    {
                        id.SelectedIndex = id.Items.IndexOf(id.Items.FindByText(DB.id1));
                        id2.SelectedIndex = id2.Items.IndexOf(id2.Items.FindByText(DB.id2));
                        id3.SelectedIndex = id3.Items.IndexOf(id3.Items.FindByText(DB.id3));
                        LoadData(DB.id1, DB.id2, DB.id3);
                    }
                }
                catch(Exception aaa)
                {

                }
               
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string uname = (String)Session["Username"];
            if (String.IsNullOrEmpty(uname))
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {            }

        }

        private void InitializeComponent()
        {
            id.Items.Clear();
            DataTable dt = new DataTable();
            string sql = @"SELECT DISTINCT InputID FROM IT..Programmer_Activity";
            dt = DB.SelectArrayDataTable(sql, null);
            id.Items.Add("Select User");
            foreach (DataRow dr in dt.Rows)
                id.Items.Add(dr["InputID"].ToString());
            id.SelectedIndex = 0;

            id2.Items.Clear();
            DataTable dt2 = new DataTable();
            string sql2 = @"SELECT DISTINCT FORMAT(InputDateTime,'yyyy') dates FROM IT..Programmer_Activity A ORDER BY dates desc";
            dt2 = DB.SelectArrayDataTable(sql2, null);
            id2.Items.Add("Year");
            foreach (DataRow dr2 in dt2.Rows)
                id2.Items.Add(dr2["dates"].ToString());
            id2.SelectedIndex = 0;
        }

        private void InitializeGrid()
        {
            DataTable dt = new DataTable();
            Panel1.Visible = false;
            Panel2.Visible = false;
            dt = AddColumn(dt);
        

        }

        private void LoadData(string id,string id2,string id3)
        {
            string aw = "";
            DataTable dt = new DataTable();
            try
            {
                aw = id3.Substring(0, 3);
            }
            catch(Exception a)
            {

            }
           
            string sql = @"SELECT A.MemoID ID,(SELECT Z.MemoDescription FROM IT..Programmer_Memo Z where Z.MemoID=A.MemoID) MemoID,COUNT(A.MemoID) total FROM IT..Programmer_Activity A
WHERE FORMAT(InputDateTime,'MMM')=@0 AND FORMAT(InputDateTime,'yyyy')=@1 AND A.InputID=@2
GROUP BY A.MemoID ORDER BY total desc";
            dt = DB.SelectArrayDataTable(sql, new object[] { aw ,id2,id});

            if (dt.Rows.Count < 1) dt = AddColumn(dt);

            grid.DataSource = dt;
            grid.DataBind();

        }
        private void LoadDataActivity(string id, string id2, string id3,string id4)
        {
            string aw = "";
            DataTable dt2 = new DataTable();
            try
            {
                aw = id3.Substring(0, 3);
            }
            catch (Exception a)
            {

            }

            string sql = @"SELECT (SELECT F.ProjectName FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectName,
(SELECT B.ModuleName FROM IT..Programmer_Module B where B.ModuleID=A.ModuleID) ModuleName,
A.ActivityDescription,A.InputDateTime FROM IT..Programmer_Activity A
WHERE FORMAT(InputDateTime,'MMM')=@0 AND FORMAT(InputDateTime,'yyyy')=@1 AND A.InputID=@2 AND A.MemoID=@3 ORDER BY A.InputDateTime";
            dt2 = DB.SelectArrayDataTable(sql, new object[] { aw, id2, id ,id4});

            if (dt2.Rows.Count < 1) dt2 = AddColumnAct(dt2);

            grid2.DataSource = dt2;
            grid2.DataBind();

        }
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            DB.id1 = id.Text;
            DB.id2 = id2.Text;
            DB.id3 = id3.Text;

            LoadData(id.Text,id2.Text,id3.Text);
        }

        private DataTable AddColumn(DataTable dt)
        {
            dt.Columns.Add("ID", typeof(String));
            dt.Columns.Add("MemoID", typeof(String));
            dt.Columns.Add("total", typeof(Int32));

            return dt;
        }
        private DataTable AddColumnAct(DataTable dt)
        {
            dt.Columns.Add("ActivityDescription", typeof(String));
            dt.Columns.Add("InputDateTime", typeof(String));
            dt.Columns.Add("ProjectName", typeof(String));
            dt.Columns.Add("ModuleName", typeof(String));

            return dt;
        }
        protected void btnbacktop_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            Panel1.Visible = true;
            LoadData(DB.id1, DB.id2, DB.id3);
            btnbacktop.Visible = false;
            btnbackbot.Visible = false;
            id.SelectedIndex = id.Items.IndexOf(id.Items.FindByText(DB.id1));
            id2.SelectedIndex = id2.Items.IndexOf(id2.Items.FindByText(DB.id2));
            id3.SelectedIndex = id3.Items.IndexOf(id3.Items.FindByText(DB.id3));
        }
    }
}