using Presentation.MVC.Common.Attributes;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new RoleAuthorize());
        }
    }
}