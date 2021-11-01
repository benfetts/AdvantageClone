if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_job_detail_adv_recon_hist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[advsp_job_detail_adv_recon_hist]
GO

CREATE PROCEDURE [dbo].[advsp_job_detail_adv_recon_hist]
AS
BEGIN

CREATE TABLE #INVOICE
	(
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[InvoiceNumber] int,
		[InvoiceSeq] int,
		[BillingPeriod] varchar(6),
		[BilledToDate] decimal(18,2),
		[ReconciledToDate] decimal(18,2),
		[RecognizedToDate] decimal(18,2),
		[AdvanceResaleTax] decimal(18,2),
		[NonResaleTax] decimal(18,2),
		[FinalRecAdj] decimal(18,2),
		[Balance] decimal(18,2),
		[JobNumber] int,
		[JobComponentNumber] smallint
	);	


	SET NOCOUNT ON;
	
	INSERT INTO #INVOICE
	SELECT AR.AR_INV_NBR, AR.AR_INV_SEQ, ISNULL(A.AR_POST_PERIOD,'') AS BillingPeriod, (SUM(ISNULL(AR.EMP_TIME_AMT,0)) + SUM(ISNULL(AR.INC_ONLY_AMT,0)) + SUM(ISNULL(AR.COMMISSION_AMT,0)) + SUM(ISNULL(AR.COST_AMT,0))
				 + SUM(ISNULL(AR.AB_SALE_AMT,0)) + SUM(ISNULL(AR.AB_COST_AMT,0)) + SUM(ISNULL(AR.AB_INC_AMT,0)) + SUM(ISNULL(AR.AB_COMMISSION_AMT,0))) AS BilledToDate, 0,0,
		 CASE WHEN (SUM(ISNULL(AR.AB_COST_AMT,0)) + SUM(ISNULL(AR.AB_INC_AMT,0)) + SUM(ISNULL(AR.AB_COMMISSION_AMT,0))) > 0 THEN ISNULL(SUM(AR.[CITY_TAX_AMT] + AR.[CNTY_TAX_AMT] + AR.[STATE_TAX_AMT]),0) ELSE 0 END AS AdvanceResaleTax,	  
		 SUM(ISNULL(AR.AB_NONRESALE_AMT,0)),
		 0,0,AR.JOB_NUMBER AS JobNumber, AR.JOB_COMPONENT_NBR AS JobComponentNumber
	FROM  AR_SUMMARY AS AR INNER JOIN
		  ACCT_REC A ON A.AR_INV_NBR = AR.AR_INV_NBR AND A.AR_INV_SEQ = AR.AR_INV_SEQ AND 
		  A.AR_TYPE = AR.AR_TYPE
	WHERE AR.JOB_NUMBER	IS NOT NULL
	GROUP BY AR.AR_INV_NBR, AR.AR_INV_SEQ, A.AR_POST_PERIOD, AR.JOB_NUMBER, AR.JOB_COMPONENT_NBR 

	UPDATE #INVOICE
	SET [ReconciledToDate] = (SELECT ISNULL(SUM(LINE_TOTAL) * -1,0) FROM ADVANCE_BILLING AB WHERE AB_FLAG IN (3,4,6) AND AB.AR_INV_NBR = #INVOICE.InvoiceNumber AND AB.AR_INV_SEQ = #INVOICE.InvoiceSeq)

	UPDATE #INVOICE
	SET [RecognizedToDate] = (SELECT ISNULL(SUM(REC_AMT),0) FROM INCOME_REC IR WHERE IR.AR_INV_NBR = #INVOICE.InvoiceNumber AND IR.AR_INV_SEQ = #INVOICE.InvoiceSeq)

	UPDATE #INVOICE
	SET [FinalRecAdj] = (SELECT ISNULL(SUM(LINE_TOTAL),0) FROM ADVANCE_BILLING AB WHERE AB_FLAG = 5 AND AB.AR_INV_NBR = #INVOICE.InvoiceNumber AND AB.AR_INV_SEQ = #INVOICE.InvoiceSeq)

	UPDATE #INVOICE
	SET [Balance] = (SELECT ISNULL(SUM(LINE_TOTAL) - (SUM(EXT_STATE_RESALE) + SUM(EXT_COUNTY_RESALE) + SUM(EXT_CITY_RESALE)),0) FROM ADVANCE_BILLING AB WHERE AB_FLAG <> 5 AND AB.AR_INV_NBR = #INVOICE.InvoiceNumber AND AB.AR_INV_SEQ = #INVOICE.InvoiceSeq AND AB.JOB_NUMBER = #INVOICE.JobNumber AND AB.JOB_COMPONENT_NBR = #INVOICE.JobComponentNumber)

	SELECT [BillingPeriod],
		[BilledToDate] + [AdvanceResaleTax] + [NonResaleTax] AS [BilledToDate],
		[ReconciledToDate],
		[RecognizedToDate],
		[Balance],
		[AdvanceResaleTax],
		[FinalRecAdj],
		[JobNumber],
		[JobComponentNumber]
	 FROM #INVOICE
	 ORDER BY [BillingPeriod]

	--SUM(ISNULL(AR.EMP_TIME_AMT,0)) + SUM(ISNULL(AR.INC_ONLY_AMT,0)) + SUM(ISNULL(AR.COMMISSION_AMT,0)) + SUM(ISNULL(AR.COST_AMT,0)) + SUM(ISNULL(AR.NON_RESALE_AMT,0)) AS ReconciledToDate,
	--	 SUM(ISNULL(AR.EMP_TIME_AMT,0)) + SUM(ISNULL(AR.INC_ONLY_AMT,0)) + SUM(ISNULL(AR.COMMISSION_AMT,0)) + SUM(ISNULL(AR.AB_SALE_AMT,0)) AS RecognizedToDate,
	--	 (SUM(ISNULL(AR.TOTAL_BILL,0))) - 
	--	 (SUM(ISNULL(AR.EMP_TIME_AMT,0)) + SUM(ISNULL(AR.INC_ONLY_AMT,0)) + SUM(ISNULL(AR.COMMISSION_AMT,0)) + SUM(ISNULL(AR.COST_AMT,0)) + SUM(ISNULL(AR.NON_RESALE_AMT,0)) + SUM(ISNULL(AR.AB_SALE_AMT,0))) AS Balance,
	--	 CASE WHEN (SUM(ISNULL(AR.AB_COST_AMT,0)) + SUM(ISNULL(AR.AB_INC_AMT,0)) + SUM(ISNULL(AR.AB_COMMISSION_AMT,0))) > 0 THEN ISNULL(SUM(AR.[CITY_TAX_AMT] + AR.[CNTY_TAX_AMT] + AR.[STATE_TAX_AMT]),0) ELSE 0 END AS AdvanceResaleTax,		 
	--	 SUM(ISNULL(AR.AB_SALE_AMT,0)) AS FinalRecAdj,

	--DECLARE @ROW_ID AS INT,
	--		@ROW_ID_CHECK AS INT,
	--		@CURR_AR_INV_NBR AS INTEGER,
	--		@CURR_AR_INV_NBR_CHECK AS INTEGER,
	--		@CURR_CHECK AS VARCHAR(50),
	--		@CURR_CHECK_DATE AS SMALLDATETIME,
	--		@CURR_JOB AS INT,
	--		@CURR_COMP AS SMALLINT

	--DECLARE MY_ROWS                         CURSOR  
 --       FOR
	--        SELECT ID,[InvoiceNumber],[JobNumber],[JobComponentNumber]
	--        FROM   #INVOICE			
 --       ;
 --       OPEN MY_ROWS;
 --       FETCH NEXT FROM MY_ROWS INTO @ROW_ID,@CURR_AR_INV_NBR,@CURR_JOB,@CURR_COMP;
 --       WHILE @@FETCH_STATUS = 0
 --       BEGIN

	--		UPDATE #INVOICE
	--		SET [ReconciledToDate] = (SELECT SUM(LINE_TOTAL)
	--		FROM ADVANCE_BILLING
	--		WHERE AB_FLAG NOT IN (1,2,5) AND AR_INV_NBR = @CURR_AR_INV_NBR
	--		GROUP BY AR_INV_NBR)
	--		WHERE [ID] = @ROW_ID	

	--		UPDATE #INVOICE
	--		SET [FinalRecAdj] = (SELECT SUM(LINE_TOTAL)
	--		FROM ADVANCE_BILLING
	--		WHERE AB_FLAG = 5 AND AR_INV_NBR = @CURR_AR_INV_NBR
	--		GROUP BY AR_INV_NBR)
	--		WHERE [ID] = @ROW_ID	

						
	--        --GO TO NEXT EVENT
	--        FETCH NEXT FROM MY_ROWS INTO @ROW_ID,@CURR_AR_INV_NBR,@CURR_JOB,@CURR_COMP;
 --       END
 --       CLOSE MY_ROWS;
 --       DEALLOCATE MY_ROWS;

	--	UPDATE #INVOICE
	--	SET [ReconciledToDate] = 0.00
	--	WHERE [ReconciledToDate] IS NULL

	--	UPDATE #INVOICE
	--	SET [FinalRecAdj] = 0.00
	--	WHERE [FinalRecAdj] IS NULL

		--SELECT [BillingPeriod],
		--[BilledToDate],
		--[ReconciledToDate],
		--[RecognizedToDate],
		--[Balance],
		--[AdvanceResaleTax],
		--[FinalRecAdj],
		--[JobNumber],
		--[JobComponentNumber]
		-- FROM #INVOICE

END	
