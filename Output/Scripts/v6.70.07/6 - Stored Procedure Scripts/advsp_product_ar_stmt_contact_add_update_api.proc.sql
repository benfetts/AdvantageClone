
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_product_ar_stmt_contact_add_update_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_product_ar_stmt_contact_add_update_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_product_ar_stmt_contact_add_update_api] 
    @cl_code varchar(6),
	@div_code varchar(6),
	@prd_code varchar(6),
    @cdp_contact_id int,
    @dist_via_email smallint,
    @dist_via_print smallint,
    @use_address smallint,
    @incl_on_acct smallint,

	@ret_val int OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

DECLARE @found int
DECLARE @action varchar(6)


BEGIN TRY

SET NOCOUNT ON

BEGIN TRAN

SET @found = 0

SET @error_msg_w = ''

IF @dist_via_email IS NULL BEGIN 
	SET @dist_via_email = 0
END

IF @dist_via_print IS NULL BEGIN 
	SET @dist_via_print = 0
END

IF @incl_on_acct IS NULL BEGIN 
	SET @incl_on_acct = 0
END

IF @use_address IS NULL BEGIN 
	SET @use_address = 0
END

IF @use_address = 0 BEGIN
	SET @error_msg_w = 'The UseAddress vaule must be a 1 or 2.'
	GOTO ERROR_MSG	
END

IF ISNULL(@cl_code, '') = '' BEGIN 
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Client code is required.'
END

SET @found = 0

SELECT @found = 1 FROM [dbo].[CLIENT] WHERE [CL_CODE] = @cl_code

IF @found = 0 BEGIN
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Client code is Invalid.'
END

IF ISNULL(@div_code, '') = '' BEGIN 
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Division code is required.'
END

SET @found = 0

SELECT @found = 1 FROM [dbo].[DIVISION] WHERE [CL_CODE] = @cl_code AND [DIV_CODE] = @div_code

IF @found = 0 BEGIN
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Division code is Invalid.'
END

IF ISNULL(@prd_code, '') = '' BEGIN 
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Product code is required.'
END

SET @found = 0

SELECT @found = 1 FROM [dbo].[CDP_CONTACT_HDR] WHERE [CDP_CONTACT_ID] = @cdp_contact_id

IF @found = 0 BEGIN
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Product code is Invalid.'
END

SET @found = 0

SELECT @found = 1 FROM [dbo].[PRODUCT] WHERE [CL_CODE] = @cl_code AND [DIV_CODE] = @div_code AND [PRD_CODE] = @prd_code

IF @found = 0 BEGIN
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Product ID is Invalid.'
END

IF @error_msg_w > '' BEGIN
	GOTO ERROR_MSG	
END

--Add Dtl

SET @ret_val = 0
SET @ret_val_s = 'Success...'

SET @found = 0

SELECT @found = 1 FROM PRODUCT_AR_STMT WHERE [CDP_CONTACT_ID] = @cdp_contact_id AND [CL_CODE] = @cl_code AND [DIV_CODE] = @div_code AND [PRD_CODE] = @prd_code

IF ISNULL(@found, 0) = 0 BEGIN
	SET @action = 'INSERT'
END
ELSE BEGIN
	SET @action = 'UPDATE'
END

IF @action = 'INSERT' BEGIN
	SET @ret_val_s = @action

	INSERT INTO [dbo].[PRODUCT_AR_STMT]
			   ([CL_CODE]
			   ,[DIV_CODE]
			   ,[PRD_CODE]
			   ,[CDP_CONTACT_ID]
			   ,[DIST_VIA_EMAIL]
			   ,[DIST_VIA_PRINT]
			   ,[USE_ADDRESS]
			   ,[INCL_ON_ACCT])
		 VALUES
			   (@cl_code
			   ,@div_code
			   ,@prd_code
			   ,@cdp_contact_id
			   ,@dist_via_email
			   ,@dist_via_print
			   ,@use_address
			   ,@incl_on_acct)

END
ELSE IF @action = 'UPDATE' BEGIN
	SET @ret_val_s = @action

	UPDATE [dbo].[PRODUCT_AR_STMT]
			SET [DIST_VIA_EMAIL] = @dist_via_email
			,[DIST_VIA_PRINT] = @dist_via_print
			,[USE_ADDRESS] = @use_address
			,[INCL_ON_ACCT] = @incl_on_acct
	WHERE [CL_CODE] = @cl_code AND [DIV_CODE] = @div_code AND [PRD_CODE] = @prd_code AND [CDP_CONTACT_ID] = @cdp_contact_id
				
END

COMMIT TRAN

--ROLLBACK TRAN

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

	IF @@TRANCOUNT > 0 BEGIN
		ROLLBACK TRAN
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	--SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */		
	
	SET @ret_val = 1
	SET @ret_val_s = @ErMessage
	
END CATCH

RETURN

GO


GRANT EXECUTE ON [advsp_product_ar_stmt_contact_add_update_api] TO PUBLIC AS dbo
GO