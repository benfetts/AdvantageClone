AdvantageMobile_UI.view_alert_recipients = function (params, viewInfo) {

    var alertId = ko.observable(0);
    var isAssignment = ko.observable(false);
    var jobNumber = ko.observable();
    var clientCode = ko.observable();
    //or pass the whole alert viewmodel??

    var recipientList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetAlertRecipients', {
                    AlertID: alertId(),
                    filter: filterOptions,
                    sort: sortOptions,
                    skip: skip,
                    take: take
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
                return d.promise();
            },
            pageSize: 15
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        pullRefreshEnabled: true,
        paginate: true,
        pageLoadMode: "scrollBottom",
        //onItemClick: recipientClick,
    };

    function viewShown(e) {

    };
    function viewShowing(e) {
        if (params.settings.alertId) {
            alertId(params.settings.alertId);
            recipientList.dataSource.load();
        };
    };
    function viewDisposing() {

    };
    //function recipientClick() {
    //    AdvantageMobile_UI.Messages.notImplemented();
    //};
    function showAddRecipient() {
        AdvantageMobile_UI.app.navigate({
            view: "select_recipients",
            settings: { alertId: viewModel.alertId(), jobNumber: 0, jobComponenNumber: 0 }
        });
    };
    var viewModel = {
        viewShown: viewShown,
        viewShowing: viewShowing,
        viewDisposing: viewDisposing,
        alertId: alertId,
        recipientList: recipientList,
        showAddRecipient: showAddRecipient
    };

    return viewModel;

};