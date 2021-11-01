
(function() {
    AdvantageMobile_UI.ClientViewModel = function(data) {
				this.Code = ko.observable();
				this.Name = ko.observable();
				this.Address1 = ko.observable();
				this.Address2 = ko.observable();
				this.City = ko.observable();
				this.County = ko.observable();
				this.State = ko.observable();
				this.Country = ko.observable();
				this.Zip = ko.observable();
				this.CL_ATTENTION = ko.observable();
				this.CL_BADDRESS1 = ko.observable();
				this.CL_BADDRESS2 = ko.observable();
				this.CL_BCITY = ko.observable();
				this.CL_BCOUNTY = ko.observable();
				this.CL_BSTATE = ko.observable();
				this.CL_BCOUNTRY = ko.observable();
				this.CL_BZIP = ko.observable();
				this.CL_SADDRESS1 = ko.observable();
				this.CL_SADDRESS2 = ko.observable();
				this.CL_SCITY = ko.observable();
				this.CL_SCOUNTY = ko.observable();
				this.CL_SSTATE = ko.observable();
				this.CL_SCOUNTRY = ko.observable();
				this.CL_SZIP = ko.observable();
				this.CL_FOOTER = ko.observable();
				this.CL_ALPHA_SORT = ko.observable();
				this.CL_FISCAL_START = ko.observable();
				this.CL_CREDIT_LIMIT = ko.observable();
				this.CL_HIGH_BALANCE = ko.observable();
				this.CL_INV_BY = ko.observable();
				this.INV_FORMAT = ko.observable();
				this.CL_MATTENTION = ko.observable();
				this.PINV_FORMAT = ko.observable();
				this.BINV_FORMAT = ko.observable();
				this.CL_MINV_BY = ko.observable();
				this.CL_MFOOTER = ko.observable();
				this.IsActive = ko.observable();
				this.NEW_BUSINESS = ko.observable();
				this.CMP_CODE_R = ko.observable();
				this.ACCT_NBR_R = ko.observable();
				this.JT_CODE_R = ko.observable();
				this.PROMO_CODE_R = ko.observable();
				this.REQ_FLDS = ko.observable();
				this.JOB_FIRST_USE_DT_R = ko.observable();
				this.COMPLEX_CODE_R = ko.observable();
				this.FORMAT_SC_CODE_R = ko.observable();
				this.DP_TM_CODE_R = ko.observable();
				this.MARKET_CODE_R = ko.observable();
				this.EMAIL_GR_CODE_R = ko.observable();
				this.BILL_COOP_CODE_R = ko.observable();
				this.AD_NBR_R = ko.observable();
				this.JOB_CLI_REF_R = ko.observable();
				this.JOB_DATE_OPENED_R = ko.observable();
				this.JOB_AD_SIZE_R = ko.observable();
				this.PROD_CONT_CODE_R = ko.observable();
				this.JOB_COMP_BUDGET_R = ko.observable();
				this.OINV_FORMAT = ko.observable();
				this.IINV_FORMAT = ko.observable();
				this.START_DATE_R = ko.observable();
				this.JOB_LOG_UDV1_R = ko.observable();
				this.JOB_LOG_UDV2_R = ko.observable();
				this.JOB_LOG_UDV3_R = ko.observable();
				this.JOB_LOG_UDV4_R = ko.observable();
				this.JOB_LOG_UDV5_R = ko.observable();
				this.JOB_CMP_UDV1_R = ko.observable();
				this.JOB_CMP_UDV2_R = ko.observable();
				this.JOB_CMP_UDV3_R = ko.observable();
				this.JOB_CMP_UDV4_R = ko.observable();
				this.JOB_CMP_UDV5_R = ko.observable();
				this.PINV_FORMAT2 = ko.observable();
				this.CL_AR_COMMENT = ko.observable();
				this.REQ_PROD_CAT = ko.observable();
				this.TAX_FLAG_R = ko.observable();
				this.FISCAL_PD_R = ko.observable();
				this.BLACKPLATE_VER_R = ko.observable();
				this.BLACKPLATE_VER2_R = ko.observable();
				this.CL_P_PAYDAYS = ko.observable();
				this.CL_M_PAYDAYS = ko.observable();
				this.SERVICE_FEE_TYPE_R = ko.observable();
				this.REQ_TIME_COMMENT = ko.observable();
				this.CONTRACT_EXP_DT = ko.observable();
				this.BATCH_NAME = ko.observable();
				this.INVOICE_LOCATION_ID = ko.observable();
				this.COMBO_INV_BY = ko.observable();
				this.COMBO_MEDIA_ONLY = ko.observable();
				this.CURRENCY_CODE = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ClientViewModel.prototype, {
        toJS: function() {
            return {
			Code: this.Code(),
			Name: this.Name(),
			Address1: this.Address1(),
			Address2: this.Address2(),
			City: this.City(),
			County: this.County(),
			State: this.State(),
			Country: this.Country(),
			Zip: this.Zip(),
			CL_ATTENTION: this.CL_ATTENTION(),
			CL_BADDRESS1: this.CL_BADDRESS1(),
			CL_BADDRESS2: this.CL_BADDRESS2(),
			CL_BCITY: this.CL_BCITY(),
			CL_BCOUNTY: this.CL_BCOUNTY(),
			CL_BSTATE: this.CL_BSTATE(),
			CL_BCOUNTRY: this.CL_BCOUNTRY(),
			CL_BZIP: this.CL_BZIP(),
			CL_SADDRESS1: this.CL_SADDRESS1(),
			CL_SADDRESS2: this.CL_SADDRESS2(),
			CL_SCITY: this.CL_SCITY(),
			CL_SCOUNTY: this.CL_SCOUNTY(),
			CL_SSTATE: this.CL_SSTATE(),
			CL_SCOUNTRY: this.CL_SCOUNTRY(),
			CL_SZIP: this.CL_SZIP(),
			CL_FOOTER: this.CL_FOOTER(),
			CL_ALPHA_SORT: this.CL_ALPHA_SORT(),
			CL_FISCAL_START: this.CL_FISCAL_START(),
			CL_CREDIT_LIMIT: String(this.CL_CREDIT_LIMIT() || 0),
			CL_HIGH_BALANCE: String(this.CL_HIGH_BALANCE() || 0),
			CL_INV_BY: this.CL_INV_BY(),
			INV_FORMAT: this.INV_FORMAT(),
			CL_MATTENTION: this.CL_MATTENTION(),
			PINV_FORMAT: this.PINV_FORMAT(),
			BINV_FORMAT: this.BINV_FORMAT(),
			CL_MINV_BY: this.CL_MINV_BY(),
			CL_MFOOTER: this.CL_MFOOTER(),
			IsActive: this.IsActive(),
			NEW_BUSINESS: this.NEW_BUSINESS(),
			CMP_CODE_R: this.CMP_CODE_R(),
			ACCT_NBR_R: this.ACCT_NBR_R(),
			JT_CODE_R: this.JT_CODE_R(),
			PROMO_CODE_R: this.PROMO_CODE_R(),
			REQ_FLDS: this.REQ_FLDS(),
			JOB_FIRST_USE_DT_R: this.JOB_FIRST_USE_DT_R(),
			COMPLEX_CODE_R: this.COMPLEX_CODE_R(),
			FORMAT_SC_CODE_R: this.FORMAT_SC_CODE_R(),
			DP_TM_CODE_R: this.DP_TM_CODE_R(),
			MARKET_CODE_R: this.MARKET_CODE_R(),
			EMAIL_GR_CODE_R: this.EMAIL_GR_CODE_R(),
			BILL_COOP_CODE_R: this.BILL_COOP_CODE_R(),
			AD_NBR_R: this.AD_NBR_R(),
			JOB_CLI_REF_R: this.JOB_CLI_REF_R(),
			JOB_DATE_OPENED_R: this.JOB_DATE_OPENED_R(),
			JOB_AD_SIZE_R: this.JOB_AD_SIZE_R(),
			PROD_CONT_CODE_R: this.PROD_CONT_CODE_R(),
			JOB_COMP_BUDGET_R: this.JOB_COMP_BUDGET_R(),
			OINV_FORMAT: this.OINV_FORMAT(),
			IINV_FORMAT: this.IINV_FORMAT(),
			START_DATE_R: this.START_DATE_R(),
			JOB_LOG_UDV1_R: this.JOB_LOG_UDV1_R(),
			JOB_LOG_UDV2_R: this.JOB_LOG_UDV2_R(),
			JOB_LOG_UDV3_R: this.JOB_LOG_UDV3_R(),
			JOB_LOG_UDV4_R: this.JOB_LOG_UDV4_R(),
			JOB_LOG_UDV5_R: this.JOB_LOG_UDV5_R(),
			JOB_CMP_UDV1_R: this.JOB_CMP_UDV1_R(),
			JOB_CMP_UDV2_R: this.JOB_CMP_UDV2_R(),
			JOB_CMP_UDV3_R: this.JOB_CMP_UDV3_R(),
			JOB_CMP_UDV4_R: this.JOB_CMP_UDV4_R(),
			JOB_CMP_UDV5_R: this.JOB_CMP_UDV5_R(),
			PINV_FORMAT2: this.PINV_FORMAT2(),
			CL_AR_COMMENT: this.CL_AR_COMMENT(),
			REQ_PROD_CAT: this.REQ_PROD_CAT(),
			TAX_FLAG_R: this.TAX_FLAG_R(),
			FISCAL_PD_R: this.FISCAL_PD_R(),
			BLACKPLATE_VER_R: this.BLACKPLATE_VER_R(),
			BLACKPLATE_VER2_R: this.BLACKPLATE_VER2_R(),
			CL_P_PAYDAYS: this.CL_P_PAYDAYS(),
			CL_M_PAYDAYS: this.CL_M_PAYDAYS(),
			SERVICE_FEE_TYPE_R: this.SERVICE_FEE_TYPE_R(),
			REQ_TIME_COMMENT: this.REQ_TIME_COMMENT(),
			CONTRACT_EXP_DT: this.CONTRACT_EXP_DT(),
			BATCH_NAME: this.BATCH_NAME(),
			INVOICE_LOCATION_ID: this.INVOICE_LOCATION_ID(),
			COMBO_INV_BY: this.COMBO_INV_BY(),
			COMBO_MEDIA_ONLY: this.COMBO_MEDIA_ONLY(),
			CURRENCY_CODE: this.CURRENCY_CODE(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.Code(data.Code);
				this.Name(data.Name);
				this.Address1(data.Address1);
				this.Address2(data.Address2);
				this.City(data.City);
				this.County(data.County);
				this.State(data.State);
				this.Country(data.Country);
				this.Zip(data.Zip);
				this.CL_ATTENTION(data.CL_ATTENTION);
				this.CL_BADDRESS1(data.CL_BADDRESS1);
				this.CL_BADDRESS2(data.CL_BADDRESS2);
				this.CL_BCITY(data.CL_BCITY);
				this.CL_BCOUNTY(data.CL_BCOUNTY);
				this.CL_BSTATE(data.CL_BSTATE);
				this.CL_BCOUNTRY(data.CL_BCOUNTRY);
				this.CL_BZIP(data.CL_BZIP);
				this.CL_SADDRESS1(data.CL_SADDRESS1);
				this.CL_SADDRESS2(data.CL_SADDRESS2);
				this.CL_SCITY(data.CL_SCITY);
				this.CL_SCOUNTY(data.CL_SCOUNTY);
				this.CL_SSTATE(data.CL_SSTATE);
				this.CL_SCOUNTRY(data.CL_SCOUNTRY);
				this.CL_SZIP(data.CL_SZIP);
				this.CL_FOOTER(data.CL_FOOTER);
				this.CL_ALPHA_SORT(data.CL_ALPHA_SORT);
				this.CL_FISCAL_START(data.CL_FISCAL_START);
				this.CL_CREDIT_LIMIT(data.CL_CREDIT_LIMIT);
				this.CL_HIGH_BALANCE(data.CL_HIGH_BALANCE);
				this.CL_INV_BY(data.CL_INV_BY);
				this.INV_FORMAT(data.INV_FORMAT);
				this.CL_MATTENTION(data.CL_MATTENTION);
				this.PINV_FORMAT(data.PINV_FORMAT);
				this.BINV_FORMAT(data.BINV_FORMAT);
				this.CL_MINV_BY(data.CL_MINV_BY);
				this.CL_MFOOTER(data.CL_MFOOTER);
				this.IsActive(data.IsActive);
				this.NEW_BUSINESS(data.NEW_BUSINESS);
				this.CMP_CODE_R(data.CMP_CODE_R);
				this.ACCT_NBR_R(data.ACCT_NBR_R);
				this.JT_CODE_R(data.JT_CODE_R);
				this.PROMO_CODE_R(data.PROMO_CODE_R);
				this.REQ_FLDS(data.REQ_FLDS);
				this.JOB_FIRST_USE_DT_R(data.JOB_FIRST_USE_DT_R);
				this.COMPLEX_CODE_R(data.COMPLEX_CODE_R);
				this.FORMAT_SC_CODE_R(data.FORMAT_SC_CODE_R);
				this.DP_TM_CODE_R(data.DP_TM_CODE_R);
				this.MARKET_CODE_R(data.MARKET_CODE_R);
				this.EMAIL_GR_CODE_R(data.EMAIL_GR_CODE_R);
				this.BILL_COOP_CODE_R(data.BILL_COOP_CODE_R);
				this.AD_NBR_R(data.AD_NBR_R);
				this.JOB_CLI_REF_R(data.JOB_CLI_REF_R);
				this.JOB_DATE_OPENED_R(data.JOB_DATE_OPENED_R);
				this.JOB_AD_SIZE_R(data.JOB_AD_SIZE_R);
				this.PROD_CONT_CODE_R(data.PROD_CONT_CODE_R);
				this.JOB_COMP_BUDGET_R(data.JOB_COMP_BUDGET_R);
				this.OINV_FORMAT(data.OINV_FORMAT);
				this.IINV_FORMAT(data.IINV_FORMAT);
				this.START_DATE_R(data.START_DATE_R);
				this.JOB_LOG_UDV1_R(data.JOB_LOG_UDV1_R);
				this.JOB_LOG_UDV2_R(data.JOB_LOG_UDV2_R);
				this.JOB_LOG_UDV3_R(data.JOB_LOG_UDV3_R);
				this.JOB_LOG_UDV4_R(data.JOB_LOG_UDV4_R);
				this.JOB_LOG_UDV5_R(data.JOB_LOG_UDV5_R);
				this.JOB_CMP_UDV1_R(data.JOB_CMP_UDV1_R);
				this.JOB_CMP_UDV2_R(data.JOB_CMP_UDV2_R);
				this.JOB_CMP_UDV3_R(data.JOB_CMP_UDV3_R);
				this.JOB_CMP_UDV4_R(data.JOB_CMP_UDV4_R);
				this.JOB_CMP_UDV5_R(data.JOB_CMP_UDV5_R);
				this.PINV_FORMAT2(data.PINV_FORMAT2);
				this.CL_AR_COMMENT(data.CL_AR_COMMENT);
				this.REQ_PROD_CAT(data.REQ_PROD_CAT);
				this.TAX_FLAG_R(data.TAX_FLAG_R);
				this.FISCAL_PD_R(data.FISCAL_PD_R);
				this.BLACKPLATE_VER_R(data.BLACKPLATE_VER_R);
				this.BLACKPLATE_VER2_R(data.BLACKPLATE_VER2_R);
				this.CL_P_PAYDAYS(data.CL_P_PAYDAYS);
				this.CL_M_PAYDAYS(data.CL_M_PAYDAYS);
				this.SERVICE_FEE_TYPE_R(data.SERVICE_FEE_TYPE_R);
				this.REQ_TIME_COMMENT(data.REQ_TIME_COMMENT);
				this.CONTRACT_EXP_DT(data.CONTRACT_EXP_DT);
				this.BATCH_NAME(data.BATCH_NAME);
				this.INVOICE_LOCATION_ID(data.INVOICE_LOCATION_ID);
				this.COMBO_INV_BY(data.COMBO_INV_BY);
				this.COMBO_MEDIA_ONLY(data.COMBO_MEDIA_ONLY);
				this.CURRENCY_CODE(data.CURRENCY_CODE);
		
            }
        }
    });
})();