/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetJobCompsEstimate]    Script Date: 5/10/2019 9:49:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- EXEC usp_wv_dd_GetJobCompsEstimate 'SYSADM', 0

CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobCompsEstimate] 
	@UserID VarChar(100),
	@CampaignID int,
	@SalesClass varchar(6),
	@ShowAll        BIT,
	@Text VARCHAR(100) = ''
AS
	Set NoCount On

	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE	@Rescrictions int

	DECLARE @Join as NVARCHAR(4000) = '',
			@Where as NVARCHAR(4000) = '',
			@sql as NVARCHAR(4000) = '',
			@paramlist as  NVARCHAR(4000) = ''

	DECLARE @OfficeCount AS integer

	set @SalesClass = Nullif(@SalesClass,'')
	set @CampaignID = nullif(@CampaignID,0)

	SELECT @EMP_CODE = EMP_CODE	FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*)	FROM EMP_OFFICE	WHERE EMP_CODE = @EMP_CODE

	SELECT
		@Rescrictions = COUNT(*)
	FROM SEC_CLIENT
	WHERE UPPER(USER_ID) = UPPER(@UserID)	

	if @ShowAll = 0
	BEGIN
		set @Where = ' WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12))
					AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
     				AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
		'
	END
	ELSE
	BEGIN
		set @Where = ' WHERE (1 = 1)
					AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
     				AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
		'
	END

	IF @Rescrictions > 0
	BEGIN
		set @Join = ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
		'
		set @Where += ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
		'
	END

	if @Text is not null and @Text != ''
	BEGIN
		set @Where = @Where + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + ''/'' + RIGHT(''000''+CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3)),3) + '' - '' + JOB_COMPONENT.JOB_COMP_DESC  + '' ('' + JOB_LOG.CL_CODE + '')'') LIKE  ''%' + LOWER(@Text) + '%'')
			'
	END

	IF @OfficeCount > 0
	BEGIN
		set @Join = @Join + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE	AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		'
	END


	set @sql = 'SELECT DISTINCT str(JOB_COMPONENT.JOB_COMPONENT_NBR) AS Code
			,JOB_COMPONENT.JOB_COMP_DESC Description
				,JOB_LOG.CL_CODE
				,JOB_COMPONENT.JOB_COMP_DESC Name
				,JOB_LOG.JOB_NUMBER JobCode
				,JOB_LOG.CL_CODE ClientCode
				,JOB_LOG.DIV_CODE DivisionCode
				,JOB_LOG.PRD_CODE ProductCode
				,JOB_COMPONENT.JOB_COMPONENT_NBR JobCompCode
				,JOB_COMPONENT.ROWID ID
				,JOB_LOG.OFFICE_CODE OfficeCode
	FROM JOB_LOG INNER JOIN
		JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
		JOIN ESTIMATE_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR
'


	set @sql += @Join + @Where + ' ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC '
	print @sql

    set @paramlist = '@EMP_CODE VarChar(6),@UserID VarChar(6),@SalesClass varchar(6),@CampaignID int'
	EXEC sp_executesql @sql , @paramlist, @EMP_CODE, @UserID,@SalesClass,@CampaignID



GO


