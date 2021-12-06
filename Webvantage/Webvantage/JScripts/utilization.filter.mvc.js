//
var jobInfoChange = false;
var dateChange = false;
var EmployeeCode = '';

function Initialize() {
    console.log("init");

}

function onFilterSelectChange(e) {
    let filterValue = '';
    let dropdown = $("#filterSelect").data("kendoDropDownList");

    filterValue = dropdown.value();

    EUFilter.Department = '';
    EUFilter.EmployeeCode = '';
    EUFilter.EmployeeRole = '';

    switch (filterValue) {
        case "department":
            //multiselect = $("#departmentMS").data("kendoMultiSelect");                
            $("#departmentFilterContainer").removeClass("display-none");
            $("#employeeFilterContainer").addClass("display-none");
            $("#roleFilterContainer").addClass("display-none");

            $("#roleMS").data("kendoMultiSelect").value([]);
            $("#empMS").data("kendoMultiSelect").value([]);
            break;
        case "employee":
            $("#employeeFilterContainer").removeClass("display-none");
            $("#departmentFilterContainer").addClass("display-none");
            $("#roleFilterContainer").addClass("display-none");

            $("#departmentMS").data("kendoMultiSelect").value([]);
            $("#roleMS").data("kendoMultiSelect").value([]);
            break;
        case "role":
            $("#roleFilterContainer").removeClass("display-none");
            $("#employeeFilterContainer").addClass("display-none");
            $("#departmentFilterContainer").addClass("display-none");

            $("#departmentMS").data("kendoMultiSelect").value([]);
            $("#empMS").data("kendoMultiSelect").value([]);
            break;
    }

    _filterSelectedValue = filterValue;

    if (_multiselectfiltered) {
        let dataGrid = $("#utilizationgrid").data("kendoGrid");
        dataGrid.dataSource.read();
    }

    //if (EUFilter.IsJobAlertsPage == true) {
        $("#employeeFilterContainer").addClass("display-none");
        $("#departmentFilterContainer").addClass("display-none");
        $("#employeeFilterContainer").addClass("display-none");
        $("#roleFilterContainer").addClass("display-none");
        $("#tdFilter").addClass("display-none");
        $("#ShowOnlyTempCompletedTasksDiv").hide();             
    //}

    if (EUFilter.IsClientPortal == "True") {

        $("#departmentFilterContainer").addClass("display-none");
        $("#employeeFilterContainer").addClass("display-none");
        $("#roleFilterContainer").addClass("display-none");
        $("#tdFilter").addClass("display-none");
        $("#ShowOnlyTempCompletedTasksDiv").hide();
        $("#IncludeBacklogItemsDiv").hide();
    }


}

function manageEmployeeFilterStatus() {
    //set the initial status of the Employee Filter based on the Inbox Selected
    //the Employee filter is active only when "All Assignments" is selected.
    let readOnly = false;
    let multiselect = "";
    let dropdown = "";
    EUFilter.ShowAssignmentType == "allalertassignments" ? readOnly = false : readOnly = true;    

    multiselect = $("#empMS").data("kendoMultiSelect");
    if (multiselect !== undefined) {
        multiselect.readonly(readOnly);       

        if (EUFilter.EmployeeCode !== undefined && EUFilter.EmployeeCode !== "") {            
            let employeesArray = (EUFilter.EmployeeCode).split(",");

            if (!_fromBookmarkFlag) {
                $("#empMS").data("kendoMultiSelect").value(employeesArray);
            }
            
        }
    }
    

    multiselect = $("#roleMS").data("kendoMultiSelect");
    if (multiselect !== undefined) {
        multiselect.readonly(readOnly);
    }

    multiselect = $("#departmentMS").data("kendoMultiSelect");
    if (multiselect !== undefined) {
        multiselect.readonly(readOnly);
    }

    dropdown = $("#filterSelect").data("kendoDropDownList");
    if (dropdown !== undefined) {
        dropdown.readonly(readOnly);
    }    

    if (readOnly) {

        $('#empMS_taglist').addClass("k-state-disabled");
        $('#empMS_taglist').addClass("noHover");

        $('#roleMS_taglist').addClass("k-state-disabled");
        $('#roleMS_taglist').addClass("noHover");

        $('#departmentMS_taglist').addClass("k-state-disabled");
        $('#departmentMS_taglist').addClass("noHover");

        //$('.k-widget.k-dropdown.k-header').prop("disabled", true).addClass("k-state-disabled");
        $('#tdFilter > span').prop("disabled", true).addClass("k-state-disabled");

        //$('k-widget.k-dropdown.k-header').addClass("noHover");
        $('#tdFilter > span').addClass("noHover");
    } else {

        $('#empMS_taglist').removeClass("k-state-disabled");
        $('#empMS_taglist').removeClass("noHover");

        $('#roleMS_taglist').removeClass("k-state-disabled");
        $('#roleMS_taglist').removeClass("noHover");

        $('#departmentMS_taglist').removeClass("k-state-disabled");
        $('#departmentMS_taglist').removeClass("noHover");

        $('.k-widget.k-dropdown.k-header').prop("disabled", false).removeClass("k-state-disabled");
        $('.k-widget.k-dropdown.k-header').removeClass("noHover");
    }
}

