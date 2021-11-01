
CREATE PROCEDURE dbo.advsp_job_activity_list
AS
BEGIN
	SET NOCOUNT ON

	-- Comments

	DECLARE @job_number integer, @job_component_nbr smallint, @has_activity bit

	CREATE TABLE #job_activity_list(
		JOB_NUMBER					integer NOT NULL,
		JOB_COMPONENT_NBR			smallint NOT NULL,
		HAS_ACTIVITY				bit NULL )

	DECLARE job_cursor CURSOR FOR 
	 SELECT JOB_NUMBER, JOB_COMPONENT_NBR
	   FROM dbo.JOB_COMPONENT
	  WHERE JOB_PROCESS_CONTRL NOT IN ( 6, 12 )

	OPEN job_cursor

	FETCH NEXT FROM job_cursor INTO @job_number, @job_component_nbr

	WHILE ( @@FETCH_STATUS <> -1 )
	BEGIN
		SELECT @has_activity = NULL
		
		IF @has_activity IS NULL
			SELECT @has_activity = ( SELECT 1 WHERE EXISTS ( SELECT * 
															   FROM dbo.ESTIMATE_APPROVAL 
															  WHERE JOB_NUMBER = @job_number		
																AND JOB_COMPONENT_NBR = @job_component_nbr ))

		IF @has_activity IS NULL
			SELECT @has_activity = ( SELECT 1 WHERE EXISTS ( SELECT * 
															   FROM dbo.EMP_TIME_DTL 
															  WHERE JOB_NUMBER = @job_number		
																AND JOB_COMPONENT_NBR = @job_component_nbr ))

		IF @has_activity IS NULL
			SELECT @has_activity = ( SELECT 1 WHERE EXISTS ( SELECT * 
															   FROM dbo.AP_PRODUCTION 
															  WHERE JOB_NUMBER = @job_number		
																AND JOB_COMPONENT_NBR = @job_component_nbr ))

		IF @has_activity IS NULL
			SELECT @has_activity = ( SELECT 1 WHERE EXISTS ( SELECT * 
															   FROM dbo.INCOME_ONLY 
															  WHERE JOB_NUMBER = @job_number		
																AND JOB_COMPONENT_NBR = @job_component_nbr ))

		IF @has_activity IS NULL
			SELECT @has_activity = ( SELECT 1 WHERE EXISTS ( SELECT * 
															   FROM dbo.ADVANCE_BILLING 
															  WHERE JOB_NUMBER = @job_number		
																AND JOB_COMPONENT_NBR = @job_component_nbr ))

		SELECT @has_activity = ISNULL( @has_activity, 0 )
		
		INSERT INTO #job_activity_list ( JOB_NUMBER, JOB_COMPONENT_NBR, HAS_ACTIVITY )
			 VALUES ( @job_number, @job_component_nbr, @has_activity )

		FETCH NEXT FROM job_cursor INTO @job_number, @job_component_nbr
	END

	CLOSE job_cursor
	DEALLOCATE job_cursor

END

SELECT * FROM #job_activity_list
