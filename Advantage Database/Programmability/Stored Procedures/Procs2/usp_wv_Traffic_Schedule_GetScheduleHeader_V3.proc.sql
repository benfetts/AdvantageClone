/****** Object:  StoredProcedure [dbo].[usp_wv_Traffic_Schedule_GetScheduleHeader_V3]    Script Date: 6/17/2019 5:49:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
	declare @totalRows int
	exec usp_wv_Traffic_Schedule_GetScheduleHeader_V3 0,0,'354SYSADM',@Skip = 0,@Take = 200,@TotalRows=@totalRows OUTPUT
	print @totalRows
*/


CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetScheduleHeader_V3] 
		@JOB_NUMBER AS int,
		@JOB_COMPONENT_NBR AS int,
		@USER_ID AS varchar(100),
		@CL_CODE AS varchar(6) = NULL,
		@DIV_CODE AS varchar(6) = NULL,
		@PRD_CODE AS varchar(6) = NULL,
		@EMP_CODE AS varchar(6) = NULL,
		@MGR_CODE AS varchar(6) = NULL,
		@AE_CODE AS varchar(6) = NULL,
		@TASK_CODE AS varchar(10) = NULL,
		@ROLE_CODE AS varchar(6) = NULL,
		@CUT_OFF_DATE AS smalldatetime = NULL,
		@SHOW_ONLY_OPEN_SCHEDS AS smallint = 1,
		--TASK LEVEL STUFF:
		@IncludeCompletedTasks bit = 0,
		@IncludeOnlyPendingTasks bit = 0,
		@ExcludeProjectedTasks bit = 0,
		--Header level:
		@CMP_ID AS integer = 0,
		--MULTIVIEW SHOULD EXCLUDE CLOSED JOBS, BUT NORMAL, SINGLE SCHED SHOULD ALLOW IT
		@INCLUDE_CLOSE_JOBS AS bit = 0,
		@MILESTONES_ONLY bit = 0,
		@TRAFFIC_STATUS_CODE varchar(10) = null,
		@GANTT bit = 0,
		@OFFICE_CODE AS varchar(6) = NULL,
		@SC_CODE AS varchar(6) = NULL,
		@JT_CODE AS varchar(10) = null,
		@ONLY_SCHEDULE_TEMPLATES bit = 0
		,@TRAFFIC_PHASE_ID int = 0
		,@Skip int = 0
		,@Take int = 0
		,@TotalRows int out

