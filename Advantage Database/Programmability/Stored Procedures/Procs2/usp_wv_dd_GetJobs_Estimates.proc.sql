/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetJobs_Estimates]    Script Date: 5/10/2019 9:27:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- exec usp_wv_dd_GetJobs_Estimates 'EML04',0

CREATE PROCEDURE [dbo].[usp_wv_dd_GetJobs_Estimates] 
	@UserID VarChar(100),
	@CampaignID int = 0,
	@SalesClass VarChar(6) = null,
	@ShowAll        BIT,
	@Text varchar(100) = ''
AS
	Set NoCount On

	DECLARE @EMP_CODE AS VARCHAR(6)

	DECLARE @Join as NVARCHAR(4000) = '',
			@Where as NVARCHAR(4000) = '',
			@sql as NVARCHAR(4000) = '',
			@GroupBy as NVARCHAR(4000) = '',
			@paramlist as  NVARCHAR(4000) = ''

	set @SalesClass = Nullif(@SalesClass,'')
	set @CampaignID = nullif(@CampaignID,0)

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)


	if EXISTS(SELECT 1 FROM SEC_CLIENT WHERE UPPER(USER_ID) = UPPER(@UserID)) 
	BEGIN
		SET @Join = ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE 
		'
		SET @Where = ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL) 
		'
		SET @GroupBy = ' GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, SEC_CLIENT.USER_ID, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,JOB_LOG.OFFICE_CODE 
		'
	END
	ELSE
	BEGIN
		SET @GroupBy = ' GROUP BY JOB_LOG.JOB_NUMBER, JOB_LOG.JOB_DESC, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE,JOB_LOG.OFFICE_CODE
		'
	END

	IF EXISTS(SELECT 1 FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE)
	BEGIN
		SET @Join = @Join + 'INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		'
	END

	if @ShowAll = 0
	BEGIN
		set @Where = 'WHERE ((JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) OR JOB_COMPONENT.ESTIMATE_NUMBER IS NULL)
					AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
     				AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
		'
	END
	ELSE
	BEGIN
		set @Where = 'WHERE (1 = 1)
					AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
     				AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
		'
	END

	if(@Text is not null and @Text != '')
	BEGIN
			set @Where = @Where + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + '' - '' + JOB_LOG.JOB_DESC  + '' ('' + JOB_LOG.CL_CODE + '')''  ) LIKE  ''%' + LOWER(@Text) + '%'')
			'
	END


	set @sql = 'SELECT DISTINCT JOB_LOG.JOB_NUMBER AS Code
				,JOB_LOG.JOB_DESC Description
				,JOB_LOG.JOB_DESC Name
				,JOB_LOG.CL_CODE ClientCode
				,JOB_LOG.DIV_CODE DivisionCode
				,JOB_LOG.PRD_CODE ProductCode
				,JOB_LOG.OFFICE_CODE OfficeCode
	FROM         JOB_LOG 
		JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
		JOIN ESTIMATE_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR
		'

	-- add joins for SEC and Office, Closed Jobs, 
	set @sql = @sql + @Join + @Where + @GroupBy + ' ORDER BY JOB_LOG.JOB_NUMBER DESC'

	print @sql

    set @paramlist = '@EMP_CODE VarChar(6),@UserID VarChar(6),@SalesClass varchar(6),@CampaignID int'
	EXEC sp_executesql @sql , @paramlist, @EMP_CODE,@UserID,@SalesClass,@CampaignID




GO


