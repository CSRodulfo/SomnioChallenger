// Requiere 
// - jQuery
// - jqGrid

// message structure : [ status , message ]

$.fn.MobyDickGrid = function (userOptions) {

    var messageHandler = function (result, callback) {

        if (result != null && result != undefined) {

            if (result[1]) {

                MostrarMensaje(result[1]);

                if (callback) {
                    callback();
                }
                return true;

            }
        }

        return false;
    };

    var confirmHandler = function (message, callback) {
        var result = confirm(message);

        if (callback) {
            callback(result);
        }
    };

    var $this = $(this);

    var options = {

        messageDataStatusIndex: 0,
        messageDataMessageIndex: 1,
        messageDataStickyIndex: 2,

        // Grilla:
        caption: "Resultados",
        listUrl: "",
        data: null,
        datatype: 'json',
        tableId: "MobyDickGrid",
        colNames: [],
        colVisibility: false,
        colAlign: false,
        colIndex: false,
        pagerId: "MobyDickPager",
        width: false,
        method: "GET",
        multiple: false,
        usePagerIcons: false,
        height: '351px',
        notSearch: true,
        sortname: '',
        sortable: true,
        // Acciones:

        //Filtrar
        filterBtnSelector: "#filter",
        filterCondition: true,
        filterMessage: "Complete los valores de búsqueda",


        //Listar todos
        listAllBtnSelector: "#listAll",
        listAllReset: false,

        //Refrescar
        refreshUrl: false,
        refreshBtnSelector: "#refresh",

        // - Agregar
        addUrl: false,
        addTitle: "Agregar registro",
        addForm: false,
        addBtnSelector: "#add",

        // - Editar
        editUrl: false,
        editTitle: "Editar registro",
        editForm: false,
        editBtnSelector: "#edit",

        // - Eliminar
        deleteUrl: false,
        deleteTitle: "Eliminar registro",
        deleteConfirm: "¿Realmente desea eliminar el registro?",
        deleteForm: false, // reservado para uso futuro
        deleteBtnSelector: "#delete",
        useGridDelete: false,

        // - Cambiar estado
        changeStateUrl: false,
        changeStateConfirm: "¿Realmente desea modificar el estado del registro?",
        changeStateAlreadyDeletedMessage: "El elemento ya fue dado de baja",

        // - Exportar
        exportUrl: false,
        exportForm: false, // form que contiene datos para enviar al post
        exportBtnSelector: "#export",

        // - Consultar
        consultUrl: false,
        consultTitle: "Ver registro",
        consultForm: false, // reservado para uso futuro
        consultBtnSelector: "#view",

        // Mensajes:
        selectFieldMessage: "Debe seleccionar un registro",
        unexpectedErrorMessage: "Ocurrió un error inesperado",

        // Métodos:
        gridData: function () { },
        onBeforeAjax: function () { },
        onAfterAjax: function () { },
        onDelete: false, //function (id) { },
        onComplete: function () { },
        onLoadComplete: function () { },
        onClickRow: false,

        onAdd: function () { options.navigate(options.addUrl, options.onBeforeAjax, options.onAfterAjax); },
        onEdit: function (id) { options.navigate(options.editUrl + "/" + id, options.onBeforeAjax, options.onAfterAjax); },
        onConsult: function (id) { options.navigate(options.consultUrl + "/" + id, options.onBeforeAjax, options.onAfterAjax); },

        navigate: function (url, before, after) { document.location = url; },

        handleFormSubmission: false,
        showMessage: messageHandler, // (data[], callback) -> return boolean;
        confirmMessage: confirmHandler, // (message, callback);
    };

    if (typeof (MobyDickGridConfig) != "undefined") {
        if (typeof (MobyDickGridConfig.options) != "undefined") {
            $.extend(options, MobyDickGridConfig.options);
        }
    }

    if (typeof (ResourcesMobyDickGrid) != "undefined") {
        if (typeof (ResourcesMobyDickGrid.options) != "undefined") {
            $.extend(options, ResourcesMobyDickGrid.options);
        }
    }

    $.extend(options, $($this).data());

    $.extend(options, userOptions);

    var getCurrentForm = function () {
        var form_id = "";

        if ($("#" + options.addForm).length > 0) {
            form_id = options.addForm;
        } else if ($("#" + options.editForm).length > 0) {
            form_id = options.editForm;
        }

        return form_id;
    };

    var getColModel = function () {
        var model = [];
        var total = 0;
        for (x in options.colWidth) {
            total += options.colWidth[x];
        }

        for (i in options.colNames) {

            var align = "left";
            var index = i;
            var hidden = false;

            if (options.colAlign) {
                align = options.colAlign[i];
            }

            if (options.colIndex) {
                index = options.colIndex[i];
            }

            if (options.colVisibility && options.colVisibility[i] == 'hidden')
                hidden = true;

            if (options.colWidth) {
                model.push({ name: index, index: index, align: options.colAlign[i], hidden: hidden, width: ((options.colWidth[i] / total) * 100) + "%" });
            } else {
                model.push({ name: index, index: index, align: options.colAlign[i], hidden: hidden });
            }
        }

        if (!options.sortable) {
            for (x in model) {
                $.extend(model[x], { sortable: false });
            }
        }

        return model;
    };

    var execAdd = function () {
        options.onAdd();
    };

    var execDblClick = function (id) {
        if (options.editUrl) {
            execEdit(id);
        }
        else if (options.consultUrl) {
            execConsult(id);
        }
    };

    var execClick = function (id) {
        var rowId = $("#" + options.tableId).jqGrid('getGridParam', 'selrow');;

        try {
            rowId = parseInt(id, 10);
        } catch (ex) { }
        if (rowId == null || rowId == undefined || isNaN(rowId)) {
            rowId = $("#" + options.tableId).jqGrid('getGridParam', 'selrow');
        }

        if (rowId) {
            options.onClickRow(rowId);
        }
    };

    var execEdit = function (id) {
        if (options.editUrl) {

            var rowId = null;

            try {
                rowId = parseInt(id, 10);
            } catch (ex) { }

            if (rowId == null || rowId == undefined || isNaN(rowId)) {
                rowId = $("#" + options.tableId).jqGrid('getGridParam', 'selrow');
            }

            if (rowId) {
                options.onEdit(rowId);
            }
            else {

                options.showMessage([false, options.selectFieldMessage]);
            }
        }
    };

    var execConsult = function (id) {
        if (options.consultUrl) {
            options.onConsult(id);
        }
    };

    var execDelete = function () {
        var rowId = $("#" + options.tableId).jqGrid('getGridParam', 'selrow');
        if (rowId) {

            /*if ($('.changeState[data-id=' + rowId + ']').is('.item-not-available')) {

                options.showMessage([ false, options.changeStateAlreadyDeletedMessage ]);

                return false;
            }*/

            if (options.useGridDelete) {
                $("#" + options.tableId).jqGrid('delGridRow', rowId, {
                    afterSubmit: function (response, postdata) {
                        options.showMessage(response);
                        return [true, '', ''];
                    },
                    width: 300,
                    modal: true,
                    url: options.deleteUrl + "/" + rowId,
                    closeAfterAdd: true,
                    reloadAfterSubmit: true
                });
            } else if (options.onDelete) {
                options.onDelete(rowId);
            } else {
                options.confirmMessage(options.deleteConfirm, function (result) {
                    if (result) {
                        options.onBeforeAjax();
                        $.ajax({
                            url: options.deleteUrl + "/" + rowId,
                            type: "POST",
                            success: function (data) {

                                options.showMessage(data);

                                $("#" + options.tableId).trigger('reloadGrid');
                            },
                            error: function () {
                                options.showMessage([false, options.unexpectedErrorMessage]);
                            },
                            complete: function () {
                                options.onAfterAjax();
                            }
                        });
                    }
                });
            }

        } else {
            options.showMessage([false, options.selectFieldMessage]);
        }
    };

    var execComplete = function () {

        options.onComplete();

    };

    var getGridData = function () {
        return options.gridData();
    };

    var alignHeaders = function () {
        $('#gview_' + options.tableId + ' .ui-jqgrid-htable').addClass('table-fixed-important');
        var objHeader = $("table[aria-labelledby=gbox_" + options.tableId + "] tr[role=rowheader] th");
        for (var i = 0; i < objHeader.length; i++) {
            var col = $("table[id=" + options.tableId + "] td[aria-describedby=" + objHeader[i].id + "]");
            var width = col.outerWidth();
            $(objHeader[i]).css("width", width);
        }
    };

    var jqOpt = {
        url: options.listUrl,
        caption: options.caption,
        datatype: options.datatype,
        mtype: options.method,
        postData: getGridData(),
        colNames: options.colNames,
        colModel: getColModel(),
        pager: $('#' + options.pagerId),
        sortname: options.sortname,
        rowNum: 10,
        rowList: [10, 20, 50],
        viewrecords: true,
        autowidth: true,
        height: options.height,
        gridview: true,
        //caption: "Resultados",
        ondblClickRow: execDblClick,
        loadComplete: options.onLoadComplete,
        gridComplete: function () {
            alignHeaders();
            options.onComplete();
        },
        multiselect: options.multiple
    };

    $('body').mouseup(function () { setTimeout(alignHeaders, 50); })

    if (options.datatype == 'local')
        jqOpt.data = options.data;

    $("#" + options.tableId).jqGrid(jqOpt)
        .navGrid('#' + options.pagerId, {
            add: false, search: false, refresh: false, edit: false, del: false
        });

    if (!options.notSearch) {
        $("#" + options.tableId).jqGrid('filterToolbar', { searchOperators: false, searchOnEnter: false });
    }

    if (options.width) {
        $("#" + options.tableId).jqGrid('setGridWidth', options.width);
    }

    if (options.addUrl) {
        $('body').off('click', options.addBtnSelector);
        $('body').on('click', options.addBtnSelector, execAdd);
    }

    if (options.editUrl) {
        $('body').off('click', options.editBtnSelector);
        $('body').on('click', options.editBtnSelector, execEdit);
    }

    if (options.deleteUrl) {
        $('body').off('click', options.deleteBtnSelector);
        $('body').on('click', options.deleteBtnSelector, execDelete);
    }


    $('body').off('click', options.refreshBtnSelector);
    $('body').on('click', options.refreshBtnSelector, function () {
        //se vacian las cajas de texto si es que quedaron con datos a la hora de hacer el listar todo
        $(".search > span > input").each(function () {
            $(this).val("");
        });
        $(".search > select").each(function () {
            $(this).val("");
        });
        $("#" + options.tableId).trigger('reloadGrid');
    });

    if (options.changeStateUrl) {
        $('body').off('click', '#' + options.tableId + ' .changeState');
        $('body').on('click', '#' + options.tableId + ' .changeState', function () {
            var itemid = $(this).data('id');

            options.confirmMessage(options.changeStateConfirm, function (result) {
                if (result) {
                    options.onBeforeAjax();
                    $.ajax({
                        url: options.changeStateUrl + "/" + itemid,
                        type: "POST",
                        success: function (data) {

                            $("#" + options.tableId).trigger('reloadGrid');
                            options.showMessage(data); // Manejar desde el controlador q mensaje se muestra (se dio de baja o se volvio a dar de alta)

                        },
                        error: function () {
                            options.showMessage([false, options.unexpectedErrorMessage]);
                        },
                        complete: function () {
                            options.onAfterAjax();
                        }
                    });
                }
            });
        });
    }

    if (options.exportUrl) {
        $('body').off('click', options.exportBtnSelector);
        $('body').on('click', options.exportBtnSelector, function (e) {

            e.preventDefault();

            var params = "";
            $('.ui-search-table input').each(function () {
                params += $(this).attr("name") + "=" + $(this).val() + "&";
            });

            if (options.exportForm) {
                //params += $('#' + options.exportForm).serialize();
            }

            //Todo: arreglar para manejo de errores del lado del servidor
            var url = options.exportUrl + "?" + params;
            url += "&sidx=" + $("#" + options.tableId).jqGrid('getGridParam', 'sortname');
            url += "&sord=" + $("#" + options.tableId).jqGrid('getGridParam', 'sortorder');
            //location.href = url;

            submitForm("#" + options.exportForm, url);


        });
    }


    $('body').off('click', options.filterBtnSelector);
    $('body').on('click', options.filterBtnSelector, function () {

        var condition = false;

        if (typeof (options.filterCondition) == "function") {
            condition = options.filterCondition();
        }
        else {
            condition = options.filterCondition;
        }
        if (condition) {
            $("#" + options.tableId).trigger('reloadGrid', [{ page: 1 }]);
        }
        else {

            options.showMessage([false, options.filterMessage]);
        }

    });

    if (options.onClickRow) {
        $('body').off('click', "#" + options.tableId + " .jqgrow");
        $('body').on('click', "#" + options.tableId + " .jqgrow", function () {
            execClick();
        });
    }

    if (options.consultUrl) {
        $('body').off('click', options.consultBtnSelector);
        $('body').on('click', options.consultBtnSelector, function () {
            var rowId = $("#" + options.tableId).jqGrid('getGridParam', 'selrow');
            if (rowId) {
                execConsult(rowId);
            } else {
                options.showMessage([false, options.selectFieldMessage]);
            }
        });
    }

    if (options.usePagerIcons) {

        if (options.addUrl) {
            $("#" + options.tableId).jqGrid().navButtonAdd('#' + options.pagerId, {
                caption: "",
                buttonicon: "ui-icon-plus",
                onClickButton: execAdd,
                position: "last",
                title: options.addTitle
            });
        }

        if (options.editurl) {
            $("#" + options.tableId).jqGrid().navButtonAdd('#' + options.pagerId, {
                caption: "",
                buttonicon: "ui-icon-pencil",
                onClickButton: execEdit,
                position: "last",
                title: options.editTitle
            });
        }

        if (options.deleteurl) {
            $("#" + options.tableId).jqGrid().navButtonAdd('#' + options.pagerId, {
                caption: "",
                buttonicon: "ui-icon-close",
                onClickButton: execDelete,
                position: "last",
                title: options.deleteTitle
            });

        }
        //// return options;
    }
    return options;
}

function submitForm(form, url) {
    var submit_form = $("<form />").css("display", "none");
    $(submit_form).prop("action", url);
    $(submit_form).prop("method", "POST");
    $(form + " input, " + form + " select, " + form + " textarea").each(function () {
        var input = $("<input>").prop("type", "hidden").prop("name", $(this).prop("name")).val($(this).val());
        $(submit_form).append(input);
    });
    $(submit_form).appendTo("body").submit();
}