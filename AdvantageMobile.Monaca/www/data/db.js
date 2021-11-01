function initializeApplication() {

    var endpointSelector = new DevExpress.EndpointSelector(AdvantageMobile_UI.config.endpoints);
    var url = '';
    var USER_KEY = "PBTT20071002";
    //var cachedUserDataString = localStorage.getItem(USER_KEY);
    var cachedUserDataString = null;
    if (localStorage.getItem(USER_KEY) != undefined) {
        cachedUserDataString = localStorage.getItem(USER_KEY);
        cachedUserDataString = sjcl.decrypt("ParkerAndLoïeTran", cachedUserDataString);
    };
    var cachedUserData = cachedUserDataString ? JSON.parse(cachedUserDataString) : null;
    var lastMessage = "";

    if (cachedUserData == undefined || cachedUserData.ServicesURL == undefined || cachedUserData.ServicesURL == null || cachedUserData.ServicesURL == '') {
        //AdvantageMobile_UI.app.navigate({view: "sign_in"});
        goToSignIn();
    } else {
        url = cachedUserData.ServicesURL;
    };

    
    var serviceConfig = $.extend(true, {}, AdvantageMobile_UI.config.services, {
        db: {
            url: endpointSelector.urlFor("db"),
            //jsonp: true, //!window.WinJS, // enable JSONP support
            withCredentials: true,
            errorHandler: handleServiceError,
            beforeSend: handleServiceRequest
        }
    });

    serviceConfig.db.url = url;

    //alert("url from db.js " + url)

    function handleServiceError(error) {
        if (error.message != lastMessage) {
            lastMessage = error.message;
            if (error.message.indexOf("Unspecified network error") > -1) {
                goToSignIn();
            } else {
                if (error.httpStatus == 401) {
                    if (error.message == "Unauthorized") {
                        AdvantageMobile_UI.Messages.toastWarning("Sign in failed:  Please verify connection settings." );
                        lastMessage = "";
                    } else {
                        AdvantageMobile_UI.Messages.toastWarning( "Sign in failed:  " + error.message);
                    };
                    goToSignIn();
                } else {
                    if (error.message == 'Not Found') {
                        AdvantageMobile_UI.Messages.toastWarning("Invalid URL");
                        goToSignIn();
                    } else {
                        var msg = error.message + " " + (error.stacktrace || "");
                        //console.log(msg);
                        if (window.WinJS) {
                            try {
                                new Windows.UI.Popups.MessageDialog(msg).showAsync();
                            } catch (e) {
                                // Another dialog is shown
                            }
                        } else {
                            DevExpress.ui.dialog.alert(msg);
                        };
                    };
                };
            };
        };

    }
    function handleServiceRequest(xhr) {
        if (xhr.method == 'MERGE' || xhr.method == 'DELETE') {
            xhr.headers['X-HTTP-Method'] = xhr.method;
            xhr.method = 'POST';
        }
    }

    AdvantageMobile_UI.db = new DevExpress.data.ODataContext(serviceConfig.db);

    $.ajaxSetup({
        beforeSend: function (xhr) {

            var d = new Date();
            var authType = 2; // forms
            var s = "";

            xhr.setRequestHeader('Access-Control-Allow-Origin', '*');

            if (AdvantageMobile_UI.CurrentUser.IsWindowsAuth() && AdvantageMobile_UI.CurrentUser.IsWindowsAuth() == true) {
                authType = 1; // basic
            }

            s = DevExpress.data.base64_encode([((d.getUTCMilliseconds() * d.getSeconds()) * (d.getUTCMilliseconds() * d.getSeconds()) * 1002),
                                                authType, // 1
                                                AdvantageMobile_UI.CurrentUser.ServerName(),
                                                AdvantageMobile_UI.CurrentUser.DatabaseName(),
                                                AdvantageMobile_UI.CurrentUser.UserCode(),
                                                AdvantageMobile_UI.CurrentUser.Password(), // 5
                                                AdvantageMobile_UI.CurrentUser.IsWindowsAuth(),
                                                AdvantageMobile_UI.CurrentUser.DomainName(),
                                                AdvantageMobile_UI.CurrentUser.NetworkUserId(),
                                                AdvantageMobile_UI.CurrentUser.NetworkPassword(),
                                                AdvantageMobile_UI.CurrentUser.UpperCaseUser(), // 10
                                                AdvantageMobile_UI.CurrentUser.UpperCaseDatabase(),
                                                AdvantageMobile_UI.CurrentUser.ChooseServer(),
                                                AdvantageMobile_UI.CurrentUser.SqlControlledAdmin(),
                                                AdvantageMobile_UI.CurrentUser.NTAuthIgnoreCase(),
                                                AdvantageMobile_UI.CurrentUser.IsConfigSet(), // 15
                                                AdvantageMobile_UI.CurrentUser.AdvantageUserLicenseInUseID(),
                                                AdvantageMobile_UI.CurrentUser.ApplicationTimeOutMinutes(),
                                              ((d.getUTCMilliseconds() * d.getSeconds()) * (d.getUTCMilliseconds() * d.getSeconds()) * 2007)].join(":"));

            //
            //alert(AdvantageMobile_UI.CurrentUser.IsWindowsAuth());
            if (AdvantageMobile_UI.CurrentUser.IsWindowsAuth() && AdvantageMobile_UI.CurrentUser.IsWindowsAuth() == true) {

                var b = "Basic " + DevExpress.data.base64_encode([AdvantageMobile_UI.CurrentUser.UserCode(), AdvantageMobile_UI.CurrentUser.Password()].join(":"))
                xhr.setRequestHeader('Authorization', b);
                //console.warn(b)
                xhr.setRequestHeader('PBTT20071002', s);

            } else {

                xhr.setRequestHeader('Authorization', s);
                xhr.setRequestHeader('PBTT20071002', s);

            }

        }
    });

}

(function () {

    initializeApplication();

    // Enable partial CORS support for IE < 10    
    $.support.cors = true;


}());