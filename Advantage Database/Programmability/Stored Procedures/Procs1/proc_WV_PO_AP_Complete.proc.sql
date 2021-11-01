


CREATE PROCEDURE [dbo].[proc_WV_PO_AP_Complete](@funct as integer, @ref_id as integer, @str as varchar(25), @sort varchar(25)) AS

--  exec proc_WV_PO_AP_Complete 1, 99, '', ''

if @funct=1 -- AP Detail Line with Job/Complete Status/AP Line Info
begin
select  JOBANDCOMP = 
   case when pd.JOB_NUMBER is not null  then Right('00000000' + convert(varchar(6),pd.JOB_NUMBER),6) +
 '-' +  case when pd.JOB_COMPONENT_NBR < 10 then '0' else '' end  + cast(pd.JOB_COMPONENT_NBR as varchar(3)) else '' end,
  Right('00000000' + convert(varchar(8),pd.PO_NUMBER),8) + '-' +Right('000' + convert(varchar(3),pd.LINE_NUMBER),3)  as PO_NUMBER,
  cast(isnull(ap.PO_COMPLETE,0) as bit) as PO_COMPLETE, pd.PO_NUMBER AS PO_NBR, pd.LINE_NUMBER,
  ap.AP_PROD_EXT_AMT,
  pd.PO_EXT_AMOUNT,
  OVER_FLG = case when ap.AP_PROD_EXT_AMT > pd.PO_EXT_AMOUNT then '+' 
   else case when ap.AP_PROD_EXT_AMT < pd.PO_EXT_AMOUNT then '-' else '' end end,
   case when (ap.AP_PROD_EXT_AMT-pd.PO_EXT_AMOUNT <> 0) then
     ap.AP_PROD_EXT_AMT-pd.PO_EXT_AMOUNT else 0 end as VARIANCE_AMOUNT,
   ap.AP_ID, pd.FNC_CODE, ap.POST_PERIOD,
   aph.AP_INV_DATE as INV_DATE, aph.AP_INV_VCHR,
   j.CL_CODE, j.DIV_CODE, j.PRD_CODE, pd.PO_QTY, ap.AP_PROD_QUANTITY,
  isnull(ap.AP_PROD_NOBILL_FLG, 0) as NONBILL
from PURCHASE_ORDER_DET as pd
 left  join AP_PRODUCTION as ap on ap.PO_NUMBER = pd.PO_NUMBER and ap.PO_LINE_NUMBER=pd.LINE_NUMBER
 left join AP_HEADER as aph on aph.AP_ID = ap.AP_ID 
 left join JOB_LOG as j on j.JOB_NUMBER = ap.JOB_NUMBER
  where pd.PO_NUMBER = @ref_id  and (ap.DELETE_FLAG=0 or ap.DELETE_FLAG is null)
 and (aph.MODIFY_FLAG is null or aph.MODIFY_FLAG=0) and pd.JOB_NUMBER IS NOT NULL

UNION

select  JOBANDCOMP  = 
   case when pd.JOB_NUMBER is not null  then Right('00000000' + convert(varchar(6),pd.JOB_NUMBER),6) +
 '-' +  case when pd.JOB_COMPONENT_NBR < 10 then '0' else '' end  + cast(pd.JOB_COMPONENT_NBR as varchar(3)) else '' end,
  Right('00000000' + convert(varchar(8),pd.PO_NUMBER),8) + '-' +Right('000' + convert(varchar(3),pd.LINE_NUMBER),3)  as PO_NUMBER,
  cast(isnull(pd.PO_COMPLETE,0) as bit) as PO_COMPLETE, pd.PO_NUMBER AS PO_NBR, pd.LINE_NUMBER,
  ap.AP_GL_AMT as AP_PROD_EXT_AMT,
  pd.PO_EXT_AMOUNT as PO_EXT_AMOUNT,
  OVER_FLG = case when ap.AP_GL_AMT > pd.PO_EXT_AMOUNT then '+' 
   else case when ap.AP_GL_AMT < pd.PO_EXT_AMOUNT then '-' else '' end end,
   case when (ap.AP_GL_AMT-pd.PO_EXT_AMOUNT <> 0) then
     ap.AP_GL_AMT-pd.PO_EXT_AMOUNT else 0 end as VARIANCE_AMOUNT,
   ap.AP_ID, pd.FNC_CODE, ap.POST_PERIOD,
   aph.AP_INV_DATE as INV_DATE, aph.AP_INV_VCHR,
   NULL as CL_CODE, NULL as DIV_CODE, NULL as PRD_CODE, pd.PO_QTY, NULL as AP_PROD_QUANTITY,
  0 as NONBILL
from PURCHASE_ORDER_DET as pd
 left  join AP_GL_DIST as ap on ap.PO_NUMBER = pd.PO_NUMBER and ap.PO_LINE_NUMBER=pd.LINE_NUMBER
 left join AP_HEADER as aph on aph.AP_ID = ap.AP_ID  
 left join JOB_LOG as j on j.JOB_NUMBER = pd.JOB_NUMBER
  where pd.PO_NUMBER = @ref_id  and (ap.DELETE_FLAG=0 or ap.DELETE_FLAG is null)
 and (aph.MODIFY_FLAG is null or aph.MODIFY_FLAG=0) and pd.JOB_NUMBER IS NULL
   
 order by pd.PO_NUMBER, pd.LINE_NUMBER 
end



