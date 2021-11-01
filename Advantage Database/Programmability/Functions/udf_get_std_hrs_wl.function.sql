/****** Object:  UserDefinedFunction [dbo].[udf_get_std_hrs]    Script Date: 09/24/2012 13:17:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[udf_get_std_hrs_wl]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[udf_get_std_hrs_wl]
GO

/****** Object:  UserDefinedFunction [dbo].[udf_get_std_hrs_wl]    Script Date: 09/24/2012 13:17:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- This function returns a result set of a range of dates for all employees and their average work day hours.
CREATE FUNCTION [dbo].[udf_get_std_hrs_wl] ( @start_date smalldatetime, @end_date smalldatetime, @emp_list varchar(4000))
RETURNS @emp_work_days TABLE ( emp_code varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS, workday smalldatetime, 
	std_hours decimal(9,3) ) 
AS
BEGIN
	DECLARE @emp TABLE (listpos int,value varchar(20))
	
	if @emp_list <> ''
	BEGIN
		INSERT INTO @emp 
		SELECT * FROM [dbo].[charlist_to_table] (@emp_list,',')		
	END	
	
	DECLARE @cur_date smalldatetime, @emp_start_date smalldatetime, @day_count integer, @start_year integer, @end_year integer, @cur_year integer
	DECLARE @year_start_date smalldatetime, @year_end_date smalldatetime, @holiday bit, @weekend bit, @dayoff bit, @allday bit  
	IF ( @start_date IS NOT NULL ) AND ( @end_date IS NOT NULL ) AND ( @start_date <= @end_date )
	BEGIN
		-- Create a table holding the average workday by year for each employee
		DECLARE @emp_year TABLE ( emp_code varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, emp_year integer, daily_avg decimal(9,2) )
		DECLARE @std_hours decimal(9,3)
		DECLARE @work_days TABLE ( workyear integer, workdate smalldatetime, holiday bit, weekend bit, dayoff bit, allday bit, [hours] decimal )
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
	SET [hours] = (SELECT SUM([HOURS]) FROM EMP_NON_TASKS ent WHERE [TYPE] = 'H' AND ALL_DAY = 0 AND workdate = ent.[START_DATE])
	WHERE allday = 0

	if @emp_list = ''
	BEGIN	
		INSERT INTO @emp_work_days ( emp_code, workday, std_hours )
		 SELECT e.EMP_CODE, wd.workdate,
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
		INSERT INTO @emp_work_days ( emp_code, workday, std_hours )
		 SELECT e.EMP_CODE, wd.workdate,
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
			AND ( e.EMP_CODE IN (SELECT value FROM @emp) ) 
			--AND (NOT EXISTS (SELECT ent.NON_TASK_ID 
			--	       FROM dbo.EMP_NON_TASKS ent INNER JOIN
			--			TIME_CATEGORY ON ent.CATEGORY = TIME_CATEGORY.CATEGORY
			--	      WHERE ent.[TYPE] = 'A' AND (TIME_CATEGORY.VAC_SICK_FLAG IN (1, 2, 3)) 
			--	        AND ent.ALL_DAY = 1 
			--			AND (wd.workdate BETWEEN ent.[START_DATE] AND ent.[END_DATE] )
			--			AND (ent.EMP_CODE = e.EMP_CODE)
			--		))				
	END
	
	RETURN
END

GO


