





CREATE PROCEDURE [dbo].[usp_wv_dd_GetEstimatesCopy]
@Client varchar(6),
@Division varchar(6),
@Product varchar(6),
@UserID varchar(100),
@JobType varchar(10)
AS
Declare @Restrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeCount AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeCount = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

SELECT @sql = 'SELECT DISTINCT ESTIMATE_LOG.ESTIMATE_NUMBER AS Code, STR(ESTIMATE_LOG.ESTIMATE_NUMBER) + '' - '' +isnull(ESTIMATE_LOG.EST_LOG_DESC, '''') AS Description
				FROM         ESTIMATE_COMPONENT INNER JOIN
							  ESTIMATE_LOG ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER LEFT OUTER JOIN
							  JOB_COMPONENT ON ESTIMATE_COMPONENT.ESTIMATE_NUMBER = JOB_COMPONENT.ESTIMATE_NUMBER AND 
							  ESTIMATE_COMPONENT.EST_COMPONENT_NBR = JOB_COMPONENT.EST_COMPONENT_NBR INNER JOIN
						  PRODUCT ON PRODUCT.CL_CODE = ESTIMATE_LOG.CL_CODE AND PRODUCT.DIV_CODE = ESTIMATE_LOG.DIV_CODE AND PRODUCT.PRD_CODE = ESTIMATE_LOG.PRD_CODE'

			if @Restrictions > 0
				Begin
				   SELECT @sql = @sql + ' INNER JOIN SEC_CLIENT ON ESTIMATE_LOG.CL_CODE = SEC_CLIENT.CL_CODE AND 
										  ESTIMATE_LOG.DIV_CODE = SEC_CLIENT.DIV_CODE AND ESTIMATE_LOG.PRD_CODE = SEC_CLIENT.PRD_CODE'
				End
			IF @OfficeCount > 0
				BEGIN
					SELECT @sql = @sql + ' INNER JOIN EMP_OFFICE ON PRODUCT.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = ''' + @EMP_CODE + ''''
				END
			SELECT @sql = @sql + ' WHERE 1=1'
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
			if @JobType <> ''
				Begin
				   SELECT @sql = @sql + ' AND (JOB_COMPONENT.JT_CODE = @JobType)'
				End			
			if @Restrictions > 0
				Begin
				   SELECT @sql = @sql + ' AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID)) AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
				End
			
SELECT @sql = @sql + ' ORDER BY ESTIMATE_LOG.ESTIMATE_NUMBER DESC'
SELECT @paramlist = '@Client VarChar(6), @Product VarChar(6), @Division VarChar(6), @UserID Varchar(100), @JobType Varchar(10)'
print @sql
EXEC sp_executesql @sql, @paramlist, @Client, @Product, @Division, @UserID, @JobType
                                               




