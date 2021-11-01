


CREATE PROCEDURE [dbo].[proc_WV_PO_Detail_LoadByPrimaryKey](@funct_id integer, @ref_id integer, @ref_id2 integer) AS

-- Load PO detail line using PO_NUMBER + LINE_NUMBER on detail as primary key.

--exec proc_WV_PO_Detail_LoadByPrimaryKey 1,18,4

declare @PO_COMPLETE as smallint
declare @PO_VOIDED as smallint
declare @VN_CODE as char(6)

  select @PO_COMPLETE = isnull(PO_COMPLETE,0), @VN_CODE=VN_CODE,
      @PO_VOIDED = isnull(VOID_FLAG,0) from PURCHASE_ORDER where PO_NUMBER=@ref_id

if @funct_id=1
begin
select pd.PO_NUMBER, pd.PO_NUMBER + LINE_NUMBER as REF_ID,
 pd.LINE_NUMBER, isnull(pd.LINE_DESC,f.FNC_DESCRIPTION) as LINE_DESC, isnull(pd.DET_DESC,'') as DET_DESC, isnull(pd.DET_INSTRUCT,'') as DET_INSTRUCT,
 isnull(pd.JOB_NUMBER,-1) as JOB_NUMBER,
 isnull( pd.JOB_COMPONENT_NBR,0) as JOB_COMPONENT_NBR, 
 isnull(pd.FNC_CODE,'') as FNC_CODE,
 isnull(f.FNC_DESCRIPTION,'') as FNC_DESCRIPTION,
 isnull(pd.PO_RATE,-1) as PO_RATE, isnull(pd.PO_QTY,-1) as PO_QTY,
 isnull(pd.PO_EXT_AMOUNT,-1) as PO_EXT_AMOUNT,
 isnull(pd.PO_COMM_PCT,-1) as PO_COMM_PCT,
 isnull( pd.EXT_MARKUP_AMT,0) as EXT_MARKUP_AMT,
 LINE_TOTAL = isnull(pd.PO_EXT_AMOUNT,0) + isnull(pd.EXT_MARKUP_AMT,0),
 isnull(pd.PO_COMPLETE,0) as PO_COMPLETE,
 isnull(j.CL_CODE,'') as CL_CODE,
 isnull(j.DIV_CODE,'') as DIV_CODE,
 isnull( j.PRD_CODE,'') AS PRD_CODE,
 ATTACHED_TO_AP = (select count(prod.AP_ID) FROM AP_PRODUCTION as prod WHERE
  prod.PO_NUMBER=pd.PO_NUMBER and prod.PO_LINE_NUMBER=pd.LINE_NUMBER
  and prod.DELETE_FLAG is null),
 isnull(pd.PO_TAX_PCT,-1) as PO_TAX_PCT, isnull(f.FNC_CPM_FLAG,0) as USE_CPM,
 @PO_COMPLETE as PO_COMPLETE, @VN_CODE as VN_CODE,
 isnull(jc.JT_CODE,'') as JT_CODE, @PO_VOIDED as PO_VOIDED, ISNULL(pd.GLACODE,'') as GLACODE, ISNULL(ga.GLADESC,'') as GLADESC
 from PURCHASE_ORDER as ph
 join PURCHASE_ORDER_DET as pd on pd.PO_NUMBER = ph.PO_NUMBER
 left join [FUNCTIONS] as f on f.FNC_CODE=pd.FNC_CODE
 left  join JOB_LOG as j on j.JOB_NUMBER = pd.JOB_NUMBER 
 left join JOB_COMPONENT as jc on jc.JOB_COMPONENT_NBR = pd.JOB_COMPONENT_NBR 
      and jc.JOB_NUMBER = pd.JOB_NUMBER
 left join GLACCOUNT as ga on ga.GLACODE = pd.GLACODE
  where pd.PO_NUMBER=@ref_id and pd.LINE_NUMBER = @ref_id2 --and  f.FNC_CODE = 'V'
end





