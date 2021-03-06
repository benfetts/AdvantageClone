CREATE PROCEDURE [dbo].[advsp_gl_budget_data_update_all]

AS
BEGIN

	SET NOCOUNT ON;
		
	CREATE TABLE #GL_BUDGET(
		[ROW_ID] int IDENTITY(1,1),
		[GLBDHCODE] varchar(20) NOT NULL)

	DECLARE @ROW_COUNT AS int
	DECLARE @ROW_ID AS int
	DECLARE @GLBDHCODE AS varchar(20)
		
	INSERT INTO #GL_BUDGET([GLBDHCODE])
	SELECT 
		GLB.[GLBDHCODE]
	FROM
		(SELECT [GLBDHCODE] = GLBDGTAPPR1 FROM dbo.GLBUDGETAPPRV WHERE GLBDGTAPPR1 IS NOT NULL UNION ALL
		 SELECT [GLBDHCODE] = GLBDGTAPPR2 FROM dbo.GLBUDGETAPPRV WHERE GLBDGTAPPR2 IS NOT NULL UNION ALL
		 SELECT [GLBDHCODE] = GLBDGTAPPR3 FROM dbo.GLBUDGETAPPRV WHERE GLBDGTAPPR3 IS NOT NULL UNION ALL
		 SELECT [GLBDHCODE] = GLBDGTAPPR4 FROM dbo.GLBUDGETAPPRV WHERE GLBDGTAPPR4 IS NOT NULL) AS GLB

	SET @ROW_COUNT = @@ROWCOUNT
	SET @ROW_ID = 1

	WHILE @ROW_ID <= @ROW_COUNT BEGIN

		SELECT
			@GLBDHCODE = [GLBDHCODE]
		FROM
			#GL_BUDGET
		WHERE
			[ROW_ID] = @ROW_ID

		EXEC [dbo].[advsp_gl_budget_data_update] @GLBDHCODE

		SET @ROW_ID = @ROW_ID + 1
			
	END

	DROP TABLE #GL_BUDGET

END
GO
