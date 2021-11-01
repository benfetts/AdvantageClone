AdvantageMobile_UI.TestView = function (params, viewInfo) {

    //var alertPriorities = [
    //        { id: 1, alphaCode: 'HH', name: localizeString('Highest') },
    //        { id: 2, alphaCode: 'H', name: localizeString('High') },
    //        { id: 3, alphaCode: '--', name: '--' },
    //        { id: 4, alphaCode: 'L', name: localizeString('Low') },
    //        { id: 5, alphaCode: 'LL', name: localizeString('Lowest') },
    //];
    //var prioritySelectBox = {
    //    dataSource: alertPriorities,
    //    displayExpr: 'name',
    //    valueExpr: 'id',
    //    value: ko.observable()
    //};

    //var templatesLoaded = false;
    //var templateId = ko.observable();
    //var templatesDataSource = new DevExpress.data.DataSource({
    //    load: function () {
    //        //if (templatesLoaded == false) {
    //            var d = new $.Deferred();
    //            AdvantageMobile_UI.db.get('GetAssignmentTemplates', {
    //            }).done(function (data) {
    //                d.resolve(data);
    //                templatesLoaded = true;
    //            }).fail(function (data) {
    //                handleDataServiceError(data);
    //            })
    //            return d.promise();
    //        //};
    //    },
    //    map: function (item) {
    //        return new AdvantageMobile_UI.AlertAssignmentTemplateViewModel(item);
    //    },
    //    byKey: function (key) {
    //        if (key && isNaN(key) == false) {
    //            return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'AlertAssignmentTemplates(' + key + ')');
    //        }
    //    }
    //});
    //var templatesSelectBox = {
    //    dataSource: templatesDataSource,
    //    displayExpr: 'Name',
    //    valueExpr: 'ID',
    //    value: templateId,
    //    //valueChangeAction: onTemplatesChange,
    //    disabled: ko.observable(false),
    //    visible: ko.observable(true)
    //};

    //var taskTile = {
    //    dataSource: AdvantageMobile_UI.db.getEmployeeTaskListDataSource(AdvantageMobile_UI.CurrentUser.EmployeeCode()),
    //    baseItemWidth: $(window).width() - 80,
    //    visible: false,
    //};
    //var taskList = {
    //    dataSource: AdvantageMobile_UI.db.getEmployeeTaskListDataSource(AdvantageMobile_UI.CurrentUser.EmployeeCode()),
    //    rendered: ko.observable(false),
    //    searchQuery: ko.observable().extend({ throttle: 1000 }),
    //    pullRefreshEnabled: true
    //};
    //function onBookmarkClick() {
    //    DevExpress.ui.dialog.alert("onBookmarkClick");
    //}

    var clientsDataSource = new DevExpress.data.DataSource({
        load: function (loadOptions) {
            var d = new $.Deferred();
            var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
            var skip = loadOptions.skip;
            var take = loadOptions.take;
            var searchVal = "";
            if (loadOptions.searchValue != null) {
                searchVal = loadOptions.searchValue;
            }
            AdvantageMobile_UI.db.get('GetClients', {
                filter: searchVal,
                skip: skip,
                take: take
            }).done(function (data) {
                d.resolve(data);
            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        },
        byKey: function (key) {
            if (key && key.toString() != '') {
                return $.getJSON(AdvantageMobile_UI.CurrentUser.ServicesURL() + 'Clients(\'' + key.toString() + '\')');
            }
        }
    });



    var viewModel = {
        //alertPriorities: alertPriorities,
        //prioritySelectBox: prioritySelectBox,
        //buttonSignIn: ko.observable(""),
        onButtonClientTestClick: function (e) {
            AdvantageMobile_UI.app.navigate({
                view: "Clients"
            });
        },
        viewShown: function () {
            //DevExpress.ui.notify('Use this page to launch test pages.  Remember that no views can have the same name.');

        },
        clientsDataSource: clientsDataSource,
        //templateId: templateId,
        //templatesDataSource: templatesDataSource,
        //templatesSelectBox: templatesSelectBox,
        //taskTile: taskTile,
        //taskList: taskList,
        //onBookmarkClick: onBookmarkClick,
    };

    return viewModel;

};