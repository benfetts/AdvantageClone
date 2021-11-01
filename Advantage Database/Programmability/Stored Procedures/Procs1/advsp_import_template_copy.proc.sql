CREATE PROCEDURE [dbo].[advsp_import_template_copy] 
	@copy_template_id smallint, 
	@user_code varchar(100), 
	@template_name varchar(100),
	@use_same_record_source bit
AS
BEGIN

	DECLARE @new_template_id smallint
	DECLARE @RECORD_SOURCE_ID smallint

	IF @use_same_record_source = 1 BEGIN
	
		SELECT @RECORD_SOURCE_ID = [RECORD_SOURCE_ID] FROM dbo.IMPORT_TEMPLATE WHERE TEMPLATE_ID = @copy_template_id
		
	END ELSE BEGIN
	
		SET @RECORD_SOURCE_ID = NULL
		
	END
	
	INSERT dbo.IMPORT_TEMPLATE (TEMPLATE_TYPE, TEMPLATE_NAME, FILE_TYPE, CREATE_USER_ID, CREATE_DATE, [RECORD_SOURCE_ID])
	SELECT TEMPLATE_TYPE, @template_name, FILE_TYPE, @user_code, GETDATE(), @RECORD_SOURCE_ID
	FROM dbo.IMPORT_TEMPLATE 
	WHERE TEMPLATE_ID = @copy_template_id 
	
	SET @new_template_id = SCOPE_IDENTITY()

	INSERT dbo.IMPORT_TEMPLATE_DTL (TEMPLATE_ID, FIELD_NAME, CSV_POSITION, START, [LENGTH], DATE_FORMAT)
	SELECT @new_template_id, FIELD_NAME, CSV_POSITION, START, [LENGTH], DATE_FORMAT
	FROM dbo.IMPORT_TEMPLATE_DTL 
	WHERE TEMPLATE_ID = @copy_template_id 
	
	INSERT dbo.ADV_SERVICE_IMPORT (TEMPLATE_ID) VALUES (@new_template_id)

	SELECT @new_template_id

END
GO


