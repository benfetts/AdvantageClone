



CREATE PROCEDURE [dbo].[usp_wv_dd_expense_inv] 
@emp_code as varchar(6)

AS
--If @emp_code = ''  --emp_code is mandatory here
--	SELECT DISTINCT INV_NBR as code, cast(INV_NBR as varchar(15)) + ' - ' + EXP_DESC as description
--	FROM EXPENSE_HEADER
--	ORDER BY INV_NBR DESC
--Else
	SELECT DISTINCT INV_NBR as code, cast(INV_NBR as varchar(15)) + ' - ' + EXP_DESC + ' - ' + CONVERT(CHAR(10), INV_DATE, 101) as description
	FROM EXPENSE_HEADER
	WHERE EMP_CODE = @emp_code
	ORDER BY INV_NBR DESC




