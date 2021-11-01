
(function() {
    AdvantageMobile_UI.AgencyViewModel = function(data) {
				this.NAME = ko.observable();
				this.ADDRESS1 = ko.observable();
				this.ADDRESS2 = ko.observable();
				this.CITY = ko.observable();
				this.STATE = ko.observable();
				this.ZIP = ko.observable();
				this.COUNTRY = ko.observable();
				this.PHONE = ko.observable();
				this.AUTO_EST_REV = ko.observable();
				this.WIP_EMP_COST = ko.observable();
				this.WIP_EMP_NBCOST = ko.observable();
				this.MAG_COMMENT = ko.observable();
				this.NEWS_COMMENT = ko.observable();
				this.OTDR_COMMENT = ko.observable();
				this.RADIO_COMMENT = ko.observable();
				this.TV_COMMENT = ko.observable();
				this.MD_INTERFACE = ko.observable();
				this.MAC_EXPORT = ko.observable();
				this.MD_RENAME = ko.observable();
				this.AUTO_EMAIL = ko.observable();
				this.DELETE_INVOICE = ko.observable();
				this.WH_VENDOR = ko.observable();
				this.AP_VOLUME_DISC = ko.observable();
				this.LOGO = ko.observable();
				this.BASE_AMT = ko.observable();
				this.IND_PCT = ko.observable();
				this.IND_WAIVER_PCT = ko.observable();
				this.NON_I_PCT = ko.observable();
				this.NON_I_WAIVER_PCT = ko.observable();
				this.INC_BILL_RATE = ko.observable();
				this.FLAG_TAX_JOBS = ko.observable();
				this.CLIENT_REF = ko.observable();
				this.CMP_BUDGET_CODE = ko.observable();
				this.QA_PWD_REQ = ko.observable();
				this.ET_BATCH = ko.observable();
				this.COPY_TS = ko.observable();
				this.IMPORT_PATH = ko.observable();
				this.CHECK_FORMAT = ko.observable();
				this.ASP_ACTIVE = ko.observable();
				this.DEF_EMAIL_GROUP = ko.observable();
				this.VALIDATE_JOB_CLOSE = ko.observable();
				this.TS_DAYS_PER_WK = ko.observable();
				this.TS_ADMIN_APPROVE = ko.observable();
				this.TS_PPERIOD_CHK = ko.observable();
				this.ENABLE_ATTACHMENTS = ko.observable();
				this.CMP_CODE_R = ko.observable();
				this.ACCT_NBR_R = ko.observable();
				this.JT_CODE_R = ko.observable();
				this.PROMO_CODE_R = ko.observable();
				this.EDIT_OFFICE = ko.observable();
				this.EMP_NOTES = ko.observable();
				this.LICENSE_KEY = ko.observable();
				this.AP_IMPORT_TYPE = ko.observable();
				this.IO_IMPORT_TYPE = ko.observable();
				this.MRP_DSN = ko.observable();
				this.PDF_GENERATOR = ko.observable();
				this.JOB_FIRST_USE_DT_R = ko.observable();
				this.COMPLEX_CODE_R = ko.observable();
				this.FORMAT_SC_CODE_R = ko.observable();
				this.DP_TM_CODE_R = ko.observable();
				this.MARKET_CODE_R = ko.observable();
				this.EMAIL_GR_CODE_R = ko.observable();
				this.BILL_COOP_CODE_R = ko.observable();
				this.AD_NBR_R = ko.observable();
				this.NOBILL_FLAG_H = ko.observable();
				this.SPELL_LIC_KEY = ko.observable();
				this.SMTP_SERVER = ko.observable();
				this.SMTP_SENDER = ko.observable();
				this.SMTP_SENDER_PWD = ko.observable();
				this.CR_AR_DESC = ko.observable();
				this.DEF_EST_RPT = ko.observable();
				this.DEF_EST_DT_ENTER = ko.observable();
				this.DEF_EST_DT_PRINT = ko.observable();
				this.DEF_EST_SUPPRESS = ko.observable();
				this.DEF_EST_INC_CONT = ko.observable();
				this.DEF_PO_RPT = ko.observable();
				this.DEF_PO_DT_ENTER = ko.observable();
				this.DEF_PO_DT_PRINT = ko.observable();
				this.MC_URL = ko.observable();
				this.MC_ACCT_ID = ko.observable();
				this.AP_OFFICE = ko.observable();
				this.INTER_COMPANY = ko.observable();
				this.FLAG_1099 = ko.observable();
				this.AP_PO_MESSAGE = ko.observable();
				this.AP_PO_REJECT = ko.observable();
				this.AP_CALC_PO = ko.observable();
				this.AP_PO_MESSAGE_TEXT = ko.observable();
				this.AP_PO_REJECT_TEXT = ko.observable();
				this.AP_LOCK_GLCODE = ko.observable();
				this.VN_ACCT_NBR = ko.observable();
				this.VN_PAY_TO_INFO = ko.observable();
				this.GL_FILTER = ko.observable();
				this.JOB_CLI_REF_R = ko.observable();
				this.JOB_DATE_OPENED_R = ko.observable();
				this.JOB_AD_SIZE_R = ko.observable();
				this.PROD_CONT_CODE_R = ko.observable();
				this.JOB_COMP_BUDGET_R = ko.observable();
				this.ALLOW_VN_EMAIL = ko.observable();
				this.ALLOW_CL_EMAIL = ko.observable();
				this.EMP_ON_ALERT_LIST = ko.observable();
				this.EMAIL_USERNAME = ko.observable();
				this.EMAIL_PWD = ko.observable();
				this.QVA_QUERY = ko.observable();
				this.BILL_SELECT_ALERT = ko.observable();
				this.MC_ACTIVE = ko.observable();
				this.PENDING_TIME_OFF = ko.observable();
				this.START_END_TIME = ko.observable();
				this.TimeApprovalActive = ko.observable();
				this.APPR_EST_REQ = ko.observable();
				this.EDIT_JOB_REQ_EST = ko.observable();
				this.INET_COMMENT = ko.observable();
				this.NON_CLIENT_GL_DET = ko.observable();
				this.START_DATE_R = ko.observable();
				this.EST_COMMENT = ko.observable();
				this.MC_ACCT_PWD = ko.observable();
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
				this.MAR_CB_ACTIVE = ko.observable();
				this.PO_AMT_REQ = ko.observable();
				this.EDIT_OTHER_TIME = ko.observable();
				this.CURRENCY_SYMBOL = ko.observable();
				this.CURRENCY_TEXT = ko.observable();
				this.COIN_TEXT = ko.observable();
				this.TIME_COMMENTS_REQ = ko.observable();
				this.USE_SMTP_FOR_PDF = ko.observable();
				this.USE_PROD_CAT = ko.observable();
				this.PO_FOOTER = ko.observable();
				this.STRATA_PATH = ko.observable();
				this.TAX_FLAG_R = ko.observable();
				this.IT_CONTACT_EMAIL = ko.observable();
				this.EMAIL_IT_CONTACT = ko.observable();
				this.EMAIL_SUPERVISOR = ko.observable();
				this.WEEKLY_TIME = ko.observable();
				this.DOC_REPOSITORY_PATH = ko.observable();
				this.DOC_REPOSITORY_USER_DOMAIN = ko.observable();
				this.DOC_REPOSITORY_USER_NAME = ko.observable();
				this.DOC_REPOSITORY_USER_PASSWORD = ko.observable();
				this.WORD_CHECK_AMT = ko.observable();
				this.BILL_MEDIA_TYPE = ko.observable();
				this.CHK_STUB_LINES_UP = ko.observable();
				this.CHK_BODY_LINES_DN = ko.observable();
				this.AP_ACCT_OFF_IMP = ko.observable();
				this.FISCAL_PD_R = ko.observable();
				this.BLACKPLATE_VER_R = ko.observable();
				this.BLACKPLATE_VER2_R = ko.observable();
				this.ACCESS_RPT_PATH = ko.observable();
				this.CONTACT_OPT = ko.observable();
				this.AP_APPROVAL = ko.observable();
				this.AP_APP_PRINT_PCT = ko.observable();
				this.AP_APP_INET_PCT = ko.observable();
				this.AP_APP_OOH_PCT = ko.observable();
				this.PDF_ALERT_ONLY = ko.observable();
				this.ALERT_NOTIFY = ko.observable();
				this.WEBVANTAGE_URL = ko.observable();
				this.TR_TITLE1 = ko.observable();
				this.TR_TITLE2 = ko.observable();
				this.TR_TITLE3 = ko.observable();
				this.TR_TITLE4 = ko.observable();
				this.TR_TITLE5 = ko.observable();
				this.TRF_HRS = ko.observable();
				this.TRF_SCHEDULE_BY = ko.observable();
				this.TRF_LOCK_DATE = ko.observable();
				this.TRF_CALC_BY_CMP = ko.observable();
				this.AUTO_ALERT_SUPER = ko.observable();
				this.SMTP_AUTH_METHOD = ko.observable();
				this.SMTP_PORT_NUMBER = ko.observable();
				this.EMAIL_REPLY_TO = ko.observable();
				this.SMTP_SECURE_TYPE = ko.observable();
				this.MB_KEY = ko.observable();
				this.SMTP_USE_EMP_LOGIN = ko.observable();
				this.SMTP_USE_EMP_FROM = ko.observable();
				this.CRNCY_IMPORT_TYPE = ko.observable();
				this.MULTI_CRNCY = ko.observable();
				this.HOME_CRNCY = ko.observable();
				this.ACCESS_TMP_PATH = ko.observable();
				this.EMAIL_ATTACH_DEF = ko.observable();
				this.POP3_SERVER = ko.observable();
				this.POP3_PORT_NUMBER = ko.observable();
				this.POP3_USERNAME = ko.observable();
				this.POP3_PWD = ko.observable();
				this.POP3_DEL_PROCESSED = ko.observable();
				this.POP3_REPLY_TO = ko.observable();
				this.POP3_AUTH_METHOD = ko.observable();
				this.POP3_SECURE_TYPE = ko.observable();
				this.AP_APP_TV_PCT = ko.observable();
				this.AP_APP_RADIO_PCT = ko.observable();
				this.SERVICE_FEE_TYPE_R = ko.observable();
				this.COUNTY = ko.observable();
				this.COS_ENTRY_FLAG = ko.observable();
				this.INV_TAX_FLAG = ko.observable();
				this.DB_TIMEZONE_ID = ko.observable();
				this.TIMEZONE_ID = ko.observable();
				this.EDIT_CDP = ko.observable();
				this.TS_COPY_HRS = ko.observable();
				this.CLIENTPORTAL_URL = ko.observable();
				this.DB_CULTURE_CODE = ko.observable();
				this.CULTURE_CODE = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AgencyViewModel.prototype, {
        toJS: function() {
            return {
			NAME: this.NAME(),
			ADDRESS1: this.ADDRESS1(),
			ADDRESS2: this.ADDRESS2(),
			CITY: this.CITY(),
			STATE: this.STATE(),
			ZIP: this.ZIP(),
			COUNTRY: this.COUNTRY(),
			PHONE: this.PHONE(),
			AUTO_EST_REV: this.AUTO_EST_REV(),
			WIP_EMP_COST: this.WIP_EMP_COST(),
			WIP_EMP_NBCOST: this.WIP_EMP_NBCOST(),
			MAG_COMMENT: this.MAG_COMMENT(),
			NEWS_COMMENT: this.NEWS_COMMENT(),
			OTDR_COMMENT: this.OTDR_COMMENT(),
			RADIO_COMMENT: this.RADIO_COMMENT(),
			TV_COMMENT: this.TV_COMMENT(),
			MD_INTERFACE: this.MD_INTERFACE(),
			MAC_EXPORT: this.MAC_EXPORT(),
			MD_RENAME: this.MD_RENAME(),
			AUTO_EMAIL: this.AUTO_EMAIL(),
			DELETE_INVOICE: this.DELETE_INVOICE(),
			WH_VENDOR: this.WH_VENDOR(),
			AP_VOLUME_DISC: this.AP_VOLUME_DISC(),
			LOGO: this.LOGO(),
			BASE_AMT: String(this.BASE_AMT() || 0),
			IND_PCT: String(this.IND_PCT() || 0),
			IND_WAIVER_PCT: String(this.IND_WAIVER_PCT() || 0),
			NON_I_PCT: String(this.NON_I_PCT() || 0),
			NON_I_WAIVER_PCT: String(this.NON_I_WAIVER_PCT() || 0),
			INC_BILL_RATE: this.INC_BILL_RATE(),
			FLAG_TAX_JOBS: this.FLAG_TAX_JOBS(),
			CLIENT_REF: this.CLIENT_REF(),
			CMP_BUDGET_CODE: this.CMP_BUDGET_CODE(),
			QA_PWD_REQ: this.QA_PWD_REQ(),
			ET_BATCH: this.ET_BATCH(),
			COPY_TS: this.COPY_TS(),
			IMPORT_PATH: this.IMPORT_PATH(),
			CHECK_FORMAT: this.CHECK_FORMAT(),
			ASP_ACTIVE: this.ASP_ACTIVE(),
			DEF_EMAIL_GROUP: this.DEF_EMAIL_GROUP(),
			VALIDATE_JOB_CLOSE: this.VALIDATE_JOB_CLOSE(),
			TS_DAYS_PER_WK: this.TS_DAYS_PER_WK(),
			TS_ADMIN_APPROVE: this.TS_ADMIN_APPROVE(),
			TS_PPERIOD_CHK: this.TS_PPERIOD_CHK(),
			ENABLE_ATTACHMENTS: this.ENABLE_ATTACHMENTS(),
			CMP_CODE_R: this.CMP_CODE_R(),
			ACCT_NBR_R: this.ACCT_NBR_R(),
			JT_CODE_R: this.JT_CODE_R(),
			PROMO_CODE_R: this.PROMO_CODE_R(),
			EDIT_OFFICE: this.EDIT_OFFICE(),
			EMP_NOTES: this.EMP_NOTES(),
			LICENSE_KEY: this.LICENSE_KEY(),
			AP_IMPORT_TYPE: this.AP_IMPORT_TYPE(),
			IO_IMPORT_TYPE: this.IO_IMPORT_TYPE(),
			MRP_DSN: this.MRP_DSN(),
			PDF_GENERATOR: this.PDF_GENERATOR(),
			JOB_FIRST_USE_DT_R: this.JOB_FIRST_USE_DT_R(),
			COMPLEX_CODE_R: this.COMPLEX_CODE_R(),
			FORMAT_SC_CODE_R: this.FORMAT_SC_CODE_R(),
			DP_TM_CODE_R: this.DP_TM_CODE_R(),
			MARKET_CODE_R: this.MARKET_CODE_R(),
			EMAIL_GR_CODE_R: this.EMAIL_GR_CODE_R(),
			BILL_COOP_CODE_R: this.BILL_COOP_CODE_R(),
			AD_NBR_R: this.AD_NBR_R(),
			NOBILL_FLAG_H: this.NOBILL_FLAG_H(),
			SPELL_LIC_KEY: this.SPELL_LIC_KEY(),
			SMTP_SERVER: this.SMTP_SERVER(),
			SMTP_SENDER: this.SMTP_SENDER(),
			SMTP_SENDER_PWD: this.SMTP_SENDER_PWD(),
			CR_AR_DESC: this.CR_AR_DESC(),
			DEF_EST_RPT: this.DEF_EST_RPT(),
			DEF_EST_DT_ENTER: this.DEF_EST_DT_ENTER(),
			DEF_EST_DT_PRINT: this.DEF_EST_DT_PRINT(),
			DEF_EST_SUPPRESS: this.DEF_EST_SUPPRESS(),
			DEF_EST_INC_CONT: this.DEF_EST_INC_CONT(),
			DEF_PO_RPT: this.DEF_PO_RPT(),
			DEF_PO_DT_ENTER: this.DEF_PO_DT_ENTER(),
			DEF_PO_DT_PRINT: this.DEF_PO_DT_PRINT(),
			MC_URL: this.MC_URL(),
			MC_ACCT_ID: this.MC_ACCT_ID(),
			AP_OFFICE: this.AP_OFFICE(),
			INTER_COMPANY: this.INTER_COMPANY(),
			FLAG_1099: this.FLAG_1099(),
			AP_PO_MESSAGE: this.AP_PO_MESSAGE(),
			AP_PO_REJECT: this.AP_PO_REJECT(),
			AP_CALC_PO: this.AP_CALC_PO(),
			AP_PO_MESSAGE_TEXT: this.AP_PO_MESSAGE_TEXT(),
			AP_PO_REJECT_TEXT: this.AP_PO_REJECT_TEXT(),
			AP_LOCK_GLCODE: this.AP_LOCK_GLCODE(),
			VN_ACCT_NBR: this.VN_ACCT_NBR(),
			VN_PAY_TO_INFO: this.VN_PAY_TO_INFO(),
			GL_FILTER: this.GL_FILTER(),
			JOB_CLI_REF_R: this.JOB_CLI_REF_R(),
			JOB_DATE_OPENED_R: this.JOB_DATE_OPENED_R(),
			JOB_AD_SIZE_R: this.JOB_AD_SIZE_R(),
			PROD_CONT_CODE_R: this.PROD_CONT_CODE_R(),
			JOB_COMP_BUDGET_R: this.JOB_COMP_BUDGET_R(),
			ALLOW_VN_EMAIL: this.ALLOW_VN_EMAIL(),
			ALLOW_CL_EMAIL: this.ALLOW_CL_EMAIL(),
			EMP_ON_ALERT_LIST: this.EMP_ON_ALERT_LIST(),
			EMAIL_USERNAME: this.EMAIL_USERNAME(),
			EMAIL_PWD: this.EMAIL_PWD(),
			QVA_QUERY: this.QVA_QUERY(),
			BILL_SELECT_ALERT: this.BILL_SELECT_ALERT(),
			MC_ACTIVE: this.MC_ACTIVE(),
			PENDING_TIME_OFF: this.PENDING_TIME_OFF(),
			START_END_TIME: this.START_END_TIME(),
			TimeApprovalActive: this.TimeApprovalActive(),
			APPR_EST_REQ: this.APPR_EST_REQ(),
			EDIT_JOB_REQ_EST: this.EDIT_JOB_REQ_EST(),
			INET_COMMENT: this.INET_COMMENT(),
			NON_CLIENT_GL_DET: this.NON_CLIENT_GL_DET(),
			START_DATE_R: this.START_DATE_R(),
			EST_COMMENT: this.EST_COMMENT(),
			MC_ACCT_PWD: this.MC_ACCT_PWD(),
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
			MAR_CB_ACTIVE: this.MAR_CB_ACTIVE(),
			PO_AMT_REQ: this.PO_AMT_REQ(),
			EDIT_OTHER_TIME: this.EDIT_OTHER_TIME(),
			CURRENCY_SYMBOL: this.CURRENCY_SYMBOL(),
			CURRENCY_TEXT: this.CURRENCY_TEXT(),
			COIN_TEXT: this.COIN_TEXT(),
			TIME_COMMENTS_REQ: this.TIME_COMMENTS_REQ(),
			USE_SMTP_FOR_PDF: this.USE_SMTP_FOR_PDF(),
			USE_PROD_CAT: this.USE_PROD_CAT(),
			PO_FOOTER: this.PO_FOOTER(),
			STRATA_PATH: this.STRATA_PATH(),
			TAX_FLAG_R: this.TAX_FLAG_R(),
			IT_CONTACT_EMAIL: this.IT_CONTACT_EMAIL(),
			EMAIL_IT_CONTACT: this.EMAIL_IT_CONTACT(),
			EMAIL_SUPERVISOR: this.EMAIL_SUPERVISOR(),
			WEEKLY_TIME: this.WEEKLY_TIME(),
			DOC_REPOSITORY_PATH: this.DOC_REPOSITORY_PATH(),
			DOC_REPOSITORY_USER_DOMAIN: this.DOC_REPOSITORY_USER_DOMAIN(),
			DOC_REPOSITORY_USER_NAME: this.DOC_REPOSITORY_USER_NAME(),
			DOC_REPOSITORY_USER_PASSWORD: this.DOC_REPOSITORY_USER_PASSWORD(),
			WORD_CHECK_AMT: this.WORD_CHECK_AMT(),
			BILL_MEDIA_TYPE: this.BILL_MEDIA_TYPE(),
			CHK_STUB_LINES_UP: this.CHK_STUB_LINES_UP(),
			CHK_BODY_LINES_DN: this.CHK_BODY_LINES_DN(),
			AP_ACCT_OFF_IMP: this.AP_ACCT_OFF_IMP(),
			FISCAL_PD_R: this.FISCAL_PD_R(),
			BLACKPLATE_VER_R: this.BLACKPLATE_VER_R(),
			BLACKPLATE_VER2_R: this.BLACKPLATE_VER2_R(),
			ACCESS_RPT_PATH: this.ACCESS_RPT_PATH(),
			CONTACT_OPT: this.CONTACT_OPT(),
			AP_APPROVAL: this.AP_APPROVAL(),
			AP_APP_PRINT_PCT: String(this.AP_APP_PRINT_PCT() || 0),
			AP_APP_INET_PCT: String(this.AP_APP_INET_PCT() || 0),
			AP_APP_OOH_PCT: String(this.AP_APP_OOH_PCT() || 0),
			PDF_ALERT_ONLY: this.PDF_ALERT_ONLY(),
			ALERT_NOTIFY: this.ALERT_NOTIFY(),
			WEBVANTAGE_URL: this.WEBVANTAGE_URL(),
			TR_TITLE1: this.TR_TITLE1(),
			TR_TITLE2: this.TR_TITLE2(),
			TR_TITLE3: this.TR_TITLE3(),
			TR_TITLE4: this.TR_TITLE4(),
			TR_TITLE5: this.TR_TITLE5(),
			TRF_HRS: String(this.TRF_HRS() || 0),
			TRF_SCHEDULE_BY: this.TRF_SCHEDULE_BY(),
			TRF_LOCK_DATE: this.TRF_LOCK_DATE(),
			TRF_CALC_BY_CMP: this.TRF_CALC_BY_CMP(),
			AUTO_ALERT_SUPER: this.AUTO_ALERT_SUPER(),
			SMTP_AUTH_METHOD: this.SMTP_AUTH_METHOD(),
			SMTP_PORT_NUMBER: this.SMTP_PORT_NUMBER(),
			EMAIL_REPLY_TO: this.EMAIL_REPLY_TO(),
			SMTP_SECURE_TYPE: this.SMTP_SECURE_TYPE(),
			MB_KEY: this.MB_KEY(),
			SMTP_USE_EMP_LOGIN: this.SMTP_USE_EMP_LOGIN(),
			SMTP_USE_EMP_FROM: this.SMTP_USE_EMP_FROM(),
			CRNCY_IMPORT_TYPE: this.CRNCY_IMPORT_TYPE(),
			MULTI_CRNCY: this.MULTI_CRNCY(),
			HOME_CRNCY: this.HOME_CRNCY(),
			ACCESS_TMP_PATH: this.ACCESS_TMP_PATH(),
			EMAIL_ATTACH_DEF: this.EMAIL_ATTACH_DEF(),
			POP3_SERVER: this.POP3_SERVER(),
			POP3_PORT_NUMBER: this.POP3_PORT_NUMBER(),
			POP3_USERNAME: this.POP3_USERNAME(),
			POP3_PWD: this.POP3_PWD(),
			POP3_DEL_PROCESSED: this.POP3_DEL_PROCESSED(),
			POP3_REPLY_TO: this.POP3_REPLY_TO(),
			POP3_AUTH_METHOD: this.POP3_AUTH_METHOD(),
			POP3_SECURE_TYPE: this.POP3_SECURE_TYPE(),
			AP_APP_TV_PCT: String(this.AP_APP_TV_PCT() || 0),
			AP_APP_RADIO_PCT: String(this.AP_APP_RADIO_PCT() || 0),
			SERVICE_FEE_TYPE_R: this.SERVICE_FEE_TYPE_R(),
			COUNTY: this.COUNTY(),
			COS_ENTRY_FLAG: this.COS_ENTRY_FLAG(),
			INV_TAX_FLAG: this.INV_TAX_FLAG(),
			DB_TIMEZONE_ID: this.DB_TIMEZONE_ID(),
			TIMEZONE_ID: this.TIMEZONE_ID(),
			EDIT_CDP: this.EDIT_CDP(),
			TS_COPY_HRS: this.TS_COPY_HRS(),
			CLIENTPORTAL_URL: this.CLIENTPORTAL_URL(),
			DB_CULTURE_CODE: this.DB_CULTURE_CODE(),
			CULTURE_CODE: this.CULTURE_CODE(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.NAME(data.NAME);
				this.ADDRESS1(data.ADDRESS1);
				this.ADDRESS2(data.ADDRESS2);
				this.CITY(data.CITY);
				this.STATE(data.STATE);
				this.ZIP(data.ZIP);
				this.COUNTRY(data.COUNTRY);
				this.PHONE(data.PHONE);
				this.AUTO_EST_REV(data.AUTO_EST_REV);
				this.WIP_EMP_COST(data.WIP_EMP_COST);
				this.WIP_EMP_NBCOST(data.WIP_EMP_NBCOST);
				this.MAG_COMMENT(data.MAG_COMMENT);
				this.NEWS_COMMENT(data.NEWS_COMMENT);
				this.OTDR_COMMENT(data.OTDR_COMMENT);
				this.RADIO_COMMENT(data.RADIO_COMMENT);
				this.TV_COMMENT(data.TV_COMMENT);
				this.MD_INTERFACE(data.MD_INTERFACE);
				this.MAC_EXPORT(data.MAC_EXPORT);
				this.MD_RENAME(data.MD_RENAME);
				this.AUTO_EMAIL(data.AUTO_EMAIL);
				this.DELETE_INVOICE(data.DELETE_INVOICE);
				this.WH_VENDOR(data.WH_VENDOR);
				this.AP_VOLUME_DISC(data.AP_VOLUME_DISC);
				this.LOGO(data.LOGO);
				this.BASE_AMT(data.BASE_AMT);
				this.IND_PCT(data.IND_PCT);
				this.IND_WAIVER_PCT(data.IND_WAIVER_PCT);
				this.NON_I_PCT(data.NON_I_PCT);
				this.NON_I_WAIVER_PCT(data.NON_I_WAIVER_PCT);
				this.INC_BILL_RATE(data.INC_BILL_RATE);
				this.FLAG_TAX_JOBS(data.FLAG_TAX_JOBS);
				this.CLIENT_REF(data.CLIENT_REF);
				this.CMP_BUDGET_CODE(data.CMP_BUDGET_CODE);
				this.QA_PWD_REQ(data.QA_PWD_REQ);
				this.ET_BATCH(data.ET_BATCH);
				this.COPY_TS(data.COPY_TS);
				this.IMPORT_PATH(data.IMPORT_PATH);
				this.CHECK_FORMAT(data.CHECK_FORMAT);
				this.ASP_ACTIVE(data.ASP_ACTIVE);
				this.DEF_EMAIL_GROUP(data.DEF_EMAIL_GROUP);
				this.VALIDATE_JOB_CLOSE(data.VALIDATE_JOB_CLOSE);
				this.TS_DAYS_PER_WK(data.TS_DAYS_PER_WK);
				this.TS_ADMIN_APPROVE(data.TS_ADMIN_APPROVE);
				this.TS_PPERIOD_CHK(data.TS_PPERIOD_CHK);
				this.ENABLE_ATTACHMENTS(data.ENABLE_ATTACHMENTS);
				this.CMP_CODE_R(data.CMP_CODE_R);
				this.ACCT_NBR_R(data.ACCT_NBR_R);
				this.JT_CODE_R(data.JT_CODE_R);
				this.PROMO_CODE_R(data.PROMO_CODE_R);
				this.EDIT_OFFICE(data.EDIT_OFFICE);
				this.EMP_NOTES(data.EMP_NOTES);
				this.LICENSE_KEY(data.LICENSE_KEY);
				this.AP_IMPORT_TYPE(data.AP_IMPORT_TYPE);
				this.IO_IMPORT_TYPE(data.IO_IMPORT_TYPE);
				this.MRP_DSN(data.MRP_DSN);
				this.PDF_GENERATOR(data.PDF_GENERATOR);
				this.JOB_FIRST_USE_DT_R(data.JOB_FIRST_USE_DT_R);
				this.COMPLEX_CODE_R(data.COMPLEX_CODE_R);
				this.FORMAT_SC_CODE_R(data.FORMAT_SC_CODE_R);
				this.DP_TM_CODE_R(data.DP_TM_CODE_R);
				this.MARKET_CODE_R(data.MARKET_CODE_R);
				this.EMAIL_GR_CODE_R(data.EMAIL_GR_CODE_R);
				this.BILL_COOP_CODE_R(data.BILL_COOP_CODE_R);
				this.AD_NBR_R(data.AD_NBR_R);
				this.NOBILL_FLAG_H(data.NOBILL_FLAG_H);
				this.SPELL_LIC_KEY(data.SPELL_LIC_KEY);
				this.SMTP_SERVER(data.SMTP_SERVER);
				this.SMTP_SENDER(data.SMTP_SENDER);
				this.SMTP_SENDER_PWD(data.SMTP_SENDER_PWD);
				this.CR_AR_DESC(data.CR_AR_DESC);
				this.DEF_EST_RPT(data.DEF_EST_RPT);
				this.DEF_EST_DT_ENTER(data.DEF_EST_DT_ENTER);
				this.DEF_EST_DT_PRINT(data.DEF_EST_DT_PRINT);
				this.DEF_EST_SUPPRESS(data.DEF_EST_SUPPRESS);
				this.DEF_EST_INC_CONT(data.DEF_EST_INC_CONT);
				this.DEF_PO_RPT(data.DEF_PO_RPT);
				this.DEF_PO_DT_ENTER(data.DEF_PO_DT_ENTER);
				this.DEF_PO_DT_PRINT(data.DEF_PO_DT_PRINT);
				this.MC_URL(data.MC_URL);
				this.MC_ACCT_ID(data.MC_ACCT_ID);
				this.AP_OFFICE(data.AP_OFFICE);
				this.INTER_COMPANY(data.INTER_COMPANY);
				this.FLAG_1099(data.FLAG_1099);
				this.AP_PO_MESSAGE(data.AP_PO_MESSAGE);
				this.AP_PO_REJECT(data.AP_PO_REJECT);
				this.AP_CALC_PO(data.AP_CALC_PO);
				this.AP_PO_MESSAGE_TEXT(data.AP_PO_MESSAGE_TEXT);
				this.AP_PO_REJECT_TEXT(data.AP_PO_REJECT_TEXT);
				this.AP_LOCK_GLCODE(data.AP_LOCK_GLCODE);
				this.VN_ACCT_NBR(data.VN_ACCT_NBR);
				this.VN_PAY_TO_INFO(data.VN_PAY_TO_INFO);
				this.GL_FILTER(data.GL_FILTER);
				this.JOB_CLI_REF_R(data.JOB_CLI_REF_R);
				this.JOB_DATE_OPENED_R(data.JOB_DATE_OPENED_R);
				this.JOB_AD_SIZE_R(data.JOB_AD_SIZE_R);
				this.PROD_CONT_CODE_R(data.PROD_CONT_CODE_R);
				this.JOB_COMP_BUDGET_R(data.JOB_COMP_BUDGET_R);
				this.ALLOW_VN_EMAIL(data.ALLOW_VN_EMAIL);
				this.ALLOW_CL_EMAIL(data.ALLOW_CL_EMAIL);
				this.EMP_ON_ALERT_LIST(data.EMP_ON_ALERT_LIST);
				this.EMAIL_USERNAME(data.EMAIL_USERNAME);
				this.EMAIL_PWD(data.EMAIL_PWD);
				this.QVA_QUERY(data.QVA_QUERY);
				this.BILL_SELECT_ALERT(data.BILL_SELECT_ALERT);
				this.MC_ACTIVE(data.MC_ACTIVE);
				this.PENDING_TIME_OFF(data.PENDING_TIME_OFF);
				this.START_END_TIME(data.START_END_TIME);
				this.TimeApprovalActive(data.TimeApprovalActive);
				this.APPR_EST_REQ(data.APPR_EST_REQ);
				this.EDIT_JOB_REQ_EST(data.EDIT_JOB_REQ_EST);
				this.INET_COMMENT(data.INET_COMMENT);
				this.NON_CLIENT_GL_DET(data.NON_CLIENT_GL_DET);
				this.START_DATE_R(data.START_DATE_R);
				this.EST_COMMENT(data.EST_COMMENT);
				this.MC_ACCT_PWD(data.MC_ACCT_PWD);
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
				this.MAR_CB_ACTIVE(data.MAR_CB_ACTIVE);
				this.PO_AMT_REQ(data.PO_AMT_REQ);
				this.EDIT_OTHER_TIME(data.EDIT_OTHER_TIME);
				this.CURRENCY_SYMBOL(data.CURRENCY_SYMBOL);
				this.CURRENCY_TEXT(data.CURRENCY_TEXT);
				this.COIN_TEXT(data.COIN_TEXT);
				this.TIME_COMMENTS_REQ(data.TIME_COMMENTS_REQ);
				this.USE_SMTP_FOR_PDF(data.USE_SMTP_FOR_PDF);
				this.USE_PROD_CAT(data.USE_PROD_CAT);
				this.PO_FOOTER(data.PO_FOOTER);
				this.STRATA_PATH(data.STRATA_PATH);
				this.TAX_FLAG_R(data.TAX_FLAG_R);
				this.IT_CONTACT_EMAIL(data.IT_CONTACT_EMAIL);
				this.EMAIL_IT_CONTACT(data.EMAIL_IT_CONTACT);
				this.EMAIL_SUPERVISOR(data.EMAIL_SUPERVISOR);
				this.WEEKLY_TIME(data.WEEKLY_TIME);
				this.DOC_REPOSITORY_PATH(data.DOC_REPOSITORY_PATH);
				this.DOC_REPOSITORY_USER_DOMAIN(data.DOC_REPOSITORY_USER_DOMAIN);
				this.DOC_REPOSITORY_USER_NAME(data.DOC_REPOSITORY_USER_NAME);
				this.DOC_REPOSITORY_USER_PASSWORD(data.DOC_REPOSITORY_USER_PASSWORD);
				this.WORD_CHECK_AMT(data.WORD_CHECK_AMT);
				this.BILL_MEDIA_TYPE(data.BILL_MEDIA_TYPE);
				this.CHK_STUB_LINES_UP(data.CHK_STUB_LINES_UP);
				this.CHK_BODY_LINES_DN(data.CHK_BODY_LINES_DN);
				this.AP_ACCT_OFF_IMP(data.AP_ACCT_OFF_IMP);
				this.FISCAL_PD_R(data.FISCAL_PD_R);
				this.BLACKPLATE_VER_R(data.BLACKPLATE_VER_R);
				this.BLACKPLATE_VER2_R(data.BLACKPLATE_VER2_R);
				this.ACCESS_RPT_PATH(data.ACCESS_RPT_PATH);
				this.CONTACT_OPT(data.CONTACT_OPT);
				this.AP_APPROVAL(data.AP_APPROVAL);
				this.AP_APP_PRINT_PCT(data.AP_APP_PRINT_PCT);
				this.AP_APP_INET_PCT(data.AP_APP_INET_PCT);
				this.AP_APP_OOH_PCT(data.AP_APP_OOH_PCT);
				this.PDF_ALERT_ONLY(data.PDF_ALERT_ONLY);
				this.ALERT_NOTIFY(data.ALERT_NOTIFY);
				this.WEBVANTAGE_URL(data.WEBVANTAGE_URL);
				this.TR_TITLE1(data.TR_TITLE1);
				this.TR_TITLE2(data.TR_TITLE2);
				this.TR_TITLE3(data.TR_TITLE3);
				this.TR_TITLE4(data.TR_TITLE4);
				this.TR_TITLE5(data.TR_TITLE5);
				this.TRF_HRS(data.TRF_HRS);
				this.TRF_SCHEDULE_BY(data.TRF_SCHEDULE_BY);
				this.TRF_LOCK_DATE(data.TRF_LOCK_DATE);
				this.TRF_CALC_BY_CMP(data.TRF_CALC_BY_CMP);
				this.AUTO_ALERT_SUPER(data.AUTO_ALERT_SUPER);
				this.SMTP_AUTH_METHOD(data.SMTP_AUTH_METHOD);
				this.SMTP_PORT_NUMBER(data.SMTP_PORT_NUMBER);
				this.EMAIL_REPLY_TO(data.EMAIL_REPLY_TO);
				this.SMTP_SECURE_TYPE(data.SMTP_SECURE_TYPE);
				this.MB_KEY(data.MB_KEY);
				this.SMTP_USE_EMP_LOGIN(data.SMTP_USE_EMP_LOGIN);
				this.SMTP_USE_EMP_FROM(data.SMTP_USE_EMP_FROM);
				this.CRNCY_IMPORT_TYPE(data.CRNCY_IMPORT_TYPE);
				this.MULTI_CRNCY(data.MULTI_CRNCY);
				this.HOME_CRNCY(data.HOME_CRNCY);
				this.ACCESS_TMP_PATH(data.ACCESS_TMP_PATH);
				this.EMAIL_ATTACH_DEF(data.EMAIL_ATTACH_DEF);
				this.POP3_SERVER(data.POP3_SERVER);
				this.POP3_PORT_NUMBER(data.POP3_PORT_NUMBER);
				this.POP3_USERNAME(data.POP3_USERNAME);
				this.POP3_PWD(data.POP3_PWD);
				this.POP3_DEL_PROCESSED(data.POP3_DEL_PROCESSED);
				this.POP3_REPLY_TO(data.POP3_REPLY_TO);
				this.POP3_AUTH_METHOD(data.POP3_AUTH_METHOD);
				this.POP3_SECURE_TYPE(data.POP3_SECURE_TYPE);
				this.AP_APP_TV_PCT(data.AP_APP_TV_PCT);
				this.AP_APP_RADIO_PCT(data.AP_APP_RADIO_PCT);
				this.SERVICE_FEE_TYPE_R(data.SERVICE_FEE_TYPE_R);
				this.COUNTY(data.COUNTY);
				this.COS_ENTRY_FLAG(data.COS_ENTRY_FLAG);
				this.INV_TAX_FLAG(data.INV_TAX_FLAG);
				this.DB_TIMEZONE_ID(data.DB_TIMEZONE_ID);
				this.TIMEZONE_ID(data.TIMEZONE_ID);
				this.EDIT_CDP(data.EDIT_CDP);
				this.TS_COPY_HRS(data.TS_COPY_HRS);
				this.CLIENTPORTAL_URL(data.CLIENTPORTAL_URL);
				this.DB_CULTURE_CODE(data.DB_CULTURE_CODE);
				this.CULTURE_CODE(data.CULTURE_CODE);
		
            }
        }
    });
})();