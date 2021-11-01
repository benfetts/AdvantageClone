/* BJL 060625 - Commented out PK_TIME_ROWS, per Scott */
/* BJL 060625 - Fixed dept/team in last SELECT */
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_ts_GetTimeSheetPrint]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_ts_GetTimeSheetPrint]
GO

CREATE PROCEDURE [dbo].[usp_wv_ts_GetTimeSheetPrint]
@emp_code varchar(6), 
@StartDate smalldatetime,
@EndDate smalldatetime,
--ST: Added this to sort:
@SortColumn varchar(35),
@USER_CODE VARCHAR(100)
AS
/*=========== QUERY ===========*/
DECLARE @RESTRICTED                   INT,
        @RESTRICTED_TO_OWN_TIMESHEET  VARCHAR(1)

	DECLARE @SEC_USER_ID int

SELECT @RESTRICTED = COUNT(1)
FROM   SEC_EMP WITH(NOLOCK)
WHERE  UPPER(SEC_EMP.[USER_ID]) = UPPER(@USER_CODE);
SET @RESTRICTED = ISNULL(@RESTRICTED, 0);

	SELECT 
		@SEC_USER_ID = SEC_USER_ID
	FROM 
		[dbo].[SEC_USER]
	WHERE 
		UPPER(EMP_CODE) = UPPER(@USER_CODE)

	IF EXISTS(SELECT * FROM [dbo].[SEC_USER_SETTING] WHERE SEC_USER_ID = @SEC_USER_ID AND SETTING_CODE = 'SI_DO_OWN_TS' AND STRING_VALUE = 'Y') BEGIN

		SET @RESTRICTED_TO_OWN_TIMESHEET = 'Y'

	END	ELSE BEGIN

		SET @RESTRICTED_TO_OWN_TIMESHEET = 'N'

	END

--IF UPPER(@RESTRICTED_TO_OWN_TIMESHEET) = 'Y'
--BEGIN
--    SET @emp_code = NULL;
--END

/* Temporary table to store returned rows */
CREATE TABLE #time_rows( 	
	ET_ID				int NOT NULL,
	ET_DTL_ID			int NOT NULL,
	FNC_CAT				varchar(10) NULL,
	EMP_HOURS			decimal(9,3) NOT NULL,
	CL_CODE				varchar(6) NULL,
	DIV_CODE			varchar(6) NULL,
	PRD_CODE			varchar(6) NULL,
	JOB_NUMBER			int NULL,
	CLIENT_REF			varchar(30) NULL,
	JOB_COMPONENT_NBR		smallint NULL,
	DP_TM_CODE			varchar(4) NULL,
	TIME_TYPE			char(1) NOT NULL,
	EDIT_FLAG			smallint NOT NULL,
	MAX_SEQ				smallint NULL,
	START_TIME			char(4) NULL,
	END_TIME			char(4) NULL,
	EMP_DATE			SmallDateTime, 
	COMMENTS			Text NULL,
	PROD_CAT_CODE		VARCHAR(10) NULL)


/* ALTER TABLE [dbo].[#time_rows] WITH NOCHECK ADD 
	CONSTRAINT [PK_time_rows] PRIMARY KEY  CLUSTERED 
	(
		[ET_ID], [ET_DTL_ID]
	)  ON [PRIMARY] */


IF @RESTRICTED = 0
BEGIN
    INSERT INTO #time_rows
    SELECT EMP_TIME_DTL.ET_ID,
           EMP_TIME_DTL.ET_DTL_ID,
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
           EMP_TIME_DTL.PROD_CAT_CODE
    FROM   EMP_TIME WITH (NOLOCK)
           INNER JOIN EMP_TIME_DTL WITH (NOLOCK)
                ON  EMP_TIME.ET_ID = EMP_TIME_DTL.ET_ID
    WHERE  EMP_TIME.EMP_CODE = @emp_code
           AND EMP_TIME.EMP_DATE >= @StartDate
           AND EMP_TIME.EMP_DATE <= @EndDate
		   AND (EMP_TIME_DTL.EDIT_FLAG = 0 OR EMP_TIME_DTL.EDIT_FLAG IS NULL)
    GROUP BY
           EMP_TIME_DTL.ET_ID,
           EMP_TIME_DTL.ET_DTL_ID,
           EMP_DATE,
           EMP_TIME_DTL.PROD_CAT_CODE
