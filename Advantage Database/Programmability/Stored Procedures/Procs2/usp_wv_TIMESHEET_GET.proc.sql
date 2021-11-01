﻿IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_TIMESHEET_GET]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_TIMESHEET_GET]
GO

CREATE PROCEDURE [dbo].[usp_wv_TIMESHEET_GET] 
@EMP_CODE    VARCHAR(6),
@StartDate   SMALLDATETIME,
@SortColumn  VARCHAR(35)
AS
/*=========== QUERY ===========*/
    BEGIN
	    SET NOCOUNT ON;

		    DECLARE @START_ON        VARCHAR(10),
				    @IS_VALID_START  BIT,
				    @DATE_PART_VAL   INT,
				    @START_DATE      SMALLDATETIME,
				    @END_DATE        SMALLDATETIME

    			
		    SET @DATE_PART_VAL = DATEPART(WEEKDAY, @StartDate); --1 = sunday, 7 = saturday
		    IF @DATE_PART_VAL = 1
		    BEGIN
			    SET @START_ON = 'Sunday';
			    SET @START_DATE = @StartDate;
		    END
		    IF @DATE_PART_VAL = 2
		    BEGIN
			    SET @START_ON = 'Monday';
			    SET @START_DATE = @StartDate;
		    END
		    IF @DATE_PART_VAL > 2
		    BEGIN
			    SET @START_ON = 'Sunday';
			    SET @START_DATE = DATEADD(DD, 1 -@DATE_PART_VAL, @StartDate);
		    END
		    SET @END_DATE = DATEADD(DD, 6, @START_DATE);

    --SELECT @START_ON AS START_ON, @START_DATE AS START_DATE;

		    CREATE TABLE #TIME_ROWS
		    (
			    ROW_ID             INT IDENTITY(1, 1),
			    ET_ID              INT NOT NULL,
			    ET_DTL_ID          INT NOT NULL,
			    FNC_CAT            VARCHAR(10)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    EMP_HOURS          DECIMAL(9, 3) NOT NULL,
			    CL_CODE            VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    DIV_CODE           VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    PRD_CODE           VARCHAR(6)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    JOB_NUMBER         INT NULL,
			    CLIENT_REF         VARCHAR(30)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    JOB_COMPONENT_NBR  SMALLINT NULL,
			    DP_TM_CODE         VARCHAR(4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    TIME_TYPE          CHAR(1)  COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
			    EDIT_FLAG          SMALLINT NOT NULL,
			    MAX_SEQ            SMALLINT NULL,
			    START_TIME         CHAR(4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    END_TIME           CHAR(4)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    EMP_DATE           SMALLDATETIME,
			    COMMENTS           TEXT NULL,
			    PROD_CAT_CODE      VARCHAR(10)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    COMPARE_STRING     VARCHAR(4000)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    DATA_KEY		   VARCHAR(2000)  COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
			    PROCESSED			BIT NULL	
		    );

		    INSERT INTO #TIME_ROWS
		    SELECT etd.ET_ID,
			       etd.ET_DTL_ID,
			       NULL,
			       SUM(EMP_HOURS),
			       NULL,
			       NULL,
			       NULL,
			       NULL,
			       NULL,
			       NULL,
			       NULL,
			       'D',
			       0,
			       MAX(SEQ_NBR),
			       NULL,
			       NULL,
			       EMP_DATE,
			       NULL,
			       etd.PROD_CAT_CODE,
			       NULL,NULL,NULL
		    FROM   EMP_TIME_DTL AS etd WITH (NOLOCK),
			       EMP_TIME AS et WITH (NOLOCK)
		    WHERE  et.ET_ID = etd.ET_ID
			       AND EMP_CODE = @EMP_CODE
			       AND EMP_DATE >= @START_DATE
			       AND EMP_DATE <= @END_DATE
		    GROUP BY
			       etd.ET_ID,
			       etd.ET_DTL_ID,
			       EMP_DATE,
			       etd.PROD_CAT_CODE;

		    UPDATE #TIME_ROWS
		    SET    FNC_CAT = etd.FNC_CODE,
			       CL_CODE = jl.CL_CODE,
			       DIV_CODE = jl.DIV_CODE,
			       PRD_CODE = jl.PRD_CODE,
			       CLIENT_REF = jl.JOB_CLI_REF,
			       JOB_NUMBER = etd.JOB_NUMBER,
			       JOB_COMPONENT_NBR = etd.JOB_COMPONENT_NBR,
			       DP_TM_CODE = etd.DP_TM_CODE
		    FROM   EMP_TIME_DTL etd WITH (NOLOCK),
			       JOB_LOG jl WITH (NOLOCK),
			       #TIME_ROWS tr
		    WHERE  tr.ET_ID = etd.ET_ID
			       AND tr.ET_DTL_ID = etd.ET_DTL_ID
			       AND tr.MAX_SEQ = etd.SEQ_NBR
			       AND etd.JOB_NUMBER = jl.JOB_NUMBER;

		    INSERT INTO #TIME_ROWS
		    SELECT etn.ET_ID,
			       etn.ET_DTL_ID,
			       CATEGORY,
			       SUM(EMP_HOURS),
			       NULL,
			       NULL,
			       NULL,
			       NULL,
			       NULL,
			       NULL,
			       DP_TM_CODE,
			       'N',
			       0,
			       NULL,
			       NULL,
			       NULL,
			       EMP_DATE,
			       NULL,
			       NULL,
			       NULL,NULL,NULL
		    FROM   EMP_TIME_NP AS etn WITH (NOLOCK),
			       EMP_TIME AS et WITH (NOLOCK)
		    WHERE  et.ET_ID = etn.ET_ID
			       AND EMP_CODE = @EMP_CODE
			       AND EMP_DATE >= @START_DATE
			       AND EMP_DATE <= @END_DATE
		    GROUP BY
			       etn.ET_ID,
			       etn.ET_DTL_ID,
			       CATEGORY,
			       DP_TM_CODE,
			       EMP_DATE;

		    --Get Comments
		    UPDATE #TIME_ROWS
		    SET    COMMENTS = ct.EMP_COMMENT
		    FROM   EMP_TIME_DTL_CMTS ct WITH (NOLOCK),
			       #TIME_ROWS tr
		    WHERE  tr.ET_ID = ct.ET_ID
			       AND tr.ET_DTL_ID = ct.ET_DTL_ID;

		    -- BJL - 11/23/03
		    UPDATE #TIME_ROWS
		    SET    START_TIME = etdc.START_TIME,
			       END_TIME = etdc.END_TIME
		    FROM   EMP_TIME_DTL_CMTS AS etdc WITH (NOLOCK),
			       #TIME_ROWS tr
		    WHERE  tr.ET_ID = etdc.ET_ID
			       AND tr.ET_DTL_ID = etdc.ET_DTL_ID;

		    -- Determine if rows have been billed
		    UPDATE #TIME_ROWS
		    SET    EDIT_FLAG = 1
		    WHERE  EXISTS (
				       SELECT etd.AR_INV_NBR
				       FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
				       WHERE  etd.ET_ID = #TIME_ROWS.ET_ID
						      AND etd.ET_DTL_ID = #TIME_ROWS.ET_DTL_ID
						      AND etd.AR_INV_NBR IS NOT NULL
							  AND (etd.EDIT_FLAG = 0 OR etd.EDIT_FLAG IS NULL)
			       );

		    -- Determine if item is summarized
		    UPDATE #TIME_ROWS
		    SET    EDIT_FLAG = 2
		    WHERE  EDIT_FLAG = 1
			       AND (
					       SELECT COUNT(*)
					       FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
					       WHERE  etd.ET_ID = #TIME_ROWS.ET_ID
							      AND etd.ET_DTL_ID = #TIME_ROWS.ET_DTL_ID
				       ) > 1;
    			
		    -- Determine if item is a restricted AB flag
		    UPDATE #TIME_ROWS
		    SET    EDIT_FLAG = 3
		    WHERE  EDIT_FLAG = 0
			       AND EXISTS (
					       SELECT AB_FLAG
					       FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
					       WHERE  etd.ET_ID = #TIME_ROWS.ET_ID
							      AND etd.ET_DTL_ID = #TIME_ROWS.ET_DTL_ID
							      AND etd.AB_FLAG IN (1, 3)
				       );

		    -- Determine if item is selected for billing
		    UPDATE #TIME_ROWS
		    SET    EDIT_FLAG = 4
		    WHERE  EDIT_FLAG = 0
			       AND EXISTS (
					       SELECT BILLING_USER
					       FROM   EMP_TIME_DTL AS etd WITH (NOLOCK)
					       WHERE  etd.ET_ID = #TIME_ROWS.ET_ID
							      AND etd.ET_DTL_ID = #TIME_ROWS.ET_DTL_ID
							      AND BILLING_USER IS NOT NULL
				       );

		    -- BJL - 11/23/03
		    -- Check if row has been approved
		    UPDATE #TIME_ROWS
		    SET    EDIT_FLAG = 6
		    WHERE  EDIT_FLAG = 0
			       AND EXISTS (
					       SELECT ET_ID
					       FROM   EMP_TIME AS et WITH (NOLOCK)
					       WHERE  et.ET_ID = #TIME_ROWS.ET_ID
							      AND APPR_FLAG = 1
				       )
			       AND EXISTS (
					       SELECT *
					       FROM   AGENCY WITH (NOLOCK)
					       WHERE  TIME_APPR_ACTIVE = 1
				       );

		    -- BJL - 11/23/03
		    -- Check if row is pending approval
		    UPDATE #TIME_ROWS
		    SET    EDIT_FLAG = 5
		    WHERE  EDIT_FLAG = 0
			       AND EXISTS (
					       SELECT ET_ID
					       FROM   EMP_TIME AS et WITH (NOLOCK)
					       WHERE  et.ET_ID = #TIME_ROWS.ET_ID
							      AND APPR_PENDING = 1
				       )
			       AND EXISTS (
					       SELECT *
					       FROM   AGENCY WITH (NOLOCK)
					       WHERE  TIME_APPR_ACTIVE = 1
				       );

		    -- JTG - 9/17/2009
		    -- Check if row is denied approval
		    UPDATE #TIME_ROWS
		    SET    EDIT_FLAG = 7
		    WHERE  EDIT_FLAG = 0
			       AND EXISTS (
					       SELECT ET_ID
					       FROM   EMP_TIME AS et WITH (NOLOCK)
					       WHERE  et.ET_ID = #TIME_ROWS.ET_ID
							      AND APPR_PENDING = 2
				       )
			       AND EXISTS (
					       SELECT *
					       FROM   AGENCY WITH (NOLOCK)
					       WHERE  TIME_APPR_ACTIVE = 1
			       );

		    UPDATE #TIME_ROWS
		    SET    COMPARE_STRING = ISNULL(#TIME_ROWS.CL_CODE, '') + '|' +
			       ISNULL(#TIME_ROWS.DIV_CODE, '') + '|' +
			       ISNULL(#TIME_ROWS.PRD_CODE, '') + '|' +
			       ISNULL(CAST(#TIME_ROWS.JOB_NUMBER AS VARCHAR), '') + '|' +
			       ISNULL(CAST(#TIME_ROWS.JOB_COMPONENT_NBR AS VARCHAR), '') + '|' +
			       ISNULL(#TIME_ROWS.FNC_CAT, '') + '|' +
			       ISNULL(#TIME_ROWS.DP_TM_CODE, '') + '|' +
			       ISNULL(#TIME_ROWS.PROD_CAT_CODE, ''),
			       DATA_KEY = ISNULL(CAST(ET_ID AS VARCHAR), '') + '|' +
			       ISNULL(CAST(ET_DTL_ID AS VARCHAR), '') + '|' +
			       ISNULL(CAST(TIME_TYPE AS VARCHAR), '') + '|' +
			       ISNULL(CAST(EDIT_FLAG AS VARCHAR), '') + '|' +
			       ISNULL(CAST(MAX_SEQ AS VARCHAR), '')
    		       
			       end_tran:

		    /* CREATE THE TIMESHEET TO AVOID THE LOOPING TO CREATE COMPLEX OBJECT IN CODE */
		    CREATE TABLE #TIME_SHEET
		    (
			    /* DISPLAY OPTIONS */
			    ROW_ID                INT IDENTITY(1, 1),
			    CL_CODE               VARCHAR(6) NULL,
			    CL_NAME               VARCHAR(40) NULL,
			    DIV_CODE              VARCHAR(6) NULL,
			    DIV_NAME              VARCHAR(40) NULL,
			    PRD_CODE              VARCHAR(6) NULL,
			    PRD_DESCRIPTION       VARCHAR(40) NULL,
			    PROD_CAT_CODE         VARCHAR(10) NULL,
			    JOB_NUMBER            INT NULL,
			    JOB_DESC              VARCHAR(60) NULL,
			    JOB_COMPONENT_NBR     SMALLINT NULL,
			    JOB_COMP_DESC         VARCHAR(60) NULL,
			    JOB_DISPLAY           VARCHAR(250) NULL,
			    JOB_COMP_DISPLAY      VARCHAR(250) NULL,
			    JOB_AND_COMP_DISPLAY  VARCHAR(500) NULL,
			    FNC_CAT               VARCHAR(10) NULL,
			    DP_TM_CODE            VARCHAR(4) NULL,
			    CLIENT_REF            VARCHAR(30) NULL,
			    --	--KEYS
			    --	ET_ID                 INT NOT NULL,
			    --	ET_DTL_ID             INT NOT NULL,
			    --	MAX_SEQ               SMALLINT NULL,
			    --	TIME_TYPE             CHAR(1) NOT NULL,
			    --	EDIT_FLAG             SMALLINT NOT NULL,
			    JOB_PROCESS_CONTRL    SMALLINT NULL,
			    ALLOW_EDIT            BIT NULL,
			    COMPARE_STRING        VARCHAR(4000)
		    );

		    --SET ORDER OF COLUMNS
		    IF @START_ON = 'Sunday'
		    BEGIN
			    ALTER TABLE #TIME_SHEET ADD [SUNDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [SUNDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [SUNDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [MONDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [MONDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [MONDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [TUESDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [TUESDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [TUESDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [WEDNESDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [WEDNESDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [WEDNESDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [THURSDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [THURSDAY_DATAKEY] VARCHAR(2000)
			    ALTER TABLE #TIME_SHEET ADD [THURSDAY_DATE] SMALLDATETIME NULL
    		   
			    ALTER TABLE #TIME_SHEET ADD [FRIDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [FRIDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [FRIDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [SATURDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [SATURDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [SATURDAY_DATE] SMALLDATETIME NULL
		    END

		    IF @START_ON = 'Monday'
		    BEGIN
			    ALTER TABLE #TIME_SHEET ADD [MONDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [MONDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [MONDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [TUESDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [TUESDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [TUESDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [WEDNESDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [WEDNESDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [WEDNESDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [THURSDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [THURSDAY_DATAKEY] VARCHAR(2000)
			    ALTER TABLE #TIME_SHEET ADD [THURSDAY_DATE] SMALLDATETIME NULL
    		   
			    ALTER TABLE #TIME_SHEET ADD [FRIDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [FRIDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [FRIDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [SATURDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [SATURDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [SATURDAY_DATE] SMALLDATETIME NULL
    		    
			    ALTER TABLE #TIME_SHEET ADD [SUNDAY] DECIMAL(9, 3) NULL
			    ALTER TABLE #TIME_SHEET ADD [SUNDAY_DATAKEY] VARCHAR(2000) NULL
			    ALTER TABLE #TIME_SHEET ADD [SUNDAY_DATE] SMALLDATETIME NULL
		    END
			    ALTER TABLE #TIME_SHEET ADD [LINE_TOTAL] DECIMAL(9, 3) NULL

		    /*
		    * loop through each row, 
		    * if cli,div,prd,prod_cat_code,fnc_cat,dp_tm_code doesn't exist, add it with the hours for this day.
		    * if it does exist, see if there are hours for that day, if yes, add it again
		    */
		    DECLARE @CURR_ROW_ID          AS INT,
				    @CURR_DATE            AS SMALLDATETIME,
				    @CURR_HOURS           AS DECIMAL(9, 3),
				    @CURR_START_TIME      AS SMALLDATETIME,
				    @CURR_END_TIME        AS SMALLDATETIME,
				    @CURR_DATA_KEY        AS VARCHAR(2000),
				    @CURR_COMPARE_STRING  AS VARCHAR  (4000),
				    @CURR_DAY_OF_WEEK                 AS INT

    		 
		    DECLARE MY_ROWS                           CURSOR  
		    FOR
			    SELECT ROW_ID
			    FROM   #TIME_ROWS WHERE PROCESSED IS NULL;


			    OPEN MY_ROWS;
				    FETCH NEXT FROM MY_ROWS INTO @CURR_ROW_ID;
		    WHILE @@FETCH_STATUS = 0
		    BEGIN
			    SELECT @CURR_DATE = EMP_DATE,
				       @CURR_COMPARE_STRING = COMPARE_STRING,
				       @CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, EMP_DATE),	--1 = sunday, 7 = saturday
				       @CURR_DATA_KEY = ISNULL(CAST(ET_ID AS VARCHAR), '') + '|' +
					       ISNULL(CAST(ET_DTL_ID AS VARCHAR), '') + '|' +
					       ISNULL(CAST(TIME_TYPE AS VARCHAR), '') + '|' +
					       ISNULL(CAST(EDIT_FLAG AS VARCHAR), '') + '|' +
					       ISNULL(CAST(MAX_SEQ AS VARCHAR), '')
			    FROM   #TIME_ROWS
			    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;

				    DECLARE @NEW_ROW_ID AS INT
				    DECLARE @THIS_ROW_ID AS INT
			    /**************************************************************/
			    --	IF THE LINE DOES EXIST, CHECK TO SEE IF THE SAME DATE HAS A TIME ALREADY, IF IT DOES, ADD NEW ROW.
			    --	IF THE DATE DOESN'T HAVE TIME (AND THE ROW DOES EXIST, UPDATE THE CORRECT TIME COLUMN)
			    IF @CURR_DAY_OF_WEEK = 1 -- SUNDAY
			    BEGIN
				    IF EXISTS (SELECT * FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.SUNDAY_DATE)))
					    BEGIN
						    SELECT @THIS_ROW_ID = ROW_ID FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.SUNDAY_DATE))
						    INSERT INTO #TIME_SHEET (CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, SUNDAY, SUNDAY_DATAKEY, SUNDAY_DATE)
						    SELECT CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, EMP_HOURS,@CURR_DATA_KEY,EMP_DATE
						    FROM   #TIME_ROWS
						    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
						    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
					    END
			    END
			    IF @CURR_DAY_OF_WEEK = 2 -- MONDAY
			    BEGIN
				    IF EXISTS (SELECT * FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.MONDAY_DATE)))
					    BEGIN
						    INSERT INTO #TIME_SHEET (CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, MONDAY, MONDAY_DATAKEY, MONDAY_DATE)
						    SELECT CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, EMP_HOURS,@CURR_DATA_KEY,EMP_DATE
						    FROM   #TIME_ROWS
						    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
						    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
					    END
			    END
			    IF @CURR_DAY_OF_WEEK = 3 -- TUESDAY
			    BEGIN
				    IF EXISTS (SELECT * FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.TUESDAY_DATE)))
					    BEGIN
						    INSERT INTO #TIME_SHEET (CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, TUESDAY, TUESDAY_DATAKEY, TUESDAY_DATE)
						    SELECT CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, EMP_HOURS,@CURR_DATA_KEY,EMP_DATE
						    FROM   #TIME_ROWS
						    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
						    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
					    END
			    END
			    IF @CURR_DAY_OF_WEEK = 4 -- WEDNESDAY
			    BEGIN
				    IF EXISTS (SELECT * FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.WEDNESDAY_DATE)))
					    BEGIN
						    INSERT INTO #TIME_SHEET (CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, WEDNESDAY, WEDNESDAY_DATAKEY, WEDNESDAY_DATE)
						    SELECT CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, EMP_HOURS,@CURR_DATA_KEY,EMP_DATE
						    FROM   #TIME_ROWS
						    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
						    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
					    END
			    END
			    IF @CURR_DAY_OF_WEEK = 5 -- THURSDAY
			    BEGIN
				    IF EXISTS (SELECT * FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.THURSDAY_DATE)))
					    BEGIN
						    INSERT INTO #TIME_SHEET (CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, THURSDAY, THURSDAY_DATAKEY, THURSDAY_DATE)
						    SELECT CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, EMP_HOURS,@CURR_DATA_KEY,EMP_DATE
						    FROM   #TIME_ROWS
						    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
						    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
					    END
			    END	
			    IF @CURR_DAY_OF_WEEK = 6 -- FRIDAY
			    BEGIN
				    IF EXISTS (SELECT * FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.FRIDAY_DATE)))
					    BEGIN
						    INSERT INTO #TIME_SHEET (CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, FRIDAY, FRIDAY_DATAKEY, FRIDAY_DATE)
						    SELECT CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, EMP_HOURS,@CURR_DATA_KEY,EMP_DATE
						    FROM   #TIME_ROWS
						    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
						    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
					    END
			    END	
			    IF @CURR_DAY_OF_WEEK = 7 -- SATURDAY
			    BEGIN
				    IF EXISTS (SELECT * FROM   #TIME_SHEET WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING AND (@CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, #TIME_SHEET.SATURDAY_DATE)))
					    BEGIN
						    INSERT INTO #TIME_SHEET (CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, SATURDAY, SATURDAY_DATAKEY, SATURDAY_DATE)
						    SELECT CL_CODE,DIV_CODE,PRD_CODE,JOB_NUMBER,JOB_COMPONENT_NBR,CLIENT_REF,FNC_CAT,DP_TM_CODE,PROD_CAT_CODE,COMPARE_STRING, EMP_HOURS,@CURR_DATA_KEY,EMP_DATE
						    FROM   #TIME_ROWS
						    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
						    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
					    END
			    END
			    /**************************************************************/
			    --IF THE LINE DOESN'T EXIST, ADD IT
			    IF NOT EXISTS (
				       SELECT *
				       FROM   #TIME_SHEET
				       WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
			       )
			    BEGIN
				    SET @NEW_ROW_ID = 0;
				    INSERT INTO #TIME_SHEET
				      (
					    CL_CODE,
					    DIV_CODE,
					    PRD_CODE,
					    JOB_NUMBER,
					    JOB_COMPONENT_NBR,
					    CLIENT_REF,
					    FNC_CAT,
					    DP_TM_CODE,
					    PROD_CAT_CODE,
					    COMPARE_STRING
				      )
				    SELECT CL_CODE,
					       DIV_CODE,
					       PRD_CODE,
					       JOB_NUMBER,
					       JOB_COMPONENT_NBR,
					       CLIENT_REF,
					       FNC_CAT,
					       DP_TM_CODE,
					       PROD_CAT_CODE,
					       COMPARE_STRING
				    FROM   #TIME_ROWS
				    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    SET @NEW_ROW_ID = @@IDENTITY;
    		        
				    IF @CURR_DAY_OF_WEEK = 1 -- SUNDAY
				    BEGIN
					    UPDATE #TIME_SHEET
					    SET    SUNDAY = EMP_HOURS,
						       SUNDAY_DATAKEY = @CURR_DATA_KEY,
						       SUNDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.ROW_ID = @NEW_ROW_ID
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    END
    		        
				    IF @CURR_DAY_OF_WEEK = 2 -- MONDAY
				    BEGIN
					    UPDATE #TIME_SHEET
					    SET    MONDAY = EMP_HOURS,
						       MONDAY_DATAKEY = @CURR_DATA_KEY,
						       MONDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.ROW_ID = @NEW_ROW_ID
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    END
    		        
				    IF @CURR_DAY_OF_WEEK = 3 -- TUESDAY
				    BEGIN
					    UPDATE #TIME_SHEET
					    SET    TUESDAY = EMP_HOURS,
						       TUESDAY_DATAKEY = @CURR_DATA_KEY,
						       TUESDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.ROW_ID = @NEW_ROW_ID
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    END
    		        
				    IF @CURR_DAY_OF_WEEK = 4 -- WEDNESDAY
				    BEGIN
					    UPDATE #TIME_SHEET
					    SET    WEDNESDAY = EMP_HOURS,
						       WEDNESDAY_DATAKEY = @CURR_DATA_KEY,
						       WEDNESDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.ROW_ID = @NEW_ROW_ID
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    END
    		        
				    IF @CURR_DAY_OF_WEEK = 5 -- THURSDAY
				    BEGIN
					    UPDATE #TIME_SHEET
					    SET    THURSDAY = EMP_HOURS,
						       THURSDAY_DATAKEY = @CURR_DATA_KEY,
						       THURSDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.ROW_ID = @NEW_ROW_ID
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    END
    		        
				    IF @CURR_DAY_OF_WEEK = 6 -- FRIDAY
				    BEGIN
					    UPDATE #TIME_SHEET
					    SET    FRIDAY = EMP_HOURS,
						       FRIDAY_DATAKEY = @CURR_DATA_KEY,
						       FRIDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.ROW_ID = @NEW_ROW_ID
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    END
    		        
				    IF @CURR_DAY_OF_WEEK = 7 -- SATURDAY
				    BEGIN
					    UPDATE #TIME_SHEET
					    SET    SATURDAY = EMP_HOURS,
						       SATURDAY_DATAKEY = @CURR_DATA_KEY,
						       SATURDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.ROW_ID = @NEW_ROW_ID
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    END
				    --mark as processed
 				    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
			    END
    		    
			    FETCH NEXT FROM MY_ROWS INTO @CURR_ROW_ID;
		    END
			    CLOSE MY_ROWS;
			    DEALLOCATE MY_ROWS;
		    DECLARE MY_ROWS2                           CURSOR  
		    FOR
			    SELECT ROW_ID
			    FROM   #TIME_ROWS WHERE PROCESSED IS NULL;

			    OPEN MY_ROWS2;
				    FETCH NEXT FROM MY_ROWS2 INTO @CURR_ROW_ID;
		    WHILE @@FETCH_STATUS = 0
		    BEGIN
			    SELECT @CURR_DATE = EMP_DATE,
				       @CURR_COMPARE_STRING = COMPARE_STRING,
				       @CURR_DAY_OF_WEEK = DATEPART(WEEKDAY, EMP_DATE),	--1 = sunday, 7 = saturday
				       @CURR_DATA_KEY = ISNULL(CAST(ET_ID AS VARCHAR), '') + '|' +
				       ISNULL(CAST(ET_DTL_ID AS VARCHAR), '') + '|' +
				       ISNULL(CAST(TIME_TYPE AS VARCHAR), '') + '|' +
				       ISNULL(CAST(EDIT_FLAG AS VARCHAR), '') + '|' +
				       ISNULL(CAST(MAX_SEQ AS VARCHAR), '')
			    FROM   #TIME_ROWS
			    WHERE  #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
				    DECLARE @ROW_TO_UPDATE AS INT
				    SELECT @ROW_TO_UPDATE = MIN(ROW_ID) FROM #TIME_SHEET WHERE #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING;
				    IF @CURR_DAY_OF_WEEK = 1 -- SUNDAY
				    BEGIN
					    --UPDATE THE ROW
					    UPDATE #TIME_SHEET
					    SET    SUNDAY = EMP_HOURS,
						       SUNDAY_DATAKEY = @CURR_DATA_KEY,
						       SUNDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID
						       AND #TIME_SHEET.ROW_ID = @ROW_TO_UPDATE;
				    END
				    IF @CURR_DAY_OF_WEEK = 2 -- MONDAY
				    BEGIN
					    --UPDATE THE ROW
					    UPDATE #TIME_SHEET
					    SET    MONDAY = EMP_HOURS,
						       MONDAY_DATAKEY = @CURR_DATA_KEY,
						       MONDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID
						       AND #TIME_SHEET.ROW_ID = @ROW_TO_UPDATE;
				    END
				    IF @CURR_DAY_OF_WEEK = 3 -- TUESDAY
				    BEGIN
					    --UPDATE THE ROW
					    UPDATE #TIME_SHEET
					    SET    TUESDAY = EMP_HOURS,
						       TUESDAY_DATAKEY = @CURR_DATA_KEY,
						       TUESDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID
						       AND #TIME_SHEET.ROW_ID = @ROW_TO_UPDATE;
				    END
				    IF @CURR_DAY_OF_WEEK = 4 -- WEDNESDAY
				    BEGIN
					    --UPDATE THE ROW
					    UPDATE #TIME_SHEET
					    SET    WEDNESDAY = EMP_HOURS,
						       WEDNESDAY_DATAKEY = @CURR_DATA_KEY,
						       WEDNESDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID
						       AND #TIME_SHEET.ROW_ID = @ROW_TO_UPDATE;
				    END		
				    IF @CURR_DAY_OF_WEEK = 5 -- THURSDAY
				    BEGIN
					    --UPDATE THE ROW
					    UPDATE #TIME_SHEET
					    SET    THURSDAY = EMP_HOURS,
						       THURSDAY_DATAKEY = @CURR_DATA_KEY,
						       THURSDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID
						       AND #TIME_SHEET.ROW_ID = @ROW_TO_UPDATE;
				    END
				    IF @CURR_DAY_OF_WEEK = 6 -- FRIDAY
				    BEGIN
					    --UPDATE THE ROW
					    UPDATE #TIME_SHEET
					    SET    FRIDAY = EMP_HOURS,
						       FRIDAY_DATAKEY = @CURR_DATA_KEY,
						       FRIDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID
						       AND #TIME_SHEET.ROW_ID = @ROW_TO_UPDATE;
				    END
				    IF @CURR_DAY_OF_WEEK = 7 -- SATURDAY
				    BEGIN
					    --UPDATE THE ROW
					    UPDATE #TIME_SHEET
					    SET    SATURDAY = EMP_HOURS,
						       SATURDAY_DATAKEY = @CURR_DATA_KEY,
						       SATURDAY_DATE = EMP_DATE
					    FROM   #TIME_ROWS,
						       #TIME_SHEET
					    WHERE  #TIME_SHEET.COMPARE_STRING = @CURR_COMPARE_STRING
						       AND #TIME_ROWS.ROW_ID = @CURR_ROW_ID
						       AND #TIME_SHEET.ROW_ID = @ROW_TO_UPDATE;
				    END
				    --mark as processed
 				    UPDATE #TIME_ROWS SET PROCESSED = 1 WHERE #TIME_ROWS.ROW_ID = @CURR_ROW_ID;
			    FETCH NEXT FROM MY_ROWS2 INTO @CURR_ROW_ID;
		    END
			    CLOSE MY_ROWS2;
			    DEALLOCATE MY_ROWS2;
    		    

		    --UPDATE THE DISPLAY ITEMS:
		    UPDATE #TIME_SHEET
		    SET    #TIME_SHEET.CL_NAME = CLIENT.CL_NAME,
				    #TIME_SHEET.DIV_NAME = DIVISION.DIV_NAME,
				    #TIME_SHEET.PRD_DESCRIPTION = PRODUCT.PRD_DESCRIPTION,
				    #TIME_SHEET.JOB_DESC = JOB_LOG.JOB_DESC,
				    #TIME_SHEET.JOB_COMP_DESC = JOB_COMPONENT.JOB_COMP_DESC,
				    #TIME_SHEET.JOB_PROCESS_CONTRL = JOB_COMPONENT.JOB_PROCESS_CONTRL,
				    #TIME_SHEET.JOB_DISPLAY = ISNULL(LTRIM(STR(JOB_LOG.JOB_NUMBER)), '') + ' - ' + ISNULL(JOB_LOG.JOB_DESC, ''),
				    #TIME_SHEET.JOB_COMP_DISPLAY = ISNULL(LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)), '') + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') ,
				    #TIME_SHEET.JOB_AND_COMP_DISPLAY = [dbo].[wvfn_display_job_and_comp](#TIME_SHEET.JOB_NUMBER, #TIME_SHEET.JOB_COMPONENT_NBR)
		    FROM   CLIENT WITH(NOLOCK)
			       RIGHT OUTER JOIN DIVISION WITH(NOLOCK)
			       RIGHT OUTER JOIN PRODUCT WITH(NOLOCK)
			       RIGHT OUTER JOIN JOB_LOG WITH(NOLOCK)
			       RIGHT OUTER JOIN #TIME_SHEET WITH(NOLOCK)
			       LEFT OUTER JOIN JOB_COMPONENT WITH(NOLOCK)
					    ON  #TIME_SHEET.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
						    AND #TIME_SHEET.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
					    ON  JOB_LOG.JOB_NUMBER = #TIME_SHEET.JOB_NUMBER
					    ON  PRODUCT.CL_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = #TIME_SHEET.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
						    AND PRODUCT.DIV_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = #TIME_SHEET.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
						    AND PRODUCT.PRD_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = #TIME_SHEET.PRD_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
					    ON  DIVISION.CL_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = #TIME_SHEET.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
						    AND DIVISION.DIV_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = #TIME_SHEET.DIV_CODE COLLATE SQL_Latin1_General_CP1_CS_AS 
					    ON  CLIENT.CL_CODE  COLLATE SQL_Latin1_General_CP1_CS_AS = #TIME_SHEET.CL_CODE COLLATE SQL_Latin1_General_CP1_CS_AS ;

		    UPDATE #TIME_SHEET SET SUNDAY_DATE = (SELECT TOP 1 SUNDAY_DATE FROM #TIME_SHEET WHERE (NOT SUNDAY_DATE IS NULL)) WHERE SUNDAY_DATE IS NULL;
		    UPDATE #TIME_SHEET SET MONDAY_DATE = (SELECT TOP 1 MONDAY_DATE FROM #TIME_SHEET WHERE (NOT MONDAY_DATE IS NULL)) WHERE MONDAY_DATE IS NULL;
		    UPDATE #TIME_SHEET SET TUESDAY_DATE = (SELECT TOP 1 TUESDAY_DATE FROM #TIME_SHEET WHERE (NOT TUESDAY_DATE IS NULL)) WHERE TUESDAY_DATE IS NULL;
		    UPDATE #TIME_SHEET SET WEDNESDAY_DATE = (SELECT TOP 1 WEDNESDAY_DATE FROM #TIME_SHEET WHERE (NOT WEDNESDAY_DATE IS NULL)) WHERE WEDNESDAY_DATE IS NULL;
		    UPDATE #TIME_SHEET SET THURSDAY_DATE = (SELECT TOP 1 THURSDAY_DATE FROM #TIME_SHEET WHERE (NOT THURSDAY_DATE IS NULL)) WHERE THURSDAY_DATE IS NULL;
		    UPDATE #TIME_SHEET SET FRIDAY_DATE = (SELECT TOP 1 FRIDAY_DATE FROM #TIME_SHEET WHERE (NOT FRIDAY_DATE IS NULL)) WHERE FRIDAY_DATE IS NULL;
		    UPDATE #TIME_SHEET SET SATURDAY_DATE = (SELECT TOP 1 SATURDAY_DATE FROM #TIME_SHEET WHERE (NOT SATURDAY_DATE IS NULL)) WHERE SATURDAY_DATE IS NULL;

		    --UPDATE ROW TOTALS
		    UPDATE #TIME_SHEET SET LINE_TOTAL = ISNULL(SUNDAY,00.000) + ISNULL(MONDAY,00.000) + ISNULL(TUESDAY,00.000) + ISNULL(WEDNESDAY,00.000) + ISNULL(THURSDAY,00.000) + ISNULL(FRIDAY,00.000) + ISNULL(SATURDAY,00.000);

		    --	--KEYS
		    --	ET_ID |
		    --	ET_DTL_ID |
		    --	MAX_SEQ |
		    --	TIME_TYPE |
		    --	EDIT_FLAG

		    DECLARE @SORT_SQL AS VARCHAR(8000);
		    SET @SORT_SQL = 'SELECT * FROM #TIME_SHEET'

		    IF RTRIM(LTRIM(@SortColumn)) = 'JOB_NUMBER'
		    BEGIN
			    SET @SORT_SQL = @SORT_SQL + ' ORDER BY JOB_NUMBER, JOB_COMPONENT_NBR, DP_TM_CODE, FNC_CAT, PROD_CAT_CODE;'
		    END
		    IF RTRIM(LTRIM(@SortColumn)) = 'CL_CODE'
		    BEGIN
			    SET @SORT_SQL = @SORT_SQL + ' ORDER BY CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR;'
		    END
		    IF RTRIM(LTRIM(@SortColumn)) = 'DIV_CODE'
		    BEGIN
			    SET @SORT_SQL = @SORT_SQL + ' ORDER BY DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR;'
		    END
		    IF RTRIM(LTRIM(@SortColumn)) = 'PRD_CODE'
		    BEGIN
			    SET @SORT_SQL = @SORT_SQL + ' ORDER BY PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR;'
		    END
		    IF RTRIM(LTRIM(@SortColumn)) = 'FNC_CAT'
		    BEGIN
			    SET @SORT_SQL = @SORT_SQL + ' ORDER BY FNC_CAT, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, DP_TM_CODE, PROD_CAT_CODE;'
		    END
		    IF RTRIM(LTRIM(@SortColumn)) = 'DP_TM_CODE'
		    BEGIN
			    SET @SORT_SQL = @SORT_SQL + ' ORDER BY DP_TM_CODE, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CAT, PROD_CAT_CODE;'
		    END
		    IF RTRIM(LTRIM(@SortColumn)) = 'EMP_DATE'
		    BEGIN
			    SET @SORT_SQL = @SORT_SQL + ' ORDER BY SUNDAY_DATE, CL_CODE, DIV_CODE, PRD_CODE, JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CAT, PROD_CAT_CODE;'
		    END

		    EXEC(@SORT_SQL);
		    DROP TABLE #TIME_ROWS;
		    DROP TABLE #TIME_SHEET;


    END
/*=========== QUERY ===========*/
