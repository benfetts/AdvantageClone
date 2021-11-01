

CREATE PROCEDURE [dbo].[usp_wv_dd_GetVendorList] 
@funct integer, 
@str VarChar(15)
AS

--Retrieve vendor Dropdown (class cDropdown)

Set NoCount On

select VN_CODE as Code, VN_NAME + 
case when VN_CITY is null or VN_CITY = '' then '' else '    (' + VN_CITY + ',' + VN_STATE + ')' end
 as [Description] from VENDOR
  where VN_ACTIVE_FLAG=1 order by VN_NAME, VN_CODE




