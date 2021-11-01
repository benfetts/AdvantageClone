
CREATE FUNCTION [dbo].[advfn_invoice_post_period] ( @invoice_nbr int, @ar_type varchar(2) )
RETURNS varchar(6)
AS
BEGIN
	DECLARE @invoice_post_period varchar(6)

SET @invoice_post_period =	
	(SELECT DISTINCT a.AR_POST_PERIOD
	FROM dbo.ACCT_REC a
	WHERE a.AR_INV_NBR = @invoice_nbr AND a.AR_TYPE = @ar_type)
	
	RETURN @invoice_post_period
END
