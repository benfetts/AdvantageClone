
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[advsp_client_contact_add_update_api]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[advsp_client_contact_add_update_api]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[advsp_client_contact_add_update_api] 
	@cdp_contact_id_in int,			--for updates
    @cont_code varchar(6),			--input
    @cl_code varchar(6),			--input
    @email_address varchar(50),		--input
    @cont_fname varchar(30),		--input
    @cont_lname varchar(30),		--input
    @cont_mi varchar(1),			--input
    @cont_title varchar(40),		--input
    @cont_address1 varchar(40),		--input
    @cont_address2 varchar(40),		--input
    @cont_city varchar(30),			--input
    @cont_county varchar(20),		--input
    @cont_state varchar(10),		--input
    @cont_country varchar(20),		--input
    @cont_zip varchar(10),			--input
    @cont_telephone varchar(13),	--input
    @cont_extention varchar(5),		--input
    @cont_fax varchar(13),			--input
    @cont_fax_extention varchar(5),	--input
    @schedule_user smallint,		--input
    @cp_user smallint,				--input
    @cp_alerts smallint,			--input
    @email_rcpt smallint,			--input
    @cell_phone varchar(13),		--input
    @cont_comment varchar(max),		--input
    @contact_type_id int,			--input

	--@default_task varchar(10),		--??
	--@task_primary smallint,			--??

	@inactive_flag smallint,		--input

	@cdp_contact_id_out int OUTPUT,	--generated
	@ret_val int OUTPUT, @ret_val_s varchar(max) OUTPUT

AS

DECLARE @ErMessage nvarchar(2048), @ErSeverity int, @ErState int
DECLARE @error_msg_w varchar(200)

DECLARE @found int = 0
DECLARE @contact_id_found int = 0
DECLARE @action varchar(6)

BEGIN TRY

SET NOCOUNT ON

BEGIN TRAN

SET @cdp_contact_id_out = @cdp_contact_id_in

SET @error_msg_w = ''

IF @cdp_contact_id_in IS NULL BEGIN 
	SET @cdp_contact_id_in = 0
END

IF @contact_type_id = 0 BEGIN 
	SET @contact_type_id = NULL
END

--CASE WHEN @contact_type_id = -1 THEN CONTACT_TYPE_ID ELSE @contact_type_id END

IF ISNULL(@cl_code, '') = '' BEGIN 
	SET @error_msg_w = 'Client code is required.'
END
ELSE BEGIN
	SELECT @found = 1 FROM [dbo].[CLIENT] WHERE CL_CODE = @cl_code AND ACTIVE_FLAG = 1
	IF @found = 0 BEGIN
		SET @error_msg_w = 'Client code is Invalid.'
	END
END

IF ISNULL(@cont_code, '') = '' BEGIN 
	IF @error_msg_w > '' BEGIN
		SET @error_msg_w = @error_msg_w + ' | '
	END
	SET @error_msg_w = @error_msg_w + 'Contact code is required.'
END

IF ISNULL(@contact_type_id, -1) > 0 BEGIN 
	SET @found = 0
	SELECT @found = 1 FROM [dbo].[CONTACT_TYPE] WHERE [CONTACT_TYPE_ID] = @contact_type_id
	IF @found = 0 BEGIN
		IF @error_msg_w > '' BEGIN
			SET @error_msg_w = @error_msg_w + ' | '
		END
		SET @error_msg_w = @error_msg_w + 'Contact Type ID is Invalid.'
	END
END

IF @error_msg_w > '' BEGIN
	GOTO ERROR_MSG	
END

--Add hdr

SET @ret_val = 0
SET @ret_val_s = 'Success...'

SET @contact_id_found = 0

SELECT @contact_id_found = [CDP_CONTACT_ID] FROM [dbo].[CDP_CONTACT_HDR] WHERE CL_CODE = @cl_code AND CONT_CODE = @cont_code

SET @contact_id_found = 0

IF @cdp_contact_id_in > 0 BEGIN /* CDP Contact ID provided */
	SELECT @contact_id_found = [CDP_CONTACT_ID] FROM [dbo].[CDP_CONTACT_HDR] WHERE CL_CODE = @cl_code AND CONT_CODE = @cont_code AND [CDP_CONTACT_ID] <> @cdp_contact_id_in
	IF ISNULL(@contact_id_found, 0) > 0 BEGIN /* Clinet/Contact combo exists on another record */
		SET @error_msg_w = 'Please enter a unique contact code for client code (' + @cl_code + ').'
		GOTO ERROR_MSG	
	END
	ELSE BEGIN
		SELECT @contact_id_found = [CDP_CONTACT_ID] FROM [dbo].[CDP_CONTACT_HDR] WHERE [CDP_CONTACT_ID] = @cdp_contact_id_in
		IF ISNULL(@contact_id_found, 0) > 0 BEGIN /* Clinet/Contact combo exists on another record */
			SET @action = 'UPDATE'
		END
		ELSE BEGIN
			SET @error_msg_w = 'Please enter a valid Contact ID.'
			GOTO ERROR_MSG	
		END
	END
