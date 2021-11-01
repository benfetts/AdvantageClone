IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_update_job_process_control]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_update_job_process_control]
GO

CREATE PROCEDURE [dbo].[advsp_update_job_process_control] /*WITH ENCRYPTION*/

	@job_number integer, 
	@job_component_nbr smallint, 
	@job_process_control_in smallint, 
	@comments text, 
	@ret_val integer OUTPUT,
	@user_id varchar(100) 
	
AS
/*=========== QUERY ===========*/

	SET NOCOUNT ON

	/* IS USED IN .Net AT THIS POINT - \AdvantageFramework.BLogic\Reporting\Methods.vb(11896): MediaPlanComparisonDetailByVendors = ... */

	-- Identify the current Advantage user
	IF ISNULL(@user_id, '') > '' BEGIN
		SET @user_id = UPPER(@user_id)
	END
	ELSE BEGIN
		SET @user_id = ''
		--SELECT @user_id = UPPER(dbo.78())
	END

	DECLARE @row_count integer, @job_process_cntl smallint, @amt decimal(20,2), @validate_job_close smallint, @bypass_validation_on_job_close bit
	DECLARE @ab_flag smallint, @archive_flag smallint

	SELECT @ret_val = 0
	SELECT @bypass_validation_on_job_close = 0;
	SELECT @validate_job_close = ISNULL(VALIDATE_JOB_CLOSE, 0) FROM AGENCY WITH(NOLOCK);

	IF (@validate_job_close = 0 AND @job_process_control_in IN (6, 12)) -- closing/archiving a job
	BEGIN
		SET @bypass_validation_on_job_close = 1;
	END

	DECLARE job_cursor CURSOR FOR
	 SELECT JOB_PROCESS_CONTRL, AB_FLAG, ARCHIVE_FLAG
	   FROM dbo.JOB_COMPONENT
	  WHERE JOB_NUMBER = @job_number
		AND JOB_COMPONENT_NBR = @job_component_nbr 

	OPEN job_cursor

	FETCH job_cursor INTO @job_process_cntl, @ab_flag, @archive_flag 

	CLOSE job_cursor
	DEALLOCATE job_cursor

	IF ( @job_process_control_in = @job_process_cntl )
		SELECT @ret_val = -1
		
	IF ( @archive_flag = 1 )
		SELECT @ret_val = -2
		
	IF ( @job_process_control_in IN (6,12) )
	BEGIN
		-- Make sure the job qualifies
		IF ( @ret_val = 0 )
		BEGIN
			IF ( @ab_flag > 0 )
				SELECT @ret_val = -3	
		END
		
		IF ( @ret_val = 0 )
		BEGIN
			SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
							  FROM dbo.AP_PRODUCTION
							 WHERE JOB_NUMBER = @job_number
							   AND JOB_COMPONENT_NBR = @job_component_nbr
							   AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
							   AND ( AP_PROD_NOBILL_FLG = 0 OR AP_PROD_NOBILL_FLG IS NULL ) 
							   AND AB_FLAG <> 3 )

			IF ( @amt > 0.00 )
				SELECT @ret_val = -6
		END
		
		IF ( @ret_val = 0 )
		BEGIN
			SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
							  FROM dbo.ADVANCE_BILLING
							 WHERE JOB_NUMBER = @job_number 
							   AND JOB_COMPONENT_NBR = @job_component_nbr 
							   AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
							   AND AB_FLAG <> 3 )

			IF ( @amt > 0.00 )
				SELECT @ret_val = -7
		END
			
		IF ( @ret_val = 0 )
		BEGIN
			SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
							  FROM dbo.INCOME_ONLY
							 WHERE JOB_NUMBER = @job_number 
							   AND JOB_COMPONENT_NBR = @job_component_nbr 
							   AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
							   AND ( NON_BILL_FLAG = 0 OR NON_BILL_FLAG IS NULL )
							   AND AB_FLAG <> 3 )

			IF ( @amt > 0.00 )
				SELECT @ret_val = -8
		END
		
		IF ( @ret_val = 0 )
		BEGIN
			SELECT @amt = ( SELECT SUM( ABS( LINE_TOTAL ) )
							  FROM dbo.EMP_TIME_DTL
							 WHERE JOB_NUMBER = @job_number 
							   AND JOB_COMPONENT_NBR = @job_component_nbr 
							   AND ( AR_INV_NBR IS NULL OR AR_INV_NBR = 0 ) 
							   AND ( EMP_NON_BILL_FLAG = 0 OR EMP_NON_BILL_FLAG IS NULL )
							   AND AB_FLAG <> 3 )

			IF ( @amt > 0.00 )
				SELECT @ret_val = -9
		END
		
		IF ( @ret_val = 0 )
		BEGIN
			SELECT @amt = ( SELECT SUM( ABS( PO_EXT_AMOUNT ))
							  FROM dbo.PURCHASE_ORDER_DET POD INNER JOIN dbo.PURCHASE_ORDER PO
								ON POD.PO_NUMBER = PO.PO_NUMBER
							 WHERE JOB_NUMBER = @job_number 
							   AND JOB_COMPONENT_NBR = @job_component_nbr
							   AND ( PO.VOID_FLAG IS NULL OR PO.VOID_FLAG = 0 ) 
							   AND ( POD.PO_COMPLETE IS NULL OR POD.PO_COMPLETE = 0 )
							   AND NOT EXISTS (	SELECT PO_NUMBER 
						                   		  FROM dbo.AP_PRODUCTION AP
												 WHERE AP.PO_NUMBER = POD.PO_NUMBER
												   AND AP.PO_LINE_NUMBER = POD.LINE_NUMBER ))

			IF ( @amt > 0.00 )
				SELECT @ret_val = -10
		END											   
	END

	IF @bypass_validation_on_job_close = 1
	BEGIN
		SET @ret_val = 0
	END
	IF ( @ret_val = 0 ) 
	BEGIN
		UPDATE dbo.JOB_COMPONENT 
		   SET JOB_PROCESS_CONTRL = @job_process_control_in 
		 WHERE JOB_NUMBER = @job_number 
		   AND JOB_COMPONENT_NBR = @job_component_nbr
		   
		IF ( @@ERROR <> 0 )
			SELECT @ret_val = -4	   	
	END	  

	IF ( @ret_val = 0 )
	BEGIN
		INSERT INTO dbo.JOB_PROCESS_LOG ( JOB_NUMBER, JOB_COMPONENT_NBR, PROCESS_DATE, 
			PROCESS_USER, ORIG_PROCESS_CNTRL, NEW_PROCESS_CNTRL, PROCESS_COMMENT )
			 VALUES ( @job_number, @job_component_nbr, GETDATE( ), @user_id, 
				@job_process_cntl, @job_process_control_in, @comments )
			 	   
		IF ( @@ERROR <> 0 )
			SELECT @ret_val = -5	   	
	END	  

	IF ( @ret_val = 0 )
	BEGIN
		UPDATE dbo.JOB_COMPONENT 
		   SET BCC_ID = NULL 
		 WHERE JOB_NUMBER = @job_number 
		   AND JOB_COMPONENT_NBR = @job_component_nbr
		   AND JOB_PROCESS_CONTRL IN (6,12)
			   
		IF ( @@ERROR <> 0 )
			SELECT @ret_val = -4	   	
	END

/*=========== QUERY ===========*/
GO

GRANT EXECUTE ON [advsp_update_job_process_control] TO PUBLIC AS dbo
GO
