using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.MainModule.Services;
using Presentation.MVC.Common;
using Presentation.MVC.Models;

namespace Presentation.MVC.Controllers
{
    public class VehicleEditController : Controller
    {
        //
        // GET: /VehicleEdit/

        public ActionResult VehicleEdit(int id = 0)
        {
            if (id != 0)
            {
                VehicleUpdateModels viewModel = new VehicleUpdateModels();
                viewModel.makes = LoadMakes();
                viewModel.safeties = LoadSafeties();
                viewModel.Vehicle = GetVehicle(id);
                if (viewModel.Vehicle.Images != null)
                {
                    if (viewModel.Vehicle.Images.Image != null)
                    {
                        viewModel.ExistImage = "true";
                        viewModel.ImageCode = "data:image/png;base64," + Convert.ToBase64String(viewModel.Vehicle.Images.Image);
                    }
                    else
                    {
                        viewModel.ExistImage = "false";
                        viewModel.ImageCode = "../Content/css/Images/default_car.jpg";
                    }
                }
                return View(viewModel);
            }
            else
                return RedirectToAction("../Home");
        }

        private DTOVehicleForUpdate GetVehicle(int id)
        {
            IServiceVehicle service = ManagerService.GetService<IServiceVehicle>();
            return service.GetVehicleByID(id);
        }


        //
        // GET: /VehicleEdit/Details/5

        [HttpPost]
        public ActionResult EditVehicle(VehicleUpdateModels view, HttpPostedFileBase theFile)
        {
            switch (view.ExistImage)
            {
                case "false":
                    view.Vehicle.Images = new DTOImagesForUpdate { Image = null };
                    break;
                case "true":
                    break;
                default:
                    view.Vehicle.Images = new DTOImagesForUpdate { Image = GetImage(theFile) };
                    break;
            }

            try
            {
                IServiceVehicle service = ManagerService.GetService<IServiceVehicle>();
                service.Edit(view.Vehicle);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("../Home");
        }

        private byte[] GetImage(HttpPostedFileBase theFile)
        {
            using (Image img = Image.FromStream(theFile.InputStream))
            {
                byte[] imgData = new byte[theFile.InputStream.Length];

                BinaryReader reader = new BinaryReader(theFile.InputStream);
                theFile.InputStream.Seek(0, SeekOrigin.Begin);

                imgData = reader.ReadBytes((int)theFile.InputStream.Length);
                return imgData;
            }
        }


        private List<DTOMake> LoadMakes()
        {
            IServiceVehicle service = ManagerService.GetService<IServiceVehicle>();
            return service.GetAllMakesDTO();
        }

        private List<DTOSafety> LoadSafeties()
        {
            IServiceVehicle service = ManagerService.GetService<IServiceVehicle>();
            return service.GetAllSafeties();
        }
    }
}
