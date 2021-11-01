
(function() {
    AdvantageMobile_UI.AlertGroupViewModel = function(data) {
				this.EmailGroupCode = ko.observable();
				this.AlertCategoryID = ko.observable();
				this.IsActive = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertGroupViewModel.prototype, {
        toJS: function() {
            return {
			EmailGroupCode: this.EmailGroupCode(),
			AlertCategoryID: this.AlertCategoryID(),
			IsActive: this.IsActive(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.EmailGroupCode(data.EmailGroupCode);
				this.AlertCategoryID(data.AlertCategoryID);
				this.IsActive(data.IsActive);
		
            }
        }
    });
})();