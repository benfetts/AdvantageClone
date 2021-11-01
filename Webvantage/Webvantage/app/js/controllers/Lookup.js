app.controller('lookupController', function ($scope, $http, $modal) {
    $scope.searchCriteria = { SecurityModule: "", LookupType: "", SearchText: "" };

    $scope.open = function (secModule, lookupType) {
        var currentCriteria = angular.copy($scope.searchCriteria);
        currentCriteria.LookupType = lookupType;
        currentCriteria.SecurityModule = secModule;

        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'app/templates/lookupModal.html',
            controller: 'lookupModalController',
            size: 'lg',
            resolve: {
                searchCriteria: function () {
                    return currentCriteria;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            if (selectedItem) {
                $scope.searchCriteria[selectedItem.ObjectName] = selectedItem;
            } else {
                $scope.searchCriteria = null;
            }
            var abc = null;
        }, function () {
            //  $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };
});