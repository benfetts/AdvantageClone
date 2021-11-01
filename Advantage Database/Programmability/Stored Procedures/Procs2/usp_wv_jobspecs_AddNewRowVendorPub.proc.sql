









CREATE PROCEDURE [dbo].[usp_wv_jobspecs_AddNewRowVendorPub]
	@JOB_NUMBER int,
	@JOB_COMPONENT smallint,
	@SPEC_ID smallint, 
	@VN_CODE varchar(6), 
	@JOB_PUB_BLEED_SIZE varchar(40),
	@JOB_PUB_CLOSE_DATE smalldatetime,
	@JOB_PUB_COLOR varchar(20),
	@JOB_PUB_EXT_DATE smalldatetime,
    @JOB_PUB_LIVE_AREA varchar(40),
    @JOB_PUB_RUN_DATE smalldatetime,
    @JOB_PUB_SCREEN varchar(20),
    @JOB_PUB_TRIM_SIZE varchar(40),
    @JOB_PUB_DENSITY varchar(25),
    @JOB_PUB_FILM varchar(25),
    @JOB_PUB_SHIP_COMM text,
    @JOB_PUB_SPCL_INST text,
    @STATUS_CODE varchar(20),
	@REGION_CODE varchar(20),
	@AD_SIZE varchar(6)
AS


	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err2 int
	 
	INSERT INTO [JOB_PUB_VENDOR]
			   ([JOB_NUMBER]
			   ,[JOB_COMPONENT_NBR]
			   ,[SPEC_ID]
			   ,[VN_CODE]
			   ,[JOB_PUB_BLEED_SIZE]
			   ,[JOB_PUB_CLOSE_DATE]
			   ,[JOB_PUB_COLOR]
			   ,[JOB_PUB_EXT_DATE]
			   ,[JOB_PUB_LIVE_AREA]
			   ,[JOB_PUB_RUN_DATE]
			   ,[JOB_PUB_SCREEN]
			   ,[JOB_PUB_TRIM_SIZE]
			   ,[JOB_PUB_DENSITY]
			   ,[JOB_PUB_FILM]
			   ,[JOB_PUB_SHIP_COMM]
			   ,[JOB_PUB_SPCL_INST]
			   ,[STATUS_CODE]
			   ,[REGION_CODE]
			   ,[AD_SIZE])
		 VALUES
			   (@JOB_NUMBER,
				@JOB_COMPONENT,
				@SPEC_ID, 
				@VN_CODE, 
				@JOB_PUB_BLEED_SIZE,
				@JOB_PUB_CLOSE_DATE,
				@JOB_PUB_COLOR,
				@JOB_PUB_EXT_DATE,
				@JOB_PUB_LIVE_AREA,
				@JOB_PUB_RUN_DATE,
				@JOB_PUB_SCREEN,
				@JOB_PUB_TRIM_SIZE,
				@JOB_PUB_DENSITY,
				@JOB_PUB_FILM,
				@JOB_PUB_SHIP_COMM,
				@JOB_PUB_SPCL_INST,
				@STATUS_CODE,
				@REGION_CODE,
				@AD_SIZE
				)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END


