END
ELSE
BEGIN
    INSERT INTO #time_rows
    SELECT EMP_TIME_DTL.ET_ID,
           EMP_TIME_DTL.ET_DTL_ID,
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
           EMP_TIME_DTL.PROD_CAT_CODE
    FROM   EMP_TIME WITH (NOLOCK)
           INNER JOIN EMP_TIME_DTL WITH (NOLOCK)
                ON  EMP_TIME.ET_ID = EMP_TIME_DTL.ET_ID
           INNER JOIN [dbo].[advtf_sec_emp] (@USER_CODE) AS SEC_EMP
                ON  EMP_TIME.EMP_CODE = SEC_EMP.EMP_CODE
    WHERE  (EMP_TIME.EMP_CODE = @emp_code)
           AND (EMP_TIME.EMP_DATE >= @StartDate)
           AND (EMP_TIME.EMP_DATE <= @EndDate)
           AND SEC_EMP.EMP_CODE = @emp_code
		   AND (EMP_TIME_DTL.EDIT_FLAG = 0 OR EMP_TIME_DTL.EDIT_FLAG IS NULL)
    GROUP BY
           EMP_TIME_DTL.ET_ID,
           EMP_TIME_DTL.ET_DTL_ID,
           EMP_TIME.EMP_DATE,
           EMP_TIME_DTL.PROD_CAT_CODE
END


UPDATE #time_rows
   SET FNC_CAT = etd.FNC_CODE,
       CL_CODE = jl.CL_CODE, 
       DIV_CODE = jl.DIV_CODE, 
       PRD_CODE = jl.PRD_CODE,
       CLIENT_REF = jl.JOB_CLI_REF,
       JOB_NUMBER = etd.JOB_NUMBER,
       JOB_COMPONENT_NBR = etd.JOB_COMPONENT_NBR,
       DP_TM_CODE = etd.DP_TM_CODE
  FROM EMP_TIME_DTL AS etd WITH (NOLOCK), JOB_LOG AS jl WITH (NOLOCK), #time_rows tr
 WHERE tr.ET_ID = etd.ET_ID 
   AND tr.ET_DTL_ID = etd.ET_DTL_ID
   AND tr.MAX_SEQ = etd.SEQ_NBR
   AND etd.JOB_NUMBER = jl.JOB_NUMBER

INSERT INTO #time_rows
     SELECT etn.ET_ID, etn.ET_DTL_ID, CATEGORY, SUM(EMP_HOURS), NULL, NULL, NULL, NULL, NULL, NULL, 
	    	DP_TM_CODE, 'N', 0, NULL, NULL, NULL, EMP_DATE, NULL,NULL
       FROM EMP_TIME_NP AS etn WITH (NOLOCK), EMP_TIME AS et WITH (NOLOCK)
      WHERE et.ET_ID = etn.ET_ID
	AND EMP_CODE = @emp_code
	AND EMP_DATE >= @StartDate
	AND EMP_DATE <= @EndDate
   GROUP BY etn.ET_ID, etn.ET_DTL_ID, CATEGORY, DP_TM_CODE, EMP_DATE

--Get Comments
UPDATE #time_rows
SET COMMENTS = ct.EMP_COMMENT
FROM EMP_TIME_DTL_CMTS AS ct WITH (NOLOCK), #time_rows tr
WHERE tr.ET_ID = ct.ET_ID
AND tr.ET_DTL_ID = ct.ET_DTL_ID

-- BJL - 11/23/03
UPDATE #time_rows
   SET START_TIME = etdc.START_TIME,
       END_TIME = etdc.END_TIME
  FROM EMP_TIME_DTL_CMTS AS etdc WITH (NOLOCK), #time_rows tr
 WHERE tr.ET_ID = etdc.ET_ID 
   AND tr.ET_DTL_ID = etdc.ET_DTL_ID

-- Determine if rows have been billed
UPDATE #time_rows
   SET EDIT_FLAG = 1
 WHERE EXISTS ( SELECT etd.AR_INV_NBR  
		  FROM EMP_TIME_DTL AS etd WITH (NOLOCK)
		 WHERE etd.ET_ID = #time_rows.ET_ID
		   AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
		   AND etd.AR_INV_NBR IS NOT NULL
		   AND (etd.EDIT_FLAG = 0 OR etd.EDIT_FLAG IS NULL))

-- Determine if item is summarized
UPDATE #time_rows
   SET EDIT_FLAG = 2
 WHERE EDIT_FLAG = 1
   AND ( SELECT COUNT(1)
	   FROM EMP_TIME_DTL AS etd WITH (NOLOCK)
	  WHERE etd.ET_ID = #time_rows.ET_ID
	    AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID ) > 1
	
