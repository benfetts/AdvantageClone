AdvantageMobile_UI.view_alert_comments = function (params, viewInfo) {

    var alertId = ko.observable(0);
    var isAssignment = ko.observable(false);
    var assignedEmployeeCode = ko.observable();
    var source = 0; // 0 = details, 1 = alert_list alert, 2 = alert_list assignment
    var commentsList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                if (alertId() == 0) {
                    alertId(params.settings.alertId);
                }
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                AdvantageMobile_UI.db.get('GetAlertComments', {
                    AlertID: alertId(),
                    Filter: filterOptions,
                    Sort: sortOptions,
                    Skip: skip,
                    Take: take
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
        onItemClick: loadComment
    };
    var commentsTextArea = {
        placeholder: "Comments",
        height: 175,
        value: ko.observable()
    };

    var addCommentPopUp = {
        height: "auto",
        visible: ko.observable(false),
        showTitle: true,
        title: "Add Comments",
        fullScreen: true
    };
    var saveButton = {
        text: localizeString("Save"),
        onClick: function (e) {
            if (commentsTextArea.value() == null || commentsTextArea.value() == ""){
                AdvantageMobile_UI.Messages.toastWarning("Please enter a comment");
                return;
            } else {
                var newComment = new AdvantageMobile_UI.AlertCommentViewModel();
                newComment.AlertID(alertId());
                newComment.UserCode(AdvantageMobile_UI.CurrentUser.UserCode());
                newComment.GeneratedDate(new Date());
                newComment.Comment(commentsTextArea.value());
                AdvantageMobile_UI.db.AlertComments.insert(newComment.toJS())
                    .done(function () {
                        commentsTextArea.value("");
                        showAddCommentPopUp();
                        commentsList.dataSource.load();
                        notifyAlertRecipients(alertId(), false, true);
                    })
                    .fail(function (data) {
                        handleDataServiceError(data);
                    });
            };
        }
    };
    var cancelButton = {
        text: localizeString("Cancel"),
        onClick: function (e) {
            addCommentPopUp.visible(false);
        }
    };

    var commentHeader = ko.observable("Test");
    var closeViewCommentButton = {
        text: localizeString("Close"),
        onClick: function (e) {
            viewCommentPopUp.visible(false);
        }
    };
    function notifyAlertRecipients(alertId, isNew, includeOriginator) {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('NotifiyAlertRecipients', {
            AlertID: alertId,
            IsNew: isNew,
            IncludeOriginator: includeOriginator,
        }).done(function (data) {
            d.resolve(data);
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        return d.promise();
    };

    function viewShowing(e) {
        if (params.settings) {
            if (params.settings.alertId) {
                alertId(params.settings.alertId);
                commentsList.dataSource.load();
            };
            if (params.settings.isAssignment) {
                isAssignment(params.settings.isAssignment);
            };
            if (params.settings.source) {

            };
        };
        commentsList.dataSource.load();
    };
    function viewShown(e) {

    };
    function viewDisposing() {

    };

    function showAddCommentPopUp() {
        addCommentPopUp.visible(!addCommentPopUp.visible());
    };
    function loadComment() {
        //load comment
        //viewCommentPopUp.visible(true);
    };

    var viewModel = {
        viewShown: viewShown,
        viewShowing: viewShowing,
        viewDisposing: viewDisposing,
        alertId: alertId,
        addCommentPopUp: addCommentPopUp,
        showAddCommentPopUp: showAddCommentPopUp,
        commentsTextArea: commentsTextArea,
        saveButton: saveButton,
        cancelButton: cancelButton,
        commentsList: commentsList,
        commentHeader: commentHeader,
        closeViewCommentButton: closeViewCommentButton,
    };

    return viewModel;

};