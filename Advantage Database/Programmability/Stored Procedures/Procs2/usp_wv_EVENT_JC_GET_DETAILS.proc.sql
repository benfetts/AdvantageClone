
CREATE PROCEDURE [dbo].[usp_wv_EVENT_JC_GET_DETAILS] 
	@JOB_NUMBER INT,
	@JOB_COMPONENT_NBR SMALLINT,
	@CUT_OFF_DATE VARCHAR(10),
	@EVENT_GEN_ID INT,
	@AD_NBR VARCHAR(30)

AS
    DECLARE @SQL VARCHAR(8000)
    SET @SQL = '
        SELECT     
            EVENT_ID, 
            EVENT_LABEL, 
            EVENT_DESC_LONG, 
            TYPE, 
            EVENT_DATE, 
            CONVERT(CHAR(10),EVENT_DATE,101) AS EVENT_DATE_NO_TIME,
            CASE DATEPART(dw,EVENT_DATE)
		        WHEN 1 THEN ''Sun''
		        WHEN 2 THEN ''Mon''
		        WHEN 3 THEN ''Tue''
		        WHEN 4 THEN ''Wed''
		        WHEN 5 THEN ''Thu''
		        WHEN 6 THEN ''Fri''
		        WHEN 7 THEN ''Sat''
	        END AS DAY_OF_WEEK,       
            CASE DATEPART(dw,EVENT_DATE)
		        WHEN 1 THEN ''Sunday''
		        WHEN 2 THEN ''Monday''
		        WHEN 3 THEN ''Tueday''
		        WHEN 4 THEN ''Wednesday''
		        WHEN 5 THEN ''Thursday''
		        WHEN 6 THEN ''Friday''
		        WHEN 7 THEN ''Saturday''
	        END AS FULL_DAY_OF_WEEK,       
            ALL_DAY, 
            QTY_HRS, 
            ISNULL(QTY_TYPE,1) AS QTY_TYPE, --DEFAULT TO 1 = HOURS
            START_TIME, 
            END_TIME, 
            RESOURCE_CODE, 
            JOB_NUMBER, 
            JOB_COMPONENT_NBR, 
            FNC_CODE, 
            AD_NUMBER, 
            EVENT_COMMENT, 
            INCOME_ONLY_ID, 
            EVENT_GEN_ID, 
            CREATE_DATE, 
            CREATE_USER,
            MODIFY_DATE,
            MODIFY_USER,
			EVENT_TYPE_ID,
			CASE
				WHEN EVENT_TYPE_ID = 0 OR EVENT_TYPE_ID IS NULL THEN ''NONE''
				WHEN EVENT_TYPE_ID = 1 THEN ''FIXED''
				WHEN EVENT_TYPE_ID = 2 THEN ''FLEX''
				WHEN EVENT_TYPE_ID = 3 THEN ''PRE''
				WHEN EVENT_TYPE_ID = 4 THEN ''HOLD''
			END AS EVENT_TYPE_ID_ALPHA_SORT 
        FROM   EVENT WITH(NOLOCK)
        WHERE  JOB_NUMBER = ' + CAST(@JOB_NUMBER AS VARCHAR) + '
               AND JOB_COMPONENT_NBR = ' + CAST(@JOB_COMPONENT_NBR AS VARCHAR) 
    IF NOT @CUT_OFF_DATE IS NULL
    BEGIN
	    SET @SQL = @SQL + ' AND (EVENT_DATE <= CONVERT(DATETIME, ''' + @CUT_OFF_DATE + ' 23:59:00'', 102))'
    END           
    IF @EVENT_GEN_ID > 0 
    BEGIN
		    SET @SQL = @SQL + ' AND EVENT_GEN_ID = ' + CAST(@EVENT_GEN_ID AS VARCHAR)
    END
	IF NOT @AD_NBR IS NULL
	BEGIN
			SET @SQL = @SQL + ' AND AD_NUMBER = ''' + @AD_NBR + ''''
	END
    SET @SQL = @SQL + ' ORDER BY START_TIME,END_TIME;'
    --PRINT @SQL
    EXEC(@SQL);

