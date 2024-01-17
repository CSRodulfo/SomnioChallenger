//Mensajes Modal
function ExecuteMessagesSuccess(data, successFunction, onErrorCallback) {
    CheckForMessages(data, successFunction, onErrorCallback);
}

function ExecuteMessagesAfterSubmit(data, successFunction, onErrorCallback) {
    CheckForMessages(JSON.parse(data.responseText), successFunction, onErrorCallback);
    $(".ui-icon-closethick").trigger('click');
}

function CheckForMessages(data, onSuccessCallback, onErrorCallback) {

    var callbackObj = new Object();
    callbackObj.message = data.PartialView;
    callbackObj.success = data.Success;

    if (data.PartialView)
        MostrarMensaje(data.PartialView);

    if (data.Success) {
        if (typeof onSuccessCallback === "function")
            onSuccessCallback(callbackObj);
    }
    else {
        if (typeof onErrorCallback === "function")
            onErrorCallback(callbackObj);
    }
}

function MostrarMensaje(mensaje) {
    $.MDmessage({
        messageType: "info",
        message: mensaje,
        title: ResourcesMDmessage.title
    });

    /*$("body").append("<div id='mdmessage'><div>")
    $("#mdmessage").empty();
    $("#mdmessage").append(mensaje);
    $("#mdmessage").dialog({
        resizable: false,
        height: 'auto',
        title: title,
        modal: true,
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close");
            }
        },
        close: function () {
            $("#mdmessage").delete();
        }

    });    */
};

function MostrarMensajeConError(mensaje, mensajeError) {
    $.MDmessage({
        messageType: "info",
        message: mensaje,
        messageError: mensajeError,
        title: ResourcesMDmessage.title
    });
};

