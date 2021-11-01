@ModelType AdvantageFramework.ProjectSchedule.Classes.Schedule

<script src="@Url.Content("~/Scripts/jszip.min.js")"></script>
<script src="@Url.Content("~/JScripts/EstimatedScheduleDlg.js")"></script>

@Code

    ViewData("Title") = "Project Schedule"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
    ViewData("IsBootstrap") = True

    Dim FilterString As String = ""
    Dim StringBuilder As New System.Text.StringBuilder

    If Not Request.QueryString("Emp") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Emp=")
        StringBuilder.Append(Request.QueryString("Emp").ToString())

    End If

    If Not Request.QueryString("Task") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Task=")
        StringBuilder.Append(Request.QueryString("Task").ToString())

    End If

    If Not Request.QueryString("Role") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Role=")
        StringBuilder.Append(Request.QueryString("Role").ToString())

    End If

    If Not Request.QueryString("Cut") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Cut=")
        StringBuilder.Append(Request.QueryString("Cut").ToString())

    End If

    If Not Request.QueryString("Comp") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Comp=")
        StringBuilder.Append(Request.QueryString("Comp").ToString())

    End If

    If Not Request.QueryString("Pend") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Pend=")
        StringBuilder.Append(Request.QueryString("Pend").ToString())

    End If

    If Not Request.QueryString("Proj") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Proj=")
        StringBuilder.Append(Request.QueryString("Proj").ToString())

    End If

    If Not Request.QueryString("P") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("P=")
        StringBuilder.Append(Request.QueryString("P").ToString())

    End If

    FilterString = StringBuilder.ToString

End Code

<style>
    .k-content .form-horizontal .form-group {
        margin-left: 0;
        margin-right: 0;
    }

    #ScheduleToolBar {
        border-style: solid !important;
        border-width: 1px !important;
        border-color: #ccc !important;
        font-family: "Open Sans", Calibri, Tahoma, Verdana, Arial, sans-serif !important;
        padding: .57142857em .37142857em !important;
        border-radius: 4px !important;
        background: #e5e5e5 !important;
        box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05) !important;
        margin-top: 5px !important;
        margin-bottom: 15px !important;
        margin-left: 20px !important;
        margin-right: 20px !important;
    }

        #ScheduleToolBar .wvi-floppy-disk {
            font-size: 22px;
        }

    .k-button-icon, .k-split-button-arrow {
        padding: 2px 4px !important;
    }

    .telerik-aqua-body {
        border: 1px solid #ccc;
        border-radius: 6px;
        padding-left: 5px;
        padding-right: 5px;
        background: #fff;
        float: none !important;
        display: block;
        margin-left: 20px !important;
        margin-right: 20px !important;
        margin-top: 8px;
        box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
    }
</style>

@helper CommentsContent()

    @<div style="padding: 10px;">

        @If Me.IsClientPortal = False AndAlso Model.CanUserEdit = True Then

            @(Html.TextAreaFor(Function(m) m.JobTraffic.TrafficComments, New With {.class = "k-textbox", .style = "height: 80px; width: 100%; resize: vertical !important;"}))
        Else

            @(Html.TextAreaFor(Function(m) m.JobTraffic.TrafficComments, New With {.class = "k-textbox", .style = "height: 80px; width: 100%; resize: vertical !important;", .readonly = True}))
        End If

    </div>

End Helper

@helper OtherInformationContent()

    @<div style="padding-top:10px; padding-bottom: 10px;">
        <div class="form-horizontal">
            <div class="form-group">
                <label class="col-sm-3 col-md-2 col-lg-2 control-label" for="DateShipped">Date Shipped</label>
                <div class="col-sm-3 col-md-2 col-lg-2">
                    @(Html.Kendo().DatePickerFor(Function(m) m.JobTraffic.DateShipped).Format("d").Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.style = "width: 125px;", .data_shortdate = ""}))
                </div>
                <label class="col-sm-2 col-md-2 col-lg-2 control-label" for="ReceivedBy">Received By</label>
                <div class="col-sm-4 col-md-6 col-lg-6">
                    @(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.ReceivedBy).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.style = "width: 100%;"}))
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 col-md-2 col-lg-2 control-label" for="DateDelivered">Date Delivered</label>
                <div class="col-sm-3 col-md-2 col-lg-2">
                    @(Html.Kendo.DatePickerFor(Function(m) m.JobTraffic.DateDelivered).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).Format("d").HtmlAttributes(New With {.style = "width: 125px;", .data_shortdate = ""}))
                </div>
                <label class="col-sm-2 col-md-2 col-lg-2 control-label" for="Reference">Reference</label>
                <div class="col-sm-4 col-md-6 col-lg-6">
                    @(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.Reference).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.style = "width: 100%;"}))
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-3 col-md-2 col-lg-2"></div>
                <div class="col-sm-3 col-md-2 col-lg-2">
                    @(Html.Kendo().CheckBoxFor(Function(m) m.JobTraffic.IsTemplate).Label("Schedule Template").Enable(Model.CanUserEdit))
                </div>
                <label class="col-sm-2 col-md-2 col-lg-2 control-label" for="Reference">Job Type</label>
                <div class="col-sm-4 col-md-6 col-lg-6">
                    @(Html.Kendo().TextBoxFor(Function(m) m.JobTypeDescription).HtmlAttributes(New With {.readonly = "true", .style = "width: 100%;"}))
                </div>
            </div>
        </div>
    </div>

End Helper

