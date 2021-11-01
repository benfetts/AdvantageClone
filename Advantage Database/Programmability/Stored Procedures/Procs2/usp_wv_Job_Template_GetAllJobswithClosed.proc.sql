if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Job_Template_GetAllJobswithClosed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Job_Template_GetAllJobswithClosed]
GO

CREATE PROCEDURE [dbo].[usp_wv_Job_Template_GetAllJobswithClosed] 
@UserID VarChar(100),
@Client VarChar(6),
@Division VarChar(6),
@Product Varchar(6),
@Job Varchar(6),
@JobComp Varchar(6),
@Office Varchar(4),
@SalesClass Varchar(6),
@AE Varchar(6),
@Campaign Varchar(6),
@CP int,
@CPID int
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000), @RestrictionsCP Int
Set NoCount On

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

Select @Rescrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

Select @RestrictionsCP = Count(*) 
FROM CP_SEC_CLIENT
Where CDP_CONTACT_ID = @CPID;


if @CP = 1
Begin
If @RestrictionsCP > 0
	SELECT @sql = 'SELECT JOB_LOG.JOB_NUMBER, isnull(JOB_LOG.JOB_DESC, '''') AS JOB_DESC, 
					JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, ISNULL(JOB_COMP_BUDGET_AM,0) AS JOB_COMP_BUDGET_AM
					FROM JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      CP_SEC_CLIENT ON JOB_LOG.CL_CODE = CP_SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = CP_SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = CP_SEC_CLIENT.PRD_CODE
					WHERE (CP_SEC_CLIENT.CDP_CONTACT_ID = @CPID)'    
	if @Client <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CL_CODE = @Client)'
	if @Division <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.DIV_CODE = @Division)'
	if @Product <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.PRD_CODE = @Product)'
	if @Job <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.JOB_NUMBER = @Job)'
	if @JobComp <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)'
	if @Office <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.OFFICE_CODE = @Office)'
	if @SalesClass <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.SC_CODE = @SalesClass)'
	if @AE <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.EMP_CODE = @AE)'
	if @Campaign <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CMP_CODE = @Campaign)'
	

If @RestrictionsCP = 0
	SELECT @sql = 'SELECT JOB_LOG.JOB_NUMBER, isnull(JOB_LOG.JOB_DESC, '''') AS JOB_DESC, 
					JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, ISNULL(JOB_COMP_BUDGET_AM,0) AS JOB_COMP_BUDGET_AM
					FROM JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER 
					WHERE (1=1)'    
	if @Client <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CL_CODE = @Client)'
	if @Division <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.DIV_CODE = @Division)'
	if @Product <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.PRD_CODE = @Product)'
	if @Job <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.JOB_NUMBER = @Job)'
	if @JobComp <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)'
	if @Office <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.OFFICE_CODE = @Office)'
	if @SalesClass <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.SC_CODE = @SalesClass)'
	if @AE <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.EMP_CODE = @AE)'
	if @Campaign <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CMP_CODE = @Campaign)'
	





SELECT @sql = @sql + ' ORDER BY JOB_LOG.JOB_NUMBER DESC'
SELECT @paramlist = '@CPID int,@Client VarChar(6),@Division VarChar(6),@Product Varchar(6),@Job Varchar(6),@JobComp Varchar(6),@Office Varchar(4),@SalesClass Varchar(6),@AE Varchar(6),@Campaign Varchar(6)'

EXEC sp_executesql @sql, @paramlist, @CPID, @Client, @Division, @Product, @Job, @JobComp, @Office, @SalesClass, @AE, @Campaign
End
Else
Begin
If @Rescrictions > 0
Begin
	SELECT @sql = 'SELECT JOB_LOG.JOB_NUMBER, isnull(JOB_LOG.JOB_DESC, '''') AS JOB_DESC, 
					JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, ISNULL(JOB_COMP_BUDGET_AM,0) AS JOB_COMP_BUDGET_AM
					FROM JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER INNER JOIN
	                      SEC_CLIENT ON JOB_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND JOB_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND 
	                      JOB_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'	
	IF @OfficeCount > 0
		BEGIN
			SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
		END
	SELECT @sql = @sql + ' WHERE (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'    
	if @Client <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CL_CODE = @Client)'
	if @Division <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.DIV_CODE = @Division)'
	if @Product <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.PRD_CODE = @Product)'
	if @Job <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.JOB_NUMBER = @Job)'
	if @JobComp <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)'
	if @Office <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.OFFICE_CODE = @Office)'
	if @SalesClass <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.SC_CODE = @SalesClass)'
	if @AE <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.EMP_CODE = @AE)'
	if @Campaign <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CMP_CODE = @Campaign)'
End
	
	

If @Rescrictions = 0
Begin
	SELECT @sql = 'SELECT JOB_LOG.JOB_NUMBER, isnull(JOB_LOG.JOB_DESC, '''') AS JOB_DESC, 
					JOB_COMPONENT.JOB_COMPONENT_NBR, JOB_COMPONENT.JOB_COMP_DESC, JOB_LOG.CL_CODE, JOB_LOG.DIV_CODE, JOB_LOG.PRD_CODE, ISNULL(JOB_COMP_BUDGET_AM,0) AS JOB_COMP_BUDGET_AM
					FROM JOB_LOG INNER JOIN
	                      JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER '	
	IF @OfficeCount > 0
		BEGIN
			SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON JOB_LOG.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE'
		END
	SELECT @sql = @sql + ' WHERE (1=1)'    
	if @Client <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CL_CODE = @Client)'
	if @Division <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.DIV_CODE = @Division)'
	if @Product <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.PRD_CODE = @Product)'
	if @Job <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.JOB_NUMBER = @Job)'
	if @JobComp <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.JOB_COMPONENT_NBR = @JobComp)'
	if @Office <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.OFFICE_CODE = @Office)'
	if @SalesClass <> '' 
		SELECT @sql = @sql + ' AND (JOB_LOG.SC_CODE = @SalesClass)'
	if @AE <> ''
		SELECT @sql = @sql + ' AND (JOB_COMPONENT.EMP_CODE = @AE)'
	if @Campaign <> ''
		SELECT @sql = @sql + ' AND (JOB_LOG.CMP_CODE = @Campaign)'
End
	

SELECT @sql = @sql + ' ORDER BY JOB_LOG.JOB_NUMBER DESC'
SELECT @paramlist = '@UserID VarChar(100),@Client VarChar(6),@Division VarChar(6),@Product Varchar(6),@Job Varchar(6),@JobComp Varchar(6),@Office Varchar(4),@SalesClass Varchar(6),@AE Varchar(6),@Campaign Varchar(6), @EMP_CODE varchar(6)'

EXEC sp_executesql @sql, @paramlist, @UserID, @Client, @Division, @Product, @Job, @JobComp, @Office, @SalesClass, @AE, @Campaign, @EMP_CODE
End