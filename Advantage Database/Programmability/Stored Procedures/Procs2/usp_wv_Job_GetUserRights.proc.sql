

CREATE PROCEDURE [dbo].[usp_wv_Job_GetUserRights] 
@USER_ID AS varchar(100)


AS

SET NOCOUNT ON

SELECT     USER_ID, SEC_VIEW, SEC_EDIT, SEC_INSERT
FROM         SEC_RIGHTS
WHERE     UPPER(USER_ID) = UPPER(@USER_ID) AND APPLICATION_ID = 'Job'

