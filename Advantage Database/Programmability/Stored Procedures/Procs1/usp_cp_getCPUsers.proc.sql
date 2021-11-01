
CREATE PROCEDURE [dbo].[usp_cp_getCPUsers] 
@Client VarChar(6)
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

SELECT @sql = 'SELECT CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_FML, ISNULL(CP_ALERTS, 0) AS CP_ALERTS, ISNULL(EMAIL_RCPT, 0) AS EMAIL_RCPT, CONT_CODE
				   FROM CDP_CONTACT_HDR 
				   WHERE CDP_CONTACT_HDR.CP_USER = 1 AND (CDP_CONTACT_HDR.INACTIVE_FLAG IS NULL OR CDP_CONTACT_HDR.INACTIVE_FLAG = 0)
				   AND CDP_CONTACT_HDR.CDP_CONTACT_ID NOT IN (SELECT CDP_CONTACT_ID FROM CP_USER)'
			if @Client <> '' 
				   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CL_CODE = @Client)'
			

SELECT @paramlist = '@Client VarChar(6)'

EXEC sp_executesql @sql, @paramlist, @Client 
 



	
