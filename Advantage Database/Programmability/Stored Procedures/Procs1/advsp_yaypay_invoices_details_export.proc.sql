IF EXISTS (select * from dbo.sysobjects where id = object_id(N'[dbo].[advsp_yaypay_invoices_details_export]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[advsp_yaypay_invoices_details_export]
GO

CREATE PROCEDURE [dbo].[advsp_yaypay_invoices_details_export] 
( @StartDate AS smalldatetime,
  @EndDate AS smalldatetime)
AS
--Stored procedure to export invoice data

BEGIN

	SELECT
		[itemId] = CAST(AR.AR_SUMMARY_ID AS varchar(12)),
		[invoiceId] = CAST(AR.AR_INV_NBR AS varchar(12)),
		[name] = CASE WHEN AR.FNC_CODE IS NOT NULL THEN FNC_DESCRIPTION
					  WHEN CAST(AR.ORDER_NBR AS varchar(MAX)) IS NOT NULL THEN CAST(AR.ORDER_NBR AS varchar(MAX))
					  ELSE '' END,
		[description] = '',
		[rate] = CAST(0 AS decimal),
		[quantity] = ISNULL(AR.HRS_QTY, 0),
		[amount] = ISNULL(AR.TOTAL_BILL, 0)
	FROM AR_SUMMARY AR LEFT OUTER JOIN
		 FUNCTIONS F ON F.FNC_CODE = AR.FNC_CODE LEFT OUTER JOIN
	     ACCT_REC ON ACCT_REC.AR_INV_NBR = AR.AR_INV_NBR AND ACCT_REC.AR_INV_SEQ = AR.AR_INV_SEQ 
	WHERE 1 = CASE WHEN ACCT_REC.VOID_DATE IS NOT NULL AND ACCT_REC.VOID_DATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 
		         WHEN ACCT_REC.CREATE_DATE BETWEEN @StartDate AND CONVERT(DATETIME, @EndDate +' 23:59:00', 101) THEN 1 ELSE 0 END AND ACCT_REC.AR_INV_SEQ <> 99 

END
GO

GRANT ALL ON [advsp_yaypay_invoices_details_export] TO PUBLIC AS dbo
GO