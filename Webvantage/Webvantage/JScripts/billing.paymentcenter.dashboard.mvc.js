//var chartColors = ["#2196f3", "#2A579A", "#00BCD4", "#009688", "#94508C"];
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
    } else if (chartId == 3) {
        
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

$("#pendingDataGrid").kendoGrid({
    sortable: true,      
    autoSizeColumns: true,    
    columns: [
        { field: "Category", title: "Vendor", attributes: { style: "text-align: left;" }, footerTemplate: "<div style='text-align: left;'>Total</div>" },
        { field: "SubCategory", title: "Type", attributes: { style: "text-align: left;" } },
        //{ field: "count", title: "Count" },
        {
            field: "Amount", title: "Total Amount", template: "#: kendo.toString(Amount, 'c0') #", footerTemplate: "<div style='text-align: right;'>#: kendo.toString(sum, 'c0') #</div>",
            attributes: {style: "text-align: right;"} }
    ],
    dataSource: GetChartData(3),
    scrollable: false,
    dataBound: function (e) {
        let rows = e.sender.tbody.children();

        for (let i = 0; i < rows.length; i++) {
            let row = $(rows[i]);
            let dataItem = e.sender.dataItem(row)

            if (dataItem.name == "Totals") {
                row.addClass("row-totals");
            }
        }
    }
});

function GetChartData(ChartId) {    
    let ChartData = new kendo.data.DataSource({
        transport: {
            read: (e) => {
                $.ajax({
                    type: "GET",
                    url: "PaymentCenter/GetChartData?ChartID=" + ChartId,
                    dataType: 'json',
                    success: (results) => {                        
                        let x = chartColors.length;
                        let totalCount = 0;
                        let totalAmount = 0;

                        $.each(results, (i, e) => {
                            e.CategoryColor = chartColors[i % x];
                            totalCount += e.Count;
                            totalAmount += e.Amount;                            

                            SetDashboardTotals(ChartId, totalCount, totalAmount);
                        });

                        if (ChartId == 3) {
                            //add totals row
                            //results.push({ Category: "Totals", SubCategory: "", Count: totalCount, Amount: totalAmount, CategoryColor: "" });
                            //console.log(results);
                        }

                        e.success(results);
                    },
                    error: (results) => {
                        //console.log("fail")
                    }
                });
            }
        },
        aggregate: [
            {field: "Amount", aggregate: "sum"}
        ]
    });

    return ChartData;
}

function legendTemplate(dataItem) {    
    labelDisplay = '';
    labelDisplay = `<span style='background-color:${dataItem.CategoryColor};opacity:0.7;border-radius: 6px;'>${dataItem.Category}</span>`;
    //                                        <td></td>
    //<td style="text-align:left;"><span style="margin-left:5px;">In-House Check</span></td>
    //console.log(labelDisplay);
    return labelDisplay;
}

$("#chartSpendByPaymentType").kendoChart({    
    dataSource: GetChartData(0),
    tooltip: {
        visible: true,
        template: "#: dataItem.Category #: #: dataItem.Count #, #: kendo.toString(dataItem.Amount, 'c0') #"
    },
    //title: {
    //    align: "left",
    //    text: "Comments per day"
    //},
    legend: {
        labels: {
            visible: false
        }
    },
    seriesDefaults: {
        type: "pie"
        //labels: {
        //    visible: true,
        //    background: "transparent"
        //}
    },
    series: [{
        field: "Amount",
        //categoryField: "Category",
        colorField: "CategoryColor",
        opacity: .7,
        gap: .5        
    }],
    valueAxis: {        
        majorGridLines: {
            visible: false
        },
        visible: false
    },
    categoryAxis: {
        majorGridLines: {
            visible: false
        },
        line: {
            visible: false
        }
    }
});

$("#chartOpenByPaymentType").kendoChart({
    dataSource: GetChartData(1),
    tooltip: {
        visible: true,
        template: "#: dataItem.Category #: #: dataItem.Count #, #: kendo.toString(dataItem.Amount, 'c0') #"
    },
    legend: {
        visible: false
    },
    seriesDefaults: {
        type: "pie"        
    },
    series: [{
        field: "Amount",
        //categoryField: "Category",
        colorField: "CategoryColor",
        opacity: .7,
        gap: .5
    }],
    categoryAxis: {
        majorGridLines: {
            visible: false
        },
        line: {
            visible: false
        }
    }
});

$("#chartPendingPayments").kendoChart({
    dataSource: GetChartData(2),
    tooltip: {
        visible: true,
        template: "#: dataItem.Category #: #: dataItem.Count #, #: kendo.toString(dataItem.Amount, 'c0') #"
    },
    legend: {
        visible: false
    },
    seriesDefaults: {
        type: "pie"
    },
    series: [{
        field: "Amount",
        //categoryField: "Category",
        colorField: "CategoryColor",
        opacity: .7,
        gap: .5
    }],
    margin: 0,
    seriesClick: function (e) {        
        let gridData = $("#pendingDataGrid").data("kendoGrid").dataSource;
        let filter = [];          

        filter.push({ field: "SubCategory", operator: "eq", value: e.dataItem.Category });
        gridData.filter(filter);

        $("#pendingGridTitle").html(e.dataItem.Category + " Vendors");
        $("#resetGrid").show();
    },
    categoryAxis: {
        majorGridLines: {
            visible: false
        },
        line: {
            visible: false
        }
    }
});
