//
let refreshPaymentCenterFlag = false;

let bankHeaderDetail = {
    bankCode: "",
    bankDescription: "",
    bankLastCheckCompleted: 0,
    cashAccountCode: "",
    cashAccountDescription: "",
    discountAccountCode: "",
    discountAccountDescription: ""
};

let InvoiceFilter = {
    BatchStatus: '',    
    BatchStatusDescription: '', 
    BatchId: 0,
    BankCode: '',
    APAccountCode: 'ALL',    
    VendorCode: 'ALL',    
    ClientCode: 'ALL',
    DateToPayCutoff: '',
    CheckDate: '',
    PaidByClient: 0,
    Production: 1,
    GLDist: 1,
    Television: 1,
    Radio: 1,
    Newspaper: 1,
    Magazine: 1,
    Internet: 1,
    Outdoor: 1,
    GridViewType: 'PaymentCenterInvoiceDetailGrid',
    InitialLoadFlag: true
};

let batchHeader = {
    BatchId: '',//not needed for save
    BatchName: '', 
    UserId: '',
    CreationDate: '', //not needed for save
    LastUpdateDate: '', //not needed for save
    BatchStatus: '', //not needed for save
    BankCode: '',
    PaymentDate: '',
    PayCutoffDate: '',
    PostingPeriod: '',
    MediaInternet: 0,
    MediaMagazine: 0,
    MediaNewspaper: 0,
    MediaOOH: 0,
    MediaRadio: 0,
    MediaTelevision: 0,
    NonClientItems: 0,
    ProductionItems: 0,
    AllInvoicesSelect: 0,
    PaidByClientSelect: 0
};

let clientSelect = [];

let vendorSelect = [];

let glSelect = [];

let invoiceSelect = [];

$(window).resize((e, collapseFlag) => {    
    ResizeGrid(collapseFlag);
});

