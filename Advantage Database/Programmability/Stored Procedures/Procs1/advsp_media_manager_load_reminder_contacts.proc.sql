CREATE PROC [advsp_media_manager_load_reminder_contacts]
	@OrderNumberLineNumberList varchar(max),
	@PONumberList varchar(max)
AS

BEGIN

	SELECT DISTINCT
		[VendorCode] = si.VN_CODE,
		[VendorName] = v.VN_NAME,
		[VendorRepCode] = si.VR_CODE,
		[ContactName] = COALESCE((rtrim(VR_FNAME) + ' '),'') + COALESCE(VR_LNAME,''),
		[ContactType] = ct.[DESCRIPTION],
		[EmailAddress] = si.EMAIL
	FROM dbo.MEDIA_MGR_GENERATED_REPORT r
		INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL d ON r.MEDIA_MGR_GENERATED_REPORT_ID = d.MEDIA_MGR_GENERATED_REPORT_ID 
		INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_SENT_INFO si ON r.MEDIA_MGR_GENERATED_REPORT_ID = si.MEDIA_MGR_GENERATED_REPORT_ID 
		INNER JOIN dbo.VENDOR v ON si.VN_CODE = v.VN_CODE
		INNER JOIN dbo.VEN_REP vr ON si.VN_CODE = vr.VN_CODE AND si.VR_CODE = vr.VR_CODE 
		LEFT OUTER JOIN dbo.CONTACT_TYPE ct ON vr.CONTACT_TYPE_ID = ct.CONTACT_TYPE_ID 
	WHERE CAST(r.ORDER_NBR AS varchar(20)) + '|' + CAST(d.LINE_NBR AS varchar(20)) IN (SELECT * FROM dbo.udf_split_list(@OrderNumberLineNumberList, ','))
	AND IS_QUOTE = 0

	UNION
	
	SELECT DISTINCT
		[VendorCode] = po.VN_CODE,
		[VendorName] = v.VN_NAME,
		[VendorRepCode] = r.VC_CODE,
		[ContactName] = COALESCE((rtrim(VC_FNAME) + ' '),'') + COALESCE(VC_LNAME,''),
		[ContactType] = ct.[DESCRIPTION],
		[EmailAddress] = r.EMAIL
	FROM dbo.MEDIA_MGR_GENERATED_PO_REPORT r
		INNER JOIN dbo.PURCHASE_ORDER po ON r.PO_NUMBER = po.PO_NUMBER 
		INNER JOIN dbo.VENDOR v ON po.VN_CODE = v.VN_CODE
		LEFT OUTER JOIN dbo.VEN_CONT vc ON v.VN_CODE = vc.VN_CODE AND r.VC_CODE = vc.VC_CODE 
		LEFT OUTER JOIN dbo.CONTACT_TYPE ct ON vc.CONTACT_TYPE_ID = ct.CONTACT_TYPE_ID 
	WHERE CAST(r.PO_NUMBER as varchar) IN (SELECT * FROM dbo.udf_split_list(@PONumberList, ','))
	
END
GO