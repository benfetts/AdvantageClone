


CREATE PROCEDURE [dbo].[proc_WV_PO_Vend_Contact_LoadAll](@funct integer, @code varchar(15), @str varchar(15)) AS

-- exec proc_WV_PO_Vend_Contact_LoadAll 1, 'latime', ''

if @funct=1 -- all active contacts for vendor with default indicated.
begin
SELECT vc.VC_CODE,
 vc.VC_LNAME + ', ' +  isnull(vc.VC_FNAME,'') + ' ' +  isnull(vc.VC_MI,'') as CONT_FULL_NAME,
vc.VC_LNAME, vc.VC_FNAME, isnull(vc.VC_MI,'') AS VC_MI, isnull(vc.EMAIL_ADDRESS,'') as VC_EMAIL_ADDRESS,
DFLT_CONTACT = CASE WHEN v.DEF_VN_CONT is null then 0 else 1 end
 FROM VEN_CONT as vc 
 left join VENDOR as v on v.DEF_VN_CONT=vc.VC_CODE and v.VN_CODE=vc.VN_CODE
WHERE vc.VN_CODE=@code
 and (VC_INACTIVE_FLAG = 0 or VC_INACTIVE_FLAG is null)
 order by vc.VC_LNAME, vc.VC_FNAME 
end



