using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections.Generic;
using Application.MainModule.Services;
using Presentation.MVC.Models;
using System.Linq.Expressions;
using System;

namespace MvcHtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        //public static MvcHtmlString MDSelectBox(this HtmlHelper htmlHelper, List<DTOSafety> selectList, bool ReadOnly = false)
        //{
        //    var list = "";
        //    foreach (DTOSafety item in selectList)
        //    {
        //        list = list + "<li value='" + item.IDSafety + "'><span class='ui-icon ui-icon-circle-close'></span>" + item.Description + "</li>";
        //    }
        //    return new MvcHtmlString(
        //        "<ol class='selectable ui-selectable-disabled ui-state-disabled' aria-disabled='true'>" +
        //            list +
        //        "</ol>"
        //    );
        //}

        //public static MvcHtmlString MDSelectBox(this HtmlHelper htmlHelper, List<DTOSafety> selectList)
        //{
        //    var list = "";
        //    foreach (DTOSafety item in selectList)
        //    {
        //        list = list + "<li value='" + item.IDSafety + "'><span class='ui-icon ui-icon-circle-close'></span>" + item.Description + "</li>";
        //    }
        //    return new MvcHtmlString(
        //        "<ol class='selectable'>" +
        //            list +
        //        "</ol>"
        //    );
        //}

        public static MvcHtmlString MDImageLoader(this HtmlHelper htmlHelper, string expression, bool ReadOnly)
        {
            return new MvcHtmlString(

                 "<p class='imgWrapper'><img class='imgBoxed allow_zoom' id=" + "imgCar" + " alt='' src='"
                 +
                 expression
                 +
                 "' /></p>"
                 );
        }

        public static MvcHtmlString MDImageLoader(this HtmlHelper htmlHelper, string expression)
        {
            return new MvcHtmlString(
                "<input type='file' id=" + "theFile" + " name=" + "theFile" + " onchange='readURL(this);' />" +
                "<p class='imgWrapper'><img class='imgBoxed allow_zoom' id=" + "imgCar" + " alt='' src='"
                +
                expression
                +
                "' /><input type='button' class='pull-right' value='Quitar Foto' onclick='RemovePicture()' /></p>" +
                "<script type='text/javascript'>"
                +
                "function readURL(input) { if (input.files && input.files[0]) { var reader = new FileReader(); reader.onload = function (e) { $('#" + "imgCar" + "').attr('src', e.target.result); document.getElementById('ExistImage').value = e.target.result; }; reader.readAsDataURL(input.files[0]); }} function RemovePicture() { $('#" + "imgCar" + "').attr('src', '../Content/css/Images/default_car.jpg'); document.getElementById('image').value = ''; }"
                +
                "</script>"
                );
        }

        public static MvcHtmlString MDGoBackButton(this HtmlHelper htmlHelper)
        {
            return MDGoBackButton(htmlHelper, "javascript:history.go(-1)");
        }

        public static MvcHtmlString MDGoBackButton(this HtmlHelper htmlHelper, string url)
        {
            string html = "<a class='btn_secundario btn-right' href='" + url + "'>Volver</a>";

            return new MvcHtmlString(html);
        }

        public static MvcHtmlString MDCheckBoxFor(this HtmlHelper htmlHelper, string label, string name)
        {
            return new MvcHtmlString(
                "<div class='checkbox'><input type='checkbox' name=" + name + " id=" + name + " /><label for=" + name + "></label><span>" + label + "</span></div>"
            );
        }
    }
}