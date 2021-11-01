


CREATE PROCEDURE [dbo].[proc_WV_PO_Void_Undo](@po_number integer) AS

-- Restore Voided Purchase Order by updating header void fields.

-- exec proc_WV_PO_Void_Undo 18
update PURCHASE_ORDER set 
   VOID_DATE=null, VOIDED_BY=null, VOID_FLAG=0
    where PO_NUMBER=@po_number

 return @@rowcount



