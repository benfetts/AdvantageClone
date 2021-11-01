
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetPresetsList] AS

    SELECT     
        TRF_PRESET_CODE AS code, 
        TRF_PRESET_DESC AS description, 
        TRF_PRESET_CODE + ISNULL(' - ' + TRF_PRESET_DESC, '') AS CodeAndDescription
    FROM         
        TRF_PRESET_HDR
    WHERE     
        ((INACTIVE_FLAG IS NULL) OR (INACTIVE_FLAG = 0))
        
        
