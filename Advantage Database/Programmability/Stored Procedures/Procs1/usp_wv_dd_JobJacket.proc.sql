/****** Object:  StoredProcedure [dbo].[usp_wv_dd_JobJacket]    Script Date: 5/20/2019 3:13:42 PM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER ON
GO




/*
	exec usp_wv_dd_JobJacket 'ama', '', '', '', '', '', 0,'','',0,0,'hil'
*/

CREATE PROCEDURE [dbo].[usp_wv_dd_JobJacket] (
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
	@Text varchar(100) = null
	)
AS
	Declare @Restrictions Int
	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @OfficeCount AS INTEGER
	DECLARE @sql nvarchar(max)
	DECLARE @params nvarchar(max),
			@recordCount INTEGER

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

	Select @Restrictions = Count(*) 
		FROM SEC_CLIENT
		WHERE UPPER(USER_ID) = UPPER(@UserID)

	set @OfficeCode = Nullif(@OfficeCode,'')
	set @ClientCode = Nullif(@ClientCode,'')
	set @DivisionCode = Nullif(@DivisionCode,'')
	set @ProductCode = Nullif(@ProductCode,'')
	set @AccountExecutive = Nullif(@AccountExecutive,'')
	set @SalesClass = Nullif(@SalesClass,'')
	set @JobType = nullif(@JobType,'')
	set @CampaignID = nullif(@CampaignID,0)

	IF @SprintID = 0
	BEGIN
	set @sql = N'SELECT DISTINCT TOP 100 JOB_LOG.JOB_NUMBER AS Code, LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '' - '' +isnull(JOB_LOG.JOB_DESC, '''') 
						+ '' | '' + JOB_LOG.CL_CODE + '' - '' + JOB_LOG.DIV_CODE + '' - '' + JOB_LOG.PRD_CODE + '''' AS Description
						,JOB_LOG.JOB_DESC Name
						,JOB_LOG.CL_CODE ClientCode
						,JOB_LOG.DIV_CODE DivisionCode
						,JOB_LOG.PRD_CODE ProductCode
						,JOB_LOG.OFFICE_CODE OfficeCode
			FROM JOB_LOG 
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
	'
	END
	ELSE
	BEGIN
	set @sql = N'SELECT DISTINCT TOP 100 JOB_LOG.JOB_NUMBER AS Code, LTRIM(STR(JOB_LOG.JOB_NUMBER)) + '' - '' +isnull(JOB_LOG.JOB_DESC, '''') 
						+ '' | '' + JOB_LOG.CL_CODE + '' - '' + JOB_LOG.DIV_CODE + '' - '' + JOB_LOG.PRD_CODE + '''' AS Description
						,JOB_LOG.JOB_DESC Name
						,JOB_LOG.CL_CODE ClientCode
						,JOB_LOG.DIV_CODE DivisionCode
						,JOB_LOG.PRD_CODE ProductCode
						,JOB_LOG.OFFICE_CODE OfficeCode
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
				WHERE (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) 
					AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
					AND (JOB_LOG.OFFICE_CODE = ISNULL(@OfficeCode,JOB_LOG.OFFICE_CODE) or (@OfficeCode is null and JOB_LOG.OFFICE_CODE is null))'

		 If @ClientCode IS NOT NULL
		 BEGIN
			set @sql = @sql + ' AND (JOB_LOG.CL_CODE = ISNULL(@ClientCode,JOB_LOG.CL_CODE) or (@ClientCode is null and JOB_LOG.CL_CODE is null))'
		 END
		 If @DivisionCode IS NOT NULL
		 BEGIN
			set @sql = @sql + ' AND (JOB_LOG.DIV_CODE = ISNULL(@DivisionCode,JOB_LOG.DIV_CODE) or (@DivisionCode is null and JOB_LOG.DIV_CODE is null))'
		 END
		 If @ProductCode IS NOT NULL
		 BEGIN
			set @sql = @sql + ' AND (JOB_LOG.PRD_CODE = ISNULL(@ProductCode,JOB_LOG.PRD_CODE) or (@ProductCode is null and JOB_LOG.PRD_CODE is null))'
		 END	 

		 set @sql = @sql + ' 					
					AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
					AND (JOB_COMPONENT.EMP_CODE = ISNULL(@AccountExecutive,JOB_COMPONENT.EMP_CODE) or (@AccountExecutive is null and JOB_COMPONENT.EMP_CODE is null))
					AND (JOB_COMPONENT.JT_CODE = ISNULL(@JobType,JOB_COMPONENT.JT_CODE) or (@JobType is null and JOB_COMPONENT.JT_CODE is null))
					AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
					AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) OR @ShowClosed = 1)
		 '
		END
		ELSE
		BEGIN
		 set @sql = @sql + ' WHERE (JOB_LOG.OFFICE_CODE = ISNULL(@OfficeCode,JOB_LOG.OFFICE_CODE) or (@OfficeCode is null and JOB_LOG.OFFICE_CODE is null))'

		 If @ClientCode IS NOT NULL
		 BEGIN
			set @sql = @sql + ' AND (JOB_LOG.CL_CODE = ISNULL(@ClientCode,JOB_LOG.CL_CODE) or (@ClientCode is null and JOB_LOG.CL_CODE is null))'
		 END
		 If @DivisionCode IS NOT NULL
		 BEGIN
			set @sql = @sql + ' AND (JOB_LOG.DIV_CODE = ISNULL(@DivisionCode,JOB_LOG.DIV_CODE) or (@DivisionCode is null and JOB_LOG.DIV_CODE is null))'
		 END
		 If @ProductCode IS NOT NULL
		 BEGIN
			set @sql = @sql + ' AND (JOB_LOG.PRD_CODE = ISNULL(@ProductCode,JOB_LOG.PRD_CODE) or (@ProductCode is null and JOB_LOG.PRD_CODE is null))'
		 END	 

		 set @sql = @sql + ' AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
					AND (JOB_COMPONENT.EMP_CODE = ISNULL(@AccountExecutive,JOB_COMPONENT.EMP_CODE) or (@AccountExecutive is null and JOB_COMPONENT.EMP_CODE is null))
					AND (JOB_COMPONENT.JT_CODE = ISNULL(@JobType,JOB_COMPONENT.JT_CODE) or (@JobType is null and JOB_COMPONENT.JT_CODE is null))
					AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
					AND (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12) OR @ShowClosed = 1)
		 '
		END

	IF @SprintID > 0
	BEGIN
	set @sql = @sql + '	AND  SPRINT_HDR.ID = @SprintID
	'
	END

	IF @Text is not null and @Text != ''
	BEGIN
		set @sql = @sql + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + '' - '' + JOB_LOG.JOB_DESC  + '' ('' + JOB_LOG.CL_CODE + '')''  ) LIKE  ''%' + LOWER(@Text) + '%'')
		'
	END

	set @sql = @sql + '	ORDER BY JOB_LOG.JOB_NUMBER DESC
			'
	print @sql

	set @params = '@OfficeCode VARCHAR(6),@ClientCode VARCHAR(6),@DivisionCode VARCHAR(6),@ProductCode VARCHAR(6),@AccountExecutive varchar(6),	@CampaignID int,@SalesClass varchar(6),@JobType varchar(10),@ShowClosed bit,@EMP_CODE AS VARCHAR(6),@UserID VarChar(100), @SprintID int'
		exec sp_executesql @sql,@params,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@EMP_CODE,@UserID,@SprintID




GO


