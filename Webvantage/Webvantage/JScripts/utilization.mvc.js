//
let _fromBookmarkFlag = false;

let GroupSecuritySettings = {
    ShowAllAssignments: true,
    ShowUnassignedAssignments: true,
    AllowTaskEdit: true
};

let UserViewSettings = {
    SearchCriteria: '',
    InboxType: 'inbox',
    ShowAssignmentType: 'myalertsandassignments',    
    GroupBy: '',
    ShowOnlyTempCompletedTasks: false,    
    IncludeBacklog: false,
    GridSize: 10,
    JJIncludeCompleted: ''
};

function LoadUserColumnSettings() {
    if (userViewSettingsReady === false) {
        setTimeout(LoadUserColumnSettings, 250);
    } else {
        GenerateColumnDetailSettings();        
        LoadUserGridView();
    }
}

function LoadUserGridView() {
    if (columnSettingsReady === false) {
        setTimeout(LoadUserGridView, 250);
    } else {        
        createGridDataSource();

        if (EUFilter.InboxType === "task") {
            aagrid = CreateTaskViewGrid();
        } else {
            aagrid = CreateEUViewGrid();
        }

        if (EUFilter.InitialLoadFlag) {
            let grid = $("#utilizationgrid").data("kendoGrid");
            grid.setDataSource(grid.dataSource);
            grid.dataSource.read();
        }

        EUGrid_SubscribeToShared();
    }
}

function GetGroupSecuritySettings() {
    $.ajax({
        url: 'EmployeeUtilization/GroupSecuritySettings',
        dataType: 'json',
        success: function (result) {
            for (let i = 0; i < result.length; i++) {
                if (result[i].SettingName === "ShowAllAssignments") {
                    GroupSecuritySettings.ShowAllAssignments = result[i].SettingValue;
                }
                if (result[i].SettingName === "ShowUnassignedAssignments") {
                    GroupSecuritySettings.ShowUnassignedAssignments = result[i].SettingValue;
                }
                if (result[i].SettingName === "AllowTaskEdit") {
                    GroupSecuritySettings.AllowTaskEdit = result[i].SettingValue;
                }
            }

            if (GroupSecuritySettings.ShowAllAssignments === "False") {
                $("#buttonAllAssignments").addClass('k-state-disabled');
                $("#buttonAllAssignments").prop('disabled', true);
            } else {
                $("#buttonAllAssignments").removeClass('k-state-disabled');
                $("#buttonAllAssignments").prop('disabled', false);
            }

            if (GroupSecuritySettings.ShowUnassignedAssignments === "False") {
                $("#buttonUnassigned").addClass('k-state-disabled');
                $("#buttonUnassigned").prop('disabled', true);
            } else {
                $("#buttonUnassigned").removeClass('k-state-disabled');
                $("#buttonUnassigned").prop('disabled', false);
            }

        },
        error: function (result) {
        }
    });
}

