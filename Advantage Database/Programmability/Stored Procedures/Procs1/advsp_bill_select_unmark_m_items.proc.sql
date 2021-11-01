CREATE PROCEDURE [dbo].[advsp_bill_select_unmark_m_items] 
	@billing_user varchar(100),	@order_number_in integer, @line_number_in smallint, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

DECLARE @inv_assign smallint

SELECT @ret_val = 0

SELECT @inv_assign = INV_ASSIGN 
FROM dbo.BILLING 
WHERE BILLING_USER = @billing_user

IF ( @inv_assign = 1 )
	SELECT @ret_val = -3

IF ( @ret_val = 0 )
BEGIN
	
	-- Radio	*********************************************************************************************************************************************
	UPDATE dbo.RADIO_DETAIL1 SET BILLING_USER = NULL, BILL_MONTHS = NULL
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in
	AND LINE_NBR = @line_number_in

	UPDATE dbo.RADIO_DETAIL SET BILLING_USER = NULL 
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in
	AND LINE_NBR = @line_number_in 

	-- TV		*********************************************************************************************************************************************
	UPDATE dbo.TV_DETAIL1 SET BILLING_USER = NULL, BILL_MONTHS = NULL
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in
	AND LINE_NBR = @line_number_in 
	
	UPDATE dbo.TV_DETAIL SET BILLING_USER = NULL
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in 
	AND LINE_NBR = @line_number_in 

	-- Magazine	*********************************************************************************************************************************************
	UPDATE dbo.MAGAZINE_DETAIL SET BILLING_USER = NULL
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in 
	AND LINE_NBR = @line_number_in 

	-- Newspaper*********************************************************************************************************************************************
	UPDATE dbo.NEWSPAPER_DETAIL SET BILLING_USER = NULL
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in 
	AND LINE_NBR = @line_number_in 

	-- Internet	*********************************************************************************************************************************************
	UPDATE dbo.INTERNET_DETAIL SET BILLING_USER = NULL 
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in 
	AND LINE_NBR = @line_number_in 

	-- Out of Home*******************************************************************************************************************************************
	UPDATE dbo.OUTDOOR_DETAIL SET BILLING_USER = NULL 
	WHERE BILLING_USER = @billing_user
	AND ORDER_NBR = @order_number_in 
	AND LINE_NBR = @line_number_in 

END
