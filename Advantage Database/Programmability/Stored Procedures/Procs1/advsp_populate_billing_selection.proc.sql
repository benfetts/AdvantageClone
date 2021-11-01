
CREATE PROCEDURE [dbo].[advsp_populate_billing_selection]
	@bill_user_in varchar(100),	@ret_val integer OUTPUT 
AS

SET NOCOUNT ON

 SELECT SELECTION, ADJUSTMENTS, INV_ASSIGN, INV_PRINT, 
		CONVERT( varchar(10), INV_DATE, 101 ), POST_PERIOD, SELECT_BY, 
		PRODUCTION, CONVERT( varchar(10), P_EMPTIME_DATE, 101 ), 
		P_CUTOFF_PP, CONVERT( varchar(10), P_INCOMEONLY_DATE, 101 ), 
		CONVERT( varchar(10), P_ADVBILL_DATE, 101 ), BCC_FLAG 
   FROM dbo.BILLING 
  WHERE BILLING_USER = @bill_user_in