(function ($) {
    $.MDmessage = function (settings) {
        var config = {
            'messageType': "error", //alert, info o popup
            'title': null,
            'buttons': [],
            'btnok': true,
            'btnokText': ResourcesMDmessage.btnokText,
            'btnYesText': ResourcesMDmessage.btnYesText,
            'btnNoText': ResourcesMDmessage.btnNoText,
            'message': ResourcesMDmessage.message,
            'messageError': ResourcesMDmessage.messageError,
            'content': null, //Permite cargar Partials (como reemplazo del message).
            'modal': true, //Con o sin blackout
            'ic': null, //Contador de ID (autoincremental)
            'name': null, //ID custom (en realidad se agrega como una clase) para identificar desde código al elemento creado.
            'modaldialogclass': 'modal-dialog',
        };


        /* <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Modal title</h4>
      </div>*/

        if (settings) { $.extend(config, settings); }

        config.ic = $(".modal").length + 1;

        var mdmDiv = document.createElement('div');
        mdmDiv.id = "mdm" + config.ic;
        mdmDiv.className = "modal fade " + config.messageType + "_message";
        $(mdmDiv).data("backdrop", "static");
        $(mdmDiv).data("keyboard", "false");
        if (config.name)
            $(mdmDiv).data("modal-name", config.name);


        var bsDialog = document.createElement('div');
        bsDialog.className = "modal-dialog";

        var bsContent = document.createElement('div');
        bsContent.className = "modal-content";

        var bsHeader = document.createElement('div');
        bsHeader.className = "modal-header";

        var closeButton = document.createElement('button');
        closeButton.type = "button";
        closeButton.className = "close";
        closeButton.innerHTML = "&times;";
        closeButton.onclick = _bsCloseBtn;
        closeButton.setAttribute("data-modal-id", mdmDiv.id);

        var bsTitle = document.createElement('h4');
        bsTitle.className = "modal-title";
        $(bsTitle).text(config.title);

        var bsBody = document.createElement('div');
        bsBody.className = "modal-body";

        if(config.messageType != 'popup')
            $(bsBody).text(config.message);
        else {
            $(bsBody).load(config.content, function () {
                centerPopUp("#mdm" + config.ic);
            });
        }

        var hiddenError = document.createElement('hidden')
        hiddenError.setAttribute("value", config.messageError)

        var bsFooter = document.createElement('div');
        bsFooter.className = "modal-footer";

        var dynamicButtons = document.createElement('span');
        dynamicButtons.id = "btns_" + config.ic;

        $.each(config.buttons, function (name, fnc) {
            switch (name) {
                case 'Si':
                    name = config.btnYesText;
                    break;
                case 'No':
                    name = config.btnNoText;
                    break;
            }

            var click, buttonOptions;

            var btnObj = $.isFunction(fnc) ? { click: fnc, text: name } : fnc;

            btnObj = $.extend({ class: "btn-primary", href: "javascript:void(0)" }, btnObj);

            var btnElem = document.createElement('button');
            btnElem.type = "button";

            var bsButtonClass;
            switch (config.messageType) {
                case 'error':
                    bsButtonClass = "danger";
                    break;
                case 'alert':
                    bsButtonClass = "warning";
                    break;
                default:
                    bsButtonClass = "info";
                    break;
            }

            btnElem.className = 'btn btn-' + bsButtonClass;
            btnElem.href = "javascript:void(0)";
            btnElem.onclick = fnc;
            $(btnElem).text(name);

            dynamicButtons.appendChild(btnElem);
        });


        bsHeader.appendChild(closeButton);
        bsHeader.appendChild(bsTitle);

        bsContent.appendChild(bsHeader);
        bsContent.appendChild(bsBody);

        if (config.btnok) {
            var btnOk = document.createElement('button');
            btnOk.type = "button";
            btnOk.className = "btn btn-default";
            btnOk.setAttribute("data-modal-id", mdmDiv.id);
            $(btnOk).text(config.btnokText);
            btnOk.onclick = _bsOkBtn;

            $(dynamicButtons).prepend(btnOk);
        }

        bsFooter.appendChild(dynamicButtons);

        bsContent.appendChild(bsFooter);

        bsDialog.appendChild(bsContent);

        bsContent.appendChild(hiddenError);

        mdmDiv.appendChild(bsDialog);


        $("body").append(mdmDiv);

        $('#' + mdmDiv.id).modal('show');
        _attachEventClose(mdmDiv.id);
    };

    /*$.MDmessage = function (settings) {
        // settings
        var config = {
            'messageType': "error", //alert, info o popup
            'title': null,
            'buttons': [],
            'btnok': true,
            'btnokText': "Aceptar", 
            'message': "Éste es un mensaje por default, reemplazar en la propiedad 'message'",
            'content': null, //Permite cargar Partials (como reemplazo del message).
            'modal': true, //Con o sin blackout
            'ic': null, //Contador de ID (autoincremental)
            'name': null, //ID custom (en realidad se agrega como una clase) para identificar desde código al elemento creado.
        };
        if (settings) { $.extend(config, settings); }

        config.ic = $(".md_message").length + 1;

        if(config.messageType != "popup") {
            $('body').append('<div id="mdm' + config.ic + '" class="md_message ' + config.messageType + '_message ' + config.name + '" style="display:none; z-index: ' + (1000 + config.ic) + ';"><p class="mdm_title ' + config.messageType + '_message_title">' + config.title + '</p><p class="mdm_text">' + config.message + '</p><div class="btns_container"><a href="javascript:closeMessage(&quot;#mdm' + config.ic + '&quot;);" class="button_ui btn_message">' + config.btnokText + '</a></div></div>');
        } else {
            $('body').append('
            <div id="mdm' + config.ic + '" class="md_message ' + config.messageType + '_message ' + config.name + '" style="display:none; z-index: ' + (1000 + config.ic) + ';">
            
                <p class="mdm_title ' + config.messageType + '_message_title">' + config.title + '</p>

                <div class="mdm_text">
                </div>
            
                <div class="btns_container">
                    <a href="javascript:closeMessage(&quot;#mdm' + config.ic + '&quot;);" class="button_ui btn_message">
                        ' + config.btnokText + '
                    </a>
                </div>
            </div>');
            $('.mdm_text').load(config.content, function () {
                centerPopUp("#mdm" + config.ic);
            });
            if (config.title == null) {
                $(".mdm_title").remove();
            };
        }

        $.each( config.buttons, function( name, props ) {
            var click, buttonOptions;
            props = $.isFunction( props ) ?
                { click: props, text: name } :
            props;
            props = $.extend({ class: "button_ui btn_message", href: "javascript:void(0)" }, props);
            click = props.click;
            props.click = function () {
                click.apply($('#mdm' + config.ic).find('.btn_message'), arguments);
            };
            $( "<a></a>", props )
                .appendTo( $("#mdm" + config.ic).find(".btns_container") );
        });

        if (config.modal == true) {
            $('body').append('<div class="blackout ' + config.name + 'bo" id="mdm' + config.ic + 'bo" style="display:none; z-index: ' + (999 + config.ic) + ';"></div>');
        }

        $(".blackout").slideDown();
        $("#mdm" + config.ic).fadeIn();

        centerPopUp("#mdm" + config.ic);
    };*/
})(jQuery);

$(window).resize(function () { centerPopUp(".md_message"); })

function _bsCloseBtn() {
    closeMessage("#" + $(this).data("modal-id"));
}

function _bsOkBtn() {
    closeMessage("#" + $(this).data("modal-id"));
}

function _attachEventClose(modalId) {
    $('#' + modalId).on('hidden.bs.modal', function (e) {
        $('#' + modalId).remove();
    })
}

function centerPopUp(popup) {
    $(popup).css({
        "top": $(window).innerHeight() / 2 - $(popup).height() / 2 + "px",
        "left": $(window).innerWidth() / 2 - $(popup).width() / 2 + "px",
    });
};


function closeMessage(selector) {
    if (selector.substr(0, 1) == "#") {
        $(selector).modal('hide');
    }
    else {
        $(".modal").each(function () {
            if ($(this).data("modal-name") == selector)
                $(this).modal('hide');
        })

        //$("[data-modal-name = " + selector + "]").modal('hide');
    }
}