function GetUserViewSettings(viewType) {      
    if (!_fromBookmarkFlag || isJobJacketView) {
        $.ajax({
            url: 'EmployeeUtilization/GetUserViewSettings',
            data: { ApplicationName:  viewType},
            dataType: 'json',
            success: function (result) {
                
                for (let i = 0; i < result.length; i++) {
                    if (result[i].SettingName === "AAM_SearchCriteria") {
                        UserViewSettings.SearchCriteria = result[i].SettingValue;
                    }
                    if (result[i].SettingName === "AAM_InboxType") {
                        UserViewSettings.InboxType = result[i].SettingValue;
                    }
                    if (result[i].SettingName === "AAM_ShowAssignmentType") {
                        UserViewSettings.ShowAssignmentType = result[i].SettingValue;
                    }
                    if (result[i].SettingName === "AAM_GroupBy") {
                        UserViewSettings.GroupBy = result[i].SettingValue;
                    }
                    if (result[i].SettingName === "AAM_ShowOnlyTempCompletedTasks") {
                        UserViewSettings.ShowOnlyTempCompletedTasks = result[i].SettingValue == "True" ? true : false;
                    }
                    if (result[i].SettingName === "AAM_IncludeBacklog") {
                        UserViewSettings.IncludeBacklog = result[i].SettingValue == "True" ? true : false;
                    }
                    if (result[i].SettingName === "AAM_GridSize") {
                        UserViewSettings.GridSize = result[i].SettingValue;
                    }
                    if (result[i].SettingName === "AAM_JJIncludeCompleted" && isJobJacketView) {
                        UserViewSettings.JJIncludeCompleted = result[i].SettingValue == "True" ? true : false;
                    }
                }
                
                SetUserViewSettings();
                userViewSettingsReady = true;
            },
            error: function (result) {
            }
        });
    } else {
        UserViewSettings.SearchCriteria = EUFilter.SearchCriteria;
        UserViewSettings.InboxType = EUFilter.InboxType;
        UserViewSettings.ShowAssignmentType = EUFilter.ShowAssignmentType;        
        UserViewSettings.ShowOnlyTempCompletedTasks = EUFilter.ShowOnlyTempCompletedTasks;
        UserViewSettings.IncludeBacklog = EUFilter.IncludeBacklog;

        //the following userViewSettings aren't stored int he EUFilter object,
        //as they do not apply to the datasource parameters
        UserViewSettings.GroupBy = urlParms.get("aamgb");
        UserViewSettings.GridSize = urlParms.get("aamgs");

        SetUserViewSettings();   
        userViewSettingsReady = true;
    }    
}

function SyncUserViewSettings() {
    UserViewSettings.SearchCriteria = EUFilter.SearchCriteria;
    UserViewSettings.InboxType = EUFilter.InboxType;
    UserViewSettings.ShowAssignmentType = EUFilter.ShowAssignmentType;    
    UserViewSettings.GroupBy = EUFilter.GroupBy;
    UserViewSettings.ShowOnlyTempCompletedTasks = EUFilter.ShowOnlyTempCompletedTasks;    
    UserViewSettings.IncludeBacklog = EUFilter.IncludeBacklog;
    UserViewSettings.GridSize = $(".k-pager-sizes span.k-input").text();

    let gridSize = $(".k-pager-sizes span.k-input").text();
    let pageSizes = ["10", "15", "20", "50", "100", "200"];

    if (gridSize && pageSizes.includes(gridSize)) {
        UserViewSettings.GridSize = gridSize;
    } else {
        //if the gridsize isn't in the pagesize array, an irrelevant value has been posted to the 
        //pager size dropdown by the datasource.
        //setting the GridSize to 10 will remove the app var setting, as 10 is the grid default.
        UserViewSettings.GridSize = "10";
    }

    if (isJobJacketView) {
        UserViewSettings.JJIncludeCompleted = EUFilter.IncludeCompletedAssignments;        
    }
}

