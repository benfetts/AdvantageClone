
(function() {
    AdvantageMobile_UI.AlertCommentViewModel = function(data) {
				this.ID = ko.observable();
				this.AlertID = ko.observable();
				this.UserCode = ko.observable();
				this.GeneratedDate = ko.observable();
				this.Comment = ko.observable();
				this.IsEmailSent = ko.observable();
				this.ClientPortalUserID = ko.observable();
				this.AssignedEmployeeCode = ko.observable();
				this.DOCUMENT_LIST = ko.observable();
				this.ALRT_NOTIFY_HDR_ID = ko.observable();
				this.ALERT_STATE_ID = ko.observable();
				this.CS_PROJECT_ID = ko.observable();
				this.CS_REVIEW_ID = ko.observable();
				this.CS_COMMENT_ID = ko.observable();
				this.CS_REPLY_ID = ko.observable();
				this.PARENT_ID = ko.observable();
				this.CS_MARKUP_IMAGE = ko.observable();
				this.IS_DRAFT = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertCommentViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			AlertID: this.AlertID(),
			UserCode: this.UserCode(),
			GeneratedDate: this.GeneratedDate(),
			Comment: this.Comment(),
			IsEmailSent: this.IsEmailSent(),
			ClientPortalUserID: this.ClientPortalUserID(),
			AssignedEmployeeCode: this.AssignedEmployeeCode(),
			DOCUMENT_LIST: this.DOCUMENT_LIST(),
			ALRT_NOTIFY_HDR_ID: this.ALRT_NOTIFY_HDR_ID(),
			ALERT_STATE_ID: this.ALERT_STATE_ID(),
			CS_PROJECT_ID: this.CS_PROJECT_ID(),
			CS_REVIEW_ID: this.CS_REVIEW_ID(),
			CS_COMMENT_ID: this.CS_COMMENT_ID(),
			CS_REPLY_ID: this.CS_REPLY_ID(),
			PARENT_ID: this.PARENT_ID(),
			CS_MARKUP_IMAGE: this.CS_MARKUP_IMAGE(),
			IS_DRAFT: this.IS_DRAFT(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.AlertID(data.AlertID);
				this.UserCode(data.UserCode);
				this.GeneratedDate(data.GeneratedDate);
				this.Comment(data.Comment);
				this.IsEmailSent(data.IsEmailSent);
				this.ClientPortalUserID(data.ClientPortalUserID);
				this.AssignedEmployeeCode(data.AssignedEmployeeCode);
				this.DOCUMENT_LIST(data.DOCUMENT_LIST);
				this.ALRT_NOTIFY_HDR_ID(data.ALRT_NOTIFY_HDR_ID);
				this.ALERT_STATE_ID(data.ALERT_STATE_ID);
				this.CS_PROJECT_ID(data.CS_PROJECT_ID);
				this.CS_REVIEW_ID(data.CS_REVIEW_ID);
				this.CS_COMMENT_ID(data.CS_COMMENT_ID);
				this.CS_REPLY_ID(data.CS_REPLY_ID);
				this.PARENT_ID(data.PARENT_ID);
				this.CS_MARKUP_IMAGE(data.CS_MARKUP_IMAGE);
				this.IS_DRAFT(data.IS_DRAFT);
		
            }
        }
    });
})();