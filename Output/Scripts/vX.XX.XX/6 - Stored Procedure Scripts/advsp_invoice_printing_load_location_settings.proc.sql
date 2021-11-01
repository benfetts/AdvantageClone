CREATE PROCEDURE [dbo].[advsp_invoice_printing_load_location_settings] ( 
	@LocationCode AS varchar(6)
)
AS
BEGIN

	SELECT 
		[LocationCode] = L.LOC_ID,
		[PageHeaderComment] = CASE WHEN L.PRT_HDR = 1 THEN L.LOC_HDR ELSE '' END,
		[PageFooterComment] = CASE WHEN L.PRT_FTR = 1 THEN L.LOC_FTR ELSE '' END,
		[PageHeaderLogoPath] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH ELSE '' END,
		[PageHeaderLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION = 'C' THEN L.DFLT_LOGO_PATH_LAND ELSE '' END,
		[PageFooterLogoPath] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_2 ELSE '' END,
		[PageFooterLogoPathLandscape] = CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN L.DFLT_LOGO_PATH_LAND_2 ELSE '' END,
		[ShowPageHeaderLogo] = CAST(CASE WHEN L.LOGO_LOCATION = 'C' THEN 1 ELSE 0 END AS bit),
		[ShowPageFooterLogo] = CAST(CASE WHEN L.LOGO_LOCATION_2 = 'C' THEN 1 ELSE 0 END AS bit)
	FROM 
		[dbo].[advtf_location_query]() AS L
	WHERE
		L.LOC_ID = @LocationCode

END
GO