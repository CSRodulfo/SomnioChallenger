using Application.MainModule.Administration.Authentication;
using Application.MainModule.Administration.FileManagement.DTO;
using Application.MainModule.Administration.RolesManagement;
using Application.MainModule.Administration.RolesManagement.DTO;
using Application.MainModule.Services;
using Domain.Resources.Libraries.PagedData;
using MvcHtmlHelpers;
using Presentation.MVC.Areas.Administration.Models;
using Presentation.MVC.Common;
using Presentation.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Presentation.MVC.Areas.Administration.Controllers
{
    public class UsersController : BaseController
    {
        //
        // GET: /Administration/Users/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            UsersList model = new UsersList();
            return View(model);

        }

        public ActionResult LoadUsers(string sidx, string sord, int page, int rows, string UserName)
        {
            try
            {
                IServiceUsers service = ManagerService.GetService<IServiceUsers>();
                PagedDataParameters pagedParameters = new PagedDataParameters(sidx == "" ? "UserId" : sidx, sord, page, rows);

                PagedDataResult<DTOUser> result = service.GetUsers(pagedParameters, UserName);

                int total = result.TotalCount;
                
                if (total == 0)
                    return this.PartialViewJson(new JsonMenssage { Menssage = Default.Resources.searchMessage });

                int totalPages = (int)Math.Ceiling((decimal)total / (decimal)rows);

                var data = new
                {
                    total = totalPages,
                    page = page,
                    records = total,
                    rows = from v in result.Results
                           select new
                           {
                               id = v.UserId,
                               cell = new string[] 
                                   {              
                                       v.UserName,
                                       string.Concat( v.FirstName, " " , v.LastName),
                                       v.Email
                                   }
                           }
                };
                //throw new NullReferenceException();
                return Json(data,JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ManagerService.Logging().Error(ex);
                return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }
        }

        [Authorize]
        public ActionResult Insert()
        {
            try
            {
                Presentation.MVC.Models.RegisterModel model = new MVC.Models.RegisterModel();
                model.Cultures = GetAllCultures();

                return View("Insert", model);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Insert(RegisterModel model)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["file"];
                    var er = Request.Form["dto"];
                    model = new RegisterModel();

                    var nvc = HttpUtility.ParseQueryString(er);
                    NameValueCollecionHelper.DataLoader(nvc, model);

                    //model.Culture = 1;
                    bool requireEmailConfirmation = false;
                    ISecurityMembership MembershipService = ManagerService.GetService<ISecurityMembership>("MVC");
                    MembershipService.CreateUserAndAccount(model.UserName, model.Password, new { FirstName = model.Nombre, LastName = model.Apellido, Email = model.Email, IdCulture = model.IdCulture }, requireConfirmationToken: requireEmailConfirmation);

                    IServiceUsers userService = ManagerService.GetService<IServiceUsers>();
                    userService.UpdatePasswordMobile(model.UserName, model.Password);

                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                        DTOFile PhotoFile = new Application.MainModule.Administration.FileManagement.DTO.DTOFile
                        {
                            Date = DateTime.Now,
                            FileData = fileBytes,
                            FileName = fileName,
                            MimeType = fileContentType
                        };

                        userService.UpdatePhoto(model.UserName, PhotoFile);
                    }

                    return Json(new JsonResponse(true, Default.Resources.insertUserMessage));
                }
                else
                    return Json(new JsonResponse(false, MBAdministration.Users.Resources.errorUserMessage));
            }
            catch (Exception ex)
            {
                if (ex.Message == "The username is already in use.")
                {
                    return Json(new JsonResponse(false, MBAdministration.Users.Resources.repeatUserMessage));
                }
                else
                    return Json(new JsonResponse(false, MBAdministration.Users.Resources.errorUserMessage));
                //return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }
        }


        public ActionResult ResetPassword(int UserId)
        {
            try
            {

                IServiceUsers userService = ManagerService.GetService<IServiceUsers>();
                DTOUserForSelect model = userService.GetDTOUserForSelectById(UserId);

                ISecurityMembership MembershipService = ManagerService.GetService<ISecurityMembership>("MVC");
                string passwordResetToken = MembershipService.GeneratePasswordResetToken(model.UserName);

                string newPassword = "123456";

                if (MembershipService.ResetPassword(passwordResetToken, newPassword))
                {
                    userService.UpdatePasswordMobile(model.UserName, newPassword);
                }

                TempData["TempMessage"] = MBAdministration.Users.Resources.PasswordMessage;
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    TempData["ErrorCompleto"] = ex.Message;
                else
                    TempData["ErrorCompleto"] = ex.Message + " " + ex.InnerException.Message;

                TempData["TempMessage"] = MBAdministration.Users.Resources.PasswordError;
                return RedirectToAction("List");
            }
        }

        public FileStreamResult GetFile(int id)
        {
            IServiceUsers userService = ManagerService.GetService<IServiceUsers>();
            DTOUserForEdit model = userService.GetDTOUserForEditById(id);

            if (model == null || model.File == null)
            {
                return new FileStreamResult(new StreamReader(Server.MapPath("~/Content/Images/profilenn.png")).BaseStream, "image/png");
            }
            else
            {
                return new FileStreamResult(new MemoryStream(model.File.FileData), model.File.MimeType);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                IServiceUsers service = ManagerService.GetService<IServiceUsers>();

                service.Delete(id);

                //service.DeleteMembership(id);

                return this.PartialViewJson(new JsonMenssage { Menssage = MBAdministration.Users.Resources.DeleteUserMessage });
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
                var service = ManagerService.GetService<IServiceUsers>();
                var model = AutoMapper.Mapper.Map<EditModel>(service.GetDTOUserForEditById(id));
                model.Cultures = service.GetDTOCulture();
                
                return View("Edit", model);
            }
        }

        [HttpPost]
        public ActionResult Edit(DTOUserForEdit dto)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["file"];
                    var er = Request.Form["dto"];
                    dto = new DTOUserForEdit();

                    var nvc = HttpUtility.ParseQueryString(er);
                    NameValueCollecionHelper.DataLoader(nvc, dto);

                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));

                        dto.File = new Application.MainModule.Administration.FileManagement.DTO.DTOFile
                        {
                            Date = DateTime.Now,
                            FileData = fileBytes,
                            FileName = fileName,
                            MimeType = fileContentType
                        };
                    }

                    IServiceUsers userService = ManagerService.GetService<IServiceUsers>();
                    userService.UpdateUserProfile(dto);
                }
            }
            catch (Exception ex)
            {
                return Json(new JsonResponse(false, MBAdministration.Users.Resources.errorEditUserMessage));
                //return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }

            return Json(new JsonResponse(true, MBAdministration.Users.Resources.EditUserMessage));
        }

        [HttpPost]
        public ActionResult AssignRoles(AsignacionRolesModels data)
        {
            int userId = data.user.UserId;

            List<int> selectedKeys = new JavaScriptSerializer().Deserialize<List<int>>(data.selectedKeys);

            IServiceUsers userService = ManagerService.GetService<IServiceUsers>();
            userService.SaveUserWithRoles(userId, selectedKeys);

            return RedirectToAction("List");
        }

        public ActionResult AssignRoles(int UserId = 0)
        {
            if (UserId != 0)
            {
                List<DTORoleForUsers> allRoles = GetAllRoles();

                DTOUserForRoles user = GetUserById(UserId);

                AsignacionRolesModels model = new AsignacionRolesModels
                {
                    user = user,
                    dataTree = GetDataTree(allRoles, user)
                };

                return View(model);

            }
            else
            {
                return RedirectToAction("List");
            }
        }

        public ActionResult Select(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("List");
            else
            {
                IServiceUsers userService = ManagerService.GetService<IServiceUsers>();

                DTOUserForSelect model = userService.GetDTOUserForSelectById(id);

                return View(model);
            }
        }

        public ActionResult Export(string sidx, string sord, string UserName)
        {
            IServiceUsers service = ManagerService.GetService<IServiceUsers>();
            try
            {
                PagedDataParametersExcel pagedParams = new PagedDataParametersExcel(sidx, sord);
                Byte[] results = service.ExportUsersList(pagedParams, UserName).GetFileExcel();

                //Si no hay archivo informo que no hubo exportación en lugar de tirar error
                if (results.Length > 0)
                    return FileExcel(results);
                else
                    TempData["TempMessage"] = Default.Resources.NonFilterMessage;

            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    TempData["ErrorCompleto"] = ex.Message;
                else
                    TempData["ErrorCompleto"] = ex.Message + " " + ex.InnerException.Message;

                TempData["TempMessage"] = Default.Resources.ErrorFilterMessage;
            }

            return RedirectToAction("List");
        }

        #region private methods

        private List<AsignacionRolesDataTree> GetDataTree(List<DTORoleForUsers> roles, DTOUserForRoles user)
        {
            List<AsignacionRolesDataTree> rv = new List<AsignacionRolesDataTree>();

            roles.ForEach(r => rv.Add(new AsignacionRolesDataTree
            {
                key = r.RoleId,
                title = r.RoleName,
                selected = user.roles.Any(ru => ru.RoleId == r.RoleId)
            }));

            return rv;
        }

        private List<DTORoleForUsers> GetAllRoles()
        {
            IServiceUsers service = ManagerService.GetService<IServiceUsers>();
            return service.GetAllDTORoleForUsers();
        }

        private DTOUserForRoles GetUserById(int id)
        {
            IServiceUsers service = ManagerService.GetService<IServiceUsers>();
            return service.GetDTOUserForRolesById(id);
        }

        private List<SelectListItem> GetAllCultures()
        {
            var dtos = ManagerService.GetService<IServiceUsers>().GetDTOCulture(); 

            return dtos.Select(d => new SelectListItem { Value = d.IdCulture.ToString(), Text = d.Description }).ToList();
        }
        #endregion

    }
}
