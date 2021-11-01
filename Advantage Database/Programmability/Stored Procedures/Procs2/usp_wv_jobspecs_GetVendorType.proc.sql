




CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetVendorType]
@VendorCode varchar(50)
AS


SELECT     VN_CATEGORY
FROM         VENDOR
WHERE      VN_CODE = @VendorCode
                                                  



