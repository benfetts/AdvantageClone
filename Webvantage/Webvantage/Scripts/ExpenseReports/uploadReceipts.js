var myApp = angular.module("angUploadReceipts", ["kendo.directives"]);

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

        getExpenseReportDetails: function (invoiceNumber) {
            return $http.get("GetExpenseReportDetails?InvoiceNumber=" + invoiceNumber);
        },
        getReceiptsList: function (invoiceNumber) {
            return $http.get("GetReceiptsList?InvoiceNumber=" + invoiceNumber);
        },
        getReceiptsListUnassigned: function (employeecode) {
            return $http.get("GetReceiptsListUnassigned?EmployeeCode=" + employeecode);
        },
        downloadReceipt: function (documentID) {
            return $http.get("DownloadReceipt?DocumentID=" + documentID);
        },
        copyReceipt: function (documentID, invoiceNumber) {
            return $http.get("CopyReceipt?DocumentID=" + documentID + '&InvoiceNumber=' + invoiceNumber);
        },
        deleteReceipt: function (documentID, invoiceNumber) {
            return $http.post("DeleteReceipt?DocumentID=" + documentID);
        },
        deleteReceiptUnassigned: function (documentID, invoiceNumber) {
            return $http.post("DeleteReceiptUnassigned?DocumentID=" + documentID);
        },
        receiptToGrid: function (documentID, rowNumber, invoiceNumber) {
            return $http.get("ReceiptToGrid?DocumentID=" + documentID + '&RowNumber=' + rowNumber + '&InvoiceNumber=' + invoiceNumber);
        },
        removeReceiptFromGrid: function (documentID, rowNumber) {
            return $http.get("RemoveReceiptFromGrid?DocumentID=" + documentID + '&RowNumber=' + rowNumber);
        },
        createExpenseReportDetails: function (ExpenseReportDetails, isImported) {
            return $http.post("CreateExpenseReportDetailsWithList", { ExpenseReportDetails, isImported });
        },
        saveUploaderButtonStates: function (includeRowsWithReceipts, showThumbnail, hideReceiptsApplied) {
            return $http.get("SaveUploaderButtonStates?includeRowsWithReceipts=" + includeRowsWithReceipts + '&showThumbnail=' + showThumbnail + '&hideReceiptsApplied=' + hideReceiptsApplied);
        },
        updateExpenseReportDetails: function (data) {
        return $http.post("UpdateExpenseReportDetails", data);
        }        
    };
});

