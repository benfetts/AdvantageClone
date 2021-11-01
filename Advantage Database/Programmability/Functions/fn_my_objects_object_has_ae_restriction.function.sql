--DROP FUNCTION [dbo].[fn_my_objects_object_has_ae_restriction]
CREATE FUNCTION [dbo].[fn_my_objects_object_has_ae_restriction] (@OBJECT_ID AS INT)
RETURNS BIT
AS
BEGIN

	DECLARE @HAS_RESTRICTION BIT

	SET @HAS_RESTRICTION = 0;
		
	SELECT @HAS_RESTRICTION = ACCOUNT_EXECUTIVE FROM [dbo].[fn_my_objects_get_static_restrictions] (@OBJECT_ID);
			
	RETURN @HAS_RESTRICTION

END