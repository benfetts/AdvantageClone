























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpHdr_Approved_Update] 

@EMP_CODE VarChar(6),
@INV_NBR VarChar(25)

AS

Update EXPENSE_HEADER set APPROVED_FLAG = 1, APPROVED_BY = @EMP_CODE, APPROVED_DATE = GETDATE()
where EMP_CODE = @EMP_CODE and INV_NBR = @INV_NBR























