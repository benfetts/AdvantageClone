CREATE VIEW [dbo].[V_CORE_MEDIA_CHECK_EXPORT]

AS

	SELECT
		[ID] = ISNULL(ROW_NUMBER() OVER(ORDER BY (SELECT 1)), 0),
		[CheckNumber] = P.AP_CHK_NBR, 
		[PayToVendorCode] = CR.PAY_TO_CODE, 
		[LinkID] = A.LINK_ID, 
		[CheckDate] = P.AP_CHK_DATE, 
		[CheckAmount] = SUM(P.AP_CHK_AMT),
		[InvoiceNumber] = AP.AP_INV_VCHR,
		[InvoiceDate] = AP.AP_INV_DATE
	FROM 
		(SELECT AP.AP_ID, TV.LINK_ID
		 FROM dbo.AP_TV AP INNER JOIN dbo.TV_HDR TV ON TV.ORDER_NBR = AP.ORDER_NBR
		 GROUP BY AP.AP_ID, TV.LINK_ID
		 HAVING TV.LINK_ID IS NOT NULL

		 UNION ALL

		 SELECT AP.AP_ID, R.LINK_ID
		 FROM dbo.AP_RADIO AP INNER JOIN dbo.RADIO_HDR R ON R.ORDER_NBR = AP.ORDER_NBR
		 GROUP BY AP.AP_ID, R.LINK_ID
		 HAVING R.LINK_ID IS NOT NULL) AS A INNER JOIN 
		dbo.AP_PMT_HIST AS P ON P.AP_ID = A.AP_ID INNER JOIN 
		dbo.AP_HEADER AS AP ON AP.AP_ID = P.AP_ID AND 
							   AP.AP_SEQ = P.AP_SEQ INNER JOIN 
		dbo.CHECK_REGISTER AS CR ON CR.BK_CODE = P.BK_CODE AND 
									CR.CHECK_NBR = P.AP_CHK_NBR
	WHERE
		CR.VOID_FLAG = 0 OR 
		CR.VOID_FLAG IS NULL
	GROUP BY 
		P.AP_CHK_NBR, 
		CR.PAY_TO_CODE, 
		A.LINK_ID, 
		P.AP_CHK_DATE,
		AP.AP_INV_VCHR,
		AP.AP_INV_DATE


