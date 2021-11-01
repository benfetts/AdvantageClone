
(function() {
    AdvantageMobile_UI.JobTrafficDetailViewModel = function(data) {
				this.JobNumber = ko.observable();
				this.JobComponentNumber = ko.observable();
				this.SequenceNumber = ko.observable();
				this.FunctionCode = ko.observable();
				this.EstimateFunctionCode = ko.observable();
				this.Description = ko.observable();
				this.StartDate = ko.observable();
				this.DueDate = ko.observable();
				this.RevisedDate = ko.observable();
				this.IsDueDateLocked = ko.observable();
				this.CompletedDate = ko.observable();
				this.Order = ko.observable();
				this.Days = ko.observable();
				this.ParentJobTrafficDetailID = ko.observable();
				this.FunctionComments = ko.observable();
				this.DueDateComments = ko.observable();
				this.RevisedDateComments = ko.observable();
				this.Hours = ko.observable();
				this.DueTime = ko.observable();
				this.RevisedDueTime = ko.observable();
				this.TaskStatus = ko.observable();
				this.IsMilestone = ko.observable();
				this.TrafficPhaseID = ko.observable();
				this.ID = ko.observable();
				this.TEMP_SEQ = ko.observable();
				this.TRF_ROLE = ko.observable();
				this.HoursAssigned = ko.observable();
				this.EmployeeCode = ko.observable();
				this.TempCompleteDate = ko.observable();
				this.PARENT_TASK_SEQ = ko.observable();
				this.GRID_ORDER = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.JobTrafficDetailViewModel.prototype, {
        toJS: function() {
            return {
			JobNumber: this.JobNumber(),
			JobComponentNumber: this.JobComponentNumber(),
			SequenceNumber: this.SequenceNumber(),
			FunctionCode: this.FunctionCode(),
			EstimateFunctionCode: this.EstimateFunctionCode(),
			Description: this.Description(),
			StartDate: this.StartDate(),
			DueDate: this.DueDate(),
			RevisedDate: this.RevisedDate(),
			IsDueDateLocked: this.IsDueDateLocked(),
			CompletedDate: this.CompletedDate(),
			Order: this.Order(),
			Days: this.Days(),
			ParentJobTrafficDetailID: this.ParentJobTrafficDetailID(),
			FunctionComments: this.FunctionComments(),
			DueDateComments: this.DueDateComments(),
			RevisedDateComments: this.RevisedDateComments(),
			Hours: String(this.Hours() || 0),
			DueTime: this.DueTime(),
			RevisedDueTime: this.RevisedDueTime(),
			TaskStatus: this.TaskStatus(),
			IsMilestone: this.IsMilestone(),
			TrafficPhaseID: this.TrafficPhaseID(),
			ID: this.ID(),
			TEMP_SEQ: this.TEMP_SEQ(),
			TRF_ROLE: this.TRF_ROLE(),
			HoursAssigned: String(this.HoursAssigned() || 0),
			EmployeeCode: this.EmployeeCode(),
			TempCompleteDate: this.TempCompleteDate(),
			PARENT_TASK_SEQ: this.PARENT_TASK_SEQ(),
			GRID_ORDER: this.GRID_ORDER(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.JobNumber(data.JobNumber);
				this.JobComponentNumber(data.JobComponentNumber);
				this.SequenceNumber(data.SequenceNumber);
				this.FunctionCode(data.FunctionCode);
				this.EstimateFunctionCode(data.EstimateFunctionCode);
				this.Description(data.Description);
				this.StartDate(data.StartDate);
				this.DueDate(data.DueDate);
				this.RevisedDate(data.RevisedDate);
				this.IsDueDateLocked(data.IsDueDateLocked);
				this.CompletedDate(data.CompletedDate);
				this.Order(data.Order);
				this.Days(data.Days);
				this.ParentJobTrafficDetailID(data.ParentJobTrafficDetailID);
				this.FunctionComments(data.FunctionComments);
				this.DueDateComments(data.DueDateComments);
				this.RevisedDateComments(data.RevisedDateComments);
				this.Hours(data.Hours);
				this.DueTime(data.DueTime);
				this.RevisedDueTime(data.RevisedDueTime);
				this.TaskStatus(data.TaskStatus);
				this.IsMilestone(data.IsMilestone);
				this.TrafficPhaseID(data.TrafficPhaseID);
				this.ID(data.ID);
				this.TEMP_SEQ(data.TEMP_SEQ);
				this.TRF_ROLE(data.TRF_ROLE);
				this.HoursAssigned(data.HoursAssigned);
				this.EmployeeCode(data.EmployeeCode);
				this.TempCompleteDate(data.TempCompleteDate);
				this.PARENT_TASK_SEQ(data.PARENT_TASK_SEQ);
				this.GRID_ORDER(data.GRID_ORDER);
		
            }
        }
    });
})();