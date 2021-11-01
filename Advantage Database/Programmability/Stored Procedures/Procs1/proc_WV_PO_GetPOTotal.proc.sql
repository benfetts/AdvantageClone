

CREATE PROCEDURE [dbo].[proc_WV_PO_GetPOTotal](@po_number integer, @po_total decimal OUTPUT) AS

     select @po_total = sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET where PO_NUMBER=@po_number

       if @po_total is null
        begin
         select @po_total=0
        end     


