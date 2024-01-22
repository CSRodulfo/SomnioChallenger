using Application.MainModule;
using Application.MainModule.Administration.RolesManagement;
using Domain.Resources.Libraries.PagedData;
using Presentation.MVC.Areas.Administration.Models;
using Presentation.MVC.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation.MVC.Controllers
{
    public class HomeController : BaseController
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }

  
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult SearchSomnio(string sidx, string sord, int page, int rows, string strategyFilter)
        {
            try
            {
                IServiceSomnio serviceSomnio = ManagerService.GetService<IServiceSomnio>();
                PagedDataParameters pagedParameters = new PagedDataParameters(sidx, sord, page, rows);
                PagedDataResult<DTOSomnioTable> result = serviceSomnio.GetSomnioBy(pagedParameters, strategyFilter);

                int total = result.TotalCount;

                if (total == 0)
                    return this.PartialViewJson(new JsonMenssage { Menssage = Default.Resources.searchMessage });

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
                                       r.Id.ToString(),
                                       r.Quantity.ToString(),
                                       r.TotalCost.ToString(),
                                       r.Date.ToString("d/MMMM/yyyy").Replace("/", " de ")
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

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult PartialAbout()
        {
            ViewBag.Message = "Your app description page.";
            return PartialView("Temporal");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AboutErrorResponse()
        {
            return Json(new JsonResponse(false, "Mensaje de error de prueba."));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AboutSuccessResponse()
        {
            return Json(new JsonResponse(true, "Mensaje de éxito de prueba."));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AboutSuccessNoMessage()
        {
            return Json(new JsonResponse(true));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AboutErrorNoMessage()
        {
            return Json(new JsonResponse(false));
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult AboutJsonMessage()
        {
            return this.PartialViewJson(new JsonMenssage { Menssage = "Error jsonMenssage" });
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Temporal()
        {
            ViewBag.Message = "Your temp page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Roles()
        {
            ViewBag.Message = "Your roles page.";
            return View();
        }

        [AllowAnonymous]
        public ActionResult Plugins()
        {
            ViewBag.Message = "Your roles page.";
            return View();
        }
    }
}
