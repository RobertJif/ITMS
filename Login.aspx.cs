using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Activity.Models;
using Activity.Core;
using System.Collections;
using System.Data.SqlClient;

namespace Activity.Account
{
    public partial class Login : Page
    {
        private static string userName;
        private static string passWd;

        protected void Page_Load(object sender, EventArgs e)
        {

            string uname = (String)Session["Username"];
            if (!String.IsNullOrEmpty(uname))
            {
                Response.Redirect("/Pages/Index.aspx");
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (AuthLogin())
                {
                    Session["Username"] = userName;
                    Response.Redirect("~/Pages/Index.aspx");
                }
                else
                {

                }
            }
        }

        private bool AuthLogin()
        {
            userName = user.Text;
            passWd = passwd.Text;

            bool auth = false;
            ArrayList data = new ArrayList();
            try
            {
                DB.ConnectCore();
                data = DB.SelectArray("SELECT UserCode, Password, PasswordSalt FROM CM..CoreUser WHERE UserCode = @0 AND IsActive = 1", new Object[] { userName });
                DB.Disconnect();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Cannot Connect To Server");
            }

            if (data.Count == 0) auth = false;
            else
            {
                string username = data[0].ToString();
                string password = data[1].ToString();
                string passwordSalt = data[2].ToString();

                string verPass = App.GenerateHashWithSalt(passWd, passwordSalt);

                if (verPass.Equals(password)) auth = true;
                else auth = false;
            }

            return auth;
        }
    }
}