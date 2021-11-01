AdvantageMobile_UI.job_list = function (params) {
    var searchVal = ko.observable("");
    var jobList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get("SearchForTimesheetJobs", {
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
            pageSize: 12,
            map: function (item) {
                return {
                    JobNumber: item.JobNumber,
                    JobComponentNumber: item.JobComponentNumber,
                    JobComponentDescription: item.JobComponentDescription,
                    JobDisplay: jobDisplay(item.JobNumber, item.JobComponentNumber, item.JobComponentDescription),
                    CdpDisplay: item.ClientCode + " | " + item.DivisionCode + " | " + item.ProductCode
                };
            }
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        paginate: true,
        pageLoadMode: "scrollBottom",
        pullRefreshEnabled: true
    };
    function viewShowing(e) {

    };
    var viewModel = {
        viewShowing: viewShowing,
        jobList: jobList,
        searchVal: searchVal,
    };

    viewModel.jobList.searchQuery.subscribe(function (value) {
        viewModel.searchVal(value);
        viewModel.jobList.dataSource.load();
    });

    return viewModel;
};