









CREATE PROCEDURE [dbo].[usp_wv_jobspecs_ApproveVersion]
	@JOB_NUMBER int,
	@JOB_COMPONENT_NBR smallint,
	@APPR_SPEC_VER int, 
	@SPEC_APPR_BY varchar(40), 
	@SPEC_APPR_COMMENT text,
	@SPEC_APPR_USER_ID varchar(100),
	@SPEC_APPR_DATE smalldatetime,
	@CPID int
AS


	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err2 int
	 
	INSERT INTO [JOB_SPEC_APPR]
			   ([JOB_NUMBER]
			   ,[JOB_COMPONENT_NBR]
			   ,[APPR_SPEC_VER]
			   ,[SPEC_APPR_BY]
			   ,[SPEC_APPR_COMMENT]
			   ,[SPEC_APPR_USER_ID]
			   ,[SPEC_APPR_DATE]
			   ,[SPEC_APPR_USER_ID_CP])
		 VALUES
			   (@JOB_NUMBER,
				@JOB_COMPONENT_NBR,
				@APPR_SPEC_VER,
				@SPEC_APPR_BY,
				@SPEC_APPR_COMMENT,
				@SPEC_APPR_USER_ID,
				@SPEC_APPR_DATE,
				@CPID)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END



