function SetUserViewSettings() {
    try {
        let currentViewValue = "";        

        //if (!_fromBookmarkFlag || isJobJacketView) {            
        //    if (UserViewSettings.SearchCriteria !== "") {
        //        EUFilter.SearchCriteria = UserViewSettings.SearchCriteria;
        //        $("#Search").val(UserViewSettings.SearchCriteria);
        //    }

        //    if (UserViewSettings.InboxType !== "") {
        //        EUFilter.InboxType = UserViewSettings.InboxType;

        //        //if (UserViewSettings.InboxType === "dismissed" || UserViewSettings.InboxType === "all") {
                    SetDateFilters(EUFilter.InboxType);
        //        //}

        //        if (UserViewSettings.InboxType === "dismissed") {
        //            $("#buttonUnassigned").addClass('k-state-disabled');
        //            $("#buttonUnassigned").prop('disabled', true);
        //        }
        //    }

        //    if (UserViewSettings.ShowAssignmentType !== "") {
        //        EUFilter.ShowAssignmentType = UserViewSettings.ShowAssignmentType;

        //        if (UserViewSettings.ShowAssignmentType !== "unassigned" && UserViewSettings.ShowAssignmentType !== "allalertassignments") {
        //            EUFilter.EmployeeCode = _EmployeeCode;

        //            $("#empMS").data("kendoMultiSelect").value([EUFilter.EmployeeCode]);
        //        } else {
        //            EUFilter.EmployeeCode = "";
        //            $("#empMS").data("kendoMultiSelect").value([{}]);
        //        }

        //        //ManageAssignmentTypeButtons(EUFilter.ShowAssignmentType);
        //    }

        //    if (UserViewSettings.GroupBy !== "") {
        //        EUFilter.GroupBy = UserViewSettings.GroupBy
        //    }

        //    if (EUFilter.ShowAssignmentType !== "myalerts" && EUFilter.ShowAssignmentType !== "unassigned") {
        //        //the excluded Assignment Types don't offer the "Only Tasks Marked Temp Complete" checkbox         
        //        if (UserViewSettings.ShowOnlyTempCompletedTasks) {
        //            $("#ShowOnlyTempCompletedTasks").attr("checked", true);
        //            EUFilter.ShowOnlyTempCompletedTasks = true;
        //        } else {
        //            $("#ShowOnlyTempCompletedTasks").attr("checked", false);
        //            EUFilter.ShowOnlyTempCompletedTasks = false;
        //        }
        //    }

        //    if (EUFilter.ShowAssignmentType !== "myalerts") {                
        //        if (UserViewSettings.IncludeBacklog) {
        //            $("#IncludeBacklogItems").attr("checked", true);
        //            EUFilter.IncludeBacklog = true;
        //        } else {
        //            $("#IncludeBacklogItems").attr("checked", false);
        //            EUFilter.IncludeBacklog = false;
        //        }
        //    }
        //} else {
        //    /************************/
        //    if (EUFilter.ShowAssignmentType !== "unassigned" && EUFilter.ShowAssignmentType !== "allalertassignments") {
        //        EUFilter.EmployeeCode = _EmployeeCode;

        //        $("#empMS").data("kendoMultiSelect").value([EUFilter.EmployeeCode]);
        //    } else {
        //        EUFilter.EmployeeCode = "";
        //        $("#empMS").data("kendoMultiSelect").value([{}]);
        //    }
        //    /************************/

        //    ManageAssignmentTypeButtons(EUFilter.ShowAssignmentType);

        //    $("#startdate").data("kendoDatePicker").value(EUFilter.StartDate);
        //    $("#duedate").data("kendoDatePicker").value(EUFilter.DueDate);

        //    $("#Search").val(EUFilter.SearchCriteria);
        //}

        //if (isJobJacketView && UserViewSettings.JJIncludeCompleted !== "") {
        //    EUFilter.IncludeCompletedAssignments = UserViewSettings.JJIncludeCompleted;

        //    //Include Completed defaults to checked in the JJ
        //    //It's only necessary to manage in the event of a false (uncheck Include Completed).
        //    if (UserViewSettings.JJIncludeCompleted == "False") {
        //        $('#includeCompletedItems').prop('checked', false);
        //    }
        //}

        userViewSettingsReady = true;
    } catch (e) { console.log(e);}
}

