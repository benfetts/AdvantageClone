//
let _fromBookmarkFlag = false;
let _sortedField = '';
let _sortedDirection = '';

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

        if (AlertFilter.InboxType === "task") {
            aagrid = CreateTaskViewGrid();
        } else {
            aagrid = CreateAAViewGrid();
        }

        if (AlertFilter.InitialLoadFlag) {
            let grid = $("#aagrid").data("kendoGrid");
            grid.setDataSource(grid.dataSource);
            grid.dataSource.read();
        }

        AAGrid_SubscribeToShared();
    }
}

function GetGroupSecuritySettings() {    
    $.ajax({
        url: 'Inbox/GroupSecuritySettings',
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
            url: 'Inbox/GetUserViewSettings',
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
        UserViewSettings.SearchCriteria = AlertFilter.SearchCriteria;
        UserViewSettings.InboxType = AlertFilter.InboxType;
        UserViewSettings.ShowAssignmentType = AlertFilter.ShowAssignmentType;        
        UserViewSettings.ShowOnlyTempCompletedTasks = AlertFilter.ShowOnlyTempCompletedTasks;
        UserViewSettings.IncludeBacklog = AlertFilter.IncludeBacklog;

        //the following userViewSettings aren't stored int he AlertFilter object,
        //as they do not apply to the datasource parameters
        UserViewSettings.GroupBy = urlParms.get("aamgb");
        UserViewSettings.GridSize = urlParms.get("aamgs");

        SetUserViewSettings();   
        userViewSettingsReady = true;
    }    
}

function SyncUserViewSettings() {
    UserViewSettings.SearchCriteria = AlertFilter.SearchCriteria;
    UserViewSettings.InboxType = AlertFilter.InboxType;
    UserViewSettings.ShowAssignmentType = AlertFilter.ShowAssignmentType;    
    UserViewSettings.GroupBy = AlertFilter.GroupBy;
    UserViewSettings.ShowOnlyTempCompletedTasks = AlertFilter.ShowOnlyTempCompletedTasks;    
    UserViewSettings.IncludeBacklog = AlertFilter.IncludeBacklog;

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
        UserViewSettings.JJIncludeCompleted = AlertFilter.IncludeCompletedAssignments;
    }
}

