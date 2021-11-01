AdvantageMobile_UI.select_recipients = function (params, viewInfo) {

    /*
    params.settings.alertId
    params.settings.jobNumber
    params.settings.jobComponentNumber

*/
    var alertId = 0;
    var jobNumber = 0;
    var jobComponentNumber = 0;
    var selectedItems = ko.observableArray([]);
    var searchVal = ko.observable("");

    var recipientList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                AdvantageMobile_UI.db.get('GetRecipientSelect', {
                    AlertID: alertId,
                    JobNumber: jobNumber,
                    JobComponentNumber: jobComponentNumber,
                    SearchValue: searchVal()
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
                return d.promise();
            },
            map: function (item) {
                return {
                    Code: item.Code,
                    FullName: item.FullName
                };
            }
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        pullRefreshEnabled: true,
        priorityBlockStyle: ko.observable(""),
        editEnabled: true,
        selectedItems: selectedItems,
        editConfig: {
            selectionEnabled: true,
            selectionType: 'item'
        },
    };

    function handleSave() {
        var items = selectedItems();
        var length = items.length;
        var codes = "";
        if (length > 0) {
            for (var i = 0; i < length; i++) {
                codes += items[i].Code + ",";
            };
            var d = new $.Deferred();
            AdvantageMobile_UI.db.get('SaveAlertRecipients', {
                AlertID: alertId,
                Codes: codes,
            }).done(function (data) {
                d.resolve(data);
                AdvantageMobile_UI.Messages.toastSuccess();
                AdvantageMobile_UI.app.navigate(viewInfo.previousViewInfo.uri, { target: "back" });
            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        };
    };

    function viewShowing(e) {
        if (params.settings.alertId != null) {
            alertId = params.settings.alertId;
        };
        if (params.settings.jobNumber != null) {
            jobNumber = params.settings.jobNumber;
        };
        if (params.settings.jobComponentNumber != null) {
            jobComponentNumber = params.settings.jobComponentNumber;
        };
        if (alertId > 0 || jobNumber > 0 || (jobNumber > 0 && jobComponentNumber > 0)) {
            viewModel.recipientList.dataSource.load();
        };
    };
    var viewModel = {
        viewShowing: viewShowing,
        recipientList: recipientList,
        handleSave: handleSave,
        selectedItems: selectedItems,
        searchVal: searchVal,
    };

    viewModel.recipientList.searchQuery.subscribe(function (value) {
        viewModel.searchVal(value);
        viewModel.recipientList.dataSource.load();
    });

    return viewModel;
};