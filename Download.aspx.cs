using Activity.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Activity.Pages
{
    public partial class Download : System.Web.UI.Page
    {
        private static SqlConnection con;
        private static SqlCommand command;

        protected void Page_Load(object sender, EventArgs e)
        {
            string fileId = Request.QueryString["fileId"].ToString();

            string str = String.Empty;
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IT;Integrated Security=True");

            command = new SqlCommand();
            command.CommandText = "SELECT * FROM IT..Technical_MasterDocument WHERE DocumentID = " + fileId + "";
            command.Connection = con;
            if (con.State == ConnectionState.Closed) con.Open();

            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                if (!reader.IsDBNull(reader.GetOrdinal("DocumentName")))
                    str = reader.GetString(reader.GetOrdinal("DocumentName"));

                if (!reader.IsDBNull(reader.GetOrdinal("FileData")))
                {                    
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = reader.GetString(reader.GetOrdinal("ContentType"));
                    Response.AddHeader("content-disposition", "attachment;documentname=" + str);
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite((byte[])reader["FileData"]);
                    Response.Flush();
                    Response.End();

                }
            }
            con.Close();
            con.Dispose();

            Response.Redirect("~/Pages/Files.aspx");
        }        
    }
}