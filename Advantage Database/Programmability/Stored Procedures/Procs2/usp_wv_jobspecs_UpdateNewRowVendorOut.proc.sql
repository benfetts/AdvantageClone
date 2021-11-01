









CREATE PROCEDURE [dbo].[usp_wv_jobspecs_UpdateNewRowVendorOut]
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
	 
	UPDATE [JOB_OUTDOOR_VENDOR]
	SET			   
			   [VN_CODE] = @VN_CODE,
			   [JOB_OUT_COPY_AREA] = @JOB_OUT_COPY_AREA,
			   [JOB_OUT_LOCATION] = @JOB_OUT_LOCATION,
			   [JOB_OUT_OVR_SIZE] = @JOB_OUT_OVR_SIZE,
			   [AD_SIZE] = @AD_SIZE
		 
		WHERE
			   [JOB_NUMBER] = @JOB_NUMBER AND
			   [JOB_COMPONENT_NBR] = @JOB_COMPONENT AND
			   [SPEC_ID] = @SPEC_ID

		SET @Err2 = @@Error

		
		RETURN @Err2
	END


















