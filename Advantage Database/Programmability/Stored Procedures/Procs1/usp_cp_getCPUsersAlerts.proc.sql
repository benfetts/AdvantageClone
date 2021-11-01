
CREATE PROCEDURE [dbo].[usp_cp_getCPUsersAlerts] 
@Client VarChar(6),
@Product VarChar(6),
@Division VarChar(6)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

SELECT @sql = 'SELECT DISTINCT CDP_CONTACT_HDR.CDP_CONTACT_ID, COALESCE (RTRIM(CDP_CONTACT_HDR.CONT_FNAME) + '' '', '''') 
                      + COALESCE (CDP_CONTACT_HDR.CONT_MI + ''. '', '''') + COALESCE (CDP_CONTACT_HDR.CONT_LNAME, '''') AS CONT_FML, ISNULL(CP_ALERTS, 0) AS CP_ALERTS, ISNULL(EMAIL_RCPT, 0) AS EMAIL_RCPT, CONT_CODE
				   FROM CDP_CONTACT_HDR INNER JOIN
                      CP_SEC_CLIENT ON CDP_CONTACT_HDR.CDP_CONTACT_ID = CP_SEC_CLIENT.CDP_CONTACT_ID
				   WHERE CDP_CONTACT_HDR.CP_USER = 1 AND (CDP_CONTACT_HDR.INACTIVE_FLAG IS NULL OR CDP_CONTACT_HDR.INACTIVE_FLAG = 0)'
			if @Client <> '' 
				   SELECT @sql = @sql + ' AND (CP_SEC_CLIENT.CL_CODE = @Client)'
			if @Division <> '' 
				   SELECT @sql = @sql + ' AND (CP_SEC_CLIENT.DIV_CODE = @Division)'
			if @Product <> '' 
				   SELECT @sql = @sql + ' AND (CP_SEC_CLIENT.PRD_CODE = @Product)'
			

SELECT @paramlist = '@Client VarChar(6), @Product VarChar(6), @Division VarChar(6)'

EXEC sp_executesql @sql, @paramlist, @Client, @Product, @Division
 



	
