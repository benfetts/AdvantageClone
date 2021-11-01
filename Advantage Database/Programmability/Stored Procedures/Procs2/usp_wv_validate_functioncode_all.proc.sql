

CREATE PROCEDURE [dbo].[usp_wv_validate_functioncode_all]
@FuncCode VARCHAR(10)
AS

	IF EXISTS(
	    SELECT FNC_CODE
	    FROM FUNCTIONS 
	    WHERE FNC_CODE = @FuncCode
	    AND ( FNC_INACTIVE IS NULL OR FNC_INACTIVE = 0 )
	)
		SELECT 1
	ELSE
		SELECT 0

