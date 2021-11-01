
(function() {
    AdvantageMobile_UI.EmployeeTimeCommentViewModel = function(data) {
				this.EmployeeTimeID = ko.observable();
				this.DetailID = ko.observable();
				this.SequenceNumber = ko.observable();
				this.Source = ko.observable();
				this.Comments = ko.observable();
				this.AdjusterComments = ko.observable();
				this.StartTime = ko.observable();
				this.EndTime = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeTimeCommentViewModel.prototype, {
        toJS: function() {
            return {
			EmployeeTimeID: this.EmployeeTimeID(),
			DetailID: this.DetailID(),
			SequenceNumber: this.SequenceNumber(),
			Source: this.Source(),
			Comments: this.Comments(),
			AdjusterComments: this.AdjusterComments(),
			StartTime: this.StartTime(),
			EndTime: this.EndTime(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.EmployeeTimeID(data.EmployeeTimeID);
				this.DetailID(data.DetailID);
				this.SequenceNumber(data.SequenceNumber);
				this.Source(data.Source);
				this.Comments(data.Comments);
				this.AdjusterComments(data.AdjusterComments);
				this.StartTime(data.StartTime);
				this.EndTime(data.EndTime);
		
            }
        }
    });
})();