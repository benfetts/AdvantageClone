CREATE PROCEDURE advsp_ap_production_calc_po_balance_excluding_ap_id @PONumber int, @POLine int, @AP_ID int

AS 

SELECT
		[POBalance] = SUM(COALESCE(D.PO_EXT_AMOUNT,0)) - SUM(COALESCE(A.AP_PROD_EXT_AMT, 0))
FROM
	[dbo].PURCHASE_ORDER_DET D
	LEFT OUTER JOIN [dbo].AP_PRODUCTION A ON D.PO_NUMBER = A.PO_NUMBER AND D.LINE_NUMBER = A.PO_LINE_NUMBER AND	(A.MODIFY_DELETE IS NULL OR A.MODIFY_DELETE=0) AND A.AP_ID <> @AP_ID
WHERE
		D.PO_NUMBER = @PONumber
AND		D.LINE_NUMBER = @POLine
GO