myApp.controller("UploadReceiptsController", function ($scope, $q, $http, expService) {

    angular.element(document).ready(function () {


        if ($scope.includeRowsWithReceipts) {
            $('#includeRowsWithReceipts').addClass('wv-add-new').removeClass('wv-neutral');
        }

        if ($scope.showThumbnail) {
            $('#showThumbnail').addClass('wv-add-new').removeClass('wv-neutral');
        } 

        if ($scope.hideReceiptsApplied) {
            $('#hideReceiptsApplied').addClass('wv-add-new').removeClass('wv-neutral');
        }

        $scope.allReceipts.forEach((image) => {

            var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                    image.url = url;
           
        });

        $scope.allReceiptsUnassigned.forEach((image) => {

            var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
            image.url = url;

        });

        //$scope.allReceipts.forEach(function (image, index) {
        //    if (image.Filename.toLowerCase().endsWith('.csv')) {
        //        image.extension = 'CSV';
        //        image.ThumbnailData = '../../Images/document_excel.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.doc')) {
        //        image.extension = 'DOC';
        //        image.ThumbnailData = '../../Images/document_word.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.docx')) {
        //        image.extension = 'DOCX';
        //        image.ThumbnailData = '../../Images/document_word.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.pdf')) {
        //        image.extension = 'PDF';
        //        image.ThumbnailData = '../../Images/document_pdf.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.ppt')) {
        //        image.extension = 'PPT';
        //        image.ThumbnailData = '../../Images/document_powerpoint.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.pptx')) {
        //        image.extension = 'PPTX';
        //        image.ThumbnailData = '../../Images/document_powerpoint.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.txt')) {
        //        image.extension = 'TXT';
        //        image.ThumbnailData = '../../Images/document_text.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.xls')) {
        //        image.extension = 'XLS';
        //        image.ThumbnailData = '../../Images/document_excel.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.xlsx')) {
        //        image.extension = 'XLSX';
        //        image.ThumbnailData = '../../Images/document_excel.png';
        //    }

        //    if (image.Filename.toLowerCase().endsWith('.zip')) {
        //        image.extension = 'ZIP';
        //        image.ThumbnailData = '../../Images/document_zip.png';
        //    }


        //});
        $scope.refreshGrid();
        resizeGrid();
    });

    //declaring variables

    $scope.invoiceNumber = invoiceNumber;
    $scope.status = status;
    $scope.allReceipts = initAllReceipts;
    $scope.allReceiptsUnassigned = initAllReceiptsUnassigned;
    $scope.uploadedImages = initUploadedImages;
    $scope.CanAdd = initCanAdd;
    $scope.CanUpdate = initCanUpdate;
    $scope.CanPrint = initCanPrint;
    $scope.Custom1 = initCustom1;
    $scope.Custom2 = initCustom2;

    $scope.UserCode = initUserCode;
    $scope.EmployeeCode = initEmployee;
    $scope.isLastPaymentSet = false;
    $scope.lastPaymentType = intiDefaultPaymentType;

    $scope.selectedReceipt = null;

    $scope.newGridRecoreds = [];
    $scope.receiptsOnNewRows = [];
    $scope.saveCancelEnabled = false;

    //lists for grid
    $scope.allJobs = initJobs;
    $scope.jobs = [];
    $scope.jobcomponents = [];

    $scope.expenseReportDetails = initData;
    $scope.gridData = [];
    $scope.gridData = prepereDataForGrid();

    

    //fill dropdowns content
    $scope.paymentTypes = [{ "Value": 0, "Description": "CC", LongDescription: "Company Card (CC)" }, { "Value": 1, "Description": "PC", LongDescription: "Personal Card or Cash (PC)" }];

    $scope.functionCodes = initFunctionCodes
        .map(function (item) { return { Code: item.Code, Description: item.Description + " (" + item.Code + ")", DescriptionOnly: item.Description }; });

    $scope.setAllReceipts = function () {
        $scope.allReceipts.forEach((image) => {

            image.Rows.forEach((row) => {

                if (row === item.Id) {
                    var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                    image.url = url;
                }

            });
        });
    };

    $scope.setAllReceiptsUnassigned = function () {
        $scope.allReceiptsUnassigned.forEach((image) => {

            image.Rows.forEach((row) => {

                if (row === item.Id) {
                    var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                    image.url = url;
                }

            });
        });
    };

    //adjusts data for grid representation
    function prepereDataForGrid(resetNewItems = false) {

        $scope.saveCancelEnabled = false;

        if (resetNewItems) {
            $scope.newGridRecoreds = [];
            $scope.receiptsOnNewRows = [];
            $scope.saveCancelEnabled = false;
        }
        else {
            if ($scope.grid != null && $scope.grid != 'undefined') {
                $scope.newGridRecoreds = [];
                $scope.grid.dataSource.data().forEach(function (row, index) {
                    if (row.Id < 0) {
                        $scope.newGridRecoreds.push(row);
                        if ($scope.CanUpdate === false) {
                            $scope.saveCancelEnabled = false;
                        } else {
                            $scope.saveCancelEnabled = true;
                        }
                        
                    }
                });
            }
        }
       

        var gridData = [];

        var item = {
            Id: 0,
            NewReceipts: null,
            Date: null,
            Description: '',
            Function: '',
            Amount: null,
            Job: '',
            Component: '',
            PaymentType: 1,
            Receipts: [],
            Uploader: null,
            ShowAllUploadedImages: true
        };
        gridData.push(item);

        //if there are new rows that are not saved
        $scope.newGridRecoreds.forEach(function (row) {
            //row.Receipts = [];

            var newRowRecord = {
                Id: row.Id,
                NewReceipts: null,
                Date: row.Date,
                Description: row.Description,
                Function: row.Function,
                Amount: row.Amount,
                Job: row.Job,
                Component: row.Component,
                PaymentType: row.PaymentType,
                Receipts: [],
                Uploader: null,
                ShowAllUploadedImages: true
            };

            $scope.receiptsOnNewRows.forEach(receipt => {
                if (receipt.rowId === row.Id) {
                    var image = $scope.allReceipts.find((item) => item.DocumentId == receipt.documentId);

                    image = getImageDatails(image);
                    newRowRecord.Receipts.push(image);
                }

            });

            gridData.push(newRowRecord);
        });


        $scope.expenseReportDetails.forEach(function (row) {

            var item = {
                Id: row.ID,
                NewReceipts: null,
                Date: row.ItemDate,
                Description: row.Description,
                Function: row.FunctionCode,
                Amount: row.Amount,
                Job: row.JobNumber,
                Component: row.JobComponentNumber,
                PaymentType: row.PaymentType,
                Receipts: [],
                Uploader: null,
                ShowAllUploadedImages: true,
                CreatedBy: row.CreatedBy,
                IsImported: row.IsImported
            };

            if (item.Job === null) { item.Job = ''; }
            if (item.Component === null) { item.Component = ''; }
            if (item.PaymentType === null) { item.PaymentType = ''; }

            $scope.allReceipts.forEach((image) => {

                image.Rows.forEach((row) => {

                    if (row === item.Id) {
                        var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                        image.url = url;

                        var extension = image.Mimetype.replace('image/', '');
                        if (extension.toLowerCase() === 'jpeg') { extension = "jpg"; }
                        image.extension = extension.toUpperCase();

                        if (image.Filename.toLowerCase().endsWith('.csv')) {
                            image.extension = 'CSV';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.doc')) {
                            image.extension = 'DOC';
                            image.ThumbnailData = '../../Images/document_word.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.docx')) {
                            image.extension = 'DOCX';
                            image.ThumbnailData = '../../Images/document_word.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.pdf')) {
                            image.extension = 'PDF';
                            image.ThumbnailData = '../../Images/document_pdf.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.ppt')) {
                            image.extension = 'PPT';
                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.pptx')) {
                            image.extension = 'PPTX';
                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.txt')) {
                            image.extension = 'TXT';
                            image.ThumbnailData = '../../Images/document_text.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.xls')) {
                            image.extension = 'XLS';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                            image.extension = 'XLSX';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.zip')) {
                            image.extension = 'ZIP';
                            image.ThumbnailData = '../../Images/document_zip.png';
                        }

                        item.Receipts.push(image);
                    }

                });
            });

            $scope.allReceiptsUnassigned.forEach((image) => {

                image.Rows.forEach((row) => {

                    if (row === item.Id) {
                        var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                        image.url = url;

                        var extension = image.Mimetype.replace('image/', '');
                        if (extension.toLowerCase() === 'jpeg') { extension = "jpg"; }
                        image.extension = extension.toUpperCase();

                        if (image.Filename.toLowerCase().endsWith('.csv')) {
                            image.extension = 'CSV';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.doc')) {
                            image.extension = 'DOC';
                            image.ThumbnailData = '../../Images/document_word.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.docx')) {
                            image.extension = 'DOCX';
                            image.ThumbnailData = '../../Images/document_word.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.pdf')) {
                            image.extension = 'PDF';
                            image.ThumbnailData = '../../Images/document_pdf.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.ppt')) {
                            image.extension = 'PPT';
                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.pptx')) {
                            image.extension = 'PPTX';
                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.txt')) {
                            image.extension = 'TXT';
                            image.ThumbnailData = '../../Images/document_text.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.xls')) {
                            image.extension = 'XLS';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                            image.extension = 'XLSX';
                            image.ThumbnailData = '../../Images/document_excel.png';
                        }

                        if (image.Filename.toLowerCase().endsWith('.zip')) {
                            image.extension = 'ZIP';
                            image.ThumbnailData = '../../Images/document_zip.png';
                        }

                        item.Receipts.push(image);
                    }

                });
            });

            //change payment type that is eliminated
            if (item.PaymentType === 2) { item.PaymentType = 1; }

            if (!$scope.includeRowsWithReceipts) {

                if (item.Receipts.length === 0) {
                    gridData.push(item);
                }

            }
            else {
                gridData.push(item);
            }
        });

        //console.log(gridData);     
                            

        return gridData;
    }

    //gets image icon for file type
    function getImageDatails(image) {

        var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
        image.url = url;

        var extension = image.Mimetype.replace('image/', '');
        if (extension.toLowerCase() == 'jpeg') { extension = "jpg"; }
        image.extension = extension.toUpperCase();


        if (image.Filename.toLowerCase().endsWith('.csv')) {
            image.extension = 'CSV';
            image.ThumbnailData = '../../Images/document_excel.png';
        }

        if (image.Filename.toLowerCase().endsWith('.doc')) {
            image.extension = 'DOC';
            image.ThumbnailData = '../../Images/document_word.png';
        }

        if (image.Filename.toLowerCase().endsWith('.docx')) {
            image.extension = 'DOCX';
            image.ThumbnailData = '../../Images/document_word.png';
        }

        if (image.Filename.toLowerCase().endsWith('.pdf')) {
            image.extension = 'PDF';
            image.ThumbnailData = '../../Images/document_pdf.png';
        }

        if (image.Filename.toLowerCase().endsWith('.ppt')) {
            image.extension = 'PPT';
            image.ThumbnailData = '../../Images/document_powerpoint.png';
        }

        if (image.Filename.toLowerCase().endsWith('.pptx')) {
            image.extension = 'PPTX';
            image.ThumbnailData = '../../Images/document_powerpoint.png';
        }

        if (image.Filename.toLowerCase().endsWith('.txt')) {
            image.extension = 'TXT';
            image.ThumbnailData = '../../Images/document_text.png';
        }

        if (image.Filename.toLowerCase().endsWith('.xls')) {
            image.extension = 'XLS';
            image.ThumbnailData = '../../Images/document_excel.png';
        }

        if (image.Filename.toLowerCase().endsWith('.xlsx')) {
            image.extension = 'XLSX';
            image.ThumbnailData = '../../Images/document_excel.png';
        }

        if (image.Filename.toLowerCase().endsWith('.zip')) {
            image.extension = 'ZIP';
            image.ThumbnailData = '../../Images/document_zip.png';
        }

        return image;
    }

    //creates data source object for reprt details
    function getDataSource() {

        var dataSource = {
            data: $scope.gridData,
            pageSize: 20,
            batch: false,
            schema: baseSchema
        };
        return dataSource;
    }

    //schema that is used when refreshing/recreating the grid
    var baseSchema = {
        model: {
            fields: {
                Id: { type: "number" },
                NewReceipts: { type: "object", editable: false },
                Date: { type: "date" },
                Description: { type: "string" },
                Function: { type: "string", validation: { required: true } },
                Amount: { type: "number", defaultValue: null, validation: {}, validation: { required: true } },
                Job: { type: "string" },
                Component: { type: "string" },
                PaymentType: { validation: { required: true }, defaultValue: 1 },
                Receipts: { type: "object", editable: false },
                Uploader: { type: "string", editable: false },
                ShowAllUploadedImages: { type: "boolean", defaultValue: false },
                CreatedBy: { type: "string", editable: false },
                IsImported: { type: "boolean", defaultValue: true }
            }
        }
    };

    //grid definition
    $scope.mainGridOptions = {
        dataSource: {
            data: $scope.gridData,
            pageSize: 20,
            batch: false,
            schema: {
                model: {
                    fields: {
                        Id: { type: "number" },
                        NewReceipts: { type: "object", editable: false },
                        Date: { type: "date" },
                        Description: { type: "string" },
                        Function: { type: "string", validation: { required: true } },
                        Amount: { type: "number", defaultValue: null, validation: {}, validation: { required: true } },
                        Job: { type: "string" },
                        Component: { type: "string" },
                        PaymentType: { validation: { required: true }, defaultValue: 1 },
                        Receipts: { type: "object", editable: false },
                        //Uploader: { type: "string", editable: false },
                        ShowAllUploadedImages: { type: "boolean", defaultValue: false },
                        CreatedBy: { type: "string", editable: false },
                        IsImported: { type: "boolean", defaultValue: true }
                    }
                }
            }
        },
        editable: {
            mode: "incell",
            confirmation: false
        },
        navigatable: true,
        selectable: "multiple, row",
        height: '100%',
        groupable: false,
        sortable: true,
        resizable: true,
        pageable: {
            refresh: false,
            info: true,
            pageSizes: false,
            previousNext: false,
            numeric: false,
            pageSize: 0,
            messages: {
                display: "{2} items"
            }
        },
        dataBound: function (e) {
            var rows = e.sender.tbody.children();
            for (var j = 0; j < rows.length; j++) {
                var row = $(rows[j]);
                row.kendoDropTarget({
                    drop: (e) => {
                        console.log("AP:" + $scope.approvedReport());
                        if ($scope.approvedReport() === false) {

                            var docId = $scope.selectedReceipt.replace('thumbnail_', '').replace('filename_', '');
                            var row = $scope.grid.dataItem(e.dropTarget[0]);
                            console.log(row);

                            var rowId = row.Id;
                            var newItemId = 0;
                            var newReceipt = {};

                            if (rowId === 0) {
                                $scope.grid.dataSource.data().forEach(function (row, index) {
                                    if (row.Id < newItemId) { newItemId = row.Id; }
                                });
                                newItemId = newItemId - 1;

                                $scope.grid.dataSource.data().forEach(function (row, index) {
                                    if (row.Id === 0) { row.Id = newItemId; row.Date = new Date(); }
                                });


                                newReceipt = { documentId: docId, rowId: newItemId, drId: docId + '|' + newItemId };
                                $scope.receiptsOnNewRows.push(newReceipt);

                                $scope.refreshGrid();
                                return;
                            }
                            else if (rowId < 0) {
                                newReceipt = { documentId: docId, rowId: rowId, drId: docId + '|' + rowId };
                                $scope.receiptsOnNewRows.push(newReceipt);

                                $scope.refreshGrid();
                                return;
                            }

                            expService.receiptToGrid(docId, rowId, $scope.invoiceNumber).then(function (result) {
                                expService.getReceiptsListUnassigned($scope.EmployeeCode.Code).then(function (resultReceipts) {
                                    $scope.allReceiptsUnassigned = resultReceipts.data;
                                    $scope.uploadedImages = resultReceipts.data;
                                    $scope.allReceiptsUnassigned.forEach(function (image, index) {
                                        if (image.Filename.toLowerCase().endsWith('.csv')) {
                                            image.extension = 'CSV';
                                            image.ThumbnailData = '../../Images/document_excel.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.doc')) {
                                            image.extension = 'DOC';
                                            image.ThumbnailData = '../../Images/document_word.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.docx')) {
                                            image.extension = 'DOCX';
                                            image.ThumbnailData = '../../Images/document_word.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.pdf')) {
                                            image.extension = 'PDF';
                                            image.ThumbnailData = '../../Images/document_pdf.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.ppt')) {
                                            image.extension = 'PPT';
                                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.pptx')) {
                                            image.extension = 'PPTX';
                                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.txt')) {
                                            image.extension = 'TXT';
                                            image.ThumbnailData = '../../Images/document_text.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.xls')) {
                                            image.extension = 'XLS';
                                            image.ThumbnailData = '../../Images/document_excel.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                                            image.extension = 'XLSX';
                                            image.ThumbnailData = '../../Images/document_excel.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.zip')) {
                                            image.extension = 'ZIP';
                                            image.ThumbnailData = '../../Images/document_zip.png';
                                        }
                                    });

                                    $(e.dropTarget[0]).removeClass("drag-drop-hover");
                                });
                                expService.getReceiptsList($scope.invoiceNumber).then(function (resultReceipts) {
                                    $scope.allReceipts = resultReceipts.data;
                                    $scope.uploadedImages = resultReceipts.data;
                                    $scope.allReceipts.forEach(function (image, index) {
                                        if (image.Filename.toLowerCase().endsWith('.csv')) {
                                            image.extension = 'CSV';
                                            image.ThumbnailData = '../../Images/document_excel.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.doc')) {
                                            image.extension = 'DOC';
                                            image.ThumbnailData = '../../Images/document_word.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.docx')) {
                                            image.extension = 'DOCX';
                                            image.ThumbnailData = '../../Images/document_word.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.pdf')) {
                                            image.extension = 'PDF';
                                            image.ThumbnailData = '../../Images/document_pdf.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.ppt')) {
                                            image.extension = 'PPT';
                                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.pptx')) {
                                            image.extension = 'PPTX';
                                            image.ThumbnailData = '../../Images/document_powerpoint.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.txt')) {
                                            image.extension = 'TXT';
                                            image.ThumbnailData = '../../Images/document_text.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.xls')) {
                                            image.extension = 'XLS';
                                            image.ThumbnailData = '../../Images/document_excel.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                                            image.extension = 'XLSX';
                                            image.ThumbnailData = '../../Images/document_excel.png';
                                        }

                                        if (image.Filename.toLowerCase().endsWith('.zip')) {
                                            image.extension = 'ZIP';
                                            image.ThumbnailData = '../../Images/document_zip.png';
                                        }
                                    });

                                    $(e.dropTarget[0]).removeClass("drag-drop-hover");
                                    $scope.refreshGrid();
                                });

                            });

                            console.log(e);
                            $(e.dropTarget[0]).removeClass("drag-drop-hover");
                            $scope.refreshGrid();

                        }
                    },
                    dragenter: function (e) {
                        $(e.dropTarget[0]).addClass("drag-drop-hover");
                        //console.log('entering',e);
                    },
                    dragleave: function (e) {
                        $(e.dropTarget[0]).removeClass("drag-drop-hover");
                        //console.log('leaving',e);
                    }
                });
            }
        },
        columns: [
            { title: "", width: 20, minResizableWidth: 20, template: "<span class='wvi wvi-more_vertical'></span>" },
            { field: "Date", title: "Date", format: "{0:MM/dd/yyyy}", width: 115, groupable: false, minResizableWidth: 115 },
            { field: "Description", title: "Description", groupable: false, width: 170, editor: descriptionEditor, minResizableWidth: 300 },
            { field: "Function", title: "Function", editor: functionMultiselectEditor, width: 220, template: functionCodeString, groupable: false, minResizableWidth: 220 },
            { field: "Amount", title: "Amount", format: '{0:n2}', groupable: false, width: 80, editor: amountEditor, minResizableWidth: 80 },
            { field: "Job", title: "Job", editor: jobMultiselectEditor, template: jobString, width: 250, minResizableWidth: 250 },
            { field: "Component", title: "Component", editor: jobcomponentMultiselectEditor, template: jobComponentString, width: 250, groupable: false, minResizableWidth: 250 },
            { field: "PaymentType", title: "Type", editor: paymentMultiselectEditor, template: paymentTypeString, width: 80, groupable: false, minResizableWidth: 80 },
            { field: "Receipts", title: "Receipts", template: newReceiptTemplate, width: 190, minResizableWidth: 190 }
        ],
        edit: function (e) {

            if ($scope.Custom2 === true && e.model["IsImported"] === true && e.model["CreatedBy"] !== $scope.UserCode) {

                this.closeCell();

            }            

            if ($scope.isLastPaymentSet == false) {
                e.model.set("PaymentType", $scope.lastPaymentType);
                $scope.isLastPaymentSet = true;
            }

            //functionms
            var functionComboBox = $("#functionms").data("kendoComboBox");
            if (functionComboBox) {
                if (e.model["Function"]) {
                    var inx = $scope.functionCodes.findIndex(function (funcode) {
                        return (e.model["Function"] == funcode.Code);
                    });

                    functionComboBox.select(inx);
                    functionComboBox.input.select();
                }
            }

            //when editing jobs field
            var jobsComboBox = $("#jobms").data("kendoComboBox");
            if (jobsComboBox) {

                var selectedClientCode = e.model["Client"];
                var selectedDivision = e.model["Division"];
                var selectedProduct = e.model["Product"];


                //if client is not selected or client is not visible
                if (selectedClientCode == null || selectedClientCode == '' || $scope.columnSettings.client == false) {

                    $scope.jobs = $scope.allJobs
                        .map(function (item) { return { Number: item.Number, Description: item.Number + ' - ' + item.JobDescription } })
                        .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);
                }
                else {
                    //var flagClient = true;
                    var flagProduct = true;
                    var flagDiv = true;

                    //if (selectedClientCode == null || selectedClientCode == '' || !$scope.columnSettings.client) { flagClient = false; }
                    if (selectedProduct == '' || selectedProduct == null || !$scope.columnSettings.product) { flagProduct = false; }
                    if (selectedDivision == '' || selectedDivision == null || !$scope.columnSettings.division) { flagDiv = false; flagProduct = false }



                    $scope.jobs = $scope.allJobs.filter((value, index, self) => ((value.ClientCode === selectedClientCode) && (!flagDiv || value.DivisionCode === selectedDivision) && (!flagProduct || value.ProductCode === selectedProduct)));
                    $scope.jobs = $scope.jobs
                        .map(function (item) { return { Number: item.Number, Description: item.Number + ' - ' + item.JobDescription } })
                        .filter((value, index, self) => self.findIndex(i => i.Number === value.Number) === index);
                }

                var ds = { data: $scope.jobs };
                jobsComboBox.setDataSource(ds);

                if (e.model["Job"]) {
                    var inx = $scope.jobs.findIndex(function (job) {
                        return (e.model["Job"] == job.Number);
                    });

                    jobsComboBox.refresh();
                    jobsComboBox.select(inx);
                    jobsComboBox.input.select();
                }


                var jobMs = e.container.find('.job');
                jobMs.change(function () {


                    var selectedJob = this.value;


                    if (selectedJob != jobsComboBox.value()) { return; }

                    if (this.value != 'undefined' && this.value != null && this.value != '') {


                        $scope.jobcomponents = $scope.allJobs.filter((value, index, self) => (value.Number == selectedJob));
                        $scope.jobcomponents = $scope.jobcomponents
                            .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description } })
                            .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index);



                        if ($scope.jobcomponents.length == 1) {

                            e.model.set("Component", $scope.jobcomponents[0].ID);
                        }
                        else {
                            //jc.value(null);
                            e.model.set("Component", '');
                        }

                        if (selectedJob && jobsComboBox.select() === -1) {
                            jobsComboBox.value('');
                        }

                    }
                    else if (this.value != 'undefined' && this.value == '') {

                        $scope.jobcomponents = [];

                        e.model.set("Component", '');

                    }
                });

            }

            //when editing job component field
            var jobComponentComboBox = $("#jobcomponentms").data("kendoComboBox");
            if (jobComponentComboBox) {

                var flagSetJob = false;
                var selectedJob = e.model["Job"];

                if (selectedJob == '' || selectedJob == null) {


                    var selectedClientCode = e.model["Client"];
                    var selectedDivision = e.model["Division"];
                    var selectedProduct = e.model["Product"];
                    var flagClient = true;
                    var flagProduct = true;
                    var flagDiv = true;

                    if (selectedProduct == '' || selectedProduct == null || !$scope.columnSettings.product) { flagProduct = false; }
                    if (selectedDivision == '' || selectedDivision == null || !$scope.columnSettings.division) { flagDiv = false; flagProduct = false }
                    if (selectedClientCode == null || selectedClientCode == '' || !$scope.columnSettings.client) { flagClient = false; flagDiv = false; flagProduct = false; }

                    $scope.jobcomponents = $scope.allJobs.filter((value, index, self) => (
                        (!flagClient || value.ClientCode === selectedClientCode) &&
                        (!flagDiv || value.DivisionCode === selectedDivision) &&
                        (!flagProduct || value.ProductCode === selectedProduct)));

                    $scope.jobcomponents = $scope.jobcomponents
                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description, Number: item.Number } })
                        .filter((value, index, self) => self.findIndex(i => i.ID === value.ID && i.Number === value.Number) === index)
                        .sort((a, b) => b.value - a.value);

                    flagSetJob = true;


                }
                else {
                    $scope.jobcomponents = $scope.allJobs.filter((value, index, self) => (value.Number == selectedJob));
                    $scope.jobcomponents = $scope.jobcomponents
                        .map(function (item) { return { ID: item.JobComponentNumber, Description: item.Description } })
                        .filter((value, index, self) => self.findIndex(i => i.ID === value.ID) === index)
                        .sort((a, b) => b.value - a.value);
                }


                var dsj = { data: $scope.jobcomponents };
                jobComponentComboBox.setDataSource(dsj);

                if (e.model["Component"]) {
                    var inx = $scope.jobcomponents.findIndex(function (cmp) {
                        return (e.model["Component"] == cmp.ID);
                    });

                    jobComponentComboBox.refresh();
                    jobComponentComboBox.select(inx);
                    jobComponentComboBox.input.select();
                }

                if (flagSetJob) {
                    jobComponentComboBox.bind("change", function (el) {

                        var res = this.text().split("/");
                        var jobValue = parseInt(res[0]);
                        e.model.set("Job", jobValue);

                    });
                }


            }

            var paymentComboBox = $('#paymentms').data("kendoComboBox");
            if (paymentComboBox) {
                paymentComboBox.bind("change", function (el) {
                    $scope.lastPaymentType = this.value();

                });
            }

            e.model.bind("change", function (j) {
                if ($scope.CanUpdate === false) {
                    $scope.saveCancelEnabled = false;
                } else {
                    $scope.saveCancelEnabled = true;
                }
                console.log('change');
                //$scope.checkDirtyRows();
            });

        },
        cancel: function (e) {

            $scope.grid.cancelChanges();
        },
        change: function (e) {

        },
        saveChanges: function (e) {

        },
        sort: function (e) {

            $scope.selectedRow = [];
        }
    };

    //checks if report is approved
    $scope.approvedReport = function () {

        if ($scope.status != "" && $scope.status != null) {
            if (parseInt($scope.status) >= 1) {

                return true;
            }
        }

        if ($scope.CanUpdate === false) {

            return true;

        }

        return false;
    };

    //grid editors

    //defines the editor that is shown in description column
    function descriptionEditor(container, options) {
 
        if (options.model.Id > 0) {
            $('<span>' + options.model.Description + '</span>').appendTo(container);
        }
        else {
            $('<input autocomplete="off" maxlength="600" type="text" class="k-input k-textbox" name="Description" data-bind="value:' + options.field + '"/>')
                .appendTo(container);
        }
       
    }

    //defines the editor that is shown in function column
    function functionMultiselectEditor(container, options) {
        if (options.model.Id > 0) {
            var funString = functionCodeString(options.model);
            $('<span>' + funString + '</span>').appendTo(container);
        }
        else {
            $('<select id="functionms" class="function" data-bind="value:' + options.field + '"/>')
                .appendTo(container)
                .kendoComboBox({
                    autoBind: false,
                    placeholder: "Select function...",
                    dataValueField: "Code",
                    dataTextField: "Description",
                    filter: "contains",

                    dataSource: { data: $scope.functionCodes },
                    valuePrimitive: true
                });
        }
    }

    //defines the editor that is shown in amount column
    function editNumberAmount(container, options) {
        if (options.model.Id > 0) {
            $('<span>' + options.model.Amount.toFixed(2) + '</span>').appendTo(container);
        }
        else {
            $('<input name="Amount" data-bind="value:' + options.field + '"/>')
                .appendTo(container)
                .kendoNumericTextBox({
                    spinners: false,
                    max: 999999999
                });
        }
    }

    function amountEditor(container, options) {
        if (options.model.Id > 0) {
            $('<span>' + options.model.Amount.toFixed(2) + '</span>').appendTo(container);
        }
        else {
            $('<input type="number" name="Amount" class="k-input k-textbox" data-bind="value:' + options.field + '"/>').appendTo(container);
        }
    }

    //defines the editor that is shown in jobs column
    function jobMultiselectEditor(container, options) {
        if (options.model.Id > 0) {
            var jobSpan = jobString(options.model);
            $('<span>' + jobSpan + '</span>').appendTo(container);
        }
        else {
            $('<select id="jobms" class="job" data-bind="value:' + options.field + '"/>')
                .appendTo(container)
                .kendoComboBox({
                    autoBind: false,
                    placeholder: "Select job...",
                    dataTextField: "Description",
                    dataValueField: "Number",

                    filter: "contains",
                    dataSource: { data: $scope.jobs },
                    valuePrimitive: true
                });
        }
    }

    //defines the editor that is shown in job component column
    function jobcomponentMultiselectEditor(container, options) {
        if (options.model.Id > 0) {
            var jobcSpan = jobComponentString(options.model);
            $('<span>' + jobcSpan + '</span>').appendTo(container);
        }
        else {
            $('<select id="jobcomponentms" class="jobcomponent" data-bind="value:' + options.field + '"/>')
                .appendTo(container)
                .kendoComboBox({
                    autoBind: false,
                    placeholder: "Select job component...",
                    dataTextField: "Description",
                    dataValueField: "ID",

                    filter: "contains",
                    dataSource: { data: $scope.jobcomponents },
                    valuePrimitive: true,
                    change: function (e) {
                        var widget = e.sender;
                        if (widget.value() && widget.select() === -1) {
                            widget.value(""); //reset widget
                        }
                    }
                });
        }
    }

    //defines the editor that is shown in payment column
    function paymentMultiselectEditor(container, options) {
        if (options.model.Id > 0) {
            var paymentSpan = paymentTypeString(options.model);
            $('<span>' + paymentSpan + '</span>').appendTo(container);
        }
        else {
            $('<select id="paymentms" class="paymentType" data-bind="value:' + options.field + '"/>')
                .appendTo(container)
                .kendoComboBox({
                    autoBind: false,
                    //placeholder: "Select payment type...",
                    dataValueField: "Value",
                    dataTextField: "Description",
                    filter: "contains",
                    template: "#: data.LongDescription #",
                    dataSource: { data: $scope.paymentTypes },
                    valuePrimitive: true
                });
        }
        $('#paymentms').data('kendoComboBox').list.width(180);
    }


    //grid field templates

    //shows selected function code descriptin in data grid cell
    function functionCodeString(item) {


        var resultCodeDesc = '';

        $scope.functionCodes.forEach(function (fc) {
            if (fc.Code == item.Function) {
                resultCodeDesc = fc.DescriptionOnly;
            }
        });
        return resultCodeDesc;
    }

    //shows selected job code descriptin in data grid cell
    function jobString(item) {


        if (item.Job == '' || item.Job == null) { return ''; }
        var job = $scope.allJobs.find(({ Number }) => Number == item.Job);
        if (job != null && job != 'undefined') {
            return job.Number + ' - ' + job.JobDescription;
        }
        else {
            return item.Job;
        }
    }

    //shows selected job component code descriptin in data grid cell
    function jobComponentString(item) {

        if (item.Component == '' || item.Component == null) { return ''; }

        var jobComponent = $scope.allJobs.find(({ Number, JobComponentNumber }) => Number == item.Job && JobComponentNumber == item.Component);
        if (jobComponent != null && jobComponent != 'undefined') {

            var tmp = jobComponent.Description.split('/');
            if (tmp.length == 2) {
                return tmp[1];
            }
            else {
                return jobComponent.Description;
            }


        }
        else {
            return item.Component;
        }
    }

    //shows selected payment descriptin in data grid cell
    function paymentTypeString(item) {

        if (item.Id == 0 && item.Receipts.length == 0) { return '' }

        var resultPaymentType = '';
        $scope.paymentTypes.forEach(function (pt) {

            if (item.PaymentType == pt.Value) {
               
                resultPaymentType = pt.Description;
            }
        });
        return resultPaymentType;
    }

    function newReceiptTemplate(item) {
        if (item.Id === null || item.Id === 0 || item.Receipts.length === 0) {
            return '';
        }
        
        var template = null;
        var result = '';

        if ($scope.showThumbnail) {
            template = kendo.template($("#thumbnailUploadFile").html());
            result = template(item);
            return result;
        } else {
            template = kendo.template($("#inlineUploadFile").html());
            //template = kendo.template($("#newInlineUploadFile").html());
            result = template(item);
            return result;
        }
    }


    //defines the cell that is shown in receipts column based on selected view
    function receiptTemplate(item) {
        var template = null;
        var result = '';
        if (item.Id == null || item.Id == 0 || item.Receipts.length == 0) { return ''; }


        if ($scope.showThumbnail) {
            template = kendo.template($("#thumbnailUploadFile").html());
        }
        else {
            template = kendo.template($("#inlineUploadFile").html());
        }
        
        //var data = item.Receipts[0];
        var data = { showAllUploadedImages: item.ShowAllUploadedImages, receipts: item.Receipts, receiptsCount: item.Receipts.length, rowId: item.Id };
        console.log(data);
        result = template(data);

        if (item.ShowAllUploadedImages) {

            for (i = 1; i < item.Receipts.length; i++) {
              
                if ($scope.showThumbnail) {
                    var tother = kendo.template($("#thumbnailUploadFileOther").html());

                    var d2 = item.Receipts[i];
                    d2.rowId = item.Id;
                    console.log(d2);
                    result += tother(d2);
                }
                else {
                    var tother = kendo.template($("#inlineUploadFileOthers").html());
                    var d2 = item.Receipts[i];
                    d2.rowId = item.Id;
                    result += tother(d2);
                }          
            }
        }

        
        return result;

    }

    //defines the cell that is shown in uploader column
    function uploaderTemplate(item) {
           
        if (item.Id == null || item.Id < 1) { return ''; }
        var template = null;
        template = kendo.template($("#uploadCellTemplate").html());
        var data = item.Id;
        var result = template(data);
        return result;
     
    }

    //defines the cell that is shown in column that user can drop receipts
    function dropReceiptTemplate(item) {

        var template = kendo.template($('#dropCellTemplate').html());
        var result = template(item.Id);

        return result;
    }


    //validates entered data in the grid (imported data)
    function validateGrid() {
        var valObject = { result: true, messages: [] };
        var messages = [];

        $scope.grid.dataSource.data().forEach(function (row, index) {

            if (row.Id != null && row.Id != 0) {

                if (row.Date == null || row.Date == '') {
                    messages.push('Error at row ' + (index + 1) + ': Date field is required');
                }
                else {
                    var r = Date.parse(row.Date).toString();
                    if (r == "NaN") { messages.push('Error at row ' + (index + 1) + ': Invalid date format.'); }
                }

                if (row.Description == null || row.Description == '') {
                    messages.push('Error at row ' + (index + 1) + ': Description field is required');
                }
                if (row.Amount == null || row.Amount == '') {
                    messages.push('Error at row ' + (index + 1) + ': Amount field is required');
                }
                else {
                    if (row.Amount == 0) { messages.push('Error at row ' + (index + 1) + ': Amount field is required.'); };
                }

                if (row.Function === null || row.Function === '') {
                    messages.push('Error at row ' + (index + 1) + ': Function field is required');
                }

                if (row.PaymentType === null || row.PaymentType === '') {
                    messages.push('Error at row ' + (index + 1) + ': Payment type field is required');
                }

                if (row.Job != null && row.Job != '') {
                    if (row.Component == '' || row.Component == null) {
                        messages.push('Error at row ' + (index + 1) + ': Job component is required when job is selected.');
                    }
                }
            }
        });
     
        if (messages.length > 0) {
            valObject.result = false;
            valObject.messages = messages;
        }

        return valObject;
    }

    //prepare for create/update records in expense report
    function prepareGridData() {

        $scope.newReportDetailsList = [];
        $scope.updateReportDetailsList = [];

        $scope.grid.dataSource.data().forEach(function (row, index) {

            var record = {};

            if (row.Id < 0) {               

                console.log(row);

                record.ID = null;
                record.InvoiceNumber = $scope.invoiceNumber;
                record.ItemDate = row.Date;
                record.Description = row.Description;
                record.FunctionCode = row.Function;
                record.Quantity = row.Quantity;
                record.Rate = row.Rate;
                record.Amount = row.Amount;

                record.PaymentType = row.PaymentType;

                if (row.Job !== null && row.Job !== '' && row.Job && row.Component !== null && row.Component !== '') {

                    record.JobNumber = row.Job;
                    record.JobComponentNumber = row.Component;

                    var findData = $scope.allJobs.filter((value, index, self) => (value.Number === row.Job));

                    if (row.Client === '' || row.Client === null) {
                        if (findData.length > 0) { record.ClientCode = findData[0].ClientCode; }
                    }
                    else {
                        //record.ClientCode = row.Client
                    }

                    if (row.Division === '' || row.Division === null) {
                        if (findData.length > 0) { record.DivisionCode = findData[0].DivisionCode; }
                    }
                    else {
                        //record.DivisionCode = row.Division
                    }

                    if (row.Product === '' || row.Product === null) {
                        if (findData.length > 0) { record.ProductCode = findData[0].ProductCode; }
                    }
                    else {
                        //record.ProductCode = row.Product
                    }
                }
                else {
                    //clean jobs

                    if (row.Job === '' || row.Job === null) {

                        record.JobNumber = null;
                        record.JobComponentNumber = null;
                        record.ClientCode = null;
                        record.DivisionCode = null;
                        record.ProductCode = null;
                    }
                }

                record.Receipts = row.Receipts;

                if (record.ID === null) {
                    $scope.newReportDetailsList.push(record);
                }
            } else {

                record.ID = row.Id;

                var findRecord = $scope.expenseReportDetails.filter((value, index, self) => (value.ID == row.Id));
                if (findRecord.length > 0) {
                    angular.copy(findRecord[0], record);
                }

                record.InvoiceNumber = $scope.invoiceNumber;
                record.ItemDate = row.Date;
                record.Description = row.Description;
                record.FunctionCode = row.Function;
                record.Quantity = row.Quantity;
                record.Rate = row.Rate;
                record.Amount = row.Amount;

                record.PaymentType = row.PaymentType;

                if (row.Job !== null && row.Job !== '' && row.Job && row.Component !== null && row.Component !== '') {

                    record.JobNumber = row.Job;
                    record.JobComponentNumber = row.Component;

                    var findDataOld = $scope.allJobs.filter((value, index, self) => (value.Number === row.Job));

                    if (row.Client === '' || row.Client === null) {
                        if (findDataOld.length > 0) { record.ClientCode = findDataOld[0].ClientCode; }
                    }
                    else {
                        //record.ClientCode = row.Client
                    }

                    if (row.Division === '' || row.Division === null) {
                        if (findDataOld.length > 0) { record.DivisionCode = findDataOld[0].DivisionCode; }
                    }
                    else {
                        //record.DivisionCode = row.Division
                    }

                    if (row.Product === '' || row.Product === null) {
                        if (findDataOld.length > 0) { record.ProductCode = findDataOld[0].ProductCode; }
                    }
                    else {
                        //record.ProductCode = row.Product
                    }
                }
                else {
                    //clean jobs

                    if (row.Job === '' || row.Job === null) {

                        record.JobNumber = null;
                        record.JobComponentNumber = null;
                        record.ClientCode = null;
                        record.DivisionCode = null;
                        record.ProductCode = null;
                    }
                }

                if (row.dirty) {
                    $scope.updateReportDetailsList.push(record);
                }

            }
            
        });
    }

    $scope.getDropZone = function () {
        if ($scope.showThumbnail) {
            return true;
        } else {
            return false;
        }
    };

    $scope.getDropZoneName = function () {        
        if ($scope.approvedReport() === false) {
            if ($scope.showThumbnail) {
                return 'dropZoneElement';
            } else {
                return 'dropZoneElementFilename';
            }
        }
       
    };

    $scope.MoveUnassignedToAssigned = function (e) {        
        //let $scope = getScope('UploadReceiptsController');
        let documentId = '';

        if (e.draggable.element[0]) {
            documentId = e.draggable.element[0].id.replace(/^\D+/g, '');

            let index = $scope.allReceiptsUnassigned.findIndex(function (document) {
                return document.DocumentId == documentId
            });

            expService.deleteReceiptUnassigned(documentId);


            //console.log($scope.allReceiptsUnassigned[index].Filename)
            //$.ajax({
            //    type: "POST",
            //    url: "DeleteReceiptUnassigned",
            //    data: documentId
            //});

            $scope.allReceipts.push($scope.allReceiptsUnassigned[index]);
            $scope.allReceiptsUnassigned.splice(index, 1);
            $scope.$apply()

            if ($scope.allReceiptsUnassigned.length == 0) {
                $("#panelbarUnassigned").hide();
            } else {
                $("#panelbarUnassigned").show();
            }
        }
    };

    $scope.getDropZoneNameUnassigned = function () {
        if ($scope.approvedReport() === false) {
            if ($scope.showThumbnail) {
                return 'dropZoneElementUnassigned';
            } else {
                return 'dropZoneElementFilenameUnassigned';
            }
        }
    };

    //handles "delete file" button click (receipt file)
    $scope.deleteFileClicked = function (documentId, rowId) {
        if (rowId < 0) {
            //just remove
            $scope.receiptsOnNewRows = $scope.receiptsOnNewRows.filter((value, index, self) => !(value.drId === documentId + '|' + rowId));
            $scope.refreshGrid();
            return;
        }

        expService.removeReceiptFromGrid(documentId, rowId).then(function (result) {
            expService.getReceiptsList($scope.invoiceNumber).then(function (receipts) {
                $scope.allReceipts = receipts.data;

                $scope.allReceipts.forEach(function (image, index) {
                    if (image.Filename.toLowerCase().endsWith('.csv')) {
                        image.extension = 'CSV';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.doc')) {
                        image.extension = 'DOC';
                        image.ThumbnailData = '../../Images/document_word.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.docx')) {
                        image.extension = 'DOCX';
                        image.ThumbnailData = '../../Images/document_word.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.pdf')) {
                        image.extension = 'PDF';
                        image.ThumbnailData = '../../Images/document_pdf.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.ppt')) {
                        image.extension = 'PPT';
                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.pptx')) {
                        image.extension = 'PPTX';
                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.txt')) {
                        image.extension = 'TXT';
                        image.ThumbnailData = '../../Images/document_text.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.xls')) {
                        image.extension = 'XLS';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                        image.extension = 'XLSX';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.zip')) {
                        image.extension = 'ZIP';
                        image.ThumbnailData = '../../Images/document_zip.png';
                    }
                });

                $scope.refreshGrid();
            });
        });
    };

    function myFunction(value, index, array) {
        return !(value.documentId === documentId && value.rowId === rowId);
    }

    //handles "dowload file" button click (receipt file)
    $scope.receiptDownloadClick = function (docid) {
        expService.downloadReceipt(docid).then(function (result) {
        });

    };

    //handles "delete file" button click (receipt file)
    $scope.deleteThumbnailClick = function (documentId) {
        //if (confirm('Are you sure you want to delete this receipt (you can\'t undo this operation)?')) {
            expService.deleteReceipt(documentId).then(function (result) {
                if (result && result.data) {
                    if (result.data.Success == true) {
                        expService.getReceiptsList($scope.invoiceNumber).then(function (receipts) {
                            $scope.allReceiptsUnassigned = receipts.data;
                            $scope.allReceiptsUnassigned.forEach(function (image, index) {
                                if (image.Filename.toLowerCase().endsWith('.csv')) {
                                    image.extension = 'CSV';
                                    image.ThumbnailData = '../../Images/document_excel.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.doc')) {
                                    image.extension = 'DOC';
                                    image.ThumbnailData = '../../Images/document_word.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.docx')) {
                                    image.extension = 'DOCX';
                                    image.ThumbnailData = '../../Images/document_word.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.pdf')) {
                                    image.extension = 'PDF';
                                    image.ThumbnailData = '../../Images/document_pdf.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.ppt')) {
                                    image.extension = 'PPT';
                                    image.ThumbnailData = '../../Images/document_powerpoint.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.pptx')) {
                                    image.extension = 'PPTX';
                                    image.ThumbnailData = '../../Images/document_powerpoint.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.txt')) {
                                    image.extension = 'TXT';
                                    image.ThumbnailData = '../../Images/document_text.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.xls')) {
                                    image.extension = 'XLS';
                                    image.ThumbnailData = '../../Images/document_excel.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                                    image.extension = 'XLSX';
                                    image.ThumbnailData = '../../Images/document_excel.png';
                                }
                                if (image.Filename.toLowerCase().endsWith('.zip')) {
                                    image.extension = 'ZIP';
                                    image.ThumbnailData = '../../Images/document_zip.png';
                                }
                            });
                            $scope.refreshGrid();
                        });
                    } else {
                        if (result.data.Message && result.data.Message != "") {
                            showKendoAlert("<strong>Delete failed:</strong>&nbsp;&nbsp;" + result.data.Message);
                        }
                    }
                }
            });
        //}
    };
    //handles "delete file" button click (receipt file)
    $scope.deleteHeaderThumbnailClick = function (documentId) {

        showKendoConfirm("Are you sure you want to delete this receipt from the expense report?")
            .done(function () {
                expService.deleteReceipt(documentId).then(function (result) {
                    if (result && result.data) {
                        if (result.data.Success == true) {
                            expService.getReceiptsList($scope.invoiceNumber).then(function (receipts) {
                                $scope.allReceipts = receipts.data;
                                $scope.allReceipts.forEach(function (image, index) {
                                    if (image.Filename.toLowerCase().endsWith('.csv')) {
                                        image.extension = 'CSV';
                                        image.ThumbnailData = '../../Images/document_excel.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.doc')) {
                                        image.extension = 'DOC';
                                        image.ThumbnailData = '../../Images/document_word.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.docx')) {
                                        image.extension = 'DOCX';
                                        image.ThumbnailData = '../../Images/document_word.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.pdf')) {
                                        image.extension = 'PDF';
                                        image.ThumbnailData = '../../Images/document_pdf.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.ppt')) {
                                        image.extension = 'PPT';
                                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.pptx')) {
                                        image.extension = 'PPTX';
                                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.txt')) {
                                        image.extension = 'TXT';
                                        image.ThumbnailData = '../../Images/document_text.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.xls')) {
                                        image.extension = 'XLS';
                                        image.ThumbnailData = '../../Images/document_excel.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                                        image.extension = 'XLSX';
                                        image.ThumbnailData = '../../Images/document_excel.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.zip')) {
                                        image.extension = 'ZIP';
                                        image.ThumbnailData = '../../Images/document_zip.png';
                                    }
                                });
                                $scope.refreshGrid();
                            });
                        } else {
                            if (result.data.Message && result.data.Message != "") {
                                showKendoAlert("<strong>Delete failed:</strong>&nbsp;&nbsp;" + result.data.Message);
                            }
                        }
                    }
                });
            })
            .fail(function () {
            });           
    };

    //handles "delete file" button click (receipt file)
    $scope.deleteHeaderThumbnailUnassignedClick = function (documentId) {

        showKendoConfirm("Are you sure you want to delete this receipt?")
            .done(function () {
                expService.deleteReceiptUnassigned(documentId).then(function (result) {
                    if (result && result.data) {
                        if (result.data.Success == true) {
                            expService.getReceiptsListUnassigned($scope.EmployeeCode.Code).then(function (receipts) {
                                $scope.allReceiptsUnassigned = receipts.data;
                                $scope.allReceiptsUnassigned.forEach(function (image, index) {
                                    if (image.Filename.toLowerCase().endsWith('.csv')) {
                                        image.extension = 'CSV';
                                        image.ThumbnailData = '../../Images/document_excel.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.doc')) {
                                        image.extension = 'DOC';
                                        image.ThumbnailData = '../../Images/document_word.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.docx')) {
                                        image.extension = 'DOCX';
                                        image.ThumbnailData = '../../Images/document_word.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.pdf')) {
                                        image.extension = 'PDF';
                                        image.ThumbnailData = '../../Images/document_pdf.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.ppt')) {
                                        image.extension = 'PPT';
                                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.pptx')) {
                                        image.extension = 'PPTX';
                                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.txt')) {
                                        image.extension = 'TXT';
                                        image.ThumbnailData = '../../Images/document_text.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.xls')) {
                                        image.extension = 'XLS';
                                        image.ThumbnailData = '../../Images/document_excel.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                                        image.extension = 'XLSX';
                                        image.ThumbnailData = '../../Images/document_excel.png';
                                    }
                                    if (image.Filename.toLowerCase().endsWith('.zip')) {
                                        image.extension = 'ZIP';
                                        image.ThumbnailData = '../../Images/document_zip.png';
                                    }
                                });
                                $scope.refreshGrid();
                            });
                        } else {
                            if (result.data.Message && result.data.Message != "") {
                                showKendoAlert("<strong>Delete failed:</strong>&nbsp;&nbsp;" + result.data.Message);
                            }
                        }
                    }
                });
            })
            .fail(function () {
            });
    };

    //toolbar functions
    //handles "save" button click 
    $scope.saveClick = function () {
        var res = validateGrid();

        if (!res.result) {
            var alertstring = '';
            res.messages.forEach(function (row, index) {
                alertstring += row + '\n';
            });
            showKendoAlert(alertstring);

            return;
        }

        var grid = $("#ExpenseReportsGrid").data("kendoGrid");
        grid.saveChanges();

        $scope.saveCancelEnabled = false;

        prepareGridData();

        if ($scope.updateReportDetailsList.length > 0) {
            expService.updateExpenseReportDetails($scope.updateReportDetailsList);
        }

        $scope.newReportDetailsList.forEach(item => {

            var receipts = [];
            angular.copy(item.Receipts, receipts);
            delete item.Receipts;

            var itemToSave = [];
            itemToSave.push(item);

            //save item
            expService.createExpenseReportDetails(itemToSave, false).then(function (result) {
                var savedItem = {};
                if (result.data.length > 0) {
                    savedItem = result.data[result.data.length - 1];

                    receipts.forEach(r => {

                        expService.receiptToGrid(r.DocumentId, savedItem.ID, $scope.invoiceNumber).then(function (result_two) {

                        });
                    });

                    setTimeout(function () {
                        closeUploadModalAndRefresh($scope.invoiceNumber);
                    }, 500);
                }
            });
        });

    };

    //handles "print receipts" button click - report header
    $scope.printReceipts = function () {


        var url = "Employee/ExpenseReports/PrintExpenseReport?InvoiceNumber=" + $scope.invoiceNumber + "&PrintSupervisorName=false&ExcludeEmployeeSignature=false&IncludeReceipts=true&IncludeReport=false&ExcludeSupervisorSignature=false";
        var reponseUrl = '';



        $.get(window.appBase + url, function (data) {

            reponseUrl = data;
        }).always(function (result) {

            reponseUrl = result;

            //window.location.href = reponseUrl;
            OpenRadWindow('Print Expense Report Receipts', reponseUrl);

        });
    };

    //handles "download receipts" button click - report header
    $scope.downloadReceipts = function () {
        var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=0&InvoiceNumber=" + $scope.invoiceNumber;
        var reponseUrl = '';

        window.location.href = url;
    };

    //counts uploaded images
    $scope.uploadedImagesCount = function () {

        if ($scope.CanPrint === false) {
            return false;
        }

        if ($scope.invoiceNumber == 0 || $scope.invoiceNumber == null || $scope.invoiceNumber == '') {
            return false;
        }
        else {
            if (parseInt($scope.uploadedImages.length) > 0) {

                return true;

            }

        }
        return false;

    };

    //handles "cancel" button click 
    $scope.cancelClick = function () {

        $scope.gridData = prepereDataForGrid(true);
        $scope.grid.setDataSource(getDataSource());

        setTimeout(function () {
            $scope.grid.dataSource.read();
            $scope.grid.refresh();

            $scope.$apply();

        }, 500);
    };

    //handles "include rows" button click 
    $scope.includeRowsClick = function () {
        $scope.includeRowsWithReceipts = !$scope.includeRowsWithReceipts;

        $scope.refreshGrid();

        expService.saveUploaderButtonStates($scope.includeRowsWithReceipts, $scope.showThumbnail, $scope.hideReceiptsApplied).then(function (result) {

        });
    };

    //handles "show thumbnail" button click 
    $scope.showThumbnailClick = function () {
        $scope.showThumbnail = !$scope.showThumbnail;
        
        expService.getReceiptsList($scope.invoiceNumber).then(function (resultReceipts) {
            $scope.allReceipts = resultReceipts.data;

            $scope.allReceipts.forEach(function (image, index) {

                var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                image.url = url;

                if (image.Filename.toLowerCase().endsWith('.csv')) {
                    image.extension = 'CSV';
                    image.ThumbnailData = '../../Images/document_excel.png';
                }

                if (image.Filename.toLowerCase().endsWith('.doc')) {
                    image.extension = 'DOC';
                    image.ThumbnailData = '../../Images/document_word.png';
                }

                if (image.Filename.toLowerCase().endsWith('.docx')) {
                    image.extension = 'DOCX';
                    image.ThumbnailData = '../../Images/document_word.png';
                }

                if (image.Filename.toLowerCase().endsWith('.pdf')) {
                    image.extension = 'PDF';
                    image.ThumbnailData = '../../Images/document_pdf.png';
                }

                if (image.Filename.toLowerCase().endsWith('.ppt')) {
                    image.extension = 'PPT';
                    image.ThumbnailData = '../../Images/document_powerpoint.png';
                }

                if (image.Filename.toLowerCase().endsWith('.pptx')) {
                    image.extension = 'PPTX';
                    image.ThumbnailData = '../../Images/document_powerpoint.png';
                }

                if (image.Filename.toLowerCase().endsWith('.txt')) {
                    image.extension = 'TXT';
                    image.ThumbnailData = '../../Images/document_text.png';
                }

                if (image.Filename.toLowerCase().endsWith('.xls')) {
                    image.extension = 'XLS';
                    image.ThumbnailData = '../../Images/document_excel.png';
                }

                if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                    image.extension = 'XLSX';
                    image.ThumbnailData = '../../Images/document_excel.png';
                }

                if (image.Filename.toLowerCase().endsWith('.zip')) {
                    image.extension = 'ZIP';
                    image.ThumbnailData = '../../Images/document_zip.png';
                }
            });
        });

        expService.getReceiptsListUnassigned($scope.EmployeeCode.Code).then(function (resultReceipts) {
            $scope.allReceiptsUnassigned = resultReceipts.data;

            $scope.allReceiptsUnassigned.forEach(function (image, index) {

                var url = window.appBase + "Employee/ExpenseReports/DownloadReceipt?DocumentID=" + image.DocumentId;
                image.url = url;

                if (image.Filename.toLowerCase().endsWith('.csv')) {
                    image.extension = 'CSV';
                    image.ThumbnailData = '../../Images/document_excel.png';
                }

                if (image.Filename.toLowerCase().endsWith('.doc')) {
                    image.extension = 'DOC';
                    image.ThumbnailData = '../../Images/document_word.png';
                }

                if (image.Filename.toLowerCase().endsWith('.docx')) {
                    image.extension = 'DOCX';
                    image.ThumbnailData = '../../Images/document_word.png';
                }

                if (image.Filename.toLowerCase().endsWith('.pdf')) {
                    image.extension = 'PDF';
                    image.ThumbnailData = '../../Images/document_pdf.png';
                }

                if (image.Filename.toLowerCase().endsWith('.ppt')) {
                    image.extension = 'PPT';
                    image.ThumbnailData = '../../Images/document_powerpoint.png';
                }

                if (image.Filename.toLowerCase().endsWith('.pptx')) {
                    image.extension = 'PPTX';
                    image.ThumbnailData = '../../Images/document_powerpoint.png';
                }

                if (image.Filename.toLowerCase().endsWith('.txt')) {
                    image.extension = 'TXT';
                    image.ThumbnailData = '../../Images/document_text.png';
                }

                if (image.Filename.toLowerCase().endsWith('.xls')) {
                    image.extension = 'XLS';
                    image.ThumbnailData = '../../Images/document_excel.png';
                }

                if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                    image.extension = 'XLSX';
                    image.ThumbnailData = '../../Images/document_excel.png';
                }

                if (image.Filename.toLowerCase().endsWith('.zip')) {
                    image.extension = 'ZIP';
                    image.ThumbnailData = '../../Images/document_zip.png';
                }
            });
        });


        $scope.refreshGrid();

        expService.saveUploaderButtonStates($scope.includeRowsWithReceipts, $scope.showThumbnail, $scope.hideReceiptsApplied).then(function (result) {

        });
    };

    //handles "hide applied receipts" button click 
    $scope.hideReceiptsAppliedClick = function () {
        $scope.hideReceiptsApplied = !$scope.hideReceiptsApplied;

        expService.saveUploaderButtonStates($scope.includeRowsWithReceipts, $scope.showThumbnail, $scope.hideReceiptsApplied).then(function (result) {

        });
    };

    $scope.printClick = function () {

    };

    $scope.ocrClick = function () { };

    //drag and drop functions

    //defines dragble element ()
    $scope.draggableHint = function (e) {
        var thumb = $("#" + e[0].id).clone();
        thumb[0].className += ' semi-transparent';

        $scope.selectedReceipt = e[0].id;

        return thumb;
    };

    $scope.onDragStart = function (e) {    
        
    };

    //$scope.onDropUnassigned = function () {       
    //    //NS: unable to get this to fire
    //};

    //handles drag end event
    $scope.onDragEnd = function (e) {               
        //$scope.allReceipts.push($scope.allReceiptsUnassigned[0]);

        var draggable = $("#" + e.currentTarget[0].id);

        if (!draggable.data("kendoDraggable").dropped) {
            $scope.selectedReceipt = null;
        }
    };


    //handles drag enter (in draggable zone) event
    $scope.onDragEnter = function (e) {
        $scope.$apply(function () {
            var dragTarget = $("#" + e.dropTarget[0].id);
            dragTarget.addClass("target-over");
        });
    };

    //handles drag enter (out of draggable zone) event
    $scope.onDragLeave = function (e) {

        $scope.$apply(function () {

            var dragTarget = $("#" + e.dropTarget[0].id);
            dragTarget.removeClass("target-over");
        });
    };

    //handles drop event
    $scope.onDrop = function (e) {        
        if ($scope.approvedReport() === false) {

            $scope.$apply(function () {

                var docId = $scope.selectedReceipt.replace('thumbnail_', '').replace('filename_', '');
                var rowId = e.dropTarget[0].id.replace('drop_', '');
                var newItemId = 0;
                var newReceipt = {};

                if (parseInt(rowId) === 0) {
                    $scope.grid.dataSource.data().forEach(function (row, index) {
                        if (row.Id < newItemId) { newItemId = row.Id; }
                    });
                    newItemId = newItemId - 1;

                    $scope.grid.dataSource.data().forEach(function (row, index) {
                        if (row.Id === 0) { row.Id = newItemId; row.Date = new Date(); }
                    });


                    newReceipt = { documentId: docId, rowId: newItemId, drId: docId + '|' + newItemId };
                    $scope.receiptsOnNewRows.push(newReceipt);

                    $scope.refreshGrid();
                    return;
                }
                else if (parseInt(rowId) < 0) {
                    newReceipt = { documentId: docId, rowId: rowId, drId: docId + '|' + rowId };
                    $scope.receiptsOnNewRows.push(newReceipt);

                    $scope.refreshGrid();
                    return;
                }


                expService.receiptToGrid(docId, rowId, $scope.invoiceNumber).then(function (result) {
                    expService.getReceiptsList($scope.invoiceNumber).then(function (resultReceipts) {
                        $scope.allReceipts = resultReceipts.data;

                        $scope.allReceipts.forEach(function (image, index) {
                            if (image.Filename.toLowerCase().endsWith('.csv')) {
                                image.extension = 'CSV';
                                image.ThumbnailData = '../../Images/document_excel.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.doc')) {
                                image.extension = 'DOC';
                                image.ThumbnailData = '../../Images/document_word.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.docx')) {
                                image.extension = 'DOCX';
                                image.ThumbnailData = '../../Images/document_word.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.pdf')) {
                                image.extension = 'PDF';
                                image.ThumbnailData = '../../Images/document_pdf.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.ppt')) {
                                image.extension = 'PPT';
                                image.ThumbnailData = '../../Images/document_powerpoint.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.pptx')) {
                                image.extension = 'PPTX';
                                image.ThumbnailData = '../../Images/document_powerpoint.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.txt')) {
                                image.extension = 'TXT';
                                image.ThumbnailData = '../../Images/document_text.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.xls')) {
                                image.extension = 'XLS';
                                image.ThumbnailData = '../../Images/document_excel.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                                image.extension = 'XLSX';
                                image.ThumbnailData = '../../Images/document_excel.png';
                            }

                            if (image.Filename.toLowerCase().endsWith('.zip')) {
                                image.extension = 'ZIP';
                                image.ThumbnailData = '../../Images/document_zip.png';
                            }
                        });

                        $scope.refreshGrid();
                    });
                });


                var dragTarget = $("#" + e.dropTarget[0].id);
                dragTarget.removeClass("target-over");
            });

        }
        
    };

    //refreshes grid (recreates data)
    $scope.refreshGrid = function () {

        $scope.gridData = prepereDataForGrid();
        $scope.grid.setDataSource(getDataSource());

        setTimeout(function () {
            $scope.grid.dataSource.read();
            $scope.grid.refresh();

            $scope.$apply();
 
        }, 500);

    };

    //handles "on receipt upload" - when user selects file for upload from cell
    $scope.onUpload = function (e) {
        var row = e.sender.element[0].attributes['rowid'].value;

        e.data =
        {
            InvoiceNumber: $scope.invoiceNumber,
            RowNumber: parseInt(row)
        };
    };

    //handles "on receipt upload" - when user selects file for upload 
    $scope.onUploadReportOnly = function (e) {
        e.data =
        {
            InvoiceNumber: $scope.invoiceNumber
        };
    };

    //handles "upload success" event - when upload finishes sucessfully
    $scope.onSuccess = function (e) {
        if (e.operation === "upload") {

            var err = $.parseJSON(e.XMLHttpRequest.responseText);
            if (err !== '') {
                showKendoAlert(err);
            }   

            $(".k-upload-files").remove();
            $(".k-upload-status").remove();
            $(".k-upload.k-header").addClass("k-upload-empty");

            expService.getReceiptsList($scope.invoiceNumber).then(function (resultReceipts) {
                $scope.allReceipts = resultReceipts.data;

                $scope.allReceipts.forEach(function (image, index) {
                    if (image.Filename.toLowerCase().endsWith('.csv')) {
                        image.extension = 'CSV';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.doc')) {
                        image.extension = 'DOC';
                        image.ThumbnailData = '../../Images/document_word.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.docx')) {
                        image.extension = 'DOCX';
                        image.ThumbnailData = '../../Images/document_word.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.pdf')) {
                        image.extension = 'PDF';
                        image.ThumbnailData = '../../Images/document_pdf.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.ppt')) {
                        image.extension = 'PPT';
                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.pptx')) {
                        image.extension = 'PPTX';
                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.txt')) {
                        image.extension = 'TXT';
                        image.ThumbnailData = '../../Images/document_text.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.xls')) {
                        image.extension = 'XLS';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                        image.extension = 'XLSX';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.zip')) {
                        image.extension = 'ZIP';
                        image.ThumbnailData = '../../Images/document_zip.png';
                    }
                });

                $scope.refreshGrid();
            });

            expService.getReceiptsListUnassigned($scope.EmployeeCode.Code).then(function (resultReceipts) {
                $scope.allReceiptsUnassigned = resultReceipts.data;

                $scope.allReceiptsUnassigned.forEach(function (image, index) {
                    if (image.Filename.toLowerCase().endsWith('.csv')) {
                        image.extension = 'CSV';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.doc')) {
                        image.extension = 'DOC';
                        image.ThumbnailData = '../../Images/document_word.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.docx')) {
                        image.extension = 'DOCX';
                        image.ThumbnailData = '../../Images/document_word.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.pdf')) {
                        image.extension = 'PDF';
                        image.ThumbnailData = '../../Images/document_pdf.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.ppt')) {
                        image.extension = 'PPT';
                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.pptx')) {
                        image.extension = 'PPTX';
                        image.ThumbnailData = '../../Images/document_powerpoint.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.txt')) {
                        image.extension = 'TXT';
                        image.ThumbnailData = '../../Images/document_text.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.xls')) {
                        image.extension = 'XLS';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.xlsx')) {
                        image.extension = 'XLSX';
                        image.ThumbnailData = '../../Images/document_excel.png';
                    }

                    if (image.Filename.toLowerCase().endsWith('.zip')) {
                        image.extension = 'ZIP';
                        image.ThumbnailData = '../../Images/document_zip.png';
                    }
                });

                $scope.refreshGrid();
            });

        }
    };

    //detect in wich row drop event occured
    $scope.getZone = function (rowId) {
        return '#dropDrownZone_' + rowId;
    };

    $scope.handleChange = function (data, dataItem, columns) {

        $scope.selectedRow = data;
    };
});

