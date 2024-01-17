using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections.Generic;
using Application.MainModule.Services;
using Presentation.MVC.Models;
using System.Linq.Expressions;
using System;
using System.Collections.Specialized;
using System.Reflection;

namespace MvcHtmlHelpers
{
    public static class NameValueCollecionHelper
    {
        /// <summary>
        /// Asigna al objeto los valores de la coleccion en las propiedades correspondientes
        /// </summary>
        /// <param name="nvc"></param>
        /// <param name="obj"></param>
        public static void DataLoader(this NameValueCollection nvc, Object obj)
        {
            foreach (string kvp in nvc.AllKeys)
            {
                PropertyInfo pi = obj.GetType().GetProperty(kvp, BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                {
                    //Se quitan los duplicados
                    var values = nvc.GetValues(kvp);
                    if (values.Length > 0)
                    {
                        pi.SetValue(obj, Convert.ChangeType(values[values.Length - 1], pi.PropertyType), null);
                    }
                }
            }
        }
    }
}