IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_Client_AddContact]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_Client_AddContact]
GO

CREATE PROCEDURE [dbo].[usp_wv_Client_AddContact]
(
	@CL_CODE VARCHAR(6),
	@CONT_CODE VARCHAR(6),
	@CONT_FNAME VARCHAR(30),
	@CONT_LNAME VARCHAR(30),
	@CONT_MI VARCHAR(1),
	@CONT_TITLE VARCHAR(40),
	@CONT_ADDRESS1 VARCHAR(40),
	@CONT_ADDRESS2 VARCHAR(40),
	@CONT_CITY VARCHAR(20),
	@CONT_COUNTY VARCHAR(20),
	@CONT_STATE VARCHAR(10),
	@CONT_COUNTRY VARCHAR(20),
	@CONT_ZIP VARCHAR(10),
	@CONT_TELEPHONE VARCHAR(13),
	@CONT_EXTENTION VARCHAR(5),
	@CONT_FAX VARCHAR(13),
	@CONT_FAX_EXTENTION VARCHAR(5),
	@EMAIL_ADDRESS VARCHAR(50),
	@CELL_PHONE VARCHAR(13),
	@SCHEDULE_USER smallint,
	@CP_USER smallint,
	@GETS_ALERTS smallint,
	@EMAIL_RCPT smallint,
	@INACTIVE smallint,
	@COPY_ADDRESS smallint,
	@CONT_COMMENT text,
	@CONTACT_TYPE_ID int,
	@CDP_ID smallint OUTPUT
)
AS
BEGIN
	SET NOCOUNT OFF
	
	DECLARE 
	@ERR INT,
	@Address1 varchar(40), @Address2 varchar(40), @City varchar(20), @State varchar(10), @Zip varchar(10)

	if @COPY_ADDRESS = 1
	Begin
		SELECT @Address1 = CL_ADDRESS1, @Address2 = CL_ADDRESS2, @City = CL_CITY, @State = CL_STATE, @Zip = CL_ZIP
		FROM CLIENT
		WHERE CL_CODE = @CL_CODE
		INSERT INTO [CDP_CONTACT_HDR]
			(
				[CONT_CODE],
				[CL_CODE],
				[CONT_FNAME],
				[CONT_LNAME],
				[CONT_MI],
				[CONT_TITLE],
				[CONT_ADDRESS1],
				[CONT_ADDRESS2],
				[CONT_CITY],
				[CONT_COUNTY],
				[CONT_STATE],
				[CONT_COUNTRY],
				[CONT_ZIP],
				[CONT_TELEPHONE],
				[CONT_EXTENTION],
				[CONT_FAX],
				[CONT_FAX_EXTENTION],
				[EMAIL_ADDRESS],
				[CELL_PHONE],
				[SCHEDULE_USER],
				[CP_USER],
				[CP_ALERTS],
				[EMAIL_RCPT],
				[INACTIVE_FLAG],
				[CONT_COMMENT],
				[CONTACT_TYPE_ID]
			)
			VALUES
			(
				@CONT_CODE,
				@CL_CODE,
				@CONT_FNAME,
				@CONT_LNAME,
				@CONT_MI,
				@CONT_TITLE,
				@Address1,
				@Address2,
				@City,
				@CONT_COUNTY,
				@State,
				@CONT_COUNTRY,
				@Zip,
				@CONT_TELEPHONE,
				@CONT_EXTENTION,
				@CONT_FAX,
				@CONT_FAX_EXTENTION,
				@EMAIL_ADDRESS,
				@CELL_PHONE,
				@SCHEDULE_USER,
				@CP_USER,
				@GETS_ALERTS,
				@EMAIL_RCPT,
				@INACTIVE,
				@CONT_COMMENT,
				@CONTACT_TYPE_ID
			)
	End
	Else
	Begin
		INSERT INTO [CDP_CONTACT_HDR]
			(
				[CONT_CODE],
				[CL_CODE],
				[CONT_FNAME],
				[CONT_LNAME],
				[CONT_MI],
				[CONT_TITLE],
				[CONT_ADDRESS1],
				[CONT_ADDRESS2],
				[CONT_CITY],
				[CONT_COUNTY],
				[CONT_STATE],
				[CONT_COUNTRY],
				[CONT_ZIP],
				[CONT_TELEPHONE],
				[CONT_EXTENTION],
				[CONT_FAX],
				[CONT_FAX_EXTENTION],
				[EMAIL_ADDRESS],
				[CELL_PHONE],
				[SCHEDULE_USER],
				[CP_USER],
				[CP_ALERTS],
				[EMAIL_RCPT],
				[INACTIVE_FLAG],
				[CONT_COMMENT],
				[CONTACT_TYPE_ID]
			)
			VALUES
			(
				@CONT_CODE,
				@CL_CODE,
				@CONT_FNAME,
				@CONT_LNAME,
				@CONT_MI,
				@CONT_TITLE,
				@CONT_ADDRESS1,
				@CONT_ADDRESS2,
				@CONT_CITY,
				@CONT_COUNTY,
				@CONT_STATE,
				@CONT_COUNTRY,
				@CONT_ZIP,
				@CONT_TELEPHONE,
				@CONT_EXTENTION,
				@CONT_FAX,
				@CONT_FAX_EXTENTION,
				@EMAIL_ADDRESS,
				@CELL_PHONE,
				@SCHEDULE_USER,
				@CP_USER,
				@GETS_ALERTS,
				@EMAIL_RCPT,
				@INACTIVE,
				@CONT_COMMENT,
				@CONTACT_TYPE_ID
			)
	End

	
	SELECT @CDP_ID = CDP_CONTACT_ID
	FROM CDP_CONTACT_HDR
	WHERE CONT_CODE = @CONT_CODE
	
	SET @ERR = @@Error

	--RETURN @ERR
END




