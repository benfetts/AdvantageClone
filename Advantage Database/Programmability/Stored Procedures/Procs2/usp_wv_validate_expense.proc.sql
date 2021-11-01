

CREATE PROCEDURE [dbo].[usp_wv_validate_expense] 
@INV_NBR INTEGER,
@EMP_CODE VARCHAR(6)
AS

Set NoCount On

If @EMP_CODE = ''
	BEGIN
		If Exists(
		SELECT DISTINCT INV_NBR
		FROM EXPENSE_HEADER
		WHERE  INV_NBR = @INV_NBR 
		)
			select 1
		Else
			select  0
	END

Else
	BEGIN
		If Exists(
		SELECT DISTINCT INV_NBR
		FROM EXPENSE_HEADER
		WHERE  INV_NBR = @INV_NBR AND EMP_CODE = @EMP_CODE
		)
			 select 1
		Else
			select  0
	END