function GenerateColumnDetailSettings() {
    try {
        $.ajax({
            type: "Get",
            url: "../../Inbox/GetGridColumnSettings?GridName=" + GetGridView(),
            dataType: "json",
            success: function (response) {
                myColumns = new Array();
                //add pay checkbox column
                myColumns.push({ selectable: true, width: "46px", attributes: { class: 'gridCheckBox', name: "#= 'payCheckBox_' + InvoiceNumber #" }, headerTemplate: PayAllCheckBoxTemplate });
                for (let i = 0; i < response.length; i++) {
                    switch (response[i].ColumnName) {
                        case "PayMethod":
                            myColumns.push({ field: "PayMethod", title: "Pay</br>Method", hidden: !response[i].IsVisible, template: PayMethodTemplate, editor: PayMethodDropList, width: response[i].ColumnWidth, attributes: { name: "#= 'PayType' + InvoiceNumber #" }, menu: false });
                            break;
                        case "PayToVendorCode":
                            myColumns.push({ field: "PayToVendorCode", title: "Pay To</br>Vendor Code", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, menu: false });
                            break;
                        case "InvoiceNumber":
                            myColumns.push({ field: "InvoiceNumber", title: "Invoice</br>Number", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, menu: false });
                            break;
                        case "InvoiceType":
                            myColumns.push({ field: "InvoiceType", title: "Invoice</br>Type", hidden: !response[i].IsVisible, width: response[i].ColumnWidth });
                            break;
                        case "DateToPay":
                            myColumns.push({ field: "DateToPay", title: "Date</br>To Pay", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, template: "#= kendo.toString(kendo.parseDate(DateToPay, 'yyyy-MM-dd'), 'MM/dd/yyyy') #", menu: false });
                            break;
                        case "BalanceToPay":
                            myColumns.push({ field: "BalanceToPay", title: "Balance</br>To Pay", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" }, menu: false });
                            break;
                        case "ApprovedAmount":
                            myColumns.push({ field: "ApprovedAmount", title: "Approved</br>Amount", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;", class: 'gridApprovedAmount', name: "#= 'approvedAmount_' + InvoiceNumber #" }, editor: editApprovedAmount, menu: false });
                            break;
                        case "GLAccount":
                            myColumns.push({ field: "GLAccount", title: "A/P GL</br>Account", hidden: !response[i].IsVisible, width: response[i].ColumnWidth });
                            break;
                        case "VendorCode":
                            myColumns.push({ field: "VendorCode", title: "Vendor</br>Code", hidden: !response[i].IsVisible, width: response[i].ColumnWidth });
                            break;
                        case "VendorName":
                            myColumns.push({ field: "VendorName", title: "Vendor Name", hidden: !response[i].IsVisible, width: response[i].ColumnWidth });
                            break;
                        case "InvoiceDescription":
                            myColumns.push({ field: "InvoiceDescription", title: "Invoice</br>Description", hidden: !response[i].IsVisible, width: response[i].ColumnWidth });
                            break;
                        case "InvoiceDate":
                            myColumns.push({ field: "InvoiceDate", title: "Invoice</br>Date", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, template: "#= kendo.toString(kendo.parseDate(InvoiceDate, 'yyyy-MM-dd'), 'MM/dd/yyyy') #" });
                            break;
                        case "InvoiceTotal":
                            myColumns.push({ field: "InvoiceTotal", title: "Invoice</br>Total", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" }, menu: false });
                            break;
                        case "InvoiceBalance":
                            myColumns.push({ field: "InvoiceBalance", title: "Invoice</br>Balance", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "DiscountPercentage":
                            myColumns.push({ field: "DiscountPercentage", title: "Discount %", hidden: !response[i].IsVisible, width: response[i].ColumnWidth });
                            break;
                        case "DiscountAvailable":
                            myColumns.push({ field: "DiscountAvailable", title: "Discount</br>Available", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "DiscountApproved":
                            myColumns.push({
                                field: "DiscountApproved", title: "Discount</br>Approved", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}",
                                attributes: { style: "text-align: right;", class: 'gridDiscountApproved', name: "#= 'discountApproved_' + InvoiceNumber #" },
                                editor: editDiscApprovedAmount,
                                editable: (dataItem) => {
                                    return dataItem.DiscountPercentage > 0;
                                }
                            });
                            break;
                        case "WithholdingTax":
                            myColumns.push({ field: "WithholdingTax", title: "Withholding</br>Tax", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "PaidPreviously":
                            myColumns.push({ field: "PaidPreviously", title: "Paid</br>Previously", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "NonBillableAmount":
                            myColumns.push({ field: "NonBillableAmount", title: "Non-Billable</br>Amount", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "BillableAmount":
                            myColumns.push({ field: "BillableAmount", title: "Billable</br>Amount", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "DirectBillAmount":
                            myColumns.push({ field: "DirectBillAmount", title: "Direct Bill/Rec</br>Amount", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "ProdAdvanceBalance":
                            myColumns.push({ field: "ProdAdvanceBalance", title: "Prod Advance</br>Balance", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "CashReceived":
                            myColumns.push({ field: "CashReceived", title: "Cash</br>Received", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        case "TotalQualified":
                            myColumns.push({ field: "TotalQualified", title: "Total</br>Qualified", hidden: !response[i].IsVisible, width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" } });
                            break;
                        //this column should only be visible if the "Paid By Client" selector is chosen
                        //column hidden by default initially
                        case "PaidByClientAmount":
                            myColumns.push({ field: "PaidByClientAmount", title: "Paid By</br>Client Amount", width: response[i].ColumnWidth, format: "{0:c}", attributes: { style: "text-align: right;" }, hidden: true });
                            break;

                    };
                }
                columnSettingsReady = true;
            },
            error: function (err) {
                showKendoAlert(err);
            }
        });
    } catch (e) {
        console.log(e);
    }
}

//parent call from Webvantage.ts
function GetRefreshPaymentCenterFlag() {
    return refreshPaymentCenterFlag;
}
//parent call from Webvantage.ts
function ResetRefreshPaymentCenterFlag() {
    refreshPaymentCenterFlag = false;
}

function InitializeScreen(batchId, paymentModule) {    
    $.ajax({
        url: 'GetExistingBatchDetail?BatchId=' + batchId + "&PaymentModule=" + paymentModule,
        dataType: 'json',
        success: function (result) {

            let bankList = $("#Bank").data("kendoDropDownList");

            if (result) {
                if (result.BatchHeader) {                    
                    _BatchStatus = result.BatchHeader.BatchStatus;

                    ProcessBatchHeaderDetail(result.BatchHeader);

                    if (result.Accounts) {                        
                        ProcessBatchAccountDetails(result.Accounts);
                    }
                    if (result.Vendors) {                        
                        ProcessBatchVendorDetails(result.Vendors);
                    }
                    if (result.Clients) {
                        ProcessBatchClientDetails(result.Clients);
                    }

                    _BatchName = result.BatchHeader.BatchName;
                    ManageScreenStatus(result.BatchHeader.BatchId, result.BatchHeader.BatchStatusDescription, result.BatchHeader.BatchName);
                    bankList.trigger("change");                                                            
                }

                _PageInitialized = true;
            }
        },
        error: function (result) {
            console.log("error");
        }
    });
}

function LoadGridView() {
    console.log("calling LoadGridView", new Error().stack);
    if (_PageInitialized == false || columnSettingsReady == false) {            
        setTimeout(LoadGridView, 250);
    } else {        
        if (_BatchStatus == 'C') {
            createCompletedBatchCheckDetailsDataSource();
            CreateCompletedDetailViewGrid();
        } else {            
            createInvoiceGridDataSource();            
            //if (GetGridView() == "PaymentCenterInvoiceDetailGrid") {
            //    CreateDetailViewGrid();
            //    $("#columnSelectorListItem").show();
            //} else {
            //    CreateSummaryViewGrid();
            //    $("#columnSelectorListItem").hide();
            //}            
            CreateDetailViewGrid();
            if (GetGridView() == "PaymentCenterInvoiceDetailGrid") {                
                $("#columnSelectorListItem").show();
            } else {                
                $("#columnSelectorListItem").hide();
            }
        }                        
        
        var grid = $("#invoiceGrid").data("kendoGrid");
        //grid.thead.on("click", ".k-checkbox", gridSelectAllClick);
        $("#checkAll").on("click", function (e) {
            gridSelectAllClick(e);
            return true;
        });
        
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read().then(function () {
            if (_BatchId !== 0) {
                SelectedInvoiceManagement();
            }
            console.log("calling refresh", new Error().stack);
            grid.refresh();
        });

        if (InvoiceFilter.InitialLoadFlag) {
            

            ResizeGrid(false);
        }
    }      
}

function SelectedInvoiceManagement() {
    let grid = $("#invoiceGrid").data("kendoGrid");
    let input;
    let checkedCnt = 0;    
    
    for (let i = 0; i < InvoiceDataSource.data().length; i++) {        
        input = `td[name='payCheckBox_${InvoiceDataSource.data()[i].InvoiceNumber}'] > input[type='checkbox']`;

        if (InvoiceDataSource.data()[i].Pay) {
            $(input).prop('checked', true);
            $(input).closest('tr').addClass('k-state-selected');
               
            _selectedInvoices.push(InvoiceDataSource.data()[i]);
            checkedCnt++;
        }
        
    }
    
    $("#checkAll")[0].checked = checkedCnt == InvoiceDataSource.data().length;

    CalculateSelectedInvoices();
}

function SetupAdditionalGridFeatures() {
    let grid = $("#invoiceGrid").data('kendoGrid');

    $("#invoiceGrid").find("#col-menu").kendoColumnMenu({
        sortable: false,
        filterable: false,
        columns: true,
        dataSource: grid.dataSource,
        owner: grid,
        init: function (e) {
            var mylist = e.container.find(".k-columns-item>ul");            

            mylist.children().each(function (e) {                
                var span = $(this).find("span");                
                $(this).find("span > br").replaceWith(" ");
                //var text = span[0].lastChild.nodeValue;                
                //span[0].lastChild.nodeValue = changeLabelText(text);
            });
        },
        open: function (e) {            
            var menu = e.container.children().data("kendoMenu");                
            menu.open(menu.element.find("li:first"));            
        }
    });  

    $("#View").kendoDropDownList({
        value: InvoiceFilter.GridViewType == "PaymentCenterInvoiceDetailGrid" ? "Detail" : "Summary",
        dataSource: {
            data: ["Detail", "Summary"]
        },
        change: function (e) {
            onGridViewSelectionChange(this.value());
        }
    });

    if (_BatchStatus == 'C') {
        $("#GridViewType").hide();
    }

    LoadColumnVisibilitySettings();    
}

function onGridViewSelectionChange(ViewType) {    
    let currentViewType = ViewType;
    let previousViewType = InvoiceFilter.GridViewType;

    InvoiceFilter.GridViewType = ViewType == "Detail" ? "PaymentCenterInvoiceDetailGrid" : "PaymentCenterInvoiceSummaryGrid";;

    //if (_IsDirty) {
    //    promptSave().done(() => ProcessInboxViewChange(previousInboxType));
    //} else {
    //    ProcessInboxViewChange(previousInboxType);
    //}

    if (previousViewType !== InvoiceFilter.GridViewType) {        
        columnSettingsReady = false;        
        DestroyGrid();        
        LoadUserColumnSettings();        
        _PageInitialized = true;        
        LoadGridView();        
        ReloadGrid();
    }
}

function DestroyGrid() {
    var dataGrid = $("#invoiceGrid").data("kendoGrid");
    dataGrid.destroy();
    $("#invoiceGrid").empty();
}

function ReloadGrid() {    
    if ($("#invoiceGrid").data("kendoGrid") === undefined || !columnSettingsReady) {
        setTimeout(ReloadGrid, 250); /* this checks the flag every 100 milliseconds*/
    } else {
        let grid = $("#invoiceGrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);
        grid.dataSource.read();
        _selectedInvoices = [];
        CalculateSelectedInvoices();
        //ResetSelectedInvoiceTotals();
    }
}

function ProcessSelectedFilterChange(FilterName, SelectedItems) {    
    let dataItem = SelectedItems;//e.sender.dataItems();    
    let selections = '';
    let selectionCount = 0;
    let selectedFilter = FilterName;    

    //selectedFilter = e.sender.element[0].id        

    if (selectedFilter == "IncludeItemsList") {
        InvoiceFilter.Production = 0;
        InvoiceFilter.GLDist = 0;

        $.each(dataItem, (i, item) => {
            switch (item.Code) {
                case "GL":
                    InvoiceFilter.GLDist = 1;
                    break;
                case "Production":
                    InvoiceFilter.Production = 1;
                    break;
            }
        });
    } else if (selectedFilter == "MediaList") {
        InvoiceFilter.Internet = 0;
        InvoiceFilter.Magazine = 0;
        InvoiceFilter.Newspaper = 0;
        InvoiceFilter.Outdoor = 0;
        InvoiceFilter.Radio = 0;
        InvoiceFilter.Television = 0;

        $.each(dataItem, (i, item) => {
            switch (item.Code) {
                case "Internet":
                    InvoiceFilter.Internet = 1;
                    break;
                case "Magazine":
                    InvoiceFilter.Magazine = 1;
                    break;
                case "Magazine":
                    InvoiceFilter.Magazine = 1;
                    break;
                case "Out of Home":
                    InvoiceFilter.Outdoor = 1;
                    break;
                case "Radio":
                    InvoiceFilter.Radio = 1;
                    break;
                case "Television":
                    InvoiceFilter.Television = 1;
                    break;

            }
        });
    } else {
        switch (FilterName) {
            case "APAccountList":
                InvoiceFilter.APAccountCode = SelectedItems.length > 0 ? SelectedItems.join(",") : "ALL";
                break;
            case "ClientList": 
                InvoiceFilter.ClientCode = SelectedItems.length > 0 ? SelectedItems.join(",") : "ALL";
                break;
            case "VendorList":
                InvoiceFilter.VendorCode = SelectedItems.length > 0 ? SelectedItems.join(",") : "ALL";
                break;
        }

        if (InvoiceFilter.BatchStatus == 'O') {
            //_IsDirty = true;
            InvoiceFilter.BatchStatus = 'E';  //Open batch is now in Edit mode
            InvoiceFilter.BatchStatusDescription = 'Edit';            
        }
    }    
}

function ProcessBatchHeaderDetail(batchHeader) {
    let bankList = $("#Bank").data("kendoDropDownList");
    bankList.value(batchHeader.BankCode);   

    InvoiceFilter.BatchId = _BatchId;
    InvoiceFilter.BatchStatus = batchHeader.BatchStatus;
    InvoiceFilter.BankCode = batchHeader.BankCode;
    InvoiceFilter.DateToPayCutoff = batchHeader.PayCutoffDate;
    InvoiceFilter.CheckDate = batchHeader.PaymentDate;
    InvoiceFilter.Production = batchHeader.ProductionItems ? 1 : 0;
    InvoiceFilter.NonClientItems = batchHeader.GLDist;
            
    if (batchHeader.AllInvoicesSelect == true && batchHeader.PaidByClientSelect == false) {
        InvoiceFilter.PaidByClient = 0;
    } else {
        InvoiceFilter.PaidByClient = 1;
    }

    //populate the "Media Filter" items
    let mediaList = $("#MediaList").data("kendoMultiSelect");
    let mediaSelected = [];    

    if (batchHeader.MediaInternet == true) {
        mediaSelected.push("Internet");
    }
    if (batchHeader.MediaMagazine == true) {
        mediaSelected.push("Magazine");
    }
    if (batchHeader.MediaNewspaper == true) {
        mediaSelected.push("Newspaper");
    }
    if (batchHeader.MediaOOH == true) {
        mediaSelected.push("Out of Home");
    }
    if (batchHeader.MediaRadio == true) {
        mediaSelected.push("Radio");
    }
    if (batchHeader.MediaTelevision == true) {
        mediaSelected.push("Television");
    }

    mediaList.value(mediaSelected);

    //populate the "Include" items
    let inludeSelectList = $("#IncludeItemsList").data("kendoMultiSelect");
    let includeSelected = [];

    if (batchHeader.ProductionItems == true) {
        includeSelected.push("Production");
    }
    if (batchHeader.NonClientItems == true) {
        includeSelected.push("GL");
    }    

    inludeSelectList.value(includeSelected);
}

function ProcessBatchAccountDetails(accountDetail) {       
    let accountList = $("#APAccountList").data("kendoMultiSelect");
    let accounts = [];

    InvoiceFilter.APAccountCode = '';

    for (let i = 0; i < accountDetail.length; i++) {
        accounts.push(accountDetail[i].GLCode)
        if (i > 0) {
            InvoiceFilter.APAccountCode += ",";
        }
        InvoiceFilter.APAccountCode += accountDetail[i].GLCode
    }

    accountList.value(accounts);    
}

function ProcessBatchVendorDetails(vendorDetail) {
    let vendorsList = $("#VendorList").data("kendoMultiSelect");
    let vendors = [];

    InvoiceFilter.VendorCode = '';    

    for (let i = 0; i < vendorDetail.length; i++) {
        vendors.push(vendorDetail[i].Code)
        if (i > 0) {
            InvoiceFilter.VendorCode += ",";
        }
        InvoiceFilter.VendorCode += vendorDetail[i].Code
    }

    vendorsList.value(vendors);
}

function ProcessBatchClientDetails(clientDetail) {
    let clientList = $("#ClientList").data("kendoMultiSelect");
    let clients = [];

    InvoiceFilter.ClientCode = '';

    for (let i = 0; i < clientDetail.length; i++) {
        clients.push(clientDetail[i].Code)
        if (i > 0) {
            InvoiceFilter.ClientCode += ",";
        }
        InvoiceFilter.ClientCode += clientDetail[i].Code
    }

    clientList.value(clients);
}

function DataLossOnFilterChange(selectList, dataItem) {       
    let invoiceValue = '';                
    let dataLoss = false;
    
    for (let i = 0; i < _selectedInvoices.length; i++) {
        switch (selectList) {
            case "APAccountList":
                invoiceValue = _selectedInvoices[i].GLAccount;
                if (invoiceValue == dataItem.Code) {
                    dataLoss = true;
                }                
                break;
            case "ClientList":
                let data = {
                    InvoiceType: _selectedInvoices[i].InvoiceType,
                    ApId: _selectedInvoices[i].APId,
                    ClientCode: dataItem.Code
                };

                ClientExistsForInvoice(data).then(function (exists) {
                    if (exists == 1) {                        
                        dataLoss = true;
                    }                        
                });
                break;
            case "VendorList":
                invoiceValue = _selectedInvoices[i].PayToVendorCode;
                if (invoiceValue == dataItem.Code) {
                    dataLoss = true;
                } 
                break;
        }

        if (dataLoss) {
            break;
        }        
    }     

    return dataLoss;
}

function DataLossNotification(notificationType) {
    //notification types:
    //      header: a batch-header change has been requested, notify user of potential dataloss
    //      refresh: a refresh has been requested, notify user of potential dataloss
    //      bank:  a batch-header change has been requested, notify user of potential dataloss
    let dfd = jQuery.Deferred();
    let message = '';

    if (notificationType == "header") {
        message = "Changing the filter criteria may remove Invoices that are selected to be paid.  Are you sure you want to continue?";
    } else if (notificationType == "refresh") {
        message = "Refreshing the grid will discard current payment selections.  Are you sure you want to continue?";
    } else {
        //bank change
        message = "Changing the selected Bank will clear any existing Invoice filters and selections.  Are you sure you want to continue?"
    }
    
    showKendoConfirm(message)
        .done(function () {        
            dfd.resolve(true);
        })
        .fail(function () {                        
            dfd.resolve(false);
        });        

    
    return dfd.promise();
}

function DeleteBatchNotification() {
    let dfd = jQuery.Deferred();

    showKendoConfirm("Are you sure you want to delete this payment batch, you can't undo this operation?")
        .done(function () {
            dfd.resolve(true);
        })
        .fail(function () {
            dfd.resolve(false);
        });


    return dfd.promise();
}


function RemoveItemFromSelectedList(selectList, dataValue) {
    let list = $("#" + selectList).data("kendoMultiSelect");
    let remove = [dataValue];
    let values = list.value().slice();

    values = $.grep(values, function (value) {
        return $.inArray(value, remove) == -1;
    });

    list.dataSource.filter({});
    list.value(values);
}

function ClientExistsForInvoice(requestData) {    
    return $.ajax({        
        url: 'ClientExistsForInvoice',
        data: requestData,
        dataType: 'json'
    });         
}

function multiSelectChange(e) {
    console.log("multiSelectChange");
    ProcessSelectedFilterChange(e.sender.element[0].id, e.sender.dataItems());
    setTimeout(function () {
        RefreshInvoiceGrid();
    }, 250);

    
}

function multiSelectSelect(e) {
    console.log("multiSelectSelect");
    if (_headerLocked) {
        e.preventDefault();
        FilterChangePromptForDataLoss(e, "selectEvent");        
    } else {
        //multiSelectChange(e);
    }
}

function multiSelectDeselect(e) {
    console.log("multiSelectDeselect");    
    let selectList = e.sender.element[0].id;
    let dataItem = e.dataItem;

    if (_headerLocked) {
        e.preventDefault();
        FilterChangePromptForDataLoss(e, "deselectEvent");        
    }

    //if (DataLossOnFilterChange(selectList, dataItem)) {
    //    DataLossNotification("header").done((continueFlag) => {
    //        if (continueFlag) {
    //            RemoveItemFromSelectedList(selectList, dataItem.Code);
    //            ProcessSelectedFilterChange(e.sender.element[0].id, e.sender.dataItems());
    //            RefreshInvoiceGrid();

    //            _IsDirty = true;    
    //        }
    //    });
    //} else {
    //    RemoveItemFromSelectedList(selectList, dataItem.Code);
    //    ProcessSelectedFilterChange(e.sender.element[0].id, e.sender.dataItems());
    //    RefreshInvoiceGrid();
    //}    
}

function FilterChangePromptForDataLoss(e, eventType) {    
    DataLossNotification("header").then(function (continueChange) {
        if (continueChange) {
            switch (eventType) {
                case "selectEvent":
                    let selected = [];
                    selected = e.sender.value();

                    selected.push(e.dataItem.Code);
                    e.sender.value(selected);

                    break;
                case "deselectEvent":
                    let selectList = e.sender.element[0].id;
                    let dataItem = e.dataItem;
                    RemoveItemFromSelectedList(selectList, dataItem.Code);
                    break;
                case "?":
                    break;
            }


            DeleteBatchHeader();

            _headerLocked = false;

            setTimeout(function () {
                ProcessSelectedFilterChange(e.sender.element[0].id, e.sender.dataItems());
            }, 1000);

            ManageSaveDeleteButtons();
            ManageInvoiceSelection();
            RefreshInvoiceGrid();
        }        
    });
}

function ViewBatchSummary() {    
    $("#showSummaryDialog").ejDialog("destroy");        
    $("#showSummaryDialog").ejDialog({
        contentUrl: "_ViewBatchSummary?BatchId=" + _BatchId,
        title: "Summary by Vendor",
        showOnInit: false,
        contentType: "iframe",
        height: "480px",
        width: "1200px",
        showFooter: false,
        enableModal: true,
        allowDraggable: false,
        backgroundScroll: false,
        enableResize: false,
        enableAutoResize: true,
        close: function (args) {
            //closeUploadModalAndRefresh($scope.expenseReportHeader.InvoiceNumber);
        }
    });
    $("#showSummaryDialog").ejDialog("open");
    $("#showSummaryDialog").ejDialog("refresh");
}

function LockedInvoiceSummary(lockedInvoices) {    
    $("#lockedGrid").kendoGrid({
        width: 750,        
        columns: [            
            { field: "InvoiceNumber", title: "Invoice Number" },
            { field: "UserName", title: "Batch Owner" },
            { field: "CreationDate", title: "Date Created", template: "#= kendo.toString(kendo.parseDate(CreationDate, 'yyyy-MM-dd'), 'MM/dd/yyyy') #"  },
            { field: "BatchName", title: "Batch Name", width: "450", attributes: { style: "max-width: 450px;" } }
        ],
        dataSource: {
            data: lockedInvoices
        }        
    });

    //$("#showLockedInvoiceDialog").ejDialog("destroy");
    $("#showLockedInvoiceDialog").ejDialog({        
        //contentUrl: "_LockedInvoiceSummary",
        title: "Locked Invoices",
        showOnInit: false,
        contentType: "iframe",
        height: "480px",
        width: "800px",
        showFooter: false,
        enableModal: true,
        allowDraggable: false,
        backgroundScroll: false,
        enableResize: false,
        enableAutoResize: true,
        close: function (args) {
            //closeUploadModalAndRefresh($scope.expenseReportHeader.InvoiceNumber);
        }
    });
    $("#showLockedInvoiceDialog").ejDialog("open");
    $("#showLockedInvoiceDialog").ejDialog("refresh");
}

function CalculateSelectedInvoices() {    
    _invoiceTotals = 0;
    _invoiceBalance = 0;
    _approvedAmount = 0;
    
    for (let i = 0; i < _selectedInvoices.length; i++) {
        _invoiceTotals += _selectedInvoices[i].InvoiceTotal;
        _invoiceBalance += _selectedInvoices[i].InvoiceBalance;
        _approvedAmount += _selectedInvoices[i].ApprovedAmount;
    }

    $("#invoiceTotals").html(kendo.toString(_invoiceTotals, "c"));
    $("#invoiceBalance").html(kendo.toString(_invoiceBalance, "c"));
    $("#approvedAmount").html(kendo.toString(_approvedAmount, "c"));
}

function SaveBatchHeader() {
    let media = $("#MediaList").data("kendoMultiSelect").value();
    let includeItems = $("#IncludeItemsList").data("kendoMultiSelect").value();
    let checkDate = $("#checkDate").data("kendoDatePicker").value();
    let postingPeriod = $("#postingPeriod").data("kendoDropDownList").value();
    let payCutoffDate = $("#dateToPayCutoff").data("kendoDatePicker").value();
    let glItems = $("#APAccountList").data("kendoMultiSelect").value();
    let vendorItems = $("#VendorList").data("kendoMultiSelect").value();
    let clientItems = $("#ClientList").data("kendoMultiSelect").value();
    let bank = $("#Bank").data("kendoDropDownList").value();
    
    if (InvoiceFilter.BatchStatus == 'O' || InvoiceFilter.BatchStatus == 'E') {
        batchHeader.BatchId = InvoiceFilter.BatchId;
    }

    InvoiceFilter.BankCode = bank;
    InvoiceFilter.DateToPayCutoff = payCutoffDate;
    InvoiceFilter.CheckDate = checkDate;
    
    //InvoiceFilter.PostingPeriod = postingPeriod;

    //////batchHeader.BatchName = '';
    //////batchHeader.UserId = ''; //not needed for save
    //////batchHeader.CreationDate = ''; //not needed for save
    //////batchHeader.LastUpdateDate = ''; //not needed for save
    batchHeader.BatchStatus = 'O';    
    batchHeader.BankCode = InvoiceFilter.BankCode;
    batchHeader.PaymentDate = checkDate;
    batchHeader.PayCutoffDate = payCutoffDate;
    batchHeader.PostingPeriod = postingPeriod;
    batchHeader.MediaInternet = media.includes("Internet") ? true : false;
    batchHeader.MediaMagazine = media.includes("Magazine") ? true : false;
    batchHeader.MediaNewspaper = media.includes("Newspaper") ? true : false;
    batchHeader.MediaOOH = media.includes("Out of Home") ? true : false;
    batchHeader.MediaRadio = media.includes("Radio") ? true : false;
    batchHeader.MediaTelevision = media.includes("Television") ? true : false;

    batchHeader.NonClientItems = includeItems.includes("GL") ? true : false;
    batchHeader.ProductionItems = includeItems.includes("Production") ? true : false;

    batchHeader.AllInvoicesSelect = InvoiceFilter.PaidByClient ? false : true;
    batchHeader.PaidByClientSelect = InvoiceFilter.PaidByClient ? true : false;

    let postData = {
        BatchHeader: {},
        Invoices: new Array(),
        Clients: new Array(),
        Accounts: new Array(),
        Vendors: new Array(),
        BatchHeaderOnly: true
    }

    postData.BatchHeader = batchHeader;    
    postData.Accounts = PackageAccountData(glItems);
    postData.Clients = PackageClientData(clientItems);
    postData.Vendors = PackageVendorData(vendorItems);

    $.ajax({
        type: "POST",
        url: "CreateNewBatch",
        data: postData,
        success: function (response) {            
            _IsDirty = false;
            _BatchId = response.BatchId;

            InvoiceFilter.BatchId = _BatchId;
            InvoiceFilter.BatchStatus = response.BatchStatus;
            InvoiceFilter.BatchStatusDescription = response.BatchStatusDescription;
            InvoiceFilter.BatchName = response.BatchName;

            //parent refresh flag
            refreshPaymentCenterFlag = true;
            
            _headerLocked = true;
            SetBatchStatusDisplay(InvoiceFilter.BatchStatusDescription);
            ManageSaveDeleteButtons();
            ManageInvoiceSelection();

            refreshPage();
        },
        error: function (response) {
        }
    });
}

function SaveBatch() {
    let media = $("#MediaList").data("kendoMultiSelect").value();
    let includeItems = $("#IncludeItemsList").data("kendoMultiSelect").value();
    let checkDate = $("#checkDate").data("kendoDatePicker").value();
    let postingPeriod = $("#postingPeriod").data("kendoDropDownList").value();
    let payCutoffDate = $("#dateToPayCutoff").data("kendoDatePicker").value();
    //let glItems = $("#APAccountList").data("kendoMultiSelect").value();
    //let vendorItems = $("#VendorList").data("kendoMultiSelect").value();
    //let clientItems = $("#ClientList").data("kendoMultiSelect").value();
    let paymentType = '';
    let paymentTypeCode = '';
    let selector = '';
    let lockedItems = [];

    //validation needed for selected data prior to allowing save
    CheckForOpenInvoices().then(function (lockedInvoices) {
        if (lockedInvoices.length) {
            lockedItems = lockedInvoices;
            //LockedInvoiceSummary(lockedInvoices);
            let msg = "This batch contains invoices that have been saved to another batch prior to this operation.<br>The following invoices have been automatically removed prior to saving.<br>";
            for (let i = 0; i < lockedInvoices.length; i++) {
                msg += "<br>" + lockedInvoices[i].InvoiceNumber;
            }

            showKendoAlert(msg);            
        }
    }).then(function () {
        if (InvoiceFilter.BatchStatus == 'O' || InvoiceFilter.BatchStatus == 'E') {
            batchHeader.BatchId = InvoiceFilter.BatchId;
        }

        ////batchHeader.BatchName = '';
        ////batchHeader.UserId = ''; //not needed for save
        ////batchHeader.CreationDate = ''; //not needed for save
        ////batchHeader.LastUpdateDate = ''; //not needed for save
        batchHeader.BatchStatus = 'O';
        batchHeader.BankCode = InvoiceFilter.BankCode;
        batchHeader.PaymentDate = checkDate;
        batchHeader.PayCutoffDate = payCutoffDate;
        batchHeader.PostingPeriod = postingPeriod;
        batchHeader.MediaInternet = media.includes("Internet") ? true : false;
        batchHeader.MediaMagazine = media.includes("Magazine") ? true : false;
        batchHeader.MediaNewspaper = media.includes("Newspaper") ? true : false;
        batchHeader.MediaOOH = media.includes("Out of Home") ? true : false;
        batchHeader.MediaRadio = media.includes("Radio") ? true : false;
        batchHeader.MediaTelevision = media.includes("Television") ? true : false;

        batchHeader.NonClientItems = includeItems.includes("GL") ? true : false;
        batchHeader.ProductionItems = includeItems.includes("Production") ? true : false;

        batchHeader.AllInvoicesSelect = InvoiceFilter.PaidByClient ? false : true;
        batchHeader.PaidByClientSelect = InvoiceFilter.PaidByClient ? true : false;

        invoiceSelect = [];

        for (let i = 0; i < _selectedInvoices.length; i++) {
            let addInvoice = true;

            if (!glSelect.includes(_selectedInvoices[i].GLAccount)) {
                glSelect.push(_selectedInvoices[i].GLAccount);
            }

            if (!vendorSelect.includes(_selectedInvoices[i].VendorCode)) {
                vendorSelect.push(_selectedInvoices[i].VendorCode);
            }
            //clients are not displayed in the grid, should they be?
            //for now just pass the clientItems array created above from the multiselect to the controller save method
            //if (!clientSelect.includes(_selectedInvoices[i].ClientCode)) {
            //    clientSelect.clone(clientItems);
            //}

            //once the pay method has been changed a dirty span is added to the cell
            //the following will remove the span allowing access to the payment method text via .html();
            selector = "td[name='PayType" + _selectedInvoices[i].InvoiceNumber + "'] > span";
            $(selector).remove();

            selector = "td[name='PayType" + _selectedInvoices[i].InvoiceNumber + "']";
            paymentType = $(selector).html();

            switch (paymentType) {
                case "In House":
                    paymentTypeCode = "CWI";
                    break;
                case "ACH":
                    paymentTypeCode = "TP_ACH";
                    break;
                case "Virtual Card":
                    paymentTypeCode = "TP_VCC";
                    break;
                case "Check":
                    paymentTypeCode = "MCK";
                    break;
            }

            if (lockedItems.length) {
                for (let k = 0; k < lockedItems.length; k++) {
                    if (lockedItems[k].InvoiceNumber == _selectedInvoices[i].InvoiceNumber) {
                        addInvoice = false;
                        break;
                    }
                }
            }


            if (addInvoice) {
                invoiceSelect.push({
                    "InvoiceNumber": _selectedInvoices[i].InvoiceNumber,
                    "PayMethod": paymentTypeCode,
                    "InvoiceType": _selectedInvoices[i].InvoiceType,
                    "APId": _selectedInvoices[i].APId,
                    "ApprovedAmount": _selectedInvoices[i].ApprovedAmount,
                    "DiscApprovedAmount": _selectedInvoices[i].DiscountApproved
                });
            }

        }

        let postData = {
            BatchHeader: {},
            Invoices: new Array(),
            Clients: new Array(),
            Accounts: new Array(),
            Vendors: new Array(),
            BatchHeaderOnly: false
        }

        postData.BatchHeader = batchHeader;
        postData.Invoices = invoiceSelect;//PackageInvoiceData(invoiceSelect);
        postData.Accounts = PackageAccountData(glSelect);
        //postData.Clients = PackageClientData(clientSelect);
        postData.Vendors = PackageVendorData(vendorSelect);

        $.ajax({
            type: "POST",
            url: "CreateNewBatch",
            data: postData,
            success: function (response) {
                _IsDirty = false;
                _BatchId = response.BatchId;

                InvoiceFilter.BatchId = _BatchId;
                InvoiceFilter.BatchStatus = response.BatchStatus;
                InvoiceFilter.BatchStatusDescription = response.BatchStatusDescription;

                InvoiceFilter.BatchName = response.BatchName;
                refreshPaymentCenterFlag = true;                
                refreshPage();
            },
            error: function (response) {
            }
        });
    });
}

function CheckForOpenInvoices() {
    //check to insure the invoice hasn't been added and saved by another user in another batch    
    let postData = {
        BatchId: _BatchId,
        Invoices: new Array()        
    }

    let lockedInvoices = [];
    let dfd = jQuery.Deferred();

    for (let i = 0; i < _selectedInvoices.length; i++) {
        postData.Invoices.push(_selectedInvoices[i].InvoiceNumber);
    }    

    $.ajax({
        type: "POST",
        url: "CheckForOpenInvoices",
        data: postData,
        success: function (response) {
            if (response.length) {
                lockedInvoices = response;
            }
            dfd.resolve(lockedInvoices);
        },
        error: function (response) {
            dfd.resolve(lockedInvoices);
        }
    });

    //lockedInvoices.push({
    //    "BatchId": 44,
    //    "BatchName": "mm-SYSADM-2021/07/12 16:25:38",
    //    "InvoiceNumber": "1-58",
    //    "UserId": "SYSADM",
    //    "UserName": "Karen B. Able",
    //    "CreationDate": "/Date(1626121560000)/",
    //    "LastUpdateDate": "/Date(1626121560000)/"
    //});

    //dfd.resolve(lockedInvoices);

    return dfd.promise();
}

function PostBatch() {
    console.log(InvoiceFilter.BatchId);
    let postData = {
        BatchId: InvoiceFilter.BatchId,
        UserCode: 'AMA'        
    };
    
    $.ajax({
        type: "POST",
        url: "PostBatch",
        data: postData,
        success: function (response) {
            console.log(response);
        },
        error: function (response) {
        }
    });
}

function deleteBatch() {
    DeleteBatchNotification().done((continueFlag) => {
        if (continueFlag) {
            $.ajax({
                type: "POST",
                url: "DeleteExistingBatch",
                data: { BatchId: _BatchId },
                success: function (response) {
                    _IsDirty = false;
                    _BatchId = 0;
                    batchHeader.BatchId = null;

                    InvoiceFilter.BatchId = _BatchId;
                    InvoiceFilter.BatchStatus = "";
                    InvoiceFilter.BatchStatusDescription = "";                    
                    InvoiceFilter.BatchName = "";                    
                    InvoiceFilter.BankCode= '';
                    InvoiceFilter.APAccountCode= 'ALL';
                    InvoiceFilter.VendorCode= 'ALL';
                    InvoiceFilter.ClientCode= 'ALL';
                    InvoiceFilter.DateToPayCutoff= '';
                    InvoiceFilter.CheckDate= '';
                    InvoiceFilter.PaidByClient= 0;
                    InvoiceFilter.Production= 1;
                    InvoiceFilter.GLDist= 1;
                    InvoiceFilter.Television= 1;
                    InvoiceFilter.Radio= 1;
                    InvoiceFilter.Newspaper= 1;
                    InvoiceFilter.Magazine= 1;
                    InvoiceFilter.Internet= 1;
                    InvoiceFilter.Outdoor = 1;
                    
                    $("#Bank").data("kendoDropDownList").value([]);

                    //$("#CashAccountDisp").html("");
                    //$("#DiscountAccountDisp").html("");

                    //$("#APAccountList").data("kendoMultiSelect").value([]);                    
                    //$("#APAccountList").data("kendoMultiSelect").setOptions({ placeholder: "" });

                    //$("#VendorList").data("kendoMultiSelect").value([]);                    
                    //$("#VendorList").data("kendoMultiSelect").setOptions({ placeholder: "" });

                    //$("#ClientList").data("kendoMultiSelect").value([]);
                    //$("#ClientList").data("kendoMultiSelect").enable(false);
                    //$("#ClientList").data("kendoMultiSelect").setOptions({ placeholder: "" });
                    
                    //$("#MediaList").data("kendoMultiSelect").value([]);
                    //$("#MediaList").data("kendoMultiSelect").setOptions({ placeholder: "" });
                    //$("#mediaCheckBoxAll").attr("disabled", true);
                    //$("#mediaCheckBoxAll").prop("checked", false);
                    
                    //$("#IncludeItemsList").data("kendoMultiSelect").value([]);
                    //$("#IncludeItemsList").data("kendoMultiSelect").setOptions({ placeholder: "" });
                    
                    //$("#postingPeriod").data("kendoDropDownList").select(-1);
                    //$("#postingPeriod").data("kendoDropDownList").text("");
                    //$("#postingPeriod").data("kendoDropDownList").setOptions({ optionLabel: "" })

                    //$("#checkDate").data("kendoDatePicker").value("");
                    //$("#checkDate").attr("placeholder", "");                    

                    //$("#dateToPayCutoff").data("kendoDatePicker").value("");
                    //$("#dateToPayCutoff").attr("placeholder", "");                    

                    //$("#CashAccountDisp").html("");
                    //$("#DiscountAccountDisp").html("");

                    //$("#batchStatusDiv").html("");
                    
                    _headerLocked = false;
                    _bankSelected = false;
                    ManageBankSelection();
                    ManageSaveDeleteButtons();
                    ManageInvoiceSelection();
                    DestroyGrid();
                    LoadGridView();
                    $("#completedGridTotals").hide();
                    //$("#invoiceGrid").data("kendoGrid").refresh();
                    _selectedInvoices = [];
                    CalculateSelectedInvoices();
                    //ResetSelectedInvoiceTotals();
                },
                error: function (response) {
                }
            });

            refreshPaymentCenterFlag = true;
        }
    });
}

function refreshPage() {    
    //if (_IsDirty) {
    //    DataLossNotification("refresh").done((continueFlag) => {
    //        if (continueFlag) {
    //            _IsDirty = false;
    //            _selectedInvoices = [];
    //            CalculateSelectedInvoices();
    //            //ResetSelectedInvoiceTotals()                              
    //            LoadGridView();
    //        }
    //    });
    //} else {
    //    _selectedInvoices = [];
    //    CalculateSelectedInvoices();
    //    //ResetSelectedInvoiceTotals()        
    //    LoadGridView();
    //}
}

function RefreshInvoiceGrid() {
    //todo - check for dirty grid (invoices selected in grid)
    //if(_selectedInvoices.length > 0) 
    //console.log("refresh:", InvoiceFilter);
    _selectedInvoices = [];
    CalculateSelectedInvoices();
    
    //ResetSelectedInvoiceTotals()

    var dataGrid = $("#invoiceGrid").data("kendoGrid");
    dataGrid.dataSource.read().then(function () {
        SelectedInvoiceManagement();
    });
}

//function ResetSelectedInvoiceTotals() {
//    _selectedInvoices = [];
//    //CalculateSelectedInvoices();
//    //$("#invoiceTotals").html("$0.00");
//    //$("#invoiceBalance").html("$0.00");
//    //$("#approvedAmount").html("$0.00");
//}


function showResetOptions() {
    showPopupForElement($('#ResetOptions'), $('#ResetOptionsButton'));
}
function showPopupForElement(popUp, anchor) {
    closeAllPopups();
    var popUpData = popUp.data('kendoPopup');
    popUpData.options.anchor = anchor;
    popUpData.open();
    $('#myOverlay').show();
}
function closeAllPopups() {
    $('.toolbar-custom-drop').each(function () {
        $(this).data('kendoPopup').close();
    });
    $('#myOverlay').hide();
}

function columnReset(operationType) {
    ProcessColumnReset(operationType);
}


function ProcessColumnReset(operationType) {
    let gridName = '';
    let url = '';

    columnSettingsReady = false;

    gridName = GetGridView();
    if (operationType === "width") {
        url = "../../Inbox/ResetGridColumnWidths";
    } else {
        url = "../../Inbox/ResetGridColumnOrder";
    }

    $.ajax({
        type: "POST",
        url: url,
        data: { GridName: gridName },
        success: function (response) {
            closeAllPopups();

            DestroyGrid();
            LoadUserColumnSettings();            
            LoadGridView();
            ReloadGrid();
        },
        error: function (response) {
            closeAllPopups();
            showKendoAlert(`An error occurred while resetting the grid column ${operationType}, please contact support.`);
        }
    });
}

function GetGridView() {
    
    return InvoiceFilter.GridViewType;
}

function LoadUserColumnSettings() {    
    if (userViewSettingsReady === false) {
        setTimeout(LoadUserColumnSettings, 250);
    } else {
        GenerateColumnDetailSettings();        
    }
}

function PayAllCheckBoxTemplate(dataItem) {
    let display = "";    

    display = '<input id="checkAll" class="k-checkbox" data-role="checkbox" aria-label="Select all rows" aria-checked="false" type="checkbox">';

    return display;
}

function SaveUserColumnWidth(columnName, newColumnWidth) {
    let grid = $('#invoiceGrid').data('kendoGrid');

    let widthDetails = {
        GridName: GetGridView(),
        GridColumns: new Array()
    };

    let existingColumnName = "";

    let columnDetail = {
        ColumnName: "",
        ColumnID: -1,
        ColumnWidth: 0
    };

    //console.log(i, grid.columns[i].title);

    ////handle the column name for special columns (LastUpdatedNoTime and GeneratedNoTime)
    //if (columnName.includes("NoTime")) {
    //    columnDetail.ColumnName = columnName.replace("NoTime", "");
    //} else {
    //    columnDetail.ColumnName = columnName;
    //}
    columnDetail.ColumnName = columnName;

    //set new column index id
    columnDetail.ColumnWidth = newColumnWidth;

    widthDetails.GridColumns.push(columnDetail);

    $.post({
        url: "../../Desktop/Inbox/ProcessGridColumnWidthChange",
        data: JSON.stringify(widthDetails),//JSON.stringify(DirtyData),
        contentType: 'application/json',
        success: function (response) {
        },
        error: function (response) {
        }
    });
}

function SaveUserColumnOrder(columnDetails) {    
    let reorderDetails = {
        GridName: GetGridView(),
        GridColumns: columnDetails
    };        

    $.post({
        url: "ProcessGridColumnReorder",
        data: JSON.stringify(reorderDetails),
        contentType: 'application/json',
        success: function (response) {            
        },
        error: function (response) {            
        }
    });
}

function LoadColumnVisibilitySettings() {
    try {        
        $.ajax({
            type: "Get",
            url: "../../Inbox/GetGridColumnVisibilitySettings?GridView=" + GetGridView(),
            dataType: "json",
            success: function (response) {                
                let Pay = true;
                let PayMethod = true;
                let PayToVendorCode = true;
                let InvoiceNumber = true;
                let InvoiceType = true;
                let DateToPay = true;
                let BalanceToPay = true;
                let ApprovedAmount = true;
                let GLAccount = true;
                let VendorCode = true;
                let VendorName = true;
                let InvoiceDescription = true;
                let InvoiceDate = true;
                let InvoiceTotal = true;
                let InvoiceBalance = true;
                let DiscountPercentage = true;
                let DiscountAvailable = true;
                let DiscountApproved = true;
                let WithholdingTax = true;
                let PaidPreviously = true;
                let NonBillableAmount = true;
                let BillableAmount = true;
                let DirectBillAmount = true;
                let ProdAdvanceBalance = true;
                let CashReceived = true;
                let TotalQualified = true;
                let PaidByClientAmount = true;

                $.each(response, function (index, value) {
                    if (value == 'Pay') { Pay = false; }
                    if (value == 'PayMethod') { PayMethod = false; }
                    if (value == 'PayToVendorCode') { PayToVendorCode = false; }
                    if (value == 'InvoiceNumber') { InvoiceNumber = false; }
                    if (value == 'InvoiceType') { InvoiceType = false; }
                    if (value == 'DateToPay') { DateToPay = false; }
                    if (value == 'BalanceToPay') { BalanceToPay = false; }
                    if (value == 'ApprovedAmount') { ApprovedAmount = false; }
                    if (value == 'GLAccount') { GLAccount = false; }
                    if (value == 'VendorCode') { VendorCode = false; }
                    if (value == 'VendorName') { VendorName = false; }
                    if (value == 'InvoiceDescription') { InvoiceDescription = false; }
                    if (value == 'InvoiceDate') { InvoiceDate = false; }
                    if (value == 'InvoiceTotal') { InvoiceTotal = false; }
                    if (value == 'InvoiceBalance') { InvoiceBalance = false; }
                    if (value == 'DiscountPercentage') { DiscountPercentage = false; }
                    if (value == 'DiscountAvailable') { DiscountAvailable = false; }
                    if (value == 'DiscountApproved') { DiscountApproved = false; }
                    if (value == 'WithholdingTax') { WithholdingTax = false; }
                    if (value == 'PaidPreviously') { PaidPreviously = false; }
                    if (value == 'NonBillableAmount') { NonBillableAmount = false; }
                    if (value == 'BillableAmount') { BillableAmount = false; }
                    if (value == 'DirectBillAmount') { DirectBillAmount = false; }
                    if (value == 'ProdAdvanceBalance') { ProdAdvanceBalance = false; }
                    if (value == 'CashReceived') { CashReceived = false; }
                    if (value == 'TotalQualified') { TotalQualified = false; }
                    if (value == 'PaidByClientAmount') { PaidByClientAmount = false; }
                });

                ColumnSettings.Pay = Pay;
                ColumnSettings.PayMethod = PayMethod;
                ColumnSettings.PayToVendorCode = PayToVendorCode;
                ColumnSettings.InvoiceNumber = InvoiceNumber;
                ColumnSettings.InvoiceType = InvoiceType;
                ColumnSettings.DateToPay = DateToPay;
                ColumnSettings.BalanceToPay = BalanceToPay;
                ColumnSettings.ApprovedAmount = ApprovedAmount;
                ColumnSettings.GLAccount = GLAccount;
                ColumnSettings.VendorCode = VendorCode;
                ColumnSettings.VendorName = VendorName;
                ColumnSettings.InvoiceDescription = InvoiceDescription;
                ColumnSettings.InvoiceDate = InvoiceDate;
                ColumnSettings.InvoiceTotal = InvoiceTotal;
                ColumnSettings.InvoiceBalance = InvoiceBalance;
                ColumnSettings.DiscountPercentage = DiscountPercentage;
                ColumnSettings.DiscountAvailable = DiscountAvailable;
                ColumnSettings.DiscountApproved = DiscountApproved;
                ColumnSettings.WithholdingTax = WithholdingTax;
                ColumnSettings.PaidPreviously = PaidPreviously;
                ColumnSettings.NonBillableAmount = NonBillableAmount;
                ColumnSettings.BillableAmount = BillableAmount;
                ColumnSettings.DirectBillAmount = DirectBillAmount;
                ColumnSettings.ProdAdvanceBalance = ProdAdvanceBalance;
                ColumnSettings.CashReceived = CashReceived;
                ColumnSettings.TotalQualified = TotalQualified;
                ColumnSettings.PaidByClientAmount = PaidByClientAmount;

                let grid = $('#invoiceGrid').data('kendoGrid');                
                for (let i = 0; i < grid.columns.length; i++) {
                    if (ColumnSettings.Pay == false && grid.columns[i].attributes.hiddenTitleValue == 'Pay') { grid.hideColumn(i); }
                    else if (ColumnSettings.PayMethod == false && grid.columns[i].attributes.hiddenTitleValue == 'PayMethod') { grid.hideColumn(i); }
                    else if (ColumnSettings.PayToVendorCode == false && grid.columns[i].attributes.hiddenTitleValue == 'PayToVendorCode') { grid.hideColumn(i); }
                    else if (ColumnSettings.InvoiceNumber == false && grid.columns[i].attributes.hiddenTitleValue == 'InvoiceNumber') { grid.hideColumn(i); }
                    else if (ColumnSettings.InvoiceType == false && grid.columns[i].attributes.hiddenTitleValue == 'InvoiceType') { grid.hideColumn(i); }
                    else if (ColumnSettings.DateToPay == false && grid.columns[i].attributes.hiddenTitleValue == 'DateToPay') { grid.hideColumn(i); }
                    else if (ColumnSettings.BalanceToPay == false && grid.columns[i].attributes.hiddenTitleValue == 'BalanceToPay') { grid.hideColumn(i); }
                    else if (ColumnSettings.ApprovedAmount == false && grid.columns[i].attributes.hiddenTitleValue == 'ApprovedAmount') { grid.hideColumn(i); }
                    else if (ColumnSettings.GLAccount == false && grid.columns[i].attributes.hiddenTitleValue == 'GLAccount') { grid.hideColumn(i); }
                    else if (ColumnSettings.VendorCode == false && grid.columns[i].attributes.hiddenTitleValue == 'VendorCode') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.VendorName == false && grid.columns[i].attributes.hiddenTitleValue == 'VendorName') { grid.hideColumn(i); }
                    else if (ColumnSettings.InvoiceDescription == false && grid.columns[i].attributes.hiddenTitleValue == 'InvoiceDescription') { grid.hideColumn(i); }
                    else if (ColumnSettings.InvoiceDate == false && grid.columns[i].attributes.hiddenTitleValue == 'InvoiceDate') { grid.hideColumn(i); }
                    else if (ColumnSettings.InvoiceTotal == false && grid.columns[i].attributes.hiddenTitleValue == 'InvoiceTotal') { grid.hideColumn(i); }
                    else if (ColumnSettings.InvoiceBalance == false && grid.columns[i].attributes.hiddenTitleValue == 'InvoiceBalance') { grid.hideColumn(i); }
                    else if (ColumnSettings.DiscountPercentage == false && grid.columns[i].attributes.hiddenTitleValue == 'DiscountPercentage') { grid.hideColumn(i); }
                    else if (ColumnSettings.DiscountAvailable == false && grid.columns[i].attributes.hiddenTitleValue == 'DiscountAvailable') { grid.hideColumn(i); }
                    else if (ColumnSettings.DiscountApproved == false && grid.columns[i].attributes.hiddenTitleValue == 'DiscountApproved') { grid.hideColumn(i); }
                    else if (ColumnSettings.WithholdingTax == false && grid.columns[i].attributes.hiddenTitleValue == 'WithholdingTax') { grid.hideColumn(i); }
                    else if (ColumnSettings.PaidPreviously == false && grid.columns[i].attributes.hiddenTitleValue == 'PaidPreviously') { grid.hideColumn(i); }
                    else if (ColumnSettings.NonBillableAmount == false && grid.columns[i].attributes.hiddenTitleValue == 'NonBillableAmount') { grid.hideColumn(i); }
                    else if (ColumnSettings.BillableAmount == false && grid.columns[i].attributes.hiddenTitleValue == 'BillableAmount') { grid.hideColumn(i); }
                    else if (ColumnSettings.DirectBillAmount == false && grid.columns[i].attributes.hiddenTitleValue == 'DirectBillAmount') { grid.hideColumn(i); }
                    else if (ColumnSettings.ProdAdvanceBalance == false && grid.columns[i].attributes.hiddenTitleValue == 'ProdAdvanceBalance') { grid.hideColumn(i); }
                    else if (ColumnSettings.CashReceived == false && grid.columns[i].attributes.hiddenTitleValue == 'CashReceived') { grid.hideColumn(i); }
                    else if (ColumnSettings.TotalQualified == false && grid.columns[i].attributes.hiddenTitleValue == 'TotalQualified') { grid.hideColumn(i); }
                    else if (ColumnSettings.PaidByClientAmount == false && grid.columns[i].attributes.hiddenTitleValue == 'PaidByClientAmount') { grid.hideColumn(i); }
                }
            },
            error: function (err) {
                showKendoAlert(err);
            }
        });
    } catch (ex) {
        console.log(ex);
    }
}

function ManageInvoiceSelection() {
    
    if (_bankSelected && _headerLocked) {
        $("#invoiceGrid").removeClass("disabled-area");
    } else {
        $("#invoiceGrid").addClass("disabled-area");
    }

    //for testing, leave disabled
    //$("#invoiceGrid").addClass("disabled-area");
}

function ClearHeaderInformation() {
    $("#toggleButtonsContainer").addClass("disabled-area");
    $("#filterPanelDiv").addClass("disabled-area");

    $("#CashAccountDisp").html("");
    $("#DiscountAccountDisp").html("");

    $("#APAccountList").data("kendoMultiSelect").value([]);
    $("#APAccountList").data("kendoMultiSelect").setOptions({ placeholder: "" });

    $("#VendorList").data("kendoMultiSelect").value([]);
    $("#VendorList").data("kendoMultiSelect").setOptions({ placeholder: "" });

    $("#ClientList").data("kendoMultiSelect").value([]);
    $("#ClientList").data("kendoMultiSelect").setOptions({ placeholder: "" });

    $("#MediaList").data("kendoMultiSelect").value([]);
    $("#MediaList").data("kendoMultiSelect").setOptions({ placeholder: "" });
    $("#mediaCheckBoxAll").attr("disabled", true);
    $("#mediaCheckBoxAll").prop("checked", false);

    $("#IncludeItemsList").data("kendoMultiSelect").value([]);
    $("#IncludeItemsList").data("kendoMultiSelect").setOptions({ placeholder: "" });

    $("#postingPeriod").data("kendoDropDownList").text("");
    $("#postingPeriod").data("kendoDropDownList").setOptions({ optionLabel: "" })

    $("#checkDate").data("kendoDatePicker").value("");
    $("#checkDate").attr("placeholder", "");

    $("#dateToPayCutoff").data("kendoDatePicker").value("");
    $("#dateToPayCutoff").attr("placeholder", "");

    $("#CashAccountDisp").html("");
    $("#DiscountAccountDisp").html("");

    InvoiceFilter.BankCode = "";
    InvoiceFilter.DateToPayCutoff = "";
    InvoiceFilter.CheckDate = "";

    $("#invoiceGrid").data('kendoGrid').dataSource.data([]);
}

function ManageBankSelection() {    
    if (_bankSelected) {
        console.log("stop");
        $("#toggleButtonsContainer").removeClass("disabled-area");
        $("#filterPanelDiv").removeClass("disabled-area");

        $("#CashAccountDisp").html(bankHeaderDetail.cashAccountCode + " </br> " + bankHeaderDetail.cashAccountDescription);
        $("#DiscountAccountDisp").html(bankHeaderDetail.discountAccountCode + " </br> " + bankHeaderDetail.discountAccountDescription);

        $("#ClientList").data("kendoMultiSelect").setOptions({ placeholder: "Select Client(s)" });
        $("#VendorList").data("kendoMultiSelect").setOptions({ placeholder: "Select Vendor(s)" });
        $("#APAccountList").data("kendoMultiSelect").setOptions({ placeholder: "Select GL Account(s)" });

        $("#checkDate").data("kendoDatePicker").value(todayDate);
        $("#dateToPayCutoff").data("kendoDatePicker").value(todayDate);

        let postPeriodData = $("#postingPeriod").data("kendoDropDownList").dataSource.data();
        let selectItem = -1;

        for (let i = 0; i < postPeriodData.length; i++) {
            if (postPeriodData[i].PostingPeriodDescription == 'CURRENT') {
                selectItem = i + 1;
                break;
            }
        }

        if (selectItem >= 0) {
            $("#postingPeriod").data("kendoDropDownList").select(selectItem);
        } else {
            $("#postingPeriod").data("kendoDropDownList").text("");
        }

        $("#postingPeriod").data("kendoDropDownList").setOptions({ optionLabel: "" });


        $("#mediaCheckBoxAll").removeAttr("disabled");
        $("#mediaCheckBoxAll").prop("checked", true);

        let optionList = $("#IncludeItemsList").data("kendoMultiSelect");
        let mediaList = $("#MediaList").data("kendoMultiSelect");

        if (_BatchId == 0) {
            var values = $.map(optionList.dataSource.data(), function (dataItem) {
                return dataItem.Code;
            });
            optionList.value(values);

            values = [];
            values = $.map(mediaList.dataSource.data(), function (dataItem) {
                return dataItem.Code;
            });
            mediaList.value(values);
        }

        if (mediaList.value().length < mediaList.dataSource.data().length) {
            $("#mediaCheckBoxAll").prop("checked", false);
        } else {
            $("#mediaCheckBoxAll").prop("checked", true);
        }

        optionList.setOptions({ placeholder: "No Options Selected" });
        mediaList.setOptions({ placeholder: "No Media Selected" });

        InvoiceFilter.BankCode = $("#Bank").data("kendoDropDownList").value();
        InvoiceFilter.DateToPayCutoff = $("#dateToPayCutoff").data("kendoDatePicker").value();
        InvoiceFilter.CheckDate = $("#checkDate").data("kendoDatePicker").value();

        if (_BatchId == 0) {
            RefreshInvoiceGrid();
        }
    } else {
        ClearHeaderInformation();
    }

    ManageSaveDeleteButtons();
}

function ManageSaveDeleteButtons() {
    console.log("ManageSaveDeleteButtons");
    if (!_headerLocked && $("#postingPeriod").data("kendoDropDownList").value() &&
        $("#checkDate").data("kendoDatePicker").value() && $("#dateToPayCutoff").data("kendoDatePicker").value()) {

        $("#saveButton").removeClass("k-state-disabled");
        $("#saveButton").prop("disabled", false);
    } else {
        $("#saveButton").addClass("k-state-disabled");
        $("#saveButton").prop("disabled", true);
    }

    if (_headerLocked) {
        $("#deleteButton").removeClass("k-state-disabled");
        $("#deleteButton").prop("disabled", false);
    } else {
        $("#deleteButton").addClass("k-state-disabled");
        $("#deleteButton").prop("disabled", true);
    }
}

//this needs to be reviewed: 7/21/21 NS
//currently its not being called anywhere.
function SetBatchStatusDisplay(batchStatusDescription) {
    let statusDisplay = '';
    switch (batchStatusDescription) {
        case 'Open': //Open
        case 'Edit': //Open batch is in Edit mode
            statusDisplay = `Batch Status: <span class="wv-save pill" style="color:white;">Open</span>`
            break;
        case 'Submitted': //Submitted
            statusDisplay = `Batch Status: <span class="wv-warning pill" style="color:white;">${batchStatusDescription}</span>`
            break;
        case 'Approved': //Approved
            statusDisplay = `Batch Status: <span class="wv-assignee-complete pill" style="color:white;">${batchStatusDescription}</span>`
            break;
        case 'Denied': //Denied
            statusDisplay = `Batch Status: <span class="wv-danger pill" style="color:white;">${batchStatusDescription}</span>`
            break;
        case 'Completed': //Completed
            statusDisplay = `Batch Status: <span class="wv-success pill" style="color:white;">${batchStatusDescription}</span>`
            break;
    }

    return statusDisplay;
}

//this needs to be reviewed: 7/21/21 NS
function ManageScreenStatus(batchId, batchStatus, batchName) {
    if (batchId !== 0) {
        //Existing Batch
        $("#batchStatusDiv").html("");
        $("#batchStatusDiv").append(SetBatchStatusDisplay(batchStatus));
        $("#panelBarTitle").html("Payment Center | " + batchName);

        $("#deleteButton").removeClass("k-state-disabled");
        $("#deleteButton").prop("disabled", false);

        if (batchStatus == "Open" || (batchStatus == "Edit" && _IsDirty == false)) {
            $("#BatchSubmissionButton").html("Submit Batch")
            $("#submitContainer").show();
            $("#viewBatchSummary").show();
        } else if (batchStatus == "Submitted") {
            $("#BatchSubmissionButton").html("Unsubmit Batch")
            $("#submitContainer").show();
            $("#viewBatchSummary").show();
        } else {
            $("#BatchSubmissionButton").html("")
            $("#submitContainer").hide();
            $("#viewBatchSummary").hide();
        }

        if (_BatchStatus == 'C') {
            $("#filterPanelDiv").addClass("disabled");
            $("#TopToolBar").addClass("disabled");

            $("#postContainer").hide();
            $("#SendOnDateListItem").hide();
        }
    } else {
        //New Batch Creation
        $("#panelBarTitle").html("Payment Center | Create New Batch");
        $("#submitContainer").hide();

        $("#deleteButton").addClass("k-state-disabled");
        $("#deleteButton").prop("disabled", true);

        $("#postContainer").hide();
        $("#SendOnDateListItem").hide();
    }
}


function GetInvoiceFilter() {
    let bankCode = $("#Bank").data("kendoDropDownList").value();
    let glItems = $("#APAccountList").data("kendoMultiSelect").value();               
    let vendorItems = $("#VendorList").data("kendoMultiSelect").value();
    let clientItems = $("#ClientList").data("kendoMultiSelect").value();    
    let checkDate = $("#checkDate").data("kendoDatePicker").value();
    let dateToPayCutoff = $("#dateToPayCutoff").data("kendoDatePicker").value();
    let includeItems = $("#IncludeItemsList").data("kendoMultiSelect").value();
    let media = $("#MediaList").data("kendoMultiSelect").value();
    let view = $("#View").data("kendoDropDownList").value();

    InvoiceFilter.BatchStatus = _BatchStatus;    
    InvoiceFilter.BatchId = _BatchId;
    InvoiceFilter.BankCode = bankCode;
    InvoiceFilter.APAccountCode = glItems.length > 0 ? glItems.join(",") : "ALL";
    InvoiceFilter.VendorCode = vendorItems.length > 0 ? vendorItems.join(",") : "ALL";
    InvoiceFilter.ClientCode = clientItems.length > 0 ? clientItems.join(",") : "ALL";
    InvoiceFilter.DateToPayCutoff = dateToPayCutoff;
    InvoiceFilter.CheckDate = checkDate;

    //All Qualified (AQ) || Paid By Client (PBC)
    InvoiceFilter.PaidByClient = _InvoiceType = "AQ" ? 1 : 0;    

    InvoiceFilter.GLDist = includeItems.includes("GL") ? 1 : 0;
    InvoiceFilter.Production = includeItems.includes("Production") ? 1 : 0;
    
    InvoiceFilter.Television = media.includes("Television") ? 1 : 0;
    InvoiceFilter.Radio = media.includes("Radio") ? 1 : 0;    
    InvoiceFilter.Newspaper = media.includes("Newspaper") ? 1 : 0;    
    InvoiceFilter.Magazine = media.includes("Magazine") ? 1 : 0;    
    InvoiceFilter.Internet = media.includes("Internet") ? 1 : 0;    
    InvoiceFilter.Outdoor = media.includes("Out of Home") ? 1 : 0;

    InvoiceFilter.GridViewType = view == 'Detail' ? 'PaymentCenterInvoiceDetailGrid' : 'PaymentCenterInvoiceSummaryGrid';       
    //InvoiceFilter.InitialLoadFlag = true;   

    return InvoiceFilter;
}

function UpdateBatchHeader(fieldName, fieldValue) {
    let postData = { BatchId: _BatchId, FieldName: fieldName, FieldValue: fieldValue };

    $.ajax({
        type: "POST",
        url: "UpdateBatchHeader",
        data: postData,
        success: function (response) {

        },
        error: function (response) {
        }
    });
}
