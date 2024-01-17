var initialPage = document.location;
var culture = document.cookie;

function MostrarError(mensaje) {
    $.MDmessage({
        messageType: "error",
        message: mensaje,
        title: ResourcesMDmessage.titleError
    });
}

function MostrarConfirm(message, fncYes, fncNo) {
    $.MDmessage({
        title: ResourcesMDmessage.titleConfirmation,
        btnok: false,
        name: "MDConfirmModal",
        buttons: {
            "Si": function () {
                if (typeof fncYes === "function")
                    fncYes();
                //closeMessage('MDConfirmModal'); //Cerrar después de ejecutar?
            }, "No": function () {
                if (typeof fncNo === "function")
                    fncNo();
                //closeMessage('MDConfirmModal'); //Cerrar después de ejecutar?
            }
        },
        message: message,
    });
}

function floatValue(value, inverse) {

    if (inverse)
        return value.replace(".", ",")

    return parseFloat(value.replace(",", "."));
}

function blockWindow() {
    if ($("#blocker").length == 0) {
        $("body").append("<div id='blocker'></div>");
        $("#blocker").css("position", "fixed").css("top", "0").css("left", "0")
            .css("width", "100%").css("height", "100%").css("z-index", "99999").css("background-color", "rgba(255,255,255,0.5)");
    } else {
        $("#blocker").show();
    }
}

function unblockWindow() {
    $("#blocker").hide();
}

function asyncNavigate(url, before, after, preventPush, method, callback) {
    location.href = url;
    /*if (!preventPush) {
        history.pushState({ "isAjax": true, "method": "GET" }, document.location, url);
    }

    if (!method) {
        method = "GET";
    }

    if (before)
        before();

    $.ajax({
        url: url,
        type: method,
        success: function (data) {
            if (data.PartialView) {
                MostrarMensaje(data.PartialView);
            } else {
                $(".body-content").html(data);
            }
            if (callback) {
                callback();
            }
        },
        error: function () {
            MostrarMensaje("Ocurrio un error en el sistema");
        },
        complete: function () {
            if (after)
                after();
        }
    });*/
}

function getFreshUrl(url) {

    if (url.indexOf("page_version") == -1) {
        if (url.indexOf("?") != -1) {
            url += "&";
        } else {
            url += "?";
        }
        url += "page_version=" + Date.now();
    } else {
        url = url.replace("page_version=", "page_version=*");
    }

    return url;
}

function confirmTreeDelete(url) {

    $("#dialog-confirm").dialog({
        height: 160,
        autoOpen: false,
        modal: true,
        show: {
            effect: "fadeIn",
            duration: 300
        },
        hide: {
            effect: "fadeOut",
            duration: 300
        },
        close: function () {
            $("#dialog-confirm .ui-state-error").css("display", "none");

        },
        buttons: {
            "Eliminar": function () {
                asyncNavigate(url, blockWindow, unblockWindow, true, "GET", function () {
                    location.reload(true);
                });
                $(this).dialog("close");
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    }).dialog("open");

}

$(function () {

    $('body').on('click', "a[data-async]", function (e) {

        e.preventDefault();

        var url = $(this).prop("href");

        var type = $(this).data("async");

        switch (type) {
            case "tree-id":
                url += "/" + $("#tree_selected_id").val();
                break;
            case "delete-tree-id":
                console.log("delete1");
                url += "/" + $("#tree_selected_id").val();
                confirmTreeDelete(url);
                return;
        }

        asyncNavigate(url, blockWindow, unblockWindow);

    });

    $('body').on('click', "form[data-async] [type=submit]", function (e) {
        $form = $(this).closest("form[data-async]");
        $form.removeData("validator");
        $form.removeData("unobtrusiveValidation");
        $.validator.unobtrusive.parse($form);
        if (!$form.valid()) {
            e.preventDefault();
        }
    });

    $('body').on('submit', "form[data-async]", function (e) {

        e.preventDefault();

        var form = this;

        var url_complete = $(this).data("async-target");

        $(form).find("[data-val-number]").each(function () {
            $(this).val(floatValue($(this).val()));
        });

        history.pushState({ "isAjax": true, "method": "GET" }, document.location, url_complete);

        blockWindow();
        $.ajax({
            url: $(form).prop("action"),
            method: $(form).prop("method"),
            data: $(form).serialize(),
            success: function (data) {
                ExecuteMessagesSuccess(data);
            },
            error: function () {
                alert("Ocurrió un error al guardar el registro");
            },
            complete: function () {
                $.get(url_complete, function (data) {
                    $(".body-content").html(data);
                    unblockWindow();
                });
            }
        });


        return false;
    });

    window.onpopstate = function (event) {

        console.log(event);

        if (event.state) {
            if (event.state.isAjax) {
                if (event.state.method == "GET") {
                    asyncNavigate(document.location, blockWindow, unblockWindow, true);
                }
            }
        } else {
            asyncNavigate(initialPage, blockWindow, unblockWindow, true);
        }

    };

});

//Mensajes mobydick. Sobreescribir en cada proyecto.
function MostrarError(mensaje) {
    $.MDmessage({
        messageType: "error",
        message: mensaje,
        title: 'Error'
    });
}

function MostrarConfirm(message, fncYes, fncNo) {
    $.MDmessage({
        title: ResourcesMDmessage.titleConfirmation,
        btnok: false,
        name: "MDConfirmModal",
        buttons: {
            "Si": function () {
                if (typeof fncYes === "function")
                    fncYes();
                //closeMessage('MDConfirmModal'); //TODO: Cerrar después de ejecutar?
            }, "No": function () {
                if (typeof fncNo === "function")
                    fncNo();
                //closeMessage('MDConfirmModal'); //TODO: Cerrar después de ejecutar?
            }
        },
        message: message,
    });
}