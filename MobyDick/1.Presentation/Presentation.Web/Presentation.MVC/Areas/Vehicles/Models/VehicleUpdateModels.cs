using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.MainModule.Services;

namespace Presentation.MVC.Models
{
    public class VehicleUpdateModels
    {
        public DTOVehicleForUpdate Vehicle { get; set; }
        public List<DTOMake> makes { get; set; }
        public List<DTOSafety> safeties { get; set; }
        public string ExistImage { get; set; }
        public string ImageCode { get; set; }
    }
}