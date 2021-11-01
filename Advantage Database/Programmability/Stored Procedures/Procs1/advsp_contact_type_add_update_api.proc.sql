
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_contact_type_add_update_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_contact_type_add_update_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_contact_type_add_update_api] 
	@contact_type_id_in int,
	@contact_type_desc varchar(100),	
	@contact_type_id_out int OUTPUT,
	@ret_val int OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

DECLARE
	@DEBUG int

DECLARE
	@found int = 0

DECLARE 
	@contact_id_found int
	

BEGIN TRY

SET NOCOUNT ON

BEGIN TRAN

SET @ret_val = 0
SET @ret_val_s = 'Success...'

SET @contact_type_id_out = @contact_type_id_in

IF @contact_type_id_in > 0 BEGIN
	SELECT @found = 1 FROM [dbo].[CONTACT_TYPE] WHERE [CONTACT_TYPE_ID] = @contact_type_id_in
	IF @found = 1 BEGIN
		SELECT @contact_id_found = [CONTACT_TYPE_ID] FROM [dbo].[CONTACT_TYPE] WHERE [CONTACT_TYPE_ID] <> @contact_type_id_in AND [DESCRIPTION] = @contact_type_desc
		IF @contact_id_found > 0 BEGIN
			SET @contact_type_id_out = @contact_id_found
			SET @error_msg_w = 'Duplicate Contact Type. Matching record found.'
			GOTO ERROR_MSG			
		END
		ELSE BEGIN
			SET @ret_val_s = 'UPDATE'
			UPDATE [dbo].[CONTACT_TYPE]
			SET [DESCRIPTION] = @contact_type_desc
			WHERE [CONTACT_TYPE_ID] = @contact_type_id_in
		END
	END
	ELSE BEGIN
		SET @error_msg_w = 'Invalid Contact ID. No matching record found.'
		GOTO ERROR_MSG
	END
END
IF @contact_type_id_in = 0 BEGIN
	SELECT @contact_id_found = [CONTACT_TYPE_ID] FROM [dbo].[CONTACT_TYPE] WHERE [DESCRIPTION] = @contact_type_desc
	IF @contact_id_found > 0 BEGIN
		SET @contact_type_id_out = @contact_id_found
		SET @error_msg_w = 'Duplicate Contact Type.'
		GOTO ERROR_MSG
	END
	ELSE BEGIN
		SET @ret_val_s = 'INSERT'
		INSERT INTO [dbo].[CONTACT_TYPE]
					([DESCRIPTION])
				VALUES
					(@contact_type_desc)

		SELECT @contact_type_id_out = MAX([CONTACT_TYPE_ID]) FROM [dbo].[CONTACT_TYPE] 
		WHERE [DESCRIPTION] = @contact_type_desc
	END
END


COMMIT TRAN

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


GRANT EXECUTE ON [advsp_contact_type_add_update_api] TO PUBLIC AS dbo
GO