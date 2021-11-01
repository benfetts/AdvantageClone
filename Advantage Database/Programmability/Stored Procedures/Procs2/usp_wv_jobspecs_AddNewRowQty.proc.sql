









CREATE PROCEDURE [dbo].[usp_wv_jobspecs_AddNewRowQty]
	@JOB_NUMBER_QTY int,
	@JOB_COMPONENT_NBR_QTY smallint,
	@SPEC_VER_QTY int, 
	@SPEC_REV_QTY int, 
	@SEQ_NBR_QTY int,
	@JOB_QTY_QTY int
AS


	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err2 int
	 
	INSERT INTO [JOB_SPEC_QTY]
			   ([JOB_NUMBER]
			   ,[JOB_COMPONENT_NBR]
			   ,[SPEC_VER]
			   ,[SPEC_REV]
			   ,[SEQ_NBR]
			   ,[JOB_QTY])
		 VALUES
			   (@JOB_NUMBER_QTY,
				@JOB_COMPONENT_NBR_QTY,
				@SPEC_VER_QTY,
				@SPEC_REV_QTY,
				@SEQ_NBR_QTY,
				@JOB_QTY_QTY
				)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END



















