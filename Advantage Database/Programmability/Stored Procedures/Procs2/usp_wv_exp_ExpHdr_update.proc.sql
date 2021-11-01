























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpHdr_update]

--@ApprovedDate DateTime,
@ApprovedFlag bit,
@ApprovedUserID VarChar(6),
@DateFrom DateTime,
@DateTo DateTime,
@Description VarChar(30),
@Dtl_Desc Varchar(2000),
@EmpCode VarChar(6),
@InvoiceAmt Decimal(14,2),
@InvoiceDate DateTime,
@InvoiceNBR VarChar(25),
@SubmittedFlag Bit,
@VNCode VarChar(6),
@Status VarChar(25)
 

AS

--Set NOCOUNT ON


Update EXPENSE_HEADER
Set EMP_CODE = @EmpCode, 
VN_CODE = @VNCode, 
INV_DATE = @InvoiceDate, 
EXP_DESC = @Description, 
DTL_DESC = @Dtl_Desc, 
DATE_FROM = @DateFrom, 
DATE_TO = @DateTo, 
INV_AMOUNT = @InvoiceAmt, 
SUBMITTED_FLAG = @SubmittedFlag, 
APPROVED_FLAG = @ApprovedFlag, 
APPROVED_BY = @ApprovedUserID, 
--APPROVED_DATE = @ApprovedDate, 
STATUS = @Status
where INV_NBR = @InvoiceNBR























