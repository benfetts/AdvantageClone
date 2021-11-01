//
function AAGrid_SubscribeToShared() {
    let grid = $("#aagrid").data("kendoGrid");

    grid.bind("sort", function (e) { 
        let element = $("th[class*=static-]")        
        element.removeClass("static-sort-desc");
        element.removeClass("static-sort-asc");

        _sortedDirection = e.sort.dir;

        _sortedField = e.sender.columns.find(column => {
            return column.field === e.sort.field
        }).title;
    });
    grid.bind("excelExport", function (e) {
        e.workbook.fileName = GetExportFileName();
                
        let sheet = e.workbook.sheets[0];
        let cellTemplate = [];
        let columnIndex = 0;        
        
        let grid = $("#aagrid").data("kendoGrid");
        let originalGridSize = grid.dataSource.pageSize();
        //console.log(originalGridSize);
        //console.log(grid.dataSource.data().length);
        grid.dataSource.pageSize(grid.dataSource.data().length);

        let gridData = $("#aagrid").data("kendoGrid")._data;

        for (let i = 0; i < sheet.rows[0].cells.length; i++) {
            if (sheet.rows[0].cells[i].value == "Task Status") {
                sheet.columns[i].width = 0;
                break;
            }
        }

        //retrieve the defined templates for the columns below
        for (let i = 0; i < this.columns.length; i++) {
            if (this.columns[i].title == "Last Updated" || this.columns[i].title == "Priority" || this.columns[i].title == "Component Number"
                || this.columns[i].title == "CC Recipient Codes") {

                if (!this.columns[i].hidden) {
                    for (let k = 0; k < sheet.rows[0].cells.length; k++) {
                        //locate the column index in the spreadsheet
                        //this is necessary for applying the template to the correct column
                        if (sheet.rows[0].cells[k].value == this.columns[i].title) {
                            columnIndex = k;
                        }
                    }
                    cellTemplate.push({ cell: this.columns[i].title, template: kendo.template(this.columns[i].template), cellIndex: columnIndex });
                }
            }
        }

        //iterate throught he spreadsheet, locate the columns that need to be "templated" and apply templates        
        let idx = 0;
        for (let i = 1; i < sheet.rows.length; i++) {
            let row = sheet.rows[i];

            if (row.type == "data") {
                for (let k = 0; k < cellTemplate.length; k++) {
                    let dataItem;
                    switch (cellTemplate[k].cell) {
                        case "Last Updated":
                            dataItem = { LastUpdated: gridData[idx].LastUpdated };                            
                            row.cells[cellTemplate[k].cellIndex].value = cellTemplate[k].template(dataItem);
                            break;
                        case "Priority":
                            dataItem = { Priority: gridData[idx].Priority };
                            row.cells[cellTemplate[k].cellIndex].value = cellTemplate[k].template(dataItem);
                            break;
                        case "Component Number":
                            dataItem = { Job: gridData[idx].Job, ComponentNumber: gridData[idx].ComponentNumber };
                            row.cells[cellTemplate[k].cellIndex].value = cellTemplate[k].template(dataItem);
                            break;
                        case "CC Recipient Codes":
                            dataItem = { CCEmployeeCodes: gridData[idx].CCEmployeeCodes };
                            row.cells[cellTemplate[k].cellIndex].value = cellTemplate[k].template(dataItem);
                            break;
                    }
                }

                ++idx;
            }
        }

        grid.dataSource.pageSize(originalGridSize);
    });

    grid.bind("cellClose", function (e) {          
        let inner = e.container[0].innerHTML;        
        if (inner.includes("DueDate")) {            
            //due date has been updated, the title of the cell needs to be updated
            //to reflect the getDueDateTitle logic after the cell has closed
            let DueDate = kendo.toString(kendo.parseDate(e.model.DueDate, 'yyyy-MM-dd'), 'MM/dd/yyyy')
            GetDateDiffAndWeekendStatus(DueDate).then(function (response) {
                //dataItem.TaskDateDiff, dueDate, dataItem.TaskDateIsWeekend, dataItem.DueDate
                title = getDueDateTitle(response.DateDifference, DueDate, response.IsWeekendDate, e.model.DueDate);

                setTimeout(function () {
                    e.container.find("div")[0].title = title;
                }, 0);
            });            
        }
        

        $("#aagrid").data("kendoGrid").refresh();
    });       
    
    grid.bind("filterMenuInit", function (e) {        
        //remove the focus from the column header
        let popup = e.container.data("kendoPopup");
        popup.bind("close", function (e) {
            $("#aagrid").focus();
        });         
        
        var filterMultiCheck = this.thead.find("[data-field=" + e.field + "]").data("kendoFilterMultiCheck")

        if (filterMultiCheck !== undefined) {
            filterMultiCheck.container.empty();
            filterMultiCheck.checkSource.sort({ field: e.field, dir: "asc" });

            // uncomment the following line to handle any grouping from the original dataSource:
            filterMultiCheck.checkSource.group(null);

            filterMultiCheck.checkSource.data(filterMultiCheck.checkSource.view().toJSON());
            filterMultiCheck.createCheckBoxes();

            $("span:contains('Select All')").html("(Select All)");
        }        
    });

    grid.bind("columnReorder", function (e) {         
        let grid = e.sender;
        let columnIndex = e.oldIndex;
        let column = e.column;
        let replaceColumnTitle;
        let staticColumnMoveAllowed = false;

        reorderedColumn.name = e.column.field === undefined ? e.column.title : e.column.field;
        reorderedColumn.oldIndex = e.oldIndex;
        reorderedColumn.newIndex = e.newIndex;

        replaceColumnTitle = grid.columns[reorderedColumn.newIndex].title;        

        if ((_staticColumns.includes(reorderedColumn.name) && _staticColumns.includes(replaceColumnTitle))
            && (replaceColumnTitle != "" && reorderedColumn.name != ""))
        {
            staticColumnMoveAllowed = true;
        }

        //Icon columns are locked down
        if ((_staticColumns.includes(reorderedColumn.name) || _staticColumns.includes(replaceColumnTitle))
            && staticColumnMoveAllowed == false) {
            setTimeout(function (e) {
                grid.reorderColumn(columnIndex, column)
            }, 1)
        } else {          
            SaveUserColumnOrder();          
        }
    });

    grid.bind("group", function (e) {        
        if (e.groups.length > 0) {
            let groupingFormat = '';
            AlertFilter.GroupBy = '';

            for (let i = 0; i < e.groups.length; i++) {
                if (i > 0) {
                    groupingFormat = " " + e.groups[i].field;
                } else {
                    groupingFormat = e.groups[i].field;
                }

                AlertFilter.GroupBy += groupingFormat;
            }
        } else {
            AlertFilter.GroupBy = '';
        }

        UpdateUserViewSettings(_viewType);
        //$("#aagrid").data("kendoGrid").dataSource.read();
    });

    grid.bind("columnResize", function (e) {
        let columnName = e.column.field === undefined ? e.column.title.replace(" ", "") : e.column.field;        
        if (!_fromBookmarkFlag) {
            SaveUserColumnWidth(columnName, e.newWidth)
        }
        
    });

    grid.bind("columnHide", function (e) { 
        //if (e.sender.dataSource._filter !== undefined) {
        //    filtered = $.grep(e.sender.dataSource.filter._filters, function (item) {
        //        console.log(item);
        //        if (item.field === "Subject")                    
        //            e.sender.dataSource._filter({});
        //        //return item.dirty;
        //    }); 
        //}        
        
        if (saveColumnVisibility) {
            let Data = {
                GridName: GetGridView(),
                Column: e.column.field,
                ShowHide: false
            };

            //utilized to capture unbound columns; i.e. TaskFlag, Stopwatch etc.
            if (Data.Column === undefined) {
                Data.Column = e.column.title;
            }

            $.post({
                url: "Inbox/SaveColumnSetting",
                dataType: "json",
                data: Data
            }).always(function () {

            });
        } else {
            e.preventDefault();
        }
    });

    grid.bind("columnShow", function (e) {
        if (saveColumnVisibility) {
            let Data = {
                GridName: GetGridView(),
                Column: e.column.field,
                ShowHide: true
            };

            if (Data.Column === undefined) {
                Data.Column = e.column.title;
            }

            $.post({
                url: "Inbox/SaveColumnSetting",
                dataType: "json",
                data: Data
            }).always(function () {
            });
        } else {
            e.preventDefault();
        }
    });

    grid.bind("navigate", function (e) {    
    });

    grid.bind("dataBinding", function (e) {     
        if (e.items == undefined) {
            e.preventDefault()
        }

        $("span.k-icon.k-i-more-vertical").replaceWith('<button class="k-button wv-icon-button wv-neutral"><span class="wvi wvi-table-selection-column"></span></button>');

        if (isJobJacketView) {
            $("#dismissAllListItem").hide();
            $("#completeTempCompleteListItem").hide();            
        } else {
            $("#dismissAllListItem").show();
            $("#completeTempCompleteListItem").show();
        }        

        if (_isClientPortal == "True") {
            
            $("#completeTempCompleteListItem").hide();
            $("#dismissAllListItem").hide();

        }

    });

    grid.bind("dataBound", function (e) {        
        let grid = e.sender;

        nonReorderableColumn = e.sender.columns[0];
        totalpages = e.sender.pager.totalPages();
        e.sender.pager.options.messages.display = "{2} items in " + totalpages + " page(s)";

        var items = e.sender.items();

        if ((AlertFilter.ShowAssignmentType === "myalertassignments" || AlertFilter.ShowAssignmentType === "myalerts") ||
            (AlertFilter.ShowAssignmentType === "allalertassignments" && $("#empMS").data("kendoMultiSelect").value().length === 1)) {
            //(AlertFilter.ShowAssignmentType === "allalertassignments" && $("#empMS").data("kendoMultiSelect").value().length === 1 && $("#empMS").data("kendoMultiSelect").value()[0] === _EmployeeCode)) {

            AreGridRowsReorderable = true;

        } else {
            AreGridRowsReorderable = false;
        }

        items.each(function (index) {
            var dataItem = grid.dataItem(this);

            if (!AreGridRowsReorderable) {
                this.className += " disabled";
            }
            if (dataItem.IsMyTaskTempComplete) {
                this.className += " strikethrough";
            }
            if (!dataItem.IsRead) {
                this.className += " not-read-bold";
            }
        })

        $("#aagrid > div.k-pager-wrap.k-grid-pager.k-widget.k-floatwrap > span.k-pager-sizes.k-label > span > select").change(function (e) {
            let gridSize = $("#aagrid > div.k-pager-wrap.k-grid-pager.k-widget.k-floatwrap > span.k-pager-sizes.k-label > span > span > span.k-input").html();
            if (gridSize !== UserViewSettings.GridSize) {
                UpdateUserViewSettings(_viewType);
            }
        })

        //changing the "items per page" dropdown fires the main grid change event, which will fire the "dirty" grid events
        //the pageFlag is managed via the Select and Close event to disable the downstream "dirty" grid events.
        let pagerDropdown = grid.pager.element.find(".k-pager-sizes [data-role=dropdownlist]")
            .data("kendoDropDownList");

        pagerDropdown.bind("select", function (e) {
            pageFlag = true;
        });

        pagerDropdown.bind("close", function (e) {
            pageFlag = false;
        });

        $("#Search").val(AlertFilter.SearchCriteria);

        ManageDismissAllButton(AlertFilter.ShowAssignmentType, AlertFilter.InboxType, items.length);
        ManageAssignmentTypeButtons(AlertFilter.ShowAssignmentType);
        ManageCompleteTempCompleteButton();        
        
        ManageSortedHeaderDisplay();
    });
}

