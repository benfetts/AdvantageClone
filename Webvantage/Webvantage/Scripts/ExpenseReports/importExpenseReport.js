var myApp = angular.module("angExpenseReportImport", ["kendo.directives"]);

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
        createExpenseReports: function (data) {
            return $http.post("CreateExpenseReports", data);
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
        getEmployeesForDropDown() {
            return $http.get("GetEmployeesForDropDown");
        },
        getGridColumnSettings: function () {
            return $http.get("GetGridColumnSettings");
        },
        saveGridColumnSettings: function (data) {
            return $http.post("SaveGridColumnSettings", data);
        },
        getImportTemplates: function () {
            return $http.get("GetImportTemplates");
        },
        getImportTemplateDetails: function (templateId) {
            return $http.get("GetImportTemplateDetails?ImportTemplateID=" + templateId);
        },
        saveImportTemplate: function (data) {
            return $http.post("SaveImportTemplate", data);
        }


    };
});

myApp.controller("ExpenseReportImportController", function ($scope, $q, $http, expService) {

     //declaring variables

    $scope.employee = initEmployee;
    //$scope.clients = initClients;
    //$scope.clients = [];
    $scope.allJobs = initJobs;

    $scope.divisions = [];
    $scope.products = [];
    $scope.jobs = [];
    $scope.jobcomponents = [];
    $scope.fileContent = '';
    $scope.allImportTemplates = initImportTemplates;
    $scope.invoiceNumber = invoiceNumber;
    $scope.hasInvalidData = false;
    $scope.flipSign = false;
    $scope.description = initDescription;
    $scope.invoiceDate = initInvoiceDate;
    $scope.isLastPaymentSet = false;
    $scope.lastPaymentType = intiDefaultPaymentType;

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
            if (item === "Quantity_Rate") {
                $scope.columnSettings.quantity = false;
                $scope.columnSettings.rate = false;
            }
            else if (item === "Client") {
                $scope.columnSettings.client = false;
            }
            else if (item === "Division") {
                $scope.columnSettings.division = false;
            }
            else if (item === "Product") {
                $scope.columnSettings.product = false;
            }
            else if (item === "Job_Component") {
                $scope.columnSettings.job = false;
                $scope.columnSettings.jobComponent = false;
            }
        });
    }
    setColumnSettingsFromInit();

    //save current column settings (visible, unvisible)
    $scope.saveColumnSettings_Click = function () {

        //post only unvisible columns
        var columns = [];
        if (!$scope.columnSettings.quantity) {
            columns.push("quantity");
        }
        if (!$scope.columnSettings.client) {
            columns.push("client");
        }
        if (!$scope.columnSettings.division) {
            columns.push("division");
        }
        if (!$scope.columnSettings.product) {
            columns.push("product");
        }
        if (!$scope.columnSettings.job) {
            columns.push("job");
        }

        expService.saveGridColumnSettings(columns).then(function (result) {
        });


        $(".k-tooltip-options").data("kendoTooltip").hide();
    };

    $scope.closeColumSettings_Click = function () {
        $(".k-tooltip-options").data("kendoTooltip").hide();
    };

    //define variables for needed to load expense report data
    //load uploaded data for reports
    $scope.firstRowHasColumnsName = true;
    $scope.importedHeader = [];
    $scope.importedData = [];
    //load expense reports
    $scope.expenseReportHeader = initHeader;
    $scope.expenseReportDetails = initData;
    $scope.gridData = [];
    $scope.gridData = prepereDataForGrid();

    $scope.selectedRow = [];
    //$scope.updateMode = "edit";
    $scope.lastHeaderData = {};


    $scope.reportDetailsList = [];

    //defines column for auto fill drop down values
    $scope.allColumnns = [
        { code: '', name: ' -- Not set ---' },
        { code: "Date", name: "Date", dataType: 'date' },
        { code: "Description", name: "Description", dataType: 'string' },
        { code: "Function", name: "Function", dataType: 'string' },
        { code: "Quantity", name: "Quantity", dataType: 'number' },
        { code: "Rate", name: "Rate", dataType: 'number' },
        { code: "Amount", name: "Amount", dataType: 'number' },
        { code: "Job", name: "Job Number", dataType: 'number'  },
        { code: "Component", name: "Job Component", dataType: 'number'  }];

    $scope.showAllCols = false;
    $scope.totalExpenses = 0;
    $scope.lessCreditCard = 0;
    $scope.totalDue = 0;

    //define drop down values for column select for auto fill functionality
    $scope.columnSelectorOptions = {
        dataSource: new kendo.data.DataSource({
            data: $scope.allColumnns
        }),
        placeholder: "Select a column",
        filter: "contains",
        dataTextField: "name",
        dataValueField: "code"
    };

    //define drop down values for template select
    $scope.templateOptions = {
        dataSource: new kendo.data.DataSource({
            data: $scope.allImportTemplates
        }),
        placeholder: "Select a template to load",
        filter: "contains",
        dataTextField: "Name",
        dataValueField: "Id"
    };

    //schema that is used when refreshing/recreating the grid
    var baseSchema = {
        model: {
            fields: {
                Id: { type: "number" },
                Date: { type: "date" },
                Description: { type: "string" },
                Function: { type: "string", validation: { required: true } },
                Quantity: { type: "number", defaultValue: null, validation: {} },
                Rate: { type: "number", defaultValue: null, validation: {} },
                Amount: { type: "number", defaultValue: null, validation: { required: true } },
                Client: { type: "string", validation: { required: true } },
                Division: { type: "string" },
                Product: { type: "string" },
                Job: { type: "string" },
                Component: { type: "string" },
                PaymentType: { validation: { required: true }, defaultValue: 0 }
                //Receipts: { type: "string" },
                //Uploader: { type: "string" }
            }
        }
    };

    //basic data source
    var baseDataSource = {
        data: $scope.gridData,
        batch: false,
        schema: baseSchema
    };

    //defines main grid - imported data values that are ready to be added to the report
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
                        Quantity: { type: "number", defaultValue: null, validation: {} },
                        Rate: { type: "number", defaultValue: null, validation: {} },
                        Amount: { type: "number", defaultValue: null, validation: { required: true } },
                        Client: { type: "string", validation: { required: true } },
                        Division: { type: "string" },
                        Product: { type: "string" },
                        Job: { type: "string" },
                        Component: { type: "string" },
                        PaymentType: { validation: { required: true }, defaultValue: 0 }
                        //Receipts: { type: "string" },
                        //Uploader: { type: "string" }
                    }
                }
            }
        },
        toolbar: kendo.template($("#template").html()),
        editable: {
            mode: "incell",
            confirmation: false
        },
        //editable: true,
        navigatable: true,
        selectable: "multiple, row",
        //toolbar: ["create", "save", "cancel"],
        height: '100%',
        resizable: true,
        sortable: true,
        columns: [
            { title: "", width: 35, minResizableWidth: 20, template: "<span class='wvi wvi-more_vertical'></span>" },
            { field: "Date", title: "Date", format: "{0:MM/dd/yyyy}", width: 115, editor: dateGridEditor, groupable: true, minResizableWidth: 115 },
            { field: "Description", title: "Description", groupable: false, width: 170, editor: descriptionEditor, minResizableWidth: 170 },
            { field: "Function", title: "Function", editor: functionMultiselectEditor, width: 150, template: functionCodeString, groupable: false, minResizableWidth: 150 },
            { field: "Quantity", title: "QTY", hidden: !$scope.columnSettings.quantity, groupable: false, width: 80, editor: quantityEditor, format: '{0:n4}', minResizableWidth: 80 },
            { field: "Rate", title: "Rate", hidden: !$scope.columnSettings.rate, format: '{0:n4}', groupable: false, width: 80, editor: rateEditor, minResizableWidth: 80 },
            { field: "Amount", title: "Amount", format: '{0:n2}', groupable: false, width: 80, editor: amountEditor, minResizableWidth: 80 },
            { field: "Client", title: "Client", hidden: !$scope.columnSettings.client, editor: clientMultiselectEditor, template: clientString, width: 170, groupable: false, minResizableWidth: 170 },
            { field: "Division", title: "Division", hidden: !$scope.columnSettings.division, editor: divisionMultiselectEditor, template: divisionString, width: 170, groupable: false, minResizableWidth: 170 },
            { field: "Product", title: "Product", hidden: !$scope.columnSettings.product, editor: productMultiselectEditor, template: productString, width: 170, groupable: false, minResizableWidth: 170 },
            { field: "Job", title: "Job", hidden: !$scope.columnSettings.job, editor: jobMultiselectEditor, template: jobString, width: 170, groupHeaderTemplate: jobGroupString, minResizableWidth: 170 },
            { field: "Component", title: "Component", hidden: !$scope.columnSettings.jobComponent, editor: jobcomponentMultiselectEditor, template: jobComponentString, width: 170, groupable: false, minResizableWidth: 170 },
            { field: "PaymentType", title: "Type", editor: paymentMultiselectEditor, template: paymentTypeString, width: 60, groupable: false }

        ],
        dataBound: function (e) {
            var columns = e.sender.columns;
            var columnIndexDate = this.wrapper.find(".k-grid-header [data-field=" + "Date" + "]").index();
            var columnIndexDescription = this.wrapper.find(".k-grid-header [data-field=" + "Description" + "]").index();
            var columnIndexAmount = this.wrapper.find(".k-grid-header [data-field=" + "Amount" + "]").index();
            var columnIndexFunction = this.wrapper.find(".k-grid-header [data-field=" + "Function" + "]").index();
            var columnIndexPayment = this.wrapper.find(".k-grid-header [data-field=" + "PaymentType" + "]").index();

            var rows = e.sender.tbody.children();
            for (var j = 0; j < rows.length; j++) {
                var row = $(rows[j]);

                var cell = row.children().eq(columnIndexDate);
                cell.addClass('required-field');

                cell = row.children().eq(columnIndexDescription);
                cell.addClass('required-field');

                cell = row.children().eq(columnIndexAmount);
                cell.addClass('required-field');

                cell = row.children().eq(columnIndexFunction);
                cell.addClass('required-field');

                cell = row.children().eq(columnIndexPayment);
                cell.addClass('required-field');
            }
        },
        edit: function (e) {

            if ($scope.isLastPaymentSet == false) {
                e.model.set("PaymentType", $scope.lastPaymentType);
                $scope.isLastPaymentSet = true;
            }

            //functionms
            var functionComboBox = $("#functionms").data("kendoComboBox");
            if (functionComboBox) {
                if (e.model["Function"]) {
                    var inx = $scope.functionCodes.findIndex(function (funcode) {
                        return e.model["Function"] === funcode.Code;
                    });

                    functionComboBox.select(inx);
                    functionComboBox.input.select();
                }
            }

            //clients change
            var clientComboBox = $("#clientms").data("kendoComboBox");
            if (clientComboBox) {
                clientComboBox.bind("change", function (el) {
                    var clientCode = this.value();

                    if (clientCode !== null && clientCode !== '') {
                        //get devisions

                        $scope.divisions = $scope.allJobs.filter((value, index, self) => value.ClientCode === clientCode);
                        $scope.divisions = $scope.divisions
                            .map(function (item) { return { Code: item.DivisionCode, Name: item.DivisionName }; })
                            .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                            .sort(function (a, b) {
                                return a.Code.localeCompare(b.Code);
                            });

                        if ($scope.divisions.length === 1) {
                            e.model.set("Division", $scope.divisions[0].Code);

                            $scope.products = $scope.allJobs.filter((value, index, self) => value.ClientCode === clientCode && value.DivisionCode === $scope.divisions[0].Code);
                            $scope.products = $scope.products
                                .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName }; })
                                .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                                .sort(function (a, b) {
                                    return a.Code.localeCompare(b.Code);
                                });

                            if ($scope.products.length === 1) {
                                e.model.set("Product", $scope.products[0].Code);


                                $scope.jobs = $scope.allJobs.filter((value, index, self) =>
                                    value.ClientCode === clientCode && value.DivisionCode === $scope.divisions[0].Code && value.ProductCode === $scope.products[0].Code);
                                $scope.jobs = $scope.jobs
                                    .map(function (item) { return { Number: item.Number, Description: item.JobDescription }; })
                                    .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);

                                if ($scope.jobs.length === 1) {

                                    if ($scope.columnSettings.job) {
                                        e.model.set("Job", $scope.jobs[0].Number);
                                    }

                                    $scope.jobcomponents = $scope.allJobs.filter((value, index, self) =>
                                        value.ClientCode === clientCode && value.Number === $scope.jobs[0].Number);
                                    $scope.jobcomponents = $scope.jobcomponents
                                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description }; })
                                        .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);

                                    if ($scope.jobcomponents.length === 1) {
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
                    var inx1 = $scope.clients.findIndex(function (cli) {
                        return e.model["Client"] === cli.Code;
                    });

                    clientComboBox.select(inx1);
                    clientComboBox.input.select();
                }
            }

            var divisionComboBox = $("#divisionms").data("kendoComboBox");
            if (divisionComboBox) {

                var selectedClientCode = e.model["Client"];
                if (selectedClientCode == null || selectedClientCode === '' || $scope.columnSettings.client === false) {

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
                    if (selectedDevision != null && selectedDevision !== '') {

                        var flagClient = true;
                        if (selectedClientCode == null || selectedClientCode === '') { flagClient = false; }

                        $scope.products = $scope.allJobs.filter((value, index, self) => (!flagClient || value.ClientCode === selectedClientCode) && value.DivisionCode === selectedDevision);
                        $scope.products = $scope.products
                            .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName }; })
                            .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                            .sort(function (a, b) {
                                return a.Code.localeCompare(b.Code);
                            });

                        if ($scope.products.length === 1) {
                            e.model.set("Product", $scope.products[0].Code);
                            $scope.jobs = $scope.allJobs.filter((value, index, self) =>
                                (!flagClient || value.ClientCode === selectedClientCode) && value.DivisionCode === selectedDevision && value.ProductCode === $scope.products[0].Code);
                            $scope.jobs = $scope.jobs
                                .map(function (item) { return { Number: item.Number, Description: item.JobDescription }; })
                                .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);

                            if ($scope.jobs.length === 1) {

                                if ($scope.columnSettings.job) {
                                    e.model.set("Job", $scope.jobs[0].Number);
                                }

                                $scope.jobcomponents = $scope.allJobs.filter((value, index, self) =>
                                    (!flagClient || value.ClientCode === selectedClientCode) && value.Number === $scope.jobs[0].Number);
                                $scope.jobcomponents = $scope.jobcomponents
                                    .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description }; })
                                    .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);

                                if ($scope.jobcomponents.length === 1) {
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
                        var findClient = $scope.allJobs.filter((value, index, self) => value.DivisionCode === selectedDevision);
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
                    var inx2 = $scope.divisions.findIndex(function (div) {
                        return e.model["Division"] === div.Code;
                    });

                    divisionComboBox.refresh();
                    divisionComboBox.select(inx2);
                    divisionComboBox.text($scope.divisions[inx2].DivisionName);
                    divisionComboBox.input.select();
                }
            }

            var productComboBox = $("#productms").data("kendoComboBox");
            if (productComboBox) {

                var selectedClientCode = e.model["Client"];
                var selectedDivision = e.model["Division"];

                if (selectedClientCode == null || selectedClientCode === '' || $scope.columnSettings.client === false) {
                    $scope.products = $scope.allJobs
                        .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName + ' (' + item.ProductCode + ')', ClientCode: item.ClientCode, DivisionCode: item.DivisionCode, CDP: item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode }; })
                        .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                        .sort(function (a, b) {
                            return a.CDP.localeCompare(b.CDP);
                        });
                }
                else {
                    var flagDiv = true;
                    if (selectedDivision === '' || selectedDivision == null) { flagDiv = false; }

                    $scope.products = $scope.allJobs.filter((value, index, self) => ((value.ClientCode === selectedClientCode) && (!flagDiv || (value.DivisionCode === selectedDivision))));
                    $scope.products = $scope.products
                        .map(function (item) { return { Code: item.ProductCode, Name: item.ProductName + ' (' + item.ProductCode + ')', ClientCode: item.ClientCode, DivisionCode: item.DivisionCode, CDP: item.ClientCode + '/' + item.DivisionCode + '/' + item.ProductCode }; })
                        .filter((value, index, self) => self.findIndex(i => i.Code === value.Code) === index)
                        .sort(function (a, b) {
                            return a.CDP.localeCompare(b.CDP);
                        });
                }

                var dsp = { data: $scope.products };
                productComboBox.setDataSource(dsp);

                if (e.model["Product"]) {
                    var inx = $scope.products.findIndex(function (pro) {
                        return (e.model["Product"] === pro.Code);
                    });


                    productComboBox.refresh();
                    productComboBox.select(inx);
                    productComboBox.input.select();
                }

                productComboBox.bind("change", function (el) {
                    var selectedProduct = this.value();

                    if (selectedProduct != null && selectedProduct != '') {
                        var flagClient = true;
                        var flagDiv = true;

                        if (selectedDivision == null || selectedDivision == '') { flagDiv = false; }
                        if (selectedClientCode == null || selectedClientCode == '') { flagClient = false; flagDiv = false; }

                        $scope.jobs = $scope.allJobs.filter((value, index, self) =>
                            (!flagClient || value.ClientCode === selectedClientCode) && (!flagDiv || value.DivisionCode === selectedDivision) && value.ProductCode === selectedProduct);
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

                        var findClient = $scope.allJobs.filter((value, index, self) => (value.ProductCode == selectedProduct));
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

            //when editing jobs field
            var jobsComboBox = $("#jobms").data("kendoComboBox");
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

                    if (this.value != 'undefined' && this.value != null && this.value != '') {

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

                });

            }

            //when editing job component field
            var jobComponentComboBox = $("#jobcomponentms").data("kendoComboBox");
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
                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description, Number: item.Number } })
                        .filter((value, index, self) => self.findIndex(i => i.ID === value.ID && i.Number === value.Number) === index)
                        .sort((a, b) => b.value - a.value);

                    flagSetJob = true;


                }
                else {
                    $scope.jobcomponents = $scope.allJobs.filter((value, index, self) => (value.Number == selectedJob));
                    $scope.jobcomponents = $scope.jobcomponents
                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description } })
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

                    });
                }
            }

            //changeamount
            //var tbQuantity = e.container.find("input[name=Quantity]").data("kendoNumericTextBox").value();
            var tbQuantity = e.container.find("input[name=Quantity]");
            var tbRate = e.container.find("input[name=Rate]");
            var tbAmount = e.container.find("input[name=Amount]").data("kendoNumericTextBox");
            var tbAmountv = e.container.find("input[name=Amount]");

            tbQuantity.change(function (ev) {
                if (this != null && this.value != "" && e.model["Rate"] != null && e.model["Rate"] != '') {
                    e.model.set("Amount", this.value * e.model["Rate"]);
                }
            });

            tbRate.change(function (ev) {
                if (e.model["Quantity"] != null && e.model["Quantity"] != '' && this.value != null && this.value != "") {

                    e.model.set("Amount", (e.model["Quantity"] * this.value).toFixed(2));
                }
            });

            tbAmountv.change(function (ev) {

                if (e.model["Quantity"] != null && e.model["Quantity"] != '' && this.value != null && this.value != "" && (e.model["Rate"] != null || e.model["Rate"] != '')) {

                    e.model.set("Rate", (this.value / e.model["Quantity"]).toFixed(4));

                }
            });

            if (tbAmount) {
                if (e.model["Quantity"] != null && e.model["Quantity"] != '' && e.model["Rate"] != null && e.model["Rate"] != '') {
                    //tbAmount.readonly(true);
                }
                else {
                    //tbAmount.readonly(false);
                }

                if ($scope.columnSettings.quantity == false && $scope.columnSettings.rate == false) {
                    //tbAmount.readonly(false);
                }
            }

            e.model.bind("change", function (j) {
                $scope.checkDirtyRows();
            });

        },
        cancel: function (e) {

            $scope.grid.cancelChanges();
        },
        cellClose: function (e) {
            //console.log(e);
            //$scope.grid.saveChanges();

        },
        saveChanges: function (e) {

        },
        sort: function (e) {

            $scope.selectedRow = [];
        }
    };

    //adds code to the end of the job description
    $scope.getJobDescription = function (client, division, product) {
        var tmp = client;
        if (division != client) { tmp += '/' + division; };
        if (product != division) { tmp += '/' + product; }
        return '(' + tmp + ')';
    };


    //functions to show details for data grid

    //shows selected function code descriptin in data grid cell
    function functionCodeString(item) {

        if (item.Function == '' || item.Function == null) { return '';}

        var found = false;
        var resultCodeDesc = '<span class="wvi wvi-alert bad-data"></span>';

        $scope.functionCodes.forEach(function (fc) {
            if (fc.Code == item.Function) {
                
                resultCodeDesc = fc.DescriptionOnly;
                found = true;
            }
        });
        if (!found) {
            resultCodeDesc += " " + item.Function;
            $scope.hasInvalidData = true;
        }

        return resultCodeDesc;
    }

    //shows selected payment descriptin in data grid cell
    function paymentTypeString(item) {
        var found = false;
        var resultPaymentType = '<span class="wvi wvi-alert bad-data"></span>';

        $scope.paymentTypes.forEach(function (pt) {

            if (item.PaymentType == pt.Value) {
               
                resultPaymentType = pt.Description;
                found = true;
            }
        });
        if (!found) {
            resultPaymentType += " " + item.PaymentType;
            $scope.hasInvalidData = true;
        }
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
            $scope.hasInvalidData = true;
            return '<span class="wvi wvi-alert bad-data"></span> ' + item.Client;
        }
    }

    //shows selected division code descriptin in data grid cell
    function divisionString(item) {

        if (item.Division == '' || item.Division == null) { return ''; }

        var division = $scope.allJobs.find(({ DivisionCode }) => DivisionCode === item.Division);
        if (division != null && division != 'undefined') {
            return division.DivisionName;  // + ' (' + division.DivisionCode + ')';
        }
        else {
            $scope.hasInvalidData = true;
            return '<span class="wvi wvi-alert bad-data"></span> ' + item.Division;
        }
    }

    //shows selected product code descriptin in data grid cell
    function productString(item) {

        if (item.Product == '' || item.Product == null) { return ''; }

        var product = $scope.allJobs.find(({ ProductCode }) => ProductCode == item.Product);
        if (product != null && product != 'undefined') {
            return product.ProductName;  // + ' (' + product.ProductCode + ')';
        }
        else {
            $scope.hasInvalidData = true;
            return '<span class="wvi wvi-alert bad-data"></span> ' + item.Product;
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
            $scope.hasInvalidData = true;
            return '<span class="wvi wvi-alert bad-data"></span> ' + item.Job;
        }
    }

    //shows selected job component code descriptin in data grid cell
    function jobComponentString(item) {
        if (item.Component == '' || item.Component == null) { return ''; }

        var jobComponent = null;

        //jobComponent = $scope.allJobs.find(({ Number, JobComponentNumber }) => Number == item.Job && JobComponentNumber == item.Component);

        if (item.Job == null || item.Job == '') {
            var jobMs = $("#jobms").data("kendoComboBox");
            jobComponent = $scope.allJobs.find(({ Number, JobComponentNumber }) => Number == jobMs.value() && JobComponentNumber == item.Component);
        } else {
            jobComponent = $scope.allJobs.find(({ Number, JobComponentNumber }) => Number == item.Job && JobComponentNumber == item.Component);
        }

        if (jobComponent != null && jobComponent != 'undefined') {

            return jobComponent.Description;
        }
        else {
            $scope.hasInvalidData = true;
            return '<span class="wvi wvi-alert bad-data"></span> ' + item.Component;
        }
    }

    //shows group descriptin in data grid header
    function jobGroupString(item) {
        if (item.value == '' || item.value == null) { return ''; }
        var job = $scope.allJobs.find(({ Number }) => Number == item.value);
        if (job != null && job != 'undefined') {
            return job.Number + ' - ' + job.JobDescription;
        }
        else {
            return item.value;
        }
    }

    $scope.handleChange = function (data, dataItem, columns) {
       
        $scope.selectedRow = data;
    };

    //remove invalid data - handles "remove invalid data" button click
    $scope.removeInvalidDataFromGrid = function () {
        $scope.grid.dataSource.data().forEach(function (row, index) {

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
                Receipts: null,
                Uploader: null
            };

            //var tempObj = null;

            //check function code 
            if (row.Function != null && row.Function != '') {
                var tempObj = $scope.functionCodes.find(item => item.Code == row.Function);
                if (tempObj == null) {
                    row.Function = '';
                }
            }

            if (row.Quantity != null && row.Quantity != '' && isNaN(row.Quantity)) { row.Quantity = null; }
            if (row.Rate != null && row.Rate != '' && isNaN(row.Rate)) { row.Rate = null; }
            if (row.Amount != null && row.Amount != '' && isNaN(row.Amount)) { row.Amount = null; }

            //client
            if (row.Client != null && row.Client != '') {
                var tempObj = $scope.clients.find(item => item.Code == row.Client);
                if (tempObj == null) {
                    row.Client = '';
                }
            }

            //division
            if (row.Division != null && row.Division != '') {
                var tempObj = $scope.allJobs.find(({ DivisionCode }) => DivisionCode === row.Division);
                if (tempObj == null || tempObj != 'undefined') {
                    row.Division = '';
                }
            }

            //product
            if (row.Product != null && row.Product != '') {
                var tempObj = $scope.allJobs.find(({ ProductCode }) => ProductCode == row.Product);
                if (tempObj == null || tempObj != 'undefined') {
                    row.Product = '';
                }
            }

            //job
            if (row.Job != null && row.Job != '') {
                var tempObj = $scope.allJobs.find(({ Number }) => Number == row.Job);
                if (tempObj == null || tempObj != 'undefined') {
                    row.Job = '';
                }
            }

            //job component
            if (row.Component != null && row.Component != '') {
                var tempObj = $scope.allJobs.find(({ Number, JobComponentNumber }) => Number == row.Job && JobComponentNumber == row.Component);
                if (tempObj == null || tempObj != 'undefined') {
                    row.Component = '';
                }
            }

            //payment
            if (row.PaymentType != null && row.PaymentType != '') {
                var tempObj = $scope.paymentTypes.find(item => item.Value == row.PaymentType);
                if (tempObj == null) {
                    row.PaymentType = '';
                }
            }


        });

        $scope.grid.refresh();
    };

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


    //defines the editor that is shown in quntity column
    function editNumberQuantity(container, options) {
        $('<input name="Quantity" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoNumericTextBox({
                spinners: false,
                max: 999999
            });
    }

    //defines the editor that is shown in rate column
    function editNumberRate(container, options) {
        $('<input name="Rate" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoNumericTextBox({
                spinners: false,
                max: 999999999
            });
    }

    //defines the editor that is shown in amount column
    function editNumberAmount(container, options) {
        $('<input name="Amount" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoNumericTextBox({
                spinners: false,
                max: 999999999
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

    //defines the editor that is shown in payment column
    function paymentMultiselectEditor(container, options) {

        $('<select class="paymentType" data-bind="value:' + options.field + '"/>')
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
            });
    }

    //defines the editor that is shown in date column
    function dateGridEditor(container, options) {

        $('<input autocomplete="off" maxlength="10" type="text" style="width:105px" name="Date" data-bind="value:' + options.field + '"/>')
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
                valuePrimitive: true,
                change: function (e) {
                    if (this.value() && this.selectedIndex === -1) {
                        this.dataSource.filter({
                            value: this.value(),
                            field: this.options.dataTextField,
                            operator: "contains"
                        });
                        this.select(0);
                        if (this.selectedIndex === -1) {
                            this.text("");
                        }
                    }
                }
            });
    }

    //defines the editor that is shown in client column
    function clientMultiselectEditor(container, options, data) {
        //$('<select id="clientms" onblur="onSelectChange();" class="client" data-bind="value:' + options.field + '"/>')

        var input = $('<select id="clientms" onblur="onSelectChange();" class="client" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: false,
                //placeholder: "Select client...",
                dataTextField: "Name",
                dataValueField: "Code",
                filter: "contains",
                dataSource: { data: $scope.clients },
                valuePrimitive: true,
                change: function (e) {
                    if (this.value() && this.selectedIndex === -1) {
                        this.dataSource.filter({
                            value: this.value(),
                            field: this.options.dataTextField,
                            operator: "contains"
                        });
                        this.select(0);
                        if (this.selectedIndex === -1) {
                            this.text("");
                        }
                    }
                }
            });
    }

    //defines the editor that is shown in division column
    function divisionMultiselectEditor(container, options) {

        $('<select id="divisionms" class="division" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: false,
                //placeholder: "Select division...",
                dataTextField: "Name",
                dataValueField: "Code",
                
                filter: "contains",
                dataSource: { data: $scope.divisions },
                valuePrimitive: true,
                change: function (e) {
                    if (this.value() && this.selectedIndex === -1) {
                        this.dataSource.filter({
                            value: this.value(),
                            field: this.options.dataTextField,
                            operator: "contains"
                        });
                        this.select(0);
                        if (this.selectedIndex === -1) {
                            this.text("");
                        }
                    }
                }
            });
    }

    //defines the editor that is shown in product column
    function productMultiselectEditor(container, options) {

        $('<select id="productms" class="product" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: false,
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
               //laceholder: "Select job...",
                dataTextField: "Description",
                dataValueField: "Number",
                
                filter: "contains",
                dataSource: { data: $scope.jobs },
                valuePrimitive: true,
                change: function (e) {
                    if (this.value() && this.selectedIndex === -1) {
                        this.dataSource.filter({
                            value: this.value(),
                            field: this.options.dataTextField,
                            operator: "contains"
                        });
                        this.select(0);
                        if (this.selectedIndex === -1) {
                            this.text("");
                        }
                    }
                }
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


    //prepare for create/update records in expense report
    function prepareGridData(selectedItems) {
        
        $scope.newReportDetailsList = [];
        $scope.updateReportDetailsList = [];

        if (selectedItems.length == 0) {
            selectedItems = $scope.grid.dataSource.data();
        }


        selectedItems.forEach(function (row, index) {

            var record = {};

            record.InvoiceNumber = $scope.invoiceNumber;
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
                    record.ClientCode = row.Client
                }

                if (row.Division == '' || row.Division == null) {
                    if (findData.length > 0) { record.DivisionCode = findData[0].DivisionCode; }
                }
                else {
                    record.DivisionCode = row.Division
                }

                if (row.Product == '' || row.Product == null) {
                    if (findData.length > 0) { record.ProductCode = findData[0].ProductCode; }
                }
                else {
                    record.ProductCode = row.Product
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
            }
        });
    }

    //adjusts data for grid representation
    function prepereDataForGrid() {
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
                Receipts: null,
                Uploader: null
            };

            if (item.Client == null) { item.Client = ''; }
            if (item.Division == null) { item.Division = ''; }
            if (item.Product == null) { item.Product = ''; }
            if (item.Job == null) { item.Job = ''; }
            if (item.Component == null) { item.Component = ''; }
            if (item.PaymentType == null) { item.PaymentType = ''; }


            //change payment type that is eliminated
            if (item.PaymentType === 2) { item.PaymentType = 1; }


            gridData.push(item);
        });

        return gridData;
    }

    //creates data source object for reprt details
    function getDataSource() {

        var dataSource = {
            data: $scope.gridData,
            batch: false,
            schema: baseSchema
        };

        return dataSource;
    }

    //validates entered data in the grid (imported data)
    function validateGrid() {

        $scope.hasInvalidData = false;
        //scope.grid.refresh();s

        var valObject = { result: true, messages: [] };
        var messages = [];

        //if ($scope.grid.select().length > 0) {
        //    var itemsToValidate = [];
        //    $scope.grid.select().each(function () {
        //        var item = $scope.grid.dataItem($(this)).toJSON();
        //        itemsToValidate.push(item);
        //    });

        //    $scope.grid.dataSource.data().forEach((row, index) => {
        //        itemsToValidate.forEach((selItem) => {
        //            if (copmpareObjects(row, selItem)) {
        //                if (row.Date == null || row.Date == '') {
        //                    messages.push('Error at row ' + (index + 1) + ': Date field is required');
        //                }
        //                else {
        //                    var r = Date.parse(row.Date).toString();
        //                    if (r == "NaN") { messages.push('Error at row ' + (index + 1) + ': Invalid date format.'); }
        //                }

        //                if (row.Description == null || row.Description == '') {
        //                    messages.push('Error at row ' + (index + 1) + ': Description field is required');
        //                }
        //                if (row.Amount == null || row.Amount == '') {
        //                    messages.push('Error at row ' + (index + 1) + ': Amount field is required');
        //                }
        //                else {
        //                    if (row.Amount == 0) { messages.push('Error at row ' + (index + 1) + ': Amount field is required.'); };
        //                }

        //                if (row.Function === null || row.Function === '') {
        //                    messages.push('Error at row ' + (index + 1) + ': Function field is required');
        //                }

        //                if (row.PaymentType === null || row.PaymentType === '') {
        //                    messages.push('Error at row ' + (index + 1) + ': Payment type field is required');
        //                }

        //                if (row.Job != null && row.Job != '') {
        //                    if (row.Component == '' || row.Component == null) {
        //                        messages.push('Error at row ' + (index + 1) + ': Job component is required when job is selected.');
        //                    }
        //                }
        //            }
        //        });
        //    });
        //} else {
            $scope.grid.dataSource.data().forEach(function (row, index) {

                if (row.Date == null || row.Date == '') {
                    messages.push('Error at row ' + (index + 1) + ': Date field is required');
                }
                else {
                    var r = Date.parse(row.Date).toString();
                    if (r == "NaN") { messages.push('Error at row ' + (index + 1) + ': Invalid date format.'); }
                }

                if (row.Description == null || row.Description == '') {
                    messages.push('Error at row ' + (index + 1) + ': Description field is required');
                }
                if (row.Amount == null || row.Amount == '') {
                    messages.push('Error at row ' + (index + 1) + ': Amount field is required');
                }
                else {
                    if (row.Amount == 0) { messages.push('Error at row ' + (index + 1) + ': Amount field is required.'); };
                }

                if (row.Function === null || row.Function === '') {
                    messages.push('Error at row ' + (index + 1) + ': Function field is required');
                }

                if (row.PaymentType === null || row.PaymentType === '') {
                    messages.push('Error at row ' + (index + 1) + ': Payment type field is required');
                }

                if (row.Job != null && row.Job != '') {
                    if (row.Component == '' || row.Component == null) {
                        messages.push('Error at row ' + (index + 1) + ': Job component is required when job is selected.');
                    }
                }
            });
        //}

        if ($scope.hasInvalidData == true) {
            messages.push('Grid has some invalid data.');
        }

        if (messages.length > 0) {
            valObject.result = false;
            valObject.messages = messages;
        }

        return valObject;
    }

    //handles "change column visibility" event
    $scope.$watch('columnSettings', function (newValue, oldValue) {
        
        if (newValue.quantity != oldValue.quantity) {

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

        if (newValue.client != oldValue.client) {
            if (newValue.client) { $scope.grid.showColumn("Client"); }
            else {
                $scope.grid.hideColumn("Client");
                $scope.division = false; newValue.division = false;
                $scope.product = false; newValue.product = false;
            }
        }

        if (newValue.division != oldValue.division) {
            if (newValue.division) {
                $scope.grid.showColumn("Division"); $scope.client = true; newValue.client = true;
            }
            else {
                $scope.grid.hideColumn("Division"); $scope.product = false; newValue.product = false;
            }
        }

        if (newValue.product != oldValue.product) {
            if (newValue.product) {
                $scope.grid.showColumn("Product");
                $scope.division = true; newValue.division = true;
                $scope.client = true; newValue.client = true;
            }
            else {
                $scope.grid.hideColumn("Product");
            }
        }

        if (newValue.job != oldValue.job) {
            if (newValue.job) {
                $scope.grid.showColumn("Job");
                $scope.jobComponent = true;
                newValue.jobComponent = true;
                //$scope.grid.showColumn("Component");
            }
            else {
                $scope.grid.hideColumn("Job");
                $scope.jobComponent = false;
                newValue.jobComponent = false;
                //$scope.grid.hideColumn("Component");
            }
        }

        if (newValue.jobComponent != oldValue.jobComponent) {
            if (newValue.jobComponent) {
                $scope.grid.showColumn("Component");
                $scope.job = true;
                newValue.job = true;
                //$scope.grid.showColumn("Job");
            }
            else {
                $scope.grid.hideColumn("Component");
                $scope.job = false;
                newValue.job = false;
                //$scope.grid.hideColumn("Job");
            }
        }

    }, true);

    //handles "selected file for import" event
    $scope.$watch('fileContent', function (newValue, oldValue) {

        if (newValue !== oldValue) {
            $scope.handleImportedData();
        }
    });


    //properties
    $scope.showMatchingTable = false;
    $scope.showGridData = false;


    //read data from file and suggest data mapping
    $scope.handleImportedData = function () {
        $scope.importedHeader = [];
        $scope.importedData = [];
        $scope.gridMatch.dataSource.data([]);

        if ($scope.fileContent === null) {
            return;
        }

        var result = CSVToArray($scope.fileContent, ',');

        //gridMatch
        if ($scope.firstRowHasColumnsName) {

            result[0].forEach((col, index) => {
                var bf = '';
                $scope.allColumnns.forEach(defCol => {
                    if (col.toLowerCase().includes(defCol.code.toLowerCase()) || defCol.code.toLowerCase().includes(col.toLowerCase())) {
                        bf = defCol.code;
                    }
                });

                var dataElement = { Id: index, Column: col.trim(), BoundField: bf, DateFormat: '', ExampleData: result[1][index] };
                $scope.importedData.push(dataElement);


                $scope.gridMatch.dataSource.add(dataElement);
            });// imported row
        }
        else {
            result[0].forEach((col, index) => {
                var dataElement = { Id: index, Column: 'Column_' + index, BoundField: '', ExampleData: col };
                $scope.importedData.push(dataElement);
                $scope.gridMatch.dataSource.add(dataElement);
            });
        }

        //load template if any selected
        if ($scope.selectedTemplate !== '' && $scope.selectedTemplate != null) {

            expService.getImportTemplateDetails($scope.selectedTemplate).then(function (result) {

                var details = result.data;


                $scope.gridMatch.dataSource.data().forEach((def, index) => {

                    details.forEach((detail) => {
                        if (detail.CSVPosition === index) {
                            def.BoundField = detail.FieldName;
                            def.DateFormat = detail.DateFormat;
                        }
                    });
                });

                $scope.gridMatch.refresh();
                //$scope.selectedTemplate = '';
            });
            //load grid
            $scope.loadData();
        }
        else {
            $scope.showMatchingTable = true;

            setTimeout(() => {
                console.log('trigger resize');
                window.dispatchEvent(new Event("resize"));
            }, 100);
        }
    };

    $scope.handleSign = () => {
        //if ($scope.selectedTemplate === '' || $scope.selectedTemplate == null) {

            $scope.grid.dataSource.data().forEach((row) => {

                //console.log(row['Quantity']);
                if (row['Quantity'] !== null) {
                    row['Quantity'] = 0 - row['Quantity'];
                }
                if (row['Rate'] !== null) {
                    row['Rate'] = 0 - row['Rate'];
                }
                if (row['Amount'] !== null) {
                    row['Amount'] = 0 - row['Amount'];
                } 
               
            });

            $scope.grid.refresh();

            $scope.grid.saveChanges();

            //$scope.loadData();
        //}
        //else {
        //    $scope.handleImportedData();
        //}
    };

    //define grid for data mapping 
    $scope.matchingGridOptions = {
        dataSource: {
            data: [],
            batch: false,
            schema: {
                model: {
                    fields: {
                        Id: { type: "number" },
                        Column: { type: "string", editable: false },
                        BoundField: { type: "string" },
                        DateFormat: { type: "string" },
                        ExampleData: { type: "string" }
                    }
                }
            }
        },
        editable: {
            mode: "incell",
            confirmation: false
        },
        navigatable: true,
        selectable: false,
        height: '100%',
        sortable: false,
        resizable: true,

        columns: [
            { field: "Id", title: "SEQ", width: 30 },
            { field: "Column", title: "Column in File", width: 70 },
            { field: "BoundField", title: "Column in Expense Report", width: "80px", editor: functionBoundField },
            { field: "DateFormat", title: "Date Format", width: "100px", minResizableWidth: 100 },
            { field: "ExampleData", title: "Example Data", width: "70px" }
        ]
    };

    //defines the editor that is shown in bound field column (mapping grid)
    function functionBoundField(container, options) {

        $('<select id="boundfieldms" class="bounded-field" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                autoBind: false,
                placeholder: "",
                dataValueField: "code",
                dataTextField: "name",
                filter: "contains",

                dataSource: { data: $scope.allColumnns },
                valuePrimitive: true
            });
    }

    //handle "reset file" button click
    $scope.cleanSelectedFile = function () {
        $('#fileImport').val('');
        $scope.fileContent = null;
        $scope.showMatchingTable = false;
        $scope.showGridData = false;
        $scope.selectedTemplate = '';
    };

    //handle "load data" button click - when mapping is done and data is ready to be presentred in the main grid
    $scope.loadData = function () {

        $scope.grid.dataSource.data([]);
        var result = CSVToArray($scope.fileContent, ',');

        //fill grid
        result.forEach((row, index) => {

            var newRecordTemp = {
                "Id": 0,
                "Date": "",
                "Description": "",
                "Function": "",
                "Quantity": null,
                "Rate": null,
                "Amount": null,
                "Client": "",
                "Division": "",
                "Product": "",
                "Job": "",
                "Component": "",
                "PaymentType": $scope.lastPaymentType
                //"Receipts": null,
                //"Uploader": null,
                //
            };

            //if row has data
            if (row.length > 1) {
                $scope.gridMatch.dataSource.data().forEach((def) => {
                    if (def.BoundField !== null && def.BoundField !== '') {
                        var value = row[def.Id];

                        if (typeof value === 'string') {
                            value = value.trim();
                        }

                        if (baseSchema.model.fields[def.BoundField].type !== 'undefined') {

                            if (baseSchema.model.fields[def.BoundField].type === 'number') {

                                console.log(def.BoundField);

                                var tmp = parseFloat(value.trim());

                                if ($scope.flipSign === true && def.BoundField === 'Amount') {
                                    tmp = 0 - tmp;
                                }

                                if (tmp === 0 || isNaN(tmp)) {

                                    newRecordTemp[def.BoundField] = null;
                                }
                                else {
                                    newRecordTemp[def.BoundField] = tmp;
                                }
                            }
                            else {
                                newRecordTemp[def.BoundField] = value;
                            }
                        }
                        else {
                            newRecordTemp[def.BoundField] = value;
                        }

                    }
                });

                if ($scope.firstRowHasColumnsName && index !== 0) {
                    $scope.grid.dataSource.add(newRecordTemp);
                }
            }//if row has data
        });

        $scope.showGridData = true;
        $scope.showMatchingTable = false;
        $scope.testGridData = $scope.grid.dataSource.data();

        setTimeout(() => {
            console.log('trigger resize');
            window.dispatchEvent(new Event("resize"));
        }, 100);

    };

    //handle "update" button click - when using auto fill
    $scope.fillColumn = function () {

        if ($scope.selectedColumnForFill == null || $scope.selectedColumnForFill == '') {
            showKendoAlert('Select column');
            return;
        }

        if ($scope.selectedColumnForFill !== 'Date' && $scope.selectedColumnForFill !== 'Function' && $scope.selectedColumnForFill !== 'Job' && $scope.selectedColumnForFill !== 'Component') {
            if ($scope.valueToFill === '' || $scope.valueToFill == null) {
                showKendoAlert('Insert value to fill the column');
                return;
            }
        }

        if ($scope.selectedColumnForFill === 'Date' && ($scope.selectedDate == '' || $scope.selectedDate == null)) {
            showKendoAlert('Select date to fill the column');
            return;
        }

        if ($scope.selectedColumnForFill === 'Function' && ($scope.selectedFunctionCode === '' || $scope.selectedFunctionCode == null)) {
            showKendoAlert('Select function to fill the column');
            return;
        }

        if ($scope.selectedColumnForFill === 'Job' && ($scope.selectedJobCode === '' || $scope.selectedJobCode == null)) {
            showKendoAlert('Select job to fill the column');
            return;
        }

        if ($scope.selectedColumnForFill === 'Component' && ($scope.selectedJobComponentCode === '' || $scope.selectedJobComponentCode == null)) {
            showKendoAlert('Select job component to fill the column');
            return;
        }

        var validValue = $scope.valueToFill;

        switch ($scope.selectedColumnForFill) {
            case 'Function': validValue = $scope.selectedFunctionCode; break;
            case 'Job': validValue = $scope.selectedJobCode; break;
            case 'Component': validValue = $scope.selectedJobComponentCode; break;
            case 'Date': validValue = $scope.selectedDate; break;
            default: validValue = $scope.valueToFill; break;
        }

        var selectedCol = $scope.allColumnns.find(col => col.code == $scope.selectedColumnForFill);
        var validJCValue;
        var validClient;
        var validDivision;
        var validProduct;

        if ($scope.selectedColumnForFill === 'Job') {

            var dsjc = $scope.allJobs.filter((value, index, self) => (value.Number == $scope.selectedJobCode));
            dsjc = dsjc
                .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description, ClientCode: item.ClientCode, DivisionCode: item.DivisionCode, ProductCode: item.ProductCode } })
                .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);

            if (dsjc.length === 1) {
                //jc.value($scope.jobcomponents[0].ID);
                validJCValue = dsjc[0].ID;
                validClient = dsjc[0].ClientCode;
                validDivision = dsjc[0].DivisionCode;
                validProduct = dsjc[0].ProductCode;
            }
            else {
                //jc.value(null);
                var dsj = $scope.allJobs.filter((value, index, self) => (value.Number == $scope.selectedJobCode));
                validJCValue = '';
                validClient = dsj[0].ClientCode;
                validDivision = dsj[0].DivisionCode;
                validProduct = dsj[0].ProductCode;
            }

        }

        if ($scope.selectedColumnForFill === 'Component') {            

            var jc = validValue.split("|");
            var jobValue = parseInt(jc[1]);
            validValue = parseInt(jc[0]);

            var dsjc2 = $scope.allJobs.filter((value, index, self) => (value.Number == jobValue && value.JobComponentNumber == validValue));
            validClient = dsjc2[0].ClientCode;
            validDivision = dsjc2[0].DivisionCode;
            validProduct = dsjc2[0].ProductCode;

        }

        //vali
        if (selectedCol != null) {
            if (selectedCol.dataType === 'number') {
                if (isNaN(validValue)) {
                    showKendoAlert('Value for selected column should be number!');
                    return;
                }
            }
        }

        //var allRows = $scope.grid.dataSource.data();
        if ($scope.grid.select().length > 0) {

            var itemsToFill = [];
            $scope.grid.select().each(function () {
                var item = $scope.grid.dataItem(this);

                itemsToFill.push(item);


            });

            itemsToFill.forEach((item) => {
                item.set($scope.selectedColumnForFill, validValue);
                //item[$scope.selectedColumnForFill] = validValue;

                if ($scope.selectedColumnForFill === 'Job' || $scope.selectedColumnForFill === 'Component') {

                    item['Client'] = validClient;
                    item['Division'] = validDivision;
                    item['Product'] = validProduct;

                }

                if ($scope.selectedColumnForFill === 'Job' && validJCValue !== '') {
                    item['Component'] = validJCValue;
                }

                if ($scope.selectedColumnForFill === 'Component' && jobValue !== '') {
                    item['Job'] = jobValue;
                }
            });

            //$scope.grid.dataSource.data().forEach((row, index) => {
            //    itemsToFill.forEach((selItem) => {
            //        if (copmpareObjects(row, selItem)) {
            //            row[$scope.selectedColumnForFill] = validValue;

            //            if ($scope.selectedColumnForFill === 'Job' && validJCValue !== '') {
            //                row['Component'] = validJCValue;
            //            }

            //            if ($scope.selectedColumnForFill === 'Component' && jobValue !== '') {
            //                row['Job'] = jobValue;
            //            }
            //        }
            //    });
            //});

        }
        else {
            $scope.grid.dataSource.data().forEach((row) => {

                row[$scope.selectedColumnForFill] = validValue

                if ($scope.selectedColumnForFill === 'Job' || $scope.selectedColumnForFill === 'Component') {

                    row['Client'] = validClient;
                    row['Division'] = validDivision;
                    row['Product'] = validProduct;

                }                

                if ($scope.selectedColumnForFill === 'Job' && validJCValue !== '') {
                    row['Component'] = validJCValue;
                }

                if ($scope.selectedColumnForFill === 'Component' && jobValue !== '') {
                    row['Job'] = jobValue;
                }
            });
        }

        //$scope.selectedColumnForFill = null;
        //$scope.valueToFill = '';

        $scope.grid.refresh();

        $scope.grid.saveChanges();

    };

    //compares if objects are equal
    function copmpareObjects(item1, item2) {

        if (item1.Id == item2.Id 
            && item1.Date == item2.Date 
            && item1.Description == item2.Description 
            && item1.Function == item2.Function 
            && item1.Quantity == item2.Quantity 
            && item1.Amount == item2.Amount 
            && item1.Client == item2.Client 
            && item1.Division == item2.Division 
            && item1.Product == item2.Product 
            && item1.Job == item2.Job 
            && item1.Component == item2.Component 
            && item1.PaymentType == item2.PaymentType 
            )
        {
            return true;
        }
        return false;
    }


    //handle "save as new import template" button click 
    $scope.saveAsNewImportTemplate = function () {

        if ($scope.templateName == null || $scope.templateName == '') {
            showKendoAlert('Please enter template name');
            return;
        }

        var listOfColumns = [];
        $scope.gridMatch.dataSource.data().forEach((def) => {

            var tempColData = {
                ID: null,
                TemplateID: null,
                CSVPosition: def.Id,
                CSVField: def.Column,
                FieldName: def.BoundField,
                DateFormat: def.DateFormat
            };

            listOfColumns.push(tempColData);
        });

        var data = { Employee: initEmployee.Code, TemplateName: $scope.templateName, ImportDetailList: listOfColumns };

        expService.saveImportTemplate(data).then(function (result) {


            if (result.data.toLowerCase() == 'ok') {
                $scope.templateName = '';
                showKendoAlert('The template has been saved successfully');
                expService.getImportTemplates().then(function (allTemps) {
                    $scope.allImportTemplates = allTemps;
                });
            }
            else {
                showKendoAlert(res.data);
            }

            //allImportTemplates

        });


    };

    //handle "load import template" button click 
    $scope.loadImportTemplate = function () {

        if ($scope.selectedTemplate == '' || $scope.selectedTemplate == null) {
            showKendoAlert('Please select template');
            return;
        }

        expService.getImportTemplateDetails($scope.selectedTemplate).then(function (result) {

            var details = result.data;


            $scope.gridMatch.dataSource.data().forEach((def, index) => {

                details.forEach((detail) => {
                    if (detail.CSVPosition == index) {
                        def.BoundField = detail.FieldName;
                        def.DateFormat = detail.DateFormat;
                    }
                });
            });

            $scope.gridMatch.refresh();
            $scope.selectedTemplate = '';
        });

    };

    //handle "save loaded data" button click 
    $scope.saveLoadedDataToReport = function () {


        var selectedItems = [];
        //$scope.grid.select().each(function () {


        //    var item = $scope.grid.dataItem($(this)).toJSON();
        //    selectedItems.push(item);
        //});



        var res = validateGrid();




        if (!res.result) {
            var alertstring = '';
            res.messages.forEach(function (row, index) {
                alertstring += row + '\n';
            });
            showKendoAlert(alertstring);

            return;
        }

        //return;

        if (!res.result) {
            var alertstring = '';
            res.messages.forEach(function (row, index) {
                alertstring += row + '\n';
            });
            showKendoAlert(alertstring);

            return;
        }

        prepareGridData(selectedItems);

        //return;

        //add report details

        if ($scope.invoiceNumber === 0 || $scope.invoiceNumber === null || $scope.invoiceNumber === '') { 

            closeDialog($scope.invoiceNumber, $scope.newReportDetailsList);

        } else {

            expService.createExpenseReportDetails($scope.newReportDetailsList, true).then(function (result) {

                if (result.data === true) {
                    //get expense reports


                    //close popup
                    closeDialog($scope.invoiceNumber, selectedItems);
                }

            });
        }       

    };
   
    //checks if there are any selected rows
    $scope.reportDetailsSelectedRow = function () {

        if ($scope.selectedRow.length > 0) {
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
    };
    
    //visible import fields
    
    //check id input field shoud be visible
    $scope.getVisibleInputField = function () {

        if ($scope.selectedColumnForFill != 'Function' && $scope.selectedColumnForFill != 'Date'
            && $scope.selectedColumnForFill != 'Job' && $scope.selectedColumnForFill != 'Component') {
            return true;
        } else {
            return false;
        }
    };

    //check id date field shoud be visible
    $scope.getVisibleDateField = function () {

        if ($scope.selectedColumnForFill == 'Date') {
            return true;
        } else {
            return false;
        }

        //
    };

    //check id function dropodown list shoud be visible
    $scope.getVisibleFunctionComboBox = function () {
        if ($scope.selectedColumnForFill == 'Function') {
            return true;
        } else {
            return false;
        }
    };

    //check id job dropodown list shoud be visible
    $scope.getVisibleJobsComboBox = function () {
        if ($scope.selectedColumnForFill == 'Job') {
            return true;
        } else {
            return false;
        }
    };

    //check id job component dropodown list shoud be visible
    $scope.getVisibleJobsComponentComboBox = function () {
        if ($scope.selectedColumnForFill == 'Component') {
            return true;
        } else {
            return false;
        }
    };
        
    //define values for function code dropdown list
    $scope.functionCodeOptions = {
        dataSource: new kendo.data.DataSource({
            data: $scope.functionCodes
        }),
        //placeholder: "Select a function",
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "Code"
    };

    //adjust data for job dropdown list (auto fill )
    $scope.jobsForCombo = $scope.allJobs
        .map(function (item) { return { Number: item.Number, Description: item.Number + ' - ' + item.JobDescription + ' ' + $scope.getJobDescription(item.ClientCode, item.DivisionCode, item.ProductCode) } })
        .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);

    //define jobs available for job dropdown list (auto fill)
    $scope.jobCodeOptions = {
        dataSource: new kendo.data.DataSource({
            data: $scope.jobsForCombo
        }),
        //placeholder: "Select a job",
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "Number"
    };

     //adjust data for job component dropdown list (auto fill )
    $scope.jobComponentsForCombo = $scope.allJobs
        .map(function (item) { return { ID: item.JobComponentNumber + '|' + item.Number, Description: item.Description } });
      

    //define jobs available for job component dropdown list (auto fill)
    $scope.jobComponentCodeOptions = {
        dataSource: new kendo.data.DataSource({
            data: $scope.jobComponentsForCombo
        }),
       // placeholder: "Select a job component",
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "ID"
    };

    $scope.deleteRecord = function () {
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
                $scope.grid.refresh();
                //$scope.hasDirtyRows = true;
            })
            .fail(function () {
            });    
                     

        //if (confirm('Are you sure you want to delete the selected row(s)?')) {

        //}

    };

});

