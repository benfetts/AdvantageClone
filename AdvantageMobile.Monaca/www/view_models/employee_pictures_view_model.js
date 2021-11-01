
(function() {
    AdvantageMobile_UI.EmployeePictureViewModel = function(data) {
				this.ID = ko.observable();
				this.EmployeeCode = ko.observable();
				this.EmployeeImage = ko.observable();
				this.EmployeeNickname = ko.observable();
				this.EmployeeWallpaper = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeePictureViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			EmployeeCode: this.EmployeeCode(),
			EmployeeImage: this.EmployeeImage(),
			EmployeeNickname: this.EmployeeNickname(),
			EmployeeWallpaper: this.EmployeeWallpaper(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.EmployeeCode(data.EmployeeCode);
				this.EmployeeImage(data.EmployeeImage);
				this.EmployeeNickname(data.EmployeeNickname);
				this.EmployeeWallpaper(data.EmployeeWallpaper);
		
            }
        }
    });
})();