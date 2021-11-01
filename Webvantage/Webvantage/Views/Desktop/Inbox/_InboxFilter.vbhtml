<script type="text/javascript" src="~/JScripts/aam.inbox.filter.mvc.js"></script>

<div>
    <ul id="panelbar" style="display:inline-block;position:relative;width:calc(100vw - 18px);min-width:calc(100vw - 18px);">
        <li class="k-state-active" style="position: relative;width:calc(100vw - 18px) !important;">
            <!--<span id="ClientName" style="background-color:#e5e5e5 !important;border-color:lightgrey !important;color:#333 !important;" class="k-link k-state-selected">Filters</span>-->
            <span id="ClientName" class="k-link k-state-selected" style="position:relative;width:calc(100vw - 45px) !important;font-weight:600;font-size:14px;"> Assignments & Alerts Manager</span>
            <div style="padding-top: 18px;padding-bottom: 20px;padding-left: 20px; border-bottom: none;overflow:auto;">
                <table>
                    <tr>
                        <td style="margin:4px;padding-right: 60px;">
                            <div id="tdEmployee">
                                <div class="wv-employee-box">
                                    <div class="body">
                                        <div class="row">
                                            <div class="image-container" title="@ViewBag.EmployeeName">
                                                <img id="employeeImage" src='@Url.Action("EmployeePicture", "Utilities")/@ViewBag.DefaultEmpCode' />
                                            </div>
                                            <div class="name" title="@ViewBag.EmployeeName">
                                                <span class="name-span">@ViewBag.EmployeeName</span>
                                            </div>
                                            <div class="button">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                        @*<td><button onclick="GetGrouping();">test</button></td>*@
                        <td style="width:110px;min-width:110px;margin:4px;padding-right: 30px;">
                            <div style="padding-bottom: 4px; color: #767676;" title="The Start and End date filters are applied based on the Last Updated date in the grid.">Start Date</div>
                            <input id="startdate" title="The Start and End date filters are applied based on the Last Updated date in the grid." style="width: 100px; color: #767676;" />
                        </td>
                        <td style="width:170px;min-width:170px;margin:4px;padding-right: 60px;">
                            <div style="padding-bottom: 4px; color: #767676;" title="The Start and End date filters are applied based on the Last Updated date in the grid.">End Date</div>
                            <input id="duedate" title="The Start and End date filters are applied based on the Last Updated date in the grid." style="width: 100px; color: #767676;" />
                        </td>
                        <td style="width:110px !important;min-width:110px !important;margin:4px 4px 4px 50px;">
                            <div id="tdFilter">
                                <div style="padding-bottom: 4px; color: #767676;"><span class="glyphicon glyphicon-filter"></span>Filter Type</div>
                                <input type="text" id="filterSelect" title="Select Filter Type" style="width:110px !important;" />
                            </div>
                        </td>
                        <td style="width:395px;min-width:395px;vertical-align:bottom;">
                            <div style="width:365px;float:left;margin:4px 4px 2px 30px;" id="employeeFilterContainer">
                                @*<div style="padding-bottom: 4px; color: #767676;">Employee</div>*@
                                <input type="text" id="empMS" title="Filter by Employee" style="width:365px;" />
                            </div>
                            <div style="width:365px;float:left;margin:4px 4px 2px 30px;" id="departmentFilterContainer" class="display-none">
                                @*<div style="padding-bottom: 4px; color: #767676;">Department</div>*@
                                <input type="text" id="departmentMS" title="Filter by Department" style="width:365px;" />
                            </div>
                            <div style="width:365px;float:left;margin:4px 4px 2px 30px;" id="roleFilterContainer" class="display-none">
                                @*<div style="padding-bottom: 4px; color: #767676;">Role</div>*@
                                <input type="text" id="roleMS" title="Filter by Role" style="width:365px;" />
                            </div>
                        </td>
                        <td style="width:200px;min-width:200px;margin:4px 4px 4px 45px;padding-left:50px;">
                            <div id="ShowOnlyTempCompletedTasksDiv">
                                <div style="padding-bottom: 4px; color: #767676;">Only Tasks Marked<br />Temp Complete</div>
                                <input type="checkbox" id="ShowOnlyTempCompletedTasks" class="k-checkbox" title="Only Tasks Marked Temp Complete" onchange="ProcessTempCompleteCheck();">
                                <label class="k-checkbox-label" for="ShowOnlyTempCompletedTasks"></label>
                            </div>
                        </td>
                        <td style="width:200px;min-width:200px;margin:4px 4px 4px 20px;padding-left:20px;">
                            <div id="IncludeBacklogItemsDiv">
                                <div style="padding-bottom: 4px; color: #767676;">Include Backlog<br />Items</div>
                                <input type="checkbox" id="IncludeBacklogItems" class="k-checkbox" title="Include Backlog Items" onchange="ProcessIncludeBacklogCheck();">
                                <label class="k-checkbox-label" for="IncludeBacklogItems"></label>
                            </div>
                        </td>
                    </tr>
                </table>

                @*<div style="display:inline-block;display:inline-block;position:relative;width:calc(100vw - 18px);min-width:calc(100vw - 18px);">
                    </div>*@
            </div>
        </li>
    </ul>
