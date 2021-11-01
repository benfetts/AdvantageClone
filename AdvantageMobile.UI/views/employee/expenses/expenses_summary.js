AdvantageMobile_UI.expenses_summary = function (params, viewInfo) {
    "use strict";
    var deniedAmount = ko.observable();
    var openAmount = ko.observable();
    var pendingAmount = ko.observable();
    var dataSourceLoaded = false;
    var scrollView = {
        //pullDownAction: pullDown
        onPullDown: function (options) {
            pullDown();
            options.component.release();
        }
    };
    function pullDown() {
        loadAll();
    }
    function loadAll() {
        dataSourceLoaded = false;
        expSummaryDataSource.load();
        loadPending();
        loadOpen();
        loadDenied();
        //console.log("loadAll");
    }
    var expSummaryDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            if (AdvantageMobile_UI.CurrentUser.EmployeeCode() != undefined && dataSourceLoaded == false) {
                var d = new $.Deferred();
                AdvantageMobile_UI.db.get('GetExpenses', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                dataSourceLoaded = true;
                return d.promise();
            }
        },
        pageSize: 12,
        map: function (item) {
            return {
                expensesDescription: item.Description,
                expensesDetailDescription: item.DetailsDescription,
                expensesApprovalStatus: GetStatus(item.Status, item.IsSubmitted, item.IsApproved),
                isReadOnly: (GetStatus(item.Status, item.IsSubmitted, item.IsApproved) !== "Open"),
                isReportOpen: (GetStatus(item.Status, item.IsSubmitted, item.IsApproved) === "Open"),
                expensesReportDate: item.InvoiceDate,
                itemID: item.InvoiceNumber,
                expSummarybgColor: GetBackgroundColor(item.Status),
                expApprovalNotes: item.ApprovalNotes
            };
        }
    });
    function GetStatus(statusCode, submitCode, approveCode) {
        if (statusCode === 0 || statusCode === null)
            return "Open";
        else if (statusCode === 1) {
            if (!submitCode || submitCode === 0 || submitCode === undefined || submitCode === null) {
                return "Pending";
            } else {
                if (!approveCode || approveCode === 0 || approveCode === undefined || approveCode === null) {
                    return "Pending Approval";
                }
                else if (approveCode === 1) {
                    return "Denied By Approver";
                } else {
                    return "Approved By Approver";
                }
            }
        } else if (statusCode === 2) {
            if (!approveCode || approveCode === 0 || approveCode === undefined || approveCode === null) {
                return "Approved";
            } else {
                return "Approved In Accounting";
            }
        } else if (statusCode === 4) {
            return "Pending Approval In Accounting";
        } else if (statusCode === 5) {
            return "Denied By Accounting";
        } else {
            return "Open";
        }
    }
    function GetBackgroundColor(statusCode) {
        if (statusCode === 0) {
            return "#00bcd4";
        } else if (statusCode === 1) {
            return "#f00f00";
        } else if (statusCode === 2) {
            return "#0097A7";
        } else if (statusCode === 3) {
            return "#ffffff";
        }
    }
    var expSummaryList = {
        dataSource: expSummaryDataSource,
        rendered: ko.observable(false),
        paginate: false,
        pageLoadMode: "scrollBottom",
        pullRefreshEnabled: true,
        scrollingEnabled: false,
        onItemClick: function (e) {
            if (e.itemData && e.itemData.itemID) {
                NavigateToExpenseDetail(e.itemData.itemID);
            } else {
                AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            }
        },
        onContentReady: function (e) {

            //if (resetSkip == true && selectedItem != undefined) {
            //    $("#dxExpSummaryList").dxList("instance").scrollToItem(selectedItem);
            //};
            //resetSkip = false;
        }
    };
    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        }
    }
    function viewShowing(e) {
        loadAll();
    }
    function loadPending() {
        AdvantageMobile_UI.db.get('GetExpensesPending', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
        }).done(function (data) {
            viewModel.pendingAmount('$' + ' ' + formatNumber(data));

        }).fail(function (data) {
            handleDataServiceError(data);
        });
    }
    function loadOpen() {
        AdvantageMobile_UI.db.get('GetExpensesOpen', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
        }).done(function (data) {
            viewModel.openAmount('$' + ' ' + formatNumber(data));
        }).fail(function (data) {
            handleDataServiceError(data);
        });
    }
    function loadDenied() {
        AdvantageMobile_UI.db.get('GetExpensesDenied', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
        }).done(function (data) {
            viewModel.deniedAmount('$' + ' ' + formatNumber(data));

        }).fail(function (data) {
            handleDataServiceError(data);
        });
    }
    function formatNumber(num) {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
    }
    var addButton = {
        title: 'Add',
        id: 'create',
        icon: 'plus',
        onExecute: function (e) {
            addExpense();
        }
    };
    function NavigateToExpenseDetail(expenseID) {
        AdvantageMobile_UI.app.navigate({
            view: "expenses_detail",
            settings: { InvoiceNumber: expenseID } //InvoiceNumber
        });
    }
    var addExpense = function (e) {
        AdvantageMobile_UI.app.navigate({
            view: "expenses_report", settings: { InvoiceNumber: 0 } //, ExpenseDetailID: 0 
        });
    };
    var submitExpense = function (rowData) {
        rowData.jQueryEvent.stopPropagation();
        AdvantageMobile_UI.app.navigate({
            view: "submit_options",
            settings: { invoiceNumber: rowData.model.itemID, from: 1 }
        });
    };
    var unSubmitExpense = function (rowData) {
        rowData.jQueryEvent.stopPropagation();
        AdvantageMobile_UI.db.get('UnSubmitExpenseReport', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            InvoiceNumber: rowData.model.itemID
        }).done(function (data) {
            if (data === "Successfully unsubmitted expense report.") {
                AdvantageMobile_UI.Messages.toastSuccess('Expense Report Unsubmitted!');
                loadAll();
            } else {
                AdvantageMobile_UI.Messages.toastWarning(data);
            }
        }).fail(function (data) {
            handleDataServiceError(data);
        });
    };
    var copyExpenseReportEvent = function (inlineData) {
        inlineData.jQueryEvent.stopPropagation();

        var result = DevExpress.ui.dialog.confirm(localizeString("Are You Sure You Want To Copy Expense Report"), null);
        result.done(function (dialogResult) {
            if (dialogResult == true) {
                var d = $.Deferred();
                AdvantageMobile_UI.db.get('CopyExpenseReport', {
                    InvoiceNumber: parseInt(inlineData.model.itemID),
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    ReportDate: (new Date()).toDateString(),
                    Description: inlineData.model.expensesDescription + ' - Copy',
                    Details: inlineData.model.expensesDetailDescription
                }).done(function (data) {
                    d.resolve(data);
                   // console.log("copyExpenseReportEvent")
                    loadAll();
                    AdvantageMobile_UI.Messages.toastSuccess(localizeString("Copy Created"));
                }).fail(function (data) {
                    d.reject(data);
                    AdvantageMobile_UI.Messages.toastWarning(localizeString("Copy Failed"));
                });
                return d.promise();
            }
        });
    };
    var deleteExpenseEvent = function (e) {
        e.jQueryEvent.stopPropagation();
        var result = DevExpress.ui.dialog.confirm(localizeString("Are You Sure You Want To Delete Expense Report"), null);
        result.done(function (dialogResult) {
            if (dialogResult == true) {
                deleteExpense(e.model.itemID);
            }
        });
        //visible: reportStatusOpen
    };
    var deleteExpense = function (invoiceNumber) {
        AdvantageMobile_UI.db.get('DeleteExpenseHeader', {
            InvoiceNumber: parseInt(invoiceNumber)
        }).done(function (data) {
            AdvantageMobile_UI.Messages.toastSuccess('Expense Report Deleted!');
           // console.log("deleteExpense")
            loadAll();
        }).fail(function (data) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Delete Failed"));
        });
    };
    var viewModel = {
        scrollView: scrollView,
        viewInfo: viewInfo,
        viewShowing: viewShowing,
        pullDown: pullDown,
        expSummaryList: expSummaryList,
        openAmount: openAmount,
        deniedAmount: deniedAmount,
        pendingAmount: pendingAmount,
        addButton: addButton,
        GetBackgroundColor: GetBackgroundColor,
        expSummaryBox: {
            direction: "row",
            width: "100%",
            height: 100
        },
        submitExpense: submitExpense,
        unSubmitExpense: unSubmitExpense,
        DeleteExpenseEvent: deleteExpenseEvent,
        CopyExpenseReportEvent: copyExpenseReportEvent
    };

    return viewModel;
};