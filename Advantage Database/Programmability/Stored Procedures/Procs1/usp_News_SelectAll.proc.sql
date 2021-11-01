

















CREATE PROCEDURE [dbo].[usp_News_SelectAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[NewsID],
	[NewsDate],
	[NewsTitle],
	[NewsText],
	[Active]
FROM
	[dbo].[tblNews]
Where Active = 1

















