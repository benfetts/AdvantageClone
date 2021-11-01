var myApp = angular.module("angExpenseReport", ["kendo.directives"]);

myApp.config(['$httpProvider', function ($httpProvider) {
    //initialize get if not there
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }
    // Answer edited to include suggestions from comments
    // because previous version of code introduced browser-related errors
    //disable IE ajax request caching
    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
    // extra
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
}]);

myApp.config(['$rootScopeProvider', function ($rootScopeProvider) {
    $rootScopeProvider.digestTtl(15);
}]);

//define service calls for api
myApp.service("expService", function ($http) {
    return {
        getFunctionCodes: function () {
            return $http.get("GetFunctionCodes");
            //return $http.get("/test/api/Properties/getAllProperties?model=" + m, {cache:false});
        },
        getClients: function () {
            return $http.get("GetClients");
        },
        getPaymentTypes: function () {
            return $http.get("GetPaymentTypes");
        },
        getJobs: function (clientCode) {
            return $http.get("GetJobs?clientCode=" + clientCode);
        },
        getJobsAllData: function (clientCode) {
            return $http.get("GetJobsAllData?clientCode=" + clientCode);
        },
        getAllJobs: function () {
            return $http.get("GetAllJobs");
        },
        getJobComponents: function (jobNumber) {
            return $http.get("GetJobComponents?jobNumber=" + jobNumber);
        },
        getDivisions: function (clientCode) {
            return $http.get("GetDivisions?clientCode=" + clientCode);
        },
        getProducts: function (clientCode, divisionCode) {
            return $http.get("GetProducts?clientCode=" + clientCode + "&divisionCode=" + divisionCode);
        },
        getExpenseReport: function (invoiceNumber) {
            return $http.get("GetExpenseReport?InvoiceNumber=" + invoiceNumber);
        },
        getExpenseReportsSample: function (count) {
            return $http.get("GetExpenseReportsSample?count=" + count);
        },
        getExpenseReportDetails: function (invoiceNumber) {
            return $http.get("GetExpenseReportDetails?InvoiceNumber=" + invoiceNumber);
        },
        createExpenseReports: function (ExpenseReports, ExpenseReportDetails) {
            return $http.post("CreateExpenseReports", { ExpenseReports, ExpenseReportDetails });
        },
        createExpenseReportDetails: function (ExpenseReportDetails, isImported) {
            return $http.post("CreateExpenseReportDetails", { ExpenseReportDetails, isImported });
        },
        updateExpenseReports: function (data) {
            return $http.post("UpdateExpenseReports", data);
        },
        updateExpenseReportDetails: function (data) {
            return $http.post("UpdateExpenseReportDetails", data);
        },
        addInvoiceBookmark: function (code, invoiceNumber, description) {
            return $http.get("AddInvoiceBookmark?Code=" + code + "&InvoiceNumber=" + invoiceNumber + "&Description=" + description);
        },
        submitExpenseReport: function (invoiceNumber, empCode) {
            return $http.get("SubmitExpenseReport?InvoiceNumber=" + invoiceNumber + "&EmployeeCode=" + empCode);
        },
        submitExpenseReportOptions: function (invoiceNumber, approvalRequired, includeReceiptsInEmailAndAlert, submittedToEmployeeCode) {
            return $http.get("SubmitExpenseReportOptions?InvoiceNumber=" + invoiceNumber + "&ApprovalRequired=" + approvalRequired + "&IncludeReceiptsInEmailAndAlert=" + includeReceiptsInEmailAndAlert + "&SubmittedToEmployeeCode=" + submittedToEmployeeCode);
        },
        unSubmitExpenseReport: function (invoiceNumber) {
            return $http.get("UnSubmitExpenseReport?InvoiceNumber=" + invoiceNumber);
        },
        getEmployeesForDropDown() {
            return $http.get("GetEmployeesForDropDown");
        },
        deleteExpenseReports: function (data) {
            return $http.post("DeleteExpenseReports", data);
        },
        deleteExpenseReportDetails: function (data) {
            return $http.post("DeleteExpenseReportDetails", data);
        },
        deleteExpenseReportDetailsByIDs: function (data) {
            return $http.post("DeleteExpenseReportDetailsByIDs", data);
        },
        getGridColumnSettings: function () {
            return $http.get("GetGridColumnSettings");
        },
        saveGridColumnSettings: function (data) {
            return $http.post("SaveGridColumnSettings", data);
        },
        getReceiptsList: function (invoiceNumber) {
            return $http.get("GetReceiptsList?InvoiceNumber=" + invoiceNumber);
        },
        copyReceipt: function (documentID, invoiceNumber) {
            return $http.get("CopyReceipt?DocumentID=" + documentID + '&InvoiceNumber=' + invoiceNumber);
        },
        deleteReceipt: function (documentID) {
            return $http.post("DeleteReceipt?DocumentID=" + documentID);
        },
        getBillingRate: function (functionCode, clientCode, divisionCode, productCode, jobNumber, jobcomponentNumber, itemDate) {
            return $http.get("GetBillingRate?functionCode=" + functionCode + "&clientCode=" + clientCode + "&divisionCode=" + divisionCode + "&productCode=" + productCode + "&jobNumber=" + jobNumber + "&jobcomponentNumber=" + jobcomponentNumber + "&itemDate=" + itemDate);
        },
        saveGridPageSize: function (pageSize) {
            return $http.post("SaveGridPageSize", { pageSize });
        },
        getGridPageSize: function () {
            return $http.get("GetExpenseReportPageSizeGet");
        },
        saveDefaultPaymentType: function (DefaultPaymentType) {
            return $http.post("SaveDefaultPaymentType", { DefaultPaymentType });
        }

    };
});

