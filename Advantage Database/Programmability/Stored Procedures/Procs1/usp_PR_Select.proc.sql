


















CREATE PROCEDURE [dbo].[usp_PR_Select]
	@PRID int
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
WHERE
	[PRID] = @PRID





















