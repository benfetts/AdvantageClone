





CREATE PROCEDURE [dbo].[proc_WV_PO_GetEmpPOLimit_Remaining_Amt](@emp_code char(6), @ponumber integer,@limit decimal OUTPUT,  @used_amount decimal OUTPUT, @remaining_amount decimal OUTPUT)
 AS

-- return PO limit and amount remaining for specified purchase order....
-- replace null limit with -1, indicating that no purchase order items are allowed for specified empcode...

/*
declare @limit decimal
declare @used decimal
declare @remain decimal

exec proc_WV_PO_GetEmpPOLimit_Remaining_Amt  'ali',18, @limit OUTPUT, @used OUTPUT, @remain OUTPUT*/

select @limit = isnull(PO_LIMIT,-1) from EMPLOYEE where EMP_CODE= @emp_code
if @@rowcount =0
  begin
      raiserror('Employee Code is not valid.',16,1)
    return
   end

select @used_amount = sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET
  where PO_NUMBER=@ponumber

if @used_amount is null
begin
 select @used_amount=0
end



select @remaining_amount = @limit - @used_amount 





