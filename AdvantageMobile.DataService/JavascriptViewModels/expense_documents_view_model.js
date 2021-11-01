
(function() {
    AdvantageMobile_UI.ExpenseDocumentViewModel = function(data) {
				this.DocumentID = ko.observable();
				this.InvoiceNumber = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ExpenseDocumentViewModel.prototype, {
        toJS: function() {
            return {
			DocumentID: this.DocumentID(),
			InvoiceNumber: this.InvoiceNumber(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.DocumentID(data.DocumentID);
				this.InvoiceNumber(data.InvoiceNumber);
		
            }
        }
    });
})();