AS

	DECLARE	@Restrictions AS smallint,
			@SQL_SELECT AS varchar(8000),
			@SQL_FROM AS varchar(8000),
			@SQL_WHERE AS varchar(8000),
			@SQL_DYNAMIC AS varchar(8000),
			@SQL_GROUP_BY AS varchar(8000),
			--Manager stuff:
			@MGR_COL varchar(20),
			@COLUMN_INDEX varchar(1),
			@ASSIGN_COL varchar(20),
			@UserCustom1 bit = 0,
			@start_rec int = 0,
			@end_rec int = 0

	if @SKIP > 0
	BEGIN
		SET @START_REC = @SKIP;
		SET @END_REC = @SKIP + @TAKE - 1;
	END
	ELSE
	BEGIN
		SET @START_REC = @SKIP;
		SET @END_REC = @TAKE;
	END



	DECLARE @EMP_CDE AS varchar(6)
	DECLARE @OfficeCount AS integer

	SELECT
		@EMP_CDE = EMP_CODE
	FROM SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@USER_ID)

	SELECT
		@OfficeCount = COUNT(*)
	FROM EMP_OFFICE
	WHERE EMP_CODE = @EMP_CDE

	SELECT
		@Restrictions = ISNULL(COUNT(1), 0)
	FROM SEC_CLIENT
	WHERE UPPER(USER_ID) = UPPER(@USER_ID)

	SELECT @UserCustom1 = Custom1
	FROM V_SEC_PERMISSION
	WHERE UserCode = @USER_ID AND ModuleCode = 'ProjectManagement_ProjectSchedule' AND ApplicationID = 2
	SET @SQL_SELECT = ';WITH CTE AS (
			SELECT DISTINCT 
                    JOB_TRAFFIC.ROWID RowId,
                    JOB_LOG.CL_CODE ClientCode, 
                    JOB_LOG.DIV_CODE DivisionCode, 
                    JOB_LOG.PRD_CODE ProductCode, 
                    JOB_LOG.JOB_NUMBER JobNumber, 
                    JOB_LOG.JOB_DESC JobDescription, 
                    JOB_TRAFFIC.JOB_COMPONENT_NBR JobComponentNumber, 
                    JOB_COMPONENT.JOB_COMP_DESC JobComponentDescription, 
                    JOB_TRAFFIC.TRF_CODE StatusCode, 
                    JOB_COMPONENT.EMP_CODE AS AccountExecutiveCode, 
                    JOB_TRAFFIC.COMPLETED_DATE AS JobCompleted, 
                    CAST(JOB_TRAFFIC.TRF_COMMENTS AS VARCHAR(4000)) AS Comments, 
                    TRAFFIC.TRF_DESCRIPTION AS Status,
                    JOB_TRAFFIC.COMPLETED_DATE CompletedDate, 
                    JOB_TRAFFIC.DATE_DELIVERED DeliveredDate, 
                    JOB_TRAFFIC.DATE_SHIPPED ShippedDate, 
                    JOB_TRAFFIC.RECEIVED_BY ReceivedBy, 
                    JOB_TRAFFIC.ASSIGN_1, 
                    JOB_TRAFFIC.ASSIGN_2, 
                    JOB_TRAFFIC.ASSIGN_3, 
                    JOB_TRAFFIC.ASSIGN_4, 
                    JOB_TRAFFIC.ASSIGN_5, 
                    JOB_TRAFFIC.REFERENCE TrafficReference, 
                    JOB_COMPONENT.JOB_FIRST_USE_DATE DueDate, 
                    JOB_COMPONENT.START_DATE StartDate,
                    ISNULL(JOB_LOG.JOB_RUSH_CHARGES,0) AS JobRushCharges,
                   	CASE JOB_COMPONENT.TRF_SCHEDULE_BY
		                WHEN 1 THEN 1
		                WHEN 0 THEN 0
		                ELSE (SELECT ISNULL(TRF_SCHEDULE_BY,0) FROM AGENCY)
	                END AS TrafficeScheduledBy,
					JOB_COMPONENT.JOB_MARKUP_PCT MarkupPct, 
					ISNULL(JOB_COMPONENT.NOBILL_FLAG,0)  NoBill,
					JOB_TRAFFIC.AUTO_UPDATE_STATUS AutoUpdateStatus,
					JOB_TRAFFIC.IS_TEMPLATE IsTemplate,
					ISNULL(JOB_TRAFFIC.PERCENT_COMPLETE,0) AS GutPercent,
					' + CAST(@UserCustom1 as varchar) + ' AS UserCustom1,
					ROW_NUMBER() OVER (ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_TRAFFIC.JOB_COMPONENT_NBR) AS RowNumber,
					Count(1) OVER() AS TotalRecordsFound

'
	SET @SQL_FROM = '