-- Determine if item is a restricted AB flag
UPDATE #time_rows
   SET EDIT_FLAG = 3
 WHERE EDIT_FLAG = 0
   AND EXISTS ( SELECT AB_FLAG
		  FROM EMP_TIME_DTL AS etd WITH (NOLOCK)
		 WHERE etd.ET_ID = #time_rows.ET_ID
		   AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
		   AND etd.AB_FLAG IN (1,3) )

-- Determine if item is selected for billing
UPDATE #time_rows
   SET EDIT_FLAG = 4
 WHERE EDIT_FLAG = 0
   AND EXISTS ( SELECT BILLING_USER
		  FROM EMP_TIME_DTL AS etd WITH (NOLOCK)
		 WHERE etd.ET_ID = #time_rows.ET_ID
		   AND etd.ET_DTL_ID = #time_rows.ET_DTL_ID
		   AND BILLING_USER IS NOT NULL )

-- BJL - 11/23/03
-- Check if row has been approved
UPDATE #time_rows
   SET EDIT_FLAG = 6
 WHERE EDIT_FLAG = 0

   AND EXISTS ( SELECT ET_ID
		  		  FROM EMP_TIME AS et WITH (NOLOCK)

		 		 WHERE et.ET_ID = #time_rows.ET_ID
		   		   AND APPR_FLAG = 1 )
   AND EXISTS ( SELECT * FROM AGENCY WITH (NOLOCK) WHERE TIME_APPR_ACTIVE = 1 )

-- BJL - 11/23/03
-- Check if row is pending approval
UPDATE #time_rows
   SET EDIT_FLAG = 5
 WHERE EDIT_FLAG = 0
   AND EXISTS ( SELECT ET_ID
		  		  FROM EMP_TIME AS et WITH (NOLOCK)
		 		 WHERE et.ET_ID = #time_rows.ET_ID
		   		   AND APPR_PENDING = 1 )
   AND EXISTS ( SELECT * FROM AGENCY WITH (NOLOCK) WHERE TIME_APPR_ACTIVE = 1 )

end_tran:

