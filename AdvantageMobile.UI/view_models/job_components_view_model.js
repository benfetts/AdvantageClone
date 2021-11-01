
(function() {
    AdvantageMobile_UI.JobComponentViewModel = function(data) {
				this.JobNumber = ko.observable();
				this.JobComponentNumber = ko.observable();
				this.JOB_BILL_HOLD = ko.observable();
				this.EMP_CODE = ko.observable();
				this.JOB_COMP_DATE = ko.observable();
				this.JOB_FIRST_USE_DATE = ko.observable();
				this.START_DATE = ko.observable();
				this.JOB_AD_SIZE = ko.observable();
				this.JOB_SPEC_TYPE = ko.observable();
				this.DepartmentTeamCode = ko.observable();
				this.JOB_MARKUP_PCT = ko.observable();
				this.CREATIVE_INSTR = ko.observable();
				this.JOB_LAYOUT_THUMB = ko.observable();
				this.JOB_LAYOUT_ROUGH = ko.observable();
				this.JOB_LAYOUT_COMP = ko.observable();
				this.JOB_LAYOUT_NONE = ko.observable();
				this.JOB_LAYOUT_SPECIAL = ko.observable();
				this.JOB_LAYOUT_SPC_EXP = ko.observable();
				this.ProcessControl = ko.observable();
				this.Description = ko.observable();
				this.JOB_COMP_COMMENTS = ko.observable();
				this.JOB_COMP_BUDGET_AM = ko.observable();
				this.ESTIMATE_NUMBER = ko.observable();
				this.EST_COMPONENT_NBR = ko.observable();
				this.BILLING_USER = ko.observable();
				this.AB_FLAG = ko.observable();
				this.JOB_DEL_INSTRUCT = ko.observable();
				this.JT_CODE = ko.observable();
				this.TAX_FLAG = ko.observable();
				this.TAX_CODE = ko.observable();
				this.NOBILL_FLAG = ko.observable();
				this.EMAIL_GR_CODE = ko.observable();
				this.AD_NBR = ko.observable();
				this.ACCT_NBR = ko.observable();
				this.PRD_AB_INCOME = ko.observable();
				this.MARKET_CODE = ko.observable();
				this.SERVICE_FEE_FLAG = ko.observable();
				this.ARCHIVE_FLAG = ko.observable();
				this.ROWID = ko.observable();
				this.ADJUST_USER = ko.observable();
				this.TRF_SCHEDULE_BY = ko.observable();
				this.TRF_SCHEDULE_REQ = ko.observable();
				this.JOB_CL_PO_NBR = ko.observable();
				this.UDV1_CODE = ko.observable();
				this.UDV2_CODE = ko.observable();
				this.UDV3_CODE = ko.observable();
				this.UDV4_CODE = ko.observable();
				this.UDV5_CODE = ko.observable();
				this.JOB_TMPLT_CODE = ko.observable();
				this.FEE_TIME = ko.observable();
				this.FISCAL_PERIOD_CODE = ko.observable();
				this.JOB_QTY = ko.observable();
				this.BLACKPLT_VER_CODE = ko.observable();
				this.BLACKPLT_VER_DESC = ko.observable();
				this.BLACKPLT_VER2_CODE = ko.observable();
				this.BLACKPLT_VER2_DESC = ko.observable();
				this.CDP_CONTACT_ID = ko.observable();
				this.PRD_CONT_CODE = ko.observable();
				this.BA_BATCH_ID = ko.observable();
				this.SELECTED_BA_ID = ko.observable();
				this.BCC_ID = ko.observable();
				this.ALRT_NOTIFY_HDR_ID = ko.observable();
				this.SERVICE_FEE_TYPE_ID = ko.observable();
				this.MEDIA_BILL_DATE = ko.observable();
				this.CS_PROJECT_ID = ko.observable();
				this.JC_COMMENTS_HTML = ko.observable();
				this.CREATIVE_INSTR_HTML = ko.observable();
				this.JOB_DEL_INSTR_HTML = ko.observable();
				this.TRF_JOB_NUMBER = ko.observable();
				this.TRF_JOB_COMPONENT_NBR = ko.observable();
				this.CLIENT_DISCOUNT_CODE = ko.observable();
				this.MODIFY_DATE = ko.observable();
				this.MODIFIED_BY = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.JobComponentViewModel.prototype, {
        toJS: function() {
            return {
			JobNumber: this.JobNumber(),
			JobComponentNumber: this.JobComponentNumber(),
			JOB_BILL_HOLD: this.JOB_BILL_HOLD(),
			EMP_CODE: this.EMP_CODE(),
			JOB_COMP_DATE: this.JOB_COMP_DATE(),
			JOB_FIRST_USE_DATE: this.JOB_FIRST_USE_DATE(),
			START_DATE: this.START_DATE(),
			JOB_AD_SIZE: this.JOB_AD_SIZE(),
			JOB_SPEC_TYPE: this.JOB_SPEC_TYPE(),
			DepartmentTeamCode: this.DepartmentTeamCode(),
			JOB_MARKUP_PCT: String(this.JOB_MARKUP_PCT() || 0),
			CREATIVE_INSTR: this.CREATIVE_INSTR(),
			JOB_LAYOUT_THUMB: this.JOB_LAYOUT_THUMB(),
			JOB_LAYOUT_ROUGH: this.JOB_LAYOUT_ROUGH(),
			JOB_LAYOUT_COMP: this.JOB_LAYOUT_COMP(),
			JOB_LAYOUT_NONE: this.JOB_LAYOUT_NONE(),
			JOB_LAYOUT_SPECIAL: this.JOB_LAYOUT_SPECIAL(),
			JOB_LAYOUT_SPC_EXP: this.JOB_LAYOUT_SPC_EXP(),
			ProcessControl: this.ProcessControl(),
			Description: this.Description(),
			JOB_COMP_COMMENTS: this.JOB_COMP_COMMENTS(),
			JOB_COMP_BUDGET_AM: String(this.JOB_COMP_BUDGET_AM() || 0),
			ESTIMATE_NUMBER: this.ESTIMATE_NUMBER(),
			EST_COMPONENT_NBR: this.EST_COMPONENT_NBR(),
			BILLING_USER: this.BILLING_USER(),
			AB_FLAG: this.AB_FLAG(),
			JOB_DEL_INSTRUCT: this.JOB_DEL_INSTRUCT(),
			JT_CODE: this.JT_CODE(),
			TAX_FLAG: this.TAX_FLAG(),
			TAX_CODE: this.TAX_CODE(),
			NOBILL_FLAG: this.NOBILL_FLAG(),
			EMAIL_GR_CODE: this.EMAIL_GR_CODE(),
			AD_NBR: this.AD_NBR(),
			ACCT_NBR: this.ACCT_NBR(),
			PRD_AB_INCOME: this.PRD_AB_INCOME(),
			MARKET_CODE: this.MARKET_CODE(),
			SERVICE_FEE_FLAG: this.SERVICE_FEE_FLAG(),
			ARCHIVE_FLAG: this.ARCHIVE_FLAG(),
			ROWID: this.ROWID(),
			ADJUST_USER: this.ADJUST_USER(),
			TRF_SCHEDULE_BY: this.TRF_SCHEDULE_BY(),
			TRF_SCHEDULE_REQ: this.TRF_SCHEDULE_REQ(),
			JOB_CL_PO_NBR: this.JOB_CL_PO_NBR(),
			UDV1_CODE: this.UDV1_CODE(),
			UDV2_CODE: this.UDV2_CODE(),
			UDV3_CODE: this.UDV3_CODE(),
			UDV4_CODE: this.UDV4_CODE(),
			UDV5_CODE: this.UDV5_CODE(),
			JOB_TMPLT_CODE: this.JOB_TMPLT_CODE(),
			FEE_TIME: this.FEE_TIME(),
			FISCAL_PERIOD_CODE: this.FISCAL_PERIOD_CODE(),
			JOB_QTY: this.JOB_QTY(),
			BLACKPLT_VER_CODE: this.BLACKPLT_VER_CODE(),
			BLACKPLT_VER_DESC: this.BLACKPLT_VER_DESC(),
			BLACKPLT_VER2_CODE: this.BLACKPLT_VER2_CODE(),
			BLACKPLT_VER2_DESC: this.BLACKPLT_VER2_DESC(),
			CDP_CONTACT_ID: this.CDP_CONTACT_ID(),
			PRD_CONT_CODE: this.PRD_CONT_CODE(),
			BA_BATCH_ID: this.BA_BATCH_ID(),
			SELECTED_BA_ID: this.SELECTED_BA_ID(),
			BCC_ID: this.BCC_ID(),
			ALRT_NOTIFY_HDR_ID: this.ALRT_NOTIFY_HDR_ID(),
			SERVICE_FEE_TYPE_ID: this.SERVICE_FEE_TYPE_ID(),
			MEDIA_BILL_DATE: this.MEDIA_BILL_DATE(),
			CS_PROJECT_ID: this.CS_PROJECT_ID(),
			JC_COMMENTS_HTML: this.JC_COMMENTS_HTML(),
			CREATIVE_INSTR_HTML: this.CREATIVE_INSTR_HTML(),
			JOB_DEL_INSTR_HTML: this.JOB_DEL_INSTR_HTML(),
			TRF_JOB_NUMBER: this.TRF_JOB_NUMBER(),
			TRF_JOB_COMPONENT_NBR: this.TRF_JOB_COMPONENT_NBR(),
			CLIENT_DISCOUNT_CODE: this.CLIENT_DISCOUNT_CODE(),
			MODIFY_DATE: this.MODIFY_DATE(),
			MODIFIED_BY: this.MODIFIED_BY(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.JobNumber(data.JobNumber);
				this.JobComponentNumber(data.JobComponentNumber);
				this.JOB_BILL_HOLD(data.JOB_BILL_HOLD);
				this.EMP_CODE(data.EMP_CODE);
				this.JOB_COMP_DATE(data.JOB_COMP_DATE);
				this.JOB_FIRST_USE_DATE(data.JOB_FIRST_USE_DATE);
				this.START_DATE(data.START_DATE);
				this.JOB_AD_SIZE(data.JOB_AD_SIZE);
				this.JOB_SPEC_TYPE(data.JOB_SPEC_TYPE);
				this.DepartmentTeamCode(data.DepartmentTeamCode);
				this.JOB_MARKUP_PCT(data.JOB_MARKUP_PCT);
				this.CREATIVE_INSTR(data.CREATIVE_INSTR);
				this.JOB_LAYOUT_THUMB(data.JOB_LAYOUT_THUMB);
				this.JOB_LAYOUT_ROUGH(data.JOB_LAYOUT_ROUGH);
				this.JOB_LAYOUT_COMP(data.JOB_LAYOUT_COMP);
				this.JOB_LAYOUT_NONE(data.JOB_LAYOUT_NONE);
				this.JOB_LAYOUT_SPECIAL(data.JOB_LAYOUT_SPECIAL);
				this.JOB_LAYOUT_SPC_EXP(data.JOB_LAYOUT_SPC_EXP);
				this.ProcessControl(data.ProcessControl);
				this.Description(data.Description);
				this.JOB_COMP_COMMENTS(data.JOB_COMP_COMMENTS);
				this.JOB_COMP_BUDGET_AM(data.JOB_COMP_BUDGET_AM);
				this.ESTIMATE_NUMBER(data.ESTIMATE_NUMBER);
				this.EST_COMPONENT_NBR(data.EST_COMPONENT_NBR);
				this.BILLING_USER(data.BILLING_USER);
				this.AB_FLAG(data.AB_FLAG);
				this.JOB_DEL_INSTRUCT(data.JOB_DEL_INSTRUCT);
				this.JT_CODE(data.JT_CODE);
				this.TAX_FLAG(data.TAX_FLAG);
				this.TAX_CODE(data.TAX_CODE);
				this.NOBILL_FLAG(data.NOBILL_FLAG);
				this.EMAIL_GR_CODE(data.EMAIL_GR_CODE);
				this.AD_NBR(data.AD_NBR);
				this.ACCT_NBR(data.ACCT_NBR);
				this.PRD_AB_INCOME(data.PRD_AB_INCOME);
				this.MARKET_CODE(data.MARKET_CODE);
				this.SERVICE_FEE_FLAG(data.SERVICE_FEE_FLAG);
				this.ARCHIVE_FLAG(data.ARCHIVE_FLAG);
				this.ROWID(data.ROWID);
				this.ADJUST_USER(data.ADJUST_USER);
				this.TRF_SCHEDULE_BY(data.TRF_SCHEDULE_BY);
				this.TRF_SCHEDULE_REQ(data.TRF_SCHEDULE_REQ);
				this.JOB_CL_PO_NBR(data.JOB_CL_PO_NBR);
				this.UDV1_CODE(data.UDV1_CODE);
				this.UDV2_CODE(data.UDV2_CODE);
				this.UDV3_CODE(data.UDV3_CODE);
				this.UDV4_CODE(data.UDV4_CODE);
				this.UDV5_CODE(data.UDV5_CODE);
				this.JOB_TMPLT_CODE(data.JOB_TMPLT_CODE);
				this.FEE_TIME(data.FEE_TIME);
				this.FISCAL_PERIOD_CODE(data.FISCAL_PERIOD_CODE);
				this.JOB_QTY(data.JOB_QTY);
				this.BLACKPLT_VER_CODE(data.BLACKPLT_VER_CODE);
				this.BLACKPLT_VER_DESC(data.BLACKPLT_VER_DESC);
				this.BLACKPLT_VER2_CODE(data.BLACKPLT_VER2_CODE);
				this.BLACKPLT_VER2_DESC(data.BLACKPLT_VER2_DESC);
				this.CDP_CONTACT_ID(data.CDP_CONTACT_ID);
				this.PRD_CONT_CODE(data.PRD_CONT_CODE);
				this.BA_BATCH_ID(data.BA_BATCH_ID);
				this.SELECTED_BA_ID(data.SELECTED_BA_ID);
				this.BCC_ID(data.BCC_ID);
				this.ALRT_NOTIFY_HDR_ID(data.ALRT_NOTIFY_HDR_ID);
				this.SERVICE_FEE_TYPE_ID(data.SERVICE_FEE_TYPE_ID);
				this.MEDIA_BILL_DATE(data.MEDIA_BILL_DATE);
				this.CS_PROJECT_ID(data.CS_PROJECT_ID);
				this.JC_COMMENTS_HTML(data.JC_COMMENTS_HTML);
				this.CREATIVE_INSTR_HTML(data.CREATIVE_INSTR_HTML);
				this.JOB_DEL_INSTR_HTML(data.JOB_DEL_INSTR_HTML);
				this.TRF_JOB_NUMBER(data.TRF_JOB_NUMBER);
				this.TRF_JOB_COMPONENT_NBR(data.TRF_JOB_COMPONENT_NBR);
				this.CLIENT_DISCOUNT_CODE(data.CLIENT_DISCOUNT_CODE);
				this.MODIFY_DATE(data.MODIFY_DATE);
				this.MODIFIED_BY(data.MODIFIED_BY);
		
            }
        }
    });
})();