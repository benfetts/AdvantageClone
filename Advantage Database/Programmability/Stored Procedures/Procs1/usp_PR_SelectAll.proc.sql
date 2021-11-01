


















CREATE PROCEDURE [dbo].[usp_PR_SelectAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[PRID],
	[PRDate],
	[PRTitle],
	[PRText],
	[Active]
FROM
	[dbo].[tblPRReleases]



















