IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_JobJacket_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dd_JobJacket_Paging]
GO

/*
	declare @totalRows int
	exec usp_wv_dd_JobJacket_Paging 'SYSADM', '', '', '', '', '', 0,'','',0,0,'',0,31,@TotalRows=@totalRows OUTPUT
	print @totalRows
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_JobJacket_Paging] (
			@UserID VarChar(100),
			@OfficeCode varchar(6),
			@ClientCode varchar(6),
			@DivisionCode varchar(6),
			@ProductCode varchar(6),
			@AccountExecutive varchar(6) = null,
			@CampaignID int = null,
			@SalesClass varchar(6) = null,
			@JobType varchar(10) = null,
			@ShowClosed bit = 0,
			@SprintID int = 0,
			@Text varchar(100) = null,
			@Skip int = 0,
			@Take int = 0,
			@CPID int = 0,
			@TotalRows int out
	)
AS
	Declare @Restrictions Int,
			@EMP_CODE AS VARCHAR(6),
			@OfficeCount AS INTEGER,
			@sql nvarchar(max),
			@params nvarchar(max),
			@START_REC int,
			@END_REC int, 
			@RestrictionsCP INT

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	Select @Restrictions = Count(*) FROM SEC_CLIENT	WHERE UPPER(USER_ID) = UPPER(@UserID)

	Select @RestrictionsCP = Count(*) FROM CP_SEC_CLIENT Where CDP_CONTACT_ID = @CPID

	set @OfficeCode = Nullif(@OfficeCode,'')
	set @ClientCode = Nullif(@ClientCode,'')
	set @DivisionCode = Nullif(@DivisionCode,'')
	set @ProductCode = Nullif(@ProductCode,'')
	set @AccountExecutive = Nullif(@AccountExecutive,'')
	set @SalesClass = Nullif(@SalesClass,'')
	set @JobType = nullif(@JobType,'')
	set @CampaignID = nullif(@CampaignID,0)

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

	IF @SprintID <= 0
	BEGIN
	set @sql = N';with CTE as (SELECT CLS.Code,CLS.Name,CLS.ClientCode,CLS.DivisionCode,CLS.ProductCode,CLS.OfficeCode,ROW_NUMBER() OVER(ORDER BY  CLS.Code DESC) ROW_ID FROM (
			SELECT DISTINCT JOB_LOG.JOB_NUMBER AS Code
						,JOB_LOG.JOB_DESC Name
						,JOB_LOG.OFFICE_CODE OfficeCode
						,JOB_LOG.CL_CODE ClientCode
						,JOB_LOG.DIV_CODE DivisionCode
						,JOB_LOG.PRD_CODE ProductCode
			FROM JOB_LOG 
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER

	'
	END
	ELSE
	BEGIN
	set @sql = N';with CTE as (SELECT CLS.Code,CLS.Name,CLS.ClientCode,CLS.DivisionCode,CLS.ProductCode,CLS.OfficeCode,ROW_NUMBER() OVER(ORDER BY  CLS.Code DESC) ROW_ID FROM (SELECT DISTINCT JOB_LOG.JOB_NUMBER AS Code
						,JOB_LOG.JOB_DESC Name
						,JOB_LOG.OFFICE_CODE OfficeCode
						,JOB_LOG.CL_CODE ClientCode
						,JOB_LOG.DIV_CODE DivisionCode
						,JOB_LOG.PRD_CODE ProductCode
			FROM SPRINT_HDR
				inner JOIN BOARD on BOARD.ID = SPRINT_HDR.BOARD_ID
				inner join BOARD_JOB on BOARD.ID = BOARD_JOB.BOARD_ID
				inner join JOB_LOG on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
	'
	END

	if(@OfficeCount > 0)
	BEGIN
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		'
	END

	if( @Restrictions > 0)
	BEGIN
	--join sec client table
		set @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
				'
	END

	if( @RestrictionsCP > 0)
	BEGIN
	--join sec client table
		set @sql = @sql + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
				'
	END

	set @sql = @sql + ' WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) OR @ShowClosed = 1) '

	if( @Restrictions > 0)
	BEGIN
	--join sec client table
		set @sql = @sql + ' AND (SEC_CLIENT.USER_ID = @UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)	 '
	END

	if( @RestrictionsCP > 0)
	BEGIN
	--join sec client table
		set @sql = @sql + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)	'
	END

	if(@OfficeCode is not null)
		set @sql = @sql + 'AND (JOB_LOG.OFFICE_CODE = @OfficeCode)
		'
	if(@ClientCode is not null)
		set @sql = @sql + 'AND (JOB_LOG.CL_CODE = @ClientCode)
		'
	if(@DivisionCode is not null)
		set @sql = @sql + 'AND (JOB_LOG.DIV_CODE = @DivisionCode)
		'
	if(@ProductCode is not null)
		set @sql = @sql + 'AND (JOB_LOG.PRD_CODE = @ProductCode)
		'
	if(@SalesClass is not null)
		set @sql = @sql + 'AND (JOB_LOG.SC_CODE = @SalesClass)
		'
	if(@AccountExecutive is not null)
		set @sql = @sql + 'AND (JOB_COMPONENT.EMP_CODE = @AccountExecutive)
		'
	if(@JobType is not null)
		set @sql = @sql + 'AND (JOB_COMPONENT.JT_CODE = @JobType)
		'
	if(@CampaignID is not null)
		set @sql = @sql + 'AND (JOB_LOG.CMP_IDENTIFIER = @CampaignID)
		'
				

	IF @SprintID > 0
	BEGIN
	set @sql = @sql + '	AND  SPRINT_HDR.ID = @SprintID
	'
	END

	IF @Text is not null and @Text != ''
	BEGIN
		set @sql = @sql + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + '' - '' + JOB_LOG.JOB_DESC  + '' ('' + JOB_LOG.CL_CODE + '')''  ) LIKE  ''%' + REPLACE(LOWER(@Text),'''','''''') + '%'')
		'
	END

	set @sql = @sql + '	) CLS) SELECT Code, Name, OfficeCode, ClientCode,DivisionCode,ProductCode, ROW_ID ,(Select count(ROW_ID) from CTE) as Totalrows FROM CTE
						WHERE ROW_ID BETWEEN @START_REC AND @END_REC OR @Take = 0
			'

	print @sql

	set @params = '@OfficeCode VARCHAR(6),@ClientCode VARCHAR(6),@DivisionCode VARCHAR(6),@ProductCode VARCHAR(6),@AccountExecutive varchar(6),	@CampaignID int,@SalesClass varchar(6),@JobType varchar(10),@ShowClosed bit,@EMP_CODE AS VARCHAR(6),@UserID VarChar(100), @SprintID int,@START_REC Int,@END_REC int, @Take INT,@CPID int'



	CREATE TABLE #TEMP
	(
		  [Code] int
		, [Name] VARCHAR(100)
		, [OfficeCode]  Varchar(6)
		, [ClientCode]  Varchar(6)
		, [DivisionCode]  Varchar(6)
		, [ProductCode]  Varchar(6)
		, [ROW_ID]  INT
		, [Totalrows] INT
	)

	insert #TEMP EXEC sp_executesql @sql,@params,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@EMP_CODE,@UserID,@SprintID, @START_REC,@END_REC,@Take, @CPID

	select @TotalRows = min(Totalrows) from #TEMP

	select Code,Name,OfficeCode,ClientCode,DivisionCode,ProductCode from #TEMP

	drop table #TEMP

GO

GRANT EXECUTE ON [usp_wv_dd_JobJacket_Paging] TO PUBLIC AS dbo
GO
