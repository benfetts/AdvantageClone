AdvantageMobile_UI.desktop = function (params, viewInfo) {

    var boolShowAlertsOverlay = false;
    
    var desktopNavBar = {
        visible: false,
        onItemClick: function (e) {
            //alert(e.itemData.value);
            var buttonSettings;

            switch (e.itemData.value) {
                case "alerts":
                    buttonSettings = { source: 1 };
                    break;
                case "assignments":
                    buttonSettings = { source: 0 };
                    break;
                case "schedule":
                    buttonSettings = { source: 0 };
                    break;
            }
            AdvantageMobile_UI.app.navigate({
                view: e.itemData.view,
                settings: buttonSettings
            });


        },
        items: [
            { text: localizeString("Alerts"), icon: "", value: "alerts", view: "alert_list" },
            { text: localizeString("Assignments"), icon: "", value: "assignments", view: "alert_list" },
            { text: localizeString("Schedule"), icon: "", value: "schedule", view: "schedule_list" }
        ]

    }

    var alertsButton = {
        text: "Alerts",
        onClick: function (e) {
            var buttonSettings;
            buttonSettings = { source: 1 };
            AdvantageMobile_UI.app.navigate({
                view: "alert_list",
                settings: buttonSettings
            });
        }
    }
    var assignmentsButton = {
        text: "Assignments",
        onClick: function (e) {
            var buttonSettings;
            buttonSettings = { source: 0 };
            AdvantageMobile_UI.app.navigate({
                view: "alert_list",
                settings: buttonSettings
            });
        }
    }

    var scheduleButton = {
        text: "Schedule",
        onClick: function(e) {
            var buttonSettings;
            buttonSettings = { source: 0 };
            AdvantageMobile_UI.app.navigate({
                view: "schedule_list",
                settings: buttonSettings
            });
        }
    }
    function showAlertsOverlay() {
        //alert("hello");
        boolShowAlertsOverlay = !boolShowAlertsOverlay;
        //alert(boolShowAlertsOverlay);
    };
    function viewShowing(e) {

    };
    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        };
    };
    var viewModel = {
        //  Put the binding properties here
        viewShowing: viewShowing, viewShown: viewShown,
        boolShowAlertsOverlay: boolShowAlertsOverlay,
        showAlertsOverlay: showAlertsOverlay,
        desktopNavBar: desktopNavBar,
        alertsButton: alertsButton,
        assignmentsButton: assignmentsButton,
        scheduleButton: scheduleButton,
    };

    return viewModel;

};

//$(function () {
//    var showHelloWorld = function () {
//        DevExpress.ui.dialog.alert("Hello world!");
//    };
//    ko.applyBindings();
//});