//
function EUGrid_SubscribeToShared() {
    let grid = $("#utilizationgrid").data("kendoGrid");

    grid.bind("sort", function (e) {
        let element = $("th[class*=static-]")
        element.removeClass("static-sort-desc");
        element.removeClass("static-sort-asc");

        _sortedDirection = e.sort.dir;

        _sortedField = e.sender.columns.find(column => {
            return column.field === e.sort.field
        }).title;
    });

    

    grid.bind("cellClose", function (e) {
        $("#utilizationgrid").data("kendoGrid").refresh();
    });

    grid.bind("filterMenuInit", function (e) {
        //remove the focus from the column header
        let popup = e.container.data("kendoPopup");
        popup.bind("close", function (e) {
            $("#utilizationgrid").focus();
        });

        var filterMultiCheck = this.thead.find("[data-field=" + e.field + "]").data("kendoFilterMultiCheck");

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
            && (replaceColumnTitle != "" && reorderedColumn.name != "")) {
            staticColumnMoveAllowed = true;
        }

        //Icon columns are locked down
        if ((_staticColumns.includes(reorderedColumn.name) || _staticColumns.includes(replaceColumnTitle))
            && staticColumnMoveAllowed == false) {
            setTimeout(function (e) {
                grid.reorderColumn(columnIndex, column);
            }, 1)
        } else {
            SaveUserColumnOrder();
        }
    });

    grid.bind("group", function (e) {
        if (e.groups.length > 0) {
            let groupingFormat = '';
            EUFilter.GroupBy = '';

            for (let i = 0; i < e.groups.length; i++) {
                if (i > 0) {
                    groupingFormat = " " + e.groups[i].field;
                } else {
                    groupingFormat = e.groups[i].field;
                }

                EUFilter.GroupBy += groupingFormat;
            }
        } else {
            EUFilter.GroupBy = '';
        }

        UpdateUserViewSettings(_viewType);
        //$("#aagrid").data("kendoGrid").dataSource.read();
    });

    grid.bind("columnResize", function (e) {
        let columnName = e.column.field === undefined ? e.column.title.replace(" ", "") : e.column.field;
        if (!_fromBookmarkFlag) {
            SaveUserColumnWidth(columnName, e.newWidth);
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
                url: "EmployeeUtilization/SaveColumnSetting",
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
                url: "EmployeeUtilization/SaveColumnSetting",
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

        //if ((EUFilter.ShowAssignmentType === "myalertassignments" || EUFilter.ShowAssignmentType === "myalerts") ||
        //    (EUFilter.ShowAssignmentType === "allalertassignments" && $("#empMS").data("kendoMultiSelect").value().length === 1)) {
        //    //(EUFilter.ShowAssignmentType === "allalertassignments" && $("#empMS").data("kendoMultiSelect").value().length === 1 && $("#empMS").data("kendoMultiSelect").value()[0] === _EmployeeCode)) {

        //    AreGridRowsReorderable = true;

        //} else {
        //    AreGridRowsReorderable = false;
        //}

        //items.each(function (index) {
        //    var dataItem = grid.dataItem(this);

        //    if (!AreGridRowsReorderable) {
        //        this.className += " disabled";
        //    }
        //    if (dataItem.IsMyTaskTempComplete) {
        //        this.className += " strikethrough";
        //    }
        //    if (!dataItem.IsRead) {
        //        this.className += " not-read-bold";
        //    }
        //})

        $("#utilizationgrid > div.k-pager-wrap.k-grid-pager.k-widget.k-floatwrap > span.k-pager-sizes.k-label > span > select").change(function (e) {
            let gridSize = $("#utilizationgrid > div.k-pager-wrap.k-grid-pager.k-widget.k-floatwrap > span.k-pager-sizes.k-label > span > span > span.k-input").html();
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

        $("#Search").val(EUFilter.SearchCriteria);

    });
}

function CreateEUViewGrid() {
    let utilizationgrid = $("#utilizationgrid").kendoGrid({
        autoBind: false,
        navigatable: true,
        reorderable: true,
        toolbar: kendo.template($("#template").html()),
        excel: {
            filterable: true,
            allPages: true
        },
        dataSource: UtilizationDataSource,
        groupable: {
            enabled: true,
            showFooter: true
        },
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

    return utilizationgrid;
}

function GetExportFileName() {
    let fileName = "";

    if (isJobJacketView) {
        fileName = "Job " + EUFilter.JobNumber + "-" + EUFilter.JobComponentNumber + "_";
    }

    switch (EUFilter.ShowAssignmentType) {
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
        switch (EUFilter.InboxType) {
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

$("#utilizationgrid").change(function (e) {
    if (e.target.id !== "Search") {
        if (!pageFlag) {
            gridDirty = true;
            enableSave();
        }
    }
});

function SetupAdditionalGridFeatures() {
    let grid = $("#utilizationgrid").data('kendoGrid');

    //grid.table.kendoSortable({
    //    handler: "td:nth-child(1),.wvi.wvi-more_vertical.no-strikethrough",
    //    autoScroll: true,
    //    disabled: ".disabled",  //if row has disabled class then sorting is not enabled
    //    hint: hintElement,
    //    cursor: "move",
    //    placeholder: function (element) {
    //        return element.clone().addClass("k-state-hover").css("opacity", 0.65);
    //    },
    //    filter: ">tbody >tr",
    //    change: function (e) {
    //        let grid = $("#utilizationgrid").data("kendoGrid");
    //        let oldIndex = e.oldIndex;
    //        let newIndex = e.newIndex;
    //        let view = grid.dataSource._data;

    //        let postUrl = "";

    //        if (oldIndex !== newIndex) {
    //            dataItem = grid.dataSource.getByUid(e.item.data("uid")); // Retrieve the moved dataItem.
    //            dataItem.Order = newIndex; // Update the order
    //            dataItem.dirty = false;

    //            // Shift the order of the records.
    //            if (oldIndex > newIndex) {
    //                for (var i = oldIndex + 1; i <= newIndex; i++) {
    //                    view[i].Order--;
    //                    view[i].dirty = false;
    //                }
    //            } else {
    //                for (var i = oldIndex - 1; i >= newIndex; i--) {
    //                    view[i].Order++;
    //                    view[i].dirty = false;
    //                }
    //            }

    //            let sequenceDetail = {
    //                AlertId: dataItem.AlertID,
    //                NewPosition: newIndex,
    //                JobNumber: dataItem.JobNumber,
    //                JobComponentNumber: dataItem.ComponentNumber,
    //                TaskSequenceNumber: dataItem.TaskSequenceNumber,
    //                EmployeeCode: _EmployeeCode
    //            };

    //            //only allow drag when viewing "my alerts" or "my assignments"
    //            if (EUFilter.ShowAssignmentType === "myalertassignments" || EUFilter.ShowAssignmentType === "myalerts" || EUFilter.ShowAssignmentType === "allalertassignments") {
    //                if (EUFilter.ShowAssignmentType === "allalertassignments") {
    //                    sequenceDetail.EmployeeCode = EUFilter.EmployeeCode;
    //                }
    //                if (dataItem.Category === "Task") {
    //                    postUrl = "../EmployeeUtilization/UpdateCardSortAssignments";
    //                } else {
    //                    postUrl = "../EmployeeUtilization/UpdateCardSortAssignments";
    //                    sequenceDetail.JobNumber = 0;
    //                    sequenceDetail.JobComponentNumber = 0;
    //                    sequenceDetail.TaskSequenceNumber = 0;
    //                }
    //            } else { //myalerts
    //                postUrl = "../EmployeeUtilization/UpdateCardSortAlerts";
    //                sequenceDetail.JobNumber = 0;
    //                sequenceDetail.JobComponentNumber = 0;
    //                sequenceDetail.TaskSequenceNumber = 0;
    //            }

    //            $.ajax({
    //                type: "POST",
    //                url: postUrl,
    //                data: JSON.stringify(sequenceDetail),
    //                contentType: 'application/json',
    //                success: function (response) {
    //                    //showKendoAlert("Sort sequence successfully updated.");
    //                },
    //                error: function (response) {
    //                    showKendoAlert("There was an issue updating the sort sequence please contact support.<br/>Message: " + response.message);
    //                }
    //            });
    //        }
    //        else {
    //            e.preventDefault();
    //            alert("defaulted");
    //        }
    //    }
    //});

    $("#utilizationgrid").find("#col-menu").kendoColumnMenu({
        sortable: false,
        filterable: false,
        columns: true,
        dataSource: grid.dataSource,
        owner: grid
    });

    LoadColumnVisibilitySettings();
}

function GenerateColumnDetailSettings() {
    $.ajax({
        type: "Get",
        url: "EmployeeUtilization/GetGridColumnSettings?GridName=" + GetGridView(),
        dataType: "json",
        success: function (response) {
            //myColumns = [];
            myColumns = new Array();
            //myColumns.push({ field: "BillableHoursGoal", title: "", hidden: true });

            for (let i = 0; i < response.length; i++) {
                switch (response[i].ColumnName) {
                    case "Search":
                        myColumns.push({
                            title: "Search", width: response[i].ColumnWidth, template: detailsTemplate, hidden: !response[i].IsVisible, attributes: {
                                style: "min-width: " + response[i].ColumnWidth + "px !important;", hiddenTitleValue: "Search"
                            }, headerTemplate: detailHeaderTemplate
                        });
                        break;
                    case "EmployeeOffice":
                        myColumns.push({ field: "EmployeeOffice", title: "Office", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" }, filterable: { extra: false } });
                        break;
                    case "EmployeeOfficeName":
                        myColumns.push({
                            field: "EmployeeOfficeName", title: "Office Name", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }
                        });
                        break;
                    case "EmployeeDepartment":
                        myColumns.push({
                            field: "EmployeeDepartment", title: "Department", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }
                        });
                        break;
                    case "EmployeeName":
                        myColumns.push({
                            field: "EmployeeName", title: "Employee Name", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }
                        });
                        break;
                    case "EmployeeDepartmentName":
                        myColumns.push({
                            field: "EmployeeDepartmentName", title: "Department Name", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupHeaderTemplate: departmentGroupingTemplate, groupFooterTemplate: groupFooterEmployeeNameTemplate
                        });
                        break;
                    case "EmployeeCode":
                        myColumns.push({
                            field: "EmployeeCode", title: "Employee Code", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }
                        });
                        break;
                    case "RequiredHours":
                        myColumns.push({
                            field: "RequiredHours", title: "Required Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterRequiredHoursTemplate, format: "{0:n2}", aggregates: ["sum"]
                        });
                        break;
                    case "BillableHoursGoal":
                        myColumns.push({
                            field: "BillableHoursGoal", title: "Billable Hours Goal", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: billablehoursgoalGroupingTemplate, format: "{0:n2}", aggregates: ["sum"]
                        });
                        break;
                    case "BillableHours":
                        myColumns.push({
                            field: "BillableHours", title: "Billable Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterBillableHoursTemplate, format: "{0:n2}", aggregates: ["sum"]
                        });
                        break;
                    case "NonBillableHours":
                        myColumns.push({
                            field: "NonBillableHours", title: "Non Billable Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterNonBillableHoursTemplate, format: "{0:n2}", aggregates: ["sum"]
                        });
                        break;
                    case "NewBusinessHours":
                        myColumns.push({
                            field: "NewBusinessHours", title: "New Business Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterNewBusinessHoursTemplate, format: "{0:n2}", aggregates: ["sum"]
                        });
                        break;
                    case "OOOHours":
                        myColumns.push({
                            field: "OOOHours", title: "PTO Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterOOOHoursTemplate, format: "{0:n2}", aggregates: ["sum"]
                        });
                        break;
                    case "TotalHours":
                        myColumns.push({
                            field: "TotalHours", title: "Total Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterTotalHoursTemplate, format: "{0:n2}", aggregates: ["sum"]
                        });
                        break;
                    case "BillableHoursPercent":
                        myColumns.push({
                            field: "BillableHoursPercent", title: "Billable Hours %", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterBillableHoursPercentTemplate, format: "{0:n2}"
                        });
                        break;
                    case "BillablePercentGoal":
                        myColumns.push({
                            field: "BillablePercentGoal", title: "Billable Hours % Goal", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterBillablePercentGoalTemplate, format: "{0:n2}", aggregates: ["average"]
                        });
                        break;
                    case "BillableVariance":
                        myColumns.push({
                            field: "BillableVariance", title: "Billable Variance", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterBillableVarianceTemplate, format: "{0:n2}"
                        });
                        break;
                    case "DirectPercentGoal":
                        myColumns.push({
                            field: "DirectPercentGoal", title: "Direct Hours % Goal", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterDirectPercentGoalTemplate, format: "{0:n2}", aggregates: ["average"]
                        });
                        break;
                    case "NonBillableHoursPercent":
                        myColumns.push({
                            field: "NonBillableHoursPercent", title: "Non Billable Hours %", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterNonBillableHoursPercentTemplate, format: "{0:n2}"
                        });
                        break;
                    case "NewBusinessPercent":
                        myColumns.push({
                            field: "NewBusinessPercent", title: "New Business %", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterNewBusinessPercentTemplate, format: "{0:n2}"
                        });
                        break;
                    case "OOOPercent":
                        myColumns.push({
                            field: "OOOPercent", title: "PTO %", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterOOOPercentTemplate, format: "{0:n2}"
                        });
                        break;
                    case "TotalUtilization":
                        myColumns.push({
                            field: "PercentOfRequiredHours", title: "Total Utilization", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterTotalUtilizationTemplate, format: "{0:n2}"
                        });
                        break;
                    case "DirectHoursGoal":
                        myColumns.push({
                            field: "DirectHoursGoal", title: "Direct Hours Goal", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, format: "{0:n2}", groupFooterTemplate: groupFooterDirectHoursGoalTemplate, aggregates: ["sum"]
                        });
                        break;
                    case "AgencyHours":
                        myColumns.push({
                            field: "AgencyHours", title: "Agency Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, format: "{0:n2}", groupFooterTemplate: groupFooterAgencyHoursTemplate, aggregates: ["sum"]
                        });
                        break; 
                    case "TotalDirectHours":
                        myColumns.push({
                            field: "TotalDirectHours", title: "Direct Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, format: "{0:n2}", groupFooterTemplate: groupFooterTotalDirectHoursTemplate, aggregates: ["sum"]
                        });
                        break;
                    case "NonDirectHours":
                        myColumns.push({
                            field: "NonDirectHours", title: "Indirect Hours", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, format: "{0:n2}", groupFooterTemplate: groupFooterIndirectHoursTemplate, aggregates: ["sum"]
                        });
                        break;
                    case "Variance":
                        myColumns.push({
                            field: "Variance", title: "Variance", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, format: "{0:n2}", groupFooterTemplate: groupFooterVarianceTemplate, aggregates: ["sum"]
                        });
                        break;
                    case "PercentDirect":
                        myColumns.push({
                            field: "PercentDirect", title: "Direct %", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterDirectPercentTemplate, format: "{0:n2}"
                        });
                        break;
                    case "PercentNonDirect":
                        myColumns.push({
                            field: "PercentNonDirect", title: "Indirect %", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterNonDirectPercentTemplate, format: "{0:n2}"
                        });
                        break;
                    case "PercentOfDirectHoursGoal":
                        myColumns.push({
                            field: "PercentOfDirectHoursGoal", title: "% of Direct Hours Goal", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterDirectHoursGoalPercentTemplate, format: "{0:n2}"
                        });
                        break;
                    case "PercentOfBillableHoursGoal":
                        myColumns.push({
                            field: "PercentOfBillableHoursGoal", title: "% of Billable Hours Goal", width: response[i].ColumnWidth, hidden: !response[i].IsVisible, attributes: { style: "width: " + response[i].ColumnWidth + "px; min-width: " + response[i].ColumnWidth + "px;" },
                            filterable: { extra: false }, groupFooterTemplate: groupFooterBillableHoursGoalPercentTemplate, format: "{0:n2}"
                        });
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

function groupFooterEmployeeNameTemplate(dataItem) {
    let EmployeeName = '';

    if (dataItem.group === undefined) {
        EmployeeName = dataItem.value + " Total:";
    } else {
        EmployeeName = dataItem.group.value + " Total:";
    }    

    return EmployeeName;

}

function groupFooterRequiredHoursTemplate(dataItem) {
    let RequiredHours = '';

    if (dataItem.RequiredHours !== undefined) {
        RequiredHours = dataItem.RequiredHours.sum;
    }

    return kendo.toString(RequiredHours, 'n');

}
function groupFooterBillableHoursTemplate(dataItem) {
    let BillableHours = '';

    if (dataItem.BillableHours !== undefined) {
        BillableHours = dataItem.BillableHours.sum;
    }

    return kendo.toString(BillableHours, 'n');

}
function groupFooterNonBillableHoursTemplate(dataItem) {
    let NonBillableHours = '';

    if (dataItem.NonBillableHours !== undefined) {
        NonBillableHours = dataItem.NonBillableHours.sum;
    }

    return kendo.toString(NonBillableHours, 'n');

}
function groupFooterNewBusinessHoursTemplate(dataItem) {
    let NewBusinessHours = '';

    if (dataItem.NewBusinessHours !== undefined) {
        NewBusinessHours = dataItem.NewBusinessHours.sum;
    }

    return kendo.toString(NewBusinessHours, 'n'); 

}
function groupFooterOOOHoursTemplate(dataItem) {
    let OOOHours = '';

    if (dataItem.OOOHours !== undefined) {
        OOOHours = dataItem.OOOHours.sum;
    }

    return kendo.toString(OOOHours, 'n');

}
function groupFooterTotalHoursTemplate(dataItem) {
    let TotalHours = '';

    if (dataItem.TotalHours !== undefined) {
        TotalHours = dataItem.TotalHours.sum;
    }

    return kendo.toString(TotalHours, 'n');

}
function groupFooterAgencyHoursTemplate(dataItem) {
    let AgencyHours = '';

    if (dataItem.AgencyHours !== undefined) {
        AgencyHours = dataItem.AgencyHours.sum;
    }

    return kendo.toString(AgencyHours, 'n');

}
function groupFooterTotalDirectHoursTemplate(dataItem) {
    let DirectHours = '';

    if (dataItem.TotalDirectHours !== undefined) {
        DirectHours = dataItem.TotalDirectHours.sum;
    }

    return kendo.toString(DirectHours, 'n');

}
function groupFooterIndirectHoursTemplate(dataItem) {
    let NonDirectHours = '';

    if (dataItem.NonDirectHours !== undefined) {
        NonDirectHours = dataItem.NonDirectHours.sum;
    }

    return kendo.toString(NonDirectHours, 'n');

}
function groupFooterVarianceTemplate(dataItem) {
    let Variance = '';

    if (dataItem.Variance !== undefined) {
        Variance = dataItem.Variance.sum;
    }

    return kendo.toString(Variance, 'n');

}
function groupFooterDirectHoursGoalTemplate(dataItem) {
    let DirectHoursGoal = '';

    if (dataItem.DirectHoursGoal !== undefined) {
        DirectHoursGoal = dataItem.DirectHoursGoal.sum;
    }

    return kendo.toString(DirectHoursGoal, 'n');

}

function groupFooterBillableHoursPercentTemplate(dataItem) {
    let BillableHoursPercent = '';

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            BillableHoursPercent = 0.00;
        } else {
            BillableHoursPercent = (dataItem.BillableHours.sum / dataItem.RequiredHours.sum) * 100;
        }
    }

    return kendo.toString(BillableHoursPercent, 'n');

}
function groupFooterBillablePercentGoalTemplate(dataItem) {
    let BillablePercentGoal = '';

    if (dataItem.BillablePercentGoal !== undefined) {
        BillablePercentGoal = dataItem.BillablePercentGoal.average;
    }

    return kendo.toString(BillablePercentGoal, 'n');

}

function groupFooterDirectPercentGoalTemplate(dataItem) {
    let DirectPercentGoal = '';

    if (dataItem.DirectPercentGoal !== undefined) {
        DirectPercentGoal = dataItem.DirectPercentGoal.average;
    }

    return kendo.toString(DirectPercentGoal, 'n');

}

function groupFooterBillableVarianceTemplate(dataItem) {
    let BillableHoursPercent = '';
    let BillableVariance = '';
    let BillablePercentGoal = '';

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            BillableHoursPercent = 0.00;
        } else {
            BillableHoursPercent = (dataItem.BillableHours.sum / dataItem.RequiredHours.sum) * 100;
        }

        BillablePercentGoal = dataItem.BillablePercentGoal.average;

        BillableVariance = BillableHoursPercent - BillablePercentGoal;
    }

    return kendo.toString(BillableVariance, 'n');

}
function groupFooterNonBillableHoursPercentTemplate(dataItem) {
    let NonBillableHoursPercent = '';

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            NonBillableHoursPercent = 0.00;
        } else {
            NonBillableHoursPercent = (dataItem.NonBillableHours.sum / dataItem.RequiredHours.sum) * 100;
        }
    }

    return kendo.toString(NonBillableHoursPercent, 'n');

}
function groupFooterNewBusinessPercentTemplate(dataItem) {
    let NewBusinessPercent = '';

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            NewBusinessPercent = 0.00;
        } else {
            NewBusinessPercent = (dataItem.NewBusinessHours.sum / dataItem.RequiredHours.sum) * 100;
        }
    }

    return kendo.toString(NewBusinessPercent, 'n');

}
function groupFooterOOOPercentTemplate(dataItem) {
    let OOOPercent = '';

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            OOOPercent = 0.00;
        } else {
            OOOPercent = (dataItem.OOOHours.sum / dataItem.RequiredHours.sum) * 100;
        }
    }

    return kendo.toString(OOOPercent, 'n');

}
function groupFooterDirectPercentTemplate(dataItem) {
    let DirectPercent = '';

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            DirectPercent = 0.00;
        } else {
            DirectPercent = (dataItem.TotalDirectHours.sum / dataItem.RequiredHours.sum) * 100;
        }
    }

    return kendo.toString(DirectPercent, 'n');

}
function groupFooterNonDirectPercentTemplate(dataItem) {
    let NonDirectPercent = '';

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            NonDirectPercent = 0.00;
        } else {
            NonDirectPercent = (dataItem.NonDirectHours.sum / dataItem.RequiredHours.sum) * 100;
        }
    }

    return kendo.toString(NonDirectPercent, 'n');

}
function groupFooterDirectHoursGoalPercentTemplate(dataItem) {
    let DirectHoursGoalPercent = '';

    if (dataItem.DirectHoursGoal !== undefined) {
        if (dataItem.DirectHoursGoal.sum === 0) {
            DirectHoursGoalPercent = 0.00;
        } else {
            DirectHoursGoalPercent = (dataItem.TotalDirectHours.sum / dataItem.DirectHoursGoal.sum) * 100;
        }
    }

    return kendo.toString(DirectHoursGoalPercent, 'n');

}
function groupFooterBillableHoursGoalPercentTemplate(dataItem) {
    let BillableHoursGoalPercent = '';

    if (dataItem.BillableHoursGoal !== undefined) {
        if (dataItem.BillableHoursGoal.sum === 0) {
            BillableHoursGoalPercent = 0.00;
        } else {
            BillableHoursGoalPercent = (dataItem.BillableHours.sum / dataItem.BillableHoursGoal.sum) * 100;
        }
    }

    return kendo.toString(BillableHoursGoalPercent, 'n');

}
function groupFooterTotalUtilizationTemplate(dataItem) {
    let BillableHoursPercent = '';
    let NonBillableHoursPercent = '';
    let NewBusinessPercent = '';
    let OOOPercent = '';
    let TotalUtilization = '';

    let TotalHours = '';
    let RequiredHours = ''

    if (dataItem.RequiredHours !== undefined) {
        if (dataItem.RequiredHours.sum === 0) {
            TotalUtilization = 0.00;
        } else {
            TotalUtilization = (dataItem.TotalHours.sum / dataItem.RequiredHours.sum) * 100;
        }


        //if (dataItem.RequiredHours.sum === 0) {
        //    BillableHoursPercent = 0.00;
        //} else {
        //    BillableHoursPercent = (dataItem.BillableHours.sum / dataItem.RequiredHours.sum) * 100;
        //}

        //if (dataItem.RequiredHours.sum === 0) {
        //    NonBillableHoursPercent = 0.00;
        //} else {
        //    NonBillableHoursPercent = (dataItem.NonBillableHours.sum / dataItem.RequiredHours.sum) * 100;
        //}

        //if (dataItem.TotalHours.sum === 0) {
        //    NewBusinessPercent = 0.00;
        //} else {
        //    NewBusinessPercent = (dataItem.NewBusinessHours.sum / dataItem.TotalHours.sum) * 100;
        //}

        //if (dataItem.RequiredHours.sum === 0) {
        //    OOOPercent = 0.00;
        //} else {
        //    OOOPercent = (dataItem.OOOHours.sum / dataItem.RequiredHours.sum) * 100;
        //}
    }

    return kendo.toString(TotalUtilization, 'n');

}