function SetUserViewSettings() {
    try {
        let currentViewValue = "";        

        if (!_fromBookmarkFlag || isJobJacketView) {            
            if (UserViewSettings.SearchCriteria !== "") {
                AlertFilter.SearchCriteria = UserViewSettings.SearchCriteria;
                $("#Search").val(UserViewSettings.SearchCriteria);
            }

            if (UserViewSettings.InboxType !== "") {
                AlertFilter.InboxType = UserViewSettings.InboxType;

                if (UserViewSettings.InboxType === "dismissed" || UserViewSettings.InboxType === "all") {
                    SetDateFilters(AlertFilter.InboxType);
                }

                if (UserViewSettings.InboxType === "dismissed") {
                    $("#buttonUnassigned").addClass('k-state-disabled');
                    $("#buttonUnassigned").prop('disabled', true);
                }
            }

            if (UserViewSettings.ShowAssignmentType !== "") {
                AlertFilter.ShowAssignmentType = UserViewSettings.ShowAssignmentType;

                if (UserViewSettings.ShowAssignmentType !== "unassigned" && UserViewSettings.ShowAssignmentType !== "allalertassignments") {
                    AlertFilter.EmployeeCode = _EmployeeCode;

                    $("#empMS").data("kendoMultiSelect").value([AlertFilter.EmployeeCode]);
                } else {
                    AlertFilter.EmployeeCode = "";
                    $("#empMS").data("kendoMultiSelect").value([{}]);
                }

                //ManageAssignmentTypeButtons(AlertFilter.ShowAssignmentType);
            }

            if (UserViewSettings.GroupBy !== "") {
                AlertFilter.GroupBy = UserViewSettings.GroupBy
            }

            if (AlertFilter.ShowAssignmentType !== "myalerts" && AlertFilter.ShowAssignmentType !== "unassigned") {
                //the excluded Assignment Types don't offer the "Only Tasks Marked Temp Complete" checkbox         
                if (UserViewSettings.ShowOnlyTempCompletedTasks) {
                    $("#ShowOnlyTempCompletedTasks").attr("checked", true);
                    AlertFilter.ShowOnlyTempCompletedTasks = true;
                } else {
                    $("#ShowOnlyTempCompletedTasks").attr("checked", false);
                    AlertFilter.ShowOnlyTempCompletedTasks = false;
                }
            }

            if (AlertFilter.ShowAssignmentType !== "myalerts") {                
                if (UserViewSettings.IncludeBacklog) {
                    $("#IncludeBacklogItems").attr("checked", true);
                    AlertFilter.IncludeBacklog = true;
                } else {
                    $("#IncludeBacklogItems").attr("checked", false);
                    AlertFilter.IncludeBacklog = false;
                }
            }
        } else {
            /************************/
            if (AlertFilter.ShowAssignmentType !== "unassigned" && AlertFilter.ShowAssignmentType !== "allalertassignments") {
                AlertFilter.EmployeeCode = _EmployeeCode;

                $("#empMS").data("kendoMultiSelect").value([AlertFilter.EmployeeCode]);
            } else {
                AlertFilter.EmployeeCode = "";
                $("#empMS").data("kendoMultiSelect").value([{}]);
            }
            /************************/

            ManageAssignmentTypeButtons(AlertFilter.ShowAssignmentType);

            $("#startdate").data("kendoDatePicker").value(AlertFilter.StartDate);
            $("#duedate").data("kendoDatePicker").value(AlertFilter.DueDate);

            $("#Search").val(AlertFilter.SearchCriteria);
        }

        if (isJobJacketView && UserViewSettings.JJIncludeCompleted !== "") {
            AlertFilter.IncludeCompletedAssignments = UserViewSettings.JJIncludeCompleted;

            //Include Completed defaults to checked in the JJ
            //It's only necessary to manage in the event of a false (uncheck Include Completed).            
            if (AlertFilter.IncludeCompletedAssignments == "False" || AlertFilter.IncludeCompletedAssignments == "false" || !AlertFilter.IncludeCompletedAssignments) {
                $('#includeCompletedItems').prop('checked', false);
            } else {
                $('#includeCompletedItems').prop('checked', true);
            }
        }

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

function allCommentsClick() {
    //If Me.FromJobNumber > 0 And Me.FromJobComponentNbr > 0 Then
    //Me.OpenWindow(" " & Me.FromJobNumber.ToString().PadLeft(6, "0") & " - " & Me.FromJobComponentNbr.ToString().PadLeft(2, "0"), "JobComponent_Comments.aspx?a=0&j=" & Me.FromJobNumber.ToString() & "&jc=" & Me.FromJobComponentNbr.ToString(), 450, 710, False, True)
    //End If

    let url = ""

    url = `JobComponent_Comments.aspx?a=0&j=${AlertFilter.JobNumber}&jc=${AlertFilter.JobComponentNumber}`;
    OpenRadWindow('Comments for Job: ', url, 450, 710, true);

}
function includeCompleted() {

    if ($('#includeCompletedItems').prop('checked') == true) {
        AlertFilter.IncludeCompletedAssignments = true;
    } else {
        AlertFilter.IncludeCompletedAssignments = false;
    }
    
    //if (AlertFilter.IncludeCompletedAssignments) {
    //    $('#includeCompleted input[type="checkbox"]').prop("checked", false);
    //    AlertFilter.IncludeCompletedAssignments = false;
    //} else {
    //    $('#includeCompleted input[type="checkbox"]').prop("checked", true);
    //    AlertFilter.IncludeCompletedAssignments = true;
    //}     

    UpdateUserViewSettings(_viewType);
    
    var dataGrid = $("#aagrid").data("kendoGrid");
    dataGrid.dataSource.read();
}

function onInboxViewChange() {
    let currentInboxType = GetViewValue();
    let previousInboxType = AlertFilter.InboxType;

    AlertFilter.InboxType = currentInboxType;

    if (gridDirty) {
        promptSave().done(() => ProcessInboxViewChange(previousInboxType));
    } else {
        ProcessInboxViewChange(previousInboxType);
    }
}

function GetViewIndex(ViewText) {
    let ViewValue = 0;

    if (ViewText == "inbox") {
        ViewValue = 0;
    } else if (ViewText == "dismissed") {
        ViewValue = 1;
    } else if (ViewText == "all") {
        ViewValue = 2;
    } else if (ViewText == "task") {
        ViewValue = 3;
    } else {
        //drafts
        ViewValue = 4;
    }

    return ViewValue;
}

function GetViewValue() {
    let ViewDropDownList = $('#AAView').data('kendoDropDownList');
    let InboxType = '';

    if (ViewDropDownList.value() === "Current") {
        InboxType = "inbox";
    } else if (ViewDropDownList.value() === "Dismissed/Completed") {
        InboxType = "dismissed";
    } else if (ViewDropDownList.value() === "All") {
        InboxType = "all";
    } else if (ViewDropDownList.value() === "Drafts") {
        InboxType = "drafts";
    } else if (ViewDropDownList.value() === "Task List View") {
        InboxType = "task";
    } else {
        InboxType = "inbox";
    }

    return InboxType;
}

function CompleteTempComplete() {    
    let gridData = $("#aagrid").data("kendoGrid").dataSource;
    let previousAlertID = 0;
    let currentAlertID = 0;

    let filters = gridData.filter();
    let allData = gridData.data();
    let query = new kendo.data.Query(allData);
    let data = query.filter(filters).data;

    let alertIds = '';

    for (let i = 0; i < data.length; i++) {
        currentAlertID = data[i].AlertID;

        if (previousAlertID !== currentAlertID) {
            if (data[i].IsMyTaskTempComplete) {
                if (i === 0) {
                    alertIds += currentAlertID;
                } else {
                    alertIds += ',' + currentAlertID;
                }                
            }
        }

        previousAlertID = data[i].AlertID;
    }        

    let request = {
        AssignedEmployee: AlertFilter.EmployeeCode,
        Role: AlertFilter.EmployeeRole,                
        ProjectManager: "All",
        Office: "All",
        TaskStatus: "",
        SearchCriteria: AlertFilter.SearchCriteria,
        AlertID: alertIds
    };    

    console.log(request);

    if (request.Role == "") {
        request.Role = "All";
    }

    if (request.AssignedEmployee == "" || request.AssignedEmployee === undefined) {
        request.AssignedEmployee = "All";
    }

    $.ajax({
        type: "POST",
        data: JSON.stringify(request),
        contentType: "application/json",
        url: "Inbox/CompleteTempComplete",
        success: function (response) {
            refreshPage("");            
        },
        error: function (response) {
            if (response.Message.length > 0) {
                showKendoAlert(response.Message);
            }
        }
    });
}

function DismissAll() {
    promptDismissAll();
}

function ProcessDismissAll() {
    let gridData = $("#aagrid").data("kendoGrid").dataSource;
    let previousAlertID = 0;
    let currentAlertID = 0;        

    let filters = gridData.filter();
    let allData = gridData.data();
    let query = new kendo.data.Query(allData);
    let data = query.filter(filters).data;     

    let alerts = [];

    for (let i = 0; i < data.length; i++) {
        currentAlertID = data[i].AlertID;
        
        if (previousAlertID !== currentAlertID) {
            if (data[i].IsMyAlert) {                
                alerts.push(currentAlertID);                
            }
        }

        previousAlertID = data[i].AlertID;
    }    

    console.log(alerts);

    $.ajax({
        type: "POST",
        data: { AlertIDs: alerts },                
        url: "Inbox/DismissComplete",        
        success: function (response) {  
            //if response.Success == False an issue occurred when processing dismissal
            /*if (!response.Success) {
                showKendoAlert(response.Message);

                if (response.Message.length > 0) {
                    showKendoAlert(response.Message);
                }
            }*/

            let dataGrid = $("#aagrid").data("kendoGrid");                            
            setTimeout(function () {
                dataGrid.dataSource.read()
            }, 1000);
        },
        error: function (response) {                        
            if (response.Message.length > 0) {
                showKendoAlert(response.Message);
            }
        }
    });
}

function ClearFilters() {
    let gridData = $("#aagrid").data("kendoGrid").dataSource;

    gridData.filter({});
}



function GetGrouping() {    
    let grouping = [];

    if (UserViewSettings.GroupBy) {
        if (UserViewSettings.GroupBy.length > 0) {
            let groupArray = UserViewSettings.GroupBy.split(" ");

            for (let i = 0; i < groupArray.length; i++) {
                grouping.push({ field: groupArray[i] });
            }
        }
    }    
    
    return grouping;
}

function ResizeGrid(collapseFlag) { 
    if ($('#aagrid').offset().top) {
        var bottom = $('#aagrid').offset().top;
        var viewHeight = $(window).height();

        let grid = $("#aagrid").data("kendoGrid");

        if (collapseFlag == true) {
            $('#aagrid').height(viewHeight - bottom - 15);
        } else {
            $('#aagrid').height(viewHeight - bottom - 15);
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
    switch (AlertFilter.InboxType) {
        case "inbox":
            GridView = "RadGridAlertInbox";
            break;
        case "dismissed":
            GridView = "RadGridAlertDismissed";
            break;
        case "all":
            GridView = "RadGridAlertAll";
            break;
        case "task":
            GridView = "AAMTaskViewGrid";
            break;
        case "drafts":
            GridView = "RadGridAlertDrafts";
            break;
    };    

    return GridView;
}

function DestroyGrid() {
    var dataGrid = $("#aagrid").data("kendoGrid");
    dataGrid.destroy();
    $("#aagrid").empty();
}

function ReloadGrid() {    

    if ($("#aagrid").data("kendoGrid") === undefined) {        
        setTimeout(ReloadGrid, 250); /* this checks the flag every 100 milliseconds*/
    } else {        
        let grid = $("#aagrid").data("kendoGrid");
        grid.setDataSource(grid.dataSource);   
        grid.dataSource.read();

        //LoadColumnVisibilitySettings();
        UpdateUserViewSettings(_viewType);            
    }
}


function ProcessInboxViewChange(previousInboxType) {     

    let currentInboxType = GetViewValue();

    //if (AlertFilter.ShowAssignmentType !== "unassigned" && AlertFilter.ShowAssignmentType !== "allassignments") {
    //    $("#empMS").data("kendoMultiSelect").value([AlertFilter.EmployeeCode]);        
    //}

    /*AC: added for dismissed logic*/
    if (currentInboxType === "dismissed") {
        $("#buttonUnassigned").removeClass("k-state-active");
        $("#buttonUnassigned").addClass('k-state-disabled');
        $("#buttonUnassigned").prop('disabled', true);         

        if (AlertFilter.ShowAssignmentType === 'unassigned') {
            $("#buttonMyAlertsAndAssignments").addClass("k-state-active");
            AlertFilter.ShowAssignmentType = "myalertsandassignments";
            $("#empMS").data("kendoMultiSelect").value([AlertFilter.EmployeeCode]);

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

    //if (AlertFilter.InboxType !== "inbox") {
    //    //$("#dismissAllListItem").hide();
    //    $("#btnDismissAll").removeClass("k-state-active");
    //    $("#btnDismissAll").prop('disabled', true);
    //} else {
    //    //$("#dismissAllListItem").show();
    //    $("#btnDismissAll").addClass('k-state-disabled');
    //    $("#btnDismissAll").prop('disabled', false);
    //}

    if (previousInboxType !== AlertFilter.InboxType) { 
        columnSettingsReady = false;
        DestroyGrid();
        LoadUserColumnSettings();

        SetDateFilters(GetViewValue());

        ReloadGrid();
    }

    //ManageDismissAllButton(AlertFilter.ShowAssignmentType, currentInboxType);
}

function SetDateFilters(view) {    
    let currentDate = new Date();
    let startDate = "";
    let dueDate = "";

    dueDate = kendo.toString(kendo.parseDate(currentDate), 'MM/dd/yyyy');        
    $("#duedate").data("kendoDatePicker").value(dueDate);

    if (view == "dismissed" || view == "all") {
        //set startDate to two days ago
        currentDate.setDate(currentDate.getDate() - 30);
        startDate = kendo.toString(kendo.parseDate(currentDate), 'MM/dd/yyyy');
        $("#startdate").data('kendoDatePicker').value(startDate);
    } else {
        $("#startdate").data('kendoDatePicker').value("");
        startDate = null;
    }

    AlertFilter.StartDate = startDate;
    AlertFilter.EndDate = dueDate;
}

function promptDismissAll() {
    let dfd = jQuery.Deferred();

    this.showKendoConfirm("<p><strong>Are you sure you want to dismiss all alerts in the filtered inbox?</strong><p>")
        .done(function () {
            ProcessDismissAll();

            setTimeout(() => {
            }, 500);

            dfd.resolve();
        })
        .fail(function () {                                   
            dfd.resolve();
        });    

    return dfd.promise();
}


function promptSave() {
    let dfd = jQuery.Deferred();    
    promptSaveActive = true;

    this.showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")    
        .done(function () {            
            saveGridChanges();            

            setTimeout(() => {
            }, 500);            

            promptSaveActive = false;
            dfd.resolve();
        })
        .fail(function () {                    
            /*process refresh and clean grid*/            
            $(".k-dirty").removeClass("k-dirty");
            
            var dataGrid = $("#aagrid").data("kendoGrid");
            dataGrid.dataSource.read();

            promptSaveActive = false;
            dfd.resolve();
        });

    gridDirty = false;
    enableSave();

    return dfd.promise();
}

function unSavedChanges() {        
    return gridDirty;
}

function ParentContainerSave() {
    saveGridChanges();
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
        console.log("stop");
        UpdateUserViewSettings(_viewType);

        var dataGrid = $("#aagrid").data("kendoGrid");
        //let gridFilters = dataGrid.dataSource.filter();

        //dataGrid.dataSource.filter({});

        gridDirty = false;
        enableSave();
        dataGrid.dataSource.read();
    }
}

function saveGridChanges() {
    
    let Grid = $("#aagrid").data("kendoGrid");
    let GridData = Grid.dataSource.data();
    let DirtyData = $.grep(GridData, function (item) {          
        return item.dirty;        
    });           

    if (isJobJacketView) {        
        //the AAM has been opened by the JJ
        //if changes have been made while in this view and saved, then
        //set the parentRefreshFlag to notify webvantage.ts to refresh
        //a possible open instance of the AAM (AAM has been opened directly).
        parentRefreshFlag = true;    
    }

    let newDirty = new Array();

    for (let i = 0; i < DirtyData.length; i++) {    
        let DirtyRow = {
            UID: "",
            AlertID: "",
            AlertCategoryID: "",
            TaskStatus: "",
            StartDate: "",
            StartDateDirty: false,
            DueDate: "",
            DueDateDirty: false,
            Priority: "",
            PriorityDirty: false
        }                        

        DirtyRow.UID = DirtyData[i]["uid"];
        DirtyRow.AlertID = DirtyData[i]["AlertID"];
        DirtyRow.AlertCategoryID = DirtyData[i]["AlertCategoryID"];
        DirtyRow.TaskStatus = DirtyData[i]["TaskStatus"];

        DirtyRow.StartDate = DirtyData[i]["StartDate"];
        if (DirtyData[i]["dirtyFields"]["StartDate"]) {
            DirtyRow.StartDateDirty = true;
        }

        DirtyRow.DueDate = DirtyData[i]["DueDate"];
        if (DirtyData[i]["dirtyFields"]["DueDate"]) {
            DirtyRow.DueDateDirty = true;
        }

        DirtyRow.Priority = DirtyData[i]["Priority"];
        if (DirtyData[i]["dirtyFields"]["Priority"]) {
            DirtyRow.PriorityDirty = true;
        }
        
        newDirty.push(DirtyRow);        
    }    
    
    let JsonDirty = JSON.stringify(newDirty);        

    if (DirtyData.length > 0) {
        $.ajax({
            type: "POST",
            url: "Inbox/ProcessDataGridUpdates",
            data: JsonDirty,//JSON.stringify(DirtyData),
            contentType: 'application/json',
            success: function (response) {                                
                //showKendoAlert("Data successfully updated.");                
                //refresh data grid
                gridDirty = false;                
                enableSave();
                $(".k-dirty").removeClass("k-dirty");
                updatePriorityIcon(newDirty);                

                if ((UserViewSettings.GroupBy.includes("StartDate") && newDirty[0].StartDateDirty) ||
                    (UserViewSettings.GroupBy.includes("DueDate") && newDirty[0].DueDateDirty) ||
                    (UserViewSettings.GroupBy.includes("Priority") && newDirty[0].PriorityDirty)) {
                    //if the grid is currently grouped on one of the editable fields above, then refresh the grid,
                    //as the 'Save' could affect the grouping
                    refreshPage("");
                }
            },
            error: function (response) {
                console.log("An error occurred during update: " + response.message);
                //showKendoAlert(Message);
            }
        });        
    }     

    //UpdateUserViewSettings();        
}

function getTaskTitleDescription(taskStatus, priority) {
    if (taskStatus === "H") {
        priorityTooltip = "High Priority";
    } else if (taskStatus === "L") {
        priorityTooltip = "Low Priority";
    } else if (taskStatus === "A") {
        if (priority == 1) {
            priorityTooltip = "Active (Highest Priority)";
        } else if (priority === 2) {
            priorityTooltip = "Active (High Priority)";
        } else if (priority === 3) {
            priorityTooltip = "Active (Normal)";
        } else if (priority === 4) {
            priorityTooltip = "Active (Low Priority)";
        } else {
            //(priority == 5)             
            priorityTooltip = "Active (Lowest Priority)";
        }
    } else if (taskStatus == "P") {
        if (priority == 1) {
            priorityTooltip = "Projected (Highest Priority)";
        } else if (priority == 2) {
            priorityTooltip = "Projected (High Priority)";
        } else if (priority == 3) {
            priorityTooltip = "Projected (Normal)";
        } else if (priority == 4) {
            priorityTooltip = "Projected (Low Priority)";
        } else {
            //(priority == 5)             
            priorityTooltip = "Projected (Lowest Priority)";
        }
    } else {
        priorityTooltip = "N/A";
    }

    return priorityTooltip;
}

function getDetailTitleDescriptionByPriority(priority) {            
    let detailTitle = "";

    switch (priority) {
        case "1":
            detailTitle = "Highest Priority/Click to view details";
            break;
        case "2":
            detailTitle = "High Priority/Click to view details";
            break;
        case "3":
            detailTitle = "Normal Priority/Click to view details";
            break;
        case "4":
            detailTitle = "Low Priority/Click to view details";
            break;
        case "5":
            detailTitle = "Lowest Priority/Click to view details";
            break;
        default:
    }  

    return detailTitle;
}

function getClassByPriority(priority) {
    let priorityClass = "";
    let priorityText = "";

    if (priority == "1") {
        priorityText = "highest";
    } else if (priority == "2") {
        priorityText = "high";
    } else if (priority == "3") {
        priorityText = "normal";
    } else if (priority == "4") {
        priorityText = "low";
    } else {
        //priority == "5"
        priorityText = "lowest";
    }

    priorityClass = `alert-priority-${priorityText}`;
    
    return priorityClass;
}

function updatePriorityIcon(DirtyData) {        
    for (let i = 0; i < DirtyData.length; i++) {        
        if (DirtyData[i].PriorityDirty) {
            let priorityClass = "td div[priority-cell = '" + DirtyData[i].AlertID + "']";
            let priorityInput = "td div[priority-cell = '" + DirtyData[i].AlertID + "'] input";
            let taskClass = "td div[task-cell = '" + DirtyData[i].AlertID + "']";
            let taskInput = "td div[task-cell = '" + DirtyData[i].AlertID + "'] input";
            let classText = getClassByPriority(DirtyData[i].Priority);  

            $(priorityClass).removeClass(function (index, className) {
                return (className.match(/(^|\s)alert-priority-\S+/g) || []).join(' ');
            });

            $(taskClass).removeClass(function (index, className) {
                return (className.match(/(^|\s)alert-priority-\S+/g) || []).join(' ');
            });

            $(priorityClass).addClass(classText);
            $(priorityInput).attr("title", getDetailTitleDescriptionByPriority(DirtyData[i].Priority));

            $(taskClass).addClass(classText);
            $(taskInput).attr("title", getTaskTitleDescription(DirtyData[i].TaskStatus, DirtyData[i].Priority));            
        }

        if (DirtyData[i].DueDateDirty) {
            let dataSource = $("#aagrid").data("kendoGrid").dataSource;
            let item = dataSource.getByUid(DirtyData[i].UID);
            let taskFlagClassText = '';
            let taskFlagClass = '';
            let taskFlagInput = '';
            let dueDateClass = '';
            //let dueDateInput = '';
            let dueDateFormatted = '';

            dueDateFormatted = kendo.toString(kendo.parseDate(DirtyData[i].DueDate, 'yyyy-MM-dd'), 'MM/dd/yyyy')

            $.ajax({
                url: 'Inbox/GetDateDiffAndWeekendStatus',
                dataType: 'json',
                data: { "DateValue": dueDateFormatted},
                success: function (result) {    
                    
                    taskFlagClassText = getDueDateClassFlag(result.DateDifference, result.IsWeekendDate, DirtyData[i].DueDate);
                    dueDateClassText = getDueDateClass(result.DateDifference, result.IsWeekendDate, DirtyData[i].DueDate);

                    taskFlagClass = "div[taskflag-cell='" + DirtyData[i].AlertID + "']";
                    taskFlagInput = "div[taskflag-cell='" + DirtyData[i].AlertID + "'] input";

                    $(taskFlagClass).removeClass(function (index, className) {
                        return (className.match(/(^|\s)standard-\S+/g) || []).join(' ');
                    }); 

                    $(taskFlagClass).removeClass("projected"); 

                    $(taskFlagClass).addClass(taskFlagClassText);
                    $(taskFlagInput).attr("title", getDueDateTitle(result.DateDifference, dueDateFormatted, result.IsWeekendDate, DirtyData[i].DueDate));    

                    dueDateClass = "div[taskduedate-cell='" + DirtyData[i].AlertID + "']";

                    $(dueDateClass).closest("td").removeClass(function (index, className) {
                        return (className.match(/(^|\s)standard-\S+/g) || []).join(' ');
                    });

                    $(dueDateClass).closest("td").removeClass("projected")

                    $(dueDateClass).closest("td").addClass(dueDateClassText);
                    $(dueDateClass).attr("title", getDueDateTitle(result.DateDifference, dueDateFormatted, result.IsWeekendDate, DirtyData[i].DueDate));    
                },
                error: function (result) {
                }
            });

            
        }
    }
}

function ExportToExcel() {    
    let grid = $("#aagrid").data("kendoGrid");
    grid.saveAsExcel();    
}

function bookmarkPage() {

    let StartDatePicker = $("#startdate").data("kendoDatePicker");
    let EndDatePicker = $("#duedate").data("kendoDatePicker");
    let StartDate = '';
    let EndDate = '';

    if (StartDatePicker.value() !== null) {
        StartDate = StartDatePicker.value().toDateString();
    }

    if (EndDatePicker.value() !== null) {
        EndDate = EndDatePicker.value().toDateString();
    }

    let bookmark = {
        SearchCriteria: $("#Search").val(),
        InboxType: GetViewValue(),
        ShowAssignmentType: UserViewSettings.ShowAssignmentType,
        StartDate: StartDate,
        EndDate: EndDate,
        EmployeeCode: AlertFilter.EmployeeCode ? AlertFilter.EmployeeCode : "",  //should this come from the multi list?,
        GridSize: UserViewSettings.GridSize,
        GroupBy: AlertFilter.GroupBy,
        ShowOnlyTempCompletedTasks: AlertFilter.ShowOnlyTempCompletedTasks
    };    

    $.ajax({
        type: "POST",
        data: bookmark,
        dataType: "json",
        url: 'Inbox/BookmarkAlertInbox',
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
    AlertFilter.SearchCriteria = "";
    //AlertFilter.ShowAssignmentType = "myalertsandassignments";
    
    UpdateUserViewSettings(_viewType);

    var dataGrid = $("#aagrid").data("kendoGrid");
    dataGrid.dataSource.filter({});
    dataGrid.dataSource.read();
}

function onNewAlertClick() {
    if (gridDirty) {
        promptSave().done(() => ProcessNewAlertClick());
    } else {
        ProcessNewAlertClick()
    }
}

function onNewAssignmentClick() {
    if (gridDirty) {
        promptSave().done(() => ProcessNewAssignmentClick());
    } else {
        ProcessNewAssignmentClick()
    }
}

function ProcessNewAlertClick() {

    let url = "";

    if (isJobJacketView) {

        url = `Alert_New.aspx?f=1&jt=1&content=1&caller=jobtemplate&j=${AlertFilter.JobNumber}&jc=${AlertFilter.JobComponentNumber}`;

    } else {

        url = 'Alert_New.aspx?f=0';

    }
    
    openRadWindowWithEvents('', url, null, 1145, true, function () {
        refreshPage("");
    });

    //OpenRadWindow('New Alert', url, null, 1145, true);    
}

function ProcessNewAssignmentClick() {
    let me = this;

    let url = "";

    if (isJobJacketView) {

        url = `~\Desktop_NewAssignment?f=1&jt=1&content=1&caller=jobtemplate$assn=1&j=${AlertFilter.JobNumber}&jc=${AlertFilter.JobComponentNumber}`;

    } else {

        url = '~\Desktop_NewAssignment';

    }

    openRadWindowWithEvents('', url, null, 1145, true, function () {        
        refreshPage("");
    });    
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
        
    AlertFilter.EmployeeCode = empcode[0];
    AlertFilter.SearchCriteria = $('#Search').val();
    AlertFilter.InboxType = GetViewValue();
    AlertFilter.StartDate = StartDate;
    AlertFilter.EndDate = EndDate;    

    
    UpdateUserViewSettings(_viewType);
    
    var grid = $("#aagrid");
    grid.data("kendoGrid").dataSource.read();

}

function onAssignmentTypeClick(AssignmentType) {
    if (gridDirty) {
        promptSave().done(() => RefreshGridByAssignmentType(AssignmentType));        
    } else {
        if (UserViewSettings.ShowAssignmentType !== "unassigned" && UserViewSettings.ShowAssignmentType !== "allalertassignments") {
            AlertFilter.EmployeeCode = _EmployeeCode;

            $("#empMS").data("kendoMultiSelect").value([AlertFilter.EmployeeCode]);
        } else {
            AlertFilter.EmployeeCode = "";
            AlertFilter.EmployeeRole = "";
            AlertFilter.Department = "";

            $("#empMS").data("kendoMultiSelect").value([]);
            $("#roleMS").data("kendoMultiSelect").value([]);
            $("#departmentMS").data("kendoMultiSelect").value([]);
        }

        RefreshGridByAssignmentType(AssignmentType);
    }

    if (AlertFilter.IsClientPortal == "True") {

        $("#ShowOnlyTempCompletedTasksDiv").hide();

    }

    //ManageDismissAllButton(AssignmentType, GetViewValue());
}

function formatEmployeeCodeArray(employeeCodes) {
    let formattedEmployeeCodes = '"' + employeeCodes.replaceAll(',', '", "') + '"';       

    return formattedEmployeeCodes;
}

function RefreshGridByAssignmentType(AssignmentType) {
    
    let EmployeeFilter = $("#empMS").data("kendoMultiSelect");
    let DatePicker = $("#startdate").data("kendoDatePicker");
    let DateValue = '';
    let EmployeeCode = '';
    let InboxType = GetViewValue();

    //disable "Show Only Tasks Marked Temp Complete" checkbox
    if (AssignmentType === "myalerts" || AssignmentType === "unassigned") {        
        $("#ShowOnlyTempCompletedTasks").prop("checked", false);
        $("#ShowOnlyTempCompletedTasksDiv").hide();
        AlertFilter.ShowOnlyTempCompletedTasks = false;
    } else {        
        $("#ShowOnlyTempCompletedTasksDiv").show();        
    }
    
    if (AssignmentType === "myalerts" ) {
        $("#IncludeBacklogItems").prop("checked", false);
        $("#IncludeBacklogItemsDiv").hide();
        AlertFilter.IncludeBacklog = false;
    } else {
        $("#IncludeBacklogItemsDiv").show();
    }

    //if AssignmentType in (My Alerts, My Assignments, My Assignments & Alerts) then
    //set the Employee Filter to the current employee
    if (AssignmentType.substr(0, 2) == "my") {
        EmployeeFilter.value(_EmployeeCode);                
    }

    //clear the Employee filter if Assignment Type = Unassigned
    if (AssignmentType == "unassigned" || AssignmentType == "allalertassignments") {
        EmployeeFilter.value([]);        
    }

    DateValue = DatePicker.value();
    EmployeeCode = EmployeeFilter.value();

    if (DateValue !== null) {
        DateValue = DatePicker.value().toDateString();
    }

    AlertFilter.StartDate = DateValue;

    DatePicker = $("#duedate").data("kendoDatePicker");

    if (DateValue !== null) {
        DateValue = DatePicker.value().toDateString();
    }

    AlertFilter.EndDate = DateValue;

    AlertFilter.EmployeeCode = EmployeeCode[0];
    AlertFilter.SearchCriteria = $('#Search').val();
    AlertFilter.InboxType = InboxType;
    AlertFilter.ShowAssignmentType = AssignmentType;

    UpdateUserViewSettings(_viewType);
    
    let DataGrid = $("#aagrid").data("kendoGrid");
    DataGrid.setDataSource(DataGrid.dataSource);
    DataGrid.dataSource.read();    
    //DataGrid.data("kendoGrid").dataSource.filter({});

    ManageAssignmentTypeButtons(AssignmentType);        
}

function ManageDismissAllButton(AssignmentType, View, TotalRecords) {
    //console.log(AssignmentType, View, TotalRecords);
    if (View === "inbox") {
        if (TotalRecords > 0 && (AssignmentType === "myalerts" || AssignmentType === "myalertsandassignments")) {
            $("#btnDismissAll").removeClass("k-state-disabled");
        } else {
            $("#btnDismissAll").addClass("k-state-disabled");
        }
    } else {
        $("#btnDismissAll").addClass("k-state-disabled");
    }
}

function ManageAssignmentTypeButtons(AssignmentType) {    
    $("#buttonMyAlertsAndAssignments").removeClass("k-state-active");
    $("#buttonMyAlerts").removeClass("k-state-active");
    $("#buttonMyAssignments").removeClass("k-state-active");
    $("#buttonAllAssignments").removeClass("k-state-active");
    $("#buttonUnassigned").removeClass("k-state-active");

    manageEmployeeFilterStatus();

    switch (AssignmentType) {
        case 'unassigned':
            $("#buttonUnassigned").addClass("k-state-active");
            AreGridRowsReorderable = false;
            break;
        case 'myalertsandassignments':
            $("#buttonMyAlertsAndAssignments").addClass("k-state-active");
            AreGridRowsReorderable = false;
            break;
        case 'myalerts':            
            $("#buttonMyAlerts").addClass("k-state-active");
            AreGridRowsReorderable = true;
            break;
        case 'myalertassignments':
            $("#buttonMyAssignments").addClass("k-state-active");
            AreGridRowsReorderable = true;
            break;
        case 'allalertassignments':
            $("#buttonAllAssignments").addClass("k-state-active");            
            AreGridRowsReorderable = false;
            break;
        default:
            break;
    }
}

function ManageCompleteTempCompleteButton() {
    if (GroupSecuritySettings.AllowTaskEdit === "False") {
        $("#btnCompleteTempComplete").addClass('k-state-disabled');
        $("#btnCompleteTempComplete").prop('disabled', true);
    } else {
        $("#btnCompleteTempComplete").removeClass('k-state-disabled');
        $("#btnCompleteTempComplete").prop('disabled', false);
    }
}

function alertAction(alertID, sprintID, category, canComplete) {

    let url = '';
    let data = {
        AlertID: alertID,
        SprintID: sprintID,
        Category: category
    };    

    if (canComplete === 1) {
        url = "Inbox/ProcessComplete";
    } else if (canComplete === 2) {
        url = "Inbox/DeleteAlert";
    } else if (canComplete === 3) {
        url = "Inbox/ReOpenAlert";
    } else {
        url = "Inbox/DismissComplete";
    }

    if (canComplete === 1 || canComplete === 2) {
        $.ajax({
            type: "POST",
            data: JSON.stringify(data),
            contentType: "application/json",
            url: url,
            success: function (response) {
                if (response.ShowDialog) {
                    onAssignToClick(response.Message, "Confirm Alert Completion");
                } else {
                    if (response.Message) {
                        showKendoAlert(response.Message);
                    }
                }

                let dataGrid = $("#aagrid").data("kendoGrid");
                dataGrid.dataSource.read();
            },
            error: function (response) {
                if (response.Message.length > 0) {
                    showKendoAlert(response.Message);
                }
            }
        });
    } else if (canComplete === 3) {
        $.ajax({
            type: "POST",
            data: { AlertID: alertID },
            url: url,
            success: function (response) {
                if (!response.Success) {
                    showKendoAlert(response.Message);

                    if (response.Message.length > 0) {
                        showKendoAlert(response.Message);
                    }
                }

                let dataGrid = $("#aagrid").data("kendoGrid");
                dataGrid.dataSource.read();

            },
            error: function (response) {
                if (response.Message.length > 0) {
                    showKendoAlert(response.Message);
                }
            }
        });     
    } else {
        $.ajax({
            type: "POST",
            data: { AlertIDs: data.AlertID },
            url: url,
            success: function (response) {                
                if (!response.Success) {
                    showKendoAlert(response.Message);

                    if (response.Message.length > 0) {
                        showKendoAlert(response.Message);
                    }
                }

                let dataGrid = $("#aagrid").data("kendoGrid");                
                dataGrid.dataSource.read();
                
            },
            error: function (response) {
                if (response.Message.length > 0) {
                    showKendoAlert(response.Message);
                }
            }
        });  
    }

    //wvbridge call
    refreshCurrentDashboard();    
    refreshAlertNotifications();
}

