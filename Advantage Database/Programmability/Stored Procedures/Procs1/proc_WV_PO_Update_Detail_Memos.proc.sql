

CREATE PROCEDURE [dbo].[proc_WV_PO_Update_Detail_Memos](@update_column varchar(15), @ref_id integer, @ref_id2 integer, @text TEXT) AS

if @update_column='det_desc' --update PO detail description text
 begin
  update PURCHASE_ORDER_DET set DET_DESC = @text where PO_NUMBER = @ref_id and LINE_NUMBER=@ref_id2
  end
else if @update_column='det_instruct' --update PO detail instruction text
 begin
  update PURCHASE_ORDER_DET set DET_INSTRUCT = @text where PO_NUMBER = @ref_id and LINE_NUMBER=@ref_id2
  end

