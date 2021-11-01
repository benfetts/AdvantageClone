IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_GetProducts_Index]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dd_GetProducts_Index]
GO


/*
	declare @index int
	exec usp_wv_dd_GetProducts_Index 'ama','','','arby,arby,atl',0,'',@Index=@index OUTPUT
	print @index
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetProducts_Index](
			@UserID VarChar(100) ,
			@ClientCode VarChar(6),
			@DivisionCode VarChar(6),
			@ProductID varchar(20),
			@SprintID Int = 0,
			@Text VARCHAR(100) = '',
			@Index int out
)
AS 

	Declare @Restrictions Int,
			@sql	nvarchar(4000),
			@join	nvarchar(4000),
			@where	nvarchar(4000),
			@paramlist nvarchar(4000),
			@OfficeCount int,
			@EMP_CODE varchar(6)

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = UPPER(@UserID);

	SELECT @OfficeCount = COUNT(1) FROM EMP_OFFICE WITH(NOLOCK) WHERE EMP_CODE = @EMP_CODE;

	SELECT @Restrictions = COUNT(1) FROM SEC_CLIENT WITH(NOLOCK) WHERE UPPER(USER_ID) = UPPER(@UserID);

	SET @ClientCode = nullif(@ClientCode,'')
	SET @DivisionCode = nullif(@DivisionCode,'')

	set @sql = N'select @Index = ROW_ID - 1 from (SELECT CLS.*,ROW_NUMBER() OVER(ORDER BY  CLS.Name) ROW_ID
				 FROM  (SELECT DISTINCT PRODUCT.CL_CODE + '','' + PRODUCT.DIV_CODE + '','' + PRODUCT.PRD_CODE as ID
							,PRODUCT.PRD_DESCRIPTION as Name 
		'

	set @where = ' WHERE (PRODUCT.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1)
						AND (PRODUCT.CL_CODE = ISNULL(@ClientCode,PRODUCT.CL_CODE))
						AND (PRODUCT.DIV_CODE = ISNULL(@DivisionCode,PRODUCT.DIV_CODE))
						AND LOWER(PRODUCT.PRD_DESCRIPTION + '' ('' + PRODUCT.PRD_CODE + '')'') LIKE ''%' + REPLACE(LOWER(@Text),'''','''''') + '%''
	'

	if(@ClientCode is not null)
	    set @where = @where + 'AND (PRODUCT.CL_CODE = @ClientCode)
		'

	if(@DivisionCode is not null)
		set @where = @where + 'AND (PRODUCT.DIV_CODE = ISNULL(@DivisionCode,PRODUCT.DIV_CODE))
		'

	IF @SprintID = 0
	BEGIN
		--join not limeted to sprint
		set @join =  ' FROM CLIENT WITH(NOLOCK)
						INNER JOIN DIVISION WITH(NOLOCK) ON  CLIENT.CL_CODE = DIVISION.CL_CODE
						INNER JOIN PRODUCT WITH(NOLOCK) ON  DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE
		'
	END
	ELSE
	BEGIN
		--join limited to sprint
		set @join =  ' FROM SPRINT_HDR
						inner JOIN BOARD on BOARD.ID = SPRINT_HDR.BOARD_ID
						inner join BOARD_JOB on BOARD.ID = BOARD_JOB.BOARD_ID
						inner join JOB_LOG on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
						inner join CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE
						INNER JOIN DIVISION ON  CLIENT.CL_CODE = DIVISION.CL_CODE
						INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE 
		'

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

	set @sql = @sql + @join + @where + '
	) CLS) foo
	WHERE foo.ID = @ProductID
	'
	print @sql

	SELECT @paramlist = '@ProductID Varchar(20),@Sprint int,@UserID VarChar(100),@ClientCode varchar(6),@DivisionCode varchar(6),@EMP_CODE varchar(6),@Index int OUTPUT'

	EXEC sp_executesql @sql, @paramlist,@ProductID, @SprintID, @UserID, @ClientCode,@DivisionCode,@EMP_CODE,@Index=@Index OUTPUT

GO

GRANT EXECUTE ON [usp_wv_dd_GetProducts_Index] TO PUBLIC AS dbo
GO
