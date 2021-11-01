AdvantageMobile_UI.time_entry = function (params, viewInfo) {
    "use strict";
    /*

        params.settings.source = -1, new time entry
        params.settings.source = 0, from alert_list
        params.settings.source = 1, from task_list
        params.settings.source = 2, from time_template_list
        params.settings.source = 3, from time_list
        params.settings.source = 4, from project_list
        params.settings.source = 5, from time_list_week
        params.settings.source = 6, from time_list_month
        params.settings.source = 7, from alert_list assignments
        params.settings.source = 8, from job_list
    */
    /*

    TODO:
    -   Backfill c/d/p/j on selection

    */

    var loadPanelVisible = ko.observable(false);
    var loadPanelMessage = localizeString('Loading');
    var isNewEntry = ko.observable(true);
    var isDirectTime = ko.observable(true);
    var employeeTimeId = ko.observable(0);
    var employeeTimeDetailId = ko.observable(0);
    var timeType = ko.observable('');
    var timeEntryDate = ko.observable(new Date());
    var clientCode = ko.observable(null);
    var divisionCode = ko.observable(null);
    var productCode = ko.observable(null);
    var jobNumber = ko.observable();
    var jobComponentNumber = ko.observable();
    var functionCode = ko.observable(null);
    var categoryCode = ko.observable(null);
    var departmentCode = ko.observable(null);
    var txtHours = ko.observable(null);
    var txtComments = ko.observable(null);
    var alertId = ko.observable(0);
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
    //var departmentDSLoaded = true;
    var isPreFill = true;
    var viewShowingCompleted = false;
    var viewShownCompleted = false;
    var jobLookupScrolled = false;

    function viewShowing() {
        viewShowingCompleted = false;
        viewShownCompleted = false;
        clearForm(true);
        //console.log("params.settings.isPreFill");
        //console.log(params.settings.isPreFill);
        if (params.settings.isPreFill != undefined) {
            isPreFill = params.settings.isPreFill;
            //console.log("set isPreFill to: " + params.settings.isPreFill)
        }
        //console.log("viewShowing");
        //console.log(isPreFill);
        // pass in a key for object type (existing time entry, task with j/c, so we can get rest of data to:
        // pre-load the cdpjc info
        var i = parseInt(params.settings.source);
        switch (i) {
            case -1:  //new time entry
                break;
            case 0:  //pre-fill; get info from alert
                this.alertId(params.settings.alertId);
                this.jobNumber(params.settings.jobNumber);
                this.jobComponentNumber(params.settings.jobComponentNumber);
                if (this.jobNumber() > 0) {
                    prefillFromJobLog();
                } else {
                    this.clientCode(params.settings.clientCode);
                    this.divisionCode(params.settings.divisionCode);
                    this.productCode(params.settings.productCode);
                }
                break;
            case 1: //pre-fill; get info from task
                this.jobNumber(params.settings.jobNumber);
                this.jobComponentNumber(params.settings.jobComponentNumber);
                this.sequenceNumber(params.settings.sequenceNumber);
                if (this.jobNumber() > 0) {
                    prefillFromJobLog();
                }
                break;
            case 2: //pre-fill; get info from time template
                this.employeeTimeTemplateId(params.settings.employeeTimeTemplateId);
                //alert(this.employeeTimeTemplateId());
                if (this.employeeTimeTemplateId() > 0) {
                    prefillFromTimeTemplate();
                }
                break;
            case 3: //load existing time entry
                this.isNewEntry(false);
                this.employeeTimeId(params.settings.employeeTimeId);
                this.employeeTimeDetailId(params.settings.employeeTimeDetailId);
                this.timeType(params.settings.timeType);
                //alert(this.employeeTimeId());
                //alert(this.employeeTimeDetailId());
                //alert(this.timeType());
                if (this.employeeTimeId() > 0 && this.employeeTimeDetailId() > 0) {
                    viewModel.loadTimeEntry();
                }
                break;
            case 4: //pre-fill; get info from project
                this.jobNumber(params.settings.jobNumber);
                this.jobComponentNumber(params.settings.jobComponentNumber);
                if (this.jobNumber() > 0) {
                    prefillFromJobLog();
                }
                break;
            case 7:  //pre-fill; get info from alert
                this.alertId(params.settings.alertId);
                this.jobNumber(params.settings.jobNumber);
                this.jobComponentNumber(params.settings.jobComponentNumber);
                if (this.jobNumber() > 0) {
                    prefillFromJobLog();
                } else {
                    this.clientCode(params.settings.clientCode);
                    this.divisionCode(params.settings.divisionCode);
                    this.productCode(params.settings.productCode);
                }
                break;
            case 8:
                this.jobNumber(params.settings.jobNumber);
                this.jobComponentNumber(params.settings.jobComponentNumber);
                if (this.jobNumber() > 0) {
                    prefillFromJobLog();
                }
        }
        if (i != 3) {
            var dt;
            if (params.settings.date) {
                dt = new Date(params.settings.date);
            } else {
                dt = new Date();
            }
            viewModel.timeEntryDate(dt);
            if (AdvantageMobile_UI.CurrentUser.DepartmentTeamCode() && AdvantageMobile_UI.CurrentUser.DepartmentTeamCode() != null) {
                viewModel.departmentCode(AdvantageMobile_UI.CurrentUser.DepartmentTeamCode());
            }
            if (viewModel.isDirectTime() == true) {
                if (AdvantageMobile_UI.CurrentUser.DefaultFunctionCode() && AdvantageMobile_UI.CurrentUser.DefaultFunctionCode() != null) {
                    viewModel.functionCode(AdvantageMobile_UI.CurrentUser.DefaultFunctionCode());
                }
                functionDSLoaded = false;
            }
        } else {

        }
        if (i != -1 && i != 3) {
            disableEntry(false, false, false, false, false);
        }
        if (i != -1) {
            addNonBillableCommand.visible(false);
            addBillableCommand.visible(false);
            clearCommand.visible(false);
        } else {
            switchBillableNonBillableCommand();
        }
        copyCommand.visible(!this.isNewEntry());
        //departmentDSLoaded = false;
        viewShowingCompleted = true;
    }
    function viewShown(e) {
        viewShownCompleted = true;
        if (isPreFill == false) {
            loadJobLookup();
        }
    }
    function viewDisposing() {
       // console.log("viewDisposing")
    }

    var clientsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
            var skip = loadOptions.skip;
            var take = loadOptions.take;
            var searchVal = "";
            if (loadOptions.searchValue != null) {
                searchVal = loadOptions.searchValue;
            }
            AdvantageMobile_UI.db.get('GetClients', {
                SearchValue: searchVal,
                Skip: skip,
                Take: take
            }).done(function (data) {
                d.resolve(data);
            }).fail(function (data) {
                handleDataServiceError(data);
            });
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
                }
                AdvantageMobile_UI.db.get('GetDivisions', {
                    ClientCode: viewModel.clientCode(),
                    SearchValue: searchVal
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
            }
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
                }
                AdvantageMobile_UI.db.get('GetProducts', {
                    ClientCode: viewModel.clientCode(),
                    DivisionCode: viewModel.divisionCode(),
                    SearchValue: searchVal
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
            }
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
    var jobsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();

            //if (isPreFill == false) {


            var skip = loadOptions.skip;
            var take = loadOptions.take;
            var searchValue = "";
            var cl = "";
            var div = "";
            var prd = "";
            //console.log("jobsDataSource");
            //console.log("myval: " + loadOptions.myVal)
            //console.log(viewModel.clientCode());
            //console.log(viewModel.divisionCode());
            //console.log(viewModel.productCode());
            if (viewModel.clientCode() != undefined) {
                cl = viewModel.clientCode();
            }
            if (viewModel.divisionCode() != undefined) {
                div = viewModel.divisionCode();
            }
            if (viewModel.productCode() != undefined) {
                prd = viewModel.productCode();
            }
            if (loadOptions.searchValue != undefined) {
                searchValue = loadOptions.searchValue;
            }
            try {
                if (skip > 0 && jobLookupScrolled == false) {
                    skip = 0;
                    take = 20;
                }
            } catch (e) {
            }
            //console.log(searchValue)
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
                    });
                }
            , 500);


            //}


            return d.promise();
        },
        byKey: function (key) {
            console.log(key);
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'JobLogs(JobNumber=' + key.toString() + ')');
            }
        },
        map: function (item) {
            //return new AdvantageMobile_UI.JobLogViewModel(item);
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
            }
            if (jobNum > 0) {
                var d = new $.Deferred();
                var searchVal = "";
                if (loadOptions.searchValue != null) {
                    searchVal = loadOptions.searchValue;
                }
                AdvantageMobile_UI.db.get('GetJobComponents', {
                    JobNumber: jobNum,
                    SearchValue: searchVal
                }).done(function (data) {
                    d.resolve(data);
                    jobComponentDSLoaded = true;
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
            }
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
            //return new AdvantageMobile_UI.JobComponentViewModel(item);
            return {
                JobComponentNumber: item.JobComponentNumber,
                Description: item.Description,
                JobComponentNumberAndDescription: item.JobComponentNumber + " - " + item.Description
            };
        }
    });
    var functionsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var searchVal = "";
            if (loadOptions.searchValue != null) {
                searchVal = loadOptions.searchValue;
            }
            AdvantageMobile_UI.db.get('GetFunctionsByEmployeeCode', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                SearchValue: searchVal
            }).done(function (data) {
                d.resolve(data);
            }).fail(function (data) {
                handleDataServiceError(data);
            });
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
    var categoriesDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var searchVal = "";
            if (loadOptions.searchValue != null) {
                searchVal = loadOptions.searchValue;
            }
            AdvantageMobile_UI.db.get('GetTimeCategories', {
                SearchValue: searchVal
            }).done(function (data) {
                d.resolve(data);
                categoryDSLoaded = true;
            })
                .fail(function (data) {
                    handleDataServiceError(data);
                });
            return d.promise();
        },
        byKey: function (key) {
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'TimeCategories(\'' + key.toString() + '\')');
            }
        },
        map: function (item) {
            return new AdvantageMobile_UI.TimeCategoryViewModel(item);
        }
    });
    //var departmentsDataSource = new DevExpress.data.DataSource({
    //    load: function (loadOptions) {
    //        if (departmentDSLoaded == false) {
    //            var d = new $.Deferred();
    //            AdvantageMobile_UI.db.get('GetDepartmentsByEmployeeCode', {
    //                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
    //            }).done(function (data) {
    //                d.resolve(data);
    //                departmentDSLoaded = true;
    //                //alert('departmentsDataSource loaded');
    //            }).fail(function (data) {
    //                handleDataServiceError(data);
    //            })
    //            return d.promise();
    //        };
    //    },
    //    byKey: function (key) {
    //        if (key && key.toString() != '') {
    //            return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'EmployeeDepartmentTeams(EmployeeCode=\'' + AdvantageMobile_UI.CurrentUser.EmployeeCode() + '\',DepartmentTeamCode=\'' + key.toString() + '\')');
    //        }
    //    },
    //    map: function (item) {
    //        return new AdvantageMobile_UI.EmployeeDepartmentTeamViewModel(item);
    //    },
    //});

    var entryDateBox = {
        value: timeEntryDate,
        readOnly: ko.observable(false),
        width: "50%"
    };
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
        onOpened: function() {
            //loadJobLookup();
        },
        onPullRefresh: function (e) {
           // console.log("jobsSelectBox onPullRefresh");
            loadJobLookup();
        },
        onScroll: function (e) {
            jobLookupScrolled = true;
           // console.log("scrolled: " + jobLookupScrolled);
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
    var categoriesSelectBox = {
        dataSource: categoriesDataSource,
        displayExpr: 'Description',
        valueExpr: 'Code',
        value: categoryCode,
        placeholder: localizeString('Select') + ' ' + localizeString('Category'),
        title: localizeString('Select') + ' ' + localizeString('Category'),
        readOnly: ko.observable(false),
        visible: ko.observable(false),
        searchEnabled: true,
        searchTimeout: 1000,
        cleanSearchOnOpening: true,
        closeOnOutsideClick: true
    };
    //var departmentsSelectBox = {
    //    dataSource: departmentsDataSource,
    //    displayExpr: 'Description',
    //    valueExpr: 'DepartmentTeamCode',
    //    value: departmentCode,
    //    placeholder: localizeString('Select') + ' ' + localizeString('Department'),
    //    title: localizeString('Select') + ' ' + localizeString('Department'),
    //    readOnly: ko.observable(false),
    //    visible: ko.observable(true),
    //    searchEnabled: true,
    //    searchTimeout: 1000
    //};
    var hoursNumberBox = {
        width: "50%",
        value: txtHours,
        //placeholder: '0.000'.toTwoDecimalPlaces(),
        min: 0,
        max: 24,
        readOnly: ko.observable(false),
        showSpinButtons: true,
        step: .25
    };
    var commentsTextArea = {
        width: "100%",
        height: 100,
        value: txtComments,
        //placeholder: localizeString('Comments'),
        readOnly: ko.observable(false)
    };

    var addNonBillableCommand = {
        title: 'Add Non Job Time',
        id: 'menu-custom1',
        onExecute: function (e) {
            viewModel.isDirectTime(false);
            setTimeEntry(viewModel.isDirectTime());
            categoryDSLoaded = false;
            categoriesDataSource.load();
            switchBillableNonBillableCommand();
        },
        visible: ko.observable(true)
    };
    var addBillableCommand = {
        title: 'Add Job Time',
        id: 'menu-custom2',
        onExecute: function (e) {
            viewModel.isDirectTime(true);
            setTimeEntry(viewModel.isDirectTime());
            clientDSLoaded = false;
            clientsDataSource.load();
            functionDSLoaded = false;
            functionsDataSource.load();
            switchBillableNonBillableCommand();
        },
        visible: ko.observable(true)
    };
    var copyCommand = {
        title: 'Copy',
        id: 'menu-custom3',
        onExecute: function (e) {
            //alert("CopyCommand")
            //alert(employeeTimeId());
            //alert(employeeTimeDetailId())
            //alert(timeType());
            AdvantageMobile_UI.app.navigate({
                view: "select_date",
                settings: { source: 2, et_id: employeeTimeId(), et_dtl_id: employeeTimeDetailId(), time_type: timeType() }
            });

        },
        visible: ko.observable(true)
    };
    var clearCommand = {
        title: 'Clear',
        id: 'menu-clear',
        onExecute: function (e) {
            jobLookupScrolled = false;
            clearForm(true);
            loadJobLookup();
        },
        visible: ko.observable(true)
    };
    var deleteCommand = {
        title: 'Delete',
        id: 'menu-remove',
        onExecute: function (e) {
            var result = DevExpress.ui.dialog.confirm(localizeString("Are You Sure You Want To Delete"), null);
            result.done(function (dialogResult) {
                if (dialogResult == true) {
                    handleDelete();
                }
            });
        },
        visible: ko.observable(false)
    };
    var cancelCommand = {
        title: 'Cancel',
        id: 'menu-cancel',
        onExecute: function (e) {
            //AdvantageMobile_UI.app.back();
            clearForm(true);
            backToTimeList();
        },
        visible: ko.observable(true)
    };

    function clearForm(resetIDs) {
        if (resetIDs && resetIDs == true) {
            viewModel.employeeTimeId(0);
            viewModel.employeeTimeDetailId(0);
        }
        viewModel.clientCode(null);
        viewModel.divisionCode(null);
        viewModel.productCode(null);
        viewModel.jobNumber(null);
        viewModel.jobComponentNumber(null);
        viewModel.functionCode(null);
        viewModel.categoryCode(null);
        viewModel.txtHours(null);
        viewModel.txtComments(null);
        viewModel.clientsSelectBox.readOnly(false);
        viewModel.divisionsSelectBox.readOnly(false);
        viewModel.productsSelectBox.readOnly(false);
        viewModel.jobsSelectBox.readOnly(false);
        viewModel.jobComponentsSelectBox.readOnly(false);
        viewModel.functionsSelectBox.readOnly(false);
        viewModel.categoriesSelectBox.readOnly(false);
        isPreFill = false;
    }

    function prefillFromJobLog() {
        var entry;
        var j = 0;
        var jc = 0;
        j = viewModel.jobNumber();
        jc = viewModel.jobComponentNumber();
        AdvantageMobile_UI.db.get('GetJobLog', {
            JobNumber: viewModel.jobNumber()
        }).done(function (data) {
            viewModel.jobNumber(j);
            viewModel.jobComponentNumber(jc);
            entry = new AdvantageMobile_UI.JobLogViewModel(data);
            if (!entry) {
                AdvantageMobile_UI.Messages.toastError('Error Loading');
            } else {
                viewModel.clientCode(entry.ClientCode());
                viewModel.divisionCode(entry.DivisionCode());
                viewModel.productCode(entry.ProductCode());
            }
        }).fail(function (data) {
            handleDataServiceError(data);
        });
    }
    function prefillFromTimeTemplate() {
        var entry;
        AdvantageMobile_UI.db.get('GetTimeTemplate', {
            EmployeeTimeTemplateID: viewModel.employeeTimeTemplateId()
        }).done(function (data) {
            entry = new AdvantageMobile_UI.EmployeeTimeTemplateViewModel(data);
            if (!entry) {
                AdvantageMobile_UI.Messages.toastError('Error Loading');
            } else {
                if (entry.JobNumber() != null) {
                    viewModel.jobNumber(entry.JobNumber());
                } else {
                    viewModel.jobNumber(0);
                }
                if (entry.JobComponentNumber() != null) {
                    viewModel.jobComponentNumber(entry.JobComponentNumber());
                } else {
                    viewModel.jobComponentNumber(0);
                }
                if (entry.DepartmentTeamCode() != null) {
                    viewModel.departmentCode(entry.DepartmentTeamCode());
                }

                if (viewModel.jobNumber() > 0) {
                    prefillFromJobLog();
                    viewModel.isDirectTime(true);
                    setTimeEntry(true);
                    if (entry.FunctionCode() != null) {
                        viewModel.functionCode(entry.FunctionCode());
                    }
                    functionDSLoaded = false;
                    functionsDataSource.load();
                }
                if (viewModel.jobNumber() == 0 && viewModel.jobComponentNumber() == 0) {
                    viewModel.isDirectTime(false);
                    setTimeEntry(false);
                    if (entry.FunctionCode() != null) {
                        viewModel.categoryCode(entry.FunctionCode());
                    }
                    categoryDSLoaded = false;
                    categoriesDataSource.load();
                }

                viewModel.txtHours(entry.EmployeeHours());
                viewModel.txtComments(entry.DefaultComment());

            }
        }).fail(function (data) {
            handleDataServiceError(data);
        });
    }

    function switchBillableNonBillableCommand() {
        addNonBillableCommand.visible(viewModel.isDirectTime());
        addBillableCommand.visible(!viewModel.isDirectTime());
    }

    function loadTimeEntry() {
        var entry;
        AdvantageMobile_UI.db.get('GetTimeEntry', {
            EmployeeTimeID: viewModel.employeeTimeId(),
            EmployeeTimeDetailID: viewModel.employeeTimeDetailId()
        }).done(function (data) {
            entry = new AdvantageMobile_UI.TimeEntryViewModel(data);
            if (!entry) {
                AdvantageMobile_UI.Messages.toastError('Error Loading');
            } else {
                var thisTimetype = '';
                thisTimetype = entry.TimeType();
                viewModel.timeType(entry.TimeType());
                viewModel.entryDateBox.readOnly(true);
                //alert(viewModel.timeType());
                if (thisTimetype == 'N') {
                    //alert('non productive');
                    viewModel.isDirectTime(false);
                    setTimeEntry(false);

                    viewModel.categoriesSelectBox.readOnly(true);

                    viewModel.categoryCode(entry.FunctionCategory());
                    categoryDSLoaded = false;
                    categoriesDataSource.load();

                } else if (thisTimetype == 'D') {
                    //alert('direct');
                    viewModel.isDirectTime(true);
                    setTimeEntry(true);
                    viewModel.clientCode(entry.ClientCode());
                    viewModel.divisionCode(entry.DivisionCode());
                    viewModel.productCode(entry.ProductCode());
                    viewModel.jobNumber(entry.JobNumber());
                    viewModel.jobComponentNumber(entry.JobComponentNumber());

                    viewModel.functionCode(entry.FunctionCategory());
                    functionDSLoaded = false;
                    functionsDataSource.load();

                    if (viewModel.jobNumber() > 0) {
                        prefillFromJobLog();
                    }

                    viewModel.clientsSelectBox.readOnly(true);
                    viewModel.divisionsSelectBox.readOnly(true);
                    viewModel.productsSelectBox.readOnly(true);
                    viewModel.jobsSelectBox.readOnly(true);
                    viewModel.jobComponentsSelectBox.readOnly(true);
                    viewModel.functionsSelectBox.readOnly(true);

                }

                viewModel.timeEntryDate(entry.EmployeeDate().toUtcDate());
                viewModel.txtHours(entry.EmployeeHours().toTwoDecimalPlaces());
                viewModel.txtComments(entry.Comments());
                viewModel.departmentCode(entry.DepartmentTeamCode());
                //viewModel.departmentsSelectBox.readOnly(true);

                var ppClosed = false;
                var procCtrlNoEdit = false;
                var hasStopwatch = false;
                var isDenied = false;
                var isEdit = false;
                var canEdit = true;
                var canDelete = false;

                if (entry.CannotEditDueToProcessControl() == 1) {
                    setHeaderMessage("Cannot Edit Due To Job Processing Control");
                    canEdit = false;
                    procCtrlNoEdit = true;
                }
                if (entry.IsDenied() == true) {
                    viewModel.headerMessage(localizeString('Day Is Denied'));
                    warningBlockCSS("message-block");
                    isDenied = true;
                }
                if (entry.IsApproved() == true) {
                    setHeaderMessage("Day Is Approved");
                    canEdit = false;
                }
                if (entry.IsPendingApproval() == true) {
                    setHeaderMessage("Day Is Pending");
                    canEdit = false;
                }
                if (entry.IsPostPeriodClosed() == true) {
                    setHeaderMessage("Post Period Is Closed");
                    canEdit = false;
                    ppClosed = true;
                }
                if (entry.HasStopwatch() != undefined && entry.HasStopwatch > 0) {
                    hasStopwatch = true;
                }
                if (entry.EditFlag() != undefined) {
                    switch (entry.EditFlag()) {
                        case 0:
                            isEdit = true;
                            break;
                        case 1:
                            setHeaderMessage("Entry Billed");
                            canEdit = false;
                            break;
                        case 2:
                            setHeaderMessage("Entry Summarized");
                            canEdit = false;
                            break;
                        case 3:
                            setHeaderMessage("Entry Restricted AB Flag");
                            canEdit = false;
                            break;
                        case 4:
                            setHeaderMessage("entry Selected For Billing");
                            canEdit = false;
                            break;
                    }
                }
                if (canEdit == false) {
                    viewModel.hoursNumberBox.readOnly(true);
                    viewModel.commentsTextArea.readOnly(true);
                }
                if (ppClosed == false && procCtrlNoEdit == false && hasStopwatch == false) {
                    if (isEdit == true || isDenied == true) {
                        canDelete = true;
                    }
                }
                if (hasStopwatch == false && entry.EmployeeHours() == 0) {
                    canDelete = true;
                }
                if (canEdit == false) {
                    canDelete = false;
                }
                viewModel.deleteCommand.visible(canDelete);
                //if (canDelete == true) {
                //    viewModel.deleteCommand.visible(true);
                //};
            }
        }).fail(function (data) {
            handleDataServiceError(data);
        });
    }
    function setHeaderMessage(localizedMessageCode) {
        viewModel.headerMessage(localizeString(localizedMessageCode));
        warningBlockCSS("message-block");
    }
    function disableEntry(disableDate, disableFunctionCategory, disableDepartmentTeam, disableHours, disableComments) {
        viewModel.entryDateBox.readOnly(disableDate);
        viewModel.clientsSelectBox.readOnly(true);
        viewModel.divisionsSelectBox.readOnly(true);
        viewModel.productsSelectBox.readOnly(true);
        viewModel.jobsSelectBox.readOnly(true);
        viewModel.jobComponentsSelectBox.readOnly(true);
        viewModel.functionsSelectBox.readOnly(disableFunctionCategory);
        viewModel.categoriesSelectBox.readOnly(disableFunctionCategory);
        //viewModel.departmentsSelectBox.readOnly(disableDepartmentTeam);
        viewModel.hoursNumberBox.readOnly(disableHours);
        viewModel.commentsTextArea.readOnly(disableComments);
    }
    function setTimeEntry(isDirectTime) {
        clearForm(false);
        viewModel.clientsSelectBox.visible(isDirectTime);
        viewModel.divisionsSelectBox.visible(isDirectTime);
        viewModel.productsSelectBox.visible(isDirectTime);
        viewModel.jobsSelectBox.visible(isDirectTime);
        viewModel.jobComponentsSelectBox.visible(isDirectTime);
        viewModel.functionsSelectBox.visible(isDirectTime);
        viewModel.categoriesSelectBox.visible(!isDirectTime);
    }

    function onClientsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            //console.log("onClientsChange");
            //console.log(isPreFill);
            divisionDSLoaded = false;
            viewModel.clientCode(e.value);
            divisionCode(null);
            productCode(null);
            this.divisionsDataSource.load();
            //console.log(viewModel.clearCommand.visible());
            if (isPreFill == false && viewShownCompleted == true) {
                jobNumber(null);
                jobComponentNumber(null);
                loadJobLookup();
            }
        }
    }
    function onDivisionsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            //console.log("onDivisionsChange");
            //console.log(isPreFill);
            productDSLoaded = false;
            viewModel.divisionCode(e.value);
            productCode(null);
            this.productsDataSource.load();
            //console.log(viewModel.clearCommand.visible());
            if (isPreFill == false && viewShownCompleted == true) {
                jobNumber(null);
                jobComponentNumber(null);
                loadJobLookup();
            }
        }
    }
    function onProductsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            //console.log("onProductsChange");
            //console.log(isPreFill);
            jobDSLoaded = false;
            viewModel.productCode(e.value);
            //console.log(viewModel.clearCommand.visible());
            if (isPreFill == false && viewShownCompleted == true) {
                jobNumber(null);
                jobComponentNumber(null);
                loadJobLookup();
            }
        }
    }
    function onJobsChange(e) {
        jobLookupScrolled = false;
        if (viewShowingCompleted == true) {
            //console.log("onJobsChange");
            //console.log(isPreFill);
            jobComponentDSLoaded = false;
            viewModel.jobNumber(e.value);
            //console.log(viewModel.clearCommand.visible());
            if (isPreFill == false && viewShownCompleted == true) {
                jobComponentNumber(null);
                this.jobComponentsDataSource.load();
            }
        }
    }

    function loadJobLookup() {
        var loadOptions = { skip: null, take: null, searchValue: null, myVal: "hi" };
        jobsDataSource.load(loadOptions);
    }

    function handleSave() {
        if (isNaN(this.txtHours()) || this.txtHours() > 24) {
            AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Hours'));
        } else {
            var funcCatCode = '';
            if (viewModel.isDirectTime() == true) {
                funcCatCode = this.functionCode();
            } else {
                funcCatCode = this.categoryCode();
            }
            if (this.jobNumber() == null) {
                this.jobNumber(0);
            }
            if (this.jobComponentNumber() == null) {
                this.jobComponentNumber(0);
            }
            if (this.txtComments() == null) {
                this.txtComments("");
            }
            if (viewModel.isDirectTime() == true) {
                if (this.jobNumber() == 0) {
                    AdvantageMobile_UI.Messages.toastError(localizeString('Please Select A Job'));
                    return false;
                }
                if (this.jobComponentNumber() == 0) {
                    AdvantageMobile_UI.Messages.toastError(localizeString('Please Select A Component'));
                    return false;
                }
           }
            if (!funcCatCode || funcCatCode == "") {
                if (viewModel.isDirectTime() == true) {
                    AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Category'));
                } else {
                    AdvantageMobile_UI.Messages.toastError(localizeString('Invalid Function'));
                }
                return;
            }
            //alert(this.alertId())
            //alert(AdvantageMobile_UI.CurrentUser.UserCode())
            AdvantageMobile_UI.db.get('SaveTimeEntry', {
                EmployeeTimeID: employeeTimeId(),
                EmployeeTimeDetailID: employeeTimeDetailId(),
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                EmployeeDate: timeEntryDate().toShortDateString(),
                FunctionOrCategory: funcCatCode,
                EmployeeHours: '' + this.txtHours() + '',
                JobNumber: this.jobNumber(),
                JobComponentNumber: this.jobComponentNumber(),
                DepartmentTeam: this.departmentCode(),
                ProductCategory: '',
                UserID: AdvantageMobile_UI.CurrentUser.UserCode(),
                Comments: this.txtComments(),
                AlertID: this.alertId(),
                TaskSequenceNumber: this.sequenceNumber()
            }).done(function (data) {
                var SaveTimeEntryResult = new AdvantageMobile_UI.SaveTimeEntryResultViewModel(data);
                employeeTimeId(SaveTimeEntryResult.EmployeeTimeID());
                employeeTimeDetailId(SaveTimeEntryResult.EmployeeTimeDetailID());
                if (employeeTimeId() > 0 && employeeTimeDetailId() > 0) {
                    //viewModel.loadTimeEntry();
                    switch (SaveTimeEntryResult.ErrorCode()) {
                        case -15:
                            AdvantageMobile_UI.Messages.toastWarning(SaveTimeEntryResult.WarningMessage());
                            backToTimeList();
                            break;
                        case -16:
                            AdvantageMobile_UI.Messages.toastFail(SaveTimeEntryResult.WarningMessage());
                            break;
                        case -17:
                            AdvantageMobile_UI.Messages.toastFail(SaveTimeEntryResult.WarningMessage());
                            break;
                        default:
                            AdvantageMobile_UI.Messages.toastSuccess();
                            backToTimeList();
                    }
                } else {
                    AdvantageMobile_UI.Messages.toastError(localizeString('Save Failed') + ":  " + SaveTimeEntryResult.Message());
                }
            }).fail(function (data) {
                handleDataServiceError(data);
            });

        }
    }
    function backToTimeList() {
        var viewToGo = "time_list";
        var source = 0;
        switch (params.settings.source) {
            case 0:
                viewToGo = "alert_list";
                source = 1;
                break;
            case 1:
                viewToGo = "task_list";
                break;
            case 2:
                viewToGo = "time_template_list";
                break;
            case 3:
                viewToGo = "time_list";
                break;
            case 4:
                viewToGo = "project_list";
                break;
            case 5:
                viewToGo = "time_list_week";
                break;
            case 6:
                viewToGo = "time_list_month";
                break;
            case 7:
                viewToGo = "alert_list";
                source = 0;
                break;
            case 8:
                viewToGo = "job_list";
                break;
            default:
                viewToGo = "time_list";
                break;
        }
        clearForm(true);
        jobsSelectBox.dataSource = null;
        loadJobLookup();
        AdvantageMobile_UI.app.navigate({
            view: viewToGo,
            settings: { source: source, date: timeEntryDate().toShortDateString(), viewBy: 0 }
        }, { target: "current", root: false }); // root: true
        //AdvantageMobile_UI.app.navigate(viewInfo.previousViewInfo.uri, { target: "current" });

    }
    function handleDelete() {
        AdvantageMobile_UI.db.get('DeleteTimeEntry', {
            EmployeeTimeID: viewModel.employeeTimeId(),
            EmployeeTimeDetailID: viewModel.employeeTimeDetailId(),
            TimeType: viewModel.timeType()
        }).done(function (data) {
            if (data.indexOf("Success") > -1) {
                AdvantageMobile_UI.Messages.toastSuccess();
                backToTimeList();
            } else {
                AdvantageMobile_UI.Messages.toastError(localizeString('Delete Failed') + ":  " + data);
            }
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        ;
    }

    var viewModel = {
        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,
        addNonBillableCommand: addNonBillableCommand,
        addBillableCommand: addBillableCommand,
        copyCommand: copyCommand,
        cancelCommand: cancelCommand,
        clearCommand: clearCommand,
        deleteCommand: deleteCommand,
        viewShowing: viewShowing,
        viewShown: viewShown,
        viewDisposing: viewDisposing,
        isNewEntry: isNewEntry,
        isDirectTime: isDirectTime,
        headerMessage: headerMessage,
        employeeTimeId: employeeTimeId,
        employeeTimeDetailId: employeeTimeDetailId,
        timeType: timeType,
        timeEntryDate: timeEntryDate,
        clientCode: clientCode,
        divisionCode: divisionCode,
        productCode: productCode,
        jobNumber: jobNumber,
        jobComponentNumber: jobComponentNumber,
        functionCode: functionCode,
        categoryCode: categoryCode,
        departmentCode: departmentCode,
        txtHours: txtHours,
        txtComments: txtComments,
        alertId: alertId,
        sequenceNumber: sequenceNumber,
        employeeTimeTemplateId: employeeTimeTemplateId,
        clientsDataSource: clientsDataSource,
        divisionsDataSource: divisionsDataSource,
        productsDataSource: productsDataSource,
        jobsDataSource: jobsDataSource,
        jobComponentsDataSource: jobComponentsDataSource,
        functionsDataSource: functionsDataSource,
        categoriesDataSource: categoriesDataSource,
        //departmentsDataSource: departmentsDataSource,
        onClientsChange: onClientsChange,
        onDivisionsChange: onDivisionsChange,
        onProductsChange: onProductsChange,
        onJobsChange: onJobsChange,
        entryDateBox: entryDateBox,
        clientsSelectBox: clientsSelectBox,
        divisionsSelectBox: divisionsSelectBox,
        productsSelectBox: productsSelectBox,
        jobsSelectBox: jobsSelectBox,
        jobComponentsSelectBox: jobComponentsSelectBox,
        functionsSelectBox: functionsSelectBox,
        categoriesSelectBox: categoriesSelectBox,
        //departmentsSelectBox: departmentsSelectBox,
        hoursNumberBox: hoursNumberBox,
        commentsTextArea: commentsTextArea,
        handleSave: handleSave,
        loadTimeEntry: loadTimeEntry,
        handleDelete: handleDelete,
        warningBlockCSS: warningBlockCSS
    };

    return viewModel;

};