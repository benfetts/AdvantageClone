
CREATE PROCEDURE [dbo].[advsp_ar_client_footer_comment] 
AS
BEGIN
	SET NOCOUNT ON;

	--Standard default footer comment
	DECLARE @std_comment_dflt_size tinyint
	DECLARE @std_comment_dflt varchar(4000)
	SELECT
		@std_comment_dflt_size = sc.FONT_SIZE,
		@std_comment_dflt = sc.STD_COMMENT
	FROM dbo.STD_COMMENT sc
	WHERE sc.APP_CODE = 'Invoices'
		AND sc.COMMENT_TYPE = 'Standard Footer'
		AND sc.CLIENT_CODE IS NULL 
		
	--Standard client comments
	CREATE TABLE #std_client_comment (
		CL_CODE							varchar(6) COLLATE SQL_Latin1_General_CP1_CS_AS, 
		FONT_SIZE						smallint NULL, 
		CL_FOOTER						varchar(4000) COLLATE SQL_Latin1_General_CP1_CS_AS)
	INSERT INTO #std_client_comment
	SELECT
		sc.CLIENT_CODE,
		sc.FONT_SIZE,
		sc.STD_COMMENT
	FROM dbo.STD_COMMENT sc
	WHERE sc.APP_CODE = 'Invoices'
		AND sc.COMMENT_TYPE = 'Standard Footer'
		AND sc.CLIENT_CODE IS NOT NULL 	
	
	--Create a comments table
	SELECT 
		c.CL_CODE,
		COALESCE(cmt.FONT_SIZE, @std_comment_dflt_size) AS FONT_SIZE,		--JP 2/20/11
		COALESCE(cmt.CL_FOOTER, @std_comment_dflt, c.CL_FOOTER) AS CL_FOOTER,		--JP 2/20/11
		COALESCE(cmt.CL_FOOTER, @std_comment_dflt, c.CL_MFOOTER) AS CL_MFOOTER,		--JP 2/20/11
		CASE
			WHEN cmt.CL_FOOTER IS NOT NULL THEN 1
			WHEN @std_comment_dflt IS NOT NULL THEN 2
			ELSE 3
		END AS FOOTER_TYPE	
	FROM dbo.CLIENT AS c	 
	LEFT JOIN #std_client_comment AS cmt
		ON c.CL_CODE = cmt.CL_CODE

END
