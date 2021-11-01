
(function() {
    AdvantageMobile_UI.ExpenseViewModel = function(data) {
				this.InvoiceNumber = ko.observable();
				this.EmployeeCode = ko.observable();
				this.VendorCode = ko.observable();
				this.InvoiceDate = ko.observable();
				this.Description = ko.observable();
				this.DetailsDescription = ko.observable();
				this.DateFrom = ko.observable();
				this.DateTo = ko.observable();
				this.InvoiceAmount = ko.observable();
				this.ApprovedBy = ko.observable();
				this.ApprovedDate = ko.observable();
				this.Status = ko.observable();
				this.ApprovalNotes = ko.observable();
				this.IsSubmitted = ko.observable();
				this.IsApproved = ko.observable();
				this.CreatedBy = ko.observable();
				this.CreatedDate = ko.observable();
				this.ModifiedBy = ko.observable();
				this.ModifiedDate = ko.observable();
				this.SubmittedTo = ko.observable();
				this.BatchDate = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ExpenseViewModel.prototype, {
        toJS: function() {
            return {
			InvoiceNumber: this.InvoiceNumber(),
			EmployeeCode: this.EmployeeCode(),
			VendorCode: this.VendorCode(),
			InvoiceDate: this.InvoiceDate(),
			Description: this.Description(),
			DetailsDescription: this.DetailsDescription(),
			DateFrom: this.DateFrom(),
			DateTo: this.DateTo(),
			InvoiceAmount: String(this.InvoiceAmount() || 0),
			ApprovedBy: this.ApprovedBy(),
			ApprovedDate: this.ApprovedDate(),
			Status: this.Status(),
			ApprovalNotes: this.ApprovalNotes(),
			IsSubmitted: this.IsSubmitted(),
			IsApproved: this.IsApproved(),
			CreatedBy: this.CreatedBy(),
			CreatedDate: this.CreatedDate(),
			ModifiedBy: this.ModifiedBy(),
			ModifiedDate: this.ModifiedDate(),
			SubmittedTo: this.SubmittedTo(),
			BatchDate: this.BatchDate(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.InvoiceNumber(data.InvoiceNumber);
				this.EmployeeCode(data.EmployeeCode);
				this.VendorCode(data.VendorCode);
				this.InvoiceDate(data.InvoiceDate);
				this.Description(data.Description);
				this.DetailsDescription(data.DetailsDescription);
				this.DateFrom(data.DateFrom);
				this.DateTo(data.DateTo);
				this.InvoiceAmount(data.InvoiceAmount);
				this.ApprovedBy(data.ApprovedBy);
				this.ApprovedDate(data.ApprovedDate);
				this.Status(data.Status);
				this.ApprovalNotes(data.ApprovalNotes);
				this.IsSubmitted(data.IsSubmitted);
				this.IsApproved(data.IsApproved);
				this.CreatedBy(data.CreatedBy);
				this.CreatedDate(data.CreatedDate);
				this.ModifiedBy(data.ModifiedBy);
				this.ModifiedDate(data.ModifiedDate);
				this.SubmittedTo(data.SubmittedTo);
				this.BatchDate(data.BatchDate);
		
            }
        }
    });
})();