AdvantageMobile_UI.time_list_month = function (params, viewInfo) {

    var selectedDate = ko.observable(new Date);
    var title = ko.observable('');
    var timeList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                //alert("loading");
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetTimeSummary', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    Group: 1,
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
            pageSize: 10,
            map: function (item) {
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
                };
            }
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        paginate: true,
        pageLoadMode: "scrollBottom",
        pullRefreshEnabled: true
    };
    function viewShowing() {
        if (params.settings) {
            if (params.settings.date) {
                viewModel.selectedDate(new Date(params.settings.date));
            };
        };
        load();
    };
    var navBar = {
        items: [
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Previous') + ' ' + localizeString('Month'), onClick: goPrevious } },
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Next') + ' ' + localizeString('Month'), onClick: goNext } }/*,
            { location: 'center', text: localizeString('For Week Of') + ': ' }*/
        ],
    };
    function goNext(e) {
        var newDate = new Date(viewModel.selectedDate().addMonths(1))
        viewModel.selectedDate(newDate);
        load();
    };
    function goPrevious(e) {
        var newDate = new Date(viewModel.selectedDate().addMonths(-1))
        viewModel.selectedDate(newDate);
        load();
    };
    function load() {
        viewModel.timeList.dataSource.load();
        viewModel.title(viewModel.selectedDate().monthName());
    };
    var viewModel = {
        title: title,
        viewShowing: viewShowing,
        selectedDate: selectedDate,
        timeList: timeList,
        navBar: navBar,
        goNext: goNext,
        goPrevious: goPrevious,
    };
    return viewModel;
};