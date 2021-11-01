IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_ar_invoice_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_ar_invoice_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_ar_invoice_get_api] 
	@job_number					int,			/* If Null then get all */
	@job_component_nbr		int,	/* If Null then get all */
	@ar_inv_nbr					int,			/* If Null then get all */
	@ar_inv_seq					int,	/* If Null then get all */

	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

--PJH 09/07/21 - Added Manual invoices  #01

IF @job_number = 0 SET @job_number = NULL
IF @job_component_nbr = 0 SET @job_component_nbr = NULL
IF @ar_inv_nbr = 0 SET @ar_inv_nbr = NULL
IF @ar_inv_seq = 0 SET @ar_inv_seq = NULL

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

DECLARE
	@DEBUG int

DECLARE
	@found int = 0

BEGIN TRY

SET NOCOUNT ON

SET @ret_val = 0
SET @ret_val_s = 'Success...'

DECLARE @ar_detail TABLE (
	JOB_NUMBER							int,
	JOB_COMPONENT_NBR			smallint,
	AR_INV_NBR							int NOT NULL,
	AR_INV_SEQ							smallint NOT NULL,
	SALE_POST_PERIOD				varchar(6),
	AR_INV_DATE						smalldatetime,
	DUE_DATE								smalldatetime,
	PAY_DAYS								int,
	JC_INV_AMOUNT					decimal(15,2),
	AR_INV_AMOUNT					decimal(15,2),
	UNIQUE (AR_INV_NBR, AR_INV_SEQ, JOB_NUMBER, JOB_COMPONENT_NBR) 
	)

DECLARE @cr_detail TABLE (
	AR_INV_NBR							int NOT NULL,
	AR_INV_SEQ							smallint NOT NULL,
	CR_PAY_AMT_TOT					decimal(15,2),
	CR_CHECK_DATE_LAST			smalldatetime,
	CR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS
	UNIQUE (AR_INV_NBR, AR_INV_SEQ) 
	)

DECLARE @ar_cr_detail TABLE (
	JOB_NUMBER							int,
	JOB_COMPONENT_NBR			smallint,
	AR_INV_NBR							int NOT NULL,
	AR_INV_SEQ							smallint NOT NULL,
	AR_INV_DATE						smalldatetime,
	DUE_DATE								smalldatetime,
	PAY_DAYS								int,
	JC_INV_AMOUNT					decimal(15,2),
	AR_INV_AMOUNT					decimal(15,2),
	CR_TOT_AMT							decimal(15,2),	/* CR_PAY_AMT + CR_ADJ_AMT */
	CR_CHECK_DATE_LAST			smalldatetime,
	INV_BALANCE						decimal(15,2),
	DAYS_TO_PAY						int,
	PENDING_CR							bit,
	SALE_POST_PERIOD				varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS,
	CR_POST_PERIOD					varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS
	UNIQUE (AR_INV_NBR, AR_INV_SEQ, JOB_NUMBER, JOB_COMPONENT_NBR) 
	)

INSERT INTO @ar_detail 
SELECT * FROM (
	SELECT A.JOB_NUMBER, 
		A.JOB_COMPONENT_NBR, 
		A.AR_INV_NBR, 
		A.AR_INV_SEQ, 
		MAX(A.SALE_POST_PERIOD) PP, 
		B.AR_INV_DATE, 
			CASE 
				WHEN B.DUE_DATE IS NOT NULL THEN B.DUE_DATE 
				WHEN MAX(B.REC_TYPE) IN('P','S') AND B.DUE_DATE IS NULL THEN B.AR_INV_DATE + ISNULL(MAX(C.CL_P_PAYDAYS),0)
				ELSE B.AR_INV_DATE + ISNULL(MAX(C.CL_M_PAYDAYS),0)
			END AS AR_INV_DATE_DUE,
			--B.DUE_DATE, 
			CASE 
				WHEN B.DUE_DATE IS NOT NULL THEN -1
				WHEN MAX(B.REC_TYPE) IN('P','S') THEN ISNULL(MAX(C.CL_P_PAYDAYS),0)
				ELSE ISNULL(MAX(C.CL_M_PAYDAYS),0)
			END AS PAY_DAYS,
		SUM(A.TOTAL_BILL) 
		JC_INV_AMOUNT, 
		MAX(B.AR_INV_AMOUNT) AR_INV_AMOUNT
	FROM AR_SUMMARY A 
		JOIN ACCT_REC B ON A.AR_INV_NBR = B.AR_INV_NBR AND A.AR_INV_SEQ = B.AR_INV_SEQ
		LEFT JOIN dbo.CLIENT AS C ON B.CL_CODE = C.CL_CODE
	WHERE B.VOID_FLAG IS NULL AND ISNULL(B.MANUAL_INV,0) = 0
		AND (A.JOB_NUMBER = @job_number OR @job_number IS NULL) 
		AND (A.JOB_COMPONENT_NBR = @job_component_nbr OR @job_component_nbr IS NULL) 
		AND (A.AR_INV_NBR = @ar_inv_nbr OR @ar_inv_nbr IS NULL) 
		AND (A.AR_INV_SEQ = @ar_inv_seq OR @ar_inv_seq IS NULL) 
	GROUP BY A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.AR_INV_NBR, A.AR_INV_SEQ, B.AR_INV_DATE, B.DUE_DATE
) A WHERE A.AR_INV_SEQ <> 99
ORDER BY A.AR_INV_NBR, A.AR_INV_SEQ
OPTION (RECOMPILE)

