<script src="~/JScripts/financial.dashboard.mvc.js"></script>
<style>



    #monthgrid > div.k-grid-header {
        padding-right: 0px !important;
    }

    #ytdgrid > div.k-grid-header {
        padding-right: 0px !important;
    }

    #chartgrid > div.k-grid-header {
        padding-right: 0px !important;
    }

    #chartgridytd > div.k-grid-header {
        padding-right: 0px !important;
    }

    #chartgridClient > div.k-grid-header {
        padding-right: 0px !important;
    }

    #newbusinessgrid > div.k-grid-header {
        padding-right: 0px !important;
        color: #767676 !important;
    }

    #growgrid > div.k-grid-header {
        padding-right: 0px !important;
        color: #767676 !important;
    }

    #billablegrid > div.k-grid-header {
        padding-right: 0px !important;
        text-align: center;
    }

    #billablegrid > div.k-filter-row th, .k-grid-header th.k-header {
        padding-right: 0px !important;
        text-align: center;
    }

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
        /*width: calc(100vw - 310px);
        min-width: calc(100vw - 310px);*/
        margin-left: auto !important;
        margin-right: auto !important;
        margin-bottom: 10px;
        padding-left: 0px !important;
        text-align: center;
        justify-content: center;
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
<div id="DashboardContainerGrid1" class="dashboard-container-row" style="width: 1500px">
    <div style="border:none;padding-top:5px; width: 750px; float: left; ">
        <div style="padding-left:10px;">
            <div id="monthgrid" style="border: 1px solid #CCC;" tabindex="1">
            </div>
        </div>
    </div>
    <div style="border:none;padding-top:5px; width: 750px; float: left;">
        <div style="padding-left:10px;">
            <div id="ytdgrid" style="border: 1px solid #CCC;" tabindex="1">
            </div>
        </div>
    </div>
</div>
<div id="DashboardContainerBottom" class="dashboard-container-row">
    <div style="text-align:center;border:none;padding-top:5px;">
        <div>
            <table align="center">
                <tr>
                    <td style="padding-left:25px;">
                        <table>
                            <tr>
                                <td style="padding-left:15px;padding-top:25px;">
                                    <div id="chartMonth" style="margin-right:10px; padding: 0px;float: left; width: 1500px"></div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left:15px;">
                                    <div id="chartgrid" style="width: 1500px" tabindex="1"></div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div id="DashboardContainerGrid2" class="dashboard-container-row" style="width: 1500px">
    <div style="border:none;padding-top:5px; width: 750px; float: left; ">
        <div style="padding-left:10px;">
            <table align="center">
                <tr>
                    <td style="padding-left:25px;">
                        <table>
                            <tr>
                                <td style="padding-left:15px;padding-top:25px;">
                                    <div id="chartytd" style="margin-right:10px; padding: 0px;float: left; width: 700px"></div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left:15px;">
                                    <div id="chartgridytd" style="width: 650px" tabindex="1"></div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="border:none;padding-top:5px; width: 750px; float: left;">
        @*<div style="padding-left:10px; padding-bottom:10px">
            <div id="billablegrid" style="border: 1px solid #CCC;" tabindex="1">
            </div>
        </div>*@
        <div style="padding-left:10px; padding-bottom:10px">
            <div id="newbusinessgrid" style="border: 1px solid #CCC;" tabindex="1">
            </div>
        </div>
        <div style="padding-left:10px;">
            <div id="growgrid" style="border: 1px solid #CCC;" tabindex="1">
            </div>
        </div>
    </div>
</div>

