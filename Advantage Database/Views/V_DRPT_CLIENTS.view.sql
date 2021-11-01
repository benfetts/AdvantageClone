CREATE VIEW [dbo].[V_DRPT_CLIENTS]

WITH SCHEMABINDING 
AS

	SELECT 
		[ID] = NEWID(),
		[ClientCode] = C.CL_CODE,
		[ClientName] = C.CL_NAME, 
		[Address] = C.CL_ADDRESS1,
		[Address2] = C.CL_ADDRESS2,
		[City] = C.CL_CITY,
		[County] = C.CL_COUNTY,
		[State] = C.CL_STATE,
		[Zip] = C.CL_ZIP,
		[Country] = C.CL_COUNTRY,        
		[NewBusiness] = CASE WHEN C.NEW_BUSINESS = 1 THEN 'Y' ELSE 'N' END,
		[IsActive] = CASE WHEN C.ACTIVE_FLAG = 1 THEN 'Y' Else 'N' END,
		[SortName] = C.CL_ALPHA_SORT,
		[BillingAddress] = C.CL_BADDRESS1,
		[BillingAddress2] = C.CL_BADDRESS2,
		[BillingCity] = C.CL_BCITY,
		[BillingCounty] = C.CL_BCOUNTY,
		[BillingState] = C.CL_BSTATE,
		[BillingZip] = C.CL_BZIP,
		[BillingCountry] = C.CL_BCOUNTRY,
		[StatementAddress] = C.CL_SADDRESS1,
		[StatementAddress2] = C.CL_SADDRESS2,
		[StatementCity] = C.CL_SCITY,
		[StatementCounty] = C.CL_SCOUNTY,
		[StatementState] = C.CL_SSTATE,
		[StatementZip] = C.CL_SZIP,
		[StatementCountry] = C.CL_SCOUNTRY,
		[FiscalStart] = CASE C.CL_FISCAL_START WHEN 1 THEN 'January'
											   WHEN 2 THEN 'February'
											   WHEN 3 THEN 'March'
											   WHEN 4 THEN 'April'
											   WHEN 5 THEN 'May'
											   WHEN 6 THEN 'June'
											   WHEN 7 THEN 'July'
											   WHEN 8 THEN 'August'
											   WHEN 9 THEN 'September'
											   WHEN 10 THEN 'October'
											   WHEN 11 THEN 'November'
											   WHEN 12 THEN 'December'
						END,
		[CreditLimit] = C.CL_CREDIT_LIMIT,  
		[ARComment] = C.CL_AR_COMMENT,
		[AssignProductionInvoicesBy] = CASE C.CL_INV_BY WHEN 1 THEN 'Job'
														WHEN 2 THEN 'Job Component'
														WHEN 3 THEN 'Product / Sales Class'
														WHEN 4 THEN 'Campaign'
														WHEN 5 THEN 'Purchase Order'
														WHEN 6 THEN 'Client'
														WHEN 7 THEN 'Division'
														WHEN 8 THEN 'Product' END,

		[ProductionInvoiceType] = CASE WHEN PID.CUSTOM_FORMAT IS NOT NULL THEN 'Custom' ELSE CASE WHEN PID.USE_AGENCY_SETTING = 1 THEN 'Agency Default' ELSE 'Client' END END,
		[ProductionInvoiceFormat] = AF.[DESCRIPTION],
		[ProductionAttentionLine] = C.CL_ATTENTION,
		[ProductionFooterComments] = C.CL_FOOTER,
		[ProductionDaysToPay] = C.CL_P_PAYDAYS,

		[AssignMediaInvoicesBy] = CASE C.CL_MINV_BY WHEN 1 THEN 'Sales Class'
													WHEN 2 THEN 'Client P.O.'
													WHEN 3 THEN 'Market'
													WHEN 4 THEN 'Order #'
													WHEN 5 THEN 'Campaign'
													WHEN 6 THEN 'Order Type' END,
		[MediaAttentionLine] = C.CL_MATTENTION,
		[MediaFooterComments] = C.CL_MFOOTER,
		[MediaDaysToPay] = C.CL_M_PAYDAYS,
		
		[MagazineInvoiceType] = CASE WHEN MID.M_CUSTOM_FORMAT IS NOT NULL THEN 'Custom' ELSE CASE WHEN MID.M_USE_AGENCY_SETTING = 1 THEN 'Agency Default' ELSE 'Client' END END,
		[MagazineInvoiceFormat] = AFM.[DESCRIPTION],
		
		[NewspaperInvoiceType] = CASE WHEN NID.N_CUSTOM_FORMAT IS NOT NULL THEN 'Custom' ELSE CASE WHEN NID.N_USE_AGENCY_SETTING = 1 THEN 'Agency Default' ELSE 'Client' END END,
		[NewspaperInvoiceFormat] = AFN.[DESCRIPTION],

		[InternetInvoiceType] = CASE WHEN IID.I_CUSTOM_FORMAT IS NOT NULL THEN 'Custom' ELSE CASE WHEN IID.I_USE_AGENCY_SETTING = 1 THEN 'Agency Default' ELSE 'Client' END END,
		[InternetInvoiceFormat] = AFI.[DESCRIPTION],
		
		[OutOfHomeInvoiceType] = CASE WHEN OID.O_CUSTOM_FORMAT IS NOT NULL THEN 'Custom' ELSE CASE WHEN OID.O_USE_AGENCY_SETTING = 1 THEN 'Agency Default' ELSE 'Client' END END,
		[OutOfHomeInvoiceFormat] = AFO.[DESCRIPTION],
		
		[RadioInvoiceType] = CASE WHEN RID.R_CUSTOM_FORMAT IS NOT NULL THEN 'Custom' ELSE CASE WHEN RID.R_USE_AGENCY_SETTING = 1 THEN 'Agency Default' ELSE 'Client' END END,
		[RadioInvoiceFormat] = AFR.[DESCRIPTION],
		
		[TelevisionInvoiceType] = CASE WHEN TID.T_CUSTOM_FORMAT IS NOT NULL THEN 'Custom' ELSE CASE WHEN TID.T_USE_AGENCY_SETTING = 1 THEN 'Agency Default' ELSE 'Client' END END,
		[TelevisionInvoiceFormat] = AFT.[DESCRIPTION],

		[OverrideAgencySettings] = CASE WHEN C.REQ_FLDS = 1 THEN 'Y' ELSE 'N' END,
		[AccountNumberRequired] = CASE WHEN C.ACCT_NBR_R = 1 THEN 'Y' ELSE 'N' END,
		[AdNumberRequired] = CASE WHEN C.AD_NBR_R = 1 THEN 'Y' ELSE 'N' END,
		[AlertGroupRequired] = CASE WHEN C.EMAIL_GR_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[Blackplate1Required] = CASE WHEN C.BLACKPLATE_VER_R = 1 THEN 'Y' ELSE 'N' END,
		[Blackplate2Required] = CASE WHEN C.BLACKPLATE_VER2_R = 1 THEN 'Y' ELSE 'N' END,
		[ComponentBudgetRequired] = CASE WHEN C.JOB_COMP_BUDGET_R = 1 THEN 'Y' ELSE 'N' END,
		[ClientReferenceRequired] = CASE WHEN C.JOB_CLI_REF_R = 1 THEN 'Y' ELSE 'N' END,
		[ComplexityCodeRequired] = CASE WHEN C.COMPLEX_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[ProductContactRequired] = CASE WHEN C.PROD_CONT_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[CoopBillingCodeRequired] = CASE WHEN C.BILL_COOP_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[DateOpenedRequired] = CASE WHEN C.JOB_DATE_OPENED_R = 1 THEN 'Y' ELSE 'N' END,
		[DepartmentCodeRequired] = CASE WHEN C.DP_TM_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[DueDateRequired] = CASE WHEN C.JOB_FIRST_USE_DT_R = 1 THEN 'Y' ELSE 'N' END,
		[FormatRequired] = CASE WHEN C.JOB_AD_SIZE_R = 1 THEN 'Y' ELSE 'N' END,
		[JobTypeRequired] = CASE WHEN C.JT_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[MarketCodeRequired] = CASE WHEN C.MARKET_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[PromotionRequired] = CASE WHEN C.PROMO_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[SCFormatRequired] = CASE WHEN C.FORMAT_SC_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[ServiceFeeTypeRequired] = CASE WHEN C.SERVICE_FEE_TYPE_R = 1 THEN 'Y' ELSE 'N' END,
		[TaxFlagRequired] = CASE WHEN C.TAX_FLAG_R = 1 THEN 'Y' ELSE 'N' END,
		[JobLogCustom1] = CASE WHEN C.JOB_LOG_UDV1_R = 1 THEN 'Y' ELSE 'N' END,
		[JobLogCustom2] = CASE WHEN C.JOB_LOG_UDV2_R = 1 THEN 'Y' ELSE 'N' END,
		[JobLogCustom3] = CASE WHEN C.JOB_LOG_UDV3_R = 1 THEN 'Y' ELSE 'N' END,
		[JobLogCustom4] = CASE WHEN C.JOB_LOG_UDV4_R = 1 THEN 'Y' ELSE 'N' END,
		[JobLogCustom5] = CASE WHEN C.JOB_LOG_UDV5_R = 1 THEN 'Y' ELSE 'N' END,
		[JobCustomComponent1Required] = CASE WHEN C.JOB_CMP_UDV1_R = 1 THEN 'Y' ELSE 'N' END,
		[JobCustomComponent2Required] = CASE WHEN C.JOB_CMP_UDV2_R = 1 THEN 'Y' ELSE 'N' END,
		[JobCustomComponent3Required] = CASE WHEN C.JOB_CMP_UDV3_R = 1 THEN 'Y' ELSE 'N' END,
		[JobCustomComponent4Required] = CASE WHEN C.JOB_CMP_UDV4_R = 1 THEN 'Y' ELSE 'N' END,
		[JobCustomComponent5Required] = CASE WHEN C.JOB_CMP_UDV5_R = 1 THEN 'Y' ELSE 'N' END,
		[CampaignCodeRequired] = CASE WHEN C.CMP_CODE_R = 1 THEN 'Y' ELSE 'N' END,
		[FiscalPeriodRequired] = CASE WHEN C.FISCAL_PD_R = 1 THEN 'Y' ELSE 'N' END,
		[ProductCategoryInTimesheetRequired] = CASE WHEN C.REQ_PROD_CAT = 1 THEN 'Y' ELSE 'N' END,
		[RequireTimeComment] = CASE WHEN C.REQ_TIME_COMMENT = 1 THEN 'Y' ELSE 'N' END,
		--[ContractExpirationDate] = C.CONTRACT_EXP_DT
		[ClientDiscountCode] =  CASE WHEN  C.CLIENT_DISCOUNT_CODE IS NOT NULL THEN  C.CLIENT_DISCOUNT_CODE ELSE '' END,
		[ClientDiscountDescription]  = CASE WHEN  CD.NAME IS NOT NULL THEN  CD.NAME ELSE '' END,
		[Biller] = ISNULL(E.EMP_FNAME+' ', '')+ISNULL(E.EMP_MI+'. ', '')+ISNULL(E.EMP_LNAME, '')
		
	FROM
		dbo.CLIENT C LEFT OUTER JOIN
		dbo.PROD_INV_DEF PID ON C.CL_CODE = PID.CL_CODE LEFT OUTER JOIN dbo.ACCESS_FORMAT AF ON PID.CUSTOM_FORMAT = AF.REPORT_NAME AND AF.MODULE='PI' LEFT OUTER JOIN
		dbo.MEDIA_INV_DEF MID ON C.CL_CODE = MID.CL_CODE LEFT OUTER JOIN dbo.ACCESS_FORMAT AFM ON MID.M_CUSTOM_FORMAT = AFM.REPORT_NAME AND AFM.MODULE='MI' LEFT OUTER JOIN
		dbo.MEDIA_INV_DEF NID ON C.CL_CODE = NID.CL_CODE LEFT OUTER JOIN dbo.ACCESS_FORMAT AFN ON NID.N_CUSTOM_FORMAT = AFN.REPORT_NAME AND AFN.MODULE='NI' LEFT OUTER JOIN
		dbo.MEDIA_INV_DEF IID ON C.CL_CODE = IID.CL_CODE LEFT OUTER JOIN dbo.ACCESS_FORMAT AFI ON IID.I_CUSTOM_FORMAT = AFI.REPORT_NAME AND AFI.MODULE='II' LEFT OUTER JOIN
		dbo.MEDIA_INV_DEF OID ON C.CL_CODE = OID.CL_CODE LEFT OUTER JOIN dbo.ACCESS_FORMAT AFO ON OID.O_CUSTOM_FORMAT = AFO.REPORT_NAME AND AFO.MODULE='OI' LEFT OUTER JOIN
		dbo.MEDIA_INV_DEF RID ON C.CL_CODE = RID.CL_CODE LEFT OUTER JOIN dbo.ACCESS_FORMAT AFR ON RID.R_CUSTOM_FORMAT = AFR.REPORT_NAME AND AFR.MODULE='RI' LEFT OUTER JOIN
		dbo.MEDIA_INV_DEF TID ON C.CL_CODE = TID.CL_CODE LEFT OUTER JOIN dbo.ACCESS_FORMAT AFT ON TID.T_CUSTOM_FORMAT = AFT.REPORT_NAME AND AFT.MODULE='TI' LEFT OUTER JOIN
		dbo.CLIENT_DISCOUNT CD ON C.CLIENT_DISCOUNT_CODE = CD.CLIENT_DISCOUNT_CODE LEFT OUTER JOIN
		dbo.EMPLOYEE_CLOAK E ON C.BILLER_EMP_CODE = E.EMP_CODE
		
GO