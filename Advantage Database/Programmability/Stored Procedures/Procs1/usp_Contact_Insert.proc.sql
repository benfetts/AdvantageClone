

















CREATE PROCEDURE [dbo].[usp_Contact_Insert]
	@FullName varchar(100),
	@Company varchar(50),
	@Email varchar(50),
	@Street1 varchar(100),
	@Street2 varchar(100),
	@City varchar(50),
	@State char(2),
	@ZipCode varchar(10),
	@Phone varchar(15),
	@HearAbout varchar(50),
	@Comments varchar(250),
	@Subsribe bit

AS

SET NOCOUNT ON

INSERT INTO [dbo].[tblContacts] (
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
) VALUES (
	@FullName,
	@Company,
	@Email,
	@Street1,
	@Street2,
	@City,
	@State,
	@ZipCode,
	@Phone,
	@HearAbout,
	@Comments,
	@Subsribe
)

Select SCOPE_IDENTITY()

















