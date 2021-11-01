


/*****************************************************************
Gets Desktop Objects for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetApplications] 
@CDPID int
AS

SELECT     CP_APPLICATIONS.APPID , '(' + CP_APPLICATIONS_CATEGORY.CATEGORY + ') - ' + CP_APPLICATIONS.APPNAME AS Description 
FROM         CP_APPLICATIONS_CATEGORY INNER JOIN
                      CP_APPLICATIONS ON CP_APPLICATIONS_CATEGORY.CATID = CP_APPLICATIONS.CATID
ORDER BY CP_APPLICATIONS_CATEGORY.CATEGORY

