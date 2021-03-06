
CREATE PROCEDURE [dbo].[usp_wv_dd_GetCategories] AS

	SELECT CATEGORY AS [Code],
		   CATEGORY + ' - ' + ISNULL(DESCRIPTION, CATEGORY) AS [Description],
		   ISNULL(DESCRIPTION, CATEGORY) AS [DescriptionOnly]
	FROM   TIME_CATEGORY WITH(NOLOCK)
	WHERE  INACTIVE_FLAG IS NULL
		   OR  INACTIVE_FLAG = 0;


