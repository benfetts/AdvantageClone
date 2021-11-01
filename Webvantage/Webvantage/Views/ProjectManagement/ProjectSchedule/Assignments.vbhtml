@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

<style>
    .form-group {
        margin-left: unset !important;
        margin-right: unset !important;
    }
    textarea {
        resize: both !important;
    }
</style>

<div style="padding-top:5px;">
    <div class="wv-bar k-widget " style="width:100%;background-color: white;padding: 0px 0px 0px 0px;border-bottom: 1px solid #CCC;display:inline-block;border-radius:4px;">
        <ul id="panelbardetail" class="k-widget k-reset k-header k-panelbar">
            <li class="k-state-active k-item k-first k-last k-state-highlight">
                <span id="Details" class="k-link k-state-selected k-header">Details</span>
                <div>
                    <div class="form-horizontal" style="padding-left:10px; padding-top:10px; padding-bottom:10px;">
                        <div>Comments:</div>                        
                        <textarea id="CommentsTextArea" class="k-textbox" style="height: 60px; width:1040px; margin-top: 5px; padding-left: 5px;"></textarea>
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <div style="padding-top:10px;"></div>
    <div class="wv-bar k-widget " style="width:100%;background-color: white;padding: 0px 0px 0px 0px;border-bottom: 1px solid #CCC;display:inline-block;border-radius:4px;">
        <ul id="panelbarassignments" class="k-widget k-reset k-header k-panelbar">
            <li class="k-state-active k-item k-first k-last k-state-highlight">
                <span id="Assignments" class="k-link k-state-selected k-header">Assignments</span>
                <div>
                    <div style="padding-top:10px; padding-bottom:10px;">
                        @If Not String.IsNullOrWhiteSpace(Model.Assignment1Label) Then
                            @<div class="form-group">
                                <label class="control-label col-sm-2" for="JobTraffic_Assign1" style="font-weight: normal !important;">@Model.Assignment1Label:</label>
                                <div>
                                    @*@(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.Assign1).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.class = "code-6 assignment", .data_employee = ""}))*@
                                    @*@(Html.Kendo.TextBoxFor(Function(m) m.Assignment1Name).Enable(False).HtmlAttributes(New With {.class = "assignment-name text-60"}))*@
                                    <input id="Assignment1" style="width:250px" class="assignment-name text-60" />
                                    <span class="k-invalid-msg" data-for="JobTraffic.Assign1"></span>
                                    @IIf(Model.ProjectManagerColumn = "TR_TITLE1", "(Manager)", "")
                                </div>
                            </div>End If

                        @If Not String.IsNullOrWhiteSpace(Model.Assignment2Label) Then
                            @<div class="form-group">
                                <label class="control-label col-sm-2" for="JobTraffic_Assign2" style="font-weight: normal !important;">@Model.Assignment2Label:</label>
                                <div>
                                    <input id="Assignment2" style="width:250px" class="assignment-name text-60" />
                                    <span class="k-invalid-msg" data-for="JobTraffic.Assign2"></span>
                                    @IIf(Model.ProjectManagerColumn = "TR_TITLE2", "(Manager)", "")
                                </div>
                            </div>End If

                        @If Not String.IsNullOrWhiteSpace(Model.Assignment3Label) Then
                            @<div class="form-group">
                                <label class="control-label col-sm-2" for="JobTraffic_Assign3" style="font-weight: normal !important;">@Model.Assignment3Label:</label>
                                <div>
                                    <input id="Assignment3" style="width:250px" class="assignment-name text-60" />
                                    <span class="k-invalid-msg" data-for="JobTraffic.Assign3"></span>
                                    @IIf(Model.ProjectManagerColumn = "TR_TITLE3", "(Manager)", "")
                                </div>
                            </div>End If

                        @If Not String.IsNullOrWhiteSpace(Model.Assignment4Label) Then
                            @<div class="form-group">
                                <label class="control-label col-sm-2" for="JobTraffic_Assign4" style="font-weight: normal !important;">@Model.Assignment4Label:</label>
                                <div>
                                    <input id="Assignment4" style="width:250px" class="assignment-name text-60" />
                                    <span class="k-invalid-msg" data-for="JobTraffic.Assign4"></span>
                                    @IIf(Model.ProjectManagerColumn = "TR_TITLE4", "(Manager)", "")
                                </div>
                            </div>End If

                        @If Not String.IsNullOrWhiteSpace(Model.Assignment5Label) Then
                            @<div class="form-group">
                                <label class="control-label col-sm-2" for="JobTraffic_Assign5" style="font-weight: normal !important;">@Model.Assignment5Label:</label>
                                <div>
                                    <input id="Assignment5" style="width:250px" class="assignment-name text-60" />
                                    <span class="k-invalid-msg" data-for="JobTraffic.Assign5"></span>
                                    @IIf(Model.ProjectManagerColumn = "TR_TITLE5", "(Manager)", "")
                                </div>
                            </div>End If

                    </div>
                </div>
            </li>
        </ul>
    </div>
    <div style="padding-top:10px;"></div>
    <div class="wv-bar k-widget " style="width:100%;background-color: white;padding: 0px 0px 0px 0px;border-bottom: 1px solid #CCC;display:inline-block;border-radius:4px;">
        <ul id="panelbarother" class="k-widget k-reset k-header k-panelbar">
            <li class="k-state-active k-item k-first k-last k-state-highlight">
                <span id="Othe Information" class="k-link k-state-selected k-header">Other Information</span>
                <div>
                    <div style="padding-top:10px; padding-bottom:10px;">
                        <div class="form-group">
                            <label class="control-label col-sm-2" style="font-weight: normal !important;">Date Shipped:</label>
                            <div>
                                <input id="dateShipped" title="Date Shipped" style="width:100px" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" style="font-weight: normal !important;">Received By:</label>
                            <div>
                                <input id="ReceivedBy" title="Received By" style="width:250px" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" style="font-weight: normal !important;">Date Delivered:</label>
                            <div>
                                <input id="dateDelivered" title="Date Delivered" style="width:100px" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" style="font-weight: normal !important;">Reference:</label>
                            <div>
                                <input id="Reference" title="Reference" style="width:250px" />
                            </div>
                        </div>
                    </div>
                </div>
            </li>
        </ul>
    </div>

    
