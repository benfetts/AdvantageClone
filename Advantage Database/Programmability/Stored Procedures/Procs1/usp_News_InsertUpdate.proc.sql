

















CREATE PROCEDURE [dbo].[usp_News_InsertUpdate]
	@NewsID int,
	@NewsDate datetime,
	@NewsTitle varchar(100),
	@NewsText varchar(500),
	@Active bit
AS

SET NOCOUNT ON

IF EXISTS(SELECT [NewsID] FROM [dbo].[tblNews] WHERE [NewsID] = @NewsID)
	BEGIN
		UPDATE [dbo].[tblNews] SET
			[NewsDate] = @NewsDate,
			[NewsTitle] = @NewsTitle,
			[NewsText] = @NewsText,
			[Active] = @Active
		WHERE
			[NewsID] = @NewsID
	END
ELSE
	BEGIN
		INSERT INTO [dbo].[tblNews] (
			[NewsDate],
			[NewsTitle],
			[NewsText],
			[Active]
		) VALUES (
			@NewsDate,
			@NewsTitle,
			@NewsText,
			@Active
		)
	END

--endregion

















