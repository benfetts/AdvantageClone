

CREATE PROCEDURE [dbo].[usp_wv_Vendor_Quote_GetVendorFunctions]
(
    @EstNo Int,
	@EstCompNo Int,
	@VendorQteNo Int,
	@Default int
)
AS
if @Default = 1
BEGIN
    SELECT  DISTINCT dbo.FUNCTIONS.FNC_CODE as Code, dbo.FUNCTIONS.FNC_DESCRIPTION as Description
    FROM         dbo.FUNCTIONS INNER JOIN
                          dbo.VENDOR ON dbo.FUNCTIONS.FNC_CODE = dbo.VENDOR.DEF_FNC_CODE INNER JOIN
                          dbo.VENDOR_QTE_VEN ON dbo.VENDOR.VN_CODE = dbo.VENDOR_QTE_VEN.VN_CODE
    WHERE     (dbo.VENDOR_QTE_VEN.ESTIMATE_NUMBER = @EstNo) AND (dbo.VENDOR_QTE_VEN.EST_COMPONENT_NBR = @EstCompNo) AND 
                          (dbo.VENDOR_QTE_VEN.VENDOR_QTE_NBR = @VendorQteNo) AND (FUNCTIONS.FNC_INACTIVE = 0 or FUNCTIONS.FNC_INACTIVE IS NULL)
END
ELSE
BEGIN
	SELECT FNC_CODE as Code, FNC_DESCRIPTION as Description
		FROM FUNCTIONS
		WHERE FNC_TYPE='V' AND (FNC_INACTIVE = 0 or FNC_INACTIVE IS NULL)
END




