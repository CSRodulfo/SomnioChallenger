using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcHtmlHelpers
{
    public static class MDSelectHelper
    {
        public static MvcHtmlString MDSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return htmlHelper.MDSelectFor<TModel, TProperty>(expression, selectList, null, (IDictionary<string, object>)null);
        }

        public static MvcHtmlString MDSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return htmlHelper.MDSelectFor<TModel, TProperty>(expression, selectList, null, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString MDSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.MDSelectFor<TModel, TProperty>(expression, selectList, null, htmlAttributes);
        }

        public static MvcHtmlString MDSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            return htmlHelper.MDSelectFor<TModel, TProperty>(expression, selectList, optionLabel, (IDictionary<string, object>)null);
        }

        public static MvcHtmlString MDSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            return htmlHelper.MDSelectFor<TModel, TProperty>(expression, selectList, optionLabel, (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString MDSelectFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            if (selectList == null)
                throw new ArgumentNullException("SelectList");

            ModelMetadata modelMetadatum = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);

            if (htmlAttributes == null)
                htmlAttributes = new Dictionary<string, object>();

            //data-attribute para seleccionar los MDselects desde el JS.
            htmlAttributes.Add("data-MDSelect", "true");

            Type type = (expression.Body as MemberExpression).Type;

            //Los tipos nuleables tienen un placeholder "Sin asignar", los no nuleables "Seleccionar..."
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                optionLabel = optionLabel != null ? optionLabel : Default.Resources.SelectAssignItem;
            }
            else
            {
                //Si hay un sólo elemento <option> lo seteo como opción seleccionada por Reflection.
                if (selectList.Count() == 1)
                {
                    var memberExpression = (MemberExpression)expression.Body;
                    var property = (PropertyInfo)memberExpression.Member;

                    //Seteo el valor a la property realizando el casteo de string a el tipo específicado por el viewModel.
                    property.SetValue(htmlHelper.ViewData.Model, Convert.ChangeType(selectList.First().Value, type), null);
                }
                optionLabel = optionLabel != null ? optionLabel : Default.Resources.SelectItem;
            }

            //Llamo al dropdown de MVC
            return htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes);
        }

        public static MvcHtmlString MDSelectListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            return MDSelectListFor(htmlHelper,expression, selectList, null);
        }

        public static MvcHtmlString MDSelectListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
             if (expression == null)
                throw new ArgumentNullException("expression");
            if (selectList == null)
                throw new ArgumentNullException("SelectList");
                    
            //Llamo al dropdown de MVC
            return htmlHelper.DropDownListFor(expression, selectList, Default.Resources.SelectItem, htmlAttributes);
        }
    }
}