FROM  JOB_COMPONENT WITH(NOLOCK)
		INNER JOIN JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR'
	IF @ExcludeProjectedTasks = 1
	BEGIN
		SET @SQL_FROM = @SQL_FROM + ' INNER JOIN JOB_TRAFFIC_DET WITH(NOLOCK) ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
		'
	END
	ELSE
	BEGIN
		SET @SQL_FROM = @SQL_FROM + ' LEFT OUTER JOIN JOB_TRAFFIC_DET WITH(NOLOCK) ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
		'
	END

	SET @SQL_FROM = @SQL_FROM + '
	INNER JOIN JOB_LOG WITH(NOLOCK) ON JOB_TRAFFIC.JOB_NUMBER = JOB_LOG.JOB_NUMBER
	LEFT OUTER JOIN TRAFFIC  WITH(NOLOCK)ON JOB_TRAFFIC.TRF_CODE = TRAFFIC.TRF_CODE
	LEFT OUTER JOIN TASK_TRAFFIC_ROLE  WITH(NOLOCK)ON JOB_TRAFFIC_DET.FNC_CODE = TASK_TRAFFIC_ROLE.TRF_CODE
	LEFT OUTER JOIN EMP_TRAFFIC_ROLE  WITH(NOLOCK)ON JOB_TRAFFIC_DET.EMP_CODE = EMP_TRAFFIC_ROLE.EMP_CODE
	LEFT OUTER JOIN	JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND JOB_TRAFFIC_DET_EMPS.SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR
'
	IF @Restrictions > 0
	BEGIN
		SET @SQL_FROM = @SQL_FROM +
		'
					INNER JOIN SEC_CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
    '
	END

	IF @OfficeCount > 0
	BEGIN
		SELECT
			@SQL_FROM = @SQL_FROM + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
	END

	SET @SQL_WHERE =
	'