myApp.controller("ExpenseReportController", function ($scope, $q, $http, expService) {
    $scope.allJobs = initJobs;
    $scope.uploadedImages = initUploadedImages;
    $scope.rowsWithImages = [];
    $scope.divisions = [];
    $scope.products = [];
    $scope.jobs = [];
    $scope.jobcomponents = [];
    $scope.selectedViewMode = 1;

    $scope.lastPaymentType = intiDefaultPaymentType;
    $scope.isLastPaymentSet = true;
    $scope.reportHasRowImages = false;
    $scope.CanAdd = initCanAdd;
    $scope.CanUpdate = initCanUpdate;
    $scope.CanPrint = initCanPrint;
    $scope.Custom1 = initCustom1;
    $scope.Custom2 = initCustom2;


    $scope.UserCode = initUserCode;

    $scope.pagesize = intiPageSize;
    $scope.HasDocuments = intiHasDocuments;
    $scope.receiptsCount = initReceiptCount;
    $scope.importrows = [];

    $scope.newExpenseReportDetailsList = [];
    $scope.checkCustom2 = false;

    var sum = 0;

    //fill dropdowns content
    $scope.paymentTypes = [{ "Value": 0, "Description": "CC", LongDescription: "Company Card (CC)" }, { "Value": 1, "Description": "PC", LongDescription: "Personal Card or Cash (PC)" }];

    $scope.clients = $scope.allJobs
        .map(function (item) { return { Code: item.ClientCode, Name: item.ClientName + ' (' + item.ClientCode + ')', NameOnly: item.ClientName }; })
        .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
        .sort(function (a, b) {
            return a.Code.localeCompare(b.Code);
        });

    $scope.functionCodes = initFunctionCodes
        .map(function (item) { return { Code: item.Code, Description: item.Description + " (" + item.Code + ")", DescriptionOnly: item.Description }; });

    //column settings - indicates wich column is shown
    $scope.columnSettings = {
        quantity: true,
        rate: true,
        client: true,
        division: true,
        product: true,
        job: true,
        jobComponent: true
    };

    //set the values as they are in database
    function setColumnSettingsFromInit() {

        initColSettings.forEach(item => {
            if (item == "Quantity_Rate") {
                $scope.columnSettings.quantity = false;
                $scope.columnSettings.rate = false;
            }
            else if (item == "Client") {
                $scope.columnSettings.client = false;
            }
            else if (item == "Division") {
                $scope.columnSettings.division = false;
            }
            else if (item == "Product") {
                $scope.columnSettings.product = false;
            }
            else if (item == "Job_Component") {
                $scope.columnSettings.job = false;
                $scope.columnSettings.jobComponent = false;
            }
        });

    }

    setColumnSettingsFromInit();

    //define variables for needed to load expense report data
    //load expense reports
    $scope.expenseReportHeader = initHeader;
    $scope.expenseReportDetails = initData;
    $scope.gridData = [];
    $scope.gridData = prepereDataForGrid();
    calculateTotals();

    $scope.selectedRow = [];
    $scope.lastHeaderData = {};

    $scope.reportDetailsList = [];

    $scope.showAllCols = false;

    $scope.totalExpenses = 0;
    $scope.lessCreditCard = 0;
    $scope.totalDue = 0;

    //schema that is used when refreshing/recreating the grid
    var baseSchema = {
        model: {
            fields: {
                Id: { type: "number" },
                Date: { type: "date" },
                Description: { type: "string" },
                Function: { type: "string", validation: { required: true } },
                Quantity: { type: "number" },
                Rate: { type: "number" },
                Amount: { type: "number" },
                Client: { type: "string", validation: { required: true } },
                Division: { type: "string" },
                Product: { type: "string" },
                Job: { type: "string" },
                Component: { type: "string" },
                //PaymentType: { type: "object", nullable: false, defaultValue: { Value: 2, Description: "Cash" } },
                PaymentType: { validation: { required: true }, defaultValue: 1 },
                Receipts: { type: "object", editable: false },
                Uploader: { type: "string", editable: false },
                ShowAllUploadedImages: { type: "boolean", defaultValue: true },
                CreatedBy: { type: "string", editable: false },
                IsImported: { type: "boolean", defaultValue: false }
            }
        }
    };


    var baseDataSource = {
        data: $scope.gridData,
        batch: false,
        schema: baseSchema
    };

    //checks if grids is editable - depend on status of the report
    function checkIfGridIsEditable() {

        if ($scope.expenseReportHeader.Status != "" && $scope.expenseReportHeader.Status != null) {
            if (parseInt($scope.expenseReportHeader.Status) >= 1) {
                return false;
            }
        }

        if ($scope.CanUpdate === false && $scope.expenseReportHeader.InvoiceNumber > 0) {

            return false;

        }

        var editable = {
            mode: "incell",
            confirmation: false,
            createAt: "bottom"
        };

        return editable;
    }

    //returns the width of the Receipts column width 
    //it's different when report has uploaded receipts
    function getReceiptsColumnWidth() {
        if ($scope.reportHasRowImages && $scope.selectedViewMode != 0) {
            return 260;
        }
        else { return 80; }
    }

    $scope.rowIndex = null;
    $scope.cellIndex = null;
    $scope.saveButtonClicked = false;

    //define grid
    $scope.mainGridOptions = {
        dataSource: {
            data: $scope.gridData,
            batch: false,
            schema: {
                model: {
                    fields: {
                        Id: { type: "number" },
                        Date: { type: "date" },
                        Description: { type: "string" },
                        Function: { type: "string", validation: { required: true } },
                        Quantity: { type: "number" },
                        Rate: { type: "number"},
                        Amount: { type: "number" },
                        Client: { type: "string", validation: { required: true } },
                        Division: { type: "string" },
                        Product: { type: "string" },
                        Job: { type: "string" },
                        Component: { type: "string" },
                        //PaymentType: { type: "object", nullable: false, defaultValue: { Value: 2, Description: "Cash" } },
                        PaymentType: { validation: { required: true }, defaultValue: 1 },
                        Receipts: { type: "object", editable: false },
                        Uploader: { type: "string", editable: false },
                        ShowAllUploadedImages: { type: "boolean", defaultValue: true },
                        CreatedBy: { type: "string", editable: false },
                        IsImported: { type: "boolean", defaultValue: false },
                        JobComponent: { type: "string", editable: false }
                    }
                }
            },
            pageSize: $scope.pagesize
        },
        filterable: {
            extra: false
        },
        toolbar: kendo.template($("#template").html()),
        editable: checkIfGridIsEditable(),
        excel: {
            allPages: true
        },
        excelExport: function (e) {
            e.workbook.fileName = $scope.expenseReportHeader.Description.toString().toLowerCase().indexOf("expense") > -1 || $scope.expenseReportHeader.Description.toString().toLowerCase().indexOf("report") > -1 ? $scope.expenseReportHeader.Description + "_" + $scope.expenseReportHeader.InvoiceNumber + ".xlsx" : "ExpenseReport_" + $scope.expenseReportHeader.Description + "_" + $scope.expenseReportHeader.InvoiceNumber + ".xlsx";

            var data = e.data;
            var gridColumns = e.sender.columns;
            var sheet = e.workbook.sheets[0];
            var visibleGridColumns = [];
            var columnTemplates = [];            

            // Create element to generate templates in.
            var elem = document.createElement('div');

            // Get a list of visible columns
            for (var i = 0; i < gridColumns.length; i++) {
                // 
                if (!gridColumns[i].hidden) {
                    visibleGridColumns.push(gridColumns[i]);
                }
            }

            // Create a collection of the column templates, together with the current column index
            for (var i = 0; i < visibleGridColumns.length; i++) {
                if (visibleGridColumns[i].template) {
                    columnTemplates.push({ cellIndex: i, template: kendo.template(visibleGridColumns[i].template) });
                }
            }

            // Traverse all exported rows.
            for (var i = 0; i < sheet.rows.length; i++) {                
                var row = sheet.rows[i];
                // Get the data item corresponding to the current row.
                var dataItem = data[i - 1];                

                if (i == 0) {
                    for (let k = 0; k < row.cells.length; k++) {
                        if (row.cells[k].value == "Uploader" || row.cells[k].value == "Receipts") {                                                        
                            row.cells[k] = "";
                        }                        
                    }
                } else {
                    // Traverse the column templates and apply them for each row at the stored column position.
                    for (var j = 0; j < columnTemplates.length; j++) {
                        var columnTemplate = columnTemplates[j];
                        // Generate the template content for the current cell.
                        elem.innerHTML = columnTemplate.template(dataItem);

                        if (row.cells[columnTemplate.cellIndex - 1] != undefined) {
                            // Output the text content of the templated cell into the exported cell.
                            try {
                                if (row.cells[columnTemplate.cellIndex - 1].value != undefined) {
                                    //don't show attachment icon column html
                                    if (row.cells[columnTemplate.cellIndex - 1].value.toString().indexOf(".k-upload") > -1) {
                                        row.cells[columnTemplate.cellIndex - 1].value = "";
                                    } else {
                                        row.cells[columnTemplate.cellIndex - 1].value = elem.textContent || elem.innerText || "";
                                    }
                                }
                            } catch (e) {
                                console.log(e);
                            }
                        }
                    }
                }                
            }               
        },
        navigatable: true,
        selectable: "multiple, row",
        height: '100%',
        groupable: true,
        group: (e) => {
            if (e.groups && e.groups.length > 0) {

                e.groups.forEach((v, i, a) => {
                    if (v.field == 'Component') {
                        a[i].field = 'JobComponent';
                    }
                });

                //e.groups.unshift({ field: 'Job', dir: 'asc', aggregates: []});
            }
        },
        sortable: {
            mode: "multiple"
        },
        resizable: true,
        pageable: {
            refresh: false,
            info: true,
            //pageSizes: true,
            buttonCount: 5,
            //alwaysVisible: false,
            pageSizes: [10, 15, 20, 50, 100, 200],
            pageSize: $scope.pagesize
        },
        columnHide: (e) => {
            var grid;
            if (e.column.field == "Job") {
                grid = $("#ExpenseReportsGrid").data("kendoGrid");
                grid.hideColumn("Component");
            }
            else if (e.column.field == "Component") {
                grid = $("#ExpenseReportsGrid").data("kendoGrid");
                grid.hideColumn("Job");
            }
            else if (e.column.field == "Quantity") {
                grid = $("#ExpenseReportsGrid").data("kendoGrid");
                grid.hideColumn("Quantity");
                grid.hideColumn("Rate");
            }

            expService.saveGridColumnSettings({ Column: e.column.field, Show: !e.column.hidden }).then(function (result) {
                console.log(result);
            });
        },
        columnShow: (e) => {
            var grid;
            if (e.column.field == "Job") {
                grid = $("#ExpenseReportsGrid").data("kendoGrid");
                grid.showColumn("Component");
            }
            else if (e.column.field == "Component") {
                grid = $("#ExpenseReportsGrid").data("kendoGrid");
                grid.showColumn("Job");
            }
            else if (e.column.field == "Quantity") {
                grid = $("#ExpenseReportsGrid").data("kendoGrid");
                grid.showColumn("Quantity");
                grid.showColumn("Rate");
            }

            expService.saveGridColumnSettings({ Column: e.column.field, Show: !e.column.hidden }).then(function (result) {
                console.log(result);
            });

        },
        columnMenuInit: (e) => {
            console.log(e);
        },
        dataBinding: function (e) {
            var current = e.sender.current() || [];
            if (current[0]) {
                $scope.cellIndex = current.index();
                $scope.rowIndex = current.parent().index();
            }
        },
        dataBound: function (e) {

            if (!isNaN($scope.cellIndex)) {
                e.sender.current(e.sender.tbody.children().eq($scope.rowIndex).children().eq($scope.cellIndex));
                $scope.rowIndex = $scope.cellIndex = null;
            }

            for (var i = 0; i < this.columns.length; i++) {
                if (this.columns[i].title !== "Job" && this.columns[i].title !== "Component" && this.columns[i].title !== "Receipts") {
                    this.autoFitColumn(i);
                }
            }

            expService.saveGridPageSize(e.sender.dataSource.pageSize()).then(function (result) {
                $scope.pagesize = e.sender.dataSource.pageSize();
                //console.log("databound" + e.sender.dataSource.pageSize());
            });

            $('#grid tr td:first-child').addClass('k-group-cell');

            let grid = $('#ExpenseReportsGrid').data('kendoGrid');

            setTimeout(() => {
                grid.pager.element.find("a").not(".k-state-disabled").attr("tabindex", "-1");
                grid.pager.element.find("span .k-dropdown").attr("tabindex", "-1");
                //k-widget k-dropdown k-header
            }, 100);

        },
        change: function (e) {
            var scrollContentOffset = this.element.find("tbody").offset().top;
            var selectContentOffset = this.select().offset().top;
            var distance = selectContentOffset - scrollContentOffset;

            this.element.find(".k-grid-content").animate({
                scrollTop: distance
            }, 400);
        },
        columns: [
            { title: "", width: 20, minResizableWidth: 20, template: "<span class='wvi wvi-more_vertical'></span>" },
            {
                field: "Date", title: "Date", format: "{0:MM/dd/yyyy}", width: 115, editor: dateGridEditor, groupable: true, minResizableWidth: 115, filterable: {
                    ui: $scope.dateFilter,
                    extra: true
                }
            },
            { field: "Description", title: "Description", groupable: true, width: 170, editor: descriptionEditor, minResizableWidth: 170, maxResizableWidth: 300 },
            {
                field: "Function", title: "Function", editor: functionMultiselectEditor, width: 220, template: functionCodeString, groupable: true, minResizableWidth: 220, groupHeaderTemplate: functionGroupString,
                filterable: {
                    ui: (element) => {
                        element.kendoDropDownList({
                            dataTextField: "Description",
                            dataValueField: "Code",
                            filter: "contains",
                            dataSource: { data: $scope.functionCodes },
                            valuePrimitive: true
                        }).data('kendoComboBox');
                    }
                }
            },
            { field: "Quantity", title: "QTY", hidden: !$scope.columnSettings.quantity, groupable: false, width: 80, minResizableWidth: 80, editor: quantityEditor },
            { field: "Rate", title: "Rate", hidden: !$scope.columnSettings.rate, groupable: false, width: 80, minResizableWidth: 80, format: '{0:n4}', editor: rateEditor },
            { field: "Amount", title: "Amount", format: '{0:n2}', groupable: false, width: 80, minResizableWidth: 80, editor: amountEditor },
            {
                field: "Client", title: "Client", hidden: !$scope.columnSettings.client, editor: clientMultiselectEditor, template: clientString, width: 170, groupable: true, minResizableWidth: 200, maxResizableWidth: 170, groupHeaderTemplate: clientGroupString,
                filterable: {
                    ui: (element) => {
                        var combobox = element.kendoDropDownList({
                            dataTextField: "Name",
                            dataValueField: "Code",
                            filter: "contains",
                            dataSource: { data: $scope.clients },
                            valuePrimitive: true
                        }).data('kendoComboBox');

                    }
                }
            },
            {
                field: "Division", title: "Division", hidden: !$scope.columnSettings.division, editor: divisionMultiselectEditor, template: divisionString, width: 170, groupable: true, minResizableWidth: 170, groupHeaderTemplate: divisionGroupString,
                filterable: {
                    ui: (element) => {
                        var divisions = $scope.allJobs
                            .map(function (item) { return { Code: item.DivisionCode, Name: item.DivisionName + ' (' + item.DivisionCode + ')', ClientCode: item.ClientCode, CD: item.ClientCode + '/' + item.DivisionCode }; })
                            .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                            .sort(function (a, b) {
                                return a.CD.localeCompare(b.CD);
                            });

                        element.kendoDropDownList({
                            dataTextField: "Name",
                            dataValueField: "Code",
                            filter: "contains",
                            dataSource: { data: divisions },
                            valuePrimitive: true
                        }).data('kendoComboBox');
                    }
                }
            },
            {
                field: "Product", title: "Product", hidden: !$scope.columnSettings.product, editor: productMultiselectEditor, template: productString, width: 170, groupable: true, minResizableWidth: 170, groupHeaderTemplate: productGroupString,
                filterable: {
                    ui: (element) => {
                        var products = $scope.allJobs
                            .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName + ' (' + item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode + ')', ClientCode: item.ClientCode, DivisionCode: item.DivisionCode, CDP: item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode }; })
                            .filter((value, index, self) => self.findIndex(i => i.Name === value.Name) === index)
                            .sort(function (a, b) {
                                return a.CDP.localeCompare(b.CDP);
                            });

                        element.kendoDropDownList({
                            dataTextField: "Name",
                            dataValueField: "Code",
                            filter: "contains",
                            dataSource: { data: products },
                            valuePrimitive: true
                        }).data('kendoComboBox');
                    }
                }
            },
            {
                field: "Job", title: "Job", hidden: !$scope.columnSettings.job, editor: jobMultiselectEditor, template: jobString, width: 250, groupHeaderTemplate: jobGroupString, groupable: true, minResizableWidth: 250,
                filterable: {
                    ui: (element) => {

                        var jobs = $scope.allJobs
                            .map(function (item) { return { Number: item.Number, Description: '' + item.Number + ' - ' + item.JobDescription }; })
                            .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);

                        element.kendoDropDownList({
                            dataTextField: "Description",
                            dataValueField: "Number",
                            filter: "contains",
                            dataSource: { data: jobs },
                            valuePrimitive: true
                        }).data('kendoComboBox');
                    }
                }
            },
            {
                field: "Component", title: "Component", hidden: !$scope.columnSettings.jobComponent, editor: jobcomponentMultiselectEditor, template: jobComponentString, width: 250, groupable: true, minResizableWidth: 250, groupHeaderTemplate: jobComponentGroupString,
                filterable: {
                    ui: (element) => {

                        // "527|2 - Component Description"
                        var jobcomponents = $scope.allJobs
                            .map(function (item) { return { ID: item.ID, Description: item.JobComponentNumber.toString().padStart(3, '0') + ' - ' + item.JobComponentDescription, Number: item.Number, jobcomponent: '' + item.Number + '|' + item.JobComponentNumber + ' - ' + item.JobComponentDescription}; })
                            .filter((value, index, self) => self.findIndex(i => i.ID === value.ID && i.Number === value.Number) === index)
                            .sort((a, b) => b.value - a.value);

                        element.kendoDropDownList({
                            dataTextField: "Description",
                            dataValueField: "jobcomponent",
                            filter: "contains",
                            dataSource: { data: jobcomponents },
                            valuePrimitive: true
                        }).data('kendoComboBox');
                    }
                }
            },
            {
                field: "PaymentType", title: "Type", editor: paymentMultiselectEditor, template: paymentTypeString, width: 80, groupable: true, minResizableWidth: 80, includeInChooser: false, groupHeaderTemplate: paymentTypeGroupString,
                filterable: {
                    ui: (element) => {

                        element.kendoDropDownList({
                            dataTextField: "LongDescription",
                            dataValueField: "Value",
                            filter: "contains",
                            dataSource: { data: $scope.paymentTypes },
                            valuePrimitive: true
                        }).data('kendoComboBox');
                    }
                }
            },
            {
                field: "Uploader", title: "Uploader", template: uploaderTemplate, width: 80, minResizableWidth: 80, groupable: false, sortable: false, filterable: false 
            },
            {
                field: "Uploader", title: "Receipts", template: newUploaderTemplate, width: 1000, minResizableWidth: 200, groupable: false, sortable: false, filterable: false, includeInChooser: false,
                attributes: {
                    "class": "k-group-cell",
                    "style": "border:solid; border-width: 0 0 1px 1px; border-color: lightgray; background-color: inherit"
                }
            },
            { field: "JobComponent", title: "Component", hidden: true, groupable: true, groupHeaderTemplate: jobComponentGroupString }
        ],
        edit: function (e) {
            var functionComboBox = $("#functionms").data("kendoComboBox");
            var jobsComboBox = $("#jobms").data("kendoComboBox");
            var jobComponentComboBox = $("#jobcomponentms").data("kendoComboBox");
            if ($scope.Custom2 === true && e.model["IsImported"] === true && e.model["CreatedBy"] !== $scope.UserCode) {
                if (functionComboBox === undefined && jobsComboBox === undefined && jobComponentComboBox === undefined) {
                    this.closeCell();
                }
            }
            if (e.model.isNew()) {
                if ($scope.isLastPaymentSet == false) {
                    e.model.set("PaymentType", $scope.lastPaymentType);
                    $scope.isLastPaymentSet = true;
                }
            }
            //sets function code value if any
            
            if (functionComboBox) {
                if (e.model["Function"]) {
                    var inx = $scope.functionCodes.findIndex(function (funcode) {
                        return (e.model["Function"] == funcode.Code);
                    });

                    functionComboBox.select(inx);
                    functionComboBox.input.select();
                }
            }
            if (functionComboBox) {
                functionComboBox.bind("change", function (el) {
                    if (e.model["Function"] != null && e.model["Function"] != '' && this.value != null && this.value != "") {

                        expService.getBillingRate(e.model["Function"], e.model["Client"], e.model["Division"], e.model["Product"], e.model["Job"], e.model["Component"]).then(result => {
                            e.model.set("Rate", result.data);                            
                            if (e.model["Quantity"] != null && e.model["Quantity"] != '' && this.value != null && this.value != "") {
                                //console.log(e.model["Rate"]);
                                if ($scope.Custom2 === true && e.model["IsImported"] === true && e.model["CreatedBy"] !== $scope.UserCode && e.model["Rate"] === 0) {
                                    e.model.set("Quantity", 0);
                                    //e.model.set("Rate", (e.model["Amount"] / e.model["Quantity"]).toFixed(4));
                                } else if ($scope.Custom2 === true && e.model["IsImported"] === true && e.model["CreatedBy"] !== $scope.UserCode && e.model["Rate"] !== 0) {
                                    e.model.set("Quantity", (e.model["Amount"] / e.model["Rate"]).toFixed(4));
                                } else {
                                    if (result.data !== '') {
                                        e.model.set("Amount", (e.model["Quantity"] * result.data).toFixed(2));
                                    }                                    
                                }
                               
                            } else if ((e.model["Quantity"] == null || e.model["Quantity"] == '') && this.value != null && this.value != "" && e.model["Amount"] != null && e.model["Amount"] != '') {
                                if (e.model["Rate"] > e.model["Amount"]) {
                                    e.model.set("Quantity", 1);
                                    e.model.set("Rate", e.model["Amount"]);
                                } else {
                                    if (result.data !== 0 && result.data !== '') {
                                        e.model.set("Quantity", (e.model["Amount"] / result.data).toFixed(0));
                                    }                                    
                                }
                             }
                        });
                    }
                });
            }

            //handles clients code change behavior
            var clientComboBox = $("#clientms").data("kendoComboBox");
            if (clientComboBox) {
                clientComboBox.bind("change", function (el) {
                    var clientCode = this.value();
                    if (clientCode != null && clientCode != '') {
                        //get devisions
                        $scope.divisions = $scope.allJobs.filter((value, index, self) => value.ClientCode === clientCode);
                        $scope.divisions = $scope.divisions
                            .map(function (item) { return { Code: item.DivisionCode, Name: item.DivisionName } })
                            .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                            .sort(function (a, b) {
                                return a.Code.localeCompare(b.Code);
                            });

                        if ($scope.divisions.length == 1) {
                            e.model.set("Division", $scope.divisions[0].Code);

                            $scope.products = $scope.allJobs.filter((value, index, self) => (value.ClientCode === clientCode && value.DivisionCode === $scope.divisions[0].Code));
                            $scope.products = $scope.products
                                .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName } })
                                .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                                .sort(function (a, b) {
                                    return a.Code.localeCompare(b.Code);
                                });

                            if ($scope.products.length == 1) {
                                e.model.set("Product", $scope.products[0].Code);
                                $scope.jobs = $scope.allJobs.filter((value, index, self) =>
                                    value.ClientCode === clientCode && value.DivisionCode === $scope.divisions[0].Code && value.ProductCode === $scope.products[0].Code);
                                $scope.jobs = $scope.jobs
                                    .map(function (item) { return { Number: item.Number, Description: item.JobDescription } })
                                    .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);
                                if ($scope.jobs.length == 1) {

                                    if ($scope.columnSettings.job) {
                                        e.model.set("Job", $scope.jobs[0].Number);
                                    }
                                    $scope.jobcomponents = $scope.allJobs.filter((value, index, self) =>
                                        (value.ClientCode === clientCode && value.Number === $scope.jobs[0].Number));
                                    $scope.jobcomponents = $scope.jobcomponents
                                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description } })
                                        .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);
                                    if ($scope.jobcomponents.length == 1) {
                                        if ($scope.columnSettings.job) {
                                            e.model.set("Component", $scope.jobcomponents[0].ID);
                                        }
                                    }
                                    else {
                                        e.model.set("Component", '');
                                    }
                                }
                                else {
                                    e.model.set("Job", '');
                                    e.model.set("Component", '');
                                }//end jobs
                            }
                            else {
                                //productms.value(null);
                                e.model.set("Product", '');
                                e.model.set("Job", '');
                                e.model.set("Component", '');
                            }//end products
                        }
                        else {
                            e.model.set("Division", '');
                            e.model.set("Product", '');
                            e.model.set("Job", '');
                            e.model.set("Component", '');
                        }//end division
                    }
                    else {
                        e.model.set("Client", '');
                        e.model.set("Division", '');
                        e.model.set("Product", '');
                        e.model.set("Job", '');
                        e.model.set("Component", '');
                    }
                    //Handle change
                });//end change handler

                if (e.model["Client"]) {
                    var inx = $scope.clients.findIndex(function (cli) {
                        return (e.model["Client"] == cli.Code);
                    });
                    clientComboBox.select(inx);
                    clientComboBox.input.select();
                }
            }

            //handles division code change behavior
            var divisionComboBox = $("#divisionms").data("kendoComboBox");
            if (divisionComboBox) {

                var selectedClientCode = e.model["Client"];
                if (selectedClientCode == null || selectedClientCode == '' || $scope.columnSettings.client == false) {

                    $scope.divisions = $scope.allJobs
                        .map(function (item) { return { Code: item.DivisionCode, Name: item.DivisionName + ' (' + item.DivisionCode + ')', ClientCode: item.ClientCode, CD: item.ClientCode + '/' + item.DivisionCode }; })
                        .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                        .sort(function (a, b) {
                            return a.CD.localeCompare(b.CD);
                        });
                }
                else {
                    $scope.divisions = $scope.allJobs.filter((value, index, self) => value.ClientCode === selectedClientCode);
                    $scope.divisions = $scope.divisions
                        .map(function (item) { return { Code: item.DivisionCode, Name: item.DivisionName + ' (' + item.DivisionCode + ')', ClientCode: item.ClientCode, CD: item.ClientCode + '/' + item.DivisionCode }; })
                        .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                        .sort(function (a, b) {
                            return a.CD.localeCompare(b.CD);
                        });
                }

                var ds = { data: $scope.divisions };
                divisionComboBox.setDataSource(ds);

                divisionComboBox.bind("change", function (el) {

                    var selectedDevision = this.value();
                    var Divisionitem = this.dataItem(this.select());

                    if (selectedDevision != null && selectedDevision != '') {

                        var flagClient = true;
                        if (selectedClientCode == null || selectedClientCode == '') { flagClient = false; }

                        $scope.products = $scope.allJobs.filter((value, index, self) => (!flagClient || value.ClientCode === selectedClientCode) && value.DivisionCode === selectedDevision);
                        $scope.products = $scope.products
                            .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName }; })
                            .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                            .sort(function (a, b) {
                                return a.Code.localeCompare(b.Code);
                            });

                        if ($scope.products.length == 1) {
                            e.model.set("Product", $scope.products[0].Code);
                            $scope.jobs = $scope.allJobs.filter((value, index, self) =>
                                ((!flagClient || value.ClientCode === selectedClientCode) && value.DivisionCode === selectedDevision && value.ProductCode === $scope.products[0].Code));
                            $scope.jobs = $scope.jobs
                                .map(function (item) { return { Number: item.Number, Description: item.JobDescription }; })
                                .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);

                            if ($scope.jobs.length == 1) {

                                if ($scope.columnSettings.job) {
                                    e.model.set("Job", $scope.jobs[0].Number);
                                }

                                $scope.jobcomponents = $scope.allJobs.filter((value, index, self) =>
                                    ((!flagClient || value.ClientCode === selectedClientCode) && value.Number === $scope.jobs[0].Number));
                                $scope.jobcomponents = $scope.jobcomponents
                                    .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description }; })
                                    .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);

                                if ($scope.jobcomponents.length == 1) {
                                    if ($scope.columnSettings.job) {
                                        e.model.set("Component", $scope.jobcomponents[0].ID);
                                    }

                                }
                                else {
                                    //jc.value(null);
                                    e.model.set("Component", '');
                                }
                            }
                            else {
                                e.model.set("Job", '');
                                e.model.set("Component", '');
                            }//end jobs
                        }
                        else {
                            //productms.value(null);
                            e.model.set("Product", '');
                            e.model.set("Job", '');
                            e.model.set("Component", '');
                        }//end products

                        //find client and set value (in case of client not selected)
                        var findClient = $scope.allJobs.filter((value, index, self) => (value.ClientCode == Divisionitem.ClientCode && value.DivisionCode == selectedDevision));
                        if (findClient.length > 0) {
                            e.model.set("Client", findClient[0].ClientCode);
                        }
                    }
                    else {
                        e.model.set("Division", '');
                        e.model.set("Product", '');
                        e.model.set("Job", '');
                        e.model.set("Component", '');
                    }
                });


                if (e.model["Division"]) {
                    var inx = $scope.divisions.findIndex(function (div) {
                        return (e.model["Division"] == div.Code);
                    });


                    divisionComboBox.refresh();
                    divisionComboBox.select(inx);

                    divisionComboBox.text($scope.divisions[inx].DivisionName);
                    divisionComboBox.input.select();

                }
            }

            //handles product code change behavior
            var productComboBox = $("#productms").data("kendoComboBox");
            if (productComboBox) {

                var selectedClientCode = e.model["Client"];
                var selectedDivision = e.model["Division"];

                if (selectedClientCode == null || selectedClientCode == '' || $scope.columnSettings.client == false) {
                    $scope.products = $scope.allJobs
                        .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName + ' (' + item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode + ')', ClientCode: item.ClientCode, DivisionCode: item.DivisionCode, CDP: item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode } })
                        .filter((value, index, self) => self.findIndex(i => i.Name === value.Name) === index)
                        .sort(function (a, b) {
                            return a.CDP.localeCompare(b.CDP);
                        });
                }
                else {
                    var flagDiv = true;
                    if (selectedDivision == '' || selectedDivision == null) { flagDiv = false; }

                    $scope.products = $scope.allJobs.filter((value, index, self) => ((value.ClientCode === selectedClientCode) && (!flagDiv || (value.DivisionCode === selectedDivision))));
                    $scope.products = $scope.products
                        .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName + ' (' + item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode + ')', ClientCode: item.ClientCode, DivisionCode: item.DivisionCode, CDP: item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode } })
                        .filter((value, index, self) => self.findIndex(i => i.Name === value.Name) === index)
                        .sort(function (a, b) {
                            return a.CDP.localeCompare(b.CDP);
                        });
                }

                var dsp = { data: $scope.products };
                productComboBox.setDataSource(dsp);
                if (e.model["Product"]) {
                    var inx = $scope.products.findIndex(function (pro) {
                        return (e.model["Product"] == pro.Code);
                    });
                    productComboBox.refresh();
                    productComboBox.select(inx);
                    productComboBox.input.select();
                }

                productComboBox.bind("change", function (el) {
                    var selectedProduct = this.value();
                    var Productitem = this.dataItem(this.select());

                    if (selectedProduct != null && selectedProduct != '') {
                        var flagClient = true;
                        var flagDiv = true;

                        if (selectedDivision == null || selectedDivision == '') { flagDiv = false; }
                        if (selectedClientCode == null || selectedClientCode == '') { flagClient = false; flagDiv = false; }

                        $scope.jobs = $scope.allJobs.filter((value, index, self) =>
                            ((!flagClient || value.ClientCode === selectedClientCode) && (!flagDiv || value.DivisionCode === selectedDivision) && value.ProductCode === selectedProduct));
                        $scope.jobs = $scope.jobs
                            .map(function (item) { return { Number: item.Number, Description: item.JobDescription } })
                            .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);

                        if ($scope.jobs.length == 1) {
                            if ($scope.columnSettings.job) {
                                e.model.set("Job", $scope.jobs[0].Number);
                            }

                            $scope.jobcomponents = $scope.allJobs.filter((value, index, self) =>
                                ((!flagClient || value.ClientCode === selectedClientCode) && value.Number === $scope.jobs[0].Number));
                            $scope.jobcomponents = $scope.jobcomponents
                                .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description } })
                                .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);

                            if ($scope.jobcomponents.length == 1) {
                                if ($scope.columnSettings.job) {
                                    e.model.set("Component", $scope.jobcomponents[0].ID);
                                }
                            }
                            else {
                                //jc.value(null);
                                e.model.set("Component", '');
                            }
                        }
                        else {
                            e.model.set("Job", '');
                            e.model.set("Component", '');
                        }//end jobs

                        var findClient = $scope.allJobs.filter((value, index, self) => (value.ClientCode == Productitem.ClientCode && value.DivisionCode == Productitem.DivisionCode && value.ProductCode == selectedProduct));
                        if (findClient.length > 0) {
                            //e.model.set("Product", findJob[0].ProductCode);
                            e.model.set("Division", findClient[0].DivisionCode);
                            e.model.set("Client", findClient[0].ClientCode);
                        }
                    }
                    else {
                        e.model.set("Product", '');
                        e.model.set("Job", '');
                        e.model.set("Component", '');
                    }
                });
            }


            //handles job code change behavior
            
            if (jobsComboBox) {
                var selectedClientCode = e.model["Client"];
                var selectedDivision = e.model["Division"];
                var selectedProduct = e.model["Product"];


                //if client is not selected or client is not visible
                if (selectedClientCode == null || selectedClientCode == '' || $scope.columnSettings.client == false) {

                    $scope.jobs = $scope.allJobs
                        .map(function (item) { return { Number: item.Number, Description: item.Number + ' - ' + item.JobDescription + ' ' + $scope.getJobDescription(item.ClientCode, item.DivisionCode, item.ProductCode) } })
                        .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);
                }
                else {
                    //var flagClient = true;
                    var flagProduct = true;
                    var flagDiv = true;

                    //if (selectedClientCode == null || selectedClientCode == '' || !$scope.columnSettings.client) { flagClient = false; }
                    if (selectedProduct == '' || selectedProduct == null || !$scope.columnSettings.product) { flagProduct = false; }
                    if (selectedDivision == '' || selectedDivision == null || !$scope.columnSettings.division) { flagDiv = false; flagProduct = false }


                    $scope.jobs = $scope.allJobs.filter((value, index, self) => ((value.ClientCode === selectedClientCode) && (!flagDiv || value.DivisionCode === selectedDivision) && (!flagProduct || value.ProductCode === selectedProduct)));
                    $scope.jobs = $scope.jobs
                        .map(function (item) { return { Number: item.Number, Description: item.Number + ' - ' + item.JobDescription } })
                        .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);


                }

                var ds = { data: $scope.jobs };
                jobsComboBox.setDataSource(ds);

                if (e.model["Job"]) {
                    var inx = $scope.jobs.findIndex(function (job) {
                        return (e.model["Job"] == job.Number);
                    });

                    jobsComboBox.refresh();
                    jobsComboBox.select(inx);
                    jobsComboBox.input.select();
                }


                var jobMs = e.container.find('.job');
                jobMs.change(function () {
                    var selectedJob = this.value;

                    if (selectedJob != jobsComboBox.value()) { return; }

                    var job = $scope.allJobs.filter((value, index, self) => (value.Number == selectedJob));
                    var Client = '';
                    var Division = '';
                    var Product = '';

                    if (job[0]) {
                        Client = job[0].ClientCode;
                        Division = job[0].DivisionCode;
                        Product = job[0].ProductCode;
                    }

                    if (this.value !== 'undefined' && this.value !== null && this.value !== '') {

                        //load job componet from job list               
                        $scope.jobcomponents = $scope.allJobs.filter((value, index, self) => (value.Number == selectedJob));
                        $scope.jobcomponents = $scope.jobcomponents
                            .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description } })
                            .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);

                        if ($scope.jobcomponents.length == 1) {
                            //jc.value($scope.jobcomponents[0].ID);
                            e.model.set("Component", '');
                            e.model.set("Component", $scope.jobcomponents[0].ID);
                        }
                        else {
                            //jc.value(null);
                            e.model.set("Component", '');
                        }

                        if (selectedJob && jobsComboBox.select() === -1) {
                            jobsComboBox.value('');
                        }
                    }
                    else if (this.value != 'undefined' && this.value == '') {
                        $scope.jobcomponents = [];
                        e.model.set("Component", '');
                    }

                    e.model.set("Client", Client);
                    e.model.set("Division", Division);
                    e.model.set("Product", Product);
                    expService.getBillingRate(e.model["Function"], Client, Division, Product, selectedJob, e.model["Component"]).then(result => {
                        if (result.data !== 0) {

                            e.model.set("Rate", result.data);

                            if (e.model["Quantity"] != null && e.model["Quantity"] != '' && this.value != null && this.value != "") {
                                e.model.set("Amount", (e.model["Quantity"] * result.data).toFixed(2));

                            }
                        }
                    });

                });

            }

            //handles job component code change behavior
            
            if (jobComponentComboBox) {
                var flagSetJob = false;
                var selectedJob = e.model["Job"];

                if (selectedJob == '' || selectedJob == null) {
                    var selectedClientCode = e.model["Client"];
                    var selectedDivision = e.model["Division"];
                    var selectedProduct = e.model["Product"];
                    var flagClient = true;
                    var flagProduct = true;
                    var flagDiv = true;

                    if (selectedProduct == '' || selectedProduct == null || !$scope.columnSettings.product) { flagProduct = false; }
                    if (selectedDivision == '' || selectedDivision == null || !$scope.columnSettings.division) { flagDiv = false; flagProduct = false }
                    if (selectedClientCode == null || selectedClientCode == '' || !$scope.columnSettings.client) { flagClient = false; flagDiv = false; flagProduct = false; }

                    $scope.jobcomponents = $scope.allJobs.filter((value, index, self) => (
                        (!flagClient || value.ClientCode === selectedClientCode) &&
                        (!flagDiv || value.DivisionCode === selectedDivision) &&
                        (!flagProduct || value.ProductCode === selectedProduct)));

                    $scope.jobcomponents = $scope.jobcomponents
                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description, Number: item.Number, value: item.Number, jobcomponent: '' + item.Number + '|' + item.JobComponentNumber + ' - ' + item.JobComponentDescription }; })
                        .filter((value, index, self) => self.findIndex(i => i.ID === value.ID && i.Number === value.Number) === index)
                        .sort((a, b) => b.value - a.value);

                    flagSetJob = true;

                }
                else {
                    $scope.jobcomponents = $scope.allJobs.filter((value, index, self) => (value.Number == selectedJob));
                    $scope.jobcomponents = $scope.jobcomponents
                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description, value: item.Number, jobcomponent: '' + item.Number + '|' + item.JobComponentNumber + ' - ' + item.JobComponentDescription }; })
                        .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index)
                        .sort((a, b) => b.value - a.value);
                }


                var dsj = { data: $scope.jobcomponents };
                jobComponentComboBox.setDataSource(dsj);

                if (e.model["Component"]) {
                    var inx = $scope.jobcomponents.findIndex(function (cmp) {
                        return (e.model["Component"] == cmp.ID);
                    });
                    jobComponentComboBox.refresh();
                    jobComponentComboBox.select(inx);
                    jobComponentComboBox.input.select();
                }

                if (flagSetJob) {
                    jobComponentComboBox.bind("change", function (el) {

                        var res = this.text().split("/");
                        var jobValue = parseInt(res[0]);
                        e.model.set("Job", jobValue);

                        var job = $scope.allJobs.filter((value, index, self) => (value.Number == jobValue));

                        var Client = job[0].ClientCode;
                        var Division = job[0].DivisionCode;
                        var Product = job[0].ProductCode;

                        e.model.set("Client", Client);
                        e.model.set("Division", Division);
                        e.model.set("Product", Product);

                        expService.getBillingRate(e.model["Function"], Client, Division, Product, e.model["Job"], e.model["Component"]).then(result => {

                            if (result.data !== 0) {

                                e.model.set("Rate", result.data);

                                if (e.model["Quantity"] != null && e.model["Quantity"] != '' && this.value != null && this.value != "") {
                                    e.model.set("Amount", (e.model["Quantity"] * result.data).toFixed(2));
                                } else if ((e.model["Quantity"] == null || e.model["Quantity"] == '') && this.value != null && this.value != "" && e.model["Amount"] != null && e.model["Amount"] != '') {
                                    if (e.model["Rate"] > e.model["Amount"]) {
                                        e.model.set("Quantity", 1);;
                                        e.model.set("Rate", e.model["Amount"]);
                                    } else {
                                        e.model.set("Quantity", (e.model["Amount"] / result.data).toFixed(0));
                                    }
                                }
                            }

                        });
                    });
                }
            }

            //sets payment code value if any
            var paymentComboBox = $('#paymentms').data("kendoComboBox");
            if (paymentComboBox) {
                paymentComboBox.bind("change", function (el) {
                    $scope.lastPaymentType = this.value();

                    expService.saveDefaultPaymentType(this.value()).then(function (result) {
                        $scope.DefaultPaymentType = this.value();
                        //console.log("databound" + e.sender.dataSource.pageSize());
                    });

                });
            }
            //changeamount
            var tbQuantity = e.container.find("input[name=Quantity]");
            var tbRate = e.container.find("input[name=Rate]");
            var tbAmount = e.container.find("input[name=Amount]").data("kendoNumericTextBox");
            var tbAmountv = e.container.find("input[name=Amount]");

            //handles quantity value change behavior
            tbQuantity.change(function (ev) {

                if (this != null && this.value != "" && e.model["Rate"] != null && e.model["Rate"] != '') {
                    e.model.set("Amount", (this.value * e.model["Rate"]).toFixed(2));
                } else if (this != null && this.value != "" && e.model["Amount"] != null && e.model["Amount"] != '') {
                    e.model.set("Rate", (e.model["Amount"] / this.value).toFixed(4));
                }
            });

            //handles rate value change behavior
            tbRate.change(function (ev) {
                if (e.model["Quantity"] != null && e.model["Quantity"] != '' && this.value != null && this.value != "") {
                    e.model.set("Amount", (e.model["Quantity"] * this.value).toFixed(2));
                } else if (e.model["Quantity"] == null && e.model["Quantity"] == '' && this.value != null && this.value != "" && e.model["Amount"] != null && e.model["Amount"] != '') {
                    e.model.set("Quantity", (e.model["Amount"] / this.value).toFixed(0));
                }
            });

            //handles amount value change behavior
            tbAmountv.change(function (ev) {
                if (e.model["Quantity"] != null && e.model["Quantity"] != '' && this.value != null && this.value != "" && (e.model["Rate"] == null || e.model["Rate"] == '')) {
                    e.model.set("Rate", (this.value / e.model["Quantity"]).toFixed(4));
                } else if (e.model["Rate"] != null && e.model["Rate"] != '' && this.value != null && this.value != "" && (e.model["Quantity"] == null || e.model["Quantity"] == '')) {
                    e.model.set("Quantity", (this.value / e.model["Rate"]).toFixed(0));
                }

                if ($scope.columnSettings.rate && e.model["Quantity"] != null && e.model["Quantity"] != '') {
                    e.model.set("Rate", (this.value / e.model["Quantity"]).toFixed(4));
                }
            });

            if (tbAmount) {
                if (e.model["Quantity"] != null && e.model["Quantity"] != '' && e.model["Rate"] != null && e.model["Rate"] != '') {
                    //tbAmount.readonly(true);
                }
                else {
                    tbAmount.readonly(false);
                }

                if ($scope.columnSettings.quantity == false && $scope.columnSettings.rate == false) {
                    tbAmount.readonly(false);
                }
            }

            e.model.bind("change", function (j) {
                $scope.checkDirtyRows();
            });

            //Autoselect text
            var input = e.container.find("input");
            setTimeout(function () {
                input.select();
            }, 25);

        },
        cancel: function (e) {

            $scope.grid.cancelChanges();
        },
        saveChanges: function (e) {

        },
        sort: function (e) {

            $scope.selectedRow = [];
        }
    };

    //functions to show details for data grid

    //shows selected function code descriptin in data grid cell
    function functionCodeString(item) {

        var resultCodeDesc = '';
        $scope.functionCodes.forEach(function (fc) {
            if (fc.Code == item.Function) {
                resultCodeDesc = fc.DescriptionOnly;
            }
        });
        return resultCodeDesc;
    }

    function functionGroupString(item) {

        if (item.value === '' || item.value === null) { return ''; }
        var func = $scope.functionCodes.find(({ Code }) => Code === item.value);

        if (func != null && func != 'undefined') {
            return func.DescriptionOnly;
        }
        else {
            return func.Code;
        }

    }

    //shows selected payment descriptin in data grid cell
    function paymentTypeString(item) {

        var resultPaymentType = '';
        $scope.paymentTypes.forEach(function (pt) {

            if (item.PaymentType == pt.Value) {
                resultPaymentType = pt.Description;
                if (pt.value === 0) {
                    resultPaymentType.tooltip = "Company Credit Card";
                } else {
                    resultPaymentType.tooltip = "Personal Card or Cash";
                }
            }
        });
        return resultPaymentType;
    }

    function paymentTypegroupString(item) {

        var resultPaymentType = '';
        $scope.paymentTypes.forEach(function (pt) {

            if (item.PaymentType == pt.Value) {
                resultPaymentType = pt.Description;
                if (pt.value === 0) {
                    resultPaymentType.tooltip = "Company Credit Card";
                } else {
                    resultPaymentType.tooltip = "Personal Card or Cash";
                }
            }
        });
        return resultPaymentType;
    }

    //shows selected client code descriptin in data grid cell
    function clientString(item) {
        if (item.Client == '' || item.Client == null) { return ''; }

        var client = $scope.clients.find(({ Code }) => Code === item.Client);

        if (client != null && client != 'undefined') {
            return client.NameOnly;
        }
        else {
            return item.Client;
        }
    }

    function clientGroupString(item) {

        if (item.value == '' || item.value == null) { return ''; }

        var client = $scope.clients.find(({ Code }) => Code === item.value);

        if (client != null && client != 'undefined') {
            return client.NameOnly;
        }
        else {
            return item.value;
        }

    }

    //shows selected division code descriptin in data grid cell
    function divisionString(item) {
        if (item.Division == '' || item.Division == null) { return ''; }

        var division = $scope.allJobs.find(({ DivisionCode, ClientCode }) => DivisionCode === item.Division && ClientCode == item.Client);
        if (division != null && division != 'undefined') {
            return division.DivisionName;  // + ' (' + division.DivisionCode + ')';
        }
        else {
            return item.Division;
        }
    }

    function divisionGroupString(item) {
        if (item.value == '' || item.value == null) {
            return '';
        }

        //find the actual data
        var items = item.items;
        while (items[0].field) {
            items = items[0].items;
        }

        var division = $scope.allJobs.find(({ DivisionCode, ClientCode }) => DivisionCode === item.value && ClientCode == items[0].Client);
        if (division != null && division != 'undefined') {
            return division.DivisionName;  // + ' (' + division.DivisionCode + ')';
        }
        else {
            return item.value;
        }

    }

    //shows selected product code descriptin in data grid cell
    function productString(item) {
        if (item.Product == '' || item.Product == null) { return ''; }

        var product = $scope.allJobs.find(({ ProductCode, DivisionCode, ClientCode }) => ProductCode == item.Product && DivisionCode == item.Division && ClientCode == item.Client);
        if (product != null && product != 'undefined') {
            return product.ProductName;  // + ' (' + product.ProductCode + ')';
        }
        else {
            return item.Product;
        }
    }

    function productGroupString(item) {

        if (item.value == '' || item.value == null) { return ''; }

        var items = item.items;
        while (items[0].field) {
            items = items[0].items;
        }
        
        var product = $scope.allJobs.find(({ ProductCode, DivisionCode, ClientCode }) => ProductCode == item.value && DivisionCode == items[0].Division && ClientCode == items[0].Client);
        if (product != null && product != 'undefined') {
            return product.ProductName;  // + ' (' + product.ProductCode + ')';
        }
        else {
            return item.value;
        }

    }

    //shows selected job code descriptin in data grid cell
    function jobString(item) {
        if (item.Job == '' || item.Job == null) { return ''; }
        var job = $scope.allJobs.find(({ Number }) => Number == item.Job);
        if (job != null && job != 'undefined') {
            return job.Number + ' - ' + job.JobDescription;
        }
        else {
            return item.Job;
        }
    }

    //shows selected job code descriptin in data grid cell
    function jobStringChart(item) {
        if (item.Job == '' || item.Job == null) { return 'N/A'; }
        var job = $scope.allJobs.find(({ Number }) => Number == item.Job);
        if (job != null && job != 'undefined') {
            return job.Number + ' - ' + job.JobDescription;
        }
        else {
            return item.Job;
        }
    }

    //shows selected job component code descriptin in data grid cell
    function jobComponentString(item) {
        if (item.Component == '' || item.Component == null) { return ''; }

        var jobComponent;

        if (item.Job == '' || item.Job == null) {
            //var jobMs = $('.job');

            var jobMs = $("#jobms").data("kendoComboBox");
            jobComponent = $scope.allJobs.find(({ Number, JobComponentNumber }) => Number == jobMs.value() && JobComponentNumber == item.Component);
        }
        else {
            jobComponent = $scope.allJobs.find(({ Number, JobComponentNumber }) => Number == item.Job && JobComponentNumber == item.Component);
        }

        if (jobComponent != null && jobComponent != 'undefined') {

            var tmp = jobComponent.Description.split('/');
            if (tmp.length == 2) {
                return tmp[1];
            }
            else {
                return jobComponent.Description;
            }

        }
        else {
            return item.Component;
        }
    }

    //shows group descriptin in data grid header
    function jobGroupString(item) {
        if (item.value == '' || item.value == null) {
            return '';
        }

        var job = $scope.allJobs.find(({ Number }) => Number == item.value);
        if (job != null && job != 'undefined') {
            return job.Number + ' - ' + job.JobDescription;
        }
        else {
            return item.value;
        }
    }

    function jobComponentGroupString(item) {
        if (item.value === '' || item.value === null) {
            return '';
        } else {
            var items = item.items;
            while (items[0].field) {
                items = items[0].items;
            }

            if (items[0].Component && items[0].JobComponent) {
                return items[0].Component.padStart(3,'0') + ' ' + items[0].JobComponent.slice(items[0].JobComponent.indexOf('-'));
            }

            return item.value;
        }
    }

    function paymentTypeGroupString(item) {
        if (item.value === null) {
            return '';

        } else {
            var type = $scope.paymentTypes.find((v, i, o) => {
                return item.value == v.Value;
            });

            return type ? type.LongDescription : '';
        }
    }

    $scope.handleChange = function (data, dataItem, columns) {
        $scope.selectedRow = data;
    };

    //grid header functions

    //handles add new rows button click
    $scope.addNewRecord = function () {
        $scope.isLastPaymentSet = false;
        $scope.grid.addRow();
        $scope.selectedRow = [];
        $scope.hasDirtyRows = true;
    };

    $scope.dateFilter = (element) => {
        element.kendoDatePicker({
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy'
        });
    };

    //handles copy rows button click
    $scope.copyRecord = function () {
        if ($scope.selectedRow === null) { showKendoAlert('Please select at least one row to copy.'); return; }

        var items = [];
        var indexes = [];
        $scope.grid.select().each(function () {
            var item = $scope.grid.dataItem($(this)).toJSON();
            items.push(item);
            indexes.push($(this).closest("tr").index());
        });

        if (items.length > 0) {
            items.forEach(function (item) {
                var newItem = {};
                angular.copy(item, newItem);
                newItem.Id = null;
                $scope.grid.dataSource.add(newItem);
            });

            $scope.selectedRow = [];
            $scope.hasDirtyRows = true;

        }

        calculateTotals();

        var rows = $scope.grid.dataSource.data();
        var row = rows[rows.length - 1];

        for (var i = 1; i <= indexes.length; i++) {
            $scope.grid.select("tr:eq(" + (rows.length - i) + ")");
        }

        var cell = $('#ExpenseReportsGrid').find('tbody tr:eq(' + (rows.length - 1) + ') td:eq(1)');
        $scope.grid.editCell(cell);

        var scrollContentOffset = $scope.grid.element.find("tbody").offset().top;
        var selectContentOffset = $scope.grid.select().offset().top;
        var distance = selectContentOffset - scrollContentOffset;

        $scope.grid.element.find(".k-grid-content").animate({
            scrollTop: distance
        }, 400);

    };

    //handles cancel grid changes button click
    $scope.cancelClick = function () {
        if (confirm('Are you sure you want to cancel all unsaved changes on the expense report grid? You cannot undo this operation.')) {
            $scope.grid.cancelChanges();
            $scope.selectedRow = [];
            $scope.hasDirtyRows = false;
        }
    };

    $scope.exportToExcel = function (){
        try {
            var grid = $('#ExpenseReportsGrid').data('kendoGrid');

            grid.saveAsExcel();
        } catch (e) {
            console.log(e);
        }
    };

    $scope.refreshDetails = () => {
        expService.getExpenseReportDetails($scope.expenseReportHeader.InvoiceNumber).then(function (details) {
            $scope.expenseReportDetails = details.data;
            $scope.gridData = prepereDataForGrid();
            calculateTotals();

            $scope.grid.setDataSource(getDataSource());
            setTimeout(function () {
                $scope.grid.dataSource.pageSize($scope.pagesize);
                $scope.grid.dataSource.read(); $scope.grid.refresh();
                $scope.hasDirtyRows = false;
                $scope.selectedRow = [];
                angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);
                $scope.$apply();
               
                //document.title = 'EX ' + $scope.expenseReportHeader.InvoiceNumber + " - " + $scope.expenseReportHeader.Description;
            }, 50);
            $scope.hasDirtyRows = false;           
        });
    };

    $scope.refreshTopDetails = () => {
        expService.getExpenseReportDetails($scope.expenseReportHeader.InvoiceNumber).then(function (details) {
            $scope.expenseReportDetails = details.data;
            $scope.gridData = prepereDataForGrid();
            calculateTotals();
        });
    };

    $scope.deleteRecordtest = function () {
        //Deletes the selected rows
        if ($scope.selectedRow === null) { showKendoAlert('Please select at least one row to delete.'); return; }
        var itemsToRemoveDB = [];
        showKendoConfirm("Are you sure you want to delete the selected row(s)?")
            .done(function () {
                $scope.grid.select().each(function () {
                    var item = $scope.grid.dataItem($(this)).toJSON();
                    itemsToRemoveDB.push(item.Id);
                    // $scope.grid.removeRow($(this));
                });
                $scope.grid.select().each(function () {
                    $scope.grid.removeRow($(this));
                });

                $scope.selectedRow = [];
                //$scope.hasDirtyRows = true;
                if (itemsToRemoveDB.length > 0) {
                    //remove from db 
                    expService.deleteExpenseReportDetailsByIDs(itemsToRemoveDB).then(function (response) {
                        $scope.grid.refresh();

                        $scope.refreshTopDetails();
                    });
                }
            })
            .fail(function () {
            });
    };

    //handles delete rows button click
    $scope.deleteRecord = function () {
        //Deletes the selected rows
        if ($scope.selectedRow === null) { showKendoAlert('Please select at least one row to delete.'); return; }
        var itemsToRemoveDB = [];
        if ($scope.saveAvailable === true || $scope.hasDirtyRows === true || dateChanged === true) {
            if (confirm('You have unsaved changes, would you like to save and continue deleting the selected row(s)?')) {
                var saved = $scope.saveClick();

                if (saved === false) {
                    return;
                }

                $scope.grid.select().each(function () {
                    var item = $scope.grid.dataItem($(this)).toJSON();
                    itemsToRemoveDB.push(item.Id);
                });
                $scope.selectedRow = [];
                $scope.hasDirtyRows = true;
                if (itemsToRemoveDB.length > 0) {
                    //remove from db 
                    expService.deleteExpenseReportDetailsByIDs(itemsToRemoveDB).then(function (response) {
                        $scope.refreshGrid();
                    });
                }

            }
        } else {
            
            if (confirm('Are you sure you want to delete the selected row(s)?')) {
                $scope.grid.select().each(function () {
                    var item = $scope.grid.dataItem($(this)).toJSON();
                    itemsToRemoveDB.push(item.Id);
                });
                $scope.selectedRow = [];
                $scope.hasDirtyRows = true;
                if (itemsToRemoveDB.length > 0) {
                    //remove from db 
                    expService.deleteExpenseReportDetailsByIDs(itemsToRemoveDB).then(function (response) {
                        $scope.refreshGridAfterDelete();
                        
                    });
                }
            }
        }
            
    };
    
    //handles show/hide grid columns button click
    $scope.showHideColumns = function () {
        $scope.showAllCols = !$scope.showAllCols;

        if (!$scope.showAllCols) {
            $scope.grid.hideColumn("Quantity");
            $scope.grid.hideColumn("Rate");
            $scope.grid.hideColumn("Client");
            $scope.grid.hideColumn("Division");
            $scope.grid.hideColumn("Product");
            $scope.grid.hideColumn("Job");
            $scope.grid.hideColumn("JobComponent");
        }
        else {
            $scope.grid.showColumn("Quantity");
            $scope.grid.showColumn("Rate");
            $scope.grid.showColumn("Client");
            $scope.grid.showColumn("Division");
            $scope.grid.showColumn("Product");
            $scope.grid.showColumn("Job");
            $scope.grid.showColumn("JobComponent");
        }
    };

    //handles "has receipt view" button click
    $scope.hasReceipViewButton = function () {
        //Clear grouping if any and show default grid view
        $scope.selectedViewMode = 0;

        $(".k-grouping-header").show();
        //$(".k-grouping-header").hide();
        $(".k-grid-content").show();
        $(".k-grid-header").show();
        $(".k-grid-pager").show();

        $('#chart-row').remove();
        //$scope.grid.dataSource.group([]);

        $scope.grid.refresh();
        resizeGrid();
    };

    //handles "receipt view" button click
    $scope.defaultViewButton = function () {
        //Clear grouping if any and show default grid view
        $scope.selectedViewMode = 1;

       // $(".k-grouping-header").hide();
        $(".k-grouping-header").show();
        $(".k-grid-content").show();
        $(".k-grid-header").show();
        $(".k-grid-pager").show();
        $("#receiptView").css("background-color", "");

        //$(".k-chart").hide();
        $('#chart-row').remove();

        //$scope.grid.dataSource.group([]);
        //$scope.selectedViewMode = 1;

        $scope.grid.refresh();
        resizeGrid();
        //$scope.grid.refresh();
    };

    //handles "thumbnail view" button click
    $scope.thumbnailView = function () {

        $scope.selectedViewMode = 2;

        //$(".k-grouping-header").hide();
        $(".k-grouping-header").show();
        $(".k-grid-content").show();
        $(".k-grid-header").show();
        $(".k-grid-pager").show();

        //$(".k-chart").hide();
        $('#chart-row').remove();
        $("#receiptView").css("background-color", "");
        //$scope.grid.dataSource.group([]);

        $scope.grid.refresh();
        resizeGrid();
        //$scope.grid.refresh();
    };

    //handles "group view" button click
    $scope.jobGroupButton = function () {
        // Group Jobs on Click

        $scope.selectedViewMode = 3;

        $(".k-grouping-header").show();
        $(".k-grid-content").show();
        $(".k-grid-header").show();
        
        $("div.k-grouping-header").removeClass("grid-group-header-hide");

        $(".k-grid-pager").show();
        $("#receiptView").css("background-color", "");

        //$(".k-chart").hide();
        $('#chart-row').remove();
        //$scope.grid.groupable = true;
        $scope.grid.dataSource.group({ field: "Job" });

        $scope.grid.collapseGroup(".k-grouping-row:contains(Job)");
        $scope.grid.expandGroup(".k-grouping-row:contains(Job)");
        $scope.grid.refresh();
        resizeGrid();
        //$scope.grid.refresh();
    };



    //handles "chart view" button click
    $scope.viewChart = function () {
        $scope.selectedViewMode = 4;

        //Hide Grid Elements
        $(".k-grouping-header").hide();
        $(".k-grid-content").hide();
        $(".k-grid-header").hide();
        $(".k-grid-pager").hide();
        $("#defaultView").css("background-color", "");
        $('#chart-row').remove();
        let $chartContainer = $("#chart-container");

        var seriesData = [];
        seriesData.length = 0;
        var mycount = 0;
        sum = 0;

        var seriesColors = ["#DC3545", "#4D82B8", "#FFC107", "#808080", "#5CB85C", "#FD7E14", "#B89A7C", "#009688", "#FFC107", "#00BCD4","#D63251","#3A6692","#E2A62E","#515151","#4B7D70","#C96615","#826446","#0C6666","#D2D20F","#0097A7"];

        //["Red", "Green", "Blue", "Yellow", "Orange", "Violet", "Indigo", "Gray", "Brown", "GreenYellow", "Sienna", "Goldenrod", "Black"];

        //
        //  Preperation of chart data for function statistics
        //
        $scope.grid.dataSource.data().forEach(function (funcExpense) {
            mycount = mycount + 1;

            item = {};
            item["code"] = funcExpense.Function;
            item["value"] = funcExpense.Amount;
            item["category"] = functionCodeString(funcExpense);
            item["percentage"] = 0;
            item["color"] = '';
            item["isExploded"] = true;

            itemDivider = {};
            itemDivider["code"] = 'dummy';
            itemDivider["value"] = 1;
            itemDivider["category"] = '';
            itemDivider["percentage"] = 0;
            itemDivider["color"] = '#808080';

            var functionCodeExist = 0;

            if (Object.keys(seriesData).length === 0) {
                seriesData.push(item);
                return;
            }

            for (i = 0; i < Object.keys(seriesData).length; i++) {
                if (seriesData[i]["code"] === item["code"]) {
                    seriesData[i]["value"] = seriesData[i]["value"] + item["value"];

                    functionCodeExist = 1;
                    break;
                }
            }

            if (functionCodeExist === 0) {

                seriesData.push(item);
            }
        });


        var jobsData = [];
        jobsData.length = 0;
        //
        //  Preperation of chart data for job statistics
        //
        $scope.grid.dataSource.data().forEach(function (funcExpense) {
            mycount = mycount + 1;

            item = {};
            item["code"] = funcExpense.Job;
            item["value"] = funcExpense.Amount;
            item["category"] = jobStringChart(funcExpense);
            item["percentage"] = 0;
            item["color"] = '';
            item["isExploded"] = true;

            var functionCodeExist = 0;

            if (Object.keys(jobsData).length == 0) {
                jobsData.push(item);
                return;
            }

            for (i = 0; i < Object.keys(jobsData).length; i++) {
                if (jobsData[i]["code"] == item["code"]) {
                    jobsData[i]["value"] = jobsData[i]["value"] + item["value"];

                    functionCodeExist = 1;
                    break;
                }
            }

            if (functionCodeExist == 0) {

                jobsData.push(item);
            }
        });


        // END RESULT
        var jobsChartdata = new kendo.data.DataSource({
            data: jobsData
        });


        var functionGridData = [];
        functionGridData.length = 0;

        //
        //  Preperation of chart data for function statistics
        //
        $scope.grid.dataSource.data().forEach(function (funcExpense) {
            mycount = mycount + 1;

            item = {};
            item["Function"] = functionCodeString(funcExpense);
            item["Amount"] = funcExpense.Amount;
            item["percentage"] = 0;
            item["color"] = '';
            //item["category"] = functionCodeString(funcExpense);
            sum = sum + funcExpense.Amount;

            var functionCodeExist = 0;

            if (Object.keys(functionGridData).length == 0) {
                functionGridData.push(item);
                return;
            }

            for (i = 0; i < Object.keys(functionGridData).length; i++) {
                if (functionGridData[i]["Function"] == item["Function"]) {
                    functionGridData[i]["Amount"] = functionGridData[i]["Amount"] + item["Amount"];

                    functionCodeExist = 1;
                    break;
                }
            }

            if (functionCodeExist == 0) {

                functionGridData.push(item);
            }
        });

        var jobGridData = [];
        jobGridData.length = 0;

        //
        //  Preperation of chart data for function statistics
        //
        
        $scope.grid.dataSource.data().forEach(function (funcExpense) {
            mycount = mycount + 1;

            item = {};
            item["Function"] = jobStringChart(funcExpense);
            item["Amount"] = funcExpense.Amount;
            item["percentage"] = 0;
            item["color"] = '';
            //item["category"] = functionCodeString(funcExpense);

            var functionCodeExist = 0;
            

            if (Object.keys(jobGridData).length == 0) {
                jobGridData.push(item);
                return;
            }

            for (i = 0; i < Object.keys(jobGridData).length; i++) {
                if (jobGridData[i]["Function"] == item["Function"]) {
                    jobGridData[i]["Amount"] = jobGridData[i]["Amount"] + item["Amount"];

                    functionCodeExist = 1;
                    break;
                }
            }

            if (functionCodeExist == 0) {

                jobGridData.push(item);
            }
        });



        //CREATE DIV ROW AND APPEND TO GRID SO CHARTS WILL BE SIDE TO SIDE        
        $chartRow = $("<div id='chart-row' style='text-align: center; font-size: 17px; display:grid; grid-template-columns:30% 70%'></div>").appendTo($('.k-grid'));       
        $chartHeaderRow = $("<div id='chart-header-row' style='justify-items: center; align-items: center; display:grid; grid-template-columns: 100%;'></div>").appendTo($('#chart-row'));
        $chartHeaderRow2 = $("<div id='chart-header-row2' style='display:grid; grid-template-columns: 100%;justify-items: center'></div>").appendTo($('#chart-row'));
        $chartHeaderRow3 = $("<div id='chart-header-row3' style='text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 17px;'><label id='LabelList' style='font-weight: normal; font-size: 17px; color: #767676'>Expense Report Breakdown By Function</label></div>").appendTo($('#chart-header-row2'));

        // End create chart data
        if (!$chartContainer.length) {
            $chartHeader = $("<div id='chart-header' style='text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 17px; display:grid; grid-template-columns:100%'><label id='Label' style='font-weight: normal; font-size: 17px; color: #767676'>Expense Report Breakdown</label></div>").appendTo($('#chart-header-row'));
            $chartHeaderGraph = $("<div id='chart-header-graph' style='text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 17px; display:grid; grid-template-columns:50% 50%'></div>").appendTo($('#chart-header'));

            // FIRST CHART FOR FUNCTIONS STATISTICS
            $chartContainer = $("<div id='chart-container-functionchart'></div>").appendTo($('#chart-header-graph'));

           
            for (i = 0; i < Object.keys(seriesData).length; i++) {      
                if (sum > 0) {
                    seriesData[i]["percentage"] = kendo.toString((seriesData[i]["value"] / sum) * 100, "n2");
                } 
                //if (seriesData[i]["code"] !== "dummy") {
                    seriesData[i]["color"] = seriesColors[i % 20]; 
                //}
                              
            }

            $chartContainer.kendoChart({
                dataSource: seriesData,
                series: [{
                    type: "pie",
                    field: "value",
                    categoryField: "category",
                    overlay: {
                        gradient: "none"
                    },
                    colorfield: "color"
                }],
                seriesDefaults: {
                    labels: {
                        template: "#= category #: $#= kendo.format('{0:n2}',value) #",
                        position: "outsideEnd",
                        visible: false,
                        background: "transparent"
                    }
                },
                
                seriesClick: function (e) {
                    var x = document.getElementById("chart-container-job");
                    var y = document.getElementById("chart-container-function");

                    y.style.display = "";
                    x.style.display = "none";

                    var l = document.getElementById("LabelList");
                    l.innerHTML = 'Expense Report Breakdown By Function';
                },
                tooltip: {
                    visible: true,
                    template: "#= category #: $#= kendo.format('{0:n2}',value) #<br/>#= kendo.format('{0:n2}',percentage*100)#%"
                },
                title: {
                    text: "Function"
                },
                legend: {
                    position: "bottom",
                    visible: false
                }
            });


            //SECOND CHART FOR JOBS STATISTICS
            $chartContainer = $("<div id='chart-container-jobchart'></div>").appendTo($('#chart-header-graph'));

            for (i = 0; i < Object.keys(jobsData).length; i++) {
                if (sum > 0) {
                    jobsData[i]["percentage"] = kendo.toString((jobsData[i]["value"] / sum) * 100, "n2");
                }
                jobsData[i]["color"] = seriesColors[i % 20];
            }

            $chartContainer.kendoChart({
                dataSource: jobsData,
                series: [{
                    type: "pie",
                    field: "value",
                    categoryField: "category",
                    overlay: {
                        gradient: "none"
                    },
                    colorfield: "color"
                }],
                seriesDefaults: {
                    labels: {
                        template: "#= category #: $#= kendo.format('{0:n2}',value) #",
                        position: "outsideEnd",
                        visible: false,
                        background: "transparent"
                    }
                },                
                seriesClick: function (e) {
                    var x = document.getElementById("chart-container-job");
                    var y = document.getElementById("chart-container-function");

                    y.style.display = "none";
                    x.style.display = "";

                    var l = document.getElementById("LabelList");
                    l.innerHTML = 'Expense Report Breakdown By Job';

                },
                tooltip: {
                    visible: true,
                    template: "#= category #: $#= kendo.format('{0:n2}',value) #<br/>#= kendo.format('{0:n2}',percentage*100)#%"
                },
                title: {
                    text: "Job"
                },
                legend: {
                    position: "bottom",
                    visible: false
                }
            });

            //CARDS

            for (i = 0; i < Object.keys(functionGridData).length; i++) {
                if (sum > 0) {
                    functionGridData[i]["percentage"] = kendo.toString((functionGridData[i]["Amount"] / sum) * 100, "n2");
                }              
                functionGridData[i]["color"] = seriesColors[i % 20];
              
            }

            for (i = 0; i < Object.keys(jobGridData).length; i++) {
                if (sum > 0) {
                    jobGridData[i]["percentage"] = kendo.toString((jobGridData[i]["Amount"] / sum) * 100, "n2");
                }
                jobGridData[i]["color"] = seriesColors[i % 20];
            }

            $chartContainer = $("<div style='padding-top: 20px; padding-left: 55px; border: none; text-align: center' id='chart-container-function'></div>").appendTo($('#chart-header-row3'));

            $chartContainer.kendoListView({                
                dataSource: functionGridData,
                template: kendo.template($("#templateListViewFunction").html()),
                width: 500               
            });

            $chartContainer = $("<div style='padding-top: 20px; padding-left: 110px; text-align: center; border: none; display: none' id='chart-container-job'></div>").appendTo($('#chart-header-row3'));

            $chartContainer.kendoListView({
                dataSource: jobGridData,
                template: kendo.template($("#templateListViewJob").html()),
                width: 500
            });
        } else {
            $(".k-chart").show();
            $chartContainer.data("kendoChart").dataSource.data(jobsData);
            $chartContainer.data("kendoChart").refresh();
        }

       
        //  CREATE ANOTHER GRID AND APPEND TO MAIN GRID

        //  POPULATE KEY CARDS
        kendo.resize($("#chart-container-functionchart"));
        kendo.resize($("#chart-container-jobchart"));

    };   

    function gridPercent(item) {

        var sum = 0;

        $scope.grid.dataSource.data().forEach(function (funcExpense) {
            sum = sum + funcExpense.Amount;
        });

        var percent = (item.Amount / sum) * 100;

        return kendo.toString(percent, "n2");
        
    }

    $scope.editRecord = function ($event) {
        // Get the element which was clicked
        var sender = $event.currentTarget;

        // Get the Kendo grid row which contains the clicked element
        var row = angular.element(sender).closest("tr");

        $scope.grid.editRow(row);
    };

    $scope.updateRecord = function ($event) {
        // Get the element which was clicked
        var sender = $event.currentTarget;

        // Get the Kendo grid row which contains the clicked element
        var row = angular.element(sender).closest("tr");

        // Get the data bound item for that row
        var dataItem = $scope.kendo.myGrid.dataItem(row);
    };

    //receipt Functions

    //handles "expand all receipts" button click (grid cell)
    $scope.toggleExpandAllReceipts = function (rowId) {

        $scope.grid.dataSource.data().forEach((row) => {

            if (row.Id == rowId) {
                row.ShowAllUploadedImages = !row.ShowAllUploadedImages
            }
        });

        $scope.grid.refresh();
    };

    //handles "delete file" button click (receipt item)
    $scope.deleteFileClicked = function (documentId) {

        if ($scope.approvedReport()) {
            showKendoAlert("You can not delete receipts on approved reports!");
            return true;
        }
        showKendoConfirm("Are you sure you want to delete this receipt from the expense report?")
            .done(function () {
                expService.deleteReceipt(documentId).then(function (result) {
                    if (result && result.data) {
                        if (result.data.Success == true) {
                            expService.getReceiptsList($scope.expenseReportHeader.InvoiceNumber).then(function (receipts) {
                                $scope.uploadedImages = receipts.data;
                                $scope.receiptsCount = receipts.data.length;
                                if (receipts.data.length === 0) {
                                    $scope.HasDocuments = 0;
                                }
                                $scope.gridData = prepereDataForGrid();
                                calculateTotals();
                                $scope.grid.setDataSource(getDataSource());
                                setTimeout(function () { $scope.grid.dataSource.pageSize($scope.pagesize); $scope.grid.dataSource.read(); $scope.grid.refresh(); resizeGrid(); $scope.hasDirtyRows = false; }, 300);
                                $scope.hasDirtyRows = false;
                            });
                        } else {
                            if (result.data.Message && result.data.Message != "") {
                                showKendoAlert("<strong>Delete failed:</strong>&nbsp;&nbsp;" + result.data.Message);
                            }
                        }
                    }

                });
            })
            .fail(function () {
            });    
    };

    $scope.numberOfUploadingItems = 0;

    //handles "on receipt upload" - when user selects file for upload
    $scope.onUpload = function (e) {
        $scope.numberOfUploadingItems++;

        var row = e.sender.element[0].attributes['rowid'].value;

        e.data =
            {
                InvoiceNumber: $scope.expenseReportHeader.InvoiceNumber,
                ExpenseDetailID: parseInt(row)
            };
    };

    //handles "upload success" event - when upload finishes sucessfully
    $scope.onSuccess = function (e) {
        if (e.operation === "upload") {

            var err = $.parseJSON(e.XMLHttpRequest.responseText);
            if (err !== '') {
                showKendoAlert(err);
            }            
            setTimeout(function () {              
            
            if ($scope.numberOfUploadingItems !== 0) {
                expService.getReceiptsList($scope.expenseReportHeader.InvoiceNumber).then(result => {
                    $scope.receiptsCount = result.data.length;
                    if (result.data.length > 0) {
                        $scope.HasDocuments = 1;
                    }
                    $scope.uploadedImages = result.data;

                    $scope.gridData = prepereDataForGrid();
                    calculateTotals();


                    $scope.grid.setDataSource(getDataSource());
                    setTimeout(function () { $scope.grid.dataSource.pageSize($scope.pagesize); $scope.grid.dataSource.read(); $scope.grid.refresh(); resizeGrid(); $scope.hasDirtyRows = false; }, 300);
                    $scope.hasDirtyRows = false;

                });
            }
            }, 50);
        }
    };

    $scope.onError = function (e) {
        console.log("ERROR");
    };

    //defines the cell that is shown in receipts column based on selected view
    function receiptTemplate(item) {
        var template = null;
        var result = '';
        if (item.Id == null || item.Id < 1 || item.Receipts.length == 0) { return ''; }


        if ($scope.selectedViewMode == 1 || $scope.selectedViewMode == 3) {
            template = kendo.template($("#inlineUploadFile").html());

            var data = item.Receipts[0];
            var data = { showAllUploadedImages: item.ShowAllUploadedImages, receipts: item.Receipts, receiptsCount: item.Receipts.length, rowId: item.Id };
            var result = template(data);

            if (item.ShowAllUploadedImages) {

                for (i = 1; i < item.Receipts.length; i++) {
                    var tother = kendo.template($("#inlineUploadFileOthers").html());
                    var d2 = item.Receipts[i];
                    result += tother(d2);
                }
            }

        }
        else if ($scope.selectedViewMode == 2) {
            template = kendo.template($("#thumbnailUploadFile").html());

            var data = item.Receipts[0];
            var data = { showAllUploadedImages: item.ShowAllUploadedImages, receipts: item.Receipts, receiptsCount: item.Receipts.length, rowId: item.Id };
            result = template(data);

            if (item.ShowAllUploadedImages) {

                for (i = 1; i < item.Receipts.length; i++) {
                    var tother = kendo.template($("#thumbnailUploadFileOther").html());
                    var d2 = item.Receipts[i];
                    result += '<div style="padding: 2px;"></div>' + tother(d2);
                }
            }
        }
        else if ($scope.selectedViewMode == 0) {
            var resultIcon = '';
            if (item.Receipts.length == 1) {
                resultIcon = '<div align="center"><img class="k-link k-button k-button-icon" src="../../Images/Icons/Grey/256/document_empty.png" /></div>';
            }
            else {
                resultIcon = '<div align="center"><img class="k-link k-button k-button-icon" src="../../Images/Icons/Grey/256/documents_empty.png" /></div>';
            }

            return resultIcon;
        }
        return result;
    }


    function newUploaderTemplate(item) {
        //console.log('newUploaderTemplate');
        if (item.Id === null || item.Id < 1 ) {
            return '';
        } 

        var template = null;
        var result = '';

        if ($scope.selectedViewMode === 0) {
            template = kendo.template($("#newUploadColumn").html());
            result = template(item);
            return result;
        } else if ($scope.selectedViewMode === 1 || $scope.selectedViewMode === 3) {
            template = kendo.template($("#inlineUploadFile").html());
            result = template(item);
            return result;
        } else {

            template = kendo.template($("#newUploadThumbnailColumn").html());
            result = template(item);
            return result;
        }
    }

    //defines the cell that is shown in uploader column
    function uploaderTemplate(item) {
        if (item.Id === null || item.Id < 1 || $scope.approvedReport()) {
            return '';
        }

        var template = null;
        template = kendo.template($("#newUploadOnlyColumn").html());
        var data = item.Id;
        var result = template(data);
        return result;
    }

    //defines the editor that is shown in quntity column
    function editNumberQuantity(container, options) {
        $('<input name="Quantity" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoNumericTextBox({
                spinners: false,
                step: 0,
                decimals: 0,
                min: -999999999,
                max: 999999
            });
    }

    function amountEditor(container, options) {
        $('<input type="number" name="Amount" class="k-input k-textbox" data-bind="value:' + options.field + '"/>').appendTo(container);
    }

    function quantityEditor(container, options) {
        $('<input type="number" name="Quantity" class="k-input k-textbox" data-bind="value:' + options.field + '"/>').appendTo(container);
    }

    function rateEditor(container, options) {
        $('<input type="number" name="Rate" class="k-input k-textbox" data-bind="value:' + options.field + '"/>').appendTo(container);
    }

    //defines the editor that is shown in rate column
    function editNumberRate(container, options) {
        $('<input name="Rate" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoNumericTextBox({
                spinners: false,
                step: 0,
                decimals: 4,
                min: -999999999,
                max: 999999999
            });
    }    

    //defines the editor that is shown in amount column
    function editNumberAmount(container, options) {
        $('<input name="Amount" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoNumericTextBox({
                spinners: false,
                step: 0,
                decimals: 2,
                min: -999999999,
                max: 999999999                
            });
    }

    //defines the editor that is shown in payment column
    function paymentMultiselectEditor(container, options) {

        var comboBox = $('<select id="paymentms" class="paymentType" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: false,
                //placeholder: "Select payment type...",
                dataValueField: "Value",
                dataTextField: "Description",
                filter: "contains",
                template: "#: data.LongDescription #",
                dataSource: { data: $scope.paymentTypes },
                valuePrimitive: true
            }).data('kendoComboBox');

        $('#paymentms').data('kendoComboBox').list.width(180);
    }

    //defines the editor that is shown in date column
    function dateGridEditor(container, options) {

        $('<input autocomplete="off" maxlength="10" type="text" style="width:110px" name="Date" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoDatePicker({
                format: "MM/dd/yyyy",
                parseFormats: ["Mddyy", "MMddyy", "Mddyyyy", "MMddyyyy", "MM/dd/yyyy", "MM/d/yy", "M/dd/yy", "M/d/yy"]
            });
    }

    //defines the editor that is shown in description column
    function descriptionEditor(container, options) {
        $('<input autocomplete="off" maxlength="600" type="text" class="k-input k-textbox" name="Description" data-bind="value:' + options.field + '"/>')
            .appendTo(container);
    }

    //defines the editor that is shown in function column
    function functionMultiselectEditor(container, options) {

        $('<select id="functionms" class="function" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: false,
                //placeholder: "Select function...",
                dataValueField: "Code",
                dataTextField: "Description",
                filter: "contains",

                dataSource: { data: $scope.functionCodes },
                valuePrimitive: true
            });
    }

    //defines the editor that is shown in client column
    function clientMultiselectEditor(container, options, data) {
        //$('<select id="clientms" onblur="onSelectChange();" class="client" data-bind="value:' + options.field + '"/>')

        var input = $('<select id="clientms" class="client" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: true,
                //placeholder: "Select client...",
                dataTextField: "Name",
                dataValueField: "Code",
                filter: "contains",
                dataSource: { data: $scope.clients },
                valuePrimitive: true,
                change: function (e) {

                }
            });
    }

    //defines the editor that is shown in division column
    function divisionMultiselectEditor(container, options) {

        $('<select id="divisionms" class="division" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: true,
                //placeholder: "Select division...",
                dataTextField: "Name",
                dataValueField: "Code",

                filter: "contains",
                dataSource: { data: $scope.divisions },
                valuePrimitive: true
            });
    }

    //defines the editor that is shown in product column
    function productMultiselectEditor(container, options) {

        $('<select id="productms" class="product" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: true,
                //placeholder: "Select product...",
                dataTextField: "Name",
                dataValueField: "Code",

                filter: "contains",
                dataSource: { data: $scope.products },
                valuePrimitive: true,
                change: function (e) {

                    var widget = e.sender;
                    if (widget.value() && widget.select() === -1) {
                        widget.value(""); //reset widget
                    }

                }
            });
    }

    //defines the editor that is shown in jobs column
    function jobMultiselectEditor(container, options) {

        $('<select id="jobms" class="job" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: true,
                //placeholder: "Select job...",
                dataTextField: "Description",
                dataValueField: "Number",

                filter: "contains",
                dataSource: { data: $scope.jobs },
                valuePrimitive: true
            });
    }

    //defines the editor that is shown in job component column
    function jobcomponentMultiselectEditor(container, options) {

        $('<select id="jobcomponentms" class="jobcomponent" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: true,
                //placeholder: "Select job component...",
                dataTextField: "Description",
                dataValueField: "ID",

                filter: "contains",
                dataSource: { data: $scope.jobcomponents },
                valuePrimitive: true,
                change: function (e) {
                    var widget = e.sender;
                    if (widget.value() && widget.select() === -1) {
                        widget.value(""); //reset widget
                    }
                }
            });
    }

    $scope.clientsDataSource = function () {
        var ret = { data: $scope.clients };
        return ret;
    };

    //calculates totals (report header)
    function calculateTotals() {
        $scope.lessCreditCard = 0;
        $scope.totalDue = 0;
        $scope.totalExpenses = 0;

        //$scope.grid.dataSource.data()

        $scope.gridData.forEach(function (expense) {
            if (expense.PaymentType === 0 || expense.PaymentType === '0') {
                $scope.lessCreditCard += expense.Amount;
            }

            if (expense.PaymentType === 1 || expense.PaymentType === '1' || expense.PaymentType === 2 || expense.PaymentType === '2') {
                $scope.totalDue += expense.Amount;
            }

            $scope.totalExpenses += expense.Amount;
        });

        $scope.lessCreditCard = $scope.lessCreditCard.toFixed(2);
        $scope.totalDue = $scope.totalDue.toFixed(2);
        $scope.totalExpenses = $scope.totalExpenses.toFixed(2);
    }

    function getPageSize() {
        expService.getGridPageSize().then(result => {
            return result.data;           
        });
    }

    function calculateTotalsFromGrid() {
        $scope.lessCreditCard = 0;
        $scope.totalDue = 0;
        $scope.totalExpenses = 0;

        //$scope.grid.dataSource.data()

        //$scope.gridData.forEach(function (expense) {
        $scope.grid.dataSource.data().forEach(function (expense) {
            //if (expense.PaymentType.Value == 0 || expense.PaymentType.Value == '0') {
            //    $scope.lessCreditCard += expense.Amount;
            //}

            //if (expense.PaymentType.Value == 1 || expense.PaymentType.Value == '1' || expense.PaymentType.Value == 2 || expense.PaymentType.Value == '2') {
            //    $scope.totalDue += expense.Amount;
            //}
            if (expense.PaymentType === 0 || expense.PaymentType === '0') {
                $scope.lessCreditCard += expense.Amount;
            }

            if (expense.PaymentType === 1 || expense.PaymentType === '1' || expense.PaymentType === 2 || expense.PaymentType === '2') {
                $scope.totalDue += expense.Amount;
            }

            $scope.totalExpenses += expense.Amount;
        });
    }
    //hide cols



    //CRUD operations

    //handles "save" button click - report header
    $scope.saveClick = function () {
        var res = validateGrid();
        if (!res.result) {
            var alertstring = '';
            res.messages.forEach(function (row, index) {
                alertstring += row + '\n';
            });
            showKendoAlert(alertstring);            
            return false;
        }
        

        if ($scope.expenseReportHeader.InvoiceNumber == null || $scope.expenseReportHeader.InvoiceNumber === 0) {

            $scope.expenseReportHeader.CreatedDate = Date.now();
            $scope.expenseReportHeader.EmployeeCode = initEmployee.Code;     //"ama";
            $scope.expenseReportHeader.VendorCode = initEmployee.VendorCode; //"ama-ex";
            //delete $scope.expenseReportHeader.StatusCode;

            var newExpensrReport = [];
            newExpensrReport.push($scope.expenseReportHeader);

            prepareGridData();

            expService.createExpenseReports(newExpensrReport, $scope.newReportDetailsList).then(function (result) {

                $scope.expenseReportHeader = result.data[0];

                angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);

                //check if data is saved
                if ($scope.expenseReportHeader.InvoiceNumber != null && $scope.expenseReportHeader.InvoiceNumber != 0) {
                    //if saved add record details
                    var tmp = $scope.expenseReportHeader.CreatedDate.replace("/Date(", "").replace(")/", "");
                    $scope.expenseReportHeader.CreatedDate = new Date(parseInt(tmp));
                    
                    //add report details
                    //expService.createExpenseReportDetails($scope.newReportDetailsList, false).then(function (result) {

                        angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);
                        if (result) {
                            //get expense reports

                            $scope.refreshDetails();

                            //expService.getExpenseReportDetails($scope.expenseReportHeader.InvoiceNumber).then(function (details) {
                            //    $scope.expenseReportDetails = details.data;
                            //    $scope.gridData = prepereDataForGrid();
                            //    calculateTotals();

                            //    $scope.grid.setDataSource(getDataSource());
                            //    setTimeout(function () {
                            //        $scope.grid.dataSource.pageSize($scope.pagesize);
                            //        $scope.grid.dataSource.read(); $scope.grid.refresh();
                            //        $scope.hasDirtyRows = false;
                            //        $scope.selectedRow = [];
                            //        angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);
                            //        $scope.$apply();
                            //    }, 500);
                            //    $scope.hasDirtyRows = false;
                            //});

                            //refreshOnSave($scope.expenseReportHeader.InvoiceNumber, "TEEST");
                        }

                    //});
                }

            });

            dateChanged = false;

        }
        else {

            dateChanged = false;

            prepareGridData();
            //update header

            var updatedExpenseReports = [];

            updatedExpenseReports.push($scope.expenseReportHeader);

            var functionsAsync = [];

            functionsAsync.push(expService.updateExpenseReports(updatedExpenseReports));
            if ($scope.newReportDetailsList.length > 0) {
                functionsAsync.push(expService.createExpenseReportDetails($scope.newReportDetailsList, false));
            }
            if ($scope.updateReportDetailsList.length > 0) {
                functionsAsync.push(expService.updateExpenseReportDetails($scope.updateReportDetailsList));
            }


            $q.all(functionsAsync).then(function (response) {

                expService.getExpenseReportDetails($scope.expenseReportHeader.InvoiceNumber).then(function (details) {
                                        
                    var groupfields = $scope.grid.dataSource._group;
                   
                    angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);
                    $scope.expenseReportDetails = details.data;
                    $scope.gridData = prepereDataForGrid();
                    calculateTotals();

                    $scope.grid.setDataSource(getDataSource());
                    $scope.grid.dataSource.pageSize($scope.pagesize);
                    setTimeout(function () {
                        $scope.grid.dataSource.read();
                        $scope.grid.refresh();
                        $scope.hasDirtyRows = false;
                        $scope.selectedRow = [];
                        angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);
                        if ($scope.selectedViewMode === 3) {
                            $scope.jobGroupButton;
                            $scope.grid.dataSource.group(groupfields);
                        }
                        $scope.$apply();
                    }, 50);
                    $scope.hasDirtyRows = false;
                });

            }).catch(function (error) {

            });
        }
    };


    function funUpdateExpenseReportHeader(updatedExpenseReports) {
        return $q.when($http.post("UpdateExpenseReports", updatedExpenseReports));
    }

    function funAddNewExpenseReportDetails(newExpenseReportDetails) {
        return $q.when($http.post("CreateExpenseReportDetails", newExpenseReportDetails));
    }

    function funUpdateExoenseReportDetails(updateExpRep) {
        return $q.when($http.post("UpdateExpenseReportDetails", updateExpRep));
    }


    //prepare for create/update records in expense report
    function prepareGridData() {

        $scope.newReportDetailsList = [];
        $scope.updateReportDetailsList = [];

        $scope.grid.dataSource.data().forEach(function (row, index) {

            var record = {};
            if (row.Id != 0 && row.Id != null) {
                record.ID = row.Id;

                var findRecord = $scope.expenseReportDetails.filter((value, index, self) => (value.ID == row.Id));
                if (findRecord.length > 0) {
                    angular.copy(findRecord[0], record);
                }
            }
            else {
                record.ID = null;
            }

            record.InvoiceNumber = $scope.expenseReportHeader.InvoiceNumber;
            record.ItemDate = row.Date;
            record.Description = row.Description;
            record.FunctionCode = row.Function;
            record.Quantity = row.Quantity;
            record.Rate = row.Rate;
            record.Amount = row.Amount;

            record.PaymentType = row.PaymentType;

            if (row.Job != null && row.Job != '' && row.Job && row.Component != null && row.Component != '') {

                record.JobNumber = row.Job;
                record.JobComponentNumber = row.Component;

                var findData = $scope.allJobs.filter((value, index, self) => (value.Number == row.Job));
                if (row.Client == '' || row.Client == null) {
                    if (findData.length > 0) { record.ClientCode = findData[0].ClientCode; }
                }
                else {
                    record.ClientCode = row.Client;
                }

                if (row.Division == '' || row.Division == null) {
                    if (findData.length > 0) { record.DivisionCode = findData[0].DivisionCode; }
                }
                else {
                    record.DivisionCode = row.Division;
                }

                if (row.Product == '' || row.Product == null) {
                    if (findData.length > 0) { record.ProductCode = findData[0].ProductCode; }
                }
                else {
                    record.ProductCode = row.Product;
                }
            }
            else {
                //clean jobs

                if (row.Job == '' || row.Job == null) {

                    record.JobNumber = null;
                    record.JobComponentNumber = null;
                    record.ClientCode = null;
                    record.DivisionCode = null;
                    record.ProductCode = null;
                }
            }

            if (record.ID == null) {
                $scope.newReportDetailsList.push(record);
                $scope.newExpenseReportDetailsList.push(record);
            }
            else {
                if (row.dirty) {
                    $scope.updateReportDetailsList.push(record);
                }
            }
        });
    }


    //adjusts data for grid representation
    function prepereDataForGrid() {
        $scope.reportHasRowImages = false;
        var gridData = [];

        $scope.expenseReportDetails.forEach(function (row) {
            var item = {
                Id: row.ID,
                Date: row.ItemDate,
                Description: row.Description,
                Function: row.FunctionCode,
                Quantity: row.Quantity,
                Rate: row.Rate,
                Amount: row.Amount,
                Client: row.ClientCode,
                Division: row.DivisionCode,
                Product: row.ProductCode,
                Job: row.JobNumber,
                Component: row.JobComponentNumber,
                PaymentType: row.PaymentType,
                Receipts: [],
                Uploader: null,
                ShowAllUploadedImages: true,
                CreatedBy: row.CreatedBy,
                IsImported: row.IsImported,
                JobComponent: row.JobComponent
            };

            if (item.Client === null) { item.Client = ''; }
            if (item.Division === null) { item.Division = ''; }
            if (item.Product === null) { item.Product = ''; }
            if (item.Job === null) { item.Job = ''; }
            if (item.Component === null) { item.Component = ''; }
            if (item.PaymentType === null) { item.PaymentType = ''; }

            $scope.uploadedImages.forEach((image) => {

                image.Rows.forEach((row) => {

                    if (row === item.Id) {

                        var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                        image.url = url;

                        var extension = image.Mimetype.replace('image/', '');
                        if (extension.toLowerCase() == 'jpeg') { extension = "jpg"; }
                        image.extension = extension.toUpperCase();


                        if (image.Filename.toLowerCase().endsWith('.csv')) {

                            image.extension = 'CSV';
                            image.ThumbnailData = '../../Images/document_excel.png';

                        }

                        if (image.Filename.toLowerCase().endsWith('.doc')) {
                            image.extension = 'DOC';
                            image.ThumbnailData = '../../Images/document_word.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.docx')) {
                            image.extension = 'DOCX';
                            image.ThumbnailData = '../../Images/document_word.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.pdf')) {
                            image.extension = 'PDF';
                            image.ThumbnailData = '../../Images/document_pdf.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.ppt')) {
                            image.extension = 'PPT';
                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.pptx')) {
                            image.extension = 'PPTX';
                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.txt')) {
                            image.extension = 'TXT';
                            image.ThumbnailData = '../../Images/document_text.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.xls')) {
                            image.extension = 'XLS';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                            image.extension = 'XLSX';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.zip')) {
                            image.extension = 'ZIP';
                            image.ThumbnailData = '../../Images/document_zip.png';
                        }

                        item.Receipts.push(image);
                        $scope.reportHasRowImages = true;
                    }
                });
            });

            //change payment type that is eliminated
            if (item.PaymentType === 2) { item.PaymentType = 1; }

            gridData.push(item);
        });

        if ($scope.expenseReportHeader.InvoiceNumber == 0 && $scope.importrows.length > 0) {

            $scope.newExpenseReportDetailsList.forEach(function (row) {
                var item = {
                    Id: row.ID,
                    Date: row.ItemDate,
                    Description: row.Description,
                    Function: row.FunctionCode,
                    Quantity: row.Quantity,
                    Rate: row.Rate,
                    Amount: row.Amount,
                    Client: row.ClientCode,
                    Division: row.DivisionCode,
                    Product: row.ProductCode,
                    Job: row.JobNumber,
                    Component: row.JobComponentNumber,
                    PaymentType: row.PaymentType,
                    Receipts: [],
                    Uploader: null,
                    ShowAllUploadedImages: true,
                    CreatedBy: row.CreatedBy,
                    IsImported: row.IsImported,
                    JobComponent: row.JobComponent
                };

                if (item.Client === null) { item.Client = ''; }
                if (item.Division === null) { item.Division = ''; }
                if (item.Product === null) { item.Product = ''; }
                if (item.Job === null) { item.Job = ''; }
                if (item.Component === null) { item.Component = ''; }
                if (item.PaymentType === null) { item.PaymentType = ''; }

                //change payment type that is eliminated
                if (item.PaymentType === 2) { item.PaymentType = 1; }

                gridData.push(item);
            });

            $scope.importrows.forEach(function (row) {
                var item = {
                    Id: row.ID,
                    Date: row.ItemDate,
                    Description: row.Description,
                    Function: row.FunctionCode,
                    Quantity: row.Quantity,
                    Rate: row.Rate,
                    Amount: row.Amount,
                    Client: row.ClientCode,
                    Division: row.DivisionCode,
                    Product: row.ProductCode,
                    Job: row.JobNumber,
                    Component: row.JobComponentNumber,
                    PaymentType: row.PaymentType,
                    Receipts: [],
                    Uploader: null,
                    ShowAllUploadedImages: true,
                    CreatedBy: row.CreatedBy,
                    IsImported: row.IsImported,
                    JobComponent: row.JobComponent
                };

                if (item.Client === null) { item.Client = ''; }
                if (item.Division === null) { item.Division = ''; }
                if (item.Product === null) { item.Product = ''; }
                if (item.Job === null) { item.Job = ''; }
                if (item.Component === null) { item.Component = ''; }
                if (item.PaymentType === null) { item.PaymentType = ''; }                

                //change payment type that is eliminated
                if (item.PaymentType === 2) { item.PaymentType = 1; }

                gridData.push(item);
            });
        }

        if ($scope.grid != null && $scope.grid != 'undefined') {
            $scope.grid.refresh();
            resizeGrid();
            $scope.grid.refresh();

            setTimeout(function () {
                $("#descriptionField").focus();
            }, 750);
        }

        return gridData;
    }

    //creates data source object for reprt details
    function getDataSource() {

        //console.log($scope.pagesize);
        var dataSource = {
            data: $scope.gridData,
            batch: false,
            schema: baseSchema
        };

        return dataSource;
    }

    //validates entered data in the grid
    function validateGrid() {
        var valObject = { result: true, messages: [] };
        var messages = [];

        $scope.grid.dataSource.data().forEach(function (row, index) {

            if (row.Date == null || row.Date === '') {
                messages.push('Error at row ' + (index + 1) + ': Date field is required');
            }
            else {
                var r = Date.parse(row.Date).toString();
                if (isNaN(r)) { messages.push('Error at row ' + (index + 1) + ': Invalid date format.'); }
            }

            if (row.Description == null || row.Description === '') {
                messages.push('Error at row ' + (index + 1) + ': Description field is required');
            }
            if (row.Amount == null || row.Amount === '') {
                messages.push('Error at row ' + (index + 1) + ': Amount field is required');
            }
            else {
                if (row.Amount === 0) { messages.push('Error at row ' + (index + 1) + ': Amount field is required.'); };
            }

            if (row.Function == null || row.Function === '') {
                messages.push('Error at row ' + (index + 1) + ': Function field is required');
            }
            else {
                var found = false;
                $scope.functionCodes.forEach(function (fc) {
                    if (fc.Code == row.Function) {
                        found = true;
                    }
                });
                if (found == false) { messages.push('Error at row ' + (index + 1) + ': Function field is required'); }
            }

            if (row.PaymentType === null || row.PaymentType === '') {
                messages.push('Error at row ' + (index + 1) + ': Payment type field is required');
            }
            else {
                var found = false;
                $scope.paymentTypes.forEach(function (pt) {
                    if (row.PaymentType == pt.Value) {
                        found = true;
                    }
                });
                if (found == false) { messages.push('Error at row ' + (index + 1) + ': Payment type field is required'); }
            }

            if (row.Job != null && row.Job != '') {
                if (row.Component == '' || row.Component == null) {
                    messages.push('Error at row ' + (index + 1) + ': Job component is required when job is selected.');
                }
            }
        });

        if (messages.length > 0) {
            valObject.result = false;
            valObject.messages = messages;
        }

        return valObject;
    }

    //top menu other functions

    //handles "bookmark" button click - report header
    $scope.bookmarkClick = function () {
        expService.addInvoiceBookmark(initEmployee.Code, $scope.expenseReportHeader.InvoiceNumber, $scope.expenseReportHeader.Description).then(function (result) {

        });
    };

    //handles "submit report" button click - report header
    $scope.submitClick = function () {

        expService.submitExpenseReport($scope.expenseReportHeader.InvoiceNumber, $scope.expenseReportHeader.EmployeeCode).then(function (result) {
            if (result.data === 'submit_options') {

                var URL = "";
                URL = window.appBase + "Employee/ExpenseReports/ExpenseReportSubmit?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber;
                $("#expenseSubmitOptionsDialog").ejDialog("destroy");
                $("#expenseSubmitOptionsDialog").ejDialog({
                    contentUrl: URL,
                    title: "Submit Expense Report Options",
                    showOnInit: false,
                    contentType: "iframe",
                    height: "400px",
                    width: "450px",
                    showFooter: false,
                    enableModal: true,
                    backgroundScroll: false,
                    enableResize: false
                });
                $("#expenseSubmitOptionsDialog").ejDialog("open");
                $("#expenseSubmitOptionsDialog").ejDialog("refresh");
            }
            else if (result.data !== 'ok') {
                showKendoAlert(result.data);
            }
            else if (result.data === 'ok') {               

                if (window.location.href.includes("invoice=new") === true) {
                    refreshOnSave($scope.expenseReportHeader.InvoiceNumber, "");
                } else {
                    window.location.href = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + $scope.expenseReportHeader.InvoiceNumber;
                }
                
            }
        });
    };

    $scope.submitOptionsClick = function () {

    };

    //handles "unsubmit report" button click - report header
    $scope.unSubmitClick = function () {
        expService.unSubmitExpenseReport($scope.expenseReportHeader.InvoiceNumber).then(function (result) {
            window.location.href = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + $scope.expenseReportHeader.InvoiceNumber;
        });
    };

    //handles "copy report" button click - report header
    $scope.copyClick = function () {
        var URL = "";
        URL = window.appBase + "Employee/ExpenseReports/ExpenseReportCopy?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber;

        $("#expenseReportCopyDialog").ejDialog("destroy");
        $("#expenseReportCopyDialog").ejDialog({
            contentUrl: URL,
            title: "Copy Expense Report",
            showOnInit: false,
            contentType: "iframe",
            height: "375px",
            width: "550px",
            showFooter: false,
            enableModal: true,
            backgroundScroll: false,
            enableResize: false
        });
        $("#expenseReportCopyDialog").ejDialog("open");
        $("#expenseReportCopyDialog").ejDialog("refresh");
    };

    //handles "delete report" button click - report header
    $scope.deleteReportClick = function () {

        showKendoConfirm("Are you sure you want to delete this report (you can\'t undo this operation)?")
            .done(function () {
                if ($scope.expenseReportHeader.InvoiceNumber != null) {
                    var newExpensrReport = [];
                    newExpensrReport.push($scope.expenseReportHeader);

                    expService.deleteExpenseReports(newExpensrReport).then(function (result) {
                        if (result.data === true) {
                            $scope.expenseReportHeader = {
                                "ApprovedBy": null, "ApprovedDate": null, "ApproverNotes": null, "BatchDate": null, "CreatedBy": null,
                                "CreatedDate": null, "DateFrom": null, "DateTo": null, "Description": null, "Details": null, "EmployeeCode": null, "EmployeeName": null,
                                "InvoiceAmount": null, "InvoiceDate": null, "InvoiceNumber": 0, "IsApproved": null, "IsSubmitted": null, "ModifiedBy": null,
                                "ModifiedDate": null, "Status": null, "StatusCode": "", "SubmittedTo": null, "VendorCode": null, "TotalNonBillable": null,
                                "TotalBillable": null, "TotalAmount": null, "Paid": false, "ExpenseReportDetails": null
                            };

                            angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);
                            $scope.expenseReportDetails = [];

                            $scope.gridData = prepereDataForGrid();
                            calculateTotals();

                            //$scope.grid.dataSource.data = ;
                            $scope.grid.setDataSource(getDataSource());
                            setTimeout(function () { $scope.grid.dataSource.pageSize($scope.pagesize); $scope.grid.dataSource.read(); $scope.grid.refresh(); $scope.hasDirtyRows = false; }, 500);
                            $scope.hasDirtyRows = false;

                            RefreshWindow("modules/employee/expense-reports/expense-search-two", false, false);                           
                        }
                    });
                }
                setTimeout(function () { CloseWindow(); }, 300);
            })
            .fail(function () {
            });
    };

    //handles "change column visibility" event
    $scope.$watch('columnSettings', function (newValue, oldValue) {
        //console.log(newValue, oldValue);
        if (newValue.quantity !== oldValue.quantity) {
            if (newValue.quantity) {
                $scope.grid.showColumn("Quantity");
                $scope.grid.showColumn("Rate");
                $scope.rate = true;
                newValue.rate = true;
            }
            else {
                $scope.grid.hideColumn("Quantity");
                $scope.grid.hideColumn("Rate");
                $scope.rate = false;
                newValue.rate = false;
            }
        }

        if (newValue.client !== oldValue.client) {
            if (newValue.client) { $scope.grid.showColumn("Client"); }
            else {
                $scope.grid.hideColumn("Client");
                $scope.division = false; newValue.division = false;
                $scope.product = false; newValue.product = false;
            }
        }

        if (newValue.division !== oldValue.division) {
            if (newValue.division) {
                $scope.grid.showColumn("Division"); $scope.client = true; newValue.client = true;
            }
            else {
                $scope.grid.hideColumn("Division"); $scope.product = false; newValue.product = false;
            }
        }

        if (newValue.product !== oldValue.product) {
            if (newValue.product) {
                $scope.grid.showColumn("Product");
                $scope.division = true; newValue.division = true;
                $scope.client = true; newValue.client = true;
            }
            else {
                $scope.grid.hideColumn("Product");
            }
        }

        if (newValue.job !== oldValue.job) {
            if (newValue.job) {
                $scope.grid.showColumn("Job");
                $scope.jobComponent = true;
                newValue.jobComponent = true;
            }
            else {
                $scope.grid.hideColumn("Job");
                $scope.jobComponent = false;
                newValue.jobComponent = false;
            }
        }

        if (newValue.jobComponent !== oldValue.jobComponent) {
            if (newValue.jobComponent) {
                $scope.grid.showColumn("JobComponent");
                $scope.job = true;
                newValue.job = true;
            }
            else {
                $scope.grid.hideColumn("JobComponent");
                $scope.job = false;
                newValue.job = false;
            }
        }
    }, true);

    //handles "refresh report" button click - report header
    $scope.refreshClick = function () {

        var invoice = $scope.expenseReportHeader.InvoiceNumber;

        if (invoice === null || invoice === '') { return; }

        expService.getExpenseReport(invoice).then(function (result) {
            $scope.expenseReportHeader = result.data;

            if ($scope.expenseReportHeader.CreatedDate) {
                var tmp = $scope.expenseReportHeader.CreatedDate.replace("/Date(", "").replace(")/", "");
                $scope.expenseReportHeader.CreatedDate = new Date(parseInt(tmp));
            }

            angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);

            expService.getReceiptsList($scope.expenseReportHeader.InvoiceNumber).then(result => {

                $scope.uploadedImages = result.data;
                $scope.receiptsCount = result.data.length;
                if (result.data.length === 0) {
                    $scope.HasDocuments = 0;
                }
                if (result.data.length > 0) {
                    $scope.HasDocuments = 1;
                }

             });

            expService.getExpenseReportDetails(invoice).then(function (resDetails) {

                $scope.hasDirtyRows = false;
                $scope.expenseReportDetails = resDetails.data;
                $scope.gridData = prepereDataForGrid();
                calculateTotals();

                //$scope.grid.dataSource.data = ;
                $scope.grid.setDataSource(getDataSource());
                $scope.grid.dataSource.pageSize($scope.pagesize);
                setTimeout(function () {
                    $scope.grid.dataSource.read();
                    $scope.grid.refresh();
                    resizeGrid();
                    $scope.hasDirtyRows = false;
                    $scope.selectedRow = [];
                    $scope.$apply();
                }, 50);
                $scope.checkDirtyRows();
                $scope.selectedRow = [];
            });

        });
    };

    $scope.refreshGrid = function () {
        var invoice = $scope.expenseReportHeader.InvoiceNumber;
        if (invoice === null || invoice === '') { return; }
        expService.getExpenseReportDetails(invoice).then(function (resDetails) {
            $scope.hasDirtyRows = false;
            $scope.expenseReportDetails = resDetails.data;
            $scope.gridData = prepereDataForGrid();
            calculateTotals();
            $scope.grid.setDataSource(getDataSource());
            setTimeout(function () {
                $scope.grid.dataSource.pageSize($scope.pagesize);
                $scope.grid.dataSource.read(); $scope.grid.refresh();
                $scope.hasDirtyRows = false;
                $scope.selectedRow = [];
                $scope.$apply();
            }, 50);
            $scope.checkDirtyRows();
            $scope.selectedRow = [];
        });
    };
    $scope.refreshGridonNew = function () {
        var invoice = $scope.expenseReportHeader.InvoiceNumber;
        if (invoice === null || invoice === '') { return; }
        expService.getExpenseReportDetails(invoice).then(function (resDetails) {
            $scope.hasDirtyRows = false;
            $scope.expenseReportDetails = resDetails.data;
            $scope.gridData = prepereDataForGrid();
            calculateTotals();
            $scope.grid.setDataSource(getDataSource());
            setTimeout(function () {
                $scope.grid.dataSource.pageSize($scope.pagesize);
                $scope.grid.dataSource.read(); $scope.grid.refresh();
               // $scope.hasDirtyRows = false;
                $scope.selectedRow = [];
                $scope.$apply();
            }, 50);
            $scope.checkDirtyRows();
            $scope.selectedRow = [];
        });
    };

    //handles "print report" button click - report header
    $scope.openPrintSettingsPage = function () {
        var URL = "";
        URL = window.appBase + "Employee/ExpenseReports/ExpenseReportPrint?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber;
        $("#expenseReportPrintOptDialog").ejDialog("destroy");
        $("#expenseReportPrintOptDialog").ejDialog({
            contentUrl: URL,
            title: "Print Expense Report",
            showOnInit: false,
            contentType: "iframe",
            height: "375px",
            width: "450px",
            showFooter: false,
            enableModal: true,
            backgroundScroll: false,
            enableResize: false
        });
        $("#expenseReportPrintOptDialog").ejDialog("open");
        $("#expenseReportPrintOptDialog").ejDialog("refresh");
    };

    //handles "import data" button click - report header
    $scope.importExpensesClick = function () {
        prepareGridData();
        if ($scope.expenseReportHeader.InvoiceNumber !== 0 && $scope.expenseReportHeader.InvoiceNumber !== null && $scope.expenseReportHeader.InvoiceNumber !== '') {
            var saved = $scope.saveClick();

            if (saved === false) {
                return;
            }
        }
       
        var URL = "";
        if ($scope.expenseReportHeader.EmployeeCode === null) {
            URL = window.appBase + "Employee/ExpenseReports/ExpenseReportImport?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber + '&empcode=' + initEmployee.Code;
        } else {
            URL = window.appBase + "Employee/ExpenseReports/ExpenseReportImport?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber + '&empcode=' + $scope.expenseReportHeader.EmployeeCode;
        }        

        $("#expenseReportImportDialog").ejDialog("destroy");
        $("#expenseReportImportDialog").ejDialog({
            contentUrl: URL,
            title: "Import",
            showOnInit: false,
            contentType: "iframe",
            height: "90%",
            width: "90%",
            showFooter: false,
            enableModal: true,
            backgroundScroll: false,
            enableResize: true,
            enableAutoResize: true,
            close: (e) => {
                var grid = $('#ExpenseReportsGrid').data('kendoGrid');

                grid.dataSource.read();
            }
        });
        $("#expenseReportImportDialog").ejDialog("refresh");
        $("#expenseReportImportDialog").ejDialog("open");

        //$('#importwindow').kendoWindow({
        //    animation: {
        //        open: {
        //            duration: 1
        //        },
        //        close: {
        //            duration: 1
        //        }
        //    },
        //    width: "90%",
        //    height: "90%",
        //    title: "Import",
        //    modal: true,
        //    visible: false,
        //    content: URL,
        //    resizable: true,
        //    position: top,
        //    iframe: true          
        //}).data("kendoWindow");

        //$("#importwindow").kendoWindow("open");
        //$("#importwindow").kendoWindow("center");
        //$("#importwindow").kendoWindow("refresh");

    };

    //handles "upload receipts" button click - report header
    $scope.uploadReceiptsClick = function () {

        var saved = $scope.saveClick();

        if (saved === false) {
            return;
        }

        var URL = "";

        if ($scope.expenseReportHeader.Status === null) {
            URL = window.appBase + "Employee/ExpenseReports/UploadReceipts?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber + '&empcode=' + $scope.expenseReportHeader.EmployeeCode + '&status=0';
        } else {
            URL = window.appBase + "Employee/ExpenseReports/UploadReceipts?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber + '&empcode=' + $scope.expenseReportHeader.EmployeeCode + '&status=' + $scope.expenseReportHeader.Status;
        }        
                
        let windowTitle = 'Manage Receipts';

        //OpenRadWindow(windowTitle, URL, 770, 1510, false, closeUploadModalAndRefresh2($scope.expenseReportHeader.InvoiceNumber));

        $("#uploadReceiptsDialog").ejDialog("destroy");
        $("#uploadReceiptsDialog").ejDialog({
            contentUrl: URL,
            title: "Manage Receipts",
            showOnInit: false,
            contentType: "iframe",
            height: "90%",
            width: "90%",
            showFooter: false,
            enableModal: true,
            allowDraggable: true,
            backgroundScroll: false,
            enableResize: true, 
            enableAutoResize: true,
            close: function (args) {
                closeUploadModalAndRefresh($scope.expenseReportHeader.InvoiceNumber);
            }
        });
        $("#uploadReceiptsDialog").ejDialog("open");
        $("#uploadReceiptsDialog").ejDialog("refresh");

        //$("#uploadwindow").ejDialog({
        //    title: "Manage Receipts",
        //    showOnInit: false,
        //    height: "90%",
        //    width: "90%",
        //    showFooter: false,
        //    enableModal: true,
        //    allowDraggable: true,
        //    backgroundScroll: false,
        //    enableResize: false,
        //    enableAutoResize: true,
        //    close: function (args) {
        //        closeUploadModalAndRefresh($scope.expenseReportHeader.InvoiceNumber);
        //    }
        //});

        //$("#uploadwindow").ejDialog("open");


        //$('#uploadwindow').kendoWindow({
        //    animation: {
        //        open: {
        //            duration: 1
        //        },
        //        close: {
        //            duration: 1
        //        }
        //    },
        //    width: "90%",
        //    height: "90%",
        //    title: "Manage Receipts",
        //    modal: true,
        //    visible: false,
        //    content: URL,
        //    resizable: true,
        //    iframe: true,
        //    close: function (args) {                
        //        $("#uploadwindow").html("");
        //        closeUploadModalAndRefresh($scope.expenseReportHeader.InvoiceNumber);
        //    }           
        //}).data("kendoWindow");

        //$('.k-widget.k-window .k-window-titlebar').css({
        //    'background-color': 'white',
        //    'border-bottom': '#2196f3 3px solid'
        //});

        //$("#uploadwindow").kendoWindow("open");
        //$("#uploadwindow").kendoWindow("center");
        //$("#uploadwindow").kendoWindow("refresh");
    };

    //handles "receipts viewer" button click - report header
    $scope.receiptsClick = function () {
        var URL = "";
        URL = window.appBase + "Employee/ExpenseReports/ExpenseReportReceipts?InvoiceNumber=" + $scope.expenseReportHeader.InvoiceNumber + '&empcode=' + $scope.expenseReportHeader.EmployeeCode;

        $("#receiptsDialog").ejDialog("destroy");
        $("#receiptsDialog").ejDialog({
            contentUrl: URL,
            title: "Advantage Receipts",
            showOnInit: false,
            contentType: "iframe",
            height: "90%",
            width: "90%",
            showFooter: false,
            enableModal: true,
            backgroundScroll: false,
            enableResize: false
        });
        $("#receiptsDialog").ejDialog("open");
        $("#receiptsDialog").ejDialog("refresh");
    };

    //generates css class based on report status
    $scope.getERStatusCssClass = function () {

        if ($scope.expenseReportHeader.StatusCode === '' || $scope.expenseReportHeader.StatusCode === "Open") {
            return "wv-save";
        }
        else if ($scope.expenseReportHeader.Status == '1' || $scope.expenseReportHeader.Status == '3' || $scope.expenseReportHeader.Status == '7') {
            return "wv-warning";
        }
        else if ($scope.expenseReportHeader.Status == '4' || $scope.expenseReportHeader.Status == '8') {
            return "wv-danger";
        }
        else if ($scope.expenseReportHeader.Status == '2' || $scope.expenseReportHeader.Status == '5' || $scope.expenseReportHeader.Status == '6') {
            return "wv-success";
        }

        return '';
    };

    $scope.splitCamelCase = function (s) {
        return s.split(/(?=[A-Z])/).join(' ');
    };
     
    //checks if save button should be available
    $scope.saveAvailable = function () {
        if ($scope.CanUpdate === false && $scope.expenseReportHeader.InvoiceNumber > 0) {
            return false;
        }

        if ($scope.expenseReportHeader.InvoiceDate === '' || $scope.expenseReportHeader.InvoiceDate === null ||
            $scope.expenseReportHeader.Description === '' || $scope.expenseReportHeader.Description === null) {
            return false;
        }

        if ($scope.expenseReportHeader.Status !== "" && $scope.expenseReportHeader.Status !== null) {
            if (parseInt($scope.expenseReportHeader.Status) >= 1) {
                return false;
            }
        }

        if (!$scope.cancelAvailable() && !$scope.hasDirtyRows) {
            return false;
        }
        return true;
    };

    $scope.saveAvailableOnChange = function (isNew, hasChanged) {
        if (!isNew) {
            if ($scope.saveAvailable() && hasChanged) {
                return true;
            }
        }

        return false;
    };

    //checks if report is saved
    $scope.savedRepot = function (button) {
        if (button === 'copy') {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            } else if ($scope.CanAdd === false) {
                return false;
            }
            else {
                return true;
            }
        } else if (button === 'delete') {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            } else if ($scope.CanUpdate === false) {
                return false;
            }
            else {
                return true;
            }
        } else if (button === 'print') {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            } else if ($scope.CanPrint === false) {
                return false;
            }
            else {
                return true;
            }
        } else if (button === 'submit') {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            } else if ($scope.CanUpdate === false) {
                return false;
            }
            else {
                return true;
            }
        } else if (button === 'import') {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            } else if ($scope.CanUpdate === false) {
                return false;
            }
            else {
                return true;
            }
        } else if (button === 'manage') {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            } 
            else {
                return true;
            }
        } else if (button === 'bookmark') {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            }
            else {
                return true;
            }
        } else {
            if ($scope.expenseReportHeader.InvoiceNumber === 0 || $scope.expenseReportHeader.InvoiceNumber === null || $scope.expenseReportHeader.InvoiceNumber === '') {
                return false;
            } 
            else {
                return true;
            }
        }
    };

    //counts uploaded images
    $scope.uploadedImagesCount = function () {

        if ($scope.expenseReportHeader.InvoiceNumber == 0 || $scope.expenseReportHeader.InvoiceNumber == null || $scope.expenseReportHeader.InvoiceNumber == '') {
            return false;
        }
        else {
            if (parseInt($scope.uploadedImages.length) > 0) {

                return true;
            }
        }
        return false;
    };

    //checks if report is approved
    $scope.approvedReport = function () {

        if ($scope.expenseReportHeader.Status !== "" && $scope.expenseReportHeader.Status !== null) {
            if (parseInt($scope.expenseReportHeader.Status) >= 1) {
                return true;
            }
        }

        if ($scope.CanUpdate === false && $scope.expenseReportHeader.InvoiceNumber > 0) {
            return true;
        }        
        return false;
    };

    
    //new or not
    $scope.isNew = function () {

        if ($scope.expenseReportHeader.InvoiceNumber == 0 || $scope.expenseReportHeader.InvoiceNumber == null || $scope.expenseReportHeader.InvoiceNumber == '' || $scope.expenseReportHeader.Description == '') {
            return true;
        }
        else {
            if ($scope.CanAdd === false) {

                return true;

            } else {

                return false;

            }
        }
    };

    angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);

    //checks if cancel button should be available
    $scope.cancelAvailable = function () {

        if (dateChanged) {
            return true;
        }

        if ($scope.expenseReportHeader.InvoiceDate === '' || $scope.expenseReportHeader.InvoiceDate === null ||
            $scope.expenseReportHeader.Description === '' || $scope.expenseReportHeader.Description === null) {

            return false;
        }

        if ($scope.grid.dataSource.data().length == 0) {

            return false;
        }

        if ($scope.expenseReportHeader.Status != "" && $scope.expenseReportHeader.Status != null) {
            if (parseInt($scope.expenseReportHeader.Status) >= 1) {

                return false;
            }
        }

        if (!$scope.hasDirtyRows) {
            return false;
        }
        return true;
    };

    //handles "cancel changes" button click - report header
    $scope.cancelHeaderClick = function () {
        
        showKendoConfirm("Are you sure you want to cancel all unsaved changes on this expense report? You cannot undo this operation.")
            .done(function () {

                var invoice = $scope.expenseReportHeader.InvoiceNumber;

                if (invoice === null || invoice === '') { return; }

                expService.getExpenseReport(invoice).then(function (result) {
                    $scope.expenseReportHeader = result.data;

                    if ($scope.expenseReportHeader.CreatedDate) {
                        var tmp = $scope.expenseReportHeader.CreatedDate.replace("/Date(", "").replace(")/", "");
                        $scope.expenseReportHeader.CreatedDate = new Date(parseInt(tmp));
                    }

                    angular.copy($scope.expenseReportHeader, $scope.lastHeaderData);

                });

                $scope.refreshDetails();

                dateChanged = false;
                //if ($scope.expenseReportHeader.InvoiceNumber == 0 || $scope.expenseReportHeader.InvoiceNumber == null || $scope.expenseReportHeader.InvoiceNumber == '' || $scope.expenseReportHeader.Description == '') {

                //    if ($scope.expenseReportHeader.EmployeeCode === null) {
                //        URL = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=" + initEmployee.Code;
                //    } else {
                //        URL = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=" + $scope.expenseReportHeader.EmployeeCode;
                //    }                   

                //} else {

                //    URL = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + $scope.expenseReportHeader.InvoiceNumber + '&empcode=' + $scope.expenseReportHeader.EmployeeCode;

                //}

                //window.location.href = URL;
            })
            .fail(function () {
            });       
    };

    //checks if there are any selected rows
    $scope.reportDetailsSelectedRow = function () {

        var custom2count = 0;

        if ($scope.selectedRow.length > 0) {

            $scope.selectedRow.forEach(function (item) {
                if ($scope.Custom2 === true && item.IsImported === true && item.CreatedBy !== $scope.UserCode) {
                    custom2count += 1;
                } 
            });

            if (custom2count > 0) {
                return false;
            } else {
                return true;
            }
            
            
        }

        return false;
    };

    $scope.selectedViewGroup = function () {

        if ($scope.selectedViewMode === 3 || $scope.selectedViewMode === 4) {
            return true;
        } 

        return false;
    };

    $scope.hasDirtyRows = false;

    //checks if there is new data in the grid
    $scope.checkDirtyRows = function () {
        var stopFlag = false;

        $scope.grid.dataSource.data().forEach(function (row, index) {
            if (row.dirty || (row.Id != null && row.Id != 0)) { $scope.hasDirtyRows = true; stopFlag = true; }
        });

        if (stopFlag) { return; }

        $scope.hasDirtyRows = false;

        return true;
    };

    //displys job description based on  job code value
    $scope.getJobDescription = function (client, division, product) {
        var tmp = client;
        if (division != client) { tmp += '/' + division; }
        if (product != division) { tmp += '/' + product; }
        return '(' + tmp + ')';
    };

    $scope.createUpdateClickNone1 = function () {
        var grid = $('#mainGridOptions').data('kendoGrid');

        var selectedRow = grid.dataItem(grid.select());

        var number = selectedRow.Id;

        var uploadDocumentNumber = [{ FileName: "Example", MIMEType: "image/png", "FileSize": 212, Description: "new", Keywords: "keywords", private_flag: 0, type: 2 }];

        expService.uploadReceiptTempdata(number);
        expService.uploadReceipt(uploadDocumentNumber);
    };

    $(function () {
        var template = kendo.template($("#template1").html());
        var initialFiles = [];

        _scope = $scope;

        $("#products").html(kendo.render(template, initialFiles));

        $("#AsyncDocuments").kendoUpload({
            async: {
                saveUrl: "UploadReceipts",
                removeUrl: "remove",
                autoUpload: false
            },
            validation: {
                allowedExtensions: [".jpg", ".jpeg", ".png", ".bmp", ".gif"]
            },
            localization: {
                select: "Select receipts",
                uploadSelectedFiles: "Add"
            },
            success: onSuccess,
            showFileList: false,
            dropZone: ".dropZoneElement",
            upload: onUpload,
            error: function (e) {
                var err = $.parseJSON(e.XMLHttpRequest.responseText);

                showKendoAlert(err.Message);

                $.map(e.files, function (file) {
                    showKendoAlert("Could not upload " + file.name);
                });
            }
        });        

        function onUpload(e) {
            var row = e.sender.element[0].attributes['rowid'].value;

            e.data =
                {
                    InvoiceNumber: $scope.expenseReportHeader.InvoiceNumber,
                    ExpenseDetailID: parseInt(row)
                };
        }

        function onSuccess(e) {
            if (e.operation === "upload") {                

                expService.getReceiptsList($scope.expenseReportHeader.InvoiceNumber).then(result => {

                    $scope.uploadedImages = result.data;

                    $scope.gridData = prepereDataForGrid();
                    calculateTotals();

                    $scope.grid.setDataSource(getDataSource());
                    setTimeout(function () { $scope.grid.dataSource.pageSize($scope.pagesize); $scope.grid.dataSource.read(); $scope.grid.refresh(); resizeGrid(); $scope.hasDirtyRows = false; }, 500);
                    $scope.hasDirtyRows = false;

                });
            }
        }

        $scope.createUpdateClick = function () {
            var grid = $('#mainGridOptions').data('kendoGrid');

            var selectedRow = grid.dataItem(grid.select());
            var uploadDocumentNumber = [];
            var number = selectedRow.Id;
            $('.tableUpdate tr').each(function (a, b) {
                var fileName = $('.FileName input', b).val();
                var fileSize = $('.FileSize input', b).val();
                var keywords = $('.Keywords input', b).val();
                var description = $('.Description input', b).val();
                var filetype = $('.Filetype input', b).val();

                uploadDocumentNumber.push({ FileName: fileName, MIMEType: filetype, FileSize: fileSize, Description: "Descr", Keywords: "Something", private_flag: 0, type: 2 });

                expService.uploadReceiptTempdata(number);
                expService.uploadReceipt(uploadDocumentNumber);

            });

            //alert("You are here");
        };   
    });

    $(window).on("resize", function () {
        $("#chart-container-functionchart svg").width(Number($('.ExpenseReportsGrid').width()));
        $("#chart-container-functionchart svg").height(Number($('.ExpenseReportsGrid').height()));
        $("#chart-container-jobchart svg").width(Number($('.ExpenseReportsGrid').width()));
        $("#chart-container-jobchart svg").height(Number($('.ExpenseReportsGrid').height()));
        if ($("#chart-container-functionchart").data("kendoChart")) {
            $("#chart-container-functionchart").data("kendoChart").refresh();
        }
        if ($("#chart-container-jobchart").data("kendoChart")) {
            $("#chart-container-jobchart").data("kendoChart").refresh();
        }

    }); 

    //test
    $scope.getGridDataJson = function () {
        $scope.testGridData = $scope.grid.dataSource.data();
    };

    calculateTotals();

    setTimeout(function () {
        $("#descriptionField").focus();
    }, 50);
});

