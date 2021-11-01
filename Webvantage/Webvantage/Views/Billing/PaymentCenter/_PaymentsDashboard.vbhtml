<script src="~/JScripts/billing.paymentcenter.dashboard.mvc.js"></script>
<style>
    #pendingDataGrid > table > tbody > tr > td {
        height: 8px !important;
    }

    #pendingChart > svg > g > g > g > g > g > text {
        font-size: 20px;
        color: #767676 !important;
    }

    /*#pendingDataGrid > table > tbody > tr:nth-child(7) {
        font-weight: 600;
    }*/ 

    #pendingDataGrid > table > tbody > tr > td:nth-child(3) {
        text-align: right;
    }

    .panelbarDashboard-sm {
        border-style: solid;
        border-width: 1px;
        border-radius: 4px;
        border-color: lightgray;
        display: inline-block;
        position: relative;
        width: 515px;
        margin-top: 5px;
        height: 97%;
    }

    .panelBarSpanDashboard-sm {
        position: relative;
        width: 485px;
        font-weight: 600;
        font-size: 14px;
        border-radius: 4px 4px 0px 0px;
        background-color: #ffffff !important;
        color: black !important;
        border-color: #ccc !important;
        text-align: left;
    }

    .dashboard-listitem-sm {
        position: relative;
        width: 515px !important;
        height: 320px;
        border: 1px solid black;
        margin-left: auto;
        margin-right: auto;
    }

    .pendingDataGrid > table > thead > tr > td {
        padding: 0px;
        height: 10px;
    }


    .panelbarDashboard-lg {
        border-style: solid;
        border-width: 1px;
        border-radius: 4px;
        border-color: lightgray;
        display: inline-block;
        position: relative;
        width: 1050px;
        margin-top: 5px;
        height: 97%;
    }

    .panelBarSpanDashboard-lg {
        position: relative;
        width: 1020px;
        font-weight: 600;
        font-size: 14px;
        border-radius: 4px 4px 0px 0px;
        background-color: #ffffff !important;
        color: black !important;
        border-color: #ccc !important;
        text-align: left;
    }

    .dashboard-listitem-lg {
        position: relative;
        width: 1050px !important;
        height: 320px;
        border: 1px solid black;
    }

    .dashboard-container-row {
        background-color: white;
        border-radius: 4px;
        overflow: hidden;
        width: calc(100vw - 310px);
        min-width: calc(100vw - 310px);
        margin-left: auto !important;
        margin-right: auto !important;
        margin-bottom: 10px;
        padding-left: 0px !important;
        text-align: center;
    }    

    .legend-marker {
        opacity: 0.7;
        border-radius: 6px;
    }
</style>
<script id="legendItemTemplate" type="text/kendo">
    <li style="list-style:none;text-align:left;height:25px;">        
            <span class="legend-marker" data-bind="style:{background-color: CategoryColor}">&nbsp;&nbsp;&nbsp;</span>
            <span>#: Category #</span>        
    </li>
</script>
<div id="DashboardContainerTop" class="dashboard-container-row">
    <ul id="dashboardOne" class="panelbarDashboard-sm" style="margin-right:16px;">
        <li class="k-state-active dashboard-listitem-sm">            
            <span class="k-link k-state-selected panelBarSpanDashboard-sm"> Spend By Payment Type | April 2021</span>
            <div style="border:none;padding-top:5px;">                
                <div style="padding-left:70px;">
                    <div id="chartSpendByPaymentTypeView" style="position: absolute; top:5px;left:5px;">
                        <button id="pie" onclick="columnView(this, 'chartSpendByPaymentType');" class="k-button wv-icon-button k-state-active" style="height:25px; width:25px;" title="Pie Chart View"><span class="glyphicon wvi wvi-chart_pie"></span></button>
                        <button id="column" onclick="columnView(this, 'chartSpendByPaymentType');" class="k-button wv-icon-button wv-neutral" style="height:25px; width:25px;" title="Bar Chart View"><span class="glyphicon wvi wvi-chart_column"></span></button>
                    </div>
                    <table style="margin-top:25px;">
                        <tr>                
                            <td style="width:250px;">
                                <div id="chartSpendByPaymentType" style="height:225px; width:250px; margin:0px; padding: 0px;"></div>
                            </td>
                            <td style="width:250px;padding-left:0px;">                             
                                <ul data-bind="source:series" data-template="legendItemTemplate" id="spendByTypeLegend">                                    
                                </ul>
                            </td>                            
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="width:375px;">
                                    <span id="spendTotalCount" style="font-weight:600;float:left;"></span>
                                    <span  id="spendTotalAmount" style="font-weight:600;float:right !important;"></span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>                
            </div>
        </li>
    </ul>
    <ul id="dashboardThree" class="panelbarDashboard-sm">
        <li class="k-state-active dashboard-listitem-sm">
            <!--<span id="ClientName" style="background-color:#e5e5e5 !important;border-color:lightgrey !important;color:#333 !important;" class="k-link k-state-selected">Filters</span>-->
            <span class="k-link k-state-selected panelBarSpanDashboard-sm"> Open Payables by Type</span>
            <div style="text-align:center;border:none;padding-top:5px;">
                <div style="padding-left:70px;">
                    <div id="chartOpenByPaymentTypeView" style="position: absolute; top:5px;left:5px;">
                        <button id="pie" onclick="columnView(this, 'chartOpenByPaymentType');" class="k-button wv-icon-button k-state-active" title="Pie Chart View" style="height:25px; width:25px;"><span class="glyphicon wvi wvi-chart_pie"></span></button>
                        <button id="column" onclick="columnView(this, 'chartOpenByPaymentType');" class="k-button wv-icon-button wv-neutral" title="Bar Chart View" style="height:25px; width:25px;"><span class="glyphicon wvi wvi-chart_column"></span></button>
                    </div>
                    <table style="margin-top:25px;">
                        <tr>
                            <td style="width:250px;">
                                <div id="chartOpenByPaymentType" style="height:225px; width:250px; margin:0px; padding: 0px;float: left;"></div>
                            </td>
                            <td style="width:250px;padding-left:0px;">
                                <ul data-bind="source:series" data-template="legendItemTemplate" id="openByTypeLegend"></ul>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="width:375px;">
                                    <span id="openTotalCount" style="font-weight:600;float:left;"></span>
                                    <span id="openTotalAmount" style="font-weight:600;float:right !important;"></span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>                
            </div>
        </li>
    </ul>
