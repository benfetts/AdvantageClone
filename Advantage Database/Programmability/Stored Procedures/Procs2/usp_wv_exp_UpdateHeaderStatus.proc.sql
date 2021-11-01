

CREATE PROCEDURE [dbo].[usp_wv_exp_UpdateHeaderStatus]
	@INV_NBR int,
	@Status int,
	@Submitted int,
	@Approved int
AS

UPDATE [dbo].[EXPENSE_HEADER] 
SET
	[STATUS] = @Status,
	SUBMITTED_FLAG = @Submitted,
	APPROVED_FLAG = @Approved

WHERE
	[INV_NBR] = @INV_NBR



















