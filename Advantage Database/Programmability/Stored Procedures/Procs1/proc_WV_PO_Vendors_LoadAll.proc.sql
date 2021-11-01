



CREATE PROCEDURE [dbo].[proc_WV_PO_Vendors_LoadAll](@funct integer, @ref_id integer,  @str1 varchar(15), @str2 varchar(15), @sort varchar(100)) AS

-- exec proc_WV_PO_Vendors_LoadAll 1,1, '', '', ''

if @funct=1 -- all active vendors, Production Category only.
begin
select VN_CATEGORY, VN_CODE, VN_NAME, VN_CITYSTATE =
case when VN_CITY is null or VN_CITY = '' then '' else VN_CITY + ', ' + VN_STATE  end,
VN_CITY, VN_STATE,VN_ZIP,
VN_ADDRESS = isnull(VN_ADDRESS1,'') + case when VN_ADDRESS2 is not null then 
 ' - ' + VN_ADDRESS2  else '' end,
isnull(VN_EMAIL,'') as VN_EMAIL,
isnull(VN_PHONE,'') as VN_PHONE, 
VN_ALPHA_SORT
 from VENDOR  where VN_ACTIVE_FLAG=1  order by  VN_ALPHA_SORT --and VN_CATEGORY = 'P' 
end
else if @funct=2
begin
select VN_CATEGORY, VN_CODE, VN_NAME, VN_CITYSTATE =
case when VN_CITY is null or VN_CITY = '' then '' else VN_CITY + ', ' + VN_STATE  end,
VN_CITY, VN_STATE,VN_ZIP,
VN_ADDRESS = isnull(VN_ADDRESS1,'') + case when VN_ADDRESS2 is not null then 
 ' - ' + VN_ADDRESS2  else '' end,
isnull(VN_EMAIL,'') as VN_EMAIL,
isnull(VN_PHONE,'') as VN_PHONE,
VN_ALPHA_SORT
 from VENDOR  where VN_ACTIVE_FLAG=1 and charindex(@str1, VN_NAME ) > 0 --and VN_CATEGORY = 'P'  
and @str1 <> ''
order by  VN_ALPHA_SORT
end

