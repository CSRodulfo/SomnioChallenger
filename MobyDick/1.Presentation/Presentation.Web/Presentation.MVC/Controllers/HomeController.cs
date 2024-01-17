using Presentation.MVC.Common;
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
        public JsonResult Line()
        {
            var data = new{
                    labels = new string[] {"label 1","label 2","label 3","label 4"},
                    datasets = new[] {
                        new {
                                label= "My First dataset",
                                fillColor= "rgba(220,220,220,0.2)",
                                strokeColor= "rgba(220,220,220,1)",
                                pointColor= "rgba(220,220,220,1)",
                                pointStrokeColor= "#fff",
                                pointHighlightFill= "#fff",
                                pointHighlightStroke= "rgba(220,220,220,1)",
                                data= new int[] {70, 40, 30,60}
                            }
                    }                 
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult Pie()
        {
            int i = 0;

            var data = new[]{
                new {
                    label = "primero",
                    value = 20,
                    color = new string[] { "#F7464A", "#46BFBD", "#FDB45C", "#6CC195", "#A779C6" }[i],
                    highlight = new string[] { "#FF5A5E", "#5AD3D1", "#FFC870", "#98E2BC", "#C79EE2" }[i++],
                    },
                    new {
                    label = "segundo",
                    value = 80,
                    color = new string[] { "#F7464A", "#46BFBD", "#FDB45C", "#6CC195", "#A779C6" }[i],
                    highlight = new string[] { "#FF5A5E", "#5AD3D1", "#FFC870", "#98E2BC", "#C79EE2" }[i++],
                    }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        
        [AllowAnonymous]
        public JsonResult PolarArea()
        {
            int i = 0;

            var data = new[]{
                new {
                    label = "primero",
                    value = 20,
                    color = new string[] { "#F7464A", "#46BFBD", "#FDB45C", "#6CC195", "#A779C6" }[i],
                    highlight = new string[] { "#FF5A5E", "#5AD3D1", "#FFC870", "#98E2BC", "#C79EE2" }[i++],
                    },
                    new {
                    label = "segundo",
                    value = 80,
                    color = new string[] { "#F7464A", "#46BFBD", "#FDB45C", "#6CC195", "#A779C6" }[i],
                    highlight = new string[] { "#FF5A5E", "#5AD3D1", "#FFC870", "#98E2BC", "#C79EE2" }[i++],
                    }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult Doughnut()
        {
            int i = 0;

            var data = new[]{
                new {
                    label = "primero",
                    value = 20,
                    color = new string[] { "#F7464A", "#46BFBD", "#FDB45C", "#6CC195", "#A779C6" }[i],
                    highlight = new string[] { "#FF5A5E", "#5AD3D1", "#FFC870", "#98E2BC", "#C79EE2" }[i++],
                    },
                    new {
                    label = "segundo",
                    value = 80,
                    color = new string[] { "#F7464A", "#46BFBD", "#FDB45C", "#6CC195", "#A779C6" }[i],
                    highlight = new string[] { "#FF5A5E", "#5AD3D1", "#FFC870", "#98E2BC", "#C79EE2" }[i++],
                    }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult Bar()
        {
            var data = new
            {
                labels = new string[] { "label 1", "label 2", "label 3", "label 4" },
                datasets = new[] {
                        new {
                                label= "My First dataset",
                                fillColor= "rgba(220,220,220,0.2)",
                                strokeColor= "rgba(220,220,220,1)",
                                pointColor= "rgba(220,220,220,1)",
                                pointStrokeColor= "#fff",
                                pointHighlightFill= "#fff",
                                pointHighlightStroke= "rgba(220,220,220,1)",
                                data= new int[] {70, 40, 30,60}
                            }
                    }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public JsonResult Radar()
        {
            var data = new
            {
                labels = new string[] { "label 1", "label 2", "label 3", "label 4" },
                datasets = new[] {
                        new {
                                label= "My First dataset",
                                fillColor= "rgba(220,220,220,0.2)",
                                strokeColor= "rgba(220,220,220,1)",
                                pointColor= "rgba(220,220,220,1)",
                                pointStrokeColor= "#fff",
                                pointHighlightFill= "#fff",
                                pointHighlightStroke= "rgba(220,220,220,1)",
                                data= new int[] {70, 40, 30,60}
                            },
                            new {
                                label= "My second dataset",
                                fillColor= "rgba(220,220,220,0.2)",
                                strokeColor= "rgba(220,220,220,1)",
                                pointColor= "rgba(220,220,220,1)",
                                pointStrokeColor= "#fff",
                                pointHighlightFill= "#fff",
                                pointHighlightStroke= "rgba(220,220,220,1)",
                                data= new int[] {10, 50, 20,124}
                            }
                    }
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
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
