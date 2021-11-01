IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_revise_order_process_cleanup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_revise_order_process_cleanup]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_revise_order_process_cleanup] 
	@user_id varchar(100), @action varchar(10), @order_type varchar(2), 
	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS
/*
***********************************************************************************************************
PJH 08/17/16 - Clear staging table after import error
PJH 01/18/18 - Added 'AW' as valid MEDIA_INTERFACE type
***********************************************************************************************************
*/

DECLARE @media_type_in varchar(2),  @error_msg_w varchar(200) 

DECLARE @ROW_COUNT int, @ROW_ID int, @DEBUG int
DECLARE @RC int, @RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
			

BEGIN TRY

BEGIN TRAN TP1

	IF @action = 'DEBUG'
		SET @DEBUG = 1
	ELSE
		SET @DEBUG = 0
		
	IF @order_type NOT IN ('NP','MA','OD','IN','TV','RA') BEGIN
		SELECT @order_type = 
			CASE @order_type
				WHEN 'N' THEN 'NP'
				WHEN 'M' THEN 'MA'
				WHEN 'I' THEN 'IN'
				WHEN 'O' THEN 'OD'
				WHEN 'T' THEN 'TV'
				WHEN 'R' THEN 'RA'
				ELSE @order_type
			END
	END	

	SELECT @media_type_in = 
		CASE @order_type
			WHEN 'NP' THEN 'N'
			WHEN 'MA' THEN 'M'
			WHEN 'IN' THEN 'I'
			WHEN 'OD' THEN 'O'
			WHEN 'TV' THEN 'T'
			WHEN 'RA' THEN 'R'
			ELSE @order_type
		END

	IF @order_type NOT IN ('NP','MA','IN','OD','TV','RA') BEGIN 
		SET @error_msg_w = 'Invalid Order Type - Valid types are NP, MA, IN, OD, TV, or RA.'
		SET @ret_val_s = @error_msg_w
		SET @ret_val = 1
		GOTO ERROR_MSG	
	END

	/** Clear UnPosted rows from staging tables **/
	IF @DEBUG = 1 BEGIN
		SELECT 'PRINT_ORDERS (Posted) to CLEAR' 'DESC-Before', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM PRINT_ORDER
		WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0)
		SELECT 'BRDCAST_ORDER (Posted) to CLEAR' 'DESC-Before', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM BRDCAST_IMPORT
		WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0)
	END

	SELECT @media_type_in '@media_type_in'
	
	IF @order_type IN ('NP','MA','IN','OD')
		DELETE FROM PRINT_ORDER
		WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0 AND USER_ID = @user_id)
	ELSE
		DELETE FROM BRDCAST_IMPORT
		WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0 AND USER_ID = @user_id)
		
	IF @DEBUG = 1 BEGIN
		SELECT 'PRINT_ORDERS (Posted) to CLEAR' 'DESC-After', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM PRINT_ORDER
		WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0)
		SELECT 'BRDCAST_ORDER (Posted) to CLEAR' 'DESC-After', MEDIA_TYPE, MEDIA_INTERFACE, POST_FLAG, * FROM BRDCAST_IMPORT
		WHERE (MEDIA_INTERFACE IN ('AB','AM','AP','AW') AND MEDIA_TYPE = @media_type_in AND POST_FLAG = 0)
	END		

	IF @@TRANCOUNT > 0
		IF @DEBUG = 1 BEGIN
			SELECT 'ROLLBACK' 'DEBUG', @order_type '@order_type'
			ROLLBACK TRAN TP1
		END
		ELSE
			COMMIT TRAN TP1

	/*====================================================== END =============================================================*/

	 GOTO ENDIT
	           
	/**************************** ERROR PROCESSING ************************************************************************/	
		ERROR_MSG:
			BEGIN
			
				--ROLLBACK TRAN			
				--SELECT @error_msg_w as ErrorMessage;
				
				SELECT 'PROCESS ERROR CONTROL'  /* DEBUG */	
				
				RAISERROR (@error_msg_w,
				 16,
				 1 )    
				
			END

		ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		SELECT 'PROCESS ERROR ROLLBACK', @@TRANCOUNT '@@TRANCOUNT'  /* DEBUG */	
		ROLLBACK TRAN TP1
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */	
	
	IF @ret_val IS NULL BEGIN
		SET @ret_val = @ErState
		SET @ret_val_s = @ErMessage
	END	

END CATCH

RETURN           
GO

GRANT EXECUTE ON advsp_revise_order_process_cleanup TO PUBLIC AS dbo
GO