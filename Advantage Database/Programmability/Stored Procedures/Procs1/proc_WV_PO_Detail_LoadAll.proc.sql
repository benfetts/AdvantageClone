


CREATE PROCEDURE proc_WV_PO_Detail_LoadAll(@filter integer, @ref_id integer, @str1 varchar(25), @str2 varchar(25)) AS

-- exec proc_WV_PO_Detail_LoadAll 1, 88, null, null

if @filter =1 -- all entries for referenced po_number
begin
select 
 pd.PO_NUMBER + LINE_NUMBER as REF_ID,
 pd.LINE_NUMBER, isnull(pd.LINE_DESC,f.FNC_DESCRIPTION) as LINE_DESC, pd.DET_DESC, pd.DET_INSTRUCT,
 pd.JOB_NUMBER, pd.JOB_COMPONENT_NBR, pd.FNC_CODE,
 f.FNC_DESCRIPTION,
 pd.PO_RATE,
 pd.PO_QTY, 
 pd.PO_EXT_AMOUNT,
 pd.PO_COMM_PCT,
 pd.EXT_MARKUP_AMT,
 LINE_TOTAL = isnull(pd.PO_EXT_AMOUNT,0) + isnull(pd.EXT_MARKUP_AMT,0),
 isnull(pd.PO_COMPLETE,0) as PO_COMPLETE,
 j.CL_CODE, j.DIV_CODE, j.PRD_CODE,
 ATTACHED_TO_AP = (case when (select count(prod.AP_ID) FROM AP_PRODUCTION as prod WHERE
  prod.PO_NUMBER=pd.PO_NUMBER and prod.PO_LINE_NUMBER=pd.LINE_NUMBER
  and prod.DELETE_FLAG is null)>0 then 1 
  when (select count(glprod.AP_ID) FROM AP_GL_DIST as glprod WHERE
  glprod.PO_NUMBER=pd.PO_NUMBER and glprod.PO_LINE_NUMBER=pd.LINE_NUMBER
  and glprod.DELETE_FLAG is null) > 0 then 1
  else 0 end),
 USE_CPM = case when f.FNC_CPM_FLAG=1 then 1 else 0 end,
 CL_NAME = isnull((select CL_NAME from CLIENT as cl where cl.CL_CODE=j.CL_CODE and j.CL_CODE is not null),''),
 JOBANDCOMP = case when pd.JOB_NUMBER is not null then Right('00000000' + convert(varchar(6),pd.JOB_NUMBER),6) +
 '-' +  case when pd.JOB_COMPONENT_NBR < 10 then '0' else '' end  + cast(pd.JOB_COMPONENT_NBR as varchar(3)) else '' end,
 CAN_DELETE_FLG =  (case when (select count(prod.AP_ID) FROM AP_PRODUCTION as prod WHERE
  prod.PO_NUMBER=pd.PO_NUMBER and prod.PO_LINE_NUMBER=pd.LINE_NUMBER
  and prod.DELETE_FLAG is null)>0 or pd.PO_COMPLETE = 1then 0 else 1 end), ISNULL(pd.GLACODE,'') as GLACODE, ISNULL(j.JOB_DESC,'') AS JOB_DESC
 from PURCHASE_ORDER as ph
 join PURCHASE_ORDER_DET as pd on pd.PO_NUMBER = ph.PO_NUMBER
 left join [FUNCTIONS] as f on f.FNC_CODE=pd.FNC_CODE
 left  join JOB_LOG as j on j.JOB_NUMBER = pd.JOB_NUMBER 
 left join JOB_COMPONENT as jc on jc.JOB_COMPONENT_NBR = pd.JOB_COMPONENT_NBR 
      and jc.JOB_NUMBER = pd.JOB_NUMBER
  where pd.PO_NUMBER = @ref_id 
 order by pd.LINE_NUMBER
end








