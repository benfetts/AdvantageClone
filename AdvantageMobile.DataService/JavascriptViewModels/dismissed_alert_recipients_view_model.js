
(function() {
    AdvantageMobile_UI.DismissedAlertRecipientViewModel = function(data) {
				this.AlertID = ko.observable();
				this.ID = ko.observable();
				this.EmployeeCode = ko.observable();
				this.EmailAddress = ko.observable();
				this.ProcessedDate = ko.observable();
				this.IsNew = ko.observable();
				this.IsRead = ko.observable();
				this.DoNotAlertEmail = ko.observable();
				this.IsAssignee = ko.observable();
				this.CARD_SEQ_NBR = ko.observable();
				this.CS_IS_REVIEWER = ko.observable();
				this.IS_DELETED = ko.observable();
				this.ALRT_NOTIFY_HDR_ID = ko.observable();
				this.ALERT_STATE_ID = ko.observable();
				this.PERC_COMPLETE = ko.observable();
				this.COMPLETED_DATE = ko.observable();
				this.TEMP_COMP_DATE = ko.observable();
				this.HOURS_ALLOWED = ko.observable();
				this.LAST_ASSIGNED = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.DismissedAlertRecipientViewModel.prototype, {
        toJS: function() {
            return {
			AlertID: this.AlertID(),
			ID: this.ID(),
			EmployeeCode: this.EmployeeCode(),
			EmailAddress: this.EmailAddress(),
			ProcessedDate: this.ProcessedDate(),
			IsNew: this.IsNew(),
			IsRead: this.IsRead(),
			DoNotAlertEmail: this.DoNotAlertEmail(),
			IsAssignee: this.IsAssignee(),
			CARD_SEQ_NBR: this.CARD_SEQ_NBR(),
			CS_IS_REVIEWER: this.CS_IS_REVIEWER(),
			IS_DELETED: this.IS_DELETED(),
			ALRT_NOTIFY_HDR_ID: this.ALRT_NOTIFY_HDR_ID(),
			ALERT_STATE_ID: this.ALERT_STATE_ID(),
			PERC_COMPLETE: this.PERC_COMPLETE(),
			COMPLETED_DATE: this.COMPLETED_DATE(),
			TEMP_COMP_DATE: this.TEMP_COMP_DATE(),
			HOURS_ALLOWED: String(this.HOURS_ALLOWED() || 0),
			LAST_ASSIGNED: this.LAST_ASSIGNED(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.AlertID(data.AlertID);
				this.ID(data.ID);
				this.EmployeeCode(data.EmployeeCode);
				this.EmailAddress(data.EmailAddress);
				this.ProcessedDate(data.ProcessedDate);
				this.IsNew(data.IsNew);
				this.IsRead(data.IsRead);
				this.DoNotAlertEmail(data.DoNotAlertEmail);
				this.IsAssignee(data.IsAssignee);
				this.CARD_SEQ_NBR(data.CARD_SEQ_NBR);
				this.CS_IS_REVIEWER(data.CS_IS_REVIEWER);
				this.IS_DELETED(data.IS_DELETED);
				this.ALRT_NOTIFY_HDR_ID(data.ALRT_NOTIFY_HDR_ID);
				this.ALERT_STATE_ID(data.ALERT_STATE_ID);
				this.PERC_COMPLETE(data.PERC_COMPLETE);
				this.COMPLETED_DATE(data.COMPLETED_DATE);
				this.TEMP_COMP_DATE(data.TEMP_COMP_DATE);
				this.HOURS_ALLOWED(data.HOURS_ALLOWED);
				this.LAST_ASSIGNED(data.LAST_ASSIGNED);
		
            }
        }
    });
})();