

CREATE PROCEDURE [dbo].[usp_wv_Client_AddContactDP]
(
	@CDP_ID smallint,
	@DIV_CODE VARCHAR(6),
	@PRD_CODE VARCHAR(6)
)
AS
BEGIN
	SET NOCOUNT OFF
	
	DECLARE 
	@ERR INT, @SEQ_NBR smallint,
	@Address1 varchar(40), @Address2 varchar(40), @City varchar(20), @State varchar(10), @Zip varchar(10)

	SELECT @SEQ_NBR = MAX(ISNULL(SEQ_NBR,1)) + 1 FROM CDP_CONTACT_DTL
	WHERE CDP_CONTACT_ID = @CDP_ID

	If @SEQ_NBR IS NULL
	Begin
		SET @SEQ_NBR = 1
	End

	if @PRD_CODE = ''
	Begin
		SET @PRD_CODE = NULL
	End
		
		INSERT INTO [CDP_CONTACT_DTL]
			(
				[CDP_CONTACT_ID],
				[SEQ_NBR],
				[DIV_CODE],
				[PRD_CODE]
			)
			VALUES
			(
				@CDP_ID,
				@SEQ_NBR,
				@DIV_CODE,
				@PRD_CODE
			)
	

	

	
	SET @ERR = @@Error

	--RETURN @ERR
END




