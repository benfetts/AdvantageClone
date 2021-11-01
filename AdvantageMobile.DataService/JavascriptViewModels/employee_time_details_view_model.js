
(function() {
    AdvantageMobile_UI.EmployeeTimeDetailViewModel = function(data) {
				this.EmployeeTimeID = ko.observable();
				this.ID = ko.observable();
				this.SequenceNumber = ko.observable();
				this.JobNumber = ko.observable();
				this.JobComponentNumber = ko.observable();
				this.FunctionCode = ko.observable();
				this.Hours = ko.observable();
				this.BillableRate = ko.observable();
				this.CostRate = ko.observable();
				this.DepartmentTeamCode = ko.observable();
				this.SalesTaxCode = ko.observable();
				this.SalesTaxStatePercentage = ko.observable();
				this.SalesTaxCountyPercentage = ko.observable();
				this.SalesTaxCityPercentage = ko.observable();
				this.SalesTaxResaleAmount = ko.observable();
				this.TAX_COMM = ko.observable();
				this.TAX_COMM_ONLY = ko.observable();
				this.EMP_COMM_PCT = ko.observable();
				this.EMP_NON_BILL_FLAG = ko.observable();
				this.AR_INV_NBR = ko.observable();
				this.AR_INV_SEQ = ko.observable();
				this.AR_TYPE = ko.observable();
				this.DateEntered = ko.observable();
				this.Comment = ko.observable();
				this.BILL_HOLD_FLG = ko.observable();
				this.UserCode = ko.observable();
				this.BillingUserCode = ko.observable();
				this.EMP_RATE_FROM = ko.observable();
				this.ADJ_COMMENTS = ko.observable();
				this.GLEXACT_BILL = ko.observable();
				this.GLESEQ_SALES = ko.observable();
				this.GLESEQ_STATE = ko.observable();
				this.GLESEQ_CNTY = ko.observable();
				this.GLESEQ_CITY = ko.observable();
				this.GLACODE_SALES = ko.observable();
				this.GLACODE_STATE = ko.observable();
				this.GLACODE_CNTY = ko.observable();
				this.GLACODE_CITY = ko.observable();
				this.AB_FLAG = ko.observable();
				this.TOTAL_COST = ko.observable();
				this.TOTAL_BILL = ko.observable();
				this.EXT_MARKUP_AMT = ko.observable();
				this.EXT_STATE_RESALE = ko.observable();
				this.EXT_COUNTY_RESALE = ko.observable();
				this.EXT_CITY_RESALE = ko.observable();
				this.LINE_TOTAL = ko.observable();
				this.POST_PERIOD = ko.observable();
				this.EDIT_FLAG = ko.observable();
				this.AB_ID = ko.observable();
				this.CMP_UPD_INV_DATE = ko.observable();
				this.CMP_UPD_PP = ko.observable();
				this.EMP_NOTES = ko.observable();
				this.XFER_FROM_JOB = ko.observable();
				this.XFER_FROM_JOB_COMP = ko.observable();
				this.XFER_FROM_FNC = ko.observable();
				this.XFER_FROM_ET_ID = ko.observable();
				this.XFER_FROM_SEQ_NBR = ko.observable();
				this.XFER_ADJ_USER = ko.observable();
				this.XFER_ADJ_DATE = ko.observable();
				this.PROD_CAT_CODE = ko.observable();
				this.FEE_TIME = ko.observable();
				this.FEE_REC_FLAG = ko.observable();
				this.FEE_REC_DATE = ko.observable();
				this.FEE_REC_USER = ko.observable();
				this.EMPLOYEE_TITLE_ID = ko.observable();
				this.JOB_VER_HDR_ID = ko.observable();
				this.BA_ID = ko.observable();
				this.BCC_ID = ko.observable();
				this.ALT_COST_RATE = ko.observable();
				this.ALT_COST_AMT = ko.observable();
				this.START_TIME = ko.observable();
				this.END_TIME = ko.observable();
				this.TRF_CODE = ko.observable();
				this.TRF_SEQ_NBR = ko.observable();
				this.ADJ_USER = ko.observable();
				this.ADJ_DATE = ko.observable();
				this.ALERT_ID = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeTimeDetailViewModel.prototype, {
        toJS: function() {
            return {
			EmployeeTimeID: this.EmployeeTimeID(),
			ID: this.ID(),
			SequenceNumber: this.SequenceNumber(),
			JobNumber: this.JobNumber(),
			JobComponentNumber: this.JobComponentNumber(),
			FunctionCode: this.FunctionCode(),
			Hours: this.Hours(),
			BillableRate: String(this.BillableRate() || 0),
			CostRate: String(this.CostRate() || 0),
			DepartmentTeamCode: this.DepartmentTeamCode(),
			SalesTaxCode: this.SalesTaxCode(),
			SalesTaxStatePercentage: String(this.SalesTaxStatePercentage() || 0),
			SalesTaxCountyPercentage: String(this.SalesTaxCountyPercentage() || 0),
			SalesTaxCityPercentage: String(this.SalesTaxCityPercentage() || 0),
			SalesTaxResaleAmount: this.SalesTaxResaleAmount(),
			TAX_COMM: this.TAX_COMM(),
			TAX_COMM_ONLY: this.TAX_COMM_ONLY(),
			EMP_COMM_PCT: String(this.EMP_COMM_PCT() || 0),
			EMP_NON_BILL_FLAG: this.EMP_NON_BILL_FLAG(),
			AR_INV_NBR: this.AR_INV_NBR(),
			AR_INV_SEQ: this.AR_INV_SEQ(),
			AR_TYPE: this.AR_TYPE(),
			DateEntered: this.DateEntered(),
			Comment: this.Comment(),
			BILL_HOLD_FLG: this.BILL_HOLD_FLG(),
			UserCode: this.UserCode(),
			BillingUserCode: this.BillingUserCode(),
			EMP_RATE_FROM: this.EMP_RATE_FROM(),
			ADJ_COMMENTS: this.ADJ_COMMENTS(),
			GLEXACT_BILL: this.GLEXACT_BILL(),
			GLESEQ_SALES: this.GLESEQ_SALES(),
			GLESEQ_STATE: this.GLESEQ_STATE(),
			GLESEQ_CNTY: this.GLESEQ_CNTY(),
			GLESEQ_CITY: this.GLESEQ_CITY(),
			GLACODE_SALES: this.GLACODE_SALES(),
			GLACODE_STATE: this.GLACODE_STATE(),
			GLACODE_CNTY: this.GLACODE_CNTY(),
			GLACODE_CITY: this.GLACODE_CITY(),
			AB_FLAG: this.AB_FLAG(),
			TOTAL_COST: String(this.TOTAL_COST() || 0),
			TOTAL_BILL: String(this.TOTAL_BILL() || 0),
			EXT_MARKUP_AMT: String(this.EXT_MARKUP_AMT() || 0),
			EXT_STATE_RESALE: String(this.EXT_STATE_RESALE() || 0),
			EXT_COUNTY_RESALE: String(this.EXT_COUNTY_RESALE() || 0),
			EXT_CITY_RESALE: String(this.EXT_CITY_RESALE() || 0),
			LINE_TOTAL: String(this.LINE_TOTAL() || 0),
			POST_PERIOD: this.POST_PERIOD(),
			EDIT_FLAG: this.EDIT_FLAG(),
			AB_ID: this.AB_ID(),
			CMP_UPD_INV_DATE: this.CMP_UPD_INV_DATE(),
			CMP_UPD_PP: this.CMP_UPD_PP(),
			EMP_NOTES: this.EMP_NOTES(),
			XFER_FROM_JOB: this.XFER_FROM_JOB(),
			XFER_FROM_JOB_COMP: this.XFER_FROM_JOB_COMP(),
			XFER_FROM_FNC: this.XFER_FROM_FNC(),
			XFER_FROM_ET_ID: this.XFER_FROM_ET_ID(),
			XFER_FROM_SEQ_NBR: this.XFER_FROM_SEQ_NBR(),
			XFER_ADJ_USER: this.XFER_ADJ_USER(),
			XFER_ADJ_DATE: this.XFER_ADJ_DATE(),
			PROD_CAT_CODE: this.PROD_CAT_CODE(),
			FEE_TIME: this.FEE_TIME(),
			FEE_REC_FLAG: this.FEE_REC_FLAG(),
			FEE_REC_DATE: this.FEE_REC_DATE(),
			FEE_REC_USER: this.FEE_REC_USER(),
			EMPLOYEE_TITLE_ID: this.EMPLOYEE_TITLE_ID(),
			JOB_VER_HDR_ID: this.JOB_VER_HDR_ID(),
			BA_ID: this.BA_ID(),
			BCC_ID: this.BCC_ID(),
			ALT_COST_RATE: String(this.ALT_COST_RATE() || 0),
			ALT_COST_AMT: String(this.ALT_COST_AMT() || 0),
			START_TIME: this.START_TIME(),
			END_TIME: this.END_TIME(),
			TRF_CODE: this.TRF_CODE(),
			TRF_SEQ_NBR: this.TRF_SEQ_NBR(),
			ADJ_USER: this.ADJ_USER(),
			ADJ_DATE: this.ADJ_DATE(),
			ALERT_ID: this.ALERT_ID(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.EmployeeTimeID(data.EmployeeTimeID);
				this.ID(data.ID);
				this.SequenceNumber(data.SequenceNumber);
				this.JobNumber(data.JobNumber);
				this.JobComponentNumber(data.JobComponentNumber);
				this.FunctionCode(data.FunctionCode);
				this.Hours(data.Hours);
				this.BillableRate(data.BillableRate);
				this.CostRate(data.CostRate);
				this.DepartmentTeamCode(data.DepartmentTeamCode);
				this.SalesTaxCode(data.SalesTaxCode);
				this.SalesTaxStatePercentage(data.SalesTaxStatePercentage);
				this.SalesTaxCountyPercentage(data.SalesTaxCountyPercentage);
				this.SalesTaxCityPercentage(data.SalesTaxCityPercentage);
				this.SalesTaxResaleAmount(data.SalesTaxResaleAmount);
				this.TAX_COMM(data.TAX_COMM);
				this.TAX_COMM_ONLY(data.TAX_COMM_ONLY);
				this.EMP_COMM_PCT(data.EMP_COMM_PCT);
				this.EMP_NON_BILL_FLAG(data.EMP_NON_BILL_FLAG);
				this.AR_INV_NBR(data.AR_INV_NBR);
				this.AR_INV_SEQ(data.AR_INV_SEQ);
				this.AR_TYPE(data.AR_TYPE);
				this.DateEntered(data.DateEntered);
				this.Comment(data.Comment);
				this.BILL_HOLD_FLG(data.BILL_HOLD_FLG);
				this.UserCode(data.UserCode);
				this.BillingUserCode(data.BillingUserCode);
				this.EMP_RATE_FROM(data.EMP_RATE_FROM);
				this.ADJ_COMMENTS(data.ADJ_COMMENTS);
				this.GLEXACT_BILL(data.GLEXACT_BILL);
				this.GLESEQ_SALES(data.GLESEQ_SALES);
				this.GLESEQ_STATE(data.GLESEQ_STATE);
				this.GLESEQ_CNTY(data.GLESEQ_CNTY);
				this.GLESEQ_CITY(data.GLESEQ_CITY);
				this.GLACODE_SALES(data.GLACODE_SALES);
				this.GLACODE_STATE(data.GLACODE_STATE);
				this.GLACODE_CNTY(data.GLACODE_CNTY);
				this.GLACODE_CITY(data.GLACODE_CITY);
				this.AB_FLAG(data.AB_FLAG);
				this.TOTAL_COST(data.TOTAL_COST);
				this.TOTAL_BILL(data.TOTAL_BILL);
				this.EXT_MARKUP_AMT(data.EXT_MARKUP_AMT);
				this.EXT_STATE_RESALE(data.EXT_STATE_RESALE);
				this.EXT_COUNTY_RESALE(data.EXT_COUNTY_RESALE);
				this.EXT_CITY_RESALE(data.EXT_CITY_RESALE);
				this.LINE_TOTAL(data.LINE_TOTAL);
				this.POST_PERIOD(data.POST_PERIOD);
				this.EDIT_FLAG(data.EDIT_FLAG);
				this.AB_ID(data.AB_ID);
				this.CMP_UPD_INV_DATE(data.CMP_UPD_INV_DATE);
				this.CMP_UPD_PP(data.CMP_UPD_PP);
				this.EMP_NOTES(data.EMP_NOTES);
				this.XFER_FROM_JOB(data.XFER_FROM_JOB);
				this.XFER_FROM_JOB_COMP(data.XFER_FROM_JOB_COMP);
				this.XFER_FROM_FNC(data.XFER_FROM_FNC);
				this.XFER_FROM_ET_ID(data.XFER_FROM_ET_ID);
				this.XFER_FROM_SEQ_NBR(data.XFER_FROM_SEQ_NBR);
				this.XFER_ADJ_USER(data.XFER_ADJ_USER);
				this.XFER_ADJ_DATE(data.XFER_ADJ_DATE);
				this.PROD_CAT_CODE(data.PROD_CAT_CODE);
				this.FEE_TIME(data.FEE_TIME);
				this.FEE_REC_FLAG(data.FEE_REC_FLAG);
				this.FEE_REC_DATE(data.FEE_REC_DATE);
				this.FEE_REC_USER(data.FEE_REC_USER);
				this.EMPLOYEE_TITLE_ID(data.EMPLOYEE_TITLE_ID);
				this.JOB_VER_HDR_ID(data.JOB_VER_HDR_ID);
				this.BA_ID(data.BA_ID);
				this.BCC_ID(data.BCC_ID);
				this.ALT_COST_RATE(data.ALT_COST_RATE);
				this.ALT_COST_AMT(data.ALT_COST_AMT);
				this.START_TIME(data.START_TIME);
				this.END_TIME(data.END_TIME);
				this.TRF_CODE(data.TRF_CODE);
				this.TRF_SEQ_NBR(data.TRF_SEQ_NBR);
				this.ADJ_USER(data.ADJ_USER);
				this.ADJ_DATE(data.ADJ_DATE);
				this.ALERT_ID(data.ALERT_ID);
		
            }
        }
    });
})();