





CREATE PROCEDURE [dbo].[usp_wv_jobspecs_GetQtyVendorTab] 
@JobSpecType varchar(6)
AS


SELECT     SPEC_TYPE_CODE, USE_QTY, ISNULL(USE_VENDOR_TAB,0) AS USE_VENDOR_TAB, INACTIVE_FLAG
FROM         JOB_SPEC_TYPE
WHERE     SPEC_TYPE_CODE = @JobSpecType
























