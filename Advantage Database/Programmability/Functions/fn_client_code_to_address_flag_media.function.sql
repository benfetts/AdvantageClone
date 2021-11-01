
CREATE FUNCTION [dbo].[fn_client_code_to_address_flag_media] 
(
	@client varchar(6)
)
RETURNS tinyint
AS
BEGIN
	DECLARE @address_flag tinyint, @agy_default_flag tinyint

	SET @agy_default_flag = (
		SELECT ISNULL(ag.ADDRESS_BLOCK, 3)		--set agency default address flag to 3 (product), just in case there is no agency record
		FROM dbo.MEDIA_INV_DEF ag 
		WHERE ag.CLIENT_OR_DEF = 1)

	SELECT
		@address_flag = COALESCE(pid.ADDRESS_BLOCK, @agy_default_flag)
	FROM dbo.CLIENT cl
	LEFT JOIN dbo.MEDIA_INV_DEF pid
	ON cl.CL_CODE = pid.CL_CODE
	WHERE cl.CL_CODE = @client   

	RETURN @address_flag

END
