@*<div id="aagrid" style="border: 1px solid #CCC;" onchange="gridDataChanged(this);" tabindex="1"></div>*@
<div id="utilizationgrid" style="border: 1px solid #CCC;" tabindex="1"></div>
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
        @*<li style="padding:0" id="completeTempCompleteListItem">
            <button id="btnCompleteTempComplete" class="k-button wv-icon-button wv-neutral k-state-disabled" disabled onclick="CompleteTempComplete();" title="Mark Temp Complete to Completed"><span class='glyphicon wvi wvi-clipboard_checks'></span></button>
        </li>
        <li style="padding:0" id="dismissAllListItem">
            <button id="btnDismissAll" class="k-button wv-icon-button wv-neutral " style="width: 100px !important;" onclick="DismissAll();"><span style="font-size: 12px;">Dismiss All</span></button>
        </li>*@
        <li style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="ExportToExcel()"><span class='wvi wvi-spreadsheet-sum' title="Export" style="font-size: 18px;"></span></button>
        </li>
        @*<li id="searchInputListItem" style="padding:0">
            <input id="Search" title="Search" class="k-input k-textbox" />
        </li>
        <li id="searchListItem" style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="search()"><span class='wvi wvi-binocular' title="Search"></span></button>
        </li>
        <li id="clearSearchListItem" style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="clearSearch()"><span class='wvi wvi-undo' title="Clear Search"></span></button>
        </li>*@
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


    th[data-title="Status"],
    th[data-title="Documents"],
    th[data-title="Task Flag"],
    th[data-title="Add Time"],
    th[data-title="Stopwatch"],
    th[data-title="Search"] {
        font-size: 0px !important;
    }

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

    #utilizationgrid {
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

    #utilizationgrid_active_cell > span > span > span.k-input {
        color: white;
    }
</style>

