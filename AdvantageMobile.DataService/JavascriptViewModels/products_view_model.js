
(function() {
    AdvantageMobile_UI.ProductViewModel = function(data) {
				this.ClientCode = ko.observable();
				this.DivisionCode = ko.observable();
				this.Code = ko.observable();
				this.Description = ko.observable();
				this.PRD_ATTENTION = ko.observable();
				this.PRD_BILL_ADDRESS1 = ko.observable();
				this.PRD_BILL_ADDRESS2 = ko.observable();
				this.PRD_BILL_CITY = ko.observable();
				this.PRD_BILL_COUNTY = ko.observable();
				this.PRD_BILL_STATE = ko.observable();
				this.PRD_BILL_COUNTRY = ko.observable();
				this.PRD_BILL_ZIP = ko.observable();
				this.PRD_BILL_TELEPHONE = ko.observable();
				this.PRD_BILL_EXTENTION = ko.observable();
				this.PRD_BILL_FAX = ko.observable();
				this.PRD_BILL_FAX_EXT = ko.observable();
				this.PRD_STATE_ADDR1 = ko.observable();
				this.PRD_STATE_ADDR2 = ko.observable();
				this.PRD_STATE_CITY = ko.observable();
				this.PRD_STATE_COUNTY = ko.observable();
				this.PRD_STATE_STATE = ko.observable();
				this.PRD_STATE_COUNTRY = ko.observable();
				this.PRD_STATE_ZIP = ko.observable();
				this.PRD_STATE_TELEPHON = ko.observable();
				this.PRD_STATE_EXT = ko.observable();
				this.PRD_STATE_FAX = ko.observable();
				this.PRD_STATE_FAX_EXT = ko.observable();
				this.PRD_ALPHA_SORT = ko.observable();
				this.OfficeCode = ko.observable();
				this.PRD_CONSOL_FUNC = ko.observable();
				this.PRD_CONT_PCT = ko.observable();
				this.PRD_PROD_MARKUP = ko.observable();
				this.PRD_PROD_BCYCLE = ko.observable();
				this.PRD_PROD_BILL_NET = ko.observable();
				this.PRD_PROD_VEN_DISC = ko.observable();
				this.PRD_PROD_ESTIMATE = ko.observable();
				this.PRD_PROD_TAX_CODE = ko.observable();
				this.PRD_PROD_COMMENTS = ko.observable();
				this.PRD_MEDIA_BCYCLE = ko.observable();
				this.PRD_RADIO_REBATE = ko.observable();
				this.PRD_RADIO_BILL_NET = ko.observable();
				this.PRD_RADIO_VEN_DISC = ko.observable();
				this.PRD_RADIO_COM_ONLY = ko.observable();
				this.PRD_RADIO_TAX_CODE = ko.observable();
				this.PRD_RADIO_DAYS = ko.observable();
				this.PRD_RADIO_PRE_POST = ko.observable();
				this.PRD_RADIO_BF_AF = ko.observable();
				this.PRD_TV_REBATE = ko.observable();
				this.PRD_TV_BILL_NET = ko.observable();
				this.PRD_TV_VEN_DISC = ko.observable();
				this.PRD_TV_COM_ONLY = ko.observable();
				this.PRD_TV_TAX_CODE = ko.observable();
				this.PRD_TV_DAYS = ko.observable();
				this.PRD_TV_PRE_POST = ko.observable();
				this.PRD_TV_BF_AF = ko.observable();
				this.PRD_MAG_REBATE = ko.observable();
				this.PRD_MAG_BILL_NET = ko.observable();
				this.PRD_MAG_VEN_DISC = ko.observable();
				this.PRD_MAG_COM_ONLY = ko.observable();
				this.PRD_MAG_TAX_CODE = ko.observable();
				this.PRD_MAG_DAYS = ko.observable();
				this.PRD_MAG_PRE_POST = ko.observable();
				this.PRD_MAG_BF_AF = ko.observable();
				this.PRD_NEWS_COMM = ko.observable();
				this.PRD_NEWS_BILL_NET = ko.observable();
				this.PRD_NEWS_VEN_DISC = ko.observable();
				this.PRD_NEWS_COM_ONLY = ko.observable();
				this.PRD_NEWS_TAX_CODE = ko.observable();
				this.PRD_NEWS_DAYS = ko.observable();
				this.PRD_NEWS_PRE_POST = ko.observable();
				this.PRD_NEWS_BF_AF = ko.observable();
				this.PRD_RADIO_COMMENT = ko.observable();
				this.PRD_SF_BEGIN_DATE = ko.observable();
				this.PRD_SF_NBR_OF_MTHS = ko.observable();
				this.PRD_SF_PER_GUARAN = ko.observable();
				this.PRD_SF_RECON_CODE = ko.observable();
				this.PRD_SF_BCYCLE = ko.observable();
				this.PRD_SF_TAX_TIME = ko.observable();
				this.PRD_SF_EMP_TIME = ko.observable();
				this.PRD_SF_MEDIA_COMM = ko.observable();
				this.PRD_SF_PROD_COMM = ko.observable();
				this.PRD_SF_AMT = ko.observable();
				this.PRD_TV_COMMENT = ko.observable();
				this.PRD_MAG_COMMENT = ko.observable();
				this.PRD_NEWS_COMMENT = ko.observable();
				this.PRD_OTDR_COMMENT = ko.observable();
				this.PRD_MISC_COMMENT = ko.observable();
				this.PRD_NEWS_REBATE = ko.observable();
				this.PRD_OTDR_REBATE = ko.observable();
				this.PRD_MISC_REBATE = ko.observable();
				this.PRD_RADIO_COMM = ko.observable();
				this.PRD_TV_COMM = ko.observable();
				this.PRD_MAG_COMM = ko.observable();
				this.PRD_OTDR_COMM = ko.observable();
				this.PRD_MISC_COMM = ko.observable();
				this.PRD_OTDR_BF_AF = ko.observable();
				this.PRD_OTDR_BILL_NET = ko.observable();
				this.PRD_OTDR_COM_ONLY = ko.observable();
				this.PRD_OTDR_DAYS = ko.observable();
				this.PRD_OTDR_PRE_POST = ko.observable();
				this.PRD_OTDR_TAX_CODE = ko.observable();
				this.PRD_OTDR_VEN_DISC = ko.observable();
				this.PRD_MISC_BF_AF = ko.observable();
				this.PRD_MISC_BILL_NET = ko.observable();
				this.PRD_MISC_COM_ONLY = ko.observable();
				this.PRD_MISC_DAYS = ko.observable();
				this.PRD_MISC_PRE_POST = ko.observable();
				this.PRD_MISC_TAX_CODE = ko.observable();
				this.PRD_MISC_VEN_DISC = ko.observable();
				this.EMAIL_GR_CODE = ko.observable();
				this.TECHNOLOGY_FEE = ko.observable();
				this.IsActive = ko.observable();
				this.USER_DEFINED1 = ko.observable();
				this.USER_DEFINED2 = ko.observable();
				this.USER_DEFINED3 = ko.observable();
				this.USER_DEFINED4 = ko.observable();
				this.BILLED_TIME = ko.observable();
				this.BILLED_MARKUP = ko.observable();
				this.BILLED_COMM = ko.observable();
				this.NEWSPAPER = ko.observable();
				this.MAGAZINE = ko.observable();
				this.RADIO = ko.observable();
				this.TELEVISION = ko.observable();
				this.OUTDOOR = ko.observable();
				this.INTERNET = ko.observable();
				this.USE_TAX_FLAGS_R = ko.observable();
				this.TAXAPPLYLN_R = ko.observable();
				this.TAXAPPLYND_R = ko.observable();
				this.TAXAPPLYNC_R = ko.observable();
				this.TAXAPPLYAI_R = ko.observable();
				this.TAXAPPLYC_R = ko.observable();
				this.TAXAPPLYR_R = ko.observable();
				this.USE_TAX_FLAGS_T = ko.observable();
				this.TAXAPPLYLN_T = ko.observable();
				this.TAXAPPLYND_T = ko.observable();
				this.TAXAPPLYNC_T = ko.observable();
				this.TAXAPPLYAI_T = ko.observable();
				this.TAXAPPLYC_T = ko.observable();
				this.TAXAPPLYR_T = ko.observable();
				this.USE_TAX_FLAGS_M = ko.observable();
				this.TAXAPPLYLN_M = ko.observable();
				this.TAXAPPLYND_M = ko.observable();
				this.TAXAPPLYNC_M = ko.observable();
				this.TAXAPPLYAI_M = ko.observable();
				this.TAXAPPLYC_M = ko.observable();
				this.TAXAPPLYR_M = ko.observable();
				this.USE_TAX_FLAGS_N = ko.observable();
				this.TAXAPPLYLN_N = ko.observable();
				this.TAXAPPLYND_N = ko.observable();
				this.TAXAPPLYNC_N = ko.observable();
				this.TAXAPPLYAI_N = ko.observable();
				this.TAXAPPLYC_N = ko.observable();
				this.TAXAPPLYR_N = ko.observable();
				this.USE_TAX_FLAGS_O = ko.observable();
				this.TAXAPPLYLN_O = ko.observable();
				this.TAXAPPLYND_O = ko.observable();
				this.TAXAPPLYNC_O = ko.observable();
				this.TAXAPPLYAI_O = ko.observable();
				this.TAXAPPLYC_O = ko.observable();
				this.TAXAPPLYR_O = ko.observable();
				this.USE_TAX_FLAGS_I = ko.observable();
				this.TAXAPPLYLN_I = ko.observable();
				this.TAXAPPLYND_I = ko.observable();
				this.TAXAPPLYNC_I = ko.observable();
				this.TAXAPPLYAI_I = ko.observable();
				this.TAXAPPLYC_I = ko.observable();
				this.TAXAPPLYR_I = ko.observable();
				this.PRD_BILL_RATE = ko.observable();
				this.PRD_BILL_EMP_TIME = ko.observable();
				this.PROD_SETUP_COMPLETE = ko.observable();
				this.RADIO_SETUP_COMPLETE = ko.observable();
				this.TV_SETUP_COMPLETE = ko.observable();
				this.MAG_SETUP_COMPLETE = ko.observable();
				this.NEWS_SETUP_COMPLETE = ko.observable();
				this.OOH_SETUP_COMPLETE = ko.observable();
				this.INET_SETUP_COMPLETE = ko.observable();
				this.USE_EST_BILL_RATE = ko.observable();
				this.CURRENCY_CODE = ko.observable();
				this.BATCH_NAME = ko.observable();
				this.AVALARA_TAX_EXEMPT_OVERRIDE = ko.observable();
				this.PRD_PROD_PAYDAYS = ko.observable();
				this.CALC_LATE_FEE = ko.observable();
				this.LATE_FEE_PERCENT = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ProductViewModel.prototype, {
        toJS: function() {
            return {
			ClientCode: this.ClientCode(),
			DivisionCode: this.DivisionCode(),
			Code: this.Code(),
			Description: this.Description(),
			PRD_ATTENTION: this.PRD_ATTENTION(),
			PRD_BILL_ADDRESS1: this.PRD_BILL_ADDRESS1(),
			PRD_BILL_ADDRESS2: this.PRD_BILL_ADDRESS2(),
			PRD_BILL_CITY: this.PRD_BILL_CITY(),
			PRD_BILL_COUNTY: this.PRD_BILL_COUNTY(),
			PRD_BILL_STATE: this.PRD_BILL_STATE(),
			PRD_BILL_COUNTRY: this.PRD_BILL_COUNTRY(),
			PRD_BILL_ZIP: this.PRD_BILL_ZIP(),
			PRD_BILL_TELEPHONE: this.PRD_BILL_TELEPHONE(),
			PRD_BILL_EXTENTION: this.PRD_BILL_EXTENTION(),
			PRD_BILL_FAX: this.PRD_BILL_FAX(),
			PRD_BILL_FAX_EXT: this.PRD_BILL_FAX_EXT(),
			PRD_STATE_ADDR1: this.PRD_STATE_ADDR1(),
			PRD_STATE_ADDR2: this.PRD_STATE_ADDR2(),
			PRD_STATE_CITY: this.PRD_STATE_CITY(),
			PRD_STATE_COUNTY: this.PRD_STATE_COUNTY(),
			PRD_STATE_STATE: this.PRD_STATE_STATE(),
			PRD_STATE_COUNTRY: this.PRD_STATE_COUNTRY(),
			PRD_STATE_ZIP: this.PRD_STATE_ZIP(),
			PRD_STATE_TELEPHON: this.PRD_STATE_TELEPHON(),
			PRD_STATE_EXT: this.PRD_STATE_EXT(),
			PRD_STATE_FAX: this.PRD_STATE_FAX(),
			PRD_STATE_FAX_EXT: this.PRD_STATE_FAX_EXT(),
			PRD_ALPHA_SORT: this.PRD_ALPHA_SORT(),
			OfficeCode: this.OfficeCode(),
			PRD_CONSOL_FUNC: this.PRD_CONSOL_FUNC(),
			PRD_CONT_PCT: String(this.PRD_CONT_PCT() || 0),
			PRD_PROD_MARKUP: String(this.PRD_PROD_MARKUP() || 0),
			PRD_PROD_BCYCLE: this.PRD_PROD_BCYCLE(),
			PRD_PROD_BILL_NET: this.PRD_PROD_BILL_NET(),
			PRD_PROD_VEN_DISC: this.PRD_PROD_VEN_DISC(),
			PRD_PROD_ESTIMATE: this.PRD_PROD_ESTIMATE(),
			PRD_PROD_TAX_CODE: this.PRD_PROD_TAX_CODE(),
			PRD_PROD_COMMENTS: this.PRD_PROD_COMMENTS(),
			PRD_MEDIA_BCYCLE: this.PRD_MEDIA_BCYCLE(),
			PRD_RADIO_REBATE: String(this.PRD_RADIO_REBATE() || 0),
			PRD_RADIO_BILL_NET: this.PRD_RADIO_BILL_NET(),
			PRD_RADIO_VEN_DISC: this.PRD_RADIO_VEN_DISC(),
			PRD_RADIO_COM_ONLY: this.PRD_RADIO_COM_ONLY(),
			PRD_RADIO_TAX_CODE: this.PRD_RADIO_TAX_CODE(),
			PRD_RADIO_DAYS: this.PRD_RADIO_DAYS(),
			PRD_RADIO_PRE_POST: this.PRD_RADIO_PRE_POST(),
			PRD_RADIO_BF_AF: this.PRD_RADIO_BF_AF(),
			PRD_TV_REBATE: String(this.PRD_TV_REBATE() || 0),
			PRD_TV_BILL_NET: this.PRD_TV_BILL_NET(),
			PRD_TV_VEN_DISC: this.PRD_TV_VEN_DISC(),
			PRD_TV_COM_ONLY: this.PRD_TV_COM_ONLY(),
			PRD_TV_TAX_CODE: this.PRD_TV_TAX_CODE(),
			PRD_TV_DAYS: this.PRD_TV_DAYS(),
			PRD_TV_PRE_POST: this.PRD_TV_PRE_POST(),
			PRD_TV_BF_AF: this.PRD_TV_BF_AF(),
			PRD_MAG_REBATE: String(this.PRD_MAG_REBATE() || 0),
			PRD_MAG_BILL_NET: this.PRD_MAG_BILL_NET(),
			PRD_MAG_VEN_DISC: this.PRD_MAG_VEN_DISC(),
			PRD_MAG_COM_ONLY: this.PRD_MAG_COM_ONLY(),
			PRD_MAG_TAX_CODE: this.PRD_MAG_TAX_CODE(),
			PRD_MAG_DAYS: this.PRD_MAG_DAYS(),
			PRD_MAG_PRE_POST: this.PRD_MAG_PRE_POST(),
			PRD_MAG_BF_AF: this.PRD_MAG_BF_AF(),
			PRD_NEWS_COMM: String(this.PRD_NEWS_COMM() || 0),
			PRD_NEWS_BILL_NET: this.PRD_NEWS_BILL_NET(),
			PRD_NEWS_VEN_DISC: this.PRD_NEWS_VEN_DISC(),
			PRD_NEWS_COM_ONLY: this.PRD_NEWS_COM_ONLY(),
			PRD_NEWS_TAX_CODE: this.PRD_NEWS_TAX_CODE(),
			PRD_NEWS_DAYS: this.PRD_NEWS_DAYS(),
			PRD_NEWS_PRE_POST: this.PRD_NEWS_PRE_POST(),
			PRD_NEWS_BF_AF: this.PRD_NEWS_BF_AF(),
			PRD_RADIO_COMMENT: this.PRD_RADIO_COMMENT(),
			PRD_SF_BEGIN_DATE: this.PRD_SF_BEGIN_DATE(),
			PRD_SF_NBR_OF_MTHS: this.PRD_SF_NBR_OF_MTHS(),
			PRD_SF_PER_GUARAN: String(this.PRD_SF_PER_GUARAN() || 0),
			PRD_SF_RECON_CODE: this.PRD_SF_RECON_CODE(),
			PRD_SF_BCYCLE: this.PRD_SF_BCYCLE(),
			PRD_SF_TAX_TIME: this.PRD_SF_TAX_TIME(),
			PRD_SF_EMP_TIME: this.PRD_SF_EMP_TIME(),
			PRD_SF_MEDIA_COMM: this.PRD_SF_MEDIA_COMM(),
			PRD_SF_PROD_COMM: this.PRD_SF_PROD_COMM(),
			PRD_SF_AMT: String(this.PRD_SF_AMT() || 0),
			PRD_TV_COMMENT: this.PRD_TV_COMMENT(),
			PRD_MAG_COMMENT: this.PRD_MAG_COMMENT(),
			PRD_NEWS_COMMENT: this.PRD_NEWS_COMMENT(),
			PRD_OTDR_COMMENT: this.PRD_OTDR_COMMENT(),
			PRD_MISC_COMMENT: this.PRD_MISC_COMMENT(),
			PRD_NEWS_REBATE: String(this.PRD_NEWS_REBATE() || 0),
			PRD_OTDR_REBATE: String(this.PRD_OTDR_REBATE() || 0),
			PRD_MISC_REBATE: String(this.PRD_MISC_REBATE() || 0),
			PRD_RADIO_COMM: String(this.PRD_RADIO_COMM() || 0),
			PRD_TV_COMM: String(this.PRD_TV_COMM() || 0),
			PRD_MAG_COMM: String(this.PRD_MAG_COMM() || 0),
			PRD_OTDR_COMM: String(this.PRD_OTDR_COMM() || 0),
			PRD_MISC_COMM: String(this.PRD_MISC_COMM() || 0),
			PRD_OTDR_BF_AF: this.PRD_OTDR_BF_AF(),
			PRD_OTDR_BILL_NET: this.PRD_OTDR_BILL_NET(),
			PRD_OTDR_COM_ONLY: this.PRD_OTDR_COM_ONLY(),
			PRD_OTDR_DAYS: this.PRD_OTDR_DAYS(),
			PRD_OTDR_PRE_POST: this.PRD_OTDR_PRE_POST(),
			PRD_OTDR_TAX_CODE: this.PRD_OTDR_TAX_CODE(),
			PRD_OTDR_VEN_DISC: this.PRD_OTDR_VEN_DISC(),
			PRD_MISC_BF_AF: this.PRD_MISC_BF_AF(),
			PRD_MISC_BILL_NET: this.PRD_MISC_BILL_NET(),
			PRD_MISC_COM_ONLY: this.PRD_MISC_COM_ONLY(),
			PRD_MISC_DAYS: this.PRD_MISC_DAYS(),
			PRD_MISC_PRE_POST: this.PRD_MISC_PRE_POST(),
			PRD_MISC_TAX_CODE: this.PRD_MISC_TAX_CODE(),
			PRD_MISC_VEN_DISC: this.PRD_MISC_VEN_DISC(),
			EMAIL_GR_CODE: this.EMAIL_GR_CODE(),
			TECHNOLOGY_FEE: String(this.TECHNOLOGY_FEE() || 0),
			IsActive: this.IsActive(),
			USER_DEFINED1: this.USER_DEFINED1(),
			USER_DEFINED2: this.USER_DEFINED2(),
			USER_DEFINED3: this.USER_DEFINED3(),
			USER_DEFINED4: this.USER_DEFINED4(),
			BILLED_TIME: this.BILLED_TIME(),
			BILLED_MARKUP: this.BILLED_MARKUP(),
			BILLED_COMM: this.BILLED_COMM(),
			NEWSPAPER: this.NEWSPAPER(),
			MAGAZINE: this.MAGAZINE(),
			RADIO: this.RADIO(),
			TELEVISION: this.TELEVISION(),
			OUTDOOR: this.OUTDOOR(),
			INTERNET: this.INTERNET(),
			USE_TAX_FLAGS_R: this.USE_TAX_FLAGS_R(),
			TAXAPPLYLN_R: this.TAXAPPLYLN_R(),
			TAXAPPLYND_R: this.TAXAPPLYND_R(),
			TAXAPPLYNC_R: this.TAXAPPLYNC_R(),
			TAXAPPLYAI_R: this.TAXAPPLYAI_R(),
			TAXAPPLYC_R: this.TAXAPPLYC_R(),
			TAXAPPLYR_R: this.TAXAPPLYR_R(),
			USE_TAX_FLAGS_T: this.USE_TAX_FLAGS_T(),
			TAXAPPLYLN_T: this.TAXAPPLYLN_T(),
			TAXAPPLYND_T: this.TAXAPPLYND_T(),
			TAXAPPLYNC_T: this.TAXAPPLYNC_T(),
			TAXAPPLYAI_T: this.TAXAPPLYAI_T(),
			TAXAPPLYC_T: this.TAXAPPLYC_T(),
			TAXAPPLYR_T: this.TAXAPPLYR_T(),
			USE_TAX_FLAGS_M: this.USE_TAX_FLAGS_M(),
			TAXAPPLYLN_M: this.TAXAPPLYLN_M(),
			TAXAPPLYND_M: this.TAXAPPLYND_M(),
			TAXAPPLYNC_M: this.TAXAPPLYNC_M(),
			TAXAPPLYAI_M: this.TAXAPPLYAI_M(),
			TAXAPPLYC_M: this.TAXAPPLYC_M(),
			TAXAPPLYR_M: this.TAXAPPLYR_M(),
			USE_TAX_FLAGS_N: this.USE_TAX_FLAGS_N(),
			TAXAPPLYLN_N: this.TAXAPPLYLN_N(),
			TAXAPPLYND_N: this.TAXAPPLYND_N(),
			TAXAPPLYNC_N: this.TAXAPPLYNC_N(),
			TAXAPPLYAI_N: this.TAXAPPLYAI_N(),
			TAXAPPLYC_N: this.TAXAPPLYC_N(),
			TAXAPPLYR_N: this.TAXAPPLYR_N(),
			USE_TAX_FLAGS_O: this.USE_TAX_FLAGS_O(),
			TAXAPPLYLN_O: this.TAXAPPLYLN_O(),
			TAXAPPLYND_O: this.TAXAPPLYND_O(),
			TAXAPPLYNC_O: this.TAXAPPLYNC_O(),
			TAXAPPLYAI_O: this.TAXAPPLYAI_O(),
			TAXAPPLYC_O: this.TAXAPPLYC_O(),
			TAXAPPLYR_O: this.TAXAPPLYR_O(),
			USE_TAX_FLAGS_I: this.USE_TAX_FLAGS_I(),
			TAXAPPLYLN_I: this.TAXAPPLYLN_I(),
			TAXAPPLYND_I: this.TAXAPPLYND_I(),
			TAXAPPLYNC_I: this.TAXAPPLYNC_I(),
			TAXAPPLYAI_I: this.TAXAPPLYAI_I(),
			TAXAPPLYC_I: this.TAXAPPLYC_I(),
			TAXAPPLYR_I: this.TAXAPPLYR_I(),
			PRD_BILL_RATE: String(this.PRD_BILL_RATE() || 0),
			PRD_BILL_EMP_TIME: this.PRD_BILL_EMP_TIME(),
			PROD_SETUP_COMPLETE: this.PROD_SETUP_COMPLETE(),
			RADIO_SETUP_COMPLETE: this.RADIO_SETUP_COMPLETE(),
			TV_SETUP_COMPLETE: this.TV_SETUP_COMPLETE(),
			MAG_SETUP_COMPLETE: this.MAG_SETUP_COMPLETE(),
			NEWS_SETUP_COMPLETE: this.NEWS_SETUP_COMPLETE(),
			OOH_SETUP_COMPLETE: this.OOH_SETUP_COMPLETE(),
			INET_SETUP_COMPLETE: this.INET_SETUP_COMPLETE(),
			USE_EST_BILL_RATE: this.USE_EST_BILL_RATE(),
			CURRENCY_CODE: this.CURRENCY_CODE(),
			BATCH_NAME: this.BATCH_NAME(),
			AVALARA_TAX_EXEMPT_OVERRIDE: this.AVALARA_TAX_EXEMPT_OVERRIDE(),
			PRD_PROD_PAYDAYS: this.PRD_PROD_PAYDAYS(),
			CALC_LATE_FEE: this.CALC_LATE_FEE(),
			LATE_FEE_PERCENT: String(this.LATE_FEE_PERCENT() || 0),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ClientCode(data.ClientCode);
				this.DivisionCode(data.DivisionCode);
				this.Code(data.Code);
				this.Description(data.Description);
				this.PRD_ATTENTION(data.PRD_ATTENTION);
				this.PRD_BILL_ADDRESS1(data.PRD_BILL_ADDRESS1);
				this.PRD_BILL_ADDRESS2(data.PRD_BILL_ADDRESS2);
				this.PRD_BILL_CITY(data.PRD_BILL_CITY);
				this.PRD_BILL_COUNTY(data.PRD_BILL_COUNTY);
				this.PRD_BILL_STATE(data.PRD_BILL_STATE);
				this.PRD_BILL_COUNTRY(data.PRD_BILL_COUNTRY);
				this.PRD_BILL_ZIP(data.PRD_BILL_ZIP);
				this.PRD_BILL_TELEPHONE(data.PRD_BILL_TELEPHONE);
				this.PRD_BILL_EXTENTION(data.PRD_BILL_EXTENTION);
				this.PRD_BILL_FAX(data.PRD_BILL_FAX);
				this.PRD_BILL_FAX_EXT(data.PRD_BILL_FAX_EXT);
				this.PRD_STATE_ADDR1(data.PRD_STATE_ADDR1);
				this.PRD_STATE_ADDR2(data.PRD_STATE_ADDR2);
				this.PRD_STATE_CITY(data.PRD_STATE_CITY);
				this.PRD_STATE_COUNTY(data.PRD_STATE_COUNTY);
				this.PRD_STATE_STATE(data.PRD_STATE_STATE);
				this.PRD_STATE_COUNTRY(data.PRD_STATE_COUNTRY);
				this.PRD_STATE_ZIP(data.PRD_STATE_ZIP);
				this.PRD_STATE_TELEPHON(data.PRD_STATE_TELEPHON);
				this.PRD_STATE_EXT(data.PRD_STATE_EXT);
				this.PRD_STATE_FAX(data.PRD_STATE_FAX);
				this.PRD_STATE_FAX_EXT(data.PRD_STATE_FAX_EXT);
				this.PRD_ALPHA_SORT(data.PRD_ALPHA_SORT);
				this.OfficeCode(data.OfficeCode);
				this.PRD_CONSOL_FUNC(data.PRD_CONSOL_FUNC);
				this.PRD_CONT_PCT(data.PRD_CONT_PCT);
				this.PRD_PROD_MARKUP(data.PRD_PROD_MARKUP);
				this.PRD_PROD_BCYCLE(data.PRD_PROD_BCYCLE);
				this.PRD_PROD_BILL_NET(data.PRD_PROD_BILL_NET);
				this.PRD_PROD_VEN_DISC(data.PRD_PROD_VEN_DISC);
				this.PRD_PROD_ESTIMATE(data.PRD_PROD_ESTIMATE);
				this.PRD_PROD_TAX_CODE(data.PRD_PROD_TAX_CODE);
				this.PRD_PROD_COMMENTS(data.PRD_PROD_COMMENTS);
				this.PRD_MEDIA_BCYCLE(data.PRD_MEDIA_BCYCLE);
				this.PRD_RADIO_REBATE(data.PRD_RADIO_REBATE);
				this.PRD_RADIO_BILL_NET(data.PRD_RADIO_BILL_NET);
				this.PRD_RADIO_VEN_DISC(data.PRD_RADIO_VEN_DISC);
				this.PRD_RADIO_COM_ONLY(data.PRD_RADIO_COM_ONLY);
				this.PRD_RADIO_TAX_CODE(data.PRD_RADIO_TAX_CODE);
				this.PRD_RADIO_DAYS(data.PRD_RADIO_DAYS);
				this.PRD_RADIO_PRE_POST(data.PRD_RADIO_PRE_POST);
				this.PRD_RADIO_BF_AF(data.PRD_RADIO_BF_AF);
				this.PRD_TV_REBATE(data.PRD_TV_REBATE);
				this.PRD_TV_BILL_NET(data.PRD_TV_BILL_NET);
				this.PRD_TV_VEN_DISC(data.PRD_TV_VEN_DISC);
				this.PRD_TV_COM_ONLY(data.PRD_TV_COM_ONLY);
				this.PRD_TV_TAX_CODE(data.PRD_TV_TAX_CODE);
				this.PRD_TV_DAYS(data.PRD_TV_DAYS);
				this.PRD_TV_PRE_POST(data.PRD_TV_PRE_POST);
				this.PRD_TV_BF_AF(data.PRD_TV_BF_AF);
				this.PRD_MAG_REBATE(data.PRD_MAG_REBATE);
				this.PRD_MAG_BILL_NET(data.PRD_MAG_BILL_NET);
				this.PRD_MAG_VEN_DISC(data.PRD_MAG_VEN_DISC);
				this.PRD_MAG_COM_ONLY(data.PRD_MAG_COM_ONLY);
				this.PRD_MAG_TAX_CODE(data.PRD_MAG_TAX_CODE);
				this.PRD_MAG_DAYS(data.PRD_MAG_DAYS);
				this.PRD_MAG_PRE_POST(data.PRD_MAG_PRE_POST);
				this.PRD_MAG_BF_AF(data.PRD_MAG_BF_AF);
				this.PRD_NEWS_COMM(data.PRD_NEWS_COMM);
				this.PRD_NEWS_BILL_NET(data.PRD_NEWS_BILL_NET);
				this.PRD_NEWS_VEN_DISC(data.PRD_NEWS_VEN_DISC);
				this.PRD_NEWS_COM_ONLY(data.PRD_NEWS_COM_ONLY);
				this.PRD_NEWS_TAX_CODE(data.PRD_NEWS_TAX_CODE);
				this.PRD_NEWS_DAYS(data.PRD_NEWS_DAYS);
				this.PRD_NEWS_PRE_POST(data.PRD_NEWS_PRE_POST);
				this.PRD_NEWS_BF_AF(data.PRD_NEWS_BF_AF);
				this.PRD_RADIO_COMMENT(data.PRD_RADIO_COMMENT);
				this.PRD_SF_BEGIN_DATE(data.PRD_SF_BEGIN_DATE);
				this.PRD_SF_NBR_OF_MTHS(data.PRD_SF_NBR_OF_MTHS);
				this.PRD_SF_PER_GUARAN(data.PRD_SF_PER_GUARAN);
				this.PRD_SF_RECON_CODE(data.PRD_SF_RECON_CODE);
				this.PRD_SF_BCYCLE(data.PRD_SF_BCYCLE);
				this.PRD_SF_TAX_TIME(data.PRD_SF_TAX_TIME);
				this.PRD_SF_EMP_TIME(data.PRD_SF_EMP_TIME);
				this.PRD_SF_MEDIA_COMM(data.PRD_SF_MEDIA_COMM);
				this.PRD_SF_PROD_COMM(data.PRD_SF_PROD_COMM);
				this.PRD_SF_AMT(data.PRD_SF_AMT);
				this.PRD_TV_COMMENT(data.PRD_TV_COMMENT);
				this.PRD_MAG_COMMENT(data.PRD_MAG_COMMENT);
				this.PRD_NEWS_COMMENT(data.PRD_NEWS_COMMENT);
				this.PRD_OTDR_COMMENT(data.PRD_OTDR_COMMENT);
				this.PRD_MISC_COMMENT(data.PRD_MISC_COMMENT);
				this.PRD_NEWS_REBATE(data.PRD_NEWS_REBATE);
				this.PRD_OTDR_REBATE(data.PRD_OTDR_REBATE);
				this.PRD_MISC_REBATE(data.PRD_MISC_REBATE);
				this.PRD_RADIO_COMM(data.PRD_RADIO_COMM);
				this.PRD_TV_COMM(data.PRD_TV_COMM);
				this.PRD_MAG_COMM(data.PRD_MAG_COMM);
				this.PRD_OTDR_COMM(data.PRD_OTDR_COMM);
				this.PRD_MISC_COMM(data.PRD_MISC_COMM);
				this.PRD_OTDR_BF_AF(data.PRD_OTDR_BF_AF);
				this.PRD_OTDR_BILL_NET(data.PRD_OTDR_BILL_NET);
				this.PRD_OTDR_COM_ONLY(data.PRD_OTDR_COM_ONLY);
				this.PRD_OTDR_DAYS(data.PRD_OTDR_DAYS);
				this.PRD_OTDR_PRE_POST(data.PRD_OTDR_PRE_POST);
				this.PRD_OTDR_TAX_CODE(data.PRD_OTDR_TAX_CODE);
				this.PRD_OTDR_VEN_DISC(data.PRD_OTDR_VEN_DISC);
				this.PRD_MISC_BF_AF(data.PRD_MISC_BF_AF);
				this.PRD_MISC_BILL_NET(data.PRD_MISC_BILL_NET);
				this.PRD_MISC_COM_ONLY(data.PRD_MISC_COM_ONLY);
				this.PRD_MISC_DAYS(data.PRD_MISC_DAYS);
				this.PRD_MISC_PRE_POST(data.PRD_MISC_PRE_POST);
				this.PRD_MISC_TAX_CODE(data.PRD_MISC_TAX_CODE);
				this.PRD_MISC_VEN_DISC(data.PRD_MISC_VEN_DISC);
				this.EMAIL_GR_CODE(data.EMAIL_GR_CODE);
				this.TECHNOLOGY_FEE(data.TECHNOLOGY_FEE);
				this.IsActive(data.IsActive);
				this.USER_DEFINED1(data.USER_DEFINED1);
				this.USER_DEFINED2(data.USER_DEFINED2);
				this.USER_DEFINED3(data.USER_DEFINED3);
				this.USER_DEFINED4(data.USER_DEFINED4);
				this.BILLED_TIME(data.BILLED_TIME);
				this.BILLED_MARKUP(data.BILLED_MARKUP);
				this.BILLED_COMM(data.BILLED_COMM);
				this.NEWSPAPER(data.NEWSPAPER);
				this.MAGAZINE(data.MAGAZINE);
				this.RADIO(data.RADIO);
				this.TELEVISION(data.TELEVISION);
				this.OUTDOOR(data.OUTDOOR);
				this.INTERNET(data.INTERNET);
				this.USE_TAX_FLAGS_R(data.USE_TAX_FLAGS_R);
				this.TAXAPPLYLN_R(data.TAXAPPLYLN_R);
				this.TAXAPPLYND_R(data.TAXAPPLYND_R);
				this.TAXAPPLYNC_R(data.TAXAPPLYNC_R);
				this.TAXAPPLYAI_R(data.TAXAPPLYAI_R);
				this.TAXAPPLYC_R(data.TAXAPPLYC_R);
				this.TAXAPPLYR_R(data.TAXAPPLYR_R);
				this.USE_TAX_FLAGS_T(data.USE_TAX_FLAGS_T);
				this.TAXAPPLYLN_T(data.TAXAPPLYLN_T);
				this.TAXAPPLYND_T(data.TAXAPPLYND_T);
				this.TAXAPPLYNC_T(data.TAXAPPLYNC_T);
				this.TAXAPPLYAI_T(data.TAXAPPLYAI_T);
				this.TAXAPPLYC_T(data.TAXAPPLYC_T);
				this.TAXAPPLYR_T(data.TAXAPPLYR_T);
				this.USE_TAX_FLAGS_M(data.USE_TAX_FLAGS_M);
				this.TAXAPPLYLN_M(data.TAXAPPLYLN_M);
				this.TAXAPPLYND_M(data.TAXAPPLYND_M);
				this.TAXAPPLYNC_M(data.TAXAPPLYNC_M);
				this.TAXAPPLYAI_M(data.TAXAPPLYAI_M);
				this.TAXAPPLYC_M(data.TAXAPPLYC_M);
				this.TAXAPPLYR_M(data.TAXAPPLYR_M);
				this.USE_TAX_FLAGS_N(data.USE_TAX_FLAGS_N);
				this.TAXAPPLYLN_N(data.TAXAPPLYLN_N);
				this.TAXAPPLYND_N(data.TAXAPPLYND_N);
				this.TAXAPPLYNC_N(data.TAXAPPLYNC_N);
				this.TAXAPPLYAI_N(data.TAXAPPLYAI_N);
				this.TAXAPPLYC_N(data.TAXAPPLYC_N);
				this.TAXAPPLYR_N(data.TAXAPPLYR_N);
				this.USE_TAX_FLAGS_O(data.USE_TAX_FLAGS_O);
				this.TAXAPPLYLN_O(data.TAXAPPLYLN_O);
				this.TAXAPPLYND_O(data.TAXAPPLYND_O);
				this.TAXAPPLYNC_O(data.TAXAPPLYNC_O);
				this.TAXAPPLYAI_O(data.TAXAPPLYAI_O);
				this.TAXAPPLYC_O(data.TAXAPPLYC_O);
				this.TAXAPPLYR_O(data.TAXAPPLYR_O);
				this.USE_TAX_FLAGS_I(data.USE_TAX_FLAGS_I);
				this.TAXAPPLYLN_I(data.TAXAPPLYLN_I);
				this.TAXAPPLYND_I(data.TAXAPPLYND_I);
				this.TAXAPPLYNC_I(data.TAXAPPLYNC_I);
				this.TAXAPPLYAI_I(data.TAXAPPLYAI_I);
				this.TAXAPPLYC_I(data.TAXAPPLYC_I);
				this.TAXAPPLYR_I(data.TAXAPPLYR_I);
				this.PRD_BILL_RATE(data.PRD_BILL_RATE);
				this.PRD_BILL_EMP_TIME(data.PRD_BILL_EMP_TIME);
				this.PROD_SETUP_COMPLETE(data.PROD_SETUP_COMPLETE);
				this.RADIO_SETUP_COMPLETE(data.RADIO_SETUP_COMPLETE);
				this.TV_SETUP_COMPLETE(data.TV_SETUP_COMPLETE);
				this.MAG_SETUP_COMPLETE(data.MAG_SETUP_COMPLETE);
				this.NEWS_SETUP_COMPLETE(data.NEWS_SETUP_COMPLETE);
				this.OOH_SETUP_COMPLETE(data.OOH_SETUP_COMPLETE);
				this.INET_SETUP_COMPLETE(data.INET_SETUP_COMPLETE);
				this.USE_EST_BILL_RATE(data.USE_EST_BILL_RATE);
				this.CURRENCY_CODE(data.CURRENCY_CODE);
				this.BATCH_NAME(data.BATCH_NAME);
				this.AVALARA_TAX_EXEMPT_OVERRIDE(data.AVALARA_TAX_EXEMPT_OVERRIDE);
				this.PRD_PROD_PAYDAYS(data.PRD_PROD_PAYDAYS);
				this.CALC_LATE_FEE(data.CALC_LATE_FEE);
				this.LATE_FEE_PERCENT(data.LATE_FEE_PERCENT);
		
            }
        }
    });
})();