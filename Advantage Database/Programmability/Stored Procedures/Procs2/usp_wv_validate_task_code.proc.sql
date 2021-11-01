





















CREATE PROCEDURE [dbo].[usp_wv_validate_task_code] 
@TaskCode VarChar(10)
AS
Set NoCount On
 
If Exists(
SELECT     
        TRF_CODE AS code, TRF_DESC AS description,TRF_CODE +'|'+ TRF_DESC AS codedescription
    FROM         
        TRAFFIC_FNC WITH(NOLOCK)
    WHERE     
       ((TRF_INACTIVE = 0) OR (TRF_INACTIVE IS NULL))
        AND TRF_CODE = @TaskCode
)
	 select 1
Else
	select  0






















