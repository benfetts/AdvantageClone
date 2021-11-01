
--Parameters
--@invoice_type: p=production, m=media
--@client = CL_CODE

CREATE FUNCTION [dbo].[advfn_std_inv_ftr_comment] (@invoice_type varchar(1), @client varchar(6))
	
RETURNS varchar(4000)
AS
BEGIN
	DECLARE @comment varchar(4000)
	DECLARE @std_comment_dflt varchar(4000)			--from STD_COMMENT
	DECLARE @std_comment_client varchar(4000)		--from STD_COMMENT
	DECLARE @client_comment varchar(4000)			--from CLIENT (CL_FOOTER or CL_MFOOTER)

	--Standard Default footer comment
	SELECT
		@std_comment_dflt = sc1.STD_COMMENT
	FROM dbo.STD_COMMENT sc1
	WHERE sc1.APP_CODE = 'Invoices'
		AND sc1.COMMENT_TYPE = 'Standard Footer'
		AND sc1.CLIENT_CODE IS NULL 
		
	--Standard Client footer comment	
	SELECT
		@std_comment_client = sc2.STD_COMMENT
	FROM dbo.STD_COMMENT sc2
	WHERE sc2.APP_CODE = 'Invoices'
		AND sc2.COMMENT_TYPE = 'Standard Footer'
		AND sc2.CLIENT_CODE = @client
					
	--Client footer comment	
	SELECT
		@client_comment = 
			CASE @invoice_type
				WHEN 'p' THEN c.CL_FOOTER
				WHEN 'm' THEN c.CL_MFOOTER
			END	
	FROM dbo.CLIENT AS c
	WHERE c.CL_CODE = @client
		
	SELECT @comment = COALESCE(@std_comment_client, @std_comment_dflt, @client_comment)			  

	RETURN @comment

END
