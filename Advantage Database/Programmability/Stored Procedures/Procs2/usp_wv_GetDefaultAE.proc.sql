







CREATE PROCEDURE [dbo].[usp_wv_GetDefaultAE]
@ClientCode varchar(6),
@DivisionCode varchar(6),
@ProductCode varchar(6)
AS

SELECT EMP_CODE
FROM ACCOUNT_EXECUTIVE
WHERE CL_CODE = @ClientCode and DIV_CODE = @DivisionCode and PRD_CODE = @ProductCode AND DEFAULT_AE = 1 




















