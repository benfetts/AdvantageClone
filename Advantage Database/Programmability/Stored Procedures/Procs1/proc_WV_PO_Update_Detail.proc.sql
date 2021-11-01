

CREATE PROCEDURE [dbo].[proc_WV_PO_Update_Detail](@ref_id integer, @po_number integer, @line_number integer,
   @line_desc varchar(40), @po_qty integer,
  @po_rate decimal(9,3), @po_tax_pct decimal, @job_number integer,
   @job_component_nbr integer, @fnc_code char(6), @po_comm_pct decimal(9,3),
   @ext_markup_amt decimal(15,2), @ext_amount decimal(14,2), @gla_code varchar(30), @po_ext_amount decimal(14,2) OUTPUT) AS

declare @ext_amt as decimal(14,2)
declare @adj_qty as decimal


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
if @fnc_code = '' 
  begin
     select @fnc_code = null
   end
 if @ext_amount=-1
   begin
     select @ext_amount=null
   end

/*
if @po_qty <=0
  begin
    raiserror('Quantity must be greater than zero on a purchase order line.',16,1)
    return
  end
*/
/*
if @po_qty is not null 
begin
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

update PURCHASE_ORDER_DET 
  set LINE_DESC=@line_desc, 
        PO_QTY=@po_qty,
        PO_RATE=@po_rate,
        PO_EXT_AMOUNT = @ext_amt,
        PO_TAX_PCT = @po_tax_pct,
        JOB_NUMBER=@job_number,
        JOB_COMPONENT_NBR = @job_component_nbr,
        FNC_CODE = @fnc_code,
        PO_COMM_PCT= @po_comm_pct,
        EXT_MARKUP_AMT= cast(@ext_markup_amt as decimal(9,3)),
        GLACODE = @gla_code
   where PO_NUMBER=@po_number and LINE_NUMBER = @line_number

  select @po_ext_amount= isnull(@ext_amt,0)

return @@error

