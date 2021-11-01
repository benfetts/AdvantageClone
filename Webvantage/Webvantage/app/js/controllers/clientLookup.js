app.controller('clientLookupController', function ($scope, $http, $modal) {
    $scope.searchCriteria = { OfficeCode: "", ClientCode: "", DivisionCode: "", ProductCode: "", ContractCode: "", SearchLevel: "", SearchText: "" };

    $scope.open = function (searchLevel) {
        var currentCriteria = angular.copy($scope.searchCriteria);
        currentCriteria.SearchLevel = searchLevel;

        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'app/templates/clientLookupModal.html',
            controller: 'clientLookupModalController',
            size: 'lg',
            resolve: {
                searchCriteria: function () {
                    return currentCriteria;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.searchCriteria = selectedItem;
        }, function () {
            //  $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };
});