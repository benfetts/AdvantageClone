AdvantageMobile_UI.sign_in = function (params, viewInfo) {

    var savedURL = '';
    var serviceFilename = "DataService.svc";
    var isWindowsAuth = false;
    var boolWindowsAuthentication = ko.observable(false);
    var domainNameVisible = ko.observable(false);
    var networkUserIdVisible = ko.observable(false);
    var networkPasswordVisible = ko.observable(false);
    var strDomainName = ko.observable();
    var strNetworkUserId = ko.observable();
    var strNetworkPassword = ko.observable();
    var serverFieldVisible = true;
    var serverFieldCSS = ko.observable("");
    var signOutIsSignIn = false;

    var urlValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter URL') //"URL is required"
        }]
    };
    //var serverValidator = {
    //    validationRules: [{
    //        type: 'required',
    //        message: localizeString('Please EnterServerName') //"Server is required"
    //    }],
    //    enabled: false
    //};
    var databaseValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Database Name') //"Database is required"
        }]
    };
    var userIdValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter UserID') //"User ID is required"
        }]
    };
    var passwordValidator = {
        validationRules: [{
            type: 'required',
            message: localizeString('Please Enter Password') //"Password is required"
        }]
    };
    var clearSavedSettingsButton = {
        text: localizeString("Clear Saved Settings"),
        onClick: function (e) {
            var result = DevExpress.ui.dialog.confirm("Are you sure?", localizeString("Clear Saved Settings"));
            result.done(function (dialogResult) {
                if (dialogResult == true) {
                    signOut();
                    AdvantageMobile_UI.CurrentUser = new AdvantageMobile_UI.MobileUserViewModel();
                    AdvantageMobile_UI.CurrentUser.saveLocal();
                    load();
                }
            });
        }
    };
    var signOutButton = {
        text: ko.observable(localizeString("Sign Out")),
        onClick: function (e) {
            if (signOutIsSignIn == false) {
                signOut();
                signOutIsSignIn = true;
                signOutButton.text(localizeString("Sign In"));
            } else {
                handleSave();
            }
        }
    };

    function windowsAuthValueChanged() {
        setAuth();
    }
    function setAuth() {
        viewModel.domainNameVisible(viewModel.boolWindowsAuthentication());
        //viewModel.networkUserIdVisible(!viewModel.boolWindowsAuthentication());
        //viewModel.networkPasswordVisible(!viewModel.boolWindowsAuthentication());
        viewModel.networkUserIdVisible(false);
        viewModel.networkPasswordVisible(false);
    }

    function viewShowing(e) {

    }
    function viewShown(e) {
        load();
    }
    function load() {
        //  Load data from local storage
        //  CurrentUser was instantiated on index.js
        if (AdvantageMobile_UI.CurrentUser.ServicesURL() != undefined) {
            viewModel.strURL(AdvantageMobile_UI.CurrentUser.ServicesURL());
            savedURL = AdvantageMobile_UI.CurrentUser.ServicesURL();
        } else {
            viewModel.strURL(undefined);
        }
        if (AdvantageMobile_UI.CurrentUser.DatabaseName() != undefined) {
            viewModel.strDatabase(AdvantageMobile_UI.CurrentUser.DatabaseName());
        } else {
            viewModel.strDatabase(undefined);
        }
        if (AdvantageMobile_UI.CurrentUser.ServerName() != undefined) {
            viewModel.strServer(AdvantageMobile_UI.CurrentUser.ServerName());
        } else {
            viewModel.strServer(undefined);
        }
        if (AdvantageMobile_UI.CurrentUser.RememberUserName() == true) {
            viewModel.strUserCode(AdvantageMobile_UI.CurrentUser.UserCode());
        } else {
            viewModel.strUserCode(undefined);
        }
        if (AdvantageMobile_UI.CurrentUser.UpperCaseDatabase() == true) {
            viewModel.strDatabase(viewModel.strDatabase().toUpperCase());
        }
        if (AdvantageMobile_UI.CurrentUser.UpperCaseUser() == true) {
            viewModel.strUserCode(viewModel.strUserCode().toUpperCase())
        }

        if (AdvantageMobile_UI.CurrentUser.RememberPassword() == true) {
            viewModel.strPassword(AdvantageMobile_UI.CurrentUser.Password());
        } else {
            viewModel.strPassword(undefined);
        }

        viewModel.boolRememberUserCode(AdvantageMobile_UI.CurrentUser.RememberUserName());
        viewModel.boolRememberPassword(AdvantageMobile_UI.CurrentUser.RememberPassword());

        if (AdvantageMobile_UI.CurrentUser.IsWindowsAuth() != undefined) {
            viewModel.boolWindowsAuthentication(AdvantageMobile_UI.CurrentUser.IsWindowsAuth())
        }
        if (AdvantageMobile_UI.CurrentUser.DomainName() != undefined) {
            viewModel.strDomainName(AdvantageMobile_UI.CurrentUser.DomainName());
        }
        if (AdvantageMobile_UI.CurrentUser.NetworkUserId() != undefined) {
            viewModel.strNetworkUserId(AdvantageMobile_UI.CurrentUser.NetworkUserId());
        }
        if (AdvantageMobile_UI.CurrentUser.NetworkPassword() != undefined) {
            viewModel.strNetworkPassword(AdvantageMobile_UI.CurrentUser.NetworkPassword());
        }
        viewModel.serverFieldCSS("");
        if (AdvantageMobile_UI.CurrentUser.ChooseServer() != undefined && AdvantageMobile_UI.CurrentUser.ChooseServer() == false) {
            viewModel.serverFieldCSS("hide");
        }
        if (AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID() > 0) {
            signOutIsSignIn = false;
            signOutButton.text(localizeString("Sign Out"));
        } else {
            signOutIsSignIn = true;
            signOutButton.text(localizeString("Sign In"));
        }
        if (AdvantageMobile_UI.CurrentUser.DatabaseName() != undefined && AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
        }

        setAuth();

        ////viewModel.strServer("TASC-SQL2012");
        ////viewModel.strDatabase("STEC66004");
        ////viewModel.strUserCode("SYSADM");
        ////viewModel.strPassword("sysadm");
        ////viewModel.boolRememberUserCode(true);
        ////viewModel.boolRememberPassword(true);

    }
    function saveFormToLocalStorage() {

        AdvantageMobile_UI.CurrentUser.ServicesURL(viewModel.strURL());
        if (AdvantageMobile_UI.CurrentUser.UpperCaseDatabase() == true) {
            viewModel.strDatabase(viewModel.strDatabase().toUpperCase());
        };
        if (AdvantageMobile_UI.CurrentUser.UpperCaseUser() == true) {
            viewModel.strUserCode(viewModel.strUserCode().toUpperCase())
        };
        AdvantageMobile_UI.CurrentUser.DatabaseName(viewModel.strDatabase());
        AdvantageMobile_UI.CurrentUser.ServerName(viewModel.strServer());
        AdvantageMobile_UI.CurrentUser.UserCode(viewModel.strUserCode());
        AdvantageMobile_UI.CurrentUser.Password(viewModel.strPassword());
        AdvantageMobile_UI.CurrentUser.RememberUserName(viewModel.boolRememberUserCode());
        AdvantageMobile_UI.CurrentUser.RememberPassword(viewModel.boolRememberPassword());
        AdvantageMobile_UI.CurrentUser.IsWindowsAuth(viewModel.boolWindowsAuthentication());
        AdvantageMobile_UI.CurrentUser.DomainName(viewModel.strDomainName());
        viewModel.strNetworkUserId(viewModel.strUserCode());
        viewModel.strNetworkPassword(viewModel.strPassword());
        AdvantageMobile_UI.CurrentUser.NetworkUserId(viewModel.strNetworkUserId());
        AdvantageMobile_UI.CurrentUser.NetworkPassword(viewModel.strNetworkPassword());

        AdvantageMobile_UI.CurrentUser.saveLocal();

    }

    function handleSave() {
        //  Validate
        if (viewModel.strURL() == undefined || viewModel.strURL() == "") {
            AdvantageMobile_UI.Messages.toastFail(localizeString('Please Enter URL'));
            return false;
        }
        if (viewModel.strDatabase() == undefined || viewModel.strDatabase() == "") {
            AdvantageMobile_UI.Messages.toastFail(localizeString('Please Enter Database Name'));
            return false;
        }
        //if (viewModel.strServer() == undefined || viewModel.strServer() == "") {
        //    AdvantageMobile_UI.Messages.toastFail(localizeString('Please EnterServerName'));
        //    return false;
        //};
        if (viewModel.strUserCode() == undefined || viewModel.strUserCode() == "") {
            AdvantageMobile_UI.Messages.toastFail(localizeString('Please Enter UserID'));
            return false;
        }
        if (viewModel.strPassword() == undefined || viewModel.strPassword() == "") {
            AdvantageMobile_UI.Messages.toastFail(localizeString('Please Enter Password'));
            return false;
        }

        var u = viewModel.strURL();
        if (u) {
            //if (u.indexOf("https") == -1) {
            //    AdvantageMobile_UI.Messages.alert(localizeString('SSL Required'));
            //    return false;
            //};
            if (u.substring(u.length - 1, u.length) != "/") {
                u = u + "/";
            }
            if (u.indexOf(".svc") == -1) {
                u = u + serviceFilename;
            }
            if (u.substring(u.length - 1, u.length) != "/") {
                u = u + "/";
            }
            viewModel.strURL(u);
        }

        var cachedUserDataString = AdvantageMobile_UI.CurrentUser.getLocal();

        if (cachedUserDataString == undefined) {

            AdvantageMobile_UI.CurrentUser = new AdvantageMobile_UI.MobileUserViewModel();
            saveFormToLocalStorage();

        };
        if (viewModel.strURL() != savedURL || AdvantageMobile_UI.CurrentUser.ServicesURL() == undefined || AdvantageMobile_UI.CurrentUser.ServicesURL() == null || AdvantageMobile_UI.CurrentUser.ServicesURL() == '') {

            AdvantageMobile_UI.config.services.db.url = viewModel.strURL();
            AdvantageMobile_UI.config.endpoints.db.local = viewModel.strURL();
            AdvantageMobile_UI.config.endpoints.db.production = viewModel.strURL();
            saveFormToLocalStorage();
            initializeApplication();

        };

        // Save regardless if good data or bad data
        saveFormToLocalStorage();

        if (viewModel.strURL() != undefined && viewModel.strDatabase() != undefined && viewModel.strUserCode() != undefined && viewModel.strPassword != undefined) {
            AdvantageMobile_UI.db.get("GetMobileUser")
                .done(function (data) {
                    if (data && data != null) {
                        AdvantageMobile_UI.CurrentUser = new AdvantageMobile_UI.MobileUserViewModel(data);
                        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
                            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
                        } else if (AdvantageMobile_UI.CurrentUser.IsValid() != null && AdvantageMobile_UI.CurrentUser.IsValid() == false) {
                            AdvantageMobile_UI.Messages.toastWarning(localizeString("Sign in failed"));
                        } else {
                            AdvantageMobile_UI.CurrentUser.ServicesURL(viewModel.strURL());
                            AdvantageMobile_UI.CurrentUser.IsValidDatabase(data.IsValidDatabase)
                            saveFormToLocalStorage();  //re-save with updated info
                            if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == true || AdvantageMobile_UI.CurrentUser.IsValidDatabase() == undefined) {
                                load();
                                signIn();
                                AdvantageMobile_UI.app.navigate({ view: "home", settings: {} }, { root: true });
                            } else {
                                AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
                            }
                        }
                    } else {
                        AdvantageMobile_UI.Messages.toastWarning(localizeString('Sign in failed'));
                    }
                })
                .fail(function (data) {
                    if (data.message.indexOf("Unspecified network error") > -1) {
                        AdvantageMobile_UI.Messages.toastWarning(localizeString('Invalid URL'));
                    } else {
                        handleDataServiceError(data);
                    }
                });
        }
    }

    var viewModel = {
        //  Put the binding properties here
        viewShowing: viewShowing,
        viewShown: viewShown,
        currentUser: ko.observable(AdvantageMobile_UI.MobileUserViewModel),
        strURL: ko.observable(""),
        strDatabase: ko.observable(""),
        strServer: ko.observable(""),
        strUserCode: ko.observable(""),
        strPassword: ko.observable(""),
        strDomainName: strDomainName,
        strNetworkUserId: strNetworkUserId,
        strNetworkPassword: strNetworkPassword,
        boolRememberUserCode: ko.observable(true),
        boolRememberPassword: ko.observable(true),
        boolWindowsAuthentication: boolWindowsAuthentication,
        handleSave: handleSave,
        domainNameVisible: domainNameVisible,
        networkUserIdVisible: networkUserIdVisible,
        networkPasswordVisible: networkPasswordVisible,
        windowsAuthValueChanged: windowsAuthValueChanged,
        urlValidator: urlValidator,
        //serverValidator: serverValidator,
        databaseValidator: databaseValidator,
        userIdValidator: userIdValidator,
        passwordValidator: passwordValidator,
        serverFieldCSS: serverFieldCSS,
        clearSavedSettingsButton: clearSavedSettingsButton,
        signOutButton: signOutButton
    };

    return viewModel;

};