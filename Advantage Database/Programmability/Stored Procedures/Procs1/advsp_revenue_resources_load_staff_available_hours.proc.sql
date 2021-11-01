CREATE PROCEDURE [dbo].[advsp_revenue_resources_load_staff_available_hours]
	@EmployeeCode AS varchar(6),
	@StartDate AS smalldatetime,
	@EndDate AS smalldatetime
AS
BEGIN

	DECLARE @ROW_COUNT AS integer
	DECLARE @ROW_ID AS integer
	DECLARE @WorkDate AS smalldatetime
	DECLARE @Hours as decimal
	DECLARE @TotalHours as decimal

	CREATE TABLE #WORK_DAYS([RowID] [int] IDENTITY(1,1),
							[Date] [smalldatetime],
							[Hours] [decimal](9,3))
	
	INSERT INTO #WORK_DAYS([Date], [Hours])
	SELECT 
		workday, std_hours 
	FROM 
		[dbo].[udf_get_std_hrs](@StartDate, @EndDate) 
	WHERE 
		emp_code = @EmployeeCode
		
	SET @ROW_COUNT = @@ROWCOUNT
	SET @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN

		SELECT
			@WorkDate = [Date]
		FROM 
			#WORK_DAYS
		WHERE
			RowID = @ROW_ID

		IF EXISTS(SELECT NON_TASK_ID FROM dbo.EMP_NON_TASKS WHERE EMP_CODE = @EmployeeCode AND [TYPE] <> 'H' AND ALL_DAY = 1 AND @WorkDate BETWEEN [START_DATE] AND END_DATE) BEGIN

			UPDATE
				#WORK_DAYS
			SET
				[Hours] = 0 
			WHERE
				RowID = @ROW_ID

		END ELSE IF EXISTS(SELECT [HOURS] FROM dbo.EMP_NON_TASKS WHERE EMP_CODE = @EmployeeCode AND [TYPE] <> 'H' AND ALL_DAY = 0 AND @WorkDate BETWEEN [START_DATE] AND END_DATE) BEGIN

			SELECT 
				@Hours = SUM([HOURS]) 
			FROM 
				dbo.EMP_NON_TASKS 
			WHERE 
				EMP_CODE = @EmployeeCode 
				AND TYPE <> 'H' 
				AND @WorkDate BETWEEN [START_DATE] AND END_DATE
				
			UPDATE
				#WORK_DAYS
			SET
				[Hours] = [Hours] - @Hours 
			WHERE
				RowID = @ROW_ID

		END

		SET @ROW_ID = @ROW_ID + 1
	
	END
	
	UPDATE
		#WORK_DAYS
	SET
		[Hours] = 0
	WHERE
		[Hours] < 0

	SELECT 
		@TotalHours = SUM([Hours])
	FROM
		#WORK_DAYS

	SELECT
		@TotalHours

	DROP TABLE #WORK_DAYS

END
GO