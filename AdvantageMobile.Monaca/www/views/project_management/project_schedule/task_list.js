AdvantageMobile_UI.task_list = function (params, viewInfo) {

    var searchVal = ko.observable("");
    //var ds = new AdvantageMobile_UI.db.getEmployeeTaskListDataSource(AdvantageMobile_UI.CurrentUser.EmployeeCode(), "");
    var resetSkip = false;
    var loadPanelVisible = ko.observable(false);
    var loadPanelMessage = localizeString('Loading');
    var selectedItem;

    var taskListDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
            var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
            var skip = loadOptions.skip;
            var take = loadOptions.take;
            if (viewModel.taskList.dataSource.pageIndex() != 0 && resetSkip == true) {
                skip = 0;
                loadOptions.skip = 0;
                take = take * viewModel.taskList.dataSource.pageIndex();
                loadOptions.take = take;
            };
            AdvantageMobile_UI.db.get('GetTasks', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                SearchValue: searchVal(),
                filter: filterOptions,
                sort: sortOptions,
                skip: skip,
                take: take
            }).done(function (data) {
                d.resolve(data);
                if (resetSkip == true && selectedItem != undefined) {
                } else {
                    loadOptions.take = taskListDataSource.pageSize;
                };
                resetSkip = false;
            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        },
        pageSize: 12,
        map: function (item) {

            var strStart = "";
            var strDue = "";
            var boolTmpCmplt = false;
            var tmpCmpltIcon = "icon_check";
            var hasStart = false;
            var hasDue = false;

            var taskPriorityIndicatorCSS = "card-indicator task-priority-pending";
            var taskDueCSS = "";
            var taskCardCSS = "card-content";
            var startDueCSS = "";
            var startCSS = "";
            var dueCSS = "";
            var commaCSS = "";
            var floatStartCSS = "";
            var lineLabelCSS = "list-line";

            if (item.TaskStatus) {
                taskPriorityIndicatorCSS = setTaskPriorityIndicatorCSS(item.TaskStatus);
            };
            if (item.StartDate != undefined) {
                hasStart = true
                strStart = item.StartDate.toShortDateString();
            };
            if (item.DueDate != undefined) {
                hasDue = true;
                strDue = item.DueDate.toShortDateString();
                taskDueCSS = setDueDateColorCSS(item.DueDate);
            };
            if (item.TempCompleteDate != null) {
                boolTmpCmplt = true;
                tmpCmpltIcon = "icon_undo";
                //taskCardCSS = "card-content line-through"
            };
            if (boolTmpCmplt == true) {
                taskCardCSS = taskCardCSS + " line-through";
                lineLabelCSS = lineLabelCSS + " line-through";
                startCSS = startCSS + " line-through";
                dueCSS = dueCSS + " line-through";
            };
            if (hasStart == true || hasDue == true) {
                if (hasStart == true && hasDue == true) {
                    // don't hide anything
                    floatStartCSS = "floatLeft"
                    if (boolTmpCmplt == true) {
                        floatStartCSS = floatStartCSS + " line-through";
                    }
                } else {
                    commaCSS = "hide";
                    if (hasStart == false) {
                        startCSS = "hide";
                    };
                    if (hasDue == false) {
                        dueCSS = "hide";
                    };
                };
            } else {
                startDueCSS = "hide";  // hide all
            };
            var cdp = "";
            if (item.ClientDivisionProductCodes != undefined) {
                cdp = item.ClientDivisionProductCodes;
                cdp = cdp.slashToPipe();
            };
            var jobData = "";
            jobData = item.JobData.slashToPipe();
            return {
                JobNumber: item.JobNumber,
                JobComponentNumber: item.JobComponentNumber,
                SequenceNumber: item.SequenceNumber,
                Description: item.TaskDescription,
                TaskStatus: setPriority(item.TaskStatus),
                StartDate: strStart,
                DueDate: strDue,
                statusText: localizeString('Status') + ':',
                startText: localizeString('Start') + ':',
                dueText: localizeString('Due') + ':',
                jobData: jobData,
                TaskPriorityIndicatorCSS: taskPriorityIndicatorCSS,
                TaskDueCSS: taskDueCSS,
                IsTempComplete: boolTmpCmplt,
                TempCompleteDate: item.TempCompleteDate,
                TempCompleteIcon: tmpCmpltIcon,
                CardCSS: taskCardCSS,
                startDueCSS: startDueCSS,
                startCSS: startCSS,
                dueCSS: dueCSS,
                commaCSS: commaCSS,
                floatStartCSS: floatStartCSS,
                lineLabelCSS: lineLabelCSS,
                cdp: cdp
            };
        }
    });

    var taskList = {
        dataSource: taskListDataSource,
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        paginate: true,
        pageLoadMode: "scrollBottom",
       pullRefreshEnabled: true,
        onItemClick: function (e) {
            selectedItem = e;
        },
        onContentReady: function (e) {
            //alert("contentReady");
            //if (resetSkip == true && selectedItem != undefined) {
            //    $("#dxTaskList").dxList("instance").scrollToItem(selectedItem);
            //    //alert(clickedItemIndex)
            //};
            //resetSkip = false;
            if (resetSkip == true && selectedItem != undefined) {
                $("#dxTaskList").dxList("instance").scrollToItem(selectedItem);
            };
            resetSkip = false;
        }
    };

    //function markTempComplete(e, itemData) {

    //    if (itemData.IsTempComplete == false) {
    //        AdvantageMobile_UI.db.markTaskTempComplete(itemData.JobNumber, itemData.JobComponentNumber, itemData.SequenceNumber);
    //    } else {
    //        AdvantageMobile_UI.db.unMarkTaskTempComplete(itemData.JobNumber, itemData.JobComponentNumber, itemData.SequenceNumber);
    //    };

    //    $(document).ajaxComplete(function () {
    //        viewModel.taskList.dataSource.load();
    //    });

    //};

    function markTempComplete(e, itemData) {

        if (itemData.IsTempComplete == false) {
            _markTaskTempComplete(itemData.JobNumber, itemData.JobComponentNumber, itemData.SequenceNumber);
        } else {
            _unMarkTaskTempComplete(itemData.JobNumber, itemData.JobComponentNumber, itemData.SequenceNumber);
        };


    };

    /*********************** TEMP ***********************/

    function _markTaskTempComplete(jobNumber, jobComponentNumber, sequenceNumber) {
        loadPanelVisible(true);
        var d = new $.Deferred();
        var success = false;
        AdvantageMobile_UI.db.get('MarkTaskTempComplete', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber,
            SequenceNumber: sequenceNumber,
        }).done(function (data) {
            d.resolve(data);
            //AdvantageMobile_UI.Messages.toastSuccess();
            //viewModel.taskList.dataSource.pageIndex(0);
            resetSkip = true;
            loadPanelVisible(false);
            viewModel.taskList.dataSource.load();
        }).fail(function (data) {
            loadPanelVisible(false);
            handleDataServiceError(data);
        })
        return d.promise();
    };
    function _unMarkTaskTempComplete(jobNumber, jobComponentNumber, sequenceNumber) {
        loadPanelVisible(true);
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('UnMarkTaskTempComplete', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber,
            SequenceNumber: sequenceNumber,
        }).done(function (data) {
            d.resolve(data);
            //AdvantageMobile_UI.Messages.toastSuccess();
            //viewModel.taskList.dataSource.pageIndex(0);
            resetSkip = true;
            loadPanelVisible(false);
            viewModel.taskList.dataSource.load();
        }).fail(function (data) {
            loadPanelVisible(false);
            handleDataServiceError(data);
        })
        return d.promise();
    };

    /**********************************************/

    function viewShowing(e) {

    };
    function viewShown(e) {

    };

    var viewModel = {
        viewShowing: viewShowing,
        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,
        viewShown: viewShown,
        taskList: taskList,
        searchVal: searchVal,
        markTempComplete: markTempComplete,
    };

    viewModel.taskList.searchQuery.subscribe(function (value) {
        viewModel.searchVal(value);
        viewModel.taskList.dataSource.load();
    });

    return viewModel;

};