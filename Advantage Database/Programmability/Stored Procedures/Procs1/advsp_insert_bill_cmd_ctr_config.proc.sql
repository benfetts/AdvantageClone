
CREATE PROCEDURE [dbo].[advsp_insert_bill_cmd_ctr_config]
	@bill_user_in varchar(100), @bccc_id_in integer, @tab_order_in smallint, @col_width_in smallint, 
	@seq_nbr smallint OUTPUT, @ret_val integer OUTPUT 
AS

SET NOCOUNT ON

	IF ( @seq_nbr IS NULL )
		SELECT @seq_nbr = ( SELECT MAX( SEQ_NBR ) + 1 FROM dbo.BILL_CMD_CTR_CONFIG WHERE BILLING_USER = @bill_user_in )

	IF ( @seq_nbr IS NULL )
		SELECT @seq_nbr = 1		
	
	INSERT INTO dbo.BILL_CMD_CTR_CONFIG ( BILLING_USER, SEQ_NBR, BCCC_ID, TAB_ORDER, COL_WIDTH )
		 VALUES ( @bill_user_in, @seq_nbr, @bccc_id_in, @tab_order_in, @col_width_in ) 	  
