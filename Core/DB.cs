using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.IO;

namespace Activity.Core
{
    class DB
    {

        #region Declaration
        private static SqlConnection con;
        private static SqlCommand command;
        private static ArrayList data;
        private static DataTable dt;
        private static object scalar;
        private static object[] dr;
        public static string backups = "1";
        public static string backupsbut = "Check All";
        public static string cctv = "1";
        public static string cctvbut = "Check All";
        public static string shut = "1";
        public static string shutbut = "Check All";
        public static string disks = "1";
        public static string diskbut = "Check All";
        public static string id1 = "";
        public static string id2 = "";
        public static string id3 = "";
        public static string id4 = "belum";
        #endregion

        #region Constructor
        #endregion

        #region HandlerMethod
        #endregion

        #region Method
        public static string getBackups()
        {
            return backups;
        }
        public static void setBackups(string backupss)
        {
            backups = backupss;
        }
        public static string getBackupsbut()
        {
            return backupsbut;
        }
        public static void setBackupsbut(string backupsss)
        {
            backupsbut = backupsss;
        }
        public static string getCCTVs()
        {
            return cctv;
        }
        public static void setCCTVs(string backupss)
        {
            cctv = backupss;
        }
        public static string getCCTVsbut()
        {
            return cctvbut;
        }
        public static void setCCTVsbut(string backupsss)
        {
            cctvbut = backupsss;
        }
        public static string getshuts()
        {
            return shut;
        }
        public static void setshuts(string backupss)
        {
            shut = backupss;
        }
        public static string getshutsbut()
        {
            return shutbut;
        }
        public static void setshutsbut(string backupsss)
        {
            shutbut = backupsss;
        }
        public static string getdisks()
        {
            return disks;
        }
        public static void setdisks(string backupss)
        {
            disks = backupss;
        }
        public static string getdisksbut()
        {
            return diskbut;
        }
        public static void setdisksbut(string backupsss)
        {
            diskbut = backupsss;
        }
        public static Boolean ConnectCore()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=IT;Integrated Security=True");
            con.Open();
            return true;

        }
        public static Boolean ConnectCoreLogin()
        {
            con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CM;Integrated Security=True;");
            con.Open();
            return true;

        }
        public static int Insert(String sqlCommand, Object[] paramValue)
        {
            ConnectCore();
            command = new SqlCommand(null, con);
            command.CommandTimeout = 90;
            command.CommandText = sqlCommand;

            if (paramValue != null)
            {
                for (int x = 0; x < paramValue.Length; x++)
                {
                    SqlParameter param = null;
                    System.Type type = paramValue[x].GetType();
                    switch (type.Name)
                    {
                        case "String":
                            param = new SqlParameter("@" + x, SqlDbType.VarChar, -1);
                            break;
                        case "DateTime":
                            param = new SqlParameter("@" + x, SqlDbType.DateTime);
                            break;
                        case "Int32":
                            param = new SqlParameter("@" + x, SqlDbType.Int, 500);
                            break;
                        case "Single":
                        case "Double":
                        case "Decimal":
                            param = new SqlParameter("@" + x, SqlDbType.Float, 500);
                            break;
                        case "Guid":
                            param = new SqlParameter("@" + x, SqlDbType.UniqueIdentifier);
                            break;
                        case "Byte[]":
                            param = new SqlParameter("@" + x, SqlDbType.VarBinary, -1);
                            break;
                        case "DBNull":
                            param = new SqlParameter("@" + x, SqlDbType.VarChar, 500);
                            param.SqlValue = "";
                            break;
                    }
                    
                    param.Value = paramValue[x];
                    command.Parameters.Add(param);

                }
            }

            command.Prepare();
            
            command.ExecuteNonQuery();
            Disconnect();

            return 1;
        }

