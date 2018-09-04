using Activity.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Activity.Pages
{
    public partial class Files : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string uname = (String)Session["Username"];
                if (String.IsNullOrEmpty(uname))
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    ErrorMessage.Visible = false;
                    InitializeGrid();
                    LoadData();
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

            grid.Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            grid.Columns[1].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            grid.Columns[3].CellStyle.HorizontalAlign = HorizontalAlign.Center;
            grid.Columns[5].CellStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();

            string sql = "SELECT DocumentID,DocumentName,Extension,FileSize,Memo Notes,InputID Uploader,InputDateTime UploadDate FROM IT..Technical_MasterDocument";
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
            dt.Columns.Add("DocumentID", typeof(String));
            dt.Columns.Add("DocumentName", typeof(String));
            dt.Columns.Add("Extension", typeof(String));
            dt.Columns.Add("FileSize", typeof(String));
            dt.Columns.Add("Notes", typeof(String));
            dt.Columns.Add("Uploader", typeof(String));
            dt.Columns.Add("UploadDate", typeof(DateTime));

            return dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string uname = (String)Session["Username"].ToString().ToUpper();

                if (!uploadControl.HasFile)
                {
                    FailureText.Text = "No File Selected !!";
                    ErrorMessage.Visible = true;
                }
                else
                {
                    string filename = Path.GetFileName(uploadControl.PostedFile.FileName);
                    string extension = Path.GetExtension(filename);
                    string contentType = uploadControl.PostedFile.ContentType;
                    HttpPostedFile file = uploadControl.PostedFile;
                    byte[] fileData = new byte[file.ContentLength];
                    file.InputStream.Read(fileData, 0, file.ContentLength);

                    //Validations  
                    if (extension != "")//extension  
                    {
                        if (fileData.Length <= 31457280)//size  
                        {
                            string sql = "INSERT INTO IT..Technical_MasterDocument VALUES (@0, @1, @2, @4, @5, SYSDATETIME(), @3,@6)";
                            DB.Insert(sql, new object[] { filename, extension, fileData.Length, fileData, memoBox.Text.ToString(), uname ,contentType});

                            FailureText.Text = "File has been succesfully added !!";
                            ErrorMessage.Visible = true;
                            memoBox.Text = "";
                           
                            LoadData();
                        }
                        else
                        {
                            FailureText.Text = "Invalid File size !!";
                            ErrorMessage.Visible = true;
                        }
                    }
                    else
                    {
                        FailureText.Text = "Invalid File Extension !!";
                        ErrorMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible) { Panel1.Visible = false; btnAdd.Text = "Add Document"; }
            else { Panel1.Visible = true; btnAdd.Text = "Hide Form"; }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string id = grid.GetDataRow(grid.FocusedRowIndex)["DocumentID"].ToString();
            Response.Redirect("/Pages/DeleteFiles.aspx?fileId=" + id);
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string id = grid.GetDataRow(grid.FocusedRowIndex)["DocumentID"].ToString();
            Response.Redirect("/Pages/Download.aspx?fileId=" + id);
        }
    }
}