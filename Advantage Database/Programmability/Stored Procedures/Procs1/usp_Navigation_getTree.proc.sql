

















CREATE PROCEDURE [dbo].[usp_Navigation_getTree] AS

SELECT     *
FROM         tblNavigation
WHERE     (ID < 100)
ORDER BY ID

