<div id="DashboardContainerBottom" class="dashboard-container-row">
    <div style="text-align:center;border:none;padding-top:5px;">
        <div>
            <table align="center">
                <tr>
                    <td style="padding-left:25px;">
                        <table>
                            <tr>
                                <td style="padding-left:15px;padding-top:25px;">
                                    <div id="chartClient" style="margin-right:10px; padding: 0px;float: left; width: 1500px"></div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding-left:15px;">
                                    <div id="chartgridClient" style="width: 1500px" tabindex="1"></div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<script>
        $(document).ready(function () {
            $("#resetGrid").hide();
            $("span.glyphicon.glyphicon-fullscreen").hide();

            //var chart = $("#chartSpendByPaymentType").data("kendoChart");
            //var viewModel = kendo.observable({
            //    series: chart.dataSource
            //});
            //kendo.bind($("#spendByTypeLegend"), viewModel.series);

            //chart = $("#chartOpenByPaymentType").data("kendoChart");
            //viewModel = kendo.observable({
            //    series: chart.dataSource
            //});
            //kendo.bind($("#openByTypeLegend"), viewModel.series);

            //chart = $("#chartMonth").data("kendoChart");
            //viewModel = kendo.observable({
            //    series: chart.dataSource
            //});
            //kendo.bind($("#pendingLegend"), viewModel.series);
            SetDateFilters();
            LoadUserGridView();
            LoadUserGridViewYTD();
            LoadUserChart();
            LoadUserChartGridView();
            LoadUserChartYTD();
            LoadUserChartGridViewYTD();
            LoadUserChartClient();
            LoadUserChartGridViewClient();
            LoadUserNewBusinessGrid();
            LoadUserGrowGrid();
            //LoadUserBillableGrid();

            chart = $("#chartMonth").data("kendoChart");
            viewModel = kendo.observable({
                series: chart.dataSource
            });
            kendo.bind($("#pendingLegend"), viewModel.series);

        });

        let FinancialDataSource;
        let FinancialDataSourceYTD;
        let FinancialDataSourceChart;
        let FinancialDataSourceChartGrid;
        let FinancialDataSourceChartYTD;
        let FinancialDataSourceChartGridYTD;
        let FinancialDataSourceChartClient;
        let FinancialDataSourceChartGridClient;
        let FinancialDataSourceBillableGrid;
        let FinancialDataSourceNewBusinessGrid;
        let FinancialDataSourceGrowGrid;


        let EUFilter = {
            UserCode: '@ViewBag.UserCode',
            FromMonth: '1',
            FromYear: '2019',
            ToMonth: '6',
            ToYear: '2019',
            EmployeeCode: '',
            DepartmentCode: '',
            StartDate: '',
            EndDate: '',
            Page: '',
            InitialLoadFlag: false
        }

        function createGridDataSource() {
            FinancialDataSource = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Category: { from: 'Category', type: 'string', editable: false, nullable: false },
                                Actual: { from: 'Actual', type: 'number', editable: false, nullable: false },
                                Budget: { from: 'Budget', type: 'number', editable: false, nullable: false },
                                VariancePercent: { from: 'VariancePercent', type: 'number', editable: false, nullable: false },
                                MTD: { from: 'MTD', type: 'number', editable: false, nullable: false },
                                YOYPercent: { from: 'YOYPercent', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSource;
        }

        function createGridDataSourceYTD() {
            FinancialDataSourceYTD = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Category: { from: 'Category', type: 'string', editable: false, nullable: false },
                                Actual: { from: 'Actual', type: 'number', editable: false, nullable: false },
                                Budget: { from: 'Budget', type: 'number', editable: false, nullable: false },
                                VariancePercent: { from: 'VariancePercent', type: 'number', editable: false, nullable: false },
                                MTD: { from: 'MTD', type: 'number', editable: false, nullable: false },
                                YOYPercent: { from: 'YOYPercent', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceYTD;
        }


        function createChartDataSource() {
            FinancialDataSourceChart = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Month: { from: 'Month', type: 'string', editable: false, nullable: false },
                                Revenue: { from: 'Revenue', type: 'number', editable: false, nullable: false },
                                Expenses: { from: 'Expenses', type: 'number', editable: false, nullable: false },
                                NetIncome: { from: 'NetIncome', type: 'number', editable: false, nullable: false },
                                Profit: { from: 'Profit', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceChart;
        }

        function createChartGridDataSource() {
            FinancialDataSourceChartGrid = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Category: { from: 'Category', type: 'string', editable: false, nullable: false },
                                January: { from: 'January', type: 'number', editable: false, nullable: false },
                                Feburary: { from: 'Feburary', type: 'number', editable: false, nullable: false },
                                March: { from: 'March', type: 'number', editable: false, nullable: false },
                                April: { from: 'April', type: 'number', editable: false, nullable: false },
                                May: { from: 'May', type: 'number', editable: false, nullable: false },
                                June: { from: 'June', type: 'number', editable: false, nullable: false },
                                July: { from: 'July', type: 'number', editable: false, nullable: false },
                                August: { from: 'August', type: 'number', editable: false, nullable: false },
                                September: { from: 'September', type: 'number', editable: false, nullable: false },
                                October: { from: 'October', type: 'number', editable: false, nullable: false },
                                November: { from: 'November', type: 'number', editable: false, nullable: false },
                                December: { from: 'December', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceChartGrid;
        }

        function createChartYTDDataSource() {
            FinancialDataSourceChartYTD = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Year: { from: 'Year', type: 'string', editable: false, nullable: false },
                                Revenue: { from: 'Revenue', type: 'number', editable: false, nullable: false },
                                Expenses: { from: 'Expenses', type: 'number', editable: false, nullable: false },
                                Income: { from: 'Income', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceChartYTD;
        }

        function createChartGridYTDDataSource() {
            FinancialDataSourceChartGridYTD = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Category: { from: 'Category', type: 'string', editable: false, nullable: false },
                                Year1: { from: 'Year1', type: 'number', editable: false, nullable: false },
                                Year2: { from: 'Year2', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceChartGridYTD;
        }

        function createChartClientDataSource() {
            FinancialDataSourceChartClient = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Client: { from: 'Client', type: 'string', editable: false, nullable: false },
                                Year1: { from: 'Year1', type: 'number', editable: false, nullable: false },
                                Year2: { from: 'Year2', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceChartClient;
        }

    function createChartGridClientDataSource() {
        FinancialDataSourceChartGridClient = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Year: { from: 'Year', type: 'string', editable: false, nullable: false },
                                Client1: { from: 'Client1', type: 'number', editable: false, nullable: false },
                                Client2: { from: 'Client2', type: 'number', editable: false, nullable: false },
                                Client3: { from: 'Client3', type: 'number', editable: false, nullable: false },
                                Client4: { from: 'Client4', type: 'number', editable: false, nullable: false },
                                Client5: { from: 'Client5', type: 'number', editable: false, nullable: false },
                                Client6: { from: 'Client6', type: 'number', editable: false, nullable: false },
                                Client7: { from: 'Client7', type: 'number', editable: false, nullable: false },
                                Client8: { from: 'Client8', type: 'number', editable: false, nullable: false },
                                Client9: { from: 'Client9', type: 'number', editable: false, nullable: false },
                                Client10: { from: 'Client10', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

        return FinancialDataSourceChartGridClient;
    }

    

        function createBilliableGridDataSource() {
            FinancialDataSourceBillableGrid = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                January: { from: 'January', type: 'number', editable: false, nullable: false },
                                Feburary: { from: 'Feburary', type: 'number', editable: false, nullable: false },
                                March: { from: 'March', type: 'number', editable: false, nullable: false },
                                April: { from: 'April', type: 'number', editable: false, nullable: false },
                                May: { from: 'May', type: 'number', editable: false, nullable: false },
                                June: { from: 'June', type: 'number', editable: false, nullable: false },
                                July: { from: 'July', type: 'number', editable: false, nullable: false },
                                August: { from: 'August', type: 'number', editable: false, nullable: false },
                                September: { from: 'September', type: 'number', editable: false, nullable: false },
                                October: { from: 'October', type: 'number', editable: false, nullable: false },
                                November: { from: 'November', type: 'number', editable: false, nullable: false },
                                December: { from: 'December', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceBillableGrid;
        }

        function createNewBusinessDataSource() {
            FinancialDataSourceNewBusinessGrid = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Client: { from: 'Client', type: 'string', editable: false, nullable: false },
                                Amount: { from: 'Amount', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceNewBusinessGrid;
        }

        function createGrowGridDataSource() {
            FinancialDataSourceGrowGrid = new kendo.data.DataSource({
                    transport: {
                        read: (e) => {
                            let data = EUFilter;

                            $.ajax({
                                type: "GET",
                                url: "@Href("~/Dashboard/Financial/GetChartData")",
                                dataType: 'json',
                                data: data,
                                success: (results) => {
                                    $.each(results, (i, e) => {

                                    });
                                    e.success(results);
                                },
                                error: (results) => {
                                    e.error(results);
                                }
                            });

                            EUFilter.InitialLoadFlag = false;
                        }
                    },

                    schema: {
                        model: {
                            fields: {
                                Client: { from: 'Client', type: 'string', editable: false, nullable: false },
                                Year1: { from: 'Year1', type: 'number', editable: false, nullable: false },
                                Year2: { from: 'Year2', type: 'number', editable: false, nullable: false }
                            }
                        }
                    }
            });

            return FinancialDataSourceGrowGrid;
        }



</script>
