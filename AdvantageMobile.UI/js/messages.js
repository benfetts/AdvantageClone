window.AdvantageMobile_UI.Messages = window.AdvantageMobile_UI.Messages || {};
(function() {

    var Messages = {};
    var toastTime = 3000; //milliseconds

    Messages.alert = function (message) {
        DevExpress.ui.dialog.alert(message);
    };
    Messages.toast = function (message) {
        DevExpress.ui.notify(message, 'info', toastTime);
    };
    Messages.toastWarning = function (message) {
        if (message == null || message == '') {
            message = "Warning"
        };
        DevExpress.ui.notify(message, 'warning', toastTime);
    };
    Messages.toastFail = function (message) {
        if (message == null || message == '') {
            message = "Fail"
        };
        DevExpress.ui.notify(message, 'error', toastTime);
    };
    Messages.toastError = function (message) {
        if (message == null || message == '') {
            message = "Error"
        };
        DevExpress.ui.notify(message, 'error', toastTime);
    };
    Messages.toastSuccess = function (message) {
        if (message == null || message == '') {
            message = "Success"
        };
        DevExpress.ui.notify(message, 'success', toastTime);
    };
    Messages.notImplemented = function () {
        this.toastWarning("Not implemented");
    };

    $.extend(AdvantageMobile_UI.Messages, Messages);

})();