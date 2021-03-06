
CREATE PROCEDURE [dbo].[usp_cp_getCPUsersEmailFlag] 
@CDPID int
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

SELECT @sql = 'SELECT ISNULL(EMAIL_RCPT,0) AS EMAIL_RCPT
				   FROM CDP_CONTACT_HDR
				   WHERE CDP_CONTACT_HDR.CP_USER = 1 AND (CDP_CONTACT_HDR.INACTIVE_FLAG IS NULL OR CDP_CONTACT_HDR.INACTIVE_FLAG = 0)'
			if @CDPID <> '' 
				   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CDP_CONTACT_ID = @CDPID)'
			

SELECT @paramlist = '@CDPID int'

EXEC sp_executesql @sql, @paramlist, @CDPID 
 



	
