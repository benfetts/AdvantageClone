<script src="~/JScripts/billing.paymentcenter.manager.mvc.js"></script>
<style>
    .search-wrapper.search-wrapper-expanded {
        width: 500px;
        height: 100vh
    }

    .search-wrapper {
        width: 200px;
        -webkit-transition: width .3s ease-in-out;
        -moz-transition: width .3s ease-in-out;
        transition: width .3s ease-in-out
    }

    .wv-grid {
        position: relative
    }

    .wv-sidebar {
        height: 100vh;
        float: left
    }

    .k-grouping-header {
        display: none !important
    }

    .wv-content .wv-k-grid {
        padding: 4px
    }

    .disabled {
        pointer-events: none;
        opacity: .5
    }

    .wv-search .k-dropdown ul li:nth-of-type(even) {
        background: #f5f5f5 !important;
        background-color: #f5f5f5 !important
    }

    .k-list li:nth-of-type(even) {
        background: #f5f5f5;
        background-color: #f5f5f5
    }
    
    .wv-k-grid tr:nth-of-type(even) {
        background: #f5f5f5;
        background-color: #f5f5f5
    }

    .k-grid-content {
        min-height: 20px
    }

    .wv-grid > .sidebar {
        min-height: 900px;
        height: 100%
    }

    .wv-k-grid .k-grid-header {
        padding: 0 !important
    }

    .wv-k-grid .k-grid-content {
        overflow-y: visible
    }

    .k-virtual-content {
        overflow-y: auto
    }

    #AddNewBatch {
        margin: auto;
        width: 900px;
        height: 450px;
    }

    #batchGrid > div.k-grid-header {
        padding-right: 0px !important;
    }
</style>
<div class="wv-search-container row">
    <div class="wv-grid col-xs-12">
        <div class="wv-sidebar-new sidebar col-md-2">
            <div class="row">
                <div class="wv-search col-xs-12">
                    <div id="searchOptions" class="au-target">
                        <div class="wv-form-spacing">
                            <label> Employee </label>
                            <div id="EmployeeMultiSelectDiv" style="width:273px;">
                                <input id="employeeMultiSelect" />
                            </div>
                        </div>

                        <div class="wv-form-spacing">
                            <label> From </label><!--anchor-->
                            <div id="FromDateDiv" style="width:273px;">
                                <input id="fromDatePicker" />
                            </div>
                        </div>                        
                        <div class="wv-form-spacing">
                            <label> To </label><!--anchor-->
                            <div id="toDateDiv" style="width:273px;">
                                <input id="toDatePicker" />
                            </div>
                        </div>
                        <div id="statusCheckBoxes">
                            <div class="wv-form-spacing">
                                <input class="k-checkbox au-target" type="checkbox" id="showOpenCB" value="O" checked>
                                <label class="k-checkbox-label" for="showOpenCB">
                                    <span class="pill wv-save">Open</span>
                                </label>
                            </div>
                            <div class="wv-form-spacing">
                                <input class="k-checkbox au-target" type="checkbox" id="showSubmittedCB" value="S" checked>
                                <label class="k-checkbox-label" for="showSubmittedCB">
                                    <span class="pill wv-warning" style="color:white;">Submitted</span>
                                </label>
                            </div>
                            <div class="wv-form-spacing">
                                <input class="k-checkbox au-target" type="checkbox" id="showApprovedCB" value="A" checked>
                                <label class="k-checkbox-label" for="showApprovedCB">
                                    <span class="pill wv-assignee-complete" style="color:white;">Approved</span>
                                </label>
                            </div>
                            <div class="wv-form-spacing">
                                <input class="k-checkbox au-target" type="checkbox" id="showDeniedCB" value="D" checked>
                                <label class="k-checkbox-label" for="showDeniedCB">
                                    <span class="pill wv-danger" style="color:white;">Denied</span>
                                </label>
                            </div>
                            <div class="wv-form-spacing">
                                <input class="k-checkbox au-target" type="checkbox" id="showCompletedCB" value="C" checked>
                                <label class="k-checkbox-label" for="showCompletedCB">
                                    <span class="pill wv-success" style="color:white;">Completed</span>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="wv-content col-md-10">
            <div id="batchGrid" style="border: 1px solid #CCC;" tabindex="1"></div>
            <script type="text/x-kendo-template" id="template">
                <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                    <li style="padding:0">
                        <button title="Create New Batch" class="wv-icon-button k-button k-grid-add wv-add-new" onclick="NewBatch()">
                            <span class="wvi wvi-navigate-plus" style="font-size: 18px;"></span>
                        </button>
                    </li>
                    <li style="padding:0">
                        <button title="Search/Find" class="wv-icon-button k-button k-normal" onclick="GetBatches()">
                            <span class="wvi wvi-magnifying-glass"></span>
                        </button>
                    </li>
                    <li style="padding:0">
                        <button title="Clear" class="wv-icon-button k-button k-normal" onclick="ClearFilters()">
                            <span class="wvi wvi-undo"></span>
                        </button>
                    </li>
                    <li style="padding:0">
                        <button title="Bookmark" class="wv-icon-button k-button k-normal" onclick="BookmarkPageClick()">
                            <span class="wvi wvi-book-bookmark"></span>
                        </button>
                    </li>
                </ul>
            </script>            
        </div>
    </div>
