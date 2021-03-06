





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetJobSpecsVendorData] 
@JobNumber int,
@JobCompNumber int,
@VendorTab int
AS

if @VendorTab = 1
Begin
SELECT     JOB_PUB_VENDOR.VN_CODE AS Vendor, ISNULL(VENDOR.VN_NAME,'') AS Publication_Name, ISNULL(JOB_PUB_VENDOR.JOB_PUB_CLOSE_DATE,'') AS Close_Date, 
                      ISNULL(JOB_PUB_VENDOR.JOB_PUB_RUN_DATE,'') AS Run_Date, ISNULL(JOB_PUB_VENDOR.JOB_PUB_EXT_DATE,'') AS Ext_Date, ISNULL(JOB_PUB_VENDOR.AD_SIZE, '') AS AdSize, ISNULL(AD_SIZE.SIZE_DESC, '') AS Size_Desc, ISNULL(JOB_PUB_VENDOR.JOB_PUB_BLEED_SIZE,'') AS Bleed_Size, 
                      ISNULL(JOB_PUB_VENDOR.JOB_PUB_TRIM_SIZE,'') AS Trim_Size, ISNULL(JOB_PUB_VENDOR.JOB_PUB_LIVE_AREA,'') AS Live_Area, ISNULL(JOB_PUB_VENDOR.JOB_PUB_SCREEN,'') AS Screen, 
                      ISNULL(JOB_PUB_VENDOR.JOB_PUB_COLOR,'') AS Color, ISNULL(JOB_PUB_VENDOR.STATUS_CODE,'') AS Status, ISNULL(JOB_PUB_VENDOR.REGION_CODE,'') AS Region, 
                      ISNULL(JOB_PUB_VENDOR.JOB_PUB_DENSITY,'') AS Density, ISNULL(JOB_PUB_VENDOR.JOB_PUB_FILM,'') AS Film, ISNULL(JOB_PUB_VENDOR.JOB_PUB_SHIP_COMM,'') AS Shipping_Comments, 
                      ISNULL(JOB_PUB_VENDOR.JOB_PUB_SPCL_INST,'') AS Special_Instructions, JOB_PUB_VENDOR.SPEC_ID
FROM         JOB_PUB_VENDOR INNER JOIN
                      VENDOR ON JOB_PUB_VENDOR.VN_CODE = VENDOR.VN_CODE LEFT OUTER JOIN
                      AD_SIZE ON VENDOR.VN_CATEGORY = AD_SIZE.MEDIA_TYPE AND JOB_PUB_VENDOR.AD_SIZE = AD_SIZE.SIZE_CODE
WHERE     (JOB_PUB_VENDOR.JOB_NUMBER = @JobNumber) AND (JOB_PUB_VENDOR.JOB_COMPONENT_NBR = @JobCompNumber)
End
Else
if @VendorTab = 2
Begin
SELECT     ISNULL(JOB_OUTDOOR_VENDOR.VN_CODE,'') AS Vendor, ISNULL(JOB_OUTDOOR_VENDOR.AD_SIZE, '') AS AdSize, ISNULL(AD_SIZE.SIZE_DESC, '') AS Size_Desc, ISNULL(VENDOR.VN_NAME,'') AS Outdoor_Company,ISNULL( JOB_OUTDOOR_VENDOR.JOB_OUT_LOCATION,'') AS Location_of_Sign, 
                      ISNULL(JOB_OUTDOOR_VENDOR.JOB_OUT_OVR_SIZE,'') AS Overall_Size, ISNULL(JOB_OUTDOOR_VENDOR.JOB_OUT_COPY_AREA,'') AS Copy_Area, JOB_OUTDOOR_VENDOR.SPEC_ID
FROM         VENDOR INNER JOIN
                      JOB_OUTDOOR_VENDOR ON VENDOR.VN_CODE = JOB_OUTDOOR_VENDOR.VN_CODE LEFT OUTER JOIN
                      AD_SIZE ON VENDOR.VN_CATEGORY = AD_SIZE.MEDIA_TYPE AND JOB_OUTDOOR_VENDOR.AD_SIZE = AD_SIZE.SIZE_CODE
WHERE     (JOB_OUTDOOR_VENDOR.JOB_NUMBER = @JobNumber) AND (JOB_OUTDOOR_VENDOR.JOB_COMPONENT_NBR = @JobCompNumber)
End























