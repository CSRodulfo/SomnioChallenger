$.fn.MobyDickChart = function (userOptions) {

    var _this = $(this);

    var options = {

        title: false,
        type: false,
        legends: false,
        src: false

    };

    $.extend(options, userOptions);

    $(_this).append('<div class="panel panel-default" />');

    var getCanvas = function () {
        return $(_this).find("canvas")[0];
    };

    var getCanvasContext = function () {
        return getCanvas().getContext("2d");
    };

    var getLegendsContainer = function () {
        return $(_this).find(".list-group-item.legends");
    };

    var setTitle = function () {
        if (options.title) {
            $(_this).find(".panel").append('<div class="panel-heading" />');
            $(_this).find(".panel-heading").append('<h3 class="panel-title" />');
            $(_this).find(".panel-title").html(options.title);
        }
    };

    var setBody = function () {
        var width = $(_this).width();

        $(_this).find(".panel").append('<ul class="list-group">');
        $(_this).find(".list-group").append('<li class="list-group-item canvas" />');
        $(_this).find(".list-group-item.canvas").append("<canvas />");
        $(_this).find("canvas").prop("width", width * 0.8).prop("height", width * 0.5);

        if (options.legends) {
            $(_this).find(".list-group").append('<li class="list-group-item legends" />');
        }
    };

    var setCanvas = function () {
        $.ajax({
            url: options.src,
            async: false,
            success: function (data) {
                var myChart = getChart(data);

                if (options.legends) {
                    var legendHolder = document.createElement('div');
                    legendHolder.innerHTML = myChart.generateLegend();

                    $(legendHolder.firstChild.childNodes).each(function (index, node) {
                        $(node).mouseover(function () {
                            var activeSegment = myChart.segments[index];
                            activeSegment.save();
                            activeSegment.fillColor = activeSegment.highlightColor;
                            myChart.showTooltip([activeSegment]);
                            activeSegment.restore();
                        });
                    });

                    $(legendHolder.firstChild).mouseout(function () {
                        myChart.draw();
                    });

                    getLegendsContainer().append(legendHolder);
                }
            }
        });
    };

    var getChart = function (data) {
        switch (options.type) {
            case "pie":
                return new Chart(getCanvasContext()).Pie(data, {
                    animationEasing: "easeOut",
                    animationSteps: 50,
                    responsive: true
                });
                break;

            case "line":
                return new Chart(getCanvasContext()).Line(data, {
                    responsive: true
                });
                break;

            case "bar":
                return new Chart(getCanvasContext()).Bar(data, {
                    responsive: true
                });
                break;

            case "radar":
                return new Chart(getCanvasContext()).Radar(data, {
                    responsive: true
                });
                break;
                
            case "polararea":
                return new Chart(getCanvasContext()).PolarArea(data, {
                    responsive: true
                });
                break;

            case "doughnut":
                return new Chart(getCanvasContext()).Doughnut(data, {
                    responsive: true
                });
                break;

            default:
                console.log("ERROR: Wrong Chart Type");
                break;
        }
    };

    var createStyles = function () {
        $('body').append('<style id="MobyDickChartCss">.list-group-item.legends ul{padding-left: 0;}.list-group-item.legends li{display:block;list-style:none;cursor:pointer;}.list-group-item.legends li span {display:inline-block;width:15px;height:15px;margin:0 10px -2px;}</style>');
    };

    var addStylesIfNotExist = function () {
        if ($('style#MobyDickChartCss').length == 0) {
            createStyles();
        }
    };

    var initialize = function () {
        addStylesIfNotExist();
        setTitle();
        setBody();
        setCanvas();
    };

    initialize();

    return _this;
};