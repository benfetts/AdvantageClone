









CREATE PROCEDURE [dbo].[usp_wv_Estimating_AddApproval]
	@JOB_NUMBER int,
	@JOB_COMPONENT_NBR smallint,
	@ESTIMATE_NUMBER int, 
	@EST_COMPONENT_NBR int, 
	@EST_QUOTE_NBR int,
	@EST_REVISION_NBR int,
	@EST_APPR_BY varchar(40),
	@EST_APPR_DATE smalldatetime,
	@EST_APPR_CL_PO_NBR varchar(20),
	@CREATE_USER varchar(100),
	@CREATE_DATE smalldatetime,
	@APPR_NOTES text
AS


	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err2 int
	 
	INSERT INTO [ESTIMATE_APPROVAL]
			   ([JOB_NUMBER]
			   ,[JOB_COMPONENT_NBR]
			   ,[ESTIMATE_NUMBER]
			   ,[EST_COMPONENT_NBR]
			   ,[EST_QUOTE_NBR]
			   ,[EST_REVISION_NBR]
			   ,[EST_APPR_BY]
			   ,[EST_APPR_DATE]
			   ,[EST_APPR_CL_PO_NBR]
			   ,[CREATE_USER]
			   ,[CREATE_DATE]
			   ,[APPR_NOTES])
		 VALUES
			   (@JOB_NUMBER,
				@JOB_COMPONENT_NBR,
				@ESTIMATE_NUMBER, 
				@EST_COMPONENT_NBR, 
				@EST_QUOTE_NBR,
				@EST_REVISION_NBR,
				@EST_APPR_BY,
				@EST_APPR_DATE,
				@EST_APPR_CL_PO_NBR,
				@CREATE_USER,
				@CREATE_DATE,
				@APPR_NOTES
				)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END



















