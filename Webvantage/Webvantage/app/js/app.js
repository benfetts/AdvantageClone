var app = angular.module('webvantageApp', ['ui.bootstrap', 'kendo.directives'])
.run(function ($rootScope) {
    $rootScope.maximumItemsPerPage = 8;
    $rootScope.maximumPageDisplayCount = 10;

    $rootScope.initialModalDialogWidth = 800;
    $rootScope.initialModalDialogHeight = 680;

    $rootScope.getCurrentRadWindow = function () {

        var oWindow = null;

        try{
            if (window.radWindow) {
                oWindow = window.radWindow;
            }
            else {
                if (window.frameElement.radWindow) {
                    oWindow = window.frameElement.radWindow;
                } else if (window.parent.frameElement.radWindow) {
                    oWindow = window.parent.frameElement.radWindow;
                }
            }
        } catch (ex) {

        }
        return oWindow;
    };

    $rootScope.defaultPercentOptions = {
        format: "p",
        decimals: 4,
        min: 0,
        step: 0.0001,
        spinners: false
    };

    $rootScope.applicationLocation = function () {
        var loc = document.location.toString();
        var appNameIndex = loc.indexOf('/', loc.indexOf('://') + 3);
        var appName = loc.substring(0, appNameIndex) + '/';
        var webFolderIndex = loc.indexOf('/', loc.indexOf(appName) + appName.length);
        var webFolderPath = loc.substring(0, webFolderIndex);

        return webFolderPath;
    };


});