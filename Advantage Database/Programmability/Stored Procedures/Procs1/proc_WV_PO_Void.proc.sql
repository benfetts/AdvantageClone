


CREATE PROCEDURE [dbo].[proc_WV_PO_Void](@po_number integer, @sys_user_id varchar(100)) AS

-- Void Purchase Order by updating header void fields.

update PURCHASE_ORDER set 
   VOID_DATE=getdate(), VOIDED_BY=@sys_user_id, VOID_FLAG=1
    where PO_NUMBER=@po_number





