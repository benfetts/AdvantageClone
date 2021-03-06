CREATE PROC [dbo].[advsp_ap_disbursed_amounts_by_glaccount] @vendor_pay_to_code varchar(6), @check_start_date smalldatetime, @check_end_date smalldatetime

AS

DECLARE @IDS TABLE (
	AP_ID int NOT NULL
)

INSERT @IDS
SELECT	DISTINCT P.AP_ID 
FROM dbo.AP_PMT_HIST P
	INNER JOIN dbo.CHECK_REGISTER C ON P.BK_CODE = C.BK_CODE AND P.AP_CHK_NBR = C.CHECK_NBR AND (C.VOID_FLAG IS NULL OR C.VOID_FLAG = 0)
	INNER JOIN (SELECT AP_ID FROM dbo.AP_HEADER
				WHERE FLAG_1099 = 1
				AND (DELETE_FLAG IS NULL OR DELETE_FLAG = 0)
				AND (MODIFY_FLAG IS NULL OR MODIFY_FLAG = 0)
				) AP ON P.AP_ID = AP.AP_ID 
WHERE	C.PAY_TO_CODE = @vendor_pay_to_code 
AND		P.AP_CHK_DATE between @check_start_date AND @check_end_date 

SELECT	[DetailGLAccount] = APTOTALS.GLACODE + ' - ' + GLA.GLADESC,
		[DisbursedAmount] = COALESCE(SUM(TOTAL_AMT), 0)
FROM (
	SELECT GLACODE, SUM(AP_GL_AMT) AS TOTAL_AMT
	FROM dbo.AP_GL_DIST
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE

	UNION

	SELECT GLACODE, SUM(AP_PROD_EXT_AMT + EXT_NONRESALE_TAX) AS TOTAL_AMT
	FROM dbo.AP_PRODUCTION 
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE

	UNION

	SELECT GLACODE, SUM(NET_AMT + NETCHARGES + VENDOR_TAX + DISCOUNT_AMT) AS TOTAL_AMT
	FROM dbo.AP_INTERNET 
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE

	UNION

	SELECT GLACODE, SUM(NET_AMT + BLEED_NET_AMT + POSITION_NET_AMT + PREMIUM_NET_AMT + COLOR_NET_AMT + DISCOUNT_LN + NETCHARGES + VENDOR_TAX) AS TOTAL_AMT
	FROM dbo.AP_MAGAZINE 
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE

	UNION

	SELECT GLACODE, SUM(NET_AMT + DISCOUNT_LN + NETCHARGES + VENDOR_TAX) AS TOTAL_AMT
	FROM dbo.AP_NEWSPAPER 
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE

	UNION

	SELECT GLACODE, SUM(NET_AMT + DISCOUNT_AMT + NETCHARGES + VENDOR_TAX) AS TOTAL_AMT
	FROM dbo.AP_OUTDOOR 
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE

	UNION

	SELECT GLACODE, SUM(EXT_NET_AMT + DISC_AMT + NETCHARGES + VENDOR_TAX) AS TOTAL_AMT
	FROM dbo.AP_RADIO  
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE

	UNION

	SELECT GLACODE, SUM(EXT_NET_AMT + DISC_AMT + NETCHARGES + VENDOR_TAX) AS TOTAL_AMT
	FROM dbo.AP_TV 
	WHERE AP_ID IN (SELECT AP_ID FROM @IDS)
	AND (MODIFY_DELETE IS NULL OR MODIFY_DELETE = 0)
	GROUP BY GLACODE) APTOTALS
		LEFT OUTER JOIN dbo.GLACCOUNT GLA ON APTOTALS.GLACODE = GLA.GLACODE
GROUP BY APTOTALS.GLACODE,  GLA.GLADESC

GO
