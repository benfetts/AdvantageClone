AdvantageMobile_UI.expenses_report = function (params, viewInfo) {
    "use strict";

    var reportStatus = ko.observable("Open");
    var invoiceNumber = ko.observable(0);
    var expenseDetailID = ko.observable(0);
    var Description = ko.observable("");
    var Details = ko.observable("");
    var RowID = ko.observable(0);
    var strReportDate = ko.observable("");
    var strDescription = ko.observable("");
    var strExpenseDescription = ko.observable("");

    var txtDetails = ko.observable(null);
    var strDetails = {
        width: "100%",
        height: 100,
        value: txtDetails,
        placeholder: localizeString('Details'),
        readOnly: ko.observable(true)
    };

    var loadPanelVisible = ko.observable(false);
    var loadPanelMessage = localizeString('Loading');
    var isNewReport = ko.observable(true);
    var isNewEntry = ko.observable(true);
    var isDirectTime = ko.observable(true);
    var employeeTimeId = ko.observable(0);
    var employeeTimeDetailId = ko.observable(0);
    var timeType = ko.observable('');
    var clientCode = ko.observable(null);
    var divisionCode = ko.observable(null);
    var productCode = ko.observable(null);
    var reportID = ko.observable(null);
    var jobNumber = ko.observable();
    var jobComponentNumber = ko.observable("1.29");
    var CcAmount = ko.observable("2.29");
    var Amount = ko.observable("1.09");
    var functionCode = ko.observable(null);
    var categoryCode = ko.observable(null);
    var departmentCode = ko.observable(null);
    var ccFlag = ko.observable(false);
    var sequenceNumber = ko.observable(-1);
    var employeeTimeTemplateId = ko.observable(0);

    var headerMessage = ko.observable('');
    var warningBlockCSS = ko.observable("hide");

    var clientDSLoaded = false;
    var divisionDSLoaded = true;
    var productDSLoaded = true;
    var jobDSLoaded = false;
    var jobComponentDSLoaded = false;
    var functionDSLoaded = true;
    var categoryDSLoaded = true;
    var viewShowingCompleted = false;
    var viewShownCompleted = false;
    var jobLookupScrolled = false;

    var ExpAmount = ko.observable("");

    var receiptDate = ko.observable(new Date());
    var receiptDateBox = {

        value: receiptDate,
        applyValueMode: "useButtons",
        readOnly: ko.observable(true),
        width: "100%",
        onValueChanged: function (data) {
        }
    };

    var expDate = ko.observable(new Date());
    var expDateBox = {

        value: expDate,
        applyValueMode: "useButtons",
        readOnly: ko.observable(false),
        width: "100%",
        onValueChanged: function (data) {
        }
    };

    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        }
        else {
            viewShownCompleted = true;
        }
    };

    function viewShowing(e) {
        //alert(params.settings.InvoiceNumber);
        //alert(params.settings.ExpenseDetailID);


        if (params.settings) {
            if (params.settings.InvoiceNumber) {
                viewModel.InvoiceNumber(params.settings.InvoiceNumber);
            } if (params.settings.ExpenseDetailID) {
                viewModel.ExpenseDetailID(params.settings.ExpenseDetailID);
            }
            if (params.settings.InvoiceNumber && params.settings.ExpenseDetailID) {
                GetExpenseDetail();
            }

        }
        if (viewInfo.routeData.settings.InvoiceNumber == 0) {
            copyButton.visible(false);
            viewModel.isNewReport(true);
        } else if (viewInfo.routeData.settings.ReportStatus === 'Open') {
            viewModel.receiptDateBox.readOnly(false);
            viewModel.strDescription.readOnly(false);
            viewModel.strDetails.readOnly(false);
            viewModel.reportsSelectBox.readOnly(false);
        }

        viewModel.isNewEntry(true);
        viewShowingCompleted = true;
    }
    //File upload
    //document.getElementById("inp").addEventListener("change", readFile);
    var selectButtonText = "Upload Receipt";
    var labelText = "";
    var multiple = true;
    var values = [];
    var accept = "image/*";
    var uploadMode = "instantly";
    var uploadUrl = AdvantageMobile_UI.CurrentUser.ServicesURL() + "SaveDocument";
    var onContentReady = function (e) {
        e.component.element().find(".dx-fileuploader-button").dxButton({ icon: '../Resources/Asset 15.png', type: 'success' });
        e.component.element().find(".dx-fileuploader-input-container")
    }
    var expReceiptDataSource = ko.observableArray([]);
    var onValueChanged = function (e) {
        debugger;
        if (e && e.values[0]) {
            var FR = new FileReader();
            var fileName = e.values[0].name;
            FR.addEventListener("load", function (e) {
                document.getElementById("img").src = e.target.result;
                document.getElementById("b64").innerHTML = e.target.result;
                var d = new $.Deferred();
                AdvantageMobile_UI.db.get('SaveDocument', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    InvoiceNumber: viewModel.InvoiceNumber().toString(),
                    ExpenseDetailID: viewModel.ExpenseDetailID().toString(),
                    RowID: viewModel.RowID(),
                    name: fileName,
                    documentBase64: e.target.result
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
            });

            FR.readAsDataURL(e.values[0]);
        }
    }

    //File upload
    function onPhotoURISuccess(imageURI) {
        var uploadImage = $('#uploadImage');
        uploadImage.attr('src', imageURI);
        $('#uploadContainer').css('display', 'block');
    };
    function onFail(message) {
        AdvantageMobile_UI.Messages.toastSuccess("Failed because: " + message);
    };
    function getPhoto(source) {
        navigator.camera.getPicture(onPhotoURISuccess, onFail, {
            quality: 100,
            destinationType: AdvantageMobile_UI.destinationType.FILE_URI,
            sourceType: source
        });
    };
    var clientsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
            var skip = loadOptions.skip;
            var take = loadOptions.take;
            var searchVal = "";
            if (loadOptions.searchValue != null) {
                searchVal = loadOptions.searchValue;
            };
            AdvantageMobile_UI.db.get('GetClients', {
                SearchValue: searchVal,
                Skip: skip,
                Take: take
            }).done(function (data) {
                d.resolve(data);
            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        },
        byKey: function (key) {
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Clients(\'' + key.toString() + '\')');
            }
        }
    });
    var divisionsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            if (viewModel.clientCode() != null && viewModel.clientCode() != "") {
                var d = new $.Deferred();
                var searchVal = "";
                if (loadOptions.searchValue != null) {
                    searchVal = loadOptions.searchValue;
                };
                AdvantageMobile_UI.db.get('GetDivisions', {
                    ClientCode: viewModel.clientCode(),
                    SearchValue: searchVal
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
                return d.promise();
            };
        },
        byKey: function (key) {
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Divisions(ClientCode=\'' +
                                 viewModel.clientCode().toString() + '\',Code=\'' + key.toString() + '\')');
            }
        },
        map: function (item) {
            return new AdvantageMobile_UI.DivisionViewModel(item);
        },
        expand: 'Client'
    });
    var productsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            if (productDSLoaded == false && viewModel.clientCode() != null && viewModel.divisionCode() != null) {
                var d = new $.Deferred();
                var searchVal = "";
                if (loadOptions.searchValue != null) {
                    searchVal = loadOptions.searchValue;
                };
                AdvantageMobile_UI.db.get('GetProducts', {
                    ClientCode: viewModel.clientCode(),
                    DivisionCode: viewModel.divisionCode(),
                    SearchValue: searchVal
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
                return d.promise();
            };
        },
        byKey: function (key) {
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Products(ClientCode=\'' +
                                 viewModel.clientCode().toString() + '\',DivisionCode=\'' + viewModel.divisionCode().toString() + '\',Code=\'' + key.toString() + '\')');
            }
        },
        map: function (item) {
            return new AdvantageMobile_UI.ProductViewModel(item);
        },
        expand: 'Division'
    });
    var reportsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            if (viewInfo.routeData.settings.InvoiceNumber > 0) {
                AdvantageMobile_UI.db.get('GetExpenseReport', {
                    InvoiceNumber: viewInfo.routeData.settings.InvoiceNumber.toString()
                    // EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
                }).done(function (data) {
                    debugger;
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
            }
            else {
                var data = [{ "Description": "New Report", "InvoiceNumber": 0 }];
                d.resolve(data);
            }
            return d.promise();
        },
        byKey: function (key) {
            //console.log(key)
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'JobLogs(JobNumber=' + key.toString() + ')');
            }
        },
        map: function (item) {
            debugger;
            return {
                ExpensesDescription: item.Description,
                ReportID: item.InvoiceNumber,
            };
        },
        expand: 'Report'
    });
    var jobsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();

            var skip = loadOptions.skip;
            var take = loadOptions.take;
            var searchValue = "";
            var cl = "";
            var div = "";
            var prd = "";
            if (viewModel.clientCode() != undefined) {
                cl = viewModel.clientCode();
            };
            if (viewModel.divisionCode() != undefined) {
                div = viewModel.divisionCode();
            };
            if (viewModel.productCode() != undefined) {
                prd = viewModel.productCode();
            };
            if (loadOptions.searchValue != undefined) {
                searchValue = loadOptions.searchValue;
            };
            try {
                if (skip > 0 && jobLookupScrolled == false) {
                    skip = 0;
                    take = 20;
                }
            } catch (e) {
            }
            setTimeout(
                function () {
                    AdvantageMobile_UI.db.get('GetJobLogs', {
                        ClientCode: cl,
                        DivisionCode: div,
                        ProductCode: prd,
                        SearchValue: searchValue,
                        Skip: skip,
                        Take: take
                    }).done(function (data) {
                        jobLookupScrolled = false;
                        d.resolve(data);
                    }).fail(function (data) {
                        handleDataServiceError(data);
                    })
                }
            , 500);


            //}


            return d.promise();
        },
        byKey: function (key) {
            //console.log(key)
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'JobLogs(JobNumber=' + key.toString() + ')');
            }
        },
        map: function (item) {
            return {
                JobNumber: item.JobNumber,
                Description: item.Description,
                JobNumberAndDescription: item.JobNumber + " - " + item.Description
            };
        },
        expand: 'Product'
    });
    var jobComponentsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {

            var jobNum = 0;
            if (viewModel.jobNumber() != null) {
                jobNum = viewModel.jobNumber();
            };
            if (jobNum > 0) {
                var d = new $.Deferred();
                var searchVal = "";
                if (loadOptions.searchValue != null) {
                    searchVal = loadOptions.searchValue;
                };
                AdvantageMobile_UI.db.get('GetJobComponents', {
                    JobNumber: jobNum,
                    SearchValue: searchVal
                }).done(function (data) {
                    d.resolve(data);
                    jobComponentDSLoaded = true;
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
                return d.promise();
            };
        },
        byKey: function (key) {
            var jobNum = 0;
            if (viewModel.jobNumber() != null) {
                jobNum = viewModel.jobNumber();
            }
            if (key && key.toString() != '' && jobNum > 0) {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'JobComponents(JobNumber=' + jobNum + ',JobComponentNumber=' + key.toString() + ')');
            }
        },
        map: function (item) {

            return {
                JobComponentNumber: item.JobComponentNumber,
                Description: item.Description,
                JobComponentNumberAndDescription: item.JobComponentNumber + " - " + item.Description
            };
        },
    });
    var functionsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var searchVal = "";
            if (loadOptions.searchValue != null) {
                searchVal = loadOptions.searchValue;
            };
            AdvantageMobile_UI.db.get('GetFunctionsByEmployeeCode', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                SearchValue: searchVal
            }).done(function (data) {
                d.resolve(data);
            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        },
        byKey: function (key) {
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Functions(\'' + key.toString() + '\')');
            }
        },
        map: function (item) {
            return new AdvantageMobile_UI.FunctionViewModel(item);
        },
    });

    var clientsSelectBox = {
        dataSource: clientsDataSource,
        displayExpr: 'Name',
        valueExpr: 'Code',
        value: clientCode,
        onValueChanged: onClientsChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Client'),
        title: localizeString('Select') + ' ' + localizeString('Client'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };
    var divisionsSelectBox = {
        dataSource: divisionsDataSource,
        displayExpr: 'Name',
        valueExpr: 'Code',
        value: divisionCode,
        onValueChanged: onDivisionsChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Division'),
        title: localizeString('Select') + ' ' + localizeString('Division'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };
    var productsSelectBox = {
        dataSource: productsDataSource,
        displayExpr: 'Description',
        valueExpr: 'Code',
        value: productCode,
        onValueChanged: onProductsChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Product'),
        title: localizeString('Select') + ' ' + localizeString('Product'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };
    var reportsSelectBox = {
        dataSource: reportsDataSource,
        displayExpr: 'ExpensesDescription',
        valueExpr: 'ReportID',
        value: reportID,
        onValueChanged: onReportChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Report'),
        title: localizeString('Select') + ' ' + localizeString('Report'),
        readOnly: ko.observable(true),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true,
        onOpened: function () {
        },
        onPullRefresh: function (e) {
            reportsDataSource.load();
        },
        onScroll: function (e) {
            //jobLookupScrolled = true;
            //console.log("scrolled: " + jobLookupScrolled);
        }
    };
    var jobsSelectBox = {
        dataSource: jobsDataSource,
        displayExpr: 'JobNumberAndDescription',
        valueExpr: 'JobNumber',
        value: jobNumber,
        onValueChanged: onJobsChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Job'),
        title: localizeString('Select') + ' ' + localizeString('Job'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true,
        onOpened: function () {
        },
        onPullRefresh: function (e) {
            loadJobLookup();
        },
        onScroll: function (e) {
            jobLookupScrolled = true;
            //console.log("scrolled: " + jobLookupScrolled);
        }
    };
    var jobComponentsSelectBox = {
        dataSource: jobComponentsDataSource,
        displayExpr: 'JobComponentNumberAndDescription',
        valueExpr: 'JobComponentNumber',
        value: jobComponentNumber,
        placeholder: localizeString('Select') + ' ' + localizeString('Component'),
        title: localizeString('Select') + ' ' + localizeString('Component'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };
    var functionsSelectBox = {
        dataSource: functionsDataSource,
        displayExpr: 'Name',
        valueExpr: 'Code',
        value: functionCode,
        placeholder: localizeString('Select') + ' ' + localizeString('Function'),
        title: localizeString('Select') + ' ' + localizeString('Function'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };

    function onClientsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            divisionDSLoaded = false;
            viewModel.clientCode(e.value)
            divisionCode(null);
            productCode(null);
            this.divisionsDataSource.load();
            if (viewModel.isNewEntry() == true && viewShownCompleted == true) {
                jobNumber(null);
                jobComponentNumber(null);
                loadJobLookup();
            }
        }
    };
    function onDivisionsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            productDSLoaded = false;
            viewModel.divisionCode(e.value)
            productCode(null);
            this.productsDataSource.load();
            if (viewModel.isNewEntry() == true && viewShownCompleted == true) {
                jobNumber(null);
                jobComponentNumber(null);
                loadJobLookup();
            }
        }
    };
    function onProductsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            jobDSLoaded = false;
            viewModel.productCode(e.value)
            if (viewModel.isNewEntry() == true && viewShownCompleted == true) {
                jobNumber(null);
                jobComponentNumber(null);
                loadJobLookup();
            }
        }
    };
    function onJobsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            jobComponentDSLoaded = false;
            viewModel.jobNumber(e.value)
            if (viewModel.isNewEntry() == true && viewShownCompleted == true) {
                jobComponentNumber(null);
                this.jobComponentsDataSource.load();
            }
        }
    };
    function onReportChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            jobComponentDSLoaded = false;
            viewModel.jobNumber(e.value)
            if (viewModel.isNewEntry() == true && viewShownCompleted == true) {
                jobComponentNumber(null);
                this.jobComponentsDataSource.load();
            }
        }
    };

    function loadJobLookup() {
        var loadOptions = { skip: null, take: null, searchValue: null, myVal: "hi" }
        jobsDataSource.load(loadOptions);
    };

    var amountValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Amount')
        }]
    };
    var reportDateValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Report Date')
        }]
    };
    var expDateValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Expense Date')
        }]
    };
    var descriptionValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Description')
        }]
    };
    var expDescriptionValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Expense Description')
        }]
    };
    var detailsValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Details')
        }]
    };

    var addButton = {
        title: 'Add',
        id: 'create',
        icon: 'plus',
        onExecute: function (e) {
            addExpense();
        }
    };
    var copyButton = {
        title: 'Copy',
        id: 'menu-custom1',
        action: function () {
            viewModel.ExpenseDetailID(0);
            AdvantageMobile_UI.Messages.toastSuccess("copyCreated");
        },
        visible: ko.observable(true)
    };
    var clearButton = {
        title: 'Clear',
        id: 'menu-custom1',
        action: function () {
            viewModel.receiptDate(null);
            viewModel.strDescription(null);
            viewModel.txtDetails(null);

            viewModel.reportID(null);
            viewModel.clientCode(null);
            viewModel.divisionCode(null);
            viewModel.productCode(null);
            viewModel.jobNumber(null);
            viewModel.jobComponentNumber(null);
            viewModel.functionCode(null);

            viewModel.expDate(null);
            viewModel.strExpenseDescription(null);
            viewModel.ExpAmount(null);
            viewModel.ccFlag(false);
        },
        visible: ko.observable(true)
    };
    var deleteButton = {
        title: 'Delete',
        id: 'menu-clear',
        action: function () {

            //DeleteExpenseDetail
            AdvantageMobile_UI.db.get('DeleteExpenseDetail', {
                ExpenseDetailID: viewModel.ExpenseDetailID().toString()
            }).done(function (data) {
                AdvantageMobile_UI.app.navigate({
                    view: "expenses_detail",
                    settings: { InvoiceNumber: viewModel.InvoiceNumber() } //InvoiceNumber
                });

            }).fail(function (error) {
                AdvantageMobile_UI.Messages.toastSuccess("deleteFailed");
            });
        },
        visible: ko.observable(true)
    };
    function GetExpenseDetail() {

        AdvantageMobile_UI.db.get('GetExpenseDetail', {
            InvoiceNumber: viewModel.InvoiceNumber().toString(),
            ExpenseDetailID: viewModel.ExpenseDetailID().toString()
        }).done(function (data) {
            viewModel.clientCode(data.ClientCode);
            viewModel.divisionCode(data.DivisionCode);
            viewModel.productCode(data.ProductCode);
            viewModel.jobNumber(data.JobNumber);
            viewModel.jobComponentNumber(data.JobComponentNumber);
            viewModel.functionCode(data.FunctionCode);
            viewModel.categoryCode(data.CategoryCode);

            viewModel.receiptDate(data.ItemDate.toShortDateString());
            viewModel.strExpenseDescription(data.Description);
            viewModel.ExpAmount(data.Amount);
            viewModel.ccFlag(data.CcFlag);
            viewModel.RowID(data.LineNumber);


            //viewModel.txtDetails(data.Description);

        }).fail(function (error) {

        });
    }
    function CopyInvoiceDetail() {

        AdvantageMobile_UI.db.get('GetExpenseDetail', {
            InvoiceNumber: viewModel.InvoiceNumber().toString(),
            ExpenseDetailID: viewModel.ExpenseDetailID().toString()
        }).done(function (data) {
            viewModel.clientCode(data.ClientCode);
            viewModel.divisionCode(data.DivisionCode);
            viewModel.productCode(data.ProductCode);
            viewModel.jobNumber(data.JobNumber);
            viewModel.jobComponentNumber(data.JobComponentNumber);
            viewModel.functionCode(data.FunctionCode);
            viewModel.categoryCode(data.CategoryCode);

            viewModel.receiptDate();

        }).fail(function (error) {

        });
    }

    function InsertExpenseDetail() {
        //alert(viewModel.ExpenseDetailID());

        AdvantageMobile_UI.db.get('InsertExpenseDetail', {
            ID: viewModel.ExpenseDetailID(),
            InvoiceNumber: viewModel.InvoiceNumber(),
            LineNumber: 0,
            ItemDate: viewModel.expDate().toShortDateString(),
            Description: viewModel.strExpenseDescription(),
            CcFlag: viewModel.ccFlag(),
            ClientCode: viewModel.clientCode().toString(),
            DivisionCode: viewModel.divisionCode().toString(),
            ProductCode: viewModel.productCode().toString(),
            JobNumber: viewModel.jobNumber(),
            JobComponentNumber: viewModel.jobComponentNumber(),
            FunctionCode: viewModel.functionCode().toString(),
            Quantity: 410,
            Rate: "0.37",
            CcAmount: (viewModel.ccFlag()) ? viewModel.ExpAmount().toString() : "0",
            Amount: (viewModel.ccFlag()) ? "0" : viewModel.ExpAmount().toString(),
            ApComment: viewModel.Details().toString(),
            CreatedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedDate: (new Date()).toShortDateString(),
            PaymentType: 2



        }).done(function (data) {

            AdvantageMobile_UI.app.navigate({
                view: "expenses_detail",
                settings: { InvoiceNumber: viewModel.InvoiceNumber() }
            });
        }).fail(function (data) {


        });
    };

    function UpdateExpenseDetail() {
        //alert(viewModel.ccFlag());
        AdvantageMobile_UI.db.get('UpdateExpenseDetail', {
            ID: viewModel.ExpenseDetailID(),
            InvoiceNumber: viewModel.InvoiceNumber(),
            LineNumber: 0,
            ItemDate: viewModel.expDate().toShortDateString(),
            Description: viewModel.strExpenseDescription(),
            CcFlag: viewModel.ccFlag(),
            ClientCode: viewModel.clientCode().toString(),
            DivisionCode: viewModel.divisionCode().toString(),
            ProductCode: viewModel.productCode().toString(),
            JobNumber: viewModel.jobNumber(),
            JobComponentNumber: viewModel.jobComponentNumber(),
            FunctionCode: viewModel.functionCode().toString(),
            Quantity: 410,
            Rate: "0.37",
            CcAmount: (viewModel.ccFlag()) ? viewModel.ExpAmount().toString() : "0",
            Amount: (viewModel.ccFlag()) ? "0" : viewModel.ExpAmount().toString(),
            ApComment: viewModel.Details().toString(),
            CreatedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedDate: (new Date()).toShortDateString(),
            PaymentType: 2
        }).done(function (data) {
            AdvantageMobile_UI.app.navigate({
                view: "expenses_detail",
                settings: { InvoiceNumber: viewModel.InvoiceNumber() }
            });

        }).fail(function (data) {


        });
    };

    function handleSave() {
        if (viewModel.ExpenseDetailID() > 0) {

            UpdateExpenseDetail();

        }
        else {

            InsertExpenseDetail();

        }
    };

    function GetStatus(statusCode) {
        if (statusCode === 0) {
            return "Open";
        }
        else if (statusCode === 1) {
            return "Approved";
        }
        else if (statusCode === 2) {
            return "Pending";
        }
        else if (statusCode === 3) {
            return "Denied";
        }
    };

    var files = ko.observableArray([]);
    var fileSelect = function (elemet, event) {
        var files = event.target.files;// FileList object

        // Loop through the FileList and render image files as thumbnails.
        for (var i = 0, f; f = files[i]; i++) {

            // Only process image files.
            if (!f.type.match('image.*')) {
                continue;
            }

            var reader = new FileReader();

            // Closure to capture the file information.
            reader.onload = (function (theFile) {
                return function (e) {
                    self.files.push(new FileModel(escape(theFile.name), e.target.result));
                };
            })(f);
            // Read in the image file as a data URL.
            reader.readAsDataURL(f);
        }
    };
    var viewModel = {
        InvoiceNumber: invoiceNumber,
        ExpenseDetailID: expenseDetailID,

        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,

        viewInfo: viewInfo,
        viewShowing: viewShowing,
        viewShown: viewShown,
        isNewEntry: isNewEntry,
        reportID: reportID,
        clientCode: clientCode,
        divisionCode: divisionCode,
        productCode: productCode,
        jobNumber: jobNumber,
        jobComponentNumber: jobComponentNumber,
        functionCode: functionCode,
        categoryCode: categoryCode,

        reportsSelectBox: reportsSelectBox,
        clientsSelectBox: clientsSelectBox,
        divisionsSelectBox: divisionsSelectBox,
        productsSelectBox: productsSelectBox,
        jobsSelectBox: jobsSelectBox,
        jobComponentsSelectBox: jobComponentsSelectBox,
        functionsSelectBox: functionsSelectBox,
        receiptDateBox: receiptDateBox,
        expDateBox: expDateBox,
        receiptDate: receiptDate,
        expDate: expDate,

        ExpAmount: ExpAmount,

        reportDateValidator: reportDateValidator,
        expDateValidator: expDateValidator,
        descriptionValidator: descriptionValidator,
        expDescriptionValidator: expDescriptionValidator,
        detailsValidator: detailsValidator,
        amountValidator: amountValidator,
        clearButton: clearButton,
        copyButton: copyButton,
        deleteButton: deleteButton,
        handleSave: handleSave,
        reportsDataSource: reportsDataSource,
        clientsDataSource: clientsDataSource,
        divisionsDataSource: divisionsDataSource,
        productsDataSource: productsDataSource,
        jobsDataSource: jobsDataSource,
        jobComponentsDataSource: jobComponentsDataSource,
        functionsDataSource: functionsDataSource,
        onClientsChange: onClientsChange,
        onDivisionsChange: onDivisionsChange,
        onProductsChange: onProductsChange,
        onJobsChange: onJobsChange,
        onReportChange: onReportChange,

        Description: Description,
        Details: Details,
        ccFlag: ccFlag,

        strReportDate: strReportDate,
        strDescription: strDescription,
        strExpenseDescription: strExpenseDescription,
        strDetails: strDetails,
        txtDetails: txtDetails,

        //File upload
        selectButtonText: selectButtonText,
        labelText: labelText,
        multiple: multiple,
        values: values,
        accept: accept,
        uploadMode: uploadMode,
        uploadUrl: uploadUrl,
        onContentReady: onContentReady,
        onValueChanged: onValueChanged,
        expReceiptDataSource: expReceiptDataSource,
        CcAmount: CcAmount,
        Amount: Amount,
        buttonType: ko.observable("normal"),
        isNewReport: isNewReport,
        RowID: RowID,
        //File upload
    };

    return viewModel;
};