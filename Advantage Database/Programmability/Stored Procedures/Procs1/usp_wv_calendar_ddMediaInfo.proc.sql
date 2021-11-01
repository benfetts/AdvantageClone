




CREATE PROCEDURE [dbo].[usp_wv_calendar_ddMediaInfo]
@VendorCode varchar(50),
@Type varchar(2)
AS


SELECT     DAILY_CIRC, SUNDAY_CIRC, CYCLE, ISSUES, PUB_FREQ, EDITIONS
FROM         VENDOR
WHERE      VN_CODE = @VendorCode
                                                  



