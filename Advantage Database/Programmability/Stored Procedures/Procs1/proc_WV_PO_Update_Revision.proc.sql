

CREATE PROCEDURE [dbo].[proc_WV_PO_Update_Revision](@funct integer, @po_number integer, @new_revision_num integer OUTPUT) AS

if @funct=1
 begin 
  select @new_revision_num = PO_REVISION + 1 from PURCHASE_ORDER where PO_NUMBER=@po_number
  UPDATE PURCHASE_ORDER set PO_REVISION =@new_revision_num  where PO_NUMBER=@po_number
 end

  return @@error




