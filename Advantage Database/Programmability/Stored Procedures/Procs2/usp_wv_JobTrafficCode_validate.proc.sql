

























CREATE PROCEDURE [dbo].[usp_wv_JobTrafficCode_validate] 
@TrafficCode VarChar(10)
AS

Set NoCount On
 
If Exists(SELECT TRF_CODE
FROM TRAFFIC
WHERE (TRF_CODE = @TrafficCode) 
AND (INACTIVE_FLAG <> 0 or INACTIVE_FLAG IS NULL))
	select 1
Else
	select  0

























