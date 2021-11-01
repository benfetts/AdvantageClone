























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpDtl_Insert]

@APComment VarChar(100),
@CCAMT Decimal(14,2),
@CCFlag Bit,
@ClientCode  VarChar(6),
@CreateUserID VarChar(6),
@DivCode VarChar(6),
@FNCCode VarChar(6),
@InvoiceLineNBR VarChar(15),
@InvoiceNBR varchar(25),
@ItemAMT Decimal(14,2),
@ItemDate DateTime,
@ItemDesc VarChar(200),
@JobCompNBR SmallInt,
@JobNBR Int,
@PrdCode VarChar(6),
@QTY Int,
@Rate Decimal(6,2)
 
AS

Set NOCOUNT ON

INSERT INTO EXPENSE_DETAIL
 (AP_COMMENT,
CC_AMT,
CC_FLAG,
CL_CODE,
CREATE_USER_ID,
DIV_CODE,
FNC_CODE,
LINE_NBR,
INV_NBR,
AMOUNT,
ITEM_DATE,
ITEM_DESC,
JOB_COMP_NBR,
JOB_NBR,
PRD_CODE,
QTY,
RATE)
Values(@APComment,
@CCAMT,
@CCFlag,
@ClientCode,
@CreateUserID,
@DivCode,
@FNCCode,
@InvoiceLineNBR,
@InvoiceNBR,
@ItemAMT,
@ItemDate,
@ItemDesc,
@JobCompNBR,
@JobNBR,
@PrdCode,
@QTY,
@Rate)























