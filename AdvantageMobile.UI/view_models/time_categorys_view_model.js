
(function() {
    AdvantageMobile_UI.TimeCategoryViewModel = function(data) {
				this.Code = ko.observable();
				this.Description = ko.observable();
				this.TimeCategoryTypeID = ko.observable();
				this.IsInactive = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.TimeCategoryViewModel.prototype, {
        toJS: function() {
            return {
			Code: this.Code(),
			Description: this.Description(),
			TimeCategoryTypeID: this.TimeCategoryTypeID(),
			IsInactive: this.IsInactive(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.Code(data.Code);
				this.Description(data.Description);
				this.TimeCategoryTypeID(data.TimeCategoryTypeID);
				this.IsInactive(data.IsInactive);
		
            }
        }
    });
})();