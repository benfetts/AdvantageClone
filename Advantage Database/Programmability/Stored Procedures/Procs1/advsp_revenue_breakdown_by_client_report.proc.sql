CREATE PROCEDURE [dbo].[advsp_revenue_breakdown_by_client_report]
	@StartingPostPeriodCode varchar(6),
	@EndingPostPeriodCode varchar(6)
AS
BEGIN
	
	DECLARE @Records TABLE (
		[ID] INT IDENTITY(1,1),
		[ClientCode] varchar(6),
		[ServiceType] varchar(8),
		[ServiceTypeDescription] varchar(40),
		[Sales] decimal(14,2),
		[Revenue] decimal(14,2),
		[Billing] decimal(14,2),
		[MediaType] varchar(1)
	)

	INSERT INTO @Records
	SELECT 
		[ClientCode] = SJ.[ClientCode],
		[ServiceType] = COALESCE(DSC.[FormatCode], SJ.[SalesClassCode]),
		[ServiceTypeDescription] = CASE WHEN ISNULL(DSC.[FormatCode], '') = '' THEN SC.SC_DESCRIPTION ELSE SCF.FORMAT_DESC END,
		[Sales] = SJ.[Sales],
		[Revenue] = SJ.[GrossIncome],
		[Billing] = SJ.[TotalBillLessResaleTax],
		[MediaType] = ISNULL(SJ.[MediaType], 'P')
	FROM
		(SELECT
			[ClientCode] = ARS.CL_CODE,
			[SalesClassCode] = ARS.SC_CODE,
			[Sales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
						   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[GrossIncome] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN (ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))) - (ARS.COST_AMT + ARS.NET_CHARGE_AMT + ARS.NON_RESALE_AMT + ARS.AB_COST_AMT)
								 ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) - (ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0)) END,
			[TotalBillLessResaleTax] = ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0)),
			[MediaType] = ARS.MEDIA_TYPE
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND 
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
									  AR.AR_TYPE = ARS.AR_TYPE
		WHERE
			(ARS.AR_INV_SEQ = 99 OR ARS.AR_INV_SEQ = 0) AND
			(AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)

		UNION ALL
		
		SELECT
			[ClientCode] = AR.CL_CODE,			
			[SalesClassCode] = AR.SC_CODE,
			[Sales] = ISNULL(AR.AR_INV_AMOUNT, 0),
			[GrossIncome] = ISNULL(AR.AR_INV_AMOUNT, 0) - ISNULL(AR.AR_COS_AMT, 0),
			[TotalBillLessResaleTax] = ISNULL(AR.AR_INV_AMOUNT, 0) - (ISNULL(AR.AR_CITY_AMT, 0) + ISNULL(AR.AR_COUNTY_AMT, 0) + ISNULL(AR.AR_STATE_AMT, 0)),
			[MediaType] = 'P'						
		FROM
			[dbo].[ACCT_REC] AS AR INNER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = AR.SC_CODE
		WHERE
			AR.MANUAL_INV = 1 AND
			(AR.AR_INV_SEQ = 99 OR AR.AR_INV_SEQ = 0) AND
			(AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode) ) AS SJ LEFT OUTER JOIN
		[dbo].SALES_CLASS SC ON SJ.SalesClassCode = SC.SC_CODE LEFT OUTER JOIN
		(SELECT	
			[SalesClassCode] = SC_CODE,
			[FormatCode] = MIN(FORMAT_CODE)
		 FROM
			dbo.SC_FORMAT
		 WHERE
			ACTIVE = 1
		 GROUP BY
			SC_CODE) AS DSC ON SJ.SalesClassCode = DSC.SalesClassCode LEFT OUTER JOIN
		[dbo].[SC_FORMAT] SCF ON DSC.SalesClassCode = SCF.SC_CODE AND
								 DSC.FormatCode = SCF.FORMAT_CODE

	SELECT
		[ID] = NEWID(),
		[Category],
		[ClientCode],
		[ClientName],
		[MediaType],
		[ServiceType],
		[ServiceTypeDescription],
		[Amount] = SUM([Amount])
	FROM
		(SELECT
	 		[Category],
	 		[ClientCode],
	 		[ClientName] = C.CL_NAME,
	 		[ServiceType],
	 		[ServiceTypeDescription],
	 		[Amount],
			[MediaType]
		 FROM
	 		(SELECT
	  			[Category] = 'S',
	  			[ClientCode],
	  			[ServiceType],
	  			[ServiceTypeDescription],
	  			[Amount] = [Sales],
				[MediaType] = [MediaType]
	 		 FROM
	  			@Records 
	 		 WHERE
	  			[Sales] <> 0
	  
	 		 UNION ALL
	  
	 		 SELECT
	  			[Category] = 'R',
	  			[ClientCode],
	  			[ServiceType],
	  			[ServiceTypeDescription],
	  			[Amount] = [Revenue],
				[MediaType] = [MediaType]
	 		 FROM
	  			@Records 
	 		 WHERE
	  			[Revenue] <> 0
	  
	 		 UNION ALL
	  
	 		 SELECT
	  			[Category] = 'B',
	  			[ClientCode],
	  			[ServiceType],
	  			[ServiceTypeDescription],
	  			[Amount] = [Billing],
				[MediaType] = [MediaType]
	 		 FROM
	  			@Records 
	 		 WHERE
	  			[Billing] <> 0) Recs
		 LEFT OUTER JOIN
	 		dbo.CLIENT C ON Recs.ClientCode = C.CL_CODE) Dtls
	GROUP BY
		[Category],
		[ClientCode],
		[ClientName],
		[MediaType],
		[ServiceType],
		[ServiceTypeDescription]

END