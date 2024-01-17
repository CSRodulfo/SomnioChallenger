using Application.MainModule.Administration.RolesManagement;
using Application.MainModule.Administration.RolesManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Common.Attributes
{
    public class RoleAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.ActionDescriptor.IsDefined
            (typeof(AllowAnonymousAttribute), true) &&
            !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined
            (typeof(AllowAnonymousAttribute), true))
            {
                string controller = filterContext.RouteData.GetRequiredString("controller");
                string action = filterContext.RouteData.GetRequiredString("action");
                string area = Convert.ToString(filterContext.RouteData.DataTokens["area"]);
                IServiceMenues menuesService = ManagerService.GetService<IServiceMenues>();

                if (menuesService.RequiresAuthorization(controller, area))
                {
                    if (!IsAuthorized(controller, action, area))
                    {
                        filterContext.Result = new HttpStatusCodeResult(404);
                    }
                }
            }
        }

        private bool IsAuthorized(string controller, string action, string area)
        {
            string[] roles = System.Web.Security.Roles.GetRolesForUser();

            IServiceRolesManagement service = ManagerService.GetService<IServiceRolesManagement>();

            List<DTORoleForAuthorization> RolesInDB = service.GetDTORolesForAuthorizationByString(roles);

            //Este usuario tiene un rol que contenga este controlador?
            bool isAuthorized = RolesInDB.Where
                (r => r.Menues.Where
                    (m => m.Controller == controller && (m.Area == area || string.IsNullOrEmpty(area))
                    //&& (m.Action == action)
                    )
                    //&& (m.Action == action || r.Admin == true))
                    .Any()).Any();

            return isAuthorized;
        }
    }
}