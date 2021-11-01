









CREATE PROCEDURE [dbo].[usp_wv_jobspecs_AddNewRowVendorOut]
	@JOB_NUMBER int,
	@JOB_COMPONENT smallint,
	@SPEC_ID smallint, 
	@VN_CODE varchar(6), 
	@JOB_OUT_COPY_AREA varchar(40),
	@JOB_OUT_LOCATION varchar(40),
	@JOB_OUT_OVR_SIZE varchar(40),
	@AD_SIZE varchar(6)
AS


	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err2 int
	 
	INSERT INTO [JOB_OUTDOOR_VENDOR]
			   ([JOB_NUMBER]
			   ,[JOB_COMPONENT_NBR]
			   ,[SPEC_ID]
			   ,[VN_CODE]
			   ,[JOB_OUT_COPY_AREA]
			   ,[JOB_OUT_LOCATION]
			   ,[JOB_OUT_OVR_SIZE]
			   ,[AD_SIZE])
		 VALUES
			   (@JOB_NUMBER,
				@JOB_COMPONENT,
				@SPEC_ID, 
				@VN_CODE, 
				@JOB_OUT_COPY_AREA,
				@JOB_OUT_LOCATION,
				@JOB_OUT_OVR_SIZE,
				@AD_SIZE
				)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END


















