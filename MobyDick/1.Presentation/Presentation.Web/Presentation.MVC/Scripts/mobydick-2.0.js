$(document).ready(function () {
    //Función del Enter
    $(':text').keypress(function (event) {
        var enterOkClass = $(this).attr('class');
        if (event.which === 13 && enterOkClass !== 'enterSubmit') {
            event.preventDefault();
            return false;
        }
    });

    //Helper Estilos
    $("#body_main_wrapper").css("min-height", $(window).innerHeight() - $("header").height() - $("footer").height() + "px");
    $(window).resize(function () { $("#body_main_wrapper").css("min-height", $(window).innerHeight() - $("header").height() - $("footer").height() + "px"); });
    $("select[multiple='multiple']").css("display", "none");


    //Grilla (ajuste de ancho dinámico)
    //$(".ui-jqgrid").each(function () {
    //    $(this).find(".ui-jqgrid-btable").setGridWidth($(this).parent().parent().width());
    //})

    //$(window).bind('resize', function () {
    //    $(".ui-jqgrid").each(function () {
    //        $(this).find(".ui-jqgrid-btable").setGridWidth($(this).parent().parent().width());
    //    })
    //}).trigger('resize');
});

$(function () {
    $('select[data-mdselect="true"]').each(function () {
        $(this).select2();
    });
});