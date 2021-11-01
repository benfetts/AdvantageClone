@Code
    ViewData("Title") = "Print Expense Report Options"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
    ViewData("IsAngular") = True
End Code

<!--  Script Source Here  -->
<script src="~/Scripts/ExpenseReports/expensePrint.js"></script>


<style>
    .fieldlist {
        margin: 0 0 -1em;
        padding: 0;
    }

        .fieldlist li {
            list-style: none;
            padding-bottom: 1em;
        }
</style>
<div ng-app="angPrintReceipts" ng-controller="ExpenseReportPrintController">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <div id="TopToolBarsecond" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width: 100%;background-color: #E5E5E5;padding: 8px 0px 8px 0px;border-bottom: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px auto; overflow:auto;">
                    <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                        <li style="padding:0">
                            <button class="k-button wv-icon-button" onclick="printClick()" title="Add time"><span class='wvi wvi-printer2' title="Print Expense Report"></span></button>
                        </li>
                    </ul>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="0" cellspacing="5">
                    <tr>
                        <td height="5px" colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width:10px;"></td>
                        <td style="width: 400px;">
                            <ul class="fieldlist">
                                <li>
                                    <input type="checkbox" id="CheckBoxPrintSupervisorName" class="k-checkbox">
                                    <label class="k-checkbox-label" for="CheckBoxPrintSupervisorName">Print Supervisor Name Below Signature Line</label>
                                </li>
                                <li>
                                    <input type="checkbox" id="CheckBoxExcludeEmployeeSignature" class="k-checkbox">
                                    <label class="k-checkbox-label" for="CheckBoxExcludeEmployeeSignature">Exclude Employee Signature</label>
                                </li>
                                <li>
                                    <input type="checkbox" id="CheckBoxExcludeSupervisorSignature" class="k-checkbox">
                                    <label class="k-checkbox-label" for="CheckBoxExcludeSupervisorSignature">Exclude Supervisor Signature</label>
                                </li>
                                <li>
                                    <input type="checkbox" id="CheckBoxIncludeReceipts" class="k-checkbox" >
                                    <label class="k-checkbox-label" for="CheckBoxIncludeReceipts">Include Receipts</label>
                                </li>
                            </ul>
                        </td>
                        <td style="width:10px;"></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <script>
        var invoiceNumber = @Html.Raw(ViewBag.InvoiceNumber);
        var arg1 = false;
        var arg2 = false;
        var arg3 = false;
        var arg4 = false;
        var _scope = getScope('ExpenseReportPrintController');;


    function closeWindow(url) {
        window.parent.closePrintDialog(url);
        OpenRadWindow('Print Expense Report', url);
    }


    function printClick() {
        if ($('#CheckBoxPrintSupervisorName').is(":checked")) {
            arg1 = true;
        }
        else {
            arg1 = false;
        }
        if ($('#CheckBoxExcludeEmployeeSignature').is(":checked")) {
            arg2 = true;
        }
        else {
            arg2 = false;
        }
        if ($('#CheckBoxIncludeReceipts').is(":checked")) {
            arg3 = true;
        }
        else {
            arg3 = false;
        }
        if ($('#CheckBoxExcludeSupervisorSignature').is(":checked")) {
            arg4 = true;
        }
        else {
            arg4 = false;
        }

        //_scope.printSave(arg1, arg2, arg3, arg4);

        $.ajax({
                type: "Post",
                url: "@Href("~/Employee/ExpenseReports/SavePrintSettings")",
                data: {
                    PrintSupervisorBelowSignature: arg1,
                    ExcludeEmployeeSignature: arg2,
                    ExcludeSupervisorSignature: arg4,
                    IncludeReceipts: arg3
                },
                dataType: "json",
                success: function (response) {

                }
            });

        var url = "Employee/ExpenseReports/PrintExpenseReport?InvoiceNumber=" + invoiceNumber + "&PrintSupervisorName=" + arg1 + "&ExcludeEmployeeSignature=" + arg2 + "&IncludeReceipts=" + arg3 + "&IncludeReport=true&ExcludeSupervisorSignature=" + arg4;
        var reponseUrl = '';

        //OpenRadWindow('Print Expense Report', window.appBase + url);
        $.get(window.appBase + url, function (data) {
            //console.log('return results');
            //console.log(data);
            reponseUrl = data;
        }).always(function (result) {
            //console.log('always');
            //console.log(result);
            reponseUrl = result;
            console.log('cw: ' + reponseUrl);
            closeWindow(reponseUrl);
        });


    }

    function loadPrintSettings(e) {
        $.ajax({
            type: "Get",
            url: "@Href("~/Employee/ExpenseReports/GetPrintSettings")",
            @*data: {
                JobNumber: @Model.JobNumber,
                JobComponentNumber: @Model.JobComponentNumber
            },*@
            dataType: "json",
            success: function (response) {

                for (var key in response) {
                    if (response.hasOwnProperty(key)) {
                        window[response[key].Item1] = response[key].Item2;
                    }
                }

                if (typeof window['PrintSupervisorBelowSignature'] !== 'undefined' && window['PrintSupervisorBelowSignature'] == 'true') {

                    $('#CheckBoxPrintSupervisorName').prop('checked', true);

                }

                if (typeof window['ExcludeEmployeeSignature'] !== 'undefined' && window['ExcludeEmployeeSignature'] == 'true') {

                    $('#CheckBoxExcludeEmployeeSignature').prop('checked', true);

                }

                if (typeof window['ExcludeSupervisorSignature'] !== 'undefined' && window['ExcludeSupervisorSignature'] == 'true') {

                    $('#CheckBoxExcludeSupervisorSignature').prop('checked', true);

                }

                if (typeof window['IncludeReceipts'] !== 'undefined' && window['IncludeReceipts'] == 'true') {

                    $('#CheckBoxIncludeReceipts').prop('checked', true);
                }

            }
        });


    }

    </script>
</div>

<script>
    
        $(document).ready(function () {
            
            //console.log($scope.allReceipts);

            loadPrintSettings();



        });

    </script>
