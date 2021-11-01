IF EXISTS ( SELECT *
            FROM dbo.sysobjects
            WHERE id = OBJECT_ID(N'[dbo].[advsp_lookup_ts_job_component_index]')
                  AND 
                  OBJECTPROPERTY(id , N'IsProcedure') = 1
          ) 
BEGIN
	DROP PROCEDURE [dbo].[advsp_lookup_ts_job_component_index]
END
GO
CREATE PROCEDURE [dbo].[advsp_lookup_ts_job_component_index] 
@UserID           VARCHAR(100) , 
@OfficeCode       VARCHAR(6) , 
@ClientCode       VARCHAR(6) , 
@DivisionCode     VARCHAR(6) , 
@ProductCode      VARCHAR(6) , 
@JobCode          INT , 
@ComponenetID     INT , 
@AccountExecutive VARCHAR(6)   = NULL , 
@CampaignID       INT          = NULL , 
@SalesClass       VARCHAR(6)   = NULL , 
@JobType          VARCHAR(10)  = NULL , 
@ShowClosed       BIT          = 0 , 
@SprintID         INT          = 0 , 
@Text             VARCHAR(100) , 
@Index            INT OUT
AS
/*=========== QUERY ===========*/
BEGIN
    DECLARE @Restrictions INT , @EMP_CODE VARCHAR(6) , @OfficeCount INT , @sql NVARCHAR(MAX) , @join NVARCHAR(MAX) , @where NVARCHAR(MAX) , @params NVARCHAR(MAX);
    SELECT @EMP_CODE = EMP_CODE
    FROM SEC_USER WITH(NOLOCK)
    WHERE UPPER(USER_CODE) = UPPER(@UserID);
    SELECT @OfficeCount = COUNT(*)
    FROM EMP_OFFICE WITH(NOLOCK)
    WHERE EMP_CODE = @EMP_CODE;
    SELECT @Restrictions = COUNT(*)
    FROM SEC_CLIENT WITH(NOLOCK)
    WHERE UPPER(USER_ID) = UPPER(@UserID);
    SET @OfficeCode = NULLIF(@OfficeCode , '');
    SET @ClientCode = NULLIF(@ClientCode , '');
    SET @DivisionCode = NULLIF(@DivisionCode , '');
    SET @ProductCode = NULLIF(@ProductCode , '');
    SET @JobCode = NULLIF(@JobCode , 0);
    SET @AccountExecutive = NULLIF(@AccountExecutive , '');
    SET @SalesClass = NULLIF(@SalesClass , '');
    SET @JobType = NULLIF(@JobType , '');
    SET @CampaignID = NULLIF(@CampaignID , 0);
    SET @sql = N'select @Index = ROW_ID - 1 from (SELECT JOB_COMPONENT.ROWID ID, ROW_NUMBER() OVER(ORDER BY  JOB_COMP_DESC) ROW_ID 
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
            SET @join = N'FROM JOB_COMPONENT
				INNER JOIN JOB_LOG ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
	';
    END;
        ELSE
        BEGIN
            SET @join = N'FROM SPRINT_HDR WITH(NOLOCK)
				inner JOIN BOARD WITH(NOLOCK) on BOARD.ID = SPRINT_HDR.BOARD_ID
				inner join BOARD_JOB WITH(NOLOCK) on BOARD.ID = BOARD_JOB.BOARD_ID
				inner join JOB_LOG WITH(NOLOCK) on JOB_LOG.JOB_NUMBER = BOARD_JOB.JOB_NUMBER
				INNER JOIN JOB_COMPONENT WITH(NOLOCK) ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
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
            SET @sql = @sql + ' INNER JOIN SEC_CLIENT WITH(NOLOCK) ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	';
            SET @where = @where + 'AND (SEC_CLIENT.USER_ID = @UserID) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	';
    END;
    IF @Text IS NOT NULL
        BEGIN
            SET @where = @where + ' AND ( LOWER(RIGHT(''000000''+CAST(JOB_LOG.JOB_NUMBER AS VARCHAR(6)),6) + ''/'' + RIGHT(''000''+CAST(JOB_COMPONENT.JOB_COMPONENT_NBR AS VARCHAR(3)),3) + '' - '' + JOB_COMPONENT.JOB_COMP_DESC  + '' ('' + JOB_LOG.CL_CODE + '')'') LIKE  ''%' + REPLACE(LOWER(@Text) , '''' , '''''') + '%'')
	';
    END;
    SET @sql = @sql + @join + @where + ') a WHERE ID = @ComponenetID';
    SELECT @params = '@UserID VarChar(100),
		@OfficeCode varchar(6),
		@ClientCode varchar(6),
		@DivisionCode varchar(6),
		@ProductCode varchar(6),
		@JobCode int,
		@ComponenetID int,
		@AccountExecutive varchar(6) = null,
		@CampaignID int = null,
		@SalesClass varchar(6) = null,
		@JobType varchar(10) = null,
		@ShowClosed bit = 0,
		@SprintID int = 0,
		@EMP_CODE varchar(6),
		@Index int OUTPUT';
    EXEC sp_executesql @sql , @params , @UserID , @OfficeCode , @ClientCode , @DivisionCode , @ProductCode , @JobCode , @ComponenetID , @AccountExecutive , @CampaignID , @SalesClass , @JobType , @ShowClosed , @SprintID , @EMP_CODE , @Index = @Index OUTPUT;
END;
/*=========== QUERY ===========*/