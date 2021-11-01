









CREATE PROCEDURE [dbo].[usp_wv_jobspecs_CopyQty]
	@JOB_NUMBER_QTY int,
	@JOB_COMPONENT_NBR_QTY smallint,
	@SPEC_VER_QTY int, 
	@SPEC_REV_QTY int, 
	@SEQ_NBR_QTY int,
	@JOB_QTY_QTY int,
	@RevCopy bit,
	@NewRevision int,
	@VerCopy bit,
	@NewVersion int,
	@VerNew bit
AS

if @RevCopy = 1
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
				@NewRevision,
				@SEQ_NBR_QTY,
				@JOB_QTY_QTY
				)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END

if @VerCopy = 1
	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err int
	 
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
				@NewVersion,
				@NewRevision,
				@SEQ_NBR_QTY,
				@JOB_QTY_QTY
				)

		SET @Err = @@Error

		
		RETURN @Err
	END

if @VerNew = 1
	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err3 int
	 
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
				@NewVersion,
				@NewRevision,
				0,
				NULL
				)

		SET @Err3 = @@Error

		
		RETURN @Err3
	END

















