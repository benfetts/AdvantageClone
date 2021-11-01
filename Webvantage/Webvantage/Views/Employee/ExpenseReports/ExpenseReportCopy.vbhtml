@Code 
    ViewData("Title") = "Expense report copy"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
<style>
    table tr td {padding-bottom:4px;}
    .k-widget.k-dropdown {
        height: 30px;
    }
    .k-widget.k-dropdown .k-dropdown-wrap {
        height: 28px;
    }

</style>

<div class="content padding-x">
    <div class="container-fluid">
        <table width="100%" border="0" cellspacing="2" cellpadding="2">
            <tr>
                <td width="15">
                    &nbsp;
                </td>
                <td width="90">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Employee:
                </td>
                <td>
                    <select id="employeeCode"></select>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Report Date:
                </td>
                <td>
                    
                    <input id="reportDate" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Description:
                </td>
                <td>
                    <input class="form-control" type="text" maxlength="30" id="description" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    Details:
                </td>
                <td>
                    
                    <textarea class="form-control" id="details" name="details" style="resize: none !important;"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <button type="button" class="k-button k-primary" onclick="copyClick()">Copy</button>&nbsp;&nbsp;
                    <button type="button" class="k-button" onclick="cancelClick()">Cancel</button>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>

    </div>
</div>
<script>
    @code
        Dim allEmployees = Newtonsoft.Json.JsonConvert.SerializeObject(ViewBag.EmployeeList)
        Dim rdate = CType(ViewBag.ReportDate, System.DateTime)

        Dim desc As String = ViewBag.Description
        desc = desc.Replace("'", "\'")

        Dim details As String = ViewBag.Details
        details = details.Replace("'", "\'")

    End Code

    var invoiceNumber = '@Html.Raw(ViewBag.InvoiceNumber)';
    var initEmployeeList = @Html.Raw(allEmployees);
    var selectedEmployee = '@Html.Raw(ViewBag.EmployeeSelectedValue)'; 
    var reportDate = '@Html.Raw(rdate.Date.ToShortDateString)';
    var description = '@Html.Raw(desc)';
    var details = '@Html.Raw(details)';

	function cancelClick() {
        window.parent.closeExpenseReportCopyDialog();

        //window.parent.closeDialogAndReloadReport('msg this');
    }

  

    function copyClick() {

        var empCode = $("#employeeCode").data("kendoDropDownList");
        var rdate = $("#reportDate").data("kendoDatePicker"); 
        //empCode.value()
        var newDescription = $('#description').val();
        var newDetails = $('#details').val();
        //var invoiceNumber = '1000000124'

        //console.log('rdate: ' + rdate.value());

        var month = rdate.value().getMonth() + 1;
        var d = month + '/' + rdate.value().getDate() + '/' + rdate.value().getFullYear();

        //console.log('rdate: ' + d);
        //EmployeeCode As String, ByVal ReportDate As System.DateTime, ByVal Description As String, ByVal Details As String
        var url = "Employee/ExpenseReports/CopyExpenseReport?InvoiceNumber=" + invoiceNumber + "&EmployeeCode=" + empCode.value() + "&ReportDate=" + d + "&Description=" + newDescription + "&Details=" + newDetails;

        $.get(window.appBase + url, function (data) {
            //console.log('return results');
            //console.log(data);
        }).always(function (result) {
            //console.log('always');
            //console.log(result);
            window.parent.closeCopyDialogAndReloadReport(result);

        });

    }



    $(document).ready(function () {

        $("#employeeCode").kendoDropDownList({
            filter: "contains",
            dataTextField: "Name",
            dataValueField: "Code",
            dataSource: initEmployeeList,
            error: function (xhr, error) {
                console.debug(xhr);
                console.debug(error);
            }
        });
        var employeeDropDown = $("#employeeCode").data("kendoDropDownList");
        employeeDropDown.value(selectedEmployee);
        //dropdownlist.trigger("change");

        $("#reportDate").kendoDatePicker({ format: "M/d/yyyy" });
        var datepicker = $("#reportDate").data("kendoDatePicker");

        var todayDate = kendo.date.today();
        
        datepicker.value(todayDate);
       // var descriptiondecode = decodeEntities(description);
        //showKendoAlert(decodeEntities(description));
        //showKendoAlert((description));
        //var detailsdecode = decodeEntities(details);
        //datepicker.value(reportDate);
        //datepicker.trigger("change");
        //val().replace("'", "\\'").replace('"', '\\"'
        $('#description').val(description);
        $('#details').val(details);



    });
</script>
