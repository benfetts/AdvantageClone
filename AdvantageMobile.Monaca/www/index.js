window.AdvantageMobile_UI = window.AdvantageMobile_UI || {};

var defaultView = "home";
//defaultView = "time_main";
//defaultView = "TestView";
//defaultView = "expense_main";
//defaultView = "rich_editor";
//defaultView = "upload_file";

var staticCulture = "default";
//staticCulture = "fr";
//staticCulture = "de";

var debug = false;
//debug = true;
var timeOutInSeconds = 60 * 120;
var idleSeconds = 0;

function onDeviceReady() {
    navigator["splashscreen"].hide();
    document.addEventListener("backbutton", onBackButton, false);
    window.requestFileSystem(LocalFileSystem.PERSISTENT, 0, gotFS, fail);
    AdvantageMobile_UI.pictureSource = navigator.camera.PictureSourceType;
    AdvantageMobile_UI.destinationType = navigator.camera.DestinationType;
}
function incrementTimer() {
    if (timeOutInSeconds > 0) {
        idleSeconds = idleSeconds + 1;
        if (idleSeconds == timeOutInSeconds) {
           // console.log("timed out");
            idleSeconds = 0;
        }
    }
}
function resetTimer() {
    idleSeconds = 0;
}
function signIn() {
    if (AdvantageMobile_UI.CurrentUser != undefined) {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get("SignIn")
            .done(function (data) {
                d.resolve(data);
                idleSeconds = 0;
                if (data != undefined) {
                    var i = 0;
                    i = data;
                    AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID(i);
                    AdvantageMobile_UI.CurrentUser.saveLocal();
                }
            }).fail(function (data) {
                handleDataServiceError(data);
                return 0;
            });
        return d.promise();
    }
}
function signOut() {
    if (AdvantageMobile_UI.CurrentUser != undefined && AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID() > 0) {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get("SignOut")
            .done(function (data) {
                d.resolve(data);
                if (data != undefined) {
                    var i = 0;
                    i = data;
                    AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID(i);
                    AdvantageMobile_UI.CurrentUser.saveLocal();
                };
                idleSeconds = 0;
                goToSignIn();
            }).fail(function (data) {
                handleDataServiceError(data);
            });
        return d.promise();
    }
}
function goToSignIn() {
    AdvantageMobile_UI.app.navigate("sign_in");
}
function isValidDatabase() {
    var isValid = false;
    var d = new $.Deferred();
    AdvantageMobile_UI.db.get("IsValidDatabase")
        .done(function (data) {
            d.resolve(data);
            if (data != undefined) {
                isValid = data;
            }
        }).fail(function (data) {
            handleDataServiceError(data);
        });
    return isValid;
    //return d.promise();
}
function enableDarkMode() {
    DarkReader.setFetchMethod(window.fetch);
    DarkReader.enable({
        brightness: 100,
        contrast: 90,
        sepia: 10
    });
}
function disableDarkMode() {

}
AdvantageMobile_UI.pictureSource;   // picture source
AdvantageMobile_UI.destinationType; // sets the format of returned value 

document.addEventListener("deviceready", onDeviceReady, false);
document.addEventListener("click", resetTimer, false);
document.addEventListener("touchstart", resetTimer, false);

