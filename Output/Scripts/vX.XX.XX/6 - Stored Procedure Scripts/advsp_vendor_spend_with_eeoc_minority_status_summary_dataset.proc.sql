CREATE PROCEDURE [dbo].[advsp_vendor_spend_with_eeoc_minority_status_summary_dataset]
	@START_POST_PERIOD varchar(6), @END_POST_PERIOD varchar(6)
AS

SELECT
	ID = NEWID(),
	VendorCode = V.VN_CODE,
	VendorName = V.VN_NAME,
	[Address] = V.VN_ADDRESS1,
	City = V.VN_CITY,
	County = V.VN_COUNTY,
	[State] = V.VN_STATE,
	ZipCode = V.VN_ZIP,
	Country = V.VN_COUNTRY,
	HUBZ = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'HZSB') THEN 'Y' ELSE 'N' END,
	[IO] = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'I') THEN 'Y' ELSE 'N' END,
	LGBT = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'LGBT') THEN 'Y' ELSE 'N' END,
	MBE = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'MO') THEN 'Y' ELSE 'N' END,
	MISC1 = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'MISC1') THEN 'Y' ELSE 'N' END,
	MISC2 = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'MISC2') THEN 'Y' ELSE 'N' END,
	MISC3 = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'MISC3') THEN 'Y' ELSE 'N' END,
	NA = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'N') THEN 'Y' ELSE 'N' END,
	OT = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'OT') THEN 'Y' ELSE 'N' END,
	OTS = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'O') THEN 'Y' ELSE 'N' END,
	SB = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'SB') THEN 'Y' ELSE 'N' END,
	SDB = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'SDB') THEN 'Y' ELSE 'N' END,
	VET = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'VOSB') THEN 'Y' ELSE 'N' END,
	WBE = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'WOB') THEN 'Y' ELSE 'N' END,
	WBS = CASE WHEN EXISTS(SELECT 1 FROM EEOC_STATUS WHERE VENDOR = V.VN_CODE AND EEOC_CODE = 'WOSB') THEN 'Y' ELSE 'N' END,
	Ethnicity = VEE.[DESCRIPTION],
	NMSDC = CASE WHEN E.IS_NMSDC = 1 THEN 'Y' ELSE 'N' END,
	NMSDCCertificationNumber = E.MINORITY_CERTIFICATE_NUMBER,
	NMSDCExpirationDate = E.MINORITY_CERTIFICATE_NUMBER_EXP_DATE,
	WBENC = CASE WHEN E.IS_WBENC = 1 THEN 'Y' ELSE 'N' END,
	WBENCCertificationNumber = E.WBENC_CERTIFICATE_NUMBER,
	WBENCExpirationDate = E.WBENC_CERTIFICATE_NUMBER_EXP_DATE,
	TotalSpend = AP.TotalSpend 
FROM
	(
		SELECT VN_FRL_EMP_CODE as VN_CODE, SUM(AP.AP_INV_AMT + COALESCE(AP.AP_SHIPPING,0) + COALESCE(AP.AP_SALES_TAX,0)) AS TotalSpend
		FROM dbo.AP_HEADER AP
		WHERE POST_PERIOD BETWEEN @START_POST_PERIOD AND @END_POST_PERIOD
        AND COALESCE(MODIFY_FLAG,0) = 0
		AND COALESCE(DELETE_FLAG,0) = 0
        AND EXISTS (SELECT 1 FROM dbo.EEOC_STATUS ES WHERE ES.VENDOR = AP.VN_FRL_EMP_CODE)
		GROUP BY VN_FRL_EMP_CODE
	) AP
		INNER JOIN dbo.VENDOR V ON AP.VN_CODE = V.VN_CODE
		LEFT OUTER JOIN dbo.VENDOR_EEOC2 E ON V.VN_CODE = E.VN_CODE 
		LEFT OUTER JOIN dbo.VENDOR_EEOC2_ETHNICITY VEE ON E.ETHNICITY_ID = VEE.ID
GO
