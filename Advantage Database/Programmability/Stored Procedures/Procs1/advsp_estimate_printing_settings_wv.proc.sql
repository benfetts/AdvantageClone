CREATE PROCEDURE [dbo].[advsp_estimate_printing_settings_wv] ( 
	@IsOneTime AS bit,
	@UserID AS varchar(100)
)
AS
BEGIN
	
	SELECT
			[UserID] = ISNULL([USER_ID], ''),
            [SelectBy] = ISNULL(SELECT_BY, ''),
            [DateToPrint] = CASE WHEN ISNULL(DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END,
			[DatePrint] = GETDATE(),
            [LogoPath] = ISNULL(LOGO_PATH, ''), 
            [LocationCode] = ISNULL(LOCATION_ID, ''),
            [ReportTitle] = ISNULL(RPT_TITLE, ''),
            [PrintClientName] = CAST(ISNULL(PRT_CL_NAME, 0) AS bit), 
            [PrintDivisionName] = CAST(ISNULL(PRT_DIV_NAME, 0) AS bit), 
            [PrintProductDescription] = CAST(ISNULL(PRT_PRD_NAME, 0) AS bit),
            [CDPAddressOption] = ISNULL(CDP_ADDRESS, ''), 
            [IncludeClientReference] =  CAST(ISNULL(CLI_REF, 0) AS bit),  
            [IncludeAccountExecutive] = CAST(ISNULL(AE_NAME, 0) AS bit),
            [IncludeSalesClass] = CAST(ISNULL(PRT_SALES_CLASS, 0) AS bit),
            [IncludeJobDueDate] = CAST(ISNULL(JOB_DUE_DATE, 0) AS bit),
            [IncludeJobQuantity] = CAST(ISNULL(JOB_QTY, 0) AS bit),
            [SuppressZeroFunctions] = CAST(ISNULL(SUPPRESS_ZERO, 0) AS bit),
            [IncludeNonBillable] = CAST(ISNULL(PRT_NONBILL, 0) AS bit),
            [IncludeQuantityHours] = CAST(ISNULL(QTY_HRS, 0) AS bit), 
            [IncludeRate] = CAST(ISNULL(INCL_RATE, 0) AS bit),
            [SubtotalsOnly] = CAST(ISNULL(SUBTOT_ONLY, 0) AS bit), 
            [IncludeCPU] = CAST(ISNULL(PRT_CPU, 0) AS bit) , 
            [IncludeCPM] = CAST(ISNULL(PRT_CPM, 0) AS bit),
            [HideComponentDescription] = CAST(ISNULL(HIDE_COMP_DESC, 0) AS bit),  
            [HideRevision] = CAST(ISNULL(HIDE_REVISION, 0) AS bit),
            [IncludeEstimateComment] = CAST(ISNULL(EST_COMMENT, 0) AS bit),   
            [IncludeEstimateComponentComment] = CAST(ISNULL(EST_COMP_COMMENT, 0) AS bit),
            [IncludeEstimateQuoteComment] = CAST(ISNULL(QTE_COMMENT, 0) AS bit),
            [IncludeEstimateRevisionComment] = CAST(ISNULL(REV_COMMENT, 0) AS bit), 
            [IncludeEstimateFunctionComment] = CAST(ISNULL(FUNC_COMMENT, 0) AS bit),
            [IncludeSuppliedByNotes] = CAST(ISNULL(SUP_BY_NOTES, 0) AS bit),
            [ReportFormat] = CASE WHEN ISNULL(REPORT_FORMAT, '') = '001' THEN '1'
								  WHEN ISNULL(REPORT_FORMAT, '') = '002' THEN '2'
								  WHEN ISNULL(REPORT_FORMAT, '') = '003' THEN '3'
								  WHEN ISNULL(REPORT_FORMAT, '') = '004' THEN '4'
								  WHEN ISNULL(REPORT_FORMAT, '') = '005' THEN '5'
								  WHEN ISNULL(REPORT_FORMAT, '') = '006' THEN '6'
								  WHEN ISNULL(REPORT_FORMAT, '') = '007' THEN '7'
								  WHEN ISNULL(REPORT_FORMAT, '') = '008' THEN '8'
								  WHEN ISNULL(REPORT_FORMAT, '') = '009' THEN '9'
								  WHEN ISNULL(REPORT_FORMAT, '') = '300' THEN '10'
								  WHEN ISNULL(REPORT_FORMAT, '') = '301' THEN '11'
								  WHEN ISNULL(REPORT_FORMAT, '') = '302' THEN '12'
								  WHEN ISNULL(REPORT_FORMAT, '') = '303' THEN '13'
								  WHEN ISNULL(REPORT_FORMAT, '') = '304' THEN '14'
								  WHEN ISNULL(REPORT_FORMAT, '') = '305' THEN '15'
								  WHEN ISNULL(REPORT_FORMAT, '') = '306' THEN '16'
								  WHEN ISNULL(REPORT_FORMAT, '') = '307' THEN '17'
								  WHEN ISNULL(REPORT_FORMAT, '') = '308' THEN '18'
								  WHEN ISNULL(REPORT_FORMAT, '') = '309' THEN '19'
								  WHEN ISNULL(REPORT_FORMAT, '') = '310' THEN '20'
								  WHEN ISNULL(REPORT_FORMAT, '') = '311' THEN '21'
								  WHEN ISNULL(REPORT_FORMAT, '') = '312' THEN '22'
								  WHEN ISNULL(REPORT_FORMAT, '') = '313' THEN '23'
								  WHEN ISNULL(REPORT_FORMAT, '') = '314' THEN '24' ELSE '1' END,  
            [CombineComponents] = CAST(ISNULL(COMBINE_COMPS, 0) AS bit),
            [ExcludeEmployeeTime] = CAST(ISNULL(EXCL_EMP_TIME, 0) AS bit),  
            [ExcludeVendor] = CAST(ISNULL(EXCL_VENDOR, 0) AS bit),
            [ExcludeIncomeOnly] = CAST(ISNULL(EXCL_IO, 0) AS bit),
            [ExcludeNonbillable] = CAST(ISNULL(EXCL_NONBILL, 0) AS bit),
            [ConsolidationOverride] = CAST(ISNULL(CONSOL_OVERRIDE, 0) AS bit),
            [GroupingOptionFunctionOption] = CASE WHEN ISNULL(FUNCTION_OPTION, '') = 'F' THEN '1'
												  WHEN ISNULL(FUNCTION_OPTION, '') = 'C' THEN '2'
												  WHEN ISNULL(FUNCTION_OPTION, '') = 'T' THEN '3'
												  WHEN ISNULL(FUNCTION_OPTION, '') = 'R' THEN '4'
												  WHEN ISNULL(FUNCTION_OPTION, '') = 'N' THEN '5' ELSE '1' END, 
            [GroupingOptionGroupOption] = CASE WHEN ISNULL(GROUP_OPTION, '') = 'N' THEN '1'
											   WHEN ISNULL(GROUP_OPTION, '') = 'T' THEN '2'
											   WHEN ISNULL(GROUP_OPTION, '') = 'H' THEN '3'
											   WHEN ISNULL(GROUP_OPTION, '') = 'HT' THEN '4'
											   WHEN ISNULL(GROUP_OPTION, '') = 'I' THEN '5'
											   WHEN ISNULL(GROUP_OPTION, '') = 'P' THEN '6' ELSE '1' END,
            [GroupingOptionInsideDescription] = ISNULL(INSIDE_CHG_DESC, ''),
            [GroupingOptionOutsideDescription] =  ISNULL(OUTSIDE_CHG_DESC, ''),
            [GroupingOptionSortOption] = CASE WHEN ISNULL(SORT_OPTION, '') = 'C' THEN '1'
											  WHEN ISNULL(SORT_OPTION, '') = 'O' THEN '2' ELSE '1' END, 
            [TotalsShowTaxSeparately] = CAST(ISNULL(TAX_SEPARATE, 0) AS bit),
            [IndicateTaxableFunctions] = CAST(ISNULL(TAX_INDICATOR, 0) AS bit),
            [TotalsShowCommissionSeparately] = CAST(ISNULL(COMM_MU_SEPARATE, 0) AS bit),
            [IndicateCommissionFunctions] = CAST(ISNULL(COMM_MU_INDICATOR, 0) AS bit),
            [TotalsShowContingencySeparately] = CAST(ISNULL(CONT_SEPARATE, 0) AS bit),
            [TotalsIncludeContingency] = CAST(ISNULL(CONTINGENCY, 0) AS bit),
            [DefaultFooterComment] = CAST(ISNULL(DEF_FOOTER_COMMENT, 0) AS bit),
            [Signature] = ISNULL([SIGNATURE], 999),
            [ExcludeSignatures] = CAST(ISNULL(EXCL_SIGNATURES, 0) AS bit),
            [IncludeSpecifications] = CAST(ISNULL(SPECS, 0) AS bit),
            [UseEmployeeSignature] = CAST(ISNULL(USE_EMP_SIG, 0) AS bit),
            [IncludeCampaignSummary] = CAST(ISNULL(CMP_SUMMARY, 0) AS bit),
            [IncludeVendorDescription] = CAST(ISNULL(VENDOR_DESC, 0) AS bit), 
            [IncludeFunctionComment] = CAST(ISNULL(FNC_COMMENT, 0) AS bit), 
            [PrintAdNumber] = CAST(ISNULL(PRT_AD_NBR, 0) AS bit)
	FROM   ESTIMATE_PRINT_DEF
	WHERE  (UPPER(USER_ID) = UPPER(@UserID))




END



GO


