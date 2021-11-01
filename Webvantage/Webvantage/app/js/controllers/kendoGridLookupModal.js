app.controller('kendoGridLookupModalController', function ($scope, $http, $q, $modalInstance, $timeout, dataService, searchCriteria) {
    $scope.searchCriteria = angular.copy(searchCriteria);
    $scope.searchResults = [];
    $scope.searchText = "";
    $scope.selectedItem = null;
    $scope.selectionMade = false;
    $scope.searchTimeoutPromise = null;
    $scope.resultsReturned = false;

    $scope.refreshSearchResults = function () {
        $timeout.cancel($scope.searchTimeoutPromise);
        $scope.searchTimeoutPromise = $timeout(function () {
            $scope.searchCriteria.SearchText = $scope.searchText;

            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                $scope.searchResults = result.data;
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
            $scope.resultsReturned = true;
            var gridColumns = [];
            var firstResult = result.data.Results[0];
            var map = columnWidthMap();
            $(result.data.Columns).each(function () {
                var gc = { field: this.FieldName, title: this.HeaderText }
                var width = map.get(this.FieldName);
                if (width !== undefined && width !== null) {
                    gc.width = width;
                }
                if (firstResult) {
                    var template;
                    if (typeof firstResult[this.FieldName] === 'boolean') {
                        template = getCheckBoxColumnTemplate(this.FieldName);
                    }
                    if (template) {
                        gc.template = template;
                    }
                }
                gridColumns.push(gc);
            });

            $scope.gridOptions = {
                dataSource: {
                    data: $scope.searchResults.Results,
                    pageSize: 100
                },
                height: 510,
                selectable: "row",
                resizable: true,
                pageable: {
                    info: true,
                    numeric: false,
                    previousNext: false
                },
                scrollable: {
                    virtual: true
                },
                columns: gridColumns,
                change: function (e) {
                    gridSelectionChanged();
                },
                dataBound: function () {
                    gridSelectionChanged();
                }
            };

            if ($modalInstance.dataLoaded !== undefined) {
                $modalInstance.dataLoaded(gridColumns);
            }

            $('#selectorGrid').on('dblclick', 'tbody > tr ', function () {
                $scope.confirmSelection();
            });

            $('#searchInput').keyup(function (e) {
                var grid = $('#selectorGrid').data('kendoGrid');
                var val = $('#searchInput').val();
                var dataFilters = [];
                //console.log(grid.dataSource);
                for (var i = 0; i < grid.columns.length; i++) {
                    var col = grid.columns[i];
                    if (col.hidden !== true) {
                        var filter = {
                            field: col.field,
                            operator: function (item) {
                                return (item.toString().toLowerCase().indexOf(val) >= 0);
                            }
                        };
                        dataFilters.push(filter);
                    }
                }
                grid.dataSource.filter([{
                    logic: "or",
                    filters: dataFilters
                }]);
            });

        });
    }

    var gridSelectionChanged = function () {
        var gridData = $('#selectorGrid').data('kendoGrid');
        var selectedRows = gridData.select(),
            enabled = false,
            item = null;
        if (selectedRows.length > 0) {
            item = gridData.dataItem(selectedRows[0]);
            enabled = true;
        }
        $scope.selectedItem = item;
        $('#selectButton').data('kendoButton').enable(enabled);
    };

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

    var getCheckBoxColumnTemplate = function (fieldName) {
        return '<div style="text-align: center;"><input type="checkbox" #= ' + fieldName + ' ? "checked=checked" : "" # disabled="disabled" style="vertical-align:middle; margin-top: 0;" ></input></div>'
    };

    var columnWidthMap = function () {

        var map = new Map();

        map.set('ClientCode', 100);
        map.set('CPMFlag', 75);
        map.set('DivisionCode', 100);
        map.set('EmployeeCode', 100);
        map.set('FunctionCode', 100);
        map.set('GeneralLedgerCode', 125);
        map.set('JobNumber', 100);
        map.set('JobComponentNumber', 100);
        map.set('ProductCode', 100);
        map.set('VendorCode', 100);
        map.set('VendorContactCode', 100);

        return map;

    }; 

});