function ManageSortedHeaderDisplay() {    
    if (_sortedDirection) {          
        if (_staticColumns.includes(_sortedField)) {
            let sel = "th[data-title='" + _sortedField + "'].k-header";
            let element = $(sel);

            //element.removeClass("static-sort-asc");
            //element.removeClass("k-sorted");
            //element.find("a.k-link").css("width", "28px");
            //element.find("a.k-link").css("margin-right", "0px");            

            element.removeClass("static-sort-desc");
            element.removeClass("static-sort-asc");

            if (_sortedDirection == 'desc')
                element.addClass("static-sort-desc");
            else if (_sortedDirection == 'asc')
                element.addClass("static-sort-asc");
        }
    }
}

function CreateAAViewGrid() {
    let aaGrid = $("#aagrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: AAManagerDataSource,
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: [10, 15, 20, 50, 100, 200],
            buttonCount: 5
        },
        editable: "incell",
        resizable: true,
        filterable: {
            operators: {
                string: {
                    contains: "Contains",
                    doesnotcontain: "Does not contain",
                    eq: "Is equal to",
                    neq: "Is not equal to",
                    startswith: "Starts with",                    
                    endswith: "Ends with",
                    isnull: "Is null",
                    isnotnull: "Is not null",
                    isempty: "Is empty",
                    isnotempty: "Is not empty",
                    isnullorempty: "Has no value",
                    isnotnullorempty: "Has value"
                }
            }
        },        
        columns: myColumns
    });

    SetupAdditionalGridFeatures();

    return aaGrid;
}

function CreateTaskViewGrid() {    
    let taskGrid = $("#aagrid").kendoGrid({    
        autoBind: false,
        navigatable: true,
        reorderable: true,
        toolbar: kendo.template($("#template").html()),
        excel: {            
            filterable: true,
            allPages: true
        },
        dataSource: AAManagerDataSource,
        groupable: true,
        sortable: true,
        pageable: {
            refresh: true,
            pageSizes: [10, 15, 20, 50, 100, 200],
            buttonCount: 5
        },
        editable: "incell",        
        resizable: true,        
        filterable: {
            operators: {
                string: {
                    contains: "Contains",
                    doesnotcontain: "Does not contain",
                    eq: "Is equal to",
                    neq: "Is not equal to",
                    startswith: "Starts with",
                    endswith: "Ends with",
                    isnull: "Is null",
                    isnotnull: "Is not null",
                    isempty: "Is empty",
                    isnotempty: "Is not empty",
                    isnullorempty: "Has no value",
                    isnotnullorempty: "Has value"
                }
            }
        },
        columns: myColumns
    });

    SetupAdditionalGridFeatures();

    return taskGrid;
}

function GetExportFileName() {
    let fileName = "";

    if (isJobJacketView) {
        fileName = "Job " + AlertFilter.JobNumber + "-" + AlertFilter.JobComponentNumber + "_";
    }

    switch (AlertFilter.ShowAssignmentType) {
        case 'unassigned':
            fileName += "Unassigned_";
            break;
        case 'myalertsandassignments':
            fileName += "My_Assignments_and_Alerts_";
            break;
        case 'myalerts':
            fileName += "My_Alerts_";
            break;
        case 'myalertassignments':
            fileName += "My_Assignments_";
            break;
        case 'allalertassignments':
            fileName += "All_Assignments_";
            break;
        default:
            break;
    }

    if (!isJobJacketView) {
        switch (AlertFilter.InboxType) {
            case 'inbox':
                fileName += "Current";
                break;
            case 'dismissed':
                fileName += "Dismissed_And_Completed";
                break;
            case 'all':
                fileName += "All";
                break;
            case 'drafts':
                fileName += "Drafts";
                break;
            case 'task':
                fileName += "Task_List_View";
                break;
            default:
                break;
        }
    }
    

    fileName += "_" + kendo.toString(kendo.parseDate(new Date()), 'yyyyddMM_hhmmss') + ".xlsx";

    return fileName;
}

$("#aagrid").change(function (e) {    
    if (e.target.id !== "Search") {
        if (!pageFlag) {
            gridDirty = true;
            enableSave();
        }
    }
});

function SetupAdditionalGridFeatures() {
    let grid = $("#aagrid").data('kendoGrid');

    grid.table.kendoSortable({        
        handler: "td:nth-child(1),.wvi.wvi-more_vertical.no-strikethrough",
        autoScroll: true,
        disabled: ".disabled",  //if row has disabled class then sorting is not enabled
        hint: hintElement,
        cursor: "move",
        placeholder: function (element) {
            return element.clone().addClass("k-state-hover").css("opacity", 0.65);
        },
        filter: ">tbody >tr",
        change: function (e) {
            let grid = $("#aagrid").data("kendoGrid");
            let oldIndex = e.oldIndex;
            let newIndex = e.newIndex;
            let view = grid.dataSource._data;

            let postUrl = "";

            if (oldIndex !== newIndex) {
                dataItem = grid.dataSource.getByUid(e.item.data("uid")); // Retrieve the moved dataItem.
                dataItem.Order = newIndex; // Update the order
                dataItem.dirty = false;

                // Shift the order of the records.
                if (oldIndex > newIndex) {
                    for (var i = oldIndex + 1; i <= newIndex; i++) {
                        view[i].Order--;
                        view[i].dirty = false;
                    }
                } else {
                    for (var i = oldIndex - 1; i >= newIndex; i--) {
                        view[i].Order++;
                        view[i].dirty = false;
                    }
                }              

                let sequenceDetail = {
                    AlertId: dataItem.AlertID,
                    NewPosition: newIndex,
                    JobNumber: dataItem.JobNumber,
                    JobComponentNumber: dataItem.ComponentNumber,
                    TaskSequenceNumber: dataItem.TaskSequenceNumber,                    
                    EmployeeCode: _EmployeeCode
                };

                //only allow drag when viewing "my alerts" or "my assignments"
                if (AlertFilter.ShowAssignmentType === "myalertassignments" || AlertFilter.ShowAssignmentType === "myalerts" || AlertFilter.ShowAssignmentType === "allalertassignments") {
                    if (AlertFilter.ShowAssignmentType === "allalertassignments") {
                        sequenceDetail.EmployeeCode = AlertFilter.EmployeeCode;
                    }
                    if (dataItem.Category === "Task") {
                        postUrl = "../Inbox/UpdateCardSortAssignments";
                    } else {
                        postUrl = "../Inbox/UpdateCardSortAssignments";
                        sequenceDetail.JobNumber = 0;
                        sequenceDetail.JobComponentNumber = 0;
                        sequenceDetail.TaskSequenceNumber = 0;
                    }
                } else { //myalerts
                    postUrl = "../Inbox/UpdateCardSortAlerts";
                    sequenceDetail.JobNumber = 0;
                    sequenceDetail.JobComponentNumber = 0;
                    sequenceDetail.TaskSequenceNumber = 0;
                }

                $.ajax({
                    type: "POST",
                    url: postUrl,
                    data: JSON.stringify(sequenceDetail),
                    contentType: 'application/json',
                    success: function (response) {
                        //showKendoAlert("Sort sequence successfully updated.");
                    },
                    error: function (response) {
                        showKendoAlert("There was an issue updating the sort sequence please contact support.<br/>Message: " + response.message);
                    }
                });
            }
            else {
                e.preventDefault();
                alert("defaulted");
            }
        }
    });

    $("#aagrid").find("#col-menu").kendoColumnMenu({
        sortable: false,        
        filterable: false,
        columns: true,
        dataSource: grid.dataSource,
        owner: grid
    });      

    LoadColumnVisibilitySettings();
}

function priorityDropList(container, options) {        
    $('<input class="combo-40" name="' + options.field + '"/>')
        .appendTo(container)
        .kendoDropDownList({
            dataTextField: "Description",
            dataValueField: "Value",
            valuePrimitive: true,
            dataSource: new kendo.data.DataSource({
                transport: {
                    read: "Inbox/GetPriorities",
                    dataType: "json"
                },
                schema: {
                    model: {
                        fields: {
                            Description: { type: "string" },
                            Value: { type: "int" }
                        }
                    }
                }
            })
        }).data('kendoDropDownList');
}

function dateEditor(container, options) {
    let item;    

        //if (options.field == 'JobCompletedDate' && options.model.JobCompletedDate == null) {
    //    options.model.JobCompletedDate = new Date();
    //    options.model.dirty = true;
    //    options.model.dirtyFields.JobCompletedDate = true;
    //    container.addClass("k-dirty-cell");
    //}

    if (AlertFilter.IsClientPortal == "False") {
        item = $('<input id="ActiveDatePicker' + options.field + '" class="date-sm" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        item.kendoDatePicker({
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy',            
            change: function (e) {                
                if (options.field === "DueDate") {                    
                    if (dueDateIsBeforeStartDate(options.model.StartDate, options.model.DueDate) === true) {
                        delete options.model.dirtyFields["DueDate"];
                        options.model.DueDate = "";

                        if ($.isEmptyObject(options.model.dirtyFields)) {
                            options.model.dirty = false;
                            gridDirty = false;
                            enableSave();
                        }

                        showKendoAlert("Please select a Due Date greater than or equal to the Start Date: " +
                            kendo.toString(kendo.parseDate(options.model.StartDate, 'yyyy-MM-dd'), 'MM/dd/yyyy'));
                    }

                    let taskFlagCell = $("td#aagrid_active_cell").closest("tr").find("td[hiddentitlevalue='Task Flag']");                    

                    //if duedate has been deleted, remove any background coloring classes.                    
                    if (!options.model.DueDate) {
                        //remove the Task Flag for same alert                        
                        taskFlagCell.find("div").hide();

                        $("td#aagrid_active_cell").removeClass("aam-standard-light-pink");
                        $("td#aagrid_active_cell").removeClass("aam-standard-light-orange");
                        $("td#aagrid_active_cell").removeClass("aam-standard-light-grey");
                        $("td#aagrid_active_cell").removeClass("aam-standard-light-green");
                        $("td#aagrid_active_cell").removeClass("aam-projected");                        
                    } else {                        
                        let DueDate = kendo.toString(kendo.parseDate(options.model.DueDate, 'yyyy-MM-dd'), 'MM/dd/yyyy')
                        let className, title = '';
                        let taskFlagElement = taskFlagCell.find("div");

                        taskFlagCell.find("div").show();

                        GetDateDiffAndWeekendStatus(DueDate).then(function (response) {                            
                            className = getDueDateClass(response.DateDifference, response.IsWeekendDate, DueDate);                            
                            title = getDueDateTitle(response.DateDifference, DueDate, response.IsWeekendDate, options.model.DueDate);
                                                  
                            let selector = `div[taskduedate-cell='${options.model.AlertID}']`;
                            
                            //due date was manually entered
                            if ($(selector).length) {
                                $(selector).closest("td").removeClass("aam-standard-light-pink");
                                $(selector).closest("td").removeClass("aam-standard-light-orange");
                                $(selector).closest("td").removeClass("aam-standard-light-grey");
                                $(selector).closest("td").removeClass("aam-standard-light-green");
                                $(selector).closest("td").removeClass("aam-projected");

                                $(selector).closest("td").addClass(className);
                            } else {
                                //date picker was selected
                                $("td#aagrid_active_cell").removeClass("aam-standard-light-pink");
                                $("td#aagrid_active_cell").removeClass("aam-standard-light-orange");
                                $("td#aagrid_active_cell").removeClass("aam-standard-light-grey");
                                $("td#aagrid_active_cell").removeClass("aam-standard-light-green");
                                $("td#aagrid_active_cell").removeClass("aam-projected");

                                $("td#aagrid_active_cell").addClass(className);                               
                            }

                            taskFlagElement.removeClass("standard-pink");                            
                            taskFlagElement.removeClass("standard-light-orange");
                            taskFlagElement.removeClass("standard-light-grey");
                            taskFlagElement.removeClass("standard-light-green"); 
                            taskFlagElement.removeClass("projected");

                            className = getDueDateClassFlag(response.DateDifference, response.IsWeekendDate, DueDate);

                            taskFlagElement.addClass(className);

                            taskFlagElement.find("input")[0].title = title;

                        });                        
                    }
                } else {
                    if (startDateIsAfterDueDate(options.model.StartDate, options.model.DueDate) === true) {
                        options.model.set("DueDate", options.model.StartDate);
                    }
                }
            }            
        });

    }

    item.bind("focus", (() => {
        setTimeout(function () {
            $('#ActiveDatePicker' + options.field).select();
        }, 50);
    }));
}

