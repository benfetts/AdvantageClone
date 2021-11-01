app.controller('clientLookupModalController', function ($scope, $http, $q, $modalInstance, $timeout, dataService, searchCriteria) {
    $scope.searchCriteria = angular.copy(searchCriteria);
    $scope.searchResults = [];
    $scope.searchText = "";
    $scope.selectedItem = null;
    $scope.selectionMade = false;
    $scope.searchTimeoutPromise = null;

    $scope.totalItems = 1;
    $scope.currentPage = 1;

    $scope.setPage = function (pageNo) {
        $scope.currentPage = pageNo;
    };

    $scope.pageChanged = function () {
       // $log.log('Page changed to: ' + $scope.currentPage);
    };

    $scope.setSelectedRow = function (item) {
        $scope.selectedItem = item;
        $scope.selectionMade = true;
    };

    $scope.setSelectedRowAndClose = function (item) {
        $scope.selectedItem = item;
        $scope.selectionMade = true;
        $scope.confirmSelection();
    };

    $scope.refreshSearchResults = function () {
        $timeout.cancel($scope.searchTimeoutPromise);
        $scope.searchTimeoutPromise = $timeout(function () {
            $scope.searchCriteria.SearchText = $scope.searchText;

            dataService.searchContracts($scope.searchCriteria).then(function (result) {
                $scope.searchResults = result.data;
                $scope.totalItems = $scope.searchResults.length;
                $scope.currentPage = 1;
            });
        }, 800);
    };

    $scope.initialSearchResults = function () {
        $scope.searchCriteria.SearchText = $scope.searchText;

        dataService.searchContracts($scope.searchCriteria).then(function (result) {
            $scope.searchResults = result.data;
            $scope.totalItems = $scope.searchResults.length;
            $scope.currentPage = 1;
        });
    }

    $scope.confirmSelection = function () {
        $modalInstance.close($scope.selectedItem);
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

    $scope.searchText = searchCriteria.searchText;
    $scope.initialSearchResults();

    $timeout(function () {
        $("#textBoxContractSearchDialog").focus();
    }, 100);
});