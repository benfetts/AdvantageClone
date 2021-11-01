AdvantageMobile_UI.time_main = function (params, viewInfo) {

    var totalHoursThisWeek = ko.observable(0);
    var viewDateValue = ko.observable(new Date());
    var selectedViewTabValue = ko.observable(0);

    var totalHoursGuage = {
        scale: {
            startValue: 0.00,
            endValue: 40,
        },
        value: totalHoursThisWeek,
        title: {
            text: localizeString('Hours This Week')
        }
    };
    function guageClick() {
        //alert(viewDateValue());
        AdvantageMobile_UI.app.navigate({
            view: 'time_list_week',
            settings: { date: viewDateValue().toShortDateString() }
        });
    };
    var addButton = {
        title: 'Add',
        id: 'create',
        icon: 'plus',
        onExecute: function (e) {
            AdvantageMobile_UI.db.get('IsTimesheetPostPeriodClosed', {
                Date: viewModel.viewDateValue().toShortDateString()
            }).done(function (data) {
                if (data == true) {
                    AdvantageMobile_UI.Messages.toastFail(localizeString('Post Period Is Closed'));
                } else {
                    AdvantageMobile_UI.app.navigate({
                        view: "time_entry",
                        settings: { source: -1, date: viewModel.viewDateValue(), isPreFill: false }
                    });
                }
            }).fail(function (data) {
                handleDataServiceError(data);
            })
        }
    };
    var addFromMyTab = {
        onItemClick: function (e) {
            addFromMyTab.selectedIndex(-1);
            AdvantageMobile_UI.app.navigate({
                view: e.itemData.view,
                settings: {source: 0}
            });
        },
        items: [
            { text: localizeString("Jobs"), value: "jobs", view: "job_list" },
            { text: localizeString("Tasks"), value: "tasks", view: "task_list" },
            { text: localizeString("Projects"), value: "projects", view: "project_list" },
            { text: localizeString("Templates"), value: "templates", view: "time_template_list" }
        ]
        , selectedIndex: ko.observable(-1)
    };
    var dateBox = {
        value: viewDateValue,
        changeAction: viewDateChanged
    }
    var viewTab = {
        onItemClick: function (e) {
            var viewToGo = 'time_list';
            var selectedValue = 0;
            selectedValue = e.itemData.value * 1;
            switch (selectedValue) {
                case 0:
                    viewToGo = 'time_list';
                    break;
                case 1:
                    viewToGo = 'time_list_week';
                    break;
                case 2:
                    viewToGo = 'time_list_month';
                    break;
            };
            viewTab.selectedIndex(-1);
            AdvantageMobile_UI.app.navigate({
                view: viewToGo,
                settings: { source: 0, date: this.viewDateValue(), viewBy: e.itemData.value }
            });
        },
        items: [
            { text: localizeString("By Day"), value: "0" },
            { text: localizeString("By Week"), value: "1" },
            { text: localizeString("By Month"), value: "2" }
        ],
        selectedIndex: ko.observable(-1)
    };

    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        };
        AdvantageMobile_UI.db.get('GetHoursThisWeek', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode() //AdvantageMobile_UI.CurrentUser.EmployeeCode(),
        }).done(function (data) {
            viewModel.totalHoursThisWeek(data);
            //alert("viewShown: " + viewModel.totalHoursThisWeek());
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        viewTab.selectedIndex(-1);
        addFromMyTab.selectedIndex(-1);
    };
    function viewDateChanged() {
        //alert(this.viewDateValue());
        //alert(this.viewTab.selectedIndex());
        //alert(this.selectedViewTabValue());
        //AdvantageMobile_UI.app.navigate({
        //    view: "time_list",
        //    settings: { source: 0, date: this.viewDateValue(), viewBy: this.selectedViewTabValue() }
        //});
    }
    function viewShowing() {

    };
    var viewModel = {
        //  Put the binding properties here
        totalHoursThisWeek: totalHoursThisWeek,
        viewDateValue: viewDateValue,
        viewDateChanged: viewDateChanged,
        addButton: addButton,
        addFromMyTab: addFromMyTab,
        viewTab: viewTab,
        viewShown: viewShown,
        viewShowing: viewShowing,
        dateBox: dateBox,
        totalHoursGuage: totalHoursGuage,
        selectedViewTabValue: selectedViewTabValue,
        guageClick: guageClick,
    };
    
    return viewModel;

};