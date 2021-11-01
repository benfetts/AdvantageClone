@*<div id="aagrid" style="border: 1px solid #CCC;" onchange="gridDataChanged(this);" tabindex="1"></div>*@
<div id="aagrid" style="border: 1px solid #CCC;" tabindex="1"></div>
<div id="ResetOptions" class="toolbar-custom-drop">
    <table>
        <thead>
            <tr>
                <th>Column Settings</th>
                @*<th>Other Task Actions</th>*@
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <button id="columnResetWidth" class="k-button wv-icon-button wv-neutral " onclick="columnReset('width');" style="width: 200px !important;" title="Reset column widths to default"><span style="font-size: 12px;">Reset Widths to Default</span></button>

                </td>
            </tr>
            <tr>
                <td>
                    <button id="columnResetOrder" class="k-button wv-icon-button wv-neutral " onclick="columnReset('order');" style="width: 200px !important;" title="Reset column order to default"><span style="font-size: 12px;">Reset Order to Default</span></button>
                </td>
            </tr>
        </tbody>
    </table>
</div>
<div class="k-overlay" id="myOverlay" style="display:none"></div>
<script type="text/x-kendo-template" id="template">
    <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
        <li id="columnSelectorListItem" style="padding:0">
            <a id="col-menu"></a>
        </li>
        <li id="resetOptionsListItem" style="padding:0">
            <button id="ResetOptionsButton" class="k-button wv-icon-button wv-neutral " onclick="showResetOptions()" style="width: 100px !important;" title="Reset column widths and order to default"><span style="font-size: 12px;">Column Reset</span></button>
        </li>
        <li id="clearColumnFiltersListItem" style="padding:0">
            <button id="btnClearColumnFilters" class="k-button wv-icon-button wv-neutral " onclick="ClearFilters();" title="Clear Column Filters"><span class='glyphicon wvi wvi-undo'></span></button>
        </li>
        <li style="padding:0" id="completeTempCompleteListItem">
            <button id="btnCompleteTempComplete" class="k-button wv-icon-button wv-neutral k-state-disabled" disabled onclick="CompleteTempComplete();" title="Mark Temp Complete to Completed"><span class='glyphicon wvi wvi-clipboard_checks'></span></button>
        </li>
        <li style="padding:0" id="dismissAllListItem">
            <button id="btnDismissAll" class="k-button wv-icon-button wv-neutral " style="width: 100px !important;" onclick="DismissAll();"><span style="font-size: 12px;">Dismiss All</span></button>
            @*<Button Class="k-button wv-icon-button wv-neutral " onclick="newAssignment()" style="width: 110px !important;" title="New Assignment"><span style="font-size: 12px;">New Assignment</span></Button>*@
        </li>
        @*<li id="ViewListItem" style="padding:0;">
            <div id="AAViewListItem">
                <span>View:</span>
                <input id="AAView" type="text" style="width: 160px;" />
            </div>
        </li>*@
        <li style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="ExportToExcel()"><span class='wvi wvi-spreadsheet-sum' title="Export" style="font-size: 18px;"></span></button>
        </li>
        <li id="searchInputListItem" style="padding:0">
            <input id="Search" title="Search" class="k-input k-textbox" />
        </li>
        <li id="searchListItem" style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="search()"><span class='wvi wvi-binocular' title="Search"></span></button>
        </li>
        <li id="clearSearchListItem" style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="clearSearch()"><span class='wvi wvi-undo' title="Clear Search"></span></button>
        </li>
    </ul>
    @*<div class='icon-background'>
            <button tabindex='-1' kendo-tooltip k-options='columnSettingsOptions' id='showHideButton' type='button' class='kpager-refresh k-link k-button k-button-icon k-tooltip-options' title='Show/Hide' onclick=''><img src='../../Images/Icons/Grey/256/table_selection_column.png' /></button>
        </div>*@


    @*<button id="btnResetColumnWidths" class="k-button wv-icon-button wv-neutral" style="float:right;" onclick="resetColumnWidths()"><span class="wvi wvi-fit_to_height" title="Reset All Column Widths to Default" style="transform: rotate(90deg);"></span></button>
        <button id="btnResetColumnOrder" class="k-button wv-icon-button wv-neutral" style="float:right;" onclick="resetColumnOrder()"><span class="glyphicon wvi wvi-text" title="Reset All Columns to Default Location" style="transform: rotate(90deg);"></span></button>*@
    @*<button id="ResetOptionsButton" class="k-button wv-icon-button wv-neutral " onclick="showTaskOptions()" style="width: 100px !important;" title="Tasks"><span style="font-size: 12px;">Tasks</span></button>*@



