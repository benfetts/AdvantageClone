IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_campaign_add_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_campaign_add_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_campaign_add_api] 
	@user_id varchar(100), 
	@action varchar(10), 

	@cl_code varchar(6), 
	@div_code varchar(6) = NULL, 
	@prd_code varchar(6) = NULL, 	
	@cmp_code varchar(6), 
	@cmp_name varchar(128), 
	@beg_date smalldatetime = NULL, 
	@end_date smalldatetime = NULL, 
	@job_number integer = 0,
	@job_component_nbr smallint = 0,
	@cmp_identifier integer OUTPUT,
	@ret_val integer OUTPUT, 
	@ret_val_s varchar(max) OUTPUT
AS

/*
PJH 01/04/18 - Created [advsp_campaign_add_api]
PJH 10/04/18 - Do not require @cmp_code - Default to @cmp_identifier
PJH 03/24/20 - Allow dates to be blank
PJH 10/05/20 - Added Job/Comp parameters
*/

IF @div_code IN ('', '*') BEGIN
	SET @div_code = NULL
	SET @prd_code = NULL
END

IF @prd_code IN ('', '*')
	SET @prd_code = NULL

IF @cmp_code IN ('', '*')
	SET @cmp_code = NULL

IF @cmp_name IN ('', '*')
	SET @cmp_name = NULL

IF @job_number = 0
	SET  @job_number = NULL

IF @job_number = 0 OR @job_component_nbr = 0
	SET  @job_component_nbr = NULL

SET NOCOUNT ON

DECLARE @error_msg_w varchar(200)
DECLARE @date_time_w smalldatetime

DECLARE @DEBUG integer
DECLARE @RC integer
	,@RC_MSG varchar(max)

DECLARE @ErMessage nvarchar(2048)
	,@ErSeverity integer
	,@ErState integer

DECLARE @row_count integer

DECLARE @add_comp bit, 
	@office_code varchar(4),
	@alert_group varchar(50)

DECLARE @job_process_contrl integer,
	@job_@cl_code varchar (6)

SET @add_comp = 1
SET @office_code = NULL

BEGIN TRAN

