﻿


CREATE VIEW [dbo].[CP_APPLICATION_SECURITY]
AS
SELECT     dbo.CP_APPLICATIONS.APPID, dbo.CP_APPLICATIONS.CATID, dbo.CP_APPLICATIONS.APPNAME, dbo.CP_APPLICATIONS.URL, 
                      dbo.CP_APPLICATIONS.IMAGEPATH, dbo.CP_APPLICATIONS.ACTIVE, dbo.CP_APPLICATIONS.SORTORDER, 
                      dbo.CP_USER_SEC_APP.CDP_CONTACT_ID
FROM         dbo.CP_APPLICATIONS INNER JOIN
                      dbo.CP_USER_SEC_APP ON dbo.CP_APPLICATIONS.APPID = dbo.CP_USER_SEC_APP.APPID



