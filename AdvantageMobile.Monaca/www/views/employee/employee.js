AdvantageMobile_UI.employee = function (params, viewInfo) {
    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        };
    };
    function viewShowing() {

    };
    var expensesButton = {
        text: "Expenses",
        onClick: function (e) {
            var buttonSettings;
            buttonSettings = { source: 1 };
            AdvantageMobile_UI.app.navigate({
                view: "expenses_summary",
                settings: buttonSettings
            });
        }
    }
    var timeButton = {
        text: "Time",
        onClick: function (e) {
            var buttonSettings;
            buttonSettings = { source: 0 };
            AdvantageMobile_UI.app.navigate({
                view: "time_main",
                settings: buttonSettings
            });
        }
    }
   var viewModel = {
        viewShowing: viewShowing,
        viewShown: viewShown,
       navbar: {
            visible: false,
            onItemClick: function (e) {
                AdvantageMobile_UI.app.navigate({
                    view: e.itemData.view,
                    id: 0
                });
            },
            //selectedIndex: 1,
            items: [
                { text: localizeString("Expenses"), icon: "", value: "expenses", view: "expenses_summary" },
                { text: localizeString("Time"), icon: "", value: "timesheet", view: "time_main" },
            ]
       },
       expensesButton: expensesButton,
       timeButton: timeButton,
    };

    return viewModel;

};