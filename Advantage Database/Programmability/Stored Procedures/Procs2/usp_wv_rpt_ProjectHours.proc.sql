if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_rpt_ProjectHours]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_rpt_ProjectHours]
GO
--Webvantage
CREATE PROCEDURE [dbo].[usp_wv_rpt_ProjectHours] 
@UserID as VarChar(100),
@StartDate smalldatetime,
@EndDate smalldatetime,
@SortOrder varchar(1),
@OpenJobsOnly smallint,
@Group smallint

AS




Declare @Restrictions Int,
		@sql nvarchar(4000),
		@sql2 nvarchar(4000),
		@paramlist nvarchar(4000),
		@paramlist2 nvarchar(4000), @NumberRecords int, @RowCount int, @job int, @comp int, @emp varchar(6), @count decimal(18,2), @posted decimal(18,2), @allowed decimal(18,2)

		
Select @Restrictions = Count(*) FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID);
--	[]           VARCHAR(50) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,

DECLARE @EMP_CDE AS VARCHAR(6)
DECLARE @RestrictionsOffice AS INTEGER

SELECT @EMP_CDE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @RestrictionsOffice = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CDE

CREATE TABLE #job 
(
	RowID int IDENTITY(1, 1), 
	[JobNum]			INT NULL,
	[JobDesc]           VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CompNum]		SMALLINT NULL,
	[CompDesc]       VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[DCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[DName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[PCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[PName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[TRF_CODE]			varchar(10),
	[MGR_EMP_CODE]		varchar(6),	
	[JOBPAD]			varchar(6),
	[COMPPAD]			varchar(2),
	[CMP_CODE]			varchar(6),
	[CMP_NAME]			varchar(128),
	[CMP_ID]			int
)	

CREATE TABLE #MY_DATA --MASTER TABLE TO RETURN
(
	RowID int IDENTITY(1, 1), 
	[JobNum]			INT NULL,
	[JobDesc]           VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CompNum]		SMALLINT NULL,
	[CompDesc]       VARCHAR(60) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[CName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[DCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[DName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[PCode]           VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[PName]           VARCHAR(40) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[EmpCode]       VARCHAR(6) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[EmpName]       VARCHAR(100) COLLATE SQL_Latin1_General_CP1_CS_AS NULL,
	[HoursPosted]    DECIMAL(18,2) NULL,
	[HoursAssigned]  DECIMAL(18,2) NULL,
	[HoursAllowed]  DECIMAL(18,2) NULL,
	[TotalHoursPosted]   DECIMAL(18,2) NULL,
	[TRF_CODE]			varchar(10),
	[MGR_EMP_CODE]		varchar(6),
	[JOBPAD]			varchar(6),
	[COMPPAD]			varchar(2),
	[CMP_CODE]			varchar(6),
	[CMP_NAME]			varchar(128),
	[CMP_ID]			int
)	


SELECT @sql = 'INSERT INTO #job (JobNum,JobDesc,CompNum,CompDesc,CCode,CName,DCode,DName,PCode,PName,TRF_CODE,MGR_EMP_CODE,JOBPAD,COMPPAD,CMP_CODE,CMP_NAME,CMP_ID)
				SELECT EMP_TIME_DTL.JOB_NUMBER, JOB_LOG.JOB_DESC, EMP_TIME_DTL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, 
                      JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, JOB_TRAFFIC.TRF_CODE, JOB_TRAFFIC.MGR_EMP_CODE, 
                      RIGHT(REPLICATE(''0'', 6) + CAST(EMP_TIME_DTL.JOB_NUMBER AS VARCHAR(6)), 6), RIGHT(REPLICATE(''0'', 2) + CAST(EMP_TIME_DTL.JOB_COMPONENT_NBR AS VARCHAR(2)), 2),
					  CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME, JOB_LOG.CMP_IDENTIFIER
				FROM  JOB_COMPONENT INNER JOIN
                      PRODUCT INNER JOIN
                      JOB_LOG ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND 
                      PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
                      DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER INNER JOIN
                      EMP_TIME_DTL INNER JOIN
                      EMP_TIME ON EMP_TIME_DTL.ET_ID = EMP_TIME.ET_ID ON JOB_COMPONENT.JOB_NUMBER = EMP_TIME_DTL.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = EMP_TIME_DTL.JOB_COMPONENT_NBR LEFT OUTER JOIN
                      JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
                      JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR LEFT OUTER JOIN
					  CAMPAIGN ON CAMPAIGN.CMP_IDENTIFIER = JOB_LOG.CMP_IDENTIFIER'
			If @Restrictions > 0
				Begin		
					SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
				End
			If @RestrictionsOffice > 0 
				Begin
				  SELECT @sql = @sql  + ' INNER JOIN EMP_OFFICE ON EMP_OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CDE + ''''
				End	

			SELECT @sql = @sql + ' WHERE (EMP_TIME.EMP_DATE >= @StartDate) AND (EMP_TIME.EMP_DATE <= @EndDate)'			
			if @OpenJobsOnly = 1
				Begin
					SELECT @sql = @sql + ' AND (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12)))'
				End			 
--			if @StartDate <> '1/1/1950' and @EndDate <> '1/1/2050'
--			    Begin
--			        SELECT @sql = @sql + ' And (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE >= @StartDate)
--							                And (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE <= @EndDate)'
--			    End
--			if @StartDate = '1/1/1950' and @EndDate = '1/1/2050'
--			    Begin
--			        SELECT @sql = @sql + 'And (((V_JOB_TRAFFIC_DET.JOB_REVISED_DATE >= @StartDate)
--							                And (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE <= @EndDate)) or (V_JOB_TRAFFIC_DET.JOB_REVISED_DATE is null))'
--			    End
			if @Restrictions > 0
				Begin
					SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				End

			SELECT @sql = @sql + ' GROUP BY EMP_TIME_DTL.JOB_NUMBER, JOB_LOG.JOB_DESC, EMP_TIME_DTL.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, 
                      JOB_LOG.CL_CODE, CLIENT.CL_NAME, JOB_LOG.DIV_CODE, DIVISION.DIV_NAME, JOB_LOG.PRD_CODE, PRODUCT.PRD_DESCRIPTION, 
                      JOB_TRAFFIC.TRF_CODE, JOB_TRAFFIC.MGR_EMP_CODE, CAMPAIGN.CMP_CODE, CAMPAIGN.CMP_NAME, JOB_LOG.CMP_IDENTIFIER'
			
	SELECT @paramlist = '@UserID VarChar(100), @StartDate DateTime, @EndDate DateTime'
	PRINT @sql
	EXEC sp_executesql @sql, @paramlist, @UserID, @StartDate, @EndDate


INSERT INTO #MY_DATA SELECT #job.JobNum, #job.JobDesc, #job.CompNum, #job.CompDesc, 
                      #job.CCode, #job.CName, #job.DCode, #job.DName, #job.PCode, #job.PName,
					  ET.EMP_CODE, dbo.udf_get_empl_name(ET.EMP_CODE, 'FML'), SUM(EMP_HOURS),0,0,0, #job.TRF_CODE, #job.MGR_EMP_CODE, #job.JOBPAD, #job.COMPPAD,
					  #job.CMP_CODE, #job.CMP_NAME, #job.CMP_ID
				FROM  EMP_TIME ET INNER JOIN
                      EMP_TIME_DTL ETD ON ET.ET_ID = ETD.ET_ID INNER JOIN
					  #job ON #job.JobNum = ETD.JOB_NUMBER AND 
						#job.CompNum = ETD.JOB_COMPONENT_NBR	
				WHERE (ET.EMP_DATE >= @StartDate) AND (ET.EMP_DATE <= @EndDate)							
			 GROUP BY  #job.JobNum, #job.JobDesc, #job.CompNum, #job.CompDesc, 
                      #job.CCode, #job.CName, #job.DCode, #job.DName, #job.PCode, #job.PName,
					  ET.EMP_CODE,#job.TRF_CODE, #job.MGR_EMP_CODE, #job.JOBPAD, #job.COMPPAD,#job.CMP_CODE, #job.CMP_NAME, #job.CMP_ID

INSERT INTO #MY_DATA SELECT #job.JobNum, #job.JobDesc, #job.CompNum, #job.CompDesc, 
                      #job.CCode, #job.CName, #job.DCode, #job.DName, #job.PCode, #job.PName,
					  JTDE.EMP_CODE, dbo.udf_get_empl_name(JTDE.EMP_CODE, 'FML'), 0,SUM(JTDE.HOURS_ALLOWED),SUM(JTDE.HOURS_ALLOWED),0, #job.TRF_CODE, #job.MGR_EMP_CODE, #job.JOBPAD, #job.COMPPAD,
					  #job.CMP_CODE, #job.CMP_NAME, #job.CMP_ID
				FROM  JOB_TRAFFIC_DET JTD INNER JOIN
                      JOB_TRAFFIC_DET_EMPS JTDE ON JTD.JOB_NUMBER = JTDE.JOB_NUMBER AND JTD.JOB_COMPONENT_NBR = JTDE.JOB_COMPONENT_NBR AND JTD.SEQ_NBR = JTDE.SEQ_NBR INNER JOIN
					  #job ON #job.JobNum = JTD.JOB_NUMBER AND 
						#job.CompNum = JTD.JOB_COMPONENT_NBR							
			 GROUP BY  #job.JobNum, #job.JobDesc, #job.CompNum, #job.CompDesc, 
                      #job.CCode, #job.CName, #job.DCode, #job.DName, #job.PCode, #job.PName,
					  JTDE.EMP_CODE,#job.TRF_CODE, #job.MGR_EMP_CODE, #job.JOBPAD, #job.COMPPAD,#job.CMP_CODE, #job.CMP_NAME, #job.CMP_ID

INSERT INTO #MY_DATA SELECT #job.JobNum, #job.JobDesc, #job.CompNum, #job.CompDesc, 
                      #job.CCode, #job.CName, #job.DCode, #job.DName, #job.PCode, #job.PName,
					  ET.EMP_CODE, dbo.udf_get_empl_name(ET.EMP_CODE, 'FML'), 0,0,0,SUM(EMP_HOURS), #job.TRF_CODE, #job.MGR_EMP_CODE, #job.JOBPAD, #job.COMPPAD,
					  #job.CMP_CODE, #job.CMP_NAME, #job.CMP_ID
				FROM  EMP_TIME ET INNER JOIN
                      EMP_TIME_DTL ETD ON ET.ET_ID = ETD.ET_ID INNER JOIN
					  #job ON #job.JobNum = ETD.JOB_NUMBER AND 
						#job.CompNum = ETD.JOB_COMPONENT_NBR					
			 GROUP BY  #job.JobNum, #job.JobDesc, #job.CompNum, #job.CompDesc, 
                      #job.CCode, #job.CName, #job.DCode, #job.DName, #job.PCode, #job.PName,
					  ET.EMP_CODE,#job.TRF_CODE, #job.MGR_EMP_CODE, #job.JOBPAD, #job.COMPPAD,#job.CMP_CODE, #job.CMP_NAME, #job.CMP_ID
	
--SELECT @NumberRecords = COUNT(*) FROM #MY_DATA
--SET @RowCount = 1

--WHILE @RowCount <= @NumberRecords
--BEGIN
-- SELECT @job = JobNum, @comp = CompNum, @emp = EmpCode
-- FROM #MY_DATA
-- WHERE RowID = @RowCount

-- SELECT @count = SUM(EMP_TIME_DTL.EMP_HOURS)
--				FROM EMP_TIME INNER JOIN
--									  EMP_TIME_DTL ON EMP_TIME.ET_ID = EMP_TIME_DTL.ET_ID INNER JOIN
--									  JOB_COMPONENT ON EMP_TIME_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
--									  EMP_TIME_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
--									  JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
--				WHERE (EMP_TIME_DTL.JOB_NUMBER = @job) AND (EMP_TIME_DTL.JOB_COMPONENT_NBR = @comp) AND (EMP_TIME.EMP_CODE = @emp)
--				GROUP BY EMP_TIME.EMP_CODE, EMP_TIME_DTL.JOB_NUMBER, EMP_TIME_DTL.JOB_COMPONENT_NBR

-- SELECT @posted = SUM(EMP_TIME_DTL.EMP_HOURS)
--				FROM EMP_TIME INNER JOIN
--									  EMP_TIME_DTL ON EMP_TIME.ET_ID = EMP_TIME_DTL.ET_ID INNER JOIN
--									  JOB_COMPONENT ON EMP_TIME_DTL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND 
--									  EMP_TIME_DTL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR INNER JOIN
--									  JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
--				WHERE (EMP_TIME_DTL.JOB_NUMBER = @job) AND (EMP_TIME_DTL.JOB_COMPONENT_NBR = @comp) AND (EMP_TIME.EMP_CODE = @emp) AND (EMP_TIME.EMP_DATE >= @StartDate) AND (EMP_TIME.EMP_DATE <= @EndDate)
--				GROUP BY EMP_TIME.EMP_CODE, EMP_TIME_DTL.JOB_NUMBER, EMP_TIME_DTL.JOB_COMPONENT_NBR

--SELECT @allowed = SUM(JOB_TRAFFIC_DET_EMPS.HOURS_ALLOWED)
--				FROM         PRODUCT INNER JOIN
--									  JOB_LOG ON PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND 
--									  PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE INNER JOIN
--									  DIVISION ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE INNER JOIN
--									  CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE INNER JOIN
--									  JOB_COMPONENT INNER JOIN
--									  JOB_TRAFFIC INNER JOIN
--									  JOB_TRAFFIC_DET ON JOB_TRAFFIC.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER AND 
--									  JOB_TRAFFIC.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR INNER JOIN
--									  JOB_TRAFFIC_DET_EMPS ON JOB_TRAFFIC_DET.JOB_NUMBER = JOB_TRAFFIC_DET_EMPS.JOB_NUMBER AND 
--									  JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET_EMPS.JOB_COMPONENT_NBR AND 
--									  JOB_TRAFFIC_DET.SEQ_NBR = JOB_TRAFFIC_DET_EMPS.SEQ_NBR ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
--									  JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR ON 
--									  JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
--				WHERE (JOB_TRAFFIC_DET.JOB_NUMBER = @job) AND (JOB_TRAFFIC_DET.JOB_COMPONENT_NBR = @comp) AND (JOB_TRAFFIC_DET_EMPS.EMP_CODE = @emp)
--				GROUP BY JOB_TRAFFIC_DET.JOB_NUMBER, JOB_TRAFFIC_DET.JOB_COMPONENT_NBR,JOB_TRAFFIC_DET_EMPS.EMP_CODE

--IF @count > 0
--Begin
--	UPDATE #MY_DATA
--	SET TotalHoursPosted = @count, HoursPosted = @posted, HoursAllowed = @allowed, HoursAssigned = @allowed
--	WHERE (JobNum = @job) AND (CompNum = @comp) AND (EmpCode = @emp)
--End

--SET @count = 0
--SET @posted = 0
--SET @allowed = 0
--SET @RowCount = @RowCount + 1
--END	


SELECT @sql = ''

if @Group = 1 or @Group = 2
Begin
	SELECT @sql = 'SELECT
		JobNum,
		JobDesc as [Job Name],
		CompNum as [Component Number],
		CompDesc as [Component Name],
		CCode as [Client Code],
		CName as [Client Name],
		DCode as [Division Code],
		DName as [Division Name],
		PCode as [Product Code],
		PName as [Product Name],
		EmpCode as [Employee Code],
		EmpName as [Employee Name],
		Sum(HoursPosted) AS HoursPosted,
		Sum(HoursAssigned) AS HoursAssigned,
		Sum(HoursAllowed) AS HoursAllowed,
		Sum(TotalHoursPosted) AS TotalHoursPosted,
		TRF_CODE,
		MGR_EMP_CODE,
		JOBPAD,
		COMPPAD,
		CMP_CODE,
		CMP_NAME,
		CMP_ID
	FROM
		#MY_DATA
	GROUP BY JobNum,JobDesc,CompNum,CompDesc,CCode,CName,DCode,DName,PCode,PName,EmpCode,EmpName,TRF_CODE,MGR_EMP_CODE,JOBPAD,COMPPAD,CMP_CODE,CMP_NAME,CMP_ID'
End
Else
Begin
	SELECT @sql = 'SELECT
		JobNum as [Job Number],
		JobDesc as [Job Name],
		CompNum as [Component Number],
		CompDesc as [Component Name],
		CCode as [Client Code],
		CName as [Client Name],
		DCode as [Division Code],
		DName as [Division Name],
		PCode as [Product Code],
		PName as [Product Name],
		EmpCode as [Employee Code],
		EmpName as [Employee Name],
		Sum(HoursPosted) as [Hours Posted],
		Sum(HoursAssigned) as [Hours Assigned],
		Sum(HoursAllowed) as [Hours Allowed],
		Sum(TotalHoursPosted) as [Total Hours Posted],
		TRF_CODE,
		MGR_EMP_CODE,
		JOBPAD,
		COMPPAD,
		CMP_CODE,
		CMP_NAME,
		CMP_ID
	FROM
		#MY_DATA
	GROUP BY JobNum,JobDesc,CompNum,CompDesc,CCode,CName,DCode,DName,PCode,PName,EmpCode,EmpName,TRF_CODE,MGR_EMP_CODE,JOBPAD,COMPPAD,CMP_CODE,CMP_NAME,CMP_ID'
End			


if @SortOrder = '1'
Begin
	SET @sql = @sql + ' ORDER BY CCode,DCode,PCode,JobNum,CompNum'
End
if @SortOrder = '2'
Begin
	SET @sql = @sql + ' ORDER BY JobNum, CompNum'
End
if @SortOrder = '3'
Begin
	SET @sql = @sql + ' ORDER BY EmpName, JobNum, CompNum'
End
if @SortOrder = '4'
Begin
	SET @sql = @sql + ' ORDER BY CCode,DCode,PCode,CMP_ID,JobNum,CompNum'
End

PRINT(@sql)
EXEC(@sql)

			
DROP TABLE #MY_DATA;
--	PRINT @sql		





