--DROP FUNCTION [dbo].[fn_my_objects_object_has_static_restriction]
CREATE FUNCTION [dbo].[fn_my_objects_object_has_static_restriction] (@OBJECT_ID AS INT, @STATIC_DEFINITION_ID AS INT)
RETURNS BIT
AS
BEGIN

DECLARE @HAS_RESTRICTION BIT

SET @HAS_RESTRICTION = 0;
	
	IF EXISTS (

		SELECT * 
		FROM 
			[dbo].[fn_my_objects_get_object_definitions](@OBJECT_ID, 1) AS A
		WHERE 
			A.IS_STATIC = 1
			AND A.DEFINITION_ID = @STATIC_DEFINITION_ID
			
	)
	BEGIN

		SET @HAS_RESTRICTION = 1
		
	END
		

		
RETURN @HAS_RESTRICTION

END