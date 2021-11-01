CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_standardinvoicebillinghistory] 
	@InvoiceNumber AS int,
	@JobNumber AS int,
	@ComponentNumber AS smallint,
	@IsDraft AS bit
AS
BEGIN
		
	IF @IsDraft = 1 BEGIN
			
		SELECT 
			[InvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
			[InvoiceDate] = ARID.AR_INV_DATE,
			[Amount] = SUM(ARS.TOTAL_BILL)
		FROM 
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
			(SELECT 
					AR.AR_INV_NBR, 
					AR.AR_TYPE, 
					[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
				FROM 
					[dbo].[ACCT_REC] AS AR
				WHERE 
					AR.AR_TYPE <> 'VO'
				GROUP BY 
					AR.AR_INV_NBR, 
					AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
										   ARID.AR_TYPE = ARS.AR_TYPE
		WHERE 
			ARS.AR_INV_NBR NOT IN (SELECT DISTINCT AR_INV_NBR FROM dbo.AR_SUMMARY WHERE AR_TYPE = 'VO') AND 
			ARS.JOB_NUMBER = @JobNumber AND
			1 = CASE WHEN @ComponentNumber = 0 THEN 1 ELSE CASE WHEN ARS.JOB_COMPONENT_NBR = @ComponentNumber THEN 1 ELSE 0 END END
		GROUP BY
			ARS.AR_INV_NBR,
			ARS.AR_INV_SEQ,
			ARID.AR_INV_DATE
		HAVING 
			SUM(ARS.TOTAL_BILL) <> 0

	END ELSE BEGIN
		
		SELECT 
			[InvoiceNumber] = RIGHT('000000' + CAST(ARS.AR_INV_NBR AS varchar(6)), 6) + '-' + RIGHT('000' + CAST(ARS.AR_INV_SEQ AS varchar(4)), 4),
			[InvoiceDate] = ARID.AR_INV_DATE,
			[Amount] = SUM(ARS.TOTAL_BILL)
		FROM 
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN 
			(SELECT 
					AR.AR_INV_NBR, 
					AR.AR_TYPE, 
					[AR_INV_DATE] = MAX(AR.AR_INV_DATE) 
				FROM 
					[dbo].[ACCT_REC] AS AR
				WHERE 
					AR.AR_TYPE <> 'VO'
				GROUP BY 
					AR.AR_INV_NBR, 
					AR.AR_TYPE) AS ARID ON ARID.AR_INV_NBR = ARS.AR_INV_NBR AND 
										   ARID.AR_TYPE = ARS.AR_TYPE
		WHERE 
			ARS.AR_INV_NBR < @InvoiceNumber AND 
			ARS.AR_INV_NBR NOT IN (SELECT DISTINCT AR_INV_NBR FROM dbo.AR_SUMMARY WHERE AR_INV_NBR < @InvoiceNumber AND AR_TYPE = 'VO') AND 
			ARS.AR_INV_SEQ <> 99 AND
			ARS.JOB_NUMBER = @JobNumber AND
			1 = CASE WHEN @ComponentNumber = 0 THEN 1 ELSE CASE WHEN ARS.JOB_COMPONENT_NBR = @ComponentNumber THEN 1 ELSE 0 END END
		GROUP BY
			ARS.AR_INV_NBR,
			ARS.AR_INV_SEQ,
			ARID.AR_INV_DATE
		HAVING 
			SUM(ARS.TOTAL_BILL) <> 0
		
	END

END




GO