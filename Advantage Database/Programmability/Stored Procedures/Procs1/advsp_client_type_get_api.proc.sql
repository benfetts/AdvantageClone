IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_client_type_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_client_type_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_client_type_get_api] 
	@client_type_ind int, 
	@show_inactive bit,

	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)


DECLARE
	@DEBUG int

DECLARE
	@found int = 0

BEGIN TRY

SET NOCOUNT ON

/* Uncomment  for Error Testing */
--SET @client_type_ind = @client_type_ind * 10000000000

IF @client_type_ind NOT IN (1,2,3) BEGIN
	SET @error_msg_w = 'Invalid Client Type. The Client Type must be (1, 2, or 3).'
	GOTO ERROR_MSG
END

IF @client_type_ind = 1
	SELECT 
		CLIENT_TYPE1_ID AS ClientTypeID,
		[DESCRIPTION] AS ClientTypeDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM CLIENT_TYPE1
	WHERE COALESCE(INACTIVE_FLAG, 0) = 0 OR @show_inactive = 1;

IF @client_type_ind = 2
	SELECT 
		CLIENT_TYPE2_ID AS ClientTypeID,
		[DESCRIPTION] AS ClientTypeDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM CLIENT_TYPE2
	WHERE COALESCE(INACTIVE_FLAG, 0) = 0 OR @show_inactive = 1;
IF @client_type_ind = 3
	SELECT 
		CLIENT_TYPE3_ID AS ClientTypeID,
		[DESCRIPTION] AS ClientTypeDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM CLIENT_TYPE3
	WHERE COALESCE(INACTIVE_FLAG, 0) = 0 OR @show_inactive = 1;


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
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();

	SET @ret_val = @ErState
	SET @ret_val_s = @ErMessage
	
	SELECT 
		@client_type_ind AS ClientTypeID,
		@ret_val_s AS ClientTypeDescription,
		0 AS InactiveFlag
	
END CATCH

RETURN