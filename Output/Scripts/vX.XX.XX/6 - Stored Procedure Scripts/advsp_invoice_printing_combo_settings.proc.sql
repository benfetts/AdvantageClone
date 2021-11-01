CREATE PROCEDURE [dbo].[advsp_invoice_printing_combo_settings] ( 
	@IsOneTime AS bit
)
AS
BEGIN

	SELECT
		[ComboInvoicePrintingOptionsID] = IPS.[ComboInvoicePrintingOptionsID],
		[IsOneTime] = IPS.IsOneTime,
		[Type] = IPS.[Type],
		[ClientCode] = IPS.ClientCode,
		[AddressBlockType] = IPS.AddressBlockType,
		[LocationCode] = IPS.LocationCode,
		--[CustomFormatName] = IPS.CustomFormatName,
		[ApplyExchangeRate] = IPS.ApplyExchangeRate,
		[ExchangeRateAmount] = IPS.ExchangeRateAmount,
		[PrintClientName] = IPS.PrintClientName,
		[PrintDivisionName] = IPS.PrintDivisionName,
		[PrintProductDescription] = IPS.PrintProductDescription,
		[PrintContactAfterAddress] = IPS.PrintContactAfterAddress,
		[UseInvoiceCategoryDescription] = IPS.UseInvoiceCategoryDescription,
		[InvoiceTitle] = IPS.InvoiceTitle,
		[InvoiceFooterCommentType] = IPS.InvoiceFooterCommentType,
		[InvoiceFooterComment] = IPS.InvoiceFooterComment,
		[ShowCodes] = IPS.ShowCodes, 
		[ContactType] = IPS.ContactType,
		[IncludeInvoiceDueDate] = IPS.IncludeInvoiceDueDate,
		[PageSetting] = IPS.PageSetting,
		[PageHeaderComment] = CASE WHEN L.PRT_HDR = 1 THEN L.LOC_HDR ELSE '' END,
		[PageFooterComment] = CASE WHEN L.PRT_FTR = 1 THEN L.LOC_FTR ELSE '' END,
		[PageHeaderLogoPath] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH ELSE '' END,
		[PageHeaderLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH_LAND ELSE '' END,
		[PageFooterLogoPath] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_2 ELSE '' END,
		[PageFooterLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_LAND_2 ELSE '' END,
		[ShowPageHeaderLogo] = CAST(CASE WHEN L.LOGO_LOCATION = 'C' THEN 1 ELSE 0 END AS bit),
		[ShowPageFooterLogo] = CAST(CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN 1 ELSE 0 END AS bit)
	FROM
		(SELECT 
				[ComboInvoicePrintingOptionsID] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.COMBO_INV_DEF_ID, AD.COMBO_INV_DEF_ID) ELSE OT.COMBO_INV_DEF_ID END, 0) AS int),
				[IsOneTime] = CAST(ISNULL(@IsOneTime, 0) AS bit),		
				[Type] = CAST(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CLIENT_OR_DEF, AD.CLIENT_OR_DEF) ELSE OT.CLIENT_OR_DEF END AS smallint),
				[ClientCode] = C.CL_CODE,					    
				[AddressBlockType] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.ADDRESS_BLOCK, AD.ADDRESS_BLOCK) ELSE OT.ADDRESS_BLOCK END, 1) AS smallint),
				[LocationCode] = CASE WHEN ISNULL(C.INVOICE_LOCATION_ID, '') = '' THEN CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_LOC_PG_FTR_DEF, AD.PRT_LOC_PG_FTR_DEF) ELSE OT.PRT_LOC_PG_FTR_DEF END ELSE C.INVOICE_LOCATION_ID END,
				[CustomFormatName] = CASE @IsOneTime WHEN 0 THEN CD.CUSTOM_FORMAT ELSE OT.CUSTOM_FORMAT END,  
				[ApplyExchangeRate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.COL_OPT_XCHGE_AMTS, AD.COL_OPT_XCHGE_AMTS) ELSE OT.COL_OPT_XCHGE_AMTS END, 0) AS smallint),
				[ExchangeRateAmount] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.COL_OPT_XCHGE_DEF, AD.COL_OPT_XCHGE_DEF) ELSE OT.COL_OPT_XCHGE_DEF END, 1) AS decimal(10,4)),
				[PrintClientName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRINT_CLIENT_NAME, AD.PRINT_CLIENT_NAME) ELSE OT.PRINT_CLIENT_NAME END, 0) AS bit),
				[PrintDivisionName] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRINT_DIV_NAME, AD.PRINT_DIV_NAME) ELSE OT.PRINT_DIV_NAME END, 0) AS bit),
				[PrintProductDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRINT_PRD_DESC, AD.PRINT_PRD_DESC) ELSE OT.PRINT_PRD_DESC END, 0) AS bit),
				[PrintContactAfterAddress] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONTACT_POS, AD.CONTACT_POS) ELSE OT.CONTACT_POS END, 0) AS bit),
				[UseInvoiceCategoryDescription] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.INV_CAT_TITLE, AD.INV_CAT_TITLE) ELSE OT.INV_CAT_TITLE END, 0) AS bit),
				[InvoiceTitle] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.INV_TITLE, AD.INV_TITLE) ELSE OT.INV_TITLE END,   
				[InvoiceFooterCommentType] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.TOT_PAYMNT_TERMS, AD.TOT_PAYMNT_TERMS) ELSE OT.TOT_PAYMNT_TERMS END, 1) AS smallint),
				[InvoiceFooterComment] = CASE @IsOneTime WHEN 0 THEN ISNULL(CD.TOT_PAYMNT_TERMS_DEF, AD.TOT_PAYMNT_TERMS_DEF) ELSE OT.TOT_PAYMNT_TERMS_DEF END,   
				[ShowCodes] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.SHOW_CODES, AD.SHOW_CODES) ELSE OT.SHOW_CODES END, 0) AS bit),
				[ContactType] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.CONTACT_TYPE, AD.CONTACT_TYPE) ELSE OT.CONTACT_TYPE END, 0) AS int),                   
				[IncludeInvoiceDueDate] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PRT_DUE_DATE, AD.PRT_DUE_DATE) ELSE OT.PRT_DUE_DATE END, 0) AS bit),
				[PageSetting] = CAST(ISNULL(CASE @IsOneTime WHEN 0 THEN ISNULL(CD.PAGE_SETTING, AD.PAGE_SETTING) ELSE OT.PAGE_SETTING END, 1) AS smallint)
			FROM 
				[dbo].[CLIENT] AS C LEFT OUTER JOIN 
				[dbo].[COMBO_INV_DEF] AS CD ON CD.CL_CODE = C.CL_CODE CROSS JOIN 
				[dbo].[COMBO_INV_DEF] AS AD CROSS JOIN 
				[dbo].[COMBO_INV_DEF] AS OT
			WHERE 
				AD.CLIENT_OR_DEF = 1 AND 
				OT.CLIENT_OR_DEF = 0) AS IPS LEFT OUTER JOIN 
		[dbo].[advtf_location_query]() AS L ON L.LOC_ID = IPS.[LocationCode]

END








GO