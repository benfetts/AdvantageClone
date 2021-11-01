




















CREATE PROCEDURE [dbo].[usp_wv_dd_GetOffices] AS

SELECT     OFFICE_CODE AS Code, ISNULL(OFFICE_CODE, '') + ' - ' + ISNULL(OFFICE_NAME, '') AS Description
FROM         OFFICE
WHERE     (INACTIVE_FLAG IS NULL) OR
                      (INACTIVE_FLAG = 0)
ORDER BY OFFICE_CODE




















