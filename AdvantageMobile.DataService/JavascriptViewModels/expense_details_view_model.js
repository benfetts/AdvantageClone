
(function() {
    AdvantageMobile_UI.ExpenseDetailViewModel = function(data) {
				this.ID = ko.observable();
				this.InvoiceNumber = ko.observable();
				this.LineNumber = ko.observable();
				this.ItemDate = ko.observable();
				this.Description = ko.observable();
				this.CcFlag = ko.observable();
				this.ClientCode = ko.observable();
				this.DivisionCode = ko.observable();
				this.ProductCode = ko.observable();
				this.JobNumber = ko.observable();
				this.JobComponentNumber = ko.observable();
				this.FunctionCode = ko.observable();
				this.Quantity = ko.observable();
				this.Rate = ko.observable();
				this.CcAmount = ko.observable();
				this.Amount = ko.observable();
				this.ApComment = ko.observable();
				this.CreatedBy = ko.observable();
				this.ModifiedBy = ko.observable();
				this.ModifiedDate = ko.observable();
				this.PaymentType = ko.observable();
				this.IMPORTED = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ExpenseDetailViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			InvoiceNumber: this.InvoiceNumber(),
			LineNumber: this.LineNumber(),
			ItemDate: this.ItemDate(),
			Description: this.Description(),
			CcFlag: this.CcFlag(),
			ClientCode: this.ClientCode(),
			DivisionCode: this.DivisionCode(),
			ProductCode: this.ProductCode(),
			JobNumber: this.JobNumber(),
			JobComponentNumber: this.JobComponentNumber(),
			FunctionCode: this.FunctionCode(),
			Quantity: this.Quantity(),
			Rate: String(this.Rate() || 0),
			CcAmount: String(this.CcAmount() || 0),
			Amount: String(this.Amount() || 0),
			ApComment: this.ApComment(),
			CreatedBy: this.CreatedBy(),
			ModifiedBy: this.ModifiedBy(),
			ModifiedDate: this.ModifiedDate(),
			PaymentType: this.PaymentType(),
			IMPORTED: this.IMPORTED(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.InvoiceNumber(data.InvoiceNumber);
				this.LineNumber(data.LineNumber);
				this.ItemDate(data.ItemDate);
				this.Description(data.Description);
				this.CcFlag(data.CcFlag);
				this.ClientCode(data.ClientCode);
				this.DivisionCode(data.DivisionCode);
				this.ProductCode(data.ProductCode);
				this.JobNumber(data.JobNumber);
				this.JobComponentNumber(data.JobComponentNumber);
				this.FunctionCode(data.FunctionCode);
				this.Quantity(data.Quantity);
				this.Rate(data.Rate);
				this.CcAmount(data.CcAmount);
				this.Amount(data.Amount);
				this.ApComment(data.ApComment);
				this.CreatedBy(data.CreatedBy);
				this.ModifiedBy(data.ModifiedBy);
				this.ModifiedDate(data.ModifiedDate);
				this.PaymentType(data.PaymentType);
				this.IMPORTED(data.IMPORTED);
		
            }
        }
    });
})();