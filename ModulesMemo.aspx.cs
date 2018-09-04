using Activity.Core;
using DevExpress.Web;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Web.UI;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Web;

namespace Activity.Pages
{
    public partial class ModulesMemo : System.Web.UI.Page
    {
        private static SqlConnection con;
        private static SqlCommand command;
        protected void Page_Init(object sender, EventArgs e)
        {
            string uname = (String)Session["Username"];
            if (String.IsNullOrEmpty(uname))
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                LoadData();
                LoadMyData();
            }
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
                    InitalizeComponent();
                    InitializeGrid();
                    LoadData();
                    LoadMyData();

                    uname = uname.ToUpper();
                    if (uname == "HENDRI IRAWAN" || uname == "JANITRA")
                    {
                        Panel1.Visible = false;
                        btnRelease.Visible = true;
                        btnDownload.Visible = true;
                        btnAddMemo.Visible = true;
                        btnEditMemo.Visible = true;
                        grid2.Visible = false;
                        grid.Visible = true;
                        btnDeleteMamo.Visible = true;

                    }
                    else
                    {
                        Panel1.Visible = false;
                        btnRelease.Visible = false;
                        btnDownload.Visible = true;
                        grid2.Visible = false;
                        grid.Visible = true;

                    }
                    if (uname == "MULIADY")
                    {
                        btnMyMemo.Visible = false;
                        btnTakeMemo.Visible = false;
                        grid2.Visible = false;
                        grid.Visible = true;
                    }
                    
                }
            }
        }

        private void InitalizeComponent()
        {
            ProjectIDlist.Items.Clear();
            ModuleIDlist.Items.Clear();
            DataTable dtp = new DataTable();
            dtp = DB.SelectArrayDataTable("SELECT ProjectID,ProjectName FROM IT..Programmer_Project",
                new object[] { });
            DataRow drp = dtp.Rows[0];
            ProjectIDlist.DataSource = dtp;
            ProjectIDlist.DataTextField = "ProjectName";
            ProjectIDlist.DataValueField = "ProjectID";
            ProjectIDlist.DataBind();
            ProjectIDlist.Items.Insert(0, new ListItem("Select Project", ""));
            ProjectIDlist.SelectedIndex = 0;


            ReleaseTarget.Text = "";
            memoDescription.Text = "";
            
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

            DataTable dt2 = new DataTable();

            dt2 = AddColumn(dt2);
            grid2.DataSource = dt2;
            grid2.DataBind();

            for (int i = 0; i < grid2.Columns.Count; i++)
                grid2.Columns[i].HeaderStyle.HorizontalAlign = HorizontalAlign.Center;

            grid2.Columns[0].CellStyle.HorizontalAlign = HorizontalAlign.Center;
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();

            string filter = " ORDER BY A.MemoID desc";
            string uname = (String)Session["Username"].ToString().ToUpper();
            if (uname != "HENDRI IRAWAN" && uname != "JANITRA" && uname != "MULYADI")
            {
                filter = " WHERE A.UserCode = '' AND A.Status = 0 ORDER BY A.MemoID desc";
            }

            string sql = @"SELECT A.MemoID,
(SELECT F.ProjectName FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectName,
(SELECT G.ModuleName FROM IT..Programmer_Module G where G.ModuleID=A.ModuleID) ModuleName,
(SELECT F.ProjectID FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectID,
(SELECT G.ModuleID FROM IT..Programmer_Module G where G.ModuleID=A.ModuleID) ModuleID,
A.MemoDescription,CASE A.Status WHEN 0 THEN 'NOT RELEASED' ELSE 'RELEASED' END Status1,A.UserCode AssignedUser, A.ReleasedTargetDateTime,
(SELECT top(1) Z.InputDateTime FROM IT..Programmer_Activity Z where Z.MemoID LIKE A.MemoID order by Z.InputDateTime) FirstBuildDateTime
,A.ReleasedRealDateTime
,CASE A.Status2 WHEN 0 THEN 'QUEUED' WHEN 1 THEN 'TAKEN' WHEN 2 THEN 'ONGOING' ELSE 'FINISHED' END Status2,A.FileName
FROM IT..Programmer_Memo A LEFT JOIN
     (SELECT B.ProjectID
      FROM IT..Programmer_Activity B
      GROUP BY B.ProjectID
     ) B
     ON A.ProjectID = B.ProjectID LEFT JOIN
     (SELECT C.ProjectID
      FROM IT..Programmer_Module C
      GROUP BY C.ProjectID
     ) C
     ON A.ProjectID = C.ProjectID LEFT JOIN
     (SELECT D.ProjectID
      FROM IT..Programmer_Project D
      GROUP BY D.ProjectID
     ) D
     ON A.ProjectID = D.ProjectID" + filter;

            dt = DB.SelectArrayDataTable(sql, null);
            if (dt.Rows.Count < 1) dt = AddColumn(dt);

            //foreach(DataRow dr in dt.Rows)
            //{
            //    string str = dr["ReleaseNotificationUser"].ToString();
            //    dr["ReleaseNotificationUser"] = str.Replace("@bangunsaranagroup.com", "");
            //}

            grid.DataSource = dt;
            grid.DataBind();

       

        }
        private void LoadMyData()
        {
            DataTable dt = new DataTable();

            string sql = @"SELECT A.MemoID,
(SELECT F.ProjectName FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectName,
(SELECT G.ModuleName FROM IT..Programmer_Module G where G.ModuleID=A.ModuleID) ModuleName,
(SELECT F.ProjectID FROM IT..Programmer_Project F where F.ProjectID=A.ProjectID) ProjectID,
(SELECT G.ModuleID FROM IT..Programmer_Module G where G.ModuleID=A.ModuleID) ModuleID,
A.MemoDescription,CASE A.Status WHEN 0 THEN 'NOT RELEASED' ELSE 'RELEASED' END Status1,A.UserCode AssignedUser, A.ReleasedTargetDateTime,
(SELECT top(1) Z.InputDateTime FROM IT..Programmer_Activity Z where Z.MemoID LIKE A.MemoID order by Z.InputDateTime) FirstBuildDateTime
,A.ReleasedRealDateTime
,CASE A.Status2 WHEN 0 THEN 'QUEUED' WHEN 1 THEN 'TAKEN' WHEN 2 THEN 'ONGOING' ELSE 'FINISHED' END Status2,A.FileName
FROM IT..Programmer_Memo A LEFT JOIN
     (SELECT B.ProjectID
      FROM IT..Programmer_Activity B
      GROUP BY B.ProjectID
     ) B
     ON A.ProjectID = B.ProjectID LEFT JOIN
     (SELECT C.ProjectID
      FROM IT..Programmer_Module C
      GROUP BY C.ProjectID
     ) C
     ON A.ProjectID = C.ProjectID LEFT JOIN
     (SELECT D.ProjectID
      FROM IT..Programmer_Project D
      GROUP BY D.ProjectID
     ) D
     ON A.ProjectID = D.ProjectID WHERE A.UserCode='" + (String)Session["Username"].ToString().ToUpper()+ "' ORDER BY A.MemoID desc";

            dt = DB.SelectArrayDataTable(sql, null);
            if (dt.Rows.Count < 1) dt = AddColumn(dt);

            //foreach(DataRow dr in dt.Rows)
            //{
            //    string str = dr["ReleaseNotificationUser"].ToString();
            //    dr["ReleaseNotificationUser"] = str.Replace("@bangunsaranagroup.com", "");
            //}

            grid2.DataSource = dt;
            grid2.DataBind();



        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            
            grid2.Visible = true;
            grid.Visible = true;
            LoadData();
            
        }

        private DataTable AddColumn(DataTable dt)
        {   
            dt.Columns.Add("MemoID", typeof(String));
            dt.Columns.Add("ProjectName", typeof(String));
            dt.Columns.Add("ModuleName", typeof(String));
            dt.Columns.Add("ProjectID", typeof(String));
            dt.Columns.Add("ModuleID", typeof(String));
            dt.Columns.Add("MemoDescription", typeof(String));
            dt.Columns.Add("Status1", typeof(String));
            dt.Columns.Add("AssignedUser", typeof(String));
            dt.Columns.Add("ReleasedTargetDateTime", typeof(DateTime));
            dt.Columns.Add("FirstBuildDateTime", typeof(DateTime));
            dt.Columns.Add("ReleasedRealTime", typeof(DateTime));
            dt.Columns.Add("Status2", typeof(String));

            dt.Columns.Add("FileName", typeof(String));



            return dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                string uname = (String)Session["Username"].ToString().ToUpper();
                string contentType = FileUpload1.PostedFile.ContentType;
                int projectId = Convert.ToInt32(ProjectIDlist.SelectedValue);
                int moduleId = 0;
                if (ModuleIDlist.SelectedValue != "") { moduleId = Convert.ToInt32(ModuleIDlist.SelectedValue); }
                
                string mailprojectname = ProjectIDlist.Text.ToString();
                string fileName = FileUpload1.PostedFile.FileName;
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                byte[] data = FileUpload1.FileBytes;

               // SaveFileToDB(memoDescription.Text,projectId,moduleId,uname,this.ReleaseTarget.Text,0,data,fileName,fileExtension);
                string sql = "INSERT INTO IT..Programmer_Memo VALUES (@0,@1,@2,'',@3,'',@4,@5,SYSDATETIME(),@5,SYSDATETIME(),@6,@7,@8,0)";
                DB.Insert(sql, new object[] { memoDescription.Text, projectId, moduleId, ReleaseTarget.Text, 0, uname, data, fileName, fileExtension });

                //string memodescription,int projectidlist,int moduleid,string usercode, string targetdate, string status,byte[] data, string filename,string filext)
                #region UserNotificationEmail

                //ArrayList list = new ArrayList();
                //foreach (ListEditItem item in notificationUser.Items)
                //{
                //    list.Add(item.Value.ToString());
                //}

                //ArrayList mailArr = new ArrayList();

                //foreach (string userCode in list)
                //{
                //    sql = "SELECT COUNT(*) " +
                //        "FROM CM..CoreUserK " +
                //        "WHERE ContactString = 'EMAIL' " +
                //        "AND IsActive = 1 " +
                //        "AND ContactValue != '@bangunsaranagroup.com' " +
                //        "AND ContactValue != '-@bangunsaranagroup.com'" +
                //        "AND UserCode = '" + userCode + "'";
                //    int hasEmail = int.Parse(DB.SelectScalar(sql, null).ToString());

                //    if (hasEmail > 0)
                //    {
                //        sql = "SELECT DISTINCT TOP 1 ContactValue " +
                //                "FROM CM..CoreUserK " +
                //                "WHERE ContactString = 'EMAIL' " +
                //                "AND IsActive = 1 " +
                //                "AND ContactValue != '@bangunsaranagroup.com' " +
                //                "AND ContactValue != '-@bangunsaranagroup.com'" +
                //                "AND UserCode = '" + userCode + "'";
                //        string emailAddress = DB.SelectScalar(sql, null).ToString();

                //        mailArr.Add(emailAddress);
                //    }
                //}

                //string toMail = "";
                //foreach (string address in mailArr) toMail = toMail + address + ",";
                //if (mailArr.Count > 0) toMail = toMail.Substring(0, toMail.Length - 1);

                #endregion


                #region SendEmail


                string mailBody = "New Memo for Project " + ProjectIDlist.SelectedItem.Text.ToString() + " has been added!\nDescription : "+memoDescription.Text;

                ArrayList mailArr2 = new ArrayList();
                if (uname == "MULIADY")
                    mailArr2.AddRange(new string[] { "HENDRI IRAWAN", "JANITRA" });
                else if (uname == "HENDRI IRAWAN")
                    mailArr2.AddRange(new string[] { "JANITRA" });
                else if (uname == "JANITRA")
                    mailArr2.AddRange(new string[] { "HENDRI IRAWAN" });

                if (mailArr2.Count > 0) SendEmail(mailArr2, mailBody);

                #endregion

                InitalizeComponent();
                LoadData();
                LoadMyData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        protected void btnReset_Click(object sender, EventArgs e)
        {
            InitalizeComponent();
        }

        private void SendEmail(ArrayList userList, string mailBody)
        {
            try
            {
                ArrayList mailArr = new ArrayList();

                foreach (string userCode in userList)
                {
                    string sql = "SELECT COUNT(*) " +
                        "FROM CM..CoreUserK " +
                        "WHERE ContactString = 'EMAIL' " +
                        "AND IsActive = 1 " +
                        "AND ContactValue != '@bangunsaranagroup.com' " +
                        "AND ContactValue != '-@bangunsaranagroup.com'" +
                        "AND UserCode = '" + userCode + "'";
                    int hasEmail = int.Parse(DB.SelectScalar(sql, null).ToString());

                    if (hasEmail > 0)
                    {
                        sql = "SELECT DISTINCT TOP 1 ContactValue " +
                                "FROM CM..CoreUserK " +
                                "WHERE ContactString = 'EMAIL' " +
                                "AND IsActive = 1 " +
                                "AND ContactValue != '@bangunsaranagroup.com' " +
                                "AND ContactValue != '-@bangunsaranagroup.com'" +
                                "AND UserCode = '" + userCode + "'";
                        string emailAddress = DB.SelectScalar(sql, null).ToString();

                        mailArr.Add(emailAddress);
                    }
                }

                string mailSubject = "NEW MODULE MEMO";

                MailSender ms = new MailSender();
                ms.SendEmail(mailSubject,
                    mailBody,
                    mailArr); //Send File By Email
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendEmailRelease(string toMail, string mailBody)
        {
            try
            {
                string mailSubject = "MODULE MEMO RELEASE";

                ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate,
                     X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };

                MailMessage mail = new MailMessage();
                MailAddress fromMail = new MailAddress("it.dept@bangunsaranagroup.com");

                mail.From = fromMail;
                mail.To.Add(toMail);
                mail.Subject = mailSubject;
                mail.Body = mailBody;

                SmtpClient client = new SmtpClient("mail.bangunsaranagroup.com", 587);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("it.dept", "12345678");
                client.EnableSsl = true;

                client.Send(mail);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool getActivities(int memoid)
        {
            DataTable dtp = new DataTable();
            dtp = DB.SelectArrayDataTable("SELECT * FROM IT..Programmer_Activity A WHERE A.MemoID=@0",
                new object[] { memoid});
            if (dtp.Rows.Count < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnRelease_Click(object sender, EventArgs e)
        {
            string id = grid.GetDataRow(grid.FocusedRowIndex)["MemoID"].ToString();
            int memoID = Int32.Parse(id);
            string status1 = grid.GetDataRow(grid.FocusedRowIndex)["Status1"].ToString();
            string status2 = grid.GetDataRow(grid.FocusedRowIndex)["Status2"].ToString();
            string userList = "hendri.irawan@bangunsaranagroup.com,janitra@bangunsaranagroup.com";
            if (status1 == "NOT RELEASED")
            {
                if (getActivities(memoID))
                {
                    
                        
                        
                        DB.Insert("UPDATE IT..Programmer_Memo SET Status = 1,Status2=3, ReleasedRealDateTime = SYSDATETIME(), EditId = @0, EditDateTime = SYSDATETIME() WHERE MemoId = @1",
                            new object[] {  (String)Session["Username"].ToString().ToUpper(), memoID });
                    
                    if (userList != "")
                    {
                        string mailBody = "Memo dengan id : " + memoID + " telah direlease oleh "+ (String)Session["Username"].ToString().ToUpper();
                        SendEmailRelease(userList, mailBody);
                    }

                    LoadData();
                        LoadMyData();
             
                  
                }
                else
                {
                    DB.Insert("UPDATE IT..Programmer_Memo SET Status = 1,Status2=3, ReleasedRealDateTime = SYSDATETIME(), EditId = @0, EditDateTime = SYSDATETIME() WHERE MemoId = @1",
                            new object[] { (String)Session["Username"].ToString().ToUpper(), memoID });

                    if (userList != "")
                    {
                        string mailBody = "Memo dengan id : " + memoID + " telah direlease oleh " + (String)Session["Username"].ToString().ToUpper();
                        SendEmailRelease(userList, mailBody);
                    }

                    LoadData();
                    LoadMyData();
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selected Memo Already Released !!')", true);
            }
        }

        protected void btnTake_Click(object sender, EventArgs e)
        {
            DateTime checkdate = (DateTime)grid.GetDataRow(grid.FocusedRowIndex)["ReleasedTargetDateTime"];

            DateTime conditionvalue = new DateTime(1900, 1, 1);
            string msg = "Selected memo does not have a realease date yet, Please Contact your administrator!";
            if (checkdate == conditionvalue)
            {
                Dialogs.ShowMessageBoxClients(msg);
            }
            else
            {
               
                    string id = grid.GetDataRow(grid.FocusedRowIndex)["MemoID"].ToString();
                    int memoID = Int32.Parse(id);
                    DB.Insert("UPDATE IT..Programmer_Memo SET UserCode=@0,Status2=1 WHERE MemoID=@1",
                        new object[] { (String)Session["Username"].ToString().ToUpper(), memoID });

                    LoadData();
                    LoadMyData();
                
            }
            
        }

        protected void btnMyMemo_Click(object sender, EventArgs e)
        {
            
            grid2.Visible = true;
            grid.Visible = false;
            LoadData();
            LoadMyData();
        }
   
    
        
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string fileId = grid.GetDataRow(grid.FocusedRowIndex)["MemoID"].ToString();
            
            string str = String.Empty;
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IT;Integrated Security=True");

            command = new SqlCommand();
            command.CommandText = "SELECT * FROM IT..Programmer_Memo WHERE MemoID=" + fileId + "";
            command.Connection = con;
            if (con.State == ConnectionState.Closed) con.Open();

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                if (!reader.IsDBNull(reader.GetOrdinal("FileName")))
                    str = reader.GetString(reader.GetOrdinal("FileName"));

                if (!reader.IsDBNull(reader.GetOrdinal("FileName")))
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/octet-stream";
             //       Response.ContentType = reader.GetString(reader.GetOrdinal("FileExtension"));
                    Response.AddHeader("content-disposition", "attachment;FileName=" + str);
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite((byte[])reader["Data"]);
                    Response.Flush();
                    Response.End();

                }
            }
            con.Close();
            con.Dispose();


        }

        protected void ProjectIDlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ModuleIDlist.Items.Clear();
                
                DataTable dt2 = new DataTable();
                string lognow = (String)Session["Username"];
                dt2 = DB.SelectArrayDataTable("SELECT ModuleID,ModuleName FROM IT..Programmer_Module WHERE IsActive = 1 AND ProjectID=@0 order by ModuleName",
                new object[] { Int32.Parse(ProjectIDlist.SelectedValue.ToString()) });
                DataRow dr2 = dt2.Rows[0];
                ModuleIDlist.DataSource = dt2;
                ModuleIDlist.DataTextField = "ModuleName";
                ModuleIDlist.DataValueField = "ModuleID";
                ModuleIDlist.DataBind();
                ModuleIDlist.Items.Insert(0, new ListItem("Select Module", ""));
                ModuleIDlist.SelectedIndex = 0;
            }
            catch (Exception es)
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible) { Panel1.Visible = false;btnAddMemo.Text = "Add Memo"; }
            else { Panel1.Visible = true; btnAddMemo.Text = "Hide Form"; }
            

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string id = grid.GetDataRow(grid.FocusedRowIndex)["MemoID"].ToString();
            Response.Redirect("/Pages/EditMemo.aspx?memoid=" + id);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = grid.GetDataRow(grid.FocusedRowIndex)["MemoID"].ToString();
            int memoID = Int32.Parse(id);
            
            string userList = "hendri.irawan@bangunsaranagroup.com,janitra@bangunsaranagroup.com";
                if (!getActivities(memoID))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('There is an activity for the selected Memo!!')", true);

                }
                else
                {
                    DB.Insert("DELETE FROM IT..Programmer_Memo WHERE MemoId = @0",
                            new object[] { memoID });

                    if (userList != "")
                    {
                        //string mailBody = "Memo dengan id : " + memoID + " telah dihapus oleh " + (String)Session["Username"].ToString().ToUpper();
                        //SendEmailRelease(userList, mailBody);
                    }

                    LoadData();
                    LoadMyData();
                }
            }
       
        
    }
}