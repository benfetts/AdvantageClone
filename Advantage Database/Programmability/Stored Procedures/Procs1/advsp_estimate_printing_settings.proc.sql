if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_estimate_printing_settings]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_estimate_printing_settings]
GO


CREATE PROCEDURE [dbo].[advsp_estimate_printing_settings] ( 
	@IsOneTime AS bit,
	@ClientOrProduct as smallint
)
AS
BEGIN

--if @ClientOrProduct = 2
--Begin
--	SELECT
--		[ID] = EST.ID,	
--		[IsOneTime] = EST.IsOneTime,
--		[Type] = EST.[Type],
--		[UserID] = EST.[UserID],
--		[ClientCode] = EST.ClientCode,
--		[DivisionCode] = EST.DivisionCode,
--		[ProductCode] = EST.ProductCode,
--		[CDP] = EST.CDP,
--		[SelectBy] = EST.SelectBy,
--		[DateToPrint] = EST.DateToPrint,
--		[DatePrint] = EST.DatePrint,
--		[UseLocationOptions] = EST.UseLocationOptions,
--        [LogoPath] = EST.LogoPath, 
--        [LocationCode] = EST.LocationCode,
--		[ReportTitle] = EST.ReportTitle,
--		[PrintClientName] = EST.PrintClientName,
--		[PrintDivisionName] = EST.PrintDivisionName,
--		[PrintProductDescription] = EST.PrintProductDescription,
--		[CDPAddressOption] = EST.CDPAddressOption,
--		[IncludeClientReference] = EST.IncludeClientReference,
--		[IncludeAccountExecutive] = EST.IncludeAccountExecutive,
--		[IncludeSalesClass] = EST.IncludeSalesClass,
--		[IncludeJobDueDate] = EST.IncludeJobDueDate,
--		[IncludeJobQuantity] = EST.IncludeJobQuantity,
--		[SuppressZeroFunctions] = EST.SuppressZeroFunctions,
--		[IncludeNonBillable] = EST.IncludeNonBillable,
--        [IncludeQuantityHours] = EST.IncludeQuantityHours,
--        [IncludeRate] = EST.IncludeRate,
--        [SubtotalsOnly] = EST.SubtotalsOnly,
--        [IncludeCPU] = EST.IncludeCPU,
--        [IncludeCPM] = EST.IncludeCPM,
--        [HideJobDescription] = EST.HideJobDescription,
--        [HideComponentDescription] = EST.HideComponentDescription,
--        [HideRevision] = EST.HideRevision,
--		[IncludeEstimateComment] = EST.IncludeEstimateComment,
--		[IncludeEstimateComponentComment] = EST.IncludeEstimateComponentComment,
--		[IncludeEstimateQuoteComment] = EST.IncludeEstimateQuoteComment,
--		[IncludeEstimateRevisionComment] = EST.IncludeEstimateRevisionComment,
--		[IncludeEstimateFunctionComment] = EST.IncludeEstimateFunctionComment,
--		[IncludeSuppliedByNotes] = EST.IncludeSuppliedByNotes,
--        [ReportFormat] = EST.ReportFormat,
--		[SummaryLevel] = EST.SummaryLevel,
--        [ExcludeEmployeeTime] = EST.ExcludeEmployeeTime,
--        [ExcludeVendor] = EST.ExcludeVendor,
--        [ExcludeIncomeOnly] = EST.ExcludeIncomeOnly,
--        [ExcludeNonbillable] = EST.ExcludeNonbillable,
--        [ConsolidationOverride] = EST.ConsolidationOverride,
--        [GroupingOptionFunctionOption] = EST.GroupingOptionFunctionOption, 
--        [GroupingOptionGroupOption] = EST.GroupingOptionGroupOption,
--        [GroupingOptionInsideDescription] = EST.GroupingOptionInsideDescription, 
--        [GroupingOptionOutsideDescription] = EST.GroupingOptionOutsideDescription, 
--        [GroupingOptionSortOption] = EST.GroupingOptionSortOption, 
--        [TotalsShowTaxSeparately] = EST.TotalsShowTaxSeparately,
--        [IndicateTaxableFunctions] = EST.IndicateTaxableFunctions,
--        [TotalsShowCommissionSeparately] = EST.TotalsShowCommissionSeparately,
--        [IndicateCommissionFunctions] = EST.IndicateCommissionFunctions,
--        [TotalsShowContingencySeparately] = EST.TotalsShowContingencySeparately,
--        [TotalsIncludeContingency] = EST.TotalsIncludeContingency,
--        [DefaultFooterComment] = EST.DefaultFooterComment,
--        [Signature] = EST.[Signature],
--        [ExcludeSignatures] = EST.ExcludeSignatures,
--        --[IncludeSpecifications] = EST.IncludeSpecifications,
--        [UseEmployeeSignature] = EST.UseEmployeeSignature,
--        [IncludeCampaignSummary] = EST.IncludeCampaignSummary,
--        [IncludeVendorDescription] = EST.IncludeVendorDescription,
--        [IncludeFunctionComment] = EST.IncludeFunctionComment,
--        [PrintAdNumber] = EST.PrintAdNumber,
--		[CustomEstimateID] = CASE WHEN EST.CustomEstimateID = 0 THEN NULL ELSE EST.CustomEstimateID END,
--		[ShowCodes] = EST.ShowCodes,
--		[ContactType] = EST.ContactType,
--        [PrintContactAfterAddress] = EST.PrintContactAfterAddress
--	FROM
--		(SELECT
--			[ID] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PROD_EST_DEF_ID, AD.PROD_EST_DEF_ID) ELSE OT.PROD_EST_DEF_ID END, 0) AS int),
--			[IsOneTime] = CAST(ISNULL(@IsOneTime, 0) AS bit),		
--			[Type] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CLIENT_OR_DEF, AD.CLIENT_OR_DEF) ELSE OT.CLIENT_OR_DEF END AS smallint),
--			--[ClientOrDefault] = CLIENT_OR_DEF,
--			[UserID] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.[USER_ID], ISNULL(AD.[USER_ID], '')) ELSE ISNULL(OT.[USER_ID], '') END,
--			[ClientCode] = ISNULL(P.CL_CODE,''),
--			[DivisionCode] = ISNULL(P.DIV_CODE,''),
--			[ProductCode] = ISNULL(P.PRD_CODE,''),
--			[CDP] = ISNULL(P.CL_CODE,'') + '|' + ISNULL(P.DIV_CODE,'') + '|' + ISNULL(P.PRD_CODE,''),
--            [SelectBy] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SELECT_BY, ISNULL(AD.SELECT_BY, '')) ELSE ISNULL(OT.SELECT_BY, '') END,
--            [DateToPrint] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CASE WHEN ISNULL(CD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END, CASE WHEN ISNULL(AD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END) ELSE CASE WHEN ISNULL(OT.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END END, 0) AS bit),
--			[DatePrint] = GETDATE(),
--			[UseLocationOptions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.USE_LOCATION_OPTIONS, AD.USE_LOCATION_OPTIONS) ELSE OT.USE_LOCATION_OPTIONS END, 0) AS bit),
--            [LogoPath] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.LOGO_PATH, ISNULL(AD.LOGO_PATH, '')) ELSE ISNULL(OT.LOGO_PATH, '') END, 
--            [LocationCode] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.LOCATION_ID, ISNULL(AD.LOCATION_ID, '')) ELSE ISNULL(OT.LOCATION_ID, '') END,
--            [ReportTitle] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.RPT_TITLE, ISNULL(AD.RPT_TITLE, '')) ELSE ISNULL(OT.RPT_TITLE, '') END,
--            [PrintClientName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CL_NAME, AD.PRT_CL_NAME) ELSE OT.PRT_CL_NAME END, 0) AS bit),
--            [PrintDivisionName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_DIV_NAME, AD.PRT_DIV_NAME) ELSE OT.PRT_DIV_NAME END, 0) AS bit),
--            [PrintProductDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_PRD_NAME, AD.PRT_PRD_NAME) ELSE OT.PRT_PRD_NAME END, 0) AS bit),
--            [CDPAddressOption] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CDP_ADDRESS, ISNULL(AD.CDP_ADDRESS, '')) ELSE ISNULL(OT.CDP_ADDRESS, '') END,
--            [IncludeClientReference] =  CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CLI_REF, AD.CLI_REF) ELSE OT.CLI_REF END, 0) AS bit),
--            [IncludeAccountExecutive] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.AE_NAME, AD.AE_NAME) ELSE OT.AE_NAME END, 0) AS bit),
--            [IncludeSalesClass] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_SALES_CLASS, AD.PRT_SALES_CLASS) ELSE OT.PRT_SALES_CLASS END, 0) AS bit),
--            [IncludeJobDueDate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.JOB_DUE_DATE, AD.JOB_DUE_DATE) ELSE OT.JOB_DUE_DATE END, 0) AS bit),
--            [IncludeJobQuantity] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.JOB_QTY, AD.JOB_QTY) ELSE OT.JOB_QTY END, 0) AS bit),
--            [SuppressZeroFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUPPRESS_ZERO, AD.SUPPRESS_ZERO) ELSE OT.SUPPRESS_ZERO END, 0) AS bit),
--            [IncludeNonBillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_NONBILL, AD.PRT_NONBILL) ELSE OT.PRT_NONBILL END, 0) AS bit),
--            [IncludeQuantityHours] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.QTY_HRS, AD.QTY_HRS) ELSE OT.QTY_HRS END, 0) AS bit),
--            [IncludeRate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.INCL_RATE, AD.INCL_RATE) ELSE OT.INCL_RATE END, 0) AS bit),
--            [SubtotalsOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUBTOT_ONLY, AD.SUBTOT_ONLY) ELSE OT.SUBTOT_ONLY END, 0) AS bit),
--            [IncludeCPU] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CPU, AD.PRT_CPU) ELSE OT.PRT_CPU END, 0) AS bit),
--            [IncludeCPM] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CPM, AD.PRT_CPM) ELSE OT.PRT_CPM END, 0) AS bit),
--			[HideJobDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.HIDE_JOB_DESC, AD.HIDE_JOB_DESC) ELSE OT.HIDE_JOB_DESC END, 0) AS bit),
--            [HideComponentDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.HIDE_COMP_DESC, AD.HIDE_COMP_DESC) ELSE OT.HIDE_COMP_DESC END, 0) AS bit),
--            [HideRevision] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.HIDE_REVISION, AD.HIDE_REVISION) ELSE OT.HIDE_REVISION END, 0) AS bit),
--            [IncludeEstimateComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EST_COMMENT, AD.EST_COMMENT) ELSE OT.EST_COMMENT END, 0) AS bit),  
--            [IncludeEstimateComponentComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EST_COMP_COMMENT, AD.EST_COMP_COMMENT) ELSE OT.EST_COMP_COMMENT END, 0) AS bit),
--            [IncludeEstimateQuoteComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.QTE_COMMENT, AD.QTE_COMMENT) ELSE OT.QTE_COMMENT END, 0) AS bit),
--            [IncludeEstimateRevisionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.REV_COMMENT, AD.REV_COMMENT) ELSE OT.REV_COMMENT END, 0) AS bit),
--            [IncludeEstimateFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.FUNC_COMMENT, AD.FUNC_COMMENT) ELSE OT.FUNC_COMMENT END, 0) AS bit),
--            [IncludeSuppliedByNotes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUP_BY_NOTES, AD.SUP_BY_NOTES) ELSE OT.SUP_BY_NOTES END, 0) AS bit),
--            [ReportFormat] = CASE @IsOneTime WHEN 0 THEN  
--							 CASE WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '001' THEN '1'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '002' THEN '2'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '003' THEN '3'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '004' THEN '4'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '005' THEN '5'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '006' THEN '6'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '007' THEN '7'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '008' THEN '8'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '009' THEN '9'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '300' THEN '10'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '301' THEN '11'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '302' THEN '12'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '303' THEN '13'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '304' THEN '14'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '305' THEN '15'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '306' THEN '16'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '307' THEN '17'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '308' THEN '18'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '309' THEN '19'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '310' THEN '20'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '311' THEN '21'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '312' THEN '22'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '313' THEN '23'
--								  WHEN ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) = '314' THEN '24' ELSE '1' END
--							ELSE CASE WHEN ISNULL(OT.REPORT_FORMAT, '') = '001' THEN '1'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '002' THEN '2'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '003' THEN '3'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '004' THEN '4'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '005' THEN '5'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '006' THEN '6'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '007' THEN '7'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '008' THEN '8'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '009' THEN '9'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '300' THEN '10'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '301' THEN '11'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '302' THEN '12'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '303' THEN '13'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '304' THEN '14'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '305' THEN '15'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '306' THEN '16'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '307' THEN '17'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '308' THEN '18'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '309' THEN '19'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '310' THEN '20'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '311' THEN '21'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '312' THEN '22'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '313' THEN '23'
--								  WHEN ISNULL(OT.REPORT_FORMAT, '') = '314' THEN '24' ELSE '1' END END,
--            [SummaryLevel] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUMMARY_LEVEL, ISNULL(AD.SUMMARY_LEVEL,0)) ELSE ISNULL(OT.SUMMARY_LEVEL,0) END AS smallint),
--            [ExcludeEmployeeTime] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_EMP_TIME, AD.EXCL_EMP_TIME) ELSE OT.EXCL_EMP_TIME END, 0) AS bit),
--            [ExcludeVendor] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_VENDOR, AD.EXCL_VENDOR) ELSE OT.EXCL_VENDOR END, 0) AS bit),
--            [ExcludeIncomeOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_IO, AD.EXCL_IO) ELSE OT.EXCL_IO END, 0) AS bit),
--            [ExcludeNonbillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_NONBILL, AD.EXCL_NONBILL) ELSE OT.EXCL_NONBILL END, 0) AS bit),
--            [ConsolidationOverride] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONSOL_OVERRIDE, AD.CONSOL_OVERRIDE) ELSE OT.CONSOL_OVERRIDE END, 0) AS bit),
--            [GroupingOptionFunctionOption] = CASE @IsOneTime WHEN 0 THEN 
--										     CASE WHEN ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) = 'F' THEN '1'
--												  WHEN ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) = 'C' THEN '2'
--												  WHEN ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) = 'T' THEN '3'
--												  WHEN ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) = 'R' THEN '4'
--												  WHEN ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) = 'N' THEN '5' ELSE '1' END
--											 ELSE CASE WHEN ISNULL(OT.FUNCTION_OPTION, '') = 'F' THEN '1'
--												  WHEN ISNULL(OT.FUNCTION_OPTION, '') = 'C' THEN '2'
--												  WHEN ISNULL(OT.FUNCTION_OPTION, '') = 'T' THEN '3'
--												  WHEN ISNULL(OT.FUNCTION_OPTION, '') = 'R' THEN '4'
--												  WHEN ISNULL(OT.FUNCTION_OPTION, '') = 'N' THEN '5' ELSE '1' END END, 	   
--            [GroupingOptionGroupOption] = CASE @IsOneTime WHEN 0 THEN 
--										      CASE WHEN ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) = 'N' THEN '1'
--												   WHEN ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) = 'T' THEN '2'
--												   WHEN ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) = 'H' THEN '3'
--												   WHEN ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) = 'HT' THEN '4'
--												   WHEN ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) = 'I' THEN '5'
--												   WHEN ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) = 'P' THEN '6' ELSE '1' END
--											 ELSE CASE WHEN ISNULL(OT.GROUP_OPTION, '') = 'N' THEN '1'
--												   WHEN ISNULL(OT.GROUP_OPTION, '') = 'T' THEN '2'
--												   WHEN ISNULL(OT.GROUP_OPTION, '') = 'H' THEN '3'
--												   WHEN ISNULL(OT.GROUP_OPTION, '') = 'HT' THEN '4'
--												   WHEN ISNULL(OT.GROUP_OPTION, '') = 'I' THEN '5'
--												   WHEN ISNULL(OT.GROUP_OPTION, '') = 'P' THEN '6' ELSE '1' END END, 
--            [GroupingOptionInsideDescription] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.INSIDE_CHG_DESC, ISNULL(AD.INSIDE_CHG_DESC, '')) ELSE ISNULL(OT.INSIDE_CHG_DESC, '') END, 
--            [GroupingOptionOutsideDescription] =  CASE @IsOneTime WHEN 0 THEN ISNULL(CD.OUTSIDE_CHG_DESC, ISNULL(AD.OUTSIDE_CHG_DESC, '')) ELSE ISNULL(OT.OUTSIDE_CHG_DESC, '') END, 
--            [GroupingOptionSortOption] = CASE @IsOneTime WHEN 0 THEN 
--										      CASE WHEN ISNULL(CD.SORT_OPTION, ISNULL(AD.SORT_OPTION, '')) = 'C' THEN '1'
--											       WHEN ISNULL(CD.SORT_OPTION, ISNULL(AD.SORT_OPTION, '')) = 'O' THEN '2' ELSE '1' END
--											 ELSE CASE WHEN ISNULL(OT.SORT_OPTION, '') = 'C' THEN '1'
--													WHEN ISNULL(OT.SORT_OPTION, '') = 'O' THEN '2' ELSE '1' END END, 
--            [TotalsShowTaxSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.TAX_SEPARATE, AD.TAX_SEPARATE) ELSE OT.TAX_SEPARATE END, 0) AS bit),
--            [IndicateTaxableFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.TAX_INDICATOR, AD.TAX_INDICATOR) ELSE OT.TAX_INDICATOR END, 0) AS bit),
--            [TotalsShowCommissionSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.COMM_MU_SEPARATE, AD.COMM_MU_SEPARATE) ELSE OT.COMM_MU_SEPARATE END, 0) AS bit),
--            [IndicateCommissionFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.COMM_MU_INDICATOR, AD.COMM_MU_INDICATOR) ELSE OT.COMM_MU_INDICATOR END, 0) AS bit),
--            [TotalsShowContingencySeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONT_SEPARATE, AD.CONT_SEPARATE) ELSE OT.CONT_SEPARATE END, 0) AS bit),
--            [TotalsIncludeContingency] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONTINGENCY, AD.CONTINGENCY) ELSE OT.CONTINGENCY END, 0) AS bit),
--            [DefaultFooterComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.DEF_FOOTER_COMMENT, AD.DEF_FOOTER_COMMENT) ELSE OT.DEF_FOOTER_COMMENT END, 0) AS bit),
--            [Signature] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.[SIGNATURE], ISNULL(AD.[SIGNATURE], 999)) ELSE ISNULL(OT.[SIGNATURE], 999) END AS smallint),
--            [ExcludeSignatures] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_SIGNATURES, AD.EXCL_SIGNATURES) ELSE OT.EXCL_SIGNATURES END, 0) AS bit),
--            --[IncludeSpecifications] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SPECS, AD.SPECS) ELSE OT.SPECS END, 0) AS bit),CAST(ISNULL(SPECS, 0) AS bit),
--            [UseEmployeeSignature] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.USE_EMP_SIG, AD.USE_EMP_SIG) ELSE OT.USE_EMP_SIG END, 0) AS bit),
--            [IncludeCampaignSummary] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CMP_SUMMARY, AD.CMP_SUMMARY) ELSE OT.CMP_SUMMARY END, 0) AS bit),
--            [IncludeVendorDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.VENDOR_DESC, AD.VENDOR_DESC) ELSE OT.VENDOR_DESC END, 0) AS bit),
--            [IncludeFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.FNC_COMMENT, AD.FNC_COMMENT) ELSE OT.FNC_COMMENT END, 0) AS bit),
--            [PrintAdNumber] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_AD_NBR, AD.PRT_AD_NBR) ELSE OT.PRT_AD_NBR END, 0) AS bit),
--			[CustomEstimateID] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CUSTOM_ESTIMATE_ID, AD.CUSTOM_ESTIMATE_ID) ELSE OT.CUSTOM_ESTIMATE_ID END AS int),
--            [ShowCodes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SHOW_CODES, AD.SHOW_CODES) ELSE OT.SHOW_CODES END, 0) AS bit),
--			[ContactType] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONTACT_TYPE, ISNULL(AD.CONTACT_TYPE,1)) ELSE ISNULL(OT.CONTACT_TYPE,1) END AS int),
--            [PrintContactAfterAddress] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CONT_AFTER, AD.PRT_CONT_AFTER) ELSE OT.PRT_CONT_AFTER END, 0) AS bit)
--	FROM   PRODUCT AS P LEFT OUTER JOIN 
--	       PROD_EST_DEF AS CD ON CD.CL_CODE = P.CL_CODE AND CD.DIV_CODE = P.DIV_CODE AND CD.PRD_CODE = P.PRD_CODE CROSS JOIN 
--		   PROD_EST_DEF AS AD CROSS JOIN 
--		   PROD_EST_DEF AS OT 
--    WHERE 
--		   AD.CLIENT_OR_DEF = 1 AND 
--		   OT.CLIENT_OR_DEF = 0   
--	) AS EST  WHERE [Type] <> 2

