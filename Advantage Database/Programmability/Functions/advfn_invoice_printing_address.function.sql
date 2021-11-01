CREATE FUNCTION [dbo].[advfn_invoice_printing_address] ( 
	@ADDRESS_BLOCK AS smallint,
	@SHOW_CODES AS smallint,
	@PRINT_CLIENT_NAME AS smallint,
	@PRINT_DIV_NAME AS smallint,
	@PRINT_PRD_DESC AS smallint,
	@CONTACT_POS AS int,
	@CL_CODE varchar(6),
	@CL_NAME varchar(40),
	@CL_ATTENTION varchar(40),
	@CL_BADDRESS1 varchar(40),
	@CL_BADDRESS2 varchar(40),
	@CL_BCITY varchar(30),
	@CL_BCOUNTY varchar(20),
	@CL_BSTATE varchar(10),
	@CL_BCOUNTRY varchar(20),
	@CL_BZIP varchar(10),
	@DIV_CODE varchar(6),
	@DIV_NAME varchar(40),
	@DIV_ATTENTION varchar(40),
	@DIV_BADDRESS1 varchar(40),
	@DIV_BADDRESS2 varchar(40),
	@DIV_BCITY varchar(30),
	@DIV_BCOUNTY varchar(20),
	@DIV_BSTATE varchar(10),
	@DIV_BCOUNTRY varchar(20),
	@DIV_BZIP varchar(10),
	@PRD_CODE varchar(6),
	@PRD_DESCRIPTION varchar(40),
	@PRD_ATTENTION varchar(40),
	@PRD_BILL_ADDRESS1 varchar(40),
	@PRD_BILL_ADDRESS2 varchar(40),
	@PRD_BILL_CITY varchar(30),
	@PRD_BILL_COUNTY varchar(20),
	@PRD_BILL_STATE varchar(10),
	@PRD_BILL_COUNTRY varchar(20),
	@PRD_BILL_ZIP varchar(10),
	@CDP_CONTACT_ID int,
	@CONT_CODE varchar(6),
	@CONT_FNAME varchar(30),
	@CONT_LNAME varchar(30),
	@CONT_MI varchar(1),
	@CONT_ADDRESS1 varchar(40),
	@CONT_ADDRESS2 varchar(40),
	@CONT_CITY varchar(30),
	@CONT_COUNTY varchar(20),
	@CONT_STATE varchar(10),
	@CONT_COUNTRY varchar(20),
	@CONT_ZIP varchar(10),
	@CONTACT_TYPE int, 
	@TYPE varchar(10))
