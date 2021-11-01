AdvantageMobile_UI.project_management = function (params, viewInfo) {

    function viewShowing(e) {

    };
    function viewShown(e) {
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        };
    };

    var projectManagementNavBar = {
        visible: false,
        onItemClick: function (e) {
            AdvantageMobile_UI.app.navigate({
                view: e.itemData.view
            });
        },
        //items: [
        //    { text: localizeString("Campaign"), icon: "", onClick: alert },
        //    { text: localizeString("Estimate"), icon: "", onClick: alert },
        //    { text: localizeString("Job Jacket"), icon: "", onClick: alert },
        //    { text: localizeString("Schedule"), icon: "", onClick: alert }
        //]
        items: [
            { text: localizeString("Jobs"), icon: "", view: "job_list" },
            { text: localizeString("Tasks"), icon: "", view: "task_list" },
            { text: localizeString("Projects"), icon: "", view: "project_list" }
        ]

    };
    var jobsButton = {
        text: "Jobs",
        onClick: function (e) {
            var buttonSettings;
            buttonSettings = { source: 0 };
            AdvantageMobile_UI.app.navigate({
                view: "job_list",
                settings: buttonSettings
            });
        }
    }
    var tasksButton = {
        text: "Tasks",
        onClick: function (e) {
            var buttonSettings;
            buttonSettings = { source: 0 };
            AdvantageMobile_UI.app.navigate({
                view: "task_list",
                settings: buttonSettings
            });
        }
    }

    var projectsButton = {
        text: "Projects",
        onClick: function (e) {
            var buttonSettings;
            buttonSettings = { source: 0 };
            AdvantageMobile_UI.app.navigate({
                view: "project_list",
                settings: buttonSettings
            });
        }
    }

    var viewModel = {
        viewShowing: viewShowing,
        viewShown: viewShown,
        projectManagementNavBar: projectManagementNavBar,
        jobsButton: jobsButton,
        tasksButton: tasksButton,
        projectsButton: projectsButton,
    };

    return viewModel;
};