function UpdateUserViewSettings(viewType) {
    if (!_fromBookmarkFlag || isJobJacketView) {
        SyncUserViewSettings();

        let data = new Array();

        data.push({ "SettingName": "AAM_SearchCriteria", "SettingValue": UserViewSettings.SearchCriteria });
        data.push({ "SettingName": "AAM_InboxType", "SettingValue": UserViewSettings.InboxType });
        data.push({ "SettingName": "AAM_ShowAssignmentType", "SettingValue": UserViewSettings.ShowAssignmentType });
        data.push({ "SettingName": "AAM_GroupBy", "SettingValue": UserViewSettings.GroupBy });
        data.push({ "SettingName": "AAM_ShowOnlyTempCompletedTasks", "SettingValue": UserViewSettings.ShowOnlyTempCompletedTasks });
        data.push({ "SettingName": "AAM_GridSize", "SettingValue": UserViewSettings.GridSize });               
        data.push({ "SettingName": "AAM_IncludeBacklog", "SettingValue": UserViewSettings.IncludeBacklog });

        if (isJobJacketView) {
            data.push({ "SettingName": "AAM_JJIncludeCompleted", "SettingValue": UserViewSettings.JJIncludeCompleted });
            //data.push({ "SettingName": "AAM_JJShowAssignmentType", "SettingValue": UserViewSettings.JJShowAssignmentType });
        }


        $.ajax({
            type: "POST",
            url: 'Inbox/UpdateUserViewSettings',
            data: JSON.stringify({ UserSettings: data, ApplicationName: viewType }),
            contentType: 'application/json',
            success: function (result) {
            },
            error: function (result) {
            }
        });
    }
}

function onInboxViewChange() {
    let currentInboxType = GetViewValue();
    let previousInboxType = EUFilter.InboxType;

    EUFilter.InboxType = currentInboxType;

    if (gridDirty) {
        promptSave().done(() => ProcessInboxViewChange(previousInboxType));
    } else {
        ProcessInboxViewChange(previousInboxType);
    }
}

//function GetViewIndex(ViewText) {
//    let ViewValue = 0;

//    if (ViewText == "inbox") {
//        ViewValue = 0;
//    } else if (ViewText == "dismissed") {
//        ViewValue = 1;
//    } else if (ViewText == "all") {
//        ViewValue = 2;
//    } else if (ViewText == "task") {
//        ViewValue = 3;
//    } else {
//        //drafts
//        ViewValue = 4;
//    }

//    return ViewValue;
//}

//function GetViewValue() {
//    let ViewDropDownList = $('#AAView').data('kendoDropDownList');
//    let InboxType = '';

//    if (ViewDropDownList.value() === "Current") {
//        InboxType = "inbox";
//    } else if (ViewDropDownList.value() === "Dismissed/Completed") {
//        InboxType = "dismissed";
//    } else if (ViewDropDownList.value() === "All") {
//        InboxType = "all";
//    } else if (ViewDropDownList.value() === "Drafts") {
//        InboxType = "drafts";
//    } else if (ViewDropDownList.value() === "Task List View") {
//        InboxType = "task";
//    } else {
//        InboxType = "inbox";
//    }

//    return InboxType;
//}

function ClearFilters() {
    let gridData = $("#utilizationgrid").data("kendoGrid").dataSource;

    gridData.filter({});
}



function GetGrouping() {    
    let grouping = [];

    //if (UserViewSettings.GroupBy) {
    //    if (UserViewSettings.GroupBy.length > 0) {
    //        let groupArray = UserViewSettings.GroupBy.split(" ");

    //        for (let i = 0; i < groupArray.length; i++) {
    //            grouping.push({ field: groupArray[i] });
    //        }
    //    }
    //}    

    if (EUFilter.Page === "dept") {
        grouping.push({
            field: 'EmployeeDepartmentName', aggregates: [{ field: "RequiredHours", aggregate: "sum" }, { field: "BillableHours", aggregate: "sum" }, { field: "NonBillableHours", aggregate: "sum" }, { field: "NewBusinessHours", aggregate: "sum" }
                , { field: "OOOHours", aggregate: "sum" }, { field: "TotalHours", aggregate: "sum" }, { field: "BillablePercentGoal", aggregate: "average" }, { field: "AgencyHours", aggregate: "sum" }, { field: "TotalDirectHours", aggregate: "sum" }
                , { field: "NonDirectHours", aggregate: "sum" }, { field: "Variance", aggregate: "sum" }, { field: "BillableHoursGoal", aggregate: "sum" }, { field: "DirectHoursGoal", aggregate: "sum" }, { field: "DirectPercentGoal", aggregate: "average" }]
        });
    }
    //else if (EUFilter.Page === "billablegoal") {
    //    grouping.push({
    //        field: 'BillableHoursGoal', aggregates: [{ field: "RequiredHours", aggregate: "sum" }, { field: "BillableHours", aggregate: "sum" }, { field: "NonBillableHours", aggregate: "sum" }, { field: "NewBusinessHours", aggregate: "sum" }
    //            , { field: "OOOHours", aggregate: "sum" }, { field: "TotalHours", aggregate: "sum" }, { field: "BillablePercentGoal", aggregate: "average" }]
    //    });
    //} 
   
    return grouping;
}

