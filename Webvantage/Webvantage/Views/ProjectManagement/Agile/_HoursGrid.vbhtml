@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours
<style>
    .board-hours-image {
        border-radius: 2px;
        height: 30px;
        width: 30px;
        margin: 0px 0px 0px 0px;
    }

    .overage {
        color: #D32F2F !important;
        font-weight: bold !important;
    }

    .hrs-tb {
    }
</style>
<script id="tmpltEmployee" type="text/template">
    <div class="wv-employee-box" title="{{tooltipFormat:FullName}}">
        <div class="image-container">
            <img id="employeeImage" src='@Url.Action("EmployeePicture", "Utilities")/{{:EmployeeCode}}' />
        </div>
        <div class="name">
            <span id="employeeName" class="name-span" title="{{tooltipFormat:FullName}}">{{:FullName}}</span>
        </div>
    </div>
</script>
<script id="tmpltComplete" type="text/template">
    {{if Complete > 0 }}
    <span class="wvi wvi-check" style="align-content:center"></span>
    {{/if}}
    @*{{if Complete < 1 }}
    <span class="wvi wvi-check" style="align-content:center"></span>
    {{/if}}*@
</script>
<input type="hidden" id="lastFocus" />
<script id="tmpltHoursAssigned" type="text/template">
    @code
        If ViewData("CanUpdate") Then
        @<text><input id="txtHoursAssigned{{:SprintEmployeeID}}" value="{{hoursFormat:HoursAssigned}}" onblur="hoursChanged({{:SprintEmployeeID}}, this, {{:HoursAssigned}}, '{{:EmployeeCode}}');"
                      onfocus="trackControl(this);" Class="e-textbox" style="width: 40px; text-align:right;padding-right:10px;" maxlength="4" /> 
        </text>
        Else
            @<Text> <span> {{hoursFormat:HoursAssigned}} </span> </Text>
        End If
    End Code
        </script>
<script id="tmpltHoursAssignedEmp" type="text/template">
    @code
        If ViewData("CanUpdate") Then
            @<Text><input id="txtHoursAssigned{{:EmployeeCode}}" value="{{hoursFormat:HoursAssigned}}" onblur="hoursChanged({{:SprintEmployeeID}}, this, {{:HoursAssigned}}, '{{:EmployeeCode}}');" onfocus="trackControl(this);"
                          Class="e-textbox" style="width: 40px; text-align:right;padding-right:10px;" maxlength="4" /> </text>
        Else
            @<Text> <span> {{hoursFormat:HoursAssigned}} </span> </Text>
        End If
    End Code
        </script>
<div id = "filter-container" style="margin-top:-15px;">
            <table style = "width: 100%;" >
                <tr>
                    <td style="width: 75%;">
                        <div id="weeklyOptions" style="display:none;">
                            <div style="display:inline-block;">
        @Html.EJ().CheckBox("CheckBoxPriorWeeks").Value("priorWeeks").Size(Size.Medium).ClientSideEvents(Sub(e)
                                                                                                             e.Change("checkBoxPriorWeeksChanged")
                                                                                                         End Sub).Checked(Model.CreatePriorWeeksSetting).Text("Include Prior Weeks")
                            </div>
                            <div style="display:inline-block;">
        @Html.EJ().CheckBox("CheckboxPast").Value("filterGrid").Size(Size.Medium).ClientSideEvents(Sub(e)
                                                                                                       e.Change("checkBoxPastChanged")
                                                                                                   End Sub).Checked(Model.ShowPastWeeksSetting).Text("Show past weeks")

                            </div>
                            <div style="display:inline-block;margin-left: 8px;">
        @Html.EJ().CheckBox("CheckboxFuture").Value("filterGrid").Size(Size.Medium).ClientSideEvents(Sub(e)
                                                                                                         e.Change("checkBoxFutureChanged")
                                                                                                     End Sub).Checked(Model.ShowFutureWeeksSetting).Text("Show future weeks")

                            </div>
                            <div style="display:inline-block;margin-left: 8px;">
        @Html.EJ().CheckBox("CheckboxGroupEmployee").Value("groupEmployee").Size(Size.Medium).ClientSideEvents(Sub(e)
                                                                                                                   e.Change("checkBoxGroupEmployeeChanged")
                                                                                                               End Sub).Checked(Model.GroupEmployeesSetting).Text("Group employees")

                            </div>
                            <div style="display:inline-block;margin-left: 8px;">
        @Html.EJ().CheckBox("CheckboxGroupWeek").Value("groupWeek").Size(Size.Medium).ClientSideEvents(Sub(e)
                                                                                                           e.Change("checkBoxGroupWeekChanged")
                                                                                                       End Sub).Checked(Model.GroupWeeksSetting).Text("Group weeks")

                            </div>
                        </div>
                    </td>
                    <td style="width: 25%; padding-left: 6px; text-align:left;">
        @Html.Kendo().MultiSelect().Name("FilterEmployees").Placeholder("Filter assignees").DataSource(Sub(ds)
                                                                                                           ds.Read(Sub(read)
                                                                                                                       read.Action("GetWorkItemFilterEmployees", "Agile", New With {.AlertID = Model.AlertID})
                                                                                                                   End Sub)
                                                                                                       End Sub).DataTextField("Name").DataValueField("Code").Events(Sub(evt)
                                                                                                                                                                        evt.Change("filterGrid")
                                                                                                                                                                    End Sub).HtmlAttributes(New With {.class = "wv-ej-autocomplete", .style = "margin-top: 8px;"})
                    </td>
                </tr>
                        </table>
