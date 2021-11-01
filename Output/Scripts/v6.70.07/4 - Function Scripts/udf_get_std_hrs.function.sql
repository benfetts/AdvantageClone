
-- This function returns a result set of a range of dates for all employees and their average work day hours.
CREATE FUNCTION [dbo].[udf_get_std_hrs] ( @start_date smalldatetime, @end_date smalldatetime )
RETURNS @emp_work_days TABLE ( emp_code varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, workday smalldatetime, 
	work_hours decimal(9,2), std_hours decimal(9,3) ) 
AS
BEGIN
	DECLARE @cur_date smalldatetime, @emp_start_date smalldatetime, @day_count integer, @start_year integer, @end_year integer, @cur_year integer
	DECLARE @year_start_date smalldatetime, @year_end_date smalldatetime, @holiday bit, @weekend bit, @allday bit 
	IF ( @start_date IS NOT NULL ) AND ( @end_date IS NOT NULL ) AND ( @start_date <= @end_date )
	BEGIN
		-- Create a table holding the average workday by year for each employee
		DECLARE @emp_year TABLE ( emp_code varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, emp_year integer, daily_avg decimal(9,2) )
		DECLARE @std_hours decimal(9,3)
		DECLARE @work_days TABLE ( workyear integer, workdate smalldatetime, holiday bit, weekend bit, allday bit, [hours] decimal )
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
				SET @allday = 0				
				IF ( SELECT COUNT( * ) 
				       FROM dbo.EMP_NON_TASKS ent 
				      WHERE ent.[TYPE] = 'H' 
				        AND ent.ALL_DAY = 1 
						AND ( @cur_date BETWEEN ent.[START_DATE] AND ent.[END_DATE] )) > 0
					SELECT @holiday = 1, @allday = 1

				IF ( SELECT COUNT( * ) 
				       FROM dbo.EMP_NON_TASKS ent 
				      WHERE ent.[TYPE] = 'H' 
				        AND ent.ALL_DAY = 0 
						AND ( @cur_date BETWEEN ent.[START_DATE] AND ent.[END_DATE] )) > 0
					SELECT @holiday = 1, @allday = 0
	
				INSERT INTO @work_days( workyear, workdate, holiday, weekend, allday ) VALUES ( @cur_year, @cur_date, @holiday, @weekend, @allday )
				
				SET @cur_date = DATEADD( day, 1, @cur_date )
			END
			
			IF ( @day_count > 0 )
				INSERT INTO @emp_year ( emp_code, emp_year, daily_avg ) 
					 SELECT e.EMP_CODE, @cur_year, 
							ROUND( CAST( e.STD_ANNUAL_HRS AS decimal(9,2)) / CAST( @day_count AS decimal(9,2)), 2 )
					   FROM dbo.EMPLOYEE e 

			SET @cur_year = @cur_year + 1
		END	
	END
	

	UPDATE @work_days
	SET [hours] = (SELECT SUM([HOURS]) AS [HOURS] FROM EMP_NON_TASKS ent WHERE [TYPE] = 'H' AND ALL_DAY = 0 AND ent.[START_DATE] = workdate AND ent.ALL_DAY = 0)
	WHERE allday = 0

	
	INSERT INTO @emp_work_days ( emp_code, workday, work_hours, std_hours )
		 SELECT e.EMP_CODE, wd.workdate,
				COALESCE( CASE 
							WHEN wd.weekend = 1 THEN 0
							ELSE ( SELECT ey.daily_avg 
							         FROM @emp_year ey 
							        WHERE ( ey.emp_year = wd.workyear )
									  AND ( ey.emp_code = e.EMP_CODE COLLATE SQL_Latin1_General_CP1_CS_AS )) 
				END, 0 ),
				COALESCE( CASE 
							WHEN DATEPART( dw, wd.workdate ) = 1 AND wd.holiday = 0 THEN ( SELECT SUN_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN DATEPART( dw, wd.workdate ) = 2 AND wd.holiday = 0 THEN ( SELECT MON_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN DATEPART( dw, wd.workdate ) = 3 AND wd.holiday = 0 THEN ( SELECT TUE_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN DATEPART( dw, wd.workdate ) = 4 AND wd.holiday = 0 THEN ( SELECT WED_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN DATEPART( dw, wd.workdate ) = 5 AND wd.holiday = 0 THEN ( SELECT THU_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN DATEPART( dw, wd.workdate ) = 6 AND wd.holiday = 0 THEN ( SELECT FRI_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							WHEN DATEPART( dw, wd.workdate ) = 7 AND wd.holiday = 0 THEN ( SELECT SAT_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE )
							ELSE CASE 
									WHEN DATEPART( dw, wd.workdate ) = 1 AND wd.holiday = 1 THEN ( SELECT SUN_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE ) - wd.[hours] 
									WHEN DATEPART( dw, wd.workdate ) = 2 AND wd.holiday = 1 THEN ( SELECT MON_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE ) - wd.[hours] 
									WHEN DATEPART( dw, wd.workdate ) = 3 AND wd.holiday = 1 THEN ( SELECT TUE_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE ) - wd.[hours] 
									WHEN DATEPART( dw, wd.workdate ) = 4 AND wd.holiday = 1 THEN ( SELECT WED_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE ) - wd.[hours] 
									WHEN DATEPART( dw, wd.workdate ) = 5 AND wd.holiday = 1 THEN ( SELECT THU_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE ) - wd.[hours] 
									WHEN DATEPART( dw, wd.workdate ) = 6 AND wd.holiday = 1 THEN ( SELECT FRI_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE ) - wd.[hours] 
									WHEN DATEPART( dw, wd.workdate ) = 7 AND wd.holiday = 1 THEN ( SELECT SAT_HRS FROM dbo.EMPLOYEE WHERE EMP_CODE = e.EMP_CODE ) - wd.[hours] 
									ELSE 0 END

				END, 0 )
		   FROM @work_days wd, dbo.EMPLOYEE e 
		  WHERE ( e.EMP_TERM_DATE >= wd.workdate OR e.EMP_TERM_DATE IS NULL )
			AND ( e.EMP_DATE <= wd.workdate OR e.EMP_DATE IS NULL )
			AND (( wd.holiday = 0) OR (wd.holiday = 1 and wd.allday = 0))
			AND ( wd.workdate BETWEEN @start_date AND @end_date ) 
	RETURN
END