--End
If @ClientOrProduct = 1 OR @ClientOrProduct = 3
Begin
	SELECT
		[ID] = EST.ID,	
		[IsOneTime] = EST.IsOneTime,
		[Type] = EST.[Type],
		[UserID] = EST.[UserID],
		[ClientCode] =EST.ClientCode,
		[DivisionCode] =  CASE WHEN EST.[Type] IN (1,3) THEN EST.DivisionCode ELSE NULL END,
		[ProductCode] =  CASE WHEN EST.[Type] IN (1,3) THEN EST.ProductCode ELSE NULL END,
		[CDP] = CASE WHEN EST.[Type] IN (1,3) THEN EST.CDP ELSE NULL END,
		[SelectBy] = EST.SelectBy,
		[DateToPrint] = EST.DateToPrint,
		[DatePrint] = EST.DatePrint,
		[UseLocationOptions] = EST.UseLocationOptions,
        [LogoPath] = EST.LogoPath, 
        [LocationCode] = EST.LocationCode,
		[ReportTitle] = EST.ReportTitle,
		[PrintClientName] = EST.PrintClientName,
		[PrintDivisionName] = EST.PrintDivisionName,
		[PrintProductDescription] = EST.PrintProductDescription,
		[CDPAddressOption] = EST.CDPAddressOption,
		[IncludeClientReference] = EST.IncludeClientReference,
		[IncludeAccountExecutive] = EST.IncludeAccountExecutive,
		[IncludeSalesClass] = EST.IncludeSalesClass,
		[IncludeJobDueDate] = EST.IncludeJobDueDate,
		[IncludeJobQuantity] = EST.IncludeJobQuantity,
		[SuppressZeroFunctions] = EST.SuppressZeroFunctions,
		[IncludeNonBillable] = EST.IncludeNonBillable,
        [IncludeQuantityHours] = EST.IncludeQuantityHours,
        [IncludeRate] = EST.IncludeRate,
        [SubtotalsOnly] = EST.SubtotalsOnly,
        [IncludeCPU] = EST.IncludeCPU,
        [IncludeCPM] = EST.IncludeCPM,
        [HideJobDescription] = EST.HideJobDescription,
        [HideComponentDescription] = EST.HideComponentDescription,
        [HideRevision] = EST.HideRevision,
		[IncludeEstimateComment] = EST.IncludeEstimateComment,
		[IncludeEstimateComponentComment] = EST.IncludeEstimateComponentComment,
		[IncludeEstimateQuoteComment] = EST.IncludeEstimateQuoteComment,
		[IncludeEstimateRevisionComment] = EST.IncludeEstimateRevisionComment,
		[IncludeEstimateFunctionComment] = EST.IncludeEstimateFunctionComment,
		[IncludeSuppliedByNotes] = EST.IncludeSuppliedByNotes,
        [ReportFormat] = EST.ReportFormat,
		[SummaryLevel] = EST.SummaryLevel,
        [ExcludeEmployeeTime] = EST.ExcludeEmployeeTime,
        [ExcludeVendor] = EST.ExcludeVendor,
        [ExcludeIncomeOnly] = EST.ExcludeIncomeOnly,
        [ExcludeNonbillable] = EST.ExcludeNonbillable,
        [ConsolidationOverride] = EST.ConsolidationOverride,
        [GroupingOptionFunctionOption] = EST.GroupingOptionFunctionOption, 
        [GroupingOptionGroupOption] = EST.GroupingOptionGroupOption,
        [GroupingOptionInsideDescription] = EST.GroupingOptionInsideDescription, 
        [GroupingOptionOutsideDescription] = EST.GroupingOptionOutsideDescription, 
        [GroupingOptionSortOption] = EST.GroupingOptionSortOption, 
        [TotalsShowTaxSeparately] = EST.TotalsShowTaxSeparately,
        [IndicateTaxableFunctions] = EST.IndicateTaxableFunctions,
        [TotalsShowCommissionSeparately] = EST.TotalsShowCommissionSeparately,
        [IndicateCommissionFunctions] = EST.IndicateCommissionFunctions,
        [TotalsShowContingencySeparately] = EST.TotalsShowContingencySeparately,
        [TotalsIncludeContingency] = EST.TotalsIncludeContingency,
        [DefaultFooterComment] = EST.DefaultFooterComment,
        [Signature] = EST.[Signature],
        [ExcludeSignatures] = EST.ExcludeSignatures,
        --[IncludeSpecifications] = EST.IncludeSpecifications,
        [UseEmployeeSignature] = EST.UseEmployeeSignature,
        [IncludeCampaignSummary] = EST.IncludeCampaignSummary,
        [IncludeVendorDescription] = EST.IncludeVendorDescription,
        [IncludeFunctionComment] = EST.IncludeFunctionComment,
        [PrintAdNumber] = EST.PrintAdNumber,
		[CustomEstimateID] = CASE WHEN EST.CustomEstimateID = 0 THEN NULL ELSE EST.CustomEstimateID END,
		[ShowCodes] = EST.ShowCodes,
		[ContactType] = EST.ContactType,
        [PrintContactAfterAddress] = EST.PrintContactAfterAddress,		
		[FileFormat] = EST.FileFormat,		
		[PrintQuantityTotals] = EST.PrintQuantityTotals,
		[ShowWatermark] = EST.ShowWatermark,
		[DisplayQuantity] = EST.DisplayQuantity,
		[DisplayHours] = EST.DisplayHours,
		[IncludeRateMarkup] = EST.IncludeRateMarkup,
		[ExcludeDateFromSignature] = EST.ExcludeDateFromSignature
		--[CityTaxLabel] = CTL.FIELD_DESCRIPTION, 
		--[CountyTaxLabel] = COTL.FIELD_DESCRIPTION, 
		--[StateTaxLabel] = STL.FIELD_DESCRIPTION
	FROM
		(SELECT
			[ID] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PROD_EST_DEF_ID, AD.PROD_EST_DEF_ID) ELSE OT.PROD_EST_DEF_ID END, 0) AS int),
			[IsOneTime] = CAST(ISNULL(@IsOneTime, 0) AS bit),		
			[Type] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CLIENT_OR_DEF, AD.CLIENT_OR_DEF) ELSE OT.CLIENT_OR_DEF END AS smallint),
			--[ClientOrDefault] = CLIENT_OR_DEF,
			[UserID] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.[USER_ID], ISNULL(AD.[USER_ID], '')) ELSE ISNULL(OT.[USER_ID], '') END,
			[ClientCode] = ISNULL(C.CL_CODE,''),
			[DivisionCode] = ISNULL(C.DIV_CODE,''),
			[ProductCode] = ISNULL(C.PRD_CODE,''),
			[CDP] = ISNULL(C.CL_CODE,'') + '|' + ISNULL(C.DIV_CODE,'') + '|' + ISNULL(C.PRD_CODE,''),
            [SelectBy] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SELECT_BY ELSE ISNULL(CD.SELECT_BY, ISNULL(AD.SELECT_BY, '')) END ELSE ISNULL(OT.SELECT_BY, '') END,
            [DateToPrint] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CASE WHEN ISNULL(CD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END, CASE WHEN ISNULL(AD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END) ELSE CASE WHEN ISNULL(OT.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END END, 0) AS bit),
			[DatePrint] = GETDATE(),
			[UseLocationOptions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SELECT_BY ELSE ISNULL(CD.USE_LOCATION_OPTIONS, AD.USE_LOCATION_OPTIONS) END ELSE OT.USE_LOCATION_OPTIONS END, 0) AS bit),
            [LogoPath] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.LOGO_PATH ELSE ISNULL(CD.LOGO_PATH, ISNULL(AD.LOGO_PATH, '')) END ELSE ISNULL(OT.LOGO_PATH, '') END, 
            [LocationCode] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.LOCATION_ID ELSE ISNULL(CD.LOCATION_ID, ISNULL(AD.LOCATION_ID, '')) END ELSE ISNULL(OT.LOCATION_ID, '') END,
            [ReportTitle] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.RPT_TITLE ELSE ISNULL(CD.RPT_TITLE, ISNULL(AD.RPT_TITLE, '')) END ELSE ISNULL(OT.RPT_TITLE, '') END,
            [PrintClientName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CL_NAME ELSE ISNULL(CD.PRT_CL_NAME, AD.PRT_CL_NAME) END ELSE OT.PRT_CL_NAME END, 0) AS bit),
            [PrintDivisionName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_DIV_NAME ELSE ISNULL(CD.PRT_DIV_NAME, AD.PRT_DIV_NAME) END ELSE OT.PRT_DIV_NAME END, 0) AS bit),
            [PrintProductDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_PRD_NAME ELSE ISNULL(CD.PRT_PRD_NAME, AD.PRT_PRD_NAME) END ELSE OT.PRT_PRD_NAME END, 0) AS bit),
            [CDPAddressOption] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CDP_ADDRESS ELSE ISNULL(CD.CDP_ADDRESS, ISNULL(AD.CDP_ADDRESS, '')) END ELSE ISNULL(OT.CDP_ADDRESS, '') END,
            [IncludeClientReference] =  CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CLI_REF ELSE ISNULL(CD.CLI_REF, AD.CLI_REF) END ELSE OT.CLI_REF END, 0) AS bit),
            [IncludeAccountExecutive] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.AE_NAME ELSE ISNULL(CD.AE_NAME, AD.AE_NAME) END ELSE OT.AE_NAME END, 0) AS bit),
            [IncludeSalesClass] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_SALES_CLASS ELSE ISNULL(CD.PRT_SALES_CLASS, AD.PRT_SALES_CLASS) END ELSE OT.PRT_SALES_CLASS END, 0) AS bit),
            [IncludeJobDueDate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.JOB_DUE_DATE ELSE ISNULL(CD.JOB_DUE_DATE, AD.JOB_DUE_DATE) END ELSE OT.JOB_DUE_DATE END, 0) AS bit),
            [IncludeJobQuantity] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.JOB_QTY ELSE ISNULL(CD.JOB_QTY, AD.JOB_QTY) END ELSE OT.JOB_QTY END, 0) AS bit),
            [SuppressZeroFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUPPRESS_ZERO ELSE ISNULL(CD.SUPPRESS_ZERO, AD.SUPPRESS_ZERO) END ELSE OT.SUPPRESS_ZERO END, 0) AS bit),
            [IncludeNonBillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_NONBILL ELSE ISNULL(CD.PRT_NONBILL, AD.PRT_NONBILL) END ELSE OT.PRT_NONBILL END, 0) AS bit),
            [IncludeQuantityHours] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.QTY_HRS ELSE ISNULL(CD.QTY_HRS, AD.QTY_HRS) END ELSE OT.QTY_HRS END, 0) AS bit),
            [IncludeRate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.INCL_RATE ELSE ISNULL(CD.INCL_RATE, AD.INCL_RATE) END ELSE OT.INCL_RATE END, 0) AS bit),
            [SubtotalsOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUBTOT_ONLY ELSE ISNULL(CD.SUBTOT_ONLY, AD.SUBTOT_ONLY) END ELSE OT.SUBTOT_ONLY END, 0) AS bit),
            [IncludeCPU] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CPU ELSE ISNULL(CD.PRT_CPU, AD.PRT_CPU) END ELSE OT.PRT_CPU END, 0) AS bit),
            [IncludeCPM] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CPM ELSE ISNULL(CD.PRT_CPM, AD.PRT_CPM) END ELSE OT.PRT_CPM END, 0) AS bit),
			[HideJobDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.HIDE_JOB_DESC ELSE ISNULL(CD.HIDE_JOB_DESC, AD.HIDE_JOB_DESC) END ELSE OT.HIDE_JOB_DESC END, 0) AS bit),
            [HideComponentDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.HIDE_COMP_DESC ELSE ISNULL(CD.HIDE_COMP_DESC, AD.HIDE_COMP_DESC) END ELSE OT.HIDE_COMP_DESC END, 0) AS bit),
            [HideRevision] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.HIDE_REVISION ELSE ISNULL(CD.HIDE_REVISION, AD.HIDE_REVISION) END ELSE OT.HIDE_REVISION END, 0) AS bit),
            [IncludeEstimateComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EST_COMMENT ELSE ISNULL(CD.EST_COMMENT, AD.EST_COMMENT) END ELSE OT.EST_COMMENT END, 0) AS bit),  
            [IncludeEstimateComponentComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EST_COMP_COMMENT ELSE ISNULL(CD.EST_COMP_COMMENT, AD.EST_COMP_COMMENT) END ELSE OT.EST_COMP_COMMENT END, 0) AS bit),
            [IncludeEstimateQuoteComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.QTE_COMMENT ELSE ISNULL(CD.QTE_COMMENT, AD.QTE_COMMENT) END ELSE OT.QTE_COMMENT END, 0) AS bit),
            [IncludeEstimateRevisionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.REV_COMMENT ELSE ISNULL(CD.REV_COMMENT, AD.REV_COMMENT) END ELSE OT.REV_COMMENT END, 0) AS bit),
            [IncludeEstimateFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FUNC_COMMENT ELSE ISNULL(CD.FUNC_COMMENT, AD.FUNC_COMMENT) END ELSE OT.FUNC_COMMENT END, 0) AS bit),
            [IncludeSuppliedByNotes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUP_BY_NOTES ELSE ISNULL(CD.SUP_BY_NOTES, AD.SUP_BY_NOTES) END ELSE OT.SUP_BY_NOTES END, 0) AS bit),
            [ReportFormat] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN ISNULL(AD.REPORT_FORMAT, '') ELSE ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) END ELSE ISNULL(OT.REPORT_FORMAT, '') END,
            [SummaryLevel] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUMMARY_LEVEL ELSE ISNULL(CD.SUMMARY_LEVEL, ISNULL(AD.SUMMARY_LEVEL,0)) END ELSE ISNULL(OT.SUMMARY_LEVEL,0) END AS smallint),
            [ExcludeEmployeeTime] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_EMP_TIME ELSE ISNULL(CD.EXCL_EMP_TIME, AD.EXCL_EMP_TIME) END ELSE OT.EXCL_EMP_TIME END, 0) AS bit),
            [ExcludeVendor] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_VENDOR ELSE ISNULL(CD.EXCL_VENDOR, AD.EXCL_VENDOR) END ELSE OT.EXCL_VENDOR END, 0) AS bit),
            [ExcludeIncomeOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_IO ELSE ISNULL(CD.EXCL_IO, AD.EXCL_IO) END ELSE OT.EXCL_IO END, 0) AS bit),
            [ExcludeNonbillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_NONBILL ELSE ISNULL(CD.EXCL_NONBILL, AD.EXCL_NONBILL) END ELSE OT.EXCL_NONBILL END, 0) AS bit),
            [ConsolidationOverride] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CONSOL_OVERRIDE ELSE ISNULL(CD.CONSOL_OVERRIDE, AD.CONSOL_OVERRIDE) END ELSE OT.CONSOL_OVERRIDE END, 0) AS bit),
            [GroupingOptionFunctionOption] = CASE @IsOneTime WHEN 0 THEN 
											 CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FUNCTION_OPTION ELSE ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) END
											 ELSE OT.FUNCTION_OPTION END, 	   
            [GroupingOptionGroupOption] = CASE @IsOneTime WHEN 0 THEN 
											CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.GROUP_OPTION ELSE ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) END
											 ELSE OT.GROUP_OPTION END, 
            [GroupingOptionInsideDescription] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.INSIDE_CHG_DESC ELSE ISNULL(CD.INSIDE_CHG_DESC, ISNULL(AD.INSIDE_CHG_DESC, '')) END ELSE ISNULL(OT.INSIDE_CHG_DESC, '') END, 
            [GroupingOptionOutsideDescription] =  CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.OUTSIDE_CHG_DESC ELSE ISNULL(CD.OUTSIDE_CHG_DESC, ISNULL(AD.OUTSIDE_CHG_DESC, '')) END ELSE ISNULL(OT.OUTSIDE_CHG_DESC, '') END, 
            [GroupingOptionSortOption] = CASE @IsOneTime WHEN 0 THEN 
											CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SORT_OPTION ELSE ISNULL(CD.SORT_OPTION, ISNULL(AD.SORT_OPTION, '')) END
											 ELSE OT.SORT_OPTION END, 
            [TotalsShowTaxSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.TAX_SEPARATE ELSE ISNULL(CD.TAX_SEPARATE, AD.TAX_SEPARATE) END ELSE OT.TAX_SEPARATE END, 0) AS bit),
            [IndicateTaxableFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.TAX_INDICATOR ELSE ISNULL(CD.TAX_INDICATOR, AD.TAX_INDICATOR) END ELSE OT.TAX_INDICATOR END, 0) AS bit),
            [TotalsShowCommissionSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.COMM_MU_SEPARATE ELSE ISNULL(CD.COMM_MU_SEPARATE, AD.COMM_MU_SEPARATE) END ELSE OT.COMM_MU_SEPARATE END, 0) AS bit),
            [IndicateCommissionFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.COMM_MU_INDICATOR ELSE ISNULL(CD.COMM_MU_INDICATOR, AD.COMM_MU_INDICATOR) END ELSE OT.COMM_MU_INDICATOR END, 0) AS bit),
            [TotalsShowContingencySeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CONT_SEPARATE ELSE ISNULL(CD.CONT_SEPARATE, AD.CONT_SEPARATE) END ELSE OT.CONT_SEPARATE END, 0) AS bit),
            [TotalsIncludeContingency] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CONTINGENCY ELSE ISNULL(CD.CONTINGENCY, AD.CONTINGENCY) END ELSE OT.CONTINGENCY END, 0) AS bit),
            [DefaultFooterComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.DEF_FOOTER_COMMENT ELSE ISNULL(CD.DEF_FOOTER_COMMENT, AD.DEF_FOOTER_COMMENT) END ELSE OT.DEF_FOOTER_COMMENT END, 0) AS bit),
            [Signature] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.[SIGNATURE] ELSE ISNULL(CD.[SIGNATURE], ISNULL(AD.[SIGNATURE], 999)) END ELSE ISNULL(OT.[SIGNATURE], 999) END AS smallint),
            [ExcludeSignatures] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_SIGNATURES ELSE ISNULL(CD.EXCL_SIGNATURES, AD.EXCL_SIGNATURES) END ELSE OT.EXCL_SIGNATURES END, 0) AS bit),
            --[IncludeSpecifications] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SPECS, AD.SPECS) ELSE OT.SPECS END, 0) AS bit),CAST(ISNULL(SPECS, 0) AS bit),
            [UseEmployeeSignature] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.USE_EMP_SIG ELSE ISNULL(CD.USE_EMP_SIG, AD.USE_EMP_SIG) END ELSE OT.USE_EMP_SIG END, 0) AS bit),
            [IncludeCampaignSummary] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CMP_SUMMARY ELSE ISNULL(CD.CMP_SUMMARY, AD.CMP_SUMMARY) END ELSE OT.CMP_SUMMARY END, 0) AS bit),
            [IncludeVendorDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.VENDOR_DESC ELSE ISNULL(CD.VENDOR_DESC, AD.VENDOR_DESC) END ELSE OT.VENDOR_DESC END, 0) AS bit),
            [IncludeFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FNC_COMMENT ELSE ISNULL(CD.FNC_COMMENT, AD.FNC_COMMENT) END ELSE OT.FNC_COMMENT END, 0) AS bit),
            [PrintAdNumber] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_AD_NBR ELSE ISNULL(CD.PRT_AD_NBR, AD.PRT_AD_NBR) END ELSE OT.PRT_AD_NBR END, 0) AS bit),
			[CustomEstimateID] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CUSTOM_ESTIMATE_ID ELSE ISNULL(CD.CUSTOM_ESTIMATE_ID, AD.CUSTOM_ESTIMATE_ID) END ELSE OT.CUSTOM_ESTIMATE_ID END AS int),
            [ShowCodes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SHOW_CODES ELSE ISNULL(CD.SHOW_CODES, AD.SHOW_CODES) END ELSE OT.SHOW_CODES END, 0) AS bit),
			[ContactType] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN ISNULL(AD.CONTACT_TYPE,1) ELSE ISNULL(CD.CONTACT_TYPE, ISNULL(AD.CONTACT_TYPE,1)) END ELSE ISNULL(OT.CONTACT_TYPE,1) END AS int),
            [PrintContactAfterAddress] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CONT_AFTER ELSE ISNULL(CD.PRT_CONT_AFTER, AD.PRT_CONT_AFTER) END ELSE OT.PRT_CONT_AFTER END, 0) AS bit),
            [FileFormat] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FILE_FORMAT ELSE ISNULL(CD.FILE_FORMAT, ISNULL(AD.FILE_FORMAT, 1)) END ELSE ISNULL(OT.FILE_FORMAT, 1) END AS smallint),
			[PrintQuantityTotals] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRINT_QTY_TOTALS ELSE ISNULL(CD.PRINT_QTY_TOTALS, AD.PRINT_QTY_TOTALS) END ELSE OT.PRINT_QTY_TOTALS END, 0) AS bit),
			[ShowWatermark] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SHOW_WATERMARK ELSE ISNULL(CD.SHOW_WATERMARK, AD.SHOW_WATERMARK) END ELSE OT.SHOW_WATERMARK END, 0) AS bit),
			[DisplayQuantity] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.DISPLAY_QTY ELSE ISNULL(CD.DISPLAY_QTY, AD.DISPLAY_QTY) END ELSE OT.DISPLAY_QTY END, 0) AS bit),
			[DisplayHours] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.DISPLAY_HOURS ELSE ISNULL(CD.DISPLAY_HOURS, AD.DISPLAY_HOURS) END ELSE OT.DISPLAY_HOURS END, 0) AS bit),
			[IncludeRateMarkup] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.INCL_RATE_MARKUP ELSE ISNULL(CD.INCL_RATE_MARKUP, AD.INCL_RATE_MARKUP) END ELSE OT.INCL_RATE_MARKUP END, 0) AS bit),
			[ExcludeDateFromSignature] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCLUDE_DATE_SIGN ELSE ISNULL(CD.EXCLUDE_DATE_SIGN, AD.EXCLUDE_DATE_SIGN) END ELSE OT.EXCLUDE_DATE_SIGN END, 0) AS bit)
	FROM   PRODUCT AS C LEFT OUTER JOIN 
	       PROD_EST_DEF AS CD ON CD.CL_CODE = C.CL_CODE CROSS JOIN 
		   PROD_EST_DEF AS AD CROSS JOIN 
		   PROD_EST_DEF AS OT 
    WHERE 
		   AD.CLIENT_OR_DEF = 1 AND 
		   OT.CLIENT_OR_DEF = 0	   
		   
		   ) AS EST --INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'CITY_TAX') AS CTL ON 1 = 1 INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'COUNTY_TAX') AS COTL ON 1 = 1 INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'STATE_TAX') AS STL ON 1 = 1
		WHERE [Type] <> 3
    UNION
	SELECT
		[ID] = EST.ID,	
		[IsOneTime] = EST.IsOneTime,
		[Type] = EST.[Type],
		[UserID] = EST.[UserID],
		[ClientCode] =EST.ClientCode,
		[DivisionCode] =  CASE WHEN EST.[Type] IN (1,3) THEN EST.DivisionCode ELSE NULL END,
		[ProductCode] =  CASE WHEN EST.[Type] IN (1,3) THEN EST.ProductCode ELSE NULL END,
		[CDP] = CASE WHEN EST.[Type] IN (1,3) THEN EST.CDP ELSE NULL END,
		[SelectBy] = EST.SelectBy,
		[DateToPrint] = EST.DateToPrint,
		[DatePrint] = EST.DatePrint,
		[UseLocationOptions] = EST.UseLocationOptions,
        [LogoPath] = EST.LogoPath, 
        [LocationCode] = EST.LocationCode,
		[ReportTitle] = EST.ReportTitle,
		[PrintClientName] = EST.PrintClientName,
		[PrintDivisionName] = EST.PrintDivisionName,
		[PrintProductDescription] = EST.PrintProductDescription,
		[CDPAddressOption] = EST.CDPAddressOption,
		[IncludeClientReference] = EST.IncludeClientReference,
		[IncludeAccountExecutive] = EST.IncludeAccountExecutive,
		[IncludeSalesClass] = EST.IncludeSalesClass,
		[IncludeJobDueDate] = EST.IncludeJobDueDate,
		[IncludeJobQuantity] = EST.IncludeJobQuantity,
		[SuppressZeroFunctions] = EST.SuppressZeroFunctions,
		[IncludeNonBillable] = EST.IncludeNonBillable,
        [IncludeQuantityHours] = EST.IncludeQuantityHours,
        [IncludeRate] = EST.IncludeRate,
        [SubtotalsOnly] = EST.SubtotalsOnly,
        [IncludeCPU] = EST.IncludeCPU,
        [IncludeCPM] = EST.IncludeCPM,
        [HideJobDescription] = EST.HideJobDescription,
        [HideComponentDescription] = EST.HideComponentDescription,
        [HideRevision] = EST.HideRevision,
		[IncludeEstimateComment] = EST.IncludeEstimateComment,
		[IncludeEstimateComponentComment] = EST.IncludeEstimateComponentComment,
		[IncludeEstimateQuoteComment] = EST.IncludeEstimateQuoteComment,
		[IncludeEstimateRevisionComment] = EST.IncludeEstimateRevisionComment,
		[IncludeEstimateFunctionComment] = EST.IncludeEstimateFunctionComment,
		[IncludeSuppliedByNotes] = EST.IncludeSuppliedByNotes,
        [ReportFormat] = EST.ReportFormat,
		[SummaryLevel] = EST.SummaryLevel,
        [ExcludeEmployeeTime] = EST.ExcludeEmployeeTime,
        [ExcludeVendor] = EST.ExcludeVendor,
        [ExcludeIncomeOnly] = EST.ExcludeIncomeOnly,
        [ExcludeNonbillable] = EST.ExcludeNonbillable,
        [ConsolidationOverride] = EST.ConsolidationOverride,
        [GroupingOptionFunctionOption] = EST.GroupingOptionFunctionOption, 
        [GroupingOptionGroupOption] = EST.GroupingOptionGroupOption,
        [GroupingOptionInsideDescription] = EST.GroupingOptionInsideDescription, 
        [GroupingOptionOutsideDescription] = EST.GroupingOptionOutsideDescription, 
        [GroupingOptionSortOption] = EST.GroupingOptionSortOption, 
        [TotalsShowTaxSeparately] = EST.TotalsShowTaxSeparately,
        [IndicateTaxableFunctions] = EST.IndicateTaxableFunctions,
        [TotalsShowCommissionSeparately] = EST.TotalsShowCommissionSeparately,
        [IndicateCommissionFunctions] = EST.IndicateCommissionFunctions,
        [TotalsShowContingencySeparately] = EST.TotalsShowContingencySeparately,
        [TotalsIncludeContingency] = EST.TotalsIncludeContingency,
        [DefaultFooterComment] = EST.DefaultFooterComment,
        [Signature] = EST.[Signature],
        [ExcludeSignatures] = EST.ExcludeSignatures,
        --[IncludeSpecifications] = EST.IncludeSpecifications,
        [UseEmployeeSignature] = EST.UseEmployeeSignature,
        [IncludeCampaignSummary] = EST.IncludeCampaignSummary,
        [IncludeVendorDescription] = EST.IncludeVendorDescription,
        [IncludeFunctionComment] = EST.IncludeFunctionComment,
        [PrintAdNumber] = EST.PrintAdNumber,
		[CustomEstimateID] = CASE WHEN EST.CustomEstimateID = 0 THEN NULL ELSE EST.CustomEstimateID END,
		[ShowCodes] = EST.ShowCodes,
		[ContactType] = EST.ContactType,
        [PrintContactAfterAddress] = EST.PrintContactAfterAddress,		
		[FileFormat] = EST.FileFormat,
		[PrintQuantityTotals] = EST.PrintQuantityTotals,
		[ShowWatermark] = EST.ShowWatermark,
		[DisplayQuantity] = EST.DisplayQuantity,
		[DisplayHours] = EST.DisplayHours,
		[IncludeRateMarkup] = EST.IncludeRateMarkup,
		[ExcludeDateFromSignature] = EST.ExcludeDateFromSignature
		--[CityTaxLabel] = CTL.FIELD_DESCRIPTION, 
		--[CountyTaxLabel] = COTL.FIELD_DESCRIPTION, 
		--[StateTaxLabel] = STL.FIELD_DESCRIPTION
	FROM
		(SELECT
			[ID] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PROD_EST_DEF_ID, AD.PROD_EST_DEF_ID) ELSE OT.PROD_EST_DEF_ID END, 0) AS int),
			[IsOneTime] = CAST(ISNULL(@IsOneTime, 0) AS bit),		
			[Type] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CLIENT_OR_DEF, AD.CLIENT_OR_DEF) ELSE OT.CLIENT_OR_DEF END AS smallint),
			--[ClientOrDefault] = CLIENT_OR_DEF,
			[UserID] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.[USER_ID], ISNULL(AD.[USER_ID], '')) ELSE ISNULL(OT.[USER_ID], '') END,
			[ClientCode] = ISNULL(C.CL_CODE,''),
			[DivisionCode] = ISNULL(C.DIV_CODE,''),
			[ProductCode] = ISNULL(C.PRD_CODE,''),
			[CDP] = ISNULL(C.CL_CODE,'') + '|' + ISNULL(C.DIV_CODE,'') + '|' + ISNULL(C.PRD_CODE,''),
            [SelectBy] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SELECT_BY ELSE ISNULL(CD.SELECT_BY, ISNULL(AD.SELECT_BY, '')) END ELSE ISNULL(OT.SELECT_BY, '') END,
            [DateToPrint] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CASE WHEN ISNULL(CD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END, CASE WHEN ISNULL(AD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END) ELSE CASE WHEN ISNULL(OT.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END END, 0) AS bit),
			[DatePrint] = GETDATE(),
			[UseLocationOptions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SELECT_BY ELSE ISNULL(CD.USE_LOCATION_OPTIONS, AD.USE_LOCATION_OPTIONS) END ELSE OT.USE_LOCATION_OPTIONS END, 0) AS bit),
            [LogoPath] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.LOGO_PATH ELSE ISNULL(CD.LOGO_PATH, ISNULL(AD.LOGO_PATH, '')) END ELSE ISNULL(OT.LOGO_PATH, '') END, 
            [LocationCode] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.LOCATION_ID ELSE ISNULL(CD.LOCATION_ID, ISNULL(AD.LOCATION_ID, '')) END ELSE ISNULL(OT.LOCATION_ID, '') END,
            [ReportTitle] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.RPT_TITLE ELSE ISNULL(CD.RPT_TITLE, ISNULL(AD.RPT_TITLE, '')) END ELSE ISNULL(OT.RPT_TITLE, '') END,
            [PrintClientName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CL_NAME ELSE ISNULL(CD.PRT_CL_NAME, AD.PRT_CL_NAME) END ELSE OT.PRT_CL_NAME END, 0) AS bit),
            [PrintDivisionName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_DIV_NAME ELSE ISNULL(CD.PRT_DIV_NAME, AD.PRT_DIV_NAME) END ELSE OT.PRT_DIV_NAME END, 0) AS bit),
            [PrintProductDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_PRD_NAME ELSE ISNULL(CD.PRT_PRD_NAME, AD.PRT_PRD_NAME) END ELSE OT.PRT_PRD_NAME END, 0) AS bit),
            [CDPAddressOption] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CDP_ADDRESS ELSE ISNULL(CD.CDP_ADDRESS, ISNULL(AD.CDP_ADDRESS, '')) END ELSE ISNULL(OT.CDP_ADDRESS, '') END,
            [IncludeClientReference] =  CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CLI_REF ELSE ISNULL(CD.CLI_REF, AD.CLI_REF) END ELSE OT.CLI_REF END, 0) AS bit),
            [IncludeAccountExecutive] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.AE_NAME ELSE ISNULL(CD.AE_NAME, AD.AE_NAME) END ELSE OT.AE_NAME END, 0) AS bit),
            [IncludeSalesClass] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_SALES_CLASS ELSE ISNULL(CD.PRT_SALES_CLASS, AD.PRT_SALES_CLASS) END ELSE OT.PRT_SALES_CLASS END, 0) AS bit),
            [IncludeJobDueDate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.JOB_DUE_DATE ELSE ISNULL(CD.JOB_DUE_DATE, AD.JOB_DUE_DATE) END ELSE OT.JOB_DUE_DATE END, 0) AS bit),
            [IncludeJobQuantity] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.JOB_QTY ELSE ISNULL(CD.JOB_QTY, AD.JOB_QTY) END ELSE OT.JOB_QTY END, 0) AS bit),
            [SuppressZeroFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUPPRESS_ZERO ELSE ISNULL(CD.SUPPRESS_ZERO, AD.SUPPRESS_ZERO) END ELSE OT.SUPPRESS_ZERO END, 0) AS bit),
            [IncludeNonBillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_NONBILL ELSE ISNULL(CD.PRT_NONBILL, AD.PRT_NONBILL) END ELSE OT.PRT_NONBILL END, 0) AS bit),
            [IncludeQuantityHours] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.QTY_HRS ELSE ISNULL(CD.QTY_HRS, AD.QTY_HRS) END ELSE OT.QTY_HRS END, 0) AS bit),
            [IncludeRate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.INCL_RATE ELSE ISNULL(CD.INCL_RATE, AD.INCL_RATE) END ELSE OT.INCL_RATE END, 0) AS bit),
            [SubtotalsOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUBTOT_ONLY ELSE ISNULL(CD.SUBTOT_ONLY, AD.SUBTOT_ONLY) END ELSE OT.SUBTOT_ONLY END, 0) AS bit),
            [IncludeCPU] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CPU ELSE ISNULL(CD.PRT_CPU, AD.PRT_CPU) END ELSE OT.PRT_CPU END, 0) AS bit),
            [IncludeCPM] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CPM ELSE ISNULL(CD.PRT_CPM, AD.PRT_CPM) END ELSE OT.PRT_CPM END, 0) AS bit),
			[HideJobDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.HIDE_JOB_DESC ELSE ISNULL(CD.HIDE_JOB_DESC, AD.HIDE_JOB_DESC) END ELSE OT.HIDE_JOB_DESC END, 0) AS bit),
            [HideComponentDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.HIDE_COMP_DESC ELSE ISNULL(CD.HIDE_COMP_DESC, AD.HIDE_COMP_DESC) END ELSE OT.HIDE_COMP_DESC END, 0) AS bit),
            [HideRevision] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.HIDE_REVISION ELSE ISNULL(CD.HIDE_REVISION, AD.HIDE_REVISION) END ELSE OT.HIDE_REVISION END, 0) AS bit),
            [IncludeEstimateComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EST_COMMENT ELSE ISNULL(CD.EST_COMMENT, AD.EST_COMMENT) END ELSE OT.EST_COMMENT END, 0) AS bit),  
            [IncludeEstimateComponentComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EST_COMP_COMMENT ELSE ISNULL(CD.EST_COMP_COMMENT, AD.EST_COMP_COMMENT) END ELSE OT.EST_COMP_COMMENT END, 0) AS bit),
            [IncludeEstimateQuoteComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.QTE_COMMENT ELSE ISNULL(CD.QTE_COMMENT, AD.QTE_COMMENT) END ELSE OT.QTE_COMMENT END, 0) AS bit),
            [IncludeEstimateRevisionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.REV_COMMENT ELSE ISNULL(CD.REV_COMMENT, AD.REV_COMMENT) END ELSE OT.REV_COMMENT END, 0) AS bit),
            [IncludeEstimateFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FUNC_COMMENT ELSE ISNULL(CD.FUNC_COMMENT, AD.FUNC_COMMENT) END ELSE OT.FUNC_COMMENT END, 0) AS bit),
            [IncludeSuppliedByNotes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUP_BY_NOTES ELSE ISNULL(CD.SUP_BY_NOTES, AD.SUP_BY_NOTES) END ELSE OT.SUP_BY_NOTES END, 0) AS bit),
            [ReportFormat] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN ISNULL(AD.REPORT_FORMAT, '') ELSE ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) END ELSE ISNULL(OT.REPORT_FORMAT, '') END,
            [SummaryLevel] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SUMMARY_LEVEL ELSE ISNULL(CD.SUMMARY_LEVEL, ISNULL(AD.SUMMARY_LEVEL,0)) END ELSE ISNULL(OT.SUMMARY_LEVEL,0) END AS smallint),
            [ExcludeEmployeeTime] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_EMP_TIME ELSE ISNULL(CD.EXCL_EMP_TIME, AD.EXCL_EMP_TIME) END ELSE OT.EXCL_EMP_TIME END, 0) AS bit),
            [ExcludeVendor] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_VENDOR ELSE ISNULL(CD.EXCL_VENDOR, AD.EXCL_VENDOR) END ELSE OT.EXCL_VENDOR END, 0) AS bit),
            [ExcludeIncomeOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_IO ELSE ISNULL(CD.EXCL_IO, AD.EXCL_IO) END ELSE OT.EXCL_IO END, 0) AS bit),
            [ExcludeNonbillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_NONBILL ELSE ISNULL(CD.EXCL_NONBILL, AD.EXCL_NONBILL) END ELSE OT.EXCL_NONBILL END, 0) AS bit),
            [ConsolidationOverride] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CONSOL_OVERRIDE ELSE ISNULL(CD.CONSOL_OVERRIDE, AD.CONSOL_OVERRIDE) END ELSE OT.CONSOL_OVERRIDE END, 0) AS bit),
            [GroupingOptionFunctionOption] = CASE @IsOneTime WHEN 0 THEN 
											 CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FUNCTION_OPTION ELSE ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) END
											 ELSE OT.FUNCTION_OPTION END, 	   
            [GroupingOptionGroupOption] = CASE @IsOneTime WHEN 0 THEN 
											CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.GROUP_OPTION ELSE ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) END
											 ELSE OT.GROUP_OPTION END, 
            [GroupingOptionInsideDescription] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.INSIDE_CHG_DESC ELSE ISNULL(CD.INSIDE_CHG_DESC, ISNULL(AD.INSIDE_CHG_DESC, '')) END ELSE ISNULL(OT.INSIDE_CHG_DESC, '') END, 
            [GroupingOptionOutsideDescription] =  CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.OUTSIDE_CHG_DESC ELSE ISNULL(CD.OUTSIDE_CHG_DESC, ISNULL(AD.OUTSIDE_CHG_DESC, '')) END ELSE ISNULL(OT.OUTSIDE_CHG_DESC, '') END, 
            [GroupingOptionSortOption] = CASE @IsOneTime WHEN 0 THEN 
											CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SORT_OPTION ELSE ISNULL(CD.SORT_OPTION, ISNULL(AD.SORT_OPTION, '')) END
											 ELSE OT.SORT_OPTION END, 
            [TotalsShowTaxSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.TAX_SEPARATE ELSE ISNULL(CD.TAX_SEPARATE, AD.TAX_SEPARATE) END ELSE OT.TAX_SEPARATE END, 0) AS bit),
            [IndicateTaxableFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.TAX_INDICATOR ELSE ISNULL(CD.TAX_INDICATOR, AD.TAX_INDICATOR) END ELSE OT.TAX_INDICATOR END, 0) AS bit),
            [TotalsShowCommissionSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.COMM_MU_SEPARATE ELSE ISNULL(CD.COMM_MU_SEPARATE, AD.COMM_MU_SEPARATE) END ELSE OT.COMM_MU_SEPARATE END, 0) AS bit),
            [IndicateCommissionFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.COMM_MU_INDICATOR ELSE ISNULL(CD.COMM_MU_INDICATOR, AD.COMM_MU_INDICATOR) END ELSE OT.COMM_MU_INDICATOR END, 0) AS bit),
            [TotalsShowContingencySeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CONT_SEPARATE ELSE ISNULL(CD.CONT_SEPARATE, AD.CONT_SEPARATE) END ELSE OT.CONT_SEPARATE END, 0) AS bit),
            [TotalsIncludeContingency] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CONTINGENCY ELSE ISNULL(CD.CONTINGENCY, AD.CONTINGENCY) END ELSE OT.CONTINGENCY END, 0) AS bit),
            [DefaultFooterComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.DEF_FOOTER_COMMENT ELSE ISNULL(CD.DEF_FOOTER_COMMENT, AD.DEF_FOOTER_COMMENT) END ELSE OT.DEF_FOOTER_COMMENT END, 0) AS bit),
            [Signature] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.[SIGNATURE] ELSE ISNULL(CD.[SIGNATURE], ISNULL(AD.[SIGNATURE], 999)) END ELSE ISNULL(OT.[SIGNATURE], 999) END AS smallint),
            [ExcludeSignatures] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCL_SIGNATURES ELSE ISNULL(CD.EXCL_SIGNATURES, AD.EXCL_SIGNATURES) END ELSE OT.EXCL_SIGNATURES END, 0) AS bit),
            --[IncludeSpecifications] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SPECS, AD.SPECS) ELSE OT.SPECS END, 0) AS bit),CAST(ISNULL(SPECS, 0) AS bit),
            [UseEmployeeSignature] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.USE_EMP_SIG ELSE ISNULL(CD.USE_EMP_SIG, AD.USE_EMP_SIG) END ELSE OT.USE_EMP_SIG END, 0) AS bit),
            [IncludeCampaignSummary] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CMP_SUMMARY ELSE ISNULL(CD.CMP_SUMMARY, AD.CMP_SUMMARY) END ELSE OT.CMP_SUMMARY END, 0) AS bit),
            [IncludeVendorDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.VENDOR_DESC ELSE ISNULL(CD.VENDOR_DESC, AD.VENDOR_DESC) END ELSE OT.VENDOR_DESC END, 0) AS bit),
            [IncludeFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FNC_COMMENT ELSE ISNULL(CD.FNC_COMMENT, AD.FNC_COMMENT) END ELSE OT.FNC_COMMENT END, 0) AS bit),
            [PrintAdNumber] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_AD_NBR ELSE ISNULL(CD.PRT_AD_NBR, AD.PRT_AD_NBR) END ELSE OT.PRT_AD_NBR END, 0) AS bit),
			[CustomEstimateID] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.CUSTOM_ESTIMATE_ID ELSE ISNULL(CD.CUSTOM_ESTIMATE_ID, AD.CUSTOM_ESTIMATE_ID) END ELSE OT.CUSTOM_ESTIMATE_ID END AS int),
            [ShowCodes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SHOW_CODES ELSE ISNULL(CD.SHOW_CODES, AD.SHOW_CODES) END ELSE OT.SHOW_CODES END, 0) AS bit),
			[ContactType] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN ISNULL(AD.CONTACT_TYPE,1) ELSE ISNULL(CD.CONTACT_TYPE, ISNULL(AD.CONTACT_TYPE,1)) END ELSE ISNULL(OT.CONTACT_TYPE,1) END AS int),
            [PrintContactAfterAddress] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRT_CONT_AFTER ELSE ISNULL(CD.PRT_CONT_AFTER, AD.PRT_CONT_AFTER) END ELSE OT.PRT_CONT_AFTER END, 0) AS bit),
            [FileFormat] = CAST(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FILE_FORMAT ELSE ISNULL(CD.FILE_FORMAT, ISNULL(AD.FILE_FORMAT, 1)) END ELSE ISNULL(OT.FILE_FORMAT, 1) END AS smallint),
			[PrintQuantityTotals] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.PRINT_QTY_TOTALS ELSE ISNULL(CD.PRINT_QTY_TOTALS, AD.PRINT_QTY_TOTALS) END ELSE OT.PRINT_QTY_TOTALS END, 0) AS bit),
			[ShowWatermark] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SHOW_WATERMARK ELSE ISNULL(CD.SHOW_WATERMARK, AD.SHOW_WATERMARK) END ELSE OT.SHOW_WATERMARK END, 0) AS bit),
			[DisplayQuantity] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.DISPLAY_QTY ELSE ISNULL(CD.DISPLAY_QTY, AD.DISPLAY_QTY) END ELSE OT.DISPLAY_QTY END, 0) AS bit),
			[DisplayHours] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.DISPLAY_HOURS ELSE ISNULL(CD.DISPLAY_HOURS, AD.DISPLAY_HOURS) END ELSE OT.DISPLAY_HOURS END, 0) AS bit),
			[IncludeRateMarkup] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.INCL_RATE_MARKUP ELSE ISNULL(CD.INCL_RATE_MARKUP, AD.INCL_RATE_MARKUP) END ELSE OT.INCL_RATE_MARKUP END, 0) AS bit),
			[ExcludeDateFromSignature] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.EXCLUDE_DATE_SIGN ELSE ISNULL(CD.EXCLUDE_DATE_SIGN, AD.EXCLUDE_DATE_SIGN) END ELSE OT.EXCLUDE_DATE_SIGN END, 0) AS bit)
	FROM   PRODUCT AS C LEFT OUTER JOIN 
	       PROD_EST_DEF AS CD ON CD.CL_CODE = C.CL_CODE AND CD.DIV_CODE = C.DIV_CODE AND CD.PRD_CODE = C.PRD_CODE CROSS JOIN 
		   PROD_EST_DEF AS AD CROSS JOIN 
		   PROD_EST_DEF AS OT 
    WHERE 
		   AD.CLIENT_OR_DEF = 1 AND 
		   OT.CLIENT_OR_DEF = 0	   
		   
		   ) AS EST --INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'CITY_TAX') AS CTL ON 1 = 1 INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'COUNTY_TAX') AS COTL ON 1 = 1 INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'STATE_TAX') AS STL ON 1 = 1
		 WHERE [Type] <> 2
