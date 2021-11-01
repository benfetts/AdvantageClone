CREATE PROCEDURE [dbo].[advsp_quote_approval_password_create]
	@EmployeeCode varchar(6),
	@Password varchar(10)
AS
BEGIN

	DECLARE @Length int
	DECLARE @Position int
	DECLARE @ASCii int
	DECLARE @EncryptedPassword varchar(30)
	DECLARE @Character varchar(1)

	SELECT @Length = LEN(@Password)

	SET @Position = 1
	SET @EncryptedPassword = ''

	WHILE @Position < (@Length + 1) BEGIN
	
		SET @Character = SUBSTRING(@Password, @Position, 1)
		SET @ASCii = ASCII(@Character)
		SET @ASCii = @ASCii - 77
		
		IF @ASCii < 0 BEGIN
		
			SET @ASCii = @ASCii + 255
			
		END
		
		SET @Character = CHAR(@ASCii)
		SET @EncryptedPassword = @EncryptedPassword + @Character
		
		SET @Position = @Position + 1
		
	END

	IF EXISTS(SELECT EMP_CODE FROM dbo.QTE_APP_PWD WHERE EMP_CODE = @EmployeeCode) BEGIN
	
		UPDATE 
			dbo.QTE_APP_PWD 
		SET 
			EMP_PWD = @EncryptedPassword 
		WHERE 
			EMP_CODE = @EmployeeCode
		
	END ELSE BEGIN
	
		INSERT INTO dbo.QTE_APP_PWD([EMP_CODE], [EMP_PWD], [DELETE_FLAG])
		VALUES(@EmployeeCode, @EncryptedPassword, 0)
		
	END

END
