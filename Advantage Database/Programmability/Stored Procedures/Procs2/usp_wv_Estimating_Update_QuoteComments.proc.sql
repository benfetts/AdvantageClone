if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[usp_wv_Estimating_Update_QuoteComments]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[usp_wv_Estimating_Update_QuoteComments]
GO

CREATE PROCEDURE [dbo].[usp_wv_Estimating_Update_QuoteComments]
(
	@EST_NBR INT,
	@EST_COMPONENT_NBR INT,
	@EST_QUOTE_NBR INT,
	@EST_REV_NBR INT,
	@SEQ_NBR INT,
	@EST_FNC_COMMENT TEXT,
	@EST_REV_SUP_BY_NTE TEXT,
	@EST_FNC_COMMENT_HTML TEXT,
	@EST_REV_SUP_BY_HTML TEXT
)
AS
BEGIN
	SET NOCOUNT OFF
	    
			UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK)
	            SET
		            [EST_FNC_COMMENT] = @EST_FNC_COMMENT,
					[EST_REV_SUP_BY_NTE] = @EST_REV_SUP_BY_NTE,
					[EST_FNC_COMMENT_HTML] = @EST_FNC_COMMENT_HTML,
					[EST_REV_SUP_BY_HTML] = @EST_REV_SUP_BY_HTML
	            WHERE
		            [ESTIMATE_NUMBER] = @EST_NBR AND 
		            [EST_COMPONENT_NBR] = @EST_COMPONENT_NBR AND
					[EST_QUOTE_NBR] = @EST_QUOTE_NBR AND
					[EST_REV_NBR] = @EST_REV_NBR AND
					[SEQ_NBR] = @SEQ_NBR

	
END