WHERE 1 = 1 '

	IF @ONLY_SCHEDULE_TEMPLATES = 1
	BEGIN

		SET @SQL_WHERE = @SQL_WHERE + ' AND (JOB_TRAFFIC.IS_TEMPLATE = 1)'

	END
	ELSE
	BEGIN

		IF @INCLUDE_CLOSE_JOBS = 0
		BEGIN

			SET @SQL_WHERE = @SQL_WHERE + ' AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'

		END

	END

	--if @UserCustom1 = 1
	--BEGIN
	--	SET @SQL_WHERE = @SQL_WHERE + ' AND (JOB_TRAFFIC.IS_TEMPLATE = 0)'
	--END

	IF @SHOW_ONLY_OPEN_SCHEDS = 1
	BEGIN
		SET @SQL_WHERE = @SQL_WHERE + ' AND (JOB_TRAFFIC.COMPLETED_DATE IS NULL)'
	END

	IF @Restrictions > 0
	BEGIN
		SET @SQL_WHERE = @SQL_WHERE + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + LTRIM(RTRIM(@USER_ID)) + ''')) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
	END


	SET @SQL_DYNAMIC = ' '

	--JOB_LOG
	IF DATALENGTH(@OFFICE_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_LOG.OFFICE_CODE =''' + LTRIM(RTRIM(@OFFICE_CODE)) + ''')'
	END
	IF DATALENGTH(@CL_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_LOG.CL_CODE =''' + LTRIM(RTRIM(@CL_CODE)) + ''')'
	END
	IF DATALENGTH(@DIV_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_LOG.DIV_CODE =''' + LTRIM(RTRIM(@DIV_CODE)) + ''')'
	END
	IF DATALENGTH(@PRD_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_LOG.PRD_CODE =''' + LTRIM(RTRIM(@PRD_CODE)) + ''')'
	END
	IF @JOB_NUMBER > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_LOG.JOB_NUMBER = ' + LTRIM(STR(@JOB_NUMBER,10)) + ')'
	END
	IF @CMP_ID > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_LOG.CMP_IDENTIFIER = ''' + LTRIM(RTRIM(@CMP_ID)) + ''')'
	END
	IF DATALENGTH(@SC_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_LOG.SC_CODE =''' + LTRIM(RTRIM(@SC_CODE)) + ''')'
	END

	--JOB_COMPONENT
	IF @JOB_COMPONENT_NBR > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = ' + LTRIM(STR(@JOB_COMPONENT_NBR,10)) + ')'
	END
	IF DATALENGTH(@AE_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_COMPONENT.EMP_CODE =''' + LTRIM(RTRIM(@AE_CODE)) + ''')'
	END
	IF DATALENGTH(@CUT_OFF_DATE) > 0
		AND @CUT_OFF_DATE IS NOT NULL
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (NOT (JOB_COMPONENT.JOB_FIRST_USE_DATE IS NULL)) AND (JOB_COMPONENT.JOB_FIRST_USE_DATE <= CONVERT(DATETIME, ''' + CAST(@CUT_OFF_DATE AS varchar) + ''', 102)) '
	END
	IF DATALENGTH(@JT_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_COMPONENT.JT_CODE =''' + LTRIM(RTRIM(@JT_CODE)) + ''')'
	END
	IF @GANTT = 1
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_COMPONENT.JOB_FIRST_USE_DATE IS NOT NULL OR JOB_COMPONENT.START_DATE IS NOT NULL)'
	END

	--JOB_TRAFFIC_DET
	IF DATALENGTH(@TASK_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_TRAFFIC_DET.FNC_CODE =''' + LTRIM(RTRIM(@TASK_CODE)) + ''')'
	END
	IF @IncludeOnlyPendingTasks = 1
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + 'AND JOB_TRAFFIC_DET.TEMP_COMP_DATE IS NOT NULL '
		SET @IncludeCompletedTasks = 0
	END
	IF DATALENGTH(@EMP_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE =''' + LTRIM(RTRIM(@EMP_CODE)) + ''')'
	END
	IF @IncludeCompletedTasks = 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + 'AND JOB_TRAFFIC_DET.JOB_COMPLETED_DATE IS NULL '
	END
	IF @ExcludeProjectedTasks = 1
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + 'AND (JOB_TRAFFIC_DET.TASK_STATUS <> ''P'' OR JOB_TRAFFIC_DET.TASK_STATUS IS NULL) '
	END
	IF @MILESTONES_ONLY = 1
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_TRAFFIC_DET.MILESTONE = 1)'
	END
	IF @TRAFFIC_PHASE_ID > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID = ' + LTRIM(RTRIM(CAST(@TRAFFIC_PHASE_ID AS varchar(15)))) + ')'
	END

	--TASK_TRAFFIC_ROLE
	IF DATALENGTH(@ROLE_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND ((TASK_TRAFFIC_ROLE.ROLE_CODE =''' + LTRIM(RTRIM(@ROLE_CODE)) + ''')  OR (EMP_TRAFFIC_ROLE.ROLE_CODE =''' + LTRIM(RTRIM(@ROLE_CODE)) + '''))'
	END
	IF DATALENGTH(@TRAFFIC_STATUS_CODE) > 0
	BEGIN
		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_TRAFFIC.TRF_CODE = ''' + LTRIM(RTRIM(@TRAFFIC_STATUS_CODE)) + ''')'
	END



	IF DATALENGTH(@MGR_CODE) > 0
	BEGIN
		SELECT
			@MGR_COL = CAST(AGY_SETTINGS_VALUE AS varchar(20))
		FROM AGY_SETTINGS
		WHERE AGY_SETTINGS_CODE = 'TRAFFIC_MGR_COL'

		SELECT
			@COLUMN_INDEX = SUBSTRING(@MGR_COL, 9, 1)

		SET @ASSIGN_COL = 'ASSIGN_' + @COLUMN_INDEX

		SET @SQL_DYNAMIC = @SQL_DYNAMIC + ' AND (JOB_TRAFFIC.' + @ASSIGN_COL + ' =''' + LTRIM(RTRIM(@MGR_CODE)) + ''')'

	END





	SET @SQL_GROUP_BY =
	' 
GROUP BY 
                    JOB_TRAFFIC.ROWID,
					JOB_LOG.CL_CODE,
					JOB_LOG.DIV_CODE,
					JOB_LOG.PRD_CODE, 
                    JOB_LOG.JOB_NUMBER,
					JOB_LOG.JOB_DESC,
					JOB_TRAFFIC.JOB_COMPONENT_NBR,
					JOB_COMPONENT.ROWID, 
                    JOB_COMPONENT.EMP_CODE,
					JOB_COMPONENT.JOB_COMP_DESC,
					JOB_TRAFFIC.TRF_CODE,
					JOB_TRAFFIC.COMPLETED_DATE, 
                    CAST(JOB_TRAFFIC.TRF_COMMENTS AS VarChar(4000)),
					TRAFFIC.TRF_DESCRIPTION,
					JOB_TRAFFIC.DATE_DELIVERED,
					JOB_TRAFFIC.DATE_SHIPPED, 
                    JOB_TRAFFIC.RECEIVED_BY,
                    JOB_TRAFFIC.ASSIGN_1,
					JOB_TRAFFIC.ASSIGN_2,
					JOB_TRAFFIC.ASSIGN_3, 
                    JOB_TRAFFIC.ASSIGN_4,
					JOB_TRAFFIC.ASSIGN_5, 
                    JOB_TRAFFIC.REFERENCE, 
                    JOB_COMPONENT.JOB_FIRST_USE_DATE,
					JOB_COMPONENT.START_DATE,
					JOB_LOG.JOB_RUSH_CHARGES,
					JOB_COMPONENT.TRF_SCHEDULE_BY,
					JOB_COMPONENT.JOB_MARKUP_PCT,
					JOB_COMPONENT.NOBILL_FLAG,
                    JOB_LOG.CL_CODE,
					JOB_LOG.DIV_CODE,
					JOB_LOG.PRD_CODE,
					JOB_TRAFFIC.PERCENT_COMPLETE,
					JOB_TRAFFIC.SCHEDULE_CALC,
					JOB_TRAFFIC.AUTO_UPDATE_STATUS,
					JOB_TRAFFIC.IS_TEMPLATE
) 
SELECT CTE.RowId,
		PRODUCT.OFFICE_CODE OfficeCode,
		OFFICE.OFFICE_NAME OfficeName,
		CTE.ClientCode,
		CLIENT.CL_NAME ClientName,
		CTE.DivisionCode,
		DIVISION.DIV_NAME DivisionName,
		CTE.ProductCode,
		PRODUCT.PRD_DESCRIPTION as ProductName,
		JobNumber,
		JobDescription,
		JobComponentNumber,
		JobComponentDescription,
		StatusCode,
        AccountExecutiveCode,
		ISNULL(EMPLOYEE.EMP_FNAME,'''') + ISNULL('' ''+EMPLOYEE.EMP_MI + ''.'', '''') + ISNULL('' ''+EMPLOYEE.EMP_LNAME, '''') AS AccountExecutiveName,
        JobCompleted,
        Comments,
        Status,
		CompletedDate,
		DeliveredDate,
		ShippedDate,
		ReceivedBy,
		ASSIGN_1,
		ASSIGN_2,
		ASSIGN_3,
		ASSIGN_4,
		ASSIGN_5,
		TrafficReference,
		DueDate,
		StartDate,
		JobRushCharges,
		TrafficeScheduledBy,
		MarkupPct,
		NoBill,
		AutoUpdateStatus,
		IsTemplate,
		GutPercent,
		UserCustom1,
		TotalRecordsFound
		 FROM CTE
	INNER JOIN CLIENT WITH(NOLOCK) ON CLIENT.CL_CODE = CTE.ClientCode
	INNER JOIN DIVISION WITH(NOLOCK) ON CTE.DivisionCode = DIVISION.DIV_CODE AND CTE.ClientCode = DIVISION.CL_CODE
	INNER JOIN PRODUCT WITH(NOLOCK) ON CTE.ClientCode = PRODUCT.CL_CODE AND CTE.DivisionCode = PRODUCT.DIV_CODE AND CTE.ProductCode = PRODUCT.PRD_CODE
	INNER JOIN OFFICE WITH(NOLOCK) ON OFFICE.OFFICE_CODE = PRODUCT.OFFICE_CODE
	LEFT JOIN EMPLOYEE WITH(NOLOCK) ON AccountExecutiveCode = EMPLOYEE.EMP_CODE
	 WHERE (RowNumber BETWEEN ' + CAST(@START_REC AS varchar(15)) + ' AND ' + CAST(@END_REC AS varchar(15)) + ') or (' + CAST(@END_REC AS varchar(15)) + ' = 0)
