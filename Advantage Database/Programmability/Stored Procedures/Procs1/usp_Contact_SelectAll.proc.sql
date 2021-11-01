


















CREATE PROCEDURE [dbo].[usp_Contact_SelectAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[ContactID],
	[ContactDate],
	[FullName],
	[Company],
	[Email],
	[Street1],
	[Street2],
	[City],
	[State],
	[ZipCode],
	[Phone],
	[HearAbout],
	[Comments],
	[Subsribe]
FROM
	[dbo].[tblContacts]
ORDER BY ContactDate Desc

















