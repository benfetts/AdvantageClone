
CREATE PROCEDURE dbo.proc_WV_PO_Transactions_LoadAll(@funct integer, @ref_id integer, @ref_id2 integer, @str varchar(25)) AS

--   exec proc_WV_PO_Transactions_LoadAll 1, 117, 0,''

if @funct =1 -- PO detail lines for specified PO followed by related AP transactions...
begin
select SRC='PO', SEQ=1, pd.PO_NUMBER, pd.LINE_NUMBER, pd.PO_QTY as SUMQTY,
pd.PO_QTY as QTY,
 pd.PO_EXT_AMOUNT as SUMAMOUNT,
JOBANDCOMP = 
   case when pd.JOB_NUMBER is not null  then Right('00000000' + convert(varchar(6),pd.JOB_NUMBER),6) +
 '-' +  case when pd.JOB_COMPONENT_NBR < 10 then '0' else '' end  + cast(pd.JOB_COMPONENT_NBR as varchar(3)) else '' end,
 'PO#/LINE ' +  Right('00000000' + convert(varchar(8),pd.PO_NUMBER),8) + '-' +Right('000' + convert(varchar(3),pd.LINE_NUMBER),3)  as REF_NUMBER,
 pd.PO_EXT_AMOUNT as AMOUNT,
   j.CL_CODE, j.DIV_CODE, j.PRD_CODE, cast(0 as bit) as PO_COMPLETE, null as INV_DATE, 0 as NONBILL,
   pd.FNC_CODE
 from PURCHASE_ORDER_DET as pd
 left join JOB_LOG as j on j.JOB_NUMBER = pd.JOB_NUMBER
 where pd.PO_NUMBER=@ref_id

 union all

select SRC='AP', SEQ=2, apd.PO_NUMBER, apd.PO_LINE_NUMBER, apd.AP_PROD_QUANTITY * -1, 
    apd.AP_PROD_QUANTITY ,
    apd.AP_PROD_EXT_AMT * -1,  JOBANDCOMP= 
 case when apd.JOB_NUMBER is not null  then Right('00000000' + convert(varchar(6),apd.JOB_NUMBER),6) +
 '-' +  case when apd.JOB_COMPONENT_NBR < 10 then '0' else '' end  + cast(apd.JOB_COMPONENT_NBR as varchar(3)) else '' end
   , 'INV# ' + aph.AP_INV_VCHR,
    apd.AP_PROD_EXT_AMT as AMOUNT,
   j.CL_CODE, j.DIV_CODE, j.PRD_CODE,   cast(isnull(apd.PO_COMPLETE,0) as bit) as PO_COMPLETE,
   aph.AP_INV_DATE as INV_DATE,   isnull(apd.AP_PROD_NOBILL_FLG, 0) as NONBILL,
   apd.FNC_CODE
    from AP_PRODUCTION as apd
     left join AP_HEADER as aph on aph.AP_ID = apd.AP_ID 
     left join JOB_LOG as j on j.JOB_NUMBER = apd.JOB_NUMBER
    where apd.PO_NUMBER=@ref_id   and (apd.DELETE_FLAG=0 or apd.DELETE_FLAG is null)
 and (aph.MODIFY_FLAG is null or aph.MODIFY_FLAG=0)

union all

select SRC='AP', SEQ=2, apg.PO_NUMBER, apg.PO_LINE_NUMBER, NULL AS AP_PROD_QUANTITY, 
    NULL AS AP_PROD_QUANTITY ,
    apg.AP_GL_AMT * -1,  JOBANDCOMP=NULL
   , 'INV# ' + aph.AP_INV_VCHR,
    apg.AP_GL_AMT as AMOUNT,
   '' as CL_CODE, '' as DIV_CODE, '' as PRD_CODE,   cast(isnull(pd.PO_COMPLETE,0) as bit) as PO_COMPLETE,
   aph.AP_INV_DATE as INV_DATE,   0 as NONBILL,
   pd.FNC_CODE
    from AP_GL_DIST as apg
     left join AP_HEADER as aph on aph.AP_ID = apg.AP_ID
     left join PURCHASE_ORDER_DET as pd on apg.PO_NUMBER = pd.PO_NUMBER and apg.PO_LINE_NUMBER=pd.LINE_NUMBER
     where apg.PO_NUMBER=@ref_id   and (apg.DELETE_FLAG=0 or apg.DELETE_FLAG is null)
 and (aph.MODIFY_FLAG is null or aph.MODIFY_FLAG=0)

order by PO_NUMBER, LINE_NUMBER, SEQ

end

