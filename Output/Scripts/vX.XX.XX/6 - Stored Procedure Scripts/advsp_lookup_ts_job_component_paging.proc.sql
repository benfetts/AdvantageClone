IF EXISTS ( SELECT *
            FROM dbo.sysobjects
            WHERE id = OBJECT_ID(N'[dbo].[advsp_lookup_ts_job_component_paging]')
                  AND 
                  OBJECTPROPERTY(id , N'IsProcedure') = 1
          ) 
    BEGIN
        DROP PROCEDURE [dbo].[advsp_lookup_ts_job_component_paging]
END
GO
CREATE PROCEDURE [dbo].[advsp_lookup_ts_job_component_paging] 
@UserID           VARCHAR(100) , 
@OfficeCode       VARCHAR(6) , 
@ClientCode       VARCHAR(6) , 
@DivisionCode     VARCHAR(6) , 
@ProductCode      VARCHAR(6) , 
@JobCode          INT , 
@AccountExecutive VARCHAR(6)   = NULL , 
@CampaignID       INT          = NULL , 
@SalesClass       VARCHAR(6)   = NULL , 
@JobType          VARCHAR(10)  = NULL , 
@ShowClosed       BIT          = 0 , 
@SprintID         INT          = 0 , 
@Text             VARCHAR(100) , 
@Skip             INT          = 0 , 
@Take             INT          = 0 , 
@CPID             INT          = 0 , 
@TotalRows        INT OUT
AS
/*=========== QUERY ===========*/
BEGIN
    DECLARE @Restrictions INT;
    DECLARE @EMP_CODE AS VARCHAR(6);
    DECLARE @OfficeCount AS INTEGER;
    DECLARE @sql NVARCHAR(MAX) , @join NVARCHAR(MAX) , @where NVARCHAR(MAX) , @params NVARCHAR(MAX) , @recordCount INTEGER , @Short SMALLINT , @START_REC INT , @END_REC INT , @RestrictionsCP INT;
    IF @SKIP > 0
        BEGIN
            SET @START_REC = @SKIP + 1;
            SET @END_REC = @SKIP + @TAKE;
    END;
        ELSE
        BEGIN
            SET @START_REC = @SKIP;
            SET @END_REC = @TAKE;
    END;
    SELECT @EMP_CODE = EMP_CODE
    FROM SEC_USER WITH(NOLOCK)
    WHERE UPPER(USER_CODE) = UPPER(@UserID);
    SELECT @OfficeCount = COUNT(1)
    FROM EMP_OFFICE WITH(NOLOCK)
    WHERE EMP_CODE = @EMP_CODE;
    SELECT @Restrictions = COUNT(1)
    FROM SEC_CLIENT WITH(NOLOCK)
    WHERE UPPER(USER_ID) = UPPER(@UserID);
    SELECT @RestrictionsCP = COUNT(1)
    FROM CP_SEC_CLIENT WITH(NOLOCK)
    WHERE CDP_CONTACT_ID = @CPID;
    SET @OfficeCode = NULLIF(@OfficeCode , '');
    SET @ClientCode = NULLIF(@ClientCode , '');
    SET @DivisionCode = NULLIF(@DivisionCode , '');
    SET @ProductCode = NULLIF(@ProductCode , '');
    SET @JobCode = NULLIF(@JobCode , 0);
    SET @AccountExecutive = NULLIF(@AccountExecutive , '');
    SET @SalesClass = NULLIF(@SalesClass , '');
    SET @JobType = NULLIF(@JobType , '');
    SET @CampaignID = NULLIF(@CampaignID , 0);
    SET @sql = N'	;WITH CTE AS (SELECT a.*,ROW_NUMBER() OVER(ORDER BY  a.JobCode DESC, a.JobCompCode ASC) ROW_ID FROM (SELECT ltrim(str(JOB_LOG.JOB_NUMBER)) + ''-'' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) AS Code,
					ltrim(str(JOB_LOG.JOB_NUMBER)) + ''-'' +   ltrim(STR(JOB_COMPONENT.JOB_COMPONENT_NBR)) + '' | '' + JOB_COMPONENT.JOB_COMP_DESC + '' | '' + JOB_LOG.CL_CODE + '' - '' + JOB_LOG.DIV_CODE + '' - '' + JOB_LOG.PRD_CODE + '''' AS Description
					,JOB_LOG.CL_CODE
						,JOB_COMPONENT.JOB_COMP_DESC Name
						,JOB_LOG.JOB_NUMBER JobCode
						,JOB_LOG.CL_CODE ClientCode
						,JOB_LOG.DIV_CODE DivisionCode
						,JOB_LOG.PRD_CODE ProductCode
						,JOB_COMPONENT.JOB_COMPONENT_NBR JobCompCode
						,CAST(JOB_LOG.JOB_NUMBER as varchar(6)) + '','' + CAST(JOB_COMPONENT.JOB_COMPONENT_NBR as varchar(10)) ID
						,JOB_LOG.OFFICE_CODE OfficeCode
						,CASE WHEN JOB_TRAFFIC.JOB_NUMBER IS NOT NULL THEN 1 ELSE 0 END AS HasSchedule
';
    SET @where = 'WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,3,5,6,9,10,12,13))
';
    IF ( @OfficeCode IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_LOG.OFFICE_CODE = @OfficeCode)
	'
    END;
    IF ( @ClientCode IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_LOG.CL_CODE = @ClientCode)
	'
    END;
    IF ( @DivisionCode IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_LOG.DIV_CODE = @DivisionCode)
	'
    END;
    IF ( @ProductCode IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_LOG.PRD_CODE = @ProductCode)
	'
    END;
    IF ( @JobCode IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_LOG.JOB_NUMBER = @JobCode)
	'
    END;
    IF ( @AccountExecutive IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_COMPONENT.EMP_CODE = @AccountExecutive)
	'
    END;
    IF ( @SalesClass IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_LOG.SC_CODE = @SalesClass)
	'
    END;
    IF ( @JobType IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_COMPONENT.JT_CODE = @JobType)
	'
    END;
    IF ( @CampaignID IS NOT NULL ) 
        BEGIN
            SET @where = @where + 'AND (JOB_LOG.CMP_IDENTIFIER = @CampaignID)
	'
    END;
    IF @SprintID <= 0
        BEGIN
            SET @join = N'FROM JOB_LOG 
				INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				LEFT OUTER JOIN	JOB_TRAFFIC ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
	';
    END;
        ELSE
        BEGIN
            SET @join = N'FROM SPRINT_HDR WITH(NOLOCK)
				INNER JOIN BOARD WITH(NOLOCK) on BOARD.ID = SPRINT_HDR.BOARD_ID
				INNER JOIN BOARD_JOB WITH(NOLOCK) on BOARD.ID = BOARD_JOB.BOARD_ID
				INNER JOIN JOB_LOG WITH(NOLOCK) on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
				INNER JOIN JOB_COMPONENT WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
				LEFT OUTER JOIN	JOB_TRAFFIC WITH(NOLOCK) ON JOB_COMPONENT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER AND JOB_COMPONENT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR
	';
            SET @where = @where + '	AND  SPRINT_HDR.ID = @SprintID
	';
    END;
    IF ( @OfficeCount > 0 ) 
        BEGIN
            SET @join = @join + ' INNER JOIN EMP_OFFICE WITH(NOLOCK) ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
	';
    END;
    IF ( @Restrictions > 0 ) 
        BEGIN
            --join sec client table
            SET @join = @join + ' INNER JOIN SEC_CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	';
            SET @where = @where + 'AND (SEC_CLIENT.USER_ID = @UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	';
    END;
    IF ( @RestrictionsCP > 0 ) 
        BEGIN
            --join sec client table
            SET @join = @join + ' INNER JOIN CP_SEC_CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
	';
            SET @where = @where + 'AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)
	';
    END;
    IF @Text IS NOT NULL
        BEGIN
            SET @where = @where + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + ''/'' + RIGHT(''000''+CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3)),3) + '' - '' + JOB_LOG.JOB_DESC  + '' - '' + JOB_COMPONENT.JOB_COMP_DESC  + '' ('' + JOB_LOG.CL_CODE + '')'') LIKE  ''%' + REPLACE(LOWER(@Text) , '''' , '''''') + '%'')
	';
    END;
    SET @sql = @sql + @join + @where + ') a)
	SELECT *, (Select count(ROW_ID) from CTE) as Totalrows FROM CTE WHERE ROW_ID BETWEEN @START_REC AND @END_REC OR @Take = 0
	';
    SET @params = '@OfficeCode VARCHAR(6),@ClientCode VARCHAR(6),@DivisionCode VARCHAR(6),@ProductCode VARCHAR(6),@JobCode int,@AccountExecutive varchar(6),@CampaignID int,@SalesClass varchar(6),@JobType varchar(10),@ShowClosed bit,@EMP_CODE AS VARCHAR(6),@UserID VarChar(100), @SprintID int,@Text varchar(100),@START_REC Int,@END_REC int, @Take INT,@CPID int';
    CREATE TABLE #TEMP ( 
                    [Code]         VARCHAR(10) , 
                    [Description]  VARCHAR(200) , 
                    [CL_CODE]      VARCHAR(6) , 
                    [Name]         VARCHAR(100) , 
                    [JobCode]      INT , 
                    [ClientCode]   VARCHAR(6) , 
                    [DivisionCode] VARCHAR(6) , 
                    [ProductCode]  VARCHAR(6) , 
                    [JobCompCode]  SMALLINT , 
                    [ID]           VARCHAR(20) , 
                    [OfficeCode]   VARCHAR(6) , 
                    HasSchedule    INT , 
                    [ROW_ID]       INT , 
                    [Totalrows]    INT
                        );
    INSERT INTO #TEMP
    EXEC sp_executesql @sql , @params , @OfficeCode , @ClientCode , @DivisionCode , @ProductCode , @JobCode , @AccountExecutive , @CampaignID , @SalesClass , @JobType , @ShowClosed , @EMP_CODE , @UserID , @SprintID , @Text , @START_REC , @END_REC , @Take , @CPID;
    SELECT 
		@TotalRows = MAX(Totalrows)
    FROM 
		#TEMP
	;
	DECLARE @DATA TABLE (	JOB_NUMBER INT,
							JOB_COMPONENT_NBR SMALLINT,
							JOB_LOG_DESC VARCHAR(60),
							JOB_COMP_DESC VARCHAR(60),
							DISPLAY_DESC VARCHAR(200)
						);
	INSERT INTO @DATA (JOB_NUMBER, JOB_COMPONENT_NBR, JOB_LOG_DESC, JOB_COMP_DESC, DISPLAY_DESC)
	SELECT
		J.JOB_NUMBER, 
		JC.JOB_COMPONENT_NBR, 
		J.JOB_DESC, 
		JC.JOB_COMP_DESC,
		CASE
			WHEN J.JOB_DESC = JC.JOB_COMP_DESC THEN JC.JOB_COMP_DESC 
			ELSE J.JOB_DESC + ' - ' + JC.JOB_COMP_DESC 
		END
	FROM
		#TEMP T
		INNER JOIN JOB_LOG J WITH(NOLOCK) ON T.JobCode = J.JOB_NUMBER
		INNER JOIN JOB_COMPONENT JC WITH(NOLOCK) ON T.JobCode = JC.JOB_NUMBER AND T.JobCompCode = JC.JOB_COMPONENT_NBR
			AND J.JOB_NUMBER = JC.JOB_NUMBER
	;
    SELECT 
		[Code] = T.Code, 
		[Name] = T.[Name], 		
		[Description] =	T.[Description],
		[JobDescription] = D.JOB_LOG_DESC,
		[JobComponentDescription] = D.JOB_COMP_DESC,
		[DisplayDescription] = D.DISPLAY_DESC,
		[ID] = T.ID, 
		[JobCode] = T.JobCode, 
		[JobCompCode] = T.JobCompCode, 
		[OfficeCode] = T.OfficeCode, 
		[ClientCode] = T.ClientCode, 
		[DivisionCode] = T.DivisionCode, 
		[ProductCode] = T.ProductCode, 
		[CL_CODE] = T.CL_CODE, 
		[HasSchedule] = T.HasSchedule
    FROM 
		#TEMP T
		INNER JOIN @DATA D ON T.JobCode = D.JOB_NUMBER AND T.JobCompCode = D.JOB_COMPONENT_NBR
	;
    DROP TABLE #TEMP;
END;
/*=========== QUERY ===========*/