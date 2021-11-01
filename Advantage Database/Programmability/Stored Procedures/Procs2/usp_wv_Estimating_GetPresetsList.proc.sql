
CREATE PROCEDURE [dbo].[usp_wv_Estimating_GetPresetsList] AS

    SELECT     
        PRESET_CODE AS code, 
        PRESET_DESC AS description, 
        PRESET_CODE + ISNULL(' - ' + PRESET_DESC, '') AS CodeAndDescription
    FROM         
        PRESET_FUNC_HDR
    WHERE     
        ((INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG = 0))
        
        
