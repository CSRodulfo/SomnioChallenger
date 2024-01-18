using Application.MainModule.Administration.Authentication;
using Application.MainModule.Administration.Authorization;
using Application.MainModule.Administration.CompanyManagement;
using Application.MainModule.Administration.CompanyManagement.DTO;
using Application.MainModule.Administration.FileManagement.DTO;
using Application.MainModule.Administration.RolesManagement;
using Presentation.MVC.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Presentation.MVC.Controllers
{
    [AllowAnonymous]
    public class NavigationController : BaseController
    {
        ISecurityRoles _roleService = ManagerService.GetService<ISecurityRoles>();

        [AllowAnonymous]
        public ActionResult NavigationMenu()
        {
            IManagerMenu service = ManagerService.GetService<IManagerMenu>();

            List<string> roles = _roleService.GetRolesForUser();

            List<DTOMenuForDisplay> _menuItems = ValidateMenu(roles, service.GetParentMenuesForDisplay());

            return PartialView("Partial/_Menu", null);
        }

        [AllowAnonymous]
        public ActionResult NavigationMenuVertical()
        {
            IManagerMenu service = ManagerService.GetService<IManagerMenu>();

            List<string> roles = _roleService.GetRolesForUser();

            List<DTOMenuForDisplay> _menuItems = ValidateMenu(roles, service.GetParentMenuesForDisplay());

            return PartialView("Partial/_MenuVertical", _menuItems);
        }

        [AllowAnonymous]
        public ActionResult NavigationHeader()
        {
            return PartialView("Partial/_Header");
        }

        [AllowAnonymous]
        private List<DTOMenuForDisplay> ValidateMenu(List<string> roles, List<DTOMenuForDisplay> menuItems)
        {
            List<DTOMenuForDisplay> itemsForRoles = (from mi in menuItems
                                                     from r in mi.Roles
                                                   
                                                     select mi).Distinct().ToList();

            foreach (DTOMenuForDisplay item in itemsForRoles)
            {
                if (item.subMenues != null && item.subMenues.Count > 0)
                {
                    item.subMenues = ValidateMenu(roles, item.subMenues);
                }
            }

            return itemsForRoles;
        }

        [AllowAnonymous]
        public ActionResult GetNavigationTitle()
        {
            string action = ControllerContext.ParentActionViewContext.RouteData.Values["action"].ToString();
            string controller = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            IManagerMenu service = ManagerService.GetService<IManagerMenu>();

            List<string> roles = _roleService.GetRolesForUser();

            List<DTOMenuForDisplay> _menuItems = ValidateMenu(roles, service.GetParentMenuesForDisplay());

            DTOMenuForTitle menuTitle = new DTOMenuForTitle();

            menuTitle = service.GetMenuForTitle(controller, action);

            List<DTOMenuForTitle> titles = new List<DTOMenuForTitle>();

            titles = GetMenuTitle(titles, menuTitle);

            return PartialView("Partial/_MenuTitle", titles);
        }

        [AllowAnonymous]
        private List<DTOMenuForTitle> GetMenuTitle(List<DTOMenuForTitle> titles, DTOMenuForTitle menu)
        {
            if (menu != null)
            {
                titles.Insert(0, menu);
                GetMenuTitle(titles, menu.parentMenu);
            }
            return titles;
        }

        [AllowAnonymous]
        public FileStreamResult Logo()
       {
            IServiceCompany userCompany = ManagerService.GetService<IServiceCompany>();
            DTOCompany model = userCompany.GetDTOCompany();

            if (model.File == null)
            {
                return new FileStreamResult(new StreamReader(Server.MapPath("~/Content/Images/client-brand2.png")).BaseStream, "image/png");
            }
            else
            {
                return new FileStreamResult(new MemoryStream(model.File.FileData), model.File.MimeType);
            }
        }

        [AllowAnonymous]
        public FileStreamResult LogoUser(String userName)
        {
            if (string.IsNullOrEmpty(userName) == false)
            {
                IServiceUsers userService = ManagerService.GetService<IServiceUsers>();
                DTOFile File = userService.GetUserFileByUserName(userName); 

                if (File == null)
                {
                    return new FileStreamResult(new StreamReader(Server.MapPath("~/Content/Images/william.jpg")).BaseStream, "image/jpeg");
                }
                else
                {
                    return new FileStreamResult(new MemoryStream(File.FileData), File.MimeType);
                }
            }
            else
                return new FileStreamResult(new StreamReader(Server.MapPath("~/Content/Images/william.jpg")).BaseStream, "image/jpeg");
        }
    }
}
