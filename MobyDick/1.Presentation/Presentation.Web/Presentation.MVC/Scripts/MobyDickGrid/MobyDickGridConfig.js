// Requiere 
// - jQuery
// - jqGrid

var MobyDickGridConfig = {
    options: {
        // addTitle: "Agregar registro",
        // editTitle: "Editar registro",
        // deleteTitle: "Eliminar registro",
        // deleteConfirm: "¿Realmente desea eliminar el registro?",
        // changeStateConfirm: "¿Realmente desea modificar el estado del registro?",
        // changeStateAlreadyDeletedMessage: "El elemento ya fue dado de baja",
        // consultTitle: "Ver registro",
        // selectFieldMessage: "Debe seleccionar un registro",
        // unexpectedErrorMessage: "Ocurrió un error inesperado",

        // addBtnSelector: "#add",
        // editBtnSelector: "#edit",
        // deleteBtnSelector: "#delete",
        // exportBtnSelector: "#export",
        // consultBtnSelector: "#view",		

        //handleFormSubmission: true,

        // Métodos sobreescritos:
        onBeforeAjax: blockWindow,
        onAfterAjax: unblockWindow,
        showMessage: function (result, callback) {
            console.log(result);
            if (result.length > 0) {
                ExecuteMessagesSuccess({ "Success": true, "PartialView": result[1] }, callback);
            } else {
                ExecuteMessagesSuccess(result, callback);
            }

            return true;
        },
        navigate: function (url, before, after) {
            asyncNavigate(url, before, after);
        },

        confirmMessage: function (message, callback) {

            MostrarConfirm(message,
                function () {
                    if (typeof callback == "function")
                        callback(true);
                    closeMessage('MDConfirmModal');
                },
                function () { closeMessage('MDConfirmModal'); }
                );
            //$(".btns_container a:first-child").hide();
        }
    }
};