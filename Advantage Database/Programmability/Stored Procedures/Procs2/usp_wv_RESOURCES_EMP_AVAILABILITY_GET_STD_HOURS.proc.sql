CREATE PROCEDURE [dbo].[usp_wv_RESOURCES_EMP_AVAILABILITY_GET_STD_HOURS] 
	@start_date smalldatetime, 
	@end_date smalldatetime, 
	@emp_list varchar(4000) 
AS
	CREATE TABLE #emp_work_days ( emp_code varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS, workday smalldatetime, std_hours decimal(9,3) )
	CREATE TABLE #emp (listpos int,value varchar(20) COLLATE SQL_Latin1_General_CP1_CS_AS)
	
	if @emp_list <> ''
	BEGIN
		INSERT INTO #emp 
		SELECT * FROM [dbo].[charlist_to_table] (@emp_list,',')		
	END	
	
	DECLARE @cur_date smalldatetime, @emp_start_date smalldatetime, @day_count integer, @start_year integer, @end_year integer, @cur_year integer
	DECLARE @year_start_date smalldatetime, @year_end_date smalldatetime, @holiday bit, @weekend bit, @dayoff bit 
	IF ( @start_date IS NOT NULL ) AND ( @end_date IS NOT NULL ) AND ( @start_date <= @end_date )
	BEGIN
		-- Create a table holding the average workday by year for each employee
		CREATE TABLE #emp_year ( emp_code varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, emp_year integer, daily_avg decimal(9,2) )
		DECLARE @std_hours decimal(9,3)
		CREATE TABLE #work_days ( workyear integer, workdate smalldatetime, holiday bit, weekend bit, dayoff bit )
		SET @start_year = DATEPART(yyyy, @start_date)		
		SET @end_year = DATEPART(yyyy, @end_date)		
		SET @cur_year = @start_year
		WHILE ( @cur_year <= @end_year )
		BEGIN
			SET @day_count = 0
			SET @year_start_date = CONVERT( smalldatetime, '01/01/' + CAST( @cur_year AS varchar(4)) )
			SET @year_end_date = CONVERT( smalldatetime, '12/31/' + CAST( @cur_year AS varchar(4)) )
			SET @cur_date = @year_start_date
			
			WHILE ( @cur_date <= @year_end_date )
			BEGIN
				SET @weekend = 0
				IF (( DATEPART( dw, @cur_date )) IN ( 1, 7 ))
					SET @weekend = 1
				ELSE
					SET @day_count = @day_count + 1
									 
				SET @holiday = 0					
				IF ( SELECT COUNT( * ) 
				       FROM dbo.EMP_NON_TASKS ent 
				      WHERE ent.[TYPE] = 'H' 
				        AND ent.ALL_DAY = 1 
						AND ( @cur_date BETWEEN ent.[START_DATE] AND ent.[END_DATE] )) > 0
					SELECT @holiday = 1			
				
				INSERT INTO #work_days( workyear, workdate, holiday, weekend ) VALUES ( @cur_year, @cur_date, @holiday, @weekend )
				
				SET @cur_date = DATEADD( day, 1, @cur_date )
			END
			
			IF ( @day_count > 0 )
				INSERT INTO #emp_year ( emp_code, emp_year, daily_avg ) 
					 SELECT e.EMP_CODE, @cur_year, 
							ROUND( CAST( e.STD_ANNUAL_HRS AS decimal(9,2)) / CAST( @day_count AS decimal(9,2)), 2 )
					   FROM dbo.EMPLOYEE e 

			SET @cur_year = @cur_year + 1
		END	
	END
	if @emp_list = ''
	BEGIN	
		 INSERT INTO #emp_work_days ( emp_code, workday, std_hours )
		 SELECT e.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS, wd.workdate,
				CASE DATEPART( dw, wd.workdate ) 
							WHEN 1 THEN ( SELECT SUN_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 2 THEN ( SELECT MON_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 3 THEN ( SELECT TUE_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 4 THEN ( SELECT WED_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 5 THEN ( SELECT THU_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 6 THEN ( SELECT FRI_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 7 THEN ( SELECT SAT_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
				END
		   FROM #work_days wd, dbo.EMPLOYEE e 
		  WHERE ( e.EMP_TERM_DATE >= wd.workdate OR e.EMP_TERM_DATE IS NULL )
			AND ( e.EMP_DATE <= wd.workdate OR e.EMP_DATE IS NULL )
			AND ( wd.holiday = 0 )
			AND ( wd.workdate BETWEEN @start_date AND @end_date )
			--AND ( e.EMP_CODE IN (@emp_list) ) 
			--AND (NOT EXISTS (SELECT ent.NON_TASK_ID 
			--	       FROM dbo.EMP_NON_TASKS ent INNER JOIN
			--			TIME_CATEGORY ON ent.CATEGORY = TIME_CATEGORY.CATEGORY
			--	      WHERE ent.[TYPE] = 'A' AND (TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
			--	        AND ent.ALL_DAY = 1 
			--			AND (wd.workdate BETWEEN ent.[START_DATE] AND ent.[END_DATE] )
			--			AND (ent.EMP_CODE = e.EMP_CODE)
			--		))				
	END
	ELSE
	BEGIN		
		 INSERT INTO #emp_work_days ( emp_code, workday, std_hours )
		 SELECT e.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS, wd.workdate,
				CASE DATEPART( dw, wd.workdate ) 
							WHEN 1 THEN ( SELECT SUN_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 2 THEN ( SELECT MON_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 3 THEN ( SELECT TUE_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 4 THEN ( SELECT WED_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 5 THEN ( SELECT THU_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 6 THEN ( SELECT FRI_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN 7 THEN ( SELECT SAT_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
				END
		   FROM #work_days wd, dbo.EMPLOYEE e 
		  WHERE ( e.EMP_TERM_DATE >= wd.workdate OR e.EMP_TERM_DATE IS NULL )
			AND ( e.EMP_DATE <= wd.workdate OR e.EMP_DATE IS NULL )
			AND ( wd.holiday = 0 )
			AND ( wd.workdate BETWEEN @start_date AND @end_date )
			AND ( e.EMP_CODE IN (SELECT value FROM #emp) ) 
			--AND (NOT EXISTS (SELECT ent.NON_TASK_ID 
			--	       FROM dbo.EMP_NON_TASKS ent INNER JOIN
			--			TIME_CATEGORY ON ent.CATEGORY = TIME_CATEGORY.CATEGORY
			--	      WHERE ent.[TYPE] = 'A' AND (TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
			--	        AND ent.ALL_DAY = 1 
			--			AND (wd.workdate BETWEEN ent.[START_DATE] AND ent.[END_DATE] )
			--			AND (ent.EMP_CODE = e.EMP_CODE)
			--		))				
	END
	
	SELECT * FROM #emp_work_days e WHERE e.std_hours <> 0.0

	DROP TABLE #emp_work_days
	DROP TABLE #work_days
	DROP TABLE #emp_year
	DROP TABLE #emp

GO
