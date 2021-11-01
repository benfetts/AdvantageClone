AdvantageMobile_UI.schedule_list = function (params, viewInfo) {

    /*
        params.settings.selectedDate
    */
    var selectedDate = ko.observable(new Date);
    var thisDate = new Date;
    var title = ko.observable('');
    var bookmarkButton = buttonBookmark;
    var searchVal = ko.observable("");

    var scheduleList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetEmployeeSchedule', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    StartDate: viewModel.selectedDate().toShortDateString(),
                    EndDate: viewModel.selectedDate().toShortDateString(),
                    SearchValue: viewModel.searchVal(),
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
                var isTempComplete = false;
                var typeCode = "";
                var isTask = false;
                var hasJobAndComponent = false;
                var strStart = "";
                var strEnd = "";
                var jobAndComponentCSS = "hide";
                var jobAndComponentText = "";
                if (item.TaskTempCompleteDate) {
                    isTempComplete = true;
                };
                if (item.StartDate) {
                    strStart = item.StartDate.toShortDateString()
                };
                if (item.EndDate) {
                    strEnd = item.EndDate.toShortDateString()
                };
                if (item.IsNonTask == 0) {
                    isTask = true;
                };
                if (item.JobNumber > 0 && item.JobComponentNumber > 0) {
                    hasJobAndComponent = true;
                    jobAndComponentCSS = "";
                    jobAndComponentText = jobDisplay(item.JobNumber, item.JobComponentNumber, item.JobComponentDescription);
                };
                typeCode = item.NonTaskType;
                return {
                    IndicatorCSS: setScheduleIndicatorCSS(typeCode),
                    HeaderDisplay: item.TaskNonTaskDisplay,
                    DateDisplay: setScheduleDateDisplay(typeCode, item.StartDate, item.EndDate, item.StartTime, item.EndTime, item.NumberDays, item.IsAllDay),
                    StartDate: strStart,
                    EndDate: strEnd,
                    TrueStartDate: item.StartDate,
                    TrueEndDate: item.EndDate,
                    IsTempComplete: isTempComplete,
                    IsTask: isTask,
                    HasJobAndComponent: hasJobAndComponent,
                    JobNumber: item.JobNumber,
                    JobComponentNumber: item.JobComponentNumber,
                    SequenceNumber: item.TaskSequenceNumber,
                    jobAndComponentCSS: jobAndComponentCSS,
                    jobAndComponentText: jobAndComponentText,
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
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Previous') + ' ' + localizeString('Day'), onClick: goPrevious } },
            { location: 'center', widget: 'button', options: { type: 'normal', icon: 'icon_calendar_31', onClick: goToSelectDate } },
            { location: 'center', widget: 'button', options: { type: 'normal', icon: 'icon_star_blue', onClick: goToday } },
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Next') + ' ' + localizeString('Day'), onClick: goNext } }
        ],
    };
    function goNext(e) {
        var newDate = new Date(viewModel.selectedDate().addDays(1))
        viewModel.selectedDate(newDate);
        load();
    };
    function goToSelectDate(e) {
        AdvantageMobile_UI.app.navigate({
            view: "select_date",
            settings: { source: 0 }
        });
    };
    function goToday(e) {
        var newDate = new Date();
        viewModel.selectedDate(newDate);
        load();
    };
    function goPrevious(e) {
        var newDate = new Date(viewModel.selectedDate().addDays(-1))
        viewModel.selectedDate(newDate);
        load();
    };
    function load() {
        var today = new Date();
        if (viewModel.selectedDate().toUtcShortDateString() == today.toUtcShortDateString()) {
            viewModel.title(localizeString("Today"));
        } else {
            ////viewModel.title(Globalize.format(viewModel.selectedDate(), 'D'));
            viewModel.title(viewModel.selectedDate());
        }
        thisDate = viewModel.selectedDate();
        viewModel.scheduleList.dataSource.load();
    };

    function viewShowing(e) {
        if (params.settings.date != undefined) {
            viewModel.selectedDate(new Date(params.settings.date));
        };
        load();
    };
    var viewModel = {
        viewShowing: viewShowing,
        selectedDate: selectedDate,
        scheduleList: scheduleList,
        navBar: navBar,
        title: title,
        bookmarkButton: bookmarkButton,
        searchVal: searchVal,
    };
    viewModel.scheduleList.searchQuery.subscribe(function (value) {
        viewModel.searchVal(value);
        viewModel.scheduleList.dataSource.load();
    });

    return viewModel;

};