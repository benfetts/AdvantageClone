
(function () {
	AdvantageMobile_UI.ExpenseReportOptionsViewModel = function (data) {
		this.InvoiceNumber = ko.observable();
		this.EmployeeCode = ko.observable();
		this.EmployeeFullName = ko.observable();
		this.EmployeeSupervisorApprovalRequired = ko.observable();
		this.SupervisorEmployeeCode = ko.observable();
		this.SupervisorEmployeeFullName = ko.observable();
		this.AlternateApproverEmployeeCode = ko.observable();
		this.AlternateApproverEmployeeFullName = ko.observable();
		//this.AvailableApprovers = ko.observable();
		this.IncludeReceiptsInEmailAndAlert = ko.observable();
		if (data)
			this.fromJS(data);
	};
	$.extend(AdvantageMobile_UI.ExpenseViewModel.prototype, {
		toJS: function () {
			return {
				InvoiceNumber: this.InvoiceNumber(),
				EmployeeCode: this.EmployeeCode(),
				EmployeeFullName: this.EmployeeFullName(),
				EmployeeSupervisorApprovalRequired: this.EmployeeSupervisorApprovalRequired(),
				SupervisorEmployeeCode: this.SupervisorEmployeeCode(),
				SupervisorEmployeeFullName: this.SupervisorEmployeeFullName(),
				AlternateApproverEmployeeCode: this.AlternateApproverEmployeeCode(),
				AlternateApproverEmployeeFullName: this.AlternateApproverEmployeeFullName(),
				//AvailableApprovers: this.AvailableApprovers(),
				IncludeReceiptsInEmailAndAlert: this.IncludeReceiptsInEmailAndAlert()
			};
		},
		fromJS: function (data) {
			if (data) {
				this.InvoiceNumber(data.InvoiceNumber);
				this.EmployeeCode(data.EmployeeCode);
				this.EmployeeFullName(data.EmployeeFullName);
				this.EmployeeSupervisorApprovalRequired(data.EmployeeSupervisorApprovalRequired);
				this.SupervisorEmployeeCode(data.SupervisorEmployeeCode);
				this.SupervisorEmployeeFullName(data.SupervisorEmployeeFullName);
				this.AlternateApproverEmployeeCode(data.AlternateApproverEmployeeCode);
				this.AlternateApproverEmployeeFullName(data.AlternateApproverEmployeeFullName);
				//this.AvailableApprovers(data.AvailableApprovers);
				this.IncludeReceiptsInEmailAndAlert(data.IncludeReceiptsInEmailAndAlert);
			}
		}
	});
})();