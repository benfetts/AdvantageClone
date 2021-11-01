
(function() {
    AdvantageMobile_UI.FunctionViewModel = function(data) {
				this.Code = ko.observable();
				this.Name = ko.observable();
				this.FunctionType = ko.observable();
				this.DepartmentTeamCode = ko.observable();
				this.FNC_CONSOLIDATION = ko.observable();
				this.FNC_CPM_FLAG = ko.observable();
				this.FNC_ORDER = ko.observable();
				this.IsInactive = ko.observable();
				this.FNC_FEE_RECONCILE = ko.observable();
				this.FNC_HEADING_ID = ko.observable();
				this.EX_FLAG = ko.observable();
				this.NONBILL_CLI_GLACCT = ko.observable();
				this.OVERHEAD_GLACCT = ko.observable();
				this.FNC_FEE_FLAG = ko.observable();
				this.FNC_BILLING_RATE = ko.observable();
				this.TAX_COMM = ko.observable();
				this.TAX_COMM_ONLY = ko.observable();
				this.FNC_NONBILL_FLAG = ko.observable();
				this.FNC_TAX_FLAG = ko.observable();
				this.FNC_COMM_FLAG = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.FunctionViewModel.prototype, {
        toJS: function() {
            return {
			Code: this.Code(),
			Name: this.Name(),
			FunctionType: this.FunctionType(),
			DepartmentTeamCode: this.DepartmentTeamCode(),
			FNC_CONSOLIDATION: this.FNC_CONSOLIDATION(),
			FNC_CPM_FLAG: this.FNC_CPM_FLAG(),
			FNC_ORDER: this.FNC_ORDER(),
			IsInactive: this.IsInactive(),
			FNC_FEE_RECONCILE: this.FNC_FEE_RECONCILE(),
			FNC_HEADING_ID: this.FNC_HEADING_ID(),
			EX_FLAG: this.EX_FLAG(),
			NONBILL_CLI_GLACCT: this.NONBILL_CLI_GLACCT(),
			OVERHEAD_GLACCT: this.OVERHEAD_GLACCT(),
			FNC_FEE_FLAG: this.FNC_FEE_FLAG(),
			FNC_BILLING_RATE: String(this.FNC_BILLING_RATE() || 0),
			TAX_COMM: this.TAX_COMM(),
			TAX_COMM_ONLY: this.TAX_COMM_ONLY(),
			FNC_NONBILL_FLAG: this.FNC_NONBILL_FLAG(),
			FNC_TAX_FLAG: this.FNC_TAX_FLAG(),
			FNC_COMM_FLAG: this.FNC_COMM_FLAG(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.Code(data.Code);
				this.Name(data.Name);
				this.FunctionType(data.FunctionType);
				this.DepartmentTeamCode(data.DepartmentTeamCode);
				this.FNC_CONSOLIDATION(data.FNC_CONSOLIDATION);
				this.FNC_CPM_FLAG(data.FNC_CPM_FLAG);
				this.FNC_ORDER(data.FNC_ORDER);
				this.IsInactive(data.IsInactive);
				this.FNC_FEE_RECONCILE(data.FNC_FEE_RECONCILE);
				this.FNC_HEADING_ID(data.FNC_HEADING_ID);
				this.EX_FLAG(data.EX_FLAG);
				this.NONBILL_CLI_GLACCT(data.NONBILL_CLI_GLACCT);
				this.OVERHEAD_GLACCT(data.OVERHEAD_GLACCT);
				this.FNC_FEE_FLAG(data.FNC_FEE_FLAG);
				this.FNC_BILLING_RATE(data.FNC_BILLING_RATE);
				this.TAX_COMM(data.TAX_COMM);
				this.TAX_COMM_ONLY(data.TAX_COMM_ONLY);
				this.FNC_NONBILL_FLAG(data.FNC_NONBILL_FLAG);
				this.FNC_TAX_FLAG(data.FNC_TAX_FLAG);
				this.FNC_COMM_FLAG(data.FNC_COMM_FLAG);
		
            }
        }
    });
})();