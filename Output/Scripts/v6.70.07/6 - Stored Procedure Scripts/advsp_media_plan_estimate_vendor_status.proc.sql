CREATE PROCEDURE [dbo].[advsp_media_plan_estimate_vendor_status]
	@MEDIA_PLAN_DTL_ID int
AS
BEGIN

	DECLARE @MEDIA_TYPE_CODE char(1)

	SELECT 
		@MEDIA_TYPE_CODE = MPD.SC_TYPE 
	FROM 
		[dbo].[MEDIA_PLAN_DTL] MPD
	WHERE 
		MPD.MEDIA_PLAN_DTL_ID = @MEDIA_PLAN_DTL_ID

	IF @MEDIA_TYPE_CODE = 'T' BEGIN

		SELECT 
			DISTINCT
			MediaPlanEstimateID = MPDLLD.MEDIA_PLAN_DTL_ID,
			VendorCode = V.VN_CODE,
			VendorName = V.VN_NAME,
			OrderNumber = H.ORDER_NBR,
			CreateDate = H.CREATE_DATE,
			LastStatusDate = (SELECT TOP 1 OOS.REVISED_DATE FROM dbo.TV_ORDER_STATUS OOS WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY REVISED_DATE DESC),
			[Status] = (SELECT TOP 1 OS.STATUS_DESC FROM dbo.TV_ORDER_STATUS OOS INNER JOIN dbo.ORDER_STATUS OS ON OOS.[STATUS] = OS.[STATUS] WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC)
		FROM 
			[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] MPDLLD
			INNER JOIN [dbo].[TV_HDR] H ON MPDLLD.ORDER_NBR = H.ORDER_NBR 
			INNER JOIN [dbo].[VENDOR] V ON H.VN_CODE = V.VN_CODE
		WHERE 
			MPDLLD.MEDIA_PLAN_DTL_ID = @MEDIA_PLAN_DTL_ID

	END ELSE IF @MEDIA_TYPE_CODE = 'R' BEGIN

		SELECT 
			DISTINCT
			MediaPlanEstimateID = MPDLLD.MEDIA_PLAN_DTL_ID,
			VendorCode = V.VN_CODE,
			VendorName = V.VN_NAME,
			OrderNumber = H.ORDER_NBR,
			CreateDate = H.CREATE_DATE,
			LastStatusDate = (SELECT TOP 1 OOS.REVISED_DATE FROM dbo.RADIO_ORDER_STATUS OOS WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC),
			[Status] = (SELECT TOP 1 OS.STATUS_DESC FROM dbo.RADIO_ORDER_STATUS OOS INNER JOIN dbo.ORDER_STATUS OS ON OOS.[STATUS] = OS.[STATUS] WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC)
		FROM 
			[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] MPDLLD
			INNER JOIN [dbo].[RADIO_HDR] H ON MPDLLD.ORDER_NBR = H.ORDER_NBR 
			INNER JOIN [dbo].[VENDOR] V ON H.VN_CODE = V.VN_CODE
		WHERE 
			MPDLLD.MEDIA_PLAN_DTL_ID = @MEDIA_PLAN_DTL_ID

	END ELSE IF @MEDIA_TYPE_CODE = 'M' BEGIN

		SELECT 
			DISTINCT
			MediaPlanEstimateID = MPDLLD.MEDIA_PLAN_DTL_ID,
			VendorCode = V.VN_CODE,
			VendorName = V.VN_NAME,
			OrderNumber = H.ORDER_NBR,
			CreateDate = H.CREATE_DATE,
			LastStatusDate = (SELECT TOP 1 OOS.REVISED_DATE FROM dbo.MAGAZINE_ORDER_STATUS OOS WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC),
			[Status] = (SELECT TOP 1 OS.STATUS_DESC FROM dbo.MAGAZINE_ORDER_STATUS OOS INNER JOIN dbo.ORDER_STATUS OS ON OOS.[STATUS] = OS.[STATUS] WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC)
		FROM 
			[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] MPDLLD
			INNER JOIN [dbo].[MAGAZINE_HEADER] H ON MPDLLD.ORDER_NBR = H.ORDER_NBR 
			INNER JOIN [dbo].[VENDOR] V ON H.VN_CODE = V.VN_CODE
		WHERE 
			MPDLLD.MEDIA_PLAN_DTL_ID = @MEDIA_PLAN_DTL_ID
			
	END ELSE IF @MEDIA_TYPE_CODE = 'N' BEGIN

		SELECT 
			DISTINCT
			MediaPlanEstimateID = MPDLLD.MEDIA_PLAN_DTL_ID,
			VendorCode = V.VN_CODE,
			VendorName = V.VN_NAME,
			OrderNumber = H.ORDER_NBR,
			CreateDate = H.CREATE_DATE,
			LastStatusDate = (SELECT TOP 1 OOS.REVISED_DATE FROM dbo.NEWSPAPER_ORDER_STATUS OOS WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC),
			[Status] = (SELECT TOP 1 OS.STATUS_DESC FROM dbo.NEWSPAPER_ORDER_STATUS OOS INNER JOIN dbo.ORDER_STATUS OS ON OOS.[STATUS] = OS.[STATUS] WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC)
		FROM 
			[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] MPDLLD
			INNER JOIN [dbo].[NEWSPAPER_HEADER] H ON MPDLLD.ORDER_NBR = H.ORDER_NBR 
			INNER JOIN [dbo].[VENDOR] V ON H.VN_CODE = V.VN_CODE
		WHERE 
			MPDLLD.MEDIA_PLAN_DTL_ID = @MEDIA_PLAN_DTL_ID
			
	END ELSE IF @MEDIA_TYPE_CODE = 'I' BEGIN

		SELECT 
			DISTINCT
			MediaPlanEstimateID = MPDLLD.MEDIA_PLAN_DTL_ID,
			VendorCode = V.VN_CODE,
			VendorName = V.VN_NAME,
			OrderNumber = H.ORDER_NBR,
			CreateDate = H.CREATE_DATE,
			LastStatusDate = (SELECT TOP 1 OOS.REVISED_DATE FROM dbo.INTERNET_ORDER_STATUS OOS WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC),
			[Status] = (SELECT TOP 1 OS.STATUS_DESC FROM dbo.INTERNET_ORDER_STATUS OOS INNER JOIN dbo.ORDER_STATUS OS ON OOS.[STATUS] = OS.[STATUS] WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC)
		FROM 
			[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] MPDLLD
			INNER JOIN [dbo].[INTERNET_HEADER] H ON MPDLLD.ORDER_NBR = H.ORDER_NBR 
			INNER JOIN [dbo].[VENDOR] V ON H.VN_CODE = V.VN_CODE
		WHERE 
			MPDLLD.MEDIA_PLAN_DTL_ID = @MEDIA_PLAN_DTL_ID
			
	END ELSE IF @MEDIA_TYPE_CODE = 'O' BEGIN

		SELECT 
			DISTINCT
			MediaPlanEstimateID = MPDLLD.MEDIA_PLAN_DTL_ID,
			VendorCode = V.VN_CODE,
			VendorName = V.VN_NAME,
			OrderNumber = H.ORDER_NBR,
			CreateDate = H.CREATE_DATE,
			LastStatusDate = (SELECT TOP 1 OOS.REVISED_DATE FROM dbo.OUTDOOR_ORDER_STATUS OOS WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC),
			[Status] = (SELECT TOP 1 OS.STATUS_DESC FROM dbo.OUTDOOR_ORDER_STATUS OOS INNER JOIN dbo.ORDER_STATUS OS ON OOS.[STATUS] = OS.[STATUS] WHERE MPDLLD.ORDER_NBR = OOS.ORDER_NBR ORDER BY OOS.REVISED_DATE DESC)
		FROM 
			[dbo].[MEDIA_PLAN_DTL_LEVEL_LINE_DATA] MPDLLD
			INNER JOIN [dbo].[OUTDOOR_HEADER] H ON MPDLLD.ORDER_NBR = H.ORDER_NBR 
			INNER JOIN [dbo].[VENDOR] V ON H.VN_CODE = V.VN_CODE
		WHERE 
			MPDLLD.MEDIA_PLAN_DTL_ID = @MEDIA_PLAN_DTL_ID

	END

END
GO