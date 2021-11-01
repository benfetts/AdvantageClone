AdvantageMobile_UI.alert_list = function (params, viewInfo) {

    /*
        params.settings.source = 0, show assignments
        params.settings.source = 1, show alerts
    */

    var loadPanelVisible = ko.observable(false);
    var loadPanelMessage = localizeString('Loading');
    var serviceName = 'GetAlerts';
    var title = ko.observable('');
    var priorityText = "--";
    var priorityCSS = "alert-priority-container alert-priority-normal";
    var isViewingAssignments = false;
    var searchVal = ko.observable("");
    var selectedItem;
    var resetSkip = false;
    var needLoad = false;
    var thitTitle
    var alertList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {

                if (needLoad == true) {

                     var d = new $.Deferred();
                    var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                    var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                    var skip = loadOptions.skip;
                    var take = loadOptions.take;
                    if (viewModel.alertList.dataSource.pageIndex() != 0 && resetSkip == true) {
                        skip = 0;
                        loadOptions.skip = 0;
                        take = take * viewModel.alertList.dataSource.pageIndex();
                        loadOptions.take = take;
                    };
                    AdvantageMobile_UI.db.get(serviceName, {
                        EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                        SearchValue: viewModel.searchVal(),
                        filter: filterOptions,
                        sort: sortOptions,
                        skip: skip,
                        take: take
                    }).done(function (data) {
                        d.resolve(data);
                        if (resetSkip == true && selectedItem != undefined) {
                        } else {
                            loadOptions.take = alertList.dataSource.pageSize;
                        };
                        resetSkip = false;
                    }).fail(function (data) {
                        handleDataServiceError(data);
                    })
                    return d.promise();

               };
            },
            pageSize: 12,
            map: function (item) {
                var dismissCompleteIcon = "icon_garbage";
                var hasJobAndComponentNumbers = false;
                if (item.Priority) {
                    priorityText = setAlertPriorityText(item.Priority);
                    priorityCSS = setAlertPriorityCSS(item.Priority);
                };
                if (item.JobNumber && item.JobComponentNumber) {
                    if (item.JobNumber > 0 && item.JobComponentNumber > 0) {
                        hasJobAndComponentNumbers = true;
                    };
                };
                if (isViewingAssignments == true) {
                    dismissCompleteIcon = "icon_document_checked";
                };
                var jobAndComponentDisplay = "";
                if ((item.JobNumber != undefined && item.JobNumber > 0) && (item.JobComponentNumber != undefined && item.JobComponentNumber > 0)) {
                    jobAndComponentDisplay = jobDisplay(item.JobNumber, item.JobComponentNumber, item.JobComponentDescription);
                    showJobInfo = true;
                };
                var timeSource = 0;
                if (isViewingAssignments == true) {
                    timeSource = 7;
                };
                var commentSource = 1;
                if (isViewingAssignments == true) {
                    commentSource = 2;
                };
                var showDueDate = false;
                var dueDateCSS = "hide";
                var strDueDate = "";
                if (item.DueDate != undefined) {
                    dueDateCSS = "";
                    showDueDate = true;
                    strDueDate = item.DueDate.toShortDateString();
                };
                var clientDisplay = "";
                var clientDisplayCSS = "hide"
                if (item.ClientCode != undefined) {
                    //clientDisplayCSS = "";
                    clientDisplay = item.ClientCode;
                    if (item.DivisionCode != undefined) {
                        clientDisplay = clientDisplay + "/" + item.DivisionCode
                    };
                    if (item.ProductCode != undefined) {
                        clientDisplay = clientDisplay + "/" + item.ProductCode
                    };
                };
                return {
                    ID: item.ID,
                    Subject: item.Subject,
                    JobNumber: item.JobNumber,
                    JobComponentNumber: item.JobComponentNumber,
                    ClientCode: item.ClientCode,
                    DivisionCode: item.DivisionCode,
                    ProductCode: item.ProductCode,
                    AlertAssignmentTemplateID: item.AlertAssignmentTemplateID,
                    AlertAssignmentStateID: item.AlertAssignmentStateID,
                    priorityBlockText: priorityText,
                    priorityBlockCSS: priorityCSS,
                    showReassign: isViewingAssignments,
                    showTimeButtons: hasJobAndComponentNumbers,
                    jobAndComponentDisplay: jobAndComponentDisplay,
                    DismissOrCompleteIcon: dismissCompleteIcon,
                    timeSource: timeSource,
                    commentSource: commentSource,
                    isAssignment: isViewingAssignments,
                    dueText: localizeString('Due') + ':',
                    dueDateCSS: dueDateCSS,
                    strDueDate: strDueDate,
                    clientDisplayCSS: clientDisplayCSS,
                    ClientDisplay: clientDisplay
                };
            }
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        pullRefreshEnabled: true,
        priorityBlockStyle: ko.observable(""),
        paginate: true,
        pageLoadMode: "scrollBottom",
        onItemClick: function (e) {
            //clickedItemIndex = e.itemIndex;
            //alert(clickedItemIndex);
            selectedItem = e;
        },
        onContentReady: function (e) {
            if (resetSkip == true && selectedItem != undefined) {
                $("#dxAlertList").dxList("instance").scrollToItem(selectedItem);
                //alert(clickedItemIndex)
            };
            resetSkip = false;
        }
    };
    function dismissComplete(e, itemData) {
        //alert(itemData.showReassign);
        dismissCompleteAlert(itemData.ID, itemData.showReassign);
    }

    function dismissCompleteAlert(alertId, forceAssignmentComplete) {
        loadPanelVisible(true);
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('DismissCompleteAlert', {
            AlertID: alertId,
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ForceAssignmentComplete: forceAssignmentComplete,
        }).done(function (data) {
            d.resolve(data);
            needLoad = true;
            alertList.dataSource.pageIndex(0);
            alertList.dataSource.load();
            loadPanelVisible(false);
        }).fail(function (data) {
            loadPanelVisible(false);
            handleDataServiceError(data);
        })
        return d.promise();
    };
    /*********************** TEMP ***********************/

    function viewShowing() {
        var source = 0;
        try {
            if (params.settings.source != undefined) {
                source = params.settings.source
            };
        } catch (e) {
            source = 0;
        };
        switch (source) {
            case 0:

                serviceName = 'GetAssignments';
                thitTitle = localizeString('Assignments');
                isViewingAssignments = true;
                break;

            case 1:

                serviceName = 'GetAlerts';
                thitTitle = localizeString('Alerts');
                break;

        };
        needLoad = true;
        viewModel.alertList.dataSource.load();
    };
    function viewShown(e) {
        if (e.direction == "backward") {
            //alert("hi")
            viewModel.alertList.dataSource.pageIndex(0);
            viewModel.alertList.dataSource.load();
        };
        viewModel.title(thitTitle);
    };

    var viewModel = {
        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,
        viewShowing: viewShowing,
        viewShown: viewShown,
        alertList: alertList,
        title: title,
        searchVal: searchVal,
        dismissComplete: dismissComplete,
    };

    viewModel.alertList.searchQuery.subscribe(function (value) {
        viewModel.searchVal(value);
        viewModel.alertList.dataSource.load();
    });

    return viewModel;

};