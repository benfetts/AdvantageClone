CREATE PROCEDURE [dbo].[usp_wv_exp_CopyEXPENSE_HEADERandDETAIL]
@INV_NBR varchar(25),
@EMP_CODE varchar(6),
@INV_DATE datetime,
@EXP_DESC varchar(30),
@DTL_DESC text,
@CREATE_USER_ID varchar(100) = null
AS

Declare @VN_CODE as VarChar(10)

SET NOCOUNT ON

DECLARE @ID int

Select @VN_CODE = VN_CODE_EXP
from EMPLOYEE 
	Inner Join VENDOR
	On VENDOR.VN_CODE = EMPLOYEE.VN_CODE_EXP
where EMP_CODE = @EMP_CODE

INSERT INTO [dbo].[EXPENSE_HEADER] (
	[EMP_CODE],
	[VN_CODE],
	[INV_DATE],
	[EXP_DESC],
	[DTL_DESC], 
	[CREATE_USER_ID],
	[CREATE_DATE]
) VALUES (
	@EMP_CODE,
	@VN_CODE,
	@INV_DATE,
	@EXP_DESC,
	@DTL_DESC,
	@CREATE_USER_ID,
	GETDATE()
)

Set @ID =  SCOPE_IDENTITY()

INSERT INTO [dbo].[EXPENSE_DETAIL]
           ([INV_NBR]
           ,[LINE_NBR]
           ,[ITEM_DATE]
           ,[ITEM_DESC]
           ,[CC_FLAG]
           ,[CL_CODE]
           ,[DIV_CODE]
           ,[PRD_CODE]
           ,[JOB_NBR]
           ,[JOB_COMP_NBR]
           ,[FNC_CODE]
           ,[QTY]
           ,[RATE]
           ,[CC_AMT]
           ,[AMOUNT]
           ,[AP_COMMENT]
           ,[CREATE_USER_ID]
           ,[MOD_USER_ID]
           ,[MOD_DATE]
		   ,[PAYMENT_TYPE])
SELECT @ID
      ,[LINE_NBR]
      ,[ITEM_DATE]
      ,[ITEM_DESC]
      ,[CC_FLAG]
      ,[CL_CODE]
      ,[DIV_CODE]
      ,[PRD_CODE]
      ,[JOB_NBR]
      ,[JOB_COMP_NBR]
      ,[FNC_CODE]
      ,[QTY]
      ,[RATE]
      ,[CC_AMT]
      ,[AMOUNT]
      ,[AP_COMMENT]
      ,@CREATE_USER_ID
      ,NULL
      ,NULL
      ,[PAYMENT_TYPE]
  FROM [dbo].[EXPENSE_DETAIL]
  WHERE [INV_NBR] = @INV_NBR AND [ITEM_DESC] <> 'System Generated'

  SELECT  @ID;