</script>
<style>
    a:hover {
        text-decoration: none !important;
    }

    table a:hover {
        text-decoration: underline !important;
    }

    .k-grid tbody tr {
        cursor: default !important;
    }

    .header-column-icon {
        cursor: default !important;
        margin-bottom: 3px !important;
    }

    .header-icon-color {
        background-color: #C0C0C0;
    }

    .static-sort-desc:before {
        /*content: " \2193";*/        
        content: "\1F80B";
        position: fixed;        
        color: #428bca;
    }

    .static-sort-asc:before {
        /*content: " \2193";*/
        content: "\1F809";
        position: fixed;        
        color: #428bca;        
    }    
    /*a.k-state-active {
        background-color: yellow !important;
    }*/

    .k-header-column-menu.k-state-active {
        background-color: #e5e5e5 !important;
    }

    .disabled {
        color: #FF0000;
    }

    .strikethrough {
        text-decoration: line-through;
        text-decoration-color: black;
    }

    .no-bold {
        font-weight: normal !Important;
    }

    .not-read-bold {
        font-weight: bold;
    }

    .no-strikethrough {
        text-decoration: none;
        display: inline-block;
    }

    .display-none {
        display: none;
    }


    /*th[data-title="Status"],
    th[data-title="Documents"],
    th[data-title="Task Flag"],
    th[data-title="Add Time"],
    th[data-title="Stopwatch"],
    th[data-title="Search"] {
        font-size: 0px !important;
    }*/


    /*th[data-title="Task Status"] > a.k-link
    {
        width: 28px;
        margin-right:0px;        
    }*/

    .projected {
        background: #FFEB3B !Important;
    }

    .k-grid td {
        max-height: 34px !important;
    }

    .standard-red {
        color: #767676 !important;
    }

    .k-pager-wrap .k-dropdown {
        width: 5.0em !important;
    }

    .k-state-focused > a.k-link,
    .k-state-focused > a.k-link > span.k-icon {
        color: white !important;
    }

    #myOverlay {
        display: none;
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

    .k-grid-filter.k-state-active {
        background-color: yellow !important;
    }

    #AAView {
        display: inline-block;
        border: 1px solid black;
    }

    #aagrid {
        min-width: 1000px !important;
    }
    
    #Search{
        height: 32px !important;
    }

    .aam-standard-light-pink 
    {    
        box-shadow: inset 0 0 25px 0 #EEACB9 !important;
    }

    .aam-standard-light-orange {
        box-shadow: inset 0 0 25px 0 #F5C7A1 !important;
    }

    .aam-standard-light-grey {
        box-shadow: inset 0 0 25px 0 #AEAEAE !important;
    }

    .aam-standard-light-green {
        box-shadow: inset 0 0 25px 0 #99C3B8 !important;
    }

    .aam-projected {
        box-shadow: inset 0 0 25px 0 #FFEB3B !important;
    }

    #aagrid_active_cell > span > span > span.k-input{
        color:white;
    }
</style>

