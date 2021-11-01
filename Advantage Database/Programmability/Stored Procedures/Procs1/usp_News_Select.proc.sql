

















CREATE PROCEDURE [dbo].[usp_News_Select]
	@NewsID int
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
WHERE
	[NewsID] = @NewsID

















