app.controller('kendoGridLookupWindowController', function ($scope, $rootScope, $timeout, dataService) {
    $scope.searchCriteria = {
        JobComponent: {
            ClientCode: '',
            DivisionCode: '',
            ProductCode: '',
            JobNumber: 0,
            JobComponentNumber: 0
        },
        Employee: {
            EmployeeCode: ''
        },
        FunctionCategory: {
            EmployeeCode: '',
            JobNumber: '',
            SearchText: '',
            FunctionCode: '',
            FunctionDescription: ''
        },
        LookupType: '',
        ShowInactive: false
    };

    $scope.searchResults = [];
    $scope.searchText = '';
    $scope.selectedItem = null;
    $scope.selectionMade = false;
    $scope.searchTimeoutPromise = null;
    $scope.resultsReturned = false;
    $scope.currentRadWindow = null;
    $scope.callingWindowName = '';
    $scope.callingWindowScope = null;
    $scope.resultCount = 0;

    $scope.optionsPanel = [];

    $scope.refreshSearchResults = function () {
        $timeout.cancel($scope.searchTimeoutPromise);
        $scope.searchTimeoutPromise = $timeout(function () {
            $scope.searchCriteria.SearchText = $scope.searchText;

            dataService.searchLookup($scope.searchCriteria).then(function (result) {
                $scope.searchResults = result.data;
                $scope.selectedItem = null;
                $scope.selectionMade = false;
                $scope.resultsReturned = true;
                $scope.resultCount = result.data.Results.length;
                var newDataSource = new kendo.data.DataSource({
                    data: $scope.searchResults.Results,
                    pageSize: 100
                });
                $('#selectorGrid').data('kendoGrid').setDataSource(newDataSource);
            });
        }, 500);
    };

    $scope.initialSearchResults = function () {
        $scope.searchCriteria.SearchText = $scope.searchText;
        dataService.searchLookup($scope.searchCriteria).then(function (result) {
            $scope.searchResults = result.data;
            $scope.resultsReturned = true;
            $scope.resultCount = result.data.Results.length;
            var gridColumns = [];
            var firstResult = result.data.Results[0];
            var minWidths = {};
            $(result.data.Columns).each(function () {
                $('#calc-width').html(this.HeaderText);
                minWidths[this.FieldName] = $('#calc-width').width() + 20;
                $('#calc-width').html('');
            });
            $(result.data.Results).each(function () {
                var item = this;
                $(result.data.Columns).each(function () {
                    $('#calc-width').html(item[this.FieldName]);
                    var thisWidth = $('#calc-width').width() + 20;
                    if (thisWidth > minWidths[this.FieldName]) {
                        minWidths[this.FieldName] = thisWidth;
                    }
                    $('#calc-width').html('');
                });
            });
            $(result.data.Columns).each(function () {
                var gc = { field: this.FieldName, title: this.HeaderText }
                var width = minWidths[this.FieldName];
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
                dataSource: new kendo.data.DataSource({
                    data: $scope.searchResults.Results,
                    pageSize: 100
                }),
                width: 400,
                pageable: false,
                height: 390,
                selectable: "row",
                scrollable: {
                    virtual: true
                },
                columns: gridColumns,
                change: function (e) {
                    gridSelectionChanged();
                },
                dataBound: function () {
                    gridSelectionChanged();
                    var currentRadWindow = $rootScope.getCurrentRadWindow();
                    var windowWidth = currentRadWindow.get_width(),
                        contentWidth = $('#content').outerWidth();
                    if (windowWidth < contentWidth) {
                        currentRadWindow.autoSize();
                    }
                }
            };
            //if ($modalInstance.dataLoaded !== undefined) {
            //    $modalInstance.dataLoaded(gridColumns);
            //}

            $('#selectorGrid').on('dblclick', 'tbody > tr ', function () {
                $scope.confirmSelection();
            });

            $('#searchInput').keyup(function (e) {
                var grid = $('#selectorGrid').data('kendoGrid');
                var val = $('#searchInput').val().toString().toLowerCase();
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
        if ($scope.currentRadWindow === null) {
            $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
        }

        if ($scope.callingWindowScope) {
            try {
                $scope.callingWindowScope.processLookupSelection($scope.selectedItem);
            } catch (err) {
                
            }
        }
        $scope.currentRadWindow.close();
    };

    $scope.cancel = function () {
         if ($scope.currentRadWindow === null) {
            $scope.currentRadWindow = $rootScope.getCurrentRadWindow();
        }

        $scope.currentRadWindow.close();
    };

    $scope.POFilterVendors = function () {
        $scope.searchCriteria.Vendor.IncludeMediaVendors = $scope.optionsPanel['POInlcudeMediaVendors'];
        $scope.refreshSearchResults();
    };

    $scope.EstimateFilterVendors = function () {
        $scope.searchCriteria.Vendor.IncludeMediaVendors = $scope.optionsPanel['EstimateMediaVendors'];
        $scope.searchCriteria.Vendor.LimitbyDefaultFunction = $scope.optionsPanel['EstimateLimitVendors'];
        $scope.refreshSearchResults();
    };

    var getCheckBoxColumnTemplate = function (fieldName) {
        return '<div style="text-align: center;"><input type="checkbox" #= ' + fieldName + ' ? "checked=checked" : "" # disabled="disabled" style="vertical-align:middle; margin-top: 0;" ></input></div>'
    };

});
