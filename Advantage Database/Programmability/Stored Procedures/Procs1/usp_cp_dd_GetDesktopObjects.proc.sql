


/*****************************************************************
Gets Desktop Objects for Drop Down
******************************************************************/
CREATE PROCEDURE [dbo].[usp_cp_dd_GetDesktopObjects] 
@CDPID int
AS
SELECT     CP_DESKTOP_OBJECTS.ID , '(' + CP_DESKTOP_OBJECT_CATEGORY.CATEGORY + ') - ' + CP_DESKTOP_OBJECTS.NAME AS Description 
FROM         CP_DESKTOP_OBJECT_CATEGORY INNER JOIN
                      CP_DESKTOP_OBJECTS ON CP_DESKTOP_OBJECT_CATEGORY.ID = CP_DESKTOP_OBJECTS.CATEGORY_ID
WHERE     (CP_DESKTOP_OBJECTS.ACTIVE = 1) AND (CP_DESKTOP_OBJECTS.ID NOT IN
                          (SELECT     CP_USER_SEC_DO.DOID
                            FROM          CP_USER_SEC_DO 
                            WHERE      CP_USER_SEC_DO.CDP_CONTACT_ID = @CDPID AND CP_USER_SEC_DO.DOID IS NOT NULL))
ORDER BY CP_DESKTOP_OBJECT_CATEGORY.CATEGORY


