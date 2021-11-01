

















CREATE PROCEDURE [dbo].[usp_PR_Insert]
	@PRDate datetime,
	@PRTitle varchar(100),
	@PRText Ntext,
	@Active bit
AS

SET NOCOUNT ON

INSERT INTO [dbo].[tblPRReleases] (
	[PRDate],
	[PRTitle],
	[PRText],
	[Active]
) VALUES (
	@PRDate,
	@PRTitle,
	@PRText,
	@Active
)

Select SCOPE_IDENTITY()

















