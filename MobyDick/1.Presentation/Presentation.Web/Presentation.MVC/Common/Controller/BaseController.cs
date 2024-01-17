using Application.MainModule.Administration.Culture.Interfaces;
using Application.MainModule.Administration.RolesManagement;
using Presentation.MVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Common
{
    public class BaseController : Controller
    {
        private const string exportFileFormat = ".xlsx";

        /// <summary>
        /// Generacion y exportacion de archivo xls
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public FileContentResult FileExcel(byte[] data)
        {
            string name = string.Concat(this.ControllerContext.RouteData.GetRequiredString("controller"), DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
            name += exportFileFormat;
            return base.File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", name);
        }

        /// <summary>
        /// Administracion del idioma de la pagina
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = System.Web.HttpContext.Current.Request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                //Si no hay cookie y está el usuario cargado, la genero
                if (requestContext.HttpContext != null
                    && requestContext.HttpContext.User != null
                    && requestContext.HttpContext.User.Identity != null
                    && string.IsNullOrEmpty(requestContext.HttpContext.User.Identity.Name) == false)
                {
                    IServiceUsers service = ManagerService.GetService<IServiceUsers>();
                    var UserId = service.GetUserIdByUserName(requestContext.HttpContext.User.Identity.Name);

                    if (UserId > 0)
                    {
                        IServiceCulture serviceCulture = ManagerService.GetService<IServiceCulture>();
                        var cultureId = service.GetCultureIdByUserId(UserId);
                        if (cultureId > 0)
                        {
                            cultureName = serviceCulture.GetDTOCultureById(cultureId).Code;
                            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["_culture"];
                            if (cookie != null)
                                cookie.Value = cultureName;   // update cookie value
                            else
                            {
                                cookie = new HttpCookie("_culture");
                                cookie.Value = cultureName;
                                cookie.Expires = DateTime.Now.AddYears(1);
                            }
                            System.Web.HttpContext.Current.Request.Cookies.Add(cookie);
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(cultureName))
                cultureName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name.ToLowerInvariant();

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe

            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentUICulture = NewCulture(cultureName);//new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentCulture = NewCulture(cultureName); // new CultureInfo("es-AR");

            return base.BeginExecute(requestContext, callback, state);
        }


        private CultureInfo NewCulture(string param)
        {
            CultureInfo cultureInfo = new CultureInfo(param);
            cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            cultureInfo.NumberFormat.CurrencyGroupSeparator = ",";

            cultureInfo.NumberFormat.NumberDecimalDigits = 2;
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            cultureInfo.NumberFormat.NumberGroupSeparator = ",";
            return cultureInfo;

        }
    }
}