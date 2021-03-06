





CREATE PROCEDURE [dbo].[usp_wv_calendar_ddMediaSpecs]
@VendorCode varchar(50),
@Type varchar(2)
AS


SELECT    MEDIA_SPECS_HDR.AD_SIZE, ISNULL(MEDIA_SPECS_DTL.SPEC_DATA, '') AS DATA, AD_SIZE.SIZE_DESC, 
                      AD_SIZE_LABEL.LABEL_SEQ, AD_SIZE_LABEL.LABEL_DESC
FROM      MEDIA_SPECS_DTL INNER JOIN
                      MEDIA_SPECS_HDR ON MEDIA_SPECS_DTL.SPEC_ID = MEDIA_SPECS_HDR.SPEC_ID INNER JOIN
                      AD_SIZE ON MEDIA_SPECS_HDR.AD_SIZE = AD_SIZE.SIZE_CODE INNER JOIN
                      AD_SIZE_LABEL ON MEDIA_SPECS_DTL.MEDIA_TYPE = AD_SIZE_LABEL.MEDIA_TYPE AND 
                      MEDIA_SPECS_DTL.LABEL_ID = AD_SIZE_LABEL.LABEL_ID
WHERE     AD_SIZE_LABEL.INACTIVE_FLAG <> 1 AND MEDIA_SPECS_HDR.VN_CODE = @VendorCode AND MEDIA_SPECS_DTL.MEDIA_TYPE = @Type                                                 
ORDER BY  MEDIA_SPECS_HDR.SPEC_ID, AD_SIZE_LABEL.LABEL_SEQ



