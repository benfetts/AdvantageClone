var batchFilter = {
    BatchOwner: '',
    StartDate: '',
    EndDate: '',
    Status: ''
};

var _PageInitialized = false;
var GridDataSource;
//var toDate = kendo.toString(kendo.parseDate(kendo.date.addDays(new Date(), 1)), 'MM/dd/yyyy');
//var fromDate = kendo.toString(kendo.parseDate(kendo.date.addDays(new Date(), -730)), 'MM/dd/yyyy');

function SetBatchFilter() {
    //batchFilter.BatchOwner:  automatically set via the EmployeeMultiSelect Change event.
    batchFilter.StartDate = $("#fromDatePicker").data("kendoDatePicker").value();
    batchFilter.EndDate = $("#toDatePicker").data("kendoDatePicker").value();
    batchFilter.Status = GetStatus();
}

function CheckForOpenBank() {
    return $.ajax({
        url: 'PaymentCenter/CheckForOpenBank',        
        dataType: 'json'
    });
}

function GetBatches() {
    SetBatchFilter();    
    //LoadGridView();
    var dataGrid = $("#batchGrid").data("kendoGrid");
    dataGrid.dataSource.read();
    dataGrid.dataSource.sync();
}

function NewBatch() {     
    CheckForOpenBank().then(function (openBank) {
        if (openBank == true) {
            let url = "Billing/PaymentCenter/CreateBatch";
            OpenRadWindow("New Payment Batch", url);
        } else {
            showKendoAlert("Banks can only be assigned to one open batch at a time and currently there are no Banks available for creating a new batch.");
        }
    });     
}

function onFilterChange() {
    GetBatches();
}

function LoadGridView() {
    if (_PageInitialized == false) {
        setTimeout(LoadGridView, 250);
    } else {
        CreateGridDataSource();
        CreateGridView();
    }
}

function CreateGridDataSource() { 
    GridDataSource = new kendo.data.DataSource({
        transport: {
            read: (e) => {
                $.ajax({
                    type: "GET",
                    url: "PaymentCenter/GetBatchHeaders",
                    contentType: "application/json",
                    data: batchFilter,
                    success: (results) => {
                        e.success(results);
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
                fields: {
                    BatchId: { from: "BatchId", type: "number", editable: false },
                    BatchName: { from: "BatchName", type: "string", editable: false },
                    BatchOwner: { from: "BatchOwner", type: "string", editable: false },
                    BankCode: { from: "BankCode", type: "string", editable: false },
                    BankDescription: { from: "BankDescription", type: "string", editable: false },
                    CreationDate: { from: "CreationDate", type: "date", editable: false },
                    PaymentDate: { from: "PaymentDate", type: "date", editable: false },
                    BatchStatus: { from: "BatchStatus", type: "string", editable: false },
                    BatchStatusDescription: { from: "BatchStatusDescription", type: "string", editable: false }
                }
            }
        }
    });
}

function CreateGridView() {
    $("#batchGrid").kendoGrid({
        autoWidth: true,
        autoBind: true,
        navigatable: true,
        reorderable: true,
        toolbar: kendo.template($("#template").html()),
        dataSource: GridDataSource,
        sortable: true,
        pageable: {
            pageSizes: [10, 15, 20, 50, 100, 200],
            buttonCount: 5
        },
        resizable: false,
        filterable: true,
        filter: function (e) {
            //onFilterChange(e);
        },
        columns: [
            { width: 70, template: BatchDetailTemplate },
            { field: "BatchName", title: "Batch Name", width: 450 },
            { field: "BatchOwner", title: "Created By", width: 175 },
            { field: "BankCode", title: "Bank Name", width: 175 },
            { field: "CreationDate", title: "Date Created", template: "#: kendo.toString(CreationDate, 'MM/dd/yyyy') #", width: 150 },
            { field: "PaymentDate", title: "Payment Date", template: "#: kendo.toString(PaymentDate, 'MM/dd/yyyy') #", width: 150 },
            { field: "BatchStatus", title: "Batch Status", width: 200, template: BatchStatusTemplate }
        ],
        dataBound: function (e) {
            totalpages = e.sender.pager.totalPages();
            e.sender.pager.options.messages.display = "{2} items in " + totalpages + " page(s)";
        }
    });
}

function BatchDetailTemplate(dataItem) {
    let display = '';    
    //display = `<a onclick"openExistingBatch(${dataItem.BatchId})" class="wv-icon-button k-button wv-neutral-two " ></a>`;    
    display = `<a onclick='openExistingBatch(${dataItem.BatchId}, "${dataItem.PaymentModule}")' class='wv-icon-button k-button wv-neutral-two'><span class='wvi wvi-magnifying-glass'></span></a>`;

    return display;
}

function openExistingBatch(batchId, paymentModule) {
    let url = "Billing/PaymentCenter/OpenBatch?BatchID=" + batchId + "&PaymentModule=" + paymentModule;
    OpenRadWindow("Open Payment Batch", url);
}

function BatchStatusTemplate(dataItem) {
    let statusDisplay = '';    
    switch (dataItem.BatchStatus) {
        case 'O': //Open
            statusDisplay = `<span class="wv-save pill" style="color:white;">${dataItem.BatchStatusDescription}</span>`
            break;
        case 'S': //Submitted
            statusDisplay = `<span class="wv-warning pill" style="color:white;">${dataItem.BatchStatusDescription}</span>`
            break;
        case 'A': //Approved
            statusDisplay = `<span class="wv-assignee-complete pill" style="color:white;">${dataItem.BatchStatusDescription}</span>`
            break;
        case 'D': //Denied
            statusDisplay = `<span class="wv-danger pill" style="color:white;">${dataItem.BatchStatusDescription}</span>`
            break;
        case 'C': //Completed
            statusDisplay = `<span class="wv-success pill" style="color:white;">${dataItem.BatchStatusDescription}</span>`
            break;
    }

    return statusDisplay;
}

function GetStatus() {
    let status = '';

    if ($("#showOpenCB").prop("checked")) {
        status = $("#showOpenCB").val() + ",";
    }

    if ($("#showSubmittedCB").prop("checked")) {
        status += $("#showSubmittedCB").val() + ",";
    }

    if ($("#showApprovedCB").prop("checked")) {
        status += $("#showApprovedCB").val() + ",";
    }

    if ($("#showDeniedCB").prop("checked")) {
        status += $("#showDeniedCB").val() + ",";
    }

    if ($("#showCompletedCB").prop("checked")) {
        status += $("#showCompletedCB").val() + ",";
    }

    return status;
}

function ClearFilters() {
    batchFilter.BatchOwner = '';
    batchFilter.EndDate = '';
    batchFilter.StartDate = '';
    batchFilter.Status = '';

    batchFilter.BatchOwner = "";

    $("#employeeMultiSelect").data("kendoMultiSelect").value([{}]);
    $("#fromDatePicker").data("kendoDatePicker").value("");
    $("#toDatePicker").data("kendoDatePicker").value("");

    $("#statusCheckBoxes :checkbox").prop("checked", false);    

    $("#batchGrid").data('kendoGrid').dataSource.data([]);
}
