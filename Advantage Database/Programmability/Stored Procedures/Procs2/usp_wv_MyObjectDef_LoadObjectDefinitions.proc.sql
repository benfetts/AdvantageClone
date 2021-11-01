SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[usp_wv_MyObjectDef_LoadObjectDefinitions]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[usp_wv_MyObjectDef_LoadObjectDefinitions]
GO
CREATE PROCEDURE [dbo].[usp_wv_MyObjectDef_LoadObjectDefinitions] /*WITH ENCRYPTION*/
@OBJECT_ID INT,
@SHOW_ONLY_CHECKED_DEFINITIONS BIT
AS
/*=========== QUERY ===========*/

	SELECT
		[ObjectDefinitionID] = OBJECT_DEFINITION_ID,
        [ObjectID] = [OBJECT_ID],
        [ObjectDescription] = OBJECT_DESCRIPTION,
        [ObjectType] = OBJECT_TYPE,
        [DefinitionID] = DEFINITION_ID,
        [DefinitionDescription] = DEFINITION_DESCRIPTION,
        [IsStatic] = IS_STATIC,
        [Checked] = CHECKED
	FROM [dbo].[fn_my_objects_get_object_definitions] (@OBJECT_ID, @SHOW_ONLY_CHECKED_DEFINITIONS);
	
/*=========== QUERY ===========*/

GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO