using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Collections.Generic;
using Application.MainModule.Services;
using Presentation.MVC.Models;
using System.Linq.Expressions;
using System;

namespace MvcHtmlHelpers
{
    public static class DatePickerHelper
    {        
        public static MvcHtmlString DateLoader(this HtmlHelper htmlHelper)
        {
            
            var script = String.Format(@"
                <script type='text/javascript'>
                    $(document).ready(function () {
                        $('#datepicker').datepicker();
                        var availableTags = [
                            'ActionScript', 'AppleScript', 'Asp', 'BASIC', 'C', 'C++', 'Clojure', 'COBOL', 'ColdFusion', 'Erlang',
                            'Fortran', 'Groovy', 'Haskell', 'Java', 'JavaScript', 'Lisp', 'Perl', 'PHP', 'Python', 'Ruby', 'Scala', 'Scheme'
                        ];
                        
                    });",
                        HtmlHelper.GetInputTypeString(InputType.Text)
                );
            return MvcHtmlString.Create(script);
                      
        }


        public static MvcHtmlString DateLoader(this HtmlHelper htmlHelper, string date)
        {

            return new MvcHtmlString(
                "<div class='calendar'>" 
                +
                "<input type='text' id=" + date + " name=" + date + " class='has" + date + " form-control' />" 
                +
                "<span class='icono-calendar pull-right' id=" + date + "></span>"
                +
                "</div>" 
            );
        }
    }
}