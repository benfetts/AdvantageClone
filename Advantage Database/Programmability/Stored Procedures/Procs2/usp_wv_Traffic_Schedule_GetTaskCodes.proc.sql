
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_GetTaskCodes] AS

    SELECT     
        TRF_CODE AS code, TRF_DESC AS description,TRF_CODE +'|'+ TRF_DESC AS codedescription
    FROM         
        TRAFFIC_FNC WITH(NOLOCK)
    WHERE     
       ((TRF_INACTIVE = 0) OR (TRF_INACTIVE IS NULL))
    ORDER BY 
        TRF_CODE

