


CREATE PROCEDURE [dbo].[proc_WV_PO_Issuer_LoadAll](@funct integer, @str1 varchar(15), @str2 varchar(15)) AS

--exec proc_WV_PO_Issuer_LoadAll 2, '', ''

if @funct=1 -- all active employees and max PO Limits
begin
select e.EMP_LNAME, e.EMP_FNAME, isnull(e.EMP_MI,'') as EMP_MI, EMP_TITLE, e.EMP_CODE,
 isnull(e.EMP_LNAME,'') + ', ' + isnull(e.EMP_FNAME,'') + ' ' + isnull(e.EMP_MI,'') as EMP_FULL_NAME,
 HAS_PO_LIMIT = case when PO_LIMIT is null or PO_LIMIT =0 then 0 else 1 end,
  isnull(PO_LIMIT,0) as PO_LIMIT,
  LAST_PO = isnull((select max(p.PO_NUMBER) from PURCHASE_ORDER as p WHERE p.EMP_CODE = e.EMP_CODE),0)
from EMPLOYEE as e
   where e.EMP_TERM_DATE is null order by e.EMP_LNAME, e.EMP_FNAME, e.EMP_MI
end
else if @funct=2 -- employees authorized to create orders.
begin
select e.EMP_LNAME, e.EMP_FNAME, isnull(e.EMP_MI,'') as EMP_MI, EMP_TITLE, e.EMP_CODE,
 isnull(e.EMP_LNAME,'') + ', ' + isnull(e.EMP_FNAME,'') + ' ' + isnull(e.EMP_MI,'') as EMP_FULL_NAME,
 HAS_PO_LIMIT = case when PO_LIMIT is null or PO_LIMIT =0 then 0 else 1 end,
  isnull(PO_LIMIT,0) as PO_LIMIT,
  LAST_PO = isnull((select max(p.PO_NUMBER) from PURCHASE_ORDER as p WHERE p.EMP_CODE = e.EMP_CODE),0)
from EMPLOYEE as e
   where e.EMP_TERM_DATE  is null and e.PO_LIMIT <> 0  order by e.EMP_LNAME, e.EMP_FNAME, e.EMP_MI
end



