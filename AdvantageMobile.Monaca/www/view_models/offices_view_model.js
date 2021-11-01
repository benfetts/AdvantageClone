
(function() {
    AdvantageMobile_UI.OfficeViewModel = function(data) {
				this.Code = ko.observable();
				this.Name = ko.observable();
				this.GLACODE_AR = ko.observable();
				this.GLACODE_AP = ko.observable();
				this.GLACODE_AP_DISC = ko.observable();
				this.PGLACODE_SALES = ko.observable();
				this.PGLACODE_COS = ko.observable();
				this.PGLACODE_WIP = ko.observable();
				this.PGLACODE_DEF_SALES = ko.observable();
				this.PGLACODE_DEF_COS = ko.observable();
				this.PGLACODE_ACC_COS = ko.observable();
				this.PGLACODE_ACC_AP = ko.observable();
				this.PGLACODE_ACC_TAX = ko.observable();
				this.MGLACODE_ACC_AP = ko.observable();
				this.MGLACODE_ACC_COS = ko.observable();
				this.MGLACODE_COS = ko.observable();
				this.MGLACODE_DEF_COS = ko.observable();
				this.MGLACODE_DEF_SALES = ko.observable();
				this.MGLACODE_SALES = ko.observable();
				this.MGLACODE_WIP = ko.observable();
				this.MGLACODE_ACC_TAX = ko.observable();
				this.GLACODE_SUSPENSE = ko.observable();
				this.GLACODE_STATE = ko.observable();
				this.GLACODE_COUNTY = ko.observable();
				this.GLACODE_CITY = ko.observable();
				this.PRD_AB_INCOME = ko.observable();
				this.MED_AB_INCOME = ko.observable();
				this.GLACODE_VOL_DISC = ko.observable();
				this.GLACODE_AP_WH = ko.observable();
				this.IsInactive = ko.observable();
				this.AVATAX_COMPANY_CODE = ko.observable();
				this.GLACODE_CRNCY_GAIN_LOSS = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.OfficeViewModel.prototype, {
        toJS: function() {
            return {
			Code: this.Code(),
			Name: this.Name(),
			GLACODE_AR: this.GLACODE_AR(),
			GLACODE_AP: this.GLACODE_AP(),
			GLACODE_AP_DISC: this.GLACODE_AP_DISC(),
			PGLACODE_SALES: this.PGLACODE_SALES(),
			PGLACODE_COS: this.PGLACODE_COS(),
			PGLACODE_WIP: this.PGLACODE_WIP(),
			PGLACODE_DEF_SALES: this.PGLACODE_DEF_SALES(),
			PGLACODE_DEF_COS: this.PGLACODE_DEF_COS(),
			PGLACODE_ACC_COS: this.PGLACODE_ACC_COS(),
			PGLACODE_ACC_AP: this.PGLACODE_ACC_AP(),
			PGLACODE_ACC_TAX: this.PGLACODE_ACC_TAX(),
			MGLACODE_ACC_AP: this.MGLACODE_ACC_AP(),
			MGLACODE_ACC_COS: this.MGLACODE_ACC_COS(),
			MGLACODE_COS: this.MGLACODE_COS(),
			MGLACODE_DEF_COS: this.MGLACODE_DEF_COS(),
			MGLACODE_DEF_SALES: this.MGLACODE_DEF_SALES(),
			MGLACODE_SALES: this.MGLACODE_SALES(),
			MGLACODE_WIP: this.MGLACODE_WIP(),
			MGLACODE_ACC_TAX: this.MGLACODE_ACC_TAX(),
			GLACODE_SUSPENSE: this.GLACODE_SUSPENSE(),
			GLACODE_STATE: this.GLACODE_STATE(),
			GLACODE_COUNTY: this.GLACODE_COUNTY(),
			GLACODE_CITY: this.GLACODE_CITY(),
			PRD_AB_INCOME: this.PRD_AB_INCOME(),
			MED_AB_INCOME: this.MED_AB_INCOME(),
			GLACODE_VOL_DISC: this.GLACODE_VOL_DISC(),
			GLACODE_AP_WH: this.GLACODE_AP_WH(),
			IsInactive: this.IsInactive(),
			AVATAX_COMPANY_CODE: this.AVATAX_COMPANY_CODE(),
			GLACODE_CRNCY_GAIN_LOSS: this.GLACODE_CRNCY_GAIN_LOSS(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.Code(data.Code);
				this.Name(data.Name);
				this.GLACODE_AR(data.GLACODE_AR);
				this.GLACODE_AP(data.GLACODE_AP);
				this.GLACODE_AP_DISC(data.GLACODE_AP_DISC);
				this.PGLACODE_SALES(data.PGLACODE_SALES);
				this.PGLACODE_COS(data.PGLACODE_COS);
				this.PGLACODE_WIP(data.PGLACODE_WIP);
				this.PGLACODE_DEF_SALES(data.PGLACODE_DEF_SALES);
				this.PGLACODE_DEF_COS(data.PGLACODE_DEF_COS);
				this.PGLACODE_ACC_COS(data.PGLACODE_ACC_COS);
				this.PGLACODE_ACC_AP(data.PGLACODE_ACC_AP);
				this.PGLACODE_ACC_TAX(data.PGLACODE_ACC_TAX);
				this.MGLACODE_ACC_AP(data.MGLACODE_ACC_AP);
				this.MGLACODE_ACC_COS(data.MGLACODE_ACC_COS);
				this.MGLACODE_COS(data.MGLACODE_COS);
				this.MGLACODE_DEF_COS(data.MGLACODE_DEF_COS);
				this.MGLACODE_DEF_SALES(data.MGLACODE_DEF_SALES);
				this.MGLACODE_SALES(data.MGLACODE_SALES);
				this.MGLACODE_WIP(data.MGLACODE_WIP);
				this.MGLACODE_ACC_TAX(data.MGLACODE_ACC_TAX);
				this.GLACODE_SUSPENSE(data.GLACODE_SUSPENSE);
				this.GLACODE_STATE(data.GLACODE_STATE);
				this.GLACODE_COUNTY(data.GLACODE_COUNTY);
				this.GLACODE_CITY(data.GLACODE_CITY);
				this.PRD_AB_INCOME(data.PRD_AB_INCOME);
				this.MED_AB_INCOME(data.MED_AB_INCOME);
				this.GLACODE_VOL_DISC(data.GLACODE_VOL_DISC);
				this.GLACODE_AP_WH(data.GLACODE_AP_WH);
				this.IsInactive(data.IsInactive);
				this.AVATAX_COMPANY_CODE(data.AVATAX_COMPANY_CODE);
				this.GLACODE_CRNCY_GAIN_LOSS(data.GLACODE_CRNCY_GAIN_LOSS);
		
            }
        }
    });
})();