$(window).on("resize", function () {     
   
    //$("#uploadReceiptsDialog").ejDialog("refresh");
    //$('#uploadReceiptsDialog').attr('style', 'height: inherit');
    //$("#uploadReceiptsDialog").ejDialog("resize");

    //var wWidth = $(window).width();
    //var dWidth = wWidth * 0.9;
    //var wHeight = $(window).height();
    //var dHeight = wHeight * 0.9;
    //$("#uploadReceiptsDialog").dialog("option", "width", dWidth);
    //$("#uploadReceiptsDialog").dialog("option", "height", dHeight);

    //resizeGrid();


    $("#uploadwindow").kendoWindow("center");

}); 

function getScope(ctrlName) {
    var sel = 'div[ng-controller="' + ctrlName + '"]';
    return angular.element(sel).scope();
}


function resizeGrid() {
    var $scope = getScope('UploadReceiptsController');
    var grid = $("#ExpenseReportsGrid").data("kendoGrid");

    //for (var i = 0; i < grid.columns.length; i++) {
    //    grid.autoFitColumn(i);
    //}

    for (var i = 0; i < grid.columns.length; i++) {

        if (grid.columns[i].title !== "Job" && grid.columns[i].title !== "Component" && grid.columns[i].title !== "Description" && grid.columns[i].title !== "PaymentType") {
            grid.autoFitColumn(i);
        }
        
    }

    gridHeaderTable = grid.thead.parent(),
        gridBodyTable = grid.tbody.parent();

    if (gridBodyTable.width() < grid.wrapper.width() - kendo.support.scrollbar()) {

        gridHeaderTable.find("> colgroup > col").last().width("");
        gridBodyTable.find("> colgroup > col").last().width("");

        grid.columns[grid.columns.length - 1].width = "";

        // remove the Grid tables' pixel width
        gridHeaderTable.width("");
        gridBodyTable.width("");
    }
}
