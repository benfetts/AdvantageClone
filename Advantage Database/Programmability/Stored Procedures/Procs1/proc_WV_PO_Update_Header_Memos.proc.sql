


CREATE PROCEDURE [dbo].[proc_WV_PO_Update_Header_Memos](@update_column varchar(25), @po_number integer,
  @text text) AS

-- update PO memo text for specified column.

if @update_column = 'po_main_instruct' 
begin
  UPDATE PURCHASE_ORDER set PO_MAIN_INSTRUCT = @text WHERE PO_NUMBER=@po_number
end
else if @update_column='del_instruct' 
begin
  UPDATE PURCHASE_ORDER set DEL_INSTRUCT = @text WHERE PO_NUMBER=@po_number
end
else if @update_column='po_footer'
begin
  UPDATE PURCHASE_ORDER set PO_FOOTER = @text WHERE PO_NUMBER=@po_number
end

return @@error





