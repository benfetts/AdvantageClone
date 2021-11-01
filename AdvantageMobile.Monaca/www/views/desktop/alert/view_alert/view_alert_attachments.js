AdvantageMobile_UI.view_alert_attachments = function (params, viewInfo) {

    var alertId = ko.observable(0);

    var attachmentsList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetAlertAttachments', {
                    AlertID: alertId(),
                    filter: filterOptions,
                    sort: sortOptions,
                    skip: skip,
                    take: take
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
                return d.promise();
            },
            pageSize: 15
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        pullRefreshEnabled: true,
        paginate: true,
        pageLoadMode: "scrollBottom",
       onItemClick: attachmentClick
    };

    function viewShowing(e) {
        if (params.settings.alertId) {
            alertId(params.settings.alertId);
            attachmentsList.dataSource.load();
        };
    };
    function viewShown(e) {

    };
    function viewDisposing() {

    };
    function attachmentClick(e, itemData) {
        //AdvantageMobile_UI.Messages.notImplemented();
        ////alert(itemData.DocumentID);
        ////var store = cordova.file.dataDirectory;
        ////var filename = itemData.Filename;
        ////var assetURL = "http://STRAN-XPS/Webvantage66004/Documents_StreamFile.aspx?id=" + itemData.DocumentID;
        //////Check for the file. 
        ////alert(assetURL);
        ////alert(store + filename);
        ////window.resolveLocalFileSystemURL(store + fileName, fileExistsOrDownloadComplete, downloadAsset);

    };
    ////function fileExistsOrDownloadComplete() {
    ////    DevExpress.ui.dialog.alert("fileExistsOrDownloadComplete");
    ////};
    ////function downloadAsset() {
    ////    var fileTransfer = new FileTransfer();
    ////    DevExpress.ui.dialog.alert("About to start transfer");
    ////    fileTransfer.download(assetURL, store + fileName,
    ////        function (entry) {
    ////            DevExpress.ui.dialog.alert("Success!");
    ////            fileExistsOrDownloadComplete();
    ////        },
    ////        function (err) {
    ////            DevExpress.ui.dialog.alert("Error");
    ////            console.dir(err);
    ////        });
    ////};
    var viewModel = {
        viewShown: viewShown,
        viewShowing: viewShowing,
        viewDisposing: viewDisposing,
        alertId: alertId,
        attachmentsList: attachmentsList,
        attachmentClick: attachmentClick,
    };

    return viewModel;


};