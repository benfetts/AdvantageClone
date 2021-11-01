(function () {


    var USER_KEY = "PBTT20071002";
    var cachedUserDataString = localStorage.getItem(USER_KEY);
    var cachedUserData = cachedUserDataString ? JSON.parse(cachedUserDataString) : null;
    function saveLocal() {
        try {
            //localStorage.setItem(USER_KEY, JSON.stringify(this.toJS()));
            var s = JSON.stringify(this.toJS());
            s = sjcl.encrypt("ParkerAndLoïeTran", s);
            //console.warn("saveLocal :: " + s);
            localStorage.setItem(USER_KEY, s);
        }
        catch (ex) {
            DevExpress.ui.dialog.alert(ex);
        }
        finally {
        };
    };
    function getLocal() {
        try {
            var s = null;
            if (localStorage.getItem(USER_KEY) != undefined) {
                s = localStorage.getItem(USER_KEY);
                s = sjcl.decrypt("ParkerAndLoïeTran", s);
                //console.warn("getLocal :: " + s);
            };
            return s;
            //var cachedString = localStorage.getItem(USER_KEY);
            //return cachedString;
        }
        catch (ex) {
            DevExpress.ui.dialog.alert(ex);
        }
        finally {
        };
    };
    function clearLocal() {
        try {
            localStorage.removeItem(USER_KEY);
        }
        catch (ex) {
            DevExpress.ui.dialog.alert(ex);
        }
        finally {
        };
    };

    // would be nice if this could return a bool, but it won't
    function validateFromServer() {
        AdvantageMobile_UI.db.get('GetMobileUser')
            .done(function (data) {
                //alert(data.EmployeeCode)
                if (data.IsValid != null && data.IsValid == false) {
                    AdvantageMobile_UI.Messages.toastWarning("Sign in Failed");
                    AdvantageMobile_UI.app.navigate('sign_in');
                };
            })
            .fail(function (data) {
                handleDataServiceError(data);
            })
    };

    $.extend(AdvantageMobile_UI.MobileUserViewModel.prototype, {
        saveLocal: saveLocal,
        getLocal: getLocal,
        clearLocal: clearLocal,
        validateFromServer: validateFromServer,
        userKey: USER_KEY,
    });

})();