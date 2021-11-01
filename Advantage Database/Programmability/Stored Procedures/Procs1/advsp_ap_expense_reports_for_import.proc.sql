CREATE PROC advsp_ap_expense_reports_for_import
	@office_code varchar(4) = NULL, @dp_tm_code varchar(4) = NULL
AS

SELECT	[InvoiceNumber] = H.INV_NBR, 
		[Status] = H.[STATUS]  
FROM dbo.EXPENSE_HEADER H
	INNER JOIN EMPLOYEE_CLOAK E ON H.EMP_CODE = E.EMP_CODE 
WHERE
	H.[STATUS] IN (1,3,4)
AND	(E.OFFICE_CODE = @office_code OR @office_code IS NULL)
AND	(E.DP_TM_CODE = @dp_tm_code OR @dp_tm_code IS NULL)
GO