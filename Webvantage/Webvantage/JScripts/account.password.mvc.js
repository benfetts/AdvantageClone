//
var key2 = null;
var o;
var n;
var c;
var capsNotificationVisible = false;
var currCapsNotificationVisible = false;
var staticNotification = $("#staticNotification").kendoNotification({
    appendTo: "#messages-containers",
    autoHideAfter: 0,
    hideOnClick: false
}).data("kendoNotification");
/*  The Notification provides the 
 *  "info", "success", "warning", and "error" 
 *  built-in notification types.  */
function showMessage(m, t) {
    if (!t) {
        t = "error";
    }
    if (m && m != "") {
        if (staticNotification) {
            staticNotification.show(m, t);
        } else {
            console.log("No staticNotification");
        }
    }
}
function hideMessage() {
    window.setTimeout(function () {
        if (staticNotification) {
            staticNotification.hide();
        } else {
            console.log("No staticNotification");
        }
    }, 500);
}
function showPasswordsContainer() {
    hideMessage();
    $("#passwordsContainer").show();
    $("#validationContainer").hide();
}
function hidePasswordsContainer() {
    $("#passwordsContainer").hide();
    $("#validationContainer").show();
}
function showValidationContainer() {
    hideMessage();
    $("#validationContainer").show();
    $("#passwordsContainer").hide();
}
function hideValidationContainer() {
    $("#validationContainer").hide();
    $("#passwordsContainer").show();
}
function sendSecurityKeyButtonChange() {
    //disabled-button 
    if ($("#emailKeyTextbox").val().length === 5) {
        $("#validateSecurityKeyButton").attr("disabled", false);
        $("#validateSecurityKeyButton").removeClass("disabled-button");
        $("#validateSecurityKeyButton").prop("title", "Click to validate!");
    } else {
        $("#validateSecurityKeyButton").attr("disabled", true);
        $("#validateSecurityKeyButton").addClass("disabled-button");
        $("#validateSecurityKeyButton").prop("title", (5 - $("#emailKeyTextbox").val().length) + " more characters until you can validate!");
    }
}
function validateSecurityKey() {
    //hideMessage();
    if ($("#emailKeyTextbox").val().length === 5) {
        var keyVal = "";
        var now = new Date();
        var x = now.getMilliseconds() * now.getMilliseconds() - now.getMilliseconds();
        keyVal = $("#emailKeyTextbox").val();
        keyVal = x + "||" + keyVal + "||" + now.getMilliseconds();
        keyVal = btoa(keyVal);
        var data = {
            k: keyVal,
            v: gqsv("dl")
        };
        $("#validateSecurityKeyButtonContainer").hide();
        $("#buttonValidateProgressContainer").show();
        $.post({
            url: window.appBase + "Account/Password/vk",
            dataType: "json",
            data: data
        }).always(function (response) {
            $("#validateSecurityKeyButtonContainer").show();
            $("#buttonValidateProgressContainer").hide();
            if (response) {
                if (response.Success == true) {
                    key2 = response.Data.k;
                    if (key2 && key2 != "") {
                        showPasswordsContainer();
                    }
                } else {
                    key2 = null;
                    hidePasswordsContainer();
                    if (response.Data.e && response.Data.e != "") {
                        showMessage(response.Data.e);
                    }
                }
            }
        });
    }
}
function gqsv(key) {
    //hideMessage();
    return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}
function snp() {
    window.setTimeout(function () {
        _snp();
    }, 500);
}
function _snp() {
    if (key2 && key2 != "") {
        n = $("#newPasswordTextbox").val();
        c = $("#compareNewPasswordTextbox").val();
        if (!n || n.trim() == "") {
            showMessage("Please enter new password.");
            return false;
        } else {
            if (!c || c.trim() == "") {
                showMessage("Please retype your password.");
            } else {
                if (n !== c) {
                    showMessage("Passwords do not match.");
                    return false;
                } else {
                    $("#buttonsContainer").hide();
                    $("#buttonProgressContainer").show();
                    var data = {
                        w: n,
                        k: key2,
                        x: gqsv("dl")
                    };
                    $.post({
                        url: window.appBase + "Account/Password/cp",
                        dataType: "json",
                        data: data
                    }).always(function (response) {
                        if (response) {
                            if (response.Success == true) {
                                key2 = response.Data.k;
                                if (key2 && key2 != "") {
                                    //showPasswordsContainer();
                                    if (response.Data.url != "") {
                                        hideMessage();
                                        //showMessage("Your password is set!", "success");
                                        $("#validationContainer").hide();
                                        $("#passwordsContainer").hide();
                                        $("#successContainer").show();
                                        $("#signInLink").click(function () {
                                            window.location.href = response.Data.url;
                                        });
                                        //window.setTimeout(function () {
                                        //    window.location.href = response.Data.url;
                                        //}, 2500);
                                    }
                                }
                            } else {
                                if (response.Data.msgs) {
                                    var messages = response.Data.msgs;
                                    for (var i = 0; i < messages.length; i++) {
                                        showMessage(messages[i]);
                                    }
                                }
                                $("#buttonsContainer").show();
                                $("#buttonProgressContainer").hide();
                            }
                        }
                    });
                }
            }
        }
    } else {
        showMessage("Server key does not match.  Your request may be expired.");
    }
}
function togglePwd() {
    if ($("#newPasswordTextbox").attr("type") === "password") {
        $("#newPasswordTextbox").attr("type", "text");
        $("#compareNewPasswordTextbox").attr("type", "text");
    } else {
        $("#newPasswordTextbox").attr("type", "password");
        $("#compareNewPasswordTextbox").attr("type", "password");
    }
}
function capLock(e) {
    var capsLockChanged = false;
    var kc = e.keyCode ? e.keyCode : e.which;
    var sk = e.shiftKey ? e.shiftKey : kc === 16;
    var isCapLock = ((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk) ? true : false;
    if (isCapLock == true) {
        $("#capsLockWarning").show();
    } else {
        $("#capsLockWarning").hide();
    }
}
function cx() {
    var data = {
        x: gqsv("dl")
    };
    $.post({
        url: window.appBase + "Account/Password/cx",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            if (response.Success == true) {
                window.location.href = response.Data.url;
            } else {

            }
        }
    });
}