@helper AssignmentsContent()

    @<div style="padding-top:10px; padding-bottom: 10px;">
        <div class="form-horizontal">

            @If Not String.IsNullOrWhiteSpace(Model.AgencySettings.Assignment1Label) Then

                @<div class="form-group">
                    <label class="control-label col-sm-2" for="JobTraffic_Assign1">@Model.AgencySettings.Assignment1Label:</label>
                    <div>
                        @(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.Assign1).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.class = "code-6 assignment", .data_employee = ""}))
                        @(Html.Kendo.TextBoxFor(Function(m) m.Assignment1Name).Enable(False).HtmlAttributes(New With {.class = "assignment-name text-60"}))
                        <span class="k-invalid-msg" data-for="JobTraffic.Assign1"></span>
                        @Model.AgencySettings.ProjectManagerLabel(AdvantageFramework.ProjectSchedule.Classes.Schedule.AgencySettingCodes.Assignment1Label)
                    </div>
                </div>                                      End If

            @If Not String.IsNullOrWhiteSpace(Model.AgencySettings.Assignment2Label) Then

                @<div class="form-group">
                    <label class="control-label col-sm-2" for="JobTraffic_Assign2">@Model.AgencySettings.Assignment2Label:</label>
                    <div>
                        @(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.Assign2).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.class = "code-6 assignment", .data_employee = ""}))
                        @(Html.Kendo.TextBoxFor(Function(m) m.Assignment2Name).Enable(False).HtmlAttributes(New With {.class = "assignment-name text-60"}))
                        <span class="k-invalid-msg" data-for="JobTraffic.Assign2"></span>
                        @Model.AgencySettings.ProjectManagerLabel(AdvantageFramework.ProjectSchedule.Classes.Schedule.AgencySettingCodes.Assignment2Label)
                    </div>
                </div>                                      End If

            @If Not String.IsNullOrWhiteSpace(Model.AgencySettings.Assignment3Label) Then

                @<div class="form-group">
                    <label class="control-label col-sm-2" for="JobTraffic_Assign3">@Model.AgencySettings.Assignment3Label:</label>
                    <div>
                        @(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.Assign3).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.class = "code-6 assignment", .data_employee = ""}))
                        @(Html.Kendo.TextBoxFor(Function(m) m.Assignment3Name).Enable(False).HtmlAttributes(New With {.class = "assignment-name text-60"}))
                        <span class="k-invalid-msg" data-for="JobTraffic.Assign3"></span>
                        @Model.AgencySettings.ProjectManagerLabel(AdvantageFramework.ProjectSchedule.Classes.Schedule.AgencySettingCodes.Assignment3Label)
                    </div>
                </div>                                      End If

            @If Not String.IsNullOrWhiteSpace(Model.AgencySettings.Assignment4Label) Then

                @<div class="form-group">
                    <label class="control-label col-sm-2" for="JobTraffic_Assign4">@Model.AgencySettings.Assignment4Label:</label>
                    <div>
                        @(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.Assign4).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.class = "code-6 assignment", .data_employee = ""}))
                        @(Html.Kendo.TextBoxFor(Function(m) m.Assignment4Name).Enable(False).HtmlAttributes(New With {.class = "assignment-name text-60"}))
                        <span class="k-invalid-msg" data-for="JobTraffic.Assign4"></span>
                        @Model.AgencySettings.ProjectManagerLabel(AdvantageFramework.ProjectSchedule.Classes.Schedule.AgencySettingCodes.Assignment4Label)
                    </div>
                </div>                                      End If

            @If Not String.IsNullOrWhiteSpace(Model.AgencySettings.Assignment5Label) Then

                @<div class="form-group">
                    <label class="control-label col-sm-2" for="JobTraffic_Assign5">@Model.AgencySettings.Assignment5Label:</label>
                    <div>
                        @(Html.Kendo.TextBoxFor(Function(m) m.JobTraffic.Assign5).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.class = "code-6 assignment", .data_employee = ""}))
                        @(Html.Kendo.TextBoxFor(Function(m) m.Assignment5Name).Enable(False).HtmlAttributes(New With {.class = "assignment-name text-60"}))
                        <span class="k-invalid-msg" data-for="JobTraffic.Assign5"></span>
                        @Model.AgencySettings.ProjectManagerLabel(AdvantageFramework.ProjectSchedule.Classes.Schedule.AgencySettingCodes.Assignment5Label)
                    </div>
                </div>                                      End If

        </div>
    </div>

End Helper

@helper RelatedJobsContent()

    @<div style="padding-top: 10px; padding-bottom: 10px;">
        <div class="form-horizontal">
            <div class="form-group">
                <label class="control-label col-sm-4 col-md-3 col-lg-3" for="JobsThatPrecede">Jobs that precede this job</label>
                <div class="col-sm-6 col-md-7 col-lg-7">
                    @(Html.ListBox("JobsThatPrecede", New SelectList({""}), New With {.class = "form-control", .size = "6", .onchange = "jobsThatPrecedeChanged()"}))
                </div>
                <div class="col-sm-2 col-md-2 col-lg-2">

                    @If Me.IsClientPortal = False AndAlso Model.CanUserEdit Then

                        @(Html.Kendo.Button().Name("DeleteJobsThatPrecede").Content("").Events(Sub(e)
                                                                                                   e.Click("deleteJobThatPrecede")
                                                                                               End Sub).Enable(False).Icon("close").HtmlAttributes(New With {.style = "width: 35px;", .type = "button"}))
                        @(Html.Kendo.Button().Name("AddJobsThatPrecede").Content("").Events(Sub(e)
                                                                                                e.Click("addJobThatPrecede")
                                                                                            End Sub).Icon("plus").HtmlAttributes(New With {.style = "width: 35px;", .type = "button"}))
                    End If

                </div>
            </div>
            <div class="form-group">
                <Label class="control-label col-sm-4 col-md-3 col-lg-3" for="JobsThatFollow">Jobs that follow this job</Label>
                <div class="col-sm-6 col-md-7 col-lg-7">
                    @(Html.ListBox("JobsThatFollow", New SelectList({""}), New With {.class = "form-control", .size = "6", .onchange = "jobsThatFollowChanged()"}))
                </div>
                <div class="col-sm-2 col-md-2 col-lg-2">

                    @If Me.IsClientPortal = False AndAlso Model.CanUserEdit Then

                        @(Html.Kendo.Button().Name("DeleteJobsThatFollow").Content("").Events(Sub(e)
                                                                                                  e.Click("deleteJobThatFollow")
                                                                                              End Sub).Enable(False).Icon("close").HtmlAttributes(New With {.style = "width: 35px;", .type = "button"}))
                    End If

                </div>
            </div>
        </div>
    </div>

