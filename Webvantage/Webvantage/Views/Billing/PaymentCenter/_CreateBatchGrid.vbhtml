<style>
    #invoiceGrid_active_cell > span > span > span.k-input {
        color: white;
    }

    #invoiceGrid {
        min-width: 1000px !important;
    }

    #gridTotals, #completedGridTotals {
        margin: 0px;
        padding: 0px;
    }

        #gridTotals > tbody > tr > td,
        #completedGridTotals > tbody > tr > td {
            height: 6px;
            border: none;
            margin: 0px;
            padding: 0px;
            width: 150px;
            text-align: center;
            font-weight: 600;
        }


        #gridTotals > tbody > tr:hover,
        #completedGridTotals > tbody > tr:hover {
            background-color: #E5E5E5;
        }

    .k-header-column-menu {
        text-decoration: none !important;
    }

    .k-dirty {
        display: none;
    }
    
    .k-filter-row > th:first-child, .k-grid tbody td:first-child, .k-grid tfoot td:first-child, .k-grid-header th.k-header:first-child{
        text-align:center;
        padding:0px !important;
    }

    td > input[type="checkbox"],
    th > input[type="checkbox"] {
        margin-right: 0px !important;
    }

    th > input[type="checkbox"] {
        margin-bottom: 10px;
    }

    .disabled-area {
        pointer-events: none;
        opacity: 0.6;        
    }
</style>

<div id="invoiceGrid" style="border: 1px solid #CCC;" tabindex="1" class="disabled-area">
    
</div>

<script type="text/x-kendo-template" id="template">
    <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
        @*<li style="padding:0" id="saveListItem">
            <button id="saveInvoicesButton" class="k-button wv-icon-button wv-save k-state-disabled" title="Save Invoice Selection(s)" onclick="SaveInvoiceSelections()" disabled><span class='wvi wvi-floppy-disk'></span></button>
        </li>*@
        <li id="columnSelectorListItem" style="padding:0">
            <a id="col-menu" style="text-decoration: none;"></a>
        </li>
        <li id="resetOptionsListItem" style="padding:0">
            <button id="ResetOptionsButton" class="k-button wv-icon-button wv-neutral " onclick="showResetOptions()" style="width: 100px !important;" title="Reset column widths and order to default"><span style="font-size: 12px;">Column Reset</span></button>
        </li>
        <li id="clearColumnFiltersListItem" style="padding:0">
            <button id="btnClearColumnFilters" class="k-button wv-icon-button wv-neutral " onclick="ClearFilters();" title="Clear Column Filters"><span class='glyphicon wvi wvi-undo'></span></button>
        </li>
        @*<li id="ViewListItem" style="padding:0;">
            <div id="AAViewListItem">
                <span>View:</span>
                <input id="AAView" type="text" style="width: 160px;" />
            </div>
        </li>*@
        <li id="GridViewType" style="padding:0;">
            <div id="View">
                <span>View:</span>
                <input id="View" type="text" style="width: 200px;" />
            </div>
        </li>
        <li style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="ExportToExcel()"><span class='wvi wvi-spreadsheet-sum' title="Export" style="font-size: 18px;"></span></button>
        </li>
        <li id="searchInputListItem" style="padding:0">
            <input id="Search" title="Search" class="k-input k-textbox" />
        </li>
        <li id="searchListItem" style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="search()"><span class='wvi wvi-binocular' title="Search"></span></button>
        </li>
        <li id="clearSearchListItem" style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="clearSearch()"><span class='wvi wvi-undo' title="Clear Search"></span></button>
        </li>
        <li style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="refreshPage()"><span class='wvi wvi-refresh' title="Refresh"></span></button>
        </li>
        <li id="viewBatchSummary" style="padding:0">
            <button class="k-button au-target" id="BatchSummaryButton"
                    title="View Batch Summary"
                    onclick="ViewBatchSummary();"
                    hidden>
                Batch Summary
            </button>
        </li>
        <li style="float:right;">
            <div>
                <table id="gridTotals">
                    <tr style="line-height:10px !important;">
                        <td>Invoice Totals</td>
                        <td>Invoice Balance</td>
                        <td>Approved Amount</td>
                    </tr>
                    <tr>
                        <td id="invoiceTotals">$0.00</td>
                        <td id="invoiceBalance">$0.00</td>
                        <td id="approvedAmount">$0.00</td>
                    </tr>
                </table>
                <table id="completedGridTotals">
                    <tr style="line-height:10px !important;">
                        <td>Batch Total</td>
                    </tr>
                    <tr>
                        <td id="batchTotal">$0.00</td>
                    </tr>
                </table>
            </div>
        </li>
    </ul>