<script>    
    var hasAccessToTimesheet = false;

    $(document).ready(function () {
        console.clear();
        uid = "";
        index = 0;        

        BuildAAViewDropDown();
        LoadUserColumnSettings();        
    });

    let todayDate = kendo.toString(kendo.parseDate(new Date()), 'MM/dd/yyyy');
    let AAManagerDataSource;
    let AreGridRowsReorderable = false;
    let pageFlag = false;    
    let _staticColumns = ["", "Search", "Status", "Category Icon", "Task Status", "Documents", "Task Flag", "Add Time", "Stopwatch"];

    let reorderedColumn = {
        name: "",
        oldIndex: -1,
        newIndex: -1
    };

    $("#aagrid").change(function (e) {        
        if (e.target.id !== "Search") {            
            if (!pageFlag) {                
                gridDirty = true;
                enableSave();
            }
        }
    });

    hasAccessToTimesheet = @ViewBag.HasAccessToTimesheet.ToString().ToLower();

    function showResetOptions() {
        showPopupForElement($('#ResetOptions'), $('#ResetOptionsButton'));
    }
    function showPopupForElement(popUp, anchor) {
        closeAllPopups();
        var popUpData = popUp.data('kendoPopup');
        popUpData.options.anchor = anchor;
        popUpData.open();
        $('#myOverlay').show();
    }
    function closeAllPopups() {
        $('.toolbar-custom-drop').each(function () {
            $(this).data('kendoPopup').close();
        });
        $('#myOverlay').hide();
    }
    $('#ResetOptions').kendoPopup({
            anchor: $('#ResetOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            open: (e) => {
                @*var data = {
                    JobNumber: @Model.JobNumber,
                    JobComponentNumber: @Model.JobComponentNumber
                };

                $.ajax({
                    type: "GET",
                    url: "@Href("~/ProjectManagement/ProjectSchedule/GetAutoStatus")",
                    data: data,
                    dataType: "json",
                    success: function (response) {
                        console.log(response);
                        if (response === true) {
                            $("#AutoStatus").prop("checked", true);
                        }
                        else {
                            $("#AutoStatus").prop("checked", false);
                        }
                    }
                });*@
            },
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

    function showTaskOptions() {
        showKendoAlert("showTaskOptions");
    }

    function SaveUserColumnOrder() {
        let grid = $('#aagrid').data('kendoGrid');

        let reorderDetails = {
            GridName: GetGridView(),
            GridColumns: new Array()
        };

        let existingColumnName = "";

        let reorderDetail = {
            ColumnName: "",
            ColumnID: -1,
            ColumnWidth: 0
        };

        //console.log(i, grid.columns[i].title);
        existingColumnName = grid.columns[reorderedColumn.oldIndex].field === undefined ? grid.columns[reorderedColumn.oldIndex].title : grid.columns[reorderedColumn.oldIndex].field;

        //handle the column name for special columns (LastUpdatedNoTime and GeneratedNoTime)
        if (existingColumnName.includes("NoTime")) {
            reorderDetail.ColumnName = existingColumnName.replace("NoTime", "");
        } else {
            reorderDetail.ColumnName = existingColumnName;
        }

        //set new column index id
        reorderDetail.ColumnID = reorderedColumn.newIndex;

        reorderDetails.GridColumns.push(reorderDetail);

        $.post({
            url: "@Href("~/Desktop/Inbox/ProcessGridColumnReorder")",
            data: JSON.stringify(reorderDetails),//JSON.stringify(DirtyData),
            contentType: 'application/json',
            success: function (response) {
                //showKendoAlert("Data successfully updated.");
                //refresh data grid
                //gridDirty = false;
                //enableSave();
                //$(".k-dirty").removeClass("k-dirty");
                //updatePriorityIcon(newDirty);
            },
            error: function (response) {
                //console.log("An error occurred during update: " + response.message);
                //showKendoAlert(Message);
            }
        });
    }

    function SaveUserColumnWidth(columnName, newColumnWidth) {
        let grid = $('#aagrid').data('kendoGrid');


        let widthDetails = {
            GridName: GetGridView(),
            GridColumns: new Array()
        };

        let existingColumnName = "";

        let columnDetail = {
            ColumnName: "",
            ColumnID: -1,
            ColumnWidth: 0
        };

        //console.log(i, grid.columns[i].title);

        //handle the column name for special columns (LastUpdatedNoTime and GeneratedNoTime)
        if (columnName.includes("NoTime")) {
            columnDetail.ColumnName = columnName.replace("NoTime", "");
            } else {
            columnDetail.ColumnName = columnName;
            }

            //set new column index id
        columnDetail.ColumnWidth = newColumnWidth;

        widthDetails.GridColumns.push(columnDetail);

        $.post({
            url: "@Href("~/Desktop/Inbox/ProcessGridColumnWidthChange")",
            data: JSON.stringify(widthDetails),//JSON.stringify(DirtyData),
            contentType: 'application/json',
            success: function (response) {
            },
            error: function (response) {
            }
        });
    }

    let AlertFilter = {
        EmployeeCode: '@ViewBag.DefaultEmpCode',
        SearchCriteria: '',
        InboxType: 'inbox', //AlertInbox
        ShowAssignmentType: 'myalertsandassignments',
        IsJobAlertsPage: false,
        JobNumber: 0,
        JobComponentNumber: 0,
        StartDate: '',
        EndDate: todayDate,
        IncludeCompletedAssignments: false,
        GroupBy: '',
        RecordsToReturn: 0,
        IsCount: false,
        IncludeReviews: false,
        IncludeBoardLevel: false,
        IncludeBacklog: false,
        ShowOnlyTempCompletedTasks: false,
        EmployeeRole: '',
        Department: '',
        InitialLoadFlag: true,
        IsClientPortal: '@ViewBag.IsClientPortal'
    }

    let ColumnSettings = {
        Search: true,
        Status: true,
        CategoryIcon: true,
        Task: true,
        Documents: true,
        TaskFlag: true,
        AddTime: true,
        Stopwatch: true,
        Subject: true,
        Generated: true,
        LastUpdated: true,
        StartDate: true,
        DueDate: true,
        TimeDue: true,
        AlertStateName: true,
        Priority: true,
        Category: true,
        AssignedTo: true,
        ClientName: true,
        Division: true,
        Product: true,
        CDP: true,
        Job: true,
        JobNumber: true,
        JobComponent: true,
        ComponentNumber: true,
        JobComponentDetailed: true,
        JobAndComponentNumber: true,
        JobDescription: true,
        ComponentDescription: true,
        ID: true,
        SoftwareVersion: true,
        SoftwareBuild: true,
        Type: true,
        Level: true,
        AE: true,
        PM: true,
        Office: true,
        Campaign: true,
        Template: true,
        TaskComments: true,
        HoursAllowed: true,
        UserName: true,
        TempCompleteDate: true,
        CCEmployeeCodes: true,
        CCEmployeeNames: true,
        Board: true,
        BoardState: true,
        SprintDescription: true,
        SprintStartDate: true,
        TaskStatusDescription: true
    }

    function filterDateEditor(element) {        
        element.kendoDatePicker({
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy'
        });
    }

    function numericFilter(element) {
        element.kendoNumericTextBox({
            format: "#",
            decimals: 0
        });
    }

    let filterCheckboxTemplate = function (e) {        
        return "<li class='k-item'><label class='k-label'><input type='checkbox' name='" + e.field + "' value='#= data." + e.field + " #'/><span>#= data.all || (data." + e.field + "?data." + e.field + ": '(Blanks)') # </span></label></li>"
    };

    function filterPlain(e) {        
        let firstDatePicker = $('input[data-bind="value:filters[0].value"]');
        let secondDatePicker = $('input[data-bind="value: filters[1].value"]');

        firstDatePicker.kendoDatePicker({
            format: "MM/dd/yyyy",
            parseFormats: ["Mddyy", "MMddyy", "Mddyyyy", "MMddyyyy", "MM/dd/yyyy", "MM/d/yy", "M/dd/yy", "M/d/yy"]
        });

        secondDatePicker.kendoDatePicker({
            format: "MM/dd/yyyy",
            parseFormats: ["Mddyy", "MMddyy", "Mddyyyy", "MMddyyyy", "MM/dd/yyyy", "MM/d/yy", "M/dd/yy", "M/d/yy"]
        });
    }

    function hintElement(element) { // Customize the hint.

        var grid = $("#aagrid").data("kendoGrid"),
            table = grid.table.clone(), // Clone the Grid table.
            wrapperWidth = 1500,//grid.wrapper.width(), // Get the Grid width.
            wrapper = $("<div class='k-grid k-widget'></div>").width(wrapperWidth),            //style='height:64px !important;overflow:hidden;
            hint;

        //k-i-arrow-up
        table.find("thead").remove(); // Remove the Grid header from the hint.
        table.find("tbody").empty(); // Remove the existing rows from the hint.
        table.wrap(wrapper); // Wrap the table
        table.append(element.clone().find('td:gt(8):lt(7)').removeAttr("uid")); // Append the dragged element.

        //console.log(element);
        hint = table.parent(); // Get the wrapper.

        return hint; // Return the hint element.
    }    

    function createGridDataSource() {          
        let gridSize = UserViewSettings.GridSize;
        let pageSizes = ["10", "15", "20", "50", "100", "200"];

        if (!gridSize || !pageSizes.includes(gridSize)) {        
            //if the gridsize isn't in the pagesize array, an irrelevant value has been posted to the 
            //pager size dropdown by the datasource.
            //setting the GridSize to 10 will remove the app var setting, as 10 is the grid default.
            UserViewSettings.GridSize = "10";
        }

        AAManagerDataSource = new kendo.data.DataSource({                  
            transport: {
                    read: (e) => {
                        let data = AlertFilter;                        
                
                        $.ajax({
                            type: "GET",
                            url: "@Href("~/Desktop/Inbox/GetAAManagerData")",
                            dataType: 'json',
                            data: data,
                            success: (results) => {
                                let newDueDate, newStartDate, newTempCompDate, newSprintStartDate;                                
                                $.each(results, (i, e) => {
                                    //drop the time from the DueDate, StartDate, TempCompleteDate and
                                    //SprintStartDate fields to accommodate server / client
                                    //timezone discrepancies when filtering the column
                                    newDueDate = kendo.parseDate(e.DueDate, "MM/dd/yyyy");
                                    newStartDate = kendo.parseDate(e.StartDate, "MM/dd/yyyy");
                                    newTempCompDate = kendo.parseDate(e.TempCompleteDate, "MM/dd/yyyy");
                                    newSprintStartDate = kendo.parseDate(e.SprintStartDate, "MM/dd/yyyy");                                    

                                    if (newDueDate) {                                        
                                        newDueDate.setHours(0, 0, 0, 0);                                                      
                                        e.DueDate = newDueDate;
                                    }

                                    if (newStartDate) {
                                        newStartDate.setHours(0, 0, 0, 0);
                                        e.StartDate = newStartDate;
                                    }

                                    if (newTempCompDate) {
                                        newTempCompDate.setHours(0, 0, 0, 0);
                                        e.TempCompleteDate = newTempCompDate;
                                    }

                                    if (newSprintStartDate) {
                                        newSprintStartDate.setHours(0, 0, 0, 0);
                                        e.SprintStartDate = newSprintStartDate;
                                    }
                                });                    
                                e.success(results);
                            },
                            error: (results) => {
                                e.error(results);
                            }
                        });

                        AlertFilter.InitialLoadFlag = false;                
                    }
                },
                pageSize: UserViewSettings.GridSize,                
                group: GetGrouping(),
                schema: {
                    model: {
                        fields: {
                            Subject: { from: "Subject", type: "string", editable: false, nullable: false },
                            Generated: { from: "Generated", type: "date", editable: false },
                            GeneratedNoTime: { from: "GeneratedNoTime", type: "date", editable: false },
                            LastUpdated: { from: "LastUpdated", type: "date", editable: false },
                            LastUpdatedNoTime: { from: "LastUpdatedNoTime", type: "date", editable: false },
                            StartDate: { from: 'StartDate', type: 'date', nullable: true },
                            DueDate: { from: 'DueDate', type: 'date', nullable: true },
                            TimeDue: { from: 'TimeDue', type: 'string', editable: false, nullable: true },
                            AlertStateName: { from: 'AlertStateName', type: 'string', editable: false, nullable: true },
                            Priority: { from: 'Priority', type: 'string' }, //10
                            AssignedTo: { from: 'AssignedTo', type: 'string', editable: false, nullable: true },
                            AssignedToEmpCode: { from: 'AssignedToEmpCode', type: 'string', editable: false, nullable: true },
                            Category: { from: "Category", type: "string", editable: false, nullable: true },
                            ClientName: { from: "ClientName", type: "string", editable: false, nullable: true },
                            ClientCode: { from: 'ClientCode', type: 'string', editable: false, nullable: true },
                            Division: { from: "GroupDivision", type: "string", editable: false, nullable: true },
                            DivisionCode: { from: 'DivisionCode', type: 'string', editable: false, nullable: true },
                            Product: { from: 'GroupProduct', type: 'string', editable: false, nullable: true },
                            ProductCode: { from: 'ProductCode', type: 'string', editable: false, nullable: true },
                            Job: { from: 'Job', type: 'string', editable: false, nullable: true }, //20
                            JobNumber: { from: 'JobNumber', type: 'number', editable: false, nullable: true },
                            JobComponent: { from: 'JobComponent', type: 'string', editable: false, nullable: true },
                            ComponentNumber: { from: 'ComponentNumber', type: 'number', editable: false, nullable: true },
                            JobComponentDetailed: { from: 'JobComponentDetailed', type: 'string', editable: false, nullable: true },
                            JobAndComponentNumber: { from: 'JobAndComponentNumber', type: 'string', editable: false, nullable: true },
                            JobDescription: { from: 'JobDescription', type: 'string', editable: false, nullable: true },
                            ComponentDescription: { from: 'ComponentDescription', type: 'string', editable: false, nullable: true },
                            ID: { from: "ID", type: "number", editable: false },
                            SoftwareVersion: { from: 'SoftwareVersion', type: 'string', editable: false, nullable: true },
                            SoftwareBuild: { from: 'SoftwareBuild', type: 'string', editable: false, nullable: true }, //30
                            Type: { from: 'AlertTypeText', type: 'string', editable: false, nullable: true },
                            AE: { from: 'AccountExecutive', type: 'string', editable: false, nullable: true },
                            PM: { from: 'ProjectManager', type: 'string', editable: false, nullable: true },
                            Office: { from: 'GroupOffice', type: 'string', editable: false, nullable: true },
                            Campaign: { from: 'GroupCampaign', type: 'string', editable: false, nullable: true },
                            Template: { from: 'GroupAlertTemplateName', type: 'string', editable: false, nullable: true },
                            IsRead: { from: 'IsRead', type: 'bit', nullable: true },
                            AlertCategoryID: { from: 'AlertCategoryID', type: 'number', nullable: true },
                            SprintID: { from: 'SprintID', type: 'number', nullable: true },
                            AlertID: { from: 'AlertID', type: 'number', nullable: true },//40
                            IsTaskAssignment: { from: 'IsTaskAssignment', type: 'bit', nullable: true },
                            AttachmentCount: { from: 'AttachmentCount', type: 'number', nullable: true },
                            IsRoutedAssignment: { from: 'IsRoutedAssignment', type: 'bit', nullable: true },
                            IsRouted: { from: 'IsRouted', type: 'bit', nullable: true },
                            IsWorkItem: { from: 'IsWorkItem', type: 'bit', nullable: true },
                            IsCurrentAssignee: { from: 'IsCurrentAssignee', type: 'bit', nullable: true },
                            IsDismissed: { from: 'IsDismissed', type: 'bit', nullable: true },
                            IsNonRoutedAssignment: { from: 'IsNonRoutedAssignment', type: 'bit', nullable: true },
                            IsCC: { from: 'IsCC', type: 'bit', nullable: true },
                            IsMyAssignment: { from: 'IsMyAssignment', type: 'bit', nullable: true },//50
                            IsMyAlert: { from: 'IsMyAlert', type: 'bit', nullable: true },
                            IsMyTask: { from: 'IsMyTask', type: 'bit', nullable: true },
                            TaskStatus: { from: 'TaskStatus', type: 'string', editable: false, nullable: true },
                            TaskComments: { from: 'TaskComments', type: 'string', editable: false, nullable: true },
                            HoursAllowed: { from: 'HoursAllowed', type: 'string', editable: false, nullable: true },
                            TaskDateDiff: { from: 'TaskDateDiff', type: 'number', editable: false, nullable: true },
                            TaskDateIsWeekend: { from: 'TaskDateIsWeekend', type: 'bit', nullable: true, editable: false },
                            //EmployeeRoleCode: { from: 'EmployeeRoleCode', type: 'string', editable: false, nullable: true },
                            //EmployeeRoleDescription: { from: 'EmployeeRoleDescription', type: 'string', editable: false, nullable: true },
                            GroupPriority: { from: 'GroupPriority', type: 'string', editable: false },//60
                            CDP: { from: 'CDPCodes', type: 'string', editable: false, nullable: true },
                            TaskSequenceNumber: { from: 'TaskSequenceNumber', type: 'number', editable: false, nullable: true },
                            AssignToLinkAddress: { from: 'AssignToLinkAddress', type: 'string', editable: false, nullable: true },
                            AssignedToTitle: { from: 'AssignedToTitle', type: 'string', editable: false, nullable: true },
                            IsMyTaskTempComplete: { from: 'IsMyTaskTempComplete', type: 'bit', nullable: true, editable: false },
                            IsOwnerAssignmentAlert: { from: 'IsOwnerAssignmentAlert', type: 'bit', nullable: true, editable: false },
                            UserName: { from: 'UserName', type: 'string', nullable: true, editable: false }, 
                            TempCompleteDate: { from: 'TempCompleteDate', type: 'date', editable: false }, 
                            TempCompleteDateNoTime: { from: 'TempCompleteDateNoTime', type: 'date', editable: false }, 
                            CCEmployeeCodes: { from: 'CCEmployeeCodes', type: 'string', nullable: true, editable: false }, 
                            CCEmployeeNames: { from: 'CCEmployeeNames', type: 'string', nullable: true, editable: false },
                            IsMyAssignmentCompleted: { from: 'IsMyAssignmentCompleted', type: 'bit', nullable: true, editable: false }, //73
                            Board: { from: 'Board', type: 'string', nullable: true, editable: false },//74
                            BoardState: { from: 'BoardState', type: 'string', nullable: true, editable: false },//75
                            SprintDescription: { from: 'Sprint', type: 'string', nullable: true, editable: false },
                            SprintStartDate: { from: 'SprintStartDate', type: 'date', nullable: true, editable: false },//77
                            IsBacklogItem: { from: 'IsBacklogItem', type: 'bit', nullable: true, editable: false }, //78
                            BoardExcludeTasks: { from: 'BoardExcludeTasks', type: 'bit', nullable: true, editable: false }, //79
                            TaskStatusDescription: { from: 'TaskStatusDescription', type: 'string', nullable: true, editable: false } //79

                        }
                    }
                }
        });
        
        return AAManagerDataSource;
    }

    function onFilterChange(e) {
        //if (e.filter === null) {
        //    $("a.k-state-active").removeClass("k-state-selected");
        //} else {
        //    $("a.k-state-active").addClass("k-state-selected");
        //}
    }

    function LoadColumnVisibilitySettings() {
        $.ajax({
            type: "Get",
            url: "Inbox/GetGridColumnVisibilitySettings?GridView=" + GetGridView(),
            dataType: "json",
            success: function (response) {
                let Search = true;
                let Status = true;
                let CategoryIcon = true;
                let Task = true;
                let Documents = true;
                let TaskFlag = true;
                let AddTime = true;
                let Stopwatch = true;
                let Subject = true;
                let Generated = true;
                let LastUpdated = true;
                let StartDate = true;
                let DueDate = true;
                let TimeDue = true;
                let AlertStateName = true;
                let Priority = true;
                let Category = true;
                let AssignedTo = true;
                let ClientName = true;
                let Division = true;
                let Product = true;
                let CDP = true;
                let Job = true;
                let JobNumber = true;
                let JobComponent = true;
                let ComponentNumber = true;
                let JobComponentDetailed = true;
                let JobAndComponentNumber = true;
                let JobDescription = true;
                let ComponentDescription = true;
                let ID = true;
                let SoftwareVersion = true;
                let SoftwareBuild = true;
                let Type = true;
                let Level = true;
                let AE = true;
                let PM = true;
                let Office = true;
                let Campaign = true;
                let Template = true;
                let TaskComments = true;
                let HoursAllowed = true;
                let By = true;
                let TempCompleteDate = true;
                let CCEmployeeCodes = true;
                let CCEmployeeNames = true;
                let Board = true;
                let BoardState = true;
                let SprintDescription = true;
                let SprintStartDate = true;
                let TaskStatusDescription = true;

                $.each(response, function (index, value) {
                    if (value == 'Search') { Search = false; }
                    if (value == 'Status') { Status = false; }
                    if (value == 'CategoryIcon') { CategoryIcon = false; }
                    if (value == 'Task') { Task = false; }
                    if (value == 'Documents') { Documents = false; }
                    if (value == 'TaskFlag') { TaskFlag = false; }
                    if (value == 'AddTime') { AddTime = false; }
                    if (value == 'Stopwatch') { Stopwatch = false; }
                    if (value == 'Subject') { Subject = false; }
                    if (value == 'Generated') { Generated = false; }
                    if (value == 'LastUpdated') { LastUpdated = false; }
                    if (value == 'StartDate') { StartDate = false; }
                    if (value == 'DueDate') { DueDate = false; }
                    if (value == 'TimeDue') { TimeDue = false; }
                    if (value == 'AlertStateName') { AlertStateName = false; }
                    if (value == 'Priority') { Priority = false; }
                    if (value == 'Category') { Category = false; }
                    if (value == 'AssignedTo') { AssignedTo = false; }
                    if (value == 'ClientName') { ClientName = false; }
                    if (value == 'Division') { Division = false; }
                    if (value == 'Product') { Product = false; }
                    if (value == 'CDP') { CDP = false; }
                    if (value == 'Job') { Job = false; }
                    if (value == 'JobNumber') { JobNumber = false; }
                    if (value == 'JobComponent') { JobComponent = false; }
                    if (value == 'ComponentNumber') { ComponentNumber = false; }
                    if (value == 'JobComponentDetailed') { JobComponentDetailed = false; }
                    if (value == 'JobAndComponentNumber') { JobAndComponentNumber = false; }
                    if (value == 'JobDescription') { JobDescription = false; }
                    if (value == 'ComponentDescription') { ComponentDescription = false; }
                    if (value == 'ID') { ID = false; }
                    if (value == 'SoftwareVersion') { SoftwareVersion = false; }
                    if (value == 'SoftwareBuild') { SoftwareBuild = false; }
                    if (value == 'Type') { Type = false; }
                    if (value == 'Level') { Level = false; }
                    if (value == 'AE') { AE = false; }
                    if (value == 'PM') { PM = false; }
                    if (value == 'Office') { Office = false; }
                    if (value == 'Campaign') { Campaign = false; }
                    if (value == 'Template') { Template = false; }
                    if (value == 'TaskComments') { TaskComments = false; }
                    if (value == 'HoursAllowed') { HoursAllowed = false; }
                    if (value == 'By') { By = false; }
                    if (value == 'TempCompleteDate') { TempCompleteDate = false; }
                    if (value == 'CCEmployeeCodes') { CCEmployeeCodes = false; }
                    if (value == 'CCEmployeeNames') { CCEmployeeNames = false; }
                    if (value == 'Board') { Board = false; }
                    if (value == 'BoardState') { BoardState = false; }
                    if (value == 'SprintDescription') { SprintDescription = false; }
                    if (value == 'SprintStartDate') { SprintStartDate = false; }
                    if (value == 'TaskStatusDescription') { TaskStatusDescription = false; }
                });

                ColumnSettings.Search = Search;
                ColumnSettings.Status = Status;
                ColumnSettings.CategoryIcon = CategoryIcon;
                ColumnSettings.Task = Task;
                ColumnSettings.Documents = Documents;
                ColumnSettings.TaskFlag = TaskFlag;
                ColumnSettings.AddTime = AddTime;
                ColumnSettings.Stopwatch = Stopwatch;
                ColumnSettings.Subject = Subject;
                ColumnSettings.Generated = Generated;
                ColumnSettings.LastUpdated = LastUpdated;
                ColumnSettings.StartDate = StartDate;
                ColumnSettings.DueDate = DueDate;
                ColumnSettings.TimeDue = TimeDue;
                ColumnSettings.AlertStateName = AlertStateName;
                ColumnSettings.Priority = Priority;
                ColumnSettings.Category = Category;
                ColumnSettings.AssignedTo = AssignedTo;
                ColumnSettings.ClientName = ClientName;
                ColumnSettings.Division = Division;
                ColumnSettings.Product = Product;
                ColumnSettings.CDP = CDP;

                ColumnSettings.Job = Job;
                ColumnSettings.JobNumber = JobNumber;
                ColumnSettings.JobComponent = JobComponent;
                ColumnSettings.ComponentNumber = ComponentNumber;
                ColumnSettings.JobComponentDetailed = JobComponentDetailed;
                ColumnSettings.JobAndComponentNumber = JobAndComponentNumber;
                ColumnSettings.JobDescription = JobDescription;
                ColumnSettings.ComponentDescription = ComponentDescription;

                ColumnSettings.ID = ID;
                ColumnSettings.SoftwareVersion = SoftwareVersion;
                ColumnSettings.SoftwareBuild = SoftwareBuild;
                ColumnSettings.Type = Type;
                ColumnSettings.Level = Level;
                ColumnSettings.AE = AE;
                ColumnSettings.PM = PM;
                ColumnSettings.Office = Office;
                ColumnSettings.Campaign = Campaign;
                ColumnSettings.Template = Template;
                ColumnSettings.TaskComments = TaskComments;
                ColumnSettings.HoursAllowed = HoursAllowed;
                ColumnSettings.By = By;
                ColumnSettings.TempCompleteDate = TempCompleteDate;
                ColumnSettings.CCEmployeeCodes = CCEmployeeCodes;
                ColumnSettings.CCEmployeeNames = CCEmployeeNames;
                ColumnSettings.Board = Board;
                ColumnSettings.BoardState = BoardState;
                ColumnSettings.SprintDescription = SprintDescription;
                ColumnSettings.SprintStartDate = SprintStartDate;
                ColumnSettings.TaskStatusDescription = TaskStatusDescription;

                //Override
                if (hasAccessToTimesheet == false) {
                    ColumnSettings.AddTime = false;
                    ColumnSettings.Stopwatch = false;
                }

                let grid = $('#aagrid').data('kendoGrid');

                for (let i = 0; i < grid.columns.length; i++) {
                    if (ColumnSettings.Search == false && grid.columns[i].attributes.hiddenTitleValue == 'Search') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Status == false && grid.columns[i].attributes.hiddenTitleValue == 'Status') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.CategoryIcon == false && grid.columns[i].attributes.hiddenTitleValue == 'Category Icon') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Task == false && grid.columns[i].attributes.hiddenTitleValue == 'Task Status') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Documents == false && grid.columns[i].attributes.hiddenTitleValue == 'Documents') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TaskFlag == false && grid.columns[i].attributes.hiddenTitleValue == 'Task Flag') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.AddTime == false && grid.columns[i].attributes.hiddenTitleValue == 'Add Time') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Stopwatch == false && grid.columns[i].attributes.hiddenTitleValue == 'Stopwatch') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Subject == false && grid.columns[i].title == 'Subject') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Generated == false && grid.columns[i].title == 'Generated') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.LastUpdated == false && grid.columns[i].title == 'Last Updated') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.StartDate == false && grid.columns[i].title == 'Start Date') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.DueDate == false && grid.columns[i].title == 'Due Date') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TimeDue == false && grid.columns[i].title == 'Time Due') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.AlertStateName == false && grid.columns[i].title == 'State') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Priority == false && grid.columns[i].title == 'Priority') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Category == false && grid.columns[i].title == 'Category') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.AssignedTo == false && grid.columns[i].title == 'Assigned To') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.ClientName == false && grid.columns[i].title == 'Client') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Division == false && grid.columns[i].title == 'Division') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Product == false && grid.columns[i].title == 'Product') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.CDP == false && grid.columns[i].title == 'CDP') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Job == false && grid.columns[i].title == 'Job') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.JobNumber == false && grid.columns[i].title == 'Job Number') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.JobComponent == false && grid.columns[i].title == 'Component') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.ComponentNumber == false && grid.columns[i].title == 'Component Number') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.JobComponentDetailed == false && grid.columns[i].title == 'Job Component') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.JobAndComponentNumber == false && grid.columns[i].title == 'Job Component Number') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.JobDescription == false && grid.columns[i].title == 'Job Description') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.ComponentDescription == false && grid.columns[i].title == 'Component Description') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.ID == false && grid.columns[i].title == 'ID') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.SoftwareVersion == false && grid.columns[i].title == 'Version') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.SoftwareBuild == false && grid.columns[i].title == 'Build') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Type == false && grid.columns[i].title == 'Type') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Level == false && grid.columns[i].title == 'Level') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.AE == false && grid.columns[i].title == 'AE') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.PM == false && grid.columns[i].title == 'PM') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Office == false && grid.columns[i].title == 'Office') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Campaign == false && grid.columns[i].title == 'Campaign') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Template == false && grid.columns[i].title == 'Template') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TaskComments == false && grid.columns[i].title == 'Task Comments') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.HoursAllowed == false && grid.columns[i].title == 'Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.By == false && grid.columns[i].title == 'By') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TempCompleteDate == false && grid.columns[i].title == 'TempCompleteDate') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.CCEmployeeCodes == false && grid.columns[i].title == 'CCEmployeeCodes') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.CCEmployeeNames == false && grid.columns[i].title == 'CCEmployeeNames') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Board == false && grid.columns[i].title == 'Board') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.BoardState == false && grid.columns[i].title == 'BoardState') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.SprintDescription == false && grid.columns[i].title == 'SprintDescription') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.SprintStartDate == false && grid.columns[i].title == 'SprintStartDate') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TaskStatusDescription == false && grid.columns[i].title == 'TaskStatusDescription') {
                        grid.hideColumn(i);
                    }
                }
            },
            error: function (err) {
                showKendoAlert(err);
            }
        });

        jobInfoChange = false;
    }