End Helper

@helper TaskDetailsContent()

    @<div style="padding-top:10px; padding-bottom: 10px;" class="row">
        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-sm-3 col-md-2 col-lg-2 control-label">

                    @Code

                        Dim CalcByStartDateEnabled As Boolean = True

                        If Not Me.IsClientPortal AndAlso Model.CanUserEdit AndAlso Not Model.AgencySettings.IsScheduleCalculationLocked Then

                            CalcByStartDateEnabled = True

                        Else

                            CalcByStartDateEnabled = False

                        End If

                        If Model.CalculateByPredecessor Then

                            Model.JobTraffic.JobComponent.TrafficScheduleBy = 1

                        End If

                    End Code

                    @If Not CalcByStartDateEnabled Then

                        @<label for="JobTraffic_JobComponent_DueDate">Start Date</label>

                    End If

                    @(Html.Kendo.RadioButtonFor(Function(m) m.JobTraffic.JobComponent.TrafficScheduleBy).Enable(CalcByStartDateEnabled).Value(1).Label(If(CalcByStartDateEnabled, "Start Date", "")).Checked(Model.JobTraffic.JobComponent.TrafficScheduleBy.GetValueOrDefault(0) = 1 OrElse Model.CalculateByPredecessor).HtmlAttributes(New With {.class = "force-save"}))

                </div>
                <div class="col-sm-3 col-md-2 col-lg-2">
                    @(Html.Kendo().DatePickerFor(Function(m) m.JobTraffic.JobComponent.StartDate).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).Format("d").HtmlAttributes(New With {.style = "width: 125px;", .class = "force-save", .data_shortdate = ""}))
                </div>
                <div class="col-sm-2 col-md-2 col-lg-2 control-label">

                    @Code Dim CalcByDueDateEnabled As Boolean = True

                        If Not Me.IsClientPortal AndAlso Model.CanUserEdit AndAlso Not Model.AgencySettings.IsScheduleCalculationLocked AndAlso Not Model.CalculateByPredecessor Then

                            CalcByDueDateEnabled = True

                        Else

                            CalcByDueDateEnabled = False

                        End If

                    End Code

                    @(Html.Kendo.RadioButtonFor(Function(m) m.JobTraffic.JobComponent.TrafficScheduleBy).Enable(CalcByDueDateEnabled).Value(0).Label(If(CalcByDueDateEnabled, "Due Date", "")).Checked(Model.JobTraffic.JobComponent.TrafficScheduleBy.GetValueOrDefault(0) = 0 AndAlso Not Model.CalculateByPredecessor).HtmlAttributes(New With {.class = "force-save"}))

                    @If Not CalcByDueDateEnabled Then

                        @<label for="JobTraffic_JobComponent_DueDate">Due Date</label>

                    End If

                </div>
                <div class="col-sm-3 col-md-2 col-lg-2">
                    @(Html.Kendo().DatePickerFor(Function(m) m.JobTraffic.JobComponent.DueDate).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).Format("d").HtmlAttributes(New With {.id = "ScheduleDueDate", .style = "width: 125px;", .class = "force-save", .data_shortdate = ""}))
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 col-md-2 col-lg-2 control-label " for="GutPercentComplete">Gut % Complete</label>
                <div class="col-sm-3 col-md-2 col-lg-2">
                    @(Html.Kendo.NumericTextBoxFor(Function(m) m.JobTraffic.PercentComplete).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).Decimals(2).Format("n2").Spinners(False).HtmlAttributes(New With {.style = "width: 125px;"}))
                </div>
                <label class="col-sm-2 col-md-2 col-lg-2 control-label" for="ScheduleCompletedDate">Completed Date</label>
                <div class="col-sm-3 col-md-2 col-lg-2">
                    @(Html.Kendo().DatePickerFor(Function(m) m.JobTraffic.CompletedDate).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).Format("d").HtmlAttributes(New With {.id = "ScheduleCompletedDate", .style = "width: 125px;", .data_shortdate = ""}))
                </div>
            </div>
            <div class="form-group">
                <label class="col-sm-3 col-md-2 col-lg-2 control-label" for="CurrentStatusCode">Status:</label>
                <div class="col-sm-9 col-md-10 col-lg-10">
                    @(Html.Kendo().TextBoxFor(Function(m) m.JobTraffic.TrafficCode).Enable(Not Me.IsClientPortal AndAlso Model.CanUserEdit).HtmlAttributes(New With {.style = "width: 125px !important", .class = "RequiredInput", .data_trafficStatus = ""}))
                    @(Html.Kendo().TextBoxFor(Function(m) m.JobTraffic.Traffic.Description).Enable(False).HtmlAttributes(New With {.style = "width: 250px !important", .class = "RequiredInput"}))
                    <span class="k-invalid-msg" data-for="JobTraffic.TrafficCode"></span>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-3 col-md-2 col-lg-2"></div>
                <div class="col-sm-9 col-md-10 col-lg-10">
                    @(Html.Kendo().CheckBoxFor(Function(m) m.UserSettings.IncludeCompletedTasks).Label("Include Completed Tasks").Enable(Model.CanUserEdit).HtmlAttributes(New With {.onchange = If(Model.CanUserEdit, "includeCompletedTasksChanged()", "")}))
                </div>
            </div>
        </div>
    </div>

End Helper

