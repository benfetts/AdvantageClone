AdvantageMobile_UI.expenses_report = function (params, viewInfo) {
    "use strict";
    var isVisible = ko.observable();
    var reportStatusOpen = ko.observable(false);
    var reportCanSave = ko.observable(true);
    var reportReadOnly = ko.observable(false);
    var invoiceNumber = ko.observable(0);
    var expenseDetailID = ko.observable(0);
    var DocumentID = ko.observable(0);
    var Description = ko.observable("");
    var Details = ko.observable("");
    var RowID = ko.observable(0);
    var strReportDate = ko.observable("");
    var strDescription = ko.observable("");
    var strDetailsDescription = ko.observable("");
    var strExpenseDescription = ko.observable("");
    var loadPanelVisible = ko.observable(false);
    var loadPanelMessage = localizeString('Loading');
    var reportID = ko.observable(null);
    var isNewInvoice = ko.observable(true);
    var ShowReportSelectBox = ko.observable(false);
    var isNewReport = ko.observable(true);
    var isNewEntry = ko.observable(true);
    var ExistingReport = ko.observable(false);
    var isDirectTime = ko.observable(true);
    var employeeTimeId = ko.observable(0);
    var employeeTimeDetailId = ko.observable(0);
    var lineNumber = ko.observable(0);
    var timeType = ko.observable('');
    var clientCode = ko.observable(null);
    var divisionCode = ko.observable(null);
    var productCode = ko.observable(null);
    var jobNumber = ko.observable(null);
    var jobComponentNumber = ko.observable(null);
    var CcAmount = ko.observable(0);
    var Amount = ko.observable(true);
    var functionCode = ko.observable(null);
    var categoryCode = ko.observable(null);
    var departmentCode = ko.observable(null);
    var ccFlag = ko.observable(false);
    var PaymentType = ko.observable();
    var sequenceNumber = ko.observable(-1);
    var employeeTimeTemplateId = ko.observable(0);
    var headerMessage = ko.observable('');
    var warningBlockCSS = ko.observable("hide");
    var companyCodeTemp = "0";
    var divisionCodeTemp = "0";
    var productCodeTemp = "0";
    var jobCodeTemp = 0;
    var reportDSLoaded = false;
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
    var Quantity = ko.observable("");
    var Rate = ko.observable("");
    var ShowRate = ko.observable(false);
    var repoFileName = ko.observable("");
    var expDocumentsDataSource = ko.observable(true);
    var reportDate = ko.observable(new Date());
    var reportDateBox = {
        value: reportDate,
        applyValueMode: "useButtons",
        readOnly: reportReadOnly,
        width: "100%",
        onValueChanged: function (data) {
        }
    };
    var firstChange = true;
    var isToastVisible = ko.observable(false);
    var picture = ko.observable();
    var expDate = ko.observable(new Date());
    var expDateBox = {
        value: expDate,
        applyValueMode: "useButtons",
        //readOnly: reportReadOnly,
        width: "100%",
        onValueChanged: function (data) {
        }
    };
    var hideKeyboard = function () {
        document.activeElement.blur();
        var inputs = document.querySelectorAll('input');
        for (var i = 0; i < inputs.length; i++) {
            inputs[i].blur();
        }
    };
    var selectButtonText = "Upload Receipt";
    var labelText = "";
    var multiple = true;
    var values = [];
    var accept = "image/*";
    var uploadMode = "instantly";
    //var uploadUrl = "http://localhost/docservice/api/upload";
    //var uploadUrl = AdvantageMobile_UI.CurrentUser.ServicesURL() + "UploadDocument";
    //var uploadUrl = AdvantageMobile_UI.CurrentUser.ServicesURL() + "UploadFile?" + "EmployeeCode=%27" + AdvantageMobile_UI.CurrentUser.EmployeeCode().toString() + "%27&InvoiceNumber=%27" + invoiceNumber().toString() + "%27&ExpenseDetailID=%27" + expenseDetailID().toString() + "%27&RowID=1" + "&fileName=%27abc%27";
    var onContentReady = function (e) {
        var button = e.element.find(".dx-fileuploader-button").dxButton('instance');

        if (button) {
            button.option('icon', 'fa fa-upload');
        }
    };
    var onUploaded = function (e) {
        //use e.request.responseText
        DevExpress.ui.dialog.alert('Uploaded', 'Uploaded');
    };
    var onValueChanged = function (e) {
        if (viewModel.ExpenseDetailID() === 0) {
            if (validateFields())
                handleSave(false, e, null);
            else
                cancelUpload(e);
        }
        else {
            uploadFile(e);
        }
    };
    var cancelUpload = function (e) {
        var values = e.component.option("values");
        $.each(values, function (index, value) {
            //if(value.name.indexOf(".png") < 3) {
            e.element
                .find(".dx-fileuploader-files-container .dx-fileuploader-cancel-button")
                .eq(index)
                .trigger("dxclick");
            //}
        });
    };
    var getPicture = function () {
        var viewModel = this;
        navigator.camera.getPicture(function (photo) {
            //viewModel.picture('data:image/jpeg;base64,' + photo);

            if (viewModel.ExpenseDetailID() === 0) {
                handleSave(false, null, 'data:image/jpeg;base64,' + photo);
            }
            else {
                uploadPhoto('data:image/jpeg;base64,' + photo);
            }
        }, function (msg) {
            alert('Failed because: ' + msg);
        }, {
            quality: 50,
            destinationType: Camera.DestinationType.DATA_URL
        });
    }
    var scrollView = {
        //pullDownAction: pullDown
        onPullDown: function (options) {
            pullDown();
            options.component.release();
        }
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
                    if (data.length === 1) {
                        viewModel.divisionCode(data[0].Code);
                    }
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
                    ClientCode: viewModel.clientCode().toString(),
                    DivisionCode: viewModel.divisionCode().toString(),
                    SearchValue: searchVal
                }).done(function (data) {
                    if (data.length === 1) {
                        viewModel.productCode(data[0].Code);
                    }
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
            var reportData = { Description: "New Report", InvoiceNumber: 0 };
            var d = new $.Deferred();
            AdvantageMobile_UI.db.get('GetOpenReports', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode().toString()
            }).done(function (data) {
                viewModel.reportID(viewModel.InvoiceNumber());
                data.unshift(reportData);
                d.resolve(data);
            }).fail(function (error) {

                d.reject(reportData);
                handleDataServiceError(error);
            });
            return d.promise();
        },
        byKey: function (key) {

        },
        map: function (item) {
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
                    AdvantageMobile_UI.db.get('GetJobLogsExpense', {
                        ClientCode: cl.toString(),
                        DivisionCode: div.toString(),
                        ProductCode: prd.toString(),
                        SearchValue: searchValue,
                        Skip: skip,
                        Take: take
                    }).done(function (data) {
                        jobLookupScrolled = false;
                        if (data.length === 1) {
                            viewModel.jobNumber(data[0].JobNumber);
                        }
                        d.resolve(data);
                    }).fail(function (data) {
                        handleDataServiceError(data);
                    })
                }
                , 500);

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
                AdvantageMobile_UI.db.get('GetJobComponentsExpense', {
                    JobNumber: jobNum,
                    SearchValue: searchVal
                }).done(function (data) {
                    if (data.length === 1) {
                        viewModel.jobComponentNumber(data[0].JobComponentNumber);
                    }
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
            //alert(searchVal);
            AdvantageMobile_UI.db.get('LoadAllEmployeeExpenseFunctions', {
                //EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                SearchValue: searchVal
            }).done(function (data) {
                //alert(data);
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
        }
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
        closeOnOutsideClick: true,
        onOpened: function () {
        },
        onPullRefresh: function (e) {
            productsDataSource.load();
        },
        onScroll: function (e) {

        }
    };
    var reportsSelectBox = {
        dataSource: reportsDataSource,
        displayExpr: 'ExpensesDescription',
        valueExpr: 'ReportID',
        value: reportID,
        onValueChanged: onReportChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Report'),
        title: localizeString('Select') + ' ' + localizeString('Report'),
        readOnly: ko.observable(false),
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
        onValueChanged: onFunctionChange,
        placeholder: localizeString('Select') + ' ' + localizeString('Function'),
        title: localizeString('Select') + ' ' + localizeString('Function'),
        readOnly: ko.observable(false),
        visible: ko.observable(true),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };
    var quantityValidator = {
        validationRules: [{
            type: 'numeric',
            message: localizeString('InvalidQuantity')
        }]
    };
    var rateValidator = {
        validationRules: [{
            type: 'numeric',
            message: localizeString('Invalid Rate')
        }]
    };
    var amountValidator = {
        validationRules: [{
            type: 'numeric',
            message: localizeString('Invalid Expense Amount')
        }, {
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
            message: localizeString('Please Enter Report Description')
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
    var clearButton = {
        title: 'Clear',
        id: 'menu-custom1',
        onExecute: function (e) {
            if (viewModel.reportStatusOpen() || viewModel.isNewEntry()) {

                var today = new Date();
                today.setHours(0, 0, 0, 0);

                if (viewModel.isNewEntry()) {
                    viewModel.strDescription(null);
                    viewModel.strDetailsDescription(null);
                    viewModel.reportDate(today)
                }

                viewModel.functionCode(null);
                viewModel.jobComponentNumber(null);
                viewModel.jobNumber(null);
                viewModel.productCode(null);
                viewModel.divisionCode(null);
                viewModel.clientCode(null);
                viewModel.ExpAmount(null);
                viewModel.Rate(null);
                viewModel.Quantity(null);
                viewModel.ccFlag(false);
                viewModel.strExpenseDescription(null);
                viewModel.expDate(today);

            } else {
                AdvantageMobile_UI.Messages.toastWarning("Only open expense reports can be cleared");
            }
        },
        visible: canBeCleared(reportStatusOpen, isNewEntry)
    };

    function CalcNewAmount() {
        if (!isNaN(Rate()) && !isNaN(Quantity()) && firstChange) {
            if (Rate() * Quantity() > 0) {
                toggle();
                ExpAmount((Rate() * Quantity()).toFixed(2));
            }
        }
        else {
            toggle();
        }
    }
    function CalcNewQuantity() {
        if (!isNaN(Rate()) && !isNaN(Quantity()) && firstChange) {
            if (Rate() * Quantity() > 0) {
                toggle();
                Quantity((ExpAmount() / Rate()).toFixed(2));
            }
        }
        else {
            toggle();
        }
    }
    function CalcNewRate() {
        if (!isNaN(ExpAmount()) && !isNaN(Quantity()) && firstChange) {
            if (Rate() * Quantity() > 0) {
                toggle();
                Rate((ExpAmount() / Quantity()).toFixed(2));
            }
        }
        else {
            toggle();
        }
    }
    function onQuantityChanged(e) {
        if (viewShownCompleted) {
            if (Quantity() > 0) {
                if (Rate() > 0) {
                    CalcNewAmount();
                } else if (Amount() > 0) {
                    CalcNewRate();
                }
            }
        }
    }
    function onRateChanged(e) {
        if (viewShownCompleted) {
            if (Rate() > 0) {
                if (Quantity() > 0) {
                    CalcNewAmount();
                } else if (Amount() > 0) {
                    CalcNewQuantity();
                }
            }
        }
    }
    function onAmountChanged(e) {
        if (viewShownCompleted) {
            if (firstChange === true) {
                //Quantity(0);
                //Rate(0);
            } else {
                toggle();
            }
        }
    }
    function toggle() {
        if (firstChange === true) {
            firstChange = false;
        } else {
            firstChange = true;
        }

    }
    function navigating(e) {
        isVisible(true);
    }
    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        }
        else {
            viewShownCompleted = true;
        }
        isVisible(false);
    }
    function viewShowing(e) {
        if (params.settings) {
            if (params.settings.InvoiceNumber > 0) {

                if (params.settings.InvoiceNumber) {
                    viewModel.InvoiceNumber(params.settings.InvoiceNumber);
                    viewModel.reportID(params.settings.InvoiceNumber);
                }
                if (params.settings.ExpenseDetailID) {
                    viewModel.ExpenseDetailID(params.settings.ExpenseDetailID);
                }
                if (viewModel.reportID() > 0) {
                    viewModel.IsNewInvoice(false);
                }
                if (viewModel.reportID() > 0 && viewModel.ExpenseDetailID() === 0) {
                    viewModel.ShowReportSelectBox(false);
                }
                if (viewModel.InvoiceNumber() > 0 && viewModel.ExpenseDetailID() > 0) {
                    GetReportDetail();
                    viewModel.isNewEntry(false);
                    viewModel.ExistingReport(true);
                    expDocumentsDataSource.load();
                }
            } else {
                viewModel.InvoiceNumber(0);
                viewModel.reportID(0);
                //                viewShowingCompleted = true;
                viewModel.reportStatusOpen(true);
                viewModel.reportReadOnly(false);
                viewModel.isNewEntry(true);
                viewModel.ExistingReport(false);
                //clearNewEntry();

            }
        }
        firstChange = true;
        viewShowingCompleted = true;
    }
    //File upload
    function uploadFile(e) {

        if (viewModel.ExpenseDetailID() > 0) {
            if (e && e.value[0]) {
                viewModel.isToastVisible(true);
                var FR = new FileReader();
                var fileInfo = e.value[0];
                var fileName = e.value[0].name;
                var reader = new FileReader();
                reader.onloadend = function (evt) {
                    //console.log("read success");
                    //console.log(evt.target.result);
                    $.ajax({
                        url: AdvantageMobile_UI.CurrentUser.ServicesURL() + "SaveDocument?EmployeeCode=%27" + AdvantageMobile_UI.CurrentUser.EmployeeCode() + "%27&InvoiceNumber=%27" + viewModel.InvoiceNumber().toString() + "%27&ExpenseDetailID=%27" + viewModel.ExpenseDetailID().toString() + "%27&RowID=" + viewModel.RowID() + "&name=%27" + fileName + "%27",
                        type: 'POST',
                        data: encodeURIComponent(evt.target.result),
                        cache: false,
                        dataType: 'json',
                        processData: false, // Don't process the files
                        contentType: "application/octet-stream", // Set content type to false as jQuery will tell the server its a query string request 
                        success: function (data) {
                            console.log(data);
                            pullDown();
                            viewModel.isToastVisible(false);
                        },
                        error: function (data) {
                            var errorMessage = '';
                            if (data && data.status && data.statusText) {
                                errorMessage = data.status + " - " + data.statusText;
                            }
                            AdvantageMobile_UI.Messages.toastError('Upload Failed:  ' + errorMessage);
                            console.log(data)
                            viewModel.isToastVisible(false);
                        }
                    });
                };
                reader.onerror = function (evt) {
                    AdvantageMobile_UI.Messages.toastError('Receipt Upload Failed!');
                    viewModel.isToastVisible(false);
                };
                reader.readAsDataURL(fileInfo);
            }
        }
    }
    function uploadPhoto(picture) {
        viewModel.isToastVisible(true);
        $.ajax({
            url: AdvantageMobile_UI.CurrentUser.ServicesURL() + "SaveDocument?EmployeeCode=%27" + AdvantageMobile_UI.CurrentUser.EmployeeCode() + "%27&InvoiceNumber=%27" + viewModel.InvoiceNumber().toString() + "%27&ExpenseDetailID=%27" + viewModel.ExpenseDetailID().toString() + "%27&RowID=" + viewModel.RowID() + "&name=%27camera%27",
            type: 'POST',
            data: encodeURIComponent(picture),
            cache: false,
            dataType: 'json',
            processData: false, // Don't process the files
            contentType: "application/octet-stream", // Set content type to false as jQuery will tell the server its a query string request 
            success: function (data) {
                //alert('successful..');
                //console.log(data);
                pullDown();
                expDocumentsDataSource.load();
                viewModel.isToastVisible(false);
            },
            error: function (data) {
                //expDocumentsDataSource.load();
                AdvantageMobile_UI.Messages.toastError('Receipt Upload Failed!');
                viewModel.isToastVisible(false);
            }
        });
    }
    function pullDown() {
        if (viewModel.InvoiceNumber() > 0 && viewModel.ExpenseDetailID() > 0) {
            GetReportDetail();
            viewModel.isNewEntry(false);
            viewModel.ExistingReport(true);
            expDocumentsDataSource.load();
        }
        viewShowingCompleted = true;
    }
    expDocumentsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            AdvantageMobile_UI.db.get('GetDocumentsByExpenseDetailID', {
                ExpenseDetailID: viewModel.ExpenseDetailID()
            }).done(function (data) {
                console.log(data)
                d.resolve(data);
                $(function () {
                    $("#tileview").dxTileView({
                        onItemClick: function (info) {
                            AdvantageMobile_UI.app.navigate({
                                view: "expense_documents",
                                settings: {
                                    InvoiceNumber: viewModel.InvoiceNumber(), DocumentID: info.itemData.ID, ExpenseDetailID: viewModel.ExpenseDetailID(), RepositoryFileName: info.itemData.RepositoryFileName, ReportReadOnly: viewModel.reportReadOnly()
                                }
                            });
                        },
                        items: data,
                        itemTemplate: function (itemData, itemIndex, itemElement) {
                            itemElement.append("<img src='data:image/png;base64," + itemData.THUMBNAIL + "'></img>");
                        }
                    });
                });

            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        },
        pageSize: 12,
        visible: ko.observable(true)
    });
    var deleteButton = {
        title: 'Delete',
        id: 'menu-clear',
        onExecute: function (e) {

            var result = DevExpress.ui.dialog.confirm(localizeString("Delete Expense Report"), null);
            result.done(function (dialogResult) {
                if (dialogResult == true) {
                    var prom = $.when(deleteExpenseDetail());
                    prom.done(function (deleteExpenseResponse) {
                        AdvantageMobile_UI.Messages.toastSuccess('Expense Report Deleted!');
                        AdvantageMobile_UI.app.back();
                    });
                };
            });
        },
        visible: reportStatusOpen
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
    var InsertExpenseHeader = function (goBack, fileInfo, photoData) {
        AdvantageMobile_UI.db.get("InsertExpenseHeader", {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ExpenseDate: viewModel.reportDate().toShortDateString(), //change
            Description: viewModel.strDescription(),
            Details: viewModel.strDetailsDescription()
        }).done(function (data) {
            viewModel.reportID(parseInt(data));
            viewModel.InvoiceNumber(parseInt(data));
            InsertExpenseDetail(goBack, fileInfo, photoData);

        }).fail(function (data) {
            handleDataServiceError(data);
        });
    };
    //File upload
    function onFunctionChange(e) {
        if (viewShowingCompleted == true) {
            isFunctionRateBased(e.value);
        }
    }
    function isFunctionRateBased(FunctionID) {
        if (FunctionID !== null) {
            AdvantageMobile_UI.db.get('GetFunctionRate', {
                FunctionCode: FunctionID
            }).done(function (data) {
                if (viewShownCompleted) {
                    viewModel.Rate(data);
                    if (viewModel.Rate() > 0) {
                        ShowRate(true);
                        if (!isNaN(Rate()) && !isNaN(Quantity())) {
                            CalcNewAmount();
                        }
                    } else {
                        viewModel.Rate("");
                        ShowRate(false);
                    }

                }

            }).fail(function (data) {
                handleDataServiceError(data);
            })
        }
    }
    function onClientsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            divisionDSLoaded = false;
            divisionCode(null);
            productCode(null);
            jobNumber(null);
            jobComponentNumber(null);
            viewModel.clientCode(e.value)
            companyCodeTemp = e.value;
            this.divisionsDataSource.load();
        }
    }
    function onDivisionsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            productDSLoaded = false;
            productCode(null);
            jobNumber(null);
            jobComponentNumber(null);
            viewModel.divisionCode(e.value)
            divisionCodeTemp = e.value;
            this.productsDataSource.load();
        }
    }
    function onProductsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            jobDSLoaded = false;
            jobNumber(null);
            jobComponentNumber(null);
            viewModel.productCode(e.value);
            productCodeTemp = e.value;
            this.jobsDataSource.load();
        }
    }
    function onJobsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            jobComponentDSLoaded = false;
            jobComponentNumber(null);
            viewModel.jobNumber(e.value)
            jobCodeTemp = e.value;
            this.jobComponentsDataSource.load();

            //Update company, div and product if job & component was selected only
            if (jobCodeTemp > 0 && (companyCodeTemp === "0" || companyCodeTemp === null)) {
                AdvantageMobile_UI.db.get('GetClientsByJobNumber', {
                    JobNumber: jobCodeTemp
                }).done(function (data) {
                    companyCodeTemp = data.Code.toString();
                }).fail(function (data) {
                    handleDataServiceError(data);
                })

                AdvantageMobile_UI.db.get('GetDivisionsByJobNumber', {
                    JobNumber: jobCodeTemp
                }).done(function (data) {
                    divisionCodeTemp = data.Code.toString();
                }).fail(function (data) {
                    handleDataServiceError(data);
                })

                AdvantageMobile_UI.db.get('GetProductsByJobNumber', {
                    JobNumber: jobCodeTemp
                }).done(function (data) {
                    productCodeTemp = data.Code.toString();
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
            }
        }
    }
    function onReportChange(e) {
        if (viewShowingCompleted == true) {
            reportDSLoaded = false;
            viewModel.reportID(e.value);
            if (viewModel.reportID() > 0) {
                viewModel.IsNewInvoice(false);
            } else {
                viewModel.IsNewInvoice(true);
            }
        }
    }
    function loadJobLookup() {
        var loadOptions = {
            skip: null, take: null, searchValue: null, myVal: "hi"
        }
        jobsDataSource.load(loadOptions);
    }
    function canBeCleared(StatusOpen, NewEntry) {
        if (StatusOpen || NewEntry) {
            return true;
        }
        else {
            return false;
        }
    }
    function GetReportDetail() {
        if (viewModel.InvoiceNumber() > 0) {

            var combinedGetReportPromise = $.when(getExpenseReport(), getExpenseDetail())

            combinedGetReportPromise.done(function (reportData, detailData) {
                viewShowingCompleted = true;
                //if (viewModel.ExpenseDetailID() > 0 && viewModel.DocumentID() > 0) {
                //    GetDocument();
                //}
            });
        }
    }
    function getExpenseReport() {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('GetExpenseReport', {
            InvoiceNumber: viewModel.InvoiceNumber().toString()
        }).done(function (data) {
            viewModel.reportStatusOpen(GetStatus(data.Status, data.IsSubmitted, data.IsApproved) === "Open");
            viewModel.reportReadOnly(GetStatus(data.Status, data.IsSubmitted, data.IsApproved) !== "Open");

            viewModel.reportDate(data.InvoiceDate.toUtcDate());
            viewModel.strDescription(data.Description);
            viewModel.strDetailsDescription(data.DetailsDescription);
            if (GetStatus(data.Status, data.IsSubmitted, data.IsApproved) !== "Open") {
                viewModel.reportCanSave(false);

                viewModel.clientsSelectBox.readOnly(true);
                viewModel.divisionsSelectBox.readOnly(true);
                viewModel.productsSelectBox.readOnly(true);
                viewModel.jobsSelectBox.readOnly(true);
                viewModel.jobComponentsSelectBox.readOnly(true);
                viewModel.functionsSelectBox.readOnly(true);
                viewModel.reportsSelectBox.readOnly(true);


            }

            d.resolve(data);
        }).fail(function (data) {
            handleDataServiceError(data);
        });

        return d.promise();
    }
    function getExpenseDetail() {
        var d = new $.Deferred();
        if (viewModel.ExpenseDetailID() > 0) {
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
                viewModel.expDate(data.ItemDate.toUtcDate());
                viewModel.strExpenseDescription(data.Description);
                viewModel.CcAmount(data.CcAmount);
                viewModel.ExpAmount(data.Amount);
                viewModel.Quantity(data.Quantity);
                viewModel.Rate(data.Rate);
                viewModel.ccFlag(data.CcFlag);
                viewModel.LineNumber(data.LineNumber);
                viewModel.PaymentType(data.PaymentType);
                if (viewModel.Rate() > 0) {
                    ShowRate(true);
                }
                d.resolve(data);
            }).fail(function (data) {
                handleDataServiceError(data);
            });
        } else {
            d.resolve(null);
        }

        return d.promise();

    }
    function AttachExpenseDetail(goBack, fileInfo, photoData) {
        var d = $.Deferred();

        AdvantageMobile_UI.db.get('InsertExpenseDetail', {
            ID: viewModel.ExpenseDetailID(),
            InvoiceNumber: parseInt(viewModel.reportID()),
            LineNumber: 0,  //change  service can handle this with highest line number?
            ItemDate: viewModel.expDate().toShortDateString(),
            Description: viewModel.strExpenseDescription(),
            CcFlag: viewModel.ccFlag(),
            ClientCode: companyCodeTemp.toString(),
            DivisionCode: divisionCodeTemp.toString(),
            ProductCode: productCodeTemp.toString(),
            JobNumber: jobCodeTemp,
            //ClientCode: viewModel.clientCode().toString(),
            //DivisionCode: viewModel.divisionCode().toString(),
            //ProductCode: viewModel.productCode().toString(),
            //JobNumber: viewModel.jobNumber(),
            JobComponentNumber: viewModel.jobComponentNumber(),
            FunctionCode: viewModel.functionCode(),
            Quantity: (viewModel.Quantity() === null) ? 0 : parseInt(viewModel.Quantity().toString()),
            Rate: (viewModel.Rate() !== null) ? viewModel.Rate().toString() : "0",
            CcAmount: (viewModel.CcAmount() !== null) ? viewModel.CcAmount().toString() : "0",
            Amount: viewModel.ExpAmount().toString(),
            ApComment: viewModel.Details().toString(),
            CreatedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedDate: (new Date()).toShortDateString(),
            PaymentType: 0   //change
        }).done(function (data) {
            d.resolve(data);
            if (goBack) AdvantageMobile_UI.Messages.toastSuccess('Expense item added to report!');
            viewModel.InvoiceNumber(parseInt(viewModel.reportID()));
            viewModel.ExpenseDetailID(parseInt(data));
            if (fileInfo != null)
                uploadFile(fileInfo);
            if (photoData != null)
                uploadPhoto(photoData);
            if (goBack) { AdvantageMobile_UI.app.back(); }
            //AdvantageMobile_UI.app.navigate({
            //    view: "expenses_detail",
            //    settings: {
            //        InvoiceNumber: viewModel.InvoiceNumber()
            //    }
            //});
        }).fail(function (data) {

            handleDataServiceError(data);
        });
        return d.promise();
    }
    function InsertExpenseDetail(goBack, fileInfo, photoData) {
        var d = $.Deferred();
        AdvantageMobile_UI.db.get('InsertExpenseDetail', {
            ID: viewModel.ExpenseDetailID(),
            InvoiceNumber: parseInt(viewModel.InvoiceNumber()),
            LineNumber: 0,  //change
            ItemDate: viewModel.expDate().toShortDateString(),
            Description: viewModel.strExpenseDescription(),
            CcFlag: viewModel.ccFlag(),
            ClientCode: companyCodeTemp.toString(),
            DivisionCode: divisionCodeTemp.toString(),
            ProductCode: productCodeTemp.toString(),
            JobNumber: jobCodeTemp,
            JobComponentNumber: viewModel.jobComponentNumber(),
            FunctionCode: viewModel.functionCode(),
            Quantity: (viewModel.Quantity() === null) ? 0 : parseInt(viewModel.Quantity().toString()),
            Rate: (viewModel.Rate() !== null) ? viewModel.Rate().toString() : "0",
            CcAmount: (viewModel.CcAmount() !== null) ? viewModel.CcAmount().toString() : "0",
            Amount: viewModel.ExpAmount().toString(),
            ApComment: viewModel.Details().toString(),
            CreatedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedDate: (new Date()).toShortDateString(),
            PaymentType: 0 //change
        }).done(function (data) {
            d.resolve(data);
            if (goBack) AdvantageMobile_UI.Messages.toastSuccess('Expense Item Created!');
            //viewModel.InvoiceNumber(parseInt(viewModel.reportID()));
            viewModel.ExpenseDetailID(parseInt(data));
            if (fileInfo != null)
                uploadFile(fileInfo);
            if (photoData != null)
                uploadPhoto(photoData);

            if (goBack) { AdvantageMobile_UI.app.back(); }
            //AdvantageMobile_UI.app.navigate({
            //    view: "expenses_detail",
            //    settings: {
            //        InvoiceNumber: viewModel.InvoiceNumber()
            //    }
            //});
        }).fail(function (data) {

            handleDataServiceError(data);
        });
        return d.promise();
    }
    function UpdateExpenseDetail(goBack) {
        var d = $.Deferred();
        ///this doesn't update header in backend code as report screen shouldn't change header info
        AdvantageMobile_UI.db.get('UpdateExpenseDetail', {
            ID: viewModel.ExpenseDetailID(),
            InvoiceNumber: parseInt(viewModel.InvoiceNumber()),
            LineNumber: viewModel.LineNumber(),      //change
            ItemDate: viewModel.expDate().toShortDateString(),
            Description: viewModel.strExpenseDescription(),
            CcFlag: viewModel.ccFlag(),
            ClientCode: companyCodeTemp.toString(),
            DivisionCode: divisionCodeTemp.toString(),
            ProductCode: productCodeTemp.toString(),
            JobNumber: jobCodeTemp,
            JobComponentNumber: viewModel.jobComponentNumber(),
            FunctionCode: viewModel.functionCode(),
            Quantity: (viewModel.Quantity() === null) ? 0 : parseInt(viewModel.Quantity().toString()),
            Rate: (viewModel.Rate() !== null) ? viewModel.Rate().toString() : "0",
            CcAmount: (viewModel.CcAmount() !== null) ? viewModel.CcAmount().toString() : "0",
            Amount: viewModel.ExpAmount().toString(),
            ApComment: viewModel.Details().toString(),
            CreatedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ModifiedDate: (new Date()).toShortDateString(),
            PaymentType: 0
        }).done(function (data) {
            d.resolve(data);
            AdvantageMobile_UI.Messages.toastSuccess('Expense Item Updated!');
            //AdvantageMobile_UI.app.navigate({
            //    view: "expenses_detail",
            //    settings: {
            //        InvoiceNumber: viewModel.InvoiceNumber()
            //    }
            //});
            if (goBack) { AdvantageMobile_UI.app.back(); }

        }).fail(function (data) {

            handleDataServiceError(data);
        });
        return d.promise();
    }
    function validateFields() {
        var validFields = true;

        if (viewModel.reportID() === null) {
            validFields = false;
            AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Report'));
            return;
        }

        if (viewModel.reportID() === 0) {
            if (viewModel.strDescription() === "" || viewModel.strDescription() === null) {
                validFields = false;
                AdvantageMobile_UI.Messages.toastError(localizeString('Please Enter Report Description'));
                return;
            }
            if (!viewModel.reportDate() || viewModel.reportDate().toShortDateString() === "") {    //change datevalidation
                validFields = false;
                AdvantageMobile_UI.Messages.toastError(localizeString('Please Enter Report Date'));
                return;
            }

        }

        if (viewModel.clientCode()) {
            //all 5 fields are required to be filled in if Client is selected
            if (viewModel.clientCode() === null) {
                AdvantageMobile_UI.Messages.toastError(localizeString('Please select all fields'));
                validFields = false;
                return;
            };

            if (viewModel.divisionCode() === null) {
                AdvantageMobile_UI.Messages.toastError(localizeString('Please select all fields'));
                validFields = false;
                return;
            };

            if (viewModel.productCode() === null) {
                AdvantageMobile_UI.Messages.toastError(localizeString('Please select all fields'));
                validFields = false;
                return;
            };

            if (viewModel.jobNumber() === null) {
                AdvantageMobile_UI.Messages.toastError(localizeString('Please select all fields'));
                validFields = false;
                return;
            };

            if (viewModel.jobComponentNumber() === null) {
                AdvantageMobile_UI.Messages.toastError(localizeString('Please select all fields'));
                validFields = false;
                return;
            };

        }

        if (viewModel.jobNumber()) {
            if (viewModel.jobComponentNumber() === null) {
                AdvantageMobile_UI.Messages.toastError(localizeString('Please Select A Component'));
                validFields = false;
                return;
            };
        }

        if (!viewModel.expDate() || viewModel.expDate().toShortDateString() === "") {
            validFields = false;
            AdvantageMobile_UI.Messages.toastError(localizeString('Please Enter Expense Date'));
            return;
        }

        if (viewModel.strExpenseDescription() === null || viewModel.strExpenseDescription() === "") {
            console.log(viewModel.strExpenseDescription())
            validFields = false;
            AdvantageMobile_UI.Messages.toastError(localizeString('Please Enter Expense Description'));
            return;
        }

        if (viewModel.Quantity() === null || viewModel.Quantity() === "") {
            if (isNaN(viewModel.Quantity())) {
                validFields = false;
                AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Quantity'));
                return;
            }
        }

        if (viewModel.Rate() === null || viewModel.Rate() === "") {
            if (isNaN(viewModel.Rate())) {
                validFields = false;
                AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Rate'));
                return;
            }
        }

        if (viewModel.ExpAmount() === null || viewModel.ExpAmount() === "") {
            validFields = false;
            AdvantageMobile_UI.Messages.toastError(localizeString('Please Enter Amount'));
            return;
        }

        if (isNaN(viewModel.ExpAmount())) {
            validFields = false;
            AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Expense Amount'));
            return;
        }

        if (viewModel.functionCode() === null) {
            AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Function'));
            validFields = false;
            return;
        }

        var funcCatCode = viewModel.functionCode();

        if (funcCatCode != null) {
            viewModel.functionCode(funcCatCode);
        }

        return validFields;
    }
    function handleSave(goBack, fileInfo, photoData) {
        if (validateFields()) {

            if (companyCodeTemp === null) {
                companyCodeTemp = "0";
            };
            if (divisionCodeTemp === null) {
                divisionCodeTemp = "0";
            };
            if (productCodeTemp === null) {
                productCodeTemp = "0";
            };


            if (viewModel.jobComponentNumber() === null) {
                viewModel.jobComponentNumber(0);
            };

            if (viewModel.strDetailsDescription() === null) {
                viewModel.strDetailsDescription("");
            };

            if (viewModel.Quantity() === null || viewModel.Quantity() === "") {
                viewModel.Quantity(0);
            }

            if (viewModel.Rate() === null || viewModel.Rate() === "") {
                viewModel.Rate(0);
            }

            if ((viewModel.reportID() === viewModel.InvoiceNumber()) || viewModel.ExpenseDetailID() === 0) {

                if (viewModel.ExpenseDetailID() > 0) {
                    UpdateExpenseDetail(goBack);
                }
                else if (viewModel.ExpenseDetailID() === 0) {
                    if (viewModel.reportID() === 0) {
                        InsertExpenseHeader(goBack, fileInfo, photoData);
                    } else if (viewModel.reportID() > 0) {
                        AttachExpenseDetail(goBack, fileInfo, photoData);
                    }
                }
            } else if (viewModel.ExpenseDetailID() > 0) {

                var combinedPromise = $.when(AttachExpenseDetail(), deleteExpenseDetail());

                combinedPromise.done(function (attachExpenseResponse, detachExpenseResponse) {
                    if (goBack) { AdvantageMobile_UI.app.back(); }
                })
            }
        }
    }
    function deleteExpenseDetail() {
        var d = $.Deferred();
        AdvantageMobile_UI.db.get('DeleteExpenseDetail', {
            ExpenseDetailID: parseInt(viewModel.ExpenseDetailID())
        }).done(function (data) {
            d.resolve(data);

        }).fail(function (data) {

            handleDataServiceError(data);
        });
        return d.promise();
    }
    function GetStatus(statusCode, submitCode, approveCode) {
        if (statusCode === 0 || statusCode === null)
            return "Open";
        else if (statusCode === 2 || approveCode === 2) {
            return "Approved";
        }
        else if (statusCode === 1 && (approveCode === 0 || approveCode === null)) {
            return "Pending"; //This needs to be corrected.
        }
        else if (statusCode === 4) {
            return "Pending";
        }
        else if (statusCode === 1 && approveCode === 1) {
            return "Denied"; //This needs to be corrected.
        }
        else if (statusCode === 5) {
            return "Denied by Accounting";
        }
    }
    var viewModel = {

        isVisible: isVisible,
        scrollView: scrollView,
        pullDown: pullDown,
        ShowReportSelectBox: ShowReportSelectBox,
        IsNewInvoice: isNewInvoice,
        InvoiceNumber: invoiceNumber,
        ExpenseDetailID: expenseDetailID,

        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,

        viewInfo: viewInfo,
        viewShowing: viewShowing,
        viewShown: viewShown,
        isNewEntry: isNewEntry,
        ExistingReport: ExistingReport,
        reportStatusOpen: reportStatusOpen,
        reportReadOnly: reportReadOnly,
        reportCanSave: reportCanSave,
        DocumentID: DocumentID,
        reportID: reportID,
        LineNumber: lineNumber,
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
        expDate: expDate,
        reportDate: reportDate,
        expDateBox: expDateBox,
        reportDateBox: reportDateBox,

        ExpAmount: ExpAmount,
        Quantity: Quantity,
        Rate: Rate,

        quantityValidator: quantityValidator,
        rateValidator: rateValidator,
        reportDateValidator: reportDateValidator,
        expDateValidator: expDateValidator,
        descriptionValidator: descriptionValidator,
        expDescriptionValidator: expDescriptionValidator,
        detailsValidator: detailsValidator,
        amountValidator: amountValidator,
        clearButton: clearButton,
        //copyButton: copyButton,
        deleteButton: deleteButton,
        handleSave: handleSave,
        reportsDataSource: reportsDataSource,
        clientsDataSource: clientsDataSource,
        divisionsDataSource: divisionsDataSource,
        productsDataSource: productsDataSource,
        jobsDataSource: jobsDataSource,
        jobComponentsDataSource: jobComponentsDataSource,
        functionsDataSource: functionsDataSource,
        onFunctionChange: onFunctionChange,
        onClientsChange: onClientsChange,
        onDivisionsChange: onDivisionsChange,
        onProductsChange: onProductsChange,
        onJobsChange: onJobsChange,
        onReportChange: onReportChange,

        Description: Description,
        Details: Details,
        CompanyChargeFlag: {
            value: ccFlag,
            text: "Corporate Credit Card?",
            readOnly: reportReadOnly
        },
        ccFlag: ccFlag,


        strReportDate: strReportDate,
        strDescription: strDescription,
        strDetailsDescription: strDetailsDescription,
        strExpenseDescription: strExpenseDescription,

        //File upload
        selectButtonText: selectButtonText,
        labelText: labelText,
        multiple: multiple,
        values: values,
        accept: accept,
        uploadMode: uploadMode,
        //uploadUrl: uploadUrl,
        onContentReady: onContentReady,
        onValueChanged: onValueChanged,
        onUploaded: onUploaded,
        CcAmount: CcAmount,
        Amount: Amount,
        PaymentType: PaymentType,
        buttonType: ko.observable("normal"),
        isNewReport: isNewReport,
        RowID: RowID,

        //File upload
        expDocumentsDataSource: expDocumentsDataSource,
        onQuantityChanged: onQuantityChanged,
        onRateChanged: onRateChanged,
        onAmountChanged: onAmountChanged,
        ShowRate: ShowRate,
        repoFileName: repoFileName,
        isToastVisible: isToastVisible,
        getPicture: getPicture,
        picture: picture
    };
    return viewModel;
};