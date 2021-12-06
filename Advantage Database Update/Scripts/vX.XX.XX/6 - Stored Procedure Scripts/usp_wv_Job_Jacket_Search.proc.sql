if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Job_Jacket_Search]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Job_Jacket_Search]
GO

/****** Object:  StoredProcedure [dbo].[usp_wv_Job_Jacket_Search]    Script Date: 10/1/2021 5:22:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[usp_wv_Job_Jacket_Search] (@UserID varchar(100),
												@Office varchar(4),
												@Client varchar(6),
												@Division varchar(6),
												@Product varchar(6),
												@SalesClass varchar(6),
												@Job int,
												@JobComp int,
												@AE varchar(6),
												@CampaignID int = 0,
												@JOB_TYPE_CODE varchar(10),
												@SHOW_CLOSED bit,
												@Year int = null,
												@skip int = 0,
												@take int = 0,
												@CPID int = 0,
												@TotalRows int out,
												@SumBudget decimal(18,2) out )
AS
/*
	declare @totalRows int,
			@sumBudget decimal(18,2)
	EXEC [dbo].[usp_wv_Job_Jacket_Search] 'nberry','','careal','careal','carall','',19724,1,'',0,'',1,null,0,50,0,@TotalRows=@totalRows OUTPUT,@SumBudget=@sumBudget OUTPUT
	print @totalRows
	print @sumBudget
*/
	DECLARE	@Rescrictions int,
			@sql nvarchar(4000),
			@paramlist nvarchar(4000),
			@whereclause nvarchar(4000),
			@sql2 nvarchar(4000),
			@start_rec int = 0,
			@end_rec int = 0, 
			@RestrictionsCP INT


	SET NOCOUNT ON

	print @JOB_TYPE_CODE

	if @skip > 0
	BEGIN
		SET @start_rec = @skip;
		SET @end_rec = @skip + @take - 1;
	END
	ELSE
	BEGIN
		SET @start_rec = @skip;
		SET @end_rec = @take;
	END


	DECLARE @EMP_CODE AS varchar(6)
	DECLARE @OfficeCount AS integer

	SELECT @EMP_CODE = EMP_CODE	FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

	SELECT @OfficeCount = COUNT(*)	FROM EMP_OFFICE	WHERE EMP_CODE = @EMP_CODE

	SELECT
		@Rescrictions = COUNT(*)
	FROM SEC_CLIENT
	WHERE UPPER(USER_ID) = UPPER(@UserID)	

	Select @RestrictionsCP = Count(*) FROM CP_SEC_CLIENT Where CDP_CONTACT_ID = @CPID


	SET	@sql = ';WITH DataCTE AS (SELECT JOB_LOG.JOB_NUMBER JobNumber, isnull(JOB_LOG.JOB_DESC, '''') AS JobDescription, JOB_COMPONENT.JOB_COMPONENT_NBR JobComponentNumber,JOB_COMPONENT.JOB_COMP_DESC JobComponentDescription, JOB_LOG.CL_CODE ClientCode, C.CL_NAME ClientName, JOB_LOG.DIV_CODE DivisionCode,
D.DIV_NAME DivisionName, JOB_LOG.PRD_CODE ProductCode, P.PRD_DESCRIPTION ProductName,JOB_COMPONENT.JOB_FIRST_USE_DATE DueDate,JOB_COMPONENT.START_DATE StartDate,	SALES_CLASS.SC_DESCRIPTION SalesClass, OFFICE.OFFICE_NAME OfficeName, JOB_COMPONENT.JOB_COMP_BUDGET_AM Budget,JOB_TYPE.JT_CODE, JOB_TYPE.JT_DESC JobType,JOB_LOG.COMP_OPEN,
EstimateStatus = CASE WHEN (NOT (JOB_COMPONENT.ESTIMATE_NUMBER IS NULL)) AND (NOT (JOB_COMPONENT.EST_COMPONENT_NBR IS NULL)) AND
(SELECT COUNT(*) FROM ESTIMATE_APPROVAL EA WITH(NOLOCK) WHERE EA.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND EA.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR) > 0 AND
(SELECT COUNT(*) FROM ESTIMATE_INT_APPR EA WITH(NOLOCK) WHERE EA.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND EA.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR) > 0 THEN ''Internally Approved / Client Approved''
WHEN (NOT (JOB_COMPONENT.ESTIMATE_NUMBER IS NULL)) AND (NOT (JOB_COMPONENT.EST_COMPONENT_NBR IS NULL)) AND (SELECT COUNT(*) FROM ESTIMATE_APPROVAL EA WITH(NOLOCK) WHERE EA.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND EA.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR) > 0 THEN ''Client Approved''
WHEN (NOT (JOB_COMPONENT.ESTIMATE_NUMBER IS NULL)) AND (NOT (JOB_COMPONENT.EST_COMPONENT_NBR IS NULL)) AND (SELECT COUNT(*) FROM ESTIMATE_INT_APPR EA WITH(NOLOCK) WHERE EA.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND EA.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR) > 0 THEN ''Internally Approved''
WHEN JOB_COMPONENT.ESTIMATE_NUMBER IS NULL AND JOB_COMPONENT.EST_COMPONENT_NBR IS NULL THEN ''No Estimate'' ELSE ''Pending Approval'' END, ROW_NUMBER() OVER (ORDER BY JOB_LOG.ROWID DESC) AS RowNumber, JobCompDesc = RIGHT(''000000'' + CONVERT(VARCHAR(6), ISNULL(JOB_LOG.JOB_NUMBER, 0)), 6) + ''/'' + RIGHT(''000'' + CONVERT(VARCHAR(3), ISNULL(JOB_COMPONENT.JOB_COMPONENT_NBR, 0)), 3) +
'' - '' + ISNULL(JOB_LOG.JOB_DESC,'''') + CASE WHEN ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '''') != ISNULL(JOB_LOG.JOB_DESC,'''') THEN '' | '' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '''') ELSE '''' END,
CDPName = CASE WHEN C.CL_NAME = D.DIV_NAME AND D.DIV_NAME = P.PRD_DESCRIPTION THEN C.CL_NAME WHEN C.CL_NAME = D.DIV_NAME AND D.DIV_NAME <> P.PRD_DESCRIPTION THEN C.CL_NAME + '' | '' + D.DIV_NAME + '' | '' + P.PRD_DESCRIPTION
WHEN C.CL_NAME <> D.DIV_NAME AND D.DIV_NAME = P.PRD_DESCRIPTION THEN C.CL_NAME + '' | '' + D.DIV_NAME ELSE C.CL_NAME + '' | '' + D.DIV_NAME + '' | '' + P.PRD_DESCRIPTION END
FROM JOB_LOG INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER JOIN CLIENT C ON JOB_LOG.CL_CODE = C.CL_CODE	JOIN DIVISION D on D.CL_CODE = JOB_LOG.CL_CODE AND D.DIV_CODE = JOB_LOG.DIV_CODE AND D.DIV_CODE = JOB_LOG.DIV_CODE
JOIN PRODUCT P on P.CL_CODE = JOB_LOG.CL_CODE AND P.PRD_CODE = JOB_LOG.PRD_CODE AND P.DIV_CODE = JOB_LOG.DIV_CODE AND P.DIV_CODE = JOB_LOG.DIV_CODE	JOIN SALES_CLASS ON SALES_CLASS.SC_CODE = JOB_LOG.SC_CODE JOIN OFFICE ON OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE LEFT JOIN JOB_TYPE ON JOB_TYPE.JT_CODE = JOB_COMPONENT.JT_CODE '

	
	set @whereclause = ''
	                                     -- INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
	IF @Rescrictions > 0
		SET	@whereclause = @whereclause + ' INNER JOIN SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE
						'

	IF @RestrictionsCP > 0
		SET	@whereclause = @whereclause + ' INNER JOIN CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND CP_SEC_CLIENT.PRD_CODE = JOB_LOG.PRD_CODE
						'

										 -- INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE
	IF @OfficeCount > 0
	BEGIN
		SET	@whereclause = @whereclause + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
	END



	if @SHOW_CLOSED = 0
		SET @whereclause = @whereclause + ' WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6,12))'
	ELSE
		SET	@whereclause = @whereclause + ' WHERE 1 = 1'
											--  (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)
	IF @Rescrictions > 0
		SET	@whereclause = @whereclause + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'

	IF @RestrictionsCP > 0
		SET	@whereclause = @whereclause + ' AND (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)'

	IF @Client <> ''
		SET @whereclause = @whereclause + ' AND (JOB_LOG.CL_CODE = @Client)'
	IF @Division <> ''
		SET @whereclause = @whereclause + ' AND (JOB_LOG.DIV_CODE = @Division)'
	IF @Product <> ''
		SET @whereclause = @whereclause + ' AND (JOB_LOG.PRD_CODE = @Product)'
	IF @Job <> ''
		SET @whereclause = @whereclause + ' AND (JOB_LOG.JOB_NUMBER = @Job)'
	IF @JobComp <> ''
		SET @whereclause = @whereclause + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)'
	IF @Office <> ''
		SET @whereclause = @whereclause + ' AND (JOB_LOG.OFFICE_CODE = @Office)'
	IF @SalesClass <> ''
		SET @whereclause = @whereclause + ' AND (JOB_LOG.SC_CODE = @SalesClass)'
	IF @AE <> ''
		SET @whereclause = @whereclause + ' AND (JOB_COMPONENT.EMP_CODE = @AE)'
	IF @CampaignID > 0
		SET @whereclause = @whereclause + ' AND (JOB_LOG.CMP_IDENTIFIER = @CampaignID)'

	IF @JOB_TYPE_CODE <> ''
		SET @whereclause = @whereclause + ' AND (JOB_TYPE.JT_CODE = @JOB_TYPE_CODE)'

	IF  @Year is not null
		SET @whereclause = @whereclause + ' AND (year(JOB_COMPONENT.JOB_COMP_DATE) = @Year)'

	--SET @sql = @sql + ' ORDER BY JOB_LOG.JOB_NUMBER DESC'

	SET @sql = @sql + @whereclause

	SET @sql = @sql + ' ) SELECT *, (Select count(RowNumber) from DataCTE) as Totalrows FROM DataCTE WHERE (RowNumber BETWEEN @START_REC AND @END_REC) or (@END_REC = 0) '

	set @sql2 = 'select @TotalRows = count(*), @SumBudget = SUM(ISNULL(JOB_COMPONENT.JOB_COMP_BUDGET_AM,0)) FROM JOB_LOG 
INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER
JOIN CLIENT ON JOB_LOG.CL_CODE = CLIENT.CL_CODE
JOIN DIVISION on  DIVISION.CL_CODE = JOB_LOG.CL_CODE AND DIVISION.DIV_CODE = JOB_LOG.DIV_CODE AND DIVISION.DIV_CODE = JOB_LOG.DIV_CODE
JOIN PRODUCT  on PRODUCT.CL_CODE = JOB_LOG.CL_CODE AND PRODUCT.PRD_CODE = JOB_LOG.PRD_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE AND PRODUCT.DIV_CODE = JOB_LOG.DIV_CODE
JOIN SALES_CLASS ON SALES_CLASS.SC_CODE = JOB_LOG.SC_CODE
JOIN OFFICE ON OFFICE.OFFICE_CODE = JOB_LOG.OFFICE_CODE
LEFT JOIN JOB_TYPE ON JOB_TYPE.JT_CODE = JOB_COMPONENT.JT_CODE' + @whereclause

	print @sql

	SELECT @paramlist = '@UserID VarChar(100),@Client VarChar(6),@Division VarChar(6),@Product Varchar(6),@Job Varchar(6),@JobComp Varchar(6),@Office Varchar(4),@SalesClass Varchar(6),@AE Varchar(6),@CampaignID Varchar(6), @EMP_CODE varchar(6),@JOB_TYPE_CODE varchar(10),@Year varchar(4),@START_REC Int,@END_REC int, @CPID int, @TotalRows int out, @SumBudget decimal(18,2) out'

	EXEC sp_executesql @sql2, @paramlist, @UserID, @Client, @Division, @Product, @Job, @JobComp, @Office, @SalesClass, @AE, @CampaignID,@EMP_CODE,@JOB_TYPE_CODE,@Year,@start_rec,@end_rec,@CPID,@TotalRows=@TotalRows out,@SumBudget=@SumBudget out

	EXEC sp_executesql @sql, @paramlist, @UserID, @Client, @Division, @Product, @Job, @JobComp, @Office, @SalesClass, @AE, @CampaignID,@EMP_CODE,@JOB_TYPE_CODE,@Year,@start_rec,@end_rec,@CPID,@TotalRows,@SumBudget






GO