<div style="margin-left: -15px; margin-right: -15px;">
    <div class="" style="background #a5a5a5;">
        @(Html.Kendo().ToolBar().Name("ScheduleToolBar").Items(Sub(i)

                                                                   Dim ScheduleCalcButtonText As String = ""
                                                                   Dim ScheduleCalcButtonToolTip As String = ""
                                                                   Dim ClickHandler As String = ""

                                                                   If Not Me.IsClientPortal Then

                                                                       If Model.CanUserEdit Then

                                                                           i.Add().Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Save", .style = "width:35px;"}).Icon("a wvi wvi-floppy-disk").Click("saveFormClick")

                                                                           i.Add().Type(CommandType.Button).Click("bookmarkFormClick").Text("<span class='wvi wvi-book-bookmark'></span>").HtmlAttributes(New With {.title = "Bookmark", .class = " k-button wv-icon-button "})

                                                                           i.Add().Text("Update Status").Type(CommandType.Button).HtmlAttributes(New With {.title = "Update status based on task status"}).Click("updateScheduleStatus")

                                                                           If Model.CalculateByPredecessor Then

                                                                               ScheduleCalcButtonText = "Predecessor"
                                                                               ScheduleCalcButtonToolTip = "Click to calculate by Order"
                                                                               ClickHandler = "changeToOrder"

                                                                           Else

                                                                               ScheduleCalcButtonText = "Order"
                                                                               ScheduleCalcButtonToolTip = "Click to calculate by Predecessor"
                                                                               ClickHandler = "changeToPredecessor"

                                                                           End If

                                                                           i.Add().Text(ScheduleCalcButtonText).Type(CommandType.Button).HtmlAttributes(New With {.title = ScheduleCalcButtonToolTip}).Click("changeScheduleCalculation")

                                                                           i.Add().Text("Versions").Type(CommandType.Button).HtmlAttributes(New With {.title = "Project Schedule Versions"}).Click("viewJobTrafficVersions")

                                                                           i.Add().Type(CommandType.Separator)

                                                                       End If

                                                                       If Not Me.QueryString.IsJobDashboard Then

                                                                           i.Add().Text("Gantt").Type(CommandType.Button).HtmlAttributes(New With {.title = "Vew Gantt"})
                                                                           i.Add().Type(CommandType.Separator)

                                                                       End If

                                                                   End If

                                                                   i.Add().Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Settings/Options", .class = "k wv-icon-button ", .style = "font-size:18px!important;"}).Text("<span class='glyphicon glyphicon-cog'></span>").Click("openSettings")
                                                                   i.Add().Type(CommandType.Separator)
                                                                   i.Add().Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .class = "k-button wv-icon-button ", .style = "width:35px;"}).Text("<span class='wvi wvi-refresh'></span>").Click("reloadWindow")
                                                                   'i.Add().Type(CommandType.Button).Click("bookmarkBoard").Text("<span class='wvi wvi-book-bookmark'></span>").HtmlAttributes(New With {.title = "Bookmark this page", .class = "k-button wv-icon-button "})
                                                                   'i.Add().Id("RefreshToolBarItem").Text("<span class='wvi wvi-refresh'></span>").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .class = "wv-icon-button wv-neutral"}).Click("reloadWindow")

                                                                   If (Model.CanUserEdit AndAlso Model.CanUserInsert) OrElse (Model.CanUserEdit = False AndAlso Model.IsTemplate = True AndAlso Model.CanUserCustom1 = True) Then

                                                                       i.Add().Type(CommandType.Separator)
                                                                       i.Add().Text("Copy To").Type(CommandType.Button).Id("CopyToProjectSchedules").Click("CopyToProjectSchedules").HtmlAttributes(New With {.title = "Copy To Project Schedules"})

                                                                   End If

                                                                   If Model.IsTemplate Then

                                                                       i.Add().Type(CommandType.Separator)
                                                                       i.Add().Text("Schedule Template").HtmlAttributes(New With {.style = "width:35px;color:red;"})

                                                                   End If

                                                                   i.Add().Text("Estimated Schedule").Type(CommandType.Button).HtmlAttributes(New With {.title = "Estimated Schedule"}).Click("EstimatedScheduleDlg")

                                                               End Sub))
    </div>


    <div class="telerik-aqua-body" style="overflow:inherit">
        @If Me.IsClientPortal = False AndAlso Model.CanUserEdit Then

            @Using (Ajax.BeginForm("SaveScheduleHeader", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber}, New AjaxOptions() With {.HttpMethod = "POST"}, New With {.id = "DetailsForm"}))
                @Html.AntiForgeryToken()

                @PageContent()

            End Using

        Else

            @PageContent()

        End If

        @Helper PageContent()
           @<div id="ScheduleHeader" style="margin-bottom: 10px; margin-top: 10px;">
                @(Html.Kendo.PanelBar().Name("ProjectScheduleDetails").ExpandMode(PanelBarExpandMode.Multiple) _
                                                                                                                                                    .Items(Sub(p)
                                                                                                                                                               p.Add().Text("Comments") _
                                                                                                      .Expanded(True) _
                                                                                                      .Content(CommentsContent().ToHtmlString)


                                                                                                                                                               p.Add().Text("Other Information") _
                                                                                            .Expanded(False) _
                                                                                            .Content(OtherInformationContent().ToHtmlString)


                                                                                                                                                               p.Add().Text("Assignments") _
                                                                                            .Expanded(False) _
                                                                                            .Content(AssignmentsContent().ToHtmlString)


                                                                                                                                                               p.Add().Text("Related Jobs") _
                                                                                            .Expanded(False) _
                                                                                            .Content(RelatedJobsContent.ToHtmlString)


                                                                                                                                                               p.Add().Text("Task Details") _
                                                                                            .Expanded(True) _
                                                                                            .Content(TaskDetailsContent().ToHtmlString)
                                                                                                                                                           End Sub))
            </div>

        End Helper

        <div id="TaskOptions" class="toolbar-custom-drop">
            <table>
                <thead>
                    <tr>
                        <th>Add Tasks</th>
                        <th>Other Task Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            @(Html.Kendo().Button().Name("AddTasksManually").Content("Manually or from list of tasks").Events(Sub(e)
                                                                                                                                          If Model.CanUserEdit = True Then
                                                                                                                                              e.Click("addTasksFromListOfTasks")
                                                                                                                                          End If
                                                                                                                                      End Sub).Enable(Model.CanUserEdit))
                        </td>
                        <td>@(Html.Kendo().Button().Name("DeleteSelectedTasks").Content("Delete selected tasks").Events(Sub(e) e.Click("deleteSelectedTasks")).Enable(Model.CanUserEdit))</td>
                    </tr>
                    <tr>
                        <td>
                            @(Html.Kendo().Button().Name("AddTaskFromTemplate").Content("From task templates").Events(Sub(e)
                                                                                                                                  If Model.CanUserEdit Then
                                                                                                                                      e.Click("addTasksFromTaskTemplates")
                                                                                                                                  End If
                                                                                                                              End Sub).Enable(Model.CanUserEdit))
                        </td>
                        <td>@(Html.Kendo().Button().Name("SearchAndReplaceTask").Content("Search and replace").Events(Sub(e) e.Click("searchAndReplaceTasks")).Enable(Model.CanUserEdit))</td>
                    </tr>
                    <tr>
                        <td>
                            @(Html.Kendo().Button().Name("AddTaskFromSchedule").Content("From an existing schedule").Events(Sub(e)
                                                                                                                                        If Model.CanUserEdit Then
                                                                                                                                            e.Click("addTasksFromExistingSchedule")
                                                                                                                                        End If
                                                                                                                                    End Sub).Enable(Model.CanUserEdit))
                        </td>
                        <td>@(Html.Kendo().Button().Name("FilterTask").Content("Filter").Events(Sub(e) e.Click("filterTasks")))</td>
                    </tr>
                    <tr>
                        <td>
                            @(Html.Kendo().Button().Name("AddTaskFromEstimate").Content("Create from estimate").Events(Sub(e)
                                                                                                                                   If Model.HasApprovedEstimate Then
                                                                                                                                       e.Click("addTasksFromEstimate")
                                                                                                                                   End If
                                                                                                                               End Sub).Enable(Model.HasApprovedEstimate AndAlso Model.CanUserEdit))
                        </td>
                        <td>@(Html.Kendo().CheckBox().Name("AutoStatus").Label("Auto Status").HtmlAttributes(New With {.onchange = "autoStatus()"}).Enable(Model.CanUserEdit))</td>
                    </tr>

                </tbody>
            </table>
        </div>

        @If Model.CanUserEdit = True Then

            @<div id="DateOptions" class="toolbar-custom-drop">
                <table>
                    <thead>
                        <tr>
                            <th>Date Actions</th>
                            <th>Set original due Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                @(Html.Kendo().Button().Name("CalculateDates").Content("Calculate Dates").Events(Sub(e)
                                                                                                                             If Model.CanUserEdit = True Then
                                                                                                                                 e.Click("calculateDates")
                                                                                                                             End If
                                                                                                                         End Sub).Enable(Model.CanUserEdit))
                            </td>
                            <td>@(Html.Kendo().Button().Name("SetDueDateWhereNotSet").Content("Only for tasks where it is not set").Events(Sub(e) e.Click("setOriginalDueDateWhereNotSet")))</td>
                        </tr>
                        <tr>
                            <td>@(Html.Kendo().Button().Name("MarkTempComplete").Content("Mark temp complete").Events(Sub(e) e.Click("markTempComplete")).Enable(Model.CanUserEdit))</td>
                            <td>@(Html.Kendo().Button().Name("SetDueDateForSelected").Content("Only selected tasks").Events(Sub(e) e.Click("setOriginalDueDateForSelected")).Enable(Model.CanUserEdit))</td>
                        </tr>
                        <tr>
                            <td>@(Html.Kendo().Button().Name("ClearDates").Content("Clear Dates").Events(Sub(e) e.Click("clearDates")).Enable(Model.CanUserEdit))</td>
                            <td>@(Html.Kendo().Button().Name("SetDueDateForAll").Content("For all tasks").Events(Sub(e) e.Click("setOriginalDueDateForAll")).Enable(Model.CanUserEdit))</td>
                        </tr>
                        <tr>
                            <td>@(Html.Kendo().Button().Name("ClearDatesIncludingOriginal").Content("Clear Dates including Original Due Date").Events(Sub(e) e.Click("clearDatesIncludingOriginalDueDate")).Enable(Model.CanUserEdit))</td>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
            </div>

        End If

        @If Model.CanUserEdit = True Then

            @<div id="EmployeeOptions" class="toolbar-custom-drop">
                <table>
                    <thead>
                        <tr>
                            <th>Employee Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>@(Html.Kendo().Button().Name("SetTeamByFunction").Content("Set team by function").Events(Sub(e) e.Click("setEmployeeTeamByFunction")))</td>
                        </tr>
                        <tr>
                            <td>@(Html.Kendo().Button().Name("SetTeamByRole").Content("Set team by role").Events(Sub(e) e.Click("setEmployeeTeamByRole")))</td>
                        </tr>
                        <tr>
                            <td>@(Html.Kendo().Button().Name("FindEmployees").Content("Find employees").Events(Sub(e) e.Click("findEmployees")))</td>
                        </tr>
                        <tr>
                            <td>@(Html.Kendo().Button().Name("ClearAllAssignments").Content("Clear all assignments").Events(Sub(e) e.Click("clearEmployeeAssignments")))</td>
                        </tr>
                    </tbody>
                </table>
            </div>

        End If
        <div>

        </div>
        <div id="gridToolBarWrap">

            @(Html.Kendo().ToolBar().Name("TreeListToolBar").Items(Sub(i)

                                                                               If Model.CanUserEdit Then

                                                                                   i.Add().Text("<span class='glyphicon glyphicon-pencil'></span>").Type(CommandType.Button).Id("QuickEditTaskButton").Click("QuickEditTaskButtonClick").HtmlAttributes(New With {.title = "Quick Edit Schedule"})

                                                                                   i.Add().Text("<span class='glyphicon glyphicon-plus'></span>").Type(CommandType.Button).Id("QuickAddTaskButon").Click("QuickAddTaskButtonClick").HtmlAttributes(New With {.title = "Quick Add Task"})

                                                                               End If

                                                                               i.Add().Text("Tasks").Type(CommandType.Button).Id("TaskOptionsButton").Click("showTaskOptions")

                                                                               If Model.CanUserEdit Then

                                                                                   i.Add().Text("Dates").Type(CommandType.Button).Id("DateOptionsButton").Click("showDateOptions")

                                                                               End If

                                                                               If Model.CanUserEdit Then

                                                                                   i.Add().Text("Employees").Type(CommandType.Button).Id("EmployeeOptionsButton").Click("showEmployeeOptions")

                                                                               End If

                                                                               i.Add().Text("Phase Filter").Type(CommandType.Separator)
                                                                               i.Add().Template("<label>Phase Filter:</label>")
                                                                               i.Add().Template("<input id='PhaseFilter' />")
                                                                               i.Add().Text("Phase Filter").Type(CommandType.Separator)

                                                                               If Not String.IsNullOrWhiteSpace(FilterString) Then

                                                                                   i.Add().Text("Clear Filters").Type(CommandType.Button).Id("ClearFiltersButton").Click("clearFilters")

                                                                               End If

                                                                           End Sub).Events(Sub(e)

                                                                                           End Sub))

        </div>



        <div id="ScheduleWrap">
            @Html.Partial("ScheduleGrid", Model)
        </div>

        @If Request.QueryString("jd") = "1" Then

            @<div id="jd-bottom-fix" style="height: 75px;"></div>

        End If
    </div>
