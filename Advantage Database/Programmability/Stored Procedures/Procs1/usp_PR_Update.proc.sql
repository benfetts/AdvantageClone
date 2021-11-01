


















CREATE PROCEDURE [dbo].[usp_PR_Update]
	@PRID int,
	@PRDate datetime,
	@PRTitle varchar(100),
	@PRText NText,
	@Active bit
AS

UPDATE [dbo].[tblPRReleases] SET
	[PRDate] = @PRDate,
	[PRTitle] = @PRTitle,
	[PRText] = @PRText,
	[Active] = @Active
WHERE
	[PRID] = @PRID

















