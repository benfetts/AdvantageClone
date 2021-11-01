IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_dd_GetClients_Index]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
    DROP PROCEDURE [dbo].[usp_wv_dd_GetClients_Index]
GO



/*
	declare @index int
	exec usp_wv_dd_GetClients_Index 'ama','','food',0,'',@Index=@index OUTPUT
	print @index
*/

CREATE procedure [dbo].[usp_wv_dd_GetClients_Index](
			@UserID varchar(100),
			@OfficeCode varchar(6) = null,
			@ClientCode varchar(6),
			@SprintID int = 0,
			@Text varchar(100) = '',
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

	SET @OfficeCode = nullif(@OfficeCode,'')


	set @sql = N'select @Index = ROW_ID - 1 from (SELECT CLS.*,ROW_NUMBER() OVER(ORDER BY  CLS.Name) ROW_ID
				 FROM  (SELECT DISTINCT CLIENT.CL_CODE AS Code
							,CLIENT.CL_NAME as Name 
		'

	set @where = ' WHERE (CLIENT.ACTIVE_FLAG = 1)
				 AND LOWER(CLIENT.CL_NAME + '' ('' + CLIENT.CL_CODE + '')'') LIKE ''%' + REPLACE(LOWER(@Text),'''','''''') + '%''
	'

	if(@OfficeCode is not null)
	set @where = @where + 'AND PRODUCT.OFFICE_CODE = @OfficeCode
	'

	IF @SprintID <= 0
	BEGIN
		--join not limeted to sprint
		set @join =  ' FROM CLIENT 
						INNER JOIN DIVISION	ON  CLIENT.CL_CODE = DIVISION.CL_CODE
						INNER JOIN  PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE 
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
	WHERE foo.Code = @ClientCode
	'
	print @sql

	SELECT @paramlist = '@OfficeCode Varchar(6),@Sprint int,@UserID VarChar(100),@ClientCode varchar(6),@EMP_CODE varchar(6),@Index int OUTPUT'

	EXEC sp_executesql @sql, @paramlist, @OfficeCode, @SprintID, @UserID, @ClientCode,@EMP_CODE,@Index=@Index OUTPUT

GO

GRANT EXECUTE ON [usp_wv_dd_GetClients_Index] TO PUBLIC AS dbo
GO

