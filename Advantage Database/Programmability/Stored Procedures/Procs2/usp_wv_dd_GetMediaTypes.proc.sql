








/*****************************************************************
Gets Media Types for Drop Down s
******************************************************************/
CREATE PROCEDURE [dbo].[usp_wv_dd_GetMediaTypes] 
@UserID VarChar(100) 
AS
Declare @Restrictions Int

Set NoCount on

Select @Restrictions = Count(*) 
FROM SEC_CLIENT
WHERE UPPER(USER_ID) = UPPER(@UserID)

--If @Restrictions > 0
	--SELECT     CLIENT.CL_CODE AS Code, CLIENT.CL_CODE + ' - ' + isnull(CLIENT.CL_NAME, '') AS Description
	--FROM         CLIENT INNER JOIN
     --                 SEC_CLIENT ON CLIENT.CL_CODE = SEC_CLIENT.CL_CODE
	--WHERE     (CLIENT.ACTIVE_FLAG = 1) AND (UPPER(SEC_CLIENT.USER_ID) = UPPER(@UserID))
	--Group BY  CLIENT.CL_CODE, CLIENT.CL_NAME
--ELSE
SELECT DISTINCT MEDIA_TYPE
FROM         dbo.MAGAZINE_HEADER
UNION
SELECT DISTINCT MEDIA_TYPE
FROM         dbo.NEWSPAPER_HEADER
UNION
SELECT DISTINCT MEDIA_TYPE
FROM         dbo.INTERNET_HEADER
UNION
SELECT DISTINCT MEDIA_TYPE
FROM         dbo.OUTDOOR_HEADER
UNION
SELECT DISTINCT MEDIA_TYPE
FROM         dbo.RADIO_HEADER
UNION
SELECT DISTINCT MEDIA_TYPE
FROM         dbo.TV_HEADER




















