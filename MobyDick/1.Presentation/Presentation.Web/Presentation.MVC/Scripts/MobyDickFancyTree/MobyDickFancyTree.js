$.fn.MobyDickFancyTree = function (userOptions) {
    var _this = $(this);

    var options = {
        activate: null,
        checkbox: false,
        useBase: true,
        iconURL: "icons.gif",
        tableId: "tree",
        source: null,
        extensions: [],
        autoActivate: true,
        keyboard: false,
        click: null,
        dblclick: null,
        dnd: null,
        keydown: null,
        select: null,
        focus: null
    };

    $.extend(options, userOptions);

    $("#" + options.tableId).fancytree({
        checkbox: options.checkbox,
        source: options.source,
        activate: options.activate,
        extensions: options.extensions,
        autoActivate: options.autoActivate,
        keyboard: options.keyboard,
        click: options.click,
        dblclick: options.dblclick,
        dnd: options.dnd,
        keydown: options.keydown,
        select: options.select,
        focus: options.focus
    });

    $("#" + options.tableId).fancytree("getRootNode").visit(function (node) {
        node.setExpanded(true);

        if (options.useBase == false) {
            while (node.hasChildren()) {
                node.getFirstChild().setExpanded(true);
                node.getFirstChild().moveTo(node.parent, "child");
            }
            node.remove();
        }
    });

    $("#" + options.tableId).fancytree.style = "url('" + options.iconURL + "')";

    return _this;
};