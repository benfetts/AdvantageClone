
(function() {
    AdvantageMobile_UI.ExpenseDetailDocumentViewModel = function(data) {
				this.DocumentID = ko.observable();
				this.ExpenseDetailID = ko.observable();
				this.ID = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ExpenseDetailDocumentViewModel.prototype, {
        toJS: function() {
            return {
			DocumentID: this.DocumentID(),
			ExpenseDetailID: this.ExpenseDetailID(),
			ID: this.ID(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.DocumentID(data.DocumentID);
				this.ExpenseDetailID(data.ExpenseDetailID);
				this.ID(data.ID);
		
            }
        }
    });
})();