RETURNS varchar(MAX)
WITH SCHEMABINDING
AS
BEGIN
	
	DECLARE @Address AS varchar(MAX)
	DECLARE @ATTENTION varchar(40)
	DECLARE @ADDRESS1 varchar(40)
	DECLARE @ADDRESS2 varchar(40)
	DECLARE @CITY varchar(30)
	DECLARE @STATE varchar(10)
	DECLARE @ZIP varchar(10)
	DECLARE @COUNTY varchar(20)
	DECLARE @COUNTRY varchar(20)
	DECLARE @HasJobContactInfo bit

	SET @Address = ''
	SET @HasJobContactInfo = 0
		
	IF @ADDRESS_BLOCK = 4 BEGIN
	
		IF ISNULL(@PRINT_CLIENT_NAME, 0) = 1 BEGIN
			
			IF @SHOW_CODES = 0 BEGIN
		
				SET @Address = @Address + @CL_NAME
		
			END ELSE BEGIN
			
				SET @Address = @Address + @CL_NAME + ' (' + @CL_CODE + ')'
			
			END

		END

		IF ISNULL(@PRINT_DIV_NAME, 0) = 1 BEGIN
			
			IF @CL_NAME <> @DIV_NAME BEGIN
			
				IF @SHOW_CODES = 0 BEGIN
		
					SET @Address = @Address + char(13) + char(10) + @DIV_NAME
				
				END ELSE BEGIN
			
					SET @Address = @Address + char(13) + char(10) + @DIV_NAME + ' (' + @DIV_CODE + ')'
			
				END

			END
			
		END

		IF ISNULL(@PRINT_PRD_DESC, 0) = 1 BEGIN
				
			IF @CL_NAME <> @PRD_DESCRIPTION BEGIN
			
				IF @SHOW_CODES = 0 BEGIN
		
					SET @Address = @Address + char(13) + char(10) + @PRD_DESCRIPTION
				
				END ELSE BEGIN
			
					SET @Address = @Address + char(13) + char(10) + @PRD_DESCRIPTION + ' (' + @PRD_CODE + ')'
			
				END

			END

		END

		IF ISNULL(@CONTACT_POS, 0) = 0 BEGIN

			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')
					SET @HasJobContactInfo = 1
		
				END

			END ELSE IF (@CONTACT_TYPE = 1 OR @CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')
					SET @HasJobContactInfo = 1
		
				END ELSE IF ISNULL(@CL_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @CL_ATTENTION
			
				END
		
			END
		
		END
		
		IF ISNULL(@CONT_ADDRESS1, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @CONT_ADDRESS1
			SET @HasJobContactInfo = 1
		
		END
		
		IF ISNULL(@CONT_ADDRESS2, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @CONT_ADDRESS2
			SET @HasJobContactInfo = 1
		
		END
		
		IF ISNULL(@CONT_CITY, '') <> '' OR ISNULL(@CONT_STATE, '') <> '' OR ISNULL(@CONT_ZIP, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + ISNULL(@CONT_CITY, '') + ', ' + ISNULL(@CONT_STATE, '') + ' ' + ISNULL(@CONT_ZIP, '')
			SET @HasJobContactInfo = 1
		
		END
		
		IF ISNULL(@CONT_COUNTRY, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @CONT_COUNTRY
			SET @HasJobContactInfo = 1
		
		END
		
		IF ISNULL(@CONTACT_POS, 0) = 1 BEGIN

			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')
					SET @HasJobContactInfo = 1
		
				END

			END ELSE IF (@CONTACT_TYPE = 1 OR @CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')
					SET @HasJobContactInfo = 1
		
				END ELSE IF ISNULL(@CL_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @CL_ATTENTION
			
				END
		
			END
		
		END
		
	END
	
	IF @ADDRESS_BLOCK = 4 AND @HasJobContactInfo = 0 BEGIN
		
		SET @ADDRESS_BLOCK = 3
		SET @Address = ''

	END
		
	IF @ADDRESS_BLOCK = 1 OR @ADDRESS_BLOCK = 2 OR @ADDRESS_BLOCK = 3 BEGIN
		
		IF ISNULL(@PRINT_CLIENT_NAME, 0) = 1 BEGIN
			
			IF @SHOW_CODES = 0 BEGIN
		
				SET @Address = @Address + @CL_NAME
		
			END ELSE BEGIN
			
				SET @Address = @Address + @CL_NAME + ' (' + @CL_CODE + ')'
			
			END

		END

		IF ISNULL(@PRINT_DIV_NAME, 0) = 1 BEGIN
			
			IF @CL_NAME <> @DIV_NAME OR ISNULL(@PRINT_CLIENT_NAME, 0) = 0 BEGIN
			
				IF @SHOW_CODES = 0 BEGIN
		
					SET @Address = @Address + char(13) + char(10) + @DIV_NAME
				
				END ELSE BEGIN
			
					SET @Address = @Address + char(13) + char(10) + @DIV_NAME + ' (' + @DIV_CODE + ')'
			
				END

			END
			
		END

		IF ISNULL(@PRINT_PRD_DESC, 0) = 1 BEGIN
				
			IF @CL_NAME <> @PRD_DESCRIPTION OR (ISNULL(@PRINT_CLIENT_NAME, 0) = 0 AND ISNULL(@PRINT_DIV_NAME, 0) = 0)  BEGIN
			
				IF @SHOW_CODES = 0 BEGIN
		
					SET @Address = @Address + char(13) + char(10) + @PRD_DESCRIPTION
				
				END ELSE BEGIN
			
					SET @Address = @Address + char(13) + char(10) + @PRD_DESCRIPTION + ' (' + @PRD_CODE + ')'
			
				END

			END

		END

	END

	IF @ADDRESS_BLOCK = 1 BEGIN
	
		IF ISNULL(@CONTACT_POS, 0) = 0 BEGIN

			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END

			END ELSE IF (@CONTACT_TYPE = 1) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@CL_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @CL_ATTENTION
			
				END
		
			END ELSE IF (@CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@CL_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @CL_ATTENTION
			
				END

			END
		
		END
		
		IF ISNULL(@CL_BADDRESS1, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @CL_BADDRESS1
			
		END
		
		IF ISNULL(@CL_BADDRESS2, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @CL_BADDRESS2
			
		END
		
		IF ISNULL(@CL_BCITY, '') <> '' OR ISNULL(@CL_BSTATE, '') <> '' OR ISNULL(@CL_BZIP, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + ISNULL(@CL_BCITY, '') + ', ' + ISNULL(@CL_BSTATE, '') + ' ' + ISNULL(@CL_BZIP, '')
			
		END
		
		IF ISNULL(@CL_BCOUNTRY, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @CL_BCOUNTRY
			
		END
		
		IF ISNULL(@CONTACT_POS, 0) = 1 BEGIN
		
			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END

			END ELSE IF (@CONTACT_TYPE = 1) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@CL_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @CL_ATTENTION
			
				END
		
			END  ELSE IF (@CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@CL_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @CL_ATTENTION
			
				END

			END
		
		END

	END ELSE IF @ADDRESS_BLOCK = 2 BEGIN
	
		IF ISNULL(@CONTACT_POS, 0) = 0 BEGIN
		
			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END

			END ELSE IF (@CONTACT_TYPE = 1) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@DIV_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @DIV_ATTENTION
			
				END
		
			END ELSE IF (@CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@DIV_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @DIV_ATTENTION
			
				END

			END
		
		END

		IF ISNULL(@DIV_BADDRESS1, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @DIV_BADDRESS1
			
		END
		
		IF ISNULL(@DIV_BADDRESS2, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @DIV_BADDRESS2
			
		END
		
		IF ISNULL(@DIV_BCITY, '') <> '' OR ISNULL(@DIV_BSTATE, '') <> '' OR ISNULL(@DIV_BZIP, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + ISNULL(@DIV_BCITY, '') + ', ' + ISNULL(@DIV_BSTATE, '') + ' ' + ISNULL(@DIV_BZIP, '')
			
		END
		
		IF ISNULL(@DIV_BCOUNTRY, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @DIV_BCOUNTRY
			
		END
		
		IF ISNULL(@CONTACT_POS, 0) = 1 BEGIN
		
			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END

			END ELSE IF (@CONTACT_TYPE = 1) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@DIV_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @DIV_ATTENTION
			
				END
		
			END ELSE IF ( @CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@DIV_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @DIV_ATTENTION
			
				END

			END
		
		END

	END ELSE IF @ADDRESS_BLOCK = 3 BEGIN
	
		IF ISNULL(@CONTACT_POS, 0) = 0 BEGIN
		
			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END

			END ELSE IF (@CONTACT_TYPE = 1) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@PRD_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @PRD_ATTENTION
			
				END
		
			END ELSE IF (@CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@PRD_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @PRD_ATTENTION
			
				END

			END
		
		END

		IF ISNULL(@PRD_BILL_ADDRESS1, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @PRD_BILL_ADDRESS1
			
		END
		
		IF ISNULL(@PRD_BILL_ADDRESS2, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @PRD_BILL_ADDRESS2
			
		END
		
		IF ISNULL(@PRD_BILL_CITY, '') <> '' OR ISNULL(@PRD_BILL_STATE, '') <> '' OR ISNULL(@PRD_BILL_ZIP, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + ISNULL(@PRD_BILL_CITY, '') + ', ' + ISNULL(@PRD_BILL_STATE, '') + ' ' + ISNULL(@PRD_BILL_ZIP, '')
			
		END
		
		IF ISNULL(@PRD_BILL_COUNTRY, '') <> '' BEGIN
		
			SET @Address = @Address + char(13) + char(10) + @PRD_BILL_COUNTRY
			
		END
		
		IF ISNULL(@CONTACT_POS, 0) = 1 BEGIN
		
			IF @CONTACT_TYPE = 0 BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END

			END ELSE IF (@CONTACT_TYPE = 1) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') AND @TYPE <> 'Job' AND @TYPE <> 'Estimate' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@PRD_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @PRD_ATTENTION
			
				END
		
			END ELSE IF (@CONTACT_TYPE = 2) BEGIN

				IF (ISNULL(@CONT_FNAME, '') <> '' OR ISNULL(@CONT_LNAME, '') <> '') BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + COALESCE((RTRIM(@CONT_FNAME) + ' '), '') + COALESCE((@CONT_MI + '. '), '') + COALESCE(@CONT_LNAME, '')

				END ELSE IF ISNULL(@PRD_ATTENTION, '') <> '' BEGIN
		
					SET @Address = @Address + char(13) + char(10) + 'Attn: ' + @PRD_ATTENTION
			
				END

			END
		
		END

	END
	
	IF @Address LIKE char(13) + char(10) + '%' BEGIN
	
		SET @Address = SUBSTRING(@Address, 3,  LEN(@Address))

	END

	RETURN RTRIM(LTRIM(@Address))
	
END








GO