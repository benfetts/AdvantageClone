@ModelType AdvantageFramework.ProjectSchedule.Classes.Schedule
@Code       ViewData("Title") = "New Project Schedule"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
<div id="temp-tool-parent" style="margin-top: 5px;">
    @(Html.Kendo.ToolBar().Name("Toolbar").Items(Sub(i)
                                                     i.Add().Type(CommandType.Button).Text("Create Project Schedule").HtmlAttributes(New With {.id = "AddSchedule"}).Click("createSchedule")

                                                     If Not Me.QueryString.IsJobDashboard Then

                                                         i.Add().Type(CommandType.Button).Text("Cancel").Click("cancel")

                                                     End If

                                                 End Sub))

</div>

<div style="margin-top: 10px;">
    @(Html.Raw(ViewData("IsJobDashboard")))
    <div id="ScheduleForm" class="form-horizontal">
        <div class="form-group">
            <label for="ClientCode" class="control-label col-sm-2">Client:</label>
            <div class="col-sm-10">
                @(Html.Kendo.TextBox().Name("ClientCode").Value(Model.ClientCode).Enable(String.IsNullOrWhiteSpace(Model.ClientCode)).HtmlAttributes(New With {.class = "code-6", .onchange = "autoLookup('Client')", .title = "Client"}))
                @(Html.Kendo.TextBox().Name("ClientName").Value(ViewData("ClientName")).Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
            </div>
        </div>
        <div class="form-group">
            <label for="DivisionCode" class="control-label col-sm-2">Division:</label>
            <div class="col-sm-10">
                @(Html.Kendo.TextBox().Name("DivisionCode").Value(Model.DivisionCode).Enable(String.IsNullOrWhiteSpace(Model.DivisionCode)).HtmlAttributes(New With {.class = "code-6", .onchange = "autoLookup('Division')", .title = "Division"}))
                @(Html.Kendo.TextBox().Name("DivisionName").Value(ViewData("DivisionName")).Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
            </div>
        </div>
        <div class="form-group">
            <label for="ProductCode" class="control-label col-sm-2">Product:</label>
            <div class="col-sm-10">
                @(Html.Kendo.TextBox().Name("ProductCode").Value(Model.ProductCode).Enable(String.IsNullOrWhiteSpace(Model.ProductCode)).HtmlAttributes(New With {.class = "code-6", .onchange = "autoLookup('Product')", .title = "Product"}))
                @(Html.Kendo.TextBox().Name("ProductName").Value(ViewData("ProductName")).Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
            </div>
        </div>
        <div class="form-group">
            <label for="JobNumber" class="control-label col-sm-2">Job:</label>
            <div class="col-sm-10">
                @(Html.Kendo.NumericTextBox().Name("JobNumber").Value(Model.JobNumber).Spinners(False).Enable(Not Model.JobNumber > 0).Decimals(0).Format("f").HtmlAttributes(New With {.class = "code-6 RequiredInput", .onchange = "autoLookup('Job')", .required = "required", .validationmessage = "Job is required.", .title = "Job"}).Placeholder(" "))
                @(Html.Kendo.TextBox().Name("JobDescription").Value(ViewData("JobDescription")).Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
                <span class="k-invalid-msg" data-for="JobNumber"></span>
            </div>
        </div>
        <div class="form-group">
            <label for="JobComponentNumber" class="control-label col-sm-2">Component:</label>
            <div class="col-sm-10">
                @(Html.Kendo.NumericTextBox().Name("JobComponentNumber").Spinners(False).Value(Model.JobComponentNumber).Enable(Not Model.JobComponentNumber > 0).Decimals(0).Format("f").HtmlAttributes(New With {.class = "code-6 RequiredInput", .onchange = "autoLookup('Component')", .required = "required", .validationmessage = "Job Component is required.", .title = "Component"}))
                @(Html.Kendo.TextBox().Name("JobComponentDescription").Value(ViewData("JobComponentDescription")).Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
                <span class="k-invalid-msg" data-for="JobComponentNumber"></span>
            </div>
        </div>
        <div class="form-group">
            <label for="TrafficStatus" class="control-label col-sm-2">Traffic Status:</label>
            <div class="col-sm-10">
                @(Html.Kendo.TextBox().Name("TrafficStatus").Value(Model.JobTraffic.TrafficCode).HtmlAttributes(New With {.class = "code-6 RequiredInput", .required = "required", .validationmessage = "Traffic Status is required.", .title = "Traffic Status"}))
                <span class="k-invalid-msg" data-for="TrafficStatus"></span>
            </div>
        </div>
        <div class="form-group">
            <label for="ProjectManager" class="control-label col-sm-2">@ViewData("ProjectManagerLabel"):</label>
            <div class="col-sm-10">
                @(Html.Kendo.TextBox().Name("ProjectManager").HtmlAttributes(New With {.class = "code-6", .title = ViewData("ProjectManagerLabel")}))
            </div>
        </div>
        @*<div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                @(Html.Kendo.Button().Name("Create").Content("Create Schedule"))
                @(Html.Kendo.Button().Name("Cancel").Content("Cancel"))
            </div>
        </div>*@
        <h4 class="panel-title">
            Copy From Existing Schedule?
            <button id="copy-existing" class="btn btn-link" data-toggle="collapse" data-parent="#accordion" href="#copy-panel" aria-expanded="true" aria-controls="collapseOne">
                <span class="k-icon k-i-arrow-60-down"></span>
            </button>
            @*<span class="pull-right">
                @(Html.Kendo.CheckBox().Name("CopyFromSchedule").Label(""))
            </span>*@

        </h4>
        <div id="copy-panel" class="panel-collapse collapse in advanced-search" role="tabpanel" aria-labelledby="headingOne">
            <div class="panel-body">
                <div id="ScheduleCopy" style="display: none;">
                    <div class="form-group">
                        <label for="CopyClientCode" class="control-label col-sm-2">Client:</label>
                        <div class="col-sm-10">
                            @(Html.Kendo.TextBox().Name("CopyClientCode").HtmlAttributes(New With {.class = "code-6", .onchange = "autoLookup('CopyClient')", .title = "Copy Client"}))
                            @(Html.Kendo.TextBox().Name("CopyClientName").Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="CopyDivisionCode" class="control-label col-sm-2">Division:</label>
                        <div class="col-sm-10">
                            @(Html.Kendo.TextBox().Name("CopyDivisionCode").HtmlAttributes(New With {.class = "code-6", .onchange = "autoLookup('CopyDivision')", .title = "Copy Division"}))
                            @(Html.Kendo.TextBox().Name("CopyDivisionName").Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="CopyProductCode" class="control-label col-sm-2">Product:</label>
                        <div class="col-sm-10">
                            @(Html.Kendo.TextBox().Name("CopyProductCode").HtmlAttributes(New With {.class = "code-6", .onchange = "autoLookup('CopyProduct')", .title = "Copy Product"}))
                            @(Html.Kendo.TextBox().Name("CopyProductName").Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="CopyJobNumber" class="control-label col-sm-2">Job:</label>
                        <div class="col-sm-10">
                            @(Html.Kendo.NumericTextBox().Name("CopyJobNumber").Spinners(False).Decimals(0).Format("f").HtmlAttributes(New With {.class = "code-6 RequiredInput", .onchange = "autoLookup('CopyJob')", .validationmessage = "Job is required.", .title = "Copy Job"}))
                            @(Html.Kendo.TextBox().Name("CopyJobDescription").Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
                            <span class="k-invalid-msg" data-for="CopyJobNumber"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="CopyJobComponentNumber" class="control-label col-sm-2">Component:</label>
                        <div class="col-sm-10">
                            @(Html.Kendo.NumericTextBox().Name("CopyJobComponentNumber").Spinners(False).Decimals(0).Format("f").HtmlAttributes(New With {.class = "code-6 RequiredInput", .onchange = "autoLookup('CopyComponent')", .validationmessage = "Job Component is required.", .title = "Copy Component"}))
                            @(Html.Kendo.TextBox().Name("CopyJobComponentDescription").Enable(False).HtmlAttributes(New With {.class = "text-60-full"}))
                            <span class="k-invalid-msg" data-for="CopyJobComponentNumber"></span>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            @(Html.Kendo.CheckBox().Name("ShowClosedArchivedJobs").Label("Show Closed/Archived Jobs?"))
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            @(Html.Kendo.CheckBox().Name("IncludeStartDate").Label("Include Start Date"))<br />
                            @(Html.Kendo.CheckBox().Name("IncludeDueDate").Label("Include Due Date"))<br />
                            @(Html.Kendo.CheckBox().Name("IncludeTaskEmployees").Label("Include Task Employee(s)"))<br />
                            @(Html.Kendo.CheckBox().Name("IncludeTaskComment").Label("Include Task Comment"))<br />
                            @(Html.Kendo.CheckBox().Name("IncludeDueDateComment").Label("Include Due Date Comment"))<br />
                            @(Html.Kendo.CheckBox().Name("IncludeTaskStatus").Label("Include Task Status"))<br />
                        </div>
                    </div>
                    @*<div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            @(Html.Kendo.Button().Name("CopyProjectSchedule").Content("Copy Project Schedule"))
                        </div>
                    </div>*@
                </div>
            </div>
        </div>

    </div>
</div>

<style>
    #CopyHeader {
        padding-bottom: 2px;
        margin-bottom: 10px;
    }

    .form-group {
        margin-bottom: 5px;
    }
    .advanced-search {
        background: #f6f6f6;
        border-radius: 6px;
        border: #ccc solid 1px;
        margin-top: 10px;
        padding: 10px 5px;
    }
    .k-checkbox-label, .k-radio-label {
        font-weight: 500;
    }
    #Toolbar {
        background: #e5e5e5;
    }
</style>

<script>
    $(document).ready(function () {
        //$('#JobNumber').data('kendoNumericTextBox').focus();
        var jobInput = $('#JobNumber').data('kendoNumericTextBox');
        var compInput = $('#JobComponentNumber').data('kendoNumericTextBox');
        var statusInput = $('#TrafficStatus');
        var pmInput = $('#ProjectManager');

        $('.collapse').collapse();

        if (jobInput.value() === 0) {
            jobInput.value(null);
        }
        if (compInput.value() === 0) {
            compInput.value(null);
        }
        if (jobInput.value() === null) {
            jobInput.focus();
        } else if (compInput.value() === '') {
            compInput.focus();
        } else if (statusInput.val() === '') {
            statusInput.focus();
        } else if (pmInput.val() === '') {
            pmInput.focus();
        }
    });
    $('#copy-existing').click(function(){
        //console.log("click");
        $('#AddSchedule').text('Copy Project Schedule');
        $('#ScheduleCopy').slideDown(100);
        $('#CopyJobNumber').data('kendoNumericTextBox').focus();
    });
    $('body').on('dblclick', 'input.k-input, input.k-textbox', function () {
        if ($(this).is(":enabled")) {
            lookup(this.name);
        }
    });
    function toggleRequired(isRequired) {
        var jobInput = $('#CopyJobNumber'),
            compInput = $('#CopyJobComponentNumber');
        if (isRequired) {
            jobInput.attr('required', 'required');
            compInput.attr('required', 'required');
        } else {
            jobInput.removeAttr('required');
            compInput.removeAttr('required');
        }
    }
    function lookup(type) {
        var onCloseCallback;
        var url;
        var Prefix = '',
            ShowClosed = false,
            IsCopy = false;
        if (type.indexOf('Copy') > -1) {
            IsCopy = true;
            Prefix = 'Copy';
            type = type.replace(Prefix, '');
            ShowClosed = $('#ShowClosedArchivedJobs').is(':checked');
        }
        var ClientCode = $('#' + Prefix + 'ClientCode').val();
        var DivisionCode = $('#' + Prefix + 'DivisionCode').val();
        var ProductCode = $('#' + Prefix + 'ProductCode').val();
        var JobNumber = $('#' + Prefix + 'JobNumber').val();
        switch (type) {

            case "ClientCode":
                url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupClients";
                onCloseCallback = function (selectedItem) {
                    if (selectedItem && selectedItem.Code !== ClientCode) {
                        setSearchValues(selectedItem.Code, selectedItem.Name, null, null, null, null, null, null, null, null, IsCopy);
                    }
                };
                break;

            case "DivisionCode":
                url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupDivisions?ClientCode=" + ClientCode + '&';
                onCloseCallback = function (selectedItem) {
                    if (selectedItem && selectedItem.Code !== DivisionCode) {
                        setSearchValues(selectedItem.ClientCode, selectedItem.ClientName, selectedItem.Code, selectedItem.Name, null, null, null, null, null, null, IsCopy);
                    }
                };
                break;

            case "ProductCode":
                url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupProducts?ClientCode=" + ClientCode + "&DivisionCode=" + DivisionCode + '&';
                onCloseCallback = function (selectedItem) {
                    if (selectedItem && selectedItem.Code !== ProductCode) {
                        setSearchValues(selectedItem.ClientCode, selectedItem.ClientName, selectedItem.DivisionCode, selectedItem.DivisionName, selectedItem.Code, selectedItem.Name, null, null, null, null, IsCopy);
                    }
                };
                break;

            case "JobNumber":
                url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupJobs?ClientCode=" + ClientCode + "&DivisionCode=" + DivisionCode + "&ProductCode=" + ProductCode + '&ShowClosed=' + ShowClosed + '&IsCopy=' + IsCopy;
                onCloseCallback = function (selectedItem) {
                    if (selectedItem && selectedItem.Number !== JobNumber) {
                        setSearchValues(selectedItem.ClientCode, selectedItem.ClientName, selectedItem.DivisionCode, selectedItem.DivisionName, selectedItem.ProductCode, selectedItem.ProductName, selectedItem.Number, selectedItem.Description, selectedItem.JobComponentNumber, selectedItem.JobComponentDescription, IsCopy);
                    }
                };
                break;

            case "JobComponentNumber":
                url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupJobComponents?ClientCode=" + ClientCode + "&DivisionCode=" + DivisionCode + "&ProductCode=" + ProductCode + "&JobNumber=" + JobNumber + '&ShowClosed=' + ShowClosed + '&IsCopy=' + IsCopy;
                onCloseCallback = function (selectedItem) {
                    if (selectedItem && selectedItem.Number !== JobComponentNumber) {
                        setSearchValues(selectedItem.ClientCode, selectedItem.ClientName, selectedItem.DivisionCode, selectedItem.DivisionName, selectedItem.ProductCode, selectedItem.ProductName, selectedItem.JobNumber, selectedItem.JobDescription, selectedItem.Number, selectedItem.Description, IsCopy);
                    }
                };
                break;

            case "TrafficStatus":
                url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupStatus";
                onCloseCallback = function (selectedItem) {
                    if (selectedItem) {
                        $('#TrafficStatus').val(selectedItem.Code).blur();
                        setTimeout(function () {
                            $('#ProjectManager').focus();
                        }, 100);
                    }
                };
                break;

            case "ProjectManager":
                url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupProjectManagers";
                onCloseCallback = function (selectedItem) {
                    if (selectedItem) {
                        $('#ProjectManager').val(selectedItem.Code);
                    }
                };
                break;

        }
        if (url) {
            OpenRadWindowLookup(url, onCloseCallback);
            //setTimeout(function () {
            //   //console.log('trying', url);
            //    var win = GetRadWindow().BrowserWindow.FindWindow(url);

            //    if (win) {
            //       //console.log('found');
            //        win.add_close(function (sender, args) {
            //            var selectedItem = sender.get_contentFrame().contentWindow.selectedItem;
            //            if (onCloseCallback) {
            //                onCloseCallback(selectedItem);
            //            }
            //        });
            //    }
            //}, 500);
        }
    }

    function OpenRadWindowLookup(url, onCloseCallback) {
        url = '@Url.Content("~")' + url;
        let Dialog = $("#LookUpDlgDiv");

        if (typeof Dialog !== 'undefined' && Dialog.length) {
            $("#LookUpDlgDiv").remove();
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }
        else {
            Dialog = $('<div id="LookUpDlgDiv"></div>');
        }

        var Title = '';

        Dialog.ejDialog({
            autoOpen: false,
            modal: true,
            height: 700,
            width: 625,
            title: "Lookup" + Title,
            enableResize: false,
            contentUrl: url,
            contentType: "iframe"
        });

        var iFrame = Dialog[0].ownerDocument.getElementsByClassName('e-iframe')[0];

        iFrame.contentWindow.Close = function (selectedItem) {

            if (onCloseCallback) {
                onCloseCallback(selectedItem);
            }

            Dialog.ejDialog('close');
        }
    }

    function autoLookup(type) {
        var finishedCallback;
        var url;
        var Prefix = '',
            ShowClosed = false,
            IsCopy = false;
        if (type.indexOf('Copy') > -1) {
            IsCopy = true;
            Prefix = 'Copy';
            type = type.replace(Prefix, '');
            ShowClosed = $('#ShowClosedArchivedJobs').is(':checked');
        }
        var ClientCode = $('#' + Prefix + 'ClientCode').val();
        var ClientName = $('#' + Prefix + 'ClientName').val();
        var DivisionCode = $('#' + Prefix + 'DivisionCode').val();
        var DivisionName = $('#' + Prefix + 'DivisionName').val();
        var ProductCode = $('#' + Prefix + 'ProductCode').val();
        var ProductName = $('#' + Prefix + 'ProductName').val();
        var JobNumber = $('#' + Prefix + 'JobNumber').val();
        var JobDescription = $('#' + Prefix + 'JobDescription').val();
        var JobComponentNumber = $('#' + Prefix + 'JobComponentNumber').val();
        var JobComponentDescription = $('#' + Prefix + 'JobComponentDescription').val();
        var focusNext = false;

        switch (type) {

            case "Client":
                if (ClientCode !== '') {
                    url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupEntity?Type=Client&ClientCode=" + ClientCode;
                }
                finishedCallback = function (result) {
                    ClientName = '';
                    if (result && result.Code) {
                        ClientName = result.Name;
                        focusNext = true;
                    }
                    setSearchValues(ClientCode, ClientName, null, null, null, null, null, null, null, null, IsCopy, focusNext);
                };
                break;

            case "Division":
                if (ClientCode !== '' && DivisionCode !== '') {
                    url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupEntity?Type=Division&ClientCode=" + ClientCode + "&DivisionCode=" + DivisionCode;
                }
               //console.log('url', url);
                finishedCallback = function (result) {
                    DivisionName = '';
                    if (result && result.Code) {
                        DivisionName = result.Name;
                        focusNext = true;
                    }
                    setSearchValues(ClientCode, ClientName, DivisionCode, DivisionName, null, null, null, null, null, null, IsCopy, focusNext);
                };
                break;

            case "Product":
                if (ClientCode !== '' && DivisionCode !== '' && ProductCode !== '') {
                    url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupEntity?Type=Product&ClientCode=" + ClientCode + "&DivisionCode=" + DivisionCode + "&ProductCode=" + ProductCode;
                }
                finishedCallback = function (result) {
                    ProductName = '';
                    if (result && result.Code) {
                        ProductName = result.Name;
                        focusNext = true;
                    }
                    setSearchValues(ClientCode, ClientName, DivisionCode, DivisionName, ProductCode, ProductName, null, null, null, null, IsCopy, focusNext);
                };
                break;

            case "Job":
                if (JobNumber !== '') {
                    url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupEntity?Type=Job&JobNumber=" + JobNumber + '&ShowClosed=' + ShowClosed + '&IsCopy=' + IsCopy;
                }
                finishedCallback = function (result) {
                    JobDescription = '';
                    JobComponentDescription = '';
                    JobComponentNumber = '';
                    if (result && result.Number) {
                        ClientCode = result.ClientCode;
                        ClientName = result.ClientName;
                        DivisionCode = result.DivisionCode;
                        DivisionName = result.DivisionName;
                        ProductCode = result.ProductCode;
                        ProductName = result.ProductName;
                        JobDescription = result.Description;
                        JobComponentNumber = result.JobComponentNumber;
                        JobComponentDescription = result.JobComponentDescription;
                        focusNext = true;
                    }
                    setSearchValues(ClientCode, ClientName, DivisionCode, DivisionName, ProductCode, ProductName, JobNumber, JobDescription, JobComponentNumber, JobComponentDescription, IsCopy, focusNext);
                };
                break;

            case "Component":
                if (JobNumber !== '' && JobComponentNumber !== '') {
                    url = "@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)LookupEntity?Type=Component&JobNumber=" + JobNumber + "&JobComponentNumber=" + JobComponentNumber + "&ShowClosed=" + ShowClosed + "&IsCopy=" + IsCopy;
                }
                finishedCallback = function (result) {
                    JobComponentDescription = '';
                    if (result && result.Number) {
                        JobComponentDescription = result.Description;
                        focusNext = true;
                    }
                    setSearchValues(ClientCode, ClientName, DivisionCode, DivisionName, ProductCode, ProductName, JobNumber, JobDescription, JobComponentNumber, JobComponentDescription, IsCopy, focusNext);
                };
                break;
        }
        if (url) {
            $.get({
                url: window.appBase + url
            }).always(function (result) {
                if (result.Success === true) {
                    finishedCallback(result.Data);
                } else {
                    if (result.Message !== '') {
                        showKendoAlert(result.Message);
                    }
                    finishedCallback(null);
                }
            });
        } else {
            finishedCallback(null);
        }
    }
    function setSearchValues(clientCode, clientName, divisionCode, divisionName, productCode, productName, jobNumber, jobDescription, jobComponentNumber, jobComponentDescription, isCopy, focusNext) {
        var prefix = '';
        if (isCopy === true) {
            prefix = 'Copy';
        }
        $('#' + prefix + 'ClientCode').val(clientCode);
        $('#' + prefix + 'ClientName').val(clientName);
        $('#' + prefix + 'DivisionCode').val(divisionCode);
        $('#' + prefix + 'DivisionName').val(divisionName);
        $('#' + prefix + 'ProductCode').val(productCode);
        $('#' + prefix + 'ProductName').val(productName);
        $('#' + prefix + 'JobNumber').data('kendoNumericTextBox').value(jobNumber);
        if (jobNumber) {
            // forces validate
            $('#' + prefix + 'JobNumber').blur();
        }
        $('#' + prefix + 'JobDescription').val(jobDescription);
        if (jobComponentNumber <= 0) {
            jobComponentNumber = null;
        }
        $('#' + prefix + 'JobComponentNumber').data('kendoNumericTextBox').value(jobComponentNumber);
        if (jobComponentNumber) {
            $('#' + prefix + 'JobComponentNumber').blur();
        }
        $('#' + prefix + 'JobComponentDescription').val(jobComponentDescription);
        if (focusNext) {
            setTimeout(function () {
                if (!clientCode) {
                    focusControl('Client', isCopy);
                } else if (!divisionCode) {
                    focusControl('Division', isCopy);
                } else if (!productCode) {
                    focusControl('Product', isCopy);
                } else if (!jobNumber) {
                    focusControl('Job', isCopy);
                } else if (!jobComponentNumber) {
                    focusControl('Component', isCopy);
                } else if (!isCopy) {
                    $('#TrafficStatus').focus();
                }
            }, 100);
        }
    }
    function focusControl(type, isCopy) {
        var prefix = '';
        if (isCopy === true) {
            prefix = 'Copy';
        }
        switch (type) {

            case "Client":
                $('#' + prefix + 'ClientCode').focus();
                break;

            case "Division":
                $('#' + prefix + 'DivisionCode').focus();
                break;

            case "Product":
                $('#' + prefix + 'ProductCode').focus();
                break;

            case "Job":
                $('#' + prefix + 'JobNumber').data('kendoNumericTextBox').focus();
                break;

            case "Component":
                $('#' + prefix + 'JobComponentNumber').data('kendoNumericTextBox').focus();
                break;
        }
    }
    function cancel() {
        CloseThisWindow();
    }
    function createSchedule() {
        kendo.ui.progress($('body'), true);

        var isCopy = $('#copy-panel').is(":visible");       
        console.log(isCopy);

        var validator = $('#ScheduleForm').kendoValidator({
            validateOnBlur: true
        }).data('kendoValidator');
        if (validator.validate() === true) {
            var data = {
                JobNumber: $('#JobNumber').val(),
                JobComponentNumber: $('#JobComponentNumber').val(),
                TrafficStatus: $('#TrafficStatus').val(),
                ProjectManager: $('#ProjectManager').val(),
                IsCopy: isCopy,
                CopyJobNumber: $('#CopyJobNumber').val(),
                CopyJobComponentNumber: $('#CopyJobComponentNumber').val(),
                IncludeStartDate: $('#IncludeStartDate').is(':checked'),
                IncludeDueDate: $('#IncludeDueDate').is(':checked'),
                IncludeTaskEmployees: $('#IncludeTaskEmployees').is(':checked'),
                IncludeTaskComment: $('#IncludeTaskComment').is(':checked'),
                IncludeDueDateComment: $('#IncludeDueDateComment').is(':checked'),
                ShowClosed: $('#ShowClosedArchivedJobs').is(':checked'),
                IncludeTaskStatus: $('#IncludeTaskStatus').is(':checked')
            };
            $.post({
                url: '@(Html.Raw(Url.Action("Create")))',
                data: data
            }).always(function (response) {
                kendo.ui.progress($('body'), false);
                if (response.Success === true) {
                    if (response.Data.url) {
                        RefreshWindow(response.Data.url, true, true);
                        CloseThisWindow();
                    }
                } else {
                    if (response.Data.Errors && response.Data.Errors.length > 0) {
                        showKendoAlert(response.Data.Errors.join("\n"));
                    }
                }
            });
        } else {
            kendo.ui.progress($('body'), false);
        }
    }

</script>
