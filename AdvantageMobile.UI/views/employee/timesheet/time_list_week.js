AdvantageMobile_UI.time_list_week = function (params, viewInfo) {

    var selectedDate = ko.observable(new Date);
    var title = ko.observable('');
    var timeApprovalActive = AdvantageMobile_UI.CurrentUser.TimeApprovalActive();
    var approvalComment = ko.observable();

    var loadPanel = {
        message: localizeString('Please Wait'),
        visible: ko.observable(false),
        shading: false
    };

    var timeList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                //alert(selectedDate.toShortDateString());
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetTimeSummary', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    Group: 0,
                    Date: viewModel.selectedDate().toShortDateString(),
                    filter: filterOptions,
                    sort: sortOptions,
                    skip: skip,
                    take: take
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
                return d.promise();
            },
            pageSize: 15,
            map: function (item) {
                var submitButtonVisible = false;
                var submitButtonIcon = "";
                var submitButtonText = localizeString('Submit');
                var approvalCommentsButtonVisible = false
                if (timeApprovalActive == true) {
                    if (item.TimeEntryStatusID == 1 || item.TimeEntryStatusID == 3 || item.TimeEntryStatusID == 4) {
                        submitButtonVisible = true
                        approvalCommentsButtonVisible = true
                    };
                    if (item.TimeEntryStatusID == 2) {  //approved
                        approvalCommentsButtonVisible = true
                    };
                    if (item.TimeEntryStatusID == 1) {  //denied
                        submitButtonIcon = "" 
                        submitButtonText = localizeString('Unsubmit');
                    };
                };
                return {
                    StartDate: item.StartDate.toUtcShortDateString(),
                    EndDate: item.EndDate.toUtcShortDateString(),
                    TotalHours: item.TotalHours.toTwoDecimalPlaces(),
                    TimeEntryStatusID: item.TimeEntryStatusID,
                    TimeEntryStatus: setTimeEntryStatus(item.TimeEntryStatusID),
                    PercentOfStandardHours: item.PercentOfStandardHours + '%',
                    StandardHours: item.StandardHours.toTwoDecimalPlaces(),
                    IsPostPeriodClosed: item.IsPostPeriodClosed,
                    totalHoursText: localizeString('Total Hours') + ':',
                    statusText: localizeString('Status') + ':',
                    submitButtonVisible: submitButtonVisible,
                    submitButtonIcon: submitButtonIcon,
                    submitButtonText: submitButtonText,
                    approvalCommentsButtonText: "Approval Comments",
                    approvalCommentsButtonVisible: approvalCommentsButtonVisible
                };
            }
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        paginate: true,
        pageLoadMode: "scrollBottom",
        pullRefreshEnabled: true
    };
    var navBar = {
        items: [
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Previous') + ' ' + localizeString('Week'), onClick: goPrevious } },
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Next') + ' ' + localizeString('Week'), onClick: goNext } }/*,
            { location: 'center', text: localizeString('For Week Of') + ': ' }*/
        ],
    };
    var approvalCommentPopUp = {
        height: "auto",
        visible: ko.observable(false),
        showTitle: true,
        title: localizeString("Approval Comments"),
        fullScreen: false
    };
    var okApprovalCommentButton = {
        text: "OK",
        onClick: function (e) {
            approvalCommentPopUp.visible(false);
        },
    };

    function viewShowing() {
        //alert(AdvantageMobile_UI.CurrentUser.EmployeeCode());
        //alert(AdvantageMobile_UI.CurrentUser.TimeApprovalActive());
        if (params.settings) {
            if (params.settings.date) {
                viewModel.selectedDate(new Date(params.settings.date));
            };
        };
        load();
    };
    function goNext(e) {
        var newDate = new Date(viewModel.selectedDate().addDays(6));
        viewModel.selectedDate(newDate);
        load();
    };
    function goPrevious(e) {
        var newDate = new Date(viewModel.selectedDate().addDays(-6));
        viewModel.selectedDate(newDate);
        load();
    };
    function load() {
        viewModel.timeList.dataSource.load();
        viewModel.title(viewModel.selectedDate().weekSpanUTC(0));
    };
    function showApprovalComments(e, itemData) {
        //alert(itemData.StartDate);
        // load data
        
        AdvantageMobile_UI.db.get('GetEmployeeTime', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            Date: new Date(itemData.StartDate).toShortDateString()
        })
        .done(function (data) {
            var employeeTime = new AdvantageMobile_UI.EmployeeTimeViewModel(data);
            viewModel.approvalComment(employeeTime.ApprovalNotes());
        })
        .fail(function (data) {
            handleDataServiceError(data);
        });

        //var employeeTime = new AdvantageMobile_UI.EmployeeTimeViewModel();
        approvalCommentPopUp.visible(true);
        
    };
    function submitTime(e, itemData) {
        //alert(itemData.TimeEntryStatusID);
        //alert(itemData.StartDate);
        var approve = true;
        if (itemData.TimeEntryStatusID == 1 || itemData.TimeEntryStatusID == 3) {
            approve = false;
        };
        var date = new Date(itemData.StartDate);
        //alert(AdvantageMobile_UI.CurrentUser.EmployeeCode());
        //alert(date.toShortDateString());
        //alert(approve);
        loadPanel.visible(true);
        AdvantageMobile_UI.db.get('SubmitDayForTimeApproval', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            EmployeeDate: date.toShortDateString(),
            Approve: approve
        }).done(function (data) {
            loadPanel.visible(false);
            if (data == "SUCCESS") {
                AdvantageMobile_UI.Messages.toastSuccess();
                viewModel.timeList.dataSource.load();
            } else {
                AdvantageMobile_UI.Messages.toastError(localizeString('Save Failed') + ":  " + data);
            };
        }).fail(function (data) {
            loadPanel.visible(false);
            handleDataServiceError(data);
        });

    };
    var viewModel = {
        //  Put the binding properties here
        title: title,
        viewShowing: viewShowing,
        selectedDate: selectedDate,
        timeList: timeList,
        navBar: navBar,
        goNext: goNext,
        goPrevious: goPrevious,
        submitTime: submitTime,
        loadPanel: loadPanel,
        approvalCommentPopUp: approvalCommentPopUp,
        okApprovalCommentButton: okApprovalCommentButton,
        showApprovalComments: showApprovalComments,
        approvalComment: approvalComment,
    };
    return viewModel;
};