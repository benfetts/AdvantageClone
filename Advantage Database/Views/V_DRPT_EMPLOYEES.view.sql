CREATE VIEW [dbo].[V_DRPT_EMPLOYEES]

--WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
		[Code] = E.EMP_CODE,
		[FirstName] = E.EMP_FNAME,
		[MiddleInitial] = E.EMP_MI,
		[LastName] = E.EMP_LNAME,
		[Title] = E.EMP_TITLE,
		[Freelance] = CASE WHEN E.FREELANCE = 1 THEN 'Y' ELSE 'N' END,
		[ActiveFreelance] = CASE WHEN E.IS_ACTIVE_FREELANCE = 1 THEN 'Y' ELSE 'N' END,
		[OfficeCode] = E.OFFICE_CODE,
		[OfficeName] = O.OFFICE_NAME,
		[AccountNumber] = E.EMP_ACCOUNT_NBR,
		[HomePhone] = E.EMP_PHONE,
		[WorkPhone] = E.EMP_PHONE_WORK,
		[WorkPhoneExtension] = E.EMP_PHONE_WORK_EXT,
		[CellPhone] = E.EMP_PHONE_CELL,
		[AlternatePhone] = E.EMP_PHONE_ALT,
		[Address] = E.EMP_ADDRESS1,
		[Address2] = E.EMP_ADDRESS2,
		[City] = E.EMP_CITY,
		[County] = E.EMP_COUNTY,
		[State] = E.EMP_STATE,
		[Zip] = E.EMP_ZIP,
		[Country] = E.EMP_COUNTRY,
		[PayToAddress] = E.EMP_PAY_TO_ADDR1,
		[PayToAddress2] = E.EMP_PAY_TO_ADDR2,
		[PayToCity] = E.EMP_PAY_TO_CITY,
		[PayToCounty] = E.EMP_PAY_TO_COUNTY,
		[PayToState] = E.EMP_PAY_TO_STATE,
		[PayToZip] = E.EMP_PAY_TO_ZIP,
		[PayToCountry] = E.EMP_PAY_TO_COUNTRY,
		[SupervisorEmployeeCode] = E.SUPERVISOR_CODE,
		[Supervisor] = COALESCE((RTRIM(S.EMP_FNAME) + ' '),'') + COALESCE((S.EMP_MI + '. '),'') + COALESCE(S.EMP_LNAME,''),
		[WeeklyTimeType] = CASE E.WEEKLY_TIME WHEN 0 THEN 'By Day'
											  WHEN 1 THEN 'By Week'
											  ELSE '[Agency Default]' END,
		[TimeAlert] = CASE WHEN E.EMP_TIME_ALERT = 1 THEN 'Y' ELSE 'N' END,
		[Status] = CASE E.[STATUS] WHEN 1 THEN 'Exempt'
							       WHEN 2 THEN 'Non-Exempt'
							       ELSE 'N/A' END,
		[FunctionCode] = E.DEF_FNC_CODE,
		[Seniority] = E.SENIORITY,
		[WorkDays] = E.EMP_WORK_DAYS,
		[StandardWorkHours] = E.STD_WORK_HRS,
		[MondayHours] = E.MON_HRS,
		[MondayStartTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_START_TIME_MON, 100), 7)),
		[MondayEndTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_END_TIME_MON, 100), 7)),
		[TuesdayHours] = E.TUE_HRS,
		[TuesdayStartTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_START_TIME_TUE, 100), 7)),
		[TuesdayEndTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_END_TIME_TUE, 100), 7)),
		[WednesdayHours] = E.WED_HRS,
		[WednesdayStartTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_START_TIME_WED, 100), 7)),
		[WednesdayEndTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_END_TIME_WED, 100), 7)),
		[ThursdayHours] = E.THU_HRS,
		[ThursdayStartTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_START_TIME_THU, 100), 7)),
		[ThursdayEndTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_END_TIME_THU, 100), 7)),
		[FridayHours] = E.FRI_HRS,
		[FridayStartTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_START_TIME_FRI, 100), 7)),
		[FridayEndTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_END_TIME_FRI, 100), 7)),
		[SaturdayHours] = E.SAT_HRS,
		[SaturdayStartTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_START_TIME_SAT, 100), 7)),
		[SaturdayEndTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_END_TIME_SAT, 100), 7)),
		[SundayHours] = E.SUN_HRS,
		[SundayStartTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_START_TIME_SUN, 100), 7)),
		[SundayEndTime] = LTRIM(RIGHT(CONVERT(VARCHAR(20), E.EMP_END_TIME_SUN, 100), 7)),
		[AnnualHours] = E.STD_ANNUAL_HRS,
		[MonthHoursGoal] = E.MTH_HRS_GOAL,
		[DirectHours] = E.DIRECT_HRS_PER,
		[VacationDateFrom] = E.VAC_FROM_DATE,
		[VacationDateTo] = E.VAC_TO_DATE,
		[VacationHours] = E.VAC_HRS,
		[VacationTimeRule] = TRV.TIME_RULE_NAME,
		[SickDateFrom] = E.SICK_FROM_DATE,
		[SickDateTo] = E.SICK_TO_DATE,
		[SickHours] = E.SICK_HRS,
		[SickTimeRule] = TRS.TIME_RULE_NAME,
		[PersonalHoursDateFrom] = E.PERS_FROM_DATE,
		[PersonalHoursDateTo] = E.PERS_TO_DATE,
		[PersonalHours] = E.PERS_HRS,
		[PersonalTimeRule] = TRP.TIME_RULE_NAME,
		[PurchaseOrderLimit] = E.PO_LIMIT,
		[PurchaseOrderApprovalRuleCode] = E.PO_APPR_RULE_CODE,
		[AllowPOGLSelection] = CASE WHEN E.PO_GL_SELECTION = 1 THEN 'Y' ELSE 'N' END,
		[LimitPOGLSelectionOffice] = CASE WHEN E.PO_GL_LIMIT_BY_OFFICE = 1 THEN 'Y' ELSE 'N' END,
		[SupervisorApprovalRequired] = CASE WHEN E.EXP_APPR_REQ = 1 THEN 'Y' ELSE 'N' END,
		[AlternateApproverCode] = E.EXP_RPT_APPROVER,
		[AlternateApprover] = COALESCE((RTRIM(APP.EMP_FNAME) + ' '),'') + COALESCE((APP.EMP_MI + '. '),'') + COALESCE(APP.EMP_LNAME,''),
		[EmployeeVendorCode] = E.VN_CODE_EXP,
		[CreditCardNumber] = E.CC_NUMBER,
		[CreditCardGLAccount] = E.CC_GL_ACCOUNT,
		[CreditCardDescription] = E.CC_DESC,
		[EmploymentDate] = E.EMP_DATE,
		[BirthDate] = E.EMP_BIRTH_DATE,
		[LastIncrease] = E.EMP_LAST_INCREASE,
		[NextReview] = E.EMP_NEXT_REVIEW,
		[TerminationDate] = E.EMP_TERM_DATE,
		[AnnualSalary] = E.EMP_ANNUAL_SALARY,
		[MonthlySalary] = E.EMP_MONTHLY_SALARY,
		[BillRate] = E.EMP_BILL_RATE,
		[CostRate] = E.EMP_COST_RATE,
		[OtherInfo] = E.EMP_OTHER_INFO,
		[ReceivesAlerts] = CASE WHEN E.ALERT_EMAIL = 2 OR E.ALERT_EMAIL = 3 THEN 'Y' ELSE 'N' END,
		[ReceivesEmail] =  CASE WHEN E.ALERT_EMAIL = 1 OR E.ALERT_EMAIL = 3 THEN 'Y' ELSE 'N' END,
		[Email] = E.EMP_EMAIL,
		[ReplyToEmail] = E.EMAIL_REPLY_TO,
		[EmailUserName] = E.EMAIL_USERNAME,
		[EmailPassword] = E.EMAIL_PWD,
		[Notes] = E.EMP_COMMENT,
		[DepartmentTeamCode] = E.DP_TM_CODE,
		--[IsMissingTime] = E.MISSING_TIME,
		--[TimesheetApprovalFlag] = E.TS_APPR_FLAG,
		--[SignaturePath] = E.SIGNATURE_PATH,
		--[AlternateDateTo] = E.ALT_DATE_TO,
		--[AlternateDateFrom] = E.ALT_DATE_FRM,
		--[AlternateCostRate] = E.ALT_COST_RATE,
		--[SMTPServer] = E.SMTP_SERVER,
		--[SignatureImage] = E.EMP_SIG,
		[RoleCode] = E.DEF_TRF_ROLE,
		[Role] = TR.ROLE_DESC,
		--[StartTime] = E.EMP_START_TIME,
		--[EndTime] = E.EMP_END_TIME,
		--[AlertNotificationType] = E.ALERT_EMAIL,
		--[LastModifiedDate] = E.LAST_MODIFIED_DATE,
		--[LastModifiedByUserCode] = E.LAST_MODIFIED_BY
		[IsAPIUser] = CASE WHEN E.IS_API_USER IS NULL THEN 'N' ELSE 'Y' END,
		[IsWVOnlyUser] = CASE WHEN WVOU.EMP_CODE IS NOT NULL THEN 'Y' ELSE 'N' END,
		[IsMediaToolsUser] = CASE WHEN MTU.EMP_CODE IS NOT NULL THEN 'Y' ELSE 'N' END,
		[IsActiveForConceptShare] =   CASE WHEN (E.CS_USERID IS NOT NULL AND E.CS_PASSWORD IS NOT NULL) THEN 'Y' ELSE 'N' END
	FROM
		dbo.EMPLOYEE E LEFT OUTER JOIN
		dbo.OFFICE O ON E.OFFICE_CODE = O.OFFICE_CODE LEFT OUTER JOIN
		dbo.TIME_RULE_HDR TRV ON E.VAC_TIME_RULE_ID = TRV.TIME_RULE_ID LEFT OUTER JOIN
		dbo.TIME_RULE_HDR TRS ON E.SICK_TIME_RULE_ID = TRS.TIME_RULE_ID LEFT OUTER JOIN
		dbo.TIME_RULE_HDR TRP ON E.PERS_TIME_RULE_ID = TRP.TIME_RULE_ID LEFT OUTER JOIN 
		dbo.EMPLOYEE S ON E.SUPERVISOR_CODE = S.EMP_CODE LEFT OUTER JOIN
		dbo.EMPLOYEE APP ON E.EXP_RPT_APPROVER = APP.EMP_CODE LEFT OUTER JOIN
		dbo.TRAFFIC_ROLE TR ON E.DEF_TRF_ROLE = TR.ROLE_CODE LEFT OUTER JOIN
		(SELECT 
				DISTINCT SU.EMP_CODE 
			FROM 
				dbo.SEC_USER SU 
				INNER JOIN dbo.SEC_USER_SETTING SUS ON SUS.SEC_USER_ID = SU.SEC_USER_ID 
													   AND SUS.[SETTING_CODE] = 'TIME_ENTRY_ONLY' 
													   AND SUS.[STRING_VALUE] = 'Y') AS WVOU ON WVOU.EMP_CODE = E.EMP_CODE LEFT OUTER JOIN
		(SELECT 
				DISTINCT SU.EMP_CODE 
			FROM 
				dbo.SEC_USER SU 
				INNER JOIN dbo.SEC_USER_SETTING SUS ON SUS.SEC_USER_ID = SU.SEC_USER_ID 
													   AND SUS.[SETTING_CODE] = 'IsMediaToolsUser' 
													   AND ISNULL(SUS.[STRING_VALUE], '') <> '') AS MTU ON MTU.EMP_CODE = E.EMP_CODE
		
GO