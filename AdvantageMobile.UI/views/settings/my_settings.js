AdvantageMobile_UI.my_settings = function (params, viewInfo) {

    var languages = [
        //{ id: "device", name: localizeString('Device') },
        { id: "default", name: localizeString('English') },
        { id: "de", name: localizeString('German') },
        { id: "fr", name: localizeString('French') }
    ];
    var themes = [
        { id: "aqua", name: "Aqua" }
    ];
    var platforms = [
        { id: "android", name: "Android" },
        { id: "ios", name: "iOS" },
        //{ id: "win8", name: "Windows 8 Phone" },
        { id: "generic", name: "Generic" }
    ];

    var savedLanguage = ko.observable();

    var languageSelectBox = {
        dataSource: languages,
        displayExpr: 'name',
        valueExpr: 'id',
        value: ko.observable()
    };
    var themeSelectBox = {
        dataSource: themes,
        displayExpr: 'name',
        valueExpr: 'id',
        value: ko.observable()
    };
    var platformSelectBox = {
        dataSource: platforms,
        displayExpr: 'name',
        valueExpr: 'id',
        value: ko.observable()
    };

    function viewShowing() {
        if (AdvantageMobile_UI.CurrentUser.LanguageCode() == undefined || AdvantageMobile_UI.CurrentUser.LanguageCode() == null) {
            languageSelectBox.value("default");
        } else {
            languageSelectBox.value(AdvantageMobile_UI.CurrentUser.LanguageCode());
            savedLanguage(AdvantageMobile_UI.CurrentUser.LanguageCode());
        };
        switch (DevExpress.devices.current().platform) {
            case "android":
                themes.push({ id: "android.holo-light", name: "Holo Light" }, { id: "android.holo-dark", name: "Holo Dark" });
                pushGenericThemes();
                if (AdvantageMobile_UI.CurrentUser.ThemeAndroid() == undefined || AdvantageMobile_UI.CurrentUser.ThemeAndroid() == null) {
                    themeSelectBox.value("android.holo-dark");
                } else {
                    themeSelectBox.value(AdvantageMobile_UI.CurrentUser.ThemeAndroid());
                };
                break;
            case "desktop":
                themes.push({ id: "desktop.default", name: localizeString('System Default') });
                if (AdvantageMobile_UI.CurrentUser.ThemeDesktop() == undefined || AdvantageMobile_UI.CurrentUser.ThemeDesktop() == null) {
                    themeSelectBox.value("desktop.default");
                } else {
                    themeSelectBox.value(AdvantageMobile_UI.CurrentUser.ThemeDesktop());
                };
                break;
            case "generic":
                if (AdvantageMobile_UI.CurrentUser.ThemeDesktop() == undefined || AdvantageMobile_UI.CurrentUser.ThemeDesktop() == null) {
                    themeSelectBox.value("advgeneric.light");
                } else {
                    themeSelectBox.value(AdvantageMobile_UI.CurrentUser.ThemeDesktop());
                };
                break;
            case "ios":
                themes.push({ id: "ios7.default", name: localizeString('System Default') });
                if (AdvantageMobile_UI.CurrentUser.ThemeIOS() == undefined || AdvantageMobile_UI.CurrentUser.ThemeIOS() == null) {
                    themeSelectBox.value("ios7.default");
                } else {
                    themeSelectBox.value(AdvantageMobile_UI.CurrentUser.ThemeIOS());
                };
                break;
            case "tizen":
                themes.push({ id: "tizen.white", name: "White" }, { id: "tizen.black", name: "Black" });
                if (AdvantageMobile_UI.CurrentUser.ThemeTizen() == undefined || AdvantageMobile_UI.CurrentUser.ThemeTizen() == null) {
                    themeSelectBox.value("tizen.black");
                } else {
                    themeSelectBox.value(AdvantageMobile_UI.CurrentUser.ThemeTizen());
                };
                break;
            case "win8":
                themes.push({ id: "win8.white", name: "White" }, { id: "win8.black", name: "Black" });
                if (AdvantageMobile_UI.CurrentUser.ThemeWin8() == undefined || AdvantageMobile_UI.CurrentUser.ThemeWin8() == null) {
                    themeSelectBox.value("win8.black");
                } else {
                    themeSelectBox.value(AdvantageMobile_UI.CurrentUser.ThemeWin8());
                };
                break;
        };
        if (AdvantageMobile_UI.CurrentUser.Platform() == undefined || AdvantageMobile_UI.CurrentUser.Platform() == null) {

        } else {
            platformSelectBox.value(AdvantageMobile_UI.CurrentUser.Platform());
        };
    };
    function pushGenericThemes() {
        themes.push({ id: "advgeneric.light", name: "Generic Light" }, { id: "advgeneric.dark", name: "Generic Dark" });
    }
    function viewShown(e) {
    };
    function viewDisposing() {
    };
    function handleSave() {
        AdvantageMobile_UI.CurrentUser.LanguageCode(languageSelectBox.value());
        switch (DevExpress.devices.current().platform) {
            case "android":
                AdvantageMobile_UI.CurrentUser.ThemeAndroid(themeSelectBox.value());
                break;
            case "desktop":
                AdvantageMobile_UI.CurrentUser.ThemeDesktop(themeSelectBox.value());
                break;
            case "ios":
                AdvantageMobile_UI.CurrentUser.ThemeIOS(themeSelectBox.value());
                break;
            case "tizen":
                AdvantageMobile_UI.CurrentUser.ThemeTizen(themeSelectBox.value());
                break;
            case "win8":
                AdvantageMobile_UI.CurrentUser.ThemeWin8(themeSelectBox.value());
                break;
        }
        AdvantageMobile_UI.CurrentUser.Platform(platformSelectBox.value());
        AdvantageMobile_UI.CurrentUser.saveLocal();
        AdvantageMobile_UI.Messages.toastSuccess();
        ////Globalize.culture(languageSelectBox.value());
        //DevExpress.ui.themes.current(themeSelectBox.value());
        //re-init app or shutdown
        //if (languageSelectBox.value() != AdvantageMobile_UI.CurrentUser.LanguageCode()) {
            //shutDown();
        //};
    };

    var viewModel = {
        languages: languages,
        themes: themes,
        viewShowing: viewShowing,
        viewShown: viewShown,
        viewDisposing: viewDisposing,
        languageSelectBox: languageSelectBox,
        themeSelectBox: themeSelectBox,
        handleSave: handleSave,
        platformSelectBox: platformSelectBox,
    };

    return viewModel;

};