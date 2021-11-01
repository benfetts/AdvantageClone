
(function() {
    AdvantageMobile_UI.JobTrafficDetailEmployeeViewModel = function(data) {
				this.ID = ko.observable();
				this.JobNumber = ko.observable();
				this.JobComponentNumber = ko.observable();
				this.SequenceNumber = ko.observable();
				this.EmployeeCode = ko.observable();
				this.HourseAllowed = ko.observable();
				this.TempCompleteDate = ko.observable();
				this.CompletedComments = ko.observable();
				this.PercentComplete = ko.observable();
				this.CARD_SEQ_NBR = ko.observable();
				this.READ_ALERT = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.JobTrafficDetailEmployeeViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			JobNumber: this.JobNumber(),
			JobComponentNumber: this.JobComponentNumber(),
			SequenceNumber: this.SequenceNumber(),
			EmployeeCode: this.EmployeeCode(),
			HourseAllowed: String(this.HourseAllowed() || 0),
			TempCompleteDate: this.TempCompleteDate(),
			CompletedComments: this.CompletedComments(),
			PercentComplete: String(this.PercentComplete() || 0),
			CARD_SEQ_NBR: this.CARD_SEQ_NBR(),
			READ_ALERT: this.READ_ALERT(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.JobNumber(data.JobNumber);
				this.JobComponentNumber(data.JobComponentNumber);
				this.SequenceNumber(data.SequenceNumber);
				this.EmployeeCode(data.EmployeeCode);
				this.HourseAllowed(data.HourseAllowed);
				this.TempCompleteDate(data.TempCompleteDate);
				this.CompletedComments(data.CompletedComments);
				this.PercentComplete(data.PercentComplete);
				this.CARD_SEQ_NBR(data.CARD_SEQ_NBR);
				this.READ_ALERT(data.READ_ALERT);
		
            }
        }
    });
})();