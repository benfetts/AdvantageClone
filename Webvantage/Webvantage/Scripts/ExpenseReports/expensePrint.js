var myApp = angular.module("angPrintReceipts", ["kendo.directives"]);

myApp.config(['$httpProvider', function ($httpProvider) {
    //initialize get if not there
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }
    // Answer edited to include suggestions from comments
    // because previous version of code introduced browser-related errors
    //disable IE ajax request caching
    $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
    // extra
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
}]);

myApp.config(['$compileProvider', function ($compileProvider) {
        $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|tel|file|blob):/);
}]);

myApp.config(['$rootScopeProvider', function ($rootScopeProvider) {
    $rootScopeProvider.digestTtl(15);
}]);

//define service calls for api
myApp.service("expService", function ($http) {
    return {
        savePrintSettings: function (PrintSupervisorBelowSignature, ExcludeEmployeeSignature, ExcludeSupervisorSignature, IncludeReceipts) {
            return $http.post("SavePrintSettings", { PrintSupervisorBelowSignature,ExcludeEmployeeSignature,ExcludeSupervisorSignature,IncludeReceipts});
        }
    };
});

myApp.controller("ExpenseReportPrintController", function ($scope, $q, $http, expService) {

    angular.element(document).ready(function () {


        //if ($scope.includeRowsWithReceipts) {
        //    $('#includeRowsWithReceipts').addClass('wv-add-new').removeClass('wv-neutral');
        //}

        //if ($scope.showThumbnail) {
        //    $('#showThumbnail').addClass('wv-add-new').removeClass('wv-neutral');
        //} 

        //if ($scope.hideReceiptsApplied) {
        //    $('#hideReceiptsApplied').addClass('wv-add-new').removeClass('wv-neutral');
        //}

        //$scope.allReceipts.forEach((image) => {

        //    var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
        //            image.url = url;
           
        //});

    });

    //declaring variables

    $scope.invoiceNumber = invoiceNumber;         
      

    $scope.printSave = function (arg1, arg2, arg3, arg4) {
        expService.savePrintSettings(arg1, arg2, arg3, arg4).then(function (result) {

        });
    };

});

function getScope(ctrlName) {
    var sel = 'div[ng-controller="' + ctrlName + '"]';
    return angular.element(sel).scope();
}