</div>


    <script>
    var assigmentsChange = false;
    var commentsChange = false;
    var otherInformationChange = false;

    //valueTemplate:'<img class="k-state-default" src="@Href("~/Utilities/EmployeePicture/")#:data.Code#" style="height:22px;width:22px;border-radius:50%;margin:2px 2px 2px 2px; float:left"><span>#:data.NameOnly#</span>',


    $(() => {
        $('.assignment-name').kendoComboBox({
            dataTextField: "NameOnly",
            dataValueField: "Code",
            template: '<img class="k-state-default" src="@Href("~/Utilities/EmployeePicture/")#:data.Code#" style="height:32px;width:32px;border-radius:50%;margin:5px 5px 5px 5px; float:left"></img>' +
                '<div><span class="k-state-default">#: data.NameOnly #<p style="font-size:smaller">#:data.Title#</p></span></div>',
            dataSource: new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "@Href("~/Utilities/SearchEmployee")",
                        dataType: "json"
                    }
                }
            }),
            change: onAssignmentChange
        }).data('kendoComboBox');

        loadAssignmentChanges();

        $('#CommentsTextArea').on("change", onCommentsChange);
        $("#dateShipped").kendoDatePicker({
            change: onDateShippedChange
        }).data("kendoDatePicker");
        $("#dateDelivered").kendoDatePicker({
            change: onDateDeliveredChange
        }).data("kendoDatePicker");

        $('#ReceivedBy').change(onOtherInfoChange);
        $('#Reference').change(onOtherInfoChange);

        $('#saveButton').on('click', saveAssigments);
        $('#cancelButton').on('click', loadAssignmentChanges);

        $("#panelbardetail").kendoPanelBar({
            expand: onExpand,
            collapse: onCollapse
        }).data("kendoPanelBar");

        $("#panelbarassignments").kendoPanelBar({
            expand: onExpand,
            collapse: onCollapse
        }).data("kendoPanelBar");

        $("#panelbarother").kendoPanelBar({
            expand: onExpand,
            collapse: onCollapse
        }).data("kendoPanelBar");

        let _isClientPortal = "@Model.CanUserEdit";

        if (_isClientPortal == "False") {
            
            $("#Assignment1").data("kendoComboBox").enable(false);
            $("#Assignment2").data("kendoComboBox").enable(false);
            $("#Assignment3").data("kendoComboBox").enable(false);
            $("#Assignment4").data("kendoComboBox").enable(false);
            $("#Assignment5").data("kendoComboBox").enable(false);
            
            
        }


    });

    function onExpand(e) {
        setTimeout(() => {
            $(window).trigger('resize');
        }, 200);

        //resizeGrid();
        //$(window).trigger('resize');
    }

    function onCollapse(e) {
        setTimeout(() => {
            $(window).trigger('resize');
        }, 200);

        //resizeGrid();
        //$(window).trigger('resize');
    }

    function onCommentsChange(e) {
        commentsChange = true;
        setSave();
    }

    function onAssignmentChange(e) {
        assigmentsChange = true;
        setSave();
    }

    function saveAssigments(e) {
        var Assignment1Code = $('#Assignment1').val();
        var Assignment2Code = $('#Assignment2').val();
        var Assignment3Code = $('#Assignment3').val();
        var Assignment4Code = $('#Assignment4').val();
        var Assignment5Code = $('#Assignment5').val();
        var TrafficComments = $('#CommentsTextArea').val();

        if (assigmentsChange === true || commentsChange === true) {
            $.ajax({
                type: "Post",
                url: "@Href("~/ProjectManagement/ProjectSchedule/PutAssigments")",
                data: {
                    JobNumber: @Model.JobNumber,
                    JobComponentNumber: @Model.JobComponentNumber,
                    Assignment1Code: Assignment1Code,
                    Assignment2Code: Assignment2Code,
                    Assignment3Code: Assignment3Code,
                    Assignment4Code: Assignment4Code,
                    Assignment5Code: Assignment5Code,
                    TrafficComments: TrafficComments
                },
                dataType: "json",
                success: function (response) {
                    assigmentsChange = false;
                    commentsChange = false;
                    loadProjectManager();
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
                    showKendoAlert(msg + errorThrown);
                }
            });
            assigmentsChange = false;
            commentsChange = false;
            setSave();
        }

        if (otherInformationChange === true) {
            saveOtherInfo();
            setSave();
        }

    }

    function loadAssignmentChanges(e) {
        $.ajax({
            type: "Get",
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetAssigments")",
            data: {
                JobNumber: @Model.JobNumber,
                JobComponentNumber: @Model.JobComponentNumber
            },
            dataType: "json",
            success: function (response) {
                assigmentsChange = false;
                var combobox = $("#Assignment1").data("kendoComboBox");
                if (combobox) {
                    combobox.value(response.Assignment1Code);
                }                  
                combobox = $("#Assignment2").data("kendoComboBox");
                if (combobox) {
                    combobox.value(response.Assignment2Code);
                }                
                combobox = $("#Assignment3").data("kendoComboBox");
                if (combobox) {
                    combobox.value(response.Assignment3Code);
                }
                combobox = $("#Assignment4").data("kendoComboBox");
                if (combobox) {
                    combobox.value(response.Assignment4Code);
                }               
                combobox = $("#Assignment5").data("kendoComboBox");
                if (combobox) {
                    combobox.value(response.Assignment5Code);
                }                
                $('#CommentsTextArea').val(response.TrafficComments === null ? '' : response.TrafficComments);
                loadOtherInfo();

                assigmentsChange = false;
                commentsChange = false;
                setSave();
            },
            error: function (jqXHR, exception) {
                var msg = '';
                if (jqXHR.status === 0) {
                    msg = 'Not connect.\n Verify Network.';
                } else if (jqXHR.status == 404) {
                    msg = 'Requested page not found. [404]';
                } else if (jqXHR.status == 500) {
                    msg = 'Internal Server Error [500].';
                } else if (exception === 'parsererror') {
                    msg = 'Requested JSON parse failed.';
                } else if (exception === 'timeout') {
                    msg = 'Time out error.';
                } else if (exception === 'abort') {
                    msg = 'Ajax request aborted.';
                } else {
                    msg = 'Uncaught Error.\n' + jqXHR.responseText;
                }
                showKendoAlert(msg);
            }

        });
    }

    function saveOtherInfo() {
        if (otherInformationChange === true) {
            var DateShipped;
            var ReceivedBy;
            var DateDelivered;
            var Reference;

            var datePicker = $("#dateShipped").data("kendoDatePicker");
            DateShipped = datePicker.value();
            datePicker = $("#dateDelivered").data("kendoDatePicker");
            DateDelivered = datePicker.value();

            ReceivedBy = $('#ReceivedBy').val()
            Reference = $('#Reference').val()

            $.ajax({
                type: "Post",
                url: "@Href("~/ProjectManagement/ProjectSchedule/PutOtherInformation")",
                data: {
                    JobNumber: @Model.JobNumber,
                    JobComponentNumber: @Model.JobComponentNumber,
                    DateShipped: DateShipped,
                    ReceivedBy: ReceivedBy,
                    DateDelivered: DateDelivered,
                    Reference: Reference
                },
                dataType: "json",
                success: function (response) {
                    otherInformationChange = false;
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
                    showKendoAlert(msg + errorThrown);
                }
            });
            otherInformationChange = false;
            setSave();
        }
    }

    function loadOtherInfo(e) {

        $.ajax({
            type: "Get",
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetOtherInformation")",
            data: {
                JobNumber: @Model.JobNumber,
                JobComponentNumber: @Model.JobComponentNumber
            },
            dataType: "json",
            success: function (response) {

                var datePicker = $("#dateShipped").data("kendoDatePicker");
                datePicker.value(response.DateShipped);
                datePicker = $("#dateDelivered").data("kendoDatePicker");
                datePicker.value(response.DateDelivered);

                $('#ReceivedBy').val(response.ReceivedBy);
                $('#Reference').val(response.Reference);
            }
        });

        otherInformationChange = false;
        setSave();
    }

    function onDateShippedChange(e) {
        otherInformationChange = true;
        setSave();
    }

    function onDateDeliveredChange(e) {
        otherInformationChange = true;
        setSave();
    }

    function onOtherInfoChange() {
        otherInformationChange = true;
        setSave();
    }


    </script>
