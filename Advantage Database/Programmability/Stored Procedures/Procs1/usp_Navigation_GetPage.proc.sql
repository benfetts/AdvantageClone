

















CREATE PROCEDURE [dbo].[usp_Navigation_GetPage] 
@ID SmallInt
AS
SELECT     *
FROM         tblNavigation
WHERE     (ID = @ID)

















