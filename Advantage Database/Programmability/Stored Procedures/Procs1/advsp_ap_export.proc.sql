CREATE PROCEDURE [dbo].[advsp_ap_export]

	@DATE_START smalldatetime,
	@DATE_END smalldatetime,
	@ENTRY_OR_INVOICE_DATE smallint -- 0 = entry date, 1 = invoice date
	
AS

BEGIN

	SET NOCOUNT ON;
	
	SET @DATE_END = DATEADD(N,-1,DATEADD(d, 1, @DATE_END))
	
	DECLARE @APIDS TABLE (
		AP_ID int NOT NULL
	)

	IF @ENTRY_OR_INVOICE_DATE = 0
	BEGIN
		INSERT @APIDS 
		SELECT	AP_ID
		FROM	[dbo].[AP_PRODUCTION] APP
		WHERE
			APP.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION

		SELECT	AP_ID
		FROM	[dbo].[AP_GL_DIST] APGL
		WHERE
			APGL.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION

		SELECT	AP_ID
		FROM	[dbo].[AP_INTERNET] API
		WHERE
			API.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION

		SELECT	AP_ID
		FROM	[dbo].[AP_MAGAZINE] APM
		WHERE
			APM.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION

		SELECT	AP_ID
		FROM	[dbo].[AP_NEWSPAPER] APN
		WHERE
			APN.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION

		SELECT	AP_ID
		FROM	[dbo].[AP_OUTDOOR] APO
		WHERE
			APO.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION

		SELECT	AP_ID
		FROM	[dbo].[AP_RADIO] APR
		WHERE
			APR.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION

		SELECT	AP_ID
		FROM	[dbo].[AP_TV] APT
		WHERE
			APT.CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)

		UNION 
		
		SELECT	AP_ID
		FROM	[dbo].[AP_HEADER]
		WHERE
			CREATE_DATE BETWEEN @DATE_START AND @DATE_END
		AND	MODIFY_FLAG IS NULL
		AND DELETE_FLAG IS NULL
	END
	ELSE
	BEGIN
		INSERT @APIDS
		SELECT AP_ID 
		FROM
			[dbo].[AP_HEADER]
		WHERE
			AP_INV_DATE BETWEEN @DATE_START AND @DATE_END
		AND	MODIFY_FLAG IS NULL
		AND DELETE_FLAG IS NULL
	END	
	
	SELECT
		[VendorCode] = VN_FRL_EMP_CODE,
		[VendorAccount] = V.VN_ACCT_NBR, 
		[VendorFederalTaxID] = V.VN_TAX_ID,
		[VendorEmailAddress] = V.VN_EMAIL,
		[VCCStatusCode] = V.VCC_STATUS,
		[VCCStatusDescription] = CASE COALESCE(V.VCC_STATUS, 0) WHEN 0 THEN 'Open'
																WHEN 1 THEN 'Accepted'
																WHEN 2 THEN 'Declined'
																END,
		[InvoiceNumber] = AP_INV_VCHR,
		[ExpenseReportYN] = CASE WHEN (SELECT COUNT(1) FROM [dbo].[AP_PRODUCTION] WHERE AP_ID = APH.AP_ID AND EXPDETAILID IS NOT NULL) + (SELECT COUNT(1) FROM [dbo].[AP_GL_DIST] WHERE AP_ID = APH.AP_ID AND EXPDETAILID IS NOT NULL) > 0 THEN 'Y' ELSE 'N' END,
		[InvoiceDescription] = AP_DESC,
		[InvoiceDate] = AP_INV_DATE,
		[DateToPay] = AP_DATE_PAY,
		[InvoiceAmount] = COALESCE(APH.AP_INV_AMT,0) + COALESCE(APH.AP_SHIPPING,0),
		[SalesTaxAmount] = APH.AP_SALES_TAX,
		[IsOnHold] = CASE COALESCE(APH.PAYMENT_HOLD,0) WHEN 1 THEN 'Y' ELSE 'N' END,
		[GLACode] = APH.GLACODE,
		[PostPeriodCode] = APH.POST_PERIOD,
		[OfficeCode] = APH.OFFICE_CODE,
		[Is1099Invoice] = CASE COALESCE(APH.FLAG_1099,0) WHEN 1 THEN 'Y' ELSE 'N' END,
		[EntryBy] = APH.CREATED_BY,
        [EntryDate] = APH.CREATE_DATE,
        [ModifiedBy] = APH.MODIFIED_BY,
        [ModifiedDate] = APH.MODIFY_DATE,
        [BatchName] = APH.BATCH_NAME,
		[DetailType] = details.DetailType,
		[DetailClientCode] = details.ClientCode,
		[DetailDivisionCode] = details.DivisionCode,
		[DetailProductCode] = details.ProductCode,
		[DetailFunctionCode] = details.FunctionCode,
		[DetailSalesClassCode] = details.SalesClassCode,
		[DetailVendorTax] = details.VendorTax,
		[DetailDisbursedAmount] = details.DisbursedAmount,
		[DetailOfficeCode] = details.OfficeCode,
		[DetailGLACode] = details.GLACode,
		[DetailGLACodeBilling] = details.GLACodeBilling 
	FROM
		@APIDS IDS
			INNER JOIN [dbo].[AP_HEADER] APH ON IDS.AP_ID = APH.AP_ID AND APH.MODIFY_FLAG IS NULL AND APH.DELETE_FLAG IS NULL
			INNER JOIN [dbo].[VENDOR] V ON APH.VN_FRL_EMP_CODE = V.VN_CODE
			LEFT OUTER JOIN (
							SELECT	AP_ID,
									DetailType = 'P',
									ClientCode = JL.CL_CODE,
									DivisionCode = JL.DIV_CODE,
									ProductCode = JL.PRD_CODE,
									FunctionCode = APP.FNC_CODE,
									SalesClassCode = JL.SC_CODE,
									VendorTax = APP.EXT_NONRESALE_TAX,
									DisbursedAmount = COALESCE(AP_PROD_EXT_AMT,0) + COALESCE(EXT_NONRESALE_TAX,0),
									OfficeCode = APP.OFFICE_CODE,
									GLACode = APP.GLACODE,
									GLACodeBilling = CASE WHEN COALESCE( AP_PROD_NOBILL_FLG, 0 ) = 1 THEN GLACODE
														  ELSE COALESCE( dbo.advfn_get_gl_acct( 42, 'P', APP.OFFICE_CODE, JL.SC_CODE, APP.FNC_CODE, NULL ), O.PGLACODE_COS ) END
							FROM	[dbo].[AP_PRODUCTION] APP
										INNER JOIN [dbo].[JOB_LOG] JL ON APP.JOB_NUMBER = JL.JOB_NUMBER 
										INNER JOIN [dbo].[OFFICE] O ON APP.OFFICE_CODE = O.OFFICE_CODE 
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							
							UNION
							
							SELECT	AP_ID,
									DetailType = 'GL',
									ClientCode = NULL,
									DivisionCode = NULL,
									ProductCode = NULL,
									FunctionCode = NULL,
									SalesClassCode = NULL,
									VendorTax = NULL,
									DisbursedAmount = GL.AP_GL_AMT,
									OfficeCode = GL.OFFICE_CODE,
									GLACode = GL.GLACODE,
									GLACodeBilling = GLACODE
							FROM	dbo.AP_GL_DIST GL
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							
							UNION
							
							SELECT	AP_ID,
									DetailType = 'I',
									ClientCode = IH.CL_CODE,
									DivisionCode = IH.DIV_CODE,
									ProductCode = IH.PRD_CODE,
									FunctionCode = NULL,
									SalesClassCode = IH.MEDIA_TYPE,
									VendorTax = NULL,
									DisbursedAmount = COALESCE(NET_AMT,0) - ABS(COALESCE(DISCOUNT_AMT,0)) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0),
									OfficeCode = API.OFFICE_CODE,
									GLACode = API.GLACODE,
									GLACodeBilling = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', API.OFFICE_CODE, IH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS )
							FROM	[dbo].[AP_INTERNET] API
										INNER JOIN [dbo].[INTERNET_HEADER] IH ON API.ORDER_NBR = IH.ORDER_NBR
										INNER JOIN [dbo].[OFFICE] O ON API.OFFICE_CODE = O.OFFICE_CODE 
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							
							UNION
							
							SELECT	AP_ID,
									DetailType = 'M',
									ClientCode = VMH.CL_CODE,
									DivisionCode = VMH.DIV_CODE,
									ProductCode = VMH.PRD_CODE,
									FunctionCode = NULL,
									SalesClassCode = VMH.MEDIA_TYPE,
									VendorTax = NULL,
									DisbursedAmount = COALESCE(DISBURSED_AMT,0),
									OfficeCode = APM.OFFICE_CODE,
									GLACode = APM.GLACODE,
									GLACodeBilling = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APM.OFFICE_CODE, VMH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS )
							FROM	[dbo].[AP_MAGAZINE] APM
										INNER JOIN [dbo].[V_MAG_HEADER] VMH ON APM.ORDER_NBR = VMH.ORDER_NBR 
										INNER JOIN [dbo].[OFFICE] O ON APM.OFFICE_CODE = O.OFFICE_CODE 
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							
							UNION
							
							SELECT	AP_ID,
									DetailType = 'N',
									ClientCode = VNH.CL_CODE,
									DivisionCode = VNH.DIV_CODE,
									ProductCode = VNH.PRD_CODE,
									FunctionCode = NULL,
									SalesClassCode = VNH.MEDIA_TYPE,
									VendorTax = NULL,
									DisbursedAmount = COALESCE(DISBURSED_AMT,0),
									OfficeCode = APN.OFFICE_CODE,
									GLACode = APN.GLACODE,
									GLACodeBilling = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APN.OFFICE_CODE, VNH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS )
							FROM	[dbo].[AP_NEWSPAPER] APN
										INNER JOIN [dbo].[V_NEWS_HEADER] VNH ON APN.ORDER_NBR = VNH.ORDER_NBR 
										INNER JOIN [dbo].[OFFICE] O ON APN.OFFICE_CODE = O.OFFICE_CODE 
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							
							UNION
							
							SELECT	AP_ID,
									DetailType = 'O',
									ClientCode = OH.CL_CODE,
									DivisionCode = OH.DIV_CODE,
									ProductCode = OH.PRD_CODE,
									FunctionCode = NULL,
									SalesClassCode = OH.MEDIA_TYPE,
									VendorTax = NULL,
									DisbursedAmount = COALESCE(NET_AMT,0) - COALESCE(DISCOUNT_AMT,0) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0),
									OfficeCode = APO.OFFICE_CODE,
									GLACode = APO.GLACODE,
									GLACodeBilling = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APO.OFFICE_CODE, OH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS )
							FROM	[dbo].[AP_OUTDOOR] APO
										INNER JOIN [dbo].[OUTDOOR_HEADER] OH ON APO.ORDER_NBR = OH.ORDER_NBR 
										INNER JOIN [dbo].[OFFICE] O ON APO.OFFICE_CODE = O.OFFICE_CODE 
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							
							UNION
							
							SELECT	AP_ID,
									DetailType = 'R',
									ClientCode = RH.CL_CODE,
									DivisionCode = RH.DIV_CODE,
									ProductCode = RH.PRD_CODE,
									FunctionCode = NULL,
									SalesClassCode = RH.MEDIA_TYPE,
									VendorTax = NULL,
									DisbursedAmount = COALESCE(EXT_NET_AMT,0) - ABS(COALESCE(DISC_AMT,0)) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0),
									OfficeCode = APR.OFFICE_CODE,
									GLACode = APR.GLACODE,
									GLACodeBilling = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APR.OFFICE_CODE, RH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS )
							FROM
								[dbo].[AP_RADIO] APR
									INNER JOIN [dbo].[OFFICE] O ON APR.OFFICE_CODE = O.OFFICE_CODE  
									INNER JOIN (SELECT CL_CODE, 
													   DIV_CODE,
													   PRD_CODE,
													   ORDER_NBR,
													   MEDIA_TYPE
												FROM [dbo].[RADIO_HEADER]
												UNION
												SELECT CL_CODE, 
													   DIV_CODE,
													   PRD_CODE,
													   ORDER_NBR,
													   MEDIA_TYPE
												FROM [dbo].[RADIO_HDR]
												) RH ON APR.ORDER_NBR = RH.ORDER_NBR 
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							
							UNION
							
							SELECT	AP_ID,
									DetailType = 'R',
									ClientCode = TH.CL_CODE,
									DivisionCode = TH.DIV_CODE,
									ProductCode = TH.PRD_CODE,
									FunctionCode = NULL,
									SalesClassCode = TH.MEDIA_TYPE,
									VendorTax = NULL,
									DisbursedAmount = COALESCE(EXT_NET_AMT,0) - ABS(COALESCE(DISC_AMT,0)) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0),
									OfficeCode = APT.OFFICE_CODE,
									GLACode = APT.GLACODE,
									GLACodeBilling = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APT.OFFICE_CODE, TH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS )
							FROM
								[dbo].[AP_TV] APT
									INNER JOIN [dbo].[OFFICE] O ON APT.OFFICE_CODE = O.OFFICE_CODE 
									INNER JOIN (SELECT CL_CODE, 
													   DIV_CODE,
													   PRD_CODE,
													   ORDER_NBR,
													   MEDIA_TYPE
												FROM [dbo].[RADIO_HEADER]
												UNION
												SELECT CL_CODE, 
													   DIV_CODE,
													   PRD_CODE,
													   ORDER_NBR,
													   MEDIA_TYPE
												FROM [dbo].[RADIO_HDR]
												) TH ON APT.ORDER_NBR = TH.ORDER_NBR
							WHERE	(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
							) details ON IDS.AP_ID = details.AP_ID 
	ORDER BY APH.AP_ID
END
GO
