//
function enableDarkMode() {
    window.setTimeout(function () {
        _enableDarkMode();
    }, 250);
}
function _enableDarkMode() {
    DarkReader.setFetchMethod(window.fetch);
    DarkReader.enable({
        brightness: 100,
        contrast: 90,
        sepia: 10
    });
}
function disableDarkMode() {

}
function isButtonDisabled(id) {
    var isDisabled = false;
    var btn = $("#" + id);
    if (btn) {
        isDisabled = $(btn).is(":disabled");
    }
    return isDisabled;
}
function enableButton(id) {
    window.setTimeout(function () {
        var btn = $("#" + id);
        if (btn) {
            $(btn).removeClass("k-state-disabled");
            $(btn).prop("disabled", false);
        }
    }, 10);
}
function disableButton(id) {
    window.setTimeout(function () {
        var btn = $("#" + id);
        if (btn) {
            $(btn).addClass("k-state-disabled");
            $(btn).prop("disabled", true);
        }
    }, 10);
}
