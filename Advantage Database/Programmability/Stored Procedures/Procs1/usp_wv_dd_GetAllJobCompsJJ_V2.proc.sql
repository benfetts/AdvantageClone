CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobCompsJJ_V2] @UserID varchar(100),
												@ShowClosed bit = 0
AS
	-- exec  [usp_wv_dd_GetAllJobCompsJJ_V2] 'ama',0
	DECLARE @Restrictions int

	SET NOCOUNT ON

	DECLARE @EMP_CODE AS varchar(6)
	DECLARE @OfficeCount AS integer,
			@sql NVARCHAR(4000),
			@paramlist NVARCHAR(4000)


	SELECT
		@EMP_CODE = EMP_CODE
	FROM SEC_USER
	WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT
		@OfficeCount = COUNT(*)
	FROM EMP_OFFICE
	WHERE EMP_CODE = @EMP_CODE

	SELECT
		@Restrictions = COUNT(*)
	FROM SEC_CLIENT
	WHERE UPPER(USER_ID) = UPPER(@UserID)

	set @sql = '			SELECT
				str(JOB_COMPONENT.JOB_COMPONENT_NBR) Code,
				LTRIM(STR(JOB_LOG.JOB_NUMBER)) + ''-'' + LTRIM(STR(JOB_COMPONENT.JOB_COMPONENT_NBR))
				+ '' | '' + JOB_COMPONENT.JOB_COMP_DESC
				+ '' | '' + JOB_LOG.CL_CODE + '' - '' + JOB_LOG.DIV_CODE + '' - '' + JOB_LOG.PRD_CODE Description,
				JOB_LOG.CL_CODE,
				JOB_COMPONENT.JOB_COMP_DESC Name,
				JOB_LOG.JOB_NUMBER JobCode,
				JOB_LOG.CL_CODE ClientCode,
				JOB_LOG.DIV_CODE DivisionCode,
				JOB_LOG.PRD_CODE ProductCode,
				JOB_COMPONENT.JOB_COMPONENT_NBR JobCompCode,
				JOB_COMPONENT.ROWID ID,
				JOB_LOG.OFFICE_CODE OfficeCode
			FROM JOB_LOG
			INNER JOIN JOB_COMPONENT
				ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
'

	IF @Restrictions > 0
		set @sql = @sql + '			INNER JOIN SEC_CLIENT
				ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE
				AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE
				AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'


	IF @OfficeCount > 0
		set @sql = @sql + '			INNER JOIN EMP_OFFICE
				ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE
				AND EMP_OFFICE.EMP_CODE = @EMP_CODE'

	IF @ShowClosed = 1
		set @sql = @sql + '			WHERE (1 = 1)'
	else
		set @sql = @sql + '			WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12))'

	IF @Restrictions > 0
		set @sql = @sql + '			AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
				AND (SEC_CLIENT.TIME_ENTRY = 0
				OR SEC_CLIENT.TIME_ENTRY IS NULL)'

	set @sql = @sql + '			ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC
'

	SET @paramlist = '@EMP_CODE VarChar(6), @UserID VarChar(6)'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @EMP_CODE, @UserID

