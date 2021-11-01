AdvantageMobile_UI.time_template_list = function (params, viewInfo) {

    function viewShown(e) {

    };

    var templateList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetTimeTemplates', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    filter: filterOptions,
                    sort: sortOptions,
                    skip: skip,
                    take: take
                }).done(function (data) {
                    d.resolve(data);
                })
                return d.promise();
            },
            pageSize: 15,
            map: function (item) {
                var jobAndComponent = "";
                if (item.JobAndComponent != undefined && item.JobAndComponent != "") {
                    jobAndComponent = item.JobAndComponent;
                    jobAndComponent = jobAndComponent.dashToPipe();
                    jobAndComponent = jobAndComponent.splice(11, 0, " - ");
                }
                return {
                    ID: item.ID,
                    FunctionDescription: item.FunctionDescription,
                    JobAndComponent: jobAndComponent,
                    Hours: item.EmployeeHours,
                    hoursText: localizeString('Hours') + ':',
                };
            }
        }),
        rendered: ko.observable(false),
        paginate: true,
        pageLoadMode: "scrollBottom",
       pullRefreshEnabled: true
    };

    var viewModel = {
        //  Put the binding properties here
        viewShown: viewShown,
        templateList: templateList,

    };

    return viewModel;
};






































////////////AdvantageMobile_UI.time_template_list = function (params, viewInfo) {
////////////    "use strict";

////////////    var shouldReload = false,
////////////        dataSource;

////////////    function handleEmployeeTimeTemplatesModification() {
////////////        shouldReload = true;
////////////    }

////////////    function viewShown(e) {
////////////        if (shouldReload) {
////////////            shouldReload = false;
////////////            dataSource.pageIndex(0);
////////////            dataSource.load();
////////////        }
////////////    }

////////////    function viewDisposing() {
////////////        AdvantageMobile_UI.db.EmployeeTimeTemplates.modified.remove(handleEmployeeTimeTemplatesModification);
////////////    }

////////////    dataSource = new DevExpress.data.DataSource({
////////////        store: AdvantageMobile_UI.db.EmployeeTimeTemplates,
////////////        map: function (item) {
////////////            return new AdvantageMobile_UI.EmployeeTimeTemplateViewModel(item);
////////////        }
////////////    });

////////////    AdvantageMobile_UI.db.EmployeeTimeTemplates.modified.add(handleEmployeeTimeTemplatesModification);

////////////    return {
////////////        dataSource: dataSource,
////////////        viewShown: viewShown,
////////////        viewDisposing: viewDisposing
////////////    };
////////////};