@ModelType AdvantageFramework.ViewModels.Employee.Timesheet.Settings

@Code

    ViewData("Title") = "Settings"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
<div class="content padding-x">
    <div class="container-fluid">
        <div class="wv-form">
            <div>
                <h5 style="margin-bottom: 8px;">Time Entry</h5>
                <div class="wv-form-group" style="vertical-align: middle;" title="(hours align with comment)">
                    <div style="display: inline-block;">
                        <label style="width: 325px;">Add unique row when comments are included</label>
                    </div>
                    <div style="display: inline-block;">
                        @Html.EJ().CheckBox("CheckBoxAddUniqueRowWhenComment").Value("AddUniqueRowWhenComment").Size(Size.Medium).Checked(Model.AddUniqueRowWhenComment).ClientSideEvents(Sub(evt)
                                                                                                                                                                                          End Sub)
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;" title="Repeat Row For All Days">
                    <div style="display: inline-block;">
                        <label style="width: 325px;">Repeat Row For All Days</label>
                    </div>
                    <div style="display: inline-block;">
                        @Html.EJ().CheckBox("CheckBoxRepeatRowForAllDays").Value("RepeatRowForAllDays").Size(Size.Medium).Checked(Model.RepeatRowForAllDays).ClientSideEvents(Sub(evt)
                                                                                                                                                                              End Sub)
                    </div>
                </div>
            </div>
            <div id="DivWeekView">
                <h5 style="margin-bottom: 8px;">Week View</h5>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;" title="Day to start week view.  Only enabled when viewing 7 days.">Start On Day</label>
                    <div>
                        <select id="StartWeekOnDay"></select>
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">Days</label>
                    <div>
                        <select id="DaysToDisplay">
                            <option value="5">5</option>
                            <option value="7">7</option>
                        </select>
                    </div>
                </div>
            </div>
            <div>
                <h5 style="margin-bottom: 8px;">Description Display Options</h5>
                <div class="wv-form-group" style="vertical-align: middle; display: none !important;">
                    <label style="width: 160px;">Job Information</label>
                    <div>
                        @Html.EJ().CheckBox("CheckBoxShowJobName").Value("ShowJobName").Size(Size.Medium).Checked(Model.ShowJobName).ClientSideEvents(Sub(evt)
                                                                                                                                                      End Sub)&nbsp;&nbsp;Show Job Description
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">Job Information</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowComponentName").Value("ShowComponentName").Size(Size.Medium).Checked(Model.ShowComponentName).ClientSideEvents(Sub(evt)
                                                                                                                                                                        End Sub)&nbsp;&nbsp;Show Component Description
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">&nbsp;</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowJobComponentNumber").Value("ShowJobComponentNumber").Size(Size.Medium).Checked(Model.ShowJobAndComponentNumber).ClientSideEvents(Sub(evt)
                                                                                                                                                                                          End Sub)&nbsp;&nbsp;Show Job/Component Number
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">Client Information</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowClient").Value("ShowClient").Size(Size.Medium).Checked(Model.ShowClientName).ClientSideEvents(Sub(evt)
                                                                                                                                                           evt.Change("clientDivisionProductCheckboxesChanged")
                                                                                                                                                       End Sub)&nbsp;&nbsp;Show Client Name
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">&nbsp;</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowDivision").Value("ShowDivision").Size(Size.Medium).Checked(Model.ShowDivisionName).ClientSideEvents(Sub(evt)
                                                                                                                                                                 evt.Change("clientDivisionProductCheckboxesChanged")
                                                                                                                                                             End Sub)&nbsp;&nbsp;Show Division Name
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">&nbsp;</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowProduct").Value("ShowProduct").Size(Size.Medium).Checked(Model.ShowProductName).ClientSideEvents(Sub(evt)
                                                                                                                                                          End Sub)&nbsp;&nbsp;Show Product Name
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">Details</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowFunctionCategory").Value("ShowFunctionCategory").Size(Size.Medium).Checked(Model.ShowFunctionCategory).ClientSideEvents(Sub(evt)
                                                                                                                                                                                 End Sub)&nbsp;&nbsp;Show Function/Category
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">&nbsp;</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowAssignment").Value("ShowAssignment").Size(Size.Medium).Checked(Model.ShowAssignment).ClientSideEvents(Sub(evt)
                                                                                                                                                               End Sub)&nbsp;&nbsp;Show Assignment
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle;">
                    <label style="width: 160px;">&nbsp;</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowProgressBar").Value("ShowProgressBar").Size(Size.Medium).Checked(Model.ShowProgressBar).ClientSideEvents(Sub(evt)
                                                                                                                                                                  End Sub)&nbsp;&nbsp;Show Progress Bar
                    </div>
                </div>
                <div class="wv-form-group" style="vertical-align: middle; display: none !important;">
                    <label style="width: 160px;">&nbsp;</label>
                    <div>
                        @Html.EJ().CheckBox("CheckboxShowHoursRemaining").Value("ShowHoursRemaining").Size(Size.Medium).Checked(Model.ShowHoursRemaining).ClientSideEvents(Sub(evt)
                                                                                                                                                                           End Sub)&nbsp;&nbsp;Show Hours Remaining
                    </div>
                </div>
            </div>
            <div style="margin: 10px 0px 0px 6px; display:block; width: 100%; text-align: right;">
                <div class="k-button-group">
                    <button id="ButtonCancel" class="k-button" onclick="cancelClick();">Cancel</button>
                    <button id="ButtonSave" class="k-button k-primary" onclick="saveClick();">Save</button>
                </div>
            </div>
        </div>
    </div>
