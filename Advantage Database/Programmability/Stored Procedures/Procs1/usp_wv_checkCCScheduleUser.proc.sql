
CREATE PROCEDURE [dbo].[usp_wv_checkCCScheduleUser] 
@CDPID int
AS

Set NoCount On

SELECT     CDP_CONTACT_HDR.SCHEDULE_USER
FROM         CDP_CONTACT_HDR
WHERE     (CDP_CONTACT_HDR.CDP_CONTACT_ID = @CDPID)	
	
