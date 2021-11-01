
CREATE PROCEDURE [dbo].[advsp_update_W_INVOICE_PRINT] @bill_user_in varchar(100), @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @print_date smalldatetime
DECLARE @rowcount integer

SELECT @ret_val = 0
SELECT @print_date = GETDATE( )

INSERT INTO dbo.W_INVOICE_PRINT ( PRINT_USER, AR_INV_NBR, CL_CODE, AR_INV_DATE, PRINT_DATE )
	 SELECT DISTINCT b.BILLING_USER, ar.AR_INV_NBR, ar.CL_CODE, b.INV_DATE, @print_date
	   FROM dbo.BILLING b, ACCT_REC ar
	  WHERE b.BILLING_USER = @bill_user_in
	    AND ar.AR_INV_NBR BETWEEN b.FIRST_INV AND b.LAST_INV
	    AND ar.AR_TYPE = 'IN'
	    AND ar.AR_INV_SEQ <> 99

SET @rowcount = @@ROWCOUNT	    

IF ( @@ERROR = 0 )
BEGIN
	IF ( @rowcount > 0 )
		UPDATE dbo.BILLING SET INV_PRINT = 1 WHERE BILLING_USER = @bill_user_in
	ELSE
		SELECT @ret_val = -2
END				
ELSE
	SELECT @ret_val = -1 
