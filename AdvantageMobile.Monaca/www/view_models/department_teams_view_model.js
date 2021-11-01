
(function() {
    AdvantageMobile_UI.DepartmentTeamViewModel = function(data) {
				this.Code = ko.observable();
				this.Name = ko.observable();
				this.IsInactive = ko.observable();
				this.DIRECT_HRS_PER_GOAL = ko.observable();
				this.CATEGORY = ko.observable();
				this.PO_APPR_RULE_CODE = ko.observable();
				this.SERVICE_FEE_TYPE_CODE = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.DepartmentTeamViewModel.prototype, {
        toJS: function() {
            return {
			Code: this.Code(),
			Name: this.Name(),
			IsInactive: this.IsInactive(),
			DIRECT_HRS_PER_GOAL: String(this.DIRECT_HRS_PER_GOAL() || 0),
			CATEGORY: this.CATEGORY(),
			PO_APPR_RULE_CODE: this.PO_APPR_RULE_CODE(),
			SERVICE_FEE_TYPE_CODE: this.SERVICE_FEE_TYPE_CODE(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.Code(data.Code);
				this.Name(data.Name);
				this.IsInactive(data.IsInactive);
				this.DIRECT_HRS_PER_GOAL(data.DIRECT_HRS_PER_GOAL);
				this.CATEGORY(data.CATEGORY);
				this.PO_APPR_RULE_CODE(data.PO_APPR_RULE_CODE);
				this.SERVICE_FEE_TYPE_CODE(data.SERVICE_FEE_TYPE_CODE);
		
            }
        }
    });
})();