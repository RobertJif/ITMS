using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Activity.Core;

namespace Activity
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        protected static string username = "";
        protected static string version = DataModel.version;  

        protected void Page_Init(object sender, EventArgs e)
        {
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string uname = (String)Session["Username"];
            if (!String.IsNullOrEmpty(uname))
            {
                // jika sudah login
                if(uname.ToUpper() == "HENDRI IRAWAN" ||
                    uname.ToUpper() == "MULYADI")
                {
                    projects.Visible = true;
                    modules.Visible = true;
                    activity.Visible = true;
                    presentation.Visible = true;
                    modulesMemo.Visible = true;
                    masterprogrammer.Visible = true;

                    visit.Visible = true;
                    networkProblem.Visible = true;
                    itActivity.Visible = true;
                    backupActivity.Visible = true;
                    shutdownActivity.Visible = true;
                    checkdiskActivity.Visible = true;
                    cctvAcvitivy.Visible = true;
                    location.Visible = true;
                    provider.Visible = true;
                    masterServer.Visible = true;
                    masterSoftware.Visible = true;
                    files.Visible = true;
                    asset.Visible = true;
                    video.Visible = true;
                    camera.Visible = true;
                    techactivity.Visible = true;
                    programmermenu.Visible = true;
                    itMenu.Visible = true;
                    masterMenu.Visible = true;
                    evaluation.Visible = true;
                    linkMenu.Visible = true;
                }
                else if(uname.ToUpper() == "JANITRA")
                {
                    projects.Visible = true;
                    modules.Visible = true;
                    activity.Visible = true;
                    presentation.Visible = true;
                    modulesMemo.Visible = true;
                    masterprogrammer.Visible = true;
                    techactivity.Visible = false;
                    visit.Visible = false;
                    networkProblem.Visible = false;
                    itActivity.Visible = false;
                    evaluation.Visible = true;
                    location.Visible = false;
                    provider.Visible = false;
                    masterServer.Visible = false;
                    masterSoftware.Visible = false;
                    video.Visible = true;
                    camera.Visible = true;

                    programmermenu.Visible = true;
                    itMenu.Visible = false;
                    masterMenu.Visible = false;
                    linkMenu.Visible = false;
                }

                else if (uname.ToUpper() == "RIAN")
                {
                    projects.Visible = false;
                    modules.Visible = false;
                    activity.Visible = false;
                    presentation.Visible = false;
                    modulesMemo.Visible = false;
                    cctvAcvitivy.Visible = true;
                    techactivity.Visible = true;
                    visit.Visible = true;
                    networkProblem.Visible = true;
                    itActivity.Visible = true;
                    backupActivity.Visible = true;
                    shutdownActivity.Visible = true;
                    checkdiskActivity.Visible = true;

                    location.Visible = true;
                    provider.Visible = true;
                    masterServer.Visible = true;
                    masterSoftware.Visible = true;
                    files.Visible = true;
                    asset.Visible = true;
                    video.Visible = true;
                    camera.Visible = true;
                    evaluation.Visible = false;
                    programmermenu.Visible = false;
                    itMenu.Visible = true;
                    masterMenu.Visible = true;
                    linkMenu.Visible = true;
                }

                else if (uname.ToUpper() == "HARISSURYA" || 
                    uname.ToUpper() == "TONISANDRO")
                {
                    projects.Visible = false;
                    modules.Visible = false;
                    activity.Visible = false;
                    presentation.Visible = false;
                    modulesMemo.Visible = false;
                    cctvAcvitivy.Visible = true;
                    techactivity.Visible = true;
                    visit.Visible = true;
                    networkProblem.Visible = true;
                    itActivity.Visible = true;
                    backupActivity.Visible = true;
                    shutdownActivity.Visible = true;
                    checkdiskActivity.Visible = true;
                    video.Visible = false;
                    camera.Visible = false;
                    location.Visible = false;
                    provider.Visible = false;
                    masterServer.Visible = false;
                    masterSoftware.Visible = false;
                    evaluation.Visible = false;
                    programmermenu.Visible = false;
                    itMenu.Visible = true;
                    masterMenu.Visible = false;
                    linkMenu.Visible = true;
                }

                else if (uname.ToUpper() == "AGUNG" ||
                    uname.ToUpper() == "KAMAL" ||
                    uname.ToUpper() == "SANDY" ||
                    uname.ToUpper() == "SUWANDY" ||
                    uname.ToUpper() == "WIDHI")
                {
                    projects.Visible = false;
                    modules.Visible = true;
                    activity.Visible = true;
                    presentation.Visible = false;
                    modulesMemo.Visible = true;
                    evaluation.Visible = false;
                    techactivity.Visible = false;
                    visit.Visible = false;
                    networkProblem.Visible = false;
                    itActivity.Visible = false;
                    backupActivity.Visible = false;
                    video.Visible = false;
                    camera.Visible = false;
                    location.Visible = false;
                    provider.Visible = false;
                    masterServer.Visible = false;
                    masterSoftware.Visible = false;

                    programmermenu.Visible = true;
                    itMenu.Visible = false;
                    masterMenu.Visible = false;
                    linkMenu.Visible = false;

                }

                else
                {
                    projects.Visible = false;
                    modules.Visible = false;
                    activity.Visible = false;
                    presentation.Visible = false;
                    modulesMemo.Visible = false;
                    techactivity.Visible = false;

                    visit.Visible = false;
                    networkProblem.Visible = false;
                    itActivity.Visible = false;
                    backupActivity.Visible = false;

                    location.Visible = false;
                    provider.Visible = false;
                    masterServer.Visible = false;
                    masterSoftware.Visible = false;
                    files.Visible = false;
                    asset.Visible = false;
                    video.Visible = false;
                    camera.Visible = false;
                    programmermenu.Visible = false;
                    itMenu.Visible = false;
                    masterMenu.Visible = false;
             
                }

                login.Visible = false;
                logout.Visible = true;
                idx.Visible = true;
                idx.Text = "[ " + uname.ToUpper() + " ]";
            }
            else
            {
                // jika belum login
                projects.Visible = false;
                modules.Visible = false;
                activity.Visible = false;
                evaluation.Visible = false;
                visit.Visible = false;
                networkProblem.Visible = false;
                itActivity.Visible = false;
                provider.Visible = false;

                programmermenu.Visible = false;
                itMenu.Visible = false;
                masterMenu.Visible = false;
                linkMenu.Visible = false;
                login.Visible = true;
                logout.Visible = false;
                idx.Visible = false;
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }   

    }
}