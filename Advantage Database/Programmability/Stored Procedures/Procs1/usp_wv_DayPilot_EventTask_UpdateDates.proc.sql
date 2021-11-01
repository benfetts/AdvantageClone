
CREATE PROCEDURE [dbo].[usp_wv_DayPilot_EventTask_UpdateDates] 
	@EVENT_TASK_ID INT,
	@NEW_START SMALLDATETIME,
	@NEW_END SMALLDATETIME,
	@INCLUDE_TIME SMALLINT,
	@USER_CODE VARCHAR(100)

AS


        DECLARE
	        @ORIGINAL_START_DATE SMALLDATETIME,
	        @ORIGINAL_END_DATE SMALLDATETIME,
	        @ORIGINAL_START_TIME SMALLDATETIME,
	        @ORIGINAL_END_TIME SMALLDATETIME,
	        @FIXED_START_DATE SMALLDATETIME,
	        @FIXED_END_DATE SMALLDATETIME,
	        @FIXED_START_TIME SMALLDATETIME,
	        @FIXED_END_TIME SMALLDATETIME,
	        @FIXED_HRS AS DECIMAL(15,2)
        	
        	
        --GET ORIGINAL DATA
        SELECT 
			@ORIGINAL_START_DATE  = START_DATE, 
			@ORIGINAL_END_DATE = END_DATE, 
			@ORIGINAL_START_TIME = START_TIME, 
			@ORIGINAL_END_TIME = END_TIME	
        FROM 
			EVENT_TASK WITH(NOLOCK) 
        WHERE 
			EVENT_TASK_ID = @EVENT_TASK_ID;

        IF @INCLUDE_TIME = 0 --MAINTAIN THE ORIGINAL TIME FOR BOTH DATES AND TIME COLUMNS, WHICH THE DAYPILOT MONTHVIEW CONTROL DOES NOT DISPLAY
        BEGIN

			SET @FIXED_START_DATE = CONVERT(
								   DATETIME,
								   CONVERT(CHAR(10), DATEPART(yyyy, @NEW_START), 101) 
								   +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(mm, @NEW_START), 101) +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(dd, @NEW_START), 101) +
								   ' ' +
								   CONVERT(CHAR(10), DATEPART(hh, @ORIGINAL_START_DATE), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(mi, @ORIGINAL_START_DATE), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(ss, @ORIGINAL_START_DATE), 101) 
								);
			SET @FIXED_END_DATE = CONVERT(
								   DATETIME,
								   CONVERT(CHAR(10), DATEPART(yyyy, @NEW_END), 101) 
								   +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(mm, @NEW_END), 101) +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(dd, @NEW_END), 101) +
								   ' ' +
								   CONVERT(CHAR(10), DATEPART(hh, @ORIGINAL_END_DATE), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(mi, @ORIGINAL_END_DATE), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(ss, @ORIGINAL_END_DATE), 101) 
								);
			SET @FIXED_START_TIME = CONVERT(
								   DATETIME,
								   CONVERT(CHAR(10), DATEPART(yyyy, @NEW_START), 101) 
								   +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(mm, @NEW_START), 101) +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(dd, @NEW_START), 101) +
								   ' ' +
								   CONVERT(CHAR(10), DATEPART(hh, @ORIGINAL_START_TIME), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(mi, @ORIGINAL_START_TIME), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(ss, @ORIGINAL_START_TIME), 101) 
								);
			SET @FIXED_END_TIME = CONVERT(
								   DATETIME,
								   CONVERT(CHAR(10), DATEPART(yyyy, @NEW_END), 101) 
								   +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(mm, @NEW_END), 101) +
								   '-' +
								   CONVERT(CHAR(10), DATEPART(dd, @NEW_END), 101) +
								   ' ' +
								   CONVERT(CHAR(10), DATEPART(hh, @ORIGINAL_END_TIME), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(mi, @ORIGINAL_END_TIME), 101) +
								   ':' +
								   CONVERT(CHAR(10), DATEPART(ss, @ORIGINAL_END_TIME), 101) 
								);
					        
        	
	        UPDATE [EVENT_TASK] WITH(ROWLOCK)
	        SET
		        START_DATE = @FIXED_START_DATE,
		        END_DATE = @FIXED_END_DATE,
		        START_TIME = @FIXED_START_TIME,
		        END_TIME = @FIXED_END_TIME
	        WHERE
		        EVENT_TASK_ID = @EVENT_TASK_ID;
        END
        
        IF @INCLUDE_TIME = 1 --JUST CHANGE IT SINCE THE DAYPILOT WEEKVIEW AND DAYVIEW DOES INCLUDE PROPER TIMES....
        BEGIN
	        SELECT   
		        @NEW_END =   
			        CASE
				        WHEN DATEDIFF(mi,@NEW_START,@NEW_END) <= 0 THEN DATEADD(hh,24,@NEW_END)
				        ELSE @NEW_END	
			        END;

	        SELECT
		        @FIXED_HRS = 
			        CASE
				        WHEN DATEDIFF(mi,@NEW_START,@NEW_END) <= 0 THEN CAST(DATEDIFF(mi,@NEW_START,DATEADD(hh,24,@NEW_END))/60.00 AS DECIMAL(15,2))
				        ELSE CAST(DATEDIFF(mi,@NEW_START,@NEW_END)/60.00 AS DECIMAL(15,2))	
			        END;

	        UPDATE [EVENT_TASK] WITH(ROWLOCK)
	        SET
		        START_DATE = @NEW_START,
		        END_DATE = @NEW_END,
		        START_TIME = @NEW_START,
		        END_TIME = @NEW_END,
		        HOURS_ALLOWED = @FIXED_HRS --Does this need to update??
	        WHERE
		        EVENT_TASK_ID = @EVENT_TASK_ID;
        END










