


















CREATE PROCEDURE [dbo].[usp_wv_dd_GetAPInvoices]
@Vendor as Varchar(6)
AS

Select Distinct AP_INV_VCHR as Code, AP_INV_VCHR + ' - ' + 
CASE WHEN AP_DESC IS NULL THEN CONVERT(CHAR(10), AP_INV_DATE, 101) ELSE AP_DESC + ' - ' + CONVERT(CHAR(10), AP_INV_DATE, 101) END as Description,
AP_INV_DATE
from AP_HEADER
WHERE VN_FRL_EMP_CODE = @Vendor AND ((DELETE_FLAG = 0) OR (DELETE_FLAG IS NULL))
ORDER BY AP_INV_DATE DESC, AP_INV_VCHR
















