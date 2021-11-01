
CREATE PROCEDURE [dbo].[advsp_ar_billing_comments] @ar_inv_list varchar(4000)  
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		bc.AR_INV_NBR,
		bc.AR_INV_SEQ,
		bc.BILL_COMMENT
	FROM dbo.BILL_COMMENT AS bc
	JOIN fn_intlist_to_table(@ar_inv_list) i 
		ON bc.AR_INV_NBR = i.number
	WHERE bc.BC_ID = (SELECT MAX(bc2.BC_ID) FROM dbo.BILL_COMMENT AS bc2 WHERE bc.AR_INV_NBR = bc2.AR_INV_NBR
		AND bc.AR_INV_SEQ = bc2.AR_INV_SEQ) 
END
