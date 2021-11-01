AdvantageMobile_UI.expense_documents = function (params, viewInfo) {
    "use strict";

    var reportStatusOpen = ko.observable(true);
    var reportLocked = ko.observable(false);
    var invoiceNumber = ko.observable(0);
    var expenseDetailID = ko.observable(0);
    var documentID = ko.observable(0);
    var repositoryFileName = ko.observable(0);
    var viewShownCompleted = false;
    var viewShowingCompleted = false;
    var imageSRC = ko.observable("");

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
        //alert(params.settings.DocumentID);
        if (params.settings) {
            if (params.settings.InvoiceNumber > 0) {
                viewModel.InvoiceNumber(params.settings.InvoiceNumber);
            }
            if (params.settings.DocumentID > 0) {
                viewModel.DocumentID(params.settings.DocumentID);
            }
            if (params.settings.ExpenseDetailID > 0) {
                viewModel.ExpenseDetailID(params.settings.ExpenseDetailID);
            }
            if (params.settings.RepositoryFilename > 0) {
                viewModel.RepositoryFilename(params.settings.RepositoryFilename);
            }
            
            if (params.settings.ReportReadOnly === true) {
                viewModel.reportLocked(false)
            } else {
                viewModel.reportLocked(true)
            }

            GetDocument();
        }
       
        viewShowingCompleted = true;
    };
    var GetDocument = function () {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('GetDocumentFromDatabase', {
            DocumentID: viewModel.DocumentID()
        }).done(function (docData) {
            AdvantageMobile_UI.db.get('GetDocumentFromRepository', {
                RepositoryFileName: docData.RepositoryFilename.toString()
            }).done(function (imageData) {
                viewShowingCompleted = true;
                viewModel.ImageSRC('data:image/' + docData.MimeType + ';base64, ' + imageData);
                d.resolve(imageData);
            }).fail(function (data) {
                handleDataServiceError(data);
            })
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        return d.promise();
    };

    function deleteButton() {
        var result = DevExpress.ui.dialog.confirm(localizeString("Are You Sure You Want To Delete"), null);
        result.done(function (dialogResult) {
            if (dialogResult == true) {
                deleteDocument();
            };
        });

    }

    //var deleteButton = {
    //    title: 'Delete',
    //    id: 'menu-clear',
    //    onExecute: function (e) {
    //        var result = DevExpress.ui.dialog.confirm(localizeString("Are You Sure You Want To Delete"), null);
    //        result.done(function (dialogResult) {
    //            if (dialogResult == true) {
    //                deleteDocument();
    //            };
    //        });
    //    },
    //    visible: reportStatusOpen
    //};

    function deleteDocument() {
        var d = $.Deferred();
        AdvantageMobile_UI.db.get('DeleteDetailDocument', {
            DocumentID: parseInt(viewModel.DocumentID())
        }).done(function (data) {
            d.resolve(data);
            AdvantageMobile_UI.Messages.toastSuccess('Expense Receipt Deleted!');
            AdvantageMobile_UI.app.back();

        }).fail(function (data) {

            handleDataServiceError(data);
        });
        return d.promise();
    };

    var viewModel = {
        //  Put the binding properties here
        viewInfo: viewInfo,
        viewShowing: viewShowing,
        viewShown: viewShown,
        InvoiceNumber: invoiceNumber,
        ExpenseDetailID: expenseDetailID,
        DocumentID: documentID,
        RepositoryFileName: repositoryFileName,
        deleteButton: deleteButton,
        ImageSRC: imageSRC,
        reportLocked: reportLocked

    };

    return viewModel;
};