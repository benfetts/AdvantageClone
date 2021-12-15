
//
var _activeView = "";

//parent call from Webvantage.ts
function refreshPage(requestor) {
    //
    RefreshGrid();
}

function openRadWindowWithEvents(title, url, windowHeight, windowWidth, modal, onCloseCallback) {
    OpenRadWindow(title, url, windowHeight, windowWidth, modal, onCloseCallback);
}//var chartColors = ["#2196f3", "#2A579A", "#00BCD4", "#009688", "#94508C"];
var chartColors = ["#337ab7", "#5cb85c", "#f0ad4e", "#5bc0de", "#d9534f"];

function ChartHeaderTemplate(item) {
    var template = kendo.template($("#ChartHeaderTemplate").html());

    //var data = { image: item.Receipt, filename: item.Filename };
    var data = item.Receipt;

    var result = template(data);
    return result;
    //console.log('receipt: ');
    //console.log(container);       
}

function SetDashboardTotals(chartId, totalCount, totalAmount) {
    if (chartId == 0) {
        $("#spendTotalCount").html("Total Count: " + totalCount);
        $("#spendTotalAmount").html("Total Amount: " + kendo.toString(totalAmount, "c0"));
    } else if (chartId == 1) {
        $("#openTotalCount").html("Total Count: " + totalCount);
        $("#openTotalAmount").html("Total Amount: " + kendo.toString(totalAmount, "c0"));
    } else if (chartId == 2) {
        $("#pendingTotalCount").html("Total Count: " + totalCount);
        $("#pendingTotalAmount").html("Total Amount: " + kendo.toString(totalAmount, "c0"));
    }

}

function pendingGridAll() {
    let gridData = $("#pendingDataGrid").data("kendoGrid").dataSource;
    gridData.filter([]);

    $("#pendingGridTitle").html("All Vendors");
    $("#resetGrid").hide();
}

function columnView(e, chartId) {
    chartId = "#" + chartId;
    pieButtonId = chartId + "View #pie";
    columnButtonId = chartId + "View #column";

    let chart = $(chartId).data("kendoChart");

    if (e.id == "pie") {
        chart.options.series[0].type = "pie";

        $(columnButtonId).removeClass('k-state-active');
        $(columnButtonId).addClass('wv-neutral');

        $(pieButtonId).removeClass('wv-neutral');
        $(pieButtonId).addClass('k-state-active');
    } else {
        chart.options.series[0].type = "column";
        $(pieButtonId).removeClass('k-state-active');
        $(pieButtonId).addClass('wv-neutral');

        $(columnButtonId).removeClass('wv-neutral');
        $(columnButtonId).addClass('k-state-active');

        chart.options.series[0].type = "column";
        //chart.options.axisDefaults.majorGridLines.visible = false;
        chart.options.valueAxis.majorGridLines.visible = false;
        chart.options.categoryAxis.majorGridLines.visible = false;

        chart.options.valueAxis.visible = false;
        //        chart.options.seriesColors = chartColors;        
        //console.log(chart.options.seriesColors);
        chart.refresh();
    }

    chart.refresh();
}

$("#dashboardOne").kendoPanelBar({
}).data("kendoPanelBar");
$("#dashboardTwo").kendoPanelBar({
}).data("kendoPanelBar");
$("#dashboardThree").kendoPanelBar({
}).data("kendoPanelBar");

//$("#pendingDataGrid").kendoGrid({
//    sortable: true,
//    autoSizeColumns: true,
//    columns: [
//        { field: "Category", title: "Vendor", attributes: { style: "text-align: left;" }, footerTemplate: "<div style='text-align: left;'>Total</div>" },
//        { field: "SubCategory", title: "Type", attributes: { style: "text-align: left;" } },
//        //{ field: "count", title: "Count" },
//        {
//            field: "Amount", title: "Total Amount", template: "#: kendo.toString(Amount, 'c0') #", footerTemplate: "<div style='text-align: right;'>#: kendo.toString(sum, 'c0') #</div>",
//            attributes: { style: "text-align: right;" }
//        }
//    ],
//    dataSource: GetChartData(3),
//    scrollable: false,
//    dataBound: function (e) {
//        let rows = e.sender.tbody.children();
//
//        for (let i = 0; i < rows.length; i++) {
//            let row = $(rows[i]);
//            let dataItem = e.sender.dataItem(row)
//
//            if (dataItem.name == "Totals") {
//                row.addClass("row-totals");
//            }
//        }
//    }
//});

function GetClients() {

    let data = EUFilter;

    $.ajax({
        type: "Get",
        url: "Financial/GetClients",
        dataType: "json",
        data: data,
        success: function (response) {

            var clients = response;
            var grid = $("#chartgridClient").data("kendoGrid");

            //console.log(clients[0]);
            var j = 1;

            for (let i = 0; i < clients.length; i++) {
                $("#chartgridClient th[data-field=Client" + j + "] ").html(clients[i].Client);
                j++;
            }

            if (clients.length === 1) {
                grid.showColumn(1);
                grid.hideColumn(2);
                grid.hideColumn(3);
                grid.hideColumn(4);
                grid.hideColumn(5);
                grid.hideColumn(6);
                grid.hideColumn(7);
                grid.hideColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 2) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.hideColumn(3);
                grid.hideColumn(4);
                grid.hideColumn(5);
                grid.hideColumn(6);
                grid.hideColumn(7);
                grid.hideColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 3) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.hideColumn(4);
                grid.hideColumn(5);
                grid.hideColumn(6);
                grid.hideColumn(7);
                grid.hideColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 4) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.showColumn(4);
                grid.hideColumn(5);
                grid.hideColumn(6);
                grid.hideColumn(7);
                grid.hideColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 5) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.showColumn(4);
                grid.showColumn(5);
                grid.hideColumn(6);
                grid.hideColumn(7);
                grid.hideColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 6) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.showColumn(4);
                grid.showColumn(5);
                grid.showColumn(6);
                grid.hideColumn(7);
                grid.hideColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 7) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.showColumn(4);
                grid.showColumn(5);
                grid.showColumn(6);
                grid.showColumn(7);
                grid.hideColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 8) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.showColumn(4);
                grid.showColumn(5);
                grid.showColumn(6);
                grid.showColumn(7);
                grid.showColumn(8);
                grid.hideColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 9) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.showColumn(4);
                grid.showColumn(5);
                grid.showColumn(6);
                grid.showColumn(7);
                grid.showColumn(8);
                grid.showColumn(9);
                grid.hideColumn(10);

            }

            if (clients.length === 10) {
                grid.showColumn(1);
                grid.showColumn(2);
                grid.showColumn(3);
                grid.showColumn(4);
                grid.showColumn(5);
                grid.showColumn(6);
                grid.showColumn(7);
                grid.showColumn(8);
                grid.showColumn(9);
                grid.showColumn(10);

            }


            //$("#chartgridClient th[data-field=Client2] ").html(clients[1].Client);
            //$("#chartgridClient th[data-field=Client3] ").html(clients[2].Client);
            //$("#chartgridClient th[data-field=Client4] ").html(clients[3].Client);
            //$("#chartgridClient th[data-field=Client5] ").html(clients[4].Client);
            //$("#chartgridClient th[data-field=Client6] ").html(clients[5].Client);
            //$("#chartgridClient th[data-field=Client7] ").html(clients[6].Client);
            //$("#chartgridClient th[data-field=Client8] ").html(clients[7].Client);
            //$("#chartgridClient th[data-field=Client9] ").html(clients[8].Client);
            //$("#chartgridClient th[data-field=Client10] ").html(clients[9].Client);

        },
        error: function (err) {
            showKendoAlert(err);
        }
    });
}