<script>    
    var hasAccessToTimesheet = false;

    $(document).ready(function () {        
        uid = "";
        index = 0;      

        LoadUserColumnSettings();        
    });

    let todayDate = kendo.toString(kendo.parseDate(new Date()), 'MM/dd/yyyy');
    let UtilizationDataSource;
    let AreGridRowsReorderable = false;
    let pageFlag = false;    
    let _staticColumns = ["", "Search", "Status", "Category Icon", "Task Status", "Documents", "Task Flag", "Add Time", "Stopwatch"];

    let reorderedColumn = {
        name: "",
        oldIndex: -1,
        newIndex: -1
    };

    $("#utilizationgrid").change(function (e) {        
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
            url: "@Href("~/ProjectManagement/ProjectSchedule / GetAutoStatus")",
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
        let grid = $('#utilizationgrid').data('kendoGrid');

        let reorderDetails = {
            GridName: GetGridView(),
            EmployeeUtilizationColumns: new Array()
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

        reorderDetails.EmployeeUtilizationColumns.push(reorderDetail);

        $.post({
            url: "@Href("~/Dashboard/EmployeeUtilization/ProcessGridColumnReorder")",
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
        let grid = $('#utilizationgrid').data('kendoGrid');


        let widthDetails = {
            GridName: GetGridView(),
            EmployeeUtilizationColumns: new Array()
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

        widthDetails.EmployeeUtilizationColumns.push(columnDetail);

        $.post({
            url: "@Href("~/Dashboard/EmployeeUtilization/ProcessGridColumnWidthChange")",
            data: JSON.stringify(widthDetails),//JSON.stringify(DirtyData),
            contentType: 'application/json',
            success: function (response) {
            },
            error: function (response) {
            }
        });
        }

    let EUFilter = {
        EmployeeCode: '@ViewBag.DefaultEmpCode',
        SearchCriteria: '',        
        Department: '',
        InitialLoadFlag: true,
        IsClientPortal: '@ViewBag.IsClientPortal',
        StartDate: '',
        EndDate: '',
        Page: ''
    }

    let ColumnSettings = {
        EmployeeOffice: true,
        EmployeeOfficeName: true,
        EmployeeDepartment: true,
        EmployeeDepartmentName: true,
        EmployeeCode: true,
        EmployeeName: true,
        RequiredHours: true,
        BillableHours: true,
        NonBillableHours: true,
        NewBusinessHours: true,
        OOOHours: true,
        TotalHours: true,
        BillableHoursPercent: true,
        BillablePercentGoal: true,
        BillableVariance: true,
        DirectPercentGoal: true,
        NonBillableHoursPercent: true,
        NewBusinessPercent: true,
        OOOPercent: true,
        TotalUtilization: true,
        DirectHoursGoal: true,
        AgencyHours: true,
        TotalDirectHours: true,
        NonDirectHours: true,
        Variance: true,
        PercentDirect: true,
        PercentNonDirect: true,
        PercentOfDirectHoursGoal: true,
        PercentOfBillableHoursGoal: true
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

        var grid = $("#utilizationgrid").data("kendoGrid"),
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
        UtilizationDataSource = new kendo.data.DataSource({                  
                transport: {
                    read: (e) => {
                        let data = EUFilter;                        
                
                        $.ajax({
                            type: "GET",
                            url: "@Href("~/Dashboard/EmployeeUtilization/GetUtilizationData")",
                            dataType: 'json',
                            data: data,
                            success: (results) => {
                                $.each(results, (i, e) => {

                                });                    
                                e.success(results);
                            },
                            error: (results) => {
                                e.error(results);
                            }
                        });

                        EUFilter.InitialLoadFlag = false;
                    }
                },
                pageSize: UserViewSettings.GridSize,                
                group: GetGrouping(),

                change: function() {
                    if(this.group().length > 0) {
                        console.log(this.group);
                    }
                },
                schema: {
                    model: {
                        fields: {
                            EmployeeOffice: { from: "EmployeeOffice", type: "string", editable: false, nullable: false },
                            EmployeeOfficeName: { from: 'EmployeeOfficeName', type: 'string', editable: false, nullable: false },
                            EmployeeCode: { from: 'EmployeeCode', type: 'string', editable: false, nullable: false },
                            EmployeeName: { from: 'EmployeeName', type: 'string', editable: false, nullable: false },
                            EmployeeDepartment: { from: "EmployeeDepartment", type: "string", editable: false, nullable: false },
                            EmployeeDepartmentName: { from: 'EmployeeDepartmentName', type: 'string', editable: false, nullable: false},
                            RequiredHours: { from: 'RequiredHours', type: 'number', editable: false, nullable: true },
                            BillableHoursGoal: { from: 'BillableHoursGoal', type: 'number', editable: false, nullable: true },
                            BillableHours: { from: 'BillableHours', type: 'number', editable: false, nullable: true },
                            NonBillableHours: { from: 'NonBillableHours', type: 'number', editable: false, nullable: true },
                            NewBusinessHours: { from: 'NewBusinessHours', type: 'number', editable: false, nullable: true },
                            OOOHours: { from: 'OOOHours', type: 'number', editable: false, nullable: true },
                            TotalHours: { from: 'TotalHours', type: 'number', editable: false, nullable: true },
                            BillableHoursPercent: { from: 'BillableHoursPercent', type: 'number', editable: false, nullable: true },
                            BillablePercentGoal: { from: 'BillablePercentGoal', type: 'number', editable: false, nullable: true },
                            BillableVariance: { from: 'BillableVariance', type: 'number', editable: false, nullable: true },
                            DirectPercentGoal: { from: 'DirectPercentGoal', type: 'number', editable: false, nullable: true },
                            NonBillableHoursPercent: { from: 'NonBillableHoursPercent', type: 'number', editable: false, nullable: true },
                            NewBusinessPercent: { from: 'NewBusinessPercent', type: 'number', editable: false, nullable: true },
                            OOOPercent: { from: 'OOOPercent', type: 'number', editable: false, nullable: true },
                            TotalUtilization: { from: 'TotalUtilization', type: 'number', editable: false, nullable: true },
                            DirectHoursGoal: { from: 'DirectHoursGoal', type: 'number', editable: false, nullable: true },
                            AgencyHours: { from: 'AgencyHours', type: 'number', editable: false, nullable: true },
                            TotalDirectHours: { from: 'TotalDirectHours', type: 'number', editable: false, nullable: true },
                            NonDirectHours: { from: 'NonDirectHours', type: 'number', editable: false, nullable: true },
                            Variance: { from: 'Variance', type: 'number', editable: false, nullable: true },
                            PercentDirect: { from: 'PercentDirect', type: 'number', editable: false, nullable: true },
                            PercentNonDirect: { from: 'PercentNonDirect', type: 'number', editable: false, nullable: true },
                            PercentOfDirectHoursGoal: { from: 'PercentOfDirectHoursGoal', type: 'number', editable: false, nullable: true },
                            PercentOfBillableHoursGoal: { from: 'PercentOfBillableHoursGoal', type: 'number', editable: false, nullable: true }
                        }
                    }
                }
        });
        
        return UtilizationDataSource;
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
            url: "EmployeeUtilization/GetGridColumnVisibilitySettings?GridView=" + GetGridView(),
            dataType: "json",
            success: function (response) {
                let EmployeeOffice = true;
                let EmployeeOfficeName = true;
                let EmployeeDepartment = true;
                let EmployeeDepartmentName = true;
                let EmployeeCode = true;
                let EmployeeName = true;
                let RequiredHours = true;
                let BillableHours = true;
                let NonBillableHours = true;
                let NewBusinessHours = true;
                let TotalHours = true;
                let BillableHoursPercent = true;
                let BillablePercentGoal = true;
                let BillableVariance = true;
                let NonBillableHoursPercent = true;
                let NewBusinessPercent = true;
                let OOOPercent = true;
                let TotalUtilization = true;
                let OOOHours = true;
                let BillableHoursGoal = true;
                let DirectPercentGoal = true;

                let DirectHoursGoal = true;
                let AgencyHours = true;
                let TotalDirectHours = true;
                let NonDirectHours = true;
                let Variance = true;
                let PercentDirect = true;
                let PercentNonDirect = true;
                let PercentOfDirectHoursGoal = true;
                let PercentOfBillableHoursGoal = true;

                $.each(response, function (index, value) {
                    if (value == 'EmployeeOffice') { EmployeeOffice = false; }
                    if (value == 'EmployeeOfficeName') { EmployeeOfficeName = false; }
                    if (value == 'EmployeeDepartment') { EmployeeDepartment = false; }
                    if (value == 'EmployeeDepartmentName') { EmployeeDepartmentName = false; }
                    if (value == 'EmployeeCode') { EmployeeCode = false; }
                    if (value == 'EmployeeName') { EmployeeName = false; }
                    if (value == 'RequiredHours') { RequiredHours = false; }
                    if (value == 'BillableHours') { BillableHours = false; }
                    if (value == 'NonBillableHours') { NonBillableHours = false; }
                    if (value == 'NewBusinessHours') { NewBusinessHours = false; }
                    if (value == 'TotalHours') { TotalHours = false; }
                    if (value == 'OOOHours') { OOOHours = false; }
                    if (value == 'BillableHoursPercent') { BillableHoursPercent = false; }
                    if (value == 'BillablePercentGoal') { BillablePercentGoal = false; }
                    if (value == 'DirectPercentGoal') { DirectPercentGoal = false; }
                    if (value == 'BillableVariance') { BillableVariance = false; }
                    if (value == 'NonBillableHoursPercent') { NonBillableHoursPercent = false; }
                    if (value == 'NewBusinessPercent') { NewBusinessPercent = false; }
                    if (value == 'OOOPercent') { OOOPercent = false; }
                    if (value == 'TotalUtilization') { TotalUtilization = false; }
                    if (value == 'BillableHoursGoal') { BillableHoursGoal = false; }
                    if (value == 'DirectHoursGoal') { DirectHoursGoal = false; }
                    if (value == 'AgencyHours') { AgencyHours = false; }
                    if (value == 'TotalDirectHours') { TotalDirectHours = false; }
                    if (value == 'NonDirectHours') { NonDirectHours = false; }
                    if (value == 'Variance') { Variance = false; }
                    if (value == 'PercentDirect') { PercentDirect = false; }
                    if (value == 'PercentNonDirect') { PercentNonDirect = false; }
                    if (value == 'PercentOfDirectHoursGoal') { PercentOfDirectHoursGoal = false; }
                    if (value == 'PercentOfBillableHoursGoal') { PercentOfBillableHoursGoal = false; }
                });

                ColumnSettings.EmployeeOffice = EmployeeOffice;
                ColumnSettings.EmployeeOfficeName = EmployeeOfficeName;
                ColumnSettings.EmployeeDepartment = EmployeeDepartment;
                ColumnSettings.EmployeeDepartmentName = EmployeeDepartmentName;
                ColumnSettings.EmployeeCode = EmployeeCode;
                ColumnSettings.EmployeeName = EmployeeName;
                ColumnSettings.RequiredHours = RequiredHours;
                ColumnSettings.BillableHours = BillableHours;
                ColumnSettings.NonBillableHours = NonBillableHours;
                ColumnSettings.NewBusinessHours = NewBusinessHours;
                ColumnSettings.TotalHours = TotalHours;
                ColumnSettings.OOOHours = OOOHours;
                ColumnSettings.BillableHoursPercent = BillableHoursPercent;
                ColumnSettings.BillablePercentGoal = BillablePercentGoal;
                ColumnSettings.DirectPercentGoal = DirectPercentGoal;
                ColumnSettings.BillableVariance = BillableVariance;
                ColumnSettings.NonBillableHoursPercent = NonBillableHoursPercent;
                ColumnSettings.NewBusinessPercent = NewBusinessPercent;
                ColumnSettings.OOOPercent = OOOPercent;
                ColumnSettings.TotalUtilization = TotalUtilization;
                ColumnSettings.BillableHoursGoal = BillableHoursGoal;
                ColumnSettings.DirectHoursGoal = DirectHoursGoal;
                ColumnSettings.AgencyHours = AgencyHours;
                ColumnSettings.TotalDirectHours = TotalDirectHours;
                ColumnSettings.NonDirectHours = NonDirectHours;
                ColumnSettings.Variance = Variance;
                ColumnSettings.PercentDirect = PercentDirect;
                ColumnSettings.PercentNonDirect = PercentNonDirect;
                ColumnSettings.PercentOfDirectHoursGoal = PercentOfDirectHoursGoal;
                ColumnSettings.PercentOfBillableHoursGoal = PercentOfBillableHoursGoal;

                let grid = $('#utilizationgrid').data('kendoGrid');

                for (let i = 0; i < grid.columns.length; i++) {
                    if (ColumnSettings.EmployeeOffice == false && grid.columns[i].attributes.hiddenTitleValue == 'Office') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.EmployeeOfficeName == false && grid.columns[i].attributes.hiddenTitleValue == 'Office Name') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.EmployeeDepartment == false && grid.columns[i].attributes.hiddenTitleValue == 'CDepartment') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.EmployeeDepartmentName == false && grid.columns[i].attributes.hiddenTitleValue == 'Department Name') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.EmployeeCode == false && grid.columns[i].attributes.hiddenTitleValue == 'Employee Code') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.EmployeeName == false && grid.columns[i].attributes.hiddenTitleValue == 'Employee Name') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.RequiredHours == false && grid.columns[i].attributes.hiddenTitleValue == 'Required Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.BillableHours == false && grid.columns[i].attributes.hiddenTitleValue == 'Billable Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.NonBillableHours == false && grid.columns[i].title == 'Non Billable Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.NewBusinessHours == false && grid.columns[i].title == 'New Business Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TotalHours == false && grid.columns[i].title == 'Total Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.OOOHours == false && grid.columns[i].title == 'OOO Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.BillableHoursPercent == false && grid.columns[i].title == 'Billable Hours %') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.BillablePercentGoal == false && grid.columns[i].title == 'Billable Hours % Goal') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.DirectPercentGoal == false && grid.columns[i].title == 'Direct Hours % Goal') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.BillableVariance == false && grid.columns[i].title == 'Billable Variance') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.NonBillableHoursPercent == false && grid.columns[i].title == 'Non Billable Hours %') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.NewBusinessPercent == false && grid.columns[i].title == 'New Business %') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.OOOPercent == false && grid.columns[i].title == 'OOO %') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TotalUtilization == false && grid.columns[i].title == 'Total Utilization') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.BillableHoursGoal == false && grid.columns[i].title == 'Billable Hours Goal') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.DirectHoursGoal == false && grid.columns[i].title == 'Direct Hours Goal') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.AgencyHours == false && grid.columns[i].title == 'Agency Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.TotalDirectHours == false && grid.columns[i].title == 'Total Direct Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.NonDirectHours == false && grid.columns[i].title == 'Non Direct Hours') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.Variance == false && grid.columns[i].title == 'Variance') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.PercentDirect == false && grid.columns[i].title == '& Direct') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.PercentNonDirect == false && grid.columns[i].title == '% Non Direct') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.PercentOfDirectHoursGoal == false && grid.columns[i].title == '% of Direct Hours Goal') {
                        grid.hideColumn(i);
                    }
                    else if (ColumnSettings.PercentOfBillableHoursGoal == false && grid.columns[i].title == '% of Billable Hours Goal') {
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
