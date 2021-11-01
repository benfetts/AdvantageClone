CREATE FUNCTION [dbo].[advtf_get_workdays] ( @start_date smalldatetime, @end_date smalldatetime )
RETURNS @work_days TABLE ( workyear integer, workdate smalldatetime, holiday bit, weekend bit ) 
AS
BEGIN
	DECLARE @cur_date smalldatetime, @emp_start_date smalldatetime, @day_count integer, @start_year integer, @end_year integer, @cur_year integer
	DECLARE @year_start_date smalldatetime, @year_end_date smalldatetime, @holiday bit, @weekend bit  
	IF ( @start_date IS NOT NULL ) AND ( @end_date IS NOT NULL ) AND ( @start_date <= @end_date )
	BEGIN
		-- Create a table holding the average workday by year for each employee
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
	
				INSERT INTO @work_days( workyear, workdate, holiday, weekend ) VALUES ( @cur_year, @cur_date, @holiday, @weekend )
				
				SET @cur_date = DATEADD( day, 1, @cur_date )
			END
			
			SET @cur_year = @cur_year + 1
		END	
	END

	RETURN
END