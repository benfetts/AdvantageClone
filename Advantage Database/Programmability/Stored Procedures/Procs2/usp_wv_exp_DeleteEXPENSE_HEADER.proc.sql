





















CREATE PROCEDURE [dbo].[usp_wv_exp_DeleteEXPENSE_HEADER]
	@INV_NBR int
AS

DECLARE @error_code integer

SET NOCOUNT ON

Begin Transaction

Delete EXPENSE_DOCS WHERE INV_NBR = @INV_NBR

IF @error_code > 0 GOTO RollitBack

Delete FROM EXPENSE_DETAIL
Where INV_NBR = @INV_NBR

IF @error_code > 0 GOTO RollitBack

DELETE FROM [dbo].[EXPENSE_HEADER]
WHERE
	[INV_NBR] = @INV_NBR

IF @error_code > 0 GOTO RollitBack

Commit Transaction
Select 1
Return

RollitBack:
Rollback Transaction
Select 0





















