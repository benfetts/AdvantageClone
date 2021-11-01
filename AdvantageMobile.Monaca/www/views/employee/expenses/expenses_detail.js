AdvantageMobile_UI.expenses_detail = function (params, viewInfo) {
    "use strict";

    var InvoiceNumber = ko.observable("");
    var InvoiceAmount = ko.observable();
    var ExpenseAmount = ko.observable();
    var DetailsDescription = ko.observable("");
    var expensesApprovalStatus = ko.observable("");
    var Title = ko.observable("");
    var HeaderInfo = ko.observable("");
    var InvoiceDate = ko.observable("");
    var expApprovalNotes = ko.observable("");
    var reportStatusOpen = ko.observable(false);
    var reportReadOnly = ko.observable(false);
    var HasApprovalNotes = ko.observable(false);
    var scrollView = {
        //pullDownAction: pullDown
        onPullDown: function (options) {
            pullDown();
            options.component.release();
        }
    }
    var dataLoaded = false;

    function pullDown() {
        console.log("pullDown");
        dataLoaded = false;
        expDetailDataSource.load();
    }
    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        }
    }
    function viewShowing(e) {
        if (params.settings && params.settings.InvoiceNumber) {
            viewModel.InvoiceNumber(params.settings.InvoiceNumber);
            loadExpenseHeader();
            loadTotalExpenseAmount();
            loadTotalInvoiceAmount();
            //expDetailDataSource.load();
        }
    }

    var resetSkip = false;
    var needLoad = false;
    var expDetailDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
                console.log("load ds!");
                var invNum;
                var d = new $.Deferred();
                if (viewModel.InvoiceNumber() !== "") {
                    invNum = viewModel.InvoiceNumber();
                }
                else {
                    invNum = viewInfo.routeData.settings.InvoiceNumber;
                }
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                if (viewModel.expenseDetailList.dataSource.pageIndex() != 0 && resetSkip == true) {
                    skip = 0;
                    loadOptions.skip = 0;
                    take = take * viewModel.expenseDetailList.dataSource.pageIndex();
                    loadOptions.take = take;
                };
                AdvantageMobile_UI.db.get('GetExpenseItems', {
                    InvoiceNumber: invNum.toString(),
                    filter: filterOptions,
                    sort: sortOptions,
                    skip: skip,
                    take: take
                }).done(function (data) {
                    d.resolve(data);
                    if (resetSkip == true) {
                        //
                    } else {
                        loadOptions.take = expenseDetailList.dataSource.pageSize;
                    }
                    resetSkip = false;
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
        },
        pageSize: 200,
        map: function (item) {
            return {
                ApComment: item.ApComment,
                Amount: '$ ' + item.Amount,
                dbAmountValue: item.Amount,
                CcAmount: item.CcAmount,
                CcFlag: item.CcFlag,
                ClientCode: item.ClientCode,
                CreatedBy: item.CreatedBy,
                Description: item.Description,
                DivisionCode: item.DivisionCode,
                FunctionCode: item.FunctionCode,
                ID: item.ID,
                InvoiceNumber: item.InvoiceNumber,
                ItemDate: (item.ItemDate !== null) ? item.ItemDate.toShortDateString() : null,
                JobComponentNumber: item.JobComponentNumber,
                JobNumber: item.JobNumber,
                LineNumber: item.LineNumber,
                ModifiedBy: item.ModifiedBy,
                ModifiedDate: item.ModifiedDate,
                PaymentType: item.PaymentType,
                ProductCode: item.ProductCode,
                Quantity: item.Quantity,
                Rate: item.Rate
            }
        }
    });

    var expenseDetailList = {
        dataSource: expDetailDataSource,
        rendered: ko.observable(true),
        pullRefreshEnabled: true,
        paginate: false,
        scrollingEnabled: false,
        pageLoadMode: "scrollBottom",
        onItemClick: function (e) {
            if (e.itemData && e.itemData.ID) {
                NavigateToExpenseDetail(e.itemData.ID);
            } else {
                AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            }
        },
        onContentReady: function (e) {
        }
    };

    function loadExpenseHeader() {
        AdvantageMobile_UI.db.get('GetExpenseReport', {
            InvoiceNumber: viewModel.InvoiceNumber().toString()
        }).done(function (data) {
            if (data) {
                viewModel.DetailsDescription(data.DetailsDescription);
                viewModel.Title(data.Description);
                viewModel.HeaderInfo(data.Description);
                viewModel.InvoiceDate(data.InvoiceDate.toShortDateString());
                viewModel.reportStatusOpen(GetStatus(data.Status, data.IsSubmitted, data.IsApproved) === "Open");
                viewModel.reportReadOnly(GetStatus(data.Status, data.IsSubmitted, data.IsApproved) !== "Open");
                viewModel.expensesApprovalStatus(GetStatus(data.Status, data.IsSubmitted, data.IsApproved));
                viewModel.expApprovalNotes(data.ApprovalNotes);
                (data.ApprovalNotes) ? viewModel.HasApprovalNotes(true) : viewModel.HasApprovalNotes(false);
            }
        }).fail(function (data) {
            handleDataServiceError(data);
        })
    }
    function loadTotalExpenseAmount() {
        AdvantageMobile_UI.db.get('GetTotalExpenseAmount', {
                InvoiceNumber: viewModel.InvoiceNumber()
        }).done(function (data) {
            viewModel.ExpenseAmount(localizeString("$") + ' ' + formatNumber(data));

        }).fail(function (data) {
            handleDataServiceError(data);
        })
    }
    function loadTotalInvoiceAmount() {
        AdvantageMobile_UI.db.get('GetTotalInvoiceAmount', {
            InvoiceNumber: viewModel.InvoiceNumber()
        }).done(function (data) {
            viewModel.InvoiceAmount(localizeString("$") + ' ' + formatNumber(data));

        }).fail(function (data) {
            handleDataServiceError(data);
        })
    }
    function formatNumber(num) {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")
    }

    function NavigateToExpenseHeaderEdit() {
        AdvantageMobile_UI.app.navigate({
            view: "expense_header_edit",
            settings: { InvoiceNumber: viewModel.InvoiceNumber() }
        });

    }
    var addButton = {
        title: 'Add',
        id: 'create',
        icon: 'plus',
        onExecute: function (e) {
            addExpense();
        },
        visible: reportStatusOpen
    };
    var submitButton = {
        title: 'Submit',
        id: 'menu-custom2',
        onExecute: function (e) {
            //console.log("INVOICE NUMBER!", viewModel.InvoiceNumber());
            AdvantageMobile_UI.app.navigate({
                view: "submit_options",
                settings: { invoiceNumber: viewModel.InvoiceNumber(), from: 0 }
            });
            //AdvantageMobile_UI.db.get('SubmitExpenseReport', {
            //    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            //    InvoiceNumber: viewModel.InvoiceNumber()
            //}).done(function (data) {
            //    if (data === "Successfully submitted expense report.") {
            //        AdvantageMobile_UI.Messages.toastSuccess('Expense Report Submitted!');
            //        loadExpenseHeader();
            //    }
            //    else {
            //        AdvantageMobile_UI.Messages.toastWarning(data);
            //    }
            //}).fail(function (data) {
            //    handleDataServiceError(data);
            //});
        },
        visible: reportStatusOpen
    };
    var UnsubmitButton = {
        title: 'UnSubmit',
        id: 'menu-custom3',
        onExecute: function (e) {
            AdvantageMobile_UI.db.get('UnSubmitExpenseReport', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                InvoiceNumber: viewModel.InvoiceNumber()
            }).done(function (data) {
                if (data === "Successfully unsubmitted expense report.") {
                    AdvantageMobile_UI.Messages.toastSuccess('Expense Report Unsubmitted!');
                    loadExpenseHeader();
                }
                else {
                    AdvantageMobile_UI.Messages.toastWarning(data);
                }
            }).fail(function (data) {
                handleDataServiceError(data);
            })
        },
        visible: reportReadOnly
    };

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

    function NavigateToExpenseDetail(ID) {
        AdvantageMobile_UI.app.navigate({
            view: "expenses_report",
            settings: { InvoiceNumber: viewModel.InvoiceNumber(), ExpenseDetailID: ID }
        });
    };

    var addExpense = function (e) {
        AdvantageMobile_UI.app.navigate({
            view: "expenses_report", settings: { InvoiceNumber: viewModel.InvoiceNumber(), ExpenseDetailID: 0 }
        });
    };

    var copyButton = {
        title: 'Copy',
        id: 'menu-custom1',
        onExecute: function (e) {
            var result = DevExpress.ui.dialog.confirm(localizeString("Copy expense report"), null);
            result.done(function (dialogResult) {
                if (dialogResult == true) {
                    copyExpenseReport();
                }
            });
        },
        visible: true
    };

    var copyExpenseReport = function () {
        AdvantageMobile_UI.db.get('CopyExpenseReport', {
            InvoiceNumber: viewModel.InvoiceNumber(),
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ReportDate: (new Date()).toDateString(),
            Description: viewModel.Title() + ' - Copy',
            Details: viewModel.DetailsDescription()

        }).done(function (data) {
            dataLoaded = false;
            viewModel.InvoiceNumber(data);
            loadExpenseHeader();
            expDetailDataSource.load();
            AdvantageMobile_UI.Messages.toastSuccess(localizeString("Copy Created"));
        }).fail(function (data) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Copy Failed"));
            handleDataServiceError(data);
        });
    };
    var deleteButton = {
        title: 'Delete',
        id: 'menu-clear',
        onExecute: function (e) {
            var result = DevExpress.ui.dialog.confirm(localizeString("Delete Expense Report"), null);
            result.done(function (dialogResult) {
                if (dialogResult == true) {
                    deleteExpense();
                };
            });
        },
        visible: reportStatusOpen
    };
    var deleteExpense = function (e) {
        AdvantageMobile_UI.db.get('DeleteExpenseHeader', {
            InvoiceNumber: parseInt(viewModel.InvoiceNumber())
        }).done(function (data) {
            AdvantageMobile_UI.Messages.toastSuccess('Expense Report Deleted!');
            AdvantageMobile_UI.app.navigate({
                view: 'expenses_summary',
                settings: {}
            });
        }).fail(function (data) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Delete Expense Report Failed!"));
            handleDataServiceError(data);
        });
    };
    var copyExpenseDetailEvent = function (inlineData) {
        inlineData.jQueryEvent.stopPropagation();
        var result = DevExpress.ui.dialog.confirm(localizeString("Copy item"), null);
        result.done(function (dialogResult) {
            if (dialogResult == true) {
                var d = $.Deferred();

                AdvantageMobile_UI.db.get('CopyExpenseReportDetail', {
                    ExpenseDetailID: inlineData.model.ID.toString(),
                    InvoiceNumber: viewModel.InvoiceNumber().toString(),
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode().toString()

                //AdvantageMobile_UI.db.get('InsertExpenseDetail', {
                //    ID: 0,
                //    InvoiceNumber: parseInt(viewModel.InvoiceNumber()),
                //    LineNumber: 0,
                //    ItemDate: inlineData.model.ItemDate, // expense date can be any 
                //    Description: inlineData.model.Description,
                //    CcFlag: inlineData.model.CcFlag,
                //    ClientCode: (inlineData.model.ClientCode === null) ? "0" : inlineData.model.ClientCode,
                //    DivisionCode: (inlineData.model.DivisionCode === null) ? "0" : inlineData.model.DivisionCode,
                //    ProductCode: (inlineData.model.ProductCode === null) ? "0" : inlineData.model.ProductCode,
                //    JobNumber: (inlineData.model.JobNumber === null) ? 0 : inlineData.model.JobNumber,
                //    JobComponentNumber: (inlineData.model.JobComponentNumber === null) ? 0 : inlineData.model.JobComponentNumber,
                //    FunctionCode: inlineData.model.FunctionCode,
                //    Quantity: (inlineData.model.Quantity === null) ? 0 : inlineData.model.Quantity,
                //    Rate: (inlineData.model.Rate !== null) ? inlineData.model.Rate.toString() : "0",
                //    CcAmount:(inlineData.model.CcAmount !== null) ? inlineData.model.CcAmount.toString() : "0",
                //    Amount: inlineData.model.dbAmountValue,
                //    ApComment: (inlineData.model.ApComment===null ) ? "" : inlineData.model.ApComment,
                //    CreatedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                //    ModifiedBy: AdvantageMobile_UI.CurrentUser.EmployeeCode(), //service should ignore as its new value
                //    ModifiedDate: (new Date()).toShortDateString(), //service should ignore as its new value
                //    PaymentType: 0      //service should ignore as its related to approval chain
                }).done(function (data) {
                    d.resolve(data);
                    dataLoaded = false;
                    expDetailDataSource.load();
                    loadTotalInvoiceAmount();
                    loadTotalExpenseAmount();
                    AdvantageMobile_UI.Messages.toastSuccess(localizeString("Expense Item Copy Created!"));
                }).fail(function (data) {
                    d.reject(data);
                    AdvantageMobile_UI.Messages.toastWarning(localizeString("Expense Item Copy Failed!"));
                    handleDataServiceError(data);
                });
                return d.promise();

            };
        });
    };
    var deleteExpenseDetailEvent = function (e) {
        e.jQueryEvent.stopPropagation();
        var result = DevExpress.ui.dialog.confirm(localizeString("Delete Expense Item"), null);
        result.done(function (dialogResult) {
            if (dialogResult == true) {
                deleteExpenseDetail(e.model.ID);
            };
        });
    };

    function deleteExpenseDetail(ExpenseDetail_ID) {
        var d = $.Deferred();
        AdvantageMobile_UI.db.get('DeleteExpenseDetail', {
            ExpenseDetailID: parseInt(ExpenseDetail_ID)
        }).done(function (data) {
            d.resolve(data);
            dataLoaded = false;
            expDetailDataSource.load();
            loadTotalInvoiceAmount();
            loadTotalExpenseAmount
        }).fail(function (data) {

            handleDataServiceError(data);
        });
        return d.promise();
    }

    var viewModel = {
        scrollView: scrollView,
        viewShowing: viewShowing,
        viewShown: viewShown,
        viewInfo: viewInfo,
        pullDown: pullDown,
        NavigateToExpenseHeaderEdit: NavigateToExpenseHeaderEdit,
        InvoiceNumber: InvoiceNumber,
        expenseDetailList: expenseDetailList,
        copyButton: copyButton,
        deleteButton: deleteButton,
        addButton: addButton,
        UnsubmitButton: UnsubmitButton,
        submitButton: submitButton,
        reportStatusOpen: reportStatusOpen,
        reportReadOnly: reportReadOnly,
        expDetailTitleBox: {
            direction: "row",
            width: "100%",
            height: 55
        },
        InvoiceAmount: InvoiceAmount,
        ExpenseAmount: ExpenseAmount,
        DetailsDescription: DetailsDescription,
        Title: Title,
        HeaderInfo: HeaderInfo,
        InvoiceDate: InvoiceDate,
        expDetailDataSource: expDetailDataSource,
        expensesApprovalStatus: expensesApprovalStatus,
        expApprovalNotes: expApprovalNotes,
        CopyExpenseDetailEvent: copyExpenseDetailEvent,
        DeleteExpenseDetailEvent: deleteExpenseDetailEvent,
        HasApprovalNotes: HasApprovalNotes
    };

    return viewModel;
};