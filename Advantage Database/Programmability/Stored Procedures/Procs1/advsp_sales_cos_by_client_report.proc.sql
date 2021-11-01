CREATE PROCEDURE [dbo].[advsp_sales_cos_by_client_report]
	@StartingPostPeriodCode varchar(6),
	@EndingPostPeriodCode varchar(6),
	@RecordSource int
AS
BEGIN

	DECLARE @Records TABLE (
		[ID] INT IDENTITY(1,1),
		[ClientCode] varchar(6),
		[Sales] decimal(14,2),
		[CostOfSales] decimal(14,2),
		[GlAccountSales] varchar(30),
		[GlAccountCostOfSales] varchar(30),
		[MediaType] varchar(1)
	)
	
	INSERT INTO @Records
	SELECT 
		[ClientCode] = SJ.[ClientCode],
		[Sales] = SJ.[Sales],
		[CostOfSales] = SJ.[CostOfSales],
		[GLAccountSales] = SJ.[GLAccountSales],
		[GLAccountCostOfSales] = SJ.[GLAccountCostOfSales],
		[MediaType] = ISNULL(SJ.[MediaType], 'P')
	FROM
		(SELECT
			[ClientCode] = ARS.CL_CODE,
			[PostPeriod] = AR.AR_POST_PERIOD,
			[Sales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0))
						   ELSE ISNULL(ARS.TOTAL_BILL, 0) - (ISNULL(ARS.CITY_TAX_AMT, 0) + ISNULL(ARS.CNTY_TAX_AMT, 0) + ISNULL(ARS.STATE_TAX_AMT, 0) + ISNULL(ARS.AB_INC_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_COMMISSION_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)) END,
			[CostOfSales] = CASE WHEN ARS.AB_REC_FLAG = 2 AND ISNULL(ARS.MEDIA_TYPE,'P') = 'P' THEN ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.AB_COST_AMT, 0) + ISNULL(ARS.AB_NONRESALE_AMT, 0)
								 ELSE ISNULL(ARS.COST_AMT, 0) + ISNULL(ARS.NET_CHARGE_AMT, 0) + ISNULL(ARS.NON_RESALE_AMT, 0) + ISNULL(ARS.DISCOUNT_AMT,0) END,
			[GLAccountSales] = ARS.GL_ACCT_SALE,
			[GLAccountCostOfSales] = ARS.GL_ACCT_COS,
			[MediaType] = ARS.MEDIA_TYPE					
		FROM
			[dbo].[AR_SUMMARY] AS ARS INNER JOIN
			[dbo].[ACCT_REC] AS AR ON AR.AR_INV_NBR = ARS.AR_INV_NBR AND
									  AR.AR_INV_SEQ = ARS.AR_INV_SEQ AND 
									  AR.AR_TYPE = ARS.AR_TYPE 
		WHERE
			(ARS.AR_INV_SEQ <> 99) AND
			(AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode)

		UNION ALL
		
		SELECT
			[ClientCode] = AR.CL_CODE,
			[PostPeriod] = AR.AR_POST_PERIOD,
			[Sales] = ISNULL(AR.AR_INV_AMOUNT, 0),
			[CostOfSales] = ISNULL(AR.AR_COS_AMT, 0),
			[GLAccountSales] = AR.GLACODE_SALES,
			[GLAccountCostOfSales] = AR.GLACODE_COS,
			[MediaType] = 'P'			
		FROM
			[dbo].[ACCT_REC] AS AR INNER JOIN
			[dbo].[CLIENT] AS C ON C.CL_CODE = AR.CL_CODE LEFT OUTER JOIN
			[dbo].[DIVISION] AS D ON D.CL_CODE = AR.CL_CODE AND
									 D.DIV_CODE = AR.DIV_CODE LEFT OUTER JOIN
			[dbo].[PRODUCT] AS P ON P.CL_CODE = AR.CL_CODE AND
									P.DIV_CODE = AR.DIV_CODE AND
									P.PRD_CODE = AR.PRD_CODE LEFT OUTER JOIN
			[dbo].[OFFICE] AS O ON O.OFFICE_CODE = AR.OFFICE_CODE LEFT OUTER JOIN
			[dbo].[SALES_CLASS] AS SC ON SC.SC_CODE = AR.SC_CODE LEFT OUTER JOIN
			[dbo].[POSTPERIOD] AS PP ON PP.PPPERIOD = AR.AR_POST_PERIOD LEFT OUTER JOIN
			[dbo].[V_AR_INVOICE_DUE_DATES] AS ARDD ON ARDD.AR_INV_NBR = AR.AR_INV_NBR
		WHERE
			AR.MANUAL_INV = 1 AND
			(AR.AR_INV_SEQ <> 99) AND
			(AR.AR_POST_PERIOD BETWEEN @StartingPostPeriodCode AND @EndingPostPeriodCode) ) AS SJ


	SELECT
		A.SalesOrCostOfSales,
		A.MediaType,
		A.ClientCode,
		A.ClientName,
		A.GLACode,
		A.MappedAccount,
		A.TargetAccount,
		A.Amount,
		[AbsoluteAmount] = A.[Amount] * CASE WHEN A.[Amount] < 0 THEN -1 ELSE 1 END,
		[DebitOrCredit] = CASE 
							WHEN A.[SalesOrCostOfSales] = 'S' AND A.[Amount] < 0 THEN 'Debit' 
							WHEN A.[SalesOrCostOfSales] = 'S' AND A.[Amount] >= 0 THEN 'Credit'
							WHEN A.[SalesOrCostOfSales] = 'P' AND A.[Amount] < 0 THEN 'Credit' 
							WHEN A.[SalesOrCostOfSales] = 'P' AND A.[Amount] >= 0 THEN 'Debit'		
							ELSE '' 
						END
	FROM
		(SELECT
			[ID] = MIN([ID]),
			S.SalesOrCostOfSales,
			S.MediaType,
			S.ClientCode,
			S.ClientName,
			S.GLACode,
			S.MappedAccount,
			S.TargetAccount,
			[Amount] = SUM(S.Amount)
		FROM
			(SELECT
				[ID],
				[SalesOrCostOfSales],
				[MediaType],
				[ClientCode],
				[ClientName] = C.CL_NAME,
				[GLACode],
				[MappedAccount] = GLAX.MappedAccount,
				[TargetAccount] = GLAEX.TargetAccount,
				[Amount]
			FROM
				(SELECT
					[ID] = [ID],
					[SalesOrCostOfSales] = 'S',
					[ClientCode],
					[Amount] = [Sales],
					[GLACode] = [GlAccountSales],
					[MediaType] = [MediaType]
				 FROM
	 				@Records
				 WHERE
	 				Sales <> 0
				 UNION ALL
				 SELECT
					[ID] = [ID],
	 				[SalesOrCostOfSales] = 'P',
	 				[ClientCode],
	 				[Amount] = [CostOfSales],
	 				[GLACode] = [GlAccountCostOfSales],
					[MediaType] = [MediaType]
				 FROM
	 				@Records
				 WHERE
	 				CostOfSales <> 0) Recs
			LEFT OUTER JOIN
				dbo.CLIENT C ON Recs.ClientCode = C.CL_CODE
			LEFT OUTER JOIN
				(SELECT 
					GLACODE,
					[MappedAccount] = SOURCE_GLACODE
				 FROM 
					[dbo].[GLACCOUNT_XREF] 
				 WHERE
					GLACCOUNT_XREF_ID IN (SELECT MAX(GLACCOUNT_XREF_ID) FROM [dbo].[GLACCOUNT_XREF] WHERE RECORD_SOURCE_ID = @RecordSource GROUP BY GLACODE)) AS GLAX ON Recs.GLACode = GLAX.GLACODE
			LEFT OUTER JOIN
				(SELECT 
					DTL.GLACODE,
					[TargetAccount] = HDR.TARGET_GLACODE
				 FROM 
					[dbo].[GLACCOUNT_XREF_EXPORT] HDR
				 INNER JOIN	
					[dbo].[GLACCOUNT_XREF_EXPORT_DETAIL] DTL ON HDR.GLACCOUNT_XREF_EXPORT_ID = DTL.GLACCOUNT_XREF_EXPORT_ID  
				 WHERE
					RECORD_SOURCE_ID = @RecordSource) AS GLAEX ON Recs.GLACode = GLAEX.GLACODE) S
			GROUP BY
				S.SalesOrCostOfSales,
				S.MediaType,
				S.ClientCode,
				S.ClientName,
				S.GLACode,
				S.MappedAccount,
				S.TargetAccount) A
			WHERE 
				A.Amount <> 0
			ORDER BY
				A.ID,
				A.SalesOrCostOfSales

END