SELECT 
	/*
 ST: the  remmed out section is what was in the DB, the select star is what I found in the sourcesafe file

	#time_rows.ET_ID,
	#time_rows.ET_DTL_ID,
	#time_rows.FNC_CAT,
	#time_rows.EMP_HOURS,
	#time_rows.CL_CODE,
	#time_rows.DIV_CODE,
	#time_rows.PRD_CODE,
	#time_rows.JOB_NUMBER,
	#time_rows.CLIENT_REF,
	#time_rows.JOB_COMPONENT_NBR,
	--ST 20060605:
	--ISNULL(#time_rows.DP_TM_CODE,(SELECT DP_TM_CODE FROM EMP_DP_TM WHERE EMP_CODE LIKE @emp_code+'%') )AS  DP_TM_CODE,
	ISNULL(#time_rows.DP_TM_CODE,#time_rows.FNC_CAT) AS DP_TM_CODE,
	#time_rows.TIME_TYPE,
	#time_rows.EDIT_FLAG,
	#time_rows.MAX_SEQ,
	#time_rows.START_TIME,
	#time_rows.END_TIME,
	#time_rows.EMP_DATE, 
	#time_rows.COMMENTS,	
	ltrim(str(#time_rows.JOB_NUMBER)) + ' - ' + JOB_LOG.JOB_DESC as JOB_DESC, 
	ltrim(str(#time_rows.JOB_COMPONENT_NBR)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC as JOB_COMP_DESC
	*/
	/*
	#time_rows.*
	*/

 	ISNULL(#time_rows.ET_ID,'')  AS ET_ID,				--0
	ISNULL(#time_rows.ET_DTL_ID,'')  AS ET_DTL_ID,		
	ISNULL(#time_rows.FNC_CAT,'') AS FNC_CAT,				
	ISNULL(#time_rows.EMP_HOURS,'')  AS EMP_HOURS,		
	ISNULL(#time_rows.CL_CODE,'')  AS CL_CODE,			
	ISNULL(#time_rows.DIV_CODE,'')  AS DIV_CODE,			
	ISNULL(#time_rows.PRD_CODE,'')  AS PRD_CODE,			
	ISNULL(#time_rows.JOB_NUMBER,'')  AS JOB_NUMBER,			
	ISNULL(#time_rows.CLIENT_REF,'')  AS CLIENT_REF,			
	ISNULL(#time_rows.JOB_COMPONENT_NBR,'')  AS JOB_COMPONENT_NBR,	
	ISNULL(#time_rows.DP_TM_CODE,'') AS DP_TM_CODE,		--10
	--ISNULL(#time_rows.DP_TM_CODE,(SELECT DP_TM_CODE FROM EMP_DP_TM WHERE EMP_CODE LIKE @emp_code+'%') ) AS  DP_TM_CODE,
	ISNULL(#time_rows.TIME_TYPE,'') AS TIME_TYPE,			
	ISNULL(#time_rows.EDIT_FLAG,'')  AS EDIT_FLAG ,			
	ISNULL(#time_rows.MAX_SEQ,'')  AS MAX_SEQ,				
	ISNULL(#time_rows.START_TIME,'')  AS START_TIME,			
	ISNULL(#time_rows.END_TIME,'')  AS END_TIME ,			
	ISNULL(#time_rows.EMP_DATE,'')  AS EMP_DATE ,			 
	ISNULL(#time_rows.COMMENTS,'')  AS COMMENTS ,
	--ST 20060607: Added this below to fix the timesheet not showing job and jobcomp number
	-- there are some duplicated fields getting returned.
	-- I didn't want to change anything...only want to add...because I don't know if it will break somewhere else if I start changing

	ISNULL(ltrim(str(#time_rows.JOB_NUMBER)),'-')  AS Job,
	ISNULL(JOB_LOG.JOB_DESC,'')  AS JobDesc,
	ISNULL(ltrim(str(#time_rows.JOB_COMPONENT_NBR)),'-') AS JobComp,--20
	--ISNULL(JOB_COMPONENT.JOB_COMP_DESC,'') AS JobCompDesc,
		

	CASE
	WHEN JOB_COMPONENT.JOB_PROCESS_CONTRL IN (12,10,9,6,5,3,2) THEN
	'<span class="warning">'  + ISNULL(JOB_COMPONENT.JOB_COMP_DESC,'') + '</span>'
	ELSE 
	ISNULL(JOB_COMPONENT.JOB_COMP_DESC,'')	
	END   AS JobCompDesc,
	
		---------------------
		
	ISNULL(ltrim(str(#time_rows.JOB_NUMBER)),'') + ' - ' + ISNULL(JOB_LOG.JOB_DESC,'') AS  JOB_DESC, 
	ISNULL(ltrim(str(#time_rows.JOB_COMPONENT_NBR)),'') + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC,'') AS  JOB_COMP_DESC,
	ISNULL(#time_rows.PROD_CAT_CODE,'') AS PROD_CAT_CODE,
	ISNULL(CLIENT.CL_NAME,'') AS CL_NAME, ISNULL(DIVISION.DIV_NAME,'') AS DIV_NAME, ISNULL(PRODUCT.PRD_DESCRIPTION,'') AS PRD_DESCRIPTION
	

	
FROM #time_rows
	Left Outer Join JOB_LOG WITH (NOLOCK) 
		on #time_rows.JOB_NUMBER = JOB_LOG.JOB_NUMBER
	Left Outer Join JOB_COMPONENT WITH (NOLOCK) 
		on #time_rows.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
		and #time_rows.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR
		/* added for tooltip */
	LEFT OUTER JOIN
		PRODUCT WITH (NOLOCK)  ON #time_rows.CL_CODE collate database_default = PRODUCT.CL_CODE collate database_default 
		AND #time_rows.DIV_CODE collate database_default = PRODUCT.DIV_CODE collate database_default 
		AND #time_rows.PRD_CODE collate database_default = PRODUCT.PRD_CODE collate database_default 
	LEFT OUTER JOIN
		DIVISION WITH (NOLOCK)  ON #time_rows.CL_CODE collate database_default = DIVISION.CL_CODE collate database_default 
		AND #time_rows.DIV_CODE collate database_default = DIVISION.DIV_CODE collate database_default 
	LEFT OUTER JOIN
		CLIENT WITH (NOLOCK)  ON #time_rows.CL_CODE collate database_default = CLIENT.CL_CODE collate database_default 
WHERE #time_rows.EMP_HOURS <> 0	
ORDER BY #time_rows.EMP_DATE, #time_rows.JOB_NUMBER, #time_rows.JOB_COMPONENT_NBR, #time_rows.FNC_CAT, #time_rows.DP_TM_CODE, 
		#time_rows.ET_DTL_ID		
	

DROP TABLE #time_rows