'
	PRINT @SQL_SELECT
	PRINT @SQL_FROM
	PRINT @SQL_WHERE
	PRINT @SQL_DYNAMIC
	PRINT @SQL_GROUP_BY
	--+ @SQL_WHERE
	 --+ @SQL_WHERE2
	 --+ @SQL_DYNAMIC 

	 create table #tempPS(
                    RowId int null,
					OfficeCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS null,
					OfficeName varchar(30) null,
                    ClientCode varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS null,
					ClientName varchar(40) null,
                    DivisionCode varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS null,
					DivisionName varchar(40) null,
                    ProductCode varchar(6)  COLLATE SQL_Latin1_General_CP1_CS_AS null,
					ProductName varchar(40) null,
                    JobNumber int  null,
                    JobDescription varchar(60) null,
                    JobComponentNumber smallint  null,
                    JobComponentDescription varchar(60) null,
                    StatusCode varchar(10) null,
                    AccountExecutiveCode varchar(6) null,
					AccountExecutiveName varchar(100) null,
                    JobCompleted smalldatetime null,
                    Comments varchar(max) null,
                    Status varchar(30) null,
                    CompletedDate smalldatetime null,
                    DeliveredDate smalldatetime null,
                    ShippedDate smalldatetime null,
                    ReceivedBy varchar(40) null,
                    ASSIGN_1 varchar(6) null,
                    ASSIGN_2 varchar(6) null,
                    ASSIGN_3 varchar(6) null,
                    ASSIGN_4 varchar(6) null,
                    ASSIGN_5 varchar(6) null,
                    TrafficReference varchar(150) null,
                    DueDate datetime null,
                    StartDate datetime null,
                    JobRushCharges smallint null,
                   	TrafficeScheduledBy int null,
					MarkupPct decimal(7,3) null,
					NoBill smallint null,
					AutoUpdateStatus bit null,
					IsTemplate bit null,
					GutPercent decimal(7,3) null,
					UserCustom1 int null,
					TotalRecordsFound int null
	)


	 --EXEC (@SQL_SELECT + @SQL_FROM  + @SQL_WHERE + @SQL_DYNAMIC + @SQL_GROUP_BY);

	INSERT INTO #tempPS EXEC (@SQL_SELECT + @SQL_FROM  + @SQL_WHERE + @SQL_DYNAMIC + @SQL_GROUP_BY);

	select RowId,
		OfficeCode,
		OfficeName,
		ClientCode,
		ClientName,
		DivisionCode,
		DivisionName,
		ProductCode,
		ProductName ProductDescription,
		JobNumber,
		JobDescription,
		JobComponentNumber,
		JobComponentDescription,
		StatusCode,
        AccountExecutiveCode,
        AccountExecutiveName,
        JobCompleted,
        Comments,
        Status,
		CompletedDate,
		DeliveredDate,
		ShippedDate,
		ReceivedBy,
		ASSIGN_1,
		ASSIGN_2,
		ASSIGN_3,
		ASSIGN_4,
		ASSIGN_5,
		TrafficReference,
		DueDate,
		StartDate,
		JobRushCharges,
		TrafficeScheduledBy,
		MarkupPct,
		NoBill,
		AutoUpdateStatus,
		IsTemplate,
		GutPercent,
		UserCustom1
 from #tempPS

	select top 1 @TotalRows = TotalRecordsFound from #tempPS

	drop table #tempPS
GO


