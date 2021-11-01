






















CREATE PROCEDURE [dbo].[usp_wv_get_ExpenseDetail] 

@InvoiceNBR varchar(25)

AS

select 
AP_COMMENT as APComment,
CC_AMT as  CCAMT,
CC_FLAG as CCFlag,
CL_CODE as ClientCode,
CREATE_USER_ID as CreateUserID,
DIV_CODE as DivCode,
FNC_CODE as   FNCCode,
LINE_NBR as InvoiceLineNBR,
INV_NBR as InvoiceNBR,  
AMOUNT as ItemAMT,
ITEM_DATE as  ItemDate,
ITEM_DESC as ItemDesc,
JOB_COMP_NBR as JobCompNBR,
JOB_NBR as JobNBR,
MOD_DATE as ModifyDate,
MOD_USER_ID as ModifyUserID,
PRD_CODE as PrdCode,
QTY as QTY,
RATE as Rate
from EXPENSE_DETAIL
where INV_NBR = @InvoiceNBR




















