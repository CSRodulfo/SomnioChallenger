using Application.MainModule.Administration.Authentication;
using Application.MainModule.Administration.RolesManagement;
using Domain.Resources;
using Domain.Resources.Libraries.PagedData;
using Presentation.MVC.Areas.Administration.Models;
using Presentation.MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Presentation.MVC.Areas.Administration.Controllers
{
    public class RolesController : BaseController
    {
        //
        // GET: /Administration/Roles/
        ISecurityRoles roleService = ManagerService.GetService<ISecurityRoles>();
        #region Roles
        public ActionResult Index()
        {
            ManageRolesViewModel model = new ManageRolesViewModel();
            model.Roles = new SelectList(roleService.GetAllRoles());
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult CreateRole()
        {
            return View(new RoleViewModel());
        }

        [HttpPost]
        public virtual ActionResult CreateRole(string roleName)
        {
            JsonMenssage response = new JsonMenssage();

            if (string.IsNullOrEmpty(roleName))
            {
                //response.Success = false;
                response.Menssage = "You must enter a role name.";

                return PartialView(response);
            }

            try
            {
                roleService.CreateRole(roleName);

                if (Request.IsAjaxRequest())
                {
                    //response.Success = true;
                    response.Menssage = "Role created successfully!";

                    return this.PartialViewJson(response);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (Request.IsAjaxRequest())
                {
                    //response.Success = false;
                    response.Menssage = ex.Message;

                    return PartialView(response);
                }

                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// This is an Ajax method that populates the 
        /// Roles drop down list.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllRoles()
        {
            var list = roleService.GetAllRoles();

            List<SelectObject> selectList = new List<SelectObject>();

            foreach (var item in list)
            {
                selectList.Add(new SelectObject() { caption = item, value = item });
            }

            return Json(selectList, JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region Asignacion Menues a Roles

        public ActionResult List()
        {
            return View("List");
        }

        [HttpPost]
        public ActionResult Edit(DTORoleForList dtoRole)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dtoRole.RoleName))
                {

                    return Json(new JsonResponse(false, MBAdministration.Roles.Resources.warningRoleMessage));
                }
                IServiceRolesManagement service = ManagerService.GetService<IServiceRolesManagement>();
                service.Update(dtoRole);
            }
            catch (Exception ex)
            {
              
                return Json(new JsonResponse(false, ex.Message));
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Insert(DTORoleForList dtoRole)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dtoRole.RoleName))
                {
                    
                    return Json(new JsonResponse(false, MBAdministration.Roles.Resources.warningRoleMessage));
                }
                IServiceRolesManagement service = ManagerService.GetService<IServiceRolesManagement>();
                service.Add(dtoRole);
            }
            catch (Exception ex)
            {
            
                return Json(new JsonResponse(false, ex.Message));
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult AssignMenues(AsignacionMenuesModels data)
        {
            int roleId = data.rol.RoleId;

            List<int> selectedKeys = new JavaScriptSerializer().Deserialize<List<int>>(data.selectedKeys);

            IServiceRolesManagement roleService = ManagerService.GetService<IServiceRolesManagement>();
            roleService.SaveRoleWithMenues(roleId, selectedKeys);

            return RedirectToAction("List");
        }

        public ActionResult AssignMenues(int RoleId = 0)
        {
            if (RoleId != 0)
            {
                List<DTOMenuesForRole> AllMenues = GetAllParentMenues();
                DTORoleForMenues role = GetRolById(RoleId);

                AsignacionMenuesModels model = new AsignacionMenuesModels
                {
                    rol = role,
                    menues = AllMenues,
                    dataTree = GetDataTree(role, AllMenues)
                };

                return View(model);
            }
            else
                return RedirectToAction("List", "Roles");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                IServiceRolesManagement service = ManagerService.GetService<IServiceRolesManagement>();
                service.Delete(id);

                return Json(true);
            }
            catch (Exception ex)
            {
                return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }
        }

        public ActionResult LoadRolesForList(string sidx, string sord, int page, int rows)
        {
            return SearchRolesForList(sidx, sord, page, rows, "");
        }

        public ActionResult SearchRolesForList(string sidx, string sord, int page, int rows, string roleNameFilter)
        {
            try
            {
                IServiceRolesManagement service = ManagerService.GetService<IServiceRolesManagement>();

                PagedDataParameters pagedParameters = new PagedDataParameters(sidx, sord, page, rows);
                PagedDataResult<DTORoleForList> result = service.GetRolesByPageAndName(pagedParameters, roleNameFilter);

                int total = result.TotalCount;

                if (total == 0)
                    return this.PartialViewJson(new JsonMenssage {  Menssage = Default.Resources.searchMessage });

                int totalPages = (int)Math.Ceiling((decimal)total / (decimal)rows);
                var data = new
                {
                    total = totalPages,
                    page = page,
                    records = total,
                    rows = from r in result.Results
                           select new
                           {
                               cell = new string[]
                                   {
                                       r.RoleId.ToString(),
                                       r.AssignationState==Define.RoleAssignationState.Assigned?"../../Content/css/images/green-light.png":"../../Content/css/images/red-light.png",
                                       r.RoleName,
                                       "<img class='" + ( r.EnableViewDeleted=="on" ? "item-disabled-available" : "item-disabled-not-available") + "' text='"+ r.EnableViewDeleted.ToString()+ "' value='"+ r.EnableViewDeleted.ToString()+"'></img>"
                                   }
                           }
                };

                return Json(data);
            }
            catch (Exception ex)
            {
                return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }
        }

        private DTORoleForMenues GetRolById(int RoleId)
        {
            IServiceRolesManagement service = ManagerService.GetService<IServiceRolesManagement>();
            return service.GetRoleForMenuesById(RoleId);
        }

        private List<DTOMenuesForRole> GetAllParentMenues()
        {
            IServiceRolesManagement service = ManagerService.GetService<IServiceRolesManagement>();
            return service.GetAllMenuesForRoles();
        }

        private List<AsignacionMenuesDataTree> GetDataTree(DTORoleForMenues Role, List<DTOMenuesForRole> Menues)
        {
            return GetChildrenDataTree(Role, Menues);
        }

        private List<AsignacionMenuesDataTree> GetChildrenDataTree(DTORoleForMenues Role, List<DTOMenuesForRole> Menues)
        {
            List<AsignacionMenuesDataTree> childrenResult = new List<AsignacionMenuesDataTree>();
            foreach (DTOMenuesForRole menu in Menues)
            {
                childrenResult.Add(GetChildDataTree(Role, menu));
            }
            return childrenResult;
        }

        private AsignacionMenuesDataTree GetChildDataTree(DTORoleForMenues Role, DTOMenuesForRole parentMenu)
        {
            AsignacionMenuesDataTree menuNode = new AsignacionMenuesDataTree();

            menuNode.key = parentMenu.IDMenu;
            menuNode.title = parentMenu.Name;
            menuNode.menuDescription = parentMenu.Description;
            menuNode.selected = Role.Menues.Any(m => m.IDMenu == parentMenu.IDMenu);

            if (parentMenu.SubMenues != null && parentMenu.SubMenues.Count > 0)
                menuNode.children = GetChildrenDataTree(Role, parentMenu.SubMenues);

            return menuNode;
        }

        #endregion
    }

    public class SelectObject
    {
        public string value { get; set; }
        public string caption { get; set; }
    }
}