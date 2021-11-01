
(function () {
    AdvantageMobile_UI.MobileUserViewModel = function (data) {
        this.DatabaseName = ko.observable();
        this.DefaultFunctionCode = ko.observable();
        this.DepartmentTeamCode = ko.observable();
        this.EmployeeCode = ko.observable();
        this.IsSignedIn = ko.observable();
        this.IsValid = ko.observable(false);
        this.IsValidDatabase = ko.observable(false);
        this.LanguageCode = ko.observable();
        this.MobileLicense = ko.observable();
        this.Password = ko.observable();
        this.Platform = ko.observable();
        this.RememberPassword = ko.observable(true);
        this.RememberUserName = ko.observable(true);
        this.ServerName = ko.observable();
        this.ServicesURL = ko.observable();
        this.IsWindowsAuth = ko.observable();
        this.DomainName = ko.observable();
        this.NetworkUserId = ko.observable();
        this.NetworkPassword = ko.observable();
        this.UpperCaseUser = ko.observable(false);
        this.UpperCaseDatabase = ko.observable(false);
        this.ChooseServer = ko.observable(true);
        this.SqlControlledAdmin = ko.observable(false);
        this.NTAuthIgnoreCase = ko.observable(false);
        this.IsConfigSet = ko.observable(false);
        this.ThemeAndroid = ko.observable();
        this.ThemeDesktop = ko.observable();
        this.ThemeGeneric = ko.observable();
        this.ThemeIOS = ko.observable();
        this.ThemeTizen = ko.observable();
        this.ThemeWin8 = ko.observable();
        this.Token = ko.observable();
        this.UserCode = ko.observable();
        this.TimeApprovalActive = ko.observable();
        this.AdvantageUserLicenseInUseID = ko.observable(0);
        this.ApplicationTimeOutMinutes = ko.observable(0);
        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.MobileUserViewModel.prototype, {
        toJS: function () {
            return {
                DatabaseName: this.DatabaseName(),
                DefaultFunctionCode: this.DefaultFunctionCode(),
                DepartmentTeamCode: this.DepartmentTeamCode(),
                EmployeeCode: this.EmployeeCode(),
                IsSignedIn: this.IsSignedIn(),
                IsValid: this.IsValid(),
                IsValidDatabase: this.IsValidDatabase(),
                LanguageCode: this.LanguageCode(),
                MobileLicense: this.MobileLicense(),
                Password: this.Password(),
                Platform: this.Platform(),
                RememberPassword: this.RememberPassword(),
                RememberUserName: this.RememberUserName(),
                ServerName: this.ServerName(),
                ServicesURL: this.ServicesURL(),
                IsWindowsAuth: this.IsWindowsAuth(),
                DomainName: this.DomainName(),
                NetworkUserId: this.NetworkUserId(),
                NetworkPassword: this.NetworkPassword(),
                UpperCaseUser: this.UpperCaseUser(),
                UpperCaseDatabase: this.UpperCaseDatabase(),
                ChooseServer: this.ChooseServer(),
                SqlControlledAdmin: this.SqlControlledAdmin(),
                NTAuthIgnoreCase: this.NTAuthIgnoreCase(),
                IsConfigSet: this.IsConfigSet(),
                ThemeAndroid: this.ThemeAndroid(),
                ThemeDesktop: this.ThemeDesktop(),
                ThemeGeneric: this.ThemeGeneric(),
                ThemeIOS: this.ThemeIOS(),
                ThemeTizen: this.ThemeTizen(),
                ThemeWin8: this.ThemeWin8(),
                Token: this.Token(),
                UserCode: this.UserCode(),
                TimeApprovalActive: this.TimeApprovalActive(),
                AdvantageUserLicenseInUseID: this.AdvantageUserLicenseInUseID(),
                ApplicationTimeOutMinutes: this.ApplicationTimeOutMinutes(),
            };
        },

        fromJS: function (data) {
            if (data) {
                this.DatabaseName(data.DatabaseName);
                this.DefaultFunctionCode(data.DefaultFunctionCode);
                this.DepartmentTeamCode(data.DepartmentTeamCode);
                this.EmployeeCode(data.EmployeeCode);
                this.IsSignedIn(data.IsSignedIn);
                this.IsValid(data.IsValid);
                this.IsValidDatabase(data.IsValidDatabase);
                this.LanguageCode(data.LanguageCode);
                this.MobileLicense(data.MobileLicense);
                this.Password(data.Password);
                this.Platform(data.Platform);
                this.RememberPassword(data.RememberPassword);
                this.RememberUserName(data.RememberUserName);
                this.ServerName(data.ServerName);
                this.ServicesURL(data.ServicesURL);
                this.IsWindowsAuth(data.IsWindowsAuth);
                this.DomainName(data.DomainName);
                this.NetworkUserId(data.NetworkUserId);
                this.NetworkPassword(data.NetworkPassword);
                this.UpperCaseUser(data.UpperCaseUser);
                this.UpperCaseDatabase(data.UpperCaseDatabase);
                this.ChooseServer(data.ChooseServer);
                this.SqlControlledAdmin(data.SqlControlledAdmin);
                this.NTAuthIgnoreCase(data.NTAuthIgnoreCase);
                this.IsConfigSet(data.IsConfigSet);
                this.ThemeAndroid(data.ThemeAndroid);
                this.ThemeDesktop(data.ThemeDesktop);
                this.ThemeGeneric(data.ThemeGeneric);
                this.ThemeIOS(data.ThemeIOS);
                this.ThemeTizen(data.ThemeTizen);
                this.ThemeWin8(data.ThemeWin8);
                this.Token(data.Token);
                this.UserCode(data.UserCode);
                this.TimeApprovalActive(data.TimeApprovalActive);
                this.AdvantageUserLicenseInUseID(data.AdvantageUserLicenseInUseID);
                this.ApplicationTimeOutMinutes(data.ApplicationTimeOutMinutes);
            }
        }
    });
})();