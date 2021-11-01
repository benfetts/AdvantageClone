IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_GetAllJobComps_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dd_GetAllJobComps_Paging]
GO

/*
	declare @totalRows int
	exec usp_wv_dd_GetAllJobComps_Paging 'ama','' , '', '', '', 0, '',0,'','',1,0,'',0,100,@TotalRows=@totalRows OUTPUT
	print @totalRows
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobComps_Paging] (
			@UserID VarChar(100),
			@OfficeCode varchar(6),
			@ClientCode varchar(6),
			@DivisionCode varchar(6),
			@ProductCode varchar(6),
			@JobCode int,
			@AccountExecutive varchar(6) = null,
			@CampaignID int = null,
			@SalesClass varchar(6) = null,
			@JobType varchar(10) = null,
			@ShowClosed bit = 0,
			@SprintID int = 0,
			@Text varchar(100),
			@Skip int = 0,
			@Take int = 0,
			@CPID int = 0,
			@TotalRows int out
	)
AS
	Declare @Restrictions Int
	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @OfficeCount AS INTEGER
	DECLARE @sql nvarchar(max),
			@join nvarchar(max),
			@where nvarchar(max),
			@params nvarchar(max),
			@recordCount INTEGER,
			@Short smallint,
			@START_REC int,
			@END_REC int, 
			@RestrictionsCP INT

	if @SKIP > 0
	BEGIN
		SET @START_REC = @SKIP + 1;
		SET @END_REC = @SKIP + @TAKE;
	END
	ELSE
	BEGIN
		SET @START_REC = @SKIP;
		SET @END_REC = @TAKE;
	END



	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	Select @Restrictions = Count(*) FROM SEC_CLIENT	WHERE UPPER(USER_ID) = UPPER(@UserID)

	Select @RestrictionsCP = Count(*) FROM CP_SEC_CLIENT Where CDP_CONTACT_ID = @CPID

	set @OfficeCode = Nullif(@OfficeCode,'')
	set @ClientCode = Nullif(@ClientCode,'')
	set @DivisionCode = Nullif(@DivisionCode,'')
	set @ProductCode = Nullif(@ProductCode,'')
	set @JobCode = nullif(@JobCode,0)
	set @AccountExecutive = Nullif(@AccountExecutive,'')
	set @SalesClass = Nullif(@SalesClass,'')
	set @JobType = nullif(@JobType,'')
	set @CampaignID = nullif(@CampaignID,0)

	set @sql = N'	;WITH CTE AS (SELECT a.*,ROW_NUMBER() OVER(ORDER BY  a.JobCode DESC, a.JobCompCode ASC) ROW_ID FROM (SELECT ltrim(str(JOB_LOG.JOB_NUMBER)) + ''-'' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code,
						ltrim(str(JOB_LOG.JOB_NUMBER)) + ''-'' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + '' | '' + JOB_COMPONENT.JOB_COMP_DESC + '' | '' + JOB_LOG.CL_CODE + '' - '' + JOB_LOG.DIV_CODE + '' - '' + JOB_LOG.PRD_CODE + '''' AS Description
						,JOB_LOG.CL_CODE
						 ,JOB_COMPONENT.JOB_COMP_DESC Name
						 ,JOB_LOG.JOB_NUMBER JobCode
						 ,JOB_LOG.CL_CODE ClientCode
						 ,JOB_LOG.DIV_CODE DivisionCode
						 ,JOB_LOG.PRD_CODE ProductCode
						 ,JOB_COMPONENT.JOB_COMPONENT_NBR JobCompCode
						 ,CAST(JOB_LOG.JOB_NUMBER as varchar(6)) + '','' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR as varchar(10)) ID
						 ,JOB_LOG.OFFICE_CODE OfficeCode
						 ,CASE WHEN JOB_TRAFFIC.JOB_NUMBER IS NOT NULL THEN 1 ELSE 0 END AS HasSchedule
	'

	set @where = 'WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) OR (@ShowClosed = 1))
	'

	if(@OfficeCode is not null)
		set @where = @where + 'AND (JOB_LOG.OFFICE_CODE = @OfficeCode)
		'
	if(@ClientCode is not null)
		set @where = @where + 'AND (JOB_LOG.CL_CODE = @ClientCode)
		'
	if(@DivisionCode is not null)
		set @where = @where + 'AND (JOB_LOG.DIV_CODE = @DivisionCode)
		'
	if(@ProductCode is not null)
		set @where = @where + 'AND (JOB_LOG.PRD_CODE = @ProductCode)
		'
	if(@JobCode is not null)
		set @where = @where + 'AND (JOB_LOG.JOB_NUMBER = @JobCode)
		'
	if(@AccountExecutive is not null)
		set @where = @where + 'AND (JOB_COMPONENT.EMP_CODE = @AccountExecutive)
		'
	if(@SalesClass is not null)
		set @where = @where + 'AND (JOB_LOG.SC_CODE = @SalesClass)
		'
	if(@JobType is not null)
		set @where = @where + 'AND (JOB_COMPONENT.JT_CODE = @JobType)
		'
	if(@CampaignID is not null)
		set @where = @where + 'AND (JOB_LOG.CMP_IDENTIFIER = @CampaignID)
		'


	IF @SprintID <= 0
	BEGIN
		set @join = N'FROM JOB_LOG 
					INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
					LEFT OUTER JOIN	JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
		'
	END
	ELSE
	BEGIN
		set @join = N'FROM SPRINT_HDR
					inner JOIN BOARD on BOARD.ID = SPRINT_HDR.BOARD_ID
					inner join BOARD_JOB on BOARD.ID = BOARD_JOB.BOARD_ID
					inner join JOB_LOG on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
					INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
					LEFT OUTER JOIN	JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
		'

		set @where = @where + '	AND  SPRINT_HDR.ID = @SprintID
		'
	END


	if(@OfficeCount > 0)
	BEGIN
		set @join = @join + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		'
	END

	if( @Restrictions > 0)
	BEGIN
	--join sec client table
		set @join = @join +  ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
		'

		set @where = @where + 'AND (SEC_CLIENT.USER_ID = @UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		'
	END

	if( @RestrictionsCP > 0)
	BEGIN
	--join sec client table
		set @join = @join +  ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
		'

		set @where = @where + 'AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)
		'
	END

	if @Text is not null
	begin
		set @where = @where + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + ''/'' + RIGHT(''000''+CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3)),3) + '' - '' + JOB_COMPONENT.JOB_COMP_DESC  + '' ('' + JOB_LOG.CL_CODE + '')'') LIKE  ''%' + REPLACE(LOWER(@Text),'''','''''') + '%'')
		'
	end


	set @sql = @sql + @join + @where + ') a)
	 SELECT *, (Select count(ROW_ID) from CTE) as Totalrows FROM CTE WHERE ROW_ID BETWEEN @START_REC AND @END_REC OR @Take = 0
	 '

	print @sql

	set @params = '@OfficeCode VARCHAR(6),@ClientCode VARCHAR(6),@DivisionCode VARCHAR(6),@ProductCode VARCHAR(6),@JobCode int,@AccountExecutive varchar(6),@CampaignID int,@SalesClass varchar(6),@JobType varchar(10),@ShowClosed bit,@EMP_CODE AS VARCHAR(6),@UserID VarChar(100), @SprintID int,@Text varchar(100),@START_REC Int,@END_REC int, @Take INT,@CPID int'
	

		CREATE TABLE #TEMP
	(
		  [Code] varchar(10)
		, [Description] VARCHAR(100)
		, [CL_CODE]  Varchar(6)
		, [Name] VARCHAR(100)
		, [JobCode] int
		, [ClientCode]  Varchar(6)
		, [DivisionCode]  Varchar(6)
		, [ProductCode]  Varchar(6)
		, [JobCompCode] SMALLINT
		, [ID] varchar(20)
		, [OfficeCode] varchar(6)
		, HasSchedule INT
		, [ROW_ID]  int
		, [Totalrows] INT
	)

	insert #TEMP exec sp_executesql @sql,@params,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@EMP_CODE,@UserID,@SprintID,@Text, @START_REC, @END_REC,@Take, @CPID

	select @TotalRows = max(Totalrows) from #TEMP

	select Code,Description,CL_CODE,Name,JobCode,OfficeCode,ClientCode,DivisionCode,ProductCode,JobCompCode,ID,HasSchedule from #TEMP

	drop table #TEMP

GO

GRANT EXECUTE ON [usp_wv_dd_GetAllJobComps_Paging] TO PUBLIC AS dbo
GO

