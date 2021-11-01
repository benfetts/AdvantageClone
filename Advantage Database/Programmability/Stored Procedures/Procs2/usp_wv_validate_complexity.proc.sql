





















CREATE PROCEDURE [dbo].[usp_wv_validate_complexity] 
@ComplexityCode VarChar(8)
AS
Set NoCount On
 
If Exists(
SELECT COMPLEX_CODE
FROM COMPLEXITY
WHERE ACTIVE = 1
AND COMPLEX_CODE = @ComplexityCode
)
	 select 1
Else
	select  0





















