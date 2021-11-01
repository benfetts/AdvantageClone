
(function() {
    AdvantageMobile_UI.AlertAssignmentStateViewModel = function(data) {
				this.ID = ko.observable();
				this.Name = ko.observable();
				this.SortOrder = ko.observable();
				this.IsActive = ko.observable();
				this.DefaultAlertCategoryCode = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAssignmentStateViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			Name: this.Name(),
			SortOrder: this.SortOrder(),
			IsActive: this.IsActive(),
			DefaultAlertCategoryCode: this.DefaultAlertCategoryCode(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.Name(data.Name);
				this.SortOrder(data.SortOrder);
				this.IsActive(data.IsActive);
				this.DefaultAlertCategoryCode(data.DefaultAlertCategoryCode);
		
            }
        }
    });
})();