@Code 
    ViewData("Title") = "Submit Expense Report Options"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True


    Dim Employees As IEnumerable = ViewBag.Employees
End Code

<style>

    .form-layout.label-l > ul li:first-child {
        width: 130px;
    }
    label{margin-bottom:0;}
</style>
<div class="content padding-x">
    <div class="container-fluid">

        <div style="margin-top: 10px; white-space: nowrap;" id="content">
            <div class="form-layout label-l">
                <ul>
                    <li>Employee:</li>
                    <li><label>@Html.Raw(ViewBag.ExpenseEmployee)</label></li>
                </ul>
                <ul>
                    <li>Supervisor:</li>
                    <li><label>@Html.Raw(ViewBag.Supervisor)</label></li>
                </ul>
                <ul>
                    <li>Alternate Approver:</li>
                    <li><label>@Html.Raw(ViewBag.AlternateApprover)</label></li>
                </ul>
                <ul>
                    <li>Select Approver:</li>
                    <li>
                        @code
                            Dim empList = New SelectList(Employees, "Code", "Name")
                        End Code
                        <select id="employeeCode"></select>
                        @*@(Html.DropDownList("empCodeToApprove", empList, "select approver"))*@
                        @*@(Html.Kendo.DropDownList().BindTo(empList).Name("empCode"))*@
                     
                    </li>
                </ul>
                <ul>
                    <li>&nbsp;</li>
                    <li>
                        <input type="checkbox" id="IncludeReceiptsInEmailAndAlert" class="k-checkbox" checked>
                        <label class="k-checkbox-label" for="IncludeReceiptsInEmailAndAlert">Include receipts in Email and Alert</label>
                    </li>
                </ul>
                
            </div>
            <div style="        text-align: right;
        margin-top: 20px;">
                <button id="Button_Submit" class="k-button k-primary" onclick="submitOptionsClick()">Submit</button>&nbsp;&nbsp;
                <button id="Button_Cancel" class="k-button" onclick="cancelClick();">Cancel</button>
            </div>
        </div>
    </div>
</div>

<script>
    @code
        Dim allEmployees = Newtonsoft.Json.JsonConvert.SerializeObject(Employees)
    End Code
    var initEmployeeList = @Html.Raw(allEmployees);
    var invoiceNumber = @Html.Raw(ViewBag.InvoiceNumber);
    var includeRecMA = false;
    var supervisorCode =  '@Html.Raw(ViewBag.SupervisorCode)';
    


    function cancelClick() {
        window.parent.closeExpenseReportSubmitOptionsDialog();
    }

    function submitOptionsClick() {
        var empCode = $("#employeeCode").data("kendoDropDownList");
        if ($('#IncludeReceiptsInEmailAndAlert').is(":checked")) {
            includeRecMA = true;
        }
        else {
            includeRecMA = false;
        }

        //var data = {
        //    InvoiceNumber: invoiceNumber,
        //    ApprovalRequired: true,
        //    IncludeReceiptsInEmailAndAlert: includeRecMA,
        //    SubmittedToEmployeeCode: empCode.value()
        //}

        //console.log(data);

        var url = "Employee/ExpenseReports/SubmitExpenseReportOptions?InvoiceNumber=" + invoiceNumber + "&ApprovalRequired=true&IncludeReceiptsInEmailAndAlert=" + includeRecMA + "&SubmittedToEmployeeCode=" + empCode.value();

        $.get(window.appBase + url, function (data) {
            console.log('return results');
            console.log(data);
        }).always(function (result) {
            console.log('always');
            console.log(result);
        });


        window.parent.closeExpenseReportSubmitOptionsDialog(invoiceNumber);
        //set flag to reload data;
        URL = window.appBase + "Employee/ExpenseReports/NewExpenseReport?invoice=" + invoiceNumber;
       
            window.parent.location.href = URL;
        
    }

    $(document).ready(function () {
        $("#employeeCode").kendoDropDownList({
            filter: "contains",
            dataTextField: "Name",
            dataValueField: "Code",
            dataSource: initEmployeeList,
            value: supervisorCode,
            error: function (xhr, error) {
                console.debug(xhr);
                console.debug(error);
            }
        });


    });




</script>
