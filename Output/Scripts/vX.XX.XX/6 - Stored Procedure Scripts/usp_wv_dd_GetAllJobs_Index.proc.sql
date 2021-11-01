IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_GetAllJobs_Index]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dd_GetAllJobs_Index]
GO


/*
	declare @index int
	exec usp_wv_dd_GetAllJobs_Index 'ama','','DUBBR','DUBBR','DUBBR',7538,'',0,'','',0,0,'',@Index=@index OUTPUT
	print @index
*/


CREATE procedure [dbo].[usp_wv_dd_GetAllJobs_Index](
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
			@Index int out
)
AS
	Declare @Restrictions int,
			@EMP_CODE varchar(6),
			@OfficeCount int,
			@sql nvarchar(max),
			@join nvarchar(max),
			@where nvarchar(max),
			@params nvarchar(max)

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	Select @Restrictions = Count(*) FROM SEC_CLIENT	WHERE UPPER(USER_ID) = UPPER(@UserID)

	set @OfficeCode = Nullif(@OfficeCode,'')
	set @ClientCode = Nullif(@ClientCode,'')
	set @DivisionCode = Nullif(@DivisionCode,'')
	set @ProductCode = Nullif(@ProductCode,'')
	set @JobCode = nullif(@JobCode,0)
	set @AccountExecutive = Nullif(@AccountExecutive,'')
	set @SalesClass = Nullif(@SalesClass,'')
	set @JobType = nullif(@JobType,'')
	set @CampaignID = nullif(@CampaignID,0)


	set @sql = N';with CTE as (select ROW_NUMBER() OVER(ORDER BY  ID DESC) - 1 [Index],ID from (
	SELECT DISTINCT JOB_LOG.JOB_NUMBER ID 
			,JOB_LOG.JOB_DESC Name
			,JOB_LOG.OFFICE_CODE OfficeCode
			,JOB_LOG.CL_CODE ClientCode
			,JOB_LOG.DIV_CODE DivisionCode
			,JOB_LOG.PRD_CODE ProductCode
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
		'
	END
	ELSE
	BEGIN
		set @join = N'	FROM SPRINT_HDR
				inner JOIN BOARD on BOARD.ID = SPRINT_HDR.BOARD_ID
				inner join BOARD_JOB on BOARD.ID = BOARD_JOB.BOARD_ID
				inner join JOB_LOG on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER

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
		set @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
		'

		set @where = @where + 'AND (SEC_CLIENT.USER_ID = @UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		'
	END

	if @Text is not null
	begin
		set @where = @where + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + '' - '' + JOB_LOG.JOB_DESC  + '' ('' + JOB_LOG.CL_CODE + '')''  ) LIKE  ''%' + REPLACE(LOWER(@Text),'''','''''') + '%'')
		'
	end

	set @sql = @sql + @join + @where + ') a ) select @Index = [Index] from CTE WHERE ID=@JobCode'

	print @sql

	SELECT @params = '@UserID VarChar(100),
			@OfficeCode varchar(6),
			@ClientCode varchar(6),
			@DivisionCode varchar(6),
			@ProductCode varchar(6),
			@JobCode int,
			@AccountExecutive varchar(6) = null,
			@CampaignID int = null,
			@SalesClass varchar(6) = null,
			@JobType varchar(10) = null,
			@Text varchar(100),
			@ShowClosed bit = 0,
			@SprintID int = 0,
			@EMP_CODE varchar(6),
			@Index int OUTPUT'

	EXEC sp_executesql @sql, @params, @UserID, @OfficeCode, @ClientCode,@DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@Text,@ShowClosed,@SprintID,@EMP_CODE,@Index=@Index OUTPUT

GO

GRANT EXECUTE ON [usp_wv_dd_GetAllJobs_Index] TO PUBLIC AS dbo
GO
