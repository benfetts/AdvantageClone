CREATE PROCEDURE [dbo].[advsp_media_traffic_alert_comments]
	@MEDIA_TRAFFIC_VENDOR_IDs varchar(max)
AS

SELECT
	[MediaTrafficVendorID] = MTV.MEDIA_TRAFFIC_VENDOR_ID,
	[VendorCode] = MTV.VN_CODE,
	[CommentID] = AC.COMMENT_ID,
	[CommentDate] = AC.GENERATED_DATE,
	[Comment] = AC.COMMENT,
	[Name] = CASE
				WHEN SU.USER_CODE IS NOT NULL THEN (SELECT COALESCE(EMP_FNAME, '') + ' ' + CASE WHEN NULLIF(EMP_MI,'') IS NULL THEN '' ELSE EMP_MI + '. ' END + COALESCE(EMP_LNAME, '')
													FROM dbo.EMPLOYEE
													WHERE EMP_CODE = SU.EMP_CODE) 
				WHEN VR.VR_CODE IS NOT NULL THEN COALESCE(VR.VR_FNAME, '') + ' ' + CASE WHEN NULLIF(VR.VR_MI,'') IS NULL THEN '' ELSE VR.VR_MI + '. ' END + COALESCE(VR.VR_LNAME, '')
				WHEN VC.VC_CODE IS NOT NULL THEN COALESCE(VC.VC_FNAME, '') + ' ' + CASE WHEN NULLIF(VC.VC_MI,'') IS NULL THEN '' ELSE VC.VC_MI + '. ' END + COALESCE(VC.VC_LNAME, '')
				ELSE NULL
			 END,
	[Email] = CASE 
				WHEN VR.VR_CODE IS NOT NULL THEN VR.EMAIL_ADDRESS 
				WHEN VC.VC_CODE IS NOT NULL THEN VC.EMAIL_ADDRESS
				ELSE NULL END,
	[AlertID] = A.ALERT_ID,
	[VendorName] = V.VN_NAME
FROM dbo.MEDIA_TRAFFIC_VENDOR MTV
	INNER JOIN dbo.ALERT A ON MTV.ALERT_ID = A.ALERT_ID 
	INNER JOIN dbo.ALERT_COMMENT AC ON A.ALERT_ID = AC.ALERT_ID 
	INNER JOIN dbo.VENDOR V ON MTV.VN_CODE = V.VN_CODE
	LEFT OUTER JOIN dbo.VEN_REP VR ON AC.VR_CODE = VR.VR_CODE AND VR.VN_CODE = MTV.VN_CODE 
	LEFT OUTER JOIN dbo.VEN_CONT VC ON AC.VC_CODE = VC.VC_CODE AND VC.VN_CODE = MTV.VN_CODE 
	LEFT OUTER JOIN dbo.SEC_USER SU ON SU.USER_CODE = AC.USER_CODE
WHERE MEDIA_TRAFFIC_VENDOR_ID IN (SELECT items FROM dbo.udf_split_list(@MEDIA_TRAFFIC_VENDOR_IDs, ','))
GO
