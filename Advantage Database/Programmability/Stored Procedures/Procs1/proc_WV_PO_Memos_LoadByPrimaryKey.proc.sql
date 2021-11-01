



CREATE PROCEDURE [dbo].[proc_WV_PO_Memos_LoadByPrimaryKey] (@column varchar(25), @po_number integer) AS

if @column = 'po_main_instruct' 
begin
    select isnull( PO_MAIN_INSTRUCT,'') as PO_MAIN_INSTRUCT  from PURCHASE_ORDER where PO_NUMBER=@po_number
end
else if @column='del_instruct' 
begin
  select  isnull(DEL_INSTRUCT,'') as DEL_INSTRUCT  from PURCHASE_ORDER WHERE PO_NUMBER=@po_number
end
else if @column='po_footer'
begin
  select  isnull(PO_FOOTER,'') as PO_FOOTER  from PURCHASE_ORDER WHERE PO_NUMBER=@po_number
end

return @@error