--#01
INSERT INTO @ar_detail 
SELECT * FROM (
	SELECT A.JOB_NUMBER, 
		A.JOB_COMPONENT_NBR, 
		A.AR_INV_NBR, 
		A.AR_INV_SEQ, 
		MAX(A.AR_POST_PERIOD) PP, 
		B.AR_INV_DATE, 
			CASE 
				WHEN B.DUE_DATE IS NOT NULL THEN B.DUE_DATE 
				WHEN MAX(B.REC_TYPE) IN('P','S') AND B.DUE_DATE IS NULL THEN B.AR_INV_DATE + ISNULL(MAX(C.CL_P_PAYDAYS),0)
				ELSE B.AR_INV_DATE + ISNULL(MAX(C.CL_M_PAYDAYS),0)
			END AS AR_INV_DATE_DUE,
			--B.DUE_DATE, 
			CASE 
				WHEN B.DUE_DATE IS NOT NULL THEN -1
				WHEN MAX(B.REC_TYPE) IN('P','S') THEN ISNULL(MAX(C.CL_P_PAYDAYS),0)
				ELSE ISNULL(MAX(C.CL_M_PAYDAYS),0)
			END AS PAY_DAYS,
		SUM(A.AR_INV_AMOUNT) 
		JC_INV_AMOUNT, 
		MAX(B.AR_INV_AMOUNT) AR_INV_AMOUNT
	FROM ACCT_REC A 
		JOIN ACCT_REC B ON A.AR_INV_NBR = B.AR_INV_NBR AND A.AR_INV_SEQ = B.AR_INV_SEQ
		LEFT JOIN dbo.CLIENT AS C ON B.CL_CODE = C.CL_CODE
	WHERE A.VOID_FLAG IS NULL AND A.MANUAL_INV = 1
		AND (A.JOB_NUMBER = @job_number OR @job_number IS NULL) 
		AND (A.JOB_COMPONENT_NBR = @job_component_nbr OR @job_component_nbr IS NULL) 
		AND (A.AR_INV_NBR = @ar_inv_nbr OR @ar_inv_nbr IS NULL) 
		AND (A.AR_INV_SEQ = @ar_inv_seq OR @ar_inv_seq IS NULL) 
	GROUP BY A.JOB_NUMBER, A.JOB_COMPONENT_NBR, A.AR_INV_NBR, A.AR_INV_SEQ, B.AR_INV_DATE, B.DUE_DATE
) A WHERE A.AR_INV_SEQ <> 99
ORDER BY A.AR_INV_NBR, A.AR_INV_SEQ
OPTION (RECOMPILE)

--SELECT * FROM @ar_detail

INSERT INTO @cr_detail
	SELECT A.AR_INV_NBR, A.AR_INV_SEQ, SUM(CR_TOT_AMT) CR_PAY_AMT_TOT, MAX(CR_CHECK_DATE) CR_CHECK_DATE_LAST, MAX(POST_PERIOD) MAX_POST_PERIOD FROM (
	SELECT A.AR_INV_NBR, A.AR_INV_SEQ, COALESCE(CR_PAY_AMT,0) + COALESCE(CR_ADJ_AMT, 0) CR_TOT_AMT, B.CR_CHECK_DATE, A.POST_PERIOD
	FROM CR_CLIENT_DTL A 
	JOIN CR_CLIENT B ON A.REC_ID = B.REC_ID AND A.SEQ_NBR = B.SEQ_NBR
	) A 
	GROUP BY A.AR_INV_NBR, A.AR_INV_SEQ
