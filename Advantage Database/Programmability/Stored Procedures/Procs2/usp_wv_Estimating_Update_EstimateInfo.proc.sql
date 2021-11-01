﻿if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Update_EstimateInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Update_EstimateInfo]
GO

CREATE PROCEDURE [dbo].[usp_wv_Estimating_Update_EstimateInfo]
(
	@EST_NBR INT,
	@EST_COMPONENT_NBR INT,
	@EST_COMP_COMMENT TEXT,
	@EST_LOG_COMMENT TEXT,
	@CMP_IDENTIFIER INT,
	@SC_CODE VARCHAR(6),
	@MARKUP_PCT DECIMAL(7,3),
	@CDP_CONTACT_ID INT,
	@EST_LOG_DESC VARCHAR(60),
	@EST_COMP_DESC VARCHAR(60),
	@EST_FTR_COMMENT TEXT,
	@EST_LOG_COMMENT_HTML TEXT,
	@EST_FTR_COMMENT_HTML TEXT,
	@EST_COMP_COMMENT_HTML TEXT
)
AS
BEGIN
	DECLARE @CMP_CODE varchar(6)
	if @CMP_IDENTIFIER IS NOT NULL
	Begin
		SELECT @CMP_CODE = CMP_CODE FROM CAMPAIGN WHERE CMP_IDENTIFIER = @CMP_IDENTIFIER
	End
	Else
	Begin
		SET @CMP_CODE = NULL
	End

	SET NOCOUNT OFF

			UPDATE [ESTIMATE_LOG] WITH(ROWLOCK)
	            SET
					[EST_LOG_DESC] = @EST_LOG_DESC,
		            [EST_LOG_COMMENT] = @EST_LOG_COMMENT,
					[CMP_CODE] = @CMP_CODE,
					[CMP_IDENTIFIER] = @CMP_IDENTIFIER,
					[SC_CODE] = @SC_CODE,
					[EST_MARKUP_PCT] = @MARKUP_PCT,
					[EST_FTR_COMMENT] = @EST_FTR_COMMENT,
		            [EST_LOG_COMMENT_HTML] = @EST_LOG_COMMENT_HTML,
		            [EST_FTR_COMMENT_HTML] = @EST_FTR_COMMENT_HTML
	           WHERE
		            [ESTIMATE_NUMBER] = @EST_NBR
	    
			UPDATE [ESTIMATE_COMPONENT] WITH(ROWLOCK)
	            SET
					[EST_COMP_DESC] = @EST_COMP_DESC,
		            [EST_COMP_COMMENT] = @EST_COMP_COMMENT,
					[CDP_CONTACT_ID] = @CDP_CONTACT_ID,
		            [EST_COMP_COMMENT_HTML] = @EST_COMP_COMMENT_HTML
	            WHERE
		            [ESTIMATE_NUMBER] = @EST_NBR AND 
		            [EST_COMPONENT_NBR] = @EST_COMPONENT_NBR

			

	
END