function getScope(ctrlName) {
    var sel = 'div[ng-controller="' + ctrlName + '"]';
    return angular.element(sel).scope();
}

function resizeGrid() {
    var $scope = getScope('ExpenseReportController');
    var VisibleColumnCount = 0;
    var grid = $("#ExpenseReportsGrid").data("kendoGrid");

    if (parseInt($scope.expenseReportHeader.Status) >= 1) {
        grid.hideColumn("Uploader");
    } else {
        grid.showColumn("Uploader");
    }

    for (var i = 0; i < grid.columns.length; i++) {

        if (grid.columns[i].title !== "Job" && grid.columns[i].title !== "Component" && grid.columns[i].title !== "Description" && grid.columns[i].title !== "PaymentType" && grid.columns[i].title !== "Receipts")  {
            grid.autoFitColumn(i);
        }
        if (!grid.columns[i].hidden) { VisibleColumnCount++; }
    }

    if (VisibleColumnCount >= 7) {

        gridHeaderTable = grid.thead.parent(),
            gridBodyTable = grid.tbody.parent();

        if (gridBodyTable.width() < grid.wrapper.width() - kendo.support.scrollbar()) {
            gridHeaderTable.find("> colgroup > col").last().width("");
            gridBodyTable.find("> colgroup > col").last().width("");

            grid.columns[grid.columns.length - 1].width = "";

            // remove the Grid tables' pixel width
            gridHeaderTable.width("");
            gridBodyTable.width("");
        }
    }
}