</div>   
<script>    
    let holdOpen = false;

    $(() => {        
        var todayDate = kendo.toString(kendo.parseDate(new Date()), 'MM/dd/yyyy');

        //$("#panelbar").kendoPanelBar();
        //var panelBar = $("#panelBar").data("kendoPanelBar");
        
        $("#panelbar").kendoPanelBar({
            expand: onExpand,
            collapse: onCollapse
        }).data("kendoPanelBar");

        $("#startdate").kendoDatePicker({
            change: function (e) {
                onDateFilterChange(e);
            },
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy',            
        }).data("kendoDatePicker");

        $("#duedate").kendoDatePicker({
            value: todayDate,
            change: function (e) {
                onDateFilterChange(e);
            },
            parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy'
        }).data("kendoDatePicker");

        //$('#CommentsTextArea').on("change", onCommentsChange);

        //$('#saveButton').on('click', saveJobInfo);
        //$('#cancelButton').on('click', loadJobInfo);
        //$('#refreshProjectSchedule').on('click', loadJobInfo);
        

        $("#filterSelect").kendoDropDownList({
            value: "employee",
            dataTextField: "text",
            dataValueField: "value",
            dataSource: [
                { text: "Department", value: "department" },
                { text: "Employee", value: "employee" },
                { text: "Role", value: "role" }
            ],
            change: (e) => {
                onFilterSelectChange(e);
            }, 
            open: (e) => {
                onFilterSelectOpen(e);  
            }
        });       

        function onFilterSelectOpen(e) {
            let currentActiveMultiSelect = '';  
            let currentActiveMultiSelectValue = '';

            //let test = $("#filterSelect").data("kendoDropDownList").value();
            //console.log("currentMS: " + test);
            currentActiveMultiSelect = $("#filterSelect").data("kendoDropDownList").value();

            switch (currentActiveMultiSelect) {
                case "department":
                    currentActiveMultiSelectValue = $("#departmentMS").data("kendoMultiSelect").value()                    
                    break;
                case "employee":
                    currentActiveMultiSelectValue = $("#empMS").data("kendoMultiSelect").value()                    
                    break;
                case "role":
                    currentActiveMultiSelectValue = $("#roleMS").data("kendoMultiSelect").value()                    
                    break;
            }

            if (currentActiveMultiSelectValue.length > 0) {
                _multiselectfiltered = true;
            } else {
                _multiselectfiltered = false;
            }            
        }

        $("#roleMS").kendoMultiSelect({   
            clearButton: false,
            placeholder: "No Role Selected",
            //value: [_EmployeeCode],
            maxSelectedItems: 20,            
            valuePrimitive: true,
            required: false,
            filter: "contains",
            dataTextField: "Description",
            dataValueField: "Code",
            //itemTemplate: employeeImageTemplate,
            dataSource: new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: "@Url.Content("~/Desktop/Inbox/GetRoles")",
                            data: (() => {                                
                            })
                        },
                        dataType: "json"
                    }
                }),
            change: (e) => {                
                onSelectedFilterChange(e);
                //manageVerticalScroll(e);
                }
        }).data('kendoMultiSelect');  

        $("#departmentMS").kendoMultiSelect({   
            clearButton: false,
            placeholder: "No Department Selected",
            //value: [_EmployeeCode],
            maxSelectedItems: 20,            
            valuePrimitive: true,
            required: false,
            filter: "contains",
            dataTextField: "Description",
            dataValueField: "Code",            
            dataSource: new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: "@Url.Content("~/Desktop/Inbox/GetDepartments")",
                            data: (() => {                                                                
                            })
                        },
                        dataType: "json"
                    }
                }),
            change: (e) => {
                onSelectedFilterChange(e);
                //manageVerticalScroll(e);
                }
        }).data('kendoMultiSelect');                

        manageEmployeeFilterStatus();
    }); 

    $("#empMS").kendoMultiSelect({   
        clearButton: false,
        placeholder: "No Employee Selected",            
        //value: [AlertFilter.EmployeeCode],
        maxSelectedItems: 20,            
        valuePrimitive: true,
        required: false,
        open: (() => { open = true; }),
        close: ((e) => {
            if (holdOpen && oneShot) {
                holdOpen = false;
                oneShot = false;
                e.preventDefault();
            }
            else {
                open = false;
            }

            holdOpen = false;
        }),
        filter: "contains",
        dataTextField: "NameOnly",
        dataValueField: "Code",
        itemTemplate: employeeImageTemplate,
        dataSource: new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "@Url.Content("~/Utilities/SearchEmployee")",
                        data: (() => {                                
                            var filterRole = $('#EmployeeMultiSelect').data('filterRole');
                            var options = $('#EmployeeMultiSelect').data('options');
                            if (filterRole) {
                                return {
                                    Role: ""
                                };
                            }
                        })
                    },
                    dataType: "json"
                }
            }),
        change: (e) => {                       
            onSelectedFilterChange(e);    

            //manageVerticalScroll(e);
        }
    }).data('kendoMultiSelect');  

    function employeeImageTemplate(dataItem) {
        var rv = '<img class="k-state-default" src="@Href("~/Utilities/EmployeePicture/")' + dataItem.Code + '" style="height:25px;width:25px;border-radius:5px;margin:5px 5px 5px 5px; float:left"></img>';
        rv = rv + '<div><span class="k-state-default">' + dataItem.NameOnly;

        if (dataItem.Title) {
            rv = rv + '<p style="font-size:smaller">' + dataItem.Title + '</p>';
        }
        else {
            rv = rv + '<p style="font-size:smaller">&nbsp</p>';
        }

        rv = rv + '</span></div>';

        return rv;
    }
</script>
