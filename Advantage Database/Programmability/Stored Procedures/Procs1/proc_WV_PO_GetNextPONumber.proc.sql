


CREATE PROCEDURE [dbo].[proc_WV_PO_GetNextPONumber](@next_po_number integer OUTPUT) AS
declare @output_num integer

--declare @test integer
--exec  proc_WV_PO_GetNextPONumber @test OUTPUT
--print '...' +  cast(@test as varchar(10))


select @output_num=-1

begin tran

/*
Select @output_num= LAST_NBR + 1
From ASSIGN_NBR
Where COLUMNNAME = 'PO_NUMBER'

update ASSIGN_NBR set LAST_NBR=@output_num 
From ASSIGN_NBR
Where COLUMNNAME = 'PO_NUMBER'
*/

select @output_num = ISNULL(max(PO_NUMBER),0) + 1 from PURCHASE_ORDER

if @@error = 0
 begin
  commit tran
 end
else
begin
  rollback tran
end

  select @next_po_number=@output_num

return @@error

