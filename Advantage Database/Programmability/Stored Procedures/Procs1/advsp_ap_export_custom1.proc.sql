CREATE PROCEDURE [dbo].[advsp_ap_export_custom1]

	@ENTRY_OR_INVOICE_OR_EXPORT_DATE smallint = 2, -- 0 = entry date, 1 = invoice date, 2 = export date
	@DATE_START smalldatetime = NULL,
	@DATE_END smalldatetime = NULL

AS

BEGIN

	DECLARE @EXPORT_DATE smalldatetime

	SET NOCOUNT ON
	
	SET @DATE_END = DATEADD(N,-1,DATEADD(d, 1, @DATE_END))
	
	SET @EXPORT_DATE = @DATE_START

	IF @ENTRY_OR_INVOICE_OR_EXPORT_DATE = 2 BEGIN
		
		SELECT
			[AccountPayableID] = aph.AP_ID,
			[VendorCode] = aph.VN_FRL_EMP_CODE,
			[VendorAccountNumber]= v.VN_ACCT_NBR,
			[VendorName] = v.VN_NAME,
			[InvoiceDate] = aph.AP_INV_DATE,
			[InvoiceNumber] = aph.AP_INV_VCHR,
			[InvoiceTotal] = COALESCE(aph.AP_INV_AMT,0) + COALESCE(aph.AP_SHIPPING,0) + COALESCE(aph.AP_SALES_TAX,0),
			[JobComponent] = APJobs.JobComponent,
			[Department] = APJobs.Department,
			[BusinessUnit] = APJobs.BusinessUnit,
			[Product] = APJobs.Product,
			[AccountNumber] = APJobs.AccountNumber,
			[Total] = APJobs.JobRowTotal,
			[CurrencyCode] = v.CURRENCY_CODE,
			[ExportDate] = CASE WHEN @EXPORT_DATE IS NULL 
									AND (NULLIF(v.VN_ACCT_NBR,'') IS NOT NULL
									AND	NULLIF(APJobs.Department,'') IS NOT NULL
									AND	NULLIF(APJobs.BusinessUnit,'') IS NOT NULL
									AND	NULLIF(APJobs.Product,'') IS NOT NULL
									AND	NULLIF(APJobs.AccountNumber,'') IS NOT NULL
									) THEN CONVERT(varchar(10), getdate(), 101)
								ELSE (SELECT EXPORT_DATE FROM dbo.AP_EXPORTED WHERE AP_ID = aph.AP_ID) END,
			[Include] = CASE WHEN (NULLIF(v.VN_ACCT_NBR,'') IS NOT NULL
									AND	NULLIF(APJobs.Department,'') IS NOT NULL
									AND	NULLIF(APJobs.BusinessUnit,'') IS NOT NULL
									AND	NULLIF(APJobs.Product,'') IS NOT NULL
									AND	NULLIF(APJobs.AccountNumber,'') IS NOT NULL
									) THEN CAST(1 as bit) ELSE CAST(0 as bit) END
		FROM dbo.AP_HEADER aph
			INNER JOIN dbo.VENDOR v ON aph.VN_FRL_EMP_CODE = v.VN_CODE 
			INNER JOIN (SELECT
							AP_ID,
							[JobComponent] = RIGHT('000000'+CAST(app.JOB_NUMBER AS varchar(6)),6) + '-' + RIGHT('000'+CAST(app.JOB_COMPONENT_NBR AS varchar(2)),2),
							[JobRowTotal] = SUM(COALESCE(AP_PROD_EXT_AMT,0) + COALESCE(EXT_NONRESALE_TAX,0)),
							[Department] = CASE WHEN jl.UDV4_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu4.UDV_DESC ELSE jl.UDV4_CODE END,
							[BusinessUnit] = CASE WHEN jl.UDV2_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu2.UDV_DESC ELSE jl.UDV2_CODE END,
							[Product] = CASE WHEN jl.UDV3_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu3.UDV_DESC ELSE jl.UDV3_CODE END,
							[AccountNumber] = CASE WHEN jl.UDV1_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu1.UDV_DESC ELSE jl.UDV1_CODE END
						FROM dbo.AP_PRODUCTION app
							INNER JOIN dbo.JOB_LOG jl ON app.JOB_NUMBER = jl.JOB_NUMBER
							LEFT OUTER JOIN dbo.JOB_LOG_UDV4 jlu4 ON jl.UDV4_CODE = jlu4.UDV_CODE 
							LEFT OUTER JOIN dbo.JOB_LOG_UDV2 jlu2 ON jl.UDV2_CODE = jlu2.UDV_CODE
							LEFT OUTER JOIN dbo.JOB_LOG_UDV3 jlu3 ON jl.UDV3_CODE = jlu3.UDV_CODE
							LEFT OUTER JOIN dbo.JOB_LOG_UDV1 jlu1 ON jl.UDV1_CODE = jlu1.UDV_CODE
						GROUP BY
								AP_ID,
								RIGHT('000000'+CAST(app.JOB_NUMBER AS varchar(6)),6) + '-' + RIGHT('000'+CAST(app.JOB_COMPONENT_NBR AS varchar(2)),2),
								jl.UDV4_CODE,
								jl.UDV2_CODE,
								jl.UDV3_CODE,
								jl.JOB_NUMBER,
								jlu4.UDV_DESC,
								jlu2.UDV_DESC,
								jlu3.UDV_DESC,
								jl.UDV1_CODE,
								jlu1.UDV_DESC
						) APJobs ON aph.AP_ID = APJobs.AP_ID
		WHERE
			(
				( @EXPORT_DATE IS NULL AND aph.AP_ID NOT IN (SELECT AP_ID FROM dbo.AP_EXPORTED) )
			OR
				( @EXPORT_DATE IS NOT NULL AND aph.AP_ID IN (SELECT AP_ID FROM dbo.AP_EXPORTED WHERE EXPORT_DATE BETWEEN @DATE_START AND @DATE_END) )
			)
		AND	aph.MODIFY_FLAG IS NULL
		AND aph.DELETE_FLAG IS NULL
		ORDER BY
			v.VN_NAME, aph.AP_INV_DATE

	END ELSE BEGIN
		
		SELECT
			[AccountPayableID] = aph.AP_ID,
			[VendorCode] = aph.VN_FRL_EMP_CODE,
			[VendorAccountNumber]= v.VN_ACCT_NBR,
			[VendorName] = v.VN_NAME,
			[InvoiceDate] = aph.AP_INV_DATE,
			[InvoiceNumber] = aph.AP_INV_VCHR,
			[InvoiceTotal] = COALESCE(aph.AP_INV_AMT,0) + COALESCE(aph.AP_SHIPPING,0) + COALESCE(aph.AP_SALES_TAX,0),
			[JobComponent] = APJobs.JobComponent,
			[Department] = APJobs.Department,
			[BusinessUnit] = APJobs.BusinessUnit,
			[Product] = APJobs.Product,
			[AccountNumber] = APJobs.AccountNumber,
			[Total] = APJobs.JobRowTotal,
			[CurrencyCode] = v.CURRENCY_CODE,
			[ExportDate] = CASE WHEN @EXPORT_DATE IS NULL 
									AND (NULLIF(v.VN_ACCT_NBR,'') IS NOT NULL
									AND	NULLIF(APJobs.Department,'') IS NOT NULL
									AND	NULLIF(APJobs.BusinessUnit,'') IS NOT NULL
									AND	NULLIF(APJobs.Product,'') IS NOT NULL
									AND	NULLIF(APJobs.AccountNumber,'') IS NOT NULL
									) THEN CONVERT(varchar(10), getdate(), 101)
								ELSE (SELECT EXPORT_DATE FROM dbo.AP_EXPORTED WHERE AP_ID = aph.AP_ID) END,
			[Include] = CASE WHEN (NULLIF(v.VN_ACCT_NBR,'') IS NOT NULL
									AND	NULLIF(APJobs.Department,'') IS NOT NULL
									AND	NULLIF(APJobs.BusinessUnit,'') IS NOT NULL
									AND	NULLIF(APJobs.Product,'') IS NOT NULL
									AND	NULLIF(APJobs.AccountNumber,'') IS NOT NULL
									) THEN CAST(1 as bit) ELSE CAST(0 as bit) END
		FROM dbo.AP_HEADER aph
			INNER JOIN dbo.VENDOR v ON aph.VN_FRL_EMP_CODE = v.VN_CODE 
			INNER JOIN (SELECT
							AP_ID,
							[JobComponent] = RIGHT('000000'+CAST(app.JOB_NUMBER AS varchar(6)),6) + '-' + RIGHT('000'+CAST(app.JOB_COMPONENT_NBR AS varchar(2)),2),
							[JobRowTotal] = SUM(COALESCE(AP_PROD_EXT_AMT,0) + COALESCE(EXT_NONRESALE_TAX,0)),
							[Department] = CASE WHEN jl.UDV4_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu4.UDV_DESC ELSE jl.UDV4_CODE END,
							[BusinessUnit] = CASE WHEN jl.UDV2_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu2.UDV_DESC ELSE jl.UDV2_CODE END,
							[Product] = CASE WHEN jl.UDV3_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu3.UDV_DESC ELSE jl.UDV3_CODE END,
							[AccountNumber] = CASE WHEN jl.UDV1_CODE = RIGHT('000000'+CAST(jl.JOB_NUMBER AS varchar(6)),6) THEN jlu1.UDV_DESC ELSE jl.UDV1_CODE END
						FROM dbo.AP_PRODUCTION app
							INNER JOIN dbo.JOB_LOG jl ON app.JOB_NUMBER = jl.JOB_NUMBER
							LEFT OUTER JOIN dbo.JOB_LOG_UDV4 jlu4 ON jl.UDV4_CODE = jlu4.UDV_CODE 
							LEFT OUTER JOIN dbo.JOB_LOG_UDV2 jlu2 ON jl.UDV2_CODE = jlu2.UDV_CODE
							LEFT OUTER JOIN dbo.JOB_LOG_UDV3 jlu3 ON jl.UDV3_CODE = jlu3.UDV_CODE
							LEFT OUTER JOIN dbo.JOB_LOG_UDV1 jlu1 ON jl.UDV1_CODE = jlu1.UDV_CODE
						GROUP BY
								AP_ID,
								RIGHT('000000'+CAST(app.JOB_NUMBER AS varchar(6)),6) + '-' + RIGHT('000'+CAST(app.JOB_COMPONENT_NBR AS varchar(2)),2),
								jl.UDV4_CODE,
								jl.UDV2_CODE,
								jl.UDV3_CODE,
								jl.JOB_NUMBER,
								jlu4.UDV_DESC,
								jlu2.UDV_DESC,
								jlu3.UDV_DESC,
								jl.UDV1_CODE,
								jlu1.UDV_DESC
						) APJobs ON aph.AP_ID = APJobs.AP_ID
		WHERE
			(
				( @ENTRY_OR_INVOICE_OR_EXPORT_DATE = 0 AND aph.CREATE_DATE BETWEEN @DATE_START AND @DATE_END )
			OR
				( @ENTRY_OR_INVOICE_OR_EXPORT_DATE = 1 AND aph.AP_INV_DATE BETWEEN @DATE_START AND @DATE_END )
			)
		AND	aph.MODIFY_FLAG IS NULL
		AND aph.DELETE_FLAG IS NULL
		ORDER BY
			v.VN_NAME, aph.AP_INV_DATE

	END

END
GO


