


















CREATE PROCEDURE [dbo].[usp_PR_Delete]
	@PRID int
AS

DELETE FROM [dbo].[tblPRReleases]
WHERE
	[PRID] = @PRID



















