

CREATE PROCEDURE [dbo].[proc_WV_PO_Delete_Approval]
(@po_number integer) AS


if exists(select PO_NUMBER from PO_APPROVAL where PO_NUMBER=@po_number)
  --and PO_APPROVAL_FLAG = False)
   begin
	 delete  from dbo.PO_APPROVAL where PO_NUMBER=@po_number     
   end


return @@error