</div>
<div id="DashboardContainerBottom" class="dashboard-container-row">
    <ul id="dashboardTwo" class="panelbarDashboard-lg">
        <li class="k-state-active dashboard-listitem-lg">
            <!--<span id="ClientName" style="background-color:#e5e5e5 !important;border-color:lightgrey !important;color:#333 !important;" class="k-link k-state-selected">Filters</span>-->
            <span class="k-link k-state-selected panelBarSpanDashboard-lg"> Upcoming Payments Due - Next 30 Days</span>
            <div style="text-align:center;border:none;padding-top:5px;">
                @*<div id="pendingBatches">
                        <span>Range:</span>
                        <input id="pendingBatchesList" type="text" style="width: 160px;" />
                    </div>*@
                <div>
                    <div id="chartPendingPaymentsView" style="position: absolute; top:5px;left:5px;z-index:1000;">
                        <button id="pie" onclick="columnView(this, 'chartPendingPayments');" class="k-button wv-icon-button k-state-active" title="Pie Chart View" style="height:25px; width:25px;"><span class="glyphicon wvi wvi-chart_pie"></span></button>
                        <button id="column" onclick="columnView(this, 'chartPendingPayments');" class="k-button wv-icon-button wv-neutral" title="Bar Chart View" style="height:25px; width:25px;"><span class="glyphicon wvi wvi-chart_column"></span></button>
                    </div>
                    <table>
                        <tr>
                            <td style="padding-left:25px;">
                                <table>
                                    <tr>
                                        <td style="width:225px;padding-left:15px;padding-top:25px;">
                                            <div id="chartPendingPayments" style="height:225px; width:250px; margin-right:10px; padding: 0px;float: left;"></div>
                                        </td>
                                        <td style="width:125px;padding-left:0px;">
                                            <ul data-bind="source:series" data-template="legendItemTemplate" id="pendingLegend"></ul>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-left:15px;">                                            
                                            <div style="width:375px;">
                                                <span id="pendingTotalCount" style="font-weight:600;float:left;"></span>
                                                <span id="pendingTotalAmount" style="font-weight:600;float:right !important;"></span>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="vertical-align:top;padding-left:100px;">
                                <table style="width:500px;">
                                    <tr style="height:10px;">
                                        <td style="text-align:center;padding:0px 0px 0px 5px;">
                                            <span id="pendingGridTitle" style="font-weight:600;float:left;margin-top:7px;">All Vendors</span>                                            
                                            <button id="resetGrid" onclick="pendingGridAll();" class="k-button wv-icon-button" title="Show All Vendors" style="height:20px; width:20px;float:right;margin-top:7px;"><span class="glyphicon wvi wvi-undo"></span></button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width:275px;padding-top:5px;">
                                            <div id="pendingDataGrid" style="max-height:241px;width:500px; margin:0px 0px 0px 0px; padding: 0px;float: right;margin-top:0px;overflow:auto;"></div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </li>
    </ul>
</div>
<script>
    $(document).ready(function () {    
        $("#resetGrid").hide();
        $("span.glyphicon.glyphicon-fullscreen").hide();                            

        var chart = $("#chartSpendByPaymentType").data("kendoChart");
        var viewModel = kendo.observable({
            series: chart.dataSource
        });
        kendo.bind($("#spendByTypeLegend"), viewModel.series);        

        chart = $("#chartOpenByPaymentType").data("kendoChart");
        viewModel = kendo.observable({
            series: chart.dataSource
        });
        kendo.bind($("#openByTypeLegend"), viewModel.series);        

        chart = $("#chartPendingPayments").data("kendoChart");
        viewModel = kendo.observable({
            series: chart.dataSource
        });
        kendo.bind($("#pendingLegend"), viewModel.series);        
    });

</script>
