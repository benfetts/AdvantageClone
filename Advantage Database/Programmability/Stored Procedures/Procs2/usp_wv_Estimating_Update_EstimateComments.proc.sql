if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Update_EstimateComments]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Update_EstimateComments]
GO

CREATE PROCEDURE [dbo].[usp_wv_Estimating_Update_EstimateComments]
(
	@EST_NBR INT,
	@EST_COMPONENT_NBR INT,
	@EST_COMP_COMMENT TEXT,
	@EST_LOG_COMMENT TEXT
)
AS
BEGIN
	SET NOCOUNT OFF
	    
			UPDATE [ESTIMATE_COMPONENT] WITH(ROWLOCK)
	            SET
		            [EST_COMP_COMMENT] = @EST_COMP_COMMENT--,
		            --[EST_COMP_COMMENT_HTML] = @EST_COMP_COMMENT
	            WHERE
		            [ESTIMATE_NUMBER] = @EST_NBR AND 
		            [EST_COMPONENT_NBR] = @EST_COMPONENT_NBR

			UPDATE [ESTIMATE_LOG] WITH(ROWLOCK)
	            SET
		            [EST_LOG_COMMENT] = @EST_LOG_COMMENT--,
		            --[EST_LOG_COMMENT_HTML] = @EST_LOG_COMMENT
	           WHERE
		            [ESTIMATE_NUMBER] = @EST_NBR

	
END





