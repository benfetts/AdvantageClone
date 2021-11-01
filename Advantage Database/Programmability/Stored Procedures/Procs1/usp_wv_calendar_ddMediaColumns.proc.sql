





CREATE PROCEDURE [dbo].[usp_wv_calendar_ddMediaColumns]
@VendorCode varchar(50),
@Type varchar(2)
AS


SELECT     LABEL_SEQ, LABEL_DESC, INACTIVE_FLAG
FROM         AD_SIZE_LABEL
WHERE INACTIVE_FLAG <> 1 AND MEDIA_TYPE = @Type
ORDER BY LABEL_SEQ



