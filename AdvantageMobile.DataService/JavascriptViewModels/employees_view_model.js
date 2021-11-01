
(function() {
    AdvantageMobile_UI.EmployeeViewModel = function(data) {
				this.Code = ko.observable();
				this.DepartmentTeamCode = ko.observable();
				this.LastName = ko.observable();
				this.FirstName = ko.observable();
				this.MiddleInitial = ko.observable();
				this.EMP_COST_RATE = ko.observable();
				this.Address1 = ko.observable();
				this.Address2 = ko.observable();
				this.EMP_ALPHA_SORT = ko.observable();
				this.City = ko.observable();
				this.Country = ko.observable();
				this.County = ko.observable();
				this.EMP_PAY_TO_ADDR1 = ko.observable();
				this.EMP_PAY_TO_ADDR2 = ko.observable();
				this.EMP_PAY_TO_CITY = ko.observable();
				this.EMP_PAY_TO_COUNTRY = ko.observable();
				this.EMP_PAY_TO_COUNTY = ko.observable();
				this.EMP_PAY_TO_STATE = ko.observable();
				this.EMP_PAY_TO_ZIP = ko.observable();
				this.PhoneNumber = ko.observable();
				this.State = ko.observable();
				this.SocialSecurityNumber = ko.observable();
				this.Zip = ko.observable();
				this.EMP_DATE = ko.observable();
				this.TerminatedDate = ko.observable();
				this.BirthDay = ko.observable();
				this.EMP_LAST_INCREASE = ko.observable();
				this.EMP_NEXT_REVIEW = ko.observable();
				this.EMP_ANNUAL_SALARY = ko.observable();
				this.EMP_MONTHLY_SALARY = ko.observable();
				this.Email = ko.observable();
				this.MonthHoursGoal = ko.observable();
				this.OfficeCode = ko.observable();
				this.SupervisorEmployeeCode = ko.observable();
				this.VAC_HRS = ko.observable();
				this.VAC_FROM_DATE = ko.observable();
				this.VAC_TO_DATE = ko.observable();
				this.SICK_HRS = ko.observable();
				this.SICK_FROM_DATE = ko.observable();
				this.SICK_TO_DATE = ko.observable();
				this.StandardWorkdays = ko.observable();
				this.EmployeeWorkdays = ko.observable();
				this.EMP_TIME_ALERT = ko.observable();
				this.SMTP_SERVER = ko.observable();
				this.EMAIL_PWD = ko.observable();
				this.MondayHours = ko.observable();
				this.TuesdayHours = ko.observable();
				this.WednesdayHours = ko.observable();
				this.ThursdayHours = ko.observable();
				this.FridayHours = ko.observable();
				this.SaturdayHours = ko.observable();
				this.SundayHours = ko.observable();
				this.ALERT_EMAIL = ko.observable();
				this.FREELANCE = ko.observable();
				this.PERS_HRS = ko.observable();
				this.PERS_FROM_DATE = ko.observable();
				this.PERS_TO_DATE = ko.observable();
				this.DefaultFunctionCode = ko.observable();
				this.PO_LIMIT = ko.observable();
				this.EMP_ACCOUNT_NBR = ko.observable();
				this.EMP_PHONE_WORK = ko.observable();
				this.EMP_PHONE_CELL = ko.observable();
				this.EMP_PHONE_ALT = ko.observable();
				this.EMP_PHONE_WORK_EXT = ko.observable();
				this.STD_ANNUAL_HRS = ko.observable();
				this.VN_CODE_EXP = ko.observable();
				this.CC_NUMBER = ko.observable();
				this.CC_DESC = ko.observable();
				this.CC_GL_ACCOUNT = ko.observable();
				this.EXP_APPR_REQ = ko.observable();
				this.MISSING_TIME = ko.observable();
				this.WEEKLY_TIME = ko.observable();
				this.SIGNATURE_PATH = ko.observable();
				this.STATUS = ko.observable();
				this.DIRECT_HRS_PER = ko.observable();
				this.DEF_TRF_ROLE = ko.observable();
				this.EMP_COMMENT = ko.observable();
				this.EMPLOYEE_TITLE_ID = ko.observable();
				this.PO_APPR_RULE_CODE = ko.observable();
				this.PO_GL_SELECTION = ko.observable();
				this.PO_GL_LIMIT_BY_OFFICE = ko.observable();
				this.SENIORITY = ko.observable();
				this.EMP_START_TIME = ko.observable();
				this.EMP_END_TIME = ko.observable();
				this.EMP_START_TIME_MON = ko.observable();
				this.EMP_END_TIME_MON = ko.observable();
				this.EMP_START_TIME_TUE = ko.observable();
				this.EMP_END_TIME_TUE = ko.observable();
				this.EMP_START_TIME_WED = ko.observable();
				this.EMP_END_TIME_WED = ko.observable();
				this.EMP_START_TIME_THU = ko.observable();
				this.EMP_END_TIME_THU = ko.observable();
				this.EMP_START_TIME_FRI = ko.observable();
				this.EMP_END_TIME_FRI = ko.observable();
				this.EMP_START_TIME_SAT = ko.observable();
				this.EMP_END_TIME_SAT = ko.observable();
				this.EMP_START_TIME_SUN = ko.observable();
				this.EMP_END_TIME_SUN = ko.observable();
				this.EMAIL_USERNAME = ko.observable();
				this.EMAIL_REPLY_TO = ko.observable();
				this.EMP_SIG = ko.observable();
				this.WV_TMPLT_HDR_ID = ko.observable();
				this.ALT_COST_RATE = ko.observable();
				this.ALT_DATE_FRM = ko.observable();
				this.ALT_DATE_TO = ko.observable();
				this.CREATED_BY = ko.observable();
				this.CREATED_DATE = ko.observable();
				this.LAST_MODIFIED_BY = ko.observable();
				this.LAST_MODIFIED_DATE = ko.observable();
				this.METHOD = ko.observable();
				this.EXP_RPT_APPROVER = ko.observable();
				this.VAC_TIME_RULE_ID = ko.observable();
				this.SICK_TIME_RULE_ID = ko.observable();
				this.PERS_TIME_RULE_ID = ko.observable();
				this.EMP_TITLE = ko.observable();
				this.TimesheetApprovalFlag = ko.observable();
				this.IS_ACTIVE_FREELANCE = ko.observable();
				this.SUGAR_USERNAME = ko.observable();
				this.SUGAR_PASSWORD = ko.observable();
				this.PROOFHQ_PASSWORD = ko.observable();
				this.PROOFHQ_USERNAME = ko.observable();
				this.EMP_BILL_RATE = ko.observable();
				this.IS_API_USER = ko.observable();
				this.GOOGLE_TOKEN = ko.observable();
				this.ADOBE_SIGNATURE_FILE = ko.observable();
				this.ADOBE_SIGNATURE_FILE_PASSWORD = ko.observable();
				this.VCC_PASSWORD = ko.observable();
				this.VCC_USERNAME = ko.observable();
				this.EMP_OMIT_MISSING = ko.observable();
				this.IGNORE_CALENDAR_SYNC = ko.observable();
				this.TIME_ZONE_ID = ko.observable();
				this.CS_PASSWORD = ko.observable();
				this.CS_USERID = ko.observable();
				this.CULTURE_CODE = ko.observable();
				this.CAL_TIME_TYPE = ko.observable();
				this.CAL_TIME_EMAIL = ko.observable();
				this.CAL_TIME_USERNAME = ko.observable();
				this.CAL_TIME_PASSWORD = ko.observable();
				this.CAL_TIME_HOST = ko.observable();
				this.CAL_TIME_PORT = ko.observable();
				this.CAL_TIME_SSL = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeViewModel.prototype, {
        toJS: function() {
            return {
			Code: this.Code(),
			DepartmentTeamCode: this.DepartmentTeamCode(),
			LastName: this.LastName(),
			FirstName: this.FirstName(),
			MiddleInitial: this.MiddleInitial(),
			EMP_COST_RATE: String(this.EMP_COST_RATE() || 0),
			Address1: this.Address1(),
			Address2: this.Address2(),
			EMP_ALPHA_SORT: this.EMP_ALPHA_SORT(),
			City: this.City(),
			Country: this.Country(),
			County: this.County(),
			EMP_PAY_TO_ADDR1: this.EMP_PAY_TO_ADDR1(),
			EMP_PAY_TO_ADDR2: this.EMP_PAY_TO_ADDR2(),
			EMP_PAY_TO_CITY: this.EMP_PAY_TO_CITY(),
			EMP_PAY_TO_COUNTRY: this.EMP_PAY_TO_COUNTRY(),
			EMP_PAY_TO_COUNTY: this.EMP_PAY_TO_COUNTY(),
			EMP_PAY_TO_STATE: this.EMP_PAY_TO_STATE(),
			EMP_PAY_TO_ZIP: this.EMP_PAY_TO_ZIP(),
			PhoneNumber: this.PhoneNumber(),
			State: this.State(),
			SocialSecurityNumber: this.SocialSecurityNumber(),
			Zip: this.Zip(),
			EMP_DATE: this.EMP_DATE(),
			TerminatedDate: this.TerminatedDate(),
			BirthDay: this.BirthDay(),
			EMP_LAST_INCREASE: this.EMP_LAST_INCREASE(),
			EMP_NEXT_REVIEW: this.EMP_NEXT_REVIEW(),
			EMP_ANNUAL_SALARY: String(this.EMP_ANNUAL_SALARY() || 0),
			EMP_MONTHLY_SALARY: String(this.EMP_MONTHLY_SALARY() || 0),
			Email: this.Email(),
			MonthHoursGoal: String(this.MonthHoursGoal() || 0),
			OfficeCode: this.OfficeCode(),
			SupervisorEmployeeCode: this.SupervisorEmployeeCode(),
			VAC_HRS: String(this.VAC_HRS() || 0),
			VAC_FROM_DATE: this.VAC_FROM_DATE(),
			VAC_TO_DATE: this.VAC_TO_DATE(),
			SICK_HRS: String(this.SICK_HRS() || 0),
			SICK_FROM_DATE: this.SICK_FROM_DATE(),
			SICK_TO_DATE: this.SICK_TO_DATE(),
			StandardWorkdays: String(this.StandardWorkdays() || 0),
			EmployeeWorkdays: this.EmployeeWorkdays(),
			EMP_TIME_ALERT: this.EMP_TIME_ALERT(),
			SMTP_SERVER: this.SMTP_SERVER(),
			EMAIL_PWD: this.EMAIL_PWD(),
			MondayHours: String(this.MondayHours() || 0),
			TuesdayHours: String(this.TuesdayHours() || 0),
			WednesdayHours: String(this.WednesdayHours() || 0),
			ThursdayHours: String(this.ThursdayHours() || 0),
			FridayHours: String(this.FridayHours() || 0),
			SaturdayHours: String(this.SaturdayHours() || 0),
			SundayHours: String(this.SundayHours() || 0),
			ALERT_EMAIL: this.ALERT_EMAIL(),
			FREELANCE: this.FREELANCE(),
			PERS_HRS: String(this.PERS_HRS() || 0),
			PERS_FROM_DATE: this.PERS_FROM_DATE(),
			PERS_TO_DATE: this.PERS_TO_DATE(),
			DefaultFunctionCode: this.DefaultFunctionCode(),
			PO_LIMIT: String(this.PO_LIMIT() || 0),
			EMP_ACCOUNT_NBR: this.EMP_ACCOUNT_NBR(),
			EMP_PHONE_WORK: this.EMP_PHONE_WORK(),
			EMP_PHONE_CELL: this.EMP_PHONE_CELL(),
			EMP_PHONE_ALT: this.EMP_PHONE_ALT(),
			EMP_PHONE_WORK_EXT: this.EMP_PHONE_WORK_EXT(),
			STD_ANNUAL_HRS: String(this.STD_ANNUAL_HRS() || 0),
			VN_CODE_EXP: this.VN_CODE_EXP(),
			CC_NUMBER: this.CC_NUMBER(),
			CC_DESC: this.CC_DESC(),
			CC_GL_ACCOUNT: this.CC_GL_ACCOUNT(),
			EXP_APPR_REQ: this.EXP_APPR_REQ(),
			MISSING_TIME: this.MISSING_TIME(),
			WEEKLY_TIME: this.WEEKLY_TIME(),
			SIGNATURE_PATH: this.SIGNATURE_PATH(),
			STATUS: this.STATUS(),
			DIRECT_HRS_PER: String(this.DIRECT_HRS_PER() || 0),
			DEF_TRF_ROLE: this.DEF_TRF_ROLE(),
			EMP_COMMENT: this.EMP_COMMENT(),
			EMPLOYEE_TITLE_ID: this.EMPLOYEE_TITLE_ID(),
			PO_APPR_RULE_CODE: this.PO_APPR_RULE_CODE(),
			PO_GL_SELECTION: this.PO_GL_SELECTION(),
			PO_GL_LIMIT_BY_OFFICE: this.PO_GL_LIMIT_BY_OFFICE(),
			SENIORITY: this.SENIORITY(),
			EMP_START_TIME: this.EMP_START_TIME(),
			EMP_END_TIME: this.EMP_END_TIME(),
			EMP_START_TIME_MON: this.EMP_START_TIME_MON(),
			EMP_END_TIME_MON: this.EMP_END_TIME_MON(),
			EMP_START_TIME_TUE: this.EMP_START_TIME_TUE(),
			EMP_END_TIME_TUE: this.EMP_END_TIME_TUE(),
			EMP_START_TIME_WED: this.EMP_START_TIME_WED(),
			EMP_END_TIME_WED: this.EMP_END_TIME_WED(),
			EMP_START_TIME_THU: this.EMP_START_TIME_THU(),
			EMP_END_TIME_THU: this.EMP_END_TIME_THU(),
			EMP_START_TIME_FRI: this.EMP_START_TIME_FRI(),
			EMP_END_TIME_FRI: this.EMP_END_TIME_FRI(),
			EMP_START_TIME_SAT: this.EMP_START_TIME_SAT(),
			EMP_END_TIME_SAT: this.EMP_END_TIME_SAT(),
			EMP_START_TIME_SUN: this.EMP_START_TIME_SUN(),
			EMP_END_TIME_SUN: this.EMP_END_TIME_SUN(),
			EMAIL_USERNAME: this.EMAIL_USERNAME(),
			EMAIL_REPLY_TO: this.EMAIL_REPLY_TO(),
			EMP_SIG: this.EMP_SIG(),
			WV_TMPLT_HDR_ID: this.WV_TMPLT_HDR_ID(),
			ALT_COST_RATE: String(this.ALT_COST_RATE() || 0),
			ALT_DATE_FRM: this.ALT_DATE_FRM(),
			ALT_DATE_TO: this.ALT_DATE_TO(),
			CREATED_BY: this.CREATED_BY(),
			CREATED_DATE: this.CREATED_DATE(),
			LAST_MODIFIED_BY: this.LAST_MODIFIED_BY(),
			LAST_MODIFIED_DATE: this.LAST_MODIFIED_DATE(),
			METHOD: this.METHOD(),
			EXP_RPT_APPROVER: this.EXP_RPT_APPROVER(),
			VAC_TIME_RULE_ID: this.VAC_TIME_RULE_ID(),
			SICK_TIME_RULE_ID: this.SICK_TIME_RULE_ID(),
			PERS_TIME_RULE_ID: this.PERS_TIME_RULE_ID(),
			EMP_TITLE: this.EMP_TITLE(),
			TimesheetApprovalFlag: this.TimesheetApprovalFlag(),
			IS_ACTIVE_FREELANCE: this.IS_ACTIVE_FREELANCE(),
			SUGAR_USERNAME: this.SUGAR_USERNAME(),
			SUGAR_PASSWORD: this.SUGAR_PASSWORD(),
			PROOFHQ_PASSWORD: this.PROOFHQ_PASSWORD(),
			PROOFHQ_USERNAME: this.PROOFHQ_USERNAME(),
			EMP_BILL_RATE: String(this.EMP_BILL_RATE() || 0),
			IS_API_USER: this.IS_API_USER(),
			GOOGLE_TOKEN: this.GOOGLE_TOKEN(),
			ADOBE_SIGNATURE_FILE: this.ADOBE_SIGNATURE_FILE(),
			ADOBE_SIGNATURE_FILE_PASSWORD: this.ADOBE_SIGNATURE_FILE_PASSWORD(),
			VCC_PASSWORD: this.VCC_PASSWORD(),
			VCC_USERNAME: this.VCC_USERNAME(),
			EMP_OMIT_MISSING: this.EMP_OMIT_MISSING(),
			IGNORE_CALENDAR_SYNC: this.IGNORE_CALENDAR_SYNC(),
			TIME_ZONE_ID: this.TIME_ZONE_ID(),
			CS_PASSWORD: this.CS_PASSWORD(),
			CS_USERID: this.CS_USERID(),
			CULTURE_CODE: this.CULTURE_CODE(),
			CAL_TIME_TYPE: this.CAL_TIME_TYPE(),
			CAL_TIME_EMAIL: this.CAL_TIME_EMAIL(),
			CAL_TIME_USERNAME: this.CAL_TIME_USERNAME(),
			CAL_TIME_PASSWORD: this.CAL_TIME_PASSWORD(),
			CAL_TIME_HOST: this.CAL_TIME_HOST(),
			CAL_TIME_PORT: this.CAL_TIME_PORT(),
			CAL_TIME_SSL: this.CAL_TIME_SSL(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.Code(data.Code);
				this.DepartmentTeamCode(data.DepartmentTeamCode);
				this.LastName(data.LastName);
				this.FirstName(data.FirstName);
				this.MiddleInitial(data.MiddleInitial);
				this.EMP_COST_RATE(data.EMP_COST_RATE);
				this.Address1(data.Address1);
				this.Address2(data.Address2);
				this.EMP_ALPHA_SORT(data.EMP_ALPHA_SORT);
				this.City(data.City);
				this.Country(data.Country);
				this.County(data.County);
				this.EMP_PAY_TO_ADDR1(data.EMP_PAY_TO_ADDR1);
				this.EMP_PAY_TO_ADDR2(data.EMP_PAY_TO_ADDR2);
				this.EMP_PAY_TO_CITY(data.EMP_PAY_TO_CITY);
				this.EMP_PAY_TO_COUNTRY(data.EMP_PAY_TO_COUNTRY);
				this.EMP_PAY_TO_COUNTY(data.EMP_PAY_TO_COUNTY);
				this.EMP_PAY_TO_STATE(data.EMP_PAY_TO_STATE);
				this.EMP_PAY_TO_ZIP(data.EMP_PAY_TO_ZIP);
				this.PhoneNumber(data.PhoneNumber);
				this.State(data.State);
				this.SocialSecurityNumber(data.SocialSecurityNumber);
				this.Zip(data.Zip);
				this.EMP_DATE(data.EMP_DATE);
				this.TerminatedDate(data.TerminatedDate);
				this.BirthDay(data.BirthDay);
				this.EMP_LAST_INCREASE(data.EMP_LAST_INCREASE);
				this.EMP_NEXT_REVIEW(data.EMP_NEXT_REVIEW);
				this.EMP_ANNUAL_SALARY(data.EMP_ANNUAL_SALARY);
				this.EMP_MONTHLY_SALARY(data.EMP_MONTHLY_SALARY);
				this.Email(data.Email);
				this.MonthHoursGoal(data.MonthHoursGoal);
				this.OfficeCode(data.OfficeCode);
				this.SupervisorEmployeeCode(data.SupervisorEmployeeCode);
				this.VAC_HRS(data.VAC_HRS);
				this.VAC_FROM_DATE(data.VAC_FROM_DATE);
				this.VAC_TO_DATE(data.VAC_TO_DATE);
				this.SICK_HRS(data.SICK_HRS);
				this.SICK_FROM_DATE(data.SICK_FROM_DATE);
				this.SICK_TO_DATE(data.SICK_TO_DATE);
				this.StandardWorkdays(data.StandardWorkdays);
				this.EmployeeWorkdays(data.EmployeeWorkdays);
				this.EMP_TIME_ALERT(data.EMP_TIME_ALERT);
				this.SMTP_SERVER(data.SMTP_SERVER);
				this.EMAIL_PWD(data.EMAIL_PWD);
				this.MondayHours(data.MondayHours);
				this.TuesdayHours(data.TuesdayHours);
				this.WednesdayHours(data.WednesdayHours);
				this.ThursdayHours(data.ThursdayHours);
				this.FridayHours(data.FridayHours);
				this.SaturdayHours(data.SaturdayHours);
				this.SundayHours(data.SundayHours);
				this.ALERT_EMAIL(data.ALERT_EMAIL);
				this.FREELANCE(data.FREELANCE);
				this.PERS_HRS(data.PERS_HRS);
				this.PERS_FROM_DATE(data.PERS_FROM_DATE);
				this.PERS_TO_DATE(data.PERS_TO_DATE);
				this.DefaultFunctionCode(data.DefaultFunctionCode);
				this.PO_LIMIT(data.PO_LIMIT);
				this.EMP_ACCOUNT_NBR(data.EMP_ACCOUNT_NBR);
				this.EMP_PHONE_WORK(data.EMP_PHONE_WORK);
				this.EMP_PHONE_CELL(data.EMP_PHONE_CELL);
				this.EMP_PHONE_ALT(data.EMP_PHONE_ALT);
				this.EMP_PHONE_WORK_EXT(data.EMP_PHONE_WORK_EXT);
				this.STD_ANNUAL_HRS(data.STD_ANNUAL_HRS);
				this.VN_CODE_EXP(data.VN_CODE_EXP);
				this.CC_NUMBER(data.CC_NUMBER);
				this.CC_DESC(data.CC_DESC);
				this.CC_GL_ACCOUNT(data.CC_GL_ACCOUNT);
				this.EXP_APPR_REQ(data.EXP_APPR_REQ);
				this.MISSING_TIME(data.MISSING_TIME);
				this.WEEKLY_TIME(data.WEEKLY_TIME);
				this.SIGNATURE_PATH(data.SIGNATURE_PATH);
				this.STATUS(data.STATUS);
				this.DIRECT_HRS_PER(data.DIRECT_HRS_PER);
				this.DEF_TRF_ROLE(data.DEF_TRF_ROLE);
				this.EMP_COMMENT(data.EMP_COMMENT);
				this.EMPLOYEE_TITLE_ID(data.EMPLOYEE_TITLE_ID);
				this.PO_APPR_RULE_CODE(data.PO_APPR_RULE_CODE);
				this.PO_GL_SELECTION(data.PO_GL_SELECTION);
				this.PO_GL_LIMIT_BY_OFFICE(data.PO_GL_LIMIT_BY_OFFICE);
				this.SENIORITY(data.SENIORITY);
				this.EMP_START_TIME(data.EMP_START_TIME);
				this.EMP_END_TIME(data.EMP_END_TIME);
				this.EMP_START_TIME_MON(data.EMP_START_TIME_MON);
				this.EMP_END_TIME_MON(data.EMP_END_TIME_MON);
				this.EMP_START_TIME_TUE(data.EMP_START_TIME_TUE);
				this.EMP_END_TIME_TUE(data.EMP_END_TIME_TUE);
				this.EMP_START_TIME_WED(data.EMP_START_TIME_WED);
				this.EMP_END_TIME_WED(data.EMP_END_TIME_WED);
				this.EMP_START_TIME_THU(data.EMP_START_TIME_THU);
				this.EMP_END_TIME_THU(data.EMP_END_TIME_THU);
				this.EMP_START_TIME_FRI(data.EMP_START_TIME_FRI);
				this.EMP_END_TIME_FRI(data.EMP_END_TIME_FRI);
				this.EMP_START_TIME_SAT(data.EMP_START_TIME_SAT);
				this.EMP_END_TIME_SAT(data.EMP_END_TIME_SAT);
				this.EMP_START_TIME_SUN(data.EMP_START_TIME_SUN);
				this.EMP_END_TIME_SUN(data.EMP_END_TIME_SUN);
				this.EMAIL_USERNAME(data.EMAIL_USERNAME);
				this.EMAIL_REPLY_TO(data.EMAIL_REPLY_TO);
				this.EMP_SIG(data.EMP_SIG);
				this.WV_TMPLT_HDR_ID(data.WV_TMPLT_HDR_ID);
				this.ALT_COST_RATE(data.ALT_COST_RATE);
				this.ALT_DATE_FRM(data.ALT_DATE_FRM);
				this.ALT_DATE_TO(data.ALT_DATE_TO);
				this.CREATED_BY(data.CREATED_BY);
				this.CREATED_DATE(data.CREATED_DATE);
				this.LAST_MODIFIED_BY(data.LAST_MODIFIED_BY);
				this.LAST_MODIFIED_DATE(data.LAST_MODIFIED_DATE);
				this.METHOD(data.METHOD);
				this.EXP_RPT_APPROVER(data.EXP_RPT_APPROVER);
				this.VAC_TIME_RULE_ID(data.VAC_TIME_RULE_ID);
				this.SICK_TIME_RULE_ID(data.SICK_TIME_RULE_ID);
				this.PERS_TIME_RULE_ID(data.PERS_TIME_RULE_ID);
				this.EMP_TITLE(data.EMP_TITLE);
				this.TimesheetApprovalFlag(data.TimesheetApprovalFlag);
				this.IS_ACTIVE_FREELANCE(data.IS_ACTIVE_FREELANCE);
				this.SUGAR_USERNAME(data.SUGAR_USERNAME);
				this.SUGAR_PASSWORD(data.SUGAR_PASSWORD);
				this.PROOFHQ_PASSWORD(data.PROOFHQ_PASSWORD);
				this.PROOFHQ_USERNAME(data.PROOFHQ_USERNAME);
				this.EMP_BILL_RATE(data.EMP_BILL_RATE);
				this.IS_API_USER(data.IS_API_USER);
				this.GOOGLE_TOKEN(data.GOOGLE_TOKEN);
				this.ADOBE_SIGNATURE_FILE(data.ADOBE_SIGNATURE_FILE);
				this.ADOBE_SIGNATURE_FILE_PASSWORD(data.ADOBE_SIGNATURE_FILE_PASSWORD);
				this.VCC_PASSWORD(data.VCC_PASSWORD);
				this.VCC_USERNAME(data.VCC_USERNAME);
				this.EMP_OMIT_MISSING(data.EMP_OMIT_MISSING);
				this.IGNORE_CALENDAR_SYNC(data.IGNORE_CALENDAR_SYNC);
				this.TIME_ZONE_ID(data.TIME_ZONE_ID);
				this.CS_PASSWORD(data.CS_PASSWORD);
				this.CS_USERID(data.CS_USERID);
				this.CULTURE_CODE(data.CULTURE_CODE);
				this.CAL_TIME_TYPE(data.CAL_TIME_TYPE);
				this.CAL_TIME_EMAIL(data.CAL_TIME_EMAIL);
				this.CAL_TIME_USERNAME(data.CAL_TIME_USERNAME);
				this.CAL_TIME_PASSWORD(data.CAL_TIME_PASSWORD);
				this.CAL_TIME_HOST(data.CAL_TIME_HOST);
				this.CAL_TIME_PORT(data.CAL_TIME_PORT);
				this.CAL_TIME_SSL(data.CAL_TIME_SSL);
		
            }
        }
    });
})();