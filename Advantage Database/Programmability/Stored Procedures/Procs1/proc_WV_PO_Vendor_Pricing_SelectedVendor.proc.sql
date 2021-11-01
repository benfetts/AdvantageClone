

CREATE PROCEDURE [dbo].[proc_WV_PO_Vendor_Pricing_SelectedVendor](@funct integer, @vn_code char(6),  @jt_code varchar(10), @str varchar(15), @sort varchar(100)) AS

--exec proc_WV_PO_Vendor_Pricing_LoadAll 1, 'hamil', 'cat', '', ''
--exec proc_WV_PO_Vendor_Pricing_LoadAll 2, '', '', 'print', ''


if @funct=1
begin

select vp.VN_PRICING_ID, vp.VN_CODE, v.VN_NAME,
 t.JT_DESC,
 vp.JT_CODE, vp.VN_PRICING_DESC,
 vp.VN_PRICING_RATE, 1 as seq, 1 as pri_sel,
 isnull(vp.VN_PRICING_NOTES,'') as VN_PRICING_NOTES
  from dbo.VN_PRICING as vp
 join JOB_TYPE as t on t.JT_CODE= vp.JT_CODE
 join VENDOR as v on v.VN_CODE=vp.VN_CODE
 where --t.INACTIVE_FLAG=0 or t.INACTIVE_FLAG is null and 
 vp.JT_CODE  = @jt_code and vp.VN_CODE= @vn_code
end

else if @funct=2
begin

select vp.VN_PRICING_ID, vp.VN_CODE, v.VN_NAME,
 t.JT_DESC,
 vp.JT_CODE, vp.VN_PRICING_DESC,
 vp.VN_PRICING_RATE, 1 as seq, pri_sel = case when vp.VN_CODE=@vn_code then 1 else 0 end,
 isnull(vp.VN_PRICING_NOTES,'') as VN_PRICING_NOTES
  from dbo.VN_PRICING as vp
 LEFT OUTER JOIN JOB_TYPE as t on t.JT_CODE= vp.JT_CODE
 join VENDOR as v on v.VN_CODE=vp.VN_CODE
 where --t.INACTIVE_FLAG=0 or t.INACTIVE_FLAG is null and 
 vp.VN_CODE=@vn_code
 order by JT_DESC, VN_NAME, VN_PRICING_DESC, VN_PRICING_RATE
end





