


CREATE PROCEDURE [dbo].[proc_WV_PO_Vendor_LoadAddress](@vn_code varchar(6), @format integer) AS

--exec proc_WV_PO_Vendor_LoadAddress 'latimes', 1

if @format =1 -- retrieve vendor address - multi-column format...
begin
select VN_CODE, VN_NAME, isnull(VN_ADDRESS1,'') as ADDRESS1,
 isnull(VN_ADDRESS2,'') as ADDRESS2,
 isnull(VN_CITY,'') as VN_CITY,
 isnull(VN_STATE,'') as VN_STATE,
 isnull(VN_ZIP,'') as VN_ZIP,
VN_CITYSTATEZIP=  isnull(VN_CITY,'') + ', ' +  isnull(VN_STATE,'') + ' ' + isnull(VN_ZIP,''),
 VN_PHONE= case when VN_PHONE_EXT is null then  isnull(VN_PHONE,'') else VN_PHONE + ' ext. ' + VN_PHONE_EXT end
 from VENDOR where VN_CODE=@vn_code
end