</div>
<div style = "margin: 10px 0px 0px 0px;" >
        @Code

            Dim HasWeeklyHours As Boolean = False
            Dim WrapSettings As New Syncfusion.JavaScript.Models.TextWrapSettings
            Dim GridBuilder = Html.EJ().Grid(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.WorkItemHoursViewModel)("WorkItemHoursGrid")

        WrapSettings.WrapMode = WrapMode.Both
        HasWeeklyHours = ViewData("HasWeeklyHours")

        GridBuilder.Datasource(Model.WorkItemHours)
        GridBuilder.EditSettings(Sub(Edit)
                                 End Sub)
        GridBuilder.AllowMultiSorting(False)
        GridBuilder.AllowSelection(False)
        GridBuilder.AllowSorting(False)
        GridBuilder.AllowTextWrap(True)
        GridBuilder.AllowGrouping(True)
        GridBuilder.GroupSettings(Sub(settings)
                                      settings.ShowDropArea(False)
                                      settings.ShowToggleButton(False)
                                  End Sub)
        GridBuilder.TextWrapSettings(WrapSettings)
        GridBuilder.SelectionType(SelectionType.Single)
        GridBuilder.EnableToolbarItems(False)
        GridBuilder.Columns(Sub(Column)
                                Column.Field("FullName").HeaderText("Employee").Template("#tmpltEmployee").AllowGrouping(True).Add()
                                Column.Field("HoursPostedPrior").HeaderText("Posted Prior").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(90).Format("{0:N2}").AllowGrouping(False) '.Add()
                                Column.Field("HoursLeft").HeaderText("Hours Left").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(90).Format("{0:N2}").AllowGrouping(False) '.Add()
                                Column.Field("HoursAssigned").HeaderText("Hours").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Template("#tmpltHoursAssigned").Format("{0:N2}").Width(110).AllowGrouping(False).Add()
                                Column.Field("WeekStart").HeaderText("Week of").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Format("{0:MM/dd/yyyy}").EnableGroupByFormat().Width(110).Add()
                                Column.Field("HoursAllowed").HeaderText("Hours Allowed").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Template("#tmpltHoursAssignedEmp").Format("{0:N2}").Width(90).AllowGrouping(False).Add()
                                'Column.Field("PercentComplete").HeaderText("% Complete").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Format("{0:N2}").Width(90).AllowGrouping(False).Add()
                                Column.Field("Complete").HeaderText("Completed").Template("#tmpltComplete").TextAlign(Syncfusion.JavaScript.TextAlign.Center).AllowGrouping(False).Width(110).Add()
                                Column.Field("HoursAvailableForWeek").HeaderText("Available").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(90).Format("{0:N2}").AllowGrouping(False).Add()
                                Column.Field("HoursAssignedForWeek").HeaderText("Assigned").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(90).Format("{0:N2}").AllowGrouping(False).Add()
                                Column.Field("HoursBalance").HeaderText("Balance").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(90).Format("{0:N2}").AllowGrouping(False).Add()
                                Column.Field("HoursPostedThis").HeaderText("Posted For Week").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(90).Format("{0:N2}").AllowGrouping(False) '.Add()
                            End Sub)
        GridBuilder.ClientSideEvents(Sub(Events)
                                         Events.ActionBegin("gridActionBegin")
                                         Events.QueryCellInfo("gridQueryCellInfo")
                                         Events.BeginEdit("gridBeginEdit")
                                         Events.EndEdit("gridEndEdit")
                                         Events.CellEdit("gridCellEdit")
                                     End Sub)
        GridBuilder.Render()

        End Code
</div>
<script>
            $.views.converters("encodeHtml", function (val) {
                var buf = [];
                if (val) {
                    for (var i = val.length - 1; i >= 0; i--) {
                        buf.unshift(['&#', val[i].charCodeAt(), ';'].join(''));
                    }
                }
                return buf.join('');
            })
            $.views.converters("tooltipFormat", function (val) {
                var n = ""
                    try {
                    if (val) {
                        n = val.replace(/"/g, '&quot;');
                    }
                } catch (e) {
                    n = ""
                }
                return n
            })
            $.views.converters("hoursFormat", function (val) {
                var n = 0.00;
                try {
                    if (val) {
                        n = parseFloat(Math.round(val * 100) / 100).toFixed(2);
                    }
                } catch (e) {
                    n = 0.00
                }
                return n
            })
</script>
<script>
            var thisSprintHeaderId = 0;
            var thisAlertId = 0;
            var groupEmployee = false;
            var groupWeek = false;
            var success = false;
            var message = "";
            var hasWeeklyHours = false;

            thisSprintHeaderId = @Html.Raw(ViewData("SprintHeaderID")) * 1;
                thisAlertId = @Html.Raw(ViewData("AlertID")) * 1;
                    groupEmployee = @Html.Raw(Model.GroupEmployeesSetting.ToString.ToLower);
                        groupWeek = @Html.Raw(Model.GroupWeeksSetting.ToString.ToLower);
                            success = @Html.Raw(Model.Result.Success.ToString.ToLower);
                                message = '@Html.Raw(Model.Result.Message.ToString)';
                                hasWeeklyHours = @Html.Raw(ViewData("HasWeeklyHours").ToString.ToLower);

                                    $(document).ready(function () {
                                        window.setTimeout(function () {
                                            _setGridGrouping();
                                        }, 10);
                                        window.setTimeout(function () {
                                            if (hasWeeklyHours === true) {
                                                $("#weeklyOptions").show();
                                            } else {
                                                $("#weeklyOptions").hide();
                                           }
                                        }, 10);
                                        window.setTimeout(function () {
                                            try {
                                                if (success == false && message != "") {
                                                    showNotification(message);
                                                }
                                            } catch (e) {
                                            }
                                        }, 10);
                                        //console.log("hasWeeklyHours", hasWeeklyHours);
                                    })

</script>
                                @Scripts.Render("~/JScripts/HoursGrid.mvc.js")
