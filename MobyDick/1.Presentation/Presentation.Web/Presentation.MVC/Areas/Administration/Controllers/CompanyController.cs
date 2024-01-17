using Application.MainModule.Administration.CompanyManagement;
using Application.MainModule.Administration.CompanyManagement.DTO;
using MvcHtmlHelpers;
using Presentation.MVC.Common;
using Presentation.MVC.Models;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Presentation.MVC.Areas.Administration.Controllers
{
    public class CompanyController : BaseController
    {
        //
        // GET: /Administration/Company/

        public ActionResult Index()
        {
            IServiceCompany userService = ManagerService.GetService<IServiceCompany>();

            DTOCompany model = userService.GetDTOCompany();

            return View("Edit", model);
        }

        public ActionResult List()
        {
            var service = ManagerService.GetService<IServiceCompany>();
            var model = AutoMapper.Mapper.Map<CompanyModel>(service.GetDTOCompany());

            return View("Edit", model);
        }

        public FileStreamResult GetFile(int id)
        {
            IServiceCompany userService = ManagerService.GetService<IServiceCompany>();
            DTOCompany model = userService.GetDTOCompany();

            if (model.File == null)
            {
                return new FileStreamResult(new StreamReader(Server.MapPath("~/Content/Images/profilenn.png")).BaseStream, "image/png");
            }
            else
            {
                return new FileStreamResult(new MemoryStream(model.File.FileData), model.File.MimeType);
            }
        }

        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
                return RedirectToAction("List");
            else
            {
                var service = ManagerService.GetService<IServiceCompany>();
                var model = AutoMapper.Mapper.Map<CompanyModel>(service.GetDTOCompany());
                
                return View("Edit", model);
            }
        }

        [HttpPost]
        public ActionResult Edit(DTOCompany dto)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["file"];
                    var er = Request.Form["dto"];
                    dto = new DTOCompany();

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

                    IServiceCompany companyService = ManagerService.GetService<IServiceCompany>();
                    companyService.Edit(dto);
                }
            }
            catch (Exception ex)
            {
                return Json(new JsonResponse(false, MBAdministration.Company.Resources.updateCompanyMessage));
                //return this.PartialViewJson(new JsonMenssage { Menssage = ex.Message });
            }

            return Json(new JsonResponse(true, MBAdministration.Company.Resources.editCompanyMessage));
            //return RedirectToAction("List");
        }
    }
}