function onExpand(e) {
    setTimeout(() => {
        $(window).trigger('resize', false);
    }, 200);
}

function onCollapse(e) {
    setTimeout(() => {
        $(window).trigger('resize', true);
    }, 300);
}


function onDateFilterChange(e) {    
    //console.log("onDateFilterChange");

    let startDate = new Date($("#startdate").val());
    let endDate = new Date($("#duedate").val());               
    
    if ($("#startdate").val() !== "" && startDate > endDate) {        
        $("#startdate").val('');
        showKendoAlert("The Start Date must be less than or equal to the End Date.");        
    } else if ($("#duedate").val() !== "" && endDate < startDate) {        
        $("#duedate").val('');
        showKendoAlert("The End Date must be greater than or equal to the Start Date.");
    } else {
        if (gridDirty) {
            promptSave().done(() => ProcessDateFilterChange());
        } else {
            ProcessDateFilterChange();
        }
    }   
}

function ProcessDateFilterChange() {
    dateChange = true;

    var datePicker = $("#startdate").data("kendoDatePicker");

    var StartDate = datePicker.value();
    if (StartDate !== null) {
        StartDate = datePicker.value().toDateString();
    } else {
        StartDate = '1/1/1950';
    }

    EUFilter.StartDate = StartDate;

    datePicker = $("#duedate").data("kendoDatePicker");
    var EndDate = datePicker.value();

    if (EndDate !== null) {
        EndDate = datePicker.value().toDateString();
        EUFilter.EndDate = EndDate;

        /*var grid = $("#utilizationgrid");
        grid.data("kendoGrid").dataSource.read();            */
    }

    var dataGrid = $("#utilizationgrid").data("kendoGrid");
    dataGrid.dataSource.read();
}

function onSelectedFilterChange(e) {    
    if (gridDirty) {
        promptSave().done(() => ProcessSelectedFilterChange(e));
    } else {
        ProcessSelectedFilterChange(e)
    }
}

function ProcessSelectedFilterChange(e) {
    let dataItem = e.sender.dataItems();
    let selectedArray = [];
    let selections = '';
    let selectionCount = 0;
    let selectedFilter = '';

    selectedFilter = e.sender.element[0].id

    $.each(dataItem, (i, v) => {
        selectedArray.push(v.Code);

        if (selectionCount == 0) {
            selections += v.Code;
        } else {
            selections += ',' + v.Code;
        }

        ++selectionCount;
    });

    switch (selectedFilter) {
        case "empMS":
            EUFilter.EmployeeCode = selections;
            break;
        case "departmentMS":
            EUFilter.Department = selections;
            break;
        case "roleMS":
            EUFilter.EmployeeRole = selections;
            break;
    }

    var dataGrid = $("#utilizationgrid").data("kendoGrid");
    dataGrid.dataSource.read();
}
