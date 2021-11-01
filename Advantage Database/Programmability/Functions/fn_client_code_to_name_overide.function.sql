
CREATE FUNCTION [dbo].[fn_client_code_to_name_overide] 
(
	@client varchar(6)
)
RETURNS tinyint
AS
BEGIN
	DECLARE @client_name_overide tinyint, @agy_name_overide tinyint

	SET @agy_name_overide = (
		SELECT ISNULL(ag.NAME_OVERIDE, 0)			--set to agency default name overide, or 0 (no overide) just in case
		FROM dbo.PROD_INV_DEF ag 
		WHERE ag.CLIENT_OR_DEF = 1)

	SELECT
		@client_name_overide = COALESCE(@agy_name_overide, @agy_name_overide)
	FROM dbo.CLIENT cl
	LEFT JOIN dbo.PROD_INV_DEF pid
		ON cl.CL_CODE = pid.CL_CODE
	WHERE cl.CL_CODE = @client 

	RETURN @client_name_overide

END
