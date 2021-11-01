@ModelType AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel
@Code       
    ViewData("Title") = "Denied!"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = False
End Code
<style>
    html, body {
        overflow: hidden !important;
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
    var denySuccess = false;
    var errorMessage = "";
    var pageText = "";
    var invoiceNumber = 0;
    var employeeName = "";
    denySuccess = @Html.Raw(ViewData("DenySuccess").ToString.ToLower);
    errorMessage = '@Html.Raw(ViewData("ErrorMessage"))';
    invoiceNumber = '@Html.Raw(Model.Header.InvoiceNumber)';
    employeeName = '@Html.Raw(Model.Header.EmployeeFullName)';
    $(document).ready(function () {
        if (denySuccess == true) {
            pageText = 'Report for ' + employeeName + ' successfullly denied.'
             $("#successDiv").show();
       } else {
            //showKendoAlert("NOT Denied!")
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
