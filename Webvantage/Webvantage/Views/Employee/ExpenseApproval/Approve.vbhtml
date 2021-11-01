@ModelType AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel
@Code       
    ViewData("Title") = "Approved!"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = False
End Code
    <style>
        html, body {
            overflow: hidden;
        }
    </style>
<link href="~/CSS/expense.approval.invoice.mvc.min.css" rel="stylesheet" />
<table style="width: 100%; padding: 30px; margin-top: 10px;">
    <tr>
        <td>
            <div id="successDiv" class="alert alert-success" style="display: none;">
                <span id="pageText"></span>
            </div>
            <div id="errorDiv" class="alert alert-danger" style="display: none;">
                <span id="errorMessage"></span>
            </div>
        </td>
    </tr>
</table>
<script>
    var success = false;
    var errorMessage = "";
    var pageText = "";
    var invoiceNumber = 0;
    var employeeName = "";
    success = @Html.Raw(ViewData("Success").ToString.ToLower);
    errorMessage = '@Html.Raw(ViewData("ErrorMessage"))';
    invoiceNumber = '@Html.Raw(Model.Header.InvoiceNumber)';
    employeeName = '@Html.Raw(Model.Header.EmployeeFullName)';
    $(document).ready(function () {
        if (success == true) {
            pageText = 'Report for ' + employeeName + ' successfullly approved.'
            $("#successDiv").show();
        } else {
            //showKendoAlert("NOT Approved!")
            $("#successDiv").hide();
        }
        if (errorMessage != "") {
            $("#errorMessage").text(errorMessage);
            $("#errorDiv").show();
            $("#successDiv").hide();
        } else {
            $("#errorMessage").text(errorMessage);
            $("#errorDiv").hide();
            if (pageText !== "") {
                $("#successDiv").show();
            }
        }
        $("#pageText").text(pageText);
    });
</script>
