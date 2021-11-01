IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_GetDivisions_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dd_GetDivisions_Paging]
GO


/*
	declare @totalRows int
	exec usp_wv_dd_GetDivisions_Paging 'ama','','',0,'',0,10,@TotalRows=@totalRows OUTPUT
	print @totalRows
*/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetDivisions_Paging](
			@UserID VarChar(100) , 
			@OfficeCode  VarChar(6) = '',
			@ClientCode VarChar(6)  = '',
			@SprintID int = 0,
			@Text VARCHAR(100) = '',
			@Skip int = 0,
			@Take int = 0,
			@CPID int = 0,
			@TotalRows int out)
AS
/*=========== QUERY ===========*/

	DECLARE @Restrictions INT, @RestrictionsCP INT
	
	SET NOCOUNT ON

	DECLARE @EMP_CODE AS VARCHAR(6),
			@OfficeCount AS INTEGER,
			@sql	nvarchar(4000),
			@join	nvarchar(4000),
			@where	nvarchar(4000),
			@paramlist nvarchar(4000),
			@START_REC int,
			@END_REC int

	if @SKIP > 0
	BEGIN
		SET @START_REC = @SKIP + 1;
		SET @END_REC = @SKIP + @TAKE + 1;
	END
	ELSE
	BEGIN
		SET @START_REC = @SKIP;
		SET @END_REC = @TAKE;
	END


	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE
	
	SELECT @Restrictions = COUNT(1) FROM   SEC_CLIENT WITH(NOLOCK) WHERE  UPPER(USER_ID) = UPPER(@UserID);

	Select @RestrictionsCP = Count(*) FROM CP_SEC_CLIENT Where CDP_CONTACT_ID = @CPID

	
	SET @ClientCode = ISNULL(RTRIM(LTRIM(@ClientCode)), '');

	SET @ClientCode = nullif(@ClientCode,'')
	SET @OfficeCode = nullif(@OfficeCode,'')


	set @sql = '	;WITH CTE AS (SELECT a.*,ROW_NUMBER() OVER(ORDER BY  a.Name) ROW_ID FROM (SELECT DISTINCT DIVISION.DIV_CODE AS Code
			,DIVISION.DIV_CODE + '' - '' + ISNULL(DIVISION.DIV_NAME, '''') + '' | '' + ISNULL(CLIENT.CL_CODE,'''') AS DESCRIPTION
			,CLIENT.CL_CODE
			,DIVISION.DIV_NAME Name
			,DIVISION.CL_CODE + '','' + DIVISION.DIV_CODE ID
		'

	set @where = 'WHERE  (DIVISION.ACTIVE_FLAG = 1) AND (CLIENT.ACTIVE_FLAG = 1)
			AND LOWER(DIVISION.DIV_NAME + '' ('' + DIVISION.DIV_CODE + '')'') LIKE ''%' + REPLACE(LOWER(@Text),'''','''''') + '%''
			'

	if(@ClientCode is not null)
		set @where = @where + 'AND (CLIENT.CL_CODE = @ClientCode)
	'
	if(@OfficeCode is not null)
		set @where = @where + 'AND (PRODUCT.OFFICE_CODE = @OfficeCode)
	'

	if @SprintID > 0
	BEGIN
		set @join = 'FROM   SPRINT_HDR
			INNER JOIN BOARD on BOARD.ID = SPRINT_HDR.BOARD_ID
			INNER JOIN BOARD_JOB on BOARD.ID = BOARD_JOB.BOARD_ID
			INNER JOIN JOB_LOG on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
			INNER JOIN CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE
			INNER JOIN DIVISION ON  CLIENT.CL_CODE = DIVISION.CL_CODE
			INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
		'

		set @where = @where + 'AND (SPRINT_HDR.ID = @SprintID OR @SprintID = 0)
		'
	END
	ELSE
	BEGIN
		set @join = 'FROM   CLIENT
			INNER JOIN DIVISION	ON  CLIENT.CL_CODE = DIVISION.CL_CODE
			INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE 
		'
	END

	if @OfficeCount > 0
	BEGIN

		set @join = @join + 'INNER JOIN  EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
			'
	END

	if @Restrictions > 0
	BEGIN
		set @join = @join + 'INNER JOIN SEC_CLIENT ON  DIVISION.CL_CODE = SEC_CLIENT.CL_CODE	AND DIVISION.DIV_CODE = SEC_CLIENT.DIV_CODE
			'


		set @where = @where + 'AND (SEC_CLIENT.USER_ID = @UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
			'

	END	

	if @RestrictionsCP > 0
	BEGIN
		set @join = @join + 'INNER JOIN CP_SEC_CLIENT ON DIVISION.CL_CODE = CP_SEC_CLIENT.CL_CODE AND DIVISION.DIV_CODE = CP_SEC_CLIENT.DIV_CODE
			'


		set @where = @where + 'AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)
			'

	END

	set @sql =  @sql + @join + @where + ') a)
	 SELECT *, (Select count(ROW_ID) from CTE) as Totalrows FROM CTE WHERE ROW_ID BETWEEN @START_REC AND @END_REC OR @Take = 0
	'

	print @sql

	CREATE TABLE #TEMP
	(
		  [Code] Varchar(6)
		, [Description] varchar(100)
		, [CL_CODE] varchar(6)
		, [Name] VARCHAR(100)
		, [ID] varchar(14)
		, [ROW_ID]  INT
		, [Totalrows] INT
	)


	SELECT @paramlist = '@UserID VarChar(100),@OfficeCode Varchar(6),@ClientCode varchar(6),@SprintID int,@Text varchar(100),@EMP_CODE varchar(6),@START_REC Int,@END_REC int,@Take int,@CPID int'

	insert #TEMP EXEC sp_executesql @sql, @paramlist, @UserID, @OfficeCode, @ClientCode, @SprintID, @Text,@EMP_CODE, @START_REC, @END_REC,@Take,@CPID

	select @TotalRows = max(Totalrows) from #TEMP

	select Code,Description, CL_CODE, Name, ID from #TEMP

	drop table #TEMP

GO

GRANT EXECUTE ON [usp_wv_dd_GetDivisions_Paging] TO PUBLIC AS dbo
GO

