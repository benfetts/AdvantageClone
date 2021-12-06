@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

<style>
    .JobBlock {
        display: block
    }

    .k-i-calendar {
        height: 1em !important;
    }

    .k-picker-wrap .k-input {
        height: 2em !important;
        line-height: 2em !important;
        min-height: 2em !important;
    }

    .k-picker-wrap {
        height: 2em !important;
    }

        .k-picker-wrap .k-select {
            height: 2em !important;
            min-height: 2em !important;
            line-height: 2em !important;
        }

    .k-dropdown .k-dropdown-wrap {
        /*font-size: 13px !important;*/
        padding-top: 1px;
        height: 2em !important;
    }

    .k-widget.k-dropdown {
        height: 2em !important;
    }

    .k-widget.k-numerictextbox {
        height: 2em !important;
    }

        .k-widget.k-numerictextbox .k-numeric-wrap .k-input {
            height: 2em !important;
            line-height: 2em !important;
        }

        .k-widget.k-numerictextbox .k-numeric-wrap {
            height: 2em !important;
        }
</style>

<div id="JobInfo" class="wv-bar k-widget" style="width:100%;background-color: white;padding: 0px 0px 0px 0px;display:inline-block;border-radius:4px;">
    <ul id="jobInfoPanelBar">
        <li class="k-state-active">
            <span id="PanelHeader" class="k-link k-state-selected">
                <span style="font-weight:600;font-size:14px;"> Project Schedule</span>
                <span id="ClientName" style="font-size:14px;font-weight:600;float:right;padding-right:10px;"></span>
            </span>
            <div style="padding-top: 30px;padding-bottom: 20px;padding-left: 30px; border-bottom: none;">
                <div style="width:250px;float:left;margin:4px;padding-right: 30px;">
                    <div style="padding-bottom: 4px; color: #767676;">Status</div>
                    <input id="Status" type="text" style="width: 240px; color: #767676;" />
                </div>
                <div id="CalcStartDateWrapper" style="width:20px;float:left;margin:6px;@(If(Model.CalculateByPredecessor, "display:none", ""))">
                    <input type="radio" name="calcstartend" id="CalcStartDate" class="k-radio" checked="checked">
                    <label class="k-radio-label" for="CalcStartDate"></label>
                </div>
                <div style="width:110px;float:left;margin:4px;padding-right: 30px;">
                    <div style="padding-bottom: 4px; color: #767676;">Start Date</div>
                    <input id="startdate" title="Start Date" style="width: 100px; color: #767676;" />
                </div>
                <div id="CalcEndDateWrapper" style="width:20px;float:left;margin:6px;@(If(Model.CalculateByPredecessor, "display:none", ""))">
                    <input type="radio" name="calcstartend" id="CalcEndDate" class="k-radio" checked="checked">
                    <label class="k-radio-label" for="CalcEndDate"></label>
                </div>
                <div style="width:110px;float:left;margin:4px;padding-right: 30px;">
                    <div style="padding-bottom: 4px; color: #767676;">Due Date</div>
                    <input id="duedate" title="Due Date" style="width: 100px; color: #767676;" />
                </div>
                <div style="width:110px;float:left;margin:4px;padding-right: 30px;">
                    <div style="padding-bottom: 4px; color: #767676;">Completed Date</div>
                    <input id="completeddate" title="Completed Date" style="width: 100px; color: #767676;" />
                </div>
                <div style="width:160px;float:left;margin:4px;padding-right: 30px;">
                    <div style="padding-bottom: 4px; color: #767676;">Actual % Complete</div>
                    <div id="ActualComplete" style="width:150px; color: #767676;" title="Actual Percent Complete is based on all disbursed hours compared to all posted hours regardless of the Task Assignment. This differs from the Grid Percent Complete which only considers posted hours based to the specific Task Assignment."></div>
                </div>
                <div style="width:50px;float:left;margin:4px;padding-right: 20px;">
                    <div style="padding-bottom: 4px; color: #767676;">Gut %</div>
                    <input type="number" id="gutcomplete" min="0" max="100" title="% Gut Complete" style="width: 50px; color: #767676;" />
                </div>
                <div align="center" style="width:110px;float:left;margin:4px;padding-right: 20px;">
                    <div style="padding-bottom: 4px; color: #767676;">Template</div>
                    <input type="checkbox" id="TemplateCB" class="k-checkbox">
                    <label class="k-checkbox-label" for="TemplateCB"></label>
                </div>

                <div class="wv-employee-box" style="float: left;" title="Project Manager">
                    <div class="body">
                        <div class="row">
                            <div class="image-container">
                                <img id="EmpImage" onerror="@Href("~/Images/Icons/White/256/user.png")" au-target-id="117">
                            </div>
                            <div class="name">
                                <div>Project Manager</div>
                                <span id="ProjectManagerName" class="name-span"></span>
                            </div>
                            <div class="button">
                            </div>
                        </div>
                    </div>
                </div>
                <div></div>
                <div style="width:100%;display:inline-block;">
                </div>
            </div>
        </li>
    </ul>
