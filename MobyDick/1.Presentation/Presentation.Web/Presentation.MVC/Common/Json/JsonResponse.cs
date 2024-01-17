using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Presentation.MVC.Common
{
    /// <summary>
    /// Clase para retornar JSON de controladores a vistas.
    /// </summary>
    public class JsonResponse
    {
        private bool _success;
        private string _partialView;

        /// <summary>
        /// Retorna si la operación fue exitosa.
        /// </summary>
        public bool Success
        {
            get { return _success; }
        }
        public string PartialView
        {
            get { return _partialView; }
        }

        public JsonResponse(JsonMenssage data)
            : this(data.Success, data.Menssage)
        { }

        /// <summary>
        /// Crea un objeto JsonResponse sin mensaje para mostrar en la vista.
        /// </summary>
        /// <param name="success">Setea si la operación fue exitosa</param>
        public JsonResponse(bool success)
            : this(success, "")
        { }

        /// <summary>
        /// Crea un objeto JsonResponse con mensaje para mostrar en la vista.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="partialView"></param>
        public JsonResponse(bool success, string partialView)
        {
            _success = success;
            _partialView = partialView;
        }
    }
}