//
function lockAllClick(e) {
    showKendoConfirm("Are you sure you want to lock <strong>ALL</strong> users?")
        .done(function () {
            la(e);
        })
        .fail(function () {
            // Cancel clicked
        });
}
function unLockAllClick(e) {
    showKendoConfirm("Are you sure you want to unlock <strong>ALL</strong> users?")
        .done(function () {
            ua(e);
        })
        .fail(function () {
            // Cancel clicked
        });
}
function clearAllClick(e) {
    showKendoConfirm("Are you sure you want to clear passwords for <strong>ALL</strong> users?")
        .done(function () {
            ca(e);
        })
        .fail(function () {
            // Cancel clicked
        });
}
function saveClick(e) {
    s(e);
}
function clearClick(e) {
    c(e);
}
function lockClick(e) {
    l(e);
}
function unLockClick(e) {
    u(e)
}
function s(e) {
    var id = e.getAttribute("data-bind") * 1;
    if (id && isNaN(id) === false) {
        id = id * 1;
        //msg(id, "");
        var tb1 = $("#txtPwd_" + id);
        var tb2 = $("#txtPwd2_" + id);
        var valid = true;
        if (tb1 && tb2) {
            var val1 = tb1.val().trim();
            var val2 = tb2.val().trim();
            if (!val1 || val1 == "") {
                //msg(id, "New Password is blank!");
                notif("New Password is blank!", "error");
                $(tb1).focus();
                valid = false;
            }
            if (valid == true && (!val2 || val2 == "")) {
                //msg(id, "Confirm Password is blank!");
                notif("Confirm Password is blank!", "error");
                $(tb2).focus();
                valid = false;
            }
            if (valid == true && val1 != val2) {
                //msg(id, "Passwords do not match!");
                notif("Passwords do not match!", "error");
                $(tb1).focus();
                valid = false;
            }
            if (valid == true) {
                var data = {
                    u: id,
                    p: val1,
                    x: gup("x")
                };
                $.post({
                    url: window.appBase + "Account/GM/cp",
                    dataType: "json",
                    data: data
                }).always(function (response) {
                    if (response) {
                        if (response.Success == true) {
                            //msg(id, "Saved!");
                            notif("Saved!", "success");
                        } else {
                            if (response.Data.msgs) {
                                var messages = response.Data.msgs;
                                var messageShown = false;
                                var noChange = false;
                                for (var i = 0; i < messages.length; i++) {
                                    //msg(id, messages[i]);
                                    if (messages[i].indexOf("did not change") > -1) {
                                        notif(messages[i], "warning");
                                        messageShown = true;
                                        noChange = true;
                                    } else {
                                        notif(messages[i], "error");
                                        messageShown = true;
                                    }
                                    if (messageShown == true) {
                                        if (noChange == true) {
                                            $(tb1).focus();
                                        } else {
                                            $(tb2).focus();
                                        }                                        
                                    }
                                }
                            }
                        }
                    }
                });

            }
        }
    }
}
function c(e) {
    var id = e.getAttribute("data-bind") * 1;
    if (id && isNaN(id) === false) {
        id = id * 1;
        //msg(id, "");
        var tb1 = $("#txtPwd_" + id);
        var tb2 = $("#txtPwd2_" + id);
        var data = {
            u: id,
            x: gup("x")
        };
        $.post({
            url: window.appBase + "Account/GM/clr",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                if (response.Success == true) {
                    //msg(id, "Cleared!");
                    notif("Cleared!", "success");
                    tb1.val(null);
                    tb2.val(null);
                } else {
                    if (response.Data.msgs) {
                        var messages = response.Data.msgs;
                        for (var i = 0; i < messages.length; i++) {
                            //msg(id, messages[i]);
                            notif(messages[i], "error");
                        }
                    }
                }
            }
        });
    }
}
function l(e) {
    var id = e.getAttribute("data-bind") * 1;
    if (id && isNaN(id) === false) {
        id = id * 1;
        var data = {
            u: id,
            x: gup("x")
        };
        $.post({
            url: window.appBase + "Account/GM/lk",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                if (response.Success == true) {
                    showLockIcon(id);
                    notif("Locked!", "error");
                } else {
                    if (response.Data.msgs) {
                        var messages = response.Data.msgs;
                        for (var i = 0; i < messages.length; i++) {
                            notif(messages[i], "error");
                        }
                    }
                }
            }
        });
    }
}
function u(e) {
    var id = e.getAttribute("data-bind") * 1;
    if (id && isNaN(id) === false) {
        console.log("unlock!", id);
        id = id * 1;
        var data = {
            u: id,
            x: gup("x")
        };
        console.log(data)
        $.post({
            url: window.appBase + "Account/GM/ulk",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                if (response.Success == true) {
                    showUnlockIcon(id);
                    notif("Unlocked!", "success");
                } else {
                    if (response.Data.msgs) {
                        var messages = response.Data.msgs;
                        for (var i = 0; i < messages.length; i++) {
                            notif(messages[i], "error");
                        }
                    }
                }
            }
        });
    }
}
function la(e) {
    var data = {
        x: gup("x")
    };
    $.post({
        url: window.appBase + "Account/GM/lka",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            if (response.Success == true) {
                reloadAll();
            } else {
                if (response.Data.msgs) {
                    var messages = response.Data.msgs;
                    for (var i = 0; i < messages.length; i++) {
                        notif(messages[i], "error");
                    }
                }
            }
        }
    });
}
function ua(e) {
    var data = {
        x: gup("x")
    };
    $.post({
        url: window.appBase + "Account/GM/ulka",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            if (response.Success == true) {
                reloadAll();
            } else {
                if (response.Data.msgs) {
                    var messages = response.Data.msgs;
                    for (var i = 0; i < messages.length; i++) {
                        notif(messages[i], "error");
                    }
                }
            }
        }
    });
}
function ca(e) {
    var data = {
        x: gup("x")
    };
    $.post({
        url: window.appBase + "Account/GM/clra",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            if (response.Success == true) {
                reloadAll();
            } else {
                if (response.Data.msgs) {
                    var messages = response.Data.msgs;
                    for (var i = 0; i < messages.length; i++) {
                        notif(messages[i], "error");
                    }
                }
            }
        }
    });
}
function showLockIcon(id) {
    $("#lockListItem_" + id).hide();
    $("#unLockListItem_" + id).show();
}
function showUnlockIcon(id) {
    $("#lockListItem_" + id).show();
    $("#unLockListItem_" + id).hide();
}
function newUserCancelClick() {
    if (parent) {
        parent.closeAdminWindow();
    }
}
function newUserSaveClick() {
    //console.log("newUserSaveClick");
    try {
        var u = "";
        var up = "";
        var dc = "";
        var dd = "";
        var ec = "";
        var ef = "";
        var em = "";
        var el = "";
        u = $("#userCodeTextbox").val();
        if (hasDepts && hasDepts == true) {
            dc = $("#Departments")[0].value;
        } else {
            dc = $("#departmentCodeTextbox").val();
            dd = $("#departmentDescriptionTextbox").val();
        }
        if (hasEmps && hasEmps == true) {
            ec = $("#Employees")[0].value;
        } else {
            ec = $("#employeeCodeTextbox").val();
            ef = $("#employeeFirstNameTextbox").val();
            em = $("#employeeMiddleInitialTextbox").val();
            el = $("#employeeLastNameTextbox").val();
        }   
        var data = {
            u: u,
            up: up,
            dc: dc,
            dd: dd,
            ec: ec,
            ef: ef,
            em: em,
            el: el,
            x: gup("x")
        };
        $.post({
            url: window.appBase + "Account/GM/nu",
            dataType: "json",
            data: data
        }).always(function (result) {
            try {
                if (result) {
                    if (result.Success && result.Success === true) {
                        if (parent) {
                            parent.refreshAdminWindow();
                        }
                    } else {
                    }
                    if (result.Message && result.Message !== "") {
                        showKendoAlert(result.Message);
                    }
                    if (response.Data.msgs) {
                        var messages = response.Data.msgs;
                        if (messages.length > 0) {
                            var messageString = "";
                            for (var i = 0; i < messages.length; i++) {
                                //msg(id, messages[i]);
                                messageString += messages[i] + "<br/>"
                            }
                            showKendoAlert(messageString);
                        }
                    }
                }
            } catch (e) {
                //
            }
        });

    } catch (e) {
        console.log("save error");
    }
}
function reloadAll() {
    window.location = window.location;
}
function msg(id, e) {
    if (id && isNaN(id) === false) {
        if ($("#msg_" + id)) {
            $("#msg_" + id).html(e);
        }
    }
}
function notif(text, type) {
    if (text && text != "") {
        /*
         * error
         * info
         * success
         * warning
         */
        if (!type || type == "") {
            type = "info";
        }
        //var popupNotification = $("#popupNotification").kendoNotification().data("kendoNotification");
        //if (popupNotification) {
        //    popupNotification.show(text, type);
        //}
        $("#popupNotification").kendoNotification({
            position: {
                top: 30
            },
            stacking: "default"
        });
        $("#popupNotification").getKendoNotification().show(text, type);
    }
}
