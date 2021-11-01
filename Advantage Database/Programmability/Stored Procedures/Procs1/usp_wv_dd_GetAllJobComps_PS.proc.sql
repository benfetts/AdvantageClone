/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetAllJobComps_PS]    Script Date: 5/10/2019 9:35:03 AM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO


/*
	exec usp_wv_dd_GetAllJobComps_PS 'ama', '', '', '', '', 0, '',0,'','', 0
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_GetAllJobComps_PS] (
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
	@Text varchar(100))
AS
	Declare @Restrictions Int
	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @OfficeCount AS INTEGER
	DECLARE @sql nvarchar(max)
	DECLARE @params nvarchar(max),
			@recordCount INTEGER,
			@Short smallint



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

	IF @ClientCode is null AND @DivisionCode is null AND @ProductCode is null and @Text is null
	BEGIN
		select @recordCount = count(*) FROM JOB_LOG 
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				 where JOB_LOG.COMP_OPEN = 1
	END
	ELSE
	BEGIN
		set @recordCount = 0
	END


	if @recordCount < 20000
	BEGIN
	set @sql = N'SELECT TOP 100 ltrim(str(JOB_LOG.JOB_NUMBER)) + ''-'' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code,
					ltrim(str(JOB_LOG.JOB_NUMBER)) + ''-'' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + '' | '' + JOB_COMPONENT.JOB_COMP_DESC + '' | '' + JOB_LOG.CL_CODE + '' - '' + JOB_LOG.DIV_CODE + '' - '' + JOB_LOG.PRD_CODE + '''' AS Description
					,JOB_LOG.CL_CODE
					 ,JOB_COMPONENT.JOB_COMP_DESC Name
					 ,JOB_LOG.JOB_NUMBER JobCode
					 ,JOB_LOG.CL_CODE ClientCode
					 ,JOB_LOG.DIV_CODE DivisionCode
					 ,JOB_LOG.PRD_CODE ProductCode
					 ,JOB_COMPONENT.JOB_COMPONENT_NBR JobCompCode
					 ,JOB_COMPONENT.ROWID ID
					 ,JOB_LOG.OFFICE_CODE OfficeCode
			FROM JOB_LOG 
				JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				JOIN JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND 
					JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
	'

	if(@OfficeCount > 0)
	BEGIN
		set @sql = @sql + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
		'
	END

	if( @Restrictions > 0)
	BEGIN
	--join sec client table
	 set @sql = @sql + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
				WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) OR (@ShowClosed = 1))
				AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) 
				AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
				AND (JOB_LOG.OFFICE_CODE = ISNULL(@OfficeCode,JOB_LOG.OFFICE_CODE) or (@OfficeCode is null and JOB_LOG.OFFICE_CODE is null))
				AND (JOB_LOG.CL_CODE = ISNULL(@ClientCode,JOB_LOG.CL_CODE) or (@ClientCode is null and JOB_LOG.CL_CODE is null))
				AND (JOB_LOG.DIV_CODE = ISNULL(@DivisionCode,JOB_LOG.DIV_CODE) or (@DivisionCode is null and JOB_LOG.DIV_CODE is null))
				AND (JOB_LOG.PRD_CODE = ISNULL(@ProductCode,JOB_LOG.PRD_CODE) or (@ProductCode is null and JOB_LOG.PRD_CODE is null))
				AND (JOB_LOG.JOB_NUMBER = ISNULL(@JobCode,JOB_LOG.JOB_NUMBER) or (@JobCode is null and JOB_LOG.JOB_NUMBER is null))
				AND (JOB_COMPONENT.EMP_CODE = ISNULL(@AccountExecutive,JOB_COMPONENT.EMP_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
				AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
				AND (JOB_COMPONENT.JT_CODE = ISNULL(@JobType,JOB_COMPONENT.JT_CODE) or (@JobType is null and JOB_COMPONENT.JT_CODE is null))
				AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
	 '
	END
	ELSE
	BEGIN
	 set @sql = @sql + ' WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) OR (@ShowClosed = 1))
				AND (JOB_LOG.OFFICE_CODE = ISNULL(@OfficeCode,JOB_LOG.OFFICE_CODE) or (@OfficeCode is null and JOB_LOG.OFFICE_CODE is null))
				AND (JOB_LOG.CL_CODE = ISNULL(@ClientCode,JOB_LOG.CL_CODE) or (@ClientCode is null and JOB_LOG.CL_CODE is null))
				AND (JOB_LOG.DIV_CODE = ISNULL(@DivisionCode,JOB_LOG.DIV_CODE) or (@DivisionCode is null and JOB_LOG.DIV_CODE is null))
				AND (JOB_LOG.PRD_CODE = ISNULL(@ProductCode,JOB_LOG.PRD_CODE) or (@ProductCode is null and JOB_LOG.PRD_CODE is null))
				AND (JOB_LOG.JOB_NUMBER = ISNULL(@JobCode,JOB_LOG.JOB_NUMBER) or (@JobCode is null and JOB_LOG.JOB_NUMBER is null))
				AND (JOB_COMPONENT.EMP_CODE = ISNULL(@AccountExecutive,JOB_COMPONENT.EMP_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
				AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
				AND (JOB_COMPONENT.JT_CODE = ISNULL(@JobType,JOB_COMPONENT.JT_CODE) or (@JobType is null and JOB_COMPONENT.JT_CODE is null))
				AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
	 '
	END

	if @Text is not null
	begin
			set @sql = @sql + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + ''/'' + RIGHT(''000''+CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3)),3) + '' - '' + JOB_COMPONENT.JOB_COMP_DESC  + '' ('' + JOB_LOG.CL_CODE + '')'') LIKE  ''%' + LOWER(@Text) + '%'')
			'
	end


	set @sql = @sql + '	ORDER BY JOB_LOG.JOB_NUMBER DESC, JOB_COMPONENT.JOB_COMPONENT_NBR ASC'



	print @sql

	set @params = '@OfficeCode VARCHAR(6),@ClientCode VARCHAR(6),@DivisionCode VARCHAR(6),@ProductCode VARCHAR(6),@JobCode int,@AccountExecutive varchar(6),@CampaignID int,@SalesClass varchar(6),@JobType varchar(10),@ShowClosed bit,@EMP_CODE AS VARCHAR(6),@UserID VarChar(100)'
	exec sp_executesql @sql,@params,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@EMP_CODE,@UserID
	END
	ELSE
	BEGIN
		set @Short = 0
		SELECT '0000' + '-' +   '0000' AS Code,
						CAST(@recordCount as varchar(10)) + ' open jobs. Please use client filters first.' AS Description
						,'' CL_CODE
						,CAST(@recordCount as varchar(10)) + ' open jobs. Please use client filters first.' Name
						 ,0 JobCode
						 ,'' ClientCode
						 ,'' DivisionCode
						 ,'' ProductCode
						 ,@Short JobCompCode
						 ,0 ID
						 ,'' OfficeCode
	END


GO


