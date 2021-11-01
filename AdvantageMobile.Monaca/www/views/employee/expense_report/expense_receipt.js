AdvantageMobile_UI.expense_receipt = function (params, viewInfo) {

    var uploadContainerVisible = false;
    var loadPanelVisible = ko.observable(false);
    var loadPanelMessage = localizeString('Loading');
    var scrollView = {
        //pullDownAction: setUploadContainerVisible
        onPullDown: function (options) {
            setUploadContainerVisible();
            options.component.release();
        }
   };

    function onPhotoDataSuccess(imageData) {
        var uploadImage = $('#uploadImage');
        uploadImage.attr('src', 'data:image/jpeg;base64,' + imageData);
        $('#uploadContainer').css('display', 'block');
    };
    function onPhotoURISuccess(imageURI) {
        var uploadImage = $('#uploadImage');
        uploadImage.attr('src', imageURI);
        $('#uploadContainer').css('display', 'block');
    };
    function onFail(message) {
        AdvantageMobile_UI.Messages.toastSuccess("Failed because: " + message);
    };
    function getPhoto(source) {
        navigator.camera.getPicture(onPhotoURISuccess, onFail, {
            quality: 100,
            destinationType: AdvantageMobile_UI.destinationType.FILE_URI,
            sourceType: source
        });
    };
    function setUploadContainerVisible() {
        if (uploadContainerVisible == true) {
            $('#uploadContainer').css('display', 'none');
            uploadContainerVisible = false;
        } else {
            $('#uploadContainer').css('display', 'block');
            uploadContainerVisible = true;
        };
    };
    function uploadToLastExpense() {
        loadPanelVisible(true);
        window.setTimeout(function () {
            loadPanelVisible(false);
            AdvantageMobile_UI.Messages.toastSuccess("Uploaded to latest expense report");
        }, 2500);
    };
    function viewShowing() {

    };

    var viewModel = {
        viewShowing: viewShowing,
        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,
        scrollView: scrollView,
        capturePhoto: function (e) {
            navigator.camera.getPicture(onPhotoDataSuccess, onFail, {
                quality: 100,
                destinationType: AdvantageMobile_UI.destinationType.DATA_URL
            });
        },
        capturePhotoEdit: function (e) {
            navigator.camera.getPicture(onPhotoDataSuccess, onFail, {
                quality: 100,
                allowEdit: true,
                destinationType: AdvantageMobile_UI.destinationType.DATA_URL
            });
        },
        photoLibrary: function (e) {
            getPhoto(AdvantageMobile_UI.pictureSource.PHOTOLIBRARY);
        },
        photoAlbum: function (e) {
            getPhoto(AdvantageMobile_UI.pictureSource.SAVEDPHOTOALBUM);
        },
        setUploadContainerVisible: setUploadContainerVisible,
        uploadToLastExpense: uploadToLastExpense,

    };

    return viewModel;

};