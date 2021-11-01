


CREATE PROCEDURE proc_WV_PO_Detail_Info(@po_num integer) AS

if @po_num <> ''
begin
 Select isnull(pd.JOB_NUMBER, '') AS JOB_NUMBER, isnull(pd.JOB_COMPONENT_NBR, '') AS JOB_COMPONENT_NBR,
		 isnull(pd.FNC_CODE, '') AS FNC_CODE, LINE_NUMBER
 from PURCHASE_ORDER_DET as pd
 where pd.PO_NUMBER = @po_num
end 