End

If @ClientOrProduct = 2
Begin
	SELECT
		[ID] = EST.ID,	
		[IsOneTime] = EST.IsOneTime,
		[Type] = EST.[Type],
		[UserID] = EST.[UserID],
		[ClientCode] = EST.ClientCode,
		[DivisionCode] = EST.DivisionCode,
		[ProductCode] = EST.ProductCode,
		[CDP] = EST.CDP,
		[SelectBy] = EST.SelectBy,
		[DateToPrint] = EST.DateToPrint,
		[DatePrint] = EST.DatePrint,
		[UseLocationOptions] = EST.UseLocationOptions,
        [LogoPath] = EST.LogoPath, 
        [LocationCode] = EST.LocationCode,
		[ReportTitle] = EST.ReportTitle,
		[PrintClientName] = EST.PrintClientName,
		[PrintDivisionName] = EST.PrintDivisionName,
		[PrintProductDescription] = EST.PrintProductDescription,
		[CDPAddressOption] = EST.CDPAddressOption,
		[IncludeClientReference] = EST.IncludeClientReference,
		[IncludeAccountExecutive] = EST.IncludeAccountExecutive,
		[IncludeSalesClass] = EST.IncludeSalesClass,
		[IncludeJobDueDate] = EST.IncludeJobDueDate,
		[IncludeJobQuantity] = EST.IncludeJobQuantity,
		[SuppressZeroFunctions] = EST.SuppressZeroFunctions,
		[IncludeNonBillable] = EST.IncludeNonBillable,
        [IncludeQuantityHours] = EST.IncludeQuantityHours,
        [IncludeRate] = EST.IncludeRate,
        [SubtotalsOnly] = EST.SubtotalsOnly,
        [IncludeCPU] = EST.IncludeCPU,
        [IncludeCPM] = EST.IncludeCPM,
        [HideJobDescription] = EST.HideJobDescription,
        [HideComponentDescription] = EST.HideComponentDescription,
        [HideRevision] = EST.HideRevision,
		[IncludeEstimateComment] = EST.IncludeEstimateComment,
		[IncludeEstimateComponentComment] = EST.IncludeEstimateComponentComment,
		[IncludeEstimateQuoteComment] = EST.IncludeEstimateQuoteComment,
		[IncludeEstimateRevisionComment] = EST.IncludeEstimateRevisionComment,
		[IncludeEstimateFunctionComment] = EST.IncludeEstimateFunctionComment,
		[IncludeSuppliedByNotes] = EST.IncludeSuppliedByNotes,
        [ReportFormat] = EST.ReportFormat,
		[SummaryLevel] = EST.SummaryLevel,
        [ExcludeEmployeeTime] = EST.ExcludeEmployeeTime,
        [ExcludeVendor] = EST.ExcludeVendor,
        [ExcludeIncomeOnly] = EST.ExcludeIncomeOnly,
        [ExcludeNonbillable] = EST.ExcludeNonbillable,
        [ConsolidationOverride] = EST.ConsolidationOverride,
        [GroupingOptionFunctionOption] = EST.GroupingOptionFunctionOption, 
        [GroupingOptionGroupOption] = EST.GroupingOptionGroupOption,
        [GroupingOptionInsideDescription] = EST.GroupingOptionInsideDescription, 
        [GroupingOptionOutsideDescription] = EST.GroupingOptionOutsideDescription, 
        [GroupingOptionSortOption] = EST.GroupingOptionSortOption, 
        [TotalsShowTaxSeparately] = EST.TotalsShowTaxSeparately,
        [IndicateTaxableFunctions] = EST.IndicateTaxableFunctions,
        [TotalsShowCommissionSeparately] = EST.TotalsShowCommissionSeparately,
        [IndicateCommissionFunctions] = EST.IndicateCommissionFunctions,
        [TotalsShowContingencySeparately] = EST.TotalsShowContingencySeparately,
        [TotalsIncludeContingency] = EST.TotalsIncludeContingency,
        [DefaultFooterComment] = EST.DefaultFooterComment,
        [Signature] = EST.[Signature],
        [ExcludeSignatures] = EST.ExcludeSignatures,
        --[IncludeSpecifications] = EST.IncludeSpecifications,
        [UseEmployeeSignature] = EST.UseEmployeeSignature,
        [IncludeCampaignSummary] = EST.IncludeCampaignSummary,
        [IncludeVendorDescription] = EST.IncludeVendorDescription,
        [IncludeFunctionComment] = EST.IncludeFunctionComment,
        [PrintAdNumber] = EST.PrintAdNumber,
		[CustomEstimateID] = CASE WHEN EST.CustomEstimateID = 0 THEN NULL ELSE EST.CustomEstimateID END,
		[ShowCodes] = EST.ShowCodes,
		[ContactType] = EST.ContactType,
        [PrintContactAfterAddress] = EST.PrintContactAfterAddress,		
		[FileFormat] = EST.FileFormat,
		[PrintQuantityTotals] = EST.PrintQuantityTotals,
		[ShowWatermark] = EST.ShowWatermark,
		[DisplayQuantity] = EST.DisplayQuantity,
		[DisplayHours] = EST.DisplayHours,
		[IncludeRateMarkup] = EST.IncludeRateMarkup,
		[ExcludeDateFromSignature] = EST.ExcludeDateFromSignature		
		--[CityTaxLabel] = CTL.FIELD_DESCRIPTION, 
		--[CountyTaxLabel] = COTL.FIELD_DESCRIPTION, 
		--[StateTaxLabel] = STL.FIELD_DESCRIPTION
	FROM
		(SELECT
			[ID] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PROD_EST_DEF_ID, AD.PROD_EST_DEF_ID) ELSE OT.PROD_EST_DEF_ID END, 0) AS int),
			[IsOneTime] = CAST(ISNULL(@IsOneTime, 0) AS bit),		
			[Type] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CLIENT_OR_DEF, AD.CLIENT_OR_DEF) ELSE OT.CLIENT_OR_DEF END AS smallint),
			--[ClientOrDefault] = CLIENT_OR_DEF,
			[UserID] = C.USER_CODE,
			[ClientCode] = NULL,
			[DivisionCode] = NULL,
			[ProductCode] = NULL,
			[CDP] = NULL,
            [SelectBy] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SELECT_BY, ISNULL(AD.SELECT_BY, '')) ELSE ISNULL(OT.SELECT_BY, '') END,
            [DateToPrint] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CASE WHEN ISNULL(CD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END, CASE WHEN ISNULL(AD.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END) ELSE CASE WHEN ISNULL(OT.DATE_TO_PRINT, 1) = 1 THEN CAST(0 AS bit) ELSE CAST(1 AS bit) END END, 0) AS bit),
			[DatePrint] = GETDATE(),
			[UseLocationOptions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.USE_LOCATION_OPTIONS, AD.USE_LOCATION_OPTIONS) ELSE OT.USE_LOCATION_OPTIONS END, 0) AS bit),
            [LogoPath] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.LOGO_PATH, ISNULL(AD.LOGO_PATH, '')) ELSE ISNULL(OT.LOGO_PATH, '') END, 
            [LocationCode] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.LOCATION_ID, ISNULL(AD.LOCATION_ID, '')) ELSE ISNULL(OT.LOCATION_ID, '') END,
            [ReportTitle] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.RPT_TITLE, ISNULL(AD.RPT_TITLE, '')) ELSE ISNULL(OT.RPT_TITLE, '') END,
            [PrintClientName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CL_NAME, AD.PRT_CL_NAME) ELSE OT.PRT_CL_NAME END, 0) AS bit),
            [PrintDivisionName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_DIV_NAME, AD.PRT_DIV_NAME) ELSE OT.PRT_DIV_NAME END, 0) AS bit),
            [PrintProductDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_PRD_NAME, AD.PRT_PRD_NAME) ELSE OT.PRT_PRD_NAME END, 0) AS bit),
            [CDPAddressOption] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CDP_ADDRESS, ISNULL(AD.CDP_ADDRESS, '')) ELSE ISNULL(OT.CDP_ADDRESS, '') END,
            [IncludeClientReference] =  CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CLI_REF, AD.CLI_REF) ELSE OT.CLI_REF END, 0) AS bit),
            [IncludeAccountExecutive] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.AE_NAME, AD.AE_NAME) ELSE OT.AE_NAME END, 0) AS bit),
            [IncludeSalesClass] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_SALES_CLASS, AD.PRT_SALES_CLASS) ELSE OT.PRT_SALES_CLASS END, 0) AS bit),
            [IncludeJobDueDate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.JOB_DUE_DATE, AD.JOB_DUE_DATE) ELSE OT.JOB_DUE_DATE END, 0) AS bit),
            [IncludeJobQuantity] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.JOB_QTY, AD.JOB_QTY) ELSE OT.JOB_QTY END, 0) AS bit),
            [SuppressZeroFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUPPRESS_ZERO, AD.SUPPRESS_ZERO) ELSE OT.SUPPRESS_ZERO END, 0) AS bit),
            [IncludeNonBillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_NONBILL, AD.PRT_NONBILL) ELSE OT.PRT_NONBILL END, 0) AS bit),
            [IncludeQuantityHours] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.QTY_HRS, AD.QTY_HRS) ELSE OT.QTY_HRS END, 0) AS bit),
            [IncludeRate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.INCL_RATE, AD.INCL_RATE) ELSE OT.INCL_RATE END, 0) AS bit),
            [SubtotalsOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUBTOT_ONLY, AD.SUBTOT_ONLY) ELSE OT.SUBTOT_ONLY END, 0) AS bit),
            [IncludeCPU] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CPU, AD.PRT_CPU) ELSE OT.PRT_CPU END, 0) AS bit),
            [IncludeCPM] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CPM, AD.PRT_CPM) ELSE OT.PRT_CPM END, 0) AS bit),
			[HideJobDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.HIDE_JOB_DESC, AD.HIDE_JOB_DESC) ELSE OT.HIDE_JOB_DESC END, 0) AS bit),
            [HideComponentDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.HIDE_COMP_DESC, AD.HIDE_COMP_DESC) ELSE OT.HIDE_COMP_DESC END, 0) AS bit),
            [HideRevision] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.HIDE_REVISION, AD.HIDE_REVISION) ELSE OT.HIDE_REVISION END, 0) AS bit),
            [IncludeEstimateComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EST_COMMENT, AD.EST_COMMENT) ELSE OT.EST_COMMENT END, 0) AS bit),  
            [IncludeEstimateComponentComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EST_COMP_COMMENT, AD.EST_COMP_COMMENT) ELSE OT.EST_COMP_COMMENT END, 0) AS bit),
            [IncludeEstimateQuoteComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.QTE_COMMENT, AD.QTE_COMMENT) ELSE OT.QTE_COMMENT END, 0) AS bit),
            [IncludeEstimateRevisionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.REV_COMMENT, AD.REV_COMMENT) ELSE OT.REV_COMMENT END, 0) AS bit),
            [IncludeEstimateFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.FUNC_COMMENT, AD.FUNC_COMMENT) ELSE OT.FUNC_COMMENT END, 0) AS bit),
            [IncludeSuppliedByNotes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUP_BY_NOTES, AD.SUP_BY_NOTES) ELSE OT.SUP_BY_NOTES END, 0) AS bit),
            [ReportFormat] = CASE @IsOneTime WHEN 0 THEN CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN ISNULL(AD.REPORT_FORMAT, '') ELSE ISNULL(CD.REPORT_FORMAT, ISNULL(AD.REPORT_FORMAT, '')) END ELSE ISNULL(OT.REPORT_FORMAT, '') END,
            [SummaryLevel] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SUMMARY_LEVEL, ISNULL(AD.SUMMARY_LEVEL,0)) ELSE ISNULL(OT.SUMMARY_LEVEL,0) END AS smallint),
            [ExcludeEmployeeTime] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_EMP_TIME, AD.EXCL_EMP_TIME) ELSE OT.EXCL_EMP_TIME END, 0) AS bit),
            [ExcludeVendor] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_VENDOR, AD.EXCL_VENDOR) ELSE OT.EXCL_VENDOR END, 0) AS bit),
            [ExcludeIncomeOnly] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_IO, AD.EXCL_IO) ELSE OT.EXCL_IO END, 0) AS bit),
            [ExcludeNonbillable] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_NONBILL, AD.EXCL_NONBILL) ELSE OT.EXCL_NONBILL END, 0) AS bit),
            [ConsolidationOverride] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONSOL_OVERRIDE, AD.CONSOL_OVERRIDE) ELSE OT.CONSOL_OVERRIDE END, 0) AS bit),
            [GroupingOptionFunctionOption] = CASE @IsOneTime WHEN 0 THEN 
											 CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.FUNCTION_OPTION ELSE ISNULL(CD.FUNCTION_OPTION, ISNULL(AD.FUNCTION_OPTION, '')) END
											 ELSE OT.FUNCTION_OPTION END, 	   
            [GroupingOptionGroupOption] = CASE @IsOneTime WHEN 0 THEN 
											CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.GROUP_OPTION ELSE ISNULL(CD.GROUP_OPTION, ISNULL(AD.GROUP_OPTION, '')) END
											 ELSE OT.GROUP_OPTION END, 
            [GroupingOptionInsideDescription] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.INSIDE_CHG_DESC, ISNULL(AD.INSIDE_CHG_DESC, '')) ELSE ISNULL(OT.INSIDE_CHG_DESC, '') END, 
            [GroupingOptionOutsideDescription] =  CASE @IsOneTime WHEN 0 THEN ISNULL(CD.OUTSIDE_CHG_DESC, ISNULL(AD.OUTSIDE_CHG_DESC, '')) ELSE ISNULL(OT.OUTSIDE_CHG_DESC, '') END, 
            [GroupingOptionSortOption] = CASE @IsOneTime WHEN 0 THEN 
											CASE WHEN CD.USE_AGENCY_SETTING = 1 THEN AD.SORT_OPTION ELSE ISNULL(CD.SORT_OPTION, ISNULL(AD.SORT_OPTION, '')) END
											 ELSE OT.SORT_OPTION END, 
            [TotalsShowTaxSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.TAX_SEPARATE, AD.TAX_SEPARATE) ELSE OT.TAX_SEPARATE END, 0) AS bit),
            [IndicateTaxableFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.TAX_INDICATOR, AD.TAX_INDICATOR) ELSE OT.TAX_INDICATOR END, 0) AS bit),
            [TotalsShowCommissionSeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.COMM_MU_SEPARATE, AD.COMM_MU_SEPARATE) ELSE OT.COMM_MU_SEPARATE END, 0) AS bit),
            [IndicateCommissionFunctions] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.COMM_MU_INDICATOR, AD.COMM_MU_INDICATOR) ELSE OT.COMM_MU_INDICATOR END, 0) AS bit),
            [TotalsShowContingencySeparately] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONT_SEPARATE, AD.CONT_SEPARATE) ELSE OT.CONT_SEPARATE END, 0) AS bit),
            [TotalsIncludeContingency] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONTINGENCY, AD.CONTINGENCY) ELSE OT.CONTINGENCY END, 0) AS bit),
            [DefaultFooterComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.DEF_FOOTER_COMMENT, AD.DEF_FOOTER_COMMENT) ELSE OT.DEF_FOOTER_COMMENT END, 0) AS bit),
            [Signature] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.[SIGNATURE], ISNULL(AD.[SIGNATURE], 999)) ELSE ISNULL(OT.[SIGNATURE], 999) END AS smallint),
            [ExcludeSignatures] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCL_SIGNATURES, AD.EXCL_SIGNATURES) ELSE OT.EXCL_SIGNATURES END, 0) AS bit),
            --[IncludeSpecifications] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SPECS, AD.SPECS) ELSE OT.SPECS END, 0) AS bit),CAST(ISNULL(SPECS, 0) AS bit),
            [UseEmployeeSignature] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.USE_EMP_SIG, AD.USE_EMP_SIG) ELSE OT.USE_EMP_SIG END, 0) AS bit),
            [IncludeCampaignSummary] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CMP_SUMMARY, AD.CMP_SUMMARY) ELSE OT.CMP_SUMMARY END, 0) AS bit),
            [IncludeVendorDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.VENDOR_DESC, AD.VENDOR_DESC) ELSE OT.VENDOR_DESC END, 0) AS bit),
            [IncludeFunctionComment] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.FNC_COMMENT, AD.FNC_COMMENT) ELSE OT.FNC_COMMENT END, 0) AS bit),
            [PrintAdNumber] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_AD_NBR, AD.PRT_AD_NBR) ELSE OT.PRT_AD_NBR END, 0) AS bit),
			[CustomEstimateID] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CUSTOM_ESTIMATE_ID, AD.CUSTOM_ESTIMATE_ID) ELSE OT.CUSTOM_ESTIMATE_ID END AS int),
            [ShowCodes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SHOW_CODES, AD.SHOW_CODES) ELSE OT.SHOW_CODES END, 0) AS bit),
			[ContactType] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONTACT_TYPE, ISNULL(AD.CONTACT_TYPE,1)) ELSE ISNULL(OT.CONTACT_TYPE,1) END AS int),
            [PrintContactAfterAddress] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_CONT_AFTER, AD.PRT_CONT_AFTER) ELSE OT.PRT_CONT_AFTER END, 0) AS bit),
            [FileFormat] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.FILE_FORMAT, ISNULL(AD.FILE_FORMAT, 1)) ELSE ISNULL(OT.FILE_FORMAT, 1) END AS smallint),
			[PrintQuantityTotals] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRINT_QTY_TOTALS, AD.PRINT_QTY_TOTALS) ELSE OT.PRINT_QTY_TOTALS END, 0) AS bit),
			[ShowWatermark] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SHOW_WATERMARK, AD.SHOW_WATERMARK) ELSE OT.SHOW_WATERMARK END, 0) AS bit),
			[DisplayQuantity] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.DISPLAY_QTY, AD.DISPLAY_QTY) ELSE OT.DISPLAY_QTY END, 0) AS bit),
			[DisplayHours] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.DISPLAY_HOURS, AD.DISPLAY_HOURS) ELSE OT.DISPLAY_HOURS END, 0) AS bit),
			[IncludeRateMarkup] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.INCL_RATE_MARKUP, AD.INCL_RATE_MARKUP) ELSE OT.INCL_RATE_MARKUP END, 0) AS bit),
			[ExcludeDateFromSignature] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.EXCLUDE_DATE_SIGN, AD.EXCLUDE_DATE_SIGN) ELSE OT.EXCLUDE_DATE_SIGN END, 0) AS bit)
	FROM   SEC_USER AS C LEFT OUTER JOIN 
	       PROD_EST_DEF AS CD ON UPPER(CD.[USER_ID]) = UPPER(C.USER_CODE) CROSS JOIN 
		   PROD_EST_DEF AS AD CROSS JOIN 
		   PROD_EST_DEF AS OT 
    WHERE 
		   AD.CLIENT_OR_DEF = 1 AND 
		   OT.CLIENT_OR_DEF = 0	   
		   
		   ) AS EST --INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'CITY_TAX') AS CTL ON 1 = 1 INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'COUNTY_TAX') AS COTL ON 1 = 1 INNER JOIN
		--(SELECT FIELD_DESCRIPTION FROM [dbo].[GEN_DESC] WHERE FIELD_NAME = 'STATE_TAX') AS STL ON 1 = 1
		 WHERE [Type] <> 3 and [Type] <> 2

End	
	




END



GO


