SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[proc_WV_PO_GetCustomPickList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[proc_WV_PO_GetCustomPickList]
GO


CREATE PROCEDURE dbo.proc_WV_PO_GetCustomPickList(@list_code varchar(50), @str as varchar(15), @sort varchar(100), @UserID varchar(100)) AS

--   exec proc_WV_PO_GetCustomPickList 'vendor_all_active', null, null
--   exec proc_WV_PO_GetCustomPickList 'po_issuer_active', null, null
--   exec proc_WV_PO_GetCustomPickList 'vendor_and_contact', null, null
Declare @Restrictions Int

Select @Restrictions = Count(*) 
FROM SEC_EMP
WHERE UPPER(USER_ID) = UPPER(@UserID)

DECLARE @EMP_CODE AS VARCHAR(6)
DECLARE @OfficeRestrictions AS INTEGER

SELECT @EMP_CODE = EMP_CODE FROM SEC_USER WHERE UPPER(USER_CODE) = UPPER(@UserID)

SELECT @OfficeRestrictions = COUNT(*) FROM EMP_OFFICE WHERE EMP_CODE = @EMP_CODE

if @list_code='vendor_filter_recent'
begin

declare @lastpodate as datetime
  select @lastpodate = max(PO_DATE) from PURCHASE_ORDER

select  
v.VN_CODE as CODE1, 
v.VN_NAME as VALUE1,
 '' as VALUE2, 
 '' as VALUE3, 
 '' as VALUE4, 
 '' as VALUE5, 
 '' as VALUE6, 
 '' as VALUE7, 
 '' as VALUE8, 
 '' AS VALUE9,
 1 as USED_RECENT, 
 1 as SEQ  from VENDOR as v
 where VN_CODE in 
   (select VN_CODE from  PURCHASE_ORDER where (PO_DATE 
       between dateadd(day,-14,isnull(@lastpodate,getdate())) and dateadd(day,1,getdate())))
       and (VN_ACTIVE_FLAG=1 or VN_ACTIVE_FLAG is null)
   union
     select '', '', '', '', '','','','','','',0,2 
   union
 select  
 v.VN_CODE as CODE1, 
 v.VN_NAME as VALUE1,
 '' as VALUE2, 
 '' as VALUE3, 
 '' as VALUE4, 
 '' as VALUE5,
 '' as VALUE6, 
 '' as VALUE7, 
 '' as VALUE8, 
 '' AS VALUE9,
   0 as USED_RECENT,
    3 as SEQ 
from VENDOR as v
 where VN_CODE in 
   (select VN_CODE from  PURCHASE_ORDER where VN_ACTIVE_FLAG=1 or VN_ACTIVE_FLAG is null)
      order by SEQ,  v.VN_NAME
end

else if @list_code='vendor_all_active'
begin
 select  
 v.VN_CODE as CODE1, 
 v.VN_CODE + ' - ' +  v.VN_NAME as VALUE1,
 '' as VALUE2,
  '' as VALUE3, 
  '' as VALUE4, 
  '' as VALUE5,
   '' as VALUE6, 
   '' as VALUE7, 
   '' as VALUE8, 
   '' AS VALUE9,
 0 as USED_RECENT, 
 0 as SEQ  from VENDOR as v
   where v.VN_ACTIVE_FLAG=1 or v.VN_ACTIVE_FLAG is null order by VN_NAME
end

else if @list_code='vendor_and_contact'

if @OfficeRestrictions > 0
Begin
	select  
v.VN_CODE as CODE1,
 v.VN_CODE + ' - ' +  v.VN_NAME as VALUE1,
 isnull(v.VN_ADDRESS1,'') as VALUE2 ,
 isnull(VN_ADDRESS2,'') as VALUE3,
 VALUE4 =case when v.VN_CITY is null or v.VN_CITY = '' then '' else v.VN_CITY + ', ' + isnull(v.VN_STATE,'') + '  ' + isnull(v.VN_ZIP,'') end,
 isnull(v.DEF_VN_CONT,'') as VALUE5,
 isnull((SELECT isnull(isnull(vc.VC_LNAME,'') + ', ' + isnull(vc.VC_FNAME,'') + ' ' +  isnull(vc.VC_MI,''),'') from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE6,
 isnull((SELECT isnull(EMAIL_ADDRESS,'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE7,
 isnull(VN_ADDRESS3,'') as VALUE8, 
 v.VN_NAME AS VALUE9
 from VENDOR as v INNER JOIN
	  EMP_OFFICE ON v.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE  where v.VN_ACTIVE_FLAG=1   order by  v.VN_CODE, v.VN_NAME -- v.VN_ALPHA_SORT

End
Else
Begin
	select  
v.VN_CODE as CODE1,
 v.VN_CODE + ' - ' +  v.VN_NAME as VALUE1,
 isnull(v.VN_ADDRESS1,'') as VALUE2 ,
 isnull(VN_ADDRESS2,'') as VALUE3,
 VALUE4 =case when v.VN_CITY is null or v.VN_CITY = '' then '' else v.VN_CITY + ', ' + isnull(v.VN_STATE,'') + '  ' + isnull(v.VN_ZIP,'') end,
 isnull(v.DEF_VN_CONT,'') as VALUE5,
 isnull((SELECT isnull(isnull(vc.VC_LNAME,'') + ', ' + isnull(vc.VC_FNAME,'') + ' ' +  isnull(vc.VC_MI,''),'') from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE6,
 isnull((SELECT isnull(EMAIL_ADDRESS,'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE7,
 isnull(VN_ADDRESS3,'') as VALUE8, 
 v.VN_NAME AS VALUE9
 from VENDOR as v  where v.VN_ACTIVE_FLAG=1   order by  v.VN_CODE, v.VN_NAME -- v.VN_ALPHA_SORT

End

else if @list_code='vendor_and_category1'--job spec vendor
begin
if @OfficeRestrictions > 0
Begin
	select  
v.VN_CODE as CODE1, 
v.VN_CODE + ' - ' +  v.VN_NAME as VALUE1,
 isnull(v.VN_ADDRESS1,'') as VALUE2 ,
 isnull(VN_ADDRESS2,'') as VALUE3,
 VALUE4 =case when v.VN_CITY is null or v.VN_CITY = '' then '' else v.VN_CITY + ', ' + isnull(v.VN_STATE,'') + '  ' + isnull(v.VN_ZIP,'') end,
 isnull(v.DEF_VN_CONT,'') as VALUE5,
 isnull((SELECT isnull(isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,''),'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE6,
 isnull((SELECT isnull(EMAIL_ADDRESS,'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE7,
 isnull(VN_ADDRESS3,'') as VALUE8, 
 v.VN_NAME AS VALUE9
 from VENDOR as v INNER JOIN
	  EMP_OFFICE ON v.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE where v.VN_ACTIVE_FLAG=1 and ((VN_CATEGORY = 'M') OR
                      (VN_CATEGORY = 'N') OR
                      (VN_CATEGORY = 'I'))
    order by  v.VN_CODE, v.VN_NAME
End
Else
Begin
	select  
v.VN_CODE as CODE1, 
v.VN_CODE + ' - ' +  v.VN_NAME as VALUE1,
 isnull(v.VN_ADDRESS1,'') as VALUE2 ,
 isnull(VN_ADDRESS2,'') as VALUE3,
 VALUE4 =case when v.VN_CITY is null or v.VN_CITY = '' then '' else v.VN_CITY + ', ' + isnull(v.VN_STATE,'') + '  ' + isnull(v.VN_ZIP,'') end,
 isnull(v.DEF_VN_CONT,'') as VALUE5,
 isnull((SELECT isnull(isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,''),'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE6,
 isnull((SELECT isnull(EMAIL_ADDRESS,'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE7,
 isnull(VN_ADDRESS3,'') as VALUE8, 
 v.VN_NAME AS VALUE9
 from VENDOR as v  where v.VN_ACTIVE_FLAG=1 and ((VN_CATEGORY = 'M') OR
                      (VN_CATEGORY = 'N') OR
                      (VN_CATEGORY = 'I'))
    order by  v.VN_CODE, v.VN_NAME
End

end
else if @list_code='vendor_and_category2'--job spec vendor
begin
if @OfficeRestrictions > 0
Begin
	select  
v.VN_CODE as CODE1, 
v.VN_CODE + ' - ' +  v.VN_NAME as VALUE1,
 isnull(v.VN_ADDRESS1,'') as VALUE2 ,
 isnull(VN_ADDRESS2,'') as VALUE3,
 VALUE4 =case when v.VN_CITY is null or v.VN_CITY = '' then '' else v.VN_CITY + ', ' + isnull(v.VN_STATE,'') + '  ' + isnull(v.VN_ZIP,'') end,
 isnull(v.DEF_VN_CONT,'') as VALUE5,
 isnull((SELECT isnull(isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,''),'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE6,
 isnull((SELECT isnull(EMAIL_ADDRESS,'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE7,
 isnull(VN_ADDRESS3,'') as VALUE8, 
 v.VN_NAME AS VALUE9
 from VENDOR as v INNER JOIN
	  EMP_OFFICE ON v.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = @EMP_CODE where v.VN_ACTIVE_FLAG=1 and (VN_CATEGORY = 'O')
    order by  v.VN_CODE, v.VN_NAME
End
Else
Begin
	select  
v.VN_CODE as CODE1, 
v.VN_CODE + ' - ' +  v.VN_NAME as VALUE1,
 isnull(v.VN_ADDRESS1,'') as VALUE2 ,
 isnull(VN_ADDRESS2,'') as VALUE3,
 VALUE4 =case when v.VN_CITY is null or v.VN_CITY = '' then '' else v.VN_CITY + ', ' + isnull(v.VN_STATE,'') + '  ' + isnull(v.VN_ZIP,'') end,
 isnull(v.DEF_VN_CONT,'') as VALUE5,
 isnull((SELECT isnull(isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,''),'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE6,
 isnull((SELECT isnull(EMAIL_ADDRESS,'')  from VEN_CONT as vc where vc.VN_CODE=v.VN_CODE and v.DEF_VN_CONT = vc.VC_CODE),'') as VALUE7,
 isnull(VN_ADDRESS3,'') as VALUE8, 
 v.VN_NAME AS VALUE9
 from VENDOR as v  where v.VN_ACTIVE_FLAG=1 and (VN_CATEGORY = 'O')
    order by  v.VN_CODE, v.VN_NAME
End

end
else if @list_code='po_issuer_active'
begin
if @Restrictions > 0
select 
e.EMP_CODE as CODE1,
 e.EMP_CODE + ' - ' + isnull(e.EMP_LNAME + ', ','') + isnull(e.EMP_FNAME + ' ','') + isnull(e.EMP_MI,'') as VALUE1,
 isnull(PO_LIMIT,-1.0) as VALUE2,  '' as VALUE3, '' as VALUE4, '' as VALUE5, '' as VALUE6,'' as VALUE7,'' as VALUE8, '' AS VALUE9,
 USED_RECENT=0, SEQ=0
from EMPLOYEE as e Inner JOIN [dbo].[advtf_sec_emp] (@UserID) AS SEC_EMP
		On e.EMP_CODE = SEC_EMP.EMP_CODE
   where e.EMP_TERM_DATE is null order by e.EMP_LNAME, e.EMP_FNAME, e.EMP_MI
else
select e.EMP_CODE as CODE1,
 e.EMP_CODE + ' - ' + isnull(e.EMP_LNAME + ', ','') + isnull(e.EMP_FNAME + ' ','') + isnull(e.EMP_MI,'') as VALUE1,
 isnull(PO_LIMIT,-1.0) as VALUE2,  '' as VALUE3, '' as VALUE4, '' as VALUE5, '' as VALUE6,'' as VALUE7,'' as VALUE8, '' AS VALUE9,
 USED_RECENT=0, SEQ=0
from EMPLOYEE as e
   where e.EMP_TERM_DATE is null order by e.EMP_LNAME, e.EMP_FNAME, e.EMP_MI
end

else if @list_code = 'vendor_contacts'
begin
SELECT vc.VC_CODE as CODE1,
 isnull(vc.VC_LNAME + ', ','') +  isnull(vc.VC_FNAME + ' ','') +  isnull(vc.VC_MI,'') as VALUE1,
 isnull(vc.EMAIL_ADDRESS,'') as VALUE2,
VALUE3 = CASE WHEN v.DEF_VN_CONT is null then 0 else 1 end,
'' as VALUE4, '' as VALUE5, '' as VALUE6, '' as VALUE7, '' as VALUE8, 0 as USED_RECENT, 0 as SEQ, '' AS VALUE9
 FROM VEN_CONT as vc 
 left join VENDOR as v on v.DEF_VN_CONT=vc.VC_CODE and v.VN_CODE=vc.VN_CODE
WHERE vc.VN_CODE=@str
 and (VC_INACTIVE_FLAG = 0 or VC_INACTIVE_FLAG is null)
 order by vc.VC_LNAME, vc.VC_FNAME 
end

else if @list_code='vendor_functions'
begin
  select f.FNC_CODE as CODE1, f.FNC_CODE + ' - ' +  isnull(f.FNC_DESCRIPTION,'')
 + case when f.FNC_CPM_FLAG=1 then ' *' else '' end
 as VALUE1,
 isnull(f.FNC_CPM_FLAG,0) as VALUE2, isnull(f.OVERHEAD_GLACCT,'') as VALUE3, ISNULL(g.GLADESC,'') as VALUE4, '' as VALUE5, '' as VALUE6,
'' as VALUE7, '' as VALUE8, 0 as USED_RECENT, 0 as SEQ, '' AS VALUE9
 from [FUNCTIONS] as f LEFT OUTER JOIN GLACCOUNT as g ON
		f.OVERHEAD_GLACCT = g.GLACODE 
 where (f.FNC_INACTIVE = 0 or f.FNC_INACTIVE is null)
 and f.FNC_TYPE = 'V'
order by f.FNC_DESCRIPTION
end




