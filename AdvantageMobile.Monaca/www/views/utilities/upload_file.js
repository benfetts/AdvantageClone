AdvantageMobile_UI.upload_file = function (params) {

    var values = ko.observableArray();
    var showUploadedFiles = ko.computed(
		function () {
		    return values().length > 0;
		}
	);
    var viewModel = {
        values: values,
        showUploadedFiles: showUploadedFiles,
    };

    return viewModel;
};