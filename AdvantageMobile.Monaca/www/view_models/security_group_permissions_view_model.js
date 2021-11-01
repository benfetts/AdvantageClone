
(function() {
    AdvantageMobile_UI.SecurityGroupPermissionViewModel = function(data) {
				this.ID = ko.observable();
				this.ApplicationID = ko.observable();
				this.ModuleID = ko.observable();
				this.ModuleCode = ko.observable();
				this.Module = ko.observable();
				this.ModuleIsCategory = ko.observable();
				this.ModuleInfoID = ko.observable();
				this.GroupID = ko.observable();
				this.GroupName = ko.observable();
				this.GroupDescription = ko.observable();
				this.IsBlocked = ko.observable();
				this.CanPrint = ko.observable();
				this.CanUpdate = ko.observable();
				this.CanAdd = ko.observable();
				this.Custom1 = ko.observable();
				this.Custom2 = ko.observable();
				this.ApplicationIsBlocked = ko.observable();
				this.ApplicationCanPrint = ko.observable();
				this.ApplicationCanUpdate = ko.observable();
				this.ApplicationCanAdd = ko.observable();
				this.ApplicationCustom1 = ko.observable();
				this.ApplicationCustom2 = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.SecurityGroupPermissionViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			ApplicationID: this.ApplicationID(),
			ModuleID: this.ModuleID(),
			ModuleCode: this.ModuleCode(),
			Module: this.Module(),
			ModuleIsCategory: this.ModuleIsCategory(),
			ModuleInfoID: this.ModuleInfoID(),
			GroupID: this.GroupID(),
			GroupName: this.GroupName(),
			GroupDescription: this.GroupDescription(),
			IsBlocked: this.IsBlocked(),
			CanPrint: this.CanPrint(),
			CanUpdate: this.CanUpdate(),
			CanAdd: this.CanAdd(),
			Custom1: this.Custom1(),
			Custom2: this.Custom2(),
			ApplicationIsBlocked: this.ApplicationIsBlocked(),
			ApplicationCanPrint: this.ApplicationCanPrint(),
			ApplicationCanUpdate: this.ApplicationCanUpdate(),
			ApplicationCanAdd: this.ApplicationCanAdd(),
			ApplicationCustom1: this.ApplicationCustom1(),
			ApplicationCustom2: this.ApplicationCustom2(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.ApplicationID(data.ApplicationID);
				this.ModuleID(data.ModuleID);
				this.ModuleCode(data.ModuleCode);
				this.Module(data.Module);
				this.ModuleIsCategory(data.ModuleIsCategory);
				this.ModuleInfoID(data.ModuleInfoID);
				this.GroupID(data.GroupID);
				this.GroupName(data.GroupName);
				this.GroupDescription(data.GroupDescription);
				this.IsBlocked(data.IsBlocked);
				this.CanPrint(data.CanPrint);
				this.CanUpdate(data.CanUpdate);
				this.CanAdd(data.CanAdd);
				this.Custom1(data.Custom1);
				this.Custom2(data.Custom2);
				this.ApplicationIsBlocked(data.ApplicationIsBlocked);
				this.ApplicationCanPrint(data.ApplicationCanPrint);
				this.ApplicationCanUpdate(data.ApplicationCanUpdate);
				this.ApplicationCanAdd(data.ApplicationCanAdd);
				this.ApplicationCustom1(data.ApplicationCustom1);
				this.ApplicationCustom2(data.ApplicationCustom2);
		
            }
        }
    });
})();