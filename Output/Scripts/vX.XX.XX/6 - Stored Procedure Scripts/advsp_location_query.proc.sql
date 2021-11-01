CREATE PROCEDURE [dbo].[advsp_location_query]
AS
SET NOCOUNT ON;
-- advsp_location_query ====================================================================
-- #01 12/24/08 - Changed prefix from sp to advsp
-- #02 06/12/09 - changed phone to remove "p" and substituted the word "fax" for "f"
-- #03 08/05/12 - added 2 columns for image footer paths (also for logo location)
-- #04 08/09/12 - fixed number of retrieved columns (added LOGO_LOCATION & LOGO_LOCATION_2)
-- #05 09/18/12 - added space in the middle of phone and fax numberset 
-- #06 03/07/14 - removed space in front of phone and fax
-- #07 03/27/14 - removed last space (not 2 spaces) from result strings - was truncating email address (735-1111)
--==========================================================================================

	CREATE TABLE #locations(
			LOC_ID varchar(6) NULL,
			PRT_HDR smallint NULL,
			LOC_HDR varchar(255),
			PRT_FTR smallint NULL,
			LOC_FTR varchar(255) NULL,
			LOGO_LOCATION varchar(1) NULL,
			DFLT_LOGO_PATH varchar(255) NULL,
			DFLT_LOGO_PATH_LAND varchar(255),
			LOGO_LOCATION_2 varchar(1) NULL,
			DFLT_LOGO_PATH_2 varchar(255) NULL,
			DFLT_LOGO_PATH_LAND_2 varchar(255),
			NAME varchar(255) NULL)

	DECLARE 
			@id varchar(6),
			@name varchar(50),
			@address1 varchar(50),
			@address2 varchar(50),
			@city varchar (35),
			@state varchar(10),
			@zip varchar(10),
			@phone varchar(20),
			@fax varchar(20),
			@email varchar(60),
			@loc_footer varchar(254),
			@logo_location varchar(1),
			@prt_header smallint,
			@prt_name smallint,
			@prt_addr1 smallint,
			@prt_addr2 smallint,
			@prt_city smallint,
			@prt_state smallint,
			@prt_zip smallint,
			@prt_phone smallint,
			@prt_fax smallint,
			@prt_email smallint,
			@prt_footer smallint,
			@prt_name_ftr smallint,
			@prt_addr1_ftr smallint,
			@prt_addr2_ftr smallint,
			@prt_city_ftr smallint,
			@prt_state_ftr smallint,
			@prt_zip_ftr smallint,
			@prt_phone_ftr smallint,
			@prt_fax_ftr smallint,
			@prt_email_ftr smallint,
			@logo_path varchar(255),
			@logo_path_land varchar(255),
			@loc_hdr varchar(255),
			@loc_ftr varchar(255),
			@logo_location_2 varchar(1),
			@logo_path_2 varchar(255),
			@logo_path_land_2 varchar(255)

	DECLARE curLocation CURSOR LOCAL FAST_FORWARD
	FOR
	SELECT
		l.ID,
		l.[NAME],
		l.ADDRESS1,
		l.ADDRESS2,
		l.CITY,
		l.STATE,
		l.ZIP,
		--l.PHONE,
		--l.FAX,
		CASE
			WHEN SUBSTRING(l.PHONE,5,1) <> ')' THEN l.PHONE
			ELSE LEFT(l.PHONE,5) + ' ' + SUBSTRING(l.PHONE,6,20)
		END AS PHONE,	
		CASE
			WHEN SUBSTRING(l.FAX,5,1) <> ')' THEN l.FAX
			ELSE LEFT(l.FAX,5) + ' ' + SUBSTRING(l.FAX,6,20)
		END AS FAX,
		l.EMAIL,
		l.LOC_FOOTER,
		l.LOGO_LOCATION,
		IsNull(l.PRT_HEADER,0),
		l.PRT_NAME,
		l.PRT_ADDR1,
		l.PRT_ADDR2,
		l.PRT_CITY,
		l.PRT_STATE,
		l.PRT_ZIP,
		l.PRT_PHONE,
		l.PRT_FAX,
		l.PRT_EMAIL,
		IsNull(l.PRT_FOOTER,0),
		l.PRT_NAME_FTR,
		l.PRT_ADDR1_FTR,
		l.PRT_ADDR2_FTR,
		l.PRT_CITY_FTR,
		l.PRT_STATE_FTR,
		l.PRT_ZIP_FTR,
		l.PRT_PHONE_FTR,
		l.PRT_FAX_FTR,
		l.PRT_EMAIL_FTR,
		l.LOGO_PATH,
		l.LOGO_PATH_LAND,
		l.LOGO_LOCATION_2,
		l.LOGO_PATH_2,
		l.LOGO_PATH_LAND_2		
	FROM dbo.LOCATIONS l

	OPEN curLocation
	FETCH NEXT FROM curLocation
	INTO @id, @name, @address1,	@address2, @city, @state, @zip, @phone, @fax, @email, 
			@loc_footer, @logo_location,
			@prt_header, @prt_name, @prt_addr1,	@prt_addr2,	@prt_city, @prt_state, @prt_zip,
			@prt_phone,	@prt_fax, @prt_email,
			@prt_footer, @prt_name_ftr,	@prt_addr1_ftr,	@prt_addr2_ftr,	@prt_city_ftr,
			@prt_state_ftr,	@prt_zip_ftr, @prt_phone_ftr, @prt_fax_ftr,	@prt_email_ftr,
			@logo_path,	@logo_path_land, @logo_location_2, @logo_path_2, @logo_path_land_2

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @loc_hdr = ''
		IF (@prt_name = 1 AND @name IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + @name + ' ' + CHAR(149) + ' '
		IF (@prt_addr1 = 1 AND @address1 IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + @address1 + ' ' + CHAR(149) + ' '
		IF (@prt_addr2 = 1 AND @address2 IS NOT NULL)
			SET @loc_hdr = @loc_hdr + @address2 + ' ' + CHAR(149) + ' '	
		IF (@prt_city = 1 AND @city IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + @city + ', ' --+ CHAR(149) + ' '
		IF (@prt_state = 1 AND @state IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + @state + ' ' --+ CHAR(149) + ' '
		IF (@prt_zip = 1 AND @zip IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + @zip + ' ' + CHAR(149) + ' '
		IF (@prt_phone = 1 AND @phone IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + '' + @phone + ' ' + CHAR(149) + ' '			--#06
		IF (@prt_fax = 1 AND @fax IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + '' + @fax + ' Fax ' + CHAR(149) + ' '			--#06
		IF (@prt_email = 1 AND @email IS NOT NULL) 
			SET @loc_hdr = @loc_hdr + @email + '' + CHAR(149) + ' '					--#06
		IF LEN(@loc_hdr) >= 2
			SET @loc_hdr = LEFT(@loc_hdr, LEN(@loc_hdr)-1)							--#07
	
		SET @loc_ftr = ''
		IF (@prt_name_ftr = 1 AND @name IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + @name + ' ' + CHAR(149) + ' '
		IF (@prt_addr1_ftr = 1 AND @address1 IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + @address1 + ' ' + CHAR(149) + ' '
		IF (@prt_addr2_ftr = 1 AND @address2 IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + @address2 + ' ' + CHAR(149) + ' '
		IF (@prt_city_ftr = 1 AND @city IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + @city + ', ' -- CHAR(149) + ' '
		IF (@prt_state_ftr = 1 AND @state IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + @state + ' ' --+ CHAR(149) + ' '
		IF (@prt_zip_ftr = 1 AND @zip IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + @zip + ' ' + CHAR(149) + ' '
		IF (@prt_phone_ftr = 1 AND @phone IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + '' + @phone + ' ' + CHAR(149) + ' '			--#06
		IF (@prt_fax_ftr = 1 AND @fax IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + '' + @fax + ' Fax ' + CHAR(149) + ' '			--#06
		IF (@prt_email_ftr = 1 AND @email IS NOT NULL) 
			SET @loc_ftr = @loc_ftr + @email + '' + CHAR(149) + ' '					--#06
		IF LEN(@loc_ftr) >= 2
			SET @loc_ftr = LEFT(@loc_ftr,LEN(@loc_ftr)-1)							--#07
	
		INSERT INTO #locations
		SELECT
		@id,
		@prt_header,
		@loc_hdr,
		@prt_footer,
		@loc_ftr,
		@logo_location,
		@logo_path,
		@logo_path_land,
		@logo_location_2,
		@logo_path_2,
		@logo_path_land_2,
		@name
	
	FETCH NEXT FROM curLocation
	INTO @id, @name, @address1,	@address2, @city, @state, @zip, @phone, @fax, @email, 
			@loc_footer, @logo_location,
			@prt_header, @prt_name, @prt_addr1,	@prt_addr2,	@prt_city, @prt_state, @prt_zip,
			@prt_phone,	@prt_fax, @prt_email,
			@prt_footer, @prt_name_ftr,	@prt_addr1_ftr,	@prt_addr2_ftr,	@prt_city_ftr,
			@prt_state_ftr,	@prt_zip_ftr, @prt_phone_ftr, @prt_fax_ftr,	@prt_email_ftr,
			@logo_path,	@logo_path_land, @logo_location_2, @logo_path_2, @logo_path_land_2	
	END	
	CLOSE curLocation
	DEALLOCATE curLocation

	SELECT * FROM #locations
