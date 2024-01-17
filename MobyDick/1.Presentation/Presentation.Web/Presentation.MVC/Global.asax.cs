using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Presentation.MVC.App_Start;
using System.Threading;
using System.Globalization;
using System;
using Presentation.MVC.Controllers;
using System.Web;
using System.Web.Security;
using EFMVC.Web.Mappers;
using Infrastructure.Cross.Logging;
using Presentation.MVC.Common;
using System.Threading.Tasks;

namespace Presentation
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Microsoft.AspNet.SignalR.HubConfiguration hc = new Microsoft.AspNet.SignalR.HubConfiguration();
            //hc.EnableDetailedErrors = true;
            //RouteTable.Routes.MapHubs(hc);

            string nlogPath = Server.MapPath("nlog-web.log");
            //InternalLogger.LogFile = nlogPath;
            //InternalLogger.LogLevel = NLog.LogLevel.Trace;


            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperMVCConfiguration.Configure();
        }

        public void Application_BeginRequest(object src, EventArgs e)
        {

        }

        protected void Application_EndRequest()
        {
            if (Context.Response.StatusCode == 404)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    Response.Clear();

                    var rd = new RouteData();
                    rd.Values["controller"] = "Errors";
                    rd.Values["action"] = "Error404";

                    IController c = new ErrorsController();
                    c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
                }
                else
                {
                    string redirectAfterLogin = HttpUtility.UrlEncode(Context.Request.RawUrl);
                    string loginUrl = FormsAuthentication.LoginUrl;

                    Context.Response.Redirect(loginUrl + "?ReturnUrl=" + redirectAfterLogin, true);
                }
            }
            if (Context.Response.StatusCode == 500)
            {
                if (Context.User.Identity.IsAuthenticated)
                {
                    Response.Clear();

                    var rd = new RouteData();
                    rd.Values["controller"] = "Errors";
                    rd.Values["action"] = "Error500";

                    IController c = new ErrorsController();
                    c.Execute(new RequestContext(new HttpContextWrapper(Context), rd));
                }
                else
                {
                    string redirectAfterLogin = HttpUtility.UrlEncode(Context.Request.RawUrl);
                    string loginUrl = FormsAuthentication.LoginUrl;

                    Context.Response.Redirect(loginUrl + "?ReturnUrl=" + redirectAfterLogin, true);
                }
            }
        }

        protected void Application_Error()
        {

            /// LEER!!! http://www.codeproject.com/Articles/422572/Exception-Handling-in-ASP-NET-MVC
            Exception lastException = Server.GetLastError();
            ManagerService.Logging().Fatal(lastException);
        }
    }
}