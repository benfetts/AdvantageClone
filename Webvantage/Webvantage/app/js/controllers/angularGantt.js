app.controller('angularGanttController', function ($scope, $rootScope, $timeout, dataService, $parse, $http, $modal) {
    $scope.JobComponentPairs = function () {
        var allJobComponentPairs = $scope.InitialJobComponentPairs;
        if ($scope.showRelatedJobs === true) {
            allJobComponentPairs = allJobComponentPairs.concat($scope.RelatedJobComponentPairs);
        }
        return allJobComponentPairs;
    };
    $scope.InitialJobComponentPairs = [];
    $scope.RelatedJobComponentPairs = [];
    $scope.tasksDataSources = [];
    $scope.ganttOptions = [];
    $scope.availableParentTasks = [];
    $scope.taskDialogActive = false;
    $scope.showRelatedJobs = false;
    $scope.showPhases = false;
    $scope.showEmployees = false;

    $scope.windowOptions = {
        title: 'Add Task',
        width: 600,
        height: 200,
        visible: false,
        modal: true
    };

    $scope.serviceRoot = $rootScope.applicationLocation() + "/ProjectSchedule";

    $scope.resetObjectArrays = function () {
        $scope.RelatedJobComponentPairs = [];
        $scope.tasksDataSources = [];
        $scope.ganttOptions = [];
        $scope.$apply();
    };

    $scope.toggleRelatedJobs = function () {
        $scope.showRelatedJobs = !$scope.showRelatedJobs;
        $scope.resetObjectArrays();
        $scope.init();
        return;
    };

    $scope.togglePhases = function () {
        $scope.showPhases = !$scope.showPhases;
        $scope.resetObjectArrays();
        $scope.init();
        return;
    };

    $scope.toggleEmployees = function () {
        $scope.showEmployees = !$scope.showEmployees;
        $scope.resetObjectArrays();
        $scope.init();
        return;
    };

    $scope.init = function () {
        var JobCompPairs = $scope.InitialJobComponentPairs;
        $(JobCompPairs).each(function () {
            var jobCompPair = this;
            dataService.getRelatedJobs(jobCompPair).then(function (result) {
                var associatedJobCompPairs = result.data;

                for (var i = 0; i < associatedJobCompPairs.length; i++) {
                    var associatedPair = associatedJobCompPairs[i];
                    var isNew = true;
                    for (var j = 0; j < $scope.InitialJobComponentPairs.length; j++) {
                        if ($scope.InitialJobComponentPairs[j].JobNumber === associatedPair.JobNumber && $scope.InitialJobComponentPairs[j].JobComponentNumber === associatedPair.JobComponentNumber) {
                            isNew = false;
                            associatedPair.IsRelatedJob = false;
                            $scope.InitialJobComponentPairs[j] = associatedPair;
                        }
                    }
                    if (isNew === true) {
                        $scope.RelatedJobComponentPairs.push(associatedPair);
                    }
                }

                //$scope.JobComponentPairs = result.data;

                for (var pairCounter = 0; pairCounter < associatedJobCompPairs.length; pairCounter++) {

                    //$scope.JobComponentPairs[pairCounter].Index = pairCounter;

                    var JobNum = associatedJobCompPairs[pairCounter].JobNumber;
                    var JobDesc = associatedJobCompPairs[pairCounter].JobDescription;
                    var JobCompNum = associatedJobCompPairs[pairCounter].JobComponentNumber;

                    var tasksDataSource = $scope.createDataSource(JobNum, JobCompNum);

                    //$scope.tasksDataSources.push(tasksDataSource);
                    $scope['tasksDataSources_' + JobNum + '_' + JobCompNum] = tasksDataSource;

                    var ganttColumns = [];

                    if ($scope.showEmployees) {
                        ganttColumns = [
                        { field: "title", title: "", width: 80 },
                        { field: "start", title: "Start Date", format: "{0:d}", width: 40, editable: true },
                        { field: "end", title: "End Date", format: "{0:d}", width: 40, editable: true },
                        { field: "employees", title: "Employees", width: 40, editable: false }
                        ];
                    } else {
                        ganttColumns = [
                        { field: "title", title: "", width: 80 },
                        { field: "start", title: "Start Date", format: "{0:d}", width: 40, editable: true },
                        { field: "end", title: "End Date", format: "{0:d}", width: 40, editable: true }
                        ];
                    }

                    var ganttOptionsObject = {
                        //toolbar: ["pdf"],
                        toolbar: [
                           //{
                           //    name: "Add",
                           //    text: "Add Task",
                           //    template: "<button class='k-button k-button-icontext k-gantt-custom-add' type='button' onclick='addTask(this)'><span class='k-icon k-i-plus'></span>Add Task</button>",
                           //    spriteCssClass: "k-tool-icon k-justifyLeft"
                           //},
                            {
                                name: "Export",
                                text: "Export",
                                template: "&nbsp;<button class='k-button k-button-icontext k-gantt-custom-export' type='button' onclick='exportPDF(this)'><span class='k-icon k-download'></span>Export</button>",
                                spriteCssClass: "k-tool-icon k-justifyLeft"
                            }
                            //,
                            //{
                            //    name: "Refresh",
                            //    text: "Refresh",
                            //    template: "&nbsp;<button class='k-button k-button-icontext k-gantt-custom-refresh' type='button' onclick='refreshData(this)'><span class='k-icon k-i-refresh'></span>Refresh</button>",
                            //    spriteCssClass: "k-tool-icon k-justifyLeft"
                            //}
                        ],
                        pdf: {
                            allPages: true,
                            fileName: JobNum + ' - ' + JobCompNum + ' ' + JobDesc + '.pdf',
                            proxyURL: $rootScope.applicationLocation() + "/export"
                        },
                        //     editable: true,
                        editable: {
                            template: $("#ganttTaskEditor").html()
                        },
                        dataSource: tasksDataSource, //$scope.tasksDataSources[pairCounter],
                        views: [
                            { type: "week", selected: true },
                            "month"
                        ],
                        columns: ganttColumns,

                        height: associatedJobCompPairs[pairCounter].CalculatedHeight,

                        showWorkHours: false,
                        showWorkDays: false,
                        add: function (e) {
                           //console.log("Task added");
                            $timeout(function () {
                                $('#' + e.sender.element.attr('id')).data("kendoGantt").refresh();
                            }, 500);
                        },
                        save: function (e) {
                           //console.log('save');
                            $timeout(function () {
                                $('#' + e.sender.element.attr('id')).data("kendoGantt").refresh();
                            }, 500);
                        },
                        dataBound: function (e) {
                            var currentGantt = $('#' + e.sender.element.attr('id')).data("kendoGantt");
                            if (currentGantt) {
                                for (var i = 0; i < currentGantt.dataSource.data().length; i++) {
                                    var item = currentGantt.dataSource.data()[i];
                                    var cellToModify = currentGantt.element.find("tr[data-uid='" + item.uid + "'] td:first-child");
                                    var originalText = $(cellToModify).text();
                                    $(cellToModify).text('');

                                    var startCell = currentGantt.element.find("tr[data-uid='" + item.uid + "'] td:nth-child(2)");
                                    var endCell = currentGantt.element.find("tr[data-uid='" + item.uid + "'] td:nth-child(3)");
                                    var employeeCell = currentGantt.element.find("tr[data-uid='" + item.uid + "'] td:nth-child(4)");
                                    var originalEmployeeText = $(employeeCell).text();
                                    $(employeeCell).text('');

                                    if (item.employees) {
                                        $(employeeCell).append("<span title='" + originalEmployeeText + "'>" + originalEmployeeText + "</span>");
                                    }
                                    if (!item.start) {
                                        $(startCell).html('<span></span>');
                                    }
                                    if (!item.end) {
                                        $(endCell).html('<span></span>');
                                    }

                                    if (item.isPhase) {
                                        var taskToModify = currentGantt.element.find("div[data-uid='" + item.uid + "']");
                                        var taskResizeHandle = taskToModify.find(".k-resize-handle");
                                        var taskContentToModify = $(taskToModify).find('.k-task-content');
                                        $(taskResizeHandle).hide();
                                        $(taskContentToModify).css('background-color', '#144875');
                                        $(cellToModify).append("<strong>" + originalText + "</strong>")
                                    } else {
                                        $(cellToModify).append("<span style='padding-left:25px;'>" + originalText + "</span>")
                                    }
                                }
                            }
                        },
                        dataBinding: function (e) {
                            var currentGantt = $('#' + e.sender.element.attr('id')).data("kendoGantt");
                            if (currentGantt) {
                                for (var i = 0; i < currentGantt.dataSource.data().length; i++) {
                                    var item = currentGantt.dataSource.data()[i];
                                    var offset = new Date().getTimezoneOffset() * 60000;
                                    var start = new Date(item.start);
                                    var end = new Date(item.end);
                                    start.setMilliseconds(start.getMilliseconds() + offset);
                                    start = new Date(start.getFullYear(), start.getMonth(), start.getDate());
                                    end = new Date(end.getFullYear(), end.getMonth(), end.getDate(), 23, 59, 59);   
                                    currentGantt.dataSource.data()[i].start = start;
                                    currentGantt.dataSource.data()[i].end = end;
                                }
                            }
                        },
                        edit: function (e) {
                            if (e.task.isPhase) {
                                showKendoAlert('Phases are read-only.');
                                e.preventDefault();
                            }
                        },
                        resizeEnd: function (e) {
                            if (e.end.getSeconds() === 0) {
                                e.end.setSeconds(e.end.getSeconds() - 1);
                            }
                        },
                        tooltip: {
                            template: "<div style='text-align:left; min-width: 200px;'><h3 style='margin: 0; padding: 0;'>#= task.title # </h3><h3 style='margin: 10px 0 10px 0; padding: 0; font-weight: normal;'>#= kendo.format(\'{0:P2}\', task.percentComplete) # </h3> Start: #= kendo.format(\'{0:d}\', task.start) # <br/> End: #= kendo.format(\'{0:d}\', task.end) # </div>"
                        }
                    };
                    $scope['ganttOptions_' + JobNum + '_' + JobCompNum] = ganttOptionsObject;
                }
            });
        });
    };

    $scope.createDataSource = function (jobNumber, jobComponentNumber) {
        var tasksDataSource = new kendo.data.GanttDataSource({
            batch: false,
            transport: {
                read: {
                    url: $scope.serviceRoot + "/GanttTasksList?JobNumber=" + jobNumber + '&JobComponentNumber=' + jobComponentNumber + '&ShowPhases=' + $scope.showPhases,
                    dataType: "jsonp"
                },
                update: {
                    url: $scope.serviceRoot + "/GanttTasksUpdate?JobNumber=" + jobNumber + '&JobComponentNumber=' + jobComponentNumber,
                    dataType: "jsonp"
                },
                destroy: {
                    url: $scope.serviceRoot + "/GanttTasksDelete?JobNumber=" + jobNumber + '&JobComponentNumber=' + jobComponentNumber,
                    dataType: "jsonp"
                },
                create: {
                    url: $scope.serviceRoot + "/GanttTasksCreate?JobNumber=" + jobNumber + '&JobComponentNumber=' + jobComponentNumber,
                    dataType: "json"
                },
                parameterMap: function (options, operation) {
                    if (operation !== "read") {
                        return { models: kendo.stringify(options.models || [options]) };
                    }
                }
            },
            schema: {
                model: {
                    id: "id",
                    fields: {
                        id: { from: "ID", type: "number" },
                        orderId: { from: "OrderID", type: "number", validation: { required: true } },
                        parentId: { from: "ParentID", type: "number", defaultValue: null, validation: { required: true } },
                        start: { from: "Start", type: "date" },
                        end: { from: "End", type: "date" },
                        title: { from: "Title", defaultValue: "", type: "string" },
                        employees: { from: "AssignedEmployees", defaultValue: "", type: "string" },
                        percentComplete: { from: "PercentComplete", type: "number" },
                        summary: { from: "Summary", type: "boolean" },
                        isPhase: { from: "IsPhase", type: "boolean" },
                        expanded: { from: "Expanded", type: "boolean", defaultValue: true }
                    }
                }
            }
        });

        return tasksDataSource;
    };

    $scope.addTask = function (jobComponentPair) {
        var currentGantt = $('#chartObject_' + jobComponentPair.JobNumber + '_' + jobComponentPair.JobComponentNumber).data("kendoGantt");
        dataService.ganttTasksListPost(jobComponentPair.JobNumber, jobComponentPair.JobComponentNumber).then(function (result) {
            $scope.availableParentTasks = result.data;
            $scope.availableParentTasks.unshift({ Title: '(None)', ID: null });
            $scope.taskDialog.center();
            $scope.taskDialog.open();
            $scope.availableParentDropdown.refresh();
            $scope.availableParentDropdown.select(0);
        });

       //console.log('add task called for ' + currentGantt.element.attr('id'));
    };

    $scope.refreshData = function (jobComponentPair) {
        var currentGantt = $('#chartObject_' + jobComponentPair.JobNumber + '_' + jobComponentPair.JobComponentNumber).data("kendoGantt");
        currentGantt.refresh();
       //console.log('refresh data called for ' + currentGantt.element.attr('id'));
    };

    $scope.exportPDF = function (jobComponentPair) {
        var currentGantt = $('#chartObject_' + jobComponentPair.JobNumber + '_' + jobComponentPair.JobComponentNumber).data("kendoGantt");
        currentGantt.saveAsPDF();
       //console.log('export pdf called for ' + currentGantt.element.attr('id'));
    };

    $scope.recalculate = function () {
        var requestData = $scope.InitialJobComponentPairs[0]; // if more than one, the controller looks for jobs in session
        requestData.RequestFrom = $('#HiddenFieldCalledFrom').val(); // project schedule = ps
        dataService.recalculateScheduleDates(requestData).then(function (result) {
            if (result.data.ErrorMessage !== null && result.data.ErrorMessage !== '') {
                showKendoAlert(result.data.ErrorMessage);
            } else {
                showKendoAlert('Recalculation was successful.');
                $scope.refresh();
            }
        })
    };

    $scope.refresh = function () {
        $scope.resetObjectArrays();
        $scope.init();
    };

    $scope.preventDrag = function (JobComponentPair) {
        var gantt = $('#chartObject_' + JobComponentPair.JobNumber + '_' + JobComponentPair.JobComponentNumber).data('kendoGantt');
        if (gantt) {
            var selector = ".k-treelist .k-grid-content";
            $(gantt.wrapper).on("mousedown", selector, function (e) {
                $(gantt.wrapper).on("mousemove.preventDrag", selector, function (e) {
                    e.stopPropagation();
                });
            })
            .on("mouseup", selector, function () {
                $(gantt.wrapper).off(".preventDrag");
            });
        }
    }

    $scope.ganttInit = function (JobComponentPair) {
        //setTimeout(function() {
        //    kendo.ui.progress($('#chartObject_' + JobComponentPair.JobNumber + '_' + JobComponentPair.JobComponentNumber).closest('div.ganttContainer'), true);
        //}, 500);
        //setTimeout(function() {
        //    kendo.ui.progress($('#chartObject_' + JobComponentPair.JobNumber + '_' +JobComponentPair.JobComponentNumber).closest('div.ganttContainer'), false);
        //}, 10000);
    }

    // $scope.init();
});
