
CREATE PROCEDURE [dbo].[usp_wv_DayPilot_Event_UpdateDates] 
	@EVENT_ID INT,
	@NEW_START SMALLDATETIME,
	@NEW_END SMALLDATETIME,
	@INCLUDE_TIME SMALLINT,
	@USER_CODE VARCHAR(100)

AS


        DECLARE
	        @ORIGINAL_DATE SMALLDATETIME,
	        @ORIGINAL_START SMALLDATETIME,
	        @ORIGINAL_END SMALLDATETIME,
	        @FIXED_DATE SMALLDATETIME,
	        @FIXED_START SMALLDATETIME,
	        @FIXED_END SMALLDATETIME,
	        @FIXED_HRS AS DECIMAL(15,2)
        	
        	
        --GET ORIGINAL DATA
        SELECT @ORIGINAL_DATE  = EVENT_DATE, @ORIGINAL_START = START_TIME, @ORIGINAL_END = END_TIME	FROM EVENT WITH(NOLOCK) WHERE EVENT_ID = @EVENT_ID;

        SET @FIXED_DATE = CONVERT(
				               DATETIME,
				               CONVERT(CHAR(10), DATEPART(yyyy, @NEW_START), 101) 
				               +
				               '-' +
				               CONVERT(CHAR(10), DATEPART(mm, @NEW_START), 101) +
				               '-' +
				               CONVERT(CHAR(10), DATEPART(dd, @NEW_START), 101) +
				               ' 00:00:00' 
				               );
        				       
        SET @FIXED_START = CONVERT(
				               DATETIME,
				               CONVERT(CHAR(10), DATEPART(yyyy, @NEW_START), 101) 
				               +
				               '-' +
				               CONVERT(CHAR(10), DATEPART(mm, @NEW_START), 101) +
				               '-' +
				               CONVERT(CHAR(10), DATEPART(dd, @NEW_START), 101) +
				               ' ' +
				               CONVERT(CHAR(10), DATEPART(hh, @ORIGINAL_START), 101) +
				               ':' +
				               CONVERT(CHAR(10), DATEPART(mi, @ORIGINAL_START), 101) +
				               ':' +
				               CONVERT(CHAR(10), DATEPART(ss, @ORIGINAL_START), 101) 
					        );
        					
        SET @FIXED_END = CONVERT(
				               DATETIME,
				               CONVERT(CHAR(10), DATEPART(yyyy, @NEW_END), 101) 
				               +
				               '-' +
				               CONVERT(CHAR(10), DATEPART(mm, @NEW_END), 101) +
				               '-' +
				               CONVERT(CHAR(10), DATEPART(dd, @NEW_END), 101) +
				               ' ' +
				               CONVERT(CHAR(10), DATEPART(hh, @ORIGINAL_END), 101) +
				               ':' +
				               CONVERT(CHAR(10), DATEPART(mi, @ORIGINAL_END), 101) +
				               ':' +
				               CONVERT(CHAR(10), DATEPART(ss, @ORIGINAL_END), 101) 
					        );
        					


        SELECT @FIXED_DATE AS FIXED_DATE,@FIXED_START AS FIXED_START,@FIXED_END AS FIXED_END, @FIXED_HRS AS FIXED_HRS


        IF @INCLUDE_TIME = 0 --NEED TO MAINTAIN THE ORIGINAL TIME, WHICH THE DAYPILOT MONTHVIEW CONTROL DOES NOT DISPLAY
        BEGIN
	        SELECT   
		        @FIXED_END =   
			        CASE
				        WHEN DATEDIFF(mi,@FIXED_START,@FIXED_END) <= 0 THEN DATEADD(hh,24,@FIXED_END)
				        ELSE @FIXED_END	
			        END;

	        SELECT
		        @FIXED_HRS = 
			        CASE
				        WHEN DATEDIFF(mi,@FIXED_START,@FIXED_END) <= 0 THEN CAST(DATEDIFF(mi,@FIXED_START,DATEADD(hh,24,@FIXED_END))/60.00 AS DECIMAL(15,2))
				        ELSE CAST(DATEDIFF(mi,@FIXED_START,@FIXED_END)/60.00 AS DECIMAL(15,2))	
			        END;
        	
	        UPDATE [EVENT] WITH(ROWLOCK)
	        SET
		        EVENT_DATE = @FIXED_DATE,
		        START_TIME = @FIXED_START,
		        END_TIME = @FIXED_END,
		        MODIFY_DATE = GETDATE(),
		        MODIFY_USER = @USER_CODE,
		        QTY_HRS = @FIXED_HRS
	        WHERE
		        EVENT_ID = @EVENT_ID;
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

	        UPDATE [EVENT] WITH(ROWLOCK)
	        SET
		        EVENT_DATE = @FIXED_DATE,
		        START_TIME = @NEW_START,
		        END_TIME = @NEW_END,
		        MODIFY_DATE = GETDATE(),
		        MODIFY_USER = @USER_CODE,
		        QTY_HRS = @FIXED_HRS
	        WHERE
		        EVENT_ID = @EVENT_ID;
        END