</div>




@Code

    Dim UnityMenuModel As Webvantage.ViewModels.UnityMenuModel = Nothing

    UnityMenuModel = New Webvantage.ViewModels.UnityMenuModel
    UnityMenuModel.JobNumber = Model.JobNumber
    UnityMenuModel.JobComponentNumber = Model.JobComponentNumber
    UnityMenuModel.JobJacketSchedule.Visible = False
    UnityMenuModel.JobJacket.Visible = False
    UnityMenuModel.CurrentPrintPage = "TrafficSchedule_Print.aspx"

End Code

@(Html.Action("UnityMenu", "Utilities", UnityMenuModel))

<script type="text/x-kendo-template" id="jobListTemplate">
    <option value="#: ID#">
        #:Description#
    </option>
</script>

<script>

    function reloadTreeList() {
        var currentScroll = $(window).scrollTop();
        saveExpanded();
        $('#ScheduleWrap').load('@Html.Raw(Url.Action("ScheduleGrid", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber}))', function (html) {
            $(window).scrollTop(currentScroll);
        });
    }
    function findWindow(url) {
        var oWnd = GetRadWindow();
        var win;
        if (oWnd) {
            win = oWnd.BrowserWindow.FindWindow(url);
        }
        return win;
    }

    function EstimatedScheduleDlg(){
        OpenEstimatedScheduleDlg(@Model.JobNumber,@Model.JobComponentNumber);
    }

    function openSettings() {
        var jt = '@Html.Raw(Json.Encode(Request.QueryString("JT")))';
        if (!jt) {
            jt = '';
        }
        var model = getModelData();
        var url = '@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)Setup?JT=' + jt + '&j=' + model.JobNumber + '&jc=' + model.JobComponentNumber;
        OpenRadWindow('Settings/Options', url, 0, 0, false,reloadTreeList);
        @*setTimeout(function () {
            var win = findWindow('@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)Setup');
            if (win) {
                win.add_close(function () {
                    reloadTreeList();
                });
            }
        }, 500);*@
    }
    function reloadWindow() {
        if (isDirty === true) {
            if (confirmRefreshWithErrors() === true) {
                saveForm(true);
            }
        } else {
            window.location.reload();
        }
    }
    function confirmRefreshWithErrors() {
        var confirmed = true;
        if (validator.errors().length > 0) {
            showKendoConfirm("Errors on the page will not be saved. Are you sure you want to continue?")
                .done(function () {
                    confirmed = true;
                    validator._errors = {};
                })
                .fail(function () {
                    confirmed = false;
                });
            return confirmed;
        }
        return true;
    }
    function showTaskOptions() {
        showPopupForElement($('#TaskOptions'), $('#TaskOptionsButton'));
    }
    function showEmployeeOptions() {
        showPopupForElement($('#EmployeeOptions'), $('#EmployeeOptionsButton'));
    }
    function showDateOptions() {
        showPopupForElement($('#DateOptions'), $('#DateOptionsButton'));
    }
    function closeAllPopups() {
        $('.toolbar-custom-drop').each(function () {
            $(this).data('kendoPopup').close();
        });
        $('#myOverlay').hide();
    }
    function showPopupForElement(popUp, anchor) {
        closeAllPopups();
        var popUpData = popUp.data('kendoPopup');
        popUpData.options.anchor = anchor;
        popUpData.open();
        $('#myOverlay').show();
    }

    function openToolBarPopupMenu(e) {
        $('div[data-uid=' + e.id + ']').data('kendoPopup').open();
    }
    function includeCompletedTasksChanged() {
        psModel.IncludeCompletedTasks = $('#UserSettings_IncludeCompletedTasks').is(":checked");
        var data = {
            Key: '@AdvantageFramework.ProjectSchedule.Classes.Schedule.UserSettingCodes.IncludeCompleted.ToString',
            Value: psModel.IncludeCompletedTasks
        }
        postToAction('SaveApplicationVar', data, true, false);
    }
    function deleteJobThatPrecede(e) {
        e.preventDefault();
        var ids = [];
        $('#JobsThatPrecede option:selected').each(function () {
            ids.push($(this).val());
        });
        var model = getModelData();
        var data = {
            JobNumber: model.JobNumber,
            JobComponentNumber: model.JobComponentNumber,
            IDs: ids
        };
        kendo.ui.progress($('#JobsThatPrecede'), true);
        $.post({
            url: controllerBase + 'DestroyJobThatPrecedes',
            dataType: 'json',
            data: data
        }).always(function () {
            jobsThatPrecede.read().always(function () {
                kendo.ui.progress($('#JobsThatPrecede'), false);
            });
        });
    }
    function deleteJobThatFollow(e) {
        e.preventDefault();
        var ids = [];
        $('#JobsThatFollow option:selected').each(function () {
            ids.push($(this).val());
        });
        var model = getModelData();
        var data = {
            JobNumber: model.JobNumber,
            JobComponentNumber: model.JobComponentNumber,
            IDs: ids
        };
        kendo.ui.progress($('#JobsThatFollow'), true);
        $.post({
            url: controllerBase + 'DestroyJobThatFollows',
            dataType: 'json',
            data: data
        }).always(function () {
            jobsThatFollow.read().always(function () {
                kendo.ui.progress($('#JobsThatFollow'), false);
            });
        });
    }
    function jobsThatFollowChanged() {
        var deleteBtn = $('#DeleteJobsThatFollow').data('kendoButton');
        if (deleteBtn) {
            deleteBtn.enable($('#JobsThatFollow option:selected').length > 0 ? true : false);
        }
    }
    function jobsThatPrecedeChanged() {
        var deleteBtn = $('#DeleteJobsThatPrecede').data('kendoButton');
        if (deleteBtn) {
            deleteBtn.enable($('#JobsThatPrecede option:selected').length > 0 ? true : false);
        }
    }
    function addJobThatPrecede(e) {
        e.preventDefault();
        var model = getModelData();
        OpenRadWindow('', 'TrafficSchedule_AddJobPred.aspx?j=' + model.JobNumber + '&jc=' + model.JobComponentNumber, 730, 1025, true, function () {
            jobsThatPrecede.read();
        });
    }

    var template = kendo.template($('#jobListTemplate').html());

    var jobsThatPrecede = new kendo.data.DataSource({
        transport: {
            read: '@Html.Raw(Url.Action("ReadJobsThatPrecede", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber}))'
        },
        requestStart: function () {
            kendo.ui.progress($('#JobsThatPrecede'), true);
        },
        requestEnd: function () {
            kendo.ui.progress($('#JobsThatPrecede'), false);
            jobsThatPrecedeChanged();
        },
        change: function () {
            $('#JobsThatPrecede').html(kendo.render(template, this.view()));
            jobsThatPrecedeChanged();
        },
        schema: {
            model: {
                id: "ID"
            }
        }
    });

    var jobsThatFollow = new kendo.data.DataSource({
        transport: {
            read: '@Html.Raw(Url.Action("ReadJobsThatFollow", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber}))'
        },
        requestStart: function () {
            kendo.ui.progress($('#JobsThatFollow'), true);
        },
        requestEnd: function () {
            kendo.ui.progress($('#JobsThatFollow'), false);
        },
        change: function () {
            $('#JobsThatFollow').html(kendo.render(template, this.view()));
            jobsThatFollowChanged();
        },
        schema: {
            model: {
                id: "ID"
            }
        }
    });

    jobsThatPrecede.read();
    jobsThatFollow.read();

    function blurInputs() {
        $('#DetailsForm input:focus, #DetailsForm textarea:focus').each(function () {
            $(this).change();
            $(this).blur();
        });
    }

    $(document).ready(function () {


        //var win = GetRadWindow();
        //if (win) {
            this.defaultView.onbeforeunload = function () {
                blurInputs();
                saveForm(false);
            };

            //this.defaultView.add_command(function (sender, args) {
            //    if (args.get_commandName() === 'Reload') {
            //        blurInputs();
            //        if (isDirty === true) {
            //            args.set_cancel(true);
            //            if (confirmRefreshWithErrors() === true) {
            //                doSave().always(function () {
            //                    sender.reload();
            //                });
            //            }
            //        }
            //    };
            //});
        //}

        var tasksDropDownArea = $('#TasksDropDownArea').parent('li');
        tasksDropDownArea.html('');
        $('#TaskOptions').appendTo(tasksDropDownArea);

        var datesDropDownArea = $('#DatesDropDownArea').parent('li');
        datesDropDownArea.html('');
        $('#DateOptions').appendTo(datesDropDownArea);

        $('#EmployeeOptions').kendoPopup({
            anchor: $('#EmployeeOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#DateOptions').kendoPopup({
            anchor: $('#DateOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#TaskOptions').kendoPopup({
            anchor: $('#TaskOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#PhaseFilter').kendoDropDownList({
            dataTextField: "Description",
            dataValueField: "ID",
            dataSource: {
                transport: {
                    read: {
                        url: '@Html.Raw(Url.Action("ReadPhases", New With {.IncludeNoFilter = True, .IncludeNone = True}))'
                    }
                }
            },
            change: function (e) {
                if (this.value() === '-1') {
                    psModel.PhaseFilter = 'no_filter';
                } else if (this.value() === '0') {
                    psModel.PhaseFilter = 'is_null';
                } else {
                    psModel.PhaseFilter = this.value();
                }
                reloadTaskList();
            }
        });

    });

    var popUpTimeout;

    $('body').on('mouseover', '#EmployeeOptionsButton, #DateOptionsButton, #TaskOptionsButton', function () {
        clearTimeout(popUpTimeout);
        if (this.id == 'EmployeeOptionsButton') {
            popUpTimeout = setTimeout(function () {
                showEmployeeOptions();
            }, 400);
        } else if (this.id == 'DateOptionsButton') {
            popUpTimeout = setTimeout(function () {
                showDateOptions();
            }, 400);
        } else if (this.id == 'TaskOptionsButton') {
            popUpTimeout = setTimeout(function () {
                showTaskOptions();
            }, 400);
        }
    }).on('mouseleave', '#EmployeeOptionsButton, #DateOptionsButton, #TaskOptionsButton, #EmployeeOptions, #DateOptions, #TaskOptions', function () {
        clearTimeout(popUpTimeout);
        if (this.id == 'EmployeeOptions') {
            closeAllPopups();
        } else if (this.id == 'DateOptions') {
            closeAllPopups();
        } else if (this.id == 'TaskOptions') {
            closeAllPopups();
        }
    }).on('click', '.toolbar-custom-drop .k-button', function () {
        closeAllPopups();
    }).on('dblclick', '#JobTraffic_TrafficCode', function () {
        lookup(this, 'Status');
    }).on('change', '#JobTraffic_TrafficCode', function () {
        validator.validateInput(this);
    }).on('change', '#DetailsForm textarea, #DetailsForm input', function () {
        var ignoreElems = ['shortdate', 'trafficstatus', 'employee'];
        var validate = true;
        var shouldIgnore = false;
        for (var i = 0; i < ignoreElems.length; i++) {
            var ignore = $(this).data(ignoreElems[i]);
            if (typeof ignore !== 'undefined' && ignore !== false) {
                shouldIgnore = true;
            }
        }
        if (shouldIgnore === false) {
            if (!isDirty) {
                if (validator.validateInput(this) === true) {
                    beginAutoSave();
                }
            }
            isDirty = true;
            if ($(this).hasClass('force-save')) {
                saveForm(false);
            }
        }
    }).on('validated', '#DetailsForm textarea, #DetailsForm input', function (e) {
       //console.log('validated', e);
        isDirty = true;
        if (e.isValid === true) {
            if ($(this).hasClass('force-save')) {
                saveForm(false);
            } else {
                beginAutoSave();
            }
        }
    }).on('dblclick', '#JobsThatFollow option', function () {
        var item = jobsThatFollow.get($(this).val());
        if (item) {
            OpenRadWindow('', '@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)Index/' + item.Code.split("/")[0] + '/' + item.Code.split("/")[1]);
        }
    }).on('dblclick', '#JobsThatPrecede option', function () {
        var item = jobsThatPrecede.get($(this).val());
        if (item) {
            OpenRadWindow('', '@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)Index/' + item.Code.split("/")[0] + '/' + item.Code.split("/")[1]);
        }
    });

    var autoSaveInterval, isDirty = false;

    function beginAutoSave() {
        endAutoSave();
        autoSaveInterval = setInterval(function () {
            saveForm(false);
        }, 3000);
    }
    function endAutoSave() {
        clearInterval(autoSaveInterval);
    }
    function saveFormClick() {
        //force a save when the button is clicked.
        isDirty = true;
        saveForm(true);
    }
    function saveForm(reloadPage) {
        if (isDirty === true) {
            doSave().always(function () {
                if (reloadPage === true) {
                    window.location.reload();
                }
            });
        }
    }

    function bookmarkFormClick() {
        var model = getModelData();
        var data = {
            JobNumber: model.JobNumber,
            JobComponentNumber: model.JobComponentNumber
        };
        $.post({
            url: controllerBase + 'BookMarkPagePS',
            dataType: 'json',
            data: data
        }).always(function () {

        });
    }

    function doSave() {
        endAutoSave();
        var $form = $('#DetailsForm');
        return $.ajax({
            type: 'POST',
            url: $form.attr('action'),
            data: $form.serialize(),
            error: function () {
                beginAutoSave();
            },
            success: function (response) {
                isDirty = false;
            }
        });
    }

    $(function () {
        var gridNav = $('#gridToolBarWrap');
        var navHomeY = gridNav.offset().top;
        var navHeight = gridNav.height();
        var isFixed = false;
        var $w = $(window);
        $w.scroll(function () {
            var scrollTop = $w.scrollTop();
            var shouldBeFixed = scrollTop > navHomeY;
            if (shouldBeFixed && !isFixed) {
                gridNav.css({
                    position: 'fixed',
                    top: 0,
                    left: gridNav.offset().left,
                    width: gridNav.width()
                });
                isFixed = true;
            } else if (!shouldBeFixed && isFixed) {
                gridNav.css({
                    position: 'static',
                    height: navHeight
                });
                isFixed = false;
            }
        });
    });

</script>

<style type="text/css">
    #JobsThatPrecede, #JobsThatFollow {
        padding: 0;
        margin: 0;
        overflow: auto;
    }

        #JobsThatPrecede option, #JobsThatFollow option {
            padding: 5px;
        }

    .toolbar-custom-drop {
        padding: 5px;
        display: none;
    }

        .toolbar-custom-drop .k-button {
            width: 100%;
        }

        .toolbar-custom-drop tbody td {
            padding: 2px 8px 2px 8px !important;
        }

            .toolbar-custom-drop tbody td:first-child {
                padding-left: 2px !important;
            }

            .toolbar-custom-drop tbody td:last-child {
                padding-right: 2px !important;
            }

    #myOverlay {
        display: none;
    }

    .dropdown-header {
        border-width: 0 0 1px 0;
        text-transform: uppercase;
    }

        .dropdown-header > span {
            display: inline-block;
            padding: 10px 5px 10px 0px;
        }

    div[id^=EstimateFunction] .k-item > span {
        display: inline-block;
        padding: 0px 5px 0px 0px;
    }

        .dropdown-header > span:first-child, div[id^=EstimateFunction] .k-item > span:first-child {
            width: 75px;
        }

    #gridToolBarWrap {
        z-index: 999;
        width: 100% !important;
    }
</style>

<div class="k-overlay" id="myOverlay"></div>

<script>
    var filterString = ' @Html.Raw(FilterString)';
</script>

@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/projectschedule.mvc.js"></script>

End Section

