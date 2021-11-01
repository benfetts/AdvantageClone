

CREATE PROCEDURE [dbo].[proc_WV_PO_Delete_Detail]
(@po_number integer, @line_number integer) AS


if exists(select PO_NUMBER from PURCHASE_ORDER where PO_NUMBER=@po_number
  and PO_COMPLETE=1)
   begin
     raiserror('Cannot remove a line on a completed Purchase Order',16,1)
     return
   end

-- remove purchase order detail line.
  delete  from dbo.PURCHASE_ORDER_DET where PO_NUMBER=@po_number
  and LINE_NUMBER=@line_number

return @@error




