/* Refresh Repository */
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_client_type_add_update_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_client_type_add_update_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_client_type_add_update_api] 
	@user_id varchar(100), 
	@action varchar(10), 
	
	@client_type_ind int, 
	@client_type_desc varchar(100), 
	@inactive_flag int,

	@client_type_id int OUTPUT,
	@ret_val int OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)


DECLARE
	@DEBUG int

DECLARE
	@found int = 0
	

BEGIN TRY

SET NOCOUNT ON

BEGIN TRAN

SET @ret_val = 0
SET @ret_val_s = 'Success...'

IF @action = 'DEBUG'
	SET @DEBUG  = 1

SET @client_type_id = 0

IF @client_type_ind NOT IN (1,2,3) BEGIN
	SET @error_msg_w = 'Invalid Client Type. The Client Type must be (1, 2, or 3).'
	GOTO ERROR_MSG
END

IF @client_type_ind = 1 BEGIN
	SELECT @found = 1 FROM [dbo].[CLIENT_TYPE1] WHERE [DESCRIPTION] = @client_type_desc
	IF @found = 1 BEGIN
		SET @ret_val_s = 'UPDATE 1'
		UPDATE [dbo].[CLIENT_TYPE1]
		SET [INACTIVE_FLAG] = @inactive_flag
		WHERE [DESCRIPTION] = @client_type_desc
	END 
	ELSE BEGIN
		SET @ret_val_s = 'INSERT 1'
		INSERT INTO [dbo].[CLIENT_TYPE1]
				   ([DESCRIPTION]
				   ,[INACTIVE_FLAG])
			 VALUES
				   (@client_type_desc,
				   COALESCE(@inactive_flag, 0))
	END
	SELECT @client_type_id = CLIENT_TYPE1_ID, @inactive_flag = [INACTIVE_FLAG] FROM [dbo].[CLIENT_TYPE1] 
	WHERE [DESCRIPTION] = @client_type_desc
END
IF @client_type_ind = 2 BEGIN
	SELECT @found = 1 FROM [dbo].[CLIENT_TYPE2] WHERE [DESCRIPTION] = @client_type_desc
	IF @found = 1 BEGIN
		SET @ret_val_s = 'UPDATE 2'
		UPDATE [dbo].[CLIENT_TYPE2]
		SET [INACTIVE_FLAG] = @inactive_flag
		WHERE [DESCRIPTION] = @client_type_desc
	END
	ELSE BEGIN
		SET @ret_val_s = 'INSERT 2'
		INSERT INTO [dbo].[CLIENT_TYPE2]
				   ([DESCRIPTION]
				   ,[INACTIVE_FLAG])
			 VALUES
				   (@client_type_desc,
				   COALESCE(@inactive_flag, 0))
	END
	SELECT @client_type_id = CLIENT_TYPE2_ID, @inactive_flag = [INACTIVE_FLAG] FROM [dbo].[CLIENT_TYPE2]
	WHERE [DESCRIPTION] = @client_type_desc
END
IF @client_type_ind = 3 BEGIN
	SELECT @found = 1 FROM [dbo].[CLIENT_TYPE3] WHERE [DESCRIPTION] = @client_type_desc
	IF @found = 1 BEGIN
		SET @ret_val_s = 'UPDATE 3'
		UPDATE [dbo].[CLIENT_TYPE3]
		SET [INACTIVE_FLAG] = @inactive_flag
		WHERE [DESCRIPTION] = @client_type_desc
	END
	ELSE BEGIN
		SET @ret_val_s = 'INSERT 3'
		INSERT INTO [dbo].[CLIENT_TYPE3]
				   ([DESCRIPTION]
				   ,[INACTIVE_FLAG])
			 VALUES
				   (@client_type_desc,
				   COALESCE(@inactive_flag, 0))
	END
	SELECT @client_type_id = CLIENT_TYPE3_ID, @inactive_flag = [INACTIVE_FLAG] FROM [dbo].[CLIENT_TYPE3]
	WHERE [DESCRIPTION] = @client_type_desc
END

IF @@TRANCOUNT > 0
	IF @DEBUG = 1 BEGIN
		IF @client_type_ind = 1
				SELECT 'CLIENT_TYPE' 'DESC', *	 
				  FROM CLIENT_TYPE1 A WHERE DESCRIPTION = @client_type_desc
		IF @client_type_ind = 2
				SELECT 'CLIENT_TYPE' 'DESC', *	 
				  FROM CLIENT_TYPE2 A WHERE DESCRIPTION = @client_type_desc
		IF @client_type_ind = 3
				SELECT 'CLIENT_TYPE' 'DESC', *	 
				  FROM CLIENT_TYPE3 A WHERE DESCRIPTION = @client_type_desc

		ROLLBACK TRAN
	END
	ELSE
		COMMIT TRAN

GOTO ENDIT
  
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			--ROLLBACK TRAN			
			--SELECT @error_msg_w as ErrorMessage;
			
			--SELECT 'PROCESS ERROR CONTROL'  /* DEBUG */	
			
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing
	
END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		--SELECT 'PROCESS ERROR ROLLBACK', @@TRANCOUNT '@@TRANCOUNT'  /* DEBUG */	
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