function ResizeGrid(collapseFlag) { 
    if ($('#utilizationgrid').offset().top) {
        var bottom = $('#utilizationgrid').offset().top;
        var viewHeight = $(window).height();

        let grid = $("#utilizationgrid").data("kendoGrid");

        if (collapseFlag == true) {
            $('#utilizationgrid').height(viewHeight - bottom - 15);
        } else {
            $('#utilizationgrid').height(viewHeight - bottom - 15);
        }

        if (grid !== undefined) {
            grid.resize();
        }
    }
}
function unSavedChanges() {
    return _scope.saveAvailable();
}

$(window).resize((e, collapseFlag) => {    
    ResizeGrid(collapseFlag);
});

function GetGridView() {
    let GridView = "";    
    GridView = "RadGridEUDashboard";
    return GridView;
}

function DestroyGrid() {
    var dataGrid = $("#utilizationgrid").data("kendoGrid");
    dataGrid.destroy();
    $("#utilizationgrid").empty();
}

function ReloadGrid() {    

    if ($("#utilizationgrid").data("kendoGrid") === undefined) {        
        setTimeout(ReloadGrid, 250); /* this checks the flag every 100 milliseconds*/
    } else {        
        let grid = $("#utilizationgrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);   
        grid.dataSource.read();

        //LoadColumnVisibilitySettings();
        UpdateUserViewSettings(_viewType);    
        
    }
}


function ProcessInboxViewChange(previousInboxType) {     

    let currentInboxType = GetViewValue();

    //if (EUFilter.ShowAssignmentType !== "unassigned" && EUFilter.ShowAssignmentType !== "allassignments") {
    //    $("#empMS").data("kendoMultiSelect").value([EUFilter.EmployeeCode]);        
    //}

    /*AC: added for dismissed logic*/
    if (currentInboxType === "dismissed") {
        $("#buttonUnassigned").removeClass("k-state-active");
        $("#buttonUnassigned").addClass('k-state-disabled');
        $("#buttonUnassigned").prop('disabled', true);         

        if (EUFilter.ShowAssignmentType === 'unassigned') {
            $("#buttonMyAlertsAndAssignments").addClass("k-state-active");
            EUFilter.ShowAssignmentType = "myalertsandassignments";
            $("#empMS").data("kendoMultiSelect").value([EUFilter.EmployeeCode]);

            UpdateUserViewSettings(_viewType);
        }
    } else {
        if (GroupSecuritySettings.ShowUnassignedAssignments === "False") {
            $("#buttonUnassigned").addClass('k-state-disabled');
            $("#buttonUnassigned").prop('disabled', true);
        } else {
            $("#buttonUnassigned").removeClass('k-state-disabled');
            $("#buttonUnassigned").prop('disabled', false);   
        }             
    }

    //if (EUFilter.InboxType !== "inbox") {
    //    //$("#dismissAllListItem").hide();
    //    $("#btnDismissAll").removeClass("k-state-active");
    //    $("#btnDismissAll").prop('disabled', true);
    //} else {
    //    //$("#dismissAllListItem").show();
    //    $("#btnDismissAll").addClass('k-state-disabled');
    //    $("#btnDismissAll").prop('disabled', false);
    //}

    if (previousInboxType !== EUFilter.InboxType) { 
        columnSettingsReady = false;
        DestroyGrid();
        LoadUserColumnSettings();

        SetDateFilters(GetViewValue());

        ReloadGrid();
    }

    //ManageDismissAllButton(EUFilter.ShowAssignmentType, currentInboxType);
}

function SetDateFilters(view) {    
    let currentDate = new Date();
    let startDate = "";
    let dueDate = "";

    var date = new Date();
    var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
    var lastDay = new Date(date.getFullYear(), date.getMonth() + 1, 0);   

    //startDate = kendo.toString(kendo.parseDate(firstDay), 'MM/dd/yyyy');
    //$("#startdate").data('kendoDatePicker').value(startDate);

    //dueDate = kendo.toString(kendo.parseDate(lastDay), 'MM/dd/yyyy');        
    //$("#duedate").data("kendoDatePicker").value(dueDate);

    //if (view == "dismissed" || view == "all") {
    //    //set startDate to two days ago
    //    currentDate.setDate(currentDate.getDate() - 30);
    //    startDate = kendo.toString(kendo.parseDate(currentDate), 'MM/dd/yyyy');
    //    $("#startdate").data('kendoDatePicker').value(startDate);
    //} else {
    //    $("#startdate").data('kendoDatePicker').value("");
    //    startDate = null;
    //}   

    //EUFilter.StartDate = startDate;
    //EUFilter.EndDate = dueDate;
    if (_fromBookmarkFlag === false) {
        EUFilter.FromMonth = firstDay.getMonth() + 1;
        EUFilter.FromYear = firstDay.getFullYear();
    }    

    if ($("#Year1Button").text() === EUFilter.FromYear.toString()) {
        $("#Year1Button").addClass("k-state-active");
    }
    if ($("#Year2Button").text() === EUFilter.FromYear.toString()) {
        $("#Year2Button").addClass("k-state-active");
    }
    if ($("#Year3Button").text() === EUFilter.FromYear.toString()) {
        $("#Year3Button").addClass("k-state-active");
    }
    

    if (EUFilter.FromMonth === 1) {
        $("#JanButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 2) {
        $("#FebButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 3) {
        $("#MarButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 4) {
        $("#AprButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 5) {
        $("#MayButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 6) {
        $("#JunButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 7) {
        $("#JulButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 8) {
        $("#AugButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 9) {
        $("#SepButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 10) {
        $("#OctButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 11) {
        $("#NovButton").addClass("k-state-active");
    } else if (EUFilter.FromMonth === 12) {
        $("#DecButton").addClass("k-state-active");
    }

}

function cancelChanges() {    
    showKendoConfirm("Are you sure you want to cancel all unsaved changes? You cannot undo this operation.")
        .done(function () {
            //OK                      
            gridDirty = false;
            refreshPage("");            
        })
        .fail(function () {
            //CANCEL
        });
}

function getParentRefreshFlag() {
    return parentRefreshFlag;
}

function getJobJacketAssignmentType(test) {
    //return JobJacketAssignmentType;
    return test;
}

function refreshPage(requestor) {        
    //if requestor is coming from webvantage.ts based on saving or sending alert/assignment in detail view then don't
    //prompt for a save.
    if (gridDirty && requestor !== "parent") {
        promptSave();
    }
    else {
        /*process refresh*/
        UpdateUserViewSettings(_viewType);

        var dataGrid = $("#utilizationgrid").data("kendoGrid");
        //let gridFilters = dataGrid.dataSource.filter();

        //dataGrid.dataSource.filter({});

        gridDirty = false;
        enableSave();
        dataGrid.dataSource.read();
    }
}

function ExportToExcel() {    
    let grid = $("#utilizationgrid").data("kendoGrid");
    grid.saveAsExcel();    
}

function bookmarkPage() {

    let StartDatePicker = $("#startdate").data("kendoDatePicker");
    let EndDatePicker = $("#duedate").data("kendoDatePicker");

    if (StartDatePicker.value() !== null) {
        StartDate = StartDatePicker.value().toDateString();
    }

    if (EndDatePicker.value() !== null) {
        EndDate = EndDatePicker.value().toDateString();
    }

    //if ($("#AugButton").data("button").options.selected) {
    //    Month = 8;
    //}

    let bookmark = {
        Month: EUFilter.FromMonth,
        Year: EUFilter.FromYear,
        GridSize: UserViewSettings.GridSize
    };    

    $.ajax({
        type: "POST",
        data: bookmark,
        dataType: "json",
        url: 'EmployeeUtilization/BookmarkEmployeeUtilization',
        success: function (data) {
            console.log(data.Success);
            if (data.Success) {
                showKendoAlert("Bookmark successfully added.");
            } else {
                showKendoAlert("Bookmark already exists.");
            }
            
        },
        error: function () {
            showKendoAlert("An error occurred while generating bookmark, please contact support.");
        }
    });
}

function clearSearch() {
    console.log("clearSearch");
    $("#Search").val("");
    EUFilter.SearchCriteria = "";
    //EUFilter.ShowAssignmentType = "myalertsandassignments";
    
    UpdateUserViewSettings(_viewType);

    var dataGrid = $("#utilizationgrid").data("kendoGrid");
    dataGrid.dataSource.filter({});
    dataGrid.dataSource.read();
}

function enableSave() {

    if (gridDirty === true) {        
        $("#saveButton").removeClass('k-state-disabled');
        $("#cancelButtonVis").removeClass('k-state-disabled');
        $("#saveButton").prop('disabled', false);
        $("#cancelButtonVis").prop('disabled', false);      
        $("#ResetOptionsButton").prop('disabled', true);
        $("#ResetOptionsButton").addClass('k-state-disabled');
    }
    else {        
        $("#saveButton").addClass('k-state-disabled');
        $("#cancelButtonVis").addClass('k-state-disabled');
        $("#saveButton").prop('disabled', true);
        $("#cancelButtonVis").prop('disabled', true);        
        $("#ResetOptionsButton").prop('disabled', false);
        $("#ResetOptionsButton").removeClass('k-state-disabled');
    }
}

function search() {

    var datePicker = $("#startdate").data("kendoDatePicker");

    var StartDate = datePicker.value();
    if (StartDate !== null) {
        StartDate = datePicker.value().toDateString();
    }
    datePicker = $("#duedate").data("kendoDatePicker");
    var EndDate = datePicker.value();
    if (EndDate !== null) {
        EndDate = datePicker.value().toDateString();
    }

    var multiselect = $("#empMS").data("kendoMultiSelect");
    var empcode = multiselect.value();
        
    EUFilter.EmployeeCode = empcode[0];
    EUFilter.SearchCriteria = $('#Search').val();
    EUFilter.InboxType = GetViewValue();
    EUFilter.StartDate = StartDate;
    EUFilter.EndDate = EndDate;    

    
    UpdateUserViewSettings(_viewType);
    
    var grid = $("#utilizationgrid");
    grid.data("kendoGrid").dataSource.read();

}

function RefreshGridByMonth(month) {   

    EUFilter.FromMonth = month;
    EUFilter.ToMonth = month;

    let DataGrid = $("#utilizationgrid").data("kendoGrid");
    DataGrid.setDataSource(DataGrid.dataSource);
    DataGrid.dataSource.read();

    $("#JanButton").removeClass("k-state-active");
    $("#FebButton").removeClass("k-state-active");
    $("#MarButton").removeClass("k-state-active");
    $("#AprButton").removeClass("k-state-active");
    $("#MayButton").removeClass("k-state-active");
    $("#JunButton").removeClass("k-state-active");
    $("#JulButton").removeClass("k-state-active");
    $("#AugButton").removeClass("k-state-active");
    $("#SepButton").removeClass("k-state-active");
    $("#OctButton").removeClass("k-state-active");
    $("#NovButton").removeClass("k-state-active");
    $("#DecButton").removeClass("k-state-active");
    $("#YTDButton").removeClass("k-state-active");

    if (month === 1) {
        $("#JanButton").addClass("k-state-active");
    } else if (month === 2) {
        $("#FebButton").addClass("k-state-active");
    } else if (month === 3) {
        $("#MarButton").addClass("k-state-active");
    } else if (month === 4) {
        $("#AprButton").addClass("k-state-active");
    } else if (month === 5) {
        $("#MayButton").addClass("k-state-active");
    } else if (month === 6) {
        $("#JunButton").addClass("k-state-active");
    } else if (month === 7) {
        $("#JulButton").addClass("k-state-active");
    } else if (month === 8) {
        $("#AugButton").addClass("k-state-active");
    } else if (month === 9) {
        $("#SepButton").addClass("k-state-active");
    } else if (month === 10) {
        $("#OctButton").addClass("k-state-active");
    } else if (month === 11) {
        $("#NovButton").addClass("k-state-active");
    } else if (month === 12) {
        $("#DecButton").addClass("k-state-active");
    }
}

function RefreshGridByYear(month) {   

    EUFilter.FromMonth = month;

    let DataGrid = $("#utilizationgrid").data("kendoGrid");
    DataGrid.setDataSource(DataGrid.dataSource);
    DataGrid.dataSource.read();
    //DataGrid.data("kendoGrid").dataSource.filter({});

    //ManageAssignmentTypeButtons(AssignmentType);
}

function onYear1Click(year) {

    EUFilter.FromYear = year;

    $("#Year1Button").addClass("k-state-active");
    $("#Year2Button").removeClass("k-state-active");
    $("#Year3Button").removeClass("k-state-active");

    let DataGrid = $("#utilizationgrid").data("kendoGrid");
    DataGrid.setDataSource(DataGrid.dataSource);
    DataGrid.dataSource.read();

}

function onYear2Click(year) {

    EUFilter.FromYear = year;

    $("#Year2Button").addClass("k-state-active");
    $("#Year1Button").removeClass("k-state-active");
    $("#Year3Button").removeClass("k-state-active");

    let DataGrid = $("#utilizationgrid").data("kendoGrid");
    DataGrid.setDataSource(DataGrid.dataSource);
    DataGrid.dataSource.read();

}

function onYear3Click(year) {

    EUFilter.FromYear = year;

    $("#Year3Button").addClass("k-state-active");
    $("#Year1Button").removeClass("k-state-active");
    $("#Year2Button").removeClass("k-state-active");

    let DataGrid = $("#utilizationgrid").data("kendoGrid");
    DataGrid.setDataSource(DataGrid.dataSource);
    DataGrid.dataSource.read();

}

function onMonthClick(month) {    

    RefreshGridByMonth(month);
   
}

function onYTDClick() {

    EUFilter.ToMonth = 13;

    let DataGrid = $("#utilizationgrid").data("kendoGrid");
    DataGrid.setDataSource(DataGrid.dataSource);
    DataGrid.dataSource.read();

    //$("#JanButton").removeClass("k-state-active");
    //$("#FebButton").removeClass("k-state-active");
    //$("#MarButton").removeClass("k-state-active");
    //$("#AprButton").removeClass("k-state-active");
    //$("#MayButton").removeClass("k-state-active");
    //$("#JunButton").removeClass("k-state-active");
    //$("#JulButton").removeClass("k-state-active");
    //$("#AugButton").removeClass("k-state-active");
    //$("#SepButton").removeClass("k-state-active");
    //$("#OctButton").removeClass("k-state-active");
    //$("#NovButton").removeClass("k-state-active");
    //$("#DecButton").removeClass("k-state-active");

    $("#YTDButton").addClass("k-state-active");

}

