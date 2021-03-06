
CREATE PROCEDURE [dbo].[usp_wv_Estimating_AddNew_GetFunctionData] 
@FNC_CODE VARCHAR(6)
AS

    SELECT     
	    FNC_CODE, 
	    FNC_DESCRIPTION, 
	    FNC_BILLING_RATE,
		FNC_TYPE,
		ISNULL(FNC_CPM_FLAG,0) AS FNC_CPM_FLAG, 
		TAX_COMM,
		TAX_COMM_ONLY,
		FNC_NONBILL_FLAG,
		FNC_TAX_FLAG,
		ISNULL(FNC_COMM_FLAG,0) AS FNC_COMM_FLAG
    FROM         
	    FUNCTIONS WITH(NOLOCK)
    WHERE     
	    (FNC_CODE = @FNC_CODE)
	    AND
	    ((FNC_INACTIVE = 0) OR
                      (FNC_INACTIVE IS NULL))
	    
