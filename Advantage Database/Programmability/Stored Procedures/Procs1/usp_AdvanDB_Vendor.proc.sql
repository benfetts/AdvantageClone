


















--version 1.1 10/18/2005 by Jim Hall   added vendor category, address, and phone data.

CREATE PROCEDURE [dbo].[usp_AdvanDB_Vendor] 

AS

SELECT  
VN_CODE, 
VN_NAME, 
VN_CATEGORY,
 VN_ADDRESS1, 
VN_ADDRESS2, 
VN_CITY, 
VN_COUNTY, 
VN_STATE, 
VN_COUNTRY, 
VN_ZIP, 
VN_PHONE,
VN_PHONE_EXT,
VN_FAX_NUMBER,
VN_FAX_EXTENTION
FROM       VENDOR
WHERE   VN_CATEGORY IN ('M','N','O','I','R','T') and VN_ACTIVE_FLAG = 1
















