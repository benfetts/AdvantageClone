AdvantageMobile_UI.expense_header_edit = function (params, viewInfo) {
    "use strict";

    var reportStatusOpen = ko.observable(false);
    var reportReadOnly = ko.observable(true);
    var strReportDate = ko.observable("");
    var strDescription = ko.observable("");
    var strDetailsDescription = ko.observable("");
    
    //var txtDetails = ko.observable(null);
    //var strDetails = {
    //    width: "100%",
    //    height: 100,
    //    value: txtDetails,
    //    placeholder: localizeString('Enter Details'),
    //    readOnly: reportReadOnly
    //};

    var timeEntryDate = ko.observable(new Date());
    var entryDateBox = {

        value: timeEntryDate,
        applyValueMode: "useButtons",
        readOnly: reportReadOnly,
        width: "100%",
        onValueChanged: function (data) {

        }
    };
    var InvoiceNumber = ko.observable(0);

    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        };
    };

    function viewShowing(e) {
        if (params.settings && params.settings.InvoiceNumber) {
            //alert(params.settings.InvoiceNumber);
            viewModel.InvoiceNumber(parseInt(params.settings.InvoiceNumber));
            //Bind Data
            if (viewModel.InvoiceNumber() > 0) {
                loadExpenseHeader();
            }
        }

    };

    function loadExpenseHeader() {
        AdvantageMobile_UI.db.get('GetExpenseReport', {
            InvoiceNumber: viewInfo.routeData.settings.InvoiceNumber.toString()
            // EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
        }).done(function (data) {
            if (data) {
                viewModel.strDescription(data.Description);
                viewModel.strDetailsDescription(data.DetailsDescription);
                viewModel.timeEntryDate(data.InvoiceDate.toUtcDate());
                viewModel.reportStatusOpen(GetStatus(data.Status, data.IsSubmitted, data.IsApproved) === "Open")
                viewModel.reportReadOnly(GetStatus(data.Status, data.IsSubmitted, data.IsApproved) !== "Open")
            }
        }).fail(function (data) {
            handleDataServiceError(data);
        })
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
    };

    var reportDateValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Report Date')
        }]
    };

    var descriptionValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Description')
        }]
    };

    var detailsValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Details')
        }]
    };

    var clearFieldsButton = function () {
        AdvantageMobile_UI.db.get("Delete Expense Header", {

            InvoiceNumber: viewModel.InvoiceNumber()

        }).done(function (data) {
            AdvantageMobile_UI.app.navigate({
                view: "expenses_summary",
                settings: {}
            });
        }).fail(function (data) {
            handleDataServiceError(data);
        });
    };

    var updateExpenseHeader = function () {
        AdvantageMobile_UI.db.get("UpdateExpenseHeader", {

            InvoiceNumber: parseInt(viewModel.InvoiceNumber()),
            ExpenseDate: viewModel.timeEntryDate().toShortDateString(), //change
            Description: viewModel.strDescription(),
            Details: viewModel.strDetailsDescription()

        }).done(function (data) {
            AdvantageMobile_UI.app.back();
            //AdvantageMobile_UI.app.navigate({
            //    view: "expenses_detail",
            //    settings: { InvoiceNumber: viewModel.InvoiceNumber()}
            //}
            //, { location: 'back' });

        }).fail(function (xhr, status, p3, p4) {
            handleDataServiceError(JSON.parse(xhr.responseText).Message);
        });
    };

    var insertExpenseHeader = function () {
        AdvantageMobile_UI.db.get("InsertExpenseHeader", {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ExpenseDate: viewModel.timeEntryDate().toShortDateString(), //change
            Description: viewModel.strDescription(),
            Details: viewModel.strDetailsDescription()
        }).done(function (data) {
            AdvantageMobile_UI.app.back();

            //viewModel.InvoiceNumber(data);
            //AdvantageMobile_UI.app.navigate({
            //    view: "expenses_detail",
            //    settings: { InvoiceNumber: data }
            //}
            //, { target: "current", root: false, direction: 'backward' });

        }).fail(function (data) {
            handleDataServiceError(data);
        });
    };

    var saveExpenseHeader = function (e) {
        if (validateFields()) {
            if (viewModel.InvoiceNumber() === 0) {
                insertExpenseHeader();
            }
            else if (viewModel.InvoiceNumber() > 0) {
                updateExpenseHeader();
            }
        }
    };

    var validateFields = function () {
        if (!viewModel.timeEntryDate() || viewModel.timeEntryDate().toShortDateString() === "") {    //change datevalidation
            AdvantageMobile_UI.Messages.toastError(localizeString('Please EnterReportDate'));
            return false;
        }

        if (viewModel.strDescription() === null || viewModel.strDescription() === "") {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Please EnterReportDescription"));
            return false;
        }

        return true;
    };

    var clearFields = {
        title: localizeString("Cancel"),
        id: 'menu-cancel',
        onExecute: function () {
            //AdvantageMobile_UI.app.back();
            clearForm();
            //backToExpenseDetail();
        },
        visible: reportStatusOpen
    };

    function clearForm() {


    };

    var viewModel = {
        viewInfo: viewInfo,
        viewShowing: viewShowing,
        viewShown: viewShown,
        InvoiceNumber: InvoiceNumber,
        strReportDate: strReportDate,
        strDescription: strDescription,
        strDetailsDescription: strDetailsDescription,
        reportDateValidator: reportDateValidator,
        descriptionValidator: descriptionValidator,
        detailsValidator: detailsValidator,
        clearFields: clearFields,
        saveExpenseHeader: saveExpenseHeader,
        timeEntryDate: timeEntryDate,
        entryDateBox: entryDateBox,
        reportStatusOpen: reportStatusOpen,
        reportReadOnly: reportReadOnly,
    };

    return viewModel;
};