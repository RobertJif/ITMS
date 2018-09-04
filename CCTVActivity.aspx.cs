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
    public partial class CCTVActivity : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            InitializeComponent();
            InitializeGrid();
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
                btnLoad_Click(null, null);
            }
        }

        private void InitializeComponent()
        {
            id.Items.Clear();
            DataTable dt = new DataTable();
            string sql = "SELECT DISTINCT InputDate sort,CONVERT(varchar(20), InputDate,13) InputDateTime FROM IT..Technical_CCTVActivity Order by sort desc";
            dt = DB.SelectArrayDataTable(sql, null);
            foreach (DataRow dr in dt.Rows)
                id.Items.Add(dr["InputDateTime"].ToString());
            id.SelectedIndex = -1;
        }

        private void InitializeGrid()
        {
            DataTable dt = new DataTable();

            dt = AddColumn(dt);
            grid.DataSource = dt;
            grid.DataBind();

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            grid.Columns["Status"].CellStyle.HorizontalAlign = HorizontalAlign.Center;

        }

        private void LoadData(string id)
        {
            DataTable dt = new DataTable();

            string sql = @"SELECT A.CCTVID,(select B.VideoRecorderName from IT..Technical_MasterVideoRecorder B where A.VideoRecorderID=B.VideoRecorderID) VideoRecorderName,
                        (select C.CameraName from IT..Technical_MasterCamera C where C.CameraID=A.CameraID) CameraName
                        ,A.Status,A.Memo
                        FROM IT..Technical_CCTVActivity A
                    WHERE A.InputDate = @0";
            dt = DB.SelectArrayDataTable(sql, new object[] { id });

            if (dt.Rows.Count < 1) dt = AddColumn(dt);

            grid.DataSource = dt;
            grid.DataBind();

           
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData(id.Text.ToString());
        }

        private DataTable AddColumn(DataTable dt)
        {
            
            dt.Columns.Add("CCTVID", typeof(String));
            dt.Columns.Add("VideoRecorderName", typeof(String));
            dt.Columns.Add("CameraName", typeof(String));
            dt.Columns.Add("Status", typeof(String));
            dt.Columns.Add("Memo", typeof(String));
            return dt;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/NewCCTVActivity");
        }

    }
}