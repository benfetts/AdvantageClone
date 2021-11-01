





















CREATE PROCEDURE [dbo].[usp_wv_validate_blackplate] 
@Code VarChar(6)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT BLACKPLT_VER_CODE, BLACKPLT_VER_DESC 
FROM BLACKPLT_VERSION
WHERE (INACTIVE_FLAG = 0 OR INACTIVE_FLAG IS NULL)
AND BLACKPLT_VER_CODE = @Code
)
	select 1
Else
	select  0






















