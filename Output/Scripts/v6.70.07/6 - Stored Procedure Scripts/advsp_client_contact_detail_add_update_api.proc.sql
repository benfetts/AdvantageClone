
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_client_contact_detail_add_update_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_client_contact_detail_add_update_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_client_contact_detail_add_update_api] 
	 @cdp_contact_id_in int		--for updates or 0 for new
	,@seq_nbr_in int			--for updates or 0 for new
	,@div_code varchar(6)		--input
	,@prd_code varchar(6)		--input
	,@delete_seq bit			--input

	,@seq_nbr_out int OUTPUT	--generated
	,@ret_val int OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

DECLARE @found int
DECLARE @seq_nbr_found int
DECLARE @action varchar(6)

DECLARE @cl_code varchar(6)
DECLARE @max_seq int

BEGIN TRY

SET NOCOUNT ON

BEGIN TRAN

SET @found = 0
SET @seq_nbr_found = 0
SET @max_seq = 0

SET @error_msg_w = ''

IF @cdp_contact_id_in IS NULL BEGIN 
	SET @cdp_contact_id_in = 0
END

IF @seq_nbr_in IS NULL BEGIN 
	SET @seq_nbr_in = 0
END

IF (@cdp_contact_id_in = 0 OR @seq_nbr_in = 0) AND @delete_seq = 1 BEGIN
	SET @error_msg_w = 'Contact ID and Seq Number are required when deleting a Division/Product association.'
	GOTO ERROR_MSG	
END

IF (@seq_nbr_in > 0) AND @delete_seq = 0 BEGIN
	SET @error_msg_w = 'Seq Number must be 0 when adding a new Division/Product association.'
	GOTO ERROR_MSG	
END

IF @delete_seq = 1 BEGIN

	SELECT @seq_nbr_found = [CDP_CONTACT_ID] FROM [dbo].[CDP_CONTACT_DTL] WHERE [CDP_CONTACT_ID] = @cdp_contact_id_in AND [SEQ_NBR] = @seq_nbr_in

	IF ISNULL(@seq_nbr_found, 0) = 0 BEGIN
		IF @error_msg_w > '' BEGIN
			SET @error_msg_w = @error_msg_w + ' | '
		END
		SET @error_msg_w = 'The provided Seq Number does not exist for deleting.'
	END

END

IF @delete_seq = 0 BEGIN

	SELECT @cl_code = [CL_CODE] FROM [dbo].[CDP_CONTACT_HDR] WHERE [CDP_CONTACT_ID] = @cdp_contact_id_in

	SET @found = 0

	IF ISNULL(@div_code, '') = '' BEGIN 
		IF @error_msg_w > '' BEGIN
			SET @error_msg_w = @error_msg_w + ' | '
		END
		SET @error_msg_w = @error_msg_w + 'Division code is required.'
	END
	ELSE BEGIN
		SELECT @found = 1 FROM [dbo].[DIVISION] WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND ACTIVE_FLAG = 1
		IF @found = 0 BEGIN
			IF @error_msg_w > '' BEGIN
				SET @error_msg_w = @error_msg_w + ' | '
			END
			SET @error_msg_w = @error_msg_w + 'Division code is Invalid.'
		END
	END

	SET @found = 0

	IF ISNULL(@prd_code, '') = '' BEGIN 
		IF @error_msg_w > '' BEGIN
			SET @error_msg_w = @error_msg_w + ' | '
		END
		SET @error_msg_w = @error_msg_w + 'Product code is required.'
	END
	ELSE BEGIN
		SELECT @found = 1 FROM [dbo].[PRODUCT] WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code AND ACTIVE_FLAG = 1
		IF @found = 0 BEGIN
			IF @error_msg_w > '' BEGIN
				SET @error_msg_w = @error_msg_w + ' | '
			END
			SET @error_msg_w = @error_msg_w + 'Product code is Invalid.'
		END
	END

END

IF @error_msg_w > '' BEGIN
	GOTO ERROR_MSG	
END

--Add Dtl

SET @ret_val = 0
SET @ret_val_s = 'Success...'

SET @seq_nbr_out = @seq_nbr_in

IF @delete_seq = 0 BEGIN

	SET @seq_nbr_found = 0

	SELECT @seq_nbr_found = [CDP_CONTACT_ID] FROM [dbo].[CDP_CONTACT_DTL] WHERE [CDP_CONTACT_ID] = @cdp_contact_id_in AND DIV_CODE = @div_code AND PRD_CODE = @prd_code AND [SEQ_NBR] <> @seq_nbr_in

	IF ISNULL(@seq_nbr_found, 0) > 0 BEGIN
		IF @error_msg_w > '' BEGIN
			SET @error_msg_w = @error_msg_w + ' | '
		END
		SET @error_msg_w = @error_msg_w + 'The provided Contact ID, Division Code, and Product Code are associated with an existing Seq Number.'
		GOTO ERROR_MSG	
	END

END

IF ISNULL(@seq_nbr_in, 0) = 0 BEGIN
	SET @action = 'INSERT'
END
ELSE BEGIN
	SET @action = 'DELETE'
END

IF @action = 'INSERT' BEGIN
	SET @ret_val_s = @action

	SELECT @max_seq = ISNULL(MAX(SEQ_NBR), 0) FROM [dbo].[CDP_CONTACT_DTL] WHERE [CDP_CONTACT_ID] = @cdp_contact_id_in

	SET @max_seq = @max_seq + 1

	INSERT INTO [dbo].[CDP_CONTACT_DTL]
			   ([CDP_CONTACT_ID]
			   ,[SEQ_NBR]
			   ,[DIV_CODE]
			   ,[PRD_CODE])
		 VALUES
			   (@cdp_contact_id_in
			   ,@max_seq
			   ,@div_code
			   ,@prd_code)

				SELECT TOP 1 @seq_nbr_out = [SEQ_NBR] FROM [CDP_CONTACT_DTL] ORDER BY [CDP_CONTACT_ID] DESC

END
ELSE IF @action = 'DELETE' BEGIN
	SET @ret_val_s = @action

	DELETE FROM [dbo].[CDP_CONTACT_DTL] WHERE [CDP_CONTACT_ID] = @cdp_contact_id_in AND [SEQ_NBR] = @seq_nbr_in		
				
END

--SELECT @seq_nbr_in '@seq_nbr_in', @seq_nbr_out '@seq_nbr_out'

--SELECT * FROM [CDP_CONTACT_DTL] WHERE [CDP_CONTACT_ID] IN (@cdp_contact_id_in)


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


GRANT EXECUTE ON [advsp_client_contact_detail_add_update_api] TO PUBLIC AS dbo
GO