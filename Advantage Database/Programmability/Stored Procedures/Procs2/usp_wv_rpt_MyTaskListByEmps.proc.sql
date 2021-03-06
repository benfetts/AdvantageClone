if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_rpt_MyTaskListByEmps]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_rpt_MyTaskListByEmps]
GO
--Webvantage
CREATE PROCEDURE [dbo].[usp_wv_rpt_MyTaskListByEmps] 
@UserID VarChar(100),
@EmpCodes VarChar(4000),
@ClientCodes VarChar(4000),
@OfficeCodes VarChar(4000),
--@JobNumber VarChar(6),
@SortOrder VarChar(1),
@StartDate smallDateTime,
@EndDate smallDateTime,
@Completed smallDateTime,
@Manager VarChar(6),
@AECodes VarChar(4000)

AS



Declare @Restrictions Int,
		@sql nvarchar(MAX),
		@sql2 nvarchar(MAX),
		@paramlist nvarchar(MAX),
		@paramlist2 nvarchar(MAX), @NumberRecords int, @RowCount int, @job int, @comp int, @seq int, @count int

		
Select @Restrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID);
--	[]           VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER

SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE

CREATE TABLE #MY_DATA --MASTER TABLE TO RETURN
(
	RowID int IDENTITY(1, 1), 
	[SubHead]           VARCHAR(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[Program]           VARCHAR(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[DCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[DName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[PCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[PName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[JobNum]			INT NULL,
	[JobDesc]           VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CompNum]		SMALLINT NULL,
	[CompDesc]       VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[Task]          VARCHAR(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[HoursAllowed]  DECIMAL(18,2) NULL,
	[Due Date]     SMALLDATETIME,
	[Rev Due Date]     SMALLDATETIME,
	[Completed Date]     SMALLDATETIME,
	[Comments]          VARCHAR(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[Emp]           VARCHAR(4000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[JTComments]           VARCHAR(MAX) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CDP]           VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[JBNUM]           VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[SEQ_NBR]			INT NULL,
	[TEMP_COMP] VARCHAR(5) NULL,
	[DueTime] VARCHAR(1000) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[IS_EVENT_TASK] SMALLINT NULL,
	[JOB_ORDER] INT NULL,
	[FNC_CODE] VARCHAR(10) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[FNC_DESC] VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[TRAFFIC_PHASE_ID] INT NULL,
	[TRAFFIC_PHASE_DESC] VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[HAS_CHILDREN] BIT
)	


SELECT @sql = 'INSERT INTO #MY_DATA SELECT  
				'''' as SubHead,
				'''' as Program, 
				JOB_LOG.CL_CODE as CCode,
				CLIENT.CL_NAME as CName,
				JOB_LOG.DIV_CODE as DCode,
				DIVISION.DIV_NAME as DName,
				JOB_LOG.PRD_CODE as PCode,
				PRODUCT.PRD_DESCRIPTION as PName,
				JOB_LOG.JOB_NUMBER as JobNum,
				JOB_LOG.JOB_DESC as JobDesc,				
				JOB_COMPONENT.JOB_COMPONENT_NBR as CompNum,
				JOB_COMPONENT.JOB_COMP_DESC as CompDesc,				
				 isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') + '' ('' + isnull(V_JOB_TRAFFIC_DET.FNC_CODE, '''') + '')'' as Task,
				SUM(V_JOB_TRAFFIC_DET.JOB_HRS) as [HoursAllowed],
				 CONVERT(CHAR(10), V_JOB_TRAFFIC_DET.JOB_DUE_DATE, 101) as [Due Date],
				CONVERT(CHAR(10), V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101) as [Rev Due Date],
				CONVERT(CHAR(10), V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) as [Completed Date],
				'''' as Comments,
				'''' as Emp,
				'''' as JTComments,
				CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP,
				CONVERT(VARCHAR(10),JOB_LOG.JOB_NUMBER) + ''-'' + JOB_LOG.JOB_DESC + ''-'' + CONVERT(CHAR(2),JOB_COMPONENT.JOB_COMPONENT_NBR) + ''-'' + JOB_COMPONENT.JOB_COMP_DESC AS JBNUM, V_JOB_TRAFFIC_DET.SEQ_NBR,
				'''' AS ''TEMP_COMP'',
				isnull(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME,'''') as DueTime, 0 AS IS_EVENT_TASK,
				ISNULL(V_JOB_TRAFFIC_DET.JOB_ORDER,-1) AS JOB_ORDER, 
				ISNULL(V_JOB_TRAFFIC_DET.FNC_CODE,'''') AS FNC_CODE,
				isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, ''''), V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID, TP.PHASE_DESC,0
			FROM JOB_LOG
			INNER JOIN CLIENT
				ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
			INNER JOIN DIVISION
				ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
				AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
			INNER JOIN PRODUCT
				ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
				AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
				AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
			INNER JOIN JOB_COMPONENT
				ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
			INNER JOIN JOB_TRAFFIC
					ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER
					AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
			INNER JOIN V_JOB_TRAFFIC_DET
				ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
				AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			LEFT OUTER JOIN EMPLOYEE
				ON V_JOB_TRAFFIC_DET.EMP_CODE = EMPLOYEE.EMP_CODE LEFT OUTER JOIN TRAFFIC_PHASE TP ON TP.TRAFFIC_PHASE_ID = V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID'
			if @ClientCodes<>'%' 
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@ClientCodes, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
				End
			if @OfficeCodes<>'%' 
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@OfficeCodes, DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
				End 
			if @EmpCodes<>'%' 
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@EmpCodes, DEFAULT) e ON V_JOB_TRAFFIC_DET.EMP_CODE = e.vstr collate database_default'
				End
				
			if @AECodes<>'%' 
				Begin
					SELECT @sql = @sql + ' INNER JOIN charlist_to_table(@AECodes, DEFAULT) f ON JOB_COMPONENT.EMP_CODE = f.vstr collate database_default'
				End 
				
			If @Restrictions > 0
				Begin		
					SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
				End
			If @RestrictionsOffice > 0 
				Begin
				  SELECT @sql = @sql  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
				End		

			SELECT @sql = @sql + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)
							AND (V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE > @Completed or V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE is null)'			
							 
			if @StartDate <> '1/1/1950' and @EndDate <> '1/1/2050'
			    Begin
			        SELECT @sql = @sql + ' And (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE >= @StartDate)
							                And (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE <= @EndDate)'
			    End
			if @StartDate = '1/1/1950' and @EndDate = '1/1/2050'
			    Begin
			        SELECT @sql = @sql + 'And (((V_JOB_TRAFFIC_DET.JOB_REVISED_DATE >= @StartDate)
							                And (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE <= @EndDate)) or (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE is null))'
			    End
			if @Manager <> 'All'
				Begin
					SELECT @sql = @sql + ' And JOB_TRAFFIC.MGR_EMP_CODE = @Manager'
				End
			if @Restrictions > 0
				Begin
					SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				End

			SELECT @sql = @sql + ' Group by JOB_LOG.CL_CODE,
				CLIENT.CL_NAME,
				JOB_LOG.DIV_CODE,
				DIVISION.DIV_NAME,
				JOB_LOG.PRD_CODE,
				PRODUCT.PRD_DESCRIPTION,
				JOB_LOG.JOB_NUMBER,
				JOB_LOG.JOB_DESC,
				JOB_COMPONENT.JOB_COMPONENT_NBR,
				JOB_COMPONENT.JOB_COMP_DESC,
				 V_JOB_TRAFFIC_DET.TASK_DESCRIPTION,V_JOB_TRAFFIC_DET.FNC_CODE,
				 V_JOB_TRAFFIC_DET.JOB_DUE_DATE,
				V_JOB_TRAFFIC_DET.JOB_REVISED_DATE,V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE,V_JOB_TRAFFIC_DET.SEQ_NBR,
				isnull(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME,''''), V_JOB_TRAFFIC_DET.JOB_ORDER, V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID, TP.PHASE_DESC'
			
	SELECT @paramlist = '@UserID VarChar(100), @EmpCodes VarChar(4000), @ClientCodes VarChar(4000), @OfficeCodes VarChar(4000), @StartDate SmallDateTime, @EndDate SmallDateTime, 
							@Completed SmallDateTime, @Manager VarChar(6), @AECodes VarChar(4000)'
	PRINT @sql
	EXEC sp_executesql @sql, @paramlist, @UserID, @EmpCodes, @ClientCodes, @OfficeCodes, @StartDate, @EndDate, @Completed, @Manager, @AECodes
	
	
--ADD IN EVENT TASKS:
SET @EndDate = DATEADD(dd,1,@EndDate)
SET @sql = ''
SET @paramlist = ''	

SET @sql = 'INSERT INTO #MY_DATA '  


SET @sql = @sql + '
SELECT     
	'''' AS SubHead, '''' AS Program, CLIENT.CL_CODE AS CCode, CLIENT.CL_NAME AS CName, DIVISION.DIV_CODE AS DCode, 
	DIVISION.DIV_NAME AS DName, PRODUCT.PRD_CODE AS PCode, PRODUCT.PRD_DESCRIPTION AS PName, JOB_LOG.JOB_NUMBER AS JobNum, 
	JOB_LOG.JOB_DESC AS JobDesc, JOB_COMPONENT.JOB_COMPONENT_NBR AS CompNum, JOB_COMPONENT.JOB_COMP_DESC AS CompDesc, 
	TRAFFIC_FNC.TRF_DESC+'' (''+TRAFFIC_FNC.TRF_CODE+'')'' AS Task, EVENT_TASK.HOURS_ALLOWED AS HoursAllowed, 
	EVENT_TASK.END_TIME AS [Due Date], EVENT_TASK.END_TIME AS [Rev Due Date], NULL AS [Completed Date], 
	EVENT_TASK.COMMENTS AS Comments, 
	ISNULL(ISNULL(EMPLOYEE.EMP_FNAME+'' '', '''')+ISNULL(EMPLOYEE.EMP_MI+''. '', '''')+ISNULL(EMPLOYEE.EMP_LNAME+'' '', ''''),'''') AS Emp, 
	'''' AS JTComments, CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP, 
	CONVERT(VARCHAR(10),JOB_LOG.JOB_NUMBER) + ''-'' + JOB_LOG.JOB_DESC + ''-'' + CONVERT(CHAR(2),JOB_COMPONENT.JOB_COMPONENT_NBR) + ''-'' + JOB_COMPONENT.JOB_COMP_DESC AS JBNUM,
	-1 AS SEQ_NBR,
	CASE WHEN EVENT_TASK.TEMP_COMP_DATE IS NOT NULL THEN ''X'' ELSE '''' END AS TEMP_COMP, 
	CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.START_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.START_TIME, 22), 3)))+ '' - ''+
	CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.END_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.END_TIME, 22), 3))) AS DueTime,  
	1 AS IS_EVENT_TASK,
	999999999 AS JOB_ORDER, 
	ISNULL(EVENT_TASK.TASK_CODE,'''') AS FNC_CODE,
	TRAFFIC_FNC.TRF_DESC, NULL,'''',0
FROM
	EVENT_TASK WITH (NOLOCK) INNER JOIN
	EVENT WITH (NOLOCK) ON EVENT_TASK.EVENT_ID = EVENT.EVENT_ID INNER JOIN
	JOB_COMPONENT WITH (NOLOCK) ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
	EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
	JOB_LOG WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
	CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
	PRODUCT WITH (NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
	JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
	DIVISION WITH (NOLOCK) ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
	TRAFFIC_FNC WITH (NOLOCK) ON EVENT_TASK.TASK_CODE = TRAFFIC_FNC.TRF_CODE 
	LEFT OUTER JOIN EMPLOYEE ON EVENT_TASK.EMP_CODE = EMPLOYEE.EMP_CODE
'
IF @ClientCodes<>'%' 
BEGIN
	SET @sql = @sql + ' INNER JOIN charlist_to_table(@ClientCodes, DEFAULT) c ON JOB_LOG.CL_CODE = c.vstr collate database_default'
END
IF @OfficeCodes<>'%' 
BEGIN
	SET @sql = @sql + ' INNER JOIN charlist_to_table(@OfficeCodes, DEFAULT) d ON JOB_LOG.OFFICE_CODE = d.vstr collate database_default'
END 
IF @EmpCodes<>'%' 
BEGIN
	SET @sql = @sql + ' INNER JOIN charlist_to_table(@EmpCodes, DEFAULT) e ON EVENT_TASK.EMP_CODE = e.vstr collate database_default'
END

IF @AECodes<>'%' 
BEGIN
	SET @sql = @sql + ' INNER JOIN charlist_to_table(@AECodes, DEFAULT) f ON JOB_COMPONENT.EMP_CODE = f.vstr collate database_default'
END 

IF @Restrictions > 0
BEGIN		
	SET @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
END
If @RestrictionsOffice > 0 
Begin
  SELECT @sql = @sql  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
End	

SET @sql = @sql + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'

IF @StartDate <> '1/1/1950' and @EndDate <> '1/1/2050'
BEGIN
    SET @sql = @sql + ' AND (EVENT_TASK.END_TIME >= @StartDate) AND (EVENT_TASK.END_TIME <= @EndDate)'
END
IF @StartDate = '1/1/1950' and @EndDate = '1/1/2050'
BEGIN
    SELECT @sql = @sql + ' AND (((EVENT_TASK.END_TIME >= @StartDate) AND (EVENT_TASK.END_TIME <= @EndDate)) OR (EVENT_TASK.END_TIME IS NULL))'
END
--IF @Manager <> 'All'
--BEGIN
--	SELECT @sql = @sql + ' AND JOB_TRAFFIC.MGR_EMP_CODE = @Manager'
--END
IF @Restrictions > 0
BEGIN
	SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
END

SET @paramlist = '@UserID VarChar(100), @EmpCodes VarChar(4000), @ClientCodes VarChar(4000), @OfficeCodes VarChar(4000), @StartDate SmallDateTime, @EndDate SmallDateTime, @Completed SmallDateTime, @Manager VarChar(6), @AECodes VarChar(4000)'



EXEC sp_executesql @sql, @paramlist, @UserID, @EmpCodes, @ClientCodes, @OfficeCodes, @StartDate, @EndDate, @Completed, @Manager, @AECodes


--CASE WHEN V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL AND V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL THEN ''X'' ELSE 
SELECT @NumberRecords = COUNT(*) FROM #MY_DATA
SET @RowCount = 1

WHILE @RowCount <= @NumberRecords
BEGIN
 SELECT @job = JobNum, @comp = CompNum, @seq = SEQ_NBR
 FROM #MY_DATA
 WHERE RowID = @RowCount

 SELECT @count = COUNT(*) FROM(
 SELECT CASE WHEN V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL AND V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL THEN 'X' ELSE '' END AS TEMP_COMP
					FROM V_JOB_TRAFFIC_DET 
					WHERE (JOB_NUMBER = @job) AND (JOB_COMPONENT_NBR = @comp) AND (SEQ_NBR = @seq)) A
 WHERE A.TEMP_COMP = 'X' 

IF @count > 0
Begin
	UPDATE #MY_DATA
	SET TEMP_COMP = 'X' 
	WHERE (JobNum = @job) AND (CompNum = @comp) AND (SEQ_NBR = @seq)
End

SET @RowCount = @RowCount + 1
END	

UPDATE #MY_DATA
SET Comments = (SELECT FNC_COMMENTS FROM JOB_TRAFFIC_DET JTD WHERE JTD.JOB_NUMBER = #MY_DATA.JobNum AND JTD.JOB_COMPONENT_NBR = #MY_DATA.CompNum AND JTD.SEQ_NBR = #MY_DATA.SEQ_NBR)

UPDATE #MY_DATA
SET JTComments = (SELECT TRF_COMMENTS FROM JOB_TRAFFIC JT WHERE JT.JOB_NUMBER = #MY_DATA.JobNum AND JT.JOB_COMPONENT_NBR = #MY_DATA.CompNum)

UPDATE #MY_DATA
SET Emp = (SELECT EMP_CODE_FML_NAME_LIST FROM V_JOB_TRAFFIC_DET_EMPS JTD WHERE JTD.JOB_NUMBER = #MY_DATA.JobNum AND JTD.JOB_COMPONENT_NBR = #MY_DATA.CompNum AND JTD.SEQ_NBR = #MY_DATA.SEQ_NBR)


SELECT @sql = ''
				
SELECT @sql = 'SELECT
	SubHead,
	Program,
	CCode,
	CName,
	DCode,
	DName,
	PCode,
	PName,
	JobNum,
	JobDesc,
	CompNum,
	CompDesc,
	Task,
	HoursAllowed,
	[Due Date],
	[Rev Due Date],
	[Completed Date],
	Comments,
	Emp,
	JTComments,
	CDP,
	JBNUM,
	#MY_DATA.SEQ_NBR,
	TEMP_COMP,
	DueTime,
	IS_EVENT_TASK,
	JOB_ORDER,
	FNC_CODE,
	FNC_DESC,
	TRAFFIC_PHASE_ID,
	TRAFFIC_PHASE_DESC,
	HAS_CHILDREN = CONVERT(BIT, CASE WHEN PARENT_TASKS.JOB_NUMBER IS NOT NULL THEN 1 ELSE 0 END)
FROM
	#MY_DATA LEFT OUTER JOIN (SELECT DISTINCT
							  			 JOB_TRAFFIC_DET.JOB_NUMBER,
										 JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,
										 [SEQ_NBR] = JOB_TRAFFIC_DET.PARENT_TASK_SEQ
									 FROM
										 dbo.JOB_TRAFFIC_DET JOIN
										 dbo.JOB_TRAFFIC ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND
														    JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
									 WHERE
										 JOB_TRAFFIC.SCHEDULE_CALC = 1 AND
										 PARENT_TASK_SEQ IS NOT NULL) PARENT_TASKS ON #MY_DATA.JobNum = PARENT_TASKS.JOB_NUMBER AND #MY_DATA.CompNum = PARENT_TASKS.JOB_COMPONENT_NBR AND #MY_DATA.SEQ_NBR = PARENT_TASKS.SEQ_NBR
	WHERE PARENT_TASKS.JOB_NUMBER IS NULL'

if @SortOrder = '1'
Begin
	SET @sql = @sql + ' ORDER BY CCode,DCode,PCode,JobNum,CompNum,[Rev Due Date] ASC,JOB_ORDER,SEQ_NBR, FNC_DESC'
End
if @SortOrder = '2'
Begin
	SET @sql = @sql + ' ORDER BY [Rev Due Date] ASC,JOB_ORDER,SEQ_NBR,FNC_DESC,CCode,DCode,PCode,JobNum,CompNum'
End
if @SortOrder = '3'
Begin
	SET @sql = @sql + ' ORDER BY FNC_DESC,[Rev Due Date] ASC,JOB_ORDER,SEQ_NBR,CCode,DCode,PCode,JobNum,CompNum ASC'
End
if @SortOrder = '4'
Begin
	SET @sql = @sql + ' ORDER BY CCode,JobNum,CompNum,[Rev Due Date] ASC, JOB_ORDER, SEQ_NBR,FNC_DESC'
End
if @SortOrder = '5'
Begin
	SET @sql = @sql + ' ORDER BY JobNum, CompNum, [Rev Due Date] ASC, JOB_ORDER, SEQ_NBR,FNC_DESC'
End
if @SortOrder = '6'
Begin
	SET @sql = @sql + ' ORDER BY [Rev Due Date] ASC,CCode,JobNum,CompNum, JOB_ORDER, SEQ_NBR'
End

PRINT(@sql)
EXEC(@sql)

	--CASE @SortOrder
	--	WHEN '1' THEN CCode + ', ' + DCode + ', ' + PCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + ', ' + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + SUBSTRING('000000000', 1, 9 - LEN(JOB_ORDER)) + CONVERT(VARCHAR(9),JOB_ORDER) + SUBSTRING('0000', 1, 4 - LEN(SEQ_NBR)) + CONVERT(CHAR(4),SEQ_NBR) + ' ASC'
	--	WHEN '2' THEN CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + ' ASC' + SUBSTRING('000000000', 1, 9 - LEN(JOB_ORDER)) + CONVERT(VARCHAR(9),JOB_ORDER) + SUBSTRING('0000', 1, 4 - LEN(SEQ_NBR)) + CONVERT(CHAR(4),SEQ_NBR) + CCode + ', ' + DCode + ', ' + PCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum)
	--	WHEN '3' THEN FNC_CODE + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) +  SUBSTRING('000000000', 1, 9 - LEN(JOB_ORDER)) + CONVERT(VARCHAR(9),JOB_ORDER) + CCode + ', ' + DCode + ', ' + PCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + ' ASC'
	--	WHEN '4' THEN CCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + SUBSTRING('000000000', 1, 9 - LEN(JOB_ORDER))  + CONVERT(VARCHAR(9), JOB_ORDER) + SUBSTRING('0000', 1, 4 - LEN(SEQ_NBR)) + CONVERT(CHAR(4), SEQ_NBR) + ' ASC'
	--	WHEN '5' THEN CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + SUBSTRING('000000000', 1, 9 - LEN(JOB_ORDER)) + CONVERT(VARCHAR(9),JOB_ORDER) + SUBSTRING('0000', 1, 4 - LEN(SEQ_NBR)) + CONVERT(CHAR(4),SEQ_NBR) + ' ASC'
	--	WHEN '6' THEN CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + CCode + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + SUBSTRING('000000000', 1, 9 - LEN(JOB_ORDER)) + CONVERT(VARCHAR(9),JOB_ORDER) + SUBSTRING('0000', 1, 4 - LEN(SEQ_NBR)) + CONVERT(CHAR(4),SEQ_NBR) + ' ASC'
	--END

	--CASE @SortOrder
	--	WHEN '1' THEN CCode + ', ' + DCode + ', ' + PCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + ', ' + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + CONVERT(CHAR(10),JOB_ORDER) + FNC_CODE + ' ASC'
	--	WHEN '2' THEN CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + ' ASC' + CONVERT(CHAR(10),JOB_ORDER) + FNC_CODE + CCode + ', ' + DCode + ', ' + PCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum)
	--	WHEN '3' THEN FNC_CODE + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) +  CONVERT(CHAR(10),JOB_ORDER) + CCode + ', ' + DCode + ', ' + PCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + ' ASC'
	--	WHEN '4' THEN CCode + ', ' + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + CONVERT(CHAR(10),JOB_ORDER) + FNC_CODE + ' ASC'
	--	WHEN '5' THEN CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + CONVERT(CHAR(10),JOB_ORDER) + FNC_CODE + ' ASC'
	--	WHEN '6' THEN CAST(CAST(ISNULL([Rev Due Date], [Due Date]) AS INT)AS CHAR(12)) + CCode + CONVERT(CHAR(10),JobNum) + ', ' + CONVERT(CHAR(10),CompNum) + ' ASC'
	--END
				
DROP TABLE #MY_DATA;
--	PRINT @sql		





