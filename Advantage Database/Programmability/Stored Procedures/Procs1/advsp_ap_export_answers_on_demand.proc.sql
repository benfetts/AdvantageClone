CREATE PROCEDURE [dbo].[advsp_ap_export_answers_on_demand]

	@DATE_START smalldatetime,
	@DATE_END smalldatetime,
	@ENTRY_OR_INVOICE_DATE smallint -- 0 = entry date, 1 = invoice date

AS

BEGIN

	SET NOCOUNT ON
	
	SET @DATE_END = DATEADD(d, 1, @DATE_END)

	DECLARE @AP_IDS TABLE (
		AP_ID int NOT NULL
	)
	
	IF @ENTRY_OR_INVOICE_DATE = 0
	BEGIN
		INSERT @AP_IDS 
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
		INSERT @AP_IDS
		SELECT AP_ID 
		FROM
			[dbo].[AP_HEADER]
		WHERE
			AP_INV_DATE BETWEEN @DATE_START AND @DATE_END
		AND	MODIFY_FLAG IS NULL
		AND DELETE_FLAG IS NULL
	END

	DECLARE @AP_HEADER TABLE (
		[AccountPayableID] int NOT NULL,
		[VendorCode] varchar(6) NOT NULL,
		[InvoiceNumber] varchar(20) NOT NULL,
		[InvoiceDate] smalldatetime NULL,
		[DueDate] smalldatetime NULL,
		[InvoiceDescription] varchar(30) NULL,
		[TotalPayable] decimal(14,2) NOT NULL,
		[PostingMonthYear] varchar(10) NULL
	)
	
	INSERT @AP_HEADER
	SELECT
		[AccountPayableID] = APH.AP_ID,
		[VendorCode] = VN_FRL_EMP_CODE,
		[InvoiceNumber] = AP_INV_VCHR,
		[InvoiceDate] = AP_INV_DATE,
		[DueDate] = AP_DATE_PAY,
		[InvoiceDescription] = AP_DESC,
		[TotalPayable] = COALESCE(AP_INV_AMT,0) + COALESCE(AP_SHIPPING,0) + COALESCE(AP_SALES_TAX,0),
		[PostingMonthYear] = RIGHT(APH.POST_PERIOD, 2) + '/' + LEFT(APH.POST_PERIOD, 4)
	FROM
		[dbo].[AP_HEADER] APH
			INNER JOIN @AP_IDS APIDS ON APH.AP_ID = APIDS.AP_ID 
	WHERE
		MODIFY_FLAG IS NULL
	AND DELETE_FLAG IS NULL
	
	SELECT
		[AccountPayableID] = APH.AccountPayableID,
		[HeaderRecordIdentifier] = 'H',
		[VendorCode] = APH.VendorCode,
		[InvoiceNumber] = APH.InvoiceNumber,
		[InvoiceDate] = APH.InvoiceDate,
		[DueDate] = APH.DueDate,
		[InvoiceDescription] = APH.InvoiceDescription,
		[TotalPayable] = APH.TotalPayable,
		[PostingMonthYear] = APH.PostingMonthYear,
		[DetailRecordIdentifier] = 'D',
		DETAIL.ClientCode,
		DETAIL.DivisionCode,
		DETAIL.ProductCode,
		DETAIL.DistributedGLAccount,
		DETAIL.DistributedAmount  
	FROM
		@AP_HEADER APH
			INNER JOIN @AP_IDS APIDS ON APH.AccountPayableID = APIDS.AP_ID 
			INNER JOIN (
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = CASE WHEN COALESCE( AP_PROD_NOBILL_FLG, 0 ) = 1 THEN GLACODE
														  ELSE COALESCE( dbo.advfn_get_gl_acct( 42, 'P', APP.OFFICE_CODE, JL.SC_CODE, APP.FNC_CODE, NULL ), O.PGLACODE_COS ) END,
							[ClientCode] = JL.CL_CODE,
							[DivisionCode] = JL.DIV_CODE,
							[ProductCode] = JL.PRD_CODE,
							[DistributedAmount] = COALESCE(AP_PROD_EXT_AMT,0) + COALESCE(EXT_NONRESALE_TAX,0)
						FROM
							[dbo].[AP_PRODUCTION] APP
								INNER JOIN [dbo].[JOB_LOG] JL ON APP.JOB_NUMBER = JL.JOB_NUMBER 
								INNER JOIN [dbo].[OFFICE] O ON APP.OFFICE_CODE = O.OFFICE_CODE 
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						
						UNION
						
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = GLACODE,
							[ClientCode] = NULL,
							[DivisionCode] = NULL,
							[ProductCode] = NULL,
							[DistributedAmount] = AP_GL_AMT
						FROM
							[dbo].[AP_GL_DIST] APGL
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						
						UNION
						
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', API.OFFICE_CODE, IH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS ),
							[ClientCode] = IH.CL_CODE,
							[DivisionCode] = IH.DIV_CODE,
							[ProductCode] = IH.PRD_CODE,
							[DistributedAmount] = COALESCE(NET_AMT,0) - ABS(COALESCE(DISCOUNT_AMT,0)) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0)
						FROM
							[dbo].[AP_INTERNET] API
								INNER JOIN [dbo].[INTERNET_HEADER] IH ON API.ORDER_NBR = IH.ORDER_NBR
								INNER JOIN [dbo].[OFFICE] O ON API.OFFICE_CODE = O.OFFICE_CODE 
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						
						UNION
						
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APM.OFFICE_CODE, VMH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS ),
							[ClientCode] = VMH.CL_CODE,
							[DivisionCode] = VMH.DIV_CODE,
							[ProductCode] = VMH.PRD_CODE,
							[DistributedAmount] = COALESCE(DISBURSED_AMT,0)
						FROM
							[dbo].[AP_MAGAZINE] APM
								INNER JOIN [dbo].[V_MAG_HEADER] VMH ON APM.ORDER_NBR = VMH.ORDER_NBR 
								INNER JOIN [dbo].[OFFICE] O ON APM.OFFICE_CODE = O.OFFICE_CODE 
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						
						UNION
						
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APN.OFFICE_CODE, VNH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS ),
							[ClientCode] = VNH.CL_CODE,
							[DivisionCode] = VNH.DIV_CODE,
							[ProductCode] = VNH.PRD_CODE,
							[DistributedAmount] = COALESCE(DISBURSED_AMT,0)
						FROM
							[dbo].[AP_NEWSPAPER] APN
								INNER JOIN [dbo].[V_NEWS_HEADER] VNH ON APN.ORDER_NBR = VNH.ORDER_NBR 
								INNER JOIN [dbo].[OFFICE] O ON APN.OFFICE_CODE = O.OFFICE_CODE 
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						
						UNION
						
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APO.OFFICE_CODE, OH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS ),
							[ClientCode] = OH.CL_CODE,
							[DivisionCode] = OH.DIV_CODE,
							[ProductCode] = OH.PRD_CODE,
							[DistributedAmount] = COALESCE(NET_AMT,0) - COALESCE(DISCOUNT_AMT,0) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0)
						FROM
							[dbo].[AP_OUTDOOR] APO
								INNER JOIN [dbo].[OUTDOOR_HEADER] OH ON APO.ORDER_NBR = OH.ORDER_NBR 
								INNER JOIN [dbo].[OFFICE] O ON APO.OFFICE_CODE = O.OFFICE_CODE 
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						
						UNION
						
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APR.OFFICE_CODE, RH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS ),
							[ClientCode] = RH.CL_CODE,
							[DivisionCode] = RH.DIV_CODE,
							[ProductCode] = RH.PRD_CODE,
							[DistributedAmount] = COALESCE(EXT_NET_AMT,0) - ABS(COALESCE(DISC_AMT,0)) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0)
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
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						
						UNION
						
						SELECT
							[AccountPayableID] = AP_ID,
							[DistributedGLAccount] = COALESCE( dbo.advfn_get_gl_acct( 42, 'M', APT.OFFICE_CODE, TH.MEDIA_TYPE, NULL, NULL ), O.MGLACODE_COS ),
							[ClientCode] = TH.CL_CODE,
							[DivisionCode] = TH.DIV_CODE,
							[ProductCode] = TH.PRD_CODE,
							[DistributedAmount] = COALESCE(EXT_NET_AMT,0) - ABS(COALESCE(DISC_AMT,0)) + COALESCE(NETCHARGES,0) + COALESCE(VENDOR_TAX,0)
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
						WHERE
							(MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
						) DETAIL ON APH.AccountPayableID = DETAIL.AccountPayableID 
END

GO
