


CREATE PROCEDURE [dbo].[proc_WV_PO_Vend_GetDefaultContact](@vn_code char(6), @vc_code char(4) OUTPUT, @vc_name varchar(255) OUTPUT, @vc_email varchar(255) OUTPUT) AS

/* Retrieve Default Contact for Vendor -- used on Webvantage PO.
declare @p1 char(4)
declare @p2 varchar(255) 
declare @p3 varchar(255) 

exec proc_WV_PO_Vend_GetDefaultContact 'excels', @p1 OUTPUT,  @p2  OUTPUT, @p3 OUTPUT

print @p1
print @p2
print @p3
*/

select @vc_code=''
select @vc_name=''
select @vc_email=''

SELECT @vc_code=isnull(vc.VC_CODE,''),
 @vc_name= vc.VC_LNAME + ', ' +  isnull(vc.VC_FNAME,'') + ' ' +  isnull(vc.VC_MI,''),
 @vc_email = isnull(vc.EMAIL_ADDRESS,'') 

 from VEN_CONT as vc join VENDOR as v on v.VN_CODE= vc.VN_CODE
 where v.DEF_VN_CONT =vc.VC_CODE and v.VN_CODE=@vn_code




