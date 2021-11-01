if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_AddCampaignApproval]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_AddCampaignApproval]
GO



CREATE PROCEDURE [dbo].[usp_wv_Estimating_AddCampaignApproval]
	@CMP_IDENTIFIER int,
	@ESTIMATE_NUMBER int, 
	@EST_COMPONENT_NBR int, 
	@EST_QUOTE_NBR int,
	@EST_REVISION_NBR int,
	@EST_APPR_BY varchar(40),
	@EST_APPR_DATE smalldatetime,
	@CREATE_USER varchar(100),
	@CREATE_DATE smalldatetime,
	@APPR_NOTES text,
	@APPR_TYPE varchar(2)
AS


	BEGIN

		SET NOCOUNT OFF
		DECLARE @Err2 int
	 
	INSERT INTO [EST_CAMP_APPROVAL]
			   ([CMP_IDENTIFIER]
			   ,[ESTIMATE_NUMBER]
			   ,[EST_COMPONENT_NBR]
			   ,[EST_QUOTE_NBR]
			   ,[EST_REVISION_NBR]
			   ,[EST_APPR_BY]
			   ,[EST_APPR_DATE]
			   ,[CREATE_USER]
			   ,[CREATE_DATE]
			   ,[APPR_NOTES]
			   ,[APPR_TYPE])
		 VALUES
			   (@CMP_IDENTIFIER,
				@ESTIMATE_NUMBER, 
				@EST_COMPONENT_NBR, 
				@EST_QUOTE_NBR,
				@EST_REVISION_NBR,
				@EST_APPR_BY,
				@EST_APPR_DATE,
				@CREATE_USER,
				@CREATE_DATE,
				@APPR_NOTES,
				@APPR_TYPE
				)

		SET @Err2 = @@Error

		
		RETURN @Err2
	END



















