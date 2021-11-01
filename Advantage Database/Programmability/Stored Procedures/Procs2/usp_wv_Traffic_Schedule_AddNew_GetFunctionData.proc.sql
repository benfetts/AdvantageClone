
CREATE PROCEDURE [dbo].[usp_wv_Traffic_Schedule_AddNew_GetFunctionData] 
@TRF_CODE VARCHAR(10)
AS

    SELECT     
	    TRF_CODE, 
	    TRF_DESC, 
	    ISNULL(TRF_ORDER,0) AS TRF_ORDER, 
	    ISNULL(TRF_DAYS,0) AS TRF_DAYS, 
	    ISNULL(TRF_HRS,0) AS TRF_HRS, 
	    TRF_INACTIVE, 
	    FNC_CODE, 
	    ISNULL(MILESTONE,0) AS MILESTONE, 
	    DEF_STATUS,
	    DEF_TRF_ROLE
	    --FNC_EST?
	    --
    FROM         
	    TRAFFIC_FNC WITH(NOLOCK)
    WHERE     
	    (TRF_CODE = @TRF_CODE)
	    AND
	    ((TRF_INACTIVE = 0) OR
                      (TRF_INACTIVE IS NULL))
	    
