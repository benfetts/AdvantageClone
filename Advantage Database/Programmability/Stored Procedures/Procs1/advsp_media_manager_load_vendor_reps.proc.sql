CREATE PROCEDURE [dbo].[advsp_media_manager_load_vendor_reps]
	
	@VendorCode			varchar(6),
	@OrderNumber		int

AS

BEGIN
	
	SELECT
		VendorCode = vr.VN_CODE,
        VendorName = v.VN_NAME,
        Code = vr.VR_CODE,
        ContactType = ct.[DESCRIPTION],
        FirstName = vr.VR_FNAME,
        MiddleInitial = vr.VR_MI,
        LastName = vr.VR_LNAME,
        Email = vr.EMAIL_ADDRESS,
        Telephone = vr.VR_TELEPHONE,
        TelephoneExtension = vr.VR_EXTENTION,
        Fax = vr.VR_FAX,
        FaxExtension = vr.VR_FAX_EXTENTION,
        CellPhone = vr.VR_PHONE_CELL,
        IsInactive = CAST(COALESCE(vr.VR_INACTIVE_FLAG, 0) as bit),
		IsOrderRep1 = CAST(CASE WHEN vr.VR_CODE = oh.VR_CODE THEN 1 ELSE 0 END as bit),
		IsOrderRep2 = CAST(CASE WHEN vr.VR_CODE = oh.VR_CODE2 THEN 1 ELSE 0 END as bit)
	FROM dbo.VEN_REP vr
		INNER JOIN dbo.VENDOR v ON vr.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.CONTACT_TYPE ct ON vr.CONTACT_TYPE_ID = ct.CONTACT_TYPE_ID 
		LEFT OUTER JOIN dbo.VEN_REP_CLIENTS vrc ON vrc.VN_CODE = @VendorCode AND vrc.VR_CODE = vr.VR_CODE
		INNER JOIN (
					SELECT ORDER_NBR, VR_CODE, VR_CODE2, CL_CODE FROM dbo.INTERNET_HEADER 
					UNION
					SELECT ORDER_NBR, VR_CODE, VR_CODE2, CL_CODE FROM dbo.MAGAZINE_HEADER 
					UNION
					SELECT ORDER_NBR, VR_CODE, VR_CODE2, CL_CODE FROM dbo.NEWSPAPER_HEADER 
					UNION
					SELECT ORDER_NBR, VR_CODE, VR_CODE2, CL_CODE FROM dbo.OUTDOOR_HEADER 
					UNION
					SELECT ORDER_NBR, VR_CODE, VR_CODE2, CL_CODE FROM dbo.RADIO_HDR
					UNION
					SELECT ORDER_NBR, VR_CODE, VR_CODE2, CL_CODE FROM dbo.TV_HDR
					) oh ON oh.ORDER_NBR = @OrderNumber
	WHERE vr.VN_CODE = @VendorCode 
	AND (vrc.CL_CODE IS NULL OR vrc.CL_CODE = oh.CL_CODE OR vrc.VR_CODE = oh.VR_CODE OR vrc.VR_CODE = oh.VR_CODE2)

END
GO