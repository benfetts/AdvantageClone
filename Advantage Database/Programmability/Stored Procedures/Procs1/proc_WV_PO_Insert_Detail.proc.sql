
CREATE PROCEDURE [dbo].[proc_WV_PO_Insert_Detail](@ref_id integer, @po_number integer,
   @line_desc varchar(40), @po_qty integer,
  @po_rate decimal(9,3), @po_tax_pct decimal, @job_number integer,
   @job_component_nbr integer, @fnc_code char(6), @po_comm_pct decimal(9,3),
   @ext_markup_amt decimal(15,2), @ext_amount decimal(14,2), @gla_code varchar(30), @new_line_num integer OUTPUT) AS

declare @ext_amt as decimal(14,2)
declare @line_number as integer
declare @adj_qty as decimal

/*
if not exists(select FNC_CODE from [FUNCTIONS] where FNC_CODE=@fnc_code)
begin
  raiserror('Function code is not valid.',16,1)
  return
end
*/



select @line_number = max(LINE_NUMBER)+1 FROM PURCHASE_ORDER_DET where PO_NUMBER=@po_number
if @line_number is null
 begin
   select @line_number=1
  end

if @po_qty=-1
 begin
   select @po_qty=null
  end
if @po_rate=-1
 begin
   select @po_rate=null
  end
if @po_tax_pct=-1
  begin
   select @po_tax_pct=null
  end
if @po_comm_pct=-1
 begin
   select @po_comm_pct=null
  end
if @ext_markup_amt=-1
  begin
    select @ext_markup_amt=null
  end
if @job_number=-1
  begin
   select @job_number=null
  end
if @job_component_nbr =-1
 begin
   select @job_component_nbr=null
  end
if @ext_amount=-1
  begin
   select @ext_amount=null
  end

if @fnc_code = '' 
  begin
   select @fnc_code = null
  end

/*
if @po_qty <=0 and @po_qty is not null
  begin
    raiserror('Quantity must be greater than zero on a purchase order line.',16,1)
    return
  end
*/

/*
if @po_qty is not null 
begin --adjust quantity (CPM) and calculate extended line total.
if exists(select FNC_CODE from [FUNCTIONS] where FNC_CODE=@fnc_code and FNC_CPM_FLAG=1)
 begin
   select @adj_qty= @po_qty / 1000
  end
 else
 begin  
   select @adj_qty=@po_qty
 end
  
   select @ext_amt = @adj_qty * @po_rate

end
else
begin
 select @ext_amt=@ext_amount
end
*/

 select @ext_amt=@ext_amount

insert into PURCHASE_ORDER_DET(PO_NUMBER,LINE_NUMBER,
 LINE_DESC, PO_QTY, PO_RATE, PO_EXT_AMOUNT, PO_TAX_PCT,
 JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE,
 PO_COMM_PCT, EXT_MARKUP_AMT, GLACODE)
  values
  (@po_number, @line_number, @line_desc, @po_qty, @po_rate, @ext_amt,
   @po_tax_pct, @job_number, @job_component_nbr,
   @fnc_code, @po_comm_pct, @ext_markup_amt, @gla_code)

  select @new_line_num = @line_number

return @line_number


