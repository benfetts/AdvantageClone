IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_GetClients_Paging]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dd_GetClients_Paging]
GO


/*****************************************************************
Gets Clients for Drop Down s
	declare @totalRows int
	exec usp_wv_dd_GetClients_Paging 'ama','','',0,'Arby''s',0,0,@TotalRows=@totalRows OUTPUT
	print @totalRows
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetClients_Paging]( 
			@UserID VarChar(100),
			@FromApp VarChar(6),
			@OfficeCode   VarChar(6) = null,
			@SprintID int = 0,
			@Text VARCHAR(100) = '',
			@Skip int = 0,
			@Take int = 10,
			@TotalRows int out)
AS
	Declare @Restrictions Int,
			@sql	nvarchar(4000),
			@join	nvarchar(4000),
			@where	nvarchar(4000),
			@START_REC int,
			@END_REC int,
			@paramlist nvarchar(4000)

	Set NoCount on

	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @OfficeCount AS INTEGER

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = UPPER(@UserID);

	SELECT @OfficeCount = COUNT(1) FROM EMP_OFFICE WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE;

	SELECT @Restrictions = COUNT(1) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID);

	SET @OfficeCode = nullif(@OfficeCode,'')

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


	--select
	set @sql = ';WITH CTE AS (SELECT CLS.*
							,ROW_NUMBER() OVER(ORDER BY  CLS.Name) ROW_ID
				'
	--basic where
	set @where = ' WHERE (CLIENT.ACTIVE_FLAG = 1)
				 AND LOWER(CLIENT.CL_NAME + '' ('' + CLIENT.CL_CODE + '')'') LIKE ''%' + REPLACE(LOWER(@Text),'''','''''') + '%''
	'

	if(@OfficeCode is not null)
		set @where = @where + 'AND PRODUCT.OFFICE_CODE = ISNULL( @OfficeCode,PRODUCT.OFFICE_CODE)
		'

	IF @SprintID <= 0
	BEGIN
		--join not limeted to sprint
		set @join =  ' FROM  (SELECT DISTINCT CLIENT.CL_CODE AS Code
							,CLIENT.CL_CODE + '' - '' + isnull(CLIENT.CL_NAME, '''') AS Description
							,CLIENT.CL_NAME as Name 
							FROM CLIENT 
						INNER JOIN DIVISION	ON  CLIENT.CL_CODE = DIVISION.CL_CODE
						INNER JOIN  PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE 
		'
	END
	ELSE
	BEGIN
		--join limited to sprint
		set @join =  ' FROM  (SELECT DISTINCT CLIENT.CL_CODE AS Code
							,CLIENT.CL_CODE + '' - '' + isnull(CLIENT.CL_NAME, '''') AS Description
							,CLIENT.CL_NAME as Name 
							FROM SPRINT_HDR
						inner JOIN BOARD on BOARD.ID = SPRINT_HDR.BOARD_ID
						inner join BOARD_JOB on BOARD.ID = BOARD_JOB.BOARD_ID
						inner join JOB_LOG on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
						inner join CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE
						INNER JOIN DIVISION ON  CLIENT.CL_CODE = DIVISION.CL_CODE
						INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE 
		'

		--where to limit sprint
		set @where = @where +' AND SPRINT_HDR.ID = @SprintID
		'
	END


	if @Restrictions > 0
	BEGIN
		--sec restrictions
		set @join = @join +  ' INNER JOIN  SEC_CLIENT ON CLIENT.CL_CODE = SEC_CLIENT.CL_CODE
		'

		set @where = @where + ' AND (SEC_CLIENT.USER_ID = @UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		'
	END

	if @OfficeCount > 0
	BEGIN
		--office restrictions
		set @join = @join +  ' INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		'
	END

	set @where = @where + ') CLS)
	 SELECT *, (Select count(ROW_ID) from CTE) as Totalrows FROM CTE WHERE ROW_ID BETWEEN @START_REC AND @END_REC OR @Take = 0
	'

	CREATE TABLE #TEMP
	(
		  [Code] Varchar(6)
		, [Description] varchar(100)
		, [Name] VARCHAR(100)
		, [ROW_ID]  INT
		, [Totalrows] INT
	)

	set @join = @join + @where

	set @sql = @sql + @join --+ @where

	print @sql

	SELECT @paramlist = '@OfficeCode Varchar(6),@SprintID int,@UserID VarChar(100),@EMP_CODE varchar(6),@START_REC Int,@END_REC int,@TAKE int'

	insert #TEMP EXEC sp_executesql @sql, @paramlist, @OfficeCode, @SprintID, @UserID,@EMP_CODE, @START_REC,@END_REC,@TAKE

	select @TotalRows = max(Totalrows) from #TEMP

	select Code,Description,Name from #TEMP

	drop table #TEMP


GO

GRANT EXECUTE ON [usp_wv_dd_GetClients_Paging] TO PUBLIC AS dbo
GO

