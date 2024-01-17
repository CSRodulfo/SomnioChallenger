using Application.MainModule.Administration.RolesManagement;
using Application.MainModule.Administration.RolesManagement.DTO;
using Presentation.MVC.Areas.Administration.Models;
using Presentation.MVC.Common;
using Presentation.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Presentation.MVC.Areas.Administration.Controllers
{
    public class MenuesController : BaseController
    {
        //
        // GET: /Administration/Menues/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            List<MenuesDataTree> dataTree = GetDataTree(LoadDTOMenuesForList());
            MenuesListModel model = new MenuesListModel();
            model.DataTree = dataTree;

            IServiceUsers uService = ManagerService.GetService<IServiceUsers>();
            model.IsUserDeveloper = uService.IsDeveloper(User.Identity.Name);

            return View(model);
        }

        public ActionResult Insert()
        {
            MenuInsertModels model = new MenuInsertModels();

            model.AllMenues = LoadDTOMenues();

            model.AllMenues.Insert(0, new DTOMenu { IDMenu = 0, Name = "" });

            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(DTOMenuesForInsert dto)
        {
            try
            {
                IServiceMenues service = ManagerService.GetService<IServiceMenues>();

                service.Insert(dto);
            }
            catch (Exception ex)
            {
                return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult TreeEdit(List<MenuesDataTree> treeData)
        {
            try
            {
                int orden = 0;

                foreach (MenuesDataTree TreeNode in treeData)
                {
                    UpdateMenuItemFromTreeData(TreeNode, ref orden);
                }

                return Json(true);
            }
            catch (Exception ex)
            {
                return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }
        }

        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("List");
            else
            {
                var service = ManagerService.GetService<IServiceMenues>();
                var model = AutoMapper.Mapper.Map<MenuEditModels>(service.GetDTOMenuesForEditById(id));

                if (model != null)
                {
                    List<DTOMenu> allMenues = LoadDTOMenues();

                    DTOMenu currentMenu = allMenues.Single(m => m.IDMenu == id);

                    allMenues.Remove(currentMenu);
                    allMenues.Insert(0, new DTOMenu { IDMenu = 0, Name = "" });

                    model.AllMenues = allMenues;

                    return View("Edit", model);
                }
                else
                    return RedirectToAction("List");
            }
        }

        [HttpPost]
        public ActionResult Edit(DTOMenuesForEdit dto)
        {
            IServiceMenues menuService = ManagerService.GetService<IServiceMenues>();

            menuService.AdvEdit(dto);

            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                IServiceMenues menuService = ManagerService.GetService<IServiceMenues>();
                menuService.Delete(id);
                return Json(true);
            }
            catch (Exception ex)
            {
                return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }
        }

        private void UpdateMenuItemFromTreeData(MenuesDataTree TreeNode, ref int orden)
        {
            DTOMenuesForTreeEdit dto = TreeToDTO(TreeNode, null, ref orden);

            IServiceMenues menuService = ManagerService.GetService<IServiceMenues>();
            menuService.Edit(dto);
        }

        private DTOMenuesForTreeEdit TreeToDTO(MenuesDataTree tree, int? IDParent, ref int orden)
        {
            DTOMenuesForTreeEdit rv = new DTOMenuesForTreeEdit();
            rv.IDMenu = tree.key;
            rv.Name = tree.title;
            rv.IDParent = IDParent;
            rv.Orden = orden;
            orden++;
            rv.SubMenues = new List<DTOMenuesForTreeEdit>();
            if (tree.children != null && tree.children.Count > 0)
            {
                foreach (MenuesDataTree child in tree.children)
                {
                    rv.SubMenues.Add(TreeToDTO(child, rv.IDMenu, ref orden));
                }
            }
            return rv;
        }

        private List<MenuesDataTree> GetDataTree(List<DTOMenuForList> Menues)
        {
            return GetChildrenDataTree(Menues);
        }

        private List<MenuesDataTree> GetChildrenDataTree(List<DTOMenuForList> Menues)
        {
            List<MenuesDataTree> childrenResult = new List<MenuesDataTree>();
            foreach (DTOMenuForList menu in Menues)
            {
                childrenResult.Add(GetChildDataTree(menu));
            }
            return childrenResult;
        }

        private MenuesDataTree GetChildDataTree(DTOMenuForList parentMenu)
        {
            MenuesDataTree menuNode = new MenuesDataTree();

            menuNode.key = parentMenu.IDMenu;
            menuNode.title = parentMenu.Name;
            menuNode.menuDescription = parentMenu.Description;
            menuNode.assignedRoles = parentMenu.AssignedRoles;

            if (parentMenu.SubMenues != null && parentMenu.SubMenues.Count > 0)
                menuNode.children = GetChildrenDataTree(parentMenu.SubMenues);

            return menuNode;
        }

        private List<DTOMenu> LoadDTOMenues()
        {
            IServiceMenues service = ManagerService.GetService<IServiceMenues>();
            return service.GetAll();
        }

        private List<DTOMenuForList> LoadDTOMenuesForList()
        {
            IServiceMenues service = ManagerService.GetService<IServiceMenues>();
            return service.GetAllMenuDTOForList();
        }
    }
}