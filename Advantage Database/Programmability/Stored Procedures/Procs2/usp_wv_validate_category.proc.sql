





















CREATE PROCEDURE [dbo].[usp_wv_validate_category]
@FuncCat VarChar(10)
AS
		

	If Exists(
	SELECT CATEGORY
	FROM TIME_CATEGORY 
	WHERE CATEGORY = @FuncCat AND (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)

	)
	Select 1
	Else
	Select 0
