</div>

<script>

    var jobInfoChange = false;
    var dateChange = false;

    var psModel = {
        JobNumber: 0,
        JobComponentNumber: 0,
        ClientCode: "",
        DivisionCode: "",
        ProductCode: "",
        UsingATaskLevelFilter: () => {
            return false;
        }
    }

    $(() => {
        $("#jobInfoPanelBar").kendoPanelBar({
            expand: (e) => {
                setTimeout(() => {
                    _resize();
                }, 250);
            },
            collapse: (e) => {
                setTimeout(() => {
                    _resize();
                }, 250);
            },
            contentLoad: (e) => {
                _resize();
            }
        }).data("kendoPanelBar");

        $("#startdate").kendoDatePicker({
            change: onStartDateChange,
            format: 'MM/dd/yyyy',
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy']
        }).data("kendoDatePicker");
        $("#duedate").kendoDatePicker({
            change: onDueDateChange,
            format: 'MM/dd/yyyy',
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy']
        }).data("kendoDatePicker");
        $("#completeddate").kendoDatePicker({
            change: onDueDateChange,
            format: 'MM/dd/yyyy',
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy']
        }).data("kendoDatePicker");

        $("#gutcomplete").kendoNumericTextBox({
            spinners: false,
            min: 0,
            max: 100,
            change: onPercentChange}).data("kendoNumericTextBox");

        $("#Status").kendoDropDownList({
            dataTextField: "Name",
            dataValueField: "Code",
            dataSource: new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "@Href("~/Utilities/SearchStatus")",
                        dataType: "json"
                    }
                }
            }),
            change: onStatusChange
        }).data('kendoDropDownList');

        $("#ActualComplete").kendoProgressBar({
            type: "percent",
            animation: {
                duration: 600
            }
        }).data("kendoProgressBar");

        loadJobInfo();
        loadProjectManager();

        $('#saveButton').on('click', saveJobInfo);
        $('#cancelButton').on('click', loadJobInfo);
        $('#refreshProjectSchedule').on('click', loadJobInfo);

        $("#TemplateCB").on('click', (() => {
            jobInfoChange = true;
            setSave();
        }));

        $.ajax({
            type: "GET",
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetHeaderLock")",
            dataType: "json",
            success: function (response) {
                if (response === true) {
                    $('#CalcStartDate').attr('disabled', true);
                    $('#CalcEndDate').attr('disabled', true);
                }
            }
        });

        $(document).on("change", "input[type='radio']", function () {
            if (this.id === 'CalcStartDate' || this.id === 'CalcEndDate') {
                var byStartDate = 0;

                if (this.id === 'CalcStartDate') {
                    byStartDate = 1;
                }
                else if (this.id === 'CalcEndDate') {
                    byStartDate = 0;
                }

                var data = {
                    JobNumber: @Model.JobNumber,
                    JobComponentNumber: @Model.JobComponentNumber,
                    ByStartDate: byStartDate
                };

                $.ajax({
                    type: "POST",
                    url: "@Href("~/ProjectManagement/ProjectSchedule/CalcByStartDate")",
                    data: data,
                    dataType: "json",
                    success: function (response) {
                    }
                });
            }
        });
    });

    function onExpand(e) {
        setTimeout(() => {
            resizeGrid();
        }, 350);
    }

    function onCollapse(e) {
        setTimeout(() => {
            resizeGrid();
        }, 350);
    }

    function onStartDateChange(e) {
        dateChange = true;
        setSave();
    }

    function onDueDateChange(e) {
        dateChange = true;
        setSave();
    }

    function onStatusChange(e) {
        jobInfoChange = true;
        setSave();
    }

    function onCommentsChange(e) {
        jobInfoChange = true;
        setSave();
    }

    function onPercentChange(e) {
        jobInfoChange = true;
        setSave();
    }

    function pad(str, max) {
        str = str.toString();
        return str.length < max ? pad("0" + str, max) : str;
    }

    function saveJobInfo(e) {
        var dfd = $.Deferred();

        if (jobInfoChange === true || dateChange == true) {
            var PercentComlete = $('#gutcomplete').val() == '' ? 0 : $('#gutcomplete').val();
            var droplist = $('#Status').data('kendoDropDownList');
            var StatusCode = droplist.value();

            var datePicker = $("#startdate").data("kendoDatePicker");
            var StartDate = datePicker.value();
            if (StartDate !== null) {
                StartDate = datePicker.value().toDateString();
            }

            datePicker = $("#duedate").data("kendoDatePicker");
            var DueDate = datePicker.value();
            if (DueDate !== null) {
                DueDate = DueDate.toDateString();
            }

            datePicker = $("#completeddate").data("kendoDatePicker");
            var CompletedDate = datePicker.value();
            if (CompletedDate !== null) {
                CompletedDate = CompletedDate.toDateString();
            }

            //var TrafficComments = $('#CommentsTextArea').val();
            var Template = $('#TemplateCB').prop('checked');

            $.ajax({
                type: "Post",
                url: "@Href("~/ProjectManagement/ProjectSchedule/PutJobInfo")",
                data: {
                    JobNumber: @Model.JobNumber,
                    JobComponentNumber: @Model.JobComponentNumber,
                    PercentComplete: PercentComlete,
                    StatusCode: StatusCode,
                    DueDate: DueDate,
                    StartDate: StartDate,
                    CompletedDate: CompletedDate,
                    Template: Template
                },
                dataType: "json",
                success: function (response) {
                    assigmentsChange = false;
                    loadProjectManager();
                    dfd.resolve();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    var msg = '';
                    if (jqXHR.status === 0) {
                        msg = 'Not connect.\n Verify Network.';
                    } else if (jqXHR.status == 404) {
                        msg = 'Requested page not found. [404]';
                    } else if (jqXHR.status == 500) {
                        msg = 'Internal Server Error [500].';
                    } else if (textStatus === 'parsererror') {
                        msg = 'Requested JSON parse failed.';
                    } else if (textStatus === 'timeout') {
                        msg = 'Time out error.';
                    } else if (textStatus === 'abort') {
                        msg = 'Ajax request aborted.';
                    } else {
                        msg = 'Uncaught Error.\n' + jqXHR.responseText;
                    }
                    dfd.resolve();
                    showKendoAlert(msg + errorThrown);
                }
            });
            jobInfoChange = false;
            dateChange = false;
            setSave();
        }
        else {
            dfd.resolve();
        }
        return dfd;
    }

    function convertTZ(date, tzString) {
        if (date != null) {
            return new Date((typeof date === "string" ? new Date(date) : date).toLocaleString("en-US", { timeZone: tzString }));
        }

        return null;
    }


    function loadJobInfo(e) {
        $.ajax({
            type: "Get",
            url: "@Href("~/Utilities/GetJobInfoForSchedule")",
            data: {
                JobNumber: @Model.JobNumber,
                JobComponentNumber: @Model.JobComponentNumber
            },
            dataType: "json",
            success: function (response) {               

                $("#JobNumbeJobComponent").text(pad(response.JobNumber.toString(), 6) + '/' + pad(response.ComponentNumber.toString(), 3) + ' - ' + response.ComponentDescription);
                if (response.JobTypeDescription != null) {
                    $("#JobType").text(" " + response.JobTypeDescription);
                }

                if ((response.Client == response.Division && response.Division == response.Product) || (response.Division == null && response.Product == null)) {
                    $('#ClientName').text(response.Client + " - " + pad(response.JobNumber.toString(), 6) + '/' + pad(response.ComponentNumber.toString(), 3) + ' - ' + response.ComponentDescription + ' - ' + response.JobTypeDescription);
                }
                else if (response.Client == response.Division || response.Division == response.Product || response.Division == null || response.Product == null) {
                    var Name = response.Client + "/";
                    Name += typeof response.Product !== "undefined" ? response.Product : response.Division;
                    $('#ClientName').text(Name + " - " + pad(response.JobNumber.toString(), 6) + '/' + pad(response.ComponentNumber.toString(), 3) + ' - ' + response.ComponentDescription + ' - ' + response.JobTypeDescription);
                }
                else {
                    $('#ClientName').text(response.Client + '/' + response.Division + "/" + response.Product + " - " + pad(response.JobNumber.toString(), 6) + '/' + pad(response.ComponentNumber.toString(), 3) + ' - ' + response.ComponentDescription + ' - ' + response.JobTypeDescription);
                }

                if (response.Template != 0) {
                    $('#TemplateCB').prop('checked', true);
                }
                else {
                    $('#TemplateCB').prop('checked', false);
                }

                if (response.PercentComplete !== null) {
                    var gutcom = $('#gutcomplete').data('kendoNumericTextBox');
                    gutcom.value(response.PercentComplete);
                }

                var droplist = $('#Status').data('kendoDropDownList');
                droplist.value(response.StatusCode);

                var datePicker = $("#startdate").data("kendoDatePicker");
                datePicker.value(response.StartDate);

                datePicker = $("#duedate").data("kendoDatePicker");
                datePicker.value(response.DueDate);

                datePicker = $("#completeddate").data("kendoDatePicker");
                datePicker.value(response.CompletedDate);

                //$('#CommentsTextArea').text(response.TrafficComments);


                if (response.CalculateByPredecessor) {

                    $('#OrderPredecessorSpan').text("Predecessor");
                    $("#OrderPredecessor").attr('title', 'Click to calculate by Order');
                }
                else {

                    $('#OrderPredecessorSpan').text("Order");
                    $("#OrderPredecessor").attr('title', 'Click to calculate by Predecessor');
                }

                if (response.ActualEMPTaskHours > 0 && response.ProjectedHours > 0) {
                    $("#ActualComplete").data('kendoProgressBar').value(Math.round(((response.ActualEMPTaskHours) / response.ProjectedHours) * 100.0));
                }
                else {
                    $("#ActualComplete").data('kendoProgressBar').value(0);
                }

                if (response.ByStartDate != 0) {
                    $('#CalcStartDate').prop('checked', true);
                    $('#CalcEndDate').prop('checked', false);
                }
                else {
                    $('#CalcStartDate').prop('checked', false);
                    $('#CalcEndDate').prop('checked', true);
                }

                CalculateByPredecessor = response.CalculateByPredecessor;
                CalculateByPredecessorChange(response.CalculateByPredecessor);

                psModel.ClientCode = response.ClientCode;
                psModel.JobNumber = response.JobNumber;
                psModel.JobComponentNumber = response.ComponentNumber;
                psModel.DivisionCode = response.DivisionCode;
                psModel.ProductCode = response.ProductCode;
            }
        });

        loadProjectManager();

        jobInfoChange = false;

        setSave();
    }

    function loadProjectManager() {
        $.ajax({
            type: "Get",
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetProjectManager")",
            data: {
                JobNumber: @Model.JobNumber,
                JobComponentNumber: @Model.JobComponentNumber
            },
            dataType: "json",
            success: function (response) {
                if (response.EmpCode != null) {
                    $("#EmpImage").attr('src', "@Href("~/Utilities/EmployeePicture/")" + response.EmpCode);
                    $("#EmpImage").attr('title', response.EmpFName + ((response.EmpMI == null || response.EmpMI == '') ? ' ' : ' ' + response.EmpMI + '. ') + response.EmpLName);
                    $("#ProjectManagerName").text(response.EmpFName + ((response.EmpMI == null || response.EmpMI == '') ? ' ' : ' ' + response.EmpMI + '. ') + response.EmpLName);
                }
                else {
                    $("#ProjectManagerName").text('');
                    $("#EmpImage").attr('src', "@Href("~/Images/Icons/White/256/user.png")");
                    $("#EmpImage").attr('title', 'Project Manager');
                }
            }
        });

    }
</script>
