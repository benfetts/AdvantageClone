




















CREATE PROCEDURE [dbo].[usp_wv_validate_udf2_jc] 
@UDV_CODE VarChar(10)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT UDV_CODE
FROM JOB_CMP_UDV2
WHERE INACTIVE_FLAG = 0
OR INACTIVE_FLAG IS NULL
AND UDV_CODE= @UDV_CODE 
)
	 select 1
Else
	select  0





















