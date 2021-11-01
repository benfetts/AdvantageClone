IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_job_log_udf_get_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_job_log_udf_get_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_job_log_udf_get_api] 
	@udv_ind int, 
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
--SET @udv_ind = @udv_ind * 10000000000

IF @udv_ind NOT IN (1,2,3,4,5) BEGIN
	SET @error_msg_w = 'Invalid User Defined Value Type. The UDV Type must be (1, 2, 3, 4, or 5).'
	GOTO ERROR_MSG
END

IF @udv_ind = 1
	SELECT 
		UDV_CODE AS UserDefinedValueCode,
		UDV_DESC AS UserDefinedValueDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM JOB_LOG_UDV1
	WHERE COALESCE(INACTIVE_FLAG, 0) = 0 OR @show_inactive = 1;
IF @udv_ind = 2
	SELECT 
		UDV_CODE AS UserDefinedValueCode,
		UDV_DESC AS UserDefinedValueDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM JOB_LOG_UDV2
	WHERE COALESCE(INACTIVE_FLAG, 0) = 0 OR @show_inactive = 1;
IF @udv_ind = 3
	SELECT 
		UDV_CODE AS UserDefinedValueCode,
		UDV_DESC AS UserDefinedValueDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM JOB_LOG_UDV3
	WHERE COALESCE(INACTIVE_FLAG, 0) = 0 OR @show_inactive = 1;
IF @udv_ind = 4
	SELECT 
		UDV_CODE AS UserDefinedValueCode,
		UDV_DESC AS UserDefinedValueDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM JOB_LOG_UDV4
	WHERE COALESCE(INACTIVE_FLAG, 0) = 0 OR @show_inactive = 1;
IF @udv_ind = 5
	SELECT 
		UDV_CODE AS UserDefinedValueCode,
		UDV_DESC AS UserDefinedValueDescription,
		COALESCE(INACTIVE_FLAG, 0) AS InactiveFlag
	FROM JOB_LOG_UDV5
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
		CAST(@udv_ind as varchar(20)) AS UserDefinedValueCode,
		@ret_val_s AS UserDefinedValueDescription,
		0 AS InactiveFlag	


END CATCH

RETURN