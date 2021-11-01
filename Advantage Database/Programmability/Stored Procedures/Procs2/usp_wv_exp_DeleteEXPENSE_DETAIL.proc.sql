





















CREATE PROCEDURE [dbo].[usp_wv_exp_DeleteEXPENSE_DETAIL]
	@EXPDETAILID int
AS

DELETE FROM [dbo].[EXPENSE_DETAIL]
WHERE
	[EXPDETAILID] = @EXPDETAILID





















