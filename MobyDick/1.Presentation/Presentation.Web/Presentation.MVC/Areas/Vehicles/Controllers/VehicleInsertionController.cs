using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.MainModule.Services;
using Presentation.MVC.Controllers;
using Presentation.MVC.Common;
using Presentation.MVC.Models;

namespace Presentation.MVC.Controllers
{
    public class VehicleInsertionController : Controller
    {
        //
        // GET: /Vehicles/

        //public ActionResult Index()
        //{
        //    return View();
        //}
        

        public ActionResult InsertVehicle()
        {

            VehicleInsertModels viewModel = new VehicleInsertModels();
            viewModel.makes = LoadMakes();
            viewModel.safeties = LoadSafeties();

            return View(viewModel);
        }        

        [HttpPost]
        public ActionResult InsertVehicle(VehicleInsertModels view, HttpPostedFileBase theFile)
        {           
            
            if (view.ExistImage != null)
            {
                view.Vehicle.Image = GetImage(theFile);                
            }
            
            try
            {                                               
                IServiceVehicle service = ManagerService.GetService<IServiceVehicle>();
                service.Add(view.Vehicle);
            }
            catch (Exception ex)
            {                
                throw ex;
            }

            return RedirectToAction("InsertVehicle");
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
