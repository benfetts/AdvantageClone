/****** Object:  StoredProcedure [dbo].[usp_wv_dd_GetEstimates]    Script Date: 3/27/2019 3:25:18 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_wv_dd_GetEstimates]
	@Client varchar(6),
	@Division varchar(6),
	@Product varchar(6),
	@UserID varchar(100),
	@JobNum int,
	@JobComp int,
	@OfficeCode varchar(6) = null,
	@CampaignID int = 0,
	@SalesClass VarChar(6) = null
AS
	Declare @Restrictions Int,
			@sql nvarchar(4000),
			@paramlist nvarchar(4000)

	DECLARE @EMP_CODE AS VARCHAR(6)
	DECLARE @OfficeCount AS INTEGER

	set @SalesClass = Nullif(@SalesClass,'')
	set @CampaignID = nullif(@CampaignID,0)

	SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE


	Select @Restrictions = Count(*) 
	FROM SEC_CLIENT
	WHERE UPPER(USER_ID) = UPPER(@UserID)

	SELECT @sql = 'SELECT DISTINCT ESTIMATE_LOG.ESTIMATE_NUMBER AS Code,
					STR(ESTIMATE_LOG.ESTIMATE_NUMBER) + '' - '' +isnull(ESTIMATE_LOG.EST_LOG_DESC, '''') AS Description,
					isnull(ESTIMATE_LOG.EST_LOG_DESC, '''') Name,
					JOB_LOG.OFFICE_CODE OfficeCode,
					ESTIMATE_LOG.CL_CODE CLientCode,
					ESTIMATE_LOG.DIV_CODE DivisionCode,
					ESTIMATE_LOG.PRD_CODE ProductCode
					FROM         ESTIMATE_COMPONENT
								  INNER JOIN ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER
								  LEFT OUTER JOIN JOB_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
										ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR
								  LEFT JOIN JOB_LOG ON JOB_COMPONENT.JOB_NUMBER = JOB_LOG.JOB_NUMBER
							   INNER JOIN PRODUCT ON PRODUCT.CL_CODE = ESTIMATE_LOG.CL_CODE AND PRODUCT.DIV_CODE = ESTIMATE_LOG.DIV_CODE AND PRODUCT.PRD_CODE = ESTIMATE_LOG.PRD_CODE'

				if @Restrictions > 0
					Begin
					   SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND 
											  ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
					End
				IF @OfficeCount > 0
					BEGIN
						SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
					END
				SELECT @sql = @sql + ' WHERE ((JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12)) OR JOB_COMPONENT.ESTIMATE_NUMBER IS NULL)
					AND (JOB_LOG.SC_CODE = ISNULL(@SalesClass,JOB_LOG.SC_CODE) or (@SalesClass is null and JOB_LOG.SC_CODE is null))
     				AND (JOB_LOG.CMP_IDENTIFIER = ISNULL(@CampaignID,JOB_LOG.CMP_IDENTIFIER) or (@CampaignID is null and JOB_LOG.CMP_IDENTIFIER is null))
				'
				if @Client <> '' 
					Begin
					   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.CL_CODE = @Client)'
					End
				if @Division <> '' 
					Begin
					   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.DIV_CODE = @Division)'
					End
				if @Product <> '' 
					Begin
					   SELECT @sql = @sql + ' AND (ESTIMATE_LOG.PRD_CODE = @Product)'
					End
				if @JobNum <> 0 
					Begin
					   SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_NUMBER = @JobNum)'
					End
				if @JobComp <> 0 
					Begin
					   SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)'
					End

				if isnull(@OfficeCode,'') <> ''
					Begin
					   SELECT @sql = @sql + ' AND (JOB_LOG.OFFICE_CODE = @OfficeCode)'
					End

				if @Restrictions > 0
					Begin
					   SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
					End
			
	SELECT @sql = @sql + ' ORDER BY ESTIMATE_LOG.ESTIMATE_NUMBER DESC'
	SELECT @paramlist = '@Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @UserID Varchar(100), @JobNum int, @JobComp int, @OfficeCode varchar(6),@SalesClass varchar(6),@CampaignID int'
	print @sql
	EXEC sp_executesql @sql, @paramlist, @Client, @Product, @Division, @UserID, @JobNum, @JobComp, @OfficeCode,@SalesClass,@CampaignID
GO