END
ELSE BEGIN /* Clinet/Contact combo does not exist */
	SELECT @contact_id_found = [CDP_CONTACT_ID] FROM [dbo].[CDP_CONTACT_HDR] WHERE CL_CODE = @cl_code AND CONT_CODE = @cont_code
	IF ISNULL(@contact_id_found, 0) > 0 BEGIN /* Clinet/Contact combo exists on another record */
		SET @error_msg_w = 'Please enter a unique contact code for client code (' + @cl_code + ').'
		GOTO ERROR_MSG	
	END
	ELSE BEGIN
		IF ISNULL(@cdp_contact_id_in, 0) = 0 BEGIN
			SET @action = 'INSERT'
		END
	END
END

IF @action = 'INSERT' BEGIN
	SET @ret_val_s = @action

	INSERT INTO [dbo].[CDP_CONTACT_HDR]
			   ([CONT_CODE]
			   ,[CL_CODE]
			   ,[EMAIL_ADDRESS]
			   ,[CONT_FNAME]
			   ,[CONT_LNAME]
			   ,[CONT_MI]
			   ,[CONT_TITLE]
			   ,[CONT_ADDRESS1]
			   ,[CONT_ADDRESS2]
			   ,[CONT_CITY]
			   ,[CONT_COUNTY]
			   ,[CONT_STATE]
			   ,[CONT_COUNTRY]
			   ,[CONT_ZIP]
			   ,[CONT_TELEPHONE]
			   ,[CONT_EXTENTION]
			   ,[CONT_FAX]
			   ,[CONT_FAX_EXTENTION]
			   ,[SCHEDULE_USER]
			   --,[DEFAULT_TASK]
			   ,[CP_USER]
			   ,[CP_ALERTS]
			   ,[EMAIL_RCPT]
			   --,[TASK_PRIMARY]
			   ,[INACTIVE_FLAG]
			   ,[CELL_PHONE]
			   ,[CONT_COMMENT]
			   ,[CONTACT_TYPE_ID])
		 VALUES
			   (@cont_code,			
				@cl_code,			
				@email_address,		
				@cont_fname,		
				@cont_lname,		
				@cont_mi,			
				@cont_title,		
				@cont_address1,		
				@cont_address2,		
				@cont_city,			
				@cont_county,		
				@cont_state,		
				@cont_country,		
				@cont_zip,			
				@cont_telephone,	
				@cont_extention,		
				@cont_fax,			
				@cont_fax_extention,	
				ISNULL(@schedule_user, 0),		
				--@default_task,		
				ISNULL(@cp_user, 0),				
				ISNULL(@cp_alerts, 0),			
				ISNULL(@email_rcpt, 0),			
				--@task_primary,			
				ISNULL(@inactive_flag, 0),		
				@cell_phone,		
				@cont_comment,			
				CASE WHEN @contact_type_id = -1 THEN NULL ELSE @contact_type_id END)

				SELECT TOP 1 @cdp_contact_id_out = [CDP_CONTACT_ID] FROM [CDP_CONTACT_HDR] ORDER BY [CDP_CONTACT_ID] DESC

