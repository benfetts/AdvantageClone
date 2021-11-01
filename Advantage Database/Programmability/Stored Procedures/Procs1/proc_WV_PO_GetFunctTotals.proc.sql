SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proc_WV_PO_GetFunctTotals]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[proc_WV_PO_GetFunctTotals]
GO



CREATE PROCEDURE proc_WV_PO_GetFunctTotals(@funct integer, @po_number integer, @ref_id integer, @str varchar(15), @str2 varchar(15)) AS

--exec proc_WV_PO_GetFunctTotals 1, 65, null, null, null
--exec proc_WV_PO_GetFunctTotals 99, 89, null, null, null

if @funct=1
begin

select distinct JOB_NUMBER into #tmp from PURCHASE_ORDER_DET where
 PO_NUMBER = @po_number

select distinct d.PO_NUMBER, d.JOB_COMPONENT_NBR into #tmp2 from PURCHASE_ORDER_DET as d 
join PURCHASE_ORDER as p on p.PO_NUMBER=d.PO_NUMBER 
where d.JOB_NUMBER in (select JOB_NUMBER from #tmp) and d.PO_NUMBER <> @po_number
and (p.VOID_FLAG = 0 or p.VOID_FLAG is null)

select d.PO_NUMBER as PO_NUMBER,
 min(Right('00000000' + convert(varchar(8),p.PO_NUMBER),8)) as PO_PAD, 
 min(p.PO_DATE) as ORDER_DATE,
 min(p.VN_CODE) as VN_CODE, min(v.VN_NAME) as VN_NAME, min(p.EMP_CODE) as EMP_CODE,
 min(isnull(d.JOB_NUMBER,0)) as JOB_NUMBER, min(isnull(d.JOB_COMPONENT_NBR,0)) as JOB_COMPONENT_NBR,
JOB_AND_COMP = case when d.JOB_NUMBER is null then '' else
  min(Right('00000000' + convert(varchar(8),d.JOB_NUMBER),8)) + '-' +
 min(Right('0000' + convert(varchar(4),d.JOB_COMPONENT_NBR),4)) end,
 min(d.FNC_CODE) as FNC_CODE, min(f.FNC_DESCRIPTION) as FNC_DESCRIPTION,
 sum(d.PO_EXT_AMOUNT) as EXT_AMOUNT, min(2) as seq,
 min(case when d.PO_NUMBER = @po_number then 1 else 0 end) as CURRENT_PO_FLG
 from PURCHASE_ORDER_DET as d
 join [FUNCTIONS] as f on f.FNC_CODE=d.FNC_CODE
 join PURCHASE_ORDER as p on p.PO_NUMBER=d.PO_NUMBER
 join #tmp2 as t on t.PO_NUMBER=d.PO_NUMBER 
 join VENDOR as v on v.VN_CODE=p.VN_CODE
 group by d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.FNC_CODE, f.FNC_DESCRIPTION, d.PO_NUMBER

   union
 
select d.PO_NUMBER as PO_NUMBER,
 min(Right('00000000' + convert(varchar(8),p.PO_NUMBER),8)) as PO_PAD, 
 min(p.PO_DATE) as ORDER_DATE,
 min(p.VN_CODE) as VN_CODE, min(v.VN_NAME) as VN_NAME,  min(p.EMP_CODE) as EMP_CODE,
 min(isnull(d.JOB_NUMBER,0)) as JOB_NUMBER, min(isnull(d.JOB_COMPONENT_NBR,0)) as JOB_COMPONENT_NBR,
JOB_AND_COMP = case when d.JOB_NUMBER is null then '' else
  min(Right('00000000' + convert(varchar(8),d.JOB_NUMBER),8)) + '-' +
 min(Right('0000' + convert(varchar(4),d.JOB_COMPONENT_NBR),4)) end,
 min(d.FNC_CODE) as FNC_CODE, min(f.FNC_DESCRIPTION) as FNC_DESCRIPTION,
 sum(d.PO_EXT_AMOUNT) as EXT_AMOUNT, min(1) as seq,
 min(case when d.PO_NUMBER = @po_number then 1 else 0 end) as CURRENT_PO_FLG
 from PURCHASE_ORDER_DET as d
 join [FUNCTIONS] as f on f.FNC_CODE=d.FNC_CODE
 join PURCHASE_ORDER as p on p.PO_NUMBER=d.PO_NUMBER
 join VENDOR as v on v.VN_CODE=p.VN_CODE
 where d.PO_NUMBER=@po_number
 group by d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.FNC_CODE, f.FNC_DESCRIPTION, d.PO_NUMBER
order by  JOB_NUMBER, JOB_COMPONENT_NBR, FNC_CODE, PO_NUMBER

drop table #tmp 
drop table #tmp2


end 
else if @funct=2
begin
select min(d.PO_NUMBER) as PO_NUMBER, 
 min(Right('00000000' + convert(varchar(8),p.PO_NUMBER),8)) as PO_PAD, 
min(p.PO_DATE) as ORDER_DATE,
 min(p.VN_CODE) as VN_CODE, min(v.VN_NAME) as VN_NAME,  min(p.EMP_CODE) as EMP_CODE,
 min(isnull(d.JOB_NUMBER,0)) as JOB_NUMBER, min(isnull(d.JOB_COMPONENT_NBR,0)) as JOB_COMPONENT_NBR,
 min(d.FNC_CODE) as FNC_CODE, min(f.FNC_DESCRIPTION) as FNC_DESCRIPTION,
 sum(d.PO_EXT_AMOUNT) as EXT_AMOUNT, min(1) as seq,
min(1) as CURRENT_PO_FLG,
  JOB_AND_COMP=( case when d.JOB_NUMBER is null then '' else
  min(Right('00000000' + convert(varchar(8),d.JOB_NUMBER),8)) + '-' +
 min(Right('0000' + convert(varchar(4),d.JOB_COMPONENT_NBR),4)) end) 
 from PURCHASE_ORDER_DET as d
 join [FUNCTIONS] as f on f.FNC_CODE=d.FNC_CODE
 join PURCHASE_ORDER as p on p.PO_NUMBER=d.PO_NUMBER
 join VENDOR as v on v.VN_CODE=p.VN_CODE
 where d.PO_NUMBER=@po_number
 group by d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.FNC_CODE, f.FNC_DESCRIPTION
order by  d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.FNC_CODE, PO_NUMBER
end

else if @funct=3
begin
select distinct JOB_NUMBER into #tmp3 from PURCHASE_ORDER_DET where
 PO_NUMBER = @po_number


select distinct d.PO_NUMBER,
 Right('00000000' + convert(varchar(8),p.PO_NUMBER),8) as PO_PAD, 
 d.JOB_COMPONENT_NBR into #tmp4 from PURCHASE_ORDER_DET as d 
join PURCHASE_ORDER as p on p.PO_NUMBER=d.PO_NUMBER 
where d.JOB_NUMBER in (select JOB_NUMBER from #tmp3) and d.PO_NUMBER <> @po_number
and (p.VOID_FLAG = 0 or p.VOID_FLAG is null)

select d.PO_NUMBER as PO_NUMBER, min(p.PO_DATE) as ORDER_DATE,
 min(Right('00000000' + convert(varchar(8),p.PO_NUMBER),8)) as PO_PAD, 
 min(p.VN_CODE) as VN_CODE, min(v.VN_NAME) as VN_NAME, min(p.EMP_CODE) as EMP_CODE,
 min(isnull(d.JOB_NUMBER,0)) as JOB_NUMBER, min(isnull(d.JOB_COMPONENT_NBR,0)) as JOB_COMPONENT_NBR,
 min(d.FNC_CODE) as FNC_CODE, min(f.FNC_DESCRIPTION) as FNC_DESCRIPTION,
 sum(d.PO_EXT_AMOUNT) as EXT_AMOUNT, min(2) as seq,
 min(case when d.PO_NUMBER = @po_number then 1 else 0 end) as CURRENT_PO_FLG
 from PURCHASE_ORDER_DET as d
 join [FUNCTIONS] as f on f.FNC_CODE=d.FNC_CODE
 join PURCHASE_ORDER as p on p.PO_NUMBER=d.PO_NUMBER
 join #tmp4 as t on t.PO_NUMBER=d.PO_NUMBER 
 join VENDOR as v on v.VN_CODE=p.VN_CODE
 group by d.JOB_NUMBER, d.JOB_COMPONENT_NBR, d.FNC_CODE, f.FNC_DESCRIPTION, d.PO_NUMBER


 drop table #tmp3
 drop table #tmp4

end
else if @funct=99
 begin

select distinct d.JOB_NUMBER into #tmp5 from PURCHASE_ORDER_DET as d  where PO_NUMBER=@po_number
select distinct d.PO_NUMBER, d.JOB_COMPONENT_NBR into #tmp7 from PURCHASE_ORDER_DET as d 
join PURCHASE_ORDER as p on p.PO_NUMBER=d.PO_NUMBER 
where d.JOB_NUMBER in (select JOB_NUMBER from #tmp5) 
and (p.VOID_FLAG = 0 or p.VOID_FLAG is null)
select min(d.PO_NUMBER) as PO_NUMBER,
 min(Right('00000000' + convert(varchar(8),d.PO_NUMBER),8)) as PO_PAD,
 JOB_NUMBER =  (case when d.JOB_NUMBER is null then '' else Right('00000000' + convert(varchar(8),d.JOB_NUMBER),8) end),
  sum(d.PO_EXT_AMOUNT) as JOB_TOTAL,
  min(isnull(j.CL_CODE,'')) as CL_CODE,
  min(1) as SELECTED_PO, min(1) as SEQ
  from PURCHASE_ORDER_DET as d
  left join JOB_LOG as j on j.JOB_NUMBER = d.JOB_NUMBER
  where d.PO_NUMBER = @po_number
    group by d.JOB_NUMBER, d.PO_NUMBER
 union
select min(d.PO_NUMBER) as PO_NUMBER,
  min(Right('00000000' + convert(varchar(8),d.PO_NUMBER),8)) as PO_PAD,
 JOB_NUMBER =  (case when d.JOB_NUMBER is null then '' else Right('00000000' + convert(varchar(8),d.JOB_NUMBER),8) end),
  sum(d.PO_EXT_AMOUNT) as JOB_TOTAL,
  min(isnull(j.CL_CODE,'')) as CL_CODE,
  min(0) as SELECTED_PO, min(1) as SEQ
  from PURCHASE_ORDER_DET as d
  left join JOB_LOG as j on j.JOB_NUMBER = d.JOB_NUMBER
  join #tmp7 as t on t.PO_NUMBER=d.PO_NUMBER
  where d.JOB_NUMBER in (select JOB_NUMBER from #tmp5) and d.PO_NUMBER <> @po_number
    group by d.JOB_NUMBER, d.PO_NUMBER
 union
select min(0) as PO_NUMBER,
  min('Job Total -->') as PO_PAD,
   JOB_NUMBER =  (case when d.JOB_NUMBER is null then '' else Right('00000000' + convert(varchar(8),d.JOB_NUMBER),8) end),
  sum(d.PO_EXT_AMOUNT) as JOB_TOTAL,
  min(isnull(j.CL_CODE,'')) as CL_CODE,
  min(0) as SELECTED_PO, min(2) as SEQ
  from PURCHASE_ORDER_DET as d
  left join JOB_LOG as j on j.JOB_NUMBER = d.JOB_NUMBER
  join #tmp7 as t on t.PO_NUMBER=d.PO_NUMBER
  where d.JOB_NUMBER in (select JOB_NUMBER from #tmp5) 
    group by d.JOB_NUMBER
    order by SEQ, JOB_NUMBER, PO_NUMBER 

drop table #tmp5
drop table #tmp7
end 



GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO