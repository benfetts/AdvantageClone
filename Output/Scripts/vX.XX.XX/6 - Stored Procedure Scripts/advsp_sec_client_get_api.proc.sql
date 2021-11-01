IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_sec_client_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_sec_client_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_sec_client_get_api] 
	@user_code varchar(6),		/* User code or NULL */
	@ret_val integer OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

SET @ret_val_s = 'Success...'

BEGIN TRY

SET NOCOUNT ON

SET @ret_val = 0
SET @ret_val_s = NULL

IF (@user_code) = '' BEGIN
	SET @user_code = NULL
END

IF (@user_code) IS NULL BEGIN
	SET @error_msg_w = 'Invalid User Code: NULL'
	GOTO ERROR_MSG
END

/* Return Dataset from SEC_CLIENT */

BEGIN

SELECT	A.[USER_ID] UserCode, 
		B.[OFFICE_CODE] OfficeCode, 
		B.[OFFICE_NAME] OfficeName,
		A.[CL_CODE] ClientCode, 
		B.[CL_NAME] ClientName,
		A.[DIV_CODE] DivisionCode, 
		B.[DIV_NAME] DivisionName,
		A.[PRD_CODE] ProductCode, 
		B.[PRD_DESCRIPTION] ProductDescription,
		CASE WHEN ISNULL(B.[CL_ACTIVE_FLAG], 0) = 0 THEN 1 ELSE 0 END IsInactive
FROM SEC_CLIENT A JOIN V_PRODUCT B ON A.CL_CODE = B.CL_CODE AND A.DIV_CODE = B.DIV_CODE AND A.PRD_CODE = B.PRD_CODE
WHERE A.[USER_ID] = @user_code

END

IF @@ROWCOUNT = 0 BEGIN
	SET @ret_val = 1
	SET @ret_val_s = 'No matching records'
END


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

	IF @ErMessage IS NOT NULL BEGIN
		SET @ret_val = 1
		SET @ret_val_s = @ErMessage
	END

END CATCH

RETURN
GO

GRANT EXECUTE ON [advsp_sec_client_get_api] TO PUBLIC AS dbo
GO