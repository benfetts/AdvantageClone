

CREATE PROCEDURE [dbo].[proc_WV_PO_Update_Printed](@funct integer, @po_number integer, @printed integer) AS

if @funct=1
 begin 
  UPDATE PURCHASE_ORDER set PO_PRINTED = @printed  where PO_NUMBER=@po_number
 end

  return @@error




