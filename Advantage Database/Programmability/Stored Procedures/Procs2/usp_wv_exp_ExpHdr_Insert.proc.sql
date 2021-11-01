























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpHdr_Insert]

@DateFrom DateTime,
@DateTo DateTime,
@Description VarChar(30),
@Dtl_Desc Varchar(2000),
@EmpCode VarChar(6),
@InvoiceAmt Decimal(14,2),
@InvoiceDate DateTime,
@InvoiceNBR VarChar(25),
@VNCode VarChar(6),
@Status VarChar(25)
 

AS

--Set NOCOUNT ON


INSERT INTO EXPENSE_HEADER (INV_NBR, EMP_CODE, VN_CODE, INV_DATE, EXP_DESC, DTL_DESC, DATE_FROM, DATE_TO, INV_AMOUNT, STATUS)
Values(@InvoiceNBR, @EmpCode, @VNCode, @InvoiceDate, @Description, @Dtl_Desc, @DateFrom, @DateTo, @InvoiceAmt, @Status)























