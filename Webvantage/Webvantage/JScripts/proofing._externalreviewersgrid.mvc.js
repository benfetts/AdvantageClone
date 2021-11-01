////let todayDate = kendo.toString(kendo.parseDate(new Date()), 'MM/dd/yyyy');
////let proofingExternalReviewerGridDataSource;

////// let grid = $("#proofingExternalReviewerGrid").data("kendoGrid");

function clearFilters() {
    $("#proofingExternalReviewerGrid").data("kendoGrid").dataSource.filter({});
}
function enabledRegularEdit() {
    changeSaveButtonState(true);
    changeCancelButtonState(true);
    return true;
}
function disableSaveButtonState() {
    changeSaveButtonState(false);
}
function disableCancelButtonState() {
    changeCancelButtonState(false);
    $("#proofingExternalReviewerGrid").data("kendoGrid").cancelChanges();
}
function changeSaveButtonState(enable) {
    $(".wv-save").kendoButton({ enable: false }).data("kendoButton").enable(enable);
}
function changeCancelButtonState(enable) {
    $(".wv-cancel").kendoButton({ enable: false }).data("kendoButton").enable(enable);
}

$(document).ready(function () {
    var proofingExternalReviewerGridDataSource;
    var crudServiceBaseUrl = window.appBase + "ProjectManagement/Proofing/";
    var clientCode = null;
    var defaultfilter = {};
    try {
        clientCode = getQueryString().c;
    } catch (e) {
        clientCode = null;
    }
    proofingExternalReviewerGridDataSource = new kendo.data.DataSource({
        transport: {
            read: function(e) {
                $.ajax({
                    url: crudServiceBaseUrl + "ExternalReviewersGet",
                    dataType: "json",
                    method: "GET",
                    success: function (result) {
                        e.success(result);
                        console.log("SUCCESS!", result);
                    },
                    error: function (result) {
                        e.error(result);
                        console.log("FAIL!", result);
                    }
                });
            },
            update: function (e) {
                $.ajax({
                    url: crudServiceBaseUrl + "ExternalReviewersUpdate",
                    dataType: "json",
                    method: "POST",
                    data: {
                        models: kendo.stringify(e.data.models)
                    },
                    success: function (result) {
                        if (result) {
                           if (result.ExternalReviewers) {
                               e.success(result.ExternalReviewers);
                           }
                            if (result.ErrorMessages && result.ErrorMessages.length > 0) {
                               var s = "";
                               for (var i = 0; i < result.ErrorMessages.length; i++) {
                                   s += "<li>" + result.ErrorMessages[i] + "</li>";
                               }
                               if (s && s != "") {
                                   ShowMessage(s);
                               }
                           }
                            $("#proofingExternalReviewerGrid").data("kendoGrid").dataSource.read();
                        }
                    },
                    error: function (result) {
                        if (result) {
                            if (result.ExternalReviewers) {
                                e.error(result.ExternalReviewers);
                            }
                            if (result.ErrorMessages) {
                                var s = "";
                                for (var i = 0; i < result.ErrorMessages.length; i++) {
                                    s += "<li>" + result.ErrorMessages[i] + "</li>";
                                }
                                ShowMessage(s);
                            }
                        }
                    }
                });
            },
            destroy: {
                url: crudServiceBaseUrl + "ExternalReviewersDestroy",
                dataType: "json"
            },
            create: {
                url: crudServiceBaseUrl + "ExternalReviewersCreate",
                dataType: "json"
            },
            parameterMap: function (options, operation) {
                if (operation !== "read" && options.models) {
                    return { models: kendo.stringify(options.models) };
                }
            }
        },
        batch: true,
        pageSize: 10,
        serverPaging: false,
        serverFiltering: false,
        schema: {
            model: {
                id: "ID",
                fields: {
                    Name: { from: "Name", type: "string", editable: true, nullable: false },
                    Email: { from: "Email", type: "string", editable: true, nullable: false },
                    ClientCode: { from: "ClientCode", type: "string", editable: false, nullable: false },
                    DivisionCode: { from: "DivisionCode", type: "string", editable: false, nullable: false },
                    ProductCode: { from: "ProductCode", type: "string", editable: false, nullable: false },
                    JobNumber: { from: "JobNumber", type: "number", editable: false, nullable: false },
                    JobComponentNumber: { from: "JobComponentNumber", type: "number", editable: false, nullable: false },
                    IsActive: { from: "IsActive", type: "bit", editable: true, nullable: false },
                    AddedByUserCode: { from: "AddedByUserCode", type: "string", editable: false, nullable: false },
                    AddedDate: { from: "AddedDate", type: "date", editable: false }
                }
            }
        },
        filter: {
            field: "ClientCode",
            operator: "equals",
            value: clientCode
        }
    });
    var grid = $("#proofingExternalReviewerGrid").kendoGrid({
        dataSource: proofingExternalReviewerGridDataSource,
        navigatable: true,
        filterable: {
            operators: {
                string: {
                    contains: "Contains",
                    doesnotcontain: "Does not contain",
                    startswith: "Starts with",
                    endswith: "Ends with"
                }
            },
            mode: "menu"
        },
        filter: function (e) {
        },
        pageable: {
            pageSizes: [10, 20, 50, 100, "all"],
            numeric: false
        },
        toolbar: [
            { template: kendo.template($('#gridToolbarTemplate').html()) }
        ],
        columns: [
            {
                field: "Name",
                editable: function (dataItem) {
                    return enabledRegularEdit();
                },
                title: "Full Name",
                filterable: {
                    extra: false
                }
            },
            {
                field: "Email",
                editable: function (dataItem) {
                    return enabledRegularEdit();
                },
                title: "Email Address",
                filterable: {
                    extra: false
                }
            },
            {
                field: "ClientCode",
                title: "Client",
                width: 120,
                filterable: {
                    extra: false
                }
            },
            //{
            //    field: "DivisionCode",
            //    title: "Division", width: 95
            //},
            //{
            //    field: "ProductCode",
            //    title: "Product", width: 95
            //},
            {
                field: "IsActive",
                editable: function (dataItem) {
                    return enabledRegularEdit();
                },
                title: "Active?",
                template: "#= IsActive ? 'Yes' : 'No' #",
                width: 85,
                editor: isActiveCheckBox,
                filterable: false,
                headerAttributes: {
                    "class": "table-cell",
                    style: "text-align: center;"
                },
                attributes: {
                    "class": "table-cell",
                    style: "text-align: center;"
                }
            },
          //{ command: "destroy", title: "&nbsp;", width: 150 }
        ],
        editable: true,
        sortable: true
    });
    grid.find(".k-grid-toolbar").on("click", ".wv-save", function (e) {
        e.preventDefault();
        $("#proofingExternalReviewerGrid").data("kendoGrid").saveChanges();
        disableSaveButtonState();
        disableCancelButtonState();
    });
    grid.find(".k-grid-toolbar").on("click", ".wv-cancel", function (e) {
        e.preventDefault();
        disableSaveButtonState();
        disableCancelButtonState();
        $("#proofingExternalReviewerGrid").data("kendoGrid").cancelChanges();
    });
    function isActiveCheckBox(container, options) {
        $('<input class="k-checkbox" type="checkbox" name="IsActive" data-type="boolean" data-bind="checked:IsActive">').appendTo(container);
    }
    if (!clientCode || clientCode == null || clientCode == undefined) {
        clearFilters();
    }
    //var saveButton = $(".wv-save").kendoButton({ click: disableSaveButtonState });
    //var cancelButton = $(".wv-cancel").kendoButton({ click: disableCancelButtonState });
    changeSaveButtonState(false);
    changeCancelButtonState(false);
});

