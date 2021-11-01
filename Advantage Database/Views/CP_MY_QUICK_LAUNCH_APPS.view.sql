﻿


CREATE VIEW [dbo].[CP_MY_QUICK_LAUNCH_APPS]
AS
SELECT     dbo.CP_USER_QUICK_LAUNCH_APPS.CDP_CONTACT_ID, dbo.CP_USER_QUICK_LAUNCH_APPS.TAB_ID, 
                      dbo.CP_USER_QUICK_LAUNCH_APPS.APPLICATION_ID, dbo.CP_APPLICATIONS.APPNAME, dbo.CP_APPLICATIONS.URL, 
                      dbo.CP_APPLICATIONS.IMAGEPATH, dbo.CP_APPLICATIONS.ACTIVE, dbo.CP_APPLICATIONS.SORTORDER
FROM         dbo.CP_USER_QUICK_LAUNCH_APPS INNER JOIN
                      dbo.CP_APPLICATIONS ON dbo.CP_USER_QUICK_LAUNCH_APPS.APPLICATION_ID = dbo.CP_APPLICATIONS.APPID



