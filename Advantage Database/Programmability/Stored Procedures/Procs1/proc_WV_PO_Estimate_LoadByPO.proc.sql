

CREATE PROCEDURE [dbo].[proc_WV_PO_Estimate_LoadByPO](@funct integer, @ponumber integer, @str varchar(25))
AS

-- retrieve approved estimate job/component details for a specific PO

--exec proc_WV_PO_Estimate_LoadByPO 3,94,''

if @funct=1
begin
select apv.JOB_NUMBER, apv.JOB_COMPONENT_NBR,
f.FNC_TYPE, f.FNC_DESCRIPTION, apv.EST_QUOTE_NBR, isnull(rd.EST_REV_QUANTITY,0) as EST_REV_QUANTITY,
isnull(rd.EST_REV_RATE,0) as EST_REV_RATE,
isnull(rd.EST_REV_EXT_AMT,0) as EST_REV_EXT_AMT,
isnull(rd.EST_REV_COMM_PCT,0) as EST_REV_COMM_PCT,
isnull(vend.VN_NAME,'(any)') as VENDOR_NAME,
isnull(j.CL_CODE,'') as CL_CODE, isnull(j.DIV_CODE,'') as DIV_CODE, isnull(PRD_CODE,'') as PRD_CODE
 from ESTIMATE_APPROVAL as apv
join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
 where apv.JOB_NUMBER in
(select distinct JOB_NUMBER from PURCHASE_ORDER_DET where PO_NUMBER = @ponumber)
 and f.FNC_TYPE = 'V'
 order by apv.JOB_NUMBER, apv.JOB_COMPONENT_NBR
end

else if @funct=2
begin
select ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, f.FNC_CODE, f.FNC_DESCRIPTION,
 f.FNC_TYPE, ea.EST_QUOTE_NBR,
 isnull(rd.EST_REV_QUANTITY,0) as EST_REV_QUANTITY,
 isnull(rd.EST_REV_RATE,0) as EST_REV_RATE,
isnull(rd.EST_REV_EXT_AMT,0) as EST_REV_EXT_AMT,
isnull(rd.EST_REV_COMM_PCT,0) as EST_REV_COMM_PCT,
isnull(vend.VN_NAME,'(any)') as VENDOR_NAME,
isnull(j.CL_CODE,'') as CL_CODE, isnull(j.DIV_CODE,'') as DIV_CODE, isnull(PRD_CODE,'') as PRD_CODE
 from ESTIMATE_APPROVAL as ea
  join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = ea.ESTIMATE_NUMBER
  and rd.EST_QUOTE_NBR = ea.EST_QUOTE_NBR
  and rd.EST_REV_NBR = ea.EST_REVISION_NBR
  join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
 left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
join JOB_LOG as j on j.JOB_NUMBER=ea.JOB_NUMBER
  where f.FNC_TYPE = 'V'
   and not exists (select pd.JOB_NUMBER, pd.JOB_COMPONENT_NBR from PURCHASE_ORDER_DET as pd
   join PURCHASE_ORDER as p on p.PO_NUMBER=pd.PO_NUMBER
   where pd.JOB_NUMBER=ea.JOB_NUMBER and pd.JOB_COMPONENT_NBR= ea.JOB_COMPONENT_NBR
     and (p.VOID_FLAG= 0 or p.VOID_FLAG is null))
  order by ea.JOB_NUMBER, ea.JOB_COMPONENT_NBR, f.FNC_DESCRIPTION desc
end

else if @funct=3 -- detail with remaining amounts...
begin
  select
apv.ESTIMATE_NUMBER, rd.EST_COMPONENT_NBR, rd.EST_QUOTE_NBR, rd.EST_REV_NBR,
apv.JOB_NUMBER, apv.JOB_COMPONENT_NBR,
f.FNC_TYPE, f.FNC_DESCRIPTION, f.FNC_CODE, apv.EST_QUOTE_NBR, isnull(rd.EST_REV_QUANTITY,0) as EST_REV_QUANTITY,
isnull(rd.EST_REV_RATE,0) as EST_REV_RATE,
EST_REV_EXT_AMT = case when rd.EST_REV_EXT_AMT is null then 0 else
 rd.EST_REV_EXT_AMT end, 
isnull(rd.EST_REV_COMM_PCT,0) as EST_REV_COMM_PCT,
isnull(vend.VN_NAME,'(any)') as VENDOR_NAME,
isnull(vend.VN_CODE,'') as VN_CODE,
isnull(j.CL_CODE,'') as CL_CODE, isnull(j.DIV_CODE,'') as DIV_CODE, isnull(PRD_CODE,'') as PRD_CODE,
EXT_MARKUP_AMT = case when rd.EXT_MARKUP_AMT is null then 0 else
 rd.EXT_MARKUP_AMT end, 
LINE_TOTAL= case when rd.LINE_TOTAL is null then 0 else
 rd.LINE_TOTAL end, 
 PO_EXIST_AMT = isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
 where pd.JOB_NUMBER=apv.JOB_NUMBER
  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0),
BALANCE=
(select sum(EST_REV_EXT_AMT) from ESTIMATE_APPROVAL as apv2
  join ESTIMATE_REV_DET as rd2 on rd2.ESTIMATE_NUMBER = apv2.ESTIMATE_NUMBER
  and rd2.EST_COMPONENT_NBR=apv2.EST_COMPONENT_NBR
  and rd2.EST_QUOTE_NBR = apv2.EST_QUOTE_NBR
  and rd2.EST_REV_NBR = apv2.EST_REVISION_NBR
  where apv2.JOB_NUMBER = apv.JOB_NUMBER 
   and  apv2.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR
   and apv2.EST_REVISION_NBR = rd.EST_REV_NBR
   and  apv2.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
   and rd2.FNC_CODE= rd.FNC_CODE
) -
 (isnull((select sum(PO_EXT_AMOUNT) from PURCHASE_ORDER_DET as pd
 join PURCHASE_ORDER as ph on ph.PO_NUMBER = pd.PO_NUMBER
 where pd.JOB_NUMBER=apv.JOB_NUMBER
  and pd.JOB_COMPONENT_NBR=apv.JOB_COMPONENT_NBR and pd.FNC_CODE=rd.FNC_CODE
  and (ph.VOID_FLAG=0 or ph.VOID_FLAG is null)),0)),
  USE_CPM = case when f.FNC_CPM_FLAG = 1 then 1 else 0 end
 from ESTIMATE_APPROVAL as apv
join ESTIMATE_REV_DET as rd on rd.ESTIMATE_NUMBER = apv.ESTIMATE_NUMBER
 and apv.EST_COMPONENT_NBR = rd.EST_COMPONENT_NBR
 and apv.EST_REVISION_NBR = rd.EST_REV_NBR
 and apv.EST_QUOTE_NBR = rd.EST_QUOTE_NBR
join [FUNCTIONS] as f on f.FNC_CODE = rd.FNC_CODE
join JOB_LOG as j on j.JOB_NUMBER=apv.JOB_NUMBER
left join VENDOR as vend on vend.VN_CODE = rd.EST_REV_SUP_BY_CDE
 where apv.JOB_NUMBER in (select distinct JOB_NUMBER from PURCHASE_ORDER_DET where 
  PO_NUMBER = @ponumber) and  f.FNC_TYPE = 'V'
  order by apv.JOB_NUMBER, rd.EST_COMPONENT_NBR, rd.EST_QUOTE_NBR, rd.EST_REV_NBR
end