function GetDateDiffAndWeekendStatus(DueDate) {
    return $.ajax({
        url: 'Inbox/GetDateDiffAndWeekendStatus',
        data: { "DateValue": DueDate },
        dataType: 'json'
    });    
}

function dueDateIsBeforeStartDate(startDate, dueDate) {
    let dueDateIsBefore = false;
    if (startDate && dueDate) {
        let s = new Date(startDate);
        let d = new Date(dueDate);
        if (s > d) {
            dueDateIsBefore = true;
        }
    }
    return dueDateIsBefore;
}

function startDateIsAfterDueDate(startDate, dueDate) {
    let startDateIsAfter = false;
    if (startDate && dueDate) {
        let s = new Date(startDate);
        let d = new Date(dueDate);
        if (s > d) {
            startDateIsAfter = true;
        }
    }
    return startDateIsAfter;
}

function GenerateColumnDetailSettings() {     
    $.ajax({        
        type: "Get",
        url: "Inbox/GetGridColumnSettings?GridName=" + GetGridView(),
        dataType: "json",
        success: function (response) {
            //myColumns = [];
            myColumns = new Array();
            myColumns.push({ title: "", width: 35, template: "<span class='wvi wvi-more_vertical no-strikethrough'></span>", attributes: { style: "width: 35;" }, resizable: true, minResizableWidth: 35 });            

            for (let i = 0; i < response.length; i++) {                
                switch (response[i].ColumnName) {
                    case "Search":
                        myColumns.push({
                            title: "Search", width: response[i].ColumnWidth, template: detailsTemplate, hidden: !response[i].IsVisible, attributes: {
                                style: "min-width: " + response[i].ColumnWidth + "px !important;", hiddenTitleValue: "Search"
                            }, headerTemplate: detailHeaderTemplate
                        });
                        break;
                    case "Status":
                        myColumns.push({ title: "Status", width: response[i].ColumnWidth, template: statusTemplate, hidden: !response[i].IsVisible, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;", hiddenTitleValue: "Status" }, headerTemplate: statusHeaderTemplate });
                        break;
                    case "CategoryIcon":
                        myColumns.push({ title: "Category Icon", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, template: categoryTemplate, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;", hiddenTitleValue: "Category Icon", class: "no-bold" }, headerTemplate: categoryIconHeaderTemplate });
                        break;
                    case "Task":
                        myColumns.push({ title: "Task Status", field: "TaskStatus", filterable: false, width: response[i].ColumnWidth, template: taskTemplate, hidden: !response[i].IsVisible, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;", hiddenTitleValue: "Task Status" }, headerTemplate: taskStatusHeaderTemplate });
                        break;
                    case "Documents":
                        myColumns.push({ title: "Documents", width: response[i].ColumnWidth, template: documentsTemplate, hidden: !response[i].IsVisible, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;", hiddenTitleValue: "Documents" }, headerTemplate: documentsHeaderTemplate });
                        break;
                    case "TaskFlag":
                        myColumns.push({ title: "Task Flag", width: response[i].ColumnWidth, template: taskFlagTemplate, hidden: !response[i].IsVisible, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;", hiddenTitleValue: "Task Flag" }, headerTemplate: taskFlagHeaderTemplate });
                        break;
                    case "AddTime":
                        myColumns.push({ title: "Add Time", width: response[i].ColumnWidth, template: addTimeTemplate, hidden: !response[i].IsVisible, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;", hiddenTitleValue: "Add Time" }, headerTemplate: addTimeHeaderTemplate });
                        break;
                    case "Stopwatch":
                        myColumns.push({ title: "Stopwatch", width: response[i].ColumnWidth, template: stopwatchTemplate, hidden: !response[i].IsVisible, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;", hiddenTitleValue: "Stopwatch" }, headerTemplate: stopwatchHeaderTemplate });
                        break;
                    case "Subject":
                        myColumns.push({ field: "Subject", title: "Subject", width: response[i].ColumnWidth, template: subjectTemplate, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" }, filterable: { extra: false } });
                        break;
                    case "UserName":
                        myColumns.push({
                            field: "UserName", title: "By", width: response[i].ColumnWidth, template: byTemplate, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false } });
                        break;
                    case "Generated":                        
                        myColumns.push({
                            field: "GeneratedNoTime", title: "Generated", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, template: "#= kendo.toString(kendo.parseDate(Generated, 'yyyy-MM-dd'), 'MM/dd/yyyy') #",
                            attributes: { type: "date", title: "#= kendo.toString(kendo.parseDate(Generated, 'yyyy-MM-dd'), 'MM/dd/yyyy hh:mm tt') #" }, groupHeaderTemplate: generatedGroupTemplate,
                            filterable: { ui: filterDateEditor}
                        });
                        break;
                    //case "LastUpdated":                        
                    //    myColumns.push({
                    //        field: "LastUpdatedNoTime", title: "Last Updated", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, template: lastUpdateTemplate, attributes: { type: "date", title: "#= kendo.toString(kendo.parseDate(LastUpdated, 'yyyy-MM-dd'), 'MM/dd/yyyy hh:mm tt') #" }, groupHeaderTemplate: lastUpdateGroupTemplate,
                    //        filterable: { extra: true }, editor: dateEditor
                    //    });
                    //    break;
                    case "LastUpdated":
                        myColumns.push({
                            field: "LastUpdatedNoTime", title: "Last Updated", width: response[i].ColumnWidth, template: lastUpdateTemplate, groupHeaderTemplate: lastUpdateGroupTemplate,
                            editor: dateEditor, hidden: !response[i].IsVisible, attributes: { class: 'date-sm' }, headerAttributes: { class: 'date-sm' },
                            filterable: { ui: filterDateEditor },
                            sortable: {
                                compare: function (a, b) {                                     
                                    return a.LastUpdated - b.LastUpdated;
                                }
                            }
                        });
                        break;
                    case "StartDate":
                        myColumns.push({
                            field: "StartDate", title: "Start Date", width: response[i].ColumnWidth, template: startDateTemplate, groupHeaderTemplate: startDateGroupTemplate,
                            editor: dateEditor, hidden: !response[i].IsVisible, attributes: { class: 'date-sm' }, headerAttributes: { class: 'date-sm' },
                            filterable: { ui: filterDateEditor }
                        });
                        break;
                    case "DueDate":
                        myColumns.push({
                            field: "DueDate", title: "Due Date", width: response[i].ColumnWidth, template: dueDateTemplate, groupHeaderTemplate: dueDateGroupTemplate,
                            editor: dateEditor, hidden: !response[i].IsVisible, attributes: { class: 'date-sm #= getDueDateClass(TaskDateDiff, TaskDateIsWeekend, DueDate) #'},
                            headerAttributes: { class: 'date-sm' }, filterable: { ui: filterDateEditor }
                        });
                        break;
                    case "TimeDue":                        
                        myColumns.push({ field: "TimeDue", title: "Time Due", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "AlertStateName":                        
                        myColumns.push({
                            field: "AlertStateName", title: "State", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: {
                                multi: true, extra: false, itemTemplate: filterCheckboxTemplate }
                            });
                        break;
                    case "Priority":                        
                        myColumns.push({
                            field: "Priority", title: "Priority", width: response[i].ColumnWidth, editor: priorityDropList, groupHeaderTemplate: priorityGroupTemplate, template: priorityTemplate, hidden: !response[i].IsVisible,
                            filterable: {
                                ui: function (element) {
                                    element.kendoDropDownList({
                                        dataSource: new kendo.data.DataSource({
                                            transport: {
                                                read: "Inbox/GetPriorities",
                                                dataType: "json"
                                            },
                                            schema: {
                                            model: {
                                                fields: {
                                                    Value: { type: "string" },
                                                    Description: { type: "string" }
                                                }
                                            }
                                        }
                                        }),
                                        optionLabel: "--Select--",
                                        dataTextField: "Description",
                                        dataValueField: "Value"
                                    });
                                },
                                extra: false,
                                operators: {
                                    string: {
                                        eq: "Is equal to",
                                        neq: "Is not equal to"
                                    }
                                }
                            }
                        });
                        break;
                    case "Category":                        
                        myColumns.push({
                            field: "Category", title: "Category", width: response[i].ColumnWidth, hidden: !response[i].IsVisible,
                            filterable: { multi: true, itemTemplate: filterCheckboxTemplate}
                            //filterable: {
                            //    ui: function (element) {
                            //        element.kendoDropDownList({
                            //            dataSource: new kendo.data.DataSource({
                            //                transport: {
                            //                    read: "Inbox/GetCategories",
                            //                    dataType: "json"
                            //                },
                            //                schema: {
                            //                    model: {
                            //                        fields: {
                            //                            CategoryName: { type: "string" },
                            //                            CategoryValue: { type: "string" }
                            //                        }
                            //                    }
                            //                }
                            //            }),
                            //            optionLabel: "--Select--",
                            //            dataTextField: "CategoryName",
                            //            dataValueField: "CategoryValue"
                            //        });
                            //    },
                            //    extra: true,
                            //    operators: {
                            //        string: {
                            //            eq: "Is equal to",
                            //            neq: "Is not equal to"
                            //        }
                            //    }
                            //}
                        });
                        break;
                    case "AssignedTo":
                        myColumns.push({ field: "AssignedTo", title: "Assigned To", width: response[i].ColumnWidth, template: functionAssignToTemplate, hidden: !response[i].IsVisible, filterable: { extra: false} });
                        break;
                    case "ClientName":
                        myColumns.push({ field: "ClientName", title: "Client", width: response[i].ColumnWidth, template: clientNameTemplate, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "Division":
                        myColumns.push({ field: "Division", title: "Division", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } } );
                        break;
                    case "Product":
                        myColumns.push({ field: "Product", title: "Product", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "CDP":
                        myColumns.push({ field: "CDP", title: "CDP Codes", sortable: true, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });                                                
                        break;
                    case "Job":                        
                        myColumns.push({ field: "Job", title: "Job", template: jobTemplate, groupHeaderTemplate: jobGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });                                          
                        break;
                    case "JobNumber":                        
                        myColumns.push({ field: "JobNumber", title: "Job Number", template: jobNumberTemplate, groupHeaderTemplate: jobNumberGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { ui: numericFilter, extra: false } });
                        break;
                    case "JobComponent":
                        myColumns.push({ field: "JobComponent", title: "Component", template: jobComponentTemplate, groupHeaderTemplate: jobComponentGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "ComponentNumber":
                        myColumns.push({ field: "ComponentNumber", title: "Component Number", template: componentNumberTemplate, groupHeaderTemplate: componentNumberGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "JobComponentDetailed":
                        myColumns.push({ field: "JobComponentDetailed", title: "Job Component", template: jobComponentDetailedTemplate, groupHeaderTemplate: jobComponentDetailedGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "JobAndComponentNumber":
                        myColumns.push({ field: "JobAndComponentNumber", title: "Job Component Number", template: jobAndComponentNumberTemplate, groupHeaderTemplate: jobAndComponentNumberGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "JobDescription":
                        myColumns.push({ field: "JobDescription", title: "Job Description", template: jobDescriptionTemplate, groupHeaderTemplate: jobDescriptionGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "ComponentDescription":
                        myColumns.push({ field: "ComponentDescription", title: "Component Description", template: componentDescriptionTemplate, groupHeaderTemplate: componentDescriptionGroupingTemplate, width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "ID":                        
                        myColumns.push({ field: "ID", title: "ID", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { ui: numericFilter, extra: false } });
                        break;
                    case "SoftwareVersion":                        
                        myColumns.push({ field: "SoftwareVersion", title: "Version", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { multi: true, itemTemplate: filterCheckboxTemplate } });
                        break;
                    case "SoftwareBuild":                        
                        myColumns.push({ field: "SoftwareBuild", title: "Build", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { multi: true, itemTemplate: filterCheckboxTemplate } });
                        break;
                    case "Type":                        
                        myColumns.push({ field: "Type", title: "Type", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { multi: true, itemTemplate: filterCheckboxTemplate } });
                        break;
                    //case "Level":                        
                    //        myColumns.push({ field: "Level", title: "Level", width: response[i].ColumnWidth, template: AlertLevelTemplate, hidden: !response[i].IsVisible, minResizableWidth: 50 });
                    //    break;
                    case "AE":                        
                        myColumns.push({ field: "AE", title: "AE", width: 150, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "PM":                        
                        myColumns.push({ field: "PM", title: "PM", width: 150, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "Office":                        
                        myColumns.push({ field: "Office", title: "Office", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "Campaign":                        
                        myColumns.push({ field: "Campaign", title: "Campaign", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "Template":                        
                        myColumns.push({ field: "Template", title: "Template", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { multi: true, itemTemplate: filterCheckboxTemplate } });
                        break;
                    case "TaskComments":
                        myColumns.push({ field: "TaskComments", title: "Task Comments", width: response[i].ColumnWidth, template: taskCommentTemplate, attributes: { style: "width: 275px; min-width: 275px; min-width: 275px" }, hidden: !response[i].IsVisible, filterable: { extra: false } });
                        break;
                    case "HoursAllowed":
                        myColumns.push({ field: "HoursAllowed", title: "Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { ui: numericFilter, extra: false } });
                        break; 
                    case "TempCompleteDate":
                        myColumns.push({
                            field: "TempCompleteDateNoTime", title: "Temp Complete Date", width: response[i].ColumnWidth, template: tempCompleteDateTemplate, groupHeaderTemplate: tempCompleteDateGroupTemplate,
                            hidden: !response[i].IsVisible, attributes: { class: 'date-sm' }, headerAttributes: { class: 'date-sm' },
                            filterable: { ui: filterDateEditor }
                        });
                        break;
                    case "CCEmployeeCodes":
                        myColumns.push({
                            field: "CCEmployeeCodes", title: "CC Recipient Codes", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, template: ccRecipientCodesTemplate, 
                            filterable: { extra: false }
                        });
                        break; 
                    case "CCEmployeeNames":
                        myColumns.push({
                            field: "CCEmployeeNames", title: "CC Recipient Names", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, template: ccRecipientNamesTemplate,
                            filterable: { extra: false }
                        });
                        break; 
                    case "Board":
                        myColumns.push({
                            field: "Board", title: "Board Name", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false }, groupHeaderTemplate: "#= 'Board: ' + value#"
                        });
                        break; 
                    case "BoardState":
                        myColumns.push({
                            field: "BoardState", title: "Board State", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false }, groupHeaderTemplate: "#= 'Board State: ' + value#"
                        });
                        break; 
                    case "SprintDescription":
                        myColumns.push({
                            field: "SprintDescription", title: "Sprint", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { extra: false }, groupHeaderTemplate: "#= 'Sprint: ' + value#"
                        });
                        break; 
                    case "SprintStartDate":
                        myColumns.push({
                            field: "SprintStartDate", title: "Sprint Start Date", width: response[i].ColumnWidth, template: sprintStartDateTemplate, groupHeaderTemplate: SprintStartDateGroupTemplate,
                            hidden: !response[i].IsVisible, attributes: { class: 'date-sm' }, headerAttributes: { class: 'date-sm' },
                            filterable: { ui: filterDateEditor }
                        });
                        break;
                    case "TaskStatusDescription":
                        myColumns.push({ title: "Task Status Description", field: "TaskStatusDescription", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, filterable: { multi: true, itemTemplate: filterCheckboxTemplate}, attributes: { style: "min-width: " + response[i].ColumnWidth + "px;" } });
                        break;
                };             

            }   
            columnSettingsReady = true;            
        },
        error: function (err) {
            showKendoAlert(err);            
        }        
    });

    
}

function ccRecipientCodesTemplate(dataItem) {
    if (dataItem.CCEmployeeCodes !== null) {
        return dataItem.CCEmployeeCodes;
    } else {
        return '';
    }
}

function ccRecipientCodesGroupTemplate(dataItem) {    
        return "CC Recipient Codes: " + dataItem.value;    
}

function ccRecipientNamesTemplate(dataItem) {
    let ccDisplay = '';
    let flag = false;
    let employeeNames = '';        
    let replaceCount = 0;    

    if (dataItem.CCEmployeeNames !== null) {
        employeeNames = dataItem.CCEmployeeNames;

        for (let i = 0; i < employeeNames.length; i++) {
            if (employeeNames.charAt(i) !== ',') {
                ccDisplay += employeeNames.charAt(i);
            } else {
                replaceCount++;

                if (replaceCount % 2 == 0) {
                    ccDisplay += '</BR>';
                } else {
                    ccDisplay += ', ';
                }
            }
        }

        return ccDisplay;
    } else {
        return '';
    }
}

function ccRecipientNamesGroupTemplate(dataItem) {
    return "CC Recipient Names: " + dataItem.value;
}

function lastUpdateTemplate(dataItem) {
    let lastUpdateDate = '';

    if (dataItem.LastUpdated !== null) {
        lastUpdateDate = kendo.toString(kendo.parseDate(dataItem.LastUpdated, 'yyyy-MM-dd'), 'MM/dd/yyyy hh:mm tt');
    }

    return lastUpdateDate;
}

function clientNameTemplate(dataItem) {
    let clientDisplay = "";

    //if (GetViewValue() === 'task') {
    //    if (!dataItem.ClientCode || !dataItem.Division || !dataItem.Product) {
    //        clientDisplay = "";
    //    }
    //    else {
    //        clientDisplay = `${dataItem.ClientCode}/${dataItem.Division}/${dataItem.Product}`;
    //    }
    //} else {
        if (dataItem.ClientName !== null) {
            clientDisplay = dataItem.ClientName;
        } else {
            clientDisplay = "";
        }        
    //}    

    return clientDisplay;
}

function detailHeaderTemplate(dataItem) {
    return `<div class='icon-background header-icon-color header-column-icon'><input class='icon-image header-column-icon' type='image' id='image' src='../Images/Icons/White/256/magnifying_glass.png' title='Search'></div>`
}
function statusHeaderTemplate(dataItem) {
    return `<div class='icon-background header-icon-color header-column-icon'><input class='icon-image header-column-icon' type='image' id='image' src='../Images/Icons/White/256/ok.png' title='Status'></div>`
}
function categoryIconHeaderTemplate(dataItem) {
    return "<div class='wv-badge header-icon-color'><span style='color:white;' title='Category Icon'>T</span></div>"
}
function taskStatusHeaderTemplate(dataItem) {
    return "<div class='wv-badge header-icon-color'><span style='color:white !important;' title='Task Status'>A</span></div>"
}
function documentsHeaderTemplate(dataItem) {
    return `<div class='icon-background header-icon-color header-column-icon'><input class='icon-image header-column-icon' type='image' id='image' src='../Images/Icons/White/256/documents_empty.png' title='Document(s)'></div>`
}
function taskFlagHeaderTemplate(dataItem) {
    return `<div class='icon-background header-icon-color header-column-icon'><input class='icon-image header-column-icon' type='image' id='image' src='../Images/Icons/White/256/signal_flag.png' title='Task Flag'></div>`
}
function addTimeHeaderTemplate(dataItem) {
    return `<div class='icon-background header-icon-color header-column-icon'><input class='icon-image header-column-icon' type='image' id='image' src='../Images/Icons/White/256/clock.png' title='Add Time'></div>`
}
function stopwatchHeaderTemplate(dataItem) {
    return `<div class='icon-background header-icon-color header-column-icon'><input class='icon-image header-column-icon' type='image' id='image' src='../Images/Icons/White/256/stopwatch.png' title='Stopwatch'></div>`
}


function lastUpdateGroupTemplate(dataItem) {
    if (dataItem.value !== null) {
        return "Last Updated: " + kendo.toString(kendo.parseDate(dataItem.value), "MM/dd/yyyy");
    } else {
        return "Last Updated:";
    }
}

function jobTemplate(dataItem) {
    let job = '';
    let jobNumber = '';
    let jobDescription = '';
    let jobView = '';
    
    if (dataItem.Job.length > 0) {
        jobNumber = ('000000' + dataItem.JobNumber).slice(-6);
        jobDescription = dataItem.JobDescription;

        job = `${jobNumber} - ${jobDescription}`;

        if (dataItem.ComponentNumber < 1) {
            if (job.length > 80) {
                jobView = `<span title='${job}'>${job.substr(0, 80)}...</span>`                
            } else {
                jobView = `<span title='${job}'>${job}</span>`
            }
        } else {
            if (job.length > 80) {
                jobView = `<a href='javascript: void (0);' cust-role='job_cell' title='${job}' onclick='onShowJobJacketClick(${dataItem.JobNumber},${dataItem.ComponentNumber})'>${job.substr(0, 80)}...</a>`
                //jobView = `<span title='${job}'>${job.substr(0, 80)}...</span>`;
            } else {
                jobView = `<a href='javascript: void (0);' cust-role='job_cell' title='${job}' onclick='onShowJobJacketClick(${dataItem.JobNumber},${dataItem.ComponentNumber})'>${job}</a>`
                //jobView = `<span title='${job}'>${job}</span>`;
            }
        }
        
    }

    return jobView;
}

function jobGroupingTemplate(dataItem) {
    let jobGrouping = 'Job: ';    

    if (dataItem.value.length > 0) {        
        jobGrouping += `${dataItem.value}`;        
    }

    return jobGrouping;
}

function jobNumberTemplate(dataItem) {
    let jobNumber = '';    

    if (dataItem.Job.length > 0) {
        jobNumber = ('000000' + dataItem.JobNumber).slice(-6);    
    }    

    return jobNumber;
}

function jobNumberGroupingTemplate(dataItem) {        
    let jobNumberView = 'Job Number: ';

    if (dataItem.value !== 0) {
        jobNumberView += ('000000' + dataItem.value).slice(-6);
    }       

    return jobNumberView;
}

function jobComponentTemplate(dataItem) {
    let jobComponentCombined = '';
    let jobComponentView = '';    
    
    if (dataItem.Job.length > 0) {        
        jobComponentCombined = dataItem.JobComponent;

        if (jobComponentCombined.length > 60) {            
            jobComponentView = `<span title='${jobComponentCombined}'>${jobComponentCombined.substr(0, 60)}...</span>`;
        } else {
            jobComponentView = `<span title='${jobComponentCombined}'>${jobComponentCombined}</span>`;            
        }
    }       

    return jobComponentView;    
}

function jobComponentGroupingTemplate(dataItem) {
    let componentView = 'Component: ';
    
    if (dataItem.value.length > 0) {                    
        componentView += dataItem.value;        
    }
        
    return componentView;
}

function componentNumberTemplate(dataItem) {
    let componentNumber = '';    

    if (dataItem.Job.length > 0) {
        componentNumber = ('000' + dataItem.ComponentNumber).slice(-3);                    
    }    

    return componentNumber;
}

function componentNumberGroupingTemplate(dataItem) {
    let componentNumber = 'Component Number: ';    
    
    componentNumber = ('000' + dataItem.value).slice(-3);    
    
    return componentNumber;
}

function jobComponentDetailedTemplate(dataItem) {
    let jobNumber = '';
    let jobDescription = '';
    let componentNumber = '';
    let componentDescription = '';
    let jobComponentCombined = '';
    let jobComponentDetailedView = '';

    if (dataItem.Job.length > 0){
        jobNumber = ('000000' + dataItem.JobNumber).slice(-6);
        jobDescription = dataItem.JobDescription;

        componentNumber = ('000' + dataItem.ComponentNumber).slice(-3);

        if (dataItem.ComponentDescription !== dataItem.JobDescription) {
            componentDescription = ' | ' + dataItem.ComponentDescription;
        }

        jobComponentCombined = `${jobNumber}/${componentNumber} - ${jobDescription} ${componentDescription}`;

        if (jobComponentCombined.length > 60) {
            jobComponentDetailedView = `<span title='${jobComponentCombined}'>${jobComponentCombined.substr(0, 60)}...</span>`;
        } else {
            jobComponentDetailedView = `<span title='${jobComponentCombined}'>${jobComponentCombined}</span>`;
        }    
    }
    

    return jobComponentDetailedView;
}

function jobComponentDetailedGroupingTemplate(dataItem) {    
    let jobComponentDetailedView = 'Job Component: ';

    if (dataItem.value.length > 0) {
        jobComponentDetailedView += dataItem.value;
    }               

    return jobComponentDetailedView;
}

function jobAndComponentNumberTemplate(dataItem) {    
    let jobAndComponentView = '';

    if (dataItem.Job.length > 0) {
        jobAndComponentView = dataItem.JobAndComponentNumber;    
    }    

    return jobAndComponentView;
}

function jobAndComponentNumberGroupingTemplate(dataItem) {    
    let jobAndComponentView = 'Job Component Number: ';    
    
    jobAndComponentView += dataItem.value;

    return jobAndComponentView;
}

function jobDescriptionTemplate(dataItem) {
    let jobDescription = '';
    let jobDescriptionView = '';

    if (dataItem.Job.length > 0) {
        if (dataItem.JobDescription !== null) {
            jobDescription = dataItem.JobDescription;
        }

        if (jobDescription.length > 60) {
            jobDescriptionView = `<span title='${jobDescription}'>${jobDescription.substr(0, 60)}...</span>`;
        } else {
            jobDescriptionView = `<span title='${jobDescription}'>${jobDescription}</span>`;
        }
    }    

    return jobDescriptionView;
}

function jobDescriptionGroupingTemplate(dataItem) {
    
    let jobDescriptionView = 'Job Description: ';    
        
    jobDescriptionView += dataItem.value;        

    return jobDescriptionView;
}

function componentDescriptionTemplate(dataItem) {
    let componentDescription = '';
    let componentDescriptionView = '';

    if (dataItem.Job.length > 0) {
        if (dataItem.ComponentDescription !== null) {
            componentDescription = dataItem.ComponentDescription;
        }

        if (componentDescription.length > 60) {
            componentDescriptionView = `<span title='${componentDescription}'>${componentDescription.substr(0, 60)}...</span>`;
        } else {
            componentDescriptionView = `<span title='${componentDescription}'>${componentDescription}</span>`;
        }
    }    

    return componentDescriptionView;
}

function componentDescriptionGroupingTemplate(dataItem) {    
    let componentDescriptionView = 'Component Description: ';
    
    componentDescriptionView += dataItem.value;    

    return componentDescriptionView;
}

function generatedGroupTemplate(dataItem) {
    if (dataItem.value !== null) {
        return "Generated: " + kendo.toString(kendo.parseDate(dataItem.value), "MM/dd/yyyy");
    } else {
        return "Generated:";
    }
}

function tempCompleteDateGroupTemplate(dataItem) {
    if (dataItem.value !== null) {
        return "Temp Complete Date: " + kendo.toString(kendo.parseDate(dataItem.value), "MM/dd/yyyy");
    } else {
        return "Temp Complete Date:";
    }
}

function startDateGroupTemplate(dataItem) {    
    if (dataItem.value !== null) {
        return "Start Date: " + kendo.toString(kendo.parseDate(dataItem.value), "MM/dd/yyyy");
    } else {
        return "Start Date:";
    }    
}

function dueDateGroupTemplate(dataItem) {
    if (dataItem.value !== null) {
        return "Due Date: " + kendo.toString(kendo.parseDate(dataItem.value), "MM/dd/yyyy");
    } else {
        return "Due Date:";
    }
}

function SprintStartDateGroupTemplate(dataItem) {
    if (dataItem.value !== null) {
        return "Sprint Start Date: " + kendo.toString(kendo.parseDate(dataItem.value), "MM/dd/yyyy");
    } else {
        return "Sprint Start Date:";
    }
}

function subjectTemplate(dataItem) {
    let SubjectView = '';
    let SubjectViewDetail = '';
    let SubjectParsed = '';  
    let SubjectTitle = '';

    if (dataItem.Subject) {
        SubjectParsed = dataItem.Subject.replace(/["']/g, "");
        SubjectView = dataItem.Subject;
    } else {
        SubjectParsed = '';
        SubjectView = '';
    }

    SubjectTitle = SubjectView;

    if (SubjectView !== null) {
        if (SubjectView.length > 80) {
            SubjectView = dataItem.Subject.substring(0, 80) + '...';
        }
    }    

    SubjectViewDetail = `<a href='javascript: void (0);' title='${SubjectTitle}' onclick='onShowDetailsClick(${dataItem.AlertID},${dataItem.AlertCategoryID},${dataItem.SprintID},"${SubjectParsed}")' cust-role='subject_cell'>${SubjectView}</a>`;

    return SubjectViewDetail
}

function cdpTemplate(dataItem) {
    let cdpText = '';    

    if (dataItem.ClientCode !== null && dataItem.DivisionCode !== null && dataItem.ProductCode !== null) {
        cdpText = dataItem.ClientCode + ' - ' + dataItem.DivisionCode + ' - ' + dataItem.ProductCode;
    } else {
        cdpText = "";
    }   

    return cdpText;
}

function categoryTemplate(dataItem) {
    let categoryText = '';
    let categoryDetail = '';
    let classText = '';

    classText = getClassByPriority(dataItem.Priority);
    categoryText = dataItem.Category.substr(0, 1);
    

    categoryDetail = `<div category-cell='${dataItem.AlertID}' class='wv-badge ${classText}' title='${dataItem.Category}'>${categoryText}</div>`

    return categoryDetail;
}

function onShowDetailsClick(ID, Category, SprintID, Subject) {
    if (gridDirty) {
        promptSave().done(() => showDetails(ID, Category, SprintID, Subject));
    } else {
        showDetails(ID, Category, SprintID, Subject);
    }
}

function showDetails(ID, Category, SprintID, Subject) {
    let droplist = $('#AAView').data('kendoDropDownList');
    
    let url = 'Desktop_AlertView?AlertID=' + ID + '&SprintID=' + SprintID + '&OpenedFrom=1';

    //if (isJobJacketView) {
    //    url += "&aamsat=" + AlertFilter.ShowAssignmentType;
    //}
    //console.log("showDetails???")
    OpenRadWindow(Subject, url);
    
}

function onShowJobJacketClick(JobNumber, ComponentNumber) {
    if (gridDirty) {
        promptSave().done(() => showJobJacket(JobNumber, ComponentNumber));
    } else {
        showJobJacket(JobNumber, ComponentNumber);
    }
}

function showJobJacket(JobNumber, ComponentNumber) {
    let url = ""

    url = `Content.aspx?From=DO&PageMode=Edit&JobNum=${JobNumber}&JobCompNum=${ComponentNumber}&NewComp=0&aamsat=${AlertFilter.ShowAssignmentType}`;
    OpenRadWindow('Job Jacket', url);
}

//function gridDataChanged(e) {    
//    console.log(e);
//    if (!pageFlag) {
//            gridDirty = true;
//            enableSave();
//    }

//}

function onAssignToClick(AssignToURL, AssignToTitle) {
    if (gridDirty) {
        promptSave().done(() => ProcessAssignToClick(AssignToURL, AssignToTitle));

    } else {
        ProcessAssignToClick(AssignToURL, AssignToTitle)
    }
}


function ProcessAssignToClick(AssignToURL, AssignToTitle) {
    var url = AssignToURL    
    openRadWindowWithEvents(AssignToTitle, url, 500, 500, false, function () {
        //reloadTaskList();        
        gridDirty = false;
        enableSave();
        saveGridChanges();
        refreshPage("");
    });
}

function openRadWindowWithEvents(title, url, windowHeight, windowWidth, modal, onCloseCallback) {    
    OpenRadWindow(title, url, windowHeight, windowWidth, modal, onCloseCallback);
}

function documentsTemplate(dataItem) {

    if (dataItem.AttachmentCount >= 1) {
        if (dataItem.AttachmentCount === 1) {
            return "<div class='icon-background background-color-sidebar standard-light-green'><input style='cursor:default !important;' class='icon-image' type='image' id='image' src='../Images/Icons/White/256/documents_empty.png' title='" + dataItem.AttachmentCount + " attachment'></div>";
        } else {
            return "<div class='icon-background background-color-sidebar standard-light-green'><input style='cursor:default !important;' class='icon-image' type='image' id='image' src='../Images/Icons/White/256/documents_empty.png' title='" + dataItem.AttachmentCount + " attachments'></div>";
        }

    } else {
        return "<div class='icon-background background-color-sidebar standard-pink'><input style='cursor:default !important;' class='icon-image' type='image' id='image' src='../Images/Icons/White/256/documents_empty.png' title='No attachments'></div>";
    }

}

function byTemplate(dataItem) {
    let byView = '';
    
    if (dataItem.UserName !== null && dataItem.UserName.length > 0) {
        byView = dataItem.UserName;
    }

    return byView;
}

//function taskClientTemplate() {

//    return `${dataItem.ClientCode}/${dataItem.DivisionCode}/${dataItem.ProductCode}`;
//}

function startDateTemplate(dataItem) {    
    
    let startDateFormatted = '';
    if (dataItem.StartDate) {
        startDateFormatted = `<div startDate-cell='${dataItem.AlertID}' title='${kendo.toString(kendo.parseDate(dataItem.StartDate), "MM/dd/yyyy")}'>${kendo.toString(kendo.parseDate(dataItem.StartDate), "MM/dd/yyyy")}</div>`;
    } else {
        startDateFormatted = `<div startDate-cell='${dataItem.AlertID}'></div>`;        
    }   

    return startDateFormatted;
}

function tempCompleteDateTemplate(dataItem) {
    let tempCompDate = ''
    if (dataItem.TempCompleteDate) {
        tempCompDate = kendo.toString(kendo.parseDate(dataItem.TempCompleteDate), "MM/dd/yyyy");
    } else {
        tempCompDate = '';
    }

    return tempCompDate;
}

function sprintStartDateTemplate(dataItem) {
    let sprintStartDate = ''
    if (dataItem.SprintStartDate) {
        sprintStartDate = kendo.toString(kendo.parseDate(dataItem.SprintStartDate), "MM/dd/yyyy");
    } else {
        sprintStartDate = '';
    }

    return sprintStartDate;
}

function taskFlagTemplate(dataItem) {
    let taskFlagDetail = '';
    let dueDate = '';    
    dueDate = kendo.toString(kendo.parseDate(dataItem.DueDate), "MM/dd/yyyy");    

    if (dataItem.DueDate !== null  && dataItem.Category === "Task") {
        taskFlagDetail = `<div taskflag-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${getDueDateClassFlag(dataItem.TaskDateDiff, dataItem.TaskDateIsWeekend, dataItem.DueDate)}'><input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/signal_flag.png' style='cursor:default !important;' title='${getDueDateTitle(dataItem.TaskDateDiff, dueDate, dataItem.TaskDateIsWeekend, dataItem.DueDate)}'></div>`
    } else {
        taskFlagDetail = "";
    }


    return taskFlagDetail;
}

function taskTempCompleteTemplate(dataItem) {
    let taskTempCompleteDetail = '';
    let taskIcon = '';
    let taskTitle = '';
    let taskClass = '';

    if (dataItem.IsMyTaskTempComplete && !dataItem.IsOwnerAssignmentAlert) {
        taskIcon = '../Images/Icons/white/256/delete.png';
        taskTitle = 'Mark Task Not Temp complete'
        taskClass = 'standard-pink';
    } else if (dataItem.IsCC) {
            taskIcon = '../Images/Icons/white/256/garbage.png';
            taskTitle = 'Dismiss Alert'
            taskClass = 'standard-light-green';        
    } else {
        taskIcon = '../Images/Icons/White/256/ok.png';
        taskTitle = 'Mark Task Temp Complete';
        taskClass = 'standard-light-green';
    }

    if (!dataItem.IsMyTask) {
        return '';
    }

    ///dueDate = kendo.toString(kendo.parseDate(dataItem.DueDate), "MM/dd/yyyy");

    taskTempCompleteDetail = `<div taskTempComp-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${taskClass}'>
                            <input class='icon-image' type='image' id='image' src='${taskIcon}' title='${taskTitle}' 
                            onclick='processTempComplete(${dataItem.IsMyTaskTempComplete}, ${dataItem.JobNumber}, ${dataItem.ComponentNumber}, ${dataItem.TaskSequenceNumber});'></div>`;

    return taskTempCompleteDetail;
}

function processTempComplete(isTaskTempComplete, jobNumber, componentNumber, sequenceNumber) {
    let data = {
        IsTaskTempComplete: isTaskTempComplete,
        JobNumber: jobNumber,
        JobComponentNumber: componentNumber,
        TaskSequenceNumber: sequenceNumber
    };

    $.ajax({
        type: "POST",
        url: "Inbox/ProcessTempComplete",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response) {
            if (response.Message.length > 0) {
                showKendoAlert(response.Message);
            }

            let grid = $("#aagrid").data("kendoGrid");
            grid.dataSource.read();
        },
        error: function (response) {
            console.log("An error occurred during update: " + response.message);
            //showKendoAlert(Message);
        }
    });
}

function dueDateTemplate(dataItem) {
    let dueDate = '';
    let dueDateFormatted = '';
    let taskClass = '';

    if (dataItem.DueDate) {
        dueDate = kendo.toString(kendo.parseDate(dataItem.DueDate), "MM/dd/yyyy");

        //apply special formatting for tasks            
        if (dataItem.AlertCategoryID == 71) {

            dueDateFormatted = `<div taskDueDate-cell='${dataItem.AlertID}' title='${getDueDateTitle(dataItem.TaskDateDiff, dueDate, dataItem.TaskDateIsWeekend, dataItem.DueDate)}'>${dueDate}</div>`;

        } else {
            //dueDateFormatted = dueDate;
            dueDateFormatted = `<div taskDueDate-cell='${dataItem.AlertID}' title='${getDueDateTitle(dataItem.TaskDateDiff, dueDate, dataItem.TaskDateIsWeekend, dataItem.DueDate)}'>${dueDate}</div>`;
        }
    } else {
        dueDateFormatted = `<div taskDueDate-cell='${dataItem.AlertID}'></div>`;
    }

    return dueDateFormatted;
}

function getDueDateTitle(TaskDateDiff, TaskDueDate, IsWeekendDate, DueDate) {
    let taskTitle = '';    

    if (DueDate !== null) {
        if (TaskDateDiff == 0) {
            taskTitle = 'Task is due today!';
        } else if (TaskDateDiff < 0) {
            taskTitle = `Task is overdue ${TaskDateDiff * -1} day(s) on ${TaskDueDate}`;
        } else if (TaskDateDiff > 0 && IsWeekendDate) {
            taskTitle = 'Due date is on a weekend!';
        } else {
            taskTitle = `Due in ${TaskDateDiff} days(s) on ${TaskDueDate}`;
        }
    }    

    return taskTitle;
}

function getDueDateClass(TaskDateDiff, IsWeekendDate, DueDate) {
    let taskClass = '';          
    
    if (DueDate !== null) {
        if (DueDate.length < 1) {
            return taskClass
        }
        
        if (TaskDateDiff < 0) {
            taskClass = 'aam-standard-light-pink';            
        } else if (TaskDateDiff == 0) {
            taskClass = 'aam-standard-light-orange';
        } else if (IsWeekendDate && TaskDateDiff > 0) {
            taskClass = 'aam-standard-light-grey';
        } else if (TaskDateDiff > 0 && TaskDateDiff <= 7) {
            taskClass = 'aam-projected';
        } else {
            taskClass = 'aam-standard-light-green';
        }
    }    

    return taskClass;
}


function getDueDateClassFlag(TaskDateDiff, IsWeekendDate, DueDate) {
    let taskClass = '';

    if (DueDate !== null) {
        if (DueDate.length < 1) {
            return taskClass
        }

        if (TaskDateDiff < 0) {
            taskClass = 'standard-pink';
        } else if (TaskDateDiff == 0) {
            taskClass = 'standard-light-orange';
        } else if (IsWeekendDate && TaskDateDiff > 0) {
            taskClass = 'standard-light-grey';
        } else if (TaskDateDiff > 0 && TaskDateDiff <= 7) {
            taskClass = 'projected';
        } else {
            taskClass = 'standard-light-green';
        }
    }

    return taskClass;
}

function detailsTemplate(dataItem) {
    let divDetail = "";
    let title = getDetailTitleDescriptionByPriority(dataItem.Priority);
    let classText = getClassByPriority(dataItem.Priority);
    let subjectParsed = "";

    if (dataItem.Subject) {
        subjectParsed = dataItem.Subject.replace(/["']/g, "");
    } else {
        subjectParsed = "";
    }

    if (dataItem.IsRead == 1) {
        divDetail = `<div priority-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${classText}'><input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/magnifying_glass.png' onclick='onShowDetailsClick(${dataItem.AlertID},${dataItem.AlertCategoryID},${dataItem.SprintID},"${subjectParsed}")' title='${title}'></div>`
    } else {
        divDetail = `<div priority-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${classText}'><input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/magnifying_glass.png' onclick='onShowDetailsClick(${dataItem.AlertID},${dataItem.AlertCategoryID},${dataItem.SprintID},"${subjectParsed}")' title='${title}'></div>`
    }

    return divDetail;
}

function statusTemplate(dataItem) {

    let currentState = "";
    let stateDetail = {};
    let canComplete = 0;
    let isTask = false;
    let statusDetail = '';

    currentState = getStatusState(dataItem);    

    if (dataItem.Category == "Task" && !dataItem.IsOwnerAssignmentAlert && GetViewValue() != "dismissed") {
        statusDetail = taskTempCompleteTemplate(dataItem);
        //} else if () {
        //    canComplete = 3;

        //    stateDetail = getStatusDetail(currentState, dataItem.Category);     
        //    statusDetail = `<div class='icon-background background-color-sidebar ${stateDetail.class}'><input class='icon-image' type='image' id='image' 
        //                src='${stateDetail.icon}' onclick="alertAction(${dataItem.AlertID},${dataItem.SprintID},'${dataItem.Category}', ${canComplete})" 
        //                title='${stateDetail.title}'></div>`;
        //    //statusDetail = taskTempCompleteTemplate(dataItem);
    } else {        
        if (dataItem.Category == "Task" && GetViewValue() == "dismissed" && currentState == "reOpen") {            
            canComplete = 3;                        
        } else if (AlertFilter.ShowAssignmentType === "myalertsandassignments") {
            if ((dataItem.IsMyAssignment === true || dataItem.IsMyTask === true || dataItem.IsTaskAssignment === true) && dataItem.IsOwnerAssignmentAlert === false) {

                    canComplete = 1;
            
            }            
        } else if (AlertFilter.ShowAssignmentType === "myalertassignments") {
            
                canComplete = 1;
            
        } else if (AlertFilter.ShowAssignmentType === "allalertassignments") {
            if ((dataItem.IsMyAssignment === true || dataItem.IsMyTask === true)) {
                
                    canComplete = 1;
                
            }
        } else if (dataItem.IsDraft === true) {
            canComplete = 2;
        } else {
            canComplete = 0;
        }                      

        if (AlertFilter.IsClientPortal == "True" && (currentState == "complete" || currentState == "reOpen")) {
            currentState = "dismiss";
        }

        stateDetail = getStatusDetail(currentState, dataItem.Category);  

        if (canComplete == 3) {            
            stateDetail.title = "Re-open Assignment";
        }

        if (stateDetail.icon == '') {
            statusDetail = '';
        }

        statusDetail = `<div class='icon-background background-color-sidebar ${stateDetail.class}'><input class='icon-image' type='image' id='image' 
                    src='${stateDetail.icon}' onclick="alertAction(${dataItem.AlertID},${dataItem.SprintID},'${dataItem.Category}', ${canComplete})" 
                    title='${stateDetail.title}'></div>`;
    }

    return statusDetail;
}

function taskTemplate(dataItem) {
    let taskStatus = dataItem.TaskStatus;
    let priority = dataItem.Priority;
    let taskClass = "";
    let priorityTooltip = "";
    let divDetail = "";
    let alertID = dataItem.AlertID;
    let fontColor = "";

    categoryText = dataItem.Category.substr(0, 1);

    if (dataItem.IsTaskAssignment == true) {

        if (taskStatus == null) {
            taskStatus = 'P';            
        }

        if (taskStatus.length > 0) {

            if (taskStatus == 'A') {
                taskClass = 'standard-light-green';
                //taskIcon = '../Images/Icons/White/256/progress_bar.png';
            }
            else {
                //taskIcon = '../Images/Icons/Grey/256/progress_bar.png';
                taskClass = 'projected';
            }
        }            

        if (taskClass == 'projected') {
            fontColor = "color: #000;";
        }
        priorityTooltip = getTaskTitleDescription(taskStatus, priority);

        //divDetail = `<div task-cell='${alertID}' class='icon-background ${taskClass}'>`;
        //divDetail += `<input class='icon-image' style='cursor:default !important;' type='image' id='image'`;

        //divDetail += `src = '${taskIcon}' title = '${priorityTooltip}' ></div >`;

        divDetail = `<div task-cell='${alertID}' class='wv-badge ${taskClass}' title='${priorityTooltip}' style='${fontColor}'>${taskStatus}</div>`;
        
    }

    return divDetail;
}

function taskCommentTemplate(dataItem) {
    let TaskCommentView = ''

    TaskCommentView = dataItem.TaskComments;

    if (TaskCommentView.length > 40) {
        TaskCommentView = dataItem.TaskComments.substring(0, 40) + '...';
    }

    return "<div title='" + dataItem.TaskComments + "'>" + TaskCommentView + "</div>"    

}



function functionAssignToTemplate(dataItem) {       
    let response = "";
    if (dataItem.AssignedTo.length == 0) {
        response = "";
    } else {
        let title = "";
        let jscript = "";
        if (AlertFilter.IsClientPortal == "False" && !dataItem.IsStandardAlert) {

            if (dataItem.AssignedToLinkAddress.includes("TrafficSchedule_TaskEmployees")) {

                title = "Employees";

            } else if (dataItem.AssignedToLinkAddress.includes("Desktop_Reassign")) {

                title = "Assignment";

            } else {

                title = dataItem.Subject;

            }

            if (dataItem && dataItem.AlertCategoryID && dataItem.AlertCategoryID == 79) {

                try {

                    try {
                        if (!dataItem.SprintID || dataItem.SprintID == undefined || dataItem.SprintID == null) {
                            dataItem.SprintID = 0;
                        }
                    } catch (e) {
                    }
                    var u = "Desktop_AlertView?AlertID=" + dataItem.AlertID + "&SprintID=" + dataItem.SprintID + "&OpenedFrom=1";
                    jscript = "OpenRadWindow('" + dataItem.Subject + "', '" + u + "')";

                } catch (e) {
                    console.log("error?", e);
                }

            } else {

                jscript = "onAssignToClick('" + dataItem.AssignedToLinkAddress + "', '" + title + "')";

            }

            response = '<a href="javascript:void(0);" title="' + dataItem.AssignedToTitle + '" onclick="' + jscript + '" cust-role="assigned_to_cell">' + dataItem.AssignedTo + '</a>';

        } else {

            response = dataItem.AssignedTo;

        }      
    }

    return response;

}

//function AlertLevelTemplate(dataItem) {

//    let response = ''

//    if (dataItem.Level == null || dataItem.Level.length <= 0) {
//        response = ''
//    } else {
//        if (dataItem.AlertLevelText == null || dataItem.AlertLevelText.length <= 0) {
//            response = "<span title='No Description Available'>" + dataItem.Level + "</span>";
//        } else {
//            response = "<span title='" + dataItem.AlertLevelText + "'>" + dataItem.Level + "</span>";
//        }
//    }
//    return response;
//}

function priorityTemplate(dataItem) {
    //if (dataItem.GroupPriority) {
    //    if (dataItem.GroupPriority == "Normal" || dataItem.GroupPriority == 3) {
    //        return "--"
    //    } else if (dataItem.GroupPriority == "Highest" || dataItem.GroupPriority == 1) {
    //        return "HH"
    //    } else if (dataItem.GroupPriority == "High" || dataItem.GroupPriority == 2) {
    //        return "H"
    //    } else if (dataItem.GroupPriority == "Low" || dataItem.GroupPriority == 4) {
    //        return "L"
    //    } else if (dataItem.GroupPriority == "Lowest" || dataItem.GroupPriority == 5) {
    //        return "LL"
    //    } else {
    //        return '';
    //    }
    //}
    if (dataItem.Priority) {
        if (dataItem.Priority == 3) {
                return "--"
        } else if (dataItem.Priority == 1) {
                return "HH"
        } else if (dataItem.Priority == 2) {
                return "H"
        } else if (dataItem.Priority == 4) {
                return "L"
        } else if (dataItem.Priority == 5) {
            return "LL"
        } else {
            return '';
        }
    }

    return '';    
}

function priorityGroupTemplate(dataItem) {    
    if (dataItem.value) {
        if (dataItem.value == 3) {
            return "Priority: Normal"
        } else if (dataItem.value == 1) {
            return "Priority: Highest"
        } else if (dataItem.value == 2) {
            return "Priority: High"
        } else if (dataItem.value == 4) {
            return "Priority: Low"
        } else if (dataItem.value == 5) {
            return "Priority: Lowest"
        } else {
            return '';
        }
    }

    return ''; 
}

function getStatusDetail(state, category) {
    let statusDetail = {
        title: "",
        icon: "",
        class: "",
        enabled: true
    };

    switch (state) {
        case "dismiss":
            statusDetail.title = "Dismiss Alert";
            statusDetail.icon = "../Images/Icons/White/256/garbage.png";
            statusDetail.class = "standard-light-green";
            break;
        case "undismiss":
            statusDetail.title = "Un-dismiss Alert";
            statusDetail.icon = "../Images/Icons/White/256/garbage_full.png";
            statusDetail.class = "standard-amber";
            break;
        case "complete":
            if (category == "Task") {
                statusDetail.title = "Mark Not Complete";
                statusDetail.icon = "../Images/Icons/White/256/delete.png";
                statusDetail.class = "standard-pink";
            } else {
                statusDetail.title = "Complete";
                statusDetail.icon = "../Images/Icons/White/256/ok.png";
                statusDetail.class = "standard-light-green";
            }

            break;
        case "reOpen":
            if (category == "Task") {
                statusDetail.title = "Not Complete";
                statusDetail.icon = "../Images/Icons/White/256/check.png";                
                statusDetail.class = "standard-amber";//NS: this was previously empty
            } else {
                statusDetail.title = "Re-open Assignment";
                statusDetail.icon = "../Images/Icons/White/256/ok.png";
                statusDetail.class = "standard-amber";
            }

            break;
        case "deleteDraft":
            statusDetail.title = "Delete Draft";
            statusDetail.icon = "../Images/Icons/White/256/delete.png";
            statusDetail.class = "standard-pink";
            break;
        case "hide":
            statusDetail.title = "";
            statusDetail.icon = "../Images/spacer.gif";
            statusDetail.class = "display-none";
            statusDetail.enabled = false;
            break;
        default:
            break;
    }

    return statusDetail;
}

function getStatusState(dataItem) {
    let status = "";
    //let openAssignment = false;
    let state = "";

    if (isJobJacketView) {
        switch (AlertFilter.ShowAssignmentType) {
            case "myalerts":
                if (dataItem.IsDismissed) {
                    state = "undismiss";
                } else {
                    state = "dismiss";
                }
                break;
            case "myalertassignments":                
                if (dataItem.Category == "task") {
                    if (dataItem.IsMyTaskTempComplete) {
                        state = "reOpen";
                    } else {
                        state = "complete";
                    }
                } else {
                    if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() == "completed" || (dataItem.IsMyAssignment && dataItem.AssignedTo.toLowerCase() == "completed")) {
                        state = "reOpen";
                    } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() !== "completed" || (dataItem.IsMyAssignment && dataItem.AssignedTo.toLowerCase() !== "completed" && !dataItem.IsMyAssignmentCompleted)) {
                        state = "complete";
                    } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() !== "completed" || (dataItem.IsMyAssignment && dataItem.AssignedTo.toLowerCase() !== "completed" && dataItem.IsMyAssignmentCompleted)) {
                        state = "reOpen";
                    } else {
                        state = "hide";
                    }
                }
                break;
            case "myalertsandassignments":

                if ((!dataItem.IsRouted && dataItem.Category !== "task" && !dataItem.IsWorkItem) || (dataItem.IsCC && dataItem.IsOwnerAssignmentAlert === true)) {
                    if (dataItem.IsDismissed) {
                        state = "undismiss";
                    } else {
                        state = "dismiss";
                    }
                } else {
                    if (dataItem.Category == "task") {
                        if (dataItem.IsMyTaskTempComplete) {
                            state = "reOpen";
                        } else {
                            state = "complete";
                        }
                    } else {
                        if (dataItem.AssignedToEmpCode == _EmployeeCode || (dataItem.IsMyAssignment && !dataItem.IsMyAssignmentCompleted)) {
                            state = "complete";
                        } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() == "completed" || (dataItem.IsMyAssignment && dataItem.AssignedTo.toLowerCase() == "completed")) { 
                            state = "reOpen";
                        } else if (dataItem.IsCC) {
                            state = "dismiss";
                        } else {
                            state = "hide";
                        }
                    }
                }
                break;
            case "allalertassignments":
                if (dataItem.AssignedToEmpCode == _EmployeeCode || (dataItem.IsMyAssignment && !dataItem.IsMyAssignmentCompleted)) {
                    state = "complete";
                } else if (dataItem.AssignedToEmpCode == _EmployeeCode || (dataItem.IsMyAssignment && dataItem.IsMyAssignmentCompleted)) {
                    state = "reOpen";
                } else {
                    state = "hide";
                }
                break;
        }

    } else {
        if (AlertFilter.ShowAssignmentType == "unassigned") {
            state = "hide";
        } else {
            
            switch (GetViewValue()) {                
                case "inbox":
                    switch (AlertFilter.ShowAssignmentType) {
                        case "myalerts":
                            state = "dismiss";
                            break;
                        case "myalertassignments":
                            if (dataItem.Category == "task") {
                                if (dataItem.IsMyTaskTempComplete) {
                                    state = "reOpen";
                                } else {
                                    state = "complete";
                                }
                            } else {
                                state = "complete";
                            }
                            break;
                        case "myalertsandassignments":

                            if ((!dataItem.IsRouted && dataItem.Category !== "task" && !dataItem.IsWorkItem) || (dataItem.IsCC && dataItem.IsOwnerAssignmentAlert === true)) {
                                state = "dismiss";
                            } else {
                                if (dataItem.Category == "task") {
                                    if (dataItem.IsMyTaskTempComplete) {
                                        state = "reOpen";
                                    } else {
                                        state = "complete";
                                    }
                                } else {
                                    if (dataItem.AssignedToEmpCode == _EmployeeCode || dataItem.IsMyAssignment) {
                                        state = "complete";
                                    //} else if (dataItem.IsWorkItem && !dataItem.IsOwnerAssignmentAlert) {
                                    //    state = "complete";
                                    } else {
                                        state = "dismiss";
                                    }
                                }
                            }
                            break;
                        case "allalertassignments":
                            if (dataItem.AssignedToEmpCode == _EmployeeCode || (dataItem.IsMyAssignment && !dataItem.IsMyAssignmentCompleted)) {
                                state = "complete";
                            } else {
                                state = "hide";
                            }
                            break;
                    }
                    break;
                case "dismissed":                    
                    switch (AlertFilter.ShowAssignmentType) {
                        case "myalerts":
                            state = "undismiss";
                            break;
                        case "myalertassignments":
                            state = "reOpen";
                            break;
                        case "myalertsandassignments":
                            if (dataItem.IsDismissed) {
                                state = "undismiss";
                            } else {
                                if (dataItem.AssignedToEmpCode == _EmployeeCode || dataItem.IsMyAssignment) {
                                    
                                        state = "reOpen";
                                    
                                } else if (dataItem.IsWorkItem) {
                                    state = "reOpen";
                                } else {
                                    state = "undismiss";
                                }
                            }
                            break;
                        case "allalertassignments":
                            if (dataItem.AssignedToEmpCode == _EmployeeCode && (dataItem.IsCurrentAssignee || dataItem.AssignedTo.toLowerCase() == "completed")) {
                                state = "reOpen";
                            } else {
                                state = "hide";
                            }
                            break;
                    }
                    break;
                case "all":
                    //if (dataItem.IsRouted) {
                    //    if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() == "completed") {
                    //        state = "reOpen";
                    //    } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() !== "completed") {
                    //        state = "complete";
                    //    } else {
                    //        state = "hide";
                    //    }
                    //} else {
                    //    if (dataItem.IsDismissed) {
                    //        state = "undismiss";
                    //    } else {
                    //        state = "dismiss";
                    //    }
                    //}

                    switch (AlertFilter.ShowAssignmentType) {
                        case "myalerts":
                            if (dataItem.IsDismissed) {
                                state = "undismiss";
                            } else {
                                state = "dismiss";
                            }
                            break;
                        case "myalertassignments":
                            if (dataItem.IsRouted) {
                                if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() == "completed") {
                                    state = "reOpen";
                                } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() !== "completed") {
                                    state = "complete";
                                } else {
                                    state = "hide";
                                }
                            }
                            break;
                        case "myalertsandassignments":
                            if (dataItem.IsRouted) {
                                if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() == "completed") {
                                    state = "reOpen";
                                } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() !== "completed") {
                                    state = "complete";
                                } else {
                                    state = "hide";
                                }
                            } else {
                                if (dataItem.IsDismissed) {
                                    state = "undismiss";
                                } else {
                                    state = "dismiss";
                                }
                            }
                            break;
                        case "allalertassignments":
                            if (dataItem.AssignedToEmpCode == _EmployeeCode && (dataItem.IsCurrentAssignee || dataItem.AssignedTo.toLowerCase() == "completed")) {
                                state = "reOpen";
                            } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() !== "completed") {
                                state = "complete";
                            } else {
                                state = "hide";
                            }
                            break;
                    }

                    break;
                case "drafts":
                    state = "deleteDraft";
                    break;
                case "task":
                    switch (AlertFilter.ShowAssignmentType) {
                        case "myalerts":
                            state = "dismiss";
                            break;
                        case "myalertassignments":
                            if (dataItem.Category == "task") {
                                if (dataItem.IsMyTaskTempComplete) {
                                    state = "reOpen";
                                } else {
                                    state = "complete";
                                }
                            } else {
                                state = "complete";
                            }
                            break;
                        case "myalertsandassignments":

                            if ((!dataItem.IsRouted && dataItem.Category !== "task" && !dataItem.IsWorkItem) || (dataItem.IsCC && dataItem.IsOwnerAssignmentAlert === true)) {
                                state = "dismiss";
                            } else {
                                if (dataItem.Category == "task") {
                                    if (dataItem.IsMyTaskTempComplete) {
                                        state = "reOpen";
                                    } else {
                                        state = "complete";
                                    }
                                } else {
                                    if (dataItem.AssignedToEmpCode == _EmployeeCode || dataItem.IsMyAssignment) {
                                        state = "complete";
                                        //} else if (dataItem.IsWorkItem && !dataItem.IsOwnerAssignmentAlert) {
                                        //    state = "complete";
                                    } else {
                                        state = "dismiss";
                                    }
                                }
                            }
                            break;
                        case "allalertassignments":
                            if (dataItem.AssignedToEmpCode == _EmployeeCode || (dataItem.IsMyAssignment && !dataItem.IsMyAssignmentCompleted)) {
                                state = "complete";
                            } else {
                                state = "hide";
                            }
                            break;
                    }
                    break;
                    
            }

        }
    }

    return state;
}


function addTimeTemplate(dataItem) {
    let addTimeDetail = '';
    let windowTitle = 'Add Time';

    if (dataItem.Category == "Task" || (dataItem.JobNumber > 0 && dataItem.ComponentNumber > 0)) {
        addTimeDetail = `<div stopwatch-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar standard-light-green'>
                            <input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/clock.png' title='Add Time' 
                            onclick="processAddTimeClick(${dataItem.AlertID}, ${dataItem.JobNumber}, ${dataItem.ComponentNumber}, ${dataItem.TaskSequenceNumber});"></div>`;
    }

    return addTimeDetail;
}

function processAddTimeClick(AlertID, JobNumber, ComponentNumber, TaskSequenceNumber) {

    let windowURL = `Employee/Timesheet/Entry?a=${AlertID}&emp=${_EmployeeCode}&j=${JobNumber}&jc=${ComponentNumber}&s=${TaskSequenceNumber}`;
    let windowTitle = 'Add Time';

    openRadWindowWithEvents(windowTitle, windowURL, 600, 600, false);
}

function stopwatchTemplate(dataItem) {
    let stopWatchDetail = '';

    if (dataItem.Category == "Task" || (dataItem.JobNumber > 0 && dataItem.ComponentNumber > 0)) {
        stopWatchDetail = `<div stopwatch-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar standard-light-green'>
                            <input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/stopwatch.png' title='Click to start Stopwatch' 
                            onclick="processStopwatchClick(${dataItem.AlertID}, ${dataItem.JobNumber}, ${dataItem.ComponentNumber}, ${dataItem.TaskSequenceNumber});"></div>`;
    } else {
        stopWatchDetail = '';
    }

    return stopWatchDetail;
}

function processStopwatchClick(AlertID, JobNumber, ComponentNumber, TaskSequenceNumber) {    

    if (TaskSequenceNumber == null) {
        TaskSequenceNumber = -1;
    }

    let data = {
        EmployeeCode: _EmployeeCode
    };


    $.post({
        url: "../Employee/Timesheet/HasStopwatch",
        dataType: "json",
        data: JSON.stringify(data),
    }).always(function (result) {
        if (result) {
            //console.log("stopwatch result", result);
            if (result.StopwatchIsRunning === true) {
                showKendoConfirm("There is a stopwatch already running.\nStop it and start a new stopwatch?")
                    .done(function () {
                        $.post({
                            url: "../Employee/Timesheet/StopStopwatch",
                            dataType: "json",
                            data: data
                        }).always(function (result) {
                            if (result) {
                                //console.log("stop?", result);
                                startStopWatch(AlertID, JobNumber, ComponentNumber, TaskSequenceNumber);
                            }
                        });
                    })
                    .fail(function () {
                        return false;
                    });
            } else {
                startStopWatch(AlertID, JobNumber, ComponentNumber, TaskSequenceNumber);
            }
        }
    });
}

function startStopWatch(AlertID, JobNumber, ComponentNumber, TaskSequenceNumber) {
    let windowTitle = 'Timesheet Stopwatch';
    let windowURL = 'Timesheet_Stopwatch.aspx';

    let data = {
        AlertID: AlertID,
        JobNumber: JobNumber,
        JobComponentNumber: ComponentNumber,
        TaskSequenceNumber: TaskSequenceNumber
    };    

    $.ajax({
        type: "POST",
        url: "Inbox/StopWatchStart",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response) {
            if (response.OpenStopWatch) {
                openRadWindowWithEvents(windowTitle, windowURL, 475, 500, false);
            } else {
                showKendoAlert(response.ErrorMessage);
            }
        },
        error: function (response) {
            showKendoAlert("An error occurred while attempting to start the stopwatch, please contact support.");
        }
    });
}

function columnReset(operationType) {        
    ProcessColumnReset(operationType);
}

function CheckColumnSettingsReadyFlagAndReloadGrid() {
    if (columnSettingsReady === false) {
        setTimeout(CheckColumnSettingsReadyFlagAndReloadGrid, 250);
    } else {
        ReloadGrid();
    }
}

function BuildAAViewDropDown() {
    if (userViewSettingsReady === false) {
        setTimeout(BuildAAViewDropDown, 250);
    } else {
        $("#AAView").kendoDropDownList({
            //autoBind: false,
            dataTextField: "Description",
            dataValueField: "Code",
            dataSource: new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "Inbox/GetFolders",
                        dataType: "json"
                    }
                }
            }),
            dataBound: function (e) {
                $("#AAView").data("kendoDropDownList").select(GetViewIndex(UserViewSettings.InboxType))
            },
            change: function (e) {
                onInboxViewChange();
            }
        }).data('kendoDropDownList');
    }
}



function ProcessColumnReset(operationType) {        
    let gridName = '';
    let url = '';

    columnSettingsReady = false;

    gridName = GetGridView();
    if (operationType === "width") {
        url = "Inbox/ResetGridColumnWidths";
    } else {
        url = "Inbox/ResetGridColumnOrder";
    }

    $.ajax({
        type: "POST",
        url: url,
        data: { GridName: gridName },        
        success: function (response) {
            closeAllPopups();
            DestroyGrid();
            
            LoadUserColumnSettings();

            SetDateFilters(GetViewValue());

            CheckColumnSettingsReadyFlagAndReloadGrid();
            //ReloadGrid();
        },
        error: function (response) {
            closeAllPopups();
            showKendoAlert(`An error occurred while resetting the grid column ${operationType}, please contact support.`);
        }
    });
}