BEGIN TRY
	IF @action = 'DEBUG'
		SET @DEBUG = 1
	ELSE
		SET @DEBUG = 0

	IF @user_id IS NULL
	BEGIN
		SET @error_msg_w = 'Invalid User ID.'

		GOTO ERROR_MSG
	END

	SELECT @date_time_w = GETDATE()

	SET @ret_val = 0
	SET @ret_val_s = 'Success...'

	IF @cmp_identifier IS NULL 
		SET @cmp_identifier = 0

	IF @div_code IS NULL
		SET @prd_code = NULL

	BEGIN
		-- Validate Client
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.CLIENT WHERE CL_CODE = @cl_code AND ACTIVE_FLAG = 1 )

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Client
			SET @error_msg_w = 'Invalid Client Code.'
			GOTO ERROR_MSG
		END	
	END

	IF @div_code IS NOT NULL
	BEGIN
		-- Validate Division
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.DIVISION WHERE CL_CODE = @cl_code AND (DIV_CODE = @div_code) AND ACTIVE_FLAG = 1 )

		IF @row_count <> 1
		BEGIN
			-- Invalid/Closed Division
			SET @error_msg_w = 'Invalid Division Code.'
			GOTO ERROR_MSG
		END	
	END

	IF @prd_code IS NOT NULL
	BEGIN
		-- Validate Product
		SELECT @row_count = ( SELECT COUNT(*) FROM dbo.PRODUCT WHERE CL_CODE = @cl_code AND (DIV_CODE = @div_code) AND (PRD_CODE = @prd_code) AND ACTIVE_FLAG = 1 )

		IF @row_count <> 1
		BEGIN
			PRINT @row_count
			-- Invalid/Closed Product
			SET @error_msg_w = 'Invalid Product Code.'
			GOTO ERROR_MSG
		END	
	END

	/**************  ADD - CAMPAIGN  ***********************************/
	BEGIN

		BEGIN
			IF ( @cmp_name IS NULL )
			BEGIN
				SET @error_msg_w = 'Invalid Campaign Name.'
				GOTO ERROR_MSG
			END	
		END

		BEGIN
			IF NOT ISDATE(@beg_date) = 1 OR @beg_date = '1900-01-01'
			BEGIN
				SET @beg_date = NULL
				--SET @error_msg_w = 'Invalid Start Date.'
				--GOTO ERROR_MSG
			END	
		END

		BEGIN
			IF NOT ISDATE(@end_date) = 1 OR @end_date = '1900-01-01'
			BEGIN
				SET @end_date = NULL
				--SET @error_msg_w = 'Invalid End Date.'
				--GOTO ERROR_MSG
			END	
		END

		IF @job_number IS NULL AND @job_component_nbr IS NOT NULL
		BEGIN
			SET @error_msg_w = 'Missing Job Number.'
			GOTO ERROR_MSG
		END

		IF @job_number IS NOT NULL AND @job_component_nbr IS NULL
		BEGIN
			SET @error_msg_w = 'Missing Job Component Number.'
			GOTO ERROR_MSG
		END

		IF @job_number IS NOT NULL AND @job_component_nbr IS NOT NULL
		BEGIN
			SELECT 
				 @job_process_contrl = B.JOB_PROCESS_CONTRL,
				 @job_@cl_code = A.CL_CODE
			FROM JOB_LOG A JOIN JOB_COMPONENT B ON A.JOB_NUMBER = B.JOB_NUMBER
			WHERE ( A.JOB_NUMBER = @job_number
					AND B.JOB_COMPONENT_NBR = @job_component_nbr
					);

			IF @@ROWCOUNT = 0
			BEGIN
				SET @error_msg_w = 'Invalid Job/Component numbers.'
				GOTO ERROR_MSG
			END

			SET @job_@cl_code = ISNULL(@job_@cl_code,'')

			IF @job_@cl_code <> @cl_code 
			BEGIN
				SET @error_msg_w = 'The Job''s client code must match the client code entered.'
				GOTO ERROR_MSG
			END

			IF @job_process_contrl IN (6,12) 
			BEGIN
				SET @error_msg_w = 'Job/Component is closed.'
				GOTO ERROR_MSG
			END		
		END

		BEGIN
			-- Validate Campaign
			SELECT @row_count = ( SELECT COUNT(*) 
									FROM dbo.CAMPAIGN 
								   WHERE CL_CODE = @cl_code
									 AND (DIV_CODE = @div_code OR (DIV_CODE IS NULL AND @div_code IS NULL))
									 AND (PRD_CODE = @prd_code OR (PRD_CODE IS NULL AND @prd_code IS NULL))
									 AND (CMP_CODE = @cmp_code)
									 )
									 --AND CMP_TYPE = 2	
									 --AND ( CMP_CLOSED IS NULL OR CMP_CLOSED = 0 )

			IF @row_count > 0
			BEGIN
				-- Invalid/Closed Campaign
				SET @error_msg_w = 'Campaign Code ''' + @cmp_code + ''' already exists for this Client/Division/Product.'
				GOTO ERROR_MSG
			END	
		END

		BEGIN
			 SELECT @office_code = OFFICE_CODE, @alert_group = EMAIL_GR_CODE
			 FROM dbo.PRODUCT WHERE CL_CODE = @cl_code AND DIV_CODE = @div_code AND PRD_CODE = @prd_code AND ACTIVE_FLAG = 1

			 --SELECT @office_code '@office_code' , @alert_group '@alert_group'
		END

		BEGIN
			SELECT 'Get Next Cmp ID' 'DESC'

			--SELECT @cmp_identifier = ( SELECT LAST_NBR + 1 FROM dbo.ASSIGN_NBR  WHERE COLUMNNAME = 'CMP_IDENTIFIER' )

			SELECT @cmp_identifier = ( SELECT MAX(CMP_IDENTIFIER) + 1 FROM dbo.CAMPAIGN )

			IF ( @cmp_identifier > 99999999 )
			BEGIN
				SELECT @cmp_identifier = 0
				-- Invalid Campaign
				SET @error_msg_w = 'Invalid Campaign ID.'
				GOTO ERROR_MSG
			END
			/** Maybe use in the future - The new version of Campaign is not using the suto number table **/
			--ELSE
			--BEGIN
			--	UPDATE dbo.ASSIGN_NBR SET LAST_NBR = @cmp_identifier WHERE COLUMNNAME = 'CMP_IDENTIFIER'
			--END
		END

		IF @cmp_code IS NULL
			SET @cmp_code = CAST(@cmp_identifier AS varchar(20))

		BEGIN
			INSERT INTO [dbo].[CAMPAIGN]
					   ([CL_CODE]
					   ,[DIV_CODE]
					   ,[PRD_CODE]
					   ,[CMP_CODE]
					   ,[CMP_BEG_DATE]
					   ,[CMP_END_DATE]
					   ,[CMP_COMMENTS]
					   ,[CMP_NAME]
					   ,[CMP_DIRECT]
					   ,[CMP_MAGAZINE]
					   ,[CMP_NEWSPAPER]
					   ,[CMP_OUTDOOR]
					   ,[CMP_PRINT_COLL]
					   ,[CMP_RADIO]
					   ,[CMP_TELEVISION]
					   ,[CMP_OTHER]
					   ,[CMP_OTHER_EXPLAIN]
					   ,[CMP_IDENTIFIER]
					   ,[CMP_CLOSED]
					   ,[ACTIVE_FLAG]
					   ,[CMP_BILL_BUDGET]
					   ,[CMP_INC_BUDGET]
					   ,[CMP_TYPE]
					   ,[OFFICE_CODE]
					   ,[ALERT_GROUP]
					   ,[CMP_INTERNET]
					   ,[AD_NBR]
					   ,[MARKET_CODE]
					   ,[JOB_NUMBER]
					   ,[JOB_COMPONENT_NBR]
					   ,[CL_WEBSITE_ID]
					   ,[AD_SERVER_ID]
					   ,[AD_SERVER_CAMPAIGN_ID]
					   ,[AD_SERVER_CREATED_BY])
				 VALUES
					   (@cl_code
					   ,@div_code
					   ,@prd_code
					   ,@cmp_code
					   ,@beg_date
					   ,@end_date
					   ,NULL --[CMP_COMMENTS]
					   ,@cmp_name
					   ,NULL --[CMP_DIRECT]
					   ,NULL --[CMP_MAGAZINE]
					   ,NULL --[CMP_NEWSPAPER]
					   ,NULL --[CMP_OUTDOOR]
					   ,NULL --[CMP_PRINT_COLL]
					   ,NULL --[CMP_RADIO]
					   ,NULL --[CMP_TELEVISION]
					   ,NULL --[CMP_OTHER]
					   ,NULL --[CMP_OTHER_EXPLAIN]
					   ,@cmp_identifier --[CMP_IDENTIFIER]
					   ,0 --[CMP_CLOSED]
					   ,NULL --[ACTIVE_FLAG]
					   ,NULL --[CMP_BILL_BUDGET]
					   ,NULL --[CMP_INC_BUDGET]
					   ,2 --[CMP_TYPE] 2 = Jobs & Orders, 1 = Overall
					   ,@office_code --[OFFICE_CODE]
					   ,@alert_group --[ALERT_GROUP]
					   ,@cmp_identifier --[CMP_INTERNET]
					   ,NULL --[AD_NBR]
					   ,NULL --[MARKET_CODE]
					   ,@job_number --[JOB_NUMBER]
					   ,@job_component_nbr --[JOB_COMPONENT_NBR]
					   ,NULL --[CL_WEBSITE_ID]
					   ,NULL --[AD_SERVER_ID]
					   ,NULL --[AD_SERVER_CAMPAIGN_ID]
					   ,NULL) --[AD_SERVER_CREATED_BY]
		END
		
		IF @job_number IS NOT NULL
		/* Update Master Job */
		BEGIN
			UPDATE JOB_LOG
			SET CMP_CODE = @cmp_code, CMP_IDENTIFIER = @cmp_identifier
			WHERE JOB_NUMBER = @job_number
		END
	END

	IF @@TRANCOUNT > 0
		IF @DEBUG = 1
		BEGIN
			SELECT 'DEBUG' 'DESC'
				,@cmp_identifier '@cmp_identifier'
				,@cmp_code '@cmp_code'
				,@user_id '@user_id'
				,@date_time_w '@date_time_w'

			SET @error_msg_w = 'DEBUG - ROLLBACK'

			GOTO ERROR_MSG
		END
	GOTO ENDIT

	/**************************** ERROR PROCESSING ***************************/
	ERROR_MSG:

	BEGIN
		SET @ret_val = - 1

		RAISERROR (
				@error_msg_w
				,16
				,1
				)
	END

	ENDIT: --Do Nothing
END TRY

BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
		SELECT 'PROCESS ERROR ROLLBACK'
			,@@TRANCOUNT '@@TRANCOUNT' /* DEBUG */
	END

	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	SELECT @ErMessage = ERROR_MESSAGE()
		,@ErSeverity = ERROR_SEVERITY()
		,@ErState = ERROR_STATE();

	SELECT @ErMessage 'ERROR_MESSAGE'
		,@ErSeverity 'ERROR_SEVERITY'
		,@ErState 'ERROR_SATE' /* DEBUG */

	--IF @ret_val <> 0
	IF @ErMessage IS NOT NULL
	BEGIN
		SET @ret_val = 1
		SET @ret_val_s = @ErMessage
	END

END CATCH

IF @DEBUG = 1 BEGIN
	SELECT 'CAMPAIGN' 'SRC', * FROM CAMPAIGN WHERE CMP_IDENTIFIER = @cmp_identifier
END

/**************************************************/
--ROLLBACK TRANSACTION - Handle in Calling process
/**************************************************/

IF @ret_val = 0
	COMMIT TRAN
ELSE
	ROLLBACK TRAN

RETURN
GO

GRANT EXECUTE ON [advsp_campaign_add_api] TO PUBLIC AS dbo
GO