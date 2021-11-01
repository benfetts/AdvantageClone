if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_rpt_TaskList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_rpt_TaskList]
GO
--Webvantage
CREATE PROCEDURE [dbo].[usp_wv_rpt_TaskList] 
@UserID VarChar(100),
@EmpCode VarChar(6),
@ClientCode VarChar(6),
@DivCode VarChar(6),
@ProdCode VarChar(6),
@JobNumber VarChar(6),
@SortOrder VarChar(1),
@StartDate SmallDateTime,
@EndDate SmallDateTime,
@Completed SmallDateTime,
@CP int,
@CPID int
AS
/*=========== QUERY ===========*/
Declare @Restrictions Int, @sql nvarchar(4000), @sql2 nvarchar(4000),
		@paramlist nvarchar(4000), @RestrictionsCP Int

Select @Restrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID);

Select @RestrictionsCP = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CPID;

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER

SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE

If @CP = 1
BEGIN
		SELECT @sql = 'SELECT A.SubHead,A.Program,A.CCode,A.CName,A.DCode,A.DName,A.PCode,A.PName,A.JobNum,A.JobDesc,A.CompNum,A.CompDesc,A.Task,A.HoursAllowed,
		A.[Due Date],A.[Rev Due Date],A.[Completed Date],
		A.Comments,A.CDP,A.TEMP_COMP,A.DueTime,A.IS_EVENT_TASK, A.TDesc, A.TRAFFIC_PHASE_ID,A.PHASE_DESC
	FROM (SELECT '''' as SubHead, '''' as Program, 
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
   				isnull(JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') + ''('' + isnull(JOB_TRAFFIC_DET.FNC_CODE, '''') + '')'' as Task,
				JOB_TRAFFIC_DET.JOB_HRS as [HoursAllowed],
				JOB_TRAFFIC_DET.JOB_DUE_DATE as [Due Date],
				JOB_TRAFFIC_DET.JOB_REVISED_DATE as [Rev Due Date],
				JOB_TRAFFIC_DET.JOB_COMPLETED_DATE as [Completed Date],
				JOB_TRAFFIC_DET.FNC_COMMENTS as Comments,
				CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP,
				CASE WHEN JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL THEN ''X'' ELSE '''' END AS ''TEMP_COMP'',
				isnull(JOB_TRAFFIC_DET.REVISED_DUE_TIME,'''') as DueTime, 0 AS IS_EVENT_TASK, JOB_TRAFFIC_DET.TASK_DESCRIPTION as TDesc, JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID, TP.PHASE_DESC
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
			INNER JOIN JOB_TRAFFIC_DET
				ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER
				AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			INNER JOIN JOB_TRAFFIC_DET_CNTS ON JOB_TRAFFIC_DET_CNTS.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER
				AND JOB_TRAFFIC_DET_CNTS.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR 
				AND JOB_TRAFFIC_DET_CNTS.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR
			LEFT OUTER JOIN TRAFFIC_PHASE TP ON TP.TRAFFIC_PHASE_ID = JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID'
			if @RestrictionsCP > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
			End				
SELECT @sql = @sql + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))' 
			if @RestrictionsCP > 0
			Begin
				SELECT @sql = @sql + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = ''' + CAST(@CPID AS VARCHAR(6)) + ''')'
			End				
			SELECT @sql = @sql + ' AND (JOB_TRAFFIC_DET_CNTS.CDP_CONTACT_ID = ''' + CAST(@CPID AS VARCHAR(6)) + ''')'
							
			SELECT @sql = @sql + ' AND (JOB_TRAFFIC_DET.JOB_COMPLETED_DATE > ''' + CAST(@Completed AS Varchar) + ''' or JOB_TRAFFIC_DET.JOB_COMPLETED_DATE is null)'
			if @ClientCode <> '%'
			Begin
				SELECT @sql = @sql + ' And JOB_LOG.CL_CODE = ''' + @ClientCode + ''''
			End	
			if @DivCode <> '%'
			Begin
				SELECT @sql = @sql + ' And JOB_LOG.DIV_CODE = ''' + @DivCode + ''''
			End	
			if @ProdCode <> '%'
			Begin
				SELECT @sql = @sql + ' And JOB_LOG.PRD_CODE = ''' + @ProdCode + ''''
			End	
			SELECT @sql = @sql + ' And JOB_LOG.JOB_NUMBER Like ''%'' + ''' + @JobNumber + ''' And JOB_TRAFFIC_DET.JOB_REVISED_DATE >= ''' + CAST(@StartDate AS Varchar) + ''' And JOB_TRAFFIC_DET.JOB_REVISED_DATE <= ''' + CAST(@EndDate AS Varchar) + ''''

		
	SELECT @sql2 = ' UNION ALL
		SELECT     '''' AS SubHead, '''' AS Program, CLIENT.CL_CODE AS CCode, CLIENT.CL_NAME AS CName, DIVISION.DIV_CODE AS DCode, 
							  DIVISION.DIV_NAME AS DName, PRODUCT.PRD_CODE AS PCode, PRODUCT.PRD_DESCRIPTION AS PName, JOB_LOG.JOB_NUMBER AS JobNum, 
							  JOB_LOG.JOB_DESC AS JobDesc, JOB_COMPONENT.JOB_COMPONENT_NBR AS CompNum, JOB_COMPONENT.JOB_COMP_DESC AS CompDesc, 
							  TRAFFIC_FNC.TRF_DESC+''(''+TRAFFIC_FNC.TRF_CODE+'')'' AS Task, EVENT_TASK.HOURS_ALLOWED AS HoursAllowed, 
							  EVENT_TASK.END_TIME AS [Due Date], EVENT_TASK.END_TIME AS [Rev Due Date], NULL AS [Completed Date], 
							  EVENT_TASK.COMMENTS AS Comments, CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP, 
							  CASE WHEN EVENT_TASK.TEMP_COMP_DATE IS NOT NULL THEN ''X'' ELSE '''' END AS TEMP_COMP, 
							  CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.START_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.START_TIME, 22), 3)))+ '' - ''+
							  CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.END_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.END_TIME, 22), 3))) AS DueTime,  
							  1 AS IS_EVENT_TASK, TRAFFIC_FNC.TRF_DESC as TDesc,'''',''''
		FROM         EVENT_TASK WITH (NOLOCK) INNER JOIN
							  EVENT WITH (NOLOCK) ON EVENT_TASK.EVENT_ID = EVENT.EVENT_ID INNER JOIN
							  JOB_COMPONENT WITH (NOLOCK) ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							  EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
							  JOB_LOG WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
							  CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
							  PRODUCT WITH (NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
							  JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
							  DIVISION WITH (NOLOCK) ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
							  TRAFFIC_FNC WITH (NOLOCK) ON EVENT_TASK.TASK_CODE = TRAFFIC_FNC.TRF_CODE' 
							  if @RestrictionsCP > 0
								Begin
									SELECT @sql2 = @sql2 + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE'
								End
SELECT @sql2 = @sql2 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
			if @RestrictionsCP > 0
			Begin
				SELECT @sql2 = @sql2 + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = ''' + CAST(@CPID AS VARCHAR(6)) + ''')'
			End	
			if @EmpCode <> ''
			Begin
				SELECT @sql2 = @sql2 + ' AND (EVENT_TASK.EMP_CODE = ''' + @EmpCode + ''')'
			End				
			SELECT @sql2 = @sql2 + ' AND (EVENT_TASK.TEMP_COMP_DATE > ''' + CAST(@Completed AS Varchar) + ''' or EVENT_TASK.TEMP_COMP_DATE is null)'
			if @ClientCode <> '%'
			Begin
				SELECT @sql2 = @sql2 + ' And JOB_LOG.CL_CODE = ''' + @ClientCode + ''''
			End	
			if @DivCode <> '%'
			Begin
				SELECT @sql2 = @sql2 + ' And JOB_LOG.DIV_CODE = ''' + @DivCode + ''''
			End	
			if @ProdCode <> '%'
			Begin
				SELECT @sql2 = @sql2 + ' And JOB_LOG.PRD_CODE = ''' + @ProdCode + ''''
			End	
			SELECT @sql2 = @sql2 + ' AND JOB_LOG.JOB_NUMBER Like ''%'' + ''' + @JobNumber + ''' AND EVENT_TASK.START_TIME >= ''' + CAST(@StartDate AS Varchar) + ''' AND EVENT_TASK.END_TIME <= DATEADD(dd,1,''' + CAST(@EndDate AS Varchar) + ''')) AS A ORDER BY'

		if @SortOrder = '1'
			Begin
				SELECT @sql2 = @sql2 + ' A.CCode, A.DCode,A.PCode,A.JobNum, A.CompNum, A.[Rev Due Date] ASC'
			End
		if @SortOrder = '2'
			Begin
				SELECT @sql2 = @sql2 + ' A.[Rev Due Date] ASC, A.CCode, A.DCode,A.PCode,A.JobNum, A.CompNum'
			End
		if @SortOrder = '3'
			Begin
				SELECT @sql2 = @sql2 + ' A.TDesc, A.CCode, A.DCode,A.PCode,A.JobNum, A.CompNum, A.[Rev Due Date] ASC'
			End

--SELECT @paramlist = '@UserID varchar(100), @EmpCode varchar(6), @Completed Datetime, @ClientCode varchar(6), @DivCode varchar(6), @ProdCode varchar(6), @JobNumber varchar(6), @StartDate Datetime, @EndDate Datetime'
Print @sql
EXEC (@sql + @sql2)
END
ELSE
BEGIN
		SELECT @sql = 'SELECT A.SubHead,A.Program,A.CCode,A.CName,A.DCode,A.DName,A.PCode,A.PName,A.JobNum,A.JobDesc,A.CompNum,A.CompDesc,A.Task,A.HoursAllowed,
		A.[Due Date],A.[Rev Due Date],A.[Completed Date],
		A.Comments,A.CDP,A.TEMP_COMP,A.DueTime,A.IS_EVENT_TASK, A.TDesc, A.TRAFFIC_PHASE_ID,A.PHASE_DESC
	FROM (SELECT '''' as SubHead, '''' as Program, 
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
   				isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '''') + ''('' + isnull(V_JOB_TRAFFIC_DET.FNC_CODE, '''') + '')'' as Task,
				V_JOB_TRAFFIC_DET.JOB_HRS as [HoursAllowed],
				V_JOB_TRAFFIC_DET.JOB_DUE_DATE as [Due Date],
				V_JOB_TRAFFIC_DET.JOB_REVISED_DATE as [Rev Due Date],
				V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE as [Completed Date],
				V_JOB_TRAFFIC_DET.FNC_COMMENTS as Comments,
				CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP,
				CASE WHEN V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL AND V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL THEN ''X'' ELSE '''' END AS ''TEMP_COMP'',
				isnull(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME,'''') as DueTime, 0 AS IS_EVENT_TASK, V_JOB_TRAFFIC_DET.TASK_DESCRIPTION as TDesc, V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID, TP.PHASE_DESC
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
			INNER JOIN V_JOB_TRAFFIC_DET
				ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
				AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
			LEFT OUTER JOIN TRAFFIC_PHASE TP ON TP.TRAFFIC_PHASE_ID = V_JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID'
			if @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
			End
			If @RestrictionsOffice > 0 
			Begin
			  SELECT @sql = @sql  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
			End					
SELECT @sql = @sql + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))' 
			if @Restrictions > 0
			Begin
				SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			End	
			if @EmpCode <> ''
			Begin
				SELECT @sql = @sql + ' AND (V_JOB_TRAFFIC_DET.EMP_CODE = ''' + @EmpCode + ''')'
			End				
			SELECT @sql = @sql + ' AND (V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE > ''' + CAST(@Completed AS Varchar) + ''' or V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE is null)'
			if @ClientCode <> '%'
			Begin
				SELECT @sql = @sql + ' And JOB_LOG.CL_CODE = ''' + @ClientCode + ''''
			End	
			if @DivCode <> '%'
			Begin
				SELECT @sql = @sql + ' And JOB_LOG.DIV_CODE = ''' + @DivCode + ''''
			End	
			if @ProdCode <> '%'
			Begin
				SELECT @sql = @sql + ' And JOB_LOG.PRD_CODE = ''' + @ProdCode + ''''
			End	
			SELECT @sql = @sql + ' And JOB_LOG.JOB_NUMBER Like ''%'' + ''' + @JobNumber + ''' And V_JOB_TRAFFIC_DET.JOB_REVISED_DATE >= ''' + CAST(@StartDate AS Varchar) + ''' And V_JOB_TRAFFIC_DET.JOB_REVISED_DATE <= ''' + CAST(@EndDate AS Varchar) + ''''

		
	SELECT @sql2 = ' UNION ALL
		SELECT     '''' AS SubHead, '''' AS Program, CLIENT.CL_CODE AS CCode, CLIENT.CL_NAME AS CName, DIVISION.DIV_CODE AS DCode, 
							  DIVISION.DIV_NAME AS DName, PRODUCT.PRD_CODE AS PCode, PRODUCT.PRD_DESCRIPTION AS PName, JOB_LOG.JOB_NUMBER AS JobNum, 
							  JOB_LOG.JOB_DESC AS JobDesc, JOB_COMPONENT.JOB_COMPONENT_NBR AS CompNum, JOB_COMPONENT.JOB_COMP_DESC AS CompDesc, 
							  TRAFFIC_FNC.TRF_DESC+''(''+TRAFFIC_FNC.TRF_CODE+'')'' AS Task, EVENT_TASK.HOURS_ALLOWED AS HoursAllowed, 
							  EVENT_TASK.END_TIME AS [Due Date], EVENT_TASK.END_TIME AS [Rev Due Date], NULL AS [Completed Date], 
							  EVENT_TASK.COMMENTS AS Comments, CLIENT.CL_NAME + '' - '' + DIVISION.DIV_NAME + '' - '' + PRODUCT.PRD_DESCRIPTION AS CDP, 
							  CASE WHEN EVENT_TASK.TEMP_COMP_DATE IS NOT NULL THEN ''X'' ELSE '''' END AS TEMP_COMP, 
							  CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.START_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.START_TIME, 22), 3)))+ '' - ''+
							  CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.END_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.END_TIME, 22), 3))) AS DueTime,  
							  1 AS IS_EVENT_TASK, TRAFFIC_FNC.TRF_DESC as TDesc,'''',''''
		FROM         EVENT_TASK WITH (NOLOCK) INNER JOIN
							  EVENT WITH (NOLOCK) ON EVENT_TASK.EVENT_ID = EVENT.EVENT_ID INNER JOIN
							  JOB_COMPONENT WITH (NOLOCK) ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
							  EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
							  JOB_LOG WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
							  CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
							  PRODUCT WITH (NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
							  JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
							  DIVISION WITH (NOLOCK) ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
							  TRAFFIC_FNC WITH (NOLOCK) ON EVENT_TASK.TASK_CODE = TRAFFIC_FNC.TRF_CODE' 
							  if @Restrictions > 0
								Begin
									SELECT @sql2 = @sql2 + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
								End
								If @RestrictionsOffice > 0 
								Begin
								  SELECT @sql2 = @sql2  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
								End	
SELECT @sql2 = @sql2 + ' WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
			if @Restrictions > 0
			Begin
				SELECT @sql2 = @sql2 + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
			End		
			if @EmpCode <> ''
			Begin
				SELECT @sql2 = @sql2 + ' AND (EVENT_TASK.EMP_CODE = ''' + @EmpCode + ''')'
			End				
			SELECT @sql2 = @sql2 + ' AND (EVENT_TASK.TEMP_COMP_DATE > ''' + CAST(@Completed AS Varchar) + ''' or EVENT_TASK.TEMP_COMP_DATE is null)'
			if @ClientCode <> '%'
			Begin
				SELECT @sql2 = @sql2 + ' And JOB_LOG.CL_CODE = ''' + @ClientCode + ''''
			End	
			if @DivCode <> '%'
			Begin
				SELECT @sql2 = @sql2 + ' And JOB_LOG.DIV_CODE = ''' + @DivCode + ''''
			End	
			if @ProdCode <> '%'
			Begin
				SELECT @sql2 = @sql2 + ' And JOB_LOG.PRD_CODE = ''' + @ProdCode + ''''
			End	
			SELECT @sql2 = @sql2 + ' AND JOB_LOG.JOB_NUMBER Like ''%'' + ''' + @JobNumber + ''' AND EVENT_TASK.START_TIME >= ''' + CAST(@StartDate AS Varchar) + ''' AND EVENT_TASK.END_TIME <= DATEADD(dd,1,''' + CAST(@EndDate AS Varchar) + ''')) AS A ORDER BY'

		if @SortOrder = '1'
			Begin
				SELECT @sql2 = @sql2 + ' A.CCode, A.DCode,A.PCode,A.JobNum, A.CompNum, A.[Rev Due Date] ASC'
			End
		if @SortOrder = '2'
			Begin
				SELECT @sql2 = @sql2 + ' A.[Rev Due Date] ASC, A.CCode, A.DCode,A.PCode,A.JobNum, A.CompNum'
			End
		if @SortOrder = '3'
			Begin
				SELECT @sql2 = @sql2 + ' A.TDesc, A.CCode, A.DCode,A.PCode,A.JobNum, A.CompNum, A.[Rev Due Date] ASC'
			End

--SELECT @paramlist = '@UserID varchar(100), @EmpCode varchar(6), @Completed Datetime, @ClientCode varchar(6), @DivCode varchar(6), @ProdCode varchar(6), @JobNumber varchar(6), @StartDate Datetime, @EndDate Datetime'
Print @sql2
EXEC (@sql + @sql2)
END


			--CASE @SortOrder
			--	WHEN '1' THEN  A.CCode + ', ' + A.DCode + ', ' + A.PCode + ', ' + CONVERT(char(10),A.JobNum) + ', ' + CONVERT(char(10),A.CompNum) + ', ' + Cast(Cast(IsNull(A.[Rev Due Date], A.[Due Date]) as Int)as Char(12)) + ' ASC'
			--	WHEN '2' THEN Cast(Cast(IsNull(A.[Rev Due Date], A.[Due Date]) as Int)as Char(12)) + ' ASC, ' + A.CCode + ', ' + A.DCode + ', ' + A.PCode + ', ' + CONVERT(char(10),A.JobNum) + ', ' + CONVERT(char(10),A.CompNum)
			--	WHEN '3' Then A.Task + A.CCode + ', ' + A.DCode + ', ' + A.PCode + ', ' + CONVERT(char(10),A.JobNum) + ', ' + CONVERT(char(10),A.CompNum) + ', ' + Cast(Cast(IsNull(A.[Rev Due Date], A.[Due Date]) as Int)as Char(12)) + ' ASC'
			--END



--ELSE --NOT RESTRICTED
--	SELECT
--		A.SubHead,A.Program,A.CCode,A.CName,A.DCode,A.DName,A.PCode,
--		A.PName,A.JobNum,A.JobDesc,A.CompNum,A.CompDesc,A.Task,A.HoursAllowed,
--		CONVERT(CHAR(10),A.[Due Date],101) AS [Due Date],
--		CONVERT(CHAR(10),A.[Rev Due Date],101) AS [Rev Due Date],
--		CONVERT(CHAR(10),A.[Completed Date],101) AS [Completed Date],
--		A.Comments,A.CDP,A.TEMP_COMP,
--		A.DueTime,
--		A.IS_EVENT_TASK
--	FROM (
--		SELECT  
--			'' as SubHead,
--			'' as Program, 
--			JOB_LOG.CL_CODE as CCode,
--			CLIENT.CL_NAME as CName,
--			JOB_LOG.DIV_CODE as DCode,
--			DIVISION.DIV_NAME as DName,
--			JOB_LOG.PRD_CODE as PCode,
--			PRODUCT.PRD_DESCRIPTION as PName,
--			JOB_LOG.JOB_NUMBER as JobNum,
--			JOB_LOG.JOB_DESC as JobDesc,
--			--Cast(JOB_LOG.JOB_NUMBER as VarChar(4)) + ' - ' + JOB_LOG.JOB_DESC as Job,
--			JOB_COMPONENT.JOB_COMPONENT_NBR as CompNum,
--			JOB_COMPONENT.JOB_COMP_DESC as CompDesc,
--			--Cast(JOB_COMPONENT.JOB_COMPONENT_NBR as VarChar(4)) + ' - ' + JOB_COMPONENT.JOB_COMP_DESC as Component,
--			 isnull(V_JOB_TRAFFIC_DET.TASK_DESCRIPTION, '') + '(' + isnull(V_JOB_TRAFFIC_DET.FNC_CODE, '') + ')' as Task,
--			V_JOB_TRAFFIC_DET.JOB_HRS as [HoursAllowed],
--			 CONVERT(CHAR(10), V_JOB_TRAFFIC_DET.JOB_DUE_DATE, 101) as [Due Date],
--			CONVERT(CHAR(10), V_JOB_TRAFFIC_DET.JOB_REVISED_DATE, 101) as [Rev Due Date],

--			CONVERT(CHAR(10), V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE, 101) as [Completed Date],
--			V_JOB_TRAFFIC_DET.FNC_COMMENTS as Comments,
--			CLIENT.CL_NAME + ' - ' + DIVISION.DIV_NAME + ' - ' + PRODUCT.PRD_DESCRIPTION AS CDP,
--			CASE WHEN V_JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL AND V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL THEN 'X' ELSE '' END AS 'TEMP_COMP',
--			isnull(V_JOB_TRAFFIC_DET.REVISED_DUE_TIME,'') as DueTime, 0 AS IS_EVENT_TASK
--		FROM JOB_LOG
--		INNER JOIN CLIENT
--			ON CLIENT.CL_CODE = JOB_LOG.CL_CODE
--		INNER JOIN DIVISION
--			ON DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
--			AND DIVISION.CL_CODE = JOB_LOG.CL_CODE
--		INNER JOIN PRODUCT
--			ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE
--			AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
--			AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE
--		INNER JOIN JOB_COMPONENT
--			ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
--		INNER JOIN V_JOB_TRAFFIC_DET
--			ON JOB_COMPONENT.JOB_NUMBER = V_JOB_TRAFFIC_DET.JOB_NUMBER
--			AND JOB_COMPONENT.JOB_COMPONENT_NBR = V_JOB_TRAFFIC_DET.JOB_COMPONENT_NBR
--		WHERE (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
--		AND (V_JOB_TRAFFIC_DET.EMP_CODE = @EmpCode)
--		AND (V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE > @Completed or V_JOB_TRAFFIC_DET.JOB_COMPLETED_DATE is null) 
--		AND JOB_LOG.CL_CODE Like '%' + @ClientCode
--		And JOB_LOG.DIV_CODE Like '%' + @DivCode
--		And JOB_LOG.PRD_CODE Like '%' + @ProdCode
--		And JOB_LOG.JOB_NUMBER Like '%' + @JobNumber
--		And V_JOB_TRAFFIC_DET.JOB_REVISED_DATE >= @StartDate
--		And V_JOB_TRAFFIC_DET.JOB_REVISED_DATE <= @EndDate
		
--		UNION ALL


--		SELECT     '' AS SubHead, '' AS Program, CLIENT.CL_CODE AS CCode, CLIENT.CL_NAME AS CName, DIVISION.DIV_CODE AS DCode, 
--							  DIVISION.DIV_NAME AS DName, PRODUCT.PRD_CODE AS PCode, PRODUCT.PRD_DESCRIPTION AS PName, JOB_LOG.JOB_NUMBER AS JobNum, 
--							  JOB_LOG.JOB_DESC AS JobDesc, JOB_COMPONENT.JOB_COMPONENT_NBR AS CompNum, JOB_COMPONENT.JOB_COMP_DESC AS CompDesc, 
--							  TRAFFIC_FNC.TRF_DESC+'('+TRAFFIC_FNC.TRF_CODE+')' AS Task, EVENT_TASK.HOURS_ALLOWED AS HoursAllowed, 
--							  EVENT_TASK.END_TIME AS [Due Date], EVENT_TASK.END_TIME AS [Rev Due Date], NULL AS [Completed Date], 
--							  EVENT_TASK.COMMENTS AS Comments, CLIENT.CL_NAME + ' - ' + DIVISION.DIV_NAME + ' - ' + PRODUCT.PRD_DESCRIPTION AS CDP, 
--							  CASE WHEN EVENT_TASK.TEMP_COMP_DATE IS NOT NULL THEN 'X' ELSE '' END AS TEMP_COMP, 
--							  CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.START_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.START_TIME, 22), 3)))+ ' - '+
--							  CONVERT(VARCHAR(40),LTRIM(SUBSTRING(CONVERT(VARCHAR(20),EVENT_TASK.END_TIME, 22), 10, 5) + RIGHT(CONVERT(VARCHAR(20), EVENT_TASK.END_TIME, 22), 3))) AS DueTime,  
--							  1 AS IS_EVENT_TASK
--		FROM         EVENT_TASK WITH (NOLOCK) INNER JOIN
--							  EVENT WITH (NOLOCK) ON EVENT_TASK.EVENT_ID = EVENT.EVENT_ID INNER JOIN
--							  JOB_COMPONENT WITH (NOLOCK) ON EVENT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
--							  EVENT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
--							  JOB_LOG WITH (NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
--							  CLIENT WITH (NOLOCK) ON JOB_LOG.CL_CODE = CLIENT.CL_CODE INNER JOIN
--							  PRODUCT WITH (NOLOCK) ON JOB_LOG.CL_CODE = PRODUCT.CL_CODE AND JOB_LOG.DIV_CODE = PRODUCT.DIV_CODE AND 
--							  JOB_LOG.PRD_CODE = PRODUCT.PRD_CODE INNER JOIN
--							  DIVISION WITH (NOLOCK) ON JOB_LOG.CL_CODE = DIVISION.CL_CODE AND JOB_LOG.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
--							  TRAFFIC_FNC WITH (NOLOCK) ON EVENT_TASK.TASK_CODE = TRAFFIC_FNC.TRF_CODE 
--		WHERE     (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))
--			AND (EVENT_TASK.EMP_CODE = @EmpCode)
--			AND (EVENT_TASK.TEMP_COMP_DATE > @Completed OR EVENT_TASK.TEMP_COMP_DATE IS NULL) 
--			AND JOB_LOG.CL_CODE Like '%' + @ClientCode
--			AND JOB_LOG.DIV_CODE Like '%' + @DivCode
--			AND JOB_LOG.PRD_CODE Like '%' + @ProdCode
--			AND JOB_LOG.JOB_NUMBER Like '%' + @JobNumber
--			AND EVENT_TASK.START_TIME >= @StartDate
--			AND EVENT_TASK.END_TIME <= DATEADD(dd,1,@EndDate)
--	) AS A
--	ORDER BY
--			CASE @SortOrder
--				WHEN '1' THEN  A.CCode + ', ' + A.DCode + ', ' + A.PCode + ', ' + CONVERT(char(10),A.JobNum) + ', ' + CONVERT(char(10),A.CompNum) + ', ' + Cast(Cast(IsNull(A.[Rev Due Date], A.[Due Date]) as Int)as Char(12)) + ' ASC'
--				WHEN '2' THEN Cast(Cast(IsNull(A.[Rev Due Date], A.[Due Date]) as Int)as Char(12)) + ' ASC, ' + A.CCode + ', ' + A.DCode + ', ' + A.PCode + ', ' + CONVERT(char(10),A.JobNum) + ', ' + CONVERT(char(10),A.CompNum)
--				WHEN '3' Then A.Task + A.CCode + ', ' + A.DCode + ', ' + A.PCode + ', ' + CONVERT(char(10),A.JobNum) + ', ' + CONVERT(char(10),A.CompNum) + ', ' + Cast(Cast(IsNull(A.[Rev Due Date], A.[Due Date]) as Int)as Char(12)) + ' ASC'
--			END

/*=========== QUERY ===========*/
