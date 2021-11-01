AdvantageMobile_UI.project_list = function (params, viewInfo) {

    var searchVal = ko.observable("");

    var projectList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetProjects', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
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
                var strStart = "";
                var strDue = "";
                var hasStart = false;
                var hasDue = false;
                var startDueCSS = "";
                var startCSS = "";
                var dueCSS = "";
                var commaCSS = "";
                var floatStartCSS = "";
                if (item.StartDate != undefined) {
                    hasStart = true
                    strStart = item.StartDate.toShortDateString();
                } else {
                    strStart = "--";
                };
                if (item.ProcessDate != undefined) {
                    hasDue = true;
                    strDue = item.ProcessDate.toShortDateString();
                    taskDueCSS = setDueDateColorCSS(item.ProcessDate);
                } else {
                    strDue = "--"
                };
                if (hasStart == true || hasDue == true) {
                    if (hasStart == true && hasDue == true) {
                        // don't hide anything
                        floatStartCSS = "floatLeft"
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
                var status = "--";
                if (item.Status != undefined && item.Status != "") {
                    status = item.Status;
                }
                return {
                    JobNumber: item.JobNumber,
                    JobComponentNumber: item.JobComponentNumber,
                    JobComponentDescription: item.JobComponentDescription,
                    Status: status,
                    AccountExecutiveFullName: item.AccountExecutiveFullName,
                    statusText: localizeString('Status') + ':',
                    startText: localizeString('Start') + ':',
                    dueText: localizeString('Due') + ':',
                    StartDate: strStart,
                    DueDate: strDue,
                    itemHeaderText: jobDisplay(item.JobNumber, item.JobComponentNumber, item.JobComponentDescription),
                    startDueCSS: startDueCSS,
                    startCSS: startCSS,
                    dueCSS: dueCSS,
                    commaCSS: commaCSS,
                    floatStartCSS: floatStartCSS,
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
        projectList: projectList,
        searchVal: searchVal,
    };

    viewModel.projectList.searchQuery.subscribe(function (value) {
        viewModel.searchVal(value);
        viewModel.projectList.dataSource.load();
    });

    return viewModel;

};