</div>
<script>
    var selectedStartWeekOnDay = @Html.Raw(Model.StartTimesheetOnDayOfWeek) * 1;
    var selectedDaysToDisplay = @Html.Raw(Model.DaysToDisplay) * 1;
    var showClient = @Html.Raw(Model.ShowClientName.ToString.ToLower);
    var showDivision = @Html.Raw(Model.ShowDivisionName.ToString.ToLower);
    var agencyOverride = false;
    var startWeekOnURL = window.appBase + "Employee/Timesheet/GetStartOfWeekOn";
    var startWeekOnDataSource = new kendo.data.DataSource({
        serverFiltering: true,
        transport: {
            read: {
                url: startWeekOnURL,
                dataType: "json",
                data: function () {
                    return {
                    };
                }
            }
        }
    });

    agencyOverride = @Html.Raw(ViewData("AgencyOverride").ToString.ToLower);
    console.log("agencyOverride", agencyOverride);

    function cancelClick() {
        window.parent.closeSettingsDialog();
    }
    function saveClick() {
        var startWeekOnDay = $("#StartWeekOnDay").data("kendoDropDownList");
        var daysToDisplay = $("#DaysToDisplay").data("kendoDropDownList");
        var data = {
            StartWeekOnDay: startWeekOnDay.value(),
            DaysToDisplay: daysToDisplay.value(),
            ShowJobName: $("#CheckBoxShowJobName").ejCheckBox("instance").option("checked"),
            ShowComponentName: $("#CheckboxShowComponentName").ejCheckBox("instance").option("checked"),
            ShowJobComponentNumber: $("#CheckboxShowJobComponentNumber").ejCheckBox("instance").option("checked"),
            ShowClient: $("#CheckboxShowClient").ejCheckBox("instance").option("checked"),
            ShowDivision: $("#CheckboxShowDivision").ejCheckBox("instance").option("checked"),
            ShowProduct: $("#CheckboxShowProduct").ejCheckBox("instance").option("checked"),
            ShowFunctionCategory: $("#CheckboxShowFunctionCategory").ejCheckBox("instance").option("checked"),
            ShowAssignment: $("#CheckboxShowAssignment").ejCheckBox("instance").option("checked"),
            AddUniqueRowWhenComment: $("#CheckBoxAddUniqueRowWhenComment").ejCheckBox("instance").option("checked"),
            ShowProgressBar: $("#CheckboxShowProgressBar").ejCheckBox("instance").option("checked"),
            ShowHoursRemaining: $("#CheckboxShowHoursRemaining").ejCheckBox("instance").option("checked"),
            RepeatRowForAllDays: $("#CheckBoxRepeatRowForAllDays").ejCheckBox("instance").option("checked")
        };
        //console.log("data?", data);
        $.post({
            url: window.appBase + "Employee/Timesheet/SaveUserTimesheetSettings",
            dataType: "json",
            data: data
        }).always(function (result) {
            //console.log("saveClick result", result);
            window.parent.closeSettingsDialog();
            window.parent.hardRefresh();
            //if (result) {
            //    if (result.Success && result.Success === true) {
            //        window.parent.refreshTimesheet();
            //        window.parent.closeDialogs();
            //    } else {
            //        if (result.Message && result.Message !== "") {
            //            showKendoAlert(JSON.parse(result.Message));
            //        }
            //    }
            //}
        });
    }
    function startWeekOnDayChanged(e) {
        //console.log("startWeekOnDayChanged", e);
    }
    function daysToDisplayChanged(e) {
        setStartWeekOnDayEnabled();
    }
    function clientDivisionProductCheckboxesChanged(e) {
        var checkBoxId = e.model.id;
        if (checkBoxId === "CheckboxShowClient") {
            setDivisionProductCheckboxes($("#CheckboxShowClient").ejCheckBox("isChecked"));
        }
        if (checkBoxId === "CheckboxShowDivision") {
            setProductCheckbox($("#CheckboxShowDivision").ejCheckBox("isChecked"));
        }
    }
    function setDivisionProductCheckboxes(enabled) {
        //console.log("setDivisionProductCheckboxes", enabled)
        if (enabled === false) {
            $("#CheckboxShowDivision").ejCheckBox("disable");
            $("#CheckboxShowProduct").ejCheckBox("disable");
            //console.log("setDivisionProductCheckboxes false");
        } else {
            $("#CheckboxShowDivision").ejCheckBox("enable");
            $("#CheckboxShowProduct").ejCheckBox("enable");
            //console.log("setDivisionProductCheckboxes true");
     }
    }
    function setProductCheckbox(enabled) {
        if (enabled === false) {
            $("#CheckboxShowProduct").ejCheckBox("disable");
            //console.log("setProductCheckbox false");
        } else {
            $("#CheckboxShowProduct").ejCheckBox("enable");
            //console.log("setProductCheckbox true");
        }
    }
    function setStartWeekOnDayEnabled() {
        var daysToDisplayDropdownList = $("#DaysToDisplay").data("kendoDropDownList");
        var startWeekOnDayDropdownList = $("#StartWeekOnDay").data("kendoDropDownList");
        var daysToDisplayValue = daysToDisplayDropdownList.value() * 1;
        //if (daysToDisplayValue === 5) {
        //    startWeekOnDayDropdownList.enable(false);
        //} else {
            startWeekOnDayDropdownList.enable(true);
        //}
    }
    $(document).ready(function () {
        $("#StartWeekOnDay").kendoDropDownList({
            filter: "contains",
            dataTextField: "Day",
            dataValueField: "DayOfWeek",
            dataSource: startWeekOnDataSource,
            change: startWeekOnDayChanged,
            error: function (xhr, error) {
                console.debug(xhr);
                console.debug(error);
            }
        });
        $("#DaysToDisplay").kendoDropDownList({
            change: daysToDisplayChanged
        });
        if (selectedStartWeekOnDay) {
            var startWeekOnDayDropdownList = $("#StartWeekOnDay").data("kendoDropDownList");
            startWeekOnDayDropdownList.value(selectedStartWeekOnDay + "");
            startWeekOnDayDropdownList.trigger("change");
        }
        if (selectedDaysToDisplay) {
            var daysToDisplayDropdownList = $("#DaysToDisplay").data("kendoDropDownList");
            daysToDisplayDropdownList.value(selectedDaysToDisplay + "");
            daysToDisplayDropdownList.trigger("change");
        }
        window.setTimeout(function () {
            if (agencyOverride === true) {
                $("#DivWeekView").hide();
            } else {
                $("#DivWeekView").show();
            }
        }, 10);
        window.setTimeout(function () {
            setDivisionProductCheckboxes(showClient);
            if (showClient === true) {
                setProductCheckbox(showDivision);
            }
        }, 10);
    });
</script>