END
ELSE IF @action = 'UPDATE' BEGIN
	SET @ret_val_s = @action

	UPDATE [dbo].[CDP_CONTACT_HDR] SET
			[CONT_CODE] = @cont_code,
			[CL_CODE] = @cl_code,
			[EMAIL_ADDRESS] = CASE WHEN @email_address = '*' THEN [EMAIL_ADDRESS] ELSE @email_address END,
			[CONT_FNAME] = CASE WHEN @cont_fname = '*' THEN [CONT_FNAME] ELSE @cont_fname END,
			[CONT_LNAME] = CASE WHEN @cont_lname = '*' THEN [CONT_LNAME] ELSE @cont_lname END,
			[CONT_MI] = CASE WHEN @cont_mi = '*' THEN [CONT_MI] ELSE @cont_mi END,
			[CONT_TITLE] = CASE WHEN @cont_title = '*' THEN [CONT_TITLE] ELSE @cont_title END,
			[CONT_ADDRESS1] = CASE WHEN @cont_address1 = '*' THEN [CONT_ADDRESS1] ELSE @cont_address1 END,
			[CONT_ADDRESS2] = CASE WHEN @cont_address2 = '*' THEN [CONT_ADDRESS2] ELSE @cont_address2 END,
			[CONT_CITY] = CASE WHEN @cont_city = '*' THEN [CONT_CITY] ELSE @cont_city END,
			[CONT_COUNTY] = CASE WHEN @cont_county = '*' THEN [CONT_COUNTY] ELSE @cont_county END,
			[CONT_STATE] = CASE WHEN @cont_state = '*' THEN [CONT_STATE] ELSE @cont_state END,
			[CONT_COUNTRY] = CASE WHEN @cont_country = '*' THEN [CONT_COUNTRY] ELSE @cont_country END,
			[CONT_ZIP] = CASE WHEN @cont_zip = '*' THEN [CONT_ZIP] ELSE @cont_zip END,
			[CONT_TELEPHONE] = CASE WHEN @cont_telephone = '*' THEN [CONT_TELEPHONE] ELSE @cont_telephone END,
			[CONT_EXTENTION] = CASE WHEN @cont_extention = '*' THEN [CONT_FAX] ELSE @cont_extention END,
			[CONT_FAX] = CASE WHEN @cont_fax = '*' THEN [CONT_FAX] ELSE @cont_fax END,
			[CONT_FAX_EXTENTION] = CASE WHEN @cont_fax_extention = '*' THEN [CONT_FAX_EXTENTION] ELSE @cont_fax_extention END,
			[SCHEDULE_USER] = CASE WHEN @schedule_user = -1 THEN 0 ELSE ISNULL(@schedule_user, 0) END,
			--[DEFAULT_TASK] = CASE WHEN @default_task = '*' THEN [DEFAULT_TASK] ELSE @default_task END,
			[CP_USER] = CASE WHEN @cp_user = -1 THEN 0 ELSE ISNULL(@cp_user, 0) END,
			[CP_ALERTS] = CASE WHEN @cp_alerts = -1 THEN 0 ELSE ISNULL(@cp_alerts, 0) END,
			[EMAIL_RCPT] = CASE WHEN @email_rcpt = -1 THEN 0 ELSE ISNULL(@email_rcpt, 0) END,
			--[TASK_PRIMARY] = CASE WHEN @task_primary = -1 THEN [TASK_PRIMARY] ELSE @task_primary END,
			[INACTIVE_FLAG] = CASE WHEN @inactive_flag = -1 THEN 0 ELSE ISNULL(@inactive_flag, 0) END,
			[CELL_PHONE] = CASE WHEN @cell_phone = '*' THEN [CELL_PHONE] ELSE @cell_phone END,
			[CONT_COMMENT] = CASE WHEN @cont_comment = '*' THEN [CONT_COMMENT] ELSE @cont_comment END,
			[CONTACT_TYPE_ID] = CASE WHEN @contact_type_id = -1 THEN NULL ELSE @contact_type_id END
	WHERE [CDP_CONTACT_ID] = @cdp_contact_id_out
		
				
END

--SELECT @cdp_contact_id_in '@cdp_contact_id_in', @cdp_contact_id_out '@cdp_contact_id_out'

--SELECT * FROM [CDP_CONTACT_HDR] WHERE [CDP_CONTACT_ID] IN (1035, @cdp_contact_id_out)


COMMIT TRAN

--ROLLBACK TRAN

GOTO ENDIT
           
/**************************** ERROR PROCESSING ************************************************************************/	
	ERROR_MSG:
		BEGIN
		
			RAISERROR (@error_msg_w,
			 16,
			 1 )    
			
		END

	ENDIT: --Do Nothing

END TRY

BEGIN CATCH

	IF @@TRANCOUNT > 0 BEGIN
		ROLLBACK TRAN
	END
	
	--ERROR_NUMBER() as ErrorNumber,
	--SELECT ERROR_MESSAGE() as ErrorMessage;
	   
	SELECT 	@ErMessage = ERROR_MESSAGE(),
					@ErSeverity = ERROR_SEVERITY(),
					@ErState = ERROR_STATE();
	
	--SELECT 	@ErMessage 'ERROR_MESSAGE',	@ErSeverity 'ERROR_SEVERITY', @ErState 'ERROR_SATE'  /* DEBUG */		
	
	SET @ret_val = 1
	SET @ret_val_s = @ErMessage
	
END CATCH

RETURN

GO


GRANT EXECUTE ON [advsp_client_contact_add_update_api] TO PUBLIC AS dbo
GO