</div>
<script>
    var _currentUser = '@ViewBag.CurrentUser'.toLowerCase();    

    //TEMPORARY    
    if (_currentUser == 'SYSADM' || _currentUser == 'sysadm') {
        _currentUser = 'ama';
    }

    $(() => {            
        _PageInitialized = true;

        batchFilter.BatchOwner = _currentUser;
        
        LoadGridView();
    })

    $('#statusCheckBoxes :checkbox').change(function () {
        onFilterChange();
    });

    @*$("#AddNewBatch").kendoDialog({
        visible: false,
        title: "Create New Payment Batch",
        open: function () {
            $.ajax({
                url: '@Url.Action("_PaymentManagerAddNew", "PaymentCenter")',
                method: 'GET',
                success: function (result) {
                    $('#AddNewBatch').html(result);
                }
            });
        },
        close: function () {
            console.log("closed");
        }
    });*@

    $("#employeeMultiSelect").kendoMultiSelect({
        autoWidth: false,
        clearButton: false,
        placeholder: "Employee",
        valuePrimitive: true,
        value: [_currentUser],
        required: false,
        open: (() => {
        }),
        close: ((e) => {
        }),
        filter: "contains",
        dataTextField: "NameOnly",
        dataValueField: "Code",
        itemTemplate: employeeImageTemplate,
        dataSource: new kendo.data.DataSource({
                transport: {
                    read: {
                        url: "@Url.Content("~/Utilities/SearchEmployee")"                        
                    },
                    dataType: "json"
                }
        }),
        change: (e) => {            
            let selectedItems = e.sender.dataItems();
            let selectedArray = [];
            let selections = '';
            let selectionCount = 0;

            console.log(selectedItems);

            $.each(selectedItems, (i, v) => {
                selectedArray.push(v.Code);

                if (selectionCount == 0) {
                    selections += v.Code;
                } else {
                    selections += ',' + v.Code;
                }

                ++selectionCount;
            });

            selections.length > 0 ? batchFilter.BatchOwner = selections : batchFilter.BatchOwner = "";
            onFilterChange();
        },
        dataBound: (e) => {
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

    $("#fromDatePicker").kendoDatePicker({
        enable: false,
        change: function (e) {
            onFilterChange();
        },
        value: "",
        parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
        format: 'MM/dd/yyyy'
    }).data("kendoDatePicker");

    $("#toDatePicker").kendoDatePicker({
        enable: false,
        change: function (e) {
            onFilterChange();
        },
        value: "",
        parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
        format: 'MM/dd/yyyy'
    }).data("kendoDatePicker");  
</script>