$(window).on("resize", function () {

    $("#importwindow").kendoWindow("center");

}); 

function onSelectChange() {

    var grid = $("#ExpenseReportsGrid").data("kendoGrid");

    for (var i = 0; i < grid.columns.length; i++) {
        if (grid.columns[i].title !== "Job" && grid.columns[i].title !== "Component" && grid.columns[i].title !== "Description") {
            grid.autoFitColumn(i);
        }  
    }
}

//define file reader directive
myApp.directive('fileReader', function () {
    return {
        scope: {
            fileReader: "="
        },
        link: function (scope, element) {
            $(element).on('change', function (changeEvent) {
                var files = changeEvent.target.files;
                if (files.length) {
                    var r = new FileReader();
                    r.onload = function (e) {
                        var contents = e.target.result;
                        scope.$apply(function () {
                            scope.fileReader = contents;
                        });
                    };

                    r.readAsText(files[0]);
                }
            });
        }
    };
});


// This will parse a delimited string into an array of
// arrays. The default delimiter is the comma, but this
// can be overriden in the second argument.
function CSVToArray(strData, strDelimiter) {
    // Check to see if the delimiter is defined. If not,
    // then default to comma.
    strDelimiter = (strDelimiter || ",");
    // Create a regular expression to parse the CSV values.
    var objPattern = new RegExp(
        (
            // Delimiters.
            "(\\" + strDelimiter + "|\\r?\\n|\\r|^)" +
            // Quoted fields.
            "(?:\"([^\"]*(?:\"\"[^\"]*)*)\"|" +
            // Standard fields.
            "([^\"\\" + strDelimiter + "\\r\\n]*))"
        ),
        "gi"
    );
    // Create an array to hold our data. Give the array
    // a default empty first row.
    var arrData = [[]];
    // Create an array to hold our individual pattern
    // matching groups.
    var arrMatches = null;
    // Keep looping over the regular expression matches
    // until we can no longer find a match.
    while (arrMatches = objPattern.exec(strData)) {
        // Get the delimiter that was found.
        var strMatchedDelimiter = arrMatches[1];
        // Check to see if the given delimiter has a length
        // (is not the start of string) and if it matches
        // field delimiter. If id does not, then we know
        // that this delimiter is a row delimiter.
        if (
            strMatchedDelimiter.length &&
            (strMatchedDelimiter != strDelimiter)
        ) {
            // Since we have reached a new row of data,
            // add an empty row to our data array.
            arrData.push([]);
        }
        // Now that we have our delimiter out of the way,
        // let's check to see which kind of value we
        // captured (quoted or unquoted).
        if (arrMatches[2]) {
            // We found a quoted value. When we capture
            // this value, unescape any double quotes.
            var strMatchedValue = arrMatches[2].replace(
                new RegExp("\"\"", "g"),
                "\""
            );
        } else {
            // We found a non-quoted value.
            var strMatchedValue = arrMatches[3];
        }
        // Now that we have our value string, let's add
        // it to the data array.
        arrData[arrData.length - 1].push(strMatchedValue);
    }
    // Return the parsed data.
    return (arrData);
}
