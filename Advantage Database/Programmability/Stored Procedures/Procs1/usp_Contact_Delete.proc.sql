


















CREATE PROCEDURE [dbo].[usp_Contact_Delete]
	@ContactID int
AS

DELETE FROM [dbo].[tblContacts]
WHERE
	[ContactID] = @ContactID



















