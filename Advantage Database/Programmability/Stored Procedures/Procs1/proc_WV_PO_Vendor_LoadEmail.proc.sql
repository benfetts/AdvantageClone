
--exec proc_WV_PO_Vendor_LoadEmail 1, 89, ''

CREATE PROCEDURE [dbo].[proc_WV_PO_Vendor_LoadEmail](@funct integer, @ref_id integer, @str varchar(25)) AS

if @funct=1  -- email info for vendor contact related to a specific po number, And other contacts for the vendor...
begin
select po.VN_CONT_CODE, po.VN_CONT_CODE as PARENT_ID,  po.VN_CODE, v.VN_NAME,
 CONTACT_NAME =   isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,'') + '*',
 CONTACT_INFO =    isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,'') + '*'  + ' - ' +   isnull(vc.EMAIL_ADDRESS,''),
 isnull(vc.EMAIL_ADDRESS,'') as EMAIL_ADDRESS, IS_PRIMARY=1
  from PURCHASE_ORDER as po
join VENDOR as v on v.VN_CODE = po.VN_CODE
join VEN_CONT as vc on vc.VN_CODE = po.VN_CODE and vc.VC_CODE = po.VN_CONT_CODE
 where po.PO_NUMBER = @ref_id and (vc.VC_INACTIVE_FLAG is null or vc.VC_INACTIVE_FLAG =0)
union 
 select vc.VC_CODE,vc.VC_CODE, vc.VN_CODE, v.VN_NAME,  CONTACT_NAME =  isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,''),
 CONTACT_INFO =    isnull(vc.VC_LNAME,'') + ',' + isnull(vc.VC_FNAME,'') + '*'  + ' - ' +   isnull(vc.EMAIL_ADDRESS,''),
 isnull(vc.EMAIL_ADDRESS,'') as EMAIL_ADDRESS, IS_PRIMARY=0
  from VEN_CONT as vc join VENDOR as v on v.VN_CODE = vc.VN_CODE
  where vc.VN_CODE in (SELECT VN_CODE from PURCHASE_ORDER as po2 where po2.PO_NUMBER=@ref_id)
  and vc.VC_CODE not in (SELECT VN_CONT_CODE from PURCHASE_ORDER as po3 where po3.PO_NUMBER=@ref_id)
 order by CONTACT_NAME
end




