CREATE PROCEDURE [dbo].[usp_wv_exp_CopyEXPENSEDETAIL]
@EXPDETAILID int,
@INV_NBR varchar(25),
@EMP_CODE varchar(6),
@CREATE_USER_ID varchar(100) = null
AS

Declare @LineNumber as Int


If Exists(
	Select LINE_NBR
	from EXPENSE_DETAIL
	Where INV_NBR = @INV_NBR)
Begin 
	Select @LineNumber = max(LINE_NBR)  + 1
	from EXPENSE_DETAIL
	Where INV_NBR = @INV_NBR
End 
Else
Begin 
	Set @LineNumber = 1
End

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
SELECT [INV_NBR]
      ,@LineNumber
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
WHERE
	[EXPDETAILID] = @EXPDETAILID

Select SCOPE_IDENTITY()