function legendTemplate(dataItem) {
    labelDisplay = '';
    labelDisplay = `<span style='background-color:${dataItem.CategoryColor};opacity:0.7;border-radius: 6px;'>${dataItem.Category}</span>`;
    //                                        <td></td>
    //<td style="text-align:left;"><span style="margin-left:5px;">In-House Check</span></td>
    //console.log(labelDisplay);
    return labelDisplay;
}

function SetDateFilters() {
    let currentDate = new Date();
    let startDate = "";
    let dueDate = "";

    var date = new Date();
    var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);

    let urlParms = new URLSearchParams(window.location.search);

    if (urlParms.has('bm')) {
        _fromBookmarkFlagFD = true;
    } else {
        _fromBookmarkFlagFD = false;
    }

    if (urlParms.get("year") != null) {
        EUFilter.FromYear = parseInt(urlParms.get("year"));
        EUFilter.ToYear = parseInt(urlParms.get("year"));
    }

    if (urlParms.get("month") != null) {
        EUFilter.FromMonth = parseInt(urlParms.get("month"));
        EUFilter.ToMonth = parseInt(urlParms.get("month"));
    }

    if (_fromBookmarkFlagFD === false) {
        EUFilter.FromMonth = firstDay.getMonth() + 1;
        EUFilter.FromYear = firstDay.getFullYear();
        EUFilter.ToMonth = firstDay.getMonth() + 1;
        EUFilter.ToYear = firstDay.getFullYear();
    }

    if ($("#Year1Button").text() === EUFilter.FromYear.toString()) {
        $("#Year1Button").addClass("k-state-active");
    }
    if ($("#Year2Button").text() === EUFilter.FromYear.toString()) {
        $("#Year2Button").addClass("k-state-active");
    }
    if ($("#Year3Button").text() === EUFilter.FromYear.toString()) {
        $("#Year3Button").addClass("k-state-active");
    }


    if (EUFilter.FromMonth === 1) {
        $("#JanButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 2) {
        $("#FebButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 3) {
        $("#MarButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 4) {
        $("#AprButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 5) {
        $("#MayButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 6) {
        $("#JunButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 7) {
        $("#JulButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 8) {
        $("#AugButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 9) {
        $("#SepButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 10) {
        $("#OctButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 11) {
        $("#NovButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 12) {
        $("#DecButton").addClass("k-state-active");
    }

}

function manageModuleViews(operation) {
    _activeView = operation;

    $("#dashboardButton").removeClass("k-state-active");
    $("#managePaymentsButton").removeClass("k-state-active");
    $("#manageVCCsButton").removeClass("k-state-active");
    $("#outstandingButton").removeClass("k-state-active");
    $("#completedButton").removeClass("k-state-active");

    switch (operation) {
        case "dashboard":
            LoadDashboardView();
            $("#payments-dashboard").show();
            $("#dashboardButton").addClass("k-state-active");

            //$("#manage-payments").hide();
            //$("#manage-virtual-cards").hide();
            //$("#payments-outstanding").hide();
            //$("#payments-completed").hide();
            break;
        case "paymentManager":
            LoadManagePaymentsView();
            $("#manage-payments").show();
            $("#managePaymentsButton").addClass("k-state-active");

            //$("#payments-dashboard").hide();            
            //$("#manage-virtual-cards").hide();
            //$("#payments-outstanding").hide();
            //$("#payments-completed").hide();
            break;
        case "vcManager":
            LoadManageVCCView();
            $("#manage-virtual-cards").show();
            $("#manageVCCsButton").addClass("k-state-active");

            $("#manage-payments").hide();
            $("#payments-dashboard").hide();
            $("#payments-outstanding").hide();
            $("#payments-completed").hide();
            break;
        case "outstanding":
            LoadOutstandingApprovalsView();
            $("#payments-outstanding").show();
            $("#outstandingButton").addClass("k-state-active");

            $("#manage-payments").hide();
            $("#payments-dashboard").hide();
            $("#manage-virtual-cards").hide();
            $("#payments-completed").hide();
            break;
        case "completed":
            LoadCompletedBatchesView();
            $("#payments-completed").show();
            $("#completedButton").addClass("k-state-active");

            $("#manage-payments").hide();
            $("#payments-dashboard").hide();
            $("#manage-virtual-cards").hide();
            $("#payments-outstanding").hide();
            break;
    }

}


//Top grids
function LoadUserGridView() {

    createGridDataSource();
    CreateFinancialViewGrid();
    //GenerateColumnDetailSettings();

    EUFilter.Page = 1;

    //if (EUFilter.InitialLoadFlag) {
    let grid = $("#monthgrid").data("kendoGrid");
    grid.setDataSource(grid.dataSource);
    grid.dataSource.read();
    //}

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    $("#monthgrid th[data-field=Category]").html(GetMonthName(EUFilter.FromMonth) + " " + EUFilter.FromYear);
    $("#monthgrid th[data-field=MTD]").html(GetMonthName(EUFilter.FromMonth) + " " + prioryear);

}

function LoadUserGridViewYTD() {

    createGridDataSourceYTD();
    CreateFinancialViewGridYTD();
    //GenerateColumnDetailSettings();

    EUFilter.Page = 2;

    kendo.ui.progress($("#TopToolBar"), true);

    //if (EUFilter.InitialLoadFlag) {
    let grid = $("#ytdgrid").data("kendoGrid");
    grid.setDataSource(grid.dataSource);
    //grid.dataSource.read();
    //}

    grid.dataSource.read().then(() => {
       // kendo.ui.progress($("#TopToolBar"), false);
    });

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    $("#ytdgrid th[data-field=Category] ").html(EUFilter.FromYear + " YTD");
    $("#ytdgrid th[data-field=MTD] ").html("YTD " + prioryear);

}

function CreateFinancialViewGrid() {
    let monthgrid = $("#monthgrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSource,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        //filter: function (e) {
        //    onFilterChange(e);
        //},
        columns: [
            { field: "Category", title: "", width: 100, headerAttributes: { style: "text-align: center" } },
            { field: "Actual", title: "Actual", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "Budget", title: "Budget", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "VariancePercent", title: "Variance", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "MTD", title: "MTD", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "YOYPercent", title: "% YOY", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" }, template: yoytemplate }
        ]
    });

    //SetupAdditionalGridFeatures();

    return monthgrid;
}

function yoytemplate(dataItem) {

    let yoy = '';

    if (dataItem.YOYPercent !== undefined) {
        if (dataItem.MTD === 0) {
            yoy = 'n/a';
            return yoy;
        } else {
            return dataItem.YOYPercent;
        }

    }

    //turn kendo.toString(BillablePercentGoal, 'n');

}

function CreateFinancialViewGridYTD() {
    let ytdgrid = $("#ytdgrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSourceYTD,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        //filter: function (e) {
        //    onFilterChange(e);
        //},
        columns: [
            { field: "Category", title: "", width: 100, headerAttributes: { style: "text-align: center" } },
            { field: "Actual", title: "Actual", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "Budget", title: "Budget", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "VariancePercent", title: "Variance", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "MTD", title: "MTD", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: "YOYPercent", title: "% YOY", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" }, template: yoytemplate }
        ]
    });

    //SetupAdditionalGridFeatures();

    return ytdgrid;
}

//Month
function LoadUserChart() {

    EUFilter.Page = 3;

    createChartDataSource();
    CreateFinancialChart();

    var chart = $('#chartMonth').data('kendoChart');
    chart.options.title.text = EUFilter.FromYear + " Monthly Financial Performance";
    chart.refresh();

    //chart.dataSource.read().then(() => {
    //    kendo.ui.progress($("#TopToolBar"), false);
    //    chart.refresh();
    //});
}

function CreateFinancialChart() {
    let chart = $("#chartMonth").kendoChart({
        title: {
            text: "Performance"
        },
        dataSource: FinancialDataSourceChart,
        //tooltip: {
        //    visible: true,
        //    template: "#: dataItem.Category #: #: dataItem.Count #, #: kendo.toString(dataItem.Amount, 'c0') #"
        //},
        //legend: {
        //    visible: false
        //},
        valueAxis: [{
            labels: {
                format: "{0:N}"
            }
        }],
        series: [{
            type: "column",
            name: "Gross Income",
            field: "Revenue",
            color: "#337ab7",
            opacity: .7,
            gap: .5
        }, {
            type: "column",
            name: "Expenses",
            field: "Expenses",
            color: "#5cb85c",
            opacity: .7,
            gap: .5
        }, {
            type: "column",
            name: "Net Income",
            field: "NetIncome",
            color: "#f0ad4e",
            opacity: .7,
            gap: .5
        }, {
            type: "line",
            markers: {
                visible: false
            },
            field: "Profit",
            labels: {
                visible: false
            }
        }],
        margin: 0,
        //seriesClick: function (e) {
        //    let gridData = $("#pendingDataGrid").data("kendoGrid").dataSource;
        //    let filter = [];

        //    filter.push({ field: "SubCategory", operator: "eq", value: e.dataItem.Category });
        //    gridData.filter(filter);

        //    $("#pendingGridTitle").html(e.dataItem.Category + " Vendors");
        //    $("#resetGrid").show();
        //},
        categoryAxis: {
            field: "Month",
            majorGridLines: {
                visible: false
            }
        },
        width: 500
    });

    return chart;

}

function LoadUserChartGridView() {

    createChartGridDataSource();
    CreateFinancialViewChartGrid();
    //GenerateColumnDetailSettings();

    EUFilter.Page = 4;

    //if (EUFilter.InitialLoadFlag) {
    let grid = $("#chartgrid").data("kendoGrid");
    grid.setDataSource(grid.dataSource);
    //grid.dataSource.read();

    grid.dataSource.read().then(() => {
        kendo.ui.progress($("#TopToolBar"), false);
    });
    //}

    $("#chartgrid th[data-field=Category] ").html("");

}

function CreateFinancialViewChartGrid() {
    let chartgrid = $("#chartgrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSourceChartGrid,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        //filter: function (e) {
        //    onFilterChange(e);
        //},
        columns: [
            { field: "Category", title: "", width: 100, headerAttributes: { style: "text-align: center" } },
            { field: 'January', title: "January", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Feburary', title: "Feburary", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'March', title: "March", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'April', title: "April", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'May', title: "May", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'June', title: "June", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'July', title: "July", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'August', title: "August", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'September', title: "September", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'October', title: "October", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'November', title: "November", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'December', title: "December", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } }
        ]
    });

    //SetupAdditionalGridFeatures();

    return chartgrid;
}

//YTD
function LoadUserChartYTD() {

    EUFilter.Page = 5;

    createChartYTDDataSource();
    CreateFinancialChartYTD();

    var chart = $('#chartytd').data('kendoChart');
    chart.options.title.text = "YTD Financial Performance";
    chart.refresh();
}

function CreateFinancialChartYTD() {
    let chart = $("#chartytd").kendoChart({
        title: {
            text: "YTD Financial Performance"
        },
        dataSource: FinancialDataSourceChartYTD,
        //tooltip: {
        //    visible: true,
        //    template: "#: dataItem.Category #: #: dataItem.Count #, #: kendo.toString(dataItem.Amount, 'c0') #"
        //},
        //legend: {
        //    visible: false
        //},
        valueAxis: [{
            labels: {
                format: "{0:N}"
            }
        }],
        series: [{
            name: "Gross Income",
            field: "Revenue",
            color: "#337ab7",
            opacity: .7,
            gap: .5
        }, {
            name: "Expenses",
            field: "Expenses",
            color: "#5cb85c",
            opacity: .7,
            gap: .5
        }, {
            name: "Net Income",
            field: "Income",
            color: "#f0ad4e",
            opacity: .7,
            gap: .5
        }],
        margin: 0,
        //seriesClick: function (e) {
        //    let gridData = $("#pendingDataGrid").data("kendoGrid").dataSource;
        //    let filter = [];

        //    filter.push({ field: "SubCategory", operator: "eq", value: e.dataItem.Category });
        //    gridData.filter(filter);

        //    $("#pendingGridTitle").html(e.dataItem.Category + " Vendors");
        //    $("#resetGrid").show();
        //},
        categoryAxis: {
            field: "Year",
            majorGridLines: {
                visible: false
            }
        },
        width: 500
    });

    return chart;

}

function LoadUserChartGridViewYTD() {

    createChartGridYTDDataSource();
    CreateFinancialViewChartGridYTD();
    //GenerateColumnDetailSettings();

    EUFilter.Page = 6;

    //if (EUFilter.InitialLoadFlag) {
    let grid = $("#chartgridytd").data("kendoGrid");
    grid.setDataSource(grid.dataSource);
    grid.dataSource.read();
    //}

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    $("#chartgridytd th[data-field=Category] ").html("");

    $("#chartgridytd th[data-field=Year1] ").html(prioryear);
    $("#chartgridytd th[data-field=Year2] ").html(EUFilter.ToYear);

}

function CreateFinancialViewChartGridYTD() {
    let chartgrid = $("#chartgridytd").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSourceChartGridYTD,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        //filter: function (e) {
        //    onFilterChange(e);
        //},
        columns: [
            { field: "Category", title: "", width: 100, headerAttributes: { style: "text-align: center" } },
            { field: 'Year1', title: "Year1", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Year2', title: "Year2", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } }
        ]
    });

    //SetupAdditionalGridFeatures();

    return chartgrid;
}

//Client
function LoadUserChartClient() {

    EUFilter.Page = 7;

    createChartClientDataSource();
    CreateFinancialChartClient();

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    var chart = $('#chartClient').data('kendoChart');
    chart.options.title.text = "Top 10 Clients: " + prioryear + " vs " + EUFilter.FromYear + " - Sales";
    chart.refresh();
}

function CreateFinancialChartClient() {

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    let chart = $("#chartClient").kendoChart({
        title: {
            text: "Top 10"
        },
        dataSource: FinancialDataSourceChartClient,
        //tooltip: {
        //    visible: true,
        //    template: "#: dataItem.Category #: #: dataItem.Count #, #: kendo.toString(dataItem.Amount, 'c0') #"
        //},
        //legend: {
        //    visible: false
        //},
        valueAxis: [{
            labels: {
                format: "{0:N}"
            }
        }],
        seriesDefaults: {
            type: "column"
        },
        series: [{
            name: prioryear,
            field: "Year1",
            color: "#337ab7",
            opacity: .7,
            gap: .5
        }, {
            name: EUFilter.FromYear,
            field: "Year2",
            color: "#5cb85c",
            opacity: .7,
            gap: .5
        }],
        margin: 0,
        //seriesClick: function (e) {
        //    let gridData = $("#pendingDataGrid").data("kendoGrid").dataSource;
        //    let filter = [];

        //    filter.push({ field: "SubCategory", operator: "eq", value: e.dataItem.Category });
        //    gridData.filter(filter);

        //    $("#pendingGridTitle").html(e.dataItem.Category + " Vendors");
        //    $("#resetGrid").show();
        //},
        categoryAxis: {
            field: "Client",
            majorGridLines: {
                visible: false
            },
            labels: {
                rotation: {
                    angle: 25
                }
            }
        },
        width: 500
    });

    return chart;

}

function labelsTemplate(e) {
    //sets every other label on a new line based on the DataItem's index
    var ds = $("#chartClient").data("kendoChart").dataSource;
    var index = ds.indexOf(e.dataItem);
    var label = index % 2 !== 0 ? " \n" : "";
    label += e.value;

    return label;
}

function LoadUserChartGridViewClient() {

    createChartGridClientDataSource();
    CreateFinancialViewChartGridClient();
    //GenerateColumnDetailSettings();

    EUFilter.Page = 8;

    //if (EUFilter.InitialLoadFlag) {
    let grid = $("#chartgridClient").data("kendoGrid");
    grid.setDataSource(grid.dataSource);
    grid.dataSource.read();
    //}    

    GetClients();

}

function CreateFinancialViewChartGridClient() {
    let chartgridClient = $("#chartgridClient").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSourceChartGridClient,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        //columns: generateColumns(FinancialDataSourceChartClient[0])
        columns: [
            { field: "Year", title: "", width: 100, headerAttributes: { style: "text-align: center" } },
            { field: 'Client1', title: "Client1", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client2', title: "Client2", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client3', title: "Client3", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client4', title: "Client4", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client5', title: "Client5", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client6', title: "Client6", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client7', title: "Client7", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client8', title: "Client8", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client9', title: "Client9", format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Client10', title: "Client10", format: "{0:n2}", headerAttributes: { style: "text-align: center" } }
        ]
    });

    //SetupAdditionalGridFeatures();

    return chartgridClient;
}

function generateColumns(firstRow) {
    var colums = [];

    for (var property in firstRow) {
        var col = {
            field: property,
            title: property,
            width: 100
        }
        colums.push(col);
    }

    return colums;
}



//Billable
function LoadUserBillableGrid() {

    EUFilter.Page = 9;

    setTimeout(function () {

        createBilliableGridDataSource();
        CreateFinancialViewBillableGrid();

        let grid = $("#billablegrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

    }, 2000);

    //$("#billablegrid th[data-field=January]").html("Title");

}

function CreateFinancialViewBillableGrid() {
    let monthgrid = $("#billablegrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSourceBillableGrid,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        //filter: function (e) {
        //    onFilterChange(e);
        //},
        columns: [
            {
                title: "Average Billable Performance",
                columns: [
                    { field: 'January', title: "Jan", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'Feburary', title: "Feb", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'March', title: "Mar", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'April', title: "Apr", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'May', title: "May", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'June', title: "Jun", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'July', title: "Jul", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'August', title: "Aug", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'September', title: "Sep", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'October', title: "Oct", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'November', title: "Nov", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
                    { field: 'December', title: "Dec", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" } }
                ]
            }

        ]
    });

    //SetupAdditionalGridFeatures();

    return monthgrid;
}

//New Business
function LoadUserNewBusinessGrid() {

    EUFilter.Page = 10;

    createNewBusinessDataSource();
    CreateFinancialViewNewBusinessGrid();

    let grid = $("#newbusinessgrid").data("kendoGrid");
    grid.setDataSource(grid.dataSource);
    grid.dataSource.read();

    $("#newbusinessgrid th[data-field=Client] ").html("Clients won in " + GetMonthName(EUFilter.FromMonth));

}

function CreateFinancialViewNewBusinessGrid() {
    let monthgrid = $("#newbusinessgrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        title: "",
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSourceNewBusinessGrid,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        noRecords: true,
        //noRecords: {
        //    template: "No records available."
        //},
        //filter: function (e) {
        //    onFilterChange(e);
        //},
        columns: [
            { field: "Client", title: "Clients won this month", width: 300, headerAttributes: { style: "text-align: center" } },
            { field: 'Amount', title: "Amount", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" }, hidden: true }
        ]
    });

    //SetupAdditionalGridFeatures();

    return monthgrid;
}

//Grow
function LoadUserGrowGrid() {

    EUFilter.Page = 11;

    createGrowGridDataSource();
    CreateFinancialViewGrowGrid();

    let grid = $("#growgrid").data("kendoGrid");
    grid.setDataSource(grid.dataSource);
    grid.dataSource.read();

    //$("#billablegrid th[data-field=January]").html("Title");

}

function CreateFinancialViewGrowGrid() {
    let monthgrid = $("#growgrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        title: "",
        //toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: FinancialDataSourceGrowGrid,
        groupable: {
            enabled: false
        },
        sortable: false,
        //pageable: false,
        //editable: "incell",
        resizable: true,
        filterable: false,
        //filter: function (e) {
        //    onFilterChange(e);
        //},
        columns: [
            { field: "Client", title: "Top 3 Fastest Growers", width: 300, headerAttributes: { style: "text-align: center" } },
            { field: 'YOY', title: "YOY Sales Gain", width: 100, format: "{0:n2}", headerAttributes: { style: "text-align: center" } },
            { field: 'Growth', title: "% Growth", width: 50, format: "{0:n2}", headerAttributes: { style: "text-align: center" }, template: growthtemplate }
        ]
    });

    //SetupAdditionalGridFeatures();

    return monthgrid;
}

function growthtemplate(dataItem) {

    let yoy = '';

    if (dataItem.Growth !== undefined) {
        if (dataItem.Growth === 0) {
            yoy = 'n/a';
            return yoy;
        } else {
            return dataItem.Growth;
        }

    }

    //turn kendo.toString(BillablePercentGoal, 'n');

}

//toolbar
function onYear1Click(year) {

    EUFilter.FromYear = year;
    EUFilter.ToYear = year;

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    $("#Year1Button").addClass("k-state-active");
    $("#Year2Button").removeClass("k-state-active");
    $("#Year3Button").removeClass("k-state-active");

    kendo.ui.progress($("#TopToolBar"), true);

    setTimeout(function () {

        EUFilter.Page = 1;
        let DataGrid = $("#monthgrid").data("kendoGrid");
        //DataGrid.setDataSource(DataGrid.dataSource);
        DataGrid.dataSource.read();

        //DataGrid.dataSource.read().then(() => {
        //    kendo.ui.progress($("#TopToolBar"), false);
        //});

        $("#monthgrid th[data-field=Category] ").html(GetMonthName(EUFilter.FromMonth) + " " + EUFilter.FromYear);
        $("#monthgrid th[data-field=MTD] ").html(GetMonthName(EUFilter.FromMonth) + " " + prioryear);

    }, 0);    

    setTimeout(function () {

        EUFilter.Page = 2;
        let DataGrid2 = $("#ytdgrid").data("kendoGrid");
        //DataGrid2.setDataSource(DataGrid2.dataSource);
        //DataGrid2.dataSource.read();

        DataGrid2.dataSource.read().then(() => {
           //kendo.ui.progress($("#TopToolBar"), false);
        });

        $("#ytdgrid th[data-field=Category] ").html(EUFilter.FromYear + " YTD");
        $("#ytdgrid th[data-field=MTD] ").html("YTD " + prioryear);
    }, 0);

    setTimeout(function () {        

        EUFilter.Page = 3;
        CreateFinancialChart();
        var chart = $("#chartMonth").data("kendoChart");

        kendo.ui.progress($("#chartMonth"), true);

        chart.options.title.text = EUFilter.FromYear + " Monthly Financial Performance";
        //chart.dataSource.read();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartMonth"), false);
            kendo.ui.progress($("#TopToolBar"), false);
            chart.refresh();
        });

        
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 4;
        let grid = $("#chartgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        //grid.dataSource.read();

        grid.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

        $("#chartgrid th[data-field=Category] ").html("");

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 5;

        var chart = $('#chartytd').data('kendoChart');

        kendo.ui.progress($("#chartytd"), true);

        chart.options.title.text = "YTD Financial Performance";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartytd"), false);
            chart.refresh();
        });

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 6;

        let grid = $("#chartgridytd").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        //grid.dataSource.read();

        grid.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        $("#chartgridytd th[data-field=Category] ").html("");

        $("#chartgridytd th[data-field=Year1] ").html(prioryear);
        $("#chartgridytd th[data-field=Year2] ").html(EUFilter.ToYear);

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 7;

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        CreateFinancialChartClient();

        var chart = $('#chartClient').data('kendoChart');

        kendo.ui.progress($("#chartClient"), true);

        chart.options.title.text = "Top 10 Clients: " + prioryear + " vs " + EUFilter.FromYear + " - Sales";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartClient"), false);
            chart.refresh();
        });

        setTimeout(function () {

            chart.options.series[0].name = prioryear;
            chart.options.series[1].name = EUFilter.ToYear;

        }, 300);

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 8;
        let grid = $("#chartgridClient").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        //grid.dataSource.read();

        grid.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

        GetClients();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 9;

        let grid = $("#billablegrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        //grid.dataSource.read();

        grid.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 10;

        let grid = $("#newbusinessgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        //grid.dataSource.read();

        grid.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

        $("#newbusinessgrid th[data-field=Client] ").html("Clients won in " + GetMonthName(EUFilter.FromMonth));

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 11;

        let grid = $("#growgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        //grid.dataSource.read();

        grid.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

    }, 0);

    
}

function onYear2Click(year) {

    EUFilter.FromYear = year;
    EUFilter.ToYear = year;

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    $("#Year2Button").addClass("k-state-active");
    $("#Year1Button").removeClass("k-state-active");
    $("#Year3Button").removeClass("k-state-active");

    kendo.ui.progress($("#TopToolBar"), true);

    setTimeout(function () {

        EUFilter.Page = 1;
        let DataGrid = $("#monthgrid").data("kendoGrid");
        //DataGrid.setDataSource(DataGrid.dataSource);
        DataGrid.dataSource.read();

        $("#monthgrid th[data-field=Category] ").html(GetMonthName(EUFilter.FromMonth) + " " + EUFilter.FromYear);
        $("#monthgrid th[data-field=MTD] ").html(GetMonthName(EUFilter.FromMonth) + " " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 2;
        let DataGrid2 = $("#ytdgrid").data("kendoGrid");
        //DataGrid2.setDataSource(DataGrid2.dataSource);
        //DataGrid2.dataSource.read();

        DataGrid2.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

        $("#ytdgrid th[data-field=Category] ").html(EUFilter.FromYear + " YTD");
        $("#ytdgrid th[data-field=MTD] ").html("YTD " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 3;
        CreateFinancialChart();
        var chart = $("#chartMonth").data("kendoChart");

        kendo.ui.progress($("#chartMonth"), true);

        chart.options.title.text = EUFilter.FromYear + " Monthly Financial Performance";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartMonth"), false);
            kendo.ui.progress($("#TopToolBar"), false);
            chart.refresh();
        });
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 4;
        let grid = $("#chartgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#chartgrid th[data-field=Category] ").html("");

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 5;

        var chart = $('#chartytd').data('kendoChart');

        kendo.ui.progress($("#chartytd"), true);

        chart.options.title.text = "YTD Financial Performance";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartytd"), false);
            chart.refresh();
        });

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 6;

        let grid = $("#chartgridytd").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        $("#chartgridytd th[data-field=Category] ").html("");

        $("#chartgridytd th[data-field=Year1] ").html(prioryear);
        $("#chartgridytd th[data-field=Year2] ").html(EUFilter.ToYear);

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 7;

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        CreateFinancialChartClient();

        var chart = $('#chartClient').data('kendoChart');

        kendo.ui.progress($("#chartClient"), true);

        chart.options.title.text = "Top 10 Clients: " + prioryear + " vs " + EUFilter.FromYear + " - Sales";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartClient"), false);
            chart.refresh();
        });

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 8;
        let grid = $("#chartgridClient").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        GetClients();

    }, 0);

    //setTimeout(function () {

    //    EUFilter.Page = 9;

    //    let grid = $("#billablegrid").data("kendoGrid");
    //    grid.setDataSource(grid.dataSource);
    //    grid.dataSource.read();

    //}, 0);

    setTimeout(function () {

        EUFilter.Page = 10;

        let grid = $("#newbusinessgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#newbusinessgrid th[data-field=Client] ").html("Clients won in " + GetMonthName(EUFilter.FromMonth));

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 11;

        let grid = $("#growgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

    }, 0);


}

function onYear3Click(year) {

    EUFilter.FromYear = year;
    EUFilter.ToYear = year;

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    $("#Year3Button").addClass("k-state-active");
    $("#Year1Button").removeClass("k-state-active");
    $("#Year2Button").removeClass("k-state-active");

    kendo.ui.progress($("#TopToolBar"), true);

    setTimeout(function () {

        EUFilter.Page = 1;
        let DataGrid = $("#monthgrid").data("kendoGrid");
        //DataGrid.setDataSource(DataGrid.dataSource);
        DataGrid.dataSource.read();

        $("#monthgrid th[data-field=Category] ").html(GetMonthName(EUFilter.FromMonth) + " " + EUFilter.FromYear);
        $("#monthgrid th[data-field=MTD] ").html(GetMonthName(EUFilter.FromMonth) + " " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 2;
        let DataGrid2 = $("#ytdgrid").data("kendoGrid");
        //DataGrid2.setDataSource(DataGrid2.dataSource);
        //DataGrid2.dataSource.read();

        DataGrid2.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

        $("#ytdgrid th[data-field=Category] ").html(EUFilter.FromYear + " YTD");
        $("#ytdgrid th[data-field=MTD] ").html("YTD " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 3;
        CreateFinancialChart();
        var chart = $("#chartMonth").data("kendoChart");

        kendo.ui.progress($("#chartMonth"), true);

        chart.options.title.text = EUFilter.FromYear + " Monthly Financial Performance";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartMonth"), false);
            kendo.ui.progress($("#TopToolBar"), false);
            chart.refresh();
        });
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 4;
        let grid = $("#chartgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#chartgrid th[data-field=Category] ").html("");

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 5;

        var chart = $('#chartytd').data('kendoChart');

        kendo.ui.progress($("#chartytd"), true);

        chart.options.title.text = "YTD Financial Performance";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartytd"), false);
            chart.refresh();
        });

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 6;

        let grid = $("#chartgridytd").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        $("#chartgridytd th[data-field=Category] ").html("");

        $("#chartgridytd th[data-field=Year1] ").html(prioryear);
        $("#chartgridytd th[data-field=Year2] ").html(EUFilter.ToYear);

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 7;

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        CreateFinancialChartClient();

        var chart = $('#chartClient').data('kendoChart');

        kendo.ui.progress($("#chartClient"), true);

        chart.options.title.text = "Top 10 Clients: " + prioryear + " vs " + EUFilter.FromYear + " - Sales";
        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartClient"), false);
            chart.refresh();
        });

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 8;
        let grid = $("#chartgridClient").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        GetClients();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 9;

        let grid = $("#billablegrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 10;

        let grid = $("#newbusinessgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#newbusinessgrid th[data-field=Client] ").html("Clients won in " + GetMonthName(EUFilter.FromMonth));

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 11;

        let grid = $("#growgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

    }, 0);


}

function LoadGrids() {
}

function onMonthClick(month) {

    RefreshGridByMonth(month);

}

function RefreshGridByMonth(month) {

    EUFilter.FromMonth = month;
    EUFilter.ToMonth = month;

    kendo.ui.progress($("#TopToolBar"), true);

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    setTimeout(function () {

        EUFilter.Page = 1;
        let DataGrid = $("#monthgrid").data("kendoGrid");
        //DataGrid.setDataSource(DataGrid.dataSource);
        DataGrid.dataSource.read();

        $("#monthgrid th[data-field=Category] ").html(GetMonthName(EUFilter.FromMonth) + " " + EUFilter.FromYear);
        $("#monthgrid th[data-field=MTD] ").html(GetMonthName(EUFilter.FromMonth) + " " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 2;
        let DataGrid2 = $("#ytdgrid").data("kendoGrid");
        //DataGrid2.setDataSource(DataGrid2.dataSource);
        //DataGrid2.dataSource.read();

        DataGrid2.dataSource.read().then(() => {
            //kendo.ui.progress($("#TopToolBar"), false);
        });

        $("#ytdgrid th[data-field=Category] ").html(EUFilter.FromYear + " YTD");
        $("#ytdgrid th[data-field=MTD] ").html("YTD " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 3;
        var chart = $("#chartMonth").data("kendoChart");

        kendo.ui.progress($("#chartMonth"), true);

        //chart.dataSource.read();
        //chart.refresh();

        chart.dataSource.read().then(() => {
            kendo.ui.progress($("#chartMonth"), false);
            kendo.ui.progress($("#TopToolBar"), false);
            chart.refresh();
        });
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 4;
        let grid = $("#chartgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#chartgrid th[data-field=Category] ").html("");

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 5;

        var chart = $('#chartytd').data('kendoChart');
        chart.options.title.text = "YTD Financial Performance";
        chart.dataSource.read();
        chart.refresh();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 6;

        let grid = $("#chartgridytd").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        $("#chartgridytd th[data-field=Category] ").html("");

        $("#chartgridytd th[data-field=Year1] ").html(prioryear);
        $("#chartgridytd th[data-field=Year2] ").html(EUFilter.ToYear);

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 7;

        CreateFinancialChartClient();

        var chart = $('#chartClient').data('kendoChart');
        chart.options.title.text = "Top 10 Clients: " + prioryear + " vs " + EUFilter.FromYear + " - Sales";
        chart.dataSource.read();
        chart.refresh();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 8;
        let grid = $("#chartgridClient").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        GetClients();

    }, 0);

    //setTimeout(function () {

    //    EUFilter.Page = 9;

    //    let grid = $("#billablegrid").data("kendoGrid");
    //    grid.setDataSource(grid.dataSource);
    //    grid.dataSource.read();

    //}, 0);

    setTimeout(function () {

        EUFilter.Page = 10;

        let grid = $("#newbusinessgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#newbusinessgrid th[data-field=Client] ").html("Clients won in " + GetMonthName(EUFilter.FromMonth));

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 11;

        let grid = $("#growgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

    }, 0);



    $("#JanButton").removeClass("k-state-active");
    $("#FebButton").removeClass("k-state-active");
    $("#MarButton").removeClass("k-state-active");
    $("#AprButton").removeClass("k-state-active");
    $("#MayButton").removeClass("k-state-active");
    $("#JunButton").removeClass("k-state-active");
    $("#JulButton").removeClass("k-state-active");
    $("#AugButton").removeClass("k-state-active");
    $("#SepButton").removeClass("k-state-active");
    $("#OctButton").removeClass("k-state-active");
    $("#NovButton").removeClass("k-state-active");
    $("#DecButton").removeClass("k-state-active");

    if (month === 1) {
        $("#JanButton").addClass("k-state-active");
    } else if (month === 2) {
        $("#FebButton").addClass("k-state-active");
    } else if (month === 3) {
        $("#MarButton").addClass("k-state-active");
    } else if (month === 4) {
        $("#AprButton").addClass("k-state-active");
    } else if (month === 5) {
        $("#MayButton").addClass("k-state-active");
    } else if (month === 6) {
        $("#JunButton").addClass("k-state-active");
    } else if (month === 7) {
        $("#JulButton").addClass("k-state-active");
    } else if (month === 8) {
        $("#AugButton").addClass("k-state-active");
    } else if (month === 9) {
        $("#SepButton").addClass("k-state-active");
    } else if (month === 10) {
        $("#OctButton").addClass("k-state-active");
    } else if (month === 11) {
        $("#NovButton").addClass("k-state-active");
    } else if (month === 12) {
        $("#DecButton").addClass("k-state-active");
    }
}

function RefreshGrid() {

    var prioryear = parseInt(EUFilter.FromYear) - 1;

    setTimeout(function () {

        EUFilter.Page = 1;
        let DataGrid = $("#monthgrid").data("kendoGrid");
        //DataGrid.setDataSource(DataGrid.dataSource);
        DataGrid.dataSource.read();

        $("#monthgrid th[data-field=Category] ").html(GetMonthName(EUFilter.FromMonth) + " " + EUFilter.FromYear);
        $("#monthgrid th[data-field=MTD] ").html(GetMonthName(EUFilter.FromMonth) + " " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 2;
        let DataGrid2 = $("#ytdgrid").data("kendoGrid");
        //DataGrid2.setDataSource(DataGrid2.dataSource);
        DataGrid2.dataSource.read();

        $("#ytdgrid th[data-field=Category] ").html(EUFilter.FromYear + " YTD");
        $("#ytdgrid th[data-field=MTD] ").html("YTD " + prioryear);
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 3;
        var chart = $("#chartMonth").data("kendoChart");
        chart.dataSource.read();
        chart.refresh();
    }, 0);

    setTimeout(function () {

        EUFilter.Page = 4;
        let grid = $("#chartgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#chartgrid th[data-field=Category] ").html("");

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 5;

        var chart = $('#chartytd').data('kendoChart');
        chart.options.title.text = "YTD Financial Performance";
        chart.dataSource.read();
        chart.refresh();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 6;

        let grid = $("#chartgridytd").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        var prioryear = parseInt(EUFilter.FromYear) - 1;

        $("#chartgridytd th[data-field=Category] ").html("");

        $("#chartgridytd th[data-field=Year1] ").html(prioryear);
        $("#chartgridytd th[data-field=Year2] ").html(EUFilter.ToYear);

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 7;

        var chart = $('#chartClient').data('kendoChart');
        chart.dataSource.read();
        chart.options.title.text = "Top 10 Clients: " + prioryear + " vs " + EUFilter.FromYear + " - Sales";
        chart.refresh();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 8;
        let grid = $("#chartgridClient").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        GetClients();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 9;

        let grid = $("#billablegrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 10;

        let grid = $("#newbusinessgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

        $("#newbusinessgrid th[data-field=Client] ").html("Clients won in " + GetMonthName(EUFilter.FromMonth));

    }, 0);

    setTimeout(function () {

        EUFilter.Page = 11;

        let grid = $("#growgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();

    }, 0);



    //$("#JanButton").removeClass("k-state-active");
    //$("#FebButton").removeClass("k-state-active");
    //$("#MarButton").removeClass("k-state-active");
    //$("#AprButton").removeClass("k-state-active");
    //$("#MayButton").removeClass("k-state-active");
    //$("#JunButton").removeClass("k-state-active");
    //$("#JulButton").removeClass("k-state-active");
    //$("#AugButton").removeClass("k-state-active");
    //$("#SepButton").removeClass("k-state-active");
    //$("#OctButton").removeClass("k-state-active");
    //$("#NovButton").removeClass("k-state-active");
    //$("#DecButton").removeClass("k-state-active");

    //if (month === 1) {
    //    $("#JanButton").addClass("k-state-active");
    //} else if (month === 2) {
    //    $("#FebButton").addClass("k-state-active");
    //} else if (month === 3) {
    //    $("#MarButton").addClass("k-state-active");
    //} else if (month === 4) {
    //    $("#AprButton").addClass("k-state-active");
    //} else if (month === 5) {
    //    $("#MayButton").addClass("k-state-active");
    //} else if (month === 6) {
    //    $("#JunButton").addClass("k-state-active");
    //} else if (month === 7) {
    //    $("#JulButton").addClass("k-state-active");
    //} else if (month === 8) {
    //    $("#AugButton").addClass("k-state-active");
    //} else if (month === 9) {
    //    $("#SepButton").addClass("k-state-active");
    //} else if (month === 10) {
    //    $("#OctButton").addClass("k-state-active");
    //} else if (month === 11) {
    //    $("#NovButton").addClass("k-state-active");
    //} else if (month === 12) {
    //    $("#DecButton").addClass("k-state-active");
    //}

}

function GenerateColumnDetailSettings() {

    myColumns = new Array();

    myColumns.push({ field: "Category", title: "", filterable: { extra: false } });
    myColumns.push({ field: "Actual", title: "Actual", filterable: { extra: false } });
    myColumns.push({ field: "Budget", title: "Budget", filterable: { extra: false } });
    myColumns.push({ field: "VaricancePercent", title: "Variance", filterable: { extra: false } });
    myColumns.push({ field: "MTD", title: "MTD", filterable: { extra: false } });
    myColumns.push({ field: "YOYPercent", title: "% YOY", filterable: { extra: false } });




}

function GetMonthName(month) {

    if (month === 1) {
        return 'JAN';
    } else if (month === 2) {
        return 'FEB';
    } else if (month === 3) {
        return 'MAR';
    } else if (month === 4) {
        return 'APR';
    } else if (month === 5) {
        return 'MAY';
    } else if (month === 6) {
        return 'JUN';
    } else if (month === 7) {
        return 'JUL';
    } else if (month === 8) {
        return 'AUG';
    } else if (month === 9) {
        return 'SEP';
    } else if (month === 10) {
        return 'OCT';
    } else if (month === 11) {
        return 'NOV';
    } else if (month === 12) {
        return 'DEC';
    }


}

function bookmarkPage() {

    //let StartDatePicker = $("#startdate").data("kendoDatePicker");
    //let EndDatePicker = $("#duedate").data("kendoDatePicker");

    //if (StartDatePicker.value() !== null) {
    //    StartDate = StartDatePicker.value().toDateString();
    //}

    //if (EndDatePicker.value() !== null) {
    //    EndDate = EndDatePicker.value().toDateString();
    //}

    //if ($("#AugButton").data("button").options.selected) {
    //    Month = 8;
    //}

    let bookmark = {
        Month: EUFilter.FromMonth,
        Year: EUFilter.FromYear,
        GridSize: 5 //UserViewSettings.GridSize
    };

    $.ajax({
        type: "POST",
        data: bookmark,
        dataType: "json",
        url: 'Financial/BookmarkFinancialDashboard',
        success: function (data) {
            console.log(data.Success);
            if (data.Success) {
                showKendoAlert("Bookmark successfully added.");
            } else {
                showKendoAlert("Bookmark already exists.");
            }

        },
        error: function () {
            showKendoAlert("An error occurred while generating bookmark, please contact support.");
        }
    });
}
