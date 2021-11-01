


















CREATE PROCEDURE [dbo].[usp_Contact_Update]
	@ContactID int,
	@ContactDate datetime,
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

UPDATE [dbo].[tblContacts] SET
	[ContactDate] = @ContactDate,
	[FullName] = @FullName,
	[Company] = @Company,
	[Email] = @Email,
	[Street1] = @Street1,
	[Street2] = @Street2,
	[City] = @City,
	[State] = @State,
	[ZipCode] = @ZipCode,
	[Phone] = @Phone,
	[HearAbout] = @HearAbout,
	[Comments] = @Comments,
	[Subsribe] = @Subsribe
WHERE
	[ContactID] = @ContactID

















