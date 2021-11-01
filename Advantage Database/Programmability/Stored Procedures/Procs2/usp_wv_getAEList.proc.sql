

/*****************************************************************
Description: Retrieves list of account executives

Change Log
02/12/2009: jtg - created
 
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_getAEList] 
@Client as VarChar(6), 
@Division as VarChar(6), 
@Product as VarChar(6),
@UserID VarChar(100)

AS
Declare @ClientRestrictions Int
DECLARE @sql 		nvarchar(4000)
DECLARE @sql_from 	nvarchar(2000)
DECLARE @sql_where 	nvarchar(2000)

Select @ClientRestrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

DECLARE @OfficeRestrictions AS INTEGER	
DECLARE @EMP_CODE AS varchar(6)

SELECT @EMP_CODE = EMP_CODE FROM [dbo].[SEC_USER] WHERE UPPER([USER_CODE]) = UPPER(@UserID)
SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

If @Client IS NULL
	Set @Client = ''
	
If @Division IS NULL
	Set @Division = ''
	
If @Product IS NULL
	Set @Product = ''

Set @sql = 'SELECT DISTINCT ACCOUNT_EXECUTIVE.EMP_CODE AS Code, ACCOUNT_EXECUTIVE.EMP_CODE + ISNULL('' - '' + V_ACTIVE_EMPLOYEE.EMP_FML, '''') AS Description '

Set @sql_from = ' FROM ACCOUNT_EXECUTIVE 
	INNER JOIN V_ACTIVE_EMPLOYEE ON ACCOUNT_EXECUTIVE.EMP_CODE = V_ACTIVE_EMPLOYEE.EMP_CODE '

If @OfficeRestrictions > 0
Begin
	Set @sql_from = @sql_from + ' INNER JOIN PRODUCT P ON ACCOUNT_EXECUTIVE.CL_CODE = P.CL_CODE AND ACCOUNT_EXECUTIVE.DIV_CODE = P.DIV_CODE AND ACCOUNT_EXECUTIVE.PRD_CODE = P.PRD_CODE
								  INNER JOIN EMP_OFFICE EO ON P.OFFICE_CODE = EO.OFFICE_CODE AND EO.EMP_CODE = ''' + @EMP_CODE + ''''
End	
if @ClientRestrictions > 0
Begin
	Set @sql_from = @sql_from + ' INNER JOIN SEC_CLIENT ON SEC_CLIENT.CL_CODE = ACCOUNT_EXECUTIVE.CL_CODE AND SEC_CLIENT.DIV_CODE = ACCOUNT_EXECUTIVE.DIV_CODE AND SEC_CLIENT.PRD_CODE = ACCOUNT_EXECUTIVE.PRD_CODE'
End

Set @sql_where = ' WHERE (INACTIVE_FLAG IS NULL OR INACTIVE_FLAG = 0) '

If @Client <> ''
	Set @sql_where = @sql_where + ' AND ACCOUNT_EXECUTIVE.CL_CODE = ''' + @Client + ''''
	
If @Division <> ''
	Set @sql_where = @sql_where + ' AND ACCOUNT_EXECUTIVE.DIV_CODE = ''' + @Division + ''''
	
If @Product <> ''
	Set @sql_where = @sql_where + ' AND ACCOUNT_EXECUTIVE.PRD_CODE = ''' + @Product + ''''

if @ClientRestrictions > 0
Begin
	Set @sql_where = @sql_where + ' AND UPPER(SEC_CLIENT.USER_ID) = UPPER(''' + @UserID + ''') AND (SEC_CLIENT.TIME_ENTRY = 0 OR SEC_CLIENT.TIME_ENTRY IS NULL)'
End	
	                     
	
Set @sql = @sql + @sql_from + @sql_where

EXEC(@sql)
--Print(@sql)

