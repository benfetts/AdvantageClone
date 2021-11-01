var myApp = angular.module("angExpenseReportReceipts", ["kendo.directives"]);

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

myApp.service("expService", function ($http) {
    return {

        getExpenseReportDetails: function (invoiceNumber) {
            return $http.get("GetExpenseReportDetails?InvoiceNumber=" + invoiceNumber);
        },
        getReceiptsList: function (invoiceNumber) {
            return $http.get("GetReceiptsList?InvoiceNumber=" + invoiceNumber);
        },
        downloadReceipt: function (documentID) {
            return $http.get("DownloadReceipt?DocumentID=" + documentID);
        },
        copyReceipt: function (documentID, invoiceNumber) {
            return $http.get("CopyReceipt?DocumentID=" + documentID + '&InvoiceNumber=' + invoiceNumber);
        },
        deleteReceipt: function (documentID) {
            return $http.post("DeleteReceipt?DocumentID=" + documentID);
        }

    };
});

myApp.controller("ExpenseReportReceiptsController", function ($scope, $q, $http, expService) {

    $scope.invoiceNumber = invoiceNumber;
    $scope.allReceipts = initAllReceipts;
    $scope.gridAllReceiptsData = [];

    //functions
    function getAllReceiptsData() {

        $scope.gridAllReceiptsData = [];
        $scope.allReceipts.forEach((image) => {

            var item = {
                Receipt: image.ThumbnailData,
                DocumentId: image.DocumentId,
                Level: 'Expense Report',
                Filename: image.Filename,
                Description: image.Description,
                Date: new Date(image.UploadedDate),
                Action: ''
            };
            //console.log(image.Date);


            $scope.gridAllReceiptsData.push(item);


        });
    }

    getAllReceiptsData();


    function getDataSource() {

        var dataSource = {
            data: $scope.gridAllReceiptsData,
            pageSize: 20,
            batch: false,
            schema: {
                model: {
                    fields: {
                        DocumentId: { type: "number" },
                        Receipt: { type: "object", editable: false },
                        Level: { type: "string" },
                        Filename: { type: "string" },
                        Description: { type: "string" },
                        Date: { type: "date" },
                        Action: { type: "string" }
                    }
                }
            }
        };

        return dataSource;
    }


    //grids
    $scope.allReceiptsOptions = {
        dataSource: {
            data: $scope.gridAllReceiptsData,
            pageSize: 20,
            batch: false,
            schema: {
                model: {
                    fields: {
                        DocumentId: { type: "number" },
                        Receipt: { type: "object", editable: false },
                        Level: { type: "string" },
                        Filename: { type: "string" },
                        Description: { type: "string" },
                        Date: { type: "date" },
                        Action: { type: "string" }
                    }
                }
            }
        },
        editable: false,
        navigatable: true,
        selectable: false,
        height: 550,
        resizable: true,
        pageable: {
            refresh: false,
            info: false,
            //pageSizes: true,
            buttonCount: 5,
            //alwaysVisible: false,
            pageSizes: [10, 20, 30, 40]
            //pageSize: 10
        },
        columns: [
            { field: "Receipt", title: "Receipt", template: receiptTemplate, width: 170, minResizableWidth: 150 },
            { field: "Level", title: "Level", width: 100 },
            { field: "Filename", title: "File name", width: 150, minResizableWidth: 150 },
            { field: "Description", title: "File description", width: 200, minResizableWidth: 150 },
            { field: "Date", title: "Date", format: "{0:MM/dd/yyyy}", width: 100, minResizableWidth: 100 },
            { field: "Action", title: "Action", template: allReceiptsActionButtons, width: 130 }
        ]
    };


    //grid field templates
    function receiptTemplate(item) {
        var template = kendo.template($("#receiptThumnail").html());

        //var data = { image: item.Receipt, filename: item.Filename };
        var data = item.Receipt;

        var result = template(data);
        return result;
        //console.log('receipt: ');
        //console.log(container);       
    }
    
    function allReceiptsActionButtons(item) {
        var template = kendo.template($("#receiptActionButtons").html());


        //var blob = new Blob([item.Receipt], { type: 'image/jpeg' });
        //var url = (window.URL || window.webkitURL).createObjectURL(blob);
        var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + item.DocumentId;

        //var data = item.DocumentId;
        var data = { DocumentId: item.DocumentId, filename: item.Filename, url: url };


        var result = template(data);
        return result;
        //console.log('receipt: ');
        //console.log(container);       
    }


    //grid button function
    $scope.receiptDownloadClick = function (docid) {

        expService.downloadReceipt(docid).then(function (result) {
        });
    };


    $scope.receiptCopyClick = function (docid) {
        console.log('receiptCopyClick: ' + docid);

        //$scope.invoiceNumber
        expService.copyReceipt(docid, $scope.invoiceNumber).then(function (result) {

            console.log('receipt copied:');
            expService.getReceiptsList($scope.invoiceNumber).then(function (receipts) {

                console.log('getReceiptsList finished');
                console.log(receipts.data);

                $scope.allReceipts = receipts.data;
                getAllReceiptsData();

                $scope.gridAllReceipts.setDataSource(getDataSource());
                setTimeout(function () { $scope.gridAllReceipts.dataSource.read(); $scope.gridAllReceipts.refresh(); }, 300);
            });
        });
    };

    $scope.receiptDeleteClick = function (docid) {
        console.log('receiptCopyClick: ' + docid);

        if (confirm('Are you sure you want to delete this upload (you can\'t undo this operation)?')) {
            //deleteReceipt
            expService.deleteReceipt(docid).then(function (result) {
                if (result && result.data) {
                    if (result.data.Success == true) {
                        expService.getReceiptsList($scope.invoiceNumber).then(function (receipts) {
                            $scope.allReceipts = receipts.data;
                            getAllReceiptsData();
                            $scope.gridAllReceipts.setDataSource(getDataSource());
                            setTimeout(function () { $scope.gridAllReceipts.dataSource.read(); $scope.gridAllReceipts.refresh(); }, 300);
                        });
                    } else {
                        if (result.data.Message && result.data.Message != "") {
                            showKendoAlert("<strong>Delete failed:</strong>&nbsp;&nbsp;" + result.data.Message);
                        }
                    }
                }
            });
        }
    };
});





