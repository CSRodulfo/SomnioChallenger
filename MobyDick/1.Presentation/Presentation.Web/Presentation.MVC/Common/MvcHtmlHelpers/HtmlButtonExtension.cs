using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcHtmlHelpers
{
    public static class HtmlButtonExtension
    {
        /// <summary>
        /// Crea el botón volver, donde va al último sitio del historial
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonBack(this HtmlHelper htmlHelper)
        {
            return ActionButtonBack(htmlHelper,null);
        }

        /// <summary>
        /// Crea el botón volver, donde va al último sitio del historial
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonBack(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnBack, string.Empty, "javascript:history.go(-1)",  rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón volver, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonBack(this HtmlHelper htmlHelper, string actionName, string controller)
        {
            return ActionButtonBack(htmlHelper, actionName, controller, null);
        }

        /// <summary>
        /// Crear el botón volver, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonBack(this HtmlHelper htmlHelper, string actionName, string controller, object htmlAttributes = null)
        {
            string url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controller);
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnBack, url, string.Empty,  rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón volver a la home
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonHome(this HtmlHelper htmlHelper)
        {
            string url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action("Index", "Home", new { area = "" });
            return ActionButtonInternal(Default.Resources.BtnBack, url, string.Empty, null);
        }

        /// <summary>
        /// Crear el botón nuevo, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSearch(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnSearch, string.Empty, string.Empty, rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón nuevo, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSearch(this HtmlHelper htmlHelper, string actionName, string controller)
        {
            return ActionButtonSearch(htmlHelper, actionName, controller, null);
        }

        /// <summary>
        /// Crear el botón de busqueda, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSearch(this HtmlHelper htmlHelper, string actionName, string controller, object htmlAttributes)
        {
            string url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controller);
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnSearch, url, string.Empty, rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón de busqueda, donde recibe el js como parametro
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="Javascript">Script a utilizar</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonJsSearch(this HtmlHelper htmlHelper, string Javascript)
        {
            return ActionButtonJsSearch(htmlHelper, Javascript, null);
        }

        /// <summary>
        /// Crear el botón de busqueda, donde recibe el js como parametro
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="Javascript">Script a utilizar</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonJsSearch(this HtmlHelper htmlHelper, string Javascript, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnSearch, string.Empty, Javascript, rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón nuevo, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonNew(this HtmlHelper htmlHelper, string actionName, string controller)
        {
            return ActionButtonNew(htmlHelper, actionName, controller,null);
        }

        /// <summary>
        /// Crear el botón nuevo, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonNew(this HtmlHelper htmlHelper, string actionName, string controller, object htmlAttributes)
        {
            string url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controller);
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnNew,url, string.Empty,  rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón nuevo, ejecutando el js enviado
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="javascript"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonNew(this HtmlHelper htmlHelper, string javascript)
        {
            return ActionButtonInternal(Default.Resources.BtnNew, string.Empty, javascript, null);
        }

        /// <summary>
        /// Crear el botón nuevo, sin js ni controller, ya que se carga desde la grilla
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonNew(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnNew, string.Empty, string.Empty, rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón nuevo, sin js ni controller, ya que se carga desde la grilla
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonExport(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnExport, string.Empty, string.Empty, rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el botón exporta, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonExport(this HtmlHelper htmlHelper, string actionName, string controller)
        {
            return ActionButtonExport(htmlHelper, actionName, controller, null);
        }

        /// <summary>
        /// Crear el botón exporta, donde va a la url que se le especifica
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonExport(this HtmlHelper htmlHelper, string actionName, string controller, object htmlAttributes)
        {
            string url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controller);
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnExport, url, string.Empty,  rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el boton guardar, generandole el js necesario para que valide, muestre error y regrese al controlador.
        /// Usar el BeginForm para especificar el metodo que se utilizara para guardar. El control solo hace el postback
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Nombre de la accion a ejecutar si guarda correctamente</param>
        /// <param name="controller">Nombre del controlador a ejecutar si guarda correctamente</param>
        /// <param name="formName">Nombre del form que contiene el boton. Por defecto es "form"</param>
        /// <param name="htmlAttributes">Si se quiere agregar algun atributo extra. Por defecto es null</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonJsSave(this HtmlHelper htmlHelper, string actionName,
                string controller, string formName)
        {
            return ActionButtonJsSave(htmlHelper, actionName, controller, formName,null);
        }

        /// <summary>
        /// Crear el boton guardar, generandole el js necesario para que valide, muestre error y regrese al controlador.
        /// Usar el BeginForm para especificar el metodo que se utilizara para guardar. El control solo hace el postback
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Nombre de la accion a ejecutar si guarda correctamente</param>
        /// <param name="controller">Nombre del controlador a ejecutar si guarda correctamente</param>
        /// <param name="formName">Nombre del form que contiene el boton. Por defecto es "form"</param>
        /// <param name="htmlAttributes">Si se quiere agregar algun atributo extra. Por defecto es null</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonJsSave(this HtmlHelper htmlHelper, string actionName,
                string controller, string formName, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            string url = (new UrlHelper(htmlHelper.ViewContext.RequestContext)).Action(actionName, controller);
            return ActionButtonInternal(Default.Resources.BtnSave, string.Empty, GetSaveJs(formName, url), rtHtmlAttributes);
        }

        /// <summary>
        /// Crear el boton guardar, generandole el js necesario para que valide, muestre error y regrese al controlador.
        /// Usar el BeginForm para especificar el metodo que se utilizara para guardar. El control solo hace el postback
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Nombre de la accion a ejecutar si guarda correctamente</param>
        /// <param name="controller">Nombre del controlador a ejecutar si guarda correctamente</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonJsSave(this HtmlHelper htmlHelper, string actionName, string controller)
        {
            return ActionButtonJsSave(htmlHelper, actionName, controller,"form", null);
        }

        /// <summary>
        /// Crear el boton guardar, generandole el js necesario para que valide, muestre error y regrese al controlador.
        /// Usar el BeginForm para especificar el metodo que se utilizara para guardar. El control solo hace el postback
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">Id del boton</param>
        /// <param name="actionName">Nombre de la accion a ejecutar si guarda correctamente</param>
        /// <param name="controller">Nombre del controlador a ejecutar si guarda correctamente</param>
        /// <param name="htmlAttributes">Si se quiere agregar algun atributo extra. Por defecto es null</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonJsSave(this HtmlHelper htmlHelper, string actionName,
                string controller, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            string url = (new UrlHelper(htmlHelper.ViewContext.RequestContext)).Action(actionName, controller);
            return ActionButtonInternal(Default.Resources.BtnSave, string.Empty, GetSaveJs("form", url), rtHtmlAttributes);
        }

        /// <summary>
        /// Sobrecarga del botón guardar, utiliza el js propio de la vista. Solo crea el botón
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName">Accion a ejecutar</param>
        /// <param name="controller">Controlador a ejecutar</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSave(this HtmlHelper htmlHelper, string actionName, string controller)
        {
            return ActionButtonSave(htmlHelper, actionName, controller, null);
        }

        /// <summary>
        /// Sobrecarga del botón guardar, utiliza el js propio de la vista. Solo crea el botón
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="actionName"></param>
        /// <param name="controller"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSave(this HtmlHelper htmlHelper,
            string actionName, string controller, object htmlAttributes)
        {
            string url = new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controller);
            return ActionButtonInternal(Default.Resources.BtnSave, url, string.Empty, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Sobrecarga del botón guardar, utiliza el js que se le pase
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSave(this HtmlHelper htmlHelper, string javascript)
        {
            return ActionButtonInternal(Default.Resources.BtnSave, string.Empty, javascript, null);
        }

        /// <summary>
        /// Sobrecarga del botón guardar, solo crea el botón
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSave(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            return ActionButtonInternal(Default.Resources.BtnSave, string.Empty, string.Empty, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Sobrecarga del botón guardar vacio para que se ejecute con submit
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSave(this HtmlHelper htmlHelper)
        {
            return ActionButtonSubmit(htmlHelper,Default.Resources.BtnSave);
        }

        /// <summary>
        /// Crear el botón nuevo, ejecutando el js enviado
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="javascript"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonEdit(this HtmlHelper htmlHelper, string javascript)
        {
            return ActionButtonInternal(Default.Resources.BtnEdit, string.Empty, javascript, null);
        }

        /// <summary>
        /// Crea el boton editar vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonEdit(this HtmlHelper htmlHelper)
        {
            return ActionButtonEdit(htmlHelper, null);
        }

        /// <summary>
        /// Crea el boton editar vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">ID del botón</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonEdit(this HtmlHelper htmlHelper, string id, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            rtHtmlAttributes.Add("id", id);
            return ActionButtonEdit(htmlHelper, rtHtmlAttributes);
        }

        /// <summary>
        /// Crea el boton editar vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonEdit(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnEdit, string.Empty, string.Empty, rtHtmlAttributes);
        }

        /// <summary>
        /// Crea el boton eliminar vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonDelete(this HtmlHelper htmlHelper)
        {
            return ActionButtonDelete(htmlHelper, null);
        }

        /// <summary>
        /// Crear el botón delete, ejecutando el js enviado
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="javascript"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonDelete(this HtmlHelper htmlHelper, string javascript)
        {
            return ActionButtonInternal(Default.Resources.BtnDel, string.Empty, javascript, null);
        }

        /// <summary>
        /// Crea el boton eliminar vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="id">ID del botón</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonDelete(this HtmlHelper htmlHelper, string id, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary();
            rtHtmlAttributes.Add("id", id);
            return ActionButtonDelete(htmlHelper, null);
        }

        /// <summary>
        /// Crea el boton eliminar vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonDelete(this HtmlHelper htmlHelper, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(Default.Resources.BtnDel, string.Empty, string.Empty,  rtHtmlAttributes);
        }

        /// <summary>
        /// Crea un boton genérico vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="displayName">Valor a mostrar en el botón</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonGeneric(this HtmlHelper htmlHelper, string displayName)
        {
            return ActionButtonGeneric(htmlHelper, displayName, null);
        }

        /// <summary>
        /// Crea un boton genérico vacio, ya que se carga por js
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="displayName">Valor a mostrar en el botón</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonGeneric(this HtmlHelper htmlHelper, string displayName, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(displayName, string.Empty, string.Empty, rtHtmlAttributes);
        }

        /// <summary>
        /// Crea un boton genérico vacio, ya que se ejecuta con submit
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="displayName">Valor a mostrar en el botón</param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSubmit(this HtmlHelper htmlHelper, string displayName)
        {
            return ActionButtonSubmit(htmlHelper, displayName, null);
        }

        /// <summary>
        /// Crea un boton genérico vacio, ya que se ejecuta con submit
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="displayName">Valor a mostrar en el botón</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString ActionButtonSubmit(this HtmlHelper htmlHelper, string displayName, object htmlAttributes)
        {
            var rtHtmlAttributes = new RouteValueDictionary(htmlAttributes);
            return ActionButtonInternal(displayName, string.Empty, string.Empty, "Submit", rtHtmlAttributes);
        }

        /// <summary>
        /// Genera un botón
        /// </summary>
        /// <param name="buttonText">Valor del boton</param>
        /// <param name="url">URL que ejecutará boton</param>
        /// <param name="javascript">Javascript que ejecutará el botón</param>
        /// <param name="htmlAttributes">Atributos del boton</param>
        /// <returns></returns>
        private static MvcHtmlString ActionButtonInternal(string buttonText, string url, string javascript, IDictionary<string, Object> htmlAttributes)
        {
            return ActionButtonInternal(buttonText, url, javascript,"button", htmlAttributes);
        }

        /// <summary>
        /// Genera un botón
        /// </summary>
        /// <param name="buttonText">Valor del boton</param>
        /// <param name="url">URL que ejecutará boton</param>
        /// <param name="javascript">Javascript que ejecutará el botón</param>
        /// <param name="type">Tipo de boton</param>
        /// <param name="htmlAttributes">Atributos del boton</param>
        /// <returns></returns>
        private static MvcHtmlString ActionButtonInternal(string buttonText, string url, string javascript, string type, IDictionary<string, Object> htmlAttributes)
        {
            var buttonBuilder = new TagBuilder("input");
            buttonBuilder.Attributes.Add("type", type);

            buttonBuilder.MergeAttributes(htmlAttributes);
            buttonBuilder.Attributes.Add("value", buttonText);

            if (string.IsNullOrEmpty(url) == false)
                buttonBuilder.MergeAttribute("onclick", "location.href=' " + url + "';");
            if (string.IsNullOrEmpty(javascript) == false)
                buttonBuilder.MergeAttribute("onclick", javascript);

            return MvcHtmlString.Create(buttonBuilder.ToString(TagRenderMode.SelfClosing));
        }
                
        /// <summary>
        /// Obtiene el js del boton guardar
        /// </summary>
        /// <param name="formName">nombre del formulario</param>
        /// <param name="url">url a ejecutar si el boton guarda correctamente</param>
        /// <returns></returns>
        private static string GetSaveJs(String formName, String url)
        {
            var sb = new StringBuilder();
            sb.Append("if (!$('#");
            sb.Append(formName);
            sb.Append("').valid()) {return} $.post($('#");
            sb.Append(formName);
            sb.Append("').prop('action'), $('#");
            sb.Append(formName);
            sb.Append("').serialize(), function (result) { MostrarMensaje(result.PartialView); if (result.Success) { location.href = '");
            sb.Append(url);
            sb.Append("'; }});");

            return sb.ToString();
        }
    }
}