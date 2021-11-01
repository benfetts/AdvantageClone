
(function() {
    AdvantageMobile_UI.JobTrafficViewModel = function(data) {
				this.JobNumber = ko.observable();
				this.JobComponentNumber = ko.observable();
				this.TrafficCode = ko.observable();
				this.TrafficPresetCode = ko.observable();
				this.Comments = ko.observable();
				this.Assign1EmployeeCode = ko.observable();
				this.Assign2EmployeeCode = ko.observable();
				this.Assign3EmployeeCode = ko.observable();
				this.Assign4EmployeeCode = ko.observable();
				this.Assign5EmployeeCode = ko.observable();
				this.DateCompleted = ko.observable();
				this.DateDelivered = ko.observable();
				this.DateShipped = ko.observable();
				this.ReceivedBy = ko.observable();
				this.Reference = ko.observable();
				this.ID = ko.observable();
				this.ManagerEmployeeCode = ko.observable();
				this.LOCK_USER = ko.observable();
				this.LOCKED_USER = ko.observable();
				this.PercentComplete = ko.observable();
				this.SCHEDULE_CALC = ko.observable();
				this.AUTO_UPDATE_STATUS = ko.observable();
				this.JOB_TRAFFIC_VER_ID = ko.observable();
				this.VERSION_LAST_APPLIED = ko.observable();
				this.IS_TEMPLATE = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.JobTrafficViewModel.prototype, {
        toJS: function() {
            return {
			JobNumber: this.JobNumber(),
			JobComponentNumber: this.JobComponentNumber(),
			TrafficCode: this.TrafficCode(),
			TrafficPresetCode: this.TrafficPresetCode(),
			Comments: this.Comments(),
			Assign1EmployeeCode: this.Assign1EmployeeCode(),
			Assign2EmployeeCode: this.Assign2EmployeeCode(),
			Assign3EmployeeCode: this.Assign3EmployeeCode(),
			Assign4EmployeeCode: this.Assign4EmployeeCode(),
			Assign5EmployeeCode: this.Assign5EmployeeCode(),
			DateCompleted: this.DateCompleted(),
			DateDelivered: this.DateDelivered(),
			DateShipped: this.DateShipped(),
			ReceivedBy: this.ReceivedBy(),
			Reference: this.Reference(),
			ID: this.ID(),
			ManagerEmployeeCode: this.ManagerEmployeeCode(),
			LOCK_USER: this.LOCK_USER(),
			LOCKED_USER: this.LOCKED_USER(),
			PercentComplete: String(this.PercentComplete() || 0),
			SCHEDULE_CALC: this.SCHEDULE_CALC(),
			AUTO_UPDATE_STATUS: this.AUTO_UPDATE_STATUS(),
			JOB_TRAFFIC_VER_ID: this.JOB_TRAFFIC_VER_ID(),
			VERSION_LAST_APPLIED: this.VERSION_LAST_APPLIED(),
			IS_TEMPLATE: this.IS_TEMPLATE(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.JobNumber(data.JobNumber);
				this.JobComponentNumber(data.JobComponentNumber);
				this.TrafficCode(data.TrafficCode);
				this.TrafficPresetCode(data.TrafficPresetCode);
				this.Comments(data.Comments);
				this.Assign1EmployeeCode(data.Assign1EmployeeCode);
				this.Assign2EmployeeCode(data.Assign2EmployeeCode);
				this.Assign3EmployeeCode(data.Assign3EmployeeCode);
				this.Assign4EmployeeCode(data.Assign4EmployeeCode);
				this.Assign5EmployeeCode(data.Assign5EmployeeCode);
				this.DateCompleted(data.DateCompleted);
				this.DateDelivered(data.DateDelivered);
				this.DateShipped(data.DateShipped);
				this.ReceivedBy(data.ReceivedBy);
				this.Reference(data.Reference);
				this.ID(data.ID);
				this.ManagerEmployeeCode(data.ManagerEmployeeCode);
				this.LOCK_USER(data.LOCK_USER);
				this.LOCKED_USER(data.LOCKED_USER);
				this.PercentComplete(data.PercentComplete);
				this.SCHEDULE_CALC(data.SCHEDULE_CALC);
				this.AUTO_UPDATE_STATUS(data.AUTO_UPDATE_STATUS);
				this.JOB_TRAFFIC_VER_ID(data.JOB_TRAFFIC_VER_ID);
				this.VERSION_LAST_APPLIED(data.VERSION_LAST_APPLIED);
				this.IS_TEMPLATE(data.IS_TEMPLATE);
		
            }
        }
    });
})();