function departmentGroupingTemplate(dataItem) {
    let department = '';

    if (dataItem.value !== '') {
        department += dataItem.value;
    }

    return department;
}

function billablehoursgoalGroupingTemplate(dataItem) {
    let billablehoursgoal = '';

    if (dataItem.BillableHoursGoal !== undefined) {
        billablehoursgoal = dataItem.BillableHoursGoal.sum;
    }

    return kendo.toString(billablehoursgoal, 'n');
}


function lastUpdateGroupTemplate(dataItem) {
    if (dataItem.value !== null) {
        return "Last Updated: " + kendo.toString(kendo.parseDate(dataItem.value), "MM/dd/yyyy");
    } else {
        return "Last Updated:";
    }
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
    //    url += "&aamsat=" + EUFilter.ShowAssignmentType;
    //}
    console.log("showDetails???")
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

    url = `Content.aspx?From=DO&PageMode=Edit&JobNum=${JobNumber}&JobCompNum=${ComponentNumber}&NewComp=0&aamsat=${EUFilter.ShowAssignmentType}`;
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




//function taskClientTemplate() {

//    return `${dataItem.ClientCode}/${dataItem.DivisionCode}/${dataItem.ProductCode}`;
//}


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

function ProcessColumnReset(operationType) {
    let gridName = '';
    let url = '';

    columnSettingsReady = false;

    gridName = GetGridView();
    if (operationType === "width") {
        url = "EmployeeUtilization/ResetGridColumnWidths";
    } else {
        url = "EmployeeUtilization/ResetGridColumnOrder";
    }

    $.ajax({
        type: "POST",
        url: url,
        data: { GridName: gridName },
        success: function (response) {
            closeAllPopups();
            DestroyGrid();

            LoadUserColumnSettings();

            SetDateFilters('');

            CheckColumnSettingsReadyFlagAndReloadGrid();
            //ReloadGrid();
        },
        error: function (response) {
            closeAllPopups();
            showKendoAlert(`An error occurred while resetting the grid column ${operationType}, please contact support.`);
        }
    });
}


