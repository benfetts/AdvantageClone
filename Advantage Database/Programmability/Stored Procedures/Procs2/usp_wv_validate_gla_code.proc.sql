





















CREATE PROCEDURE [dbo].[usp_wv_validate_gla_code] 
@GlaCode VarChar(30)
AS
Set NoCount On
 
If Exists(
SELECT DISTINCT GLACODE
FROM GLACCOUNT
WHERE GLACODE = @GlaCode and GLPO = 1 and GLAACTIVE = 'A'
)
	 select 1
Else
	select  0





















