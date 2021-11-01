

















CREATE PROCEDURE [dbo].[usp_News_Delete]
	@NewsID int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[tblNews]
WHERE
	[NewsID] = @NewsID

















