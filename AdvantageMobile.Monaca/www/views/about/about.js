AdvantageMobile_UI.about = function (params, viewInfo) {

    var currentPlatform = ko.observable("");

    function viewShowing(e) {

    };
    function viewShown(e) {
        currentPlatform(DevExpress.devices.current().platform);
    };

    var viewModel = {
        viewShowing: viewShowing,
        viewShown: viewShown,
        currentPlatform: currentPlatform,
    };

    return viewModel;
};