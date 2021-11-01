app.controller('lookupModalController', function ($scope, $http, $q, $modalInstance, $timeout, dataService, searchCriteria) {
    $scope.searchCriteria = angular.copy(searchCriteria);
    $scope.searchResults = [];
    $scope.searchText = "";
    $scope.selectedItem = null;
    $scope.selectionMade = false;
    $scope.searchTimeoutPromise = null;
    $scope.resultsReturned = false;

    $scope.totalItems = 0;
    $scope.currentPage = 1;
    $scope.numPerPage = 10;

    $scope.paginate = function (value) {
        var begin, end, index;
        begin = ($scope.currentPage - 1) * $scope.numPerPage;
        end = begin + $scope.numPerPage;
        index = $scope.searchResults.Results.indexOf(value);
        var toReturn = (begin <= index && index < end);
        return toReturn;
    };

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

            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                $scope.searchResults = result.data;
                $scope.totalItems = $scope.searchResults.Results.length;
                $scope.currentPage = 1;
                $scope.selectedItem = null;
                $scope.selectionMade = false;
                $scope.resultsReturned = true;
            });
        }, 800);
    };

    $scope.initialSearchResults = function () {
        $scope.searchCriteria.SearchText = $scope.searchText;

        dataService.searchLookup($scope.searchCriteria).then(function (result) {
            $scope.searchResults = result.data;
            $scope.totalItems = $scope.searchResults.Results.length;
            $scope.currentPage = 1;
            $scope.resultsReturned = true;
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
        //$("#textBoxContractSearchDialog").focus();
    }, 100);
});