OPTION (RECOMPILE)

--SELECT * FROM @cr_detail A
--ORDER BY A.AR_INV_NBR, A.AR_INV_SEQ

INSERT INTO @ar_cr_detail
SELECT 	JOB_NUMBER,
	JOB_COMPONENT_NBR,
	A.AR_INV_NBR,	A.AR_INV_SEQ,
	AR_INV_DATE,	DUE_DATE,
	PAY_DAYS,
	JC_INV_AMOUNT,	AR_INV_AMOUNT,
	B.CR_PAY_AMT_TOT, B.CR_CHECK_DATE_LAST, 0 INV_BALANCE, 0, 0, A.SALE_POST_PERIOD, B.CR_POST_PERIOD
	FROM @ar_detail A LEFT JOIN @cr_detail B ON A.AR_INV_NBR = B.AR_INV_NBR AND A.AR_INV_SEQ = B.AR_INV_SEQ
OPTION (RECOMPILE)

SET @found = @@ROWCOUNT

IF @found = 0 BEGIN
	SET @error_msg_w = 'No matching records...'
	GOTO ERROR_MSG
END

UPDATE @ar_cr_detail
SET CR_TOT_AMT = COALESCE(CR_TOT_AMT, 0)
OPTION (RECOMPILE)

UPDATE @ar_cr_detail 
SET INV_BALANCE = AR_INV_AMOUNT - CR_TOT_AMT
OPTION (RECOMPILE)

UPDATE @ar_cr_detail 
SET DAYS_TO_PAY = DATEDIFF(dd, AR_INV_DATE, COALESCE(CR_CHECK_DATE_LAST, GETDATE()))
OPTION (RECOMPILE)

UPDATE @ar_cr_detail 
SET PENDING_CR = CASE WHEN CR_CHECK_DATE_LAST IS NULL THEN 1 ELSE 0 END
OPTION (RECOMPILE)

/*
Days to Pay - Show the Days to Pay being used to calculate the Due Date that you added that is in the client maintenance. 
Media and Production do have different days.

PayDays - Calculate the invoice date compared to the last CR date to calc the number of days it took to pay the invoice.
*/

/* PJH 04/13/18 - Change labels from PAY_DAYS & DAYS_TO_PAY */
SELECT 
	JOB_NUMBER JobNumber, 
	JOB_COMPONENT_NBR JobComponentNumber, 
	AR_INV_NBR InvoiceNumber, 
	AR_INV_SEQ InvoiceSequence, 
	AR_INV_DATE InvoiceDate, 
	DUE_DATE DueDate, 
	PAY_DAYS DaysToPay, 
	JC_INV_AMOUNT JobComponentInvoiceAmount, 
	AR_INV_AMOUNT InvoiceAmount,
	CR_TOT_AMT CashReceiptAmount, 
	CR_CHECK_DATE_LAST LastCashReceiptDate,
	INV_BALANCE InvoiceBalance,
	DAYS_TO_PAY PayDays,
	PENDING_CR PendingCashReceipts,
	SALE_POST_PERIOD SalePostPeriod,
	CR_POST_PERIOD CashReceiptPostPeriod
FROM @ar_cr_detail
WHERE AR_INV_AMOUNT <> 0
OPTION (RECOMPILE)

GOTO ENDIT
  
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();

	IF @ErMessage IS NOT NULL BEGIN
		SET @ret_val = 1
		SET @ret_val_s = @ErMessage
	END

	/* PJH 04/13/18 - Change labels fro PAY_DAYS & DAYS_TO_PAY */
	SELECT 
	0 JobNumber, 
	0 JobComponentNumber, 
	0 InvoiceNumber, 
	0 InvoiceSequence, 
	NULL InvoiceDate, 
	NULL DueDate, 
	0 DaysToPay, 
	0 JobComponentInvoiceAmount, 
	0 InvoiceAmount,
	0 CashReceiptAmount, 
	NULL LastCashReceiptDate,
	0 InvoiceBalance,
	0 PayDays,
	0 PendingCashReceipts,
	NULL SalePostPeriod,
	@ErMessage CashReceiptPostPeriod

END CATCH

GO

GRANT EXECUTE ON [advsp_ar_invoice_get_api] TO PUBLIC AS dbo
GO