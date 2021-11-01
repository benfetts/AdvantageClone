
(function() {
    AdvantageMobile_UI.SecurityUserViewModel = function(data) {
				this.ID = ko.observable();
				this.UserCode = ko.observable();
				this.UserName = ko.observable();
				this.EmployeeCode = ko.observable();
				this.CheckUserAccess = ko.observable();
				this.TimeHwnd = ko.observable();
				this.MenuHwnd = ko.observable();
				this.WebSessionID = ko.observable();
				this.IS_INACTIVE = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.SecurityUserViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			UserCode: this.UserCode(),
			UserName: this.UserName(),
			EmployeeCode: this.EmployeeCode(),
			CheckUserAccess: this.CheckUserAccess(),
			TimeHwnd: this.TimeHwnd(),
			MenuHwnd: this.MenuHwnd(),
			WebSessionID: this.WebSessionID(),
			IS_INACTIVE: this.IS_INACTIVE(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.UserCode(data.UserCode);
				this.UserName(data.UserName);
				this.EmployeeCode(data.EmployeeCode);
				this.CheckUserAccess(data.CheckUserAccess);
				this.TimeHwnd(data.TimeHwnd);
				this.MenuHwnd(data.MenuHwnd);
				this.WebSessionID(data.WebSessionID);
				this.IS_INACTIVE(data.IS_INACTIVE);
		
            }
        }
    });
})();