</script>
<div id="ResetOptions" class="toolbar-custom-drop">
    <table>
        <thead>
            <tr>
                <th>Column Settings</th>
                @*<th>Other Task Actions</th>*@
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <button id="columnResetWidth" class="k-button wv-icon-button wv-neutral " onclick="columnReset('width');" style="width: 200px !important;" title="Reset column widths to default"><span style="font-size: 12px;">Reset Widths to Default</span></button>

                </td>
            </tr>
            <tr>
                <td>
                    <button id="columnResetOrder" class="k-button wv-icon-button wv-neutral " onclick="columnReset('order');" style="width: 200px !important;" title="Reset column order to default"><span style="font-size: 12px;">Reset Order to Default</span></button>
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="k-overlay" id="myOverlay" style="display:none"></div>
<script>

    let _PageInitialized = false;
    let _invoiceTotals = 0;
    let _invoiceBalance = 0;
    let _approvedAmount = 0;
    let _selectedInvoices = [];
    let oldPageSize = 0;
    let InvoiceDataSource;
    let BatchCheckDataSource;
    let ColumnSettings = {
        Pay: true,
        PayMethod: true,
        PayToVendorCode: true,
        InvoiceNumber: true,
        InvoiceType: true,
        DateToPay: true,
        BalanceToPay: true,
        ApprovedAmount: true,
        GLAccount: true,
        VendorCode: true,
        VendorName: true,
        InvoiceDescription: true,
        InvoiceDate: true,
        InvoiceTotal: true,
        InvoiceBalance: true,
        DiscountPercentage: true,
        DiscountAvailable: true,
        DiscountApproved: true,
        WithholdingTax: true,
        PaidPreviously: true,
        NonBillableAmount: true,
        BillableAmount: true,
        DirectBillAmount: true,
        ProdAdvanceBalance: true,
        CashReceived: true,
        TotalQualified: true,
        PaidByClientAmount: true
    }
    let reorderedColumn = {
        name: "",
        oldIndex: -1,
        newIndex: -1
    };
    let summaryColumns = [
        "Pay", "PayMethod", "PayToVendorCode", "InvoiceNumber", "InvoiceType", "DateToPay", "InvoiceTotal", "BalanceToPay", "ApprovedAmount"
    ];

    $(document).ready(function () {
        console.clear();
        //temporary until user preferences have been saved, retrieved and applied
        userViewSettingsReady = true;

        LoadUserColumnSettings();

        if (_BatchId !== 0) {
            InitializeScreen(_BatchId, _PaymentModule);
        } else {
            _PageInitialized = true;

            //ManageScreenStatus(0, '', '');
        }

        LoadGridView();        
    });

    //this columns cannot be reordered/moved
    let _staticColumns = ["Pay"];

    function createInvoiceGridDataSource() {        
        InvoiceDataSource = new kendo.data.DataSource({
            transport: {
            read: (e) => {
                    $.ajax({
                        type: "GET",
                        url: "@Href("~/PaymentCenter/GetInvoiceData")",
                        dataType: 'json',
                        data: GetInvoiceFilter(),
                        success: (results) => {
                            e.success(results);                            
                        },
                        error: (results) => {
                            e.error(results);
                        }
                    });

                    InvoiceFilter.InitialLoadFlag = false;
                }
            },
            pageSize: 10,
            schema: {
                model: {
                    id: "APId",
                    fields: {
                        Pay: {from: 'Pay', type: "boolean", editable: false },
                        APId: { from: "APId", type: "number", editable: false},
                        PayToVendorCode: { from: "PayToVendorCode", type: "string", editable: false },
                        PayToVendorName: { from: "PayToVendorName", type: "string", editable: false },
                        InvoiceNumber: { from: "InvoiceNumber", type: "string", editable: false },
                        InvoiceType: { from: "InvoiceType", type: "string", editable: false },
                        DateToPay: { from: 'DateToPay', type: 'date', nullable: true, editable: false },
                        BalanceToPay: { from: 'BalanceToPay', type: 'number', nullable: true, editable: false },
                        ApprovedAmount: { from: 'ApprovedAmount', type: 'number', editable: true,  nullable: true, validation: { min: 0 } },
                        GLAccount: { from: 'GLAccount', type: 'string', editable: false },
                        VendorCode: { from: 'VendorCode', type: 'string', editable: false },
                        VendorName: { from: 'VendorName', type: 'string', editable: false },
                        InvoiceDescription: { from: 'InvoiceDescription', type: 'string', editable: false },
                        InvoiceDate: { from: 'InvoiceDate', type: 'date', editable: false },
                        InvoiceTotal: { from: 'InvoiceTotal', type: 'number', editable: false },
                        InvoiceBalance: { from: 'InvoiceBalance', type: 'number', editable: false },
                        InvoicePaidAmount: { from: 'InvoicePaidAmount', type: 'number', editable: false },
                        DiscountPercentage: { from: 'DiscountPercentage', type: 'string', editable: false },
                        DiscountAvailable: { from: 'DiscountAvailable', type: 'number', editable: false },
                        DiscountApproved: { from: 'DiscountApproved', type: 'number', editable: true, validation: { min: 0 } },
                        WithholdingTax: { from: 'WithholdingTax', type: 'number', editable: false },
                        PaidPreviously: { from: 'PaidPreviously', type: 'number', editable: false },
                        NonBillableAmount: { from: 'NonBillableAmount', type: 'number', editable: false },
                        BillableAmount: { from: 'BillableAmount', type: 'number', editable: false },
                        DirectBillAmount: { from: 'DirectBillAmount', type: 'number', editable: false },
                        ProdAdvanceBalance: { from: 'ProdAdvanceBalance', type: 'number', editable: false },
                        CashReceived: { from: 'CashReceived', type: 'number', editable: false },
                        TotalQualified: { from: 'TotalQualified', type: 'number', editable: false },
                        PaidByClientAmount: { from: 'PaidByClientAmount', type: 'number', editable: false }
                    }
                }
            }
        });
        //console.log(InvoiceDataSource._data);
        return InvoiceDataSource;
    }

    function CreateDetailViewGrid() {
        $("#invoiceGrid").kendoGrid({
            //height: 486,
            persistSelection: true,
            autoBind: false,
            navigatable: true,
            reorderable: true,
            toolbar: kendo.template($("#template").html()),
            excel: {
                filterable: true,
                allPages: true
            },
            dataSource: InvoiceDataSource,
            groupable: false,
            sortable: true,
            pageable: {
                refresh: true,
                pageSizes: [10, 15, 20, 50, 100, 200],
                buttonCount: 5
            },
            editable: "incell",
            resizable: true,
            filterable: true,
            filter: function (e) {
                //onFilterChange(e);
            },
            columns: myColumns,
            dataBound: function (e) {                
                totalpages = e.sender.pager.totalPages();
                e.sender.pager.options.messages.display = "{2} items in " + totalpages + " page(s)";
                $("span.k-icon.k-i-more-vertical").replaceWith('<button class="k-button wv-icon-button wv-neutral"><span class="wvi wvi-table-selection-column"></span></button>');

                $(".gridCheckBox").on("change", gridCheckBoxChange);
                
                
                //$(".gridCheckBox").on("mousedown", function (e) {
                //    console.log($(".gridCheckBox"));
                //    console.log("mousedown");
                //});
                //$(".gridCheckBox").on("click", function (e) {
                //    console.log(e.sender);
                //    console.log("click");
                //});

                $("#completedGridTotals").hide();
                CalculateSelectedInvoices();

                let filterPanelExpanded = $("#panelMain")[0].ariaExpanded;
                let gridHeight = parseInt($(".k-grid-content.k-auto-scrollable")[0].clientHeight);
                
                //evaluate as string
                if (filterPanelExpanded == "true") {
                    if (gridHeight < 300) {
                        $(".k-grid-content.k-auto-scrollable").css("height", "301px");
                    }
                } else {                    
                    if (gridHeight < 500) {
                        $(".k-grid-content.k-auto-scrollable").css("height", "518px");
                    }
                }                
            },
            columnHide: function (e) {
                let Data = {
                    GridName: GetGridView(),
                    Column: e.column.field,
                    ShowHide: false
                };

                //utilized to capture unbound columns;
                if (Data.Column === undefined) {
                    Data.Column = e.column.title;
                }

                $.post({
                    url: "SaveColumnSetting",
                    dataType: "json",
                    data: Data
                }).always(function () {

                });
            },
            columnShow: function (e) {
                let Data = {
                    GridName: GetGridView(),
                    Column: e.column.field,
                    ShowHide: true
                };

                if (Data.Column === undefined) {
                    Data.Column = e.column.title;
                }

                $.post({
                    url: "SaveColumnSetting",
                    dataType: "json",
                    data: Data
                }).always(function () {
                });
            },
            columnResize: function (e) {
                let columnName = e.column.field === undefined ? e.column.title.replace(" ", "") : e.column.field;
                SaveUserColumnWidth(columnName, e.newWidth);
            },
            columnReorder: function (e) {
                let grid = e.sender;
                let columnIndex = e.oldIndex;
                let column = e.column;
                let columnDetails = Array();
                let headers;

                if (columnIndex == 0 || columnIndex == 1) {
                    setTimeout(function (e) {
                        grid.reorderColumn(columnIndex, column);
                    }, 1);
                } else {
                    setTimeout(function () {
                        headers = $("#invoiceGrid > div > div > table > thead > tr > th");

                        for (let i = 0; i < headers.length; i++) {
                            header = $(headers[i]);
                            columnDetails.push({ "ColumnName": header.attr("data-field"), "ColumnID": header.attr("data-index") })
                        }

                        SaveUserColumnOrder(columnDetails);
                    }, 1);
                }
            }
        });

        SetupAdditionalGridFeatures();
    }

    function createCompletedBatchCheckDetailsDataSource() {
        BatchCheckDataSource = new kendo.data.DataSource({
            transport: {
            read: (e) => {
                    $.ajax({
                        type: "GET",
                        url: "@Href("~/PaymentCenter/GetCompletedBatchCheckDetails")",
                        dataType: 'json',
                        data: { BatchId: _BatchId },
                        success: (results) => {
                            e.success(results);

                            let batchTotal = 0;
                            for (let i = 1; i < results.length; i++) {
                                batchTotal += results[i].CheckAmount;
                            }

                            $("#batchTotal").html();
                            $("#batchTotal").html(kendo.toString(batchTotal, "c"));
                        },
                        error: (results) => {
                            e.error(results);
                        }
                    });
                }
            },
            pageSize: 10,
            schema: {
                model: {
                    id: "APId",
                    fields: {
                        APId: { from: "APId", type: "number", editable: false },
                        CheckNumber: { from: "CheckNumber", type: "number", editable: false },
                        PaymentType: { from: "PaymentType", type: "string", editable: false },
                        PaymentTypeDetail: { from: "PaymentTypeDetail", type: "string", editable: false },
                        GLAccount: { from: 'GLAccount', type: 'string', editable: false },
                        CheckDate: { from: 'CheckDate', type: 'date', editable: false },
                        PayToVendorCode: { from: "PayToVendorCode", type: "string", editable: false },
                        PayToVendorName: { from: "PayToVendorName", type: "string", editable: false },
                        CheckAmount: { from: 'CheckAmount', type: 'number', editable: false },
                        DiscountAmount: { from: 'DiscountAmount', type: 'number', editable: false }
                    }
                }
            }
        });

        return BatchCheckDataSource;
    }

    function CreateCompletedDetailViewGrid() {
        $("#invoiceGrid").kendoGrid({
            //height: 486,
            autoBind: false,
            navigatable: true,
            toolbar: kendo.template($("#template").html()),
            excel: {
                filterable: true,
                allPages: true
            },
            dataSource: BatchCheckDataSource,
            groupable: false,
            sortable: true,
            pageable: {
                refresh: true,
                pageSizes: [10, 15, 20, 50, 100, 200],
                buttonCount: 5
            },
            resizable: true,
            filterable: true,
            filter: function (e) {
                //onFilterChange(e);
            },
            columns: [
                { field: "CheckNumber", title: "Check</br>Number", width: 225 },
                { field: "PaymentType", title: "Payment</br>Type", width: 225 },
                { field: "PaymentTypeDetail", title: "Payment</br>Type Detail", width: 225 },
                { field: "GLAccount", title: "GL</br>Account", width: 150 },
                { field: "CheckDate", title: "Check</br>Date", width: 150, template: "#= kendo.toString(kendo.parseDate(CheckDate, 'yyyy-MM-dd'), 'MM/dd/yyyy') #" },
                { field: "PayToVendorCode", title: "Pay To</br>Vendor Code", width: 150 },
                { field: "PayToVendorName", title: "Pay To</br>Vendor Name", width: 225 },
                { field: "CheckAmount", title: "Check</br>Total", width: 150, format: "{0:c}", attributes: { style: "text-align: right;" } },
                { field: "DiscountAmount", title: "Discount</br>Total", width: 150, format: "{0:c}", attributes: { style: "text-align: right;" } }
            ],
            dataBound: function (e) {
                totalpages = e.sender.pager.totalPages();
                e.sender.pager.options.messages.display = "{2} items in " + totalpages + " page(s)";
                $("span.k-icon.k-i-more-vertical").replaceWith('<button class="k-button wv-icon-button wv-neutral"><span class="wvi wvi-table-selection-column"></span></button>');

                $("#gridTotals").hide();
                $("#completedGridTotals").show();

                $("#saveListItem").hide();
                $("#cancelListItem").hide();
                $("#deleteListItem").hide();
            }
        });

        SetupAdditionalGridFeatures();
    }

    function gridCheckBoxChange(e) {
        console.log(new Error().stack);
        //if (this.value() > options.model.BalanceToPay) {
        //    options.model.set("ApprovedAmount", options.model.BalanceToPay);
        //let data = $("#invoiceGrid").data("kendoGrid").dataSource.data();
        ////let rows = e.sender.select();
        //console.log(e);
        //for (let i = 0; i < 1; i++) {
        //    data[i].set("ApprovedAmount", data[i].BalanceToPay);
        //}        
        
        let $input = $(this);
        let checked = e.target.checked;
        let invoiceNumber = $input.attr("name").substring($input.attr("name").indexOf("_") + 1, $input.attr("name").length);

        var grid = $("#invoiceGrid").data("kendoGrid");

        for (let i = 0; i < grid.dataSource._data.length; i++) {
            if (grid.dataSource._data[i].InvoiceNumber == invoiceNumber) {
                if (checked) {
                    _selectedInvoices.push(grid.dataSource._data[i]);
                    grid.dataSource._data[i].set("ApprovedAmount", grid.dataSource._data[i].BalanceToPay);
                } else {
                    //grid.dataSource._data[i].set("Pay", 0);
                    grid.dataSource._data[i].set("ApprovedAmount", 0);
                    for (let x = 0; x < _selectedInvoices.length; x++) {
                        if (_selectedInvoices[x].InvoiceNumber == invoiceNumber) {
                            _selectedInvoices.splice(x, 1);
                            break;
                        }
                    }
                }
                $(".gridCheckBox.k-state-focused").removeClass("k-state-focused");
                break;                
            }
        }        
        
        CalculateSelectedInvoices();

        _IsDirty = true;        
    }

    function gridSelectAllClick(e) {
        var grid = $("#invoiceGrid").data("kendoGrid");
        let data = grid.dataSource.data();
        let selectAll = false;

        //oldPageSize = grid.dataSource.pageSize();
        //grid.dataSource.pageSize(data.length);             

        if ($("#checkAll")[0].checked) {            
            _selectedInvoices = [];
            for (let i = 0; i < data.length; i++) {
                _selectedInvoices.push(data[i]);
            }

            selectAll = true;
        } else {            
            _selectedInvoices = [];
            selectAll = false;
        }

        ////NS: this will need some work for large data sets!
        ////fyi, using data[k].set or view[k].set is even slower        
        
        if (selectAll) {
            for (let k = 0; k < data.length; k++) {
                let row = data[k];
                
                row.ApprovedAmount = row.BalanceToPay;
                row.Pay = true;                
            }
        } else {
            for (let k = 0; k < data.length; k++) {
                let row = data[k];                
                row.ApprovedAmount = 0;
                row.Pay = false;                
            }
        }

        grid.refresh();

        $("#checkAll")[0].checked = selectAll;

                //select/highlight rows that are selected to be paid
                //let selector = "";
                //let row = "";                

                //for (let i = 0; i < _selectedInvoices.length; i++) {
                //    selector = `input[name='payCheckBox_${_selectedInvoices[i].InvoiceNumber}']`;
                //    row = $(selector).closest("tr");
                //    row.addClass("k-state-selected");                    
                //}

        //CalculateSelectedInvoices();

        _IsDirty = true; 
    };

    function DiscountAvailableTemplate(dataItem) {
        let output = dataItem.DiscountAvailable;

    /* cf_disc_amt
    If (ap_date_pay >= cc_check_date,
        If ( (( cf_inv_balance *  ap_disc_pct) / 100) > 0,  ROUND((( cf_inv_balance *  ap_disc_pct) / 100),2), 0)   , 0)
    */

        return output;
    }

    function PayMethodTemplate(dataItem) {
        let display = '';

        switch (dataItem.PayMethod) {
            case 'CWI':
                display = 'In House';
                break;
            case 'TP_ACH':
                display = 'ACH';
                break;
            case 'TP_CHK':
                display = 'Check';
                break;
            case 'TP_VCC':
                display = 'Virtual Card';
                break;
            default:
                break;
        }

        return display;
    }

    function PayMethodDropList(container, options) {
        $('<input class="combo-40" name="' + options.field + '"/>')
            .appendTo(container)
            .kendoDropDownList({
            dataSource: new kendo.data.DataSource({
                        transport: {
                            read: {
                                url: "@Href("~/PaymentCenter/GetPaymentTypes")",
                                dataType: "json"
                            }
                        }
                    }),
                dataTextField: "Description",
                dataValueField: "Code",
                value:0
            }).data('kendoDropDownList');
    }

    function editApprovedAmount(container, options) {
        let item = $('<input data-bind="value:' + options.field + '"/>').appendTo(container);

        item.kendoNumericTextBox({
            spinners: false,
            step: 0,
            min: 0,
            change: function (e) {
                let invoiceNumber = options.model.InvoiceNumber
                let dataId = $(this)[0].element.closest('tr').attr('data-uid');
                let exists = false;
                let existingIndex = 0;

                if (this.value() > options.model.BalanceToPay) {
                    options.model.set("ApprovedAmount", options.model.BalanceToPay);
                    showKendoAlert("The Approved Amount cannot exceed the Balance To Pay.</br></br>Amount has been set to " + kendo.toString(options.model.BalanceToPay, "c"));
                }

                for (let j = 0; j < _selectedInvoices.length; j++) {
                    if (_selectedInvoices[j].InvoiceNumber == invoiceNumber) {
                        exists = true;
                        existingIndex = j;

                        _selectedInvoices[j].ApprovedAmount = this.value();
                        break;
                    }
                }

                if (!exists) {
                    let grid = $("#invoiceGrid").data("kendoGrid");
                    let row = grid.table.find("[data-uid=" + dataId + "]");
                    grid.select(row);

                    _selectedInvoices.push(options.model);
                }

                console.log("editApprovedAmount");
                CalculateSelectedInvoices();

                _IsDirty = true;
            }
        });

        item.bind("focus", (() => {
            setTimeout(function () {
                $('[data-role="numerictextbox"]').select();
            }, 50);
        }));
    }

    function editDiscApprovedAmount(container, options) {
        console.log(container);
        let item = $('<input data-bind="value:' + options.field + '"/>').appendTo(container);

        item.kendoNumericTextBox({
            spinners: false,
            step: 0,
            min: 0,
            change: function (e) {
                let invoiceNumber = options.model.InvoiceNumber
                let dataId = $(this)[0].element.closest('tr').attr('data-uid');
                let exists = false;
                let existingIndex = 0;

                if (this.value() > options.model.BalanceToPay) {
                    console.log(options.model);
                    options.model.set("DiscountApproved", options.model.DiscountApproved);
                    showKendoAlert("The Discount Approved Amount cannot exceed the Balance To Pay.");
                }

                for (let j = 0; j < _selectedInvoices.length; j++) {
                    if (_selectedInvoices[j].InvoiceNumber == invoiceNumber) {
                        exists = true;
                        existingIndex = j;

                        _selectedInvoices[j].DiscountApproved = this.value();
                        break;
                    }
                }

                if (!exists) {
                    let grid = $("#invoiceGrid").data("kendoGrid");
                    let row = grid.table.find("[data-uid=" + dataId + "]");
                    grid.select(row);

                    _selectedInvoices.push(options.model);
                }
                console.log("editDiscApprovedAmount");
                CalculateSelectedInvoices();

                _IsDirty = true;
            }
        });

        item.bind("focus", (() => {
            setTimeout(function () {
                $('[data-role="numerictextbox"]').select();
            }, 50);
        }));
    }

    $('#ResetOptions').kendoPopup({
        anchor: $('#ResetOptionsButton'),
        origin: "bottom left",
        position: "top left",
        collision: "fit",
        close: function () {
            $('#myOverlay').hide();
        }
    }).data('kendoPopup');


</script>
