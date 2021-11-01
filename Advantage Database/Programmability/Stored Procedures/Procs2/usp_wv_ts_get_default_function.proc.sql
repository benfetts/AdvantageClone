






















CREATE PROCEDURE [dbo].[usp_wv_ts_get_default_function] 
@EmpCode VarChar(6),
@Function as Varchar(100) OUTPUT
AS
SELECT     @Function = DEF_FNC_CODE
FROM         EMPLOYEE WITH (NOLOCK)
WHERE     (EMP_CODE = @EmpCode)






















