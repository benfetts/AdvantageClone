
(function() {
    AdvantageMobile_UI.SecurityUserSettingViewModel = function(data) {
				this.ID = ko.observable();
				this.SecurityUserID = ko.observable();
				this.SettingCode = ko.observable();
				this.StringValue = ko.observable();
				this.NumericValue = ko.observable();
				this.DateValue = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.SecurityUserSettingViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			SecurityUserID: this.SecurityUserID(),
			SettingCode: this.SettingCode(),
			StringValue: this.StringValue(),
			NumericValue: String(this.NumericValue() || 0),
			DateValue: this.DateValue(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.SecurityUserID(data.SecurityUserID);
				this.SettingCode(data.SettingCode);
				this.StringValue(data.StringValue);
				this.NumericValue(data.NumericValue);
				this.DateValue(data.DateValue);
		
            }
        }
    });
})();