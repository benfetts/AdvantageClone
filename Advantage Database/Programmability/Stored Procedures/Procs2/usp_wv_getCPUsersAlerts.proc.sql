
CREATE PROCEDURE [dbo].[usp_wv_getCPUsersAlerts] 
@Client VarChar(6),
@Product VarChar(6),
@Division VarChar(6)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

SELECT @sql = 'SELECT DISTINCT CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_FML, ISNULL(CP_ALERTS, 0) AS CP_ALERTS, ISNULL(EMAIL_RCPT, 0) AS EMAIL_RCPT, CONT_CODE
				   FROM CDP_CONTACT_HDR LEFT OUTER JOIN
                      CDP_CONTACT_DTL ON CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
				   WHERE CDP_CONTACT_HDR.CP_USER = 1 AND (CDP_CONTACT_HDR.INACTIVE_FLAG IS NULL OR CDP_CONTACT_HDR.INACTIVE_FLAG = 0)'
			if @Client <> '' 
				   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CL_CODE = @Client)'
			if @Division <> '' 
				   SELECT @sql = @sql + ' AND (CDP_CONTACT_DTL.DIV_CODE = @Division OR CDP_CONTACT_DTL.DIV_CODE IS NULL)'
			if @Product <> '' 
				   SELECT @sql = @sql + ' AND (CDP_CONTACT_DTL.PRD_CODE = @Product OR CDP_CONTACT_DTL.PRD_CODE IS NULL)'
			

SELECT @paramlist = '@Client VarChar(6), @Product VarChar(6), @Division VarChar(6)'

EXEC sp_executesql @sql, @paramlist, @Client, @Product, @Division
 



	
