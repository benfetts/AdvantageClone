
(function() {
    AdvantageMobile_UI.JobLogViewModel = function(data) {
				this.JobNumber = ko.observable();
				this.OfficeCode = ko.observable();
				this.ClientCode = ko.observable();
				this.DivisionCode = ko.observable();
				this.ProductCode = ko.observable();
				this.CampaignCode = ko.observable();
				this.SalesClassCode = ko.observable();
				this.USER_ID = ko.observable();
				this.CREATE_DATE = ko.observable();
				this.Description = ko.observable();
				this.JOB_DATE_OPENED = ko.observable();
				this.JOB_RUSH_CHARGES = ko.observable();
				this.JOB_ESTIMATE_REQ = ko.observable();
				this.Comments = ko.observable();
				this.JOB_CLI_REF = ko.observable();
				this.BILL_COOP_CODE = ko.observable();
				this.FORMAT_SC_CODE = ko.observable();
				this.FORMAT_CODE = ko.observable();
				this.COMPLEX_CODE = ko.observable();
				this.PROMO_CODE = ko.observable();
				this.CMP_IDENTIFIER = ko.observable();
				this.CMP_LINE_NBR = ko.observable();
				this.ROWID = ko.observable();
				this.JOB_BILL_COMMENT = ko.observable();
				this.FEE_JOB = ko.observable();
				this.UDV1_CODE = ko.observable();
				this.UDV2_CODE = ko.observable();
				this.UDV3_CODE = ko.observable();
				this.UDV4_CODE = ko.observable();
				this.UDV5_CODE = ko.observable();
				this.COMP_OPEN = ko.observable();
				this.LOCKED_USER = ko.observable();
				this.NP_COOP_SPLIT = ko.observable();
				this.JOB_COMMENTS_HTML = ko.observable();
				this.MODIFY_DATE = ko.observable();
				this.MODIFIED_BY = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.JobLogViewModel.prototype, {
        toJS: function() {
            return {
			JobNumber: this.JobNumber(),
			OfficeCode: this.OfficeCode(),
			ClientCode: this.ClientCode(),
			DivisionCode: this.DivisionCode(),
			ProductCode: this.ProductCode(),
			CampaignCode: this.CampaignCode(),
			SalesClassCode: this.SalesClassCode(),
			USER_ID: this.USER_ID(),
			CREATE_DATE: this.CREATE_DATE(),
			Description: this.Description(),
			JOB_DATE_OPENED: this.JOB_DATE_OPENED(),
			JOB_RUSH_CHARGES: this.JOB_RUSH_CHARGES(),
			JOB_ESTIMATE_REQ: this.JOB_ESTIMATE_REQ(),
			Comments: this.Comments(),
			JOB_CLI_REF: this.JOB_CLI_REF(),
			BILL_COOP_CODE: this.BILL_COOP_CODE(),
			FORMAT_SC_CODE: this.FORMAT_SC_CODE(),
			FORMAT_CODE: this.FORMAT_CODE(),
			COMPLEX_CODE: this.COMPLEX_CODE(),
			PROMO_CODE: this.PROMO_CODE(),
			CMP_IDENTIFIER: this.CMP_IDENTIFIER(),
			CMP_LINE_NBR: this.CMP_LINE_NBR(),
			ROWID: this.ROWID(),
			JOB_BILL_COMMENT: this.JOB_BILL_COMMENT(),
			FEE_JOB: this.FEE_JOB(),
			UDV1_CODE: this.UDV1_CODE(),
			UDV2_CODE: this.UDV2_CODE(),
			UDV3_CODE: this.UDV3_CODE(),
			UDV4_CODE: this.UDV4_CODE(),
			UDV5_CODE: this.UDV5_CODE(),
			COMP_OPEN: this.COMP_OPEN(),
			LOCKED_USER: this.LOCKED_USER(),
			NP_COOP_SPLIT: this.NP_COOP_SPLIT(),
			JOB_COMMENTS_HTML: this.JOB_COMMENTS_HTML(),
			MODIFY_DATE: this.MODIFY_DATE(),
			MODIFIED_BY: this.MODIFIED_BY(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.JobNumber(data.JobNumber);
				this.OfficeCode(data.OfficeCode);
				this.ClientCode(data.ClientCode);
				this.DivisionCode(data.DivisionCode);
				this.ProductCode(data.ProductCode);
				this.CampaignCode(data.CampaignCode);
				this.SalesClassCode(data.SalesClassCode);
				this.USER_ID(data.USER_ID);
				this.CREATE_DATE(data.CREATE_DATE);
				this.Description(data.Description);
				this.JOB_DATE_OPENED(data.JOB_DATE_OPENED);
				this.JOB_RUSH_CHARGES(data.JOB_RUSH_CHARGES);
				this.JOB_ESTIMATE_REQ(data.JOB_ESTIMATE_REQ);
				this.Comments(data.Comments);
				this.JOB_CLI_REF(data.JOB_CLI_REF);
				this.BILL_COOP_CODE(data.BILL_COOP_CODE);
				this.FORMAT_SC_CODE(data.FORMAT_SC_CODE);
				this.FORMAT_CODE(data.FORMAT_CODE);
				this.COMPLEX_CODE(data.COMPLEX_CODE);
				this.PROMO_CODE(data.PROMO_CODE);
				this.CMP_IDENTIFIER(data.CMP_IDENTIFIER);
				this.CMP_LINE_NBR(data.CMP_LINE_NBR);
				this.ROWID(data.ROWID);
				this.JOB_BILL_COMMENT(data.JOB_BILL_COMMENT);
				this.FEE_JOB(data.FEE_JOB);
				this.UDV1_CODE(data.UDV1_CODE);
				this.UDV2_CODE(data.UDV2_CODE);
				this.UDV3_CODE(data.UDV3_CODE);
				this.UDV4_CODE(data.UDV4_CODE);
				this.UDV5_CODE(data.UDV5_CODE);
				this.COMP_OPEN(data.COMP_OPEN);
				this.LOCKED_USER(data.LOCKED_USER);
				this.NP_COOP_SPLIT(data.NP_COOP_SPLIT);
				this.JOB_COMMENTS_HTML(data.JOB_COMMENTS_HTML);
				this.MODIFY_DATE(data.MODIFY_DATE);
				this.MODIFIED_BY(data.MODIFIED_BY);
		
            }
        }
    });
})();