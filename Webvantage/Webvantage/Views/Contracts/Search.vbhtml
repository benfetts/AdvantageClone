@Code
    ViewData("Title") = "Search Page"
    Layout = "~/Views/Shared/_LayoutChildPage.vbhtml"
End Code

<div class="row" ng-app="contractsApp">
    <div style="padding-bottom:10px;">&nbsp;</div>
    <div class="col-md-3" ng-controller="searchController">
        <script type="text/ng-template" id="myModalContent.html">
            <div class="modal-header">
                <h3 class="modal-title">Contract Search - {{searchCriteria.SearchLevel}}</h3>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <input type="text" ng-model="searchText" id="textBoxContractSearchDialog" ng-keyup="refreshSearchResults()" class="form-control" /><span ng-show="$scope.searchText.length < 3">Please enter at least 3 characters to search on.</span>
                </div>

                <table class="table table-striped">

                    <thead>
                        <tr>
                            <th>Office</th>
                            <th>Client</th>
                            <th>Division</th>
                            <th>Product</th>
                            <th>Code</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr ng-repeat="result in searchResults" ng-dblclick="setSelectedRowAndClose(result)" ng-click="setSelectedRow(result)" ng-class="{info: selectedItem === result}">
                            <td>{{result.OfficeName}} <span ng-hide="result.OfficeCode === ''">({{result.OfficeCode}})</span></td>
                            <td>{{result.ClientName}} <span ng-hide="result.ClientCode === ''">({{result.ClientCode}})</span></td>
                            <td>{{result.DivisionName}} <span ng-hide="result.DivisionCode === ''">({{result.DivisionCode}})</span></td>
                            <td>{{result.ProductName}} <span ng-hide="result.ProductCode === ''">({{result.ProductCode}})</span></td>
                            <td>{{result.ContractCode}}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="modal-footer">
                <button type="submit" class="btn btn-primary" ng-disabled="!selectionMade" ng-click="confirmSelection()">Select</button>
                <button class="btn btn-warning" ng-click="cancel()">Cancel</button>
            </div>
        </script>
        <h2>Contract Search</h2>
        <form>
            <fieldset>
                <!-- Text input-->
                <div class="form-group">
                    <label class="control-label" for="filterOffice">Office</label>
                    <div>
                        <input id="filterOffice" name="filterOffice" ng-model="searchCriteria.OfficeCode" ng-dblclick="open('Office')" placeholder="Office" class="form-control input-md" type="text">
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="control-label" for="filterClient">Client</label>
                    <div>
                        <input id="filterClient" name="filterClient" ng-model="searchCriteria.ClientCode" ng-dblclick="open('Client')" placeholder="Client" class="form-control input-md" type="text">
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="control-label" for="filterDivision">Division</label>
                    <div>
                        <input id="filterDivision" name="filterDivision" ng-model="searchCriteria.DivisionCode" ng-dblclick="open('Division')" placeholder="Division" class="form-control input-md" type="text">
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="control-label" for="filterProduct">Product</label>
                    <div>
                        <input id="filterProduct" name="filterProduct" ng-model="searchCriteria.ProductCode" ng-dblclick="open('Product')" placeholder="Product" class="form-control input-md" type="text">
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="control-label" for="filterCode">Code</label>
                    <div>
                        <input id="filterCode" name="filterCode" ng-model="searchCriteria.ContractCode" placeholder="Code" ng-dblclick="open('Code')" class="form-control input-md" required="" type="text">
                    </div>
                </div>
                <!-- Text input-->
                <div class="form-group">
                    <label class="control-label" for="filterName">Name</label>
                    <div>
                        <input id="filterName" name="filterName" placeholder="Name" class="form-control input-md" required="" type="text">
                    </div>
                </div>
            </fieldset>
        </form>
    </div>
</div>

<script type="text/javascript">
    // typically all of these elements are in their own files, with a particular directory structure.
    // this is just for a one-stop-shop example
    var app = angular.module('contractsApp', ['ui.bootstrap']);

    app.service('dataService', function ($http, $q) {

        this.searchContracts = function (searchCriteria) {
            var deferred = $q.defer();

            if (searchCriteria.SearchText === null || searchCriteria.SearchText === undefined) {
                searchCriteria.SearchText = '';
            }

            if (searchCriteria.OfficeCode === null || searchCriteria.OfficeCode === undefined) {
                searchCriteria.OfficeCode = '';
            }

            if (searchCriteria.ClientCode === null || searchCriteria.ClientCode === undefined) {
                searchCriteria.ClientCode = '';
            }

            if (searchCriteria.DivisionCode === null || searchCriteria.DivisionCode === undefined) {
                searchCriteria.DivisionCode = '';
            }

            if (searchCriteria.ProductCode === null || searchCriteria.ProductCode === undefined) {
                searchCriteria.ProductCode = '';
            }

            if (searchCriteria.ContractCode === null || searchCriteria.ContractCode === undefined) {
                searchCriteria.ContractCode = '';
            }

            try {
                $http({
                    url: window.location.origin + '/Webvantage/contracts/searchcontracts',
                    method: "POST",
                    data: { 'searchCriteriaText': JSON.stringify(searchCriteria) }
                })
                .then(function (response) {
                    // success
                    deferred.resolve(response);
                });
            } catch (e) {
                deferred.reject(e);
            }

            return deferred.promise;
        };
    });

    app.controller('searchController', function ($scope, $http, $modal) {
        $scope.searchCriteria = { OfficeCode: "", ClientCode: "", DivisionCode: "", ProductCode: "", ContractCode: "", SearchLevel: "", SearchText: "" };

        $scope.open = function (searchLevel) {
            var currentCriteria = angular.copy($scope.searchCriteria);
            currentCriteria.SearchLevel = searchLevel;

            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'myModalContent.html',
                controller: 'modalController',
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

    app.controller('modalController', function ($scope, $http, $q, $modalInstance, $timeout, dataService, searchCriteria) {
        $scope.searchCriteria = angular.copy(searchCriteria);
        $scope.searchResults = [];
        $scope.searchText = "";
        $scope.selectedItem = null;
        $scope.selectionMade = false;
        $scope.searchTimeoutPromise = null;

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
                });
            }, 800);
        };

        $scope.initialSearchResults = function()
        {
            $scope.searchCriteria.SearchText = $scope.searchText;

            dataService.searchContracts($scope.searchCriteria).then(function (result) {
                $scope.searchResults = result.data;
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
</script>