        public static DateTime ServerDateTime()
        {
            ConnectCore();
            DateTime serverDT;
            dt = new DataTable();
            string sqlCommand = "SELECT GETDATE()";
            Object[] paramValue = new Object[] { };

            command = new SqlCommand(sqlCommand, con);
            command.CommandTimeout = 90;

            if (paramValue != null)
            {
                for (int x = 0; x < paramValue.Length; x++)
                {
                    SqlParameter param = new SqlParameter("@" + x, SqlDbType.VarChar, 500);
                    param.Value = paramValue[x];
                    command.Parameters.Add(param);
                }
            }

            SqlDataReader row = command.ExecuteReader();

            if (row.HasRows)
            {
                dt.Load(row);
            }

            serverDT = DateTime.Parse(dt.Rows[0][0].ToString());
            Disconnect();

            return serverDT;
        }
        public static ArrayList SelectArray2(String sqlCommand, Object[] paramValue)
        {
            ConnectCoreLogin();
            data = new ArrayList();
            command = new SqlCommand(sqlCommand, con);
            command.CommandTimeout = 90;

            if (paramValue != null)
            {
                for (int x = 0; x < paramValue.Length; x++)
                {
                    SqlParameter param = new SqlParameter("@" + x, SqlDbType.VarChar, 500);
                    param.Value = paramValue[x];
                    command.Parameters.Add(param);
                }
            }

            SqlDataReader row = command.ExecuteReader();

            if (row.HasRows)
            {
                while (row.Read())
                {
                    for (int i = 0; i < row.FieldCount; i++)
                    {
                        String rowData = row.GetString(i);
                        data.Add(rowData);
                    }
                }
            }

            Disconnect();
            return data;
        }
        public static ArrayList SelectArray(String sqlCommand, Object[] paramValue)
        {
            ConnectCore();
            data = new ArrayList();
            command = new SqlCommand(sqlCommand, con);
            command.CommandTimeout = 90;

            if (paramValue != null)
            {
                for (int x = 0; x < paramValue.Length; x++)
                {
                    SqlParameter param = new SqlParameter("@" + x, SqlDbType.VarChar, 500);
                    param.Value = paramValue[x];
                    command.Parameters.Add(param);
                }
            }

            SqlDataReader row = command.ExecuteReader();

            if (row.HasRows)
            {
                while (row.Read())
                {
                    for (int i = 0; i < row.FieldCount; i++)
                    {
                        String rowData = row.GetString(i);
                        data.Add(rowData);
                    }
                }
            }

            Disconnect();
            return data;
        }

        public static DataTable SelectArrayDataTable(String sqlCommand, Object[] paramValue)
        {
            ConnectCore();
            dt = new DataTable();
            command = new SqlCommand(sqlCommand, con);
            command.CommandTimeout = 90;

            if (paramValue != null)
            {
                for (int x = 0; x < paramValue.Length; x++)
                {
                    SqlParameter param = new SqlParameter("@" + x, SqlDbType.VarChar, 500);
                    param.Value = paramValue[x];
                    command.Parameters.Add(param);
                }
            }

            SqlDataReader row = command.ExecuteReader();

            if (row.HasRows)
            {
                dt.Load(row);
            }
            Disconnect();

            return dt;
        }

        public static Object SelectScalar(String sqlCommand, Object[] paramValue)
        {
            DB.ConnectCore();
            scalar = null;
            command = new SqlCommand(sqlCommand, con);
            command.CommandTimeout = 90;

            if (paramValue != null)
            {
                for (int x = 0; x < paramValue.Length; x++)
                {
                    SqlParameter param = new SqlParameter("@" + x, SqlDbType.VarChar, 500);
                    param.Value = paramValue[x];
                    command.Parameters.Add(param);
                }
            }

            SqlDataReader row = command.ExecuteReader();

            if (row.Read())
            {
                scalar = row.GetSqlValue(0);
            }
            DB.Disconnect();

            return scalar;
        }
        
        

        public static Object[] SelectRow(String sqlCommand, Object[] paramValue)
        {
            ConnectCore();
            command = new SqlCommand(sqlCommand, con);
            command.CommandTimeout = 90;

            if (paramValue != null)
            {
                for (int x = 0; x < paramValue.Length; x++)
                {
                    SqlParameter param = new SqlParameter("@" + x, SqlDbType.VarChar, 500);
                    param.Value = paramValue[x];
                    command.Parameters.Add(param);
                }
            }

            SqlDataReader row = command.ExecuteReader();

            if (row.Read())
            {
                dr = new object[row.FieldCount];
                for (int i = 0; i < row.FieldCount; i++)
                {
                    dr[i] = row.GetSqlValue(i);
                }
            }
            ConnectCore();

            return dr;
        }

        public static Boolean Disconnect()
        {
            con.Close();
            return true;
        }
        #endregion
        
       
    }
}