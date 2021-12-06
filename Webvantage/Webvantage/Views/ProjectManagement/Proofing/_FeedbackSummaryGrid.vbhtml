@ModelType Generic.List(Of AdvantageFramework.ConceptShare.ConceptShareFeedbackLog)
<div id="FeedbackLogGrid"></div>
<script>
    function filenameClick(e) {
        console.log("filenameClick", e);
        console.log("value", $(e).text());
        navigator.clipboard.writeText($(e).text());
        window.parent.showNotification("Filename copied to clipboard.", "success");
    }
    $(document).ready(function () {
        var feedbackSummaryLogGridDataSource;
        var crudServiceBaseUrl = window.appBase + "ProjectManagement/Proofing/";
        feedbackSummaryLogGridDataSource = new kendo.data.DataSource({
            transport: {
                read: function(e) {
                    $.ajax({
                        url: crudServiceBaseUrl + "FeedbackSummaryLogGet",
                        dataType: "json",
                        method: "GET",
                        success: function (result) {
                            e.success(result);
                        //    console.log("SUCCESS!", result);
                        },
                        error: function (result) {
                            e.error(result);
                        //    console.log("FAIL!", result);
                        }
                    });
                },
                update: function (e) {
                    $.ajax({
                        url: crudServiceBaseUrl + "FeedbackSummaryLogUpdate",
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
                                refreshGrid();
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
                parameterMap: function (options, operation) {
                    if (operation !== "read" && options.models) {
                        return { models: kendo.stringify(options.models) };
                    }
                }
            },
            batch: true,
            pageSize: 15,
            serverPaging: false,
            serverFiltering: false,
            schema: {
                model: {
                    id: "ID",
                    fields: {
                        AlertID: { from: "AlertID", type: "number", editable: false, nullable: false },
                        ReviewID: { from: "ReviewID", type: "number", editable: false, nullable: false },
                        ProjectID: { from: "ProjectID", type: "number", editable: false, nullable: false },
                        JobNumber: { from: "JobNumber", type: "number", editable: false, nullable: false },
                        JobComponentNumber: { from: "JobComponentNumber", type: "number", editable: false, nullable: false },
                        Filename: { from: "Filename", type: "string", editable: false, nullable: true },
                        BackupDate: { from: "BackupDate", type: "date", editable: false, nullable: true },
                        BackedUp: { from: "BackedUp", type: "bit", editable: false, nullable: true }
                    }
                }
            }
        });
        var grid = $("#FeedbackLogGrid").kendoGrid({
            dataSource: feedbackSummaryLogGridDataSource,
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
                pageSizes: [5, 10, 20, 50, 100, "all"],
                numeric: false
            },
            columns: [
                {
                    field: "AlertID",
                    title: "Alert ID",
                    width: 70,
                    filterable: false
                },
                {
                    field: "ReviewID",
                    title: "Review ID",
                    width: 80,
                    filterable: false
                },
                {
                    field: "JobNumber",
                    title: "Job",
                    width: 65,
                    filterable: false
                },
                {
                    field: "JobComponentNumber",
                    title: "Component",
                    width: 74,
                    filterable: false
                },
                {
                    field: "Filename",
                    title: "Filename",
                    template: "<div style='cursor:pointer;' onclick='filenameClick(this)'>#=Filename#</div>",
                    filterable: {
                        extra: false
                    }
                },
                {
                    command: {
                        text: "Download",
                        click: downloadFeedbackSummary
                    },
                    title: " ",
                    width: "110px"
                },
                {
                    command: {
                        text: "Try Email",
                        click: downloadFeedbackSummaryEmail
                    },
                    title: " ",
                    width: "110px"
                },
                {
                    command: {
                        text: "Mark as received",
                        click: markAsRecieved
                    },
                    title: " ",
                    width: "148px"
                },
                //{
                //    field: "BackedUp",
                //    title: "Received?",
                //    template: "#= BackedUp ? 'Yes' : 'No' #",
                //    width: 85,
                //    //editor: isBackedUpCheckBox,
                //    filterable: false,

                //    headerAttributes: {
                //        "class": "table-cell",
                //        style: "text-align: center;"
                //    },
                //    attributes: {
                //        "class": "table-cell",
                //        style: "text-align: center;"
                //    }
                //},
                //{
                //    field: "EmployeeCode",
                //    title: "Employee Code",
                //    width: 120,
                //    filterable: {
                //        extra: false
                //    }
                //},
                {
                    field: "BackupDate",
                    title: "Last Received",
                    format: "{0:G}",
                    width: 180,
                    filterable: false
                },
                {
                    command: {
                        text: "Mark NOT received",
                        click: markAsFailed
                    },
                    title: " ",
                    width: "165px"
                }
            ],
            editable: false,
            sortable: true
        });
        function downloadFeedbackSummaryEmail(e) {
            e.preventDefault();
            grid.select($(e.currentTarget).closest("tr"));
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            if (dataItem) {
                var hasEmail = false;
                var emailAddress = $("#emailAddress").val();
                if (emailAddress && emailAddress != "") {
                    hasEmail = true;
                } else {
                    alert("No email address!");
                    return false;
                }
                var data = {
                    AlertID: dataItem.AlertID,
                    ProjectID: dataItem.ProjectID,
                    ReviewID: dataItem.ReviewID,
                    ID: dataItem.ID,
                    EmailAddress: emailAddress
                }
                $.get({
                    url: crudServiceBaseUrl + "TryGetFeedbackSummary",
                    dataType: "json",
                    data: data
                }).always(function (response) {
                    window.parent.showNotification("Set <strong>Mark as received</strong> once you get the report from email.", "success");
                });
            }
        }
        function downloadFeedbackSummary(e) {
            e.preventDefault();
            grid.select($(e.currentTarget).closest("tr"));
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            if (dataItem) {
                var hasEmail = false;
                var emailAddress = ""; //$("#emailAddress").val();
                //if (emailAddress && emailAddress != "") {
                //    hasEmail = true;
                //}
                var data = {
                    AlertID: dataItem.AlertID,
                    ProjectID: dataItem.ProjectID,
                    ReviewID: dataItem.ReviewID,
                    ID: dataItem.ID,
                    EmailAddress: emailAddress
                }
                console.log("data", data);
                if (hasEmail == false) {
                    showProgress();
                }
                $.get({
                    url: crudServiceBaseUrl + "TryGetFeedbackSummary",
                    dataType: "json",
                    data: data
                }).always(function (response) {
                    hideProgress();
                    if (response) {
                        //console.log("TryGetFeedbackSummary", response);
                        if (response.Success == true) {
                            if (hasEmail == false) {
                                window.location.href = crudServiceBaseUrl + 'DownloadFeedbackSummary?Key=' + response.Key;
                                _markAsRecieved(dataItem.AlertID, dataItem.ProjectID, dataItem.ReviewID, dataItem.ID);
                            } else {
                                window.parent.showNotification("Set <strong>Mark as received</strong> once you get the report from email.", "success");
                            }
                        } else {
                            if (response.Message && response.Message != "") {
                                window.parent.showNotification(response.Message, "error");
                                //alert(response.Message);
                            }
                        }
                    }
                });
            }
        }
        function markAsRecieved(e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            if (dataItem) {
                _markAsRecieved(dataItem.AlertID, dataItem.ProjectID, dataItem.ReviewID, dataItem.ID);
            }
        }
        function _markAsRecieved(alertId, projectId, reviewId, Id) {
                var data = {
                    AlertID: alertId,
                    ProjectID: projectId,
                    ReviewID: reviewId,
                    ID: Id
                }
                $.post({
                    url: crudServiceBaseUrl + "MarkAsRecivedFeedbackSummary",
                    dataType: "json",
                    data: data
                }).always(function (result) {
                    if (result) {
                        //console.log(result);
                        if (result.Success && result.Success === true) {
                            //console.log("SUCCESS!");
                            refreshGrid();
                        } else {
                            if (result.Message && result.Message !== "") {
                                try {
                                    window.parent.showNotification(result.Message, "error");
                                    //alert(result.Message);
                                } catch (e) {
                                    //window.parent.showNotification(result.Message, "error");
                                }
                            }
                        }
                    }
                });
        }
        function markAsFailed(e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            if (dataItem) {
                var data = {
                    AlertID: dataItem.AlertID,
                    ReviewID: dataItem.ReviewID,
                    ID: dataItem.ID
                }
                $.post({
                    url: crudServiceBaseUrl + "MarkAsFailedFeedbackSummary",
                    dataType: "json",
                    data: data
                }).always(function (result) {
                    if (result) {
                        //console.log(result);
                        if (result.Success && result.Success === true) {
                            //console.log("SUCCESS!");
                            refreshGrid();
                        } else {
                            if (result.Message && result.Message !== "") {
                                try {
                                    window.parent.showNotification(result.Message, "error");
                                    //alert(result.Message);
                                } catch (e) {
                                    //window.parent.showNotification(result.Message, "error");
                                }
                            }
                        }
                    }
                });
            }
        }
        function isBackedUpCheckBox(container, options) {
            $('<input class="k-checkbox" type="checkbox" name="BackedUp" data-type="boolean" data-bind="checked:BackedUp">').appendTo(container);
        }
        function refreshGrid() {
            $("#FeedbackLogGrid").data("kendoGrid").dataSource.read();
        }
    });
</script>
