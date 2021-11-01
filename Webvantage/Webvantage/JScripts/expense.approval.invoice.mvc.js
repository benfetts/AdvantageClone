//
function approveInvoice(x, invoiceNumber, approver, comment) {
    //console.log("approveInvoice", x, invoiceNumber, approver, comment);
    try {
        var data = {
            x: x,
            inv: invoiceNumber,
            emp: approver,
            c: comment
        };
        $.post({
            url: window.appBase + "Employee/ExpenseApproval/Approve",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                console.log("approveInvoice response", response);
                if (response.Success == true) {
                    $("#currentStatusSpan").text("Approved");
                    $("#statusChangedMessage").text("The Expense Report status has changed and it is no longer available to approve or deny.  Status is:  Approved");
                    $("#actionedMessage").text("The Expense Report status has changed and it is no longer available to approve or deny.  Status is:  Approved");
                    setButtons(2);
                    hideForm();
                }
            }
        });
    } catch (e) {
        console.log("Approve:approveInvoice:error:", e);
    }
}
function denyInvoice(x, invoiceNumber, approver, comment) {
    //console.log("denyInvoice", x, invoiceNumber, approver, comment);
    try {
        var data = {
            x: x,
            inv: invoiceNumber,
            emp: approver,
            c: comment
        };
        $.post({
            url: window.appBase + "Employee/ExpenseApproval/Deny",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                if (response.Success == true) {
                    $("#ModalDialog").ejDialog("close");
                    $("#currentStatusSpan").text("Denied");
                    $("#statusChangedMessage").text("The Expense Report status has changed and it is no longer available to approve or deny.  Status is:  Denied");
                    $("#actionedMessage").text("The Expense Report status has changed and it is no longer available to approve or deny.  Status is:  Denied");
                    setButtons(1);
                    hideForm();
                }
            }
        });
    } catch (e) {
        console.log("Approve:approveInvoice:error:", e);
    }
}
function setButtons(approvalFlag) {
    approvalFlag = approvalFlag * 1;
    //if (approvalFlag == 1) { // Denied
    //    $("#approveButton").prop("disabled", false);
    //    $("#denyButton").prop("disabled", true);
    //} else if (approvalFlag == 2) { // Approved
    //    $("#approveButton").prop("disabled", true);
    //    $("#denyButton").prop("disabled", false);
    //} else { // Pending
    //    $("#approveButton").prop("disabled", false);
    //    $("#denyButton").prop("disabled", false);
    //}
    if (approvalFlag == 1) { // Denied
        $("#approveButton").hide();
        $("#denyButton").hide();
        $("#addCommentButton").hide();
    } else if (approvalFlag == 2) { // Approved
        $("#approveButton").hide();
        $("#denyButton").hide();
        $("#addCommentButton").hide();
    } else if (approvalFlag == 0) { // Pending
        $("#approveButton").show();
        $("#denyButton").show();
        $("#addCommentButton").show();
    } else { // Pending
        $("#approveButton").show();
        $("#denyButton").show();
        $("#addCommentButton").show();
    }

}
function hideForm() {
    //$("#actionedContainer").show();
    //$("#expenseReportContainer").hide();
}
function checkBoxShowAllDocumentsChanged(e) {
    //console.log("checkBoxShowAllDocumentsChanged", e);
    console.log($("#checkBoxShowAllDocuments").is(":checked"))
    if ($("#checkBoxShowAllDocuments").is(":checked") == true) {
        $("#docsGridContainer").show();
    } else {
        $("#docsGridContainer").hide();
    }
}
