
(function() {
    AdvantageMobile_UI.AlertAttachmentViewModel = function(data) {
				this.ID = ko.observable();
				this.AlertID = ko.observable();
				this.UserCode = ko.observable();
				this.GeneratedDate = ko.observable();
				this.EmailSent = ko.observable();
				this.DocumentID = ko.observable();
				this.ClientPortalUserID = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAttachmentViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			AlertID: this.AlertID(),
			UserCode: this.UserCode(),
			GeneratedDate: this.GeneratedDate(),
			EmailSent: this.EmailSent(),
			DocumentID: this.DocumentID(),
			ClientPortalUserID: this.ClientPortalUserID(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.AlertID(data.AlertID);
				this.UserCode(data.UserCode);
				this.GeneratedDate(data.GeneratedDate);
				this.EmailSent(data.EmailSent);
				this.DocumentID(data.DocumentID);
				this.ClientPortalUserID(data.ClientPortalUserID);
		
            }
        }
    });
})();