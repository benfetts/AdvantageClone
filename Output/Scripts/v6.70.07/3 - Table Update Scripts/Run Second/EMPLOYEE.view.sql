﻿CREATE VIEW [dbo].[EMPLOYEE] WITH ENCRYPTION
AS
	SELECT 
		E.EMP_CODE,
		E.DP_TM_CODE,
		EMP_LNAME,
		EMP_FNAME,
		EMP_MI,
		EMP_COST_RATE,
		EMP_ADDRESS1,
		EMP_ADDRESS2,
		EMP_ALPHA_SORT,
		EMP_CITY,
		EMP_COUNTRY,
		EMP_COUNTY,
		EMP_PAY_TO_ADDR1,
		EMP_PAY_TO_ADDR2,
		EMP_PAY_TO_CITY,
		EMP_PAY_TO_COUNTRY,
		EMP_PAY_TO_COUNTY,
		EMP_PAY_TO_STATE,
		EMP_PAY_TO_ZIP,
		EMP_PHONE,
		EMP_STATE,
		EMP_OTHER_INFO,
		EMP_ZIP,
		EMP_DATE,
		EMP_TERM_DATE,
		EMP_BIRTH_DATE,
		EMP_LAST_INCREASE,
		EMP_NEXT_REVIEW,
		EMP_ANNUAL_SALARY,
		EMP_MONTHLY_SALARY,
		EMP_EMAIL,
		OFFICE_CODE,
		SUPERVISOR_CODE,
		VAC_FROM_DATE,
		VAC_TO_DATE,
		SICK_FROM_DATE,
		SICK_TO_DATE,
		STD_WORK_HRS,
		EMP_WORK_DAYS,
		EMP_TIME_ALERT,
		SMTP_SERVER,
		EMAIL_PWD,
		MON_HRS,
		TUE_HRS,
		WED_HRS,
		THU_HRS,
		FRI_HRS,
		SAT_HRS,
		SUN_HRS,
		ALERT_EMAIL,
		MTH_HRS_GOAL,
		VAC_HRS,
		SICK_HRS,
		FREELANCE,
		PERS_HRS,
		PERS_FROM_DATE,
		PERS_TO_DATE,
		DEF_FNC_CODE,
		PO_LIMIT,
		EMP_ACCOUNT_NBR,
		EMP_PHONE_WORK,
		EMP_PHONE_CELL,
		EMP_PHONE_ALT,
		EMP_PHONE_WORK_EXT,
		STD_ANNUAL_HRS,
		VN_CODE_EXP,
		CC_NUMBER,
		CC_DESC,
		CC_GL_ACCOUNT,
		EXP_APPR_REQ,
		MISSING_TIME,
		WEEKLY_TIME,
		SIGNATURE_PATH,
		[STATUS],
		DIRECT_HRS_PER,
		DEF_TRF_ROLE,
		EMP_COMMENT,
		E.EMPLOYEE_TITLE_ID,
		PO_APPR_RULE_CODE,
		PO_GL_SELECTION,
		PO_GL_LIMIT_BY_OFFICE,
		SENIORITY,
		EMP_START_TIME,
		EMP_END_TIME,
		EMP_START_TIME_MON,
		EMP_END_TIME_MON,
		EMP_START_TIME_TUE,
		EMP_END_TIME_TUE,
		EMP_START_TIME_WED,
		EMP_END_TIME_WED,
		EMP_START_TIME_THU,
		EMP_END_TIME_THU,
		EMP_START_TIME_FRI,
		EMP_END_TIME_FRI,
		EMP_START_TIME_SAT,
		EMP_END_TIME_SAT,
		EMP_START_TIME_SUN,
		EMP_END_TIME_SUN,
		EMAIL_USERNAME,
		EMAIL_REPLY_TO,
		EMP_SIG,
		WV_TMPLT_HDR_ID,
		ALT_COST_RATE,
		ALT_DATE_FRM,
		ALT_DATE_TO,
		CREATED_BY,
		CREATED_DATE,
		LAST_MODIFIED_BY,
		LAST_MODIFIED_DATE,
		METHOD,
		EXP_RPT_APPROVER,
		VAC_TIME_RULE_ID,
		SICK_TIME_RULE_ID,
		PERS_TIME_RULE_ID,
		ET.EMPLOYEE_TITLE AS EMP_TITLE,
		TS_APPR_FLAG,
		IS_ACTIVE_FREELANCE,
		SUGAR_PASSWORD,
		SUGAR_USERNAME,
		PROOFHQ_PASSWORD,
		PROOFHQ_USERNAME,
		IS_API_USER,
		GOOGLE_TOKEN,
		ADOBE_SIGNATURE_FILE,
		ADOBE_SIGNATURE_FILE_PASSWORD,
		VCC_PASSWORD,
		VCC_USERNAME,
		CS_PASSWORD,
		CS_USERID,
		EMP_OMIT_MISSING,
		IGNORE_CALENDAR_SYNC,
		TIME_ZONE_ID,
		CULTURE_CODE,
		CAL_TIME_TYPE,
		CAL_TIME_EMAIL,
		CAL_TIME_USERNAME,
		CAL_TIME_PASSWORD,
		CAL_TIME_HOST,
		CAL_TIME_PORT,
		CAL_TIME_SSL,
		BR.BILLING_RATE AS EMP_BILL_RATE
	FROM 
		EMPLOYEE_CLOAK AS E
		LEFT OUTER JOIN EMPLOYEE_TITLE AS ET ON E.EMPLOYEE_TITLE_ID = ET.EMPLOYEE_TITLE_ID
		LEFT OUTER JOIN BILLING_RATE BR ON E.EMP_CODE = BR.EMP_CODE AND BR.BILL_RATE_PREC_ID = 2

GO

EXEC sp_refreshview 'dbo.EMPLOYEE'
GO


