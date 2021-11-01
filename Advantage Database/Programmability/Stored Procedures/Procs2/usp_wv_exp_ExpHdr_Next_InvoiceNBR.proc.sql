

























CREATE PROCEDURE [dbo].[usp_wv_exp_ExpHdr_Next_InvoiceNBR]

@EmpCode VarChar(6)

AS

declare @INV_NBR as varchar(25)
declare @month as varchar(2)
declare @day as varchar(2)
declare @year as varchar(4)

set @month = datepart(m,GETDATE())
set @day = datepart(d,GETDATE())
set @year = datepart(yyyy,GETDATE())

set @INV_NBR = @EmpCode + @month + @day + @year

Select @INV_NBR + '_' + convert(varchar(2), count(*) + 1) as InvoiceNBR from EXPENSE_HEADER where INV_NBR like @INV_NBR + '%'

