</script>

<script id="columnFeature" type="text/x-kendo-template">
    <style>
        .k-widget.k-tooltip {
            background-color: rgb(229,229,229);
            border: solid;
            border-width: 1px;
            color: rgb(118,118,118);
        }
    </style>
    <div class="template-wrapper">

        @*<ul class="fieldlist">
                <li>
                    <input type="checkbox" id="columnQuantity" class="k-checkbox">
                    <label class="k-checkbox-label" for="columnQuantity">Quantity</label>
                </li>
                <li>
                    <input type="checkbox" id="columnClient" class="k-checkbox">
                    <label class="k-checkbox-label" for="columnClient">Client</label>
                </li>
                <li>
                    <input type="checkbox" id="columnDivision" class="k-checkbox">
                    <label class="k-checkbox-label" for="columnDivision">Division</label>
                </li>
                <li>
                    <input type="checkbox" id="columnProduct" class="k-checkbox">
                    <label class="k-checkbox-label" for="columnProduct">Product</label>
                </li>
                <li>
                    <input type="checkbox" id="columnJob" class="k-checkbox">
                    <label class="k-checkbox-label" for="columnJob">Job</label>
                </li>
                <li>
                    <input type="checkbox" id="columnJobComponent" class="k-checkbox">
                    <label class="k-checkbox-label" for="columnJobComponent">Job Component</label>
                </li>
            </ul>*@

        <div style="text-align: left; margin-top:20px; margin-left:1em;">
            <button id="saveColumnSettings" class="k-button k-primary" onclick="saveColumnSettings_Click()">Save</button>&nbsp;&nbsp;
            <button id="cancelColumnSettings" class="k-button" onclick="closeColumSettings_Click();">Close</button>
        </div>
    </div>
</script>
