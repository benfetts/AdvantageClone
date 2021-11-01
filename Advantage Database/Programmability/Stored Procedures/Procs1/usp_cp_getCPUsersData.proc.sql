
CREATE PROCEDURE [dbo].[usp_cp_getCPUsersData] 
@CDPID int
AS
Declare @Rescrictions Int,
		@sql nvarchar(4000),
		@paramlist nvarchar(4000)
Set NoCount On

SELECT @sql = 'SELECT CDP_CONTACT_HDR.CDP_CONTACT_ID, CDP_CONTACT_HDR.CONT_FML, 
                      ISNULL(CDP_CONTACT_HDR.EMAIL_ADDRESS, ''''), CDP_CONTACT_HDR.CL_CODE, ISNULL(CDP_CONTACT_DTL.DIV_CODE, ''''), 
                      ISNULL(CDP_CONTACT_DTL.PRD_CODE, ''''), CDP_CONTACT_HDR.CP_USER, CDP_CONTACT_HDR.INACTIVE_FLAG, CDP_CONTACT_HDR.CONT_CODE
				   FROM CDP_CONTACT_HDR LEFT OUTER JOIN
                      CDP_CONTACT_DTL ON CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
				   WHERE 1=1'
			if @CDPID <> '' 
				   SELECT @sql = @sql + ' AND (CDP_CONTACT_HDR.CDP_CONTACT_ID = @CDPID)'
			

SELECT @paramlist = '@CDPID int'

EXEC sp_executesql @sql, @paramlist, @CDPID 
 



	