$(function () {
    "use strict";

    AdvantageMobile_UI.tabCss = ko.observable("");
    AdvantageMobile_UI.whiteDateBoxCss = ko.observable("white-datebox");

    function showMenu(e) {
        AdvantageMobile_UI.app.viewShown.remove(showMenu);

        if (e.viewInfo.viewName !== "Home")
            return;

        setTimeout(function () {
            $(".nav-button").trigger("dxclick");
        }, 1000);
    }
    $(document).on("ajaxSend", function (e, xhr, settings) {   //   timeout for DB
        settings.timeout = 2 * 60 * 1000; // 2 minutes
    });

    function onBackButton() {
        if (AdvantageMobile_UI.app.canBack()) {
            AdvantageMobile_UI.app.back();
        } else {
            // Exit app when can no longer go back
            var r = confirm("Exit?");
            if (r == true) {
                switch (DevExpress.devices.current().platform) {
                    case "tizen":
                        tizen.application.getCurrentApplication().exit();
                        break;
                    case "android":
                        navigator.app.exitApp();
                        break;
                    case "win8":
                        window.external.Notify("DevExpress.ExitApp");
                        break;
                }
            }
        }
    }

    function gotFS(fileSystem) {
        app.fileSystem = fileSystem;
    }
    function fail(evt) {
        console.log(evt.error.code);
    }
    // Instantiate current mobile user when app starts:
    AdvantageMobile_UI.CurrentUser = new AdvantageMobile_UI.MobileUserViewModel();
    var cachedUserDataString = AdvantageMobile_UI.CurrentUser.getLocal();

    if (!cachedUserDataString || cachedUserDataString == null) {
        defaultView = "sign_in";
    } else {
        var cachedUserData = JSON.parse(cachedUserDataString);
        AdvantageMobile_UI.CurrentUser = new AdvantageMobile_UI.MobileUserViewModel(cachedUserData);
        if (AdvantageMobile_UI.CurrentUser.ServicesURL() && AdvantageMobile_UI.CurrentUser.ServicesURL() != null) {
            AdvantageMobile_UI.config.endpoints.db.local = AdvantageMobile_UI.CurrentUser.ServicesURL();
            AdvantageMobile_UI.config.endpoints.db.production = AdvantageMobile_UI.CurrentUser.ServicesURL();
            AdvantageMobile_UI.CurrentUser.validateFromServer();
        } else {
            defaultView = "sign_in";
        }
        if (AdvantageMobile_UI.CurrentUser.UserCode() == null || AdvantageMobile_UI.CurrentUser.UserCode() == '') {
            defaultView = "sign_in";
        }
        if (AdvantageMobile_UI.CurrentUser.Token() == null || AdvantageMobile_UI.CurrentUser.Token() == '') {
            defaultView = "sign_in";
        }
        if (AdvantageMobile_UI.CurrentUser.EmployeeCode() == null || AdvantageMobile_UI.CurrentUser.EmployeeCode() == '') {
            defaultView = "sign_in";
        }
        if (!AdvantageMobile_UI.CurrentUser.RememberPassword() || AdvantageMobile_UI.CurrentUser.RememberPassword() == false) {
            defaultView = "sign_in";
        }
        if (AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID() == null || AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID() == 0) {
            defaultView = "sign_in";
        }
        if (!AdvantageMobile_UI.CurrentUser.IsValidDatabase() || AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            defaultView = "sign_in";
        }
    }
    //alert(AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID());
    if (defaultView != "sign_in") {
        //license:
        signIn();
    }
    //// Uncomment the line below to force platform regardless of device
    //DevExpress.devices.current({ platform: "generic" });
    //DevExpress.devices.current({ platform: "tizen" });

    //  Don't allow platform switching by user; must depend on device!
    if (debug == true) {
        if (AdvantageMobile_UI.CurrentUser.Platform() != undefined && AdvantageMobile_UI.CurrentUser.Platform() != null) {
            DevExpress.devices.current({ platform: AdvantageMobile_UI.CurrentUser.Platform() });
        }
    };

    //DevExpress.ui.themes.current("generic.light");
    //DevExpress.ui.themes.current("ios7.default");
    DevExpress.ui.themes.current("android5.light");

    //  Set theme for data visualization controls
    DevExpress.viz.core.currentTheme("ios", "light");

    try {
        if (AdvantageMobile_UI.CurrentUser.LanguageCode() != undefined && AdvantageMobile_UI.CurrentUser.LanguageCode() != null) {
                staticCulture = AdvantageMobile_UI.CurrentUser.LanguageCode();
        }
    }
    catch (e) {
        staticCulture = "default";
    }

    //staticCulture = "de";
    //alert(staticCulture);
    ////Globalize.culture(staticCulture);

    ////var dictionary = Globalize.cultures[staticCulture].messages;

    //////  Switch Layouts depending on device (not yet implemented)
    //////  http://js.devexpress.com/Documentation/Tutorial/SPA_Framework/Use_Split_Layout_For_Tablets?version=14_1
    ////var layoutSet = [
    ////    { platform: "ios", tablet: true, controller: new DevExpress.framework.html.IOSSplitLayoutController() },
    ////    { platform: "android", tablet: true, controller: new DevExpress.framework.html.AndroidSplitLayoutController() },
    ////    { platform: "android", phone: true, root: false, controller: new DevExpress.framework.html.SimpleLayoutController() },
    ////    { win8: false, phone: true, controller: new DevExpress.framework.html.NavBarController() },
    ////    { win8: true, phone: true, root: true, controller: new DevExpress.framework.html.PivotLayoutController() },
    ////    { win8: true, phone: true, root: false, controller: new DevExpress.framework.html.SimpleLayoutController() }
    ////];

    var appConfig = {

        namespace: AdvantageMobile_UI,
        viewPortNode: document.getElementById("viewPort"),
        commandMapping: AdvantageMobile_UI.config.commandMapping,
        layoutSet: DevExpress.framework.html.layoutSets[AdvantageMobile_UI.config.layoutSet],
        //navigationType: "slideout",
        navigation: [
                      //{
                      //    "title": "Test",
                      //    "onExecute": "#TestView",
                      //    "icon": "preferences"
                      //},
                      {
                          "title": "Home",
                "onExecute": "#home"
                //,
                //          "icon": "icon_home"
                      },
                      //{
                      //    "title": "Schedule",
                      //    "onExecute": "#schedule_list",
                      //    "icon": "icon_desktop"
                      //},
                      {
                          "title": "Desktop",
                          "onExecute": "#desktop"
                          //,
                          //"icon": "icon_desktop"
                      },
                      {
                          "title": "Employee",
                          "onExecute": "#employee"
                          //,
                          //"icon": "icon_user"
                      },
                      {
                          "title": "Project Management",
                          "onExecute": "#project_management"
                          //,
                          //"icon": "icon_chart_area"
                      },
                      //{
                      //    "title": "Media",
                      //    "onExecute": "#media",
                      //    "icon": "icon_tv"
                      //},
                      {
                          "title": "About",
                          "onExecute": "#about"
                          //,
                          //"icon": "icon_information"
                      },
                      {
                          "title": "Sign In",
                          "onExecute": "#sign_in"
                          //,
                          //"icon": "icon_key2"
                      }
        ]

    };

    $.each(appConfig.navigation, function () {
        ////if (this.title.indexOf("@") === 0)
        ////    this.title = dictionary[this.title.substring(1)];
    });


    AdvantageMobile_UI.app = new DevExpress.framework.html.HtmlApplication(appConfig);
    AdvantageMobile_UI.app.router.register(":view/:settings", { view: defaultView, settings: undefined });
    AdvantageMobile_UI.app.on("resolveLayoutController", function (args) {
        var viewName = args.viewInfo.viewName;
       // alert(viewName);
        if (viewName === "expenses_summary") {
            args.layoutController = AdvantageMobile_UI.app.emptyController
        }
    });
    AdvantageMobile_UI.